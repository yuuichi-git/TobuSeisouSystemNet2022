namespace H_Car {
    partial class H_CarVerification {
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
            HPictureBoxExCarVerification = new H_ControlEx.H_PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExCarVerification).BeginInit();
            SuspendLayout();
            // 
            // HPictureBoxExCarVerification
            // 
            HPictureBoxExCarVerification.BorderStyle = BorderStyle.Fixed3D;
            HPictureBoxExCarVerification.Dock = DockStyle.Fill;
            HPictureBoxExCarVerification.Location = new Point(0, 0);
            HPictureBoxExCarVerification.Name = "HPictureBoxExCarVerification";
            HPictureBoxExCarVerification.Size = new Size(651, 810);
            HPictureBoxExCarVerification.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxExCarVerification.TabIndex = 0;
            HPictureBoxExCarVerification.TabStop = false;
            // 
            // H_CarVerification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 810);
            Controls.Add(HPictureBoxExCarVerification);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_CarVerification";
            Text = "H_CarVerification";
            FormClosed += H_CarVerification_FormClosed;
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExCarVerification).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_PictureBoxEx HPictureBoxExCarVerification;
    }
}