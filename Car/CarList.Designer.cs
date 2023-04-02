namespace Car {
    partial class CarList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarList));
            tableLayoutPanel1 = new TableLayoutPanel();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelStatus = new ToolStripStatusLabel();
            PanelUp = new Panel();
            CheckBoxDeleteFlag = new CheckBox();
            ButtonUpdate = new Button();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemEdit = new ToolStripMenuItem();
            ToolStripMenuItemInsertNewCar = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("tableLayoutPanel1.Controls"));
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ToolStripMenuItemDelete = new ToolStripMenuItem();
            SheetViewList = SpreadList.GetSheet(0);
            tableLayoutPanel1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            ContextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(StatusStrip1, 0, 3);
            tableLayoutPanel1.Controls.Add(PanelUp, 0, 1);
            tableLayoutPanel1.Controls.Add(MenuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(SpreadList, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.Size = new Size(1904, 1041);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelStatus });
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
            // PanelUp
            // 
            PanelUp.Controls.Add(CheckBoxDeleteFlag);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(1898, 54);
            PanelUp.TabIndex = 0;
            // 
            // CheckBoxDeleteFlag
            // 
            CheckBoxDeleteFlag.AutoSize = true;
            CheckBoxDeleteFlag.Location = new Point(1500, 20);
            CheckBoxDeleteFlag.Name = "CheckBoxDeleteFlag";
            CheckBoxDeleteFlag.Size = new Size(138, 19);
            CheckBoxDeleteFlag.TabIndex = 1;
            CheckBoxDeleteFlag.Text = "削除済のレコードも表示";
            CheckBoxDeleteFlag.UseVisualStyleBackColor = true;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1672, 9);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 0;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemEdit, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1904, 24);
            MenuStrip1.TabIndex = 1;
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
            ToolStripMenuItemEdit.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemInsertNewCar });
            ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            ToolStripMenuItemEdit.Size = new Size(43, 20);
            ToolStripMenuItemEdit.Text = "編集";
            // 
            // ToolStripMenuItemInsertNewCar
            // 
            ToolStripMenuItemInsertNewCar.Name = "ToolStripMenuItemInsertNewCar";
            ToolStripMenuItemInsertNewCar.Size = new Size(174, 22);
            ToolStripMenuItemInsertNewCar.Text = "車両を新規登録する";
            ToolStripMenuItemInsertNewCar.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.ContextMenuStrip = ContextMenuStrip1;
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 927);
            SpreadList.TabIndex = 3;
            SpreadList.CellDoubleClick += SpreadList_CellDoubleClick;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemDelete });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size(231, 26);
            ContextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            // 
            // ToolStripMenuItemDelete
            // 
            ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            ToolStripMenuItemDelete.Size = new Size(230, 22);
            ToolStripMenuItemDelete.Text = "選択されているレコードを削除する";
            ToolStripMenuItemDelete.Click += ToolStripMenuItem_Click;
            // 
            // CarList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tableLayoutPanel1);
            MainMenuStrip = MenuStrip1;
            Name = "CarList";
            Text = "CarList";
            FormClosing += CarList_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelUp.ResumeLayout(false);
            PanelUp.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ContextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel PanelUp;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private Button ButtonUpdate;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private CheckBox CheckBoxDeleteFlag;
        private ContextMenuStrip ContextMenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemDelete;
        private ToolStripMenuItem ToolStripMenuItemInsertNewCar;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}