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
            this.TableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelUp = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.PanelMiddle = new System.Windows.Forms.Panel();
            this.SpreadAggregate = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, ((object)(resources.GetObject("PanelMiddle.Controls"))));
            this.SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, ((object)(resources.GetObject("PanelMiddle.Controls1"))));
            this.SheetViewList = this.SpreadList.GetSheet(0);
            this.SheetViewAggregate = this.SpreadAggregate.GetSheet(0);
            this.TableLayoutPanelBase.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.PanelUp.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.PanelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadAggregate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadList)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            this.TableLayoutPanelBase.ColumnCount = 1;
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.Controls.Add(this.MenuStrip1, 0, 0);
            this.TableLayoutPanelBase.Controls.Add(this.PanelUp, 0, 1);
            this.TableLayoutPanelBase.Controls.Add(this.StatusStrip1, 0, 3);
            this.TableLayoutPanelBase.Controls.Add(this.PanelMiddle, 0, 2);
            this.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            this.TableLayoutPanelBase.RowCount = 4;
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.Size = new System.Drawing.Size(929, 786);
            this.TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMenu,
            this.ToolStripMenuItemHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(929, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            this.ToolStripMenuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemPrint,
            this.ToolStripMenuItemExit});
            this.ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            this.ToolStripMenuItemMenu.Size = new System.Drawing.Size(52, 20);
            this.ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemPrint
            // 
            this.ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            this.ToolStripMenuItemPrint.Size = new System.Drawing.Size(244, 22);
            this.ToolStripMenuItemPrint.Text = "期間内の従事者集計表を印刷する";
            this.ToolStripMenuItemPrint.Click += new System.EventHandler(this.ToolStripMenuItemPrint_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(244, 22);
            this.ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // PanelUp
            // 
            this.PanelUp.Controls.Add(this.label4);
            this.PanelUp.Controls.Add(this.label3);
            this.PanelUp.Controls.Add(this.DateTimePicker2);
            this.PanelUp.Controls.Add(this.DateTimePicker1);
            this.PanelUp.Controls.Add(this.ButtonUpdate);
            this.PanelUp.Controls.Add(this.label2);
            this.PanelUp.Controls.Add(this.label1);
            this.PanelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelUp.Location = new System.Drawing.Point(3, 27);
            this.PanelUp.Name = "PanelUp";
            this.PanelUp.Size = new System.Drawing.Size(923, 78);
            this.PanelUp.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(500, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "期間内の従事者集計表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "期間内の従事者一覧表";
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.CustomFormat = "yyyy年MM月dd日(dddd)";
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker2.Location = new System.Drawing.Point(276, 16);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(168, 23);
            this.DateTimePicker2.TabIndex = 9;
            this.DateTimePicker2.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CustomFormat = "yyyy年MM月dd日(dddd)";
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Location = new System.Drawing.Point(80, 16);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(168, 23);
            this.DateTimePicker1.TabIndex = 8;
            this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(688, 12);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(180, 36);
            this.ButtonUpdate.TabIndex = 7;
            this.ButtonUpdate.Text = "最 新 化";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "配車日付";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStatusLabelStatus});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 764);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(929, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 2;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelStatus
            // 
            this.ToolStripStatusLabelStatus.Name = "ToolStripStatusLabelStatus";
            this.ToolStripStatusLabelStatus.Size = new System.Drawing.Size(145, 17);
            this.ToolStripStatusLabelStatus.Text = "ToolStripStatusLabelStatus";
            // 
            // PanelMiddle
            // 
            this.PanelMiddle.Controls.Add(this.SpreadAggregate);
            this.PanelMiddle.Controls.Add(this.SpreadList);
            this.PanelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMiddle.Location = new System.Drawing.Point(3, 111);
            this.PanelMiddle.Name = "PanelMiddle";
            this.PanelMiddle.Size = new System.Drawing.Size(923, 648);
            this.PanelMiddle.TabIndex = 3;
            // 
            // SpreadAggregate
            // 
            this.SpreadAggregate.AccessibleDescription = "SpreadCount, 集計値, Row 0, Column 0";
            this.SpreadAggregate.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SpreadAggregate.Location = new System.Drawing.Point(496, 4);
            this.SpreadAggregate.Name = "SpreadAggregate";
            this.SpreadAggregate.Size = new System.Drawing.Size(424, 624);
            this.SpreadAggregate.TabIndex = 4;
            // 
            // SpreadList
            // 
            this.SpreadList.AccessibleDescription = "SpreadList, 一覧表示, Row 0, Column 0";
            this.SpreadList.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SpreadList.Location = new System.Drawing.Point(4, 4);
            this.SpreadList.Name = "SpreadList";
            this.SpreadList.Size = new System.Drawing.Size(488, 624);
            this.SpreadList.TabIndex = 3;
            // 
            // WardChiyoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 786);
            this.Controls.Add(this.TableLayoutPanelBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WardChiyoda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WardChiyoda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WardChiyoda_FormClosing);
            this.TableLayoutPanelBase.ResumeLayout(false);
            this.TableLayoutPanelBase.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.PanelUp.ResumeLayout(false);
            this.PanelUp.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.PanelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpreadAggregate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadList)).EndInit();
            this.ResumeLayout(false);

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