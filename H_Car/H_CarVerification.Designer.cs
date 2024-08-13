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
            HPictureBoxExSubPicture = new H_ControlEx.H_PictureBoxEx();
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            HPictureBoxExMainPicture = new H_ControlEx.H_PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExSubPicture).BeginInit();
            HTableLayoutPanelExBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExMainPicture).BeginInit();
            SuspendLayout();
            // 
            // HPictureBoxExSubPicture
            // 
            HPictureBoxExSubPicture.BorderStyle = BorderStyle.Fixed3D;
            HPictureBoxExSubPicture.Dock = DockStyle.Fill;
            HPictureBoxExSubPicture.Location = new Point(615, 3);
            HPictureBoxExSubPicture.Name = "HPictureBoxExSubPicture";
            HPictureBoxExSubPicture.Size = new Size(606, 830);
            HPictureBoxExSubPicture.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxExSubPicture.TabIndex = 0;
            HPictureBoxExSubPicture.TabStop = false;
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 2;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExBase.Controls.Add(HPictureBoxExSubPicture, 1, 0);
            HTableLayoutPanelExBase.Controls.Add(HPictureBoxExMainPicture, 0, 0);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 1;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExBase.Size = new Size(1224, 836);
            HTableLayoutPanelExBase.TabIndex = 1;
            // 
            // HPictureBoxExMainPicture
            // 
            HPictureBoxExMainPicture.BorderStyle = BorderStyle.Fixed3D;
            HPictureBoxExMainPicture.Dock = DockStyle.Fill;
            HPictureBoxExMainPicture.Location = new Point(3, 3);
            HPictureBoxExMainPicture.Name = "HPictureBoxExMainPicture";
            HPictureBoxExMainPicture.Size = new Size(606, 830);
            HPictureBoxExMainPicture.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxExMainPicture.TabIndex = 1;
            HPictureBoxExMainPicture.TabStop = false;
            // 
            // H_CarVerification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 836);
            Controls.Add(HTableLayoutPanelExBase);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_CarVerification";
            Text = "H_CarVerification";
            FormClosed += H_CarVerification_FormClosed;
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExSubPicture).EndInit();
            HTableLayoutPanelExBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HPictureBoxExMainPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_PictureBoxEx HPictureBoxExSubPicture;
        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private H_ControlEx.H_PictureBoxEx HPictureBoxExMainPicture;
    }
}