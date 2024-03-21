namespace WardSpreadsheet {
    partial class WardChiyoda {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WardChiyoda));
            TableLayoutPanelBase = new TableLayoutPanel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            PanelUp = new Panel();
            label4 = new Label();
            label3 = new Label();
            DateTimePicker2 = new DateTimePicker();
            DateTimePicker1 = new DateTimePicker();
            ButtonUpdate = new Button();
            label2 = new Label();
            label1 = new Label();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelStatus = new ToolStripStatusLabel();
            PanelMiddle = new Panel();
            SpreadAggregate = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("PanelMiddle.Controls"));
            SheetViewAggregate = SpreadAggregate.GetSheet(0);
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("PanelMiddle.Controls1"));
            SheetViewList = SpreadList.GetSheet(0);
            TableLayoutPanelBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadAggregate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelMiddle, 0, 2);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(929, 786);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(929, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrint, ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(244, 22);
            ToolStripMenuItemPrint.Text = "期間内の従事者集計表を印刷する";
            ToolStripMenuItemPrint.Click += ToolStripMenuItemPrint_Click;
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(244, 22);
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
            PanelUp.Controls.Add(label4);
            PanelUp.Controls.Add(label3);
            PanelUp.Controls.Add(DateTimePicker2);
            PanelUp.Controls.Add(DateTimePicker1);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Controls.Add(label2);
            PanelUp.Controls.Add(label1);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(923, 78);
            PanelUp.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(500, 56);
            label4.Name = "label4";
            label4.Size = new Size(156, 20);
            label4.TabIndex = 11;
            label4.Text = "期間内の従事者集計表";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(8, 56);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 10;
            label3.Text = "期間内の従事者一覧表";
            // 
            // DateTimePicker2
            // 
            DateTimePicker2.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePicker2.Format = DateTimePickerFormat.Custom;
            DateTimePicker2.Location = new Point(276, 16);
            DateTimePicker2.Name = "DateTimePicker2";
            DateTimePicker2.Size = new Size(168, 23);
            DateTimePicker2.TabIndex = 9;
            DateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
            // 
            // DateTimePicker1
            // 
            DateTimePicker1.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.Location = new Point(80, 16);
            DateTimePicker1.Name = "DateTimePicker1";
            DateTimePicker1.Size = new Size(168, 23);
            DateTimePicker1.TabIndex = 8;
            DateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(688, 12);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 7;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 20);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 6;
            label2.Text = "～";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "配車日付";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelStatus });
            StatusStrip1.Location = new Point(0, 764);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(929, 22);
            StatusStrip1.SizingGrip = false;
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
            // PanelMiddle
            // 
            PanelMiddle.Controls.Add(SpreadAggregate);
            PanelMiddle.Controls.Add(SpreadList);
            PanelMiddle.Dock = DockStyle.Fill;
            PanelMiddle.Location = new Point(3, 111);
            PanelMiddle.Name = "PanelMiddle";
            PanelMiddle.Size = new Size(923, 648);
            PanelMiddle.TabIndex = 3;
            // 
            // SpreadAggregate
            // 
            SpreadAggregate.AccessibleDescription = "SpreadCount, 集計値, Row 0, Column 0";
            SpreadAggregate.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadAggregate.Location = new Point(496, 4);
            SpreadAggregate.Name = "SpreadAggregate";
            SpreadAggregate.Size = new Size(424, 624);
            SpreadAggregate.TabIndex = 4;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, 一覧表示, Row 0, Column 0";
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(4, 4);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(488, 624);
            SpreadList.TabIndex = 3;
            // 
            // WardChiyoda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 786);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WardChiyoda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WardChiyoda";
            FormClosing += WardChiyoda_FormClosing;
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpreadAggregate).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private Panel PanelUp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private Label label1;
        private Label label2;
        private Button ButtonUpdate;
        private DateTimePicker DateTimePicker2;
        private DateTimePicker DateTimePicker1;
        private Panel PanelMiddle;
        private FarPoint.Win.Spread.FpSpread SpreadAggregate;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private Label label4;
        private Label label3;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private FarPoint.Win.Spread.SheetView SheetViewAggregate;
    }
}