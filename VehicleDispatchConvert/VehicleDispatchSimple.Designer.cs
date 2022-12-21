namespace VehicleDispatchConvert {
    partial class VehicleDispatchSimple {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(48, 12);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(256, 40);
            this.ButtonUpdate.TabIndex = 0;
            this.ButtonUpdate.Text = "”配車当日.xls”にデータを書き込みます";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 144);
            this.label1.TabIndex = 1;
            this.label1.Text = "配車表転記作業での注意事項！\r\n\r\n①深井翔/大橋松生等の特殊な扱いの従事者の記入方法を確認すること。\r\n②千代田配車等に３人目を付けた場合、配車表の枠が対応して" +
    "いないので、別枠に記載すること。";
            // 
            // VehicleDispatchSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleDispatchSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VehicleDispatchSimple";
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonUpdate;
        private Label label1;
    }
}