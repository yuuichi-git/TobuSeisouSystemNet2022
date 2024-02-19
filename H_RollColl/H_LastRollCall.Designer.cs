namespace H_RollColl {
    partial class H_LastRollCall {
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
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            h_LabelEx2 = new H_ControlEx.H_LabelEx();
            HDateTimePickerExOperationDate = new H_ControlEx.H_DateTimePickerEx();
            HTimeExFirstRollCallTime = new H_ControlEx.H_TimeEx();
            h_LabelEx3 = new H_ControlEx.H_LabelEx();
            HComboBoxExLastPlantName = new H_ControlEx.H_ComboBoxEx();
            h_LabelEx4 = new H_ControlEx.H_LabelEx();
            h_LabelEx5 = new H_ControlEx.H_LabelEx();
            h_LabelEx6 = new H_ControlEx.H_LabelEx();
            h_LabelEx7 = new H_ControlEx.H_LabelEx();
            h_LabelEx8 = new H_ControlEx.H_LabelEx();
            HTimeExLastPlantYmdHms = new H_ControlEx.H_TimeEx();
            HTimeExLastRollCallYmdHms = new H_ControlEx.H_TimeEx();
            HNumericUpDownExFirstOdoMeter = new H_ControlEx.H_NumericUpDownEx();
            HNumericUpDownExLastOdoMeter = new H_ControlEx.H_NumericUpDownEx();
            HNumericUpDownExOilAmount = new H_ControlEx.H_NumericUpDownEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExFirstOdoMeter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExLastOdoMeter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExOilAmount).BeginInit();
            SuspendLayout();
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(20, 44);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(79, 15);
            h_LabelEx1.TabIndex = 0;
            h_LabelEx1.Text = "車庫出庫時刻";
            // 
            // h_LabelEx2
            // 
            h_LabelEx2.AutoSize = true;
            h_LabelEx2.Location = new Point(68, 16);
            h_LabelEx2.Name = "h_LabelEx2";
            h_LabelEx2.Size = new Size(31, 15);
            h_LabelEx2.TabIndex = 1;
            h_LabelEx2.Text = "日付";
            // 
            // HDateTimePickerExOperationDate
            // 
            HDateTimePickerExOperationDate.CustomFormat = "yyyy年MM月dd日(dddd)";
            HDateTimePickerExOperationDate.Format = DateTimePickerFormat.Custom;
            HDateTimePickerExOperationDate.Location = new Point(104, 12);
            HDateTimePickerExOperationDate.Name = "HDateTimePickerExOperationDate";
            HDateTimePickerExOperationDate.Size = new Size(180, 23);
            HDateTimePickerExOperationDate.TabIndex = 0;
            HDateTimePickerExOperationDate.Value = new DateTime(2024, 2, 19, 0, 0, 0, 0);
            // 
            // HTimeExFirstRollCallTime
            // 
            HTimeExFirstRollCallTime.CustomFormat = " HH時mm分";
            HTimeExFirstRollCallTime.Format = DateTimePickerFormat.Custom;
            HTimeExFirstRollCallTime.Location = new Point(104, 40);
            HTimeExFirstRollCallTime.Name = "HTimeExFirstRollCallTime";
            HTimeExFirstRollCallTime.Size = new Size(92, 23);
            HTimeExFirstRollCallTime.TabIndex = 1;
            HTimeExFirstRollCallTime.Value = new DateTime(2024, 2, 19, 0, 0, 0, 0);
            // 
            // h_LabelEx3
            // 
            h_LabelEx3.AutoSize = true;
            h_LabelEx3.Location = new Point(20, 72);
            h_LabelEx3.Name = "h_LabelEx3";
            h_LabelEx3.Size = new Size(79, 15);
            h_LabelEx3.TabIndex = 4;
            h_LabelEx3.Text = "最終搬入場所";
            // 
            // HComboBoxExLastPlantName
            // 
            HComboBoxExLastPlantName.FormattingEnabled = true;
            HComboBoxExLastPlantName.Location = new Point(104, 68);
            HComboBoxExLastPlantName.Name = "HComboBoxExLastPlantName";
            HComboBoxExLastPlantName.Size = new Size(180, 23);
            HComboBoxExLastPlantName.TabIndex = 2;
            // 
            // h_LabelEx4
            // 
            h_LabelEx4.AutoSize = true;
            h_LabelEx4.Location = new Point(44, 128);
            h_LabelEx4.Name = "h_LabelEx4";
            h_LabelEx4.Size = new Size(55, 15);
            h_LabelEx4.TabIndex = 6;
            h_LabelEx4.Text = "帰庫時刻";
            // 
            // h_LabelEx5
            // 
            h_LabelEx5.AutoSize = true;
            h_LabelEx5.Location = new Point(20, 100);
            h_LabelEx5.Name = "h_LabelEx5";
            h_LabelEx5.Size = new Size(79, 15);
            h_LabelEx5.TabIndex = 7;
            h_LabelEx5.Text = "最終搬入時刻";
            // 
            // h_LabelEx6
            // 
            h_LabelEx6.AutoSize = true;
            h_LabelEx6.Location = new Point(24, 156);
            h_LabelEx6.Name = "h_LabelEx6";
            h_LabelEx6.Size = new Size(76, 15);
            h_LabelEx6.TabIndex = 8;
            h_LabelEx6.Text = "出庫時メーター";
            // 
            // h_LabelEx7
            // 
            h_LabelEx7.AutoSize = true;
            h_LabelEx7.Location = new Point(24, 184);
            h_LabelEx7.Name = "h_LabelEx7";
            h_LabelEx7.Size = new Size(76, 15);
            h_LabelEx7.TabIndex = 9;
            h_LabelEx7.Text = "帰庫時メーター";
            // 
            // h_LabelEx8
            // 
            h_LabelEx8.AutoSize = true;
            h_LabelEx8.Location = new Point(32, 212);
            h_LabelEx8.Name = "h_LabelEx8";
            h_LabelEx8.Size = new Size(67, 15);
            h_LabelEx8.TabIndex = 10;
            h_LabelEx8.Text = "燃料給油量";
            // 
            // HTimeExLastPlantYmdHms
            // 
            HTimeExLastPlantYmdHms.CustomFormat = " HH時mm分";
            HTimeExLastPlantYmdHms.Format = DateTimePickerFormat.Custom;
            HTimeExLastPlantYmdHms.Location = new Point(104, 96);
            HTimeExLastPlantYmdHms.Name = "HTimeExLastPlantYmdHms";
            HTimeExLastPlantYmdHms.Size = new Size(92, 23);
            HTimeExLastPlantYmdHms.TabIndex = 3;
            HTimeExLastPlantYmdHms.Value = new DateTime(2024, 2, 19, 0, 0, 0, 0);
            // 
            // HTimeExLastRollCallYmdHms
            // 
            HTimeExLastRollCallYmdHms.CustomFormat = " HH時mm分";
            HTimeExLastRollCallYmdHms.Format = DateTimePickerFormat.Custom;
            HTimeExLastRollCallYmdHms.Location = new Point(104, 124);
            HTimeExLastRollCallYmdHms.Name = "HTimeExLastRollCallYmdHms";
            HTimeExLastRollCallYmdHms.Size = new Size(92, 23);
            HTimeExLastRollCallYmdHms.TabIndex = 4;
            HTimeExLastRollCallYmdHms.Value = new DateTime(2024, 2, 19, 0, 0, 0, 0);
            // 
            // HNumericUpDownExFirstOdoMeter
            // 
            HNumericUpDownExFirstOdoMeter.BorderStyle = BorderStyle.FixedSingle;
            HNumericUpDownExFirstOdoMeter.ImeMode = ImeMode.Off;
            HNumericUpDownExFirstOdoMeter.Location = new Point(104, 152);
            HNumericUpDownExFirstOdoMeter.Name = "HNumericUpDownExFirstOdoMeter";
            HNumericUpDownExFirstOdoMeter.Size = new Size(76, 23);
            HNumericUpDownExFirstOdoMeter.TabIndex = 5;
            HNumericUpDownExFirstOdoMeter.TextAlign = HorizontalAlignment.Right;
            // 
            // HNumericUpDownExLastOdoMeter
            // 
            HNumericUpDownExLastOdoMeter.BorderStyle = BorderStyle.FixedSingle;
            HNumericUpDownExLastOdoMeter.ImeMode = ImeMode.Off;
            HNumericUpDownExLastOdoMeter.Location = new Point(104, 180);
            HNumericUpDownExLastOdoMeter.Name = "HNumericUpDownExLastOdoMeter";
            HNumericUpDownExLastOdoMeter.Size = new Size(76, 23);
            HNumericUpDownExLastOdoMeter.TabIndex = 6;
            HNumericUpDownExLastOdoMeter.TextAlign = HorizontalAlignment.Right;
            // 
            // HNumericUpDownExOilAmount
            // 
            HNumericUpDownExOilAmount.BorderStyle = BorderStyle.FixedSingle;
            HNumericUpDownExOilAmount.ImeMode = ImeMode.Off;
            HNumericUpDownExOilAmount.Location = new Point(104, 208);
            HNumericUpDownExOilAmount.Name = "HNumericUpDownExOilAmount";
            HNumericUpDownExOilAmount.Size = new Size(76, 23);
            HNumericUpDownExOilAmount.TabIndex = 7;
            HNumericUpDownExOilAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(88, 256);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(136, 32);
            HButtonExUpdate.TabIndex = 8;
            HButtonExUpdate.Text = "Update";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            // 
            // H_LastRollCall
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 311);
            Controls.Add(HButtonExUpdate);
            Controls.Add(HNumericUpDownExOilAmount);
            Controls.Add(HNumericUpDownExLastOdoMeter);
            Controls.Add(HNumericUpDownExFirstOdoMeter);
            Controls.Add(HTimeExLastRollCallYmdHms);
            Controls.Add(HTimeExLastPlantYmdHms);
            Controls.Add(h_LabelEx8);
            Controls.Add(h_LabelEx7);
            Controls.Add(h_LabelEx6);
            Controls.Add(h_LabelEx5);
            Controls.Add(h_LabelEx4);
            Controls.Add(HComboBoxExLastPlantName);
            Controls.Add(h_LabelEx3);
            Controls.Add(HTimeExFirstRollCallTime);
            Controls.Add(HDateTimePickerExOperationDate);
            Controls.Add(h_LabelEx2);
            Controls.Add(h_LabelEx1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_LastRollCall";
            Text = "H_LastRollCall";
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExFirstOdoMeter).EndInit();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExLastOdoMeter).EndInit();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExOilAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_LabelEx h_LabelEx2;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerExOperationDate;
        private H_ControlEx.H_TimeEx HTimeExFirstRollCallTime;
        private H_ControlEx.H_LabelEx h_LabelEx3;
        private H_ControlEx.H_ComboBoxEx HComboBoxExLastPlantName;
        private H_ControlEx.H_LabelEx h_LabelEx4;
        private H_ControlEx.H_LabelEx h_LabelEx5;
        private H_ControlEx.H_LabelEx h_LabelEx6;
        private H_ControlEx.H_LabelEx h_LabelEx7;
        private H_ControlEx.H_LabelEx h_LabelEx8;
        private H_ControlEx.H_TimeEx HTimeExLastPlantYmdHms;
        private H_ControlEx.H_TimeEx HTimeExLastRollCallYmdHms;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExFirstOdoMeter;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExLastOdoMeter;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExOilAmount;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
    }
}