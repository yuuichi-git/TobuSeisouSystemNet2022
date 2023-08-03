namespace CollectionWeight {
    partial class CollectionWeightTaitouList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionWeightTaitouList));
            TableLayoutPanelBasae = new TableLayoutPanel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelStatus = new ToolStripStatusLabel();
            PanelUp = new Panel();
            DateTimePickerJpExOperationDate2 = new ControlEx.DateTimePickerJpEx();
            label2 = new Label();
            DateTimePickerJpExOperationDate1 = new ControlEx.DateTimePickerJpEx();
            label1 = new Label();
            ButtonUpdate = new Button();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelBasae.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            TableLayoutPanelBasae.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelBasae
            // 
            TableLayoutPanelBasae.ColumnCount = 1;
            TableLayoutPanelBasae.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBasae.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelBasae.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBasae.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBasae.Controls.Add(PanelUp, 0, 1);
            TableLayoutPanelBasae.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelBasae.Dock = DockStyle.Fill;
            TableLayoutPanelBasae.Location = new Point(0, 0);
            TableLayoutPanelBasae.Name = "TableLayoutPanelBasae";
            TableLayoutPanelBasae.RowCount = 4;
            TableLayoutPanelBasae.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBasae.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelBasae.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBasae.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBasae.Size = new Size(1904, 1041);
            TableLayoutPanelBasae.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
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
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelStatus });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1904, 22);
            StatusStrip1.TabIndex = 1;
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
            PanelUp.Controls.Add(DateTimePickerJpExOperationDate2);
            PanelUp.Controls.Add(label2);
            PanelUp.Controls.Add(DateTimePickerJpExOperationDate1);
            PanelUp.Controls.Add(label1);
            PanelUp.Controls.Add(ButtonUpdate);
            PanelUp.Dock = DockStyle.Fill;
            PanelUp.Location = new Point(3, 27);
            PanelUp.Name = "PanelUp";
            PanelUp.Size = new Size(1898, 54);
            PanelUp.TabIndex = 2;
            // 
            // DateTimePickerJpExOperationDate2
            // 
            DateTimePickerJpExOperationDate2.CustomFormat = " ";
            DateTimePickerJpExOperationDate2.Format = DateTimePickerFormat.Custom;
            DateTimePickerJpExOperationDate2.Location = new Point(284, 16);
            DateTimePickerJpExOperationDate2.Name = "DateTimePickerJpExOperationDate2";
            DateTimePickerJpExOperationDate2.Size = new Size(184, 23);
            DateTimePickerJpExOperationDate2.TabIndex = 6;
            DateTimePickerJpExOperationDate2.ValueChanged += DateTimePickerJpExOperationDate2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(264, 20);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 5;
            label2.Text = "～";
            // 
            // DateTimePickerJpExOperationDate1
            // 
            DateTimePickerJpExOperationDate1.CustomFormat = " ";
            DateTimePickerJpExOperationDate1.Format = DateTimePickerFormat.Custom;
            DateTimePickerJpExOperationDate1.Location = new Point(76, 16);
            DateTimePickerJpExOperationDate1.Name = "DateTimePickerJpExOperationDate1";
            DateTimePickerJpExOperationDate1.Size = new Size(184, 23);
            DateTimePickerJpExOperationDate1.TabIndex = 4;
            DateTimePickerJpExOperationDate1.ValueChanged += DateTimePickerJpExOperationDate1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(28, 20);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "収集日";
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1668, 8);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 1;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, DBデータ, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 927);
            SpreadList.TabIndex = 3;
            // 
            // CollectionWeightTaitouList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TableLayoutPanelBasae);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CollectionWeightTaitouList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CollectionWeightTaitouList";
            FormClosing += CollectionWeightTaitouList_FormClosing;
            TableLayoutPanelBasae.ResumeLayout(false);
            TableLayoutPanelBasae.PerformLayout();
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

        private TableLayoutPanel TableLayoutPanelBasae;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private Panel PanelUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private Button ButtonUpdate;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private Label label1;
        private ControlEx.DateTimePickerJpEx DateTimePickerJpExOperationDate1;
        private ControlEx.DateTimePickerJpEx DateTimePickerJpExOperationDate2;
        private Label label2;
    }
}