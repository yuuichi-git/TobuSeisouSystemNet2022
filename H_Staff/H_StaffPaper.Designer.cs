namespace H_Staff {
    partial class HStaffPaper {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HStaffPaper));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemPrintA4 = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HTableLayoutPanelExMiddle = new H_ControlEx.H_TableLayoutPanelEx();
            SpreadStaffRegisterHead = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExMiddle.Controls"));
            SpreadStaffRegisterTail = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExMiddle.Controls1"));
            SheetStaffRegisterTail = SpreadStaffRegisterTail.GetSheet(0);
            SheetStaffRegisterHead = SpreadStaffRegisterHead.GetSheet(0);
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HTableLayoutPanelExMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadStaffRegisterHead).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpreadStaffRegisterTail).BeginInit();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 2);
            HTableLayoutPanelExBase.Controls.Add(HTableLayoutPanelExMiddle, 0, 1);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 3;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1902, 1216);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemPrint, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1902, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
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
            ToolStripMenuItemPrintA4.Size = new Size(165, 22);
            ToolStripMenuItemPrintA4.Text = "A4用紙で印刷する";
            ToolStripMenuItemPrintA4.Click += ToolStripMenuItemPrintA4_Click;
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
            StatusStrip1.Location = new Point(0, 1194);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1902, 22);
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
            // HTableLayoutPanelExMiddle
            // 
            HTableLayoutPanelExMiddle.ColumnCount = 2;
            HTableLayoutPanelExMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExMiddle.Controls.Add(SpreadStaffRegisterHead, 0, 0);
            HTableLayoutPanelExMiddle.Controls.Add(SpreadStaffRegisterTail, 1, 0);
            HTableLayoutPanelExMiddle.Dock = DockStyle.Fill;
            HTableLayoutPanelExMiddle.Location = new Point(3, 27);
            HTableLayoutPanelExMiddle.Name = "HTableLayoutPanelExMiddle";
            HTableLayoutPanelExMiddle.RowCount = 1;
            HTableLayoutPanelExMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExMiddle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExMiddle.Size = new Size(1896, 1162);
            HTableLayoutPanelExMiddle.TabIndex = 2;
            // 
            // SpreadStaffRegisterHead
            // 
            SpreadStaffRegisterHead.AccessibleDescription = "SpreadStaffRegisterHead, Sheet1, Row 0, Column 0";
            SpreadStaffRegisterHead.Dock = DockStyle.Fill;
            SpreadStaffRegisterHead.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadStaffRegisterHead.Location = new Point(3, 3);
            SpreadStaffRegisterHead.Name = "SpreadStaffRegisterHead";
            SpreadStaffRegisterHead.Size = new Size(942, 1156);
            SpreadStaffRegisterHead.TabIndex = 0;
            // 
            // SpreadStaffRegisterTail
            // 
            SpreadStaffRegisterTail.AccessibleDescription = "Book1, Sheet1, Row 0, Column 0";
            SpreadStaffRegisterTail.Dock = DockStyle.Fill;
            SpreadStaffRegisterTail.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadStaffRegisterTail.Location = new Point(951, 3);
            SpreadStaffRegisterTail.Name = "SpreadStaffRegisterTail";
            SpreadStaffRegisterTail.Size = new Size(942, 1156);
            SpreadStaffRegisterTail.TabIndex = 1;
            // 
            // HStaffPaper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1216);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MinimumSize = new Size(1918, 1046);
            Name = "HStaffPaper";
            Text = "H_StaffPaper";
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HTableLayoutPanelExMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpreadStaffRegisterHead).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpreadStaffRegisterTail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExMiddle;
        private FarPoint.Win.Spread.FpSpread SpreadStaffRegisterHead;
        private FarPoint.Win.Spread.FpSpread SpreadStaffRegisterTail;
        private FarPoint.Win.Spread.SheetView SheetStaffRegisterTail;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemPrintA4;
        private FarPoint.Win.Spread.SheetView SheetStaffRegisterHead;
    }
}