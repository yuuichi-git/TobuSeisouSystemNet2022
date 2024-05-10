namespace H_CarAccident {
    partial class H_CarAccidentList {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_CarAccidentList));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemNew = new ToolStripMenuItem();
            ToolStripMenuItemNewFile = new ToolStripMenuItem();
            ToolStripMenuItemExport = new ToolStripMenuItem();
            ToolStripMenuItemExportExcel = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            HDateTimePickerExOccurrence2 = new H_ControlEx.H_DateTimePickerEx();
            h_LabelEx2 = new H_ControlEx.H_LabelEx();
            HDateTimePickerExOccurrence1 = new H_ControlEx.H_DateTimePickerEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(SpreadList, 0, 2);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1904, 1041);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemNew, ToolStripMenuItemExport, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1904, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(195, 22);
            ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            ToolStripMenuItemExit.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemNew
            // 
            ToolStripMenuItemNew.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemNewFile });
            ToolStripMenuItemNew.Name = "ToolStripMenuItemNew";
            ToolStripMenuItemNew.Size = new Size(43, 20);
            ToolStripMenuItemNew.Text = "新規";
            // 
            // ToolStripMenuItemNewFile
            // 
            ToolStripMenuItemNewFile.Name = "ToolStripMenuItemNewFile";
            ToolStripMenuItemNewFile.Size = new Size(180, 22);
            ToolStripMenuItemNewFile.Text = "新しい記録を作成する";
            ToolStripMenuItemNewFile.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemExport
            // 
            ToolStripMenuItemExport.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemExportExcel });
            ToolStripMenuItemExport.Name = "ToolStripMenuItemExport";
            ToolStripMenuItemExport.Size = new Size(72, 20);
            ToolStripMenuItemExport.Text = "エクスポート";
            // 
            // ToolStripMenuItemExportExcel
            // 
            ToolStripMenuItemExportExcel.Name = "ToolStripMenuItemExportExcel";
            ToolStripMenuItemExportExcel.Size = new Size(235, 22);
            ToolStripMenuItemExportExcel.Text = "Excel(xlsx)形式でエクスポートする";
            ToolStripMenuItemExportExcel.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 22);
            StatusStrip1.SizingGrip = false;
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelDetail
            // 
            ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            ToolStripStatusLabelDetail.Size = new Size(143, 17);
            ToolStripStatusLabelDetail.Text = "ToolStripStatusLabelDetail";
            // 
            // HPanelExUp
            // 
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Controls.Add(HDateTimePickerExOccurrence2);
            HPanelExUp.Controls.Add(h_LabelEx2);
            HPanelExUp.Controls.Add(HDateTimePickerExOccurrence1);
            HPanelExUp.Controls.Add(h_LabelEx1);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1898, 54);
            HPanelExUp.TabIndex = 2;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(1680, 12);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(156, 32);
            HButtonExUpdate.TabIndex = 4;
            HButtonExUpdate.Text = "最 新 化";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // HDateTimePickerExOccurrence2
            // 
            HDateTimePickerExOccurrence2.CustomFormat = " yyyy年MM月dd日(dddd)";
            HDateTimePickerExOccurrence2.Format = DateTimePickerFormat.Custom;
            HDateTimePickerExOccurrence2.Location = new Point(328, 16);
            HDateTimePickerExOccurrence2.Name = "HDateTimePickerExOccurrence2";
            HDateTimePickerExOccurrence2.Size = new Size(184, 23);
            HDateTimePickerExOccurrence2.TabIndex = 3;
            HDateTimePickerExOccurrence2.Value = new DateTime(2024, 5, 8, 0, 0, 0, 0);
            HDateTimePickerExOccurrence2.ValueChanged += HDateTimePickerExOccurrence2_ValueChanged;
            // 
            // h_LabelEx2
            // 
            h_LabelEx2.AutoSize = true;
            h_LabelEx2.Location = new Point(304, 20);
            h_LabelEx2.Name = "h_LabelEx2";
            h_LabelEx2.Size = new Size(19, 15);
            h_LabelEx2.TabIndex = 2;
            h_LabelEx2.Text = "～";
            // 
            // HDateTimePickerExOccurrence1
            // 
            HDateTimePickerExOccurrence1.CustomFormat = " yyyy年MM月dd日(dddd)";
            HDateTimePickerExOccurrence1.Format = DateTimePickerFormat.Custom;
            HDateTimePickerExOccurrence1.Location = new Point(116, 16);
            HDateTimePickerExOccurrence1.Name = "HDateTimePickerExOccurrence1";
            HDateTimePickerExOccurrence1.Size = new Size(184, 23);
            HDateTimePickerExOccurrence1.TabIndex = 1;
            HDateTimePickerExOccurrence1.Value = new DateTime(2024, 5, 8, 0, 0, 0, 0);
            HDateTimePickerExOccurrence1.ValueChanged += HDateTimePickerExOccurrence1_ValueChanged;
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(44, 20);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(67, 15);
            h_LabelEx1.TabIndex = 0;
            h_LabelEx1.Text = "事故発生日";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "Book1, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 927);
            SpreadList.TabIndex = 3;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // H_CarAccidentList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(HTableLayoutPanelExBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_CarAccidentList";
            Text = "H_CarAccidentList";
            FormClosing += H_CarAccidentList_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerExOccurrence2;
        private H_ControlEx.H_LabelEx h_LabelEx2;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerExOccurrence1;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private ToolStripMenuItem ToolStripMenuItemExport;
        private ToolStripMenuItem ToolStripMenuItemExportExcel;
        private ToolStripMenuItem ToolStripMenuItemNew;
        private ToolStripMenuItem ToolStripMenuItemNewFile;
    }
}
