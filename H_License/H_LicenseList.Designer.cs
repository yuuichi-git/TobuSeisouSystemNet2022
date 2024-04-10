namespace H_License {
    partial class HLicenseList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HLicenseList));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemNew = new ToolStripMenuItem();
            ToolStripMenuItemNewLicense = new ToolStripMenuItem();
            ToolStripMenuItemDisplay = new ToolStripMenuItem();
            ToolStripMenuItemDeleted = new ToolStripMenuItem();
            ToolStripMenuItemOutput = new ToolStripMenuItem();
            ToolStripMenuItemToukaiCSV = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            HTabControlExKANA = new H_ControlEx.H_TabControlEx();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabPage9 = new TabPage();
            tabPage10 = new TabPage();
            tabPage11 = new TabPage();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"));
            SheetViewList = SpreadList.GetSheet(0);
            SheetViewToukaidenshi = SpreadList.GetSheet(1);
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            HTabControlExKANA.SuspendLayout();
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
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemNew, ToolStripMenuItemDisplay, ToolStripMenuItemOutput, ToolStripMenuItemHelp });
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
            // 
            // ToolStripMenuItemNew
            // 
            ToolStripMenuItemNew.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemNewLicense });
            ToolStripMenuItemNew.Name = "ToolStripMenuItemNew";
            ToolStripMenuItemNew.Size = new Size(43, 20);
            ToolStripMenuItemNew.Text = "新規";
            // 
            // ToolStripMenuItemNewLicense
            // 
            ToolStripMenuItemNewLicense.Name = "ToolStripMenuItemNewLicense";
            ToolStripMenuItemNewLicense.Size = new Size(183, 22);
            ToolStripMenuItemNewLicense.Text = "新規レコードを追加する";
            ToolStripMenuItemNewLicense.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemDisplay
            // 
            ToolStripMenuItemDisplay.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemDeleted });
            ToolStripMenuItemDisplay.Name = "ToolStripMenuItemDisplay";
            ToolStripMenuItemDisplay.Size = new Size(43, 20);
            ToolStripMenuItemDisplay.Text = "表示";
            // 
            // ToolStripMenuItemDeleted
            // 
            ToolStripMenuItemDeleted.CheckOnClick = true;
            ToolStripMenuItemDeleted.Name = "ToolStripMenuItemDeleted";
            ToolStripMenuItemDeleted.Size = new Size(162, 22);
            ToolStripMenuItemDeleted.Text = "削除済も表示する";
            // 
            // ToolStripMenuItemOutput
            // 
            ToolStripMenuItemOutput.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemToukaiCSV });
            ToolStripMenuItemOutput.Name = "ToolStripMenuItemOutput";
            ToolStripMenuItemOutput.Size = new Size(43, 20);
            ToolStripMenuItemOutput.Text = "出力";
            // 
            // ToolStripMenuItemToukaiCSV
            // 
            ToolStripMenuItemToukaiCSV.Name = "ToolStripMenuItemToukaiCSV";
            ToolStripMenuItemToukaiCSV.Size = new Size(237, 22);
            ToolStripMenuItemToukaiCSV.Text = "東海電子ALC用のCSVを作成する";
            ToolStripMenuItemToukaiCSV.Click += ToolStripMenuItem_Click;
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
            HPanelExUp.Controls.Add(HTabControlExKANA);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(0, 24);
            HPanelExUp.Margin = new Padding(0);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1904, 60);
            HPanelExUp.TabIndex = 2;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(1688, 12);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(148, 32);
            HButtonExUpdate.TabIndex = 1;
            HButtonExUpdate.Text = "最　新　化";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // HTabControlExKANA
            // 
            HTabControlExKANA.Controls.Add(tabPage1);
            HTabControlExKANA.Controls.Add(tabPage2);
            HTabControlExKANA.Controls.Add(tabPage3);
            HTabControlExKANA.Controls.Add(tabPage4);
            HTabControlExKANA.Controls.Add(tabPage5);
            HTabControlExKANA.Controls.Add(tabPage6);
            HTabControlExKANA.Controls.Add(tabPage7);
            HTabControlExKANA.Controls.Add(tabPage8);
            HTabControlExKANA.Controls.Add(tabPage9);
            HTabControlExKANA.Controls.Add(tabPage10);
            HTabControlExKANA.Controls.Add(tabPage11);
            HTabControlExKANA.Location = new Point(4, 32);
            HTabControlExKANA.Name = "HTabControlExKANA";
            HTabControlExKANA.SelectedIndex = 0;
            HTabControlExKANA.Size = new Size(1896, 28);
            HTabControlExKANA.SizeMode = TabSizeMode.Fixed;
            HTabControlExKANA.TabIndex = 0;
            HTabControlExKANA.Click += HTabControlExKANA_Click;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1888, 0);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "全て";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1888, 0);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "あ行";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1888, 0);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "か行";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1888, 0);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "さ行";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1888, 0);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "た行";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1888, 0);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "な行";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1888, 0);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "は行";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1888, 0);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "ま行";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 24);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1888, 0);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "や行";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            tabPage10.Location = new Point(4, 24);
            tabPage10.Name = "tabPage10";
            tabPage10.Size = new Size(1888, 0);
            tabPage10.TabIndex = 9;
            tabPage10.Text = "ら行";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Location = new Point(4, 24);
            tabPage11.Name = "tabPage11";
            tabPage11.Size = new Size(1888, 0);
            tabPage11.TabIndex = 10;
            tabPage11.Text = "わ行";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, 東海電子, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 927);
            SpreadList.TabIndex = 3;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // HLicenseList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(HTableLayoutPanelExBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            Name = "HLicenseList";
            Text = "H_LicenseList";
            FormClosing += H_LicenseList_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HTabControlExKANA.ResumeLayout(false);
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
        private H_ControlEx.H_TabControlEx HTabControlExKANA;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripMenuItem ToolStripMenuItemNew;
        private ToolStripMenuItem ToolStripMenuItemNewLicense;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private ToolStripMenuItem ToolStripMenuItemDisplay;
        private ToolStripMenuItem ToolStripMenuItemDeleted;
        private ToolStripMenuItem ToolStripMenuItemOutput;
        private ToolStripMenuItem ToolStripMenuItemToukaiCSV;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private FarPoint.Win.Spread.SheetView SheetViewToukaidenshi;
    }
}
