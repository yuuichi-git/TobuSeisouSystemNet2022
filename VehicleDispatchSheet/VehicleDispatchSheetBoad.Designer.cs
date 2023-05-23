namespace VehicleDispatchSheet {
    partial class VehicleDispatchSheetBoad {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleDispatchSheetBoad));
            TableLayoutPanelExBase = new ControlEx.TableLayoutPanelEx();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelStatus = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripStatusLabelPosition = new ToolStripStatusLabel();
            SpreadBase = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelExBase.Controls"));
            SheetView1 = SpreadBase.GetSheet(0);
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            配車表ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemExport = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            PanelUp = new Panel();
            CheckBox1 = new CheckBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            ComboBoxInstruction2 = new ComboBox();
            label8 = new Label();
            ComboBoxInstruction1 = new ComboBox();
            ComboBoxWEATHER = new ComboBox();
            label5 = new Label();
            GroupBox1 = new GroupBox();
            ComboBox4 = new ComboBox();
            ComboBox3 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            ComboBox2 = new ComboBox();
            label4 = new Label();
            ComboBox1 = new ComboBox();
            label3 = new Label();
            ComboBoxMISATO = new ComboBox();
            label2 = new Label();
            UcDateTimeJpOperationDate = new ControlEx.UcDateTimeJp();
            label1 = new Label();
            ButtonUpdate = new Button();
            TableLayoutPanelExBase.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadBase).BeginInit();
            MenuStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            groupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanelExBase
            // 
            TableLayoutPanelExBase.ButtonBorderStyleDotted = false;
            TableLayoutPanelExBase.ColumnCount = 1;
            TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelExBase.Controls.Add(SpreadBase, 0, 2);
            TableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelExBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelExBase.Dock = DockStyle.Fill;
            TableLayoutPanelExBase.Location = new Point(0, 0);
            TableLayoutPanelExBase.Name = "TableLayoutPanelExBase";
            TableLayoutPanelExBase.RowCount = 4;
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelExBase.Size = new Size(1904, 1041);
            TableLayoutPanelExBase.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelStatus, toolStripStatusLabel2, ToolStripStatusLabelPosition });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 22);
            StatusStrip1.TabIndex = 2;
            StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelStatus
            // 
            ToolStripStatusLabelStatus.Name = "ToolStripStatusLabelStatus";
            ToolStripStatusLabelStatus.Size = new Size(145, 17);
            ToolStripStatusLabelStatus.Text = "ToolStripStatusLabelStatus";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(62, 17);
            toolStripStatusLabel2.Text = "　Position";
            // 
            // ToolStripStatusLabelPosition
            // 
            ToolStripStatusLabelPosition.Name = "ToolStripStatusLabelPosition";
            ToolStripStatusLabelPosition.Size = new Size(156, 17);
            ToolStripStatusLabelPosition.Text = "ToolStripStatusLabelPosition";
            // 
            // SpreadBase
            // 
            SpreadBase.AccessibleDescription = "SpreadBase, 配車表, Row 0, Column 0";
            SpreadBase.Dock = DockStyle.Fill;
            SpreadBase.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadBase.Location = new Point(3, 177);
            SpreadBase.Name = "SpreadBase";
            SpreadBase.Size = new Size(1898, 837);
            SpreadBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1904, 24);
            MenuStrip1.TabIndex = 1;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { 配車表ToolStripMenuItem, ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // 配車表ToolStripMenuItem
            // 
            配車表ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrint, ToolStripMenuItemExport });
            配車表ToolStripMenuItem.Name = "配車表ToolStripMenuItem";
            配車表ToolStripMenuItem.Size = new Size(195, 22);
            配車表ToolStripMenuItem.Text = "配車表";
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(238, 22);
            ToolStripMenuItemPrint.Text = "印刷する (B4横)";
            ToolStripMenuItemPrint.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemExport
            // 
            ToolStripMenuItemExport.Name = "ToolStripMenuItemExport";
            ToolStripMenuItemExport.Size = new Size(238, 22);
            ToolStripMenuItemExport.Text = "Excel (.xls) 形式でエクスポートする";
            ToolStripMenuItemExport.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(195, 22);
            ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // PanelUp
            // 
            PanelUp.Controls.Add(CheckBox1);
            PanelUp.Controls.Add(groupBox2);
            PanelUp.Controls.Add(ComboBoxWEATHER);
            PanelUp.Controls.Add(label5);
            PanelUp.Controls.Add(GroupBox1);
            PanelUp.Controls.Add(UcDateTimeJpOperationDate);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(1898, 144);
            PanelUp.TabIndex = 3;
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(1508, 64);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(150, 19);
            CheckBox1.TabIndex = 19;
            CheckBox1.Text = "記録済の項目を読み込む";
            CheckBox1.UseVisualStyleBackColor = true;
            CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(ComboBoxInstruction2);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(ComboBoxInstruction1);
            groupBox2.Location = new Point(348, 52);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1052, 84);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "指示事項(必須)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 52);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 21;
            label9.Text = "その他事項";
            // 
            // ComboBoxInstruction2
            // 
            ComboBoxInstruction2.FormattingEnabled = true;
            ComboBoxInstruction2.Items.AddRange(new object[] { "事故を起こした時、あなたはどうしますか？　事故を起こす前にやっておく事があるのではないですか？" });
            ComboBoxInstruction2.Location = new Point(76, 48);
            ComboBoxInstruction2.Name = "ComboBoxInstruction2";
            ComboBoxInstruction2.Size = new Size(956, 23);
            ComboBoxInstruction2.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 24);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 19;
            label8.Text = "指示事項";
            // 
            // ComboBoxInstruction1
            // 
            ComboBoxInstruction1.FormattingEnabled = true;
            ComboBoxInstruction1.Items.AddRange(new object[] { "法定速度遵守  ", "車間距離の保持", "追い越し注意  ", "行違い注意    ", "スリップ注意  ", "路肩注意      ", "優先交通権の確認 ", "踏切注意         ", "発進時の前後左右の確認 ", "信号注意       ", "カーブ・交差点注意 ", "通行区分厳守   ", "横断歩道注意   ", "歩行者・自転車に注意 ", "連続運転・無理な運行の禁止 ", "運転中の携帯電話使用厳禁  ", "シートベルトの着用 ", "積載状況の確認と記録 ", "確実な積み付け ", "雨天・霧発生時のライト点灯", "老人と子供に注意", "適時適切な休憩・休息", "適時適切な報告の実施", "危険予知の励行", "事故予測の励行", "問題意識の保持", "「思いやり」「譲り合い」の励行", "「だろう」運転禁止", "「かもしれない」運転の励行", "「ながら」運転の禁止" });
            ComboBoxInstruction1.Location = new Point(76, 20);
            ComboBoxInstruction1.Name = "ComboBoxInstruction1";
            ComboBoxInstruction1.Size = new Size(956, 23);
            ComboBoxInstruction1.TabIndex = 0;
            // 
            // ComboBoxWEATHER
            // 
            ComboBoxWEATHER.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxWEATHER.FormattingEnabled = true;
            ComboBoxWEATHER.Items.AddRange(new object[] { "", "晴れ", "曇り", "小雨", "雨", "雪" });
            ComboBoxWEATHER.Location = new Point(1304, 18);
            ComboBoxWEATHER.Name = "ComboBoxWEATHER";
            ComboBoxWEATHER.Size = new Size(80, 23);
            ComboBoxWEATHER.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1268, 22);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 17;
            label5.Text = "天候";
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(ComboBox4);
            GroupBox1.Controls.Add(ComboBox3);
            GroupBox1.Controls.Add(label6);
            GroupBox1.Controls.Add(label7);
            GroupBox1.Controls.Add(ComboBox2);
            GroupBox1.Controls.Add(label4);
            GroupBox1.Controls.Add(ComboBox1);
            GroupBox1.Controls.Add(label3);
            GroupBox1.Controls.Add(ComboBoxMISATO);
            GroupBox1.Controls.Add(label2);
            GroupBox1.Location = new Point(348, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(900, 44);
            GroupBox1.TabIndex = 15;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "点呼執行者";
            // 
            // ComboBox4
            // 
            ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox4.FormattingEnabled = true;
            ComboBox4.Items.AddRange(new object[] { "", "新井", "波潟", "五十嵐", "川名", "石原", "今村", "辻" });
            ComboBox4.Location = new Point(612, 14);
            ComboBox4.Name = "ComboBox4";
            ComboBox4.Size = new Size(104, 23);
            ComboBox4.TabIndex = 16;
            // 
            // ComboBox3
            // 
            ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox3.FormattingEnabled = true;
            ComboBox3.Items.AddRange(new object[] { "", "新井", "波潟", "五十嵐", "川名", "石原", "今村", "辻" });
            ComboBox3.Location = new Point(436, 14);
            ComboBox3.Name = "ComboBox3";
            ComboBox3.Size = new Size(104, 23);
            ComboBox3.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(548, 18);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 18;
            label6.Text = "本社(帰２)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(372, 18);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 17;
            label7.Text = "本社(帰１)";
            // 
            // ComboBox2
            // 
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox2.FormattingEnabled = true;
            ComboBox2.Items.AddRange(new object[] { "", "新井", "波潟", "川名", "石原", "今村", "辻" });
            ComboBox2.Location = new Point(260, 14);
            ComboBox2.Name = "ComboBox2";
            ComboBox2.Size = new Size(104, 23);
            ComboBox2.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(732, 18);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 14;
            label4.Text = "三郷";
            // 
            // ComboBox1
            // 
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Items.AddRange(new object[] { "", "新井", "波潟", "川名", "石原", "今村", "辻" });
            ComboBox1.Location = new Point(84, 14);
            ComboBox1.Name = "ComboBox1";
            ComboBox1.Size = new Size(104, 23);
            ComboBox1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(196, 18);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 13;
            label3.Text = "本社(出２)";
            // 
            // ComboBoxMISATO
            // 
            ComboBoxMISATO.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxMISATO.FormattingEnabled = true;
            ComboBoxMISATO.Items.AddRange(new object[] { "", "波潟", "川名", "酒井", "青木" });
            ComboBoxMISATO.Location = new Point(764, 14);
            ComboBoxMISATO.Name = "ComboBoxMISATO";
            ComboBoxMISATO.Size = new Size(104, 23);
            ComboBoxMISATO.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 18);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 12;
            label2.Text = "本社(出１)";
            // 
            // UcDateTimeJpOperationDate
            // 
            UcDateTimeJpOperationDate.Location = new Point(96, 56);
            UcDateTimeJpOperationDate.Name = "UcDateTimeJpOperationDate";
            UcDateTimeJpOperationDate.Size = new Size(183, 23);
            UcDateTimeJpOperationDate.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 60);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 7;
            label1.Text = "配車日付";
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1672, 52);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 1;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // VehicleDispatchSheetBoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MaximumSize = new Size(1920, 1080);
            Name = "VehicleDispatchSheetBoad";
            StartPosition = FormStartPosition.CenterParent;
            Text = "VehicleDispatchSheetBoad";
            FormClosing += VehicleDispatchSheetBoad_FormClosing;
            TableLayoutPanelExBase.ResumeLayout(false);
            TableLayoutPanelExBase.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadBase).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ControlEx.TableLayoutPanelEx TableLayoutPanelExBase;
        private FarPoint.Win.Spread.FpSpread SpreadBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private Panel PanelUp;
        private Button ButtonUpdate;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel ToolStripStatusLabelPosition;
        private ControlEx.UcDateTimeJp UcDateTimeJpOperationDate;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox ComboBoxMISATO;
        private ComboBox ComboBox2;
        private ComboBox ComboBox1;
        private GroupBox GroupBox1;
        private ToolStripMenuItem 配車表ToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemExport;
        private ComboBox ComboBoxWEATHER;
        private Label label5;
        private ComboBox ComboBox4;
        private ComboBox ComboBox3;
        private Label label6;
        private Label label7;
        private GroupBox groupBox2;
        private Label label9;
        private ComboBox ComboBoxInstruction2;
        private Label label8;
        private ComboBox ComboBoxInstruction1;
        private CheckBox CheckBox1;
        private FarPoint.Win.Spread.SheetView SheetView1;
    }
}