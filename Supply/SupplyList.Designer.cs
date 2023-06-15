namespace Supply {
    partial class SupplyList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyList));
            TableLayoutPanelBase = new TableLayoutPanel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemEdit = new ToolStripMenuItem();
            ToolStripMenuItemInventory = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            PanelUp = new Panel();
            label3 = new Label();
            ComboBoxSupplyType = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            DateTimePickerJpEx2 = new ControlEx.DateTimePickerJpEx();
            DateTimePickerJpEx1 = new ControlEx.DateTimePickerJpEx();
            ButtonUpdate = new Button();
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
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBase.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(734, 1041);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemEdit, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(734, 24);
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
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // ToolStripMenuItemEdit
            // 
            ToolStripMenuItemEdit.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemInventory });
            ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            ToolStripMenuItemEdit.Size = new Size(43, 20);
            ToolStripMenuItemEdit.Text = "編集";
            // 
            // ToolStripMenuItemInventory
            // 
            ToolStripMenuItemInventory.Name = "ToolStripMenuItemInventory";
            ToolStripMenuItemInventory.Size = new Size(186, 22);
            ToolStripMenuItemInventory.Text = "棚卸在庫数を入力する";
            ToolStripMenuItemInventory.Click += ToolStripMenuItemInventory_Click;
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
            StatusStrip1.Size = new Size(734, 22);
            StatusStrip1.SizingGrip = false;
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
            // PanelUp
            // 
            PanelUp.Controls.Add(label3);
            PanelUp.Controls.Add(ComboBoxSupplyType);
            PanelUp.Controls.Add(label2);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(DateTimePickerJpEx2);
            PanelUp.Controls.Add(DateTimePickerJpEx1);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(728, 68);
            PanelUp.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 40);
            label3.Name = "label3";
            label3.Size = new Size(60, 17);
            label3.TabIndex = 7;
            label3.Text = "在庫種別";
            // 
            // ComboBoxSupplyType
            // 
            ComboBoxSupplyType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSupplyType.FormattingEnabled = true;
            ComboBoxSupplyType.Items.AddRange(new object[] { "事務での備品", "雇上での備品", "産廃での備品", "水物での備品" });
            ComboBoxSupplyType.Location = new Point(92, 36);
            ComboBoxSupplyType.Name = "ComboBoxSupplyType";
            ComboBoxSupplyType.Size = new Size(140, 23);
            ComboBoxSupplyType.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(280, 12);
            label2.Name = "label2";
            label2.Size = new Size(21, 17);
            label2.TabIndex = 5;
            label2.Text = "～";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(73, 17);
            label1.TabIndex = 4;
            label1.Text = "対象年月日";
            // 
            // DateTimePickerJpEx2
            // 
            DateTimePickerJpEx2.CustomFormat = " ";
            DateTimePickerJpEx2.Format = DateTimePickerFormat.Custom;
            DateTimePickerJpEx2.Location = new Point(304, 8);
            DateTimePickerJpEx2.Name = "DateTimePickerJpEx2";
            DateTimePickerJpEx2.Size = new Size(184, 23);
            DateTimePickerJpEx2.TabIndex = 3;
            // 
            // DateTimePickerJpEx1
            // 
            DateTimePickerJpEx1.CustomFormat = " ";
            DateTimePickerJpEx1.Format = DateTimePickerFormat.Custom;
            DateTimePickerJpEx1.Location = new Point(92, 8);
            DateTimePickerJpEx1.Name = "DateTimePickerJpEx1";
            DateTimePickerJpEx1.Size = new Size(184, 23);
            DateTimePickerJpEx1.TabIndex = 2;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(530, 16);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 1;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 101);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(728, 913);
            SpreadList.TabIndex = 3;
            // 
            // SupplyList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 1041);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SupplyList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplyList";
            FormClosing += SupplyList_FormClosing;
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
        private ToolStripMenuItem ToolStripMenuItemExit;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel PanelUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private Button ButtonUpdate;
        private ControlEx.DateTimePickerJpEx DateTimePickerJpEx1;
        private ControlEx.DateTimePickerJpEx DateTimePickerJpEx2;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox ComboBoxSupplyType;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemInventory;
    }
}