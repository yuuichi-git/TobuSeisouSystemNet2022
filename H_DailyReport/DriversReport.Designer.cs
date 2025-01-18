namespace H_DailyReport {
    partial class DriversReport {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversReport));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemPrintB5 = new ToolStripMenuItem();
            ToolStripMenuItemPrintB5Dialog = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            SpreadDriversReport = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewDriversReport = SpreadDriversReport.GetSheet(0);
            HPanelExUp = new H_ControlEx.H_PanelEx();
            h_LabelEx3 = new H_ControlEx.H_LabelEx();
            HComboBoxExPrinterName = new H_ControlEx.H_ComboBoxEx();
            h_LabelEx2 = new H_ControlEx.H_LabelEx();
            HNumericUpDownExYear = new H_ControlEx.H_NumericUpDownEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadDriversReport).BeginInit();
            HPanelExUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExYear).BeginInit();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(SpreadDriversReport, 0, 2);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1173, 961);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemPrint, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1173, 24);
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
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrintB5, ToolStripMenuItemPrintB5Dialog });
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(43, 20);
            ToolStripMenuItemPrint.Text = "印刷";
            // 
            // ToolStripMenuItemPrintB5
            // 
            ToolStripMenuItemPrintB5.Name = "ToolStripMenuItemPrintB5";
            ToolStripMenuItemPrintB5.Size = new Size(217, 22);
            ToolStripMenuItemPrintB5.Text = "B5で印刷する(直接印刷)";
            ToolStripMenuItemPrintB5.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemPrintB5Dialog
            // 
            ToolStripMenuItemPrintB5Dialog.Name = "ToolStripMenuItemPrintB5Dialog";
            ToolStripMenuItemPrintB5Dialog.Size = new Size(217, 22);
            ToolStripMenuItemPrintB5Dialog.Text = "B5で印刷する(ダイアログ表示)";
            ToolStripMenuItemPrintB5Dialog.Click += ToolStripMenuItem_Click;
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
            StatusStrip1.Location = new Point(0, 939);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1173, 22);
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
            // SpreadDriversReport
            // 
            SpreadDriversReport.AccessibleDescription = "SpreadDriversReport, Sheet1, Row 0, Column 0";
            SpreadDriversReport.Dock = DockStyle.Fill;
            SpreadDriversReport.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadDriversReport.Location = new Point(3, 87);
            SpreadDriversReport.Name = "SpreadDriversReport";
            SpreadDriversReport.Size = new Size(1167, 847);
            SpreadDriversReport.TabIndex = 2;
            // 
            // HPanelExUp
            // 
            HPanelExUp.Controls.Add(h_LabelEx3);
            HPanelExUp.Controls.Add(HComboBoxExPrinterName);
            HPanelExUp.Controls.Add(h_LabelEx2);
            HPanelExUp.Controls.Add(HNumericUpDownExYear);
            HPanelExUp.Controls.Add(h_LabelEx1);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1167, 54);
            HPanelExUp.TabIndex = 3;
            // 
            // h_LabelEx3
            // 
            h_LabelEx3.AutoSize = true;
            h_LabelEx3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            h_LabelEx3.Location = new Point(324, 16);
            h_LabelEx3.Name = "h_LabelEx3";
            h_LabelEx3.Size = new Size(58, 21);
            h_LabelEx3.TabIndex = 4;
            h_LabelEx3.Text = "出力先";
            // 
            // HComboBoxExPrinterName
            // 
            HComboBoxExPrinterName.FormattingEnabled = true;
            HComboBoxExPrinterName.Location = new Point(384, 16);
            HComboBoxExPrinterName.Name = "HComboBoxExPrinterName";
            HComboBoxExPrinterName.Size = new Size(256, 23);
            HComboBoxExPrinterName.TabIndex = 3;
            // 
            // h_LabelEx2
            // 
            h_LabelEx2.AutoSize = true;
            h_LabelEx2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            h_LabelEx2.Location = new Point(212, 16);
            h_LabelEx2.Name = "h_LabelEx2";
            h_LabelEx2.Size = new Size(26, 21);
            h_LabelEx2.TabIndex = 2;
            h_LabelEx2.Text = "年";
            // 
            // HNumericUpDownExYear
            // 
            HNumericUpDownExYear.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HNumericUpDownExYear.Location = new Point(160, 12);
            HNumericUpDownExYear.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            HNumericUpDownExYear.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            HNumericUpDownExYear.Name = "HNumericUpDownExYear";
            HNumericUpDownExYear.Size = new Size(48, 29);
            HNumericUpDownExYear.TabIndex = 1;
            HNumericUpDownExYear.TextAlign = HorizontalAlignment.Right;
            HNumericUpDownExYear.Value = new decimal(new int[] { 5, 0, 0, 0 });
            HNumericUpDownExYear.ValueChanged += HNumericUpDownExYear_ValueChanged;
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            h_LabelEx1.Location = new Point(36, 16);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(122, 21);
            h_LabelEx1.TabIndex = 0;
            h_LabelEx1.Text = "年号選択　令和";
            // 
            // DriversReport
            // 
            AccessibleRole = AccessibleRole.OutlineButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 961);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            Name = "DriversReport";
            Text = "DriversReport";
            FormClosing += DriversReport_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadDriversReport).EndInit();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExYear).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private FarPoint.Win.Spread.FpSpread SpreadDriversReport;
        private ToolStripMenuItem ToolStripMenuItemPrintB5;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private H_ControlEx.H_LabelEx h_LabelEx2;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExYear;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private ToolStripMenuItem ToolStripMenuItemPrintB5Dialog;
        private H_ControlEx.H_LabelEx h_LabelEx3;
        private H_ControlEx.H_ComboBoxEx HComboBoxExPrinterName;
        private FarPoint.Win.Spread.SheetView SheetViewDriversReport;
    }
}