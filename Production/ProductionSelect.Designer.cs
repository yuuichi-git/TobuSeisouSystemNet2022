namespace Production {
    partial class ProductionSelect {
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
            this.LabelDayOfWeek = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LabelCellNumber = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.LabelNumberOfPeople = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ComboBoxSetName = new System.Windows.Forms.ComboBox();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelDayOfWeek
            // 
            this.LabelDayOfWeek.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelDayOfWeek.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelDayOfWeek.Location = new System.Drawing.Point(120, 104);
            this.LabelDayOfWeek.Name = "LabelDayOfWeek";
            this.LabelDayOfWeek.Size = new System.Drawing.Size(112, 24);
            this.LabelDayOfWeek.TabIndex = 142;
            this.LabelDayOfWeek.Text = "月火水木金土日 ";
            this.LabelDayOfWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(28, 107);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 20);
            this.label18.TabIndex = 141;
            this.label18.Text = "配車曜日：";
            // 
            // LabelCellNumber
            // 
            this.LabelCellNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelCellNumber.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelCellNumber.Location = new System.Drawing.Point(120, 8);
            this.LabelCellNumber.Name = "LabelCellNumber";
            this.LabelCellNumber.Size = new System.Drawing.Size(112, 24);
            this.LabelCellNumber.TabIndex = 140;
            this.LabelCellNumber.Text = "88";
            this.LabelCellNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(28, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 20);
            this.label17.TabIndex = 139;
            this.label17.Text = "配車番号：";
            // 
            // LabelNumberOfPeople
            // 
            this.LabelNumberOfPeople.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelNumberOfPeople.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelNumberOfPeople.Location = new System.Drawing.Point(120, 72);
            this.LabelNumberOfPeople.Name = "LabelNumberOfPeople";
            this.LabelNumberOfPeople.Size = new System.Drawing.Size(112, 24);
            this.LabelNumberOfPeople.TabIndex = 138;
            this.LabelNumberOfPeople.Text = "4人";
            this.LabelNumberOfPeople.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(28, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 20);
            this.label16.TabIndex = 137;
            this.label16.Text = "配車人数：";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(28, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 20);
            this.label13.TabIndex = 135;
            this.label13.Text = "配  車  先：";
            // 
            // ComboBoxSetName
            // 
            this.ComboBoxSetName.FormattingEnabled = true;
            this.ComboBoxSetName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ComboBoxSetName.Location = new System.Drawing.Point(120, 40);
            this.ComboBoxSetName.Name = "ComboBoxSetName";
            this.ComboBoxSetName.Size = new System.Drawing.Size(112, 23);
            this.ComboBoxSetName.TabIndex = 143;
            this.ComboBoxSetName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSetName_SelectedIndexChanged);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(60, 144);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(148, 32);
            this.ButtonUpdate.TabIndex = 144;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ProductionSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 186);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ComboBoxSetName);
            this.Controls.Add(this.LabelDayOfWeek);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.LabelCellNumber);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.LabelNumberOfPeople);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductionSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductionSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private Label LabelDayOfWeek;
        private Label label18;
        private Label LabelCellNumber;
        private Label label17;
        private Label LabelNumberOfPeople;
        private Label label16;
        private Label label13;
        private ComboBox ComboBoxSetName;
        private Button ButtonUpdate;
    }
}