namespace Staff {
    partial class StaffList {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffList));
            TableLayoutPanelExBase = new ControlEx.TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExport = new ToolStripMenuItem();
            ToolStripMenuItemExport1 = new ToolStripMenuItem();
            ToolStripMenuItemExport2 = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            編集ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItemNewStaff = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            PanelUp = new Panel();
            CheckBoxRetired = new CheckBox();
            ComboBoxAccidentYear = new ComboBox();
            label1 = new Label();
            GroupBox3 = new GroupBox();
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
            ButtonUpdate = new Button();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelExBase.Controls"));
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ToolStripMenuItemLicense = new ToolStripMenuItem();
            ToolStripMenuItemToukanpo = new ToolStripMenuItem();
            ToolStripMenuItemMap = new ToolStripMenuItem();
            TabControlExStaff = new ControlEx.TabControlEx();
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
            SheetViewList = SpreadList.GetSheet(0);
            SheetViewList2 = SpreadList.GetSheet(1);
            TableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            GroupBox3.SuspendLayout();
            GroupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            ContextMenuStrip1.SuspendLayout();
            TabControlExStaff.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanelExBase
            // 
            TableLayoutPanelExBase.ButtonBorderStyleDotted = false;
            TableLayoutPanelExBase.ColumnCount = 1;
            TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelExBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 4);
            TableLayoutPanelExBase.Controls.Add(SpreadList, 0, 3);
            TableLayoutPanelExBase.Controls.Add(TabControlExStaff, 0, 2);
            TableLayoutPanelExBase.Dock = DockStyle.Fill;
            TableLayoutPanelExBase.Location = new Point(0, 0);
            TableLayoutPanelExBase.Name = "TableLayoutPanelExBase";
            TableLayoutPanelExBase.RowCount = 5;
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelExBase.Size = new Size(1904, 1041);
            TableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, 編集ToolStripMenuItem, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1904, 24);
            MenuStrip1.TabIndex = 1;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemExport, ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemExport
            // 
            ToolStripMenuItemExport.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemExport1, ToolStripMenuItemExport2 });
            ToolStripMenuItemExport.Name = "ToolStripMenuItemExport";
            ToolStripMenuItemExport.Size = new Size(195, 22);
            ToolStripMenuItemExport.Text = "Excel形式でエクスポート";
            // 
            // ToolStripMenuItemExport1
            // 
            ToolStripMenuItemExport1.Name = "ToolStripMenuItemExport1";
            ToolStripMenuItemExport1.Size = new Size(240, 22);
            ToolStripMenuItemExport1.Text = "従事者リストをエクスポートする";
            ToolStripMenuItemExport1.Click += ToolStripMenuItemExport1_Click;
            // 
            // ToolStripMenuItemExport2
            // 
            ToolStripMenuItemExport2.Name = "ToolStripMenuItemExport2";
            ToolStripMenuItemExport2.Size = new Size(240, 22);
            ToolStripMenuItemExport2.Text = "健康診断用リストをエクスポートする";
            ToolStripMenuItemExport2.Click += ToolStripMenuItemExport2_Click;
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(195, 22);
            ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // 編集ToolStripMenuItem
            // 
            編集ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemNewStaff });
            編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            編集ToolStripMenuItem.Size = new Size(43, 20);
            編集ToolStripMenuItem.Text = "編集";
            // 
            // ToolStripMenuItemNewStaff
            // 
            ToolStripMenuItemNewStaff.Name = "ToolStripMenuItemNewStaff";
            ToolStripMenuItemNewStaff.Size = new Size(186, 22);
            ToolStripMenuItemNewStaff.Text = "新規従事者を登録する";
            ToolStripMenuItemNewStaff.Click += ToolStripMenuItemNewStaff_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // PanelUp
            // 
            PanelUp.Controls.Add(CheckBoxRetired);
            PanelUp.Controls.Add(ComboBoxAccidentYear);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(GroupBox3);
            PanelUp.Controls.Add(GroupBox2);
            PanelUp.Controls.Add(GroupBox1);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(1898, 54);
            PanelUp.TabIndex = 3;
            // 
            // CheckBoxRetired
            // 
            CheckBoxRetired.AutoSize = true;
            CheckBoxRetired.Location = new Point(1104, 20);
            CheckBoxRetired.Name = "CheckBoxRetired";
            CheckBoxRetired.Size = new Size(114, 19);
            CheckBoxRetired.TabIndex = 3;
            CheckBoxRetired.Text = "退職者も表示する";
            CheckBoxRetired.UseVisualStyleBackColor = true;
            // 
            // ComboBoxAccidentYear
            // 
            ComboBoxAccidentYear.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxAccidentYear.Enabled = false;
            ComboBoxAccidentYear.FormattingEnabled = true;
            ComboBoxAccidentYear.Items.AddRange(new object[] { "2020年度", "2021年度", "2022年度", "2023年度" });
            ComboBoxAccidentYear.Location = new Point(1008, 16);
            ComboBoxAccidentYear.Name = "ComboBoxAccidentYear";
            ComboBoxAccidentYear.Size = new Size(84, 23);
            ComboBoxAccidentYear.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(904, 20);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 7;
            label1.Text = "事故件数集計年度";
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(CheckBoxNone2);
            GroupBox3.Controls.Add(CheckBoxWorkStaff);
            GroupBox3.Controls.Add(CheckBoxDriver);
            GroupBox3.Location = new Point(668, 4);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(208, 44);
            GroupBox3.TabIndex = 6;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "職種(第三条件)";
            // 
            // CheckBoxNone2
            // 
            CheckBoxNone2.AutoSize = true;
            CheckBoxNone2.Checked = true;
            CheckBoxNone2.CheckState = CheckState.Checked;
            CheckBoxNone2.Location = new Point(136, 16);
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
            GroupBox2.Location = new Point(396, 4);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(256, 44);
            GroupBox2.TabIndex = 5;
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
            GroupBox1.Location = new Point(16, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(368, 44);
            GroupBox1.TabIndex = 1;
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
            // ButtonUpdate
            // 
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1672, 8);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 0;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 22);
            StatusStrip1.TabIndex = 4;
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
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, 従事者リスト, Row 0, Column 0";
            SpreadList.ContextMenuStrip = ContextMenuStrip1;
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 115);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 899);
            SpreadList.TabIndex = 5;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemLicense, ToolStripMenuItemToukanpo, ToolStripMenuItemMap });
            ContextMenuStrip1.Name = "contextMenuStrip1";
            ContextMenuStrip1.Size = new Size(199, 70);
            ContextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            // 
            // ToolStripMenuItemLicense
            // 
            ToolStripMenuItemLicense.Name = "ToolStripMenuItemLicense";
            ToolStripMenuItemLicense.Size = new Size(198, 22);
            ToolStripMenuItemLicense.Text = "免許証を表示する";
            ToolStripMenuItemLicense.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemToukanpo
            // 
            ToolStripMenuItemToukanpo.Name = "ToolStripMenuItemToukanpo";
            ToolStripMenuItemToukanpo.Size = new Size(198, 22);
            ToolStripMenuItemToukanpo.Text = "東環保修了証を表示する";
            ToolStripMenuItemToukanpo.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemMap
            // 
            ToolStripMenuItemMap.Name = "ToolStripMenuItemMap";
            ToolStripMenuItemMap.Size = new Size(198, 22);
            ToolStripMenuItemMap.Text = "地図を表示する";
            ToolStripMenuItemMap.Click += ToolStripMenuItem_Click;
            // 
            // TabControlExStaff
            // 
            TabControlExStaff.Controls.Add(tabPage1);
            TabControlExStaff.Controls.Add(tabPage2);
            TabControlExStaff.Controls.Add(tabPage3);
            TabControlExStaff.Controls.Add(tabPage4);
            TabControlExStaff.Controls.Add(tabPage5);
            TabControlExStaff.Controls.Add(tabPage6);
            TabControlExStaff.Controls.Add(tabPage7);
            TabControlExStaff.Controls.Add(tabPage8);
            TabControlExStaff.Controls.Add(tabPage9);
            TabControlExStaff.Controls.Add(tabPage10);
            TabControlExStaff.Controls.Add(tabPage11);
            TabControlExStaff.Location = new Point(10, 84);
            TabControlExStaff.Margin = new Padding(10, 0, 10, 0);
            TabControlExStaff.Name = "TabControlExStaff";
            TabControlExStaff.SelectedIndex = 0;
            TabControlExStaff.Size = new Size(1884, 28);
            TabControlExStaff.SizeMode = TabSizeMode.Fixed;
            TabControlExStaff.TabIndex = 6;
            TabControlExStaff.Click += TabControlEx1_Click;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1876, 0);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "全て";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1876, 0);
            tabPage2.TabIndex = 1;
            tabPage2.Tag = "ア";
            tabPage2.Text = "あ行";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1876, 0);
            tabPage3.TabIndex = 2;
            tabPage3.Tag = "カ";
            tabPage3.Text = "か行";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1876, 0);
            tabPage4.TabIndex = 3;
            tabPage4.Tag = "サ";
            tabPage4.Text = "さ行";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1876, 0);
            tabPage5.TabIndex = 4;
            tabPage5.Tag = "タ";
            tabPage5.Text = "た行";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1876, 0);
            tabPage6.TabIndex = 5;
            tabPage6.Tag = "ナ";
            tabPage6.Text = "な行";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(1876, 0);
            tabPage7.TabIndex = 6;
            tabPage7.Tag = "ハ";
            tabPage7.Text = "は行";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(1876, 0);
            tabPage8.TabIndex = 7;
            tabPage8.Tag = "マ";
            tabPage8.Text = "ま行";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 24);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(1876, 0);
            tabPage9.TabIndex = 8;
            tabPage9.Tag = "ヤ";
            tabPage9.Text = "や行";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            tabPage10.Location = new Point(4, 24);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(3);
            tabPage10.Size = new Size(1876, 0);
            tabPage10.TabIndex = 9;
            tabPage10.Tag = "ラ";
            tabPage10.Text = "ら行";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Location = new Point(4, 24);
            tabPage11.Name = "tabPage11";
            tabPage11.Padding = new Padding(3);
            tabPage11.Size = new Size(1876, 0);
            tabPage11.TabIndex = 10;
            tabPage11.Tag = "ワ";
            tabPage11.Text = "わ行";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // StaffList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TableLayoutPanelExBase);
            DoubleBuffered = true;
            MainMenuStrip = MenuStrip1;
            Name = "StaffList";
            Text = "StaffList";
            FormClosing += StaffList_FormClosing;
            TableLayoutPanelExBase.ResumeLayout(false);
            TableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ContextMenuStrip1.ResumeLayout(false);
            TabControlExStaff.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ControlEx.TableLayoutPanelEx TableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private Panel PanelUp;
        private Button ButtonUpdate;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private ControlEx.TabControlEx TabControlExStaff;
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
        private GroupBox GroupBox3;
        private CheckBox CheckBoxNone2;
        private CheckBox CheckBoxWorkStaff;
        private CheckBox CheckBoxDriver;
        private GroupBox GroupBox2;
        private CheckBox CheckBoxPartTimeJob2;
        private CheckBox CheckBoxNoteBook;
        private CheckBox CheckBoxFullTimeJob;
        private GroupBox GroupBox1;
        private CheckBox CheckBoxJiunrou;
        private CheckBox CheckBoxSinunten;
        private CheckBox CheckBoxPartTimeJob1;
        private CheckBox CheckBoxCompanyEmployee;
        private CheckBox CheckBoxOfficer;
        private ComboBox ComboBoxAccidentYear;
        private Label label1;
        private CheckBox CheckBoxRetired;
        private CheckBox CheckBoxNone1;
        private ToolStripMenuItem 編集ToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemNewStaff;
        private ContextMenuStrip ContextMenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemLicense;
        private ToolStripMenuItem ToolStripMenuItemToukanpo;
        private ToolStripMenuItem ToolStripMenuItemMap;
        private CheckBox checkBox1;
        private ToolStripMenuItem ToolStripMenuItemExport;
        private ToolStripMenuItem ToolStripMenuItemExport1;
        private ToolStripMenuItem ToolStripMenuItemExport2;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private FarPoint.Win.Spread.SheetView SheetViewList2;
    }
}