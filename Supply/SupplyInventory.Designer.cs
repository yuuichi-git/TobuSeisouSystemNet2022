namespace Supply {
    partial class SupplyInventory {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyInventory));
            TableLayoutPanelBase = new TableLayoutPanel();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            PanelUp = new Panel();
            ButtonUpdate = new Button();
            label1 = new Label();
            MonthPicker1 = new ControlEx.MonthPicker();
            label3 = new Label();
            ComboBoxSupplyType = new ComboBox();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            TableLayoutPanelBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            StatusStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            MenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(644, 777);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 101);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(638, 649);
            SpreadList.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 755);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(644, 22);
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
            // PanelUp
            // 
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(MonthPicker1);
            PanelUp.Controls.Add(label3);
            PanelUp.Controls.Add(ComboBoxSupplyType);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(638, 68);
            PanelUp.TabIndex = 1;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(437, 16);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 12;
            ButtonUpdate.Text = "UPDATE";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(60, 17);
            label1.TabIndex = 11;
            label1.Text = "棚卸年月";
            // 
            // MonthPicker1
            // 
            MonthPicker1.CustomFormat = "yyyy年MM月";
            MonthPicker1.Format = DateTimePickerFormat.Custom;
            MonthPicker1.Location = new Point(84, 8);
            MonthPicker1.Name = "MonthPicker1";
            MonthPicker1.Size = new Size(104, 23);
            MonthPicker1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 40);
            label3.Name = "label3";
            label3.Size = new Size(60, 17);
            label3.TabIndex = 9;
            label3.Text = "在庫種別";
            // 
            // ComboBoxSupplyType
            // 
            ComboBoxSupplyType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSupplyType.FormattingEnabled = true;
            ComboBoxSupplyType.Items.AddRange(new object[] { "事務での備品", "雇上での備品", "産廃での備品", "水物での備品" });
            ComboBoxSupplyType.Location = new Point(84, 36);
            ComboBoxSupplyType.Name = "ComboBoxSupplyType";
            ComboBoxSupplyType.Size = new Size(140, 23);
            ComboBoxSupplyType.TabIndex = 8;
            ComboBoxSupplyType.SelectedIndexChanged += ComboBoxSupplyType_SelectedIndexChanged;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(644, 24);
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
            // SupplyInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 777);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SupplyInventory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplyInventory";
            TopMost = true;
            FormClosing += SupplyIn_FormClosing;
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private Panel PanelUp;
        private Label label3;
        private ComboBox ComboBoxSupplyType;
        private ControlEx.MonthPicker MonthPicker1;
        private Label label1;
        private Button ButtonUpdate;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}