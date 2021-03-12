using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using ExanimaResrouceSdk;

using Xunit;

namespace ExanimaResrouceSdkTests {
    public class UnPackerTests {
        private const string RPK_FILE = "..\\..\\..\\TestData\\Sound.rpk";

        [Fact]
        public void VerifyRpkHeader() {
            var resourcePacker = new ResourceFilePacker(RPK_FILE);
            Assert.True(resourcePacker.IsRpkPackedFile());
            Assert.True(resourcePacker.IsRpkPackedFile());
        }

        [Fact]
        public void TestReadFileCount() {
            var resourcePacker = new ResourceFilePacker(RPK_FILE);
            _ = resourcePacker.GetFileCount();
        }

        [Fact]
        public void TestReadFiles() {
            var resourcePacker = new ResourceFilePacker(RPK_FILE);
            var fileNames = resourcePacker.GetPackedFiles();
            Trace.WriteLine(string.Join("\n", fileNames
                .Select(i => $"{i.name} -> Size: {i.size}, Address: {i.location}")));
        }

        [Fact]
        public void UnpackAllFiles() {
            var resourcePacker = new ResourceFilePacker(RPK_FILE);
            var packedFileInfos = resourcePacker.GetPackedFiles();

            var unpacDir = "unpacked";
            if (!Directory.Exists(unpacDir)) {
                Directory.CreateDirectory(unpacDir);
            }
            var unpackedFiles = resourcePacker.UnpackFiles(packedFileInfos, $"{unpacDir}");
            var sizeCorrectedFiles = ResourceFilePacker.UpdatePackedFileData(unpackedFiles);

            Assert.True(sizeCorrectedFiles.Select(i => i.size)
                .SequenceEqual(unpackedFiles.Select(i => i.size)));

            Assert.True(unpackedFiles.All(i => i.coldStorageLocation != default));

            var newPackedFile = "..\\..\\..\\TestData\\Sound_ManualEdits.rpk";
            ResourceFilePacker.PackFile(unpackedFiles, newPackedFile);
            Directory.Delete(unpacDir, true);

            var originalFileInfo = new FileInfo(RPK_FILE);
            var myPackedFileInfo = new FileInfo(newPackedFile);
            Assert.Equal(originalFileInfo.Length, myPackedFileInfo.Length);

        }
    }
}
