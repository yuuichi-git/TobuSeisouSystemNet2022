namespace CarAccident {
    partial class CarAccidentList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarAccidentList));
            TableLayoutPanelBase = new TableLayoutPanel();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelStatus = new ToolStripStatusLabel();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelBase.Controls"));
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExportExcel = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemEdit = new ToolStripMenuItem();
            ToolStripMenuItemNew = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            PanelUp = new Panel();
            DateTimePickerOccurrenceDate2 = new DateTimePicker();
            label1 = new Label();
            DateTimePickerOccurrenceDate1 = new DateTimePicker();
            label7 = new Label();
            ButtonUpdate = new Button();
            SheetViewList = SpreadList.GetSheet(0);
            TableLayoutPanelBase.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            MenuStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(1904, 1041);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelStatus });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 22);
            StatusStrip1.TabIndex = 3;
            StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelStatus
            // 
            ToolStripStatusLabelStatus.Name = "ToolStripStatusLabelStatus";
            ToolStripStatusLabelStatus.Size = new Size(143, 17);
            ToolStripStatusLabelStatus.Text = "ToolStripStatusLabelDetail";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 927);
            SpreadList.TabIndex = 0;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemEdit, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1904, 24);
            MenuStrip1.TabIndex = 1;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemExportExcel, ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemExportExcel
            // 
            ToolStripMenuItemExportExcel.Name = "ToolStripMenuItemExportExcel";
            ToolStripMenuItemExportExcel.Size = new Size(207, 22);
            ToolStripMenuItemExportExcel.Text = "Excel形式でエクスポートする";
            ToolStripMenuItemExportExcel.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(207, 22);
            ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // ToolStripMenuItemEdit
            // 
            ToolStripMenuItemEdit.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemNew });
            ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            ToolStripMenuItemEdit.Size = new Size(43, 20);
            ToolStripMenuItemEdit.Text = "編集";
            // 
            // ToolStripMenuItemNew
            // 
            ToolStripMenuItemNew.Name = "ToolStripMenuItemNew";
            ToolStripMenuItemNew.Size = new Size(183, 22);
            ToolStripMenuItemNew.Text = "新規レコードを作成する";
            ToolStripMenuItemNew.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // PanelUp
            // 
            PanelUp.Controls.Add(DateTimePickerOccurrenceDate2);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(DateTimePickerOccurrenceDate1);
            PanelUp.Controls.Add(label7);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(1898, 54);
            PanelUp.TabIndex = 2;
            // 
            // DateTimePickerOccurrenceDate2
            // 
            DateTimePickerOccurrenceDate2.CustomFormat = "yyyy年MM月dd日(ddd)";
            DateTimePickerOccurrenceDate2.Format = DateTimePickerFormat.Custom;
            DateTimePickerOccurrenceDate2.Location = new Point(300, 16);
            DateTimePickerOccurrenceDate2.Name = "DateTimePickerOccurrenceDate2";
            DateTimePickerOccurrenceDate2.Size = new Size(144, 23);
            DateTimePickerOccurrenceDate2.TabIndex = 21;
            DateTimePickerOccurrenceDate2.ValueChanged += DateTimePickerOccurrenceDate2_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(276, 20);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 20;
            label1.Text = "～";
            // 
            // DateTimePickerOccurrenceDate1
            // 
            DateTimePickerOccurrenceDate1.CustomFormat = "yyyy年MM月dd日(ddd)";
            DateTimePickerOccurrenceDate1.Format = DateTimePickerFormat.Custom;
            DateTimePickerOccurrenceDate1.Location = new Point(128, 16);
            DateTimePickerOccurrenceDate1.Name = "DateTimePickerOccurrenceDate1";
            DateTimePickerOccurrenceDate1.Size = new Size(144, 23);
            DateTimePickerOccurrenceDate1.TabIndex = 19;
            DateTimePickerOccurrenceDate1.ValueChanged += DateTimePickerOccurrenceDate1_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 20);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 18;
            label7.Text = "事故発生日時";
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1672, 9);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 0;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // CarAccidentList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TableLayoutPanelBase);
            MainMenuStrip = MenuStrip1;
            Name = "CarAccidentList";
            Text = "CarAccidentList";
            FormClosing += CarAccidentList_FormClosing;
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private Panel PanelUp;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private Button ButtonUpdate;
        private DateTimePicker DateTimePickerOccurrenceDate2;
        private Label label1;
        private DateTimePicker DateTimePickerOccurrenceDate1;
        private Label label7;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemNew;
        private ToolStripMenuItem ToolStripMenuItemExportExcel;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}