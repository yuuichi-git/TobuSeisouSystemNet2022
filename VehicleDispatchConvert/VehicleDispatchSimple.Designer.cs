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
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.ComboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(16, 96);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(320, 40);
            this.ButtonUpdate.TabIndex = 0;
            this.ButtonUpdate.Text = "”配車当日.xls”にデータを書き込みます";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 204);
            this.label1.TabIndex = 1;
            this.label1.Text = "配車表転記作業での注意事項！\r\n\r\n①深井翔/大橋松生等の特殊な扱いの従事者の記入方法を確認すること。\r\n②千代田配車等に３人目を付けた場合、配車表の枠が対応して" +
    "いないので、別枠に記載すること。\r\n③臨時の新大・小プレ・軽ダ・軽小は自動入力されます。注意点は、作業員が二人付いた場合、二人目は上書きされてしまいます。配車表" +
    "の枠が対応していないので、別枠に記載すること。\r\n";
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "新井",
            "波潟",
            "川名",
            "石原",
            "辻"});
            this.ComboBox1.Location = new System.Drawing.Point(184, 8);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(88, 23);
            this.ComboBox1.TabIndex = 2;
            // 
            // ComboBox2
            // 
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Items.AddRange(new object[] {
            "新井",
            "波潟",
            "川名",
            "石原",
            "辻"});
            this.ComboBox2.Location = new System.Drawing.Point(184, 36);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(88, 23);
            this.ComboBox2.TabIndex = 3;
            // 
            // ComboBox3
            // 
            this.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox3.FormattingEnabled = true;
            this.ComboBox3.Items.AddRange(new object[] {
            "川名",
            "酒井",
            "青木"});
            this.ComboBox3.Location = new System.Drawing.Point(184, 64);
            this.ComboBox3.Name = "ComboBox3";
            this.ComboBox3.Size = new System.Drawing.Size(88, 23);
            this.ComboBox3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "点呼執行者(本社１)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "点呼執行者(本社２)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "点呼執行者(三郷)";
            // 
            // VehicleDispatchSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboBox3);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleDispatchSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VehicleDispatchSimple";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ButtonUpdate;
        private Label label1;
        private ComboBox ComboBox1;
        private ComboBox ComboBox2;
        private ComboBox ComboBox3;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}