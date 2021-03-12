using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExanimaResrouceSdk;

namespace ExanimaResourceEditor {
    public partial class ResrouceEditorInterface : Form {
        private const string UNPACK_DIRECTORY = "tempUnpackFolder";
        private readonly string _resrouceFile;
        private readonly Regex[] _regexIgnoreStrings;

        private ResourceFilePacker _resourcePacker;
        private PackedFileInfo _selectedPackedFile;
        private PackedFileInfo[] _packedFiles;

        public ResrouceEditorInterface(string resrouceFile) {
            var regexFile = "ignore.reg";
            if (File.Exists(regexFile)) {
                var regexLines = File.ReadAllLines(regexFile);
                _regexIgnoreStrings = regexLines.Select(i => new Regex(i)).ToArray();
            }

            _resrouceFile = resrouceFile;
            InitializeComponent();

            _resourcePacker = new ResourceFilePacker(_resrouceFile);
        }

        ~ResrouceEditorInterface() {
            if (Directory.Exists(UNPACK_DIRECTORY)) {
                Directory.Delete(UNPACK_DIRECTORY, true);
            }
        }

        private void ResrouceEditorInterface_Load(object sender, EventArgs e) {
            _packedFiles = _resourcePacker.GetPackedFiles();
            packedFilesListView.Items.Clear();
            packedFilesListView.Items.AddRange(_packedFiles.Select(i => i.name).ToArray());
            packedFilesCountStatusLabel.Text = $"Packed Files: {_packedFiles.Length}";
        }

        private void SelectedPackedFiledChanged(object sender, EventArgs e) {
            var selctedFileName = (string)packedFilesListView.SelectedItem;
            _selectedPackedFile = _packedFiles.Single(i => i.name == selctedFileName);

            packedFileNameLabel.Text = $"Packed File: {_selectedPackedFile.name}";
            packedFileOffsetLabel.Text = $"Packed File Offset: {_selectedPackedFile.location}";
            packedFileTypeLabel.Text = $"Packed File Type: {_selectedPackedFile.extension}";
            packedFileSizeLabel.Text = $"Packed File Size: {_selectedPackedFile.size / 10} Kb";

            selectedFileStatusLabel.Text = $"Selected File: {_selectedPackedFile.name}";
        }

        private void SavePackedFileClicked(object sender, EventArgs e) {
            var fileType = _selectedPackedFile.extension;
            var dialog = new SaveFileDialog {
                Filter = $"{fileType} files|*.{fileType}"
            };

            if (dialog.ShowDialog() == DialogResult.OK) {
                var fileData = _resourcePacker.ReadFile(_selectedPackedFile);
                File.WriteAllBytes(dialog.FileName, fileData);
            }
        }

        private void UnpackAllFilesClicked(object sender, EventArgs e) {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                var runningTask = Task.Run(() => _resourcePacker.UnpackFiles(_packedFiles, dialog.SelectedPath));
                var loadingIndicator = new LoadingIndicator("Unpacking Files...", runningTask);
                loadingIndicator.ShowDialog();
            }
        }

        private void RepackButtonClicked(object sender, EventArgs e) {
            _resourcePacker.Dispose();
            var runningTask = Task.Run(() => ResourceFilePacker.PackFile(_packedFiles, _resrouceFile));
            var loadingIndicator = new LoadingIndicator($"Packing Files... '{_resrouceFile}'", runningTask);
            loadingIndicator.ShowDialog();

            _resourcePacker = new ResourceFilePacker(_resrouceFile);
            Directory.Delete(UNPACK_DIRECTORY, true);

            repackButton.Enabled = false;
        }

        private void EditPackedFileClicked(object sender, EventArgs e) {
            if (packedFilesListView.SelectedItem is null) {
                MessageBox.Show("Please select an item to edit.");
                return;
            }

            if (!SetupEditor()) {
                return;
            }

            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK) {
                var selectedFile = _packedFiles.Single(i =>
                     i.name == (string)packedFilesListView.SelectedItem);

                var fileData = File.ReadAllBytes(openFile.FileName);
                var fileExt = selectedFile.extension;
                fileExt = fileExt != "" ? $".{fileExt}" : "";

                File.WriteAllBytes($"{UNPACK_DIRECTORY}{Path.DirectorySeparatorChar}{selectedFile.name}{fileExt}", fileData);
                _packedFiles = ResourceFilePacker.UpdatePackedFileData(_packedFiles);
            }

            SelectedPackedFiledChanged(default, default);
        }

        private bool SetupEditor() {
            if (repackButton.Enabled) {
                return true;
            }

            var messageBoxResult = MessageBox.Show(this,
                "This will unpack all the files from the rpk onto the running drive. Would you like to continue?",
                "Warning Unpacking Files",
                MessageBoxButtons.YesNo);

            if (messageBoxResult != DialogResult.Yes) {
                return false;
            }

            if (!Directory.Exists(UNPACK_DIRECTORY)) {
                Directory.CreateDirectory(UNPACK_DIRECTORY);
            }

            var runningTask = Task.Run(() => _resourcePacker.UnpackFiles(_packedFiles, UNPACK_DIRECTORY));
            var loadingIndicator = new LoadingIndicator("Unpacking Files...", runningTask);
            loadingIndicator.ShowDialog();

            // The loading indicator should halt our thread.
            _packedFiles = runningTask.Result
                ?? throw new Exception("An error occurred while unpacking...");

            repackButton.Enabled = true;
            return true;
        }

        private void ResrouceEditorInterface_FormClosing(object sender, FormClosingEventArgs e) {
            if (Directory.Exists(UNPACK_DIRECTORY)) {
                Directory.Delete(UNPACK_DIRECTORY, true);
            }
        }

        private void ReverseGameDataClick(object sender, EventArgs e) {
            if (!SetupEditor()) {
                return;
            }

            _packedFiles = ResourceFilePacker.UpdatePackedFileData(_packedFiles);

            var reversedData = _packedFiles.Reverse().ToArray();
            WriteColdStorageLocation(reversedData);

            RepackButtonClicked(default, default);
            ResrouceEditorInterface_Load(default, default);
        }

        private void RandomizeFileDataClicked(object sender, EventArgs e) {
            if (!SetupEditor()) {
                return;
            }

            _packedFiles = ResourceFilePacker.UpdatePackedFileData(_packedFiles);

            var rng = new Random();
            var randomizedData = _packedFiles.OrderBy(x => rng.Next()).ToArray();
            WriteColdStorageLocation(randomizedData);


            RepackButtonClicked(default, default);
            ResrouceEditorInterface_Load(default, default);
        }

        private void WriteColdStorageLocation(PackedFileInfo[] newOrder) {
            for (var i = 0; i < _packedFiles.Length; i++) {
                if (_regexIgnoreStrings != null && _regexIgnoreStrings.Any(reg => reg.IsMatch(_packedFiles[i].name))) {
                    continue;
                }

                var fileExt = _packedFiles[i].extension;
                fileExt = fileExt != "" ? $".{fileExt}" : "";
                _packedFiles[i].coldStorageLocation = $"{UNPACK_DIRECTORY}{Path.DirectorySeparatorChar}{newOrder[i].name}{fileExt}";
                _packedFiles[i].size = newOrder[i].size;
            }
        }
    }
}