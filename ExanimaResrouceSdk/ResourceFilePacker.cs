using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ExanimaResrouceSdk {
    public class ResourceFilePacker : IDisposable {
        private readonly string _gameFile;
        private readonly FileStream _gameFileData;

        public ResourceFilePacker(string gameFile) {
            _gameFile = gameFile;
            _gameFileData = File.OpenRead(_gameFile);
        }

        ~ResourceFilePacker() {
            _gameFileData.Dispose();
        }

        public PackedFileInfo[] UnpackFiles(PackedFileInfo[] filesToUnpack, string destinationFolder) {
            foreach (var packedFileInfo in filesToUnpack) {
                packedFileInfo.coldStorageLocation = $"{destinationFolder}\\{packedFileInfo.name}.{GetFileType(packedFileInfo)}";
                File.WriteAllBytes(packedFileInfo.coldStorageLocation, ReadFile(packedFileInfo));
            }
            return filesToUnpack;
        }

        public byte[] ReadFile(PackedFileInfo packedFileInfo) {
            _gameFileData.Seek(packedFileInfo.location + 8, SeekOrigin.Begin);
            var buffer = new byte[packedFileInfo.size];
            _gameFileData.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        public PackedFileInfo[] GetPackedFiles() {
            var fileReader = new BinaryReader(_gameFileData);

            // File names start 64 bits from the header.
            fileReader.BaseStream.Seek(8, SeekOrigin.Begin);

            var fileCount = GetFileCount();
            var dataAddress = GetDataAddress();

            var packedFiles = new PackedFileInfo[fileCount];
            for (var x = 0u; x < fileCount; x++) {
                var fileName = Encoding.UTF8.GetString(fileReader.ReadBytes(16)).Split('\0')[0]
                    ?? throw new Exception("Invalid String");

                var fileOffset = fileReader.ReadUInt32();
                var fileSize = fileReader.ReadUInt32();
                fileReader.BaseStream.Position += 8;

                packedFiles[x] = new PackedFileInfo() {
                    name = fileName,
                    size = fileSize,
                    dataStartOffset = fileOffset,
                    location = fileOffset + dataAddress
                };
            }

            for (var x = 0; x < fileCount; x++) {
                packedFiles[x].extension = GetFileType(packedFiles[x]);
            }

            return packedFiles;
        }

        public uint GetFileCount() {
            return GetDataAddress() / 32;
        }

        public uint GetDataAddress() {
            var returnTo = _gameFileData.Position;

            var buffer = new byte[4];
            _gameFileData.Seek(4, SeekOrigin.Begin);
            _gameFileData.Read(buffer, 0, buffer.Length);

            _gameFileData.Position = returnTo;
            return BitConverter.ToUInt32(buffer.ToArray(), 0);
        }

        public bool IsRpkPackedFile() {
            var returnTo = _gameFileData.Position;

            var buffer = new byte[4];
            _gameFileData.Seek(0, SeekOrigin.Begin);
            _gameFileData.Read(buffer, 0, buffer.Length);

            _gameFileData.Position = returnTo;
            return buffer.SequenceEqual(FileHeaders.RpkHeader);
        }

        private string GetFileType(PackedFileInfo packedFileInfo) {
            var returnTo = _gameFileData.Position;

            var buffer = new byte[8];
            _gameFileData.Position = packedFileInfo.location + 8;
            _gameFileData.Read(buffer, 0, buffer.Length);

            if (buffer.Take(4).SequenceEqual(FileHeaders.Wave)) {
                return "wav";
            }

            if (buffer.Take(4).SequenceEqual(FileHeaders.Texture)) {
                return "dds";
            }

            _gameFileData.Position = returnTo;
            return default;
        }

        public static void PackFile(PackedFileInfo[] packedFiles, string packFileLocation) {

            var updatedPackedFiles = UpdatePackedFileData(packedFiles);
            using (var fileStream = new BinaryWriter(File.Open(packFileLocation, FileMode.Create))) {
                var dataRegionSize = 0u;
                var dataBlockStart = (updatedPackedFiles.Length * 32) + 8;

                fileStream.BaseStream.Position = dataBlockStart;
                foreach (var file in updatedPackedFiles) {
                    file.dataStartOffset = dataRegionSize;
                    dataRegionSize += WriteFile(fileStream, file);
                }

                fileStream.BaseStream.Position = 0;
                fileStream.Write(FileHeaders.RpkHeader);
                fileStream.Write((uint)(updatedPackedFiles.Length * 32));
                foreach (var file in updatedPackedFiles) {
                    var nameBuffer = new byte[16];
                    var nameBytes = Encoding.UTF8.GetBytes(file.name);
                    Array.Copy(nameBytes, nameBuffer, nameBytes.Length);

                    fileStream.Write(nameBuffer);
                    fileStream.Write(file.dataStartOffset);
                    fileStream.Write(file.size);

                    // File alignment.
                    fileStream.Write(0ul);
                }
            }
        }

        private static uint WriteFile(BinaryWriter fileStream, PackedFileInfo file) {
            // fileStream.Write(file.gameId);
            if (file.coldStorageLocation == default) {
                throw new Exception("Could not find file to pack.");
            }

            var fileBytes = File.ReadAllBytes(file.coldStorageLocation);
            fileStream.Write(fileBytes);
            return (uint)fileBytes.Length;
        }

        public static PackedFileInfo[] UpdatePackedFileData(PackedFileInfo[] packedFiles) {
            foreach (var packedFile in packedFiles) {
                if (packedFile.coldStorageLocation != default) {
                    var fileInfo = new FileInfo(packedFile.coldStorageLocation);
                    packedFile.size = (uint)fileInfo.Length;
                    packedFile.dataStartOffset = 0;
                }
            }
            return packedFiles;
        }

        public void Dispose() {
            _gameFileData.Dispose();
        }
    }
}