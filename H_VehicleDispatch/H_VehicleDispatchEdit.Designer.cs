namespace H_VehicleDispatch {
    partial class H_VehicleDispatchEdit {
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
            HLabelExFinancialYear = new H_ControlEx.H_LabelEx();
            HNumericUpDownExFinancialYear = new H_ControlEx.H_NumericUpDownEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            HRadioButtonExMonday = new H_ControlEx.H_RadioButtonEx();
            HRadioButtonExTuesday = new H_ControlEx.H_RadioButtonEx();
            HRadioButtonExWednesday = new H_ControlEx.H_RadioButtonEx();
            HRadioButtonExThursday = new H_ControlEx.H_RadioButtonEx();
            HRadioButtonExFriday = new H_ControlEx.H_RadioButtonEx();
            HRadioButtonExSaturday = new H_ControlEx.H_RadioButtonEx();
            HRadioButtonExSunday = new H_ControlEx.H_RadioButtonEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            HPanelExDayOfWeek = new H_ControlEx.H_PanelEx();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExFinancialYear).BeginInit();
            HPanelExDayOfWeek.SuspendLayout();
            SuspendLayout();
            // 
            // HLabelExFinancialYear
            // 
            HLabelExFinancialYear.AutoSize = true;
            HLabelExFinancialYear.Location = new Point(16, 16);
            HLabelExFinancialYear.Name = "HLabelExFinancialYear";
            HLabelExFinancialYear.Size = new Size(107, 15);
            HLabelExFinancialYear.TabIndex = 1;
            HLabelExFinancialYear.Text = "対象とする会計年度";
            // 
            // HNumericUpDownExFinancialYear
            // 
            HNumericUpDownExFinancialYear.Location = new Point(128, 12);
            HNumericUpDownExFinancialYear.Maximum = new decimal(new int[] { 2024, 0, 0, 0 });
            HNumericUpDownExFinancialYear.Minimum = new decimal(new int[] { 2023, 0, 0, 0 });
            HNumericUpDownExFinancialYear.Name = "HNumericUpDownExFinancialYear";
            HNumericUpDownExFinancialYear.Size = new Size(52, 23);
            HNumericUpDownExFinancialYear.TabIndex = 2;
            HNumericUpDownExFinancialYear.TextAlign = HorizontalAlignment.Right;
            HNumericUpDownExFinancialYear.Value = new decimal(new int[] { 2023, 0, 0, 0 });
            HNumericUpDownExFinancialYear.ValueChanged += HNumericUpDownExFinancialYear_ValueChanged;
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(24, 12);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(83, 15);
            h_LabelEx1.TabIndex = 3;
            h_LabelEx1.Text = "対象とする曜日";
            // 
            // HRadioButtonExMonday
            // 
            HRadioButtonExMonday.AutoSize = true;
            HRadioButtonExMonday.Location = new Point(112, 10);
            HRadioButtonExMonday.Name = "HRadioButtonExMonday";
            HRadioButtonExMonday.Size = new Size(61, 19);
            HRadioButtonExMonday.TabIndex = 4;
            HRadioButtonExMonday.TabStop = true;
            HRadioButtonExMonday.Tag = "月";
            HRadioButtonExMonday.Text = "月曜日";
            HRadioButtonExMonday.UseVisualStyleBackColor = true;
            HRadioButtonExMonday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HRadioButtonExTuesday
            // 
            HRadioButtonExTuesday.AutoSize = true;
            HRadioButtonExTuesday.Location = new Point(112, 36);
            HRadioButtonExTuesday.Name = "HRadioButtonExTuesday";
            HRadioButtonExTuesday.Size = new Size(61, 19);
            HRadioButtonExTuesday.TabIndex = 5;
            HRadioButtonExTuesday.TabStop = true;
            HRadioButtonExTuesday.Tag = "火";
            HRadioButtonExTuesday.Text = "火曜日";
            HRadioButtonExTuesday.UseVisualStyleBackColor = true;
            HRadioButtonExTuesday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HRadioButtonExWednesday
            // 
            HRadioButtonExWednesday.AutoSize = true;
            HRadioButtonExWednesday.Location = new Point(112, 60);
            HRadioButtonExWednesday.Name = "HRadioButtonExWednesday";
            HRadioButtonExWednesday.Size = new Size(61, 19);
            HRadioButtonExWednesday.TabIndex = 6;
            HRadioButtonExWednesday.TabStop = true;
            HRadioButtonExWednesday.Tag = "水";
            HRadioButtonExWednesday.Text = "水曜日";
            HRadioButtonExWednesday.UseVisualStyleBackColor = true;
            HRadioButtonExWednesday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HRadioButtonExThursday
            // 
            HRadioButtonExThursday.AutoSize = true;
            HRadioButtonExThursday.Location = new Point(112, 84);
            HRadioButtonExThursday.Name = "HRadioButtonExThursday";
            HRadioButtonExThursday.Size = new Size(61, 19);
            HRadioButtonExThursday.TabIndex = 7;
            HRadioButtonExThursday.TabStop = true;
            HRadioButtonExThursday.Tag = "木";
            HRadioButtonExThursday.Text = "木曜日";
            HRadioButtonExThursday.UseVisualStyleBackColor = true;
            HRadioButtonExThursday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HRadioButtonExFriday
            // 
            HRadioButtonExFriday.AutoSize = true;
            HRadioButtonExFriday.Location = new Point(112, 108);
            HRadioButtonExFriday.Name = "HRadioButtonExFriday";
            HRadioButtonExFriday.Size = new Size(61, 19);
            HRadioButtonExFriday.TabIndex = 8;
            HRadioButtonExFriday.TabStop = true;
            HRadioButtonExFriday.Tag = "金";
            HRadioButtonExFriday.Text = "金曜日";
            HRadioButtonExFriday.UseVisualStyleBackColor = true;
            HRadioButtonExFriday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HRadioButtonExSaturday
            // 
            HRadioButtonExSaturday.AutoSize = true;
            HRadioButtonExSaturday.ForeColor = Color.Blue;
            HRadioButtonExSaturday.Location = new Point(112, 132);
            HRadioButtonExSaturday.Name = "HRadioButtonExSaturday";
            HRadioButtonExSaturday.Size = new Size(61, 19);
            HRadioButtonExSaturday.TabIndex = 9;
            HRadioButtonExSaturday.TabStop = true;
            HRadioButtonExSaturday.Tag = "土";
            HRadioButtonExSaturday.Text = "土曜日";
            HRadioButtonExSaturday.UseVisualStyleBackColor = true;
            HRadioButtonExSaturday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HRadioButtonExSunday
            // 
            HRadioButtonExSunday.AutoSize = true;
            HRadioButtonExSunday.ForeColor = Color.Red;
            HRadioButtonExSunday.Location = new Point(112, 156);
            HRadioButtonExSunday.Name = "HRadioButtonExSunday";
            HRadioButtonExSunday.Size = new Size(61, 19);
            HRadioButtonExSunday.TabIndex = 10;
            HRadioButtonExSunday.TabStop = true;
            HRadioButtonExSunday.Tag = "日";
            HRadioButtonExSunday.Text = "日曜日";
            HRadioButtonExSunday.UseVisualStyleBackColor = true;
            HRadioButtonExSunday.CheckedChanged += HRadioButtonEx_CheckedChanged;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(32, 244);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(168, 32);
            HButtonExUpdate.TabIndex = 11;
            HButtonExUpdate.Text = "この条件で記録する";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // HPanelExDayOfWeek
            // 
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExMonday);
            HPanelExDayOfWeek.Controls.Add(h_LabelEx1);
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExSunday);
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExTuesday);
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExSaturday);
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExWednesday);
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExFriday);
            HPanelExDayOfWeek.Controls.Add(HRadioButtonExThursday);
            HPanelExDayOfWeek.Location = new Point(12, 40);
            HPanelExDayOfWeek.Name = "HPanelExDayOfWeek";
            HPanelExDayOfWeek.Size = new Size(200, 184);
            HPanelExDayOfWeek.TabIndex = 12;
            // 
            // H_VehicleDispatchEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 288);
            Controls.Add(HPanelExDayOfWeek);
            Controls.Add(HButtonExUpdate);
            Controls.Add(HNumericUpDownExFinancialYear);
            Controls.Add(HLabelExFinancialYear);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_VehicleDispatchEdit";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "H_VehicleDispatchEdit";
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExFinancialYear).EndInit();
            HPanelExDayOfWeek.ResumeLayout(false);
            HPanelExDayOfWeek.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private H_ControlEx.H_LabelEx HLabelExFinancialYear;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExFinancialYear;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExMonday;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExTuesday;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExWednesday;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExThursday;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExFriday;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExSaturday;
        private H_ControlEx.H_RadioButtonEx HRadioButtonExSunday;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private H_ControlEx.H_PanelEx HPanelExDayOfWeek;
    }
}