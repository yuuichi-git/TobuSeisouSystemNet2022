namespace H_Toukanpo {
    partial class H_ToukanpoSpeedSurvey {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_ToukanpoSpeedSurvey));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemExport = new ToolStripMenuItem();
            ToolStripMenuItemExportExcel = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            h_LabelEx3 = new H_ControlEx.H_LabelEx();
            HNumericUpDownExMonth = new H_ControlEx.H_NumericUpDownEx();
            h_LabelEx2 = new H_ControlEx.H_LabelEx();
            HNumericUpDownExYear = new H_ControlEx.H_NumericUpDownEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExYear).BeginInit();
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
            HTableLayoutPanelExBase.Size = new Size(743, 996);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemExport, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(743, 24);
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
            StatusStrip1.Location = new Point(0, 974);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(743, 22);
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
            HPanelExUp.Controls.Add(h_LabelEx3);
            HPanelExUp.Controls.Add(HNumericUpDownExMonth);
            HPanelExUp.Controls.Add(h_LabelEx2);
            HPanelExUp.Controls.Add(HNumericUpDownExYear);
            HPanelExUp.Controls.Add(h_LabelEx1);
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(737, 54);
            HPanelExUp.TabIndex = 2;
            // 
            // h_LabelEx3
            // 
            h_LabelEx3.AutoSize = true;
            h_LabelEx3.Location = new Point(228, 20);
            h_LabelEx3.Name = "h_LabelEx3";
            h_LabelEx3.Size = new Size(31, 15);
            h_LabelEx3.TabIndex = 5;
            h_LabelEx3.Text = "月分";
            // 
            // HNumericUpDownExMonth
            // 
            HNumericUpDownExMonth.Location = new Point(184, 16);
            HNumericUpDownExMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            HNumericUpDownExMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            HNumericUpDownExMonth.Name = "HNumericUpDownExMonth";
            HNumericUpDownExMonth.Size = new Size(40, 23);
            HNumericUpDownExMonth.TabIndex = 4;
            HNumericUpDownExMonth.TextAlign = HorizontalAlignment.Center;
            HNumericUpDownExMonth.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // h_LabelEx2
            // 
            h_LabelEx2.AutoSize = true;
            h_LabelEx2.Location = new Point(160, 20);
            h_LabelEx2.Name = "h_LabelEx2";
            h_LabelEx2.Size = new Size(19, 15);
            h_LabelEx2.TabIndex = 3;
            h_LabelEx2.Text = "年";
            // 
            // HNumericUpDownExYear
            // 
            HNumericUpDownExYear.Location = new Point(100, 16);
            HNumericUpDownExYear.Maximum = new decimal(new int[] { 2025, 0, 0, 0 });
            HNumericUpDownExYear.Minimum = new decimal(new int[] { 2024, 0, 0, 0 });
            HNumericUpDownExYear.Name = "HNumericUpDownExYear";
            HNumericUpDownExYear.Size = new Size(56, 23);
            HNumericUpDownExYear.TabIndex = 2;
            HNumericUpDownExYear.TextAlign = HorizontalAlignment.Center;
            HNumericUpDownExYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(16, 20);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(79, 15);
            h_LabelEx1.TabIndex = 1;
            h_LabelEx1.Text = "集計対象年月";
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(564, 12);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(140, 32);
            HButtonExUpdate.TabIndex = 0;
            HButtonExUpdate.Text = "最 新 化";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, 速度調査, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(737, 882);
            SpreadList.TabIndex = 3;
            // 
            // H_ToukanpoSpeedSurvey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 996);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_ToukanpoSpeedSurvey";
            Text = "H_ToukanpoSpeedSurvey";
            FormClosing += H_ToukanpoSpeedSurvey_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private ToolStripMenuItem ToolStripMenuItemExport;
        private ToolStripMenuItem ToolStripMenuItemExportExcel;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_LabelEx h_LabelEx3;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExMonth;
        private H_ControlEx.H_LabelEx h_LabelEx2;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExYear;
    }
}