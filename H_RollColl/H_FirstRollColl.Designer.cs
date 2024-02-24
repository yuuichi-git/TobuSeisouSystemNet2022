namespace H_RollColl {
    partial class H_FirstRollColl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_FirstRollColl));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemExport = new ToolStripMenuItem();
            ToolStripMenuItemExportExcel = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            SpreadFirstRollCall = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewFirstRollCall = SpreadFirstRollCall.GetSheet(0);
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            HCheckBoxEx1 = new H_ControlEx.H_CheckBoxEx();
            GroupBox2 = new GroupBox();
            HComboBoxExInstruction2 = new H_ControlEx.H_ComboBoxEx();
            HComboBoxExInstruction1 = new H_ControlEx.H_ComboBoxEx();
            label9 = new Label();
            label8 = new Label();
            GroupBox1 = new GroupBox();
            HComboBoxEx5 = new H_ControlEx.H_ComboBoxEx();
            HComboBoxEx4 = new H_ControlEx.H_ComboBoxEx();
            HComboBoxExWeather = new H_ControlEx.H_ComboBoxEx();
            label5 = new Label();
            HComboBoxEx3 = new H_ControlEx.H_ComboBoxEx();
            HComboBoxEx2 = new H_ControlEx.H_ComboBoxEx();
            HComboBoxEx1 = new H_ControlEx.H_ComboBoxEx();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            HDateTimePickerExOperationDate = new H_ControlEx.H_DateTimePickerEx();
            label1 = new Label();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripStatusLabelPosition = new ToolStripStatusLabel();
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadFirstRollCall).BeginInit();
            HPanelExUp.SuspendLayout();
            GroupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(SpreadFirstRollCall, 0, 2);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1904, 1041);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemExport, ToolStripMenuItemHelp });
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
            ToolStripMenuItemExportExcel.Size = new Size(229, 22);
            ToolStripMenuItemExportExcel.Text = "Excel(xls)形式でエクスポートする";
            ToolStripMenuItemExportExcel.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // SpreadFirstRollCall
            // 
            SpreadFirstRollCall.AccessibleDescription = "SpreadFirstRollCall, 配車表, Row 0, Column 0";
            SpreadFirstRollCall.Dock = DockStyle.Fill;
            SpreadFirstRollCall.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadFirstRollCall.Location = new Point(3, 177);
            SpreadFirstRollCall.Name = "SpreadFirstRollCall";
            SpreadFirstRollCall.Size = new Size(1898, 837);
            SpreadFirstRollCall.TabIndex = 1;
            // 
            // HPanelExUp
            // 
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Controls.Add(HCheckBoxEx1);
            HPanelExUp.Controls.Add(GroupBox2);
            HPanelExUp.Controls.Add(GroupBox1);
            HPanelExUp.Controls.Add(HDateTimePickerExOperationDate);
            HPanelExUp.Controls.Add(label1);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1898, 144);
            HPanelExUp.TabIndex = 2;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HButtonExUpdate.Location = new Point(1664, 52);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(176, 36);
            HButtonExUpdate.TabIndex = 25;
            HButtonExUpdate.Text = "配車表を作成する";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // HCheckBoxEx1
            // 
            HCheckBoxEx1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HCheckBoxEx1.AutoSize = true;
            HCheckBoxEx1.Location = new Point(1488, 64);
            HCheckBoxEx1.Name = "HCheckBoxEx1";
            HCheckBoxEx1.Size = new Size(150, 19);
            HCheckBoxEx1.TabIndex = 1;
            HCheckBoxEx1.Text = "記録済の項目を読み込む";
            HCheckBoxEx1.UseVisualStyleBackColor = true;
            HCheckBoxEx1.CheckedChanged += HCheckBoxEx1_CheckedChanged;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(HComboBoxExInstruction2);
            GroupBox2.Controls.Add(HComboBoxExInstruction1);
            GroupBox2.Controls.Add(label9);
            GroupBox2.Controls.Add(label8);
            GroupBox2.Location = new Point(356, 52);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(1092, 84);
            GroupBox2.TabIndex = 19;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "指示事項(必須)";
            // 
            // HComboBoxExInstruction2
            // 
            HComboBoxExInstruction2.FormattingEnabled = true;
            HComboBoxExInstruction2.Items.AddRange(new object[] { "事故を起こした時、あなたはどうしますか？　事故を起こす前にやっておく事があるのではないですか？" });
            HComboBoxExInstruction2.Location = new Point(76, 48);
            HComboBoxExInstruction2.Name = "HComboBoxExInstruction2";
            HComboBoxExInstruction2.Size = new Size(968, 23);
            HComboBoxExInstruction2.TabIndex = 22;
            // 
            // HComboBoxExInstruction1
            // 
            HComboBoxExInstruction1.FormattingEnabled = true;
            HComboBoxExInstruction1.Items.AddRange(new object[] { "法定速度遵守  ", "車間距離の保持", "追い越し注意  ", "行違い注意    ", "スリップ注意  ", "路肩注意      ", "優先交通権の確認 ", "踏切注意         ", "発進時の前後左右の確認 ", "信号注意       ", "カーブ・交差点注意 ", "通行区分厳守   ", "横断歩道注意   ", "歩行者・自転車に注意 ", "連続運転・無理な運行の禁止 ", "運転中の携帯電話使用厳禁  ", "シートベルトの着用 ", "積載状況の確認と記録 ", "確実な積み付け ", "雨天・霧発生時のライト点灯", "老人と子供に注意", "適時適切な休憩・休息", "適時適切な報告の実施", "危険予知の励行", "事故予測の励行", "問題意識の保持", "「思いやり」「譲り合い」の励行", "「だろう」運転禁止", "「かもしれない」運転の励行", "「ながら」運転の禁止" });
            HComboBoxExInstruction1.Location = new Point(76, 20);
            HComboBoxExInstruction1.Name = "HComboBoxExInstruction1";
            HComboBoxExInstruction1.Size = new Size(968, 23);
            HComboBoxExInstruction1.TabIndex = 20;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 24);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 19;
            label8.Text = "指示事項";
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(HComboBoxEx5);
            GroupBox1.Controls.Add(HComboBoxEx4);
            GroupBox1.Controls.Add(HComboBoxExWeather);
            GroupBox1.Controls.Add(label5);
            GroupBox1.Controls.Add(HComboBoxEx3);
            GroupBox1.Controls.Add(HComboBoxEx2);
            GroupBox1.Controls.Add(HComboBoxEx1);
            GroupBox1.Controls.Add(label6);
            GroupBox1.Controls.Add(label7);
            GroupBox1.Controls.Add(label4);
            GroupBox1.Controls.Add(label3);
            GroupBox1.Controls.Add(label2);
            GroupBox1.Location = new Point(356, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(1092, 44);
            GroupBox1.TabIndex = 16;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "点呼執行者";
            // 
            // HComboBoxEx5
            // 
            HComboBoxEx5.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxEx5.FormattingEnabled = true;
            HComboBoxEx5.Items.AddRange(new object[] { "", "波潟", "川名", "酒井", "青木" });
            HComboBoxEx5.Location = new Point(768, 14);
            HComboBoxEx5.Name = "HComboBoxEx5";
            HComboBoxEx5.Size = new Size(100, 23);
            HComboBoxEx5.TabIndex = 22;
            // 
            // HComboBoxEx4
            // 
            HComboBoxEx4.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxEx4.FormattingEnabled = true;
            HComboBoxEx4.Items.AddRange(new object[] { "", "新井", "波潟", "川名", "石原", "今村", "百瀨", "辻" });
            HComboBoxEx4.Location = new Point(612, 14);
            HComboBoxEx4.Name = "HComboBoxEx4";
            HComboBoxEx4.Size = new Size(100, 23);
            HComboBoxEx4.TabIndex = 21;
            // 
            // HComboBoxExWeather
            // 
            HComboBoxExWeather.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxExWeather.FormattingEnabled = true;
            HComboBoxExWeather.Items.AddRange(new object[] { "", "晴れ", "曇り", "小雨", "雨", "雪" });
            HComboBoxExWeather.Location = new Point(928, 14);
            HComboBoxExWeather.Name = "HComboBoxExWeather";
            HComboBoxExWeather.Size = new Size(100, 23);
            HComboBoxExWeather.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(892, 18);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 23;
            label5.Text = "天気";
            // 
            // HComboBoxEx3
            // 
            HComboBoxEx3.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxEx3.FormattingEnabled = true;
            HComboBoxEx3.Items.AddRange(new object[] { "", "新井", "波潟", "川名", "石原", "今村", "百瀨", "辻" });
            HComboBoxEx3.Location = new Point(436, 14);
            HComboBoxEx3.Name = "HComboBoxEx3";
            HComboBoxEx3.Size = new Size(100, 23);
            HComboBoxEx3.TabIndex = 20;
            // 
            // HComboBoxEx2
            // 
            HComboBoxEx2.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxEx2.FormattingEnabled = true;
            HComboBoxEx2.Items.AddRange(new object[] { "", "新井", "波潟", "川名", "石原", "今村", "百瀨", "辻" });
            HComboBoxEx2.Location = new Point(260, 14);
            HComboBoxEx2.Name = "HComboBoxEx2";
            HComboBoxEx2.Size = new Size(100, 23);
            HComboBoxEx2.TabIndex = 19;
            // 
            // HComboBoxEx1
            // 
            HComboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList;
            HComboBoxEx1.FormattingEnabled = true;
            HComboBoxEx1.Items.AddRange(new object[] { "", "新井", "波潟", "川名", "石原", "今村", "百瀨", "辻" });
            HComboBoxEx1.Location = new Point(84, 14);
            HComboBoxEx1.Name = "HComboBoxEx1";
            HComboBoxEx1.Size = new Size(100, 23);
            HComboBoxEx1.TabIndex = 1;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(732, 18);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 14;
            label4.Text = "三郷";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 18);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 12;
            label2.Text = "本社(出１)";
            // 
            // HDateTimePickerExOperationDate
            // 
            HDateTimePickerExOperationDate.CustomFormat = " yyyy年MM月dd日(dddd)";
            HDateTimePickerExOperationDate.Format = DateTimePickerFormat.Custom;
            HDateTimePickerExOperationDate.Location = new Point(92, 56);
            HDateTimePickerExOperationDate.Name = "HDateTimePickerExOperationDate";
            HDateTimePickerExOperationDate.Size = new Size(180, 23);
            HDateTimePickerExOperationDate.TabIndex = 1;
            HDateTimePickerExOperationDate.Value = new DateTime(2024, 2, 20, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 60);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "配車日付";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail, toolStripStatusLabel2, ToolStripStatusLabelPosition });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 22);
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
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(50, 17);
            toolStripStatusLabel2.Text = "Position";
            // 
            // ToolStripStatusLabelPosition
            // 
            ToolStripStatusLabelPosition.Name = "ToolStripStatusLabelPosition";
            ToolStripStatusLabelPosition.Size = new Size(156, 17);
            ToolStripStatusLabelPosition.Text = "ToolStripStatusLabelPosition";
            // 
            // H_FirstRollColl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MinimumSize = new Size(1918, 1046);
            Name = "H_FirstRollColl";
            Text = "H_FirstRollColl";
            FormClosing += H_FirstRollColl_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadFirstRollCall).EndInit();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private FarPoint.Win.Spread.FpSpread SpreadFirstRollCall;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerExOperationDate;
        private Label label1;
        private GroupBox GroupBox1;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox GroupBox2;
        private Label label9;
        private Label label8;
        private H_ControlEx.H_ComboBoxEx HComboBoxExInstruction2;
        private H_ControlEx.H_ComboBoxEx HComboBoxExInstruction1;
        private H_ControlEx.H_ComboBoxEx HComboBoxEx5;
        private H_ControlEx.H_ComboBoxEx HComboBoxEx4;
        private H_ControlEx.H_ComboBoxEx HComboBoxEx3;
        private H_ControlEx.H_ComboBoxEx HComboBoxEx2;
        private H_ControlEx.H_ComboBoxEx HComboBoxEx1;
        private H_ControlEx.H_ComboBoxEx HComboBoxExWeather;
        private Label label5;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private H_ControlEx.H_CheckBoxEx HCheckBoxEx1;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel ToolStripStatusLabelPosition;
        private FarPoint.Win.Spread.SheetView SheetViewFirstRollCall;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemExport;
        private ToolStripMenuItem ToolStripMenuItemExportExcel;
    }
}
