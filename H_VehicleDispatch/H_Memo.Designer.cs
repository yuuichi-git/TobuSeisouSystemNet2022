namespace H_VehicleDispatch {
    partial class H_Memo {
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
            HTextBoxExMemo = new H_ControlEx.H_TextBoxEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            SuspendLayout();
            // 
            // HTextBoxExMemo
            // 
            HTextBoxExMemo.ImeMode = ImeMode.Hiragana;
            HTextBoxExMemo.Location = new Point(4, 4);
            HTextBoxExMemo.Multiline = true;
            HTextBoxExMemo.Name = "HTextBoxExMemo";
            HTextBoxExMemo.Size = new Size(516, 88);
            HTextBoxExMemo.TabIndex = 0;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(396, 100);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(112, 32);
            HButtonExUpdate.TabIndex = 1;
            HButtonExUpdate.Text = "UPDATE";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // H_Memo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 141);
            Controls.Add(HButtonExUpdate);
            Controls.Add(HTextBoxExMemo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_Memo";
            Text = "H_Memo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private H_ControlEx.H_TextBoxEx HTextBoxExMemo;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
    }
}