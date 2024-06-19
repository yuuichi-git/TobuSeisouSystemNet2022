namespace H_License {
    partial class H_LicenseCard {
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
            HPictureBoxExHead = new H_ControlEx.H_PictureBoxEx();
            HPictureBoxExTail = new H_ControlEx.H_PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExHead).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExTail).BeginInit();
            SuspendLayout();
            // 
            // HPictureBoxExHead
            // 
            HPictureBoxExHead.BorderStyle = BorderStyle.Fixed3D;
            HPictureBoxExHead.Location = new Point(4, 4);
            HPictureBoxExHead.Name = "HPictureBoxExHead";
            HPictureBoxExHead.Size = new Size(484, 308);
            HPictureBoxExHead.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxExHead.TabIndex = 0;
            HPictureBoxExHead.TabStop = false;
            // 
            // HPictureBoxExTail
            // 
            HPictureBoxExTail.BorderStyle = BorderStyle.Fixed3D;
            HPictureBoxExTail.Location = new Point(4, 316);
            HPictureBoxExTail.Name = "HPictureBoxExTail";
            HPictureBoxExTail.Size = new Size(484, 308);
            HPictureBoxExTail.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxExTail.TabIndex = 1;
            HPictureBoxExTail.TabStop = false;
            // 
            // H_LicenseCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 628);
            Controls.Add(HPictureBoxExTail);
            Controls.Add(HPictureBoxExHead);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_LicenseCard";
            Text = "H_LicenseCard";
            FormClosing += H_LicenseCard_FormClosing;
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExHead).EndInit();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExTail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_PictureBoxEx HPictureBoxExHead;
        private H_ControlEx.H_PictureBoxEx HPictureBoxExTail;
    }
}