namespace H_CollectionWeight {
    partial class H_CollectionWeightCHIYODA {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_CollectionWeightCHIYODA));
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            label2 = new Label();
            HDateTimePickerEx2 = new H_ControlEx.H_DateTimePickerEx();
            HDateTimePickerEx1 = new H_ControlEx.H_DateTimePickerEx();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls"));
            SheetViewList = SpreadList.GetSheet(0);
            SpreadAggregate = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("HTableLayoutPanelExBase.Controls1"));
            ToolStripMenuItemExit = new ToolStripMenuItem();
            SheetViewAggregate = SpreadAggregate.GetSheet(0);
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpreadAggregate).BeginInit();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 2;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(SpreadList, 0, 2);
            HTableLayoutPanelExBase.Controls.Add(SpreadAggregate, 1, 2);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(984, 761);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            HTableLayoutPanelExBase.SetColumnSpan(MenuStrip1, 2);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(984, 24);
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
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            HTableLayoutPanelExBase.SetColumnSpan(StatusStrip1, 2);
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 739);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(984, 22);
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
            // HPanelExUp
            // 
            HTableLayoutPanelExBase.SetColumnSpan(HPanelExUp, 2);
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Controls.Add(label2);
            HPanelExUp.Controls.Add(HDateTimePickerEx2);
            HPanelExUp.Controls.Add(HDateTimePickerEx1);
            HPanelExUp.Controls.Add(label1);
            HPanelExUp.Controls.Add(label4);
            HPanelExUp.Controls.Add(label3);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(978, 74);
            HPanelExUp.TabIndex = 2;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Location = new Point(792, 20);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(152, 36);
            HButtonExUpdate.TabIndex = 18;
            HButtonExUpdate.Text = "最　新　化";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 16);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 17;
            label2.Text = "～";
            // 
            // HDateTimePickerEx2
            // 
            HDateTimePickerEx2.CustomFormat = " yyyy年MM月dd日(dddd)";
            HDateTimePickerEx2.Format = DateTimePickerFormat.Custom;
            HDateTimePickerEx2.Location = new Point(276, 12);
            HDateTimePickerEx2.Name = "HDateTimePickerEx2";
            HDateTimePickerEx2.Size = new Size(184, 23);
            HDateTimePickerEx2.TabIndex = 16;
            HDateTimePickerEx2.Value = new DateTime(2024, 3, 20, 0, 0, 0, 0);
            HDateTimePickerEx2.ValueChanged += HDateTimePickerEx2_ValueChanged;
            // 
            // HDateTimePickerEx1
            // 
            HDateTimePickerEx1.CustomFormat = " yyyy年MM月dd日(dddd)";
            HDateTimePickerEx1.Format = DateTimePickerFormat.Custom;
            HDateTimePickerEx1.Location = new Point(72, 12);
            HDateTimePickerEx1.Name = "HDateTimePickerEx1";
            HDateTimePickerEx1.Size = new Size(184, 23);
            HDateTimePickerEx1.TabIndex = 15;
            HDateTimePickerEx1.Value = new DateTime(2024, 3, 20, 0, 0, 0, 0);
            HDateTimePickerEx1.ValueChanged += HDateTimePickerEx1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 14;
            label1.Text = "配車日付";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(496, 48);
            label4.Name = "label4";
            label4.Size = new Size(156, 20);
            label4.TabIndex = 13;
            label4.Text = "期間内の従事者集計表";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(4, 48);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 12;
            label3.Text = "期間内の従事者一覧表";
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "Book1, 一覧表示, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 107);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(486, 627);
            SpreadList.TabIndex = 3;
            // 
            // SpreadAggregate
            // 
            SpreadAggregate.AccessibleDescription = "Book1, 集計値, Row 0, Column 0";
            SpreadAggregate.Dock = DockStyle.Fill;
            SpreadAggregate.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadAggregate.Location = new Point(495, 107);
            SpreadAggregate.Name = "SpreadAggregate";
            SpreadAggregate.Size = new Size(486, 627);
            SpreadAggregate.TabIndex = 4;
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(195, 22);
            ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            // 
            // H_CollectionWeightCHIYODA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(HTableLayoutPanelExBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_CollectionWeightCHIYODA";
            Text = "H_CollectionWeightCHIYODA";
            FormClosing += H_CollectionWeightCHIYODA_FormClosing;
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HPanelExUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpreadAggregate).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private FarPoint.Win.Spread.FpSpread SpreadAggregate;
        private FarPoint.Win.Spread.SheetView SheetViewList;
        private Label label4;
        private Label label3;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerEx2;
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerEx1;
        private Label label1;
        private Label label2;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private FarPoint.Win.Spread.SheetView SheetViewAggregate;
    }
}