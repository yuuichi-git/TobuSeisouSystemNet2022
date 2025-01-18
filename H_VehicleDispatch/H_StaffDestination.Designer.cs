namespace H_VehicleDispatch {
    partial class H_StaffDestination {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_StaffDestination));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemPrintA4 = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            label2 = new Label();
            label1 = new Label();
            HComboBoxExSelectName = new H_ControlEx.H_ComboBoxEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            h_LabelEx2 = new H_ControlEx.H_LabelEx();
            HDateTimePickerExOperationDate2 = new H_ControlEx.H_DateTimePickerEx();
            HDateTimePickerExOperationDate1 = new H_ControlEx.H_DateTimePickerEx();
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
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(SpreadList, 0, 2);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1192, 738);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemPrint, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1192, 24);
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
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrintA4 });
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(43, 20);
            ToolStripMenuItemPrint.Text = "印刷";
            // 
            // ToolStripMenuItemPrintA4
            // 
            ToolStripMenuItemPrintA4.Name = "ToolStripMenuItemPrintA4";
            ToolStripMenuItemPrintA4.Size = new Size(139, 22);
            ToolStripMenuItemPrintA4.Text = "印刷する(A4)";
            ToolStripMenuItemPrintA4.Click += ToolStripMenuItem_Click;
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
            StatusStrip1.Location = new Point(0, 716);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1192, 22);
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
            HPanelExUp.Controls.Add(label2);
            HPanelExUp.Controls.Add(label1);
            HPanelExUp.Controls.Add(HComboBoxExSelectName);
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Controls.Add(h_LabelEx2);
            HPanelExUp.Controls.Add(HDateTimePickerExOperationDate2);
            HPanelExUp.Controls.Add(HDateTimePickerExOperationDate1);
            HPanelExUp.Controls.Add(h_LabelEx1);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1186, 84);
            HPanelExUp.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 52);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 9;
            label2.Text = "(従事者マスターから選択して下さい)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 52);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 8;
            label1.Text = "氏名";
            // 
            // HComboBoxExSelectName
            // 
            HComboBoxExSelectName.FormattingEnabled = true;
            HComboBoxExSelectName.ImeMode = ImeMode.Hiragana;
            HComboBoxExSelectName.Location = new Point(76, 48);
            HComboBoxExSelectName.Name = "HComboBoxExSelectName";
            HComboBoxExSelectName.Size = new Size(196, 23);
            HComboBoxExSelectName.TabIndex = 7;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HButtonExUpdate.Location = new Point(996, 24);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(148, 32);
            HButtonExUpdate.TabIndex = 6;
            HButtonExUpdate.Text = "最　新　化";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // h_LabelEx2
            // 
            h_LabelEx2.AutoSize = true;
            h_LabelEx2.Location = new Point(268, 20);
            h_LabelEx2.Name = "h_LabelEx2";
            h_LabelEx2.Size = new Size(19, 15);
            h_LabelEx2.TabIndex = 5;
            h_LabelEx2.Text = "～";
            // 
            // HDateTimePickerExOperationDate2
            // 
            HDateTimePickerExOperationDate2.CustomFormat = " 令和05年10月10日(火曜日)";
            HDateTimePickerExOperationDate2.Format = DateTimePickerFormat.Custom;
            HDateTimePickerExOperationDate2.Location = new Point(292, 16);
            HDateTimePickerExOperationDate2.Name = "HDateTimePickerExOperationDate2";
            HDateTimePickerExOperationDate2.Size = new Size(186, 23);
            HDateTimePickerExOperationDate2.TabIndex = 4;
            HDateTimePickerExOperationDate2.TabStop = false;
            HDateTimePickerExOperationDate2.Value = new DateTime(2023, 10, 10, 0, 0, 0, 0);
            HDateTimePickerExOperationDate2.ValueChanged += HDateTimePickerExOperationDate2_ValueChanged;
            // 
            // HDateTimePickerExOperationDate1
            // 
            HDateTimePickerExOperationDate1.CustomFormat = " 令和05年10月10日(火曜日)";
            HDateTimePickerExOperationDate1.Format = DateTimePickerFormat.Custom;
            HDateTimePickerExOperationDate1.Location = new Point(76, 16);
            HDateTimePickerExOperationDate1.Name = "HDateTimePickerExOperationDate1";
            HDateTimePickerExOperationDate1.Size = new Size(186, 23);
            HDateTimePickerExOperationDate1.TabIndex = 2;
            HDateTimePickerExOperationDate1.TabStop = false;
            HDateTimePickerExOperationDate1.Value = new DateTime(2023, 10, 10, 0, 0, 0, 0);
            HDateTimePickerExOperationDate1.ValueChanged += HDateTimePickerExOperationDate1_ValueChanged;
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(28, 20);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(43, 15);
            h_LabelEx1.TabIndex = 3;
            h_LabelEx1.Text = "配車日";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 117);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1186, 594);
            SpreadList.TabIndex = 3;
            // 
            // H_StaffDestination
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 738);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_StaffDestination";
            Text = "H_StaffDestination";
            FormClosing += H_StaffDestination_FormClosing;
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
        private H_ControlEx.H_LabelEx h_LabelEx2;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerExOperationDate2;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerExOperationDate1;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemPrintA4;
        private Label label2;
        private Label label1;
        private H_ControlEx.H_ComboBoxEx HComboBoxExSelectName;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}