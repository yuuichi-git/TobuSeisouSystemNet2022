namespace Supply {
    partial class SupplyIn {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyIn));
            TableLayoutPanelBase = new TableLayoutPanel();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"));
            SheetViewList = SpreadList.GetSheet(0);
            PanelUp = new Panel();
            ButtonUpdate = new Button();
            label1 = new Label();
            MonthPicker1 = new ControlEx.MonthPicker();
            label3 = new Label();
            ComboBoxSupplyType = new ComboBox();
            TableLayoutPanelBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            PanelUp.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(572, 777);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 101);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(566, 649);
            SpreadList.TabIndex = 0;
            // 
            // PanelUp
            // 
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(MonthPicker1);
            PanelUp.Controls.Add(label3);
            PanelUp.Controls.Add(ComboBoxSupplyType);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(566, 68);
            PanelUp.TabIndex = 1;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(365, 16);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 12;
            ButtonUpdate.Text = "UPDATE";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(60, 17);
            label1.TabIndex = 11;
            label1.Text = "棚卸年月";
            // 
            // MonthPicker1
            // 
            MonthPicker1.CustomFormat = "yyyy年MM月";
            MonthPicker1.Format = DateTimePickerFormat.Custom;
            MonthPicker1.Location = new Point(84, 8);
            MonthPicker1.Name = "MonthPicker1";
            MonthPicker1.Size = new Size(104, 23);
            MonthPicker1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 40);
            label3.Name = "label3";
            label3.Size = new Size(60, 17);
            label3.TabIndex = 9;
            label3.Text = "在庫種別";
            // 
            // ComboBoxSupplyType
            // 
            ComboBoxSupplyType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSupplyType.FormattingEnabled = true;
            ComboBoxSupplyType.Items.AddRange(new object[] { "事務での備品", "雇上での備品", "産廃での備品", "水物での備品" });
            ComboBoxSupplyType.Location = new Point(84, 36);
            ComboBoxSupplyType.Name = "ComboBoxSupplyType";
            ComboBoxSupplyType.Size = new Size(140, 23);
            ComboBoxSupplyType.TabIndex = 8;
            // 
            // SupplyIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 777);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SupplyIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplyIn";
            TopMost = true;
            TableLayoutPanelBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private Panel PanelUp;
        private Label label3;
        private ComboBox ComboBoxSupplyType;
        private ControlEx.MonthPicker MonthPicker1;
        private Label label1;
        private Button ButtonUpdate;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}