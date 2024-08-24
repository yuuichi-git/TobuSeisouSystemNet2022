namespace H_LegalTwelveItem {
    partial class H_LegalTwelveItemList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_LegalTwelveItemList));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemPrintA4 = new ToolStripMenuItem();
            ToolStripMenuItemPrintA4Dialog = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HCheckBoxExJobForm = new H_ControlEx.H_CheckBoxEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            h_LabelEx2 = new H_ControlEx.H_LabelEx();
            HNumericUpDownExFiscalYear = new H_ControlEx.H_NumericUpDownEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExFiscalYear).BeginInit();
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
            HTableLayoutPanelExBase.Size = new Size(1172, 961);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemPrint, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1172, 24);
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
            ToolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrintA4, ToolStripMenuItemPrintA4Dialog });
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(43, 20);
            ToolStripMenuItemPrint.Text = "印刷";
            // 
            // ToolStripMenuItemPrintA4
            // 
            ToolStripMenuItemPrintA4.Name = "ToolStripMenuItemPrintA4";
            ToolStripMenuItemPrintA4.Size = new Size(218, 22);
            ToolStripMenuItemPrintA4.Text = "A4で印刷する(直接印刷)";
            ToolStripMenuItemPrintA4.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemPrintA4Dialog
            // 
            ToolStripMenuItemPrintA4Dialog.Name = "ToolStripMenuItemPrintA4Dialog";
            ToolStripMenuItemPrintA4Dialog.Size = new Size(218, 22);
            ToolStripMenuItemPrintA4Dialog.Text = "A4で印刷する(ダイアログ印刷)";
            ToolStripMenuItemPrintA4Dialog.Click += ToolStripMenuItem_Click;
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
            StatusStrip1.Size = new Size(1172, 22);
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
            HPanelExUp.Controls.Add(HCheckBoxExJobForm);
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Controls.Add(h_LabelEx2);
            HPanelExUp.Controls.Add(HNumericUpDownExFiscalYear);
            HPanelExUp.Controls.Add(h_LabelEx1);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1166, 54);
            HPanelExUp.TabIndex = 2;
            // 
            // HCheckBoxExJobForm
            // 
            HCheckBoxExJobForm.AutoSize = true;
            HCheckBoxExJobForm.Location = new Point(244, 20);
            HCheckBoxExJobForm.Name = "HCheckBoxExJobForm";
            HCheckBoxExJobForm.Size = new Size(114, 19);
            HCheckBoxExJobForm.TabIndex = 4;
            HCheckBoxExJobForm.Text = "短期雇用も含める";
            HCheckBoxExJobForm.UseVisualStyleBackColor = true;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(960, 12);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(168, 32);
            HButtonExUpdate.TabIndex = 3;
            HButtonExUpdate.Text = "最 新 化";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // h_LabelEx2
            // 
            h_LabelEx2.AutoSize = true;
            h_LabelEx2.Location = new Point(136, 20);
            h_LabelEx2.Name = "h_LabelEx2";
            h_LabelEx2.Size = new Size(31, 15);
            h_LabelEx2.TabIndex = 2;
            h_LabelEx2.Text = "年度";
            // 
            // HNumericUpDownExFiscalYear
            // 
            HNumericUpDownExFiscalYear.Location = new Point(80, 16);
            HNumericUpDownExFiscalYear.Maximum = new decimal(new int[] { 2025, 0, 0, 0 });
            HNumericUpDownExFiscalYear.Minimum = new decimal(new int[] { 2023, 0, 0, 0 });
            HNumericUpDownExFiscalYear.Name = "HNumericUpDownExFiscalYear";
            HNumericUpDownExFiscalYear.Size = new Size(52, 23);
            HNumericUpDownExFiscalYear.TabIndex = 1;
            HNumericUpDownExFiscalYear.TextAlign = HorizontalAlignment.Right;
            HNumericUpDownExFiscalYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(20, 20);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(55, 15);
            h_LabelEx1.TabIndex = 0;
            h_LabelEx1.Text = "対象年度";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1166, 847);
            SpreadList.TabIndex = 3;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // H_LegalTwelveItemList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 961);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_LegalTwelveItemList";
            Text = "H_LegalTwelveItemList";
            FormClosing += H_LegalTwelveItemList_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HNumericUpDownExFiscalYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemPrintA4;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private H_ControlEx.H_LabelEx h_LabelEx2;
        private H_ControlEx.H_NumericUpDownEx HNumericUpDownExFiscalYear;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private H_ControlEx.H_CheckBoxEx HCheckBoxExJobForm;
        private ToolStripMenuItem ToolStripMenuItemPrintA4Dialog;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}
