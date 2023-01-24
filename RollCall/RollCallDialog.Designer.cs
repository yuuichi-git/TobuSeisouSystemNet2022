namespace RollCall {
    partial class RollCallDialog {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumericLastPlantCount = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxLastPlantName = new System.Windows.Forms.ComboBox();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.MaskedTextBoxLastPlantTime = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBoxLastRollCallTime = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DateTimePickerFarstRollCallTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLastPlantCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "搬入回数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "最終搬入場所";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "最終搬入時刻";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "車庫帰庫時刻";
            // 
            // NumericLastPlantCount
            // 
            this.NumericLastPlantCount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NumericLastPlantCount.Location = new System.Drawing.Point(112, 36);
            this.NumericLastPlantCount.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumericLastPlantCount.Name = "NumericLastPlantCount";
            this.NumericLastPlantCount.Size = new System.Drawing.Size(44, 23);
            this.NumericLastPlantCount.TabIndex = 1;
            this.NumericLastPlantCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericLastPlantCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // ComboBoxLastPlantName
            // 
            this.ComboBoxLastPlantName.FormattingEnabled = true;
            this.ComboBoxLastPlantName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ComboBoxLastPlantName.Location = new System.Drawing.Point(112, 64);
            this.ComboBoxLastPlantName.Name = "ComboBoxLastPlantName";
            this.ComboBoxLastPlantName.Size = new System.Drawing.Size(124, 23);
            this.ComboBoxLastPlantName.TabIndex = 2;
            this.ComboBoxLastPlantName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(108, 160);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(92, 28);
            this.ButtonUpdate.TabIndex = 5;
            this.ButtonUpdate.Text = "登　録";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(204, 160);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(47, 28);
            this.ButtonClear.TabIndex = 6;
            this.ButtonClear.TabStop = false;
            this.ButtonClear.Text = "解除";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // MaskedTextBoxLastPlantTime
            // 
            this.MaskedTextBoxLastPlantTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaskedTextBoxLastPlantTime.Location = new System.Drawing.Point(112, 92);
            this.MaskedTextBoxLastPlantTime.Mask = "90:00";
            this.MaskedTextBoxLastPlantTime.Name = "MaskedTextBoxLastPlantTime";
            this.MaskedTextBoxLastPlantTime.Size = new System.Drawing.Size(48, 23);
            this.MaskedTextBoxLastPlantTime.TabIndex = 3;
            this.MaskedTextBoxLastPlantTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaskedTextBoxLastPlantTime.ValidatingType = typeof(System.DateTime);
            this.MaskedTextBoxLastPlantTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // MaskedTextBoxLastRollCallTime
            // 
            this.MaskedTextBoxLastRollCallTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaskedTextBoxLastRollCallTime.Location = new System.Drawing.Point(112, 120);
            this.MaskedTextBoxLastRollCallTime.Mask = "90:00";
            this.MaskedTextBoxLastRollCallTime.Name = "MaskedTextBoxLastRollCallTime";
            this.MaskedTextBoxLastRollCallTime.Size = new System.Drawing.Size(48, 23);
            this.MaskedTextBoxLastRollCallTime.TabIndex = 4;
            this.MaskedTextBoxLastRollCallTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaskedTextBoxLastRollCallTime.ValidatingType = typeof(System.DateTime);
            this.MaskedTextBoxLastRollCallTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "車庫出庫時刻";
            // 
            // DateTimePickerFarstRollCallTime
            // 
            this.DateTimePickerFarstRollCallTime.CustomFormat = " HH:mm";
            this.DateTimePickerFarstRollCallTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerFarstRollCallTime.Location = new System.Drawing.Point(112, 8);
            this.DateTimePickerFarstRollCallTime.Name = "DateTimePickerFarstRollCallTime";
            this.DateTimePickerFarstRollCallTime.Size = new System.Drawing.Size(52, 23);
            this.DateTimePickerFarstRollCallTime.TabIndex = 0;
            this.DateTimePickerFarstRollCallTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // RollCallDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 196);
            this.Controls.Add(this.DateTimePickerFarstRollCallTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MaskedTextBoxLastRollCallTime);
            this.Controls.Add(this.MaskedTextBoxLastPlantTime);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ComboBoxLastPlantName);
            this.Controls.Add(this.NumericLastPlantCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RollCallDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RollCallDialog";
            ((System.ComponentModel.ISupportInitialize)(this.NumericLastPlantCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown NumericLastPlantCount;
        private ComboBox ComboBoxLastPlantName;
        private Button ButtonUpdate;
        private Button ButtonClear;
        private MaskedTextBox MaskedTextBoxLastPlantTime;
        private MaskedTextBox MaskedTextBoxLastRollCallTime;
        private Label label5;
        private DateTimePicker DateTimePickerFarstRollCallTime;
    }
}