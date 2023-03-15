namespace WardSpreadsheet {
    partial class WardTaitou {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WardTaitou));
            TableLayoutPanelBase = new TableLayoutPanel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemExport = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelStatus = new ToolStripStatusLabel();
            PanelUp = new Panel();
            ButtonUpdate = new Button();
            DateTimePicker2 = new DateTimePicker();
            DateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            TableLayoutPanelBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(857, 1041);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new System.Drawing.Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(857, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrint, ToolStripMenuItemExport, ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(195, 22);
            ToolStripMenuItemPrint.Text = "印刷する";
            ToolStripMenuItemPrint.Click += ToolStripMenuItemPrint_Click;
            // 
            // ToolStripMenuItemExport
            // 
            ToolStripMenuItemExport.Name = "ToolStripMenuItemExport";
            ToolStripMenuItemExport.Size = new Size(195, 22);
            ToolStripMenuItemExport.Text = "エクスポートする";
            ToolStripMenuItemExport.Click += ToolStripMenuItemExport_Click;
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
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabelStatus });
            StatusStrip1.Location = new System.Drawing.Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(857, 22);
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(39, 17);
            ToolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelStatus
            // 
            ToolStripStatusLabelStatus.Name = "ToolStripStatusLabelStatus";
            ToolStripStatusLabelStatus.Size = new Size(118, 17);
            ToolStripStatusLabelStatus.Text = "toolStripStatusLabel2";
            // 
            // PanelUp
            // 
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Controls.Add(DateTimePicker2);
            PanelUp.Controls.Add(DateTimePicker1);
            PanelUp.Controls.Add(label2);
            PanelUp.Controls.Add(label1);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new System.Drawing.Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(851, 54);
            PanelUp.TabIndex = 2;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new System.Drawing.Point(640, 8);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 14;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            // 
            // DateTimePicker2
            // 
            DateTimePicker2.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePicker2.Format = DateTimePickerFormat.Custom;
            DateTimePicker2.Location = new System.Drawing.Point(288, 16);
            DateTimePicker2.Name = "DateTimePicker2";
            DateTimePicker2.Size = new Size(168, 23);
            DateTimePicker2.TabIndex = 13;
            // 
            // DateTimePicker1
            // 
            DateTimePicker1.CustomFormat = "yyyy年MM月dd日(dddd)";
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.Location = new System.Drawing.Point(92, 16);
            DateTimePicker1.Name = "DateTimePicker1";
            DateTimePicker1.Size = new Size(168, 23);
            DateTimePicker1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(264, 20);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 11;
            label2.Text = "～";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(32, 20);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 10;
            label1.Text = "配車日付";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new System.Drawing.Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(851, 927);
            SpreadList.TabIndex = 3;
            // 
            // WardTaitou
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 1041);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WardTaitou";
            Text = "WardTaitou";
            FormClosing += WardTaitou_FormClosing;
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel ToolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private Panel PanelUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private DateTimePicker DateTimePicker2;
        private DateTimePicker DateTimePicker1;
        private Label label2;
        private Label label1;
        private Button ButtonUpdate;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemExport;
    }
}