namespace H_Staff {
    partial class HStaffList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HStaffList));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            SheetViewMedical = SpreadList.GetSheet(1);
            SheetViewDriver = SpreadList.GetSheet(2);
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemNew = new ToolStripMenuItem();
            ToolStripMenuItemNewStaff = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            ButtonUpdate = new Button();
            CheckBoxRetired = new CheckBox();
            GroupBox3 = new GroupBox();
            checkBox2 = new CheckBox();
            CheckBoxNone2 = new CheckBox();
            CheckBoxWorkStaff = new CheckBox();
            CheckBoxDriver = new CheckBox();
            GroupBox2 = new GroupBox();
            CheckBoxNone1 = new CheckBox();
            CheckBoxPartTimeJob2 = new CheckBox();
            CheckBoxNoteBook = new CheckBox();
            CheckBoxFullTimeJob = new CheckBox();
            GroupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            CheckBoxJiunrou = new CheckBox();
            CheckBoxSinunten = new CheckBox();
            CheckBoxPartTimeJob1 = new CheckBox();
            CheckBoxCompanyEmployee = new CheckBox();
            CheckBoxOfficer = new CheckBox();
            HTabControlExKANA = new H_ControlEx.H_TabControlEx();
            tabPage11 = new TabPage();
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
            HTableLayoutPanelExBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            StatusStrip1.SuspendLayout();
            MenuStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            GroupBox3.SuspendLayout();
            GroupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            HTabControlExKANA.SuspendLayout();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.Controls.Add(SpreadList, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(HTabControlExKANA, 0, 2);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 5;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExBase.Size = new Size(1904, 1041);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, 健康診断用リスト, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 118);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 900);
            SpreadList.TabIndex = 5;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 1021);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 20);
            StatusStrip1.TabIndex = 4;
            StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 15);
            toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelDetail
            // 
            ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            ToolStripStatusLabelDetail.Size = new Size(142, 15);
            ToolStripStatusLabelDetail.Text = "toolStripStatusLabelDetail";
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemNew, ToolStripMenuItemHelp });
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
            ToolStripMenuItemNew.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemNewStaff });
            ToolStripMenuItemNew.Name = "ToolStripMenuItemNew";
            ToolStripMenuItemNew.Size = new Size(43, 20);
            ToolStripMenuItemNew.Text = "新規";
            // 
            // ToolStripMenuItemNewStaff
            // 
            ToolStripMenuItemNewStaff.Name = "ToolStripMenuItemNewStaff";
            ToolStripMenuItemNewStaff.Size = new Size(183, 22);
            ToolStripMenuItemNewStaff.Text = "新規レコードを追加する";
            ToolStripMenuItemNewStaff.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // HPanelExUp
            // 
            HPanelExUp.Controls.Add(ButtonUpdate);
            HPanelExUp.Controls.Add(CheckBoxRetired);
            HPanelExUp.Controls.Add(GroupBox3);
            HPanelExUp.Controls.Add(GroupBox2);
            HPanelExUp.Controls.Add(GroupBox1);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1898, 54);
            HPanelExUp.TabIndex = 2;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1684, 8);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 9;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += Button_Click;
            // 
            // CheckBoxRetired
            // 
            CheckBoxRetired.AutoSize = true;
            CheckBoxRetired.Location = new Point(960, 24);
            CheckBoxRetired.Name = "CheckBoxRetired";
            CheckBoxRetired.Size = new Size(114, 19);
            CheckBoxRetired.TabIndex = 8;
            CheckBoxRetired.Text = "退職者も表示する";
            CheckBoxRetired.UseVisualStyleBackColor = true;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(checkBox2);
            GroupBox3.Controls.Add(CheckBoxNone2);
            GroupBox3.Controls.Add(CheckBoxWorkStaff);
            GroupBox3.Controls.Add(CheckBoxDriver);
            GroupBox3.Location = new Point(656, 8);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(272, 44);
            GroupBox3.TabIndex = 7;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "職種(第三条件)";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(136, 16);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(62, 19);
            checkBox2.TabIndex = 3;
            checkBox2.Tag = "20";
            checkBox2.Text = "事務職";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBoxNone2
            // 
            CheckBoxNone2.AutoSize = true;
            CheckBoxNone2.Checked = true;
            CheckBoxNone2.CheckState = CheckState.Checked;
            CheckBoxNone2.Location = new Point(200, 16);
            CheckBoxNone2.Name = "CheckBoxNone2";
            CheckBoxNone2.Size = new Size(68, 19);
            CheckBoxNone2.TabIndex = 2;
            CheckBoxNone2.Tag = "99";
            CheckBoxNone2.Text = "指定なし";
            CheckBoxNone2.UseVisualStyleBackColor = true;
            // 
            // CheckBoxWorkStaff
            // 
            CheckBoxWorkStaff.AutoSize = true;
            CheckBoxWorkStaff.Checked = true;
            CheckBoxWorkStaff.CheckState = CheckState.Checked;
            CheckBoxWorkStaff.Location = new Point(72, 16);
            CheckBoxWorkStaff.Name = "CheckBoxWorkStaff";
            CheckBoxWorkStaff.Size = new Size(62, 19);
            CheckBoxWorkStaff.TabIndex = 1;
            CheckBoxWorkStaff.Tag = "11";
            CheckBoxWorkStaff.Text = "作業員";
            CheckBoxWorkStaff.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDriver
            // 
            CheckBoxDriver.AutoSize = true;
            CheckBoxDriver.Checked = true;
            CheckBoxDriver.CheckState = CheckState.Checked;
            CheckBoxDriver.Location = new Point(8, 16);
            CheckBoxDriver.Name = "CheckBoxDriver";
            CheckBoxDriver.Size = new Size(62, 19);
            CheckBoxDriver.TabIndex = 0;
            CheckBoxDriver.Tag = "10";
            CheckBoxDriver.Text = "運転手";
            CheckBoxDriver.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(CheckBoxNone1);
            GroupBox2.Controls.Add(CheckBoxPartTimeJob2);
            GroupBox2.Controls.Add(CheckBoxNoteBook);
            GroupBox2.Controls.Add(CheckBoxFullTimeJob);
            GroupBox2.Location = new Point(392, 8);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(256, 44);
            GroupBox2.TabIndex = 6;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "雇用形態(第二条件)";
            // 
            // CheckBoxNone1
            // 
            CheckBoxNone1.AutoSize = true;
            CheckBoxNone1.Checked = true;
            CheckBoxNone1.CheckState = CheckState.Checked;
            CheckBoxNone1.Location = new Point(184, 16);
            CheckBoxNone1.Name = "CheckBoxNone1";
            CheckBoxNone1.Size = new Size(68, 19);
            CheckBoxNone1.TabIndex = 3;
            CheckBoxNone1.Tag = "99";
            CheckBoxNone1.Text = "指定なし";
            CheckBoxNone1.UseVisualStyleBackColor = true;
            // 
            // CheckBoxPartTimeJob2
            // 
            CheckBoxPartTimeJob2.AutoSize = true;
            CheckBoxPartTimeJob2.Checked = true;
            CheckBoxPartTimeJob2.CheckState = CheckState.Checked;
            CheckBoxPartTimeJob2.Location = new Point(112, 16);
            CheckBoxPartTimeJob2.Name = "CheckBoxPartTimeJob2";
            CheckBoxPartTimeJob2.Size = new Size(72, 19);
            CheckBoxPartTimeJob2.TabIndex = 2;
            CheckBoxPartTimeJob2.Tag = "12";
            CheckBoxPartTimeJob2.Text = "アルバイト";
            CheckBoxPartTimeJob2.UseVisualStyleBackColor = true;
            // 
            // CheckBoxNoteBook
            // 
            CheckBoxNoteBook.AutoSize = true;
            CheckBoxNoteBook.Checked = true;
            CheckBoxNoteBook.CheckState = CheckState.Checked;
            CheckBoxNoteBook.Location = new Point(60, 16);
            CheckBoxNoteBook.Name = "CheckBoxNoteBook";
            CheckBoxNoteBook.Size = new Size(50, 19);
            CheckBoxNoteBook.TabIndex = 1;
            CheckBoxNoteBook.Tag = "11";
            CheckBoxNoteBook.Text = "手帳";
            CheckBoxNoteBook.UseVisualStyleBackColor = true;
            // 
            // CheckBoxFullTimeJob
            // 
            CheckBoxFullTimeJob.AutoSize = true;
            CheckBoxFullTimeJob.Checked = true;
            CheckBoxFullTimeJob.CheckState = CheckState.Checked;
            CheckBoxFullTimeJob.Location = new Point(8, 16);
            CheckBoxFullTimeJob.Name = "CheckBoxFullTimeJob";
            CheckBoxFullTimeJob.Size = new Size(50, 19);
            CheckBoxFullTimeJob.TabIndex = 0;
            CheckBoxFullTimeJob.Tag = "10";
            CheckBoxFullTimeJob.Text = "長期";
            CheckBoxFullTimeJob.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(checkBox1);
            GroupBox1.Controls.Add(CheckBoxJiunrou);
            GroupBox1.Controls.Add(CheckBoxSinunten);
            GroupBox1.Controls.Add(CheckBoxPartTimeJob1);
            GroupBox1.Controls.Add(CheckBoxCompanyEmployee);
            GroupBox1.Controls.Add(CheckBoxOfficer);
            GroupBox1.Location = new Point(16, 8);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(368, 44);
            GroupBox1.TabIndex = 2;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "役職又は所属(第一条件)";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(184, 16);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(50, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Tag = "13";
            checkBox1.Text = "派遣";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBoxJiunrou
            // 
            CheckBoxJiunrou.AutoSize = true;
            CheckBoxJiunrou.Checked = true;
            CheckBoxJiunrou.CheckState = CheckState.Checked;
            CheckBoxJiunrou.Location = new Point(300, 16);
            CheckBoxJiunrou.Name = "CheckBoxJiunrou";
            CheckBoxJiunrou.Size = new Size(62, 19);
            CheckBoxJiunrou.TabIndex = 4;
            CheckBoxJiunrou.Tag = "21";
            CheckBoxJiunrou.Text = "自運労";
            CheckBoxJiunrou.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSinunten
            // 
            CheckBoxSinunten.AutoSize = true;
            CheckBoxSinunten.Checked = true;
            CheckBoxSinunten.CheckState = CheckState.Checked;
            CheckBoxSinunten.Location = new Point(236, 16);
            CheckBoxSinunten.Name = "CheckBoxSinunten";
            CheckBoxSinunten.Size = new Size(62, 19);
            CheckBoxSinunten.TabIndex = 3;
            CheckBoxSinunten.Tag = "20";
            CheckBoxSinunten.Text = "新運転";
            CheckBoxSinunten.UseVisualStyleBackColor = true;
            // 
            // CheckBoxPartTimeJob1
            // 
            CheckBoxPartTimeJob1.AutoSize = true;
            CheckBoxPartTimeJob1.Checked = true;
            CheckBoxPartTimeJob1.CheckState = CheckState.Checked;
            CheckBoxPartTimeJob1.Location = new Point(112, 16);
            CheckBoxPartTimeJob1.Name = "CheckBoxPartTimeJob1";
            CheckBoxPartTimeJob1.Size = new Size(72, 19);
            CheckBoxPartTimeJob1.TabIndex = 2;
            CheckBoxPartTimeJob1.Tag = "12";
            CheckBoxPartTimeJob1.Text = "アルバイト";
            CheckBoxPartTimeJob1.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCompanyEmployee
            // 
            CheckBoxCompanyEmployee.AutoSize = true;
            CheckBoxCompanyEmployee.Checked = true;
            CheckBoxCompanyEmployee.CheckState = CheckState.Checked;
            CheckBoxCompanyEmployee.Location = new Point(60, 16);
            CheckBoxCompanyEmployee.Name = "CheckBoxCompanyEmployee";
            CheckBoxCompanyEmployee.Size = new Size(50, 19);
            CheckBoxCompanyEmployee.TabIndex = 1;
            CheckBoxCompanyEmployee.Tag = "11";
            CheckBoxCompanyEmployee.Text = "社員";
            CheckBoxCompanyEmployee.UseVisualStyleBackColor = true;
            // 
            // CheckBoxOfficer
            // 
            CheckBoxOfficer.AutoSize = true;
            CheckBoxOfficer.Checked = true;
            CheckBoxOfficer.CheckState = CheckState.Checked;
            CheckBoxOfficer.Location = new Point(8, 16);
            CheckBoxOfficer.Name = "CheckBoxOfficer";
            CheckBoxOfficer.Size = new Size(50, 19);
            CheckBoxOfficer.TabIndex = 0;
            CheckBoxOfficer.Tag = "10";
            CheckBoxOfficer.Text = "役員";
            CheckBoxOfficer.UseVisualStyleBackColor = true;
            // 
            // HTabControlExKANA
            // 
            HTabControlExKANA.Controls.Add(tabPage11);
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
            HTabControlExKANA.Dock = DockStyle.Fill;
            HTabControlExKANA.Location = new Point(0, 84);
            HTabControlExKANA.Margin = new Padding(0);
            HTabControlExKANA.Name = "HTabControlExKANA";
            HTabControlExKANA.SelectedIndex = 0;
            HTabControlExKANA.Size = new Size(1904, 31);
            HTabControlExKANA.SizeMode = TabSizeMode.Fixed;
            HTabControlExKANA.TabIndex = 6;
            HTabControlExKANA.Click += HTabControlExKANA_Click;
            // 
            // tabPage11
            // 
            tabPage11.Location = new Point(4, 24);
            tabPage11.Name = "tabPage11";
            tabPage11.Size = new Size(1896, 3);
            tabPage11.TabIndex = 10;
            tabPage11.Text = "すべて";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1896, 3);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "あ行";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1896, 3);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "か行";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1896, 3);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "さ行";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1896, 3);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "た行";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1896, 3);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "な行";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1896, 3);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "は行";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1896, 3);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "ま行";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1896, 3);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "や行";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 24);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1896, 3);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "ら行";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            tabPage10.Location = new Point(4, 24);
            tabPage10.Name = "tabPage10";
            tabPage10.Size = new Size(1896, 3);
            tabPage10.TabIndex = 9;
            tabPage10.Text = "わ行";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // HStaffList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MinimumSize = new Size(1918, 1046);
            Name = "HStaffList";
            Text = "H_StaffList";
            FormClosing += HStaffList_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            HTabControlExKANA.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private GroupBox GroupBox1;
        private CheckBox checkBox1;
        private CheckBox CheckBoxJiunrou;
        private CheckBox CheckBoxSinunten;
        private CheckBox CheckBoxPartTimeJob1;
        private CheckBox CheckBoxCompanyEmployee;
        private CheckBox CheckBoxOfficer;
        private GroupBox GroupBox2;
        private CheckBox CheckBoxNone1;
        private CheckBox CheckBoxPartTimeJob2;
        private CheckBox CheckBoxNoteBook;
        private CheckBox CheckBoxFullTimeJob;
        private GroupBox GroupBox3;
        private CheckBox checkBox2;
        private CheckBox CheckBoxNone2;
        private CheckBox CheckBoxWorkStaff;
        private CheckBox CheckBoxDriver;
        private CheckBox CheckBoxRetired;
        private Button ButtonUpdate;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private H_ControlEx.H_TabControlEx HTabControlExKANA;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private FarPoint.Win.Spread.SheetView SheetViewMedical;
        private FarPoint.Win.Spread.SheetView SheetViewDriver;
        private ToolStripMenuItem ToolStripMenuItemNew;
        private ToolStripMenuItem ToolStripMenuItemNewStaff;
    }
}