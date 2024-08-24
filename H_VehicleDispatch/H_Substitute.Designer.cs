namespace H_VehicleDispatch {
    partial class H_Substitute {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_Substitute));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            SpreadHSubstitute = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetView1 = SpreadHSubstitute.GetSheet(0);
            SheetView2 = SpreadHSubstitute.GetSheet(1);
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HLabelExFaxNumber = new H_ControlEx.H_LabelEx();
            h_LabelEx3 = new H_ControlEx.H_LabelEx();
            HComboBoxExPrinterName = new H_ControlEx.H_ComboBoxEx();
            HButtonExPrint = new H_ControlEx.H_ButtonEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            HTableLayoutPanelExBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadHSubstitute).BeginInit();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            MenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExBase.Controls.Add(SpreadHSubstitute, 0, 2);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1036, 1041);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // SpreadHSubstitute
            // 
            SpreadHSubstitute.AccessibleDescription = "SpreadHSubstitute, 共通, Row 0, Column 0";
            SpreadHSubstitute.Dock = DockStyle.Fill;
            SpreadHSubstitute.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadHSubstitute.Location = new Point(3, 87);
            SpreadHSubstitute.Name = "SpreadHSubstitute";
            SpreadHSubstitute.Size = new Size(1030, 927);
            SpreadHSubstitute.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1036, 22);
            StatusStrip1.TabIndex = 3;
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
            HPanelExUp.Controls.Add(HLabelExFaxNumber);
            HPanelExUp.Controls.Add(h_LabelEx3);
            HPanelExUp.Controls.Add(HComboBoxExPrinterName);
            HPanelExUp.Controls.Add(HButtonExPrint);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1030, 54);
            HPanelExUp.TabIndex = 1;
            // 
            // HLabelExFaxNumber
            // 
            HLabelExFaxNumber.BorderStyle = BorderStyle.Fixed3D;
            HLabelExFaxNumber.Font = new Font("Yu Gothic UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            HLabelExFaxNumber.ForeColor = Color.Red;
            HLabelExFaxNumber.Location = new Point(356, 4);
            HLabelExFaxNumber.Name = "HLabelExFaxNumber";
            HLabelExFaxNumber.Size = new Size(436, 42);
            HLabelExFaxNumber.TabIndex = 7;
            HLabelExFaxNumber.Text = "東京都環境衛生事業協同組合 練馬区支部事務局\r\nＦＡＸ ０３－５９４７－３４４１";
            // 
            // h_LabelEx3
            // 
            h_LabelEx3.AutoSize = true;
            h_LabelEx3.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            h_LabelEx3.Location = new Point(16, 18);
            h_LabelEx3.Name = "h_LabelEx3";
            h_LabelEx3.Size = new Size(54, 20);
            h_LabelEx3.TabIndex = 6;
            h_LabelEx3.Text = "出力先";
            // 
            // HComboBoxExPrinterName
            // 
            HComboBoxExPrinterName.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxExPrinterName.FormattingEnabled = true;
            HComboBoxExPrinterName.Location = new Point(76, 16);
            HComboBoxExPrinterName.Name = "HComboBoxExPrinterName";
            HComboBoxExPrinterName.Size = new Size(256, 23);
            HComboBoxExPrinterName.TabIndex = 5;
            // 
            // HButtonExPrint
            // 
            HButtonExPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HButtonExPrint.Location = new Point(834, 10);
            HButtonExPrint.Name = "HButtonExPrint";
            HButtonExPrint.Size = new Size(164, 32);
            HButtonExPrint.TabIndex = 0;
            HButtonExPrint.Text = "印刷 又は FAXする";
            HButtonExPrint.TextDirectionVertical = "";
            HButtonExPrint.UseVisualStyleBackColor = true;
            HButtonExPrint.Click += HButtonExPrint_Click;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1036, 24);
            MenuStrip1.TabIndex = 2;
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
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // H_Substitute
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 1041);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_Substitute";
            Text = "H_Substitute";
            FormClosing += H_Substitute_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadHSubstitute).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private FarPoint.Win.Spread.FpSpread SpreadHSubstitute;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_ButtonEx HButtonExPrint;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private H_ControlEx.H_LabelEx h_LabelEx3;
        private H_ControlEx.H_ComboBoxEx HComboBoxExPrinterName;
        private FarPoint.Win.Spread.SheetView SheetView1;
        private FarPoint.Win.Spread.SheetView SheetView2;
        private H_ControlEx.H_LabelEx HLabelExFaxNumber;
    }
}