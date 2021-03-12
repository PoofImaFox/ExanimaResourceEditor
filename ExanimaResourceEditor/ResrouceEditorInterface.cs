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
        private const string REGEX_FILE = "patterns.regex";

        private readonly string _windowTitle;
        private readonly string _resrouceFile;
        private Regex[] _regexStrings;
        private bool _regexFilter;

        private ResourceFilePacker _resourcePacker;
        private PackedFileInfo _selectedPackedFile;
        private PackedFileInfo[] _packedFiles;

        public ResrouceEditorInterface(string resrouceFile) {
            ReLoadRegex();

            _resrouceFile = resrouceFile;
            InitializeComponent();

            _resourcePacker = new ResourceFilePacker(_resrouceFile);
            _windowTitle = Text;
            Text = $"{_windowTitle} - Packed '{Path.GetFullPath(_resrouceFile)}'";
        }

        ~ResrouceEditorInterface() {
            if (Directory.Exists(UNPACK_DIRECTORY)) {
                Directory.Delete(UNPACK_DIRECTORY, true);
            }
        }

        private void ResrouceEditorInterface_Load(object sender, EventArgs e) {
            _packedFiles = _resourcePacker.GetPackedFiles();
            ResetDisplayLayout();
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
            ResetDisplayLayout();
            Text = $"{_windowTitle} - Packed '{Path.GetFullPath(_resrouceFile)}'";
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

        private void AddFileButtonClicked(object sender, EventArgs e) {
            if (!SetupEditor()) {
                return;
            }

            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK) {
                var fileName = Path.GetFileName(openFile.FileName);

                fileName = fileName.Split('.')[0]
                    ?? throw new Exception($"There was an unspecified error with the file name '{openFile.FileName}'");

                var fileData = File.ReadAllBytes(openFile.FileName);
                fileName = fileName.Length > 16
                    ? new string(fileName.Take(16).ToArray())
                    : fileName;

                var packedFileLocation = $"{UNPACK_DIRECTORY}\\{fileName}";
                File.WriteAllBytes(packedFileLocation, fileData);

                var fileInfo = new FileInfo(packedFileLocation);
                Array.Resize(ref _packedFiles, _packedFiles.Length + 1);
                var packedFile = new PackedFileInfo() {
                    coldStorageLocation = openFile.FileName,
                    name = fileInfo.Name.ToLower(),
                    size = (uint)fileInfo.Length,
                    extension = fileInfo.Extension
                };

                _packedFiles[_packedFiles.Length - 1] = packedFile;
                _packedFiles = ResourceFilePacker.UpdatePackedFileData(_packedFiles);
                ResetDisplayLayout();
            }
        }

        private void RemoveFileClicked(object sender, EventArgs e) {
            if (packedFilesListView.SelectedItem is null) {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            if (!SetupEditor()) {
                return;
            }

            var selectedFile = _packedFiles.Single(i =>
                i.name == (string)packedFilesListView.SelectedItem);

            File.Delete(selectedFile.coldStorageLocation);

            var indexItemToRemove = Array.IndexOf(_packedFiles, selectedFile);
            _packedFiles = _packedFiles.RemoveAt(indexItemToRemove);
            _packedFiles = ResourceFilePacker.UpdatePackedFileData(_packedFiles);
            ResetDisplayLayout();
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

            ReLoadRegex();

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
            Text = $"{_windowTitle} - Unpacked '{Path.GetFullPath(UNPACK_DIRECTORY)}'";
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

        private void EditRegexMatchesClicked(object sender, EventArgs e) {
            if (!SetupEditor()) {
                return;
            }

            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK) {
                var fileData = File.ReadAllBytes(openFile.FileName);

                var matchedFiles = _packedFiles.Where(i => _regexStrings.Any(reg => reg.IsMatch(i.name)));

                foreach (var fileToReplace in matchedFiles) {
                    File.WriteAllBytes(fileToReplace.coldStorageLocation, fileData);
                }

                _packedFiles = ResourceFilePacker.UpdatePackedFileData(_packedFiles);

                RepackButtonClicked(default, default);
                ResrouceEditorInterface_Load(default, default);
            }
        }

        private void WriteColdStorageLocation(PackedFileInfo[] newOrder) {
            for (var i = 0; i < _packedFiles.Length; i++) {
                if (_regexStrings != null && _regexStrings.Any(reg => reg.IsMatch(_packedFiles[i].name))) {
                    continue;
                }

                var fileExt = _packedFiles[i].extension;
                fileExt = fileExt != "" ? $".{fileExt}" : "";
                _packedFiles[i].coldStorageLocation = $"{UNPACK_DIRECTORY}{Path.DirectorySeparatorChar}{newOrder[i].name}{fileExt}";
                _packedFiles[i].size = newOrder[i].size;
            }
        }

        private void EditRegexButtonClicked(object sender, EventArgs e) {
            if (!File.Exists(REGEX_FILE)) {
                File.WriteAllBytes(REGEX_FILE, Array.Empty<byte>());
            }

            Process.Start("notepad.exe", REGEX_FILE);
        }

        private void ToggleRegexFilterClicked(object sender, EventArgs e) {
            ReLoadRegex();
            _regexFilter = true;
            ResetDisplayLayout();
        }

        private void UnFilterDisplayClicked(object sender, EventArgs e) {
            ReLoadRegex();
            _regexFilter = false;
            ResetDisplayLayout();
        }

        private void ResetDisplayLayout() {
            packedFilesListView.Items.Clear();

            var displayFiles = _regexStrings != null && _regexFilter
                ? _packedFiles.Where(i => _regexStrings.Any(reg => reg.IsMatch(i.name)))
                : _packedFiles;

            packedFilesListView.Items.AddRange(displayFiles.Select(i => i.name).ToArray());
            packedFilesCountStatusLabel.Text = $"Packed Files: {_packedFiles.Length}";
        }

        private void ReLoadRegex() {
            if (File.Exists(REGEX_FILE)) {
                var regexLines = File.ReadAllLines(REGEX_FILE);
                _regexStrings = regexLines.Select(i => new Regex(i)).ToArray();
            }
        }

        private void QuickViewButtonClicked(object sender, EventArgs e) {
            if (packedFilesListView.SelectedItem is null) {
                MessageBox.Show("Please select an item to quick view.");
                return;
            }

            if (!SetupEditor()) {
                return;
            }

            Process.Start(_selectedPackedFile.coldStorageLocation);
        }
    }
}