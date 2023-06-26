namespace StatusOfResidence {
    partial class StatusOfResidenceNewUpdate {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            TableLayoutPanelBase = new TableLayoutPanel();
            PanelUp = new Panel();
            ButtonUpdate = new Button();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            PanelCenter = new Panel();
            ButtonDeletePictureTail = new Button();
            ButtonClipPictureTail = new Button();
            ButtonSelectPictureTail = new Button();
            ButtonDeletePictureHead = new Button();
            ButtonClipPictureHead = new Button();
            ButtonSelectPictureHead = new Button();
            PictureBoxTail = new PictureBox();
            PictureBoxHead = new PictureBox();
            label10 = new Label();
            TextBoxStaffNameKana = new TextBox();
            ComboBoxExWorkLimit = new ControlEx.ComboBoxEx();
            ComboBoxExStatusOfResidence = new ControlEx.ComboBoxEx();
            ComboBoxExAddress = new ControlEx.ComboBoxEx();
            ComboBoxExNationarity = new ControlEx.ComboBoxEx();
            ComboBoxExSex = new ControlEx.ComboBoxEx();
            DateTimePickerExDeadlineDate = new ControlEx.DateTimePickerEx();
            DateTimePickerExPeriodDate = new ControlEx.DateTimePickerEx();
            DateTimePickerExBirthDay = new ControlEx.DateTimePickerEx();
            TextBoxStaffName = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            ComboBoxExSerchStaff = new ControlEx.ComboBoxEx();
            label11 = new Label();
            TableLayoutPanelBase.SuspendLayout();
            PanelUp.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxTail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHead).BeginInit();
            MenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelCenter, 0, 2);
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(1060, 791);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // PanelUp
            // 
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(1054, 54);
            PanelUp.TabIndex = 0;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(840, 8);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 2;
            ButtonUpdate.Text = "UPDATE";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 769);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1060, 22);
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
            // PanelCenter
            // 
            PanelCenter.Controls.Add(ComboBoxExSerchStaff);
            PanelCenter.Controls.Add(label11);
            PanelCenter.Controls.Add(ButtonDeletePictureTail);
            PanelCenter.Controls.Add(ButtonClipPictureTail);
            PanelCenter.Controls.Add(ButtonSelectPictureTail);
            PanelCenter.Controls.Add(ButtonDeletePictureHead);
            PanelCenter.Controls.Add(ButtonClipPictureHead);
            PanelCenter.Controls.Add(ButtonSelectPictureHead);
            PanelCenter.Controls.Add(PictureBoxTail);
            PanelCenter.Controls.Add(PictureBoxHead);
            PanelCenter.Controls.Add(label10);
            PanelCenter.Controls.Add(TextBoxStaffNameKana);
            PanelCenter.Controls.Add(ComboBoxExWorkLimit);
            PanelCenter.Controls.Add(ComboBoxExStatusOfResidence);
            PanelCenter.Controls.Add(ComboBoxExAddress);
            PanelCenter.Controls.Add(ComboBoxExNationarity);
            PanelCenter.Controls.Add(ComboBoxExSex);
            PanelCenter.Controls.Add(DateTimePickerExDeadlineDate);
            PanelCenter.Controls.Add(DateTimePickerExPeriodDate);
            PanelCenter.Controls.Add(DateTimePickerExBirthDay);
            PanelCenter.Controls.Add(TextBoxStaffName);
            PanelCenter.Controls.Add(label9);
            PanelCenter.Controls.Add(label8);
            PanelCenter.Controls.Add(label7);
            PanelCenter.Controls.Add(label6);
            PanelCenter.Controls.Add(label5);
            PanelCenter.Controls.Add(label4);
            PanelCenter.Controls.Add(label3);
            PanelCenter.Controls.Add(label2);
            PanelCenter.Controls.Add(label1);
            PanelCenter.Dock = DockStyle.Fill;
            PanelCenter.Location = new Point(3, 87);
            PanelCenter.Name = "PanelCenter";
            PanelCenter.Size = new Size(1054, 677);
            PanelCenter.TabIndex = 1;
            // 
            // ButtonDeletePictureTail
            // 
            ButtonDeletePictureTail.Location = new Point(956, 408);
            ButtonDeletePictureTail.Name = "ButtonDeletePictureTail";
            ButtonDeletePictureTail.Size = new Size(68, 24);
            ButtonDeletePictureTail.TabIndex = 38;
            ButtonDeletePictureTail.Tag = "PictureBoxTail";
            ButtonDeletePictureTail.Text = "Delete";
            ButtonDeletePictureTail.UseVisualStyleBackColor = true;
            ButtonDeletePictureTail.Click += ToolStripMenuItem_Click;
            // 
            // ButtonClipPictureTail
            // 
            ButtonClipPictureTail.Location = new Point(956, 380);
            ButtonClipPictureTail.Name = "ButtonClipPictureTail";
            ButtonClipPictureTail.Size = new Size(68, 24);
            ButtonClipPictureTail.TabIndex = 37;
            ButtonClipPictureTail.Tag = "PictureBoxTail";
            ButtonClipPictureTail.Text = "Clip";
            ButtonClipPictureTail.UseVisualStyleBackColor = true;
            ButtonClipPictureTail.Click += ToolStripMenuItem_Click;
            // 
            // ButtonSelectPictureTail
            // 
            ButtonSelectPictureTail.Location = new Point(956, 352);
            ButtonSelectPictureTail.Name = "ButtonSelectPictureTail";
            ButtonSelectPictureTail.Size = new Size(68, 24);
            ButtonSelectPictureTail.TabIndex = 36;
            ButtonSelectPictureTail.Tag = "PictureBoxTail";
            ButtonSelectPictureTail.Text = "Select";
            ButtonSelectPictureTail.UseVisualStyleBackColor = true;
            ButtonSelectPictureTail.Click += ToolStripMenuItem_Click;
            // 
            // ButtonDeletePictureHead
            // 
            ButtonDeletePictureHead.Location = new Point(956, 88);
            ButtonDeletePictureHead.Name = "ButtonDeletePictureHead";
            ButtonDeletePictureHead.Size = new Size(68, 24);
            ButtonDeletePictureHead.TabIndex = 35;
            ButtonDeletePictureHead.Tag = "PictureBoxHead";
            ButtonDeletePictureHead.Text = "Delete";
            ButtonDeletePictureHead.UseVisualStyleBackColor = true;
            ButtonDeletePictureHead.Click += ToolStripMenuItem_Click;
            // 
            // ButtonClipPictureHead
            // 
            ButtonClipPictureHead.Location = new Point(956, 60);
            ButtonClipPictureHead.Name = "ButtonClipPictureHead";
            ButtonClipPictureHead.Size = new Size(68, 24);
            ButtonClipPictureHead.TabIndex = 34;
            ButtonClipPictureHead.Tag = "PictureBoxHead";
            ButtonClipPictureHead.Text = "Clip";
            ButtonClipPictureHead.UseVisualStyleBackColor = true;
            ButtonClipPictureHead.Click += ToolStripMenuItem_Click;
            // 
            // ButtonSelectPictureHead
            // 
            ButtonSelectPictureHead.Location = new Point(956, 32);
            ButtonSelectPictureHead.Name = "ButtonSelectPictureHead";
            ButtonSelectPictureHead.Size = new Size(68, 24);
            ButtonSelectPictureHead.TabIndex = 33;
            ButtonSelectPictureHead.Tag = "PictureBoxHead";
            ButtonSelectPictureHead.Text = "Select";
            ButtonSelectPictureHead.UseVisualStyleBackColor = true;
            ButtonSelectPictureHead.Click += ToolStripMenuItem_Click;
            // 
            // PictureBoxTail
            // 
            PictureBoxTail.BorderStyle = BorderStyle.FixedSingle;
            PictureBoxTail.Location = new Point(460, 344);
            PictureBoxTail.Name = "PictureBoxTail";
            PictureBoxTail.Size = new Size(488, 308);
            PictureBoxTail.TabIndex = 21;
            PictureBoxTail.TabStop = false;
            // 
            // PictureBoxHead
            // 
            PictureBoxHead.BorderStyle = BorderStyle.FixedSingle;
            PictureBoxHead.Location = new Point(460, 24);
            PictureBoxHead.Name = "PictureBoxHead";
            PictureBoxHead.Size = new Size(488, 308);
            PictureBoxHead.TabIndex = 20;
            PictureBoxHead.TabStop = false;
            // 
            // label10
            // 
            label10.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(24, 92);
            label10.Name = "label10";
            label10.Size = new Size(100, 20);
            label10.TabIndex = 19;
            label10.Text = "カナ";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TextBoxStaffNameKana
            // 
            TextBoxStaffNameKana.Location = new Point(128, 92);
            TextBoxStaffNameKana.Name = "TextBoxStaffNameKana";
            TextBoxStaffNameKana.Size = new Size(304, 23);
            TextBoxStaffNameKana.TabIndex = 18;
            // 
            // ComboBoxExWorkLimit
            // 
            ComboBoxExWorkLimit.FormattingEnabled = true;
            ComboBoxExWorkLimit.Location = new Point(128, 260);
            ComboBoxExWorkLimit.Name = "ComboBoxExWorkLimit";
            ComboBoxExWorkLimit.Size = new Size(168, 23);
            ComboBoxExWorkLimit.TabIndex = 17;
            // 
            // ComboBoxExStatusOfResidence
            // 
            ComboBoxExStatusOfResidence.FormattingEnabled = true;
            ComboBoxExStatusOfResidence.Location = new Point(128, 232);
            ComboBoxExStatusOfResidence.Name = "ComboBoxExStatusOfResidence";
            ComboBoxExStatusOfResidence.Size = new Size(168, 23);
            ComboBoxExStatusOfResidence.TabIndex = 16;
            // 
            // ComboBoxExAddress
            // 
            ComboBoxExAddress.FormattingEnabled = true;
            ComboBoxExAddress.Location = new Point(128, 204);
            ComboBoxExAddress.Name = "ComboBoxExAddress";
            ComboBoxExAddress.Size = new Size(168, 23);
            ComboBoxExAddress.TabIndex = 15;
            // 
            // ComboBoxExNationarity
            // 
            ComboBoxExNationarity.FormattingEnabled = true;
            ComboBoxExNationarity.Location = new Point(128, 176);
            ComboBoxExNationarity.Name = "ComboBoxExNationarity";
            ComboBoxExNationarity.Size = new Size(168, 23);
            ComboBoxExNationarity.TabIndex = 14;
            // 
            // ComboBoxExSex
            // 
            ComboBoxExSex.FormattingEnabled = true;
            ComboBoxExSex.Location = new Point(128, 148);
            ComboBoxExSex.Name = "ComboBoxExSex";
            ComboBoxExSex.Size = new Size(56, 23);
            ComboBoxExSex.TabIndex = 13;
            // 
            // DateTimePickerExDeadlineDate
            // 
            DateTimePickerExDeadlineDate.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePickerExDeadlineDate.Format = DateTimePickerFormat.Custom;
            DateTimePickerExDeadlineDate.Location = new Point(128, 316);
            DateTimePickerExDeadlineDate.Name = "DateTimePickerExDeadlineDate";
            DateTimePickerExDeadlineDate.Size = new Size(168, 23);
            DateTimePickerExDeadlineDate.TabIndex = 12;
            // 
            // DateTimePickerExPeriodDate
            // 
            DateTimePickerExPeriodDate.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePickerExPeriodDate.Format = DateTimePickerFormat.Custom;
            DateTimePickerExPeriodDate.Location = new Point(128, 288);
            DateTimePickerExPeriodDate.Name = "DateTimePickerExPeriodDate";
            DateTimePickerExPeriodDate.Size = new Size(168, 23);
            DateTimePickerExPeriodDate.TabIndex = 11;
            // 
            // DateTimePickerExBirthDay
            // 
            DateTimePickerExBirthDay.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePickerExBirthDay.Format = DateTimePickerFormat.Custom;
            DateTimePickerExBirthDay.Location = new Point(128, 120);
            DateTimePickerExBirthDay.Name = "DateTimePickerExBirthDay";
            DateTimePickerExBirthDay.Size = new Size(168, 23);
            DateTimePickerExBirthDay.TabIndex = 10;
            // 
            // TextBoxStaffName
            // 
            TextBoxStaffName.Location = new Point(128, 64);
            TextBoxStaffName.Name = "TextBoxStaffName";
            TextBoxStaffName.Size = new Size(304, 23);
            TextBoxStaffName.TabIndex = 9;
            // 
            // label9
            // 
            label9.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(24, 316);
            label9.Name = "label9";
            label9.Size = new Size(100, 20);
            label9.TabIndex = 8;
            label9.Text = "有効期限";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(24, 288);
            label8.Name = "label8";
            label8.Size = new Size(100, 20);
            label8.TabIndex = 7;
            label8.Text = "在留期間";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(24, 260);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 6;
            label7.Text = "就労制限の有無";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(24, 232);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 5;
            label6.Text = "在留資格";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(24, 204);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 4;
            label5.Text = "住居地";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(24, 176);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 3;
            label4.Text = "国籍・地域";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(24, 148);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 2;
            label3.Text = "性別";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(24, 120);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "生年月日";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 64);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 0;
            label1.Text = "氏名";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1060, 24);
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
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // ComboBoxExSerchStaff
            // 
            ComboBoxExSerchStaff.FormattingEnabled = true;
            ComboBoxExSerchStaff.Location = new Point(128, 24);
            ComboBoxExSerchStaff.Name = "ComboBoxExSerchStaff";
            ComboBoxExSerchStaff.Size = new Size(304, 23);
            ComboBoxExSerchStaff.TabIndex = 40;
            // 
            // label11
            // 
            label11.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(24, 24);
            label11.Name = "label11";
            label11.Size = new Size(100, 20);
            label11.TabIndex = 39;
            label11.Text = "従事者選択";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StatusOfResidenceNewUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 791);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StatusOfResidenceNewUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StatusOfResidenceNew";
            FormClosing += StatusOfResidenceNew_FormClosing;
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            PanelUp.ResumeLayout(false);
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelCenter.ResumeLayout(false);
            PanelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxTail).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHead).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private Panel PanelUp;
        private Panel PanelCenter;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private Label label1;
        private TextBox TextBoxStaffName;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ControlEx.DateTimePickerEx DateTimePickerExBirthDay;
        private ControlEx.DateTimePickerEx DateTimePickerExDeadlineDate;
        private ControlEx.DateTimePickerEx DateTimePickerExPeriodDate;
        private ControlEx.ComboBoxEx ComboBoxExAddress;
        private ControlEx.ComboBoxEx ComboBoxExNationarity;
        private ControlEx.ComboBoxEx ComboBoxExSex;
        private Label label10;
        private TextBox TextBoxStaffNameKana;
        private ControlEx.ComboBoxEx ComboBoxExWorkLimit;
        private ControlEx.ComboBoxEx ComboBoxExStatusOfResidence;
        private PictureBox PictureBoxTail;
        private PictureBox PictureBoxHead;
        private Button ButtonDeletePictureHead;
        private Button ButtonClipPictureHead;
        private Button ButtonSelectPictureHead;
        private Button ButtonDeletePictureTail;
        private Button ButtonClipPictureTail;
        private Button ButtonSelectPictureTail;
        private Button ButtonUpdate;
        private ControlEx.ComboBoxEx ComboBoxExSerchStaff;
        private Label label11;
    }
}