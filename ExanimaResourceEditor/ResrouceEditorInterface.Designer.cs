
namespace ExanimaResourceEditor
{
	partial class ResrouceEditorInterface
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResrouceEditorInterface));
			this.packedFilesListView = new System.Windows.Forms.ListBox();
			this.resrouceInformationGroupBox = new System.Windows.Forms.GroupBox();
			this.packedFileSizeLabel = new System.Windows.Forms.Label();
			this.packedFileTypeLabel = new System.Windows.Forms.Label();
			this.packedFileOffsetLabel = new System.Windows.Forms.Label();
			this.packedFileNameLabel = new System.Windows.Forms.Label();
			this.editFileButton = new System.Windows.Forms.Button();
			this.repackButton = new System.Windows.Forms.Button();
			this.unpackFileButton = new System.Windows.Forms.Button();
			this.unpackAllFilesButton = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.packedFilesCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.selectedFileStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.regexMatchingToolButton = new System.Windows.Forms.ToolStripSplitButton();
			this.unFilterDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toggleDisplayFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editRegexButton = new System.Windows.Forms.ToolStripMenuItem();
			this.moddingActionGroupBox = new System.Windows.Forms.GroupBox();
			this.randomizeFileDataButton = new System.Windows.Forms.Button();
			this.reverseGameDataButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.quickViewFileButton = new System.Windows.Forms.Button();
			this.resrouceInformationGroupBox.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.moddingActionGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// packedFilesListView
			// 
			this.packedFilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.packedFilesListView.FormattingEnabled = true;
			this.packedFilesListView.Location = new System.Drawing.Point(0, 0);
			this.packedFilesListView.Name = "packedFilesListView";
			this.packedFilesListView.Size = new System.Drawing.Size(427, 420);
			this.packedFilesListView.TabIndex = 0;
			this.packedFilesListView.SelectedIndexChanged += new System.EventHandler(this.SelectedPackedFiledChanged);
			// 
			// resrouceInformationGroupBox
			// 
			this.resrouceInformationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.resrouceInformationGroupBox.Controls.Add(this.packedFileSizeLabel);
			this.resrouceInformationGroupBox.Controls.Add(this.packedFileTypeLabel);
			this.resrouceInformationGroupBox.Controls.Add(this.packedFileOffsetLabel);
			this.resrouceInformationGroupBox.Controls.Add(this.packedFileNameLabel);
			this.resrouceInformationGroupBox.Location = new System.Drawing.Point(433, 12);
			this.resrouceInformationGroupBox.Name = "resrouceInformationGroupBox";
			this.resrouceInformationGroupBox.Size = new System.Drawing.Size(355, 137);
			this.resrouceInformationGroupBox.TabIndex = 1;
			this.resrouceInformationGroupBox.TabStop = false;
			this.resrouceInformationGroupBox.Text = "Resrouce Information";
			// 
			// packedFileSizeLabel
			// 
			this.packedFileSizeLabel.AutoSize = true;
			this.packedFileSizeLabel.Location = new System.Drawing.Point(6, 112);
			this.packedFileSizeLabel.Name = "packedFileSizeLabel";
			this.packedFileSizeLabel.Size = new System.Drawing.Size(89, 13);
			this.packedFileSizeLabel.TabIndex = 0;
			this.packedFileSizeLabel.Text = "Packed File Size:";
			// 
			// packedFileTypeLabel
			// 
			this.packedFileTypeLabel.AutoSize = true;
			this.packedFileTypeLabel.Location = new System.Drawing.Point(6, 78);
			this.packedFileTypeLabel.Name = "packedFileTypeLabel";
			this.packedFileTypeLabel.Size = new System.Drawing.Size(93, 13);
			this.packedFileTypeLabel.TabIndex = 0;
			this.packedFileTypeLabel.Text = "Packed File Type:";
			// 
			// packedFileOffsetLabel
			// 
			this.packedFileOffsetLabel.AutoSize = true;
			this.packedFileOffsetLabel.Location = new System.Drawing.Point(6, 46);
			this.packedFileOffsetLabel.Name = "packedFileOffsetLabel";
			this.packedFileOffsetLabel.Size = new System.Drawing.Size(100, 13);
			this.packedFileOffsetLabel.TabIndex = 0;
			this.packedFileOffsetLabel.Text = "Packed File Offset: ";
			// 
			// packedFileNameLabel
			// 
			this.packedFileNameLabel.AutoSize = true;
			this.packedFileNameLabel.Location = new System.Drawing.Point(6, 16);
			this.packedFileNameLabel.Name = "packedFileNameLabel";
			this.packedFileNameLabel.Size = new System.Drawing.Size(69, 13);
			this.packedFileNameLabel.TabIndex = 0;
			this.packedFileNameLabel.Text = "Packed File: ";
			// 
			// editFileButton
			// 
			this.editFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.editFileButton.Location = new System.Drawing.Point(433, 368);
			this.editFileButton.Name = "editFileButton";
			this.editFileButton.Size = new System.Drawing.Size(355, 23);
			this.editFileButton.TabIndex = 2;
			this.editFileButton.Text = "Edit";
			this.editFileButton.UseVisualStyleBackColor = true;
			this.editFileButton.Click += new System.EventHandler(this.EditPackedFileClicked);
			// 
			// repackButton
			// 
			this.repackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.repackButton.Enabled = false;
			this.repackButton.Location = new System.Drawing.Point(433, 397);
			this.repackButton.Name = "repackButton";
			this.repackButton.Size = new System.Drawing.Size(355, 23);
			this.repackButton.TabIndex = 3;
			this.repackButton.Text = "Re-Pack To Resource";
			this.repackButton.UseVisualStyleBackColor = true;
			this.repackButton.Click += new System.EventHandler(this.RepackButtonClicked);
			// 
			// unpackFileButton
			// 
			this.unpackFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.unpackFileButton.Location = new System.Drawing.Point(433, 339);
			this.unpackFileButton.Name = "unpackFileButton";
			this.unpackFileButton.Size = new System.Drawing.Size(355, 23);
			this.unpackFileButton.TabIndex = 2;
			this.unpackFileButton.Text = "Unpack Selected File";
			this.unpackFileButton.UseVisualStyleBackColor = true;
			this.unpackFileButton.Click += new System.EventHandler(this.SavePackedFileClicked);
			// 
			// unpackAllFilesButton
			// 
			this.unpackAllFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.unpackAllFilesButton.Location = new System.Drawing.Point(433, 310);
			this.unpackAllFilesButton.Name = "unpackAllFilesButton";
			this.unpackAllFilesButton.Size = new System.Drawing.Size(355, 23);
			this.unpackAllFilesButton.TabIndex = 2;
			this.unpackAllFilesButton.Text = "Unpack All Files";
			this.unpackAllFilesButton.UseVisualStyleBackColor = true;
			this.unpackAllFilesButton.Click += new System.EventHandler(this.UnpackAllFilesClicked);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packedFilesCountStatusLabel,
            this.selectedFileStatusLabel,
            this.regexMatchingToolButton});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// packedFilesCountStatusLabel
			// 
			this.packedFilesCountStatusLabel.Name = "packedFilesCountStatusLabel";
			this.packedFilesCountStatusLabel.Size = new System.Drawing.Size(74, 17);
			this.packedFilesCountStatusLabel.Text = "Packed Files:";
			// 
			// selectedFileStatusLabel
			// 
			this.selectedFileStatusLabel.Name = "selectedFileStatusLabel";
			this.selectedFileStatusLabel.Size = new System.Drawing.Size(78, 17);
			this.selectedFileStatusLabel.Text = "Selected File: ";
			// 
			// regexMatchingToolButton
			// 
			this.regexMatchingToolButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.regexMatchingToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.regexMatchingToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unFilterDisplayToolStripMenuItem,
            this.toggleDisplayFilterToolStripMenuItem,
            this.editRegexButton});
			this.regexMatchingToolButton.Image = ((System.Drawing.Image)(resources.GetObject("regexMatchingToolButton.Image")));
			this.regexMatchingToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.regexMatchingToolButton.Name = "regexMatchingToolButton";
			this.regexMatchingToolButton.Size = new System.Drawing.Size(109, 20);
			this.regexMatchingToolButton.Text = "Regex Matching";
			this.regexMatchingToolButton.ToolTipText = "Toggle Regex Filter";
			// 
			// unFilterDisplayToolStripMenuItem
			// 
			this.unFilterDisplayToolStripMenuItem.Name = "unFilterDisplayToolStripMenuItem";
			this.unFilterDisplayToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.unFilterDisplayToolStripMenuItem.Text = "UnFilter Display";
			this.unFilterDisplayToolStripMenuItem.Click += new System.EventHandler(this.UnFilterDisplayClicked);
			// 
			// toggleDisplayFilterToolStripMenuItem
			// 
			this.toggleDisplayFilterToolStripMenuItem.Name = "toggleDisplayFilterToolStripMenuItem";
			this.toggleDisplayFilterToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.toggleDisplayFilterToolStripMenuItem.Text = "Filter Display";
			this.toggleDisplayFilterToolStripMenuItem.Click += new System.EventHandler(this.ToggleRegexFilterClicked);
			// 
			// editRegexButton
			// 
			this.editRegexButton.Name = "editRegexButton";
			this.editRegexButton.Size = new System.Drawing.Size(156, 22);
			this.editRegexButton.Text = "Edit Regex";
			this.editRegexButton.Click += new System.EventHandler(this.EditRegexButtonClicked);
			// 
			// moddingActionGroupBox
			// 
			this.moddingActionGroupBox.Controls.Add(this.randomizeFileDataButton);
			this.moddingActionGroupBox.Controls.Add(this.reverseGameDataButton);
			this.moddingActionGroupBox.Controls.Add(this.button1);
			this.moddingActionGroupBox.Location = new System.Drawing.Point(433, 155);
			this.moddingActionGroupBox.Name = "moddingActionGroupBox";
			this.moddingActionGroupBox.Size = new System.Drawing.Size(355, 109);
			this.moddingActionGroupBox.TabIndex = 5;
			this.moddingActionGroupBox.TabStop = false;
			this.moddingActionGroupBox.Text = "Modding - Use \'patterns.regex\' to Ignore Regex matched files";
			// 
			// randomizeFileDataButton
			// 
			this.randomizeFileDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.randomizeFileDataButton.Location = new System.Drawing.Point(6, 47);
			this.randomizeFileDataButton.Name = "randomizeFileDataButton";
			this.randomizeFileDataButton.Size = new System.Drawing.Size(343, 23);
			this.randomizeFileDataButton.TabIndex = 2;
			this.randomizeFileDataButton.Text = "Randomize File Data And Names";
			this.randomizeFileDataButton.UseVisualStyleBackColor = true;
			this.randomizeFileDataButton.Click += new System.EventHandler(this.RandomizeFileDataClicked);
			// 
			// reverseGameDataButton
			// 
			this.reverseGameDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.reverseGameDataButton.Location = new System.Drawing.Point(6, 18);
			this.reverseGameDataButton.Name = "reverseGameDataButton";
			this.reverseGameDataButton.Size = new System.Drawing.Size(343, 23);
			this.reverseGameDataButton.TabIndex = 2;
			this.reverseGameDataButton.Text = "Reverse File Data And Names";
			this.reverseGameDataButton.UseVisualStyleBackColor = true;
			this.reverseGameDataButton.Click += new System.EventHandler(this.ReverseGameDataClick);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(6, 76);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(343, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Edit All Regex Matches";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.EditRegexMatchesClicked);
			// 
			// quickViewFileButton
			// 
			this.quickViewFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.quickViewFileButton.Location = new System.Drawing.Point(433, 281);
			this.quickViewFileButton.Name = "quickViewFileButton";
			this.quickViewFileButton.Size = new System.Drawing.Size(355, 23);
			this.quickViewFileButton.TabIndex = 2;
			this.quickViewFileButton.Text = "Quick View Selected File";
			this.quickViewFileButton.UseVisualStyleBackColor = true;
			this.quickViewFileButton.Click += new System.EventHandler(this.QuickViewButtonClicked);
			// 
			// ResrouceEditorInterface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.moddingActionGroupBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.repackButton);
			this.Controls.Add(this.quickViewFileButton);
			this.Controls.Add(this.unpackAllFilesButton);
			this.Controls.Add(this.unpackFileButton);
			this.Controls.Add(this.editFileButton);
			this.Controls.Add(this.resrouceInformationGroupBox);
			this.Controls.Add(this.packedFilesListView);
			this.Name = "ResrouceEditorInterface";
			this.Text = "Resrouce Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResrouceEditorInterface_FormClosing);
			this.Load += new System.EventHandler(this.ResrouceEditorInterface_Load);
			this.resrouceInformationGroupBox.ResumeLayout(false);
			this.resrouceInformationGroupBox.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.moddingActionGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ListBox packedFilesListView;
        private System.Windows.Forms.GroupBox resrouceInformationGroupBox;
        private System.Windows.Forms.Button editFileButton;
        private System.Windows.Forms.Button repackButton;
        private System.Windows.Forms.Label packedFileNameLabel;
        private System.Windows.Forms.Label packedFileOffsetLabel;
        private System.Windows.Forms.Label packedFileTypeLabel;
        private System.Windows.Forms.Label packedFileSizeLabel;
        private System.Windows.Forms.Button unpackFileButton;
        private System.Windows.Forms.Button unpackAllFilesButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel packedFilesCountStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel selectedFileStatusLabel;
        private System.Windows.Forms.GroupBox moddingActionGroupBox;
        private System.Windows.Forms.Button reverseGameDataButton;
        private System.Windows.Forms.Button randomizeFileDataButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSplitButton regexMatchingToolButton;
        private System.Windows.Forms.ToolStripMenuItem toggleDisplayFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRegexButton;
        private System.Windows.Forms.ToolStripMenuItem unFilterDisplayToolStripMenuItem;
        private System.Windows.Forms.Button quickViewFileButton;
    }
}

