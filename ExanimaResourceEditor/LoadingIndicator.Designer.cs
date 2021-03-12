
namespace ExanimaResourceEditor {
    partial class LoadingIndicator {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.messageLabel = new System.Windows.Forms.Label();
			this.loadingIndicatorImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.loadingIndicatorImage)).BeginInit();
			this.SuspendLayout();
			// 
			// messageLabel
			// 
			this.messageLabel.AutoSize = true;
			this.messageLabel.Location = new System.Drawing.Point(4, 3);
			this.messageLabel.MaximumSize = new System.Drawing.Size(600, 0);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(53, 13);
			this.messageLabel.TabIndex = 1;
			this.messageLabel.Text = "Message:";
			// 
			// loadingIndicatorImage
			// 
			this.loadingIndicatorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.loadingIndicatorImage.Image = global::ExanimaResourceEditor.Properties.Resources.greenLoader;
			this.loadingIndicatorImage.Location = new System.Drawing.Point(1, 19);
			this.loadingIndicatorImage.Name = "loadingIndicatorImage";
			this.loadingIndicatorImage.Size = new System.Drawing.Size(597, 32);
			this.loadingIndicatorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.loadingIndicatorImage.TabIndex = 2;
			this.loadingIndicatorImage.TabStop = false;
			// 
			// LoadingIndicator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 51);
			this.Controls.Add(this.loadingIndicatorImage);
			this.Controls.Add(this.messageLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LoadingIndicator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "LoadingIndicator";
			((System.ComponentModel.ISupportInitialize)(this.loadingIndicatorImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.PictureBox loadingIndicatorImage;
    }
}