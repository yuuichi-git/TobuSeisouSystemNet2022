namespace VehicleDispatch {
    partial class SetMemo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.TextBoxMemo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(408, 64);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(84, 28);
            this.ButtonUpdate.TabIndex = 3;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // TextBoxMemo
            // 
            this.TextBoxMemo.Location = new System.Drawing.Point(4, 4);
            this.TextBoxMemo.Multiline = true;
            this.TextBoxMemo.Name = "TextBoxMemo";
            this.TextBoxMemo.Size = new System.Drawing.Size(492, 56);
            this.TextBoxMemo.TabIndex = 2;
            this.TextBoxMemo.Text = "あ\r\nあ\r\nあ\r\n";
            // 
            // SetMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 96);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.TextBoxMemo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetMemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetMemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ButtonUpdate;
        private TextBox TextBoxMemo;
    }
}