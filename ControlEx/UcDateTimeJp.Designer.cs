namespace ControlEx {
    partial class UcDateTimeJp {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.MaskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Location = new System.Drawing.Point(60, 0);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(123, 23);
            this.DateTimePicker1.TabIndex = 0;
            this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // MaskedTextBox1
            // 
            this.MaskedTextBox1.Location = new System.Drawing.Point(0, 0);
            this.MaskedTextBox1.Mask = "AA90年90月90日(AAA)";
            this.MaskedTextBox1.Name = "MaskedTextBox1";
            this.MaskedTextBox1.Size = new System.Drawing.Size(152, 23);
            this.MaskedTextBox1.TabIndex = 2;
            this.MaskedTextBox1.Text = "昭和470625月曜日";
            // 
            // UcDateTimeJp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MaskedTextBox1);
            this.Controls.Add(this.DateTimePicker1);
            this.Name = "UcDateTimeJp";
            this.Size = new System.Drawing.Size(183, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker DateTimePicker1;
        private MaskedTextBox MaskedTextBox1;
    }
}
