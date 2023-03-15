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
            ButtonUpdate = new Button();
            TextBoxMemo = new TextBox();
            SuspendLayout();
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Location = new Point(408, 64);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(84, 28);
            ButtonUpdate.TabIndex = 3;
            ButtonUpdate.Text = "Update";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // TextBoxMemo
            // 
            TextBoxMemo.ImeMode = ImeMode.Hiragana;
            TextBoxMemo.Location = new Point(4, 4);
            TextBoxMemo.Multiline = true;
            TextBoxMemo.Name = "TextBoxMemo";
            TextBoxMemo.Size = new Size(492, 56);
            TextBoxMemo.TabIndex = 2;
            TextBoxMemo.Text = "あ\r\nあ\r\nあ\r\n";
            // 
            // SetMemo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 96);
            Controls.Add(ButtonUpdate);
            Controls.Add(TextBoxMemo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetMemo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SetMemo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonUpdate;
        private TextBox TextBoxMemo;
    }
}