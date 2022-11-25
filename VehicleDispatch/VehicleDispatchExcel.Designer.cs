namespace VehicleDispatch {
    partial class VehicleDispatchExcel {
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
            this.ButtonOutputExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOutputExcel
            // 
            this.ButtonOutputExcel.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonOutputExcel.Location = new System.Drawing.Point(92, 12);
            this.ButtonOutputExcel.Name = "ButtonOutputExcel";
            this.ButtonOutputExcel.Size = new System.Drawing.Size(388, 40);
            this.ButtonOutputExcel.TabIndex = 2;
            this.ButtonOutputExcel.Text = "配車表へデータを書き込みます";
            this.ButtonOutputExcel.UseVisualStyleBackColor = true;
            this.ButtonOutputExcel.Click += new System.EventHandler(this.ButtonOutputExcel_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 172);
            this.label1.TabIndex = 3;
            this.label1.Text = "開発中につき、意見を上げて下さい。\r\n\r\nデータ書き込みの対象ファイルは、デスクトップにある”配車当日.xls”です。";
            // 
            // VehicleDispatchExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonOutputExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleDispatchExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VehicleDispatchExcel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VehicleDispatchExcel_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private Button ButtonOutputExcel;
        private Label label1;
    }
}