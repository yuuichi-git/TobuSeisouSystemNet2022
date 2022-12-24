namespace License {
    partial class LicenseCard {
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
            this.PictureBoxHead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxHead
            // 
            this.PictureBoxHead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBoxHead.Location = new System.Drawing.Point(4, 4);
            this.PictureBoxHead.Name = "PictureBoxHead";
            this.PictureBoxHead.Size = new System.Drawing.Size(656, 424);
            this.PictureBoxHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxHead.TabIndex = 0;
            this.PictureBoxHead.TabStop = false;
            // 
            // LicenseLedgerPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 432);
            this.Controls.Add(this.PictureBoxHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseLedgerPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LicenseLedgerPicture";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PictureBoxHead;
    }
}