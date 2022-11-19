namespace CarAccident {
    partial class CarAccidentList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarAccidentList));
            this.TableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, ((object)(resources.GetObject("TableLayoutPanelBase.Controls"))));
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelUp = new System.Windows.Forms.Panel();
            this.DateTimePickerOccurrenceDate2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimePickerOccurrenceDate1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.SheetViewList = this.SpreadList.GetSheet(0);
            this.TableLayoutPanelBase.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadList)).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.PanelUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            this.TableLayoutPanelBase.ColumnCount = 1;
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelBase.Controls.Add(this.StatusStrip1, 0, 3);
            this.TableLayoutPanelBase.Controls.Add(this.SpreadList, 0, 2);
            this.TableLayoutPanelBase.Controls.Add(this.MenuStrip1, 0, 0);
            this.TableLayoutPanelBase.Controls.Add(this.PanelUp, 0, 1);
            this.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            this.TableLayoutPanelBase.RowCount = 4;
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.Size = new System.Drawing.Size(1904, 1041);
            this.TableLayoutPanelBase.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStatusLabelStatus});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 1019);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1904, 22);
            this.StatusStrip1.TabIndex = 3;
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
            this.ToolStripStatusLabelStatus.Size = new System.Drawing.Size(143, 17);
            this.ToolStripStatusLabelStatus.Text = "ToolStripStatusLabelDetail";
            // 
            // SpreadList
            // 
            this.SpreadList.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0";
            this.SpreadList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpreadList.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SpreadList.Location = new System.Drawing.Point(3, 87);
            this.SpreadList.Name = "SpreadList";
            this.SpreadList.Size = new System.Drawing.Size(1898, 927);
            this.SpreadList.TabIndex = 0;
            this.SpreadList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.SpreadList_CellDoubleClick);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMenu,
            this.ToolStripMenuItemEdit,
            this.ToolStripMenuItemHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            this.ToolStripMenuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemExportExcel,
            this.ToolStripMenuItemExit});
            this.ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            this.ToolStripMenuItemMenu.Size = new System.Drawing.Size(52, 20);
            this.ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemExportExcel
            // 
            this.ToolStripMenuItemExportExcel.Name = "ToolStripMenuItemExportExcel";
            this.ToolStripMenuItemExportExcel.Size = new System.Drawing.Size(207, 22);
            this.ToolStripMenuItemExportExcel.Text = "Excel形式でエクスポートする";
            this.ToolStripMenuItemExportExcel.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(207, 22);
            this.ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNew});
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(43, 20);
            this.ToolStripMenuItemEdit.Text = "編集";
            // 
            // ToolStripMenuItemNew
            // 
            this.ToolStripMenuItemNew.Name = "ToolStripMenuItemNew";
            this.ToolStripMenuItemNew.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItemNew.Text = "新規レコードを作成する";
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // PanelUp
            // 
            this.PanelUp.Controls.Add(this.DateTimePickerOccurrenceDate2);
            this.PanelUp.Controls.Add(this.label1);
            this.PanelUp.Controls.Add(this.DateTimePickerOccurrenceDate1);
            this.PanelUp.Controls.Add(this.label7);
            this.PanelUp.Controls.Add(this.ButtonUpdate);
            this.PanelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelUp.Location = new System.Drawing.Point(3, 27);
            this.PanelUp.Name = "PanelUp";
            this.PanelUp.Size = new System.Drawing.Size(1898, 54);
            this.PanelUp.TabIndex = 2;
            // 
            // DateTimePickerOccurrenceDate2
            // 
            this.DateTimePickerOccurrenceDate2.CustomFormat = "yyyy年MM月dd日(ddd)";
            this.DateTimePickerOccurrenceDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerOccurrenceDate2.Location = new System.Drawing.Point(300, 16);
            this.DateTimePickerOccurrenceDate2.Name = "DateTimePickerOccurrenceDate2";
            this.DateTimePickerOccurrenceDate2.Size = new System.Drawing.Size(144, 23);
            this.DateTimePickerOccurrenceDate2.TabIndex = 21;
            this.DateTimePickerOccurrenceDate2.ValueChanged += new System.EventHandler(this.DateTimePickerOccurrenceDate2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "～";
            // 
            // DateTimePickerOccurrenceDate1
            // 
            this.DateTimePickerOccurrenceDate1.CustomFormat = "yyyy年MM月dd日(ddd)";
            this.DateTimePickerOccurrenceDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerOccurrenceDate1.Location = new System.Drawing.Point(128, 16);
            this.DateTimePickerOccurrenceDate1.Name = "DateTimePickerOccurrenceDate1";
            this.DateTimePickerOccurrenceDate1.Size = new System.Drawing.Size(144, 23);
            this.DateTimePickerOccurrenceDate1.TabIndex = 19;
            this.DateTimePickerOccurrenceDate1.ValueChanged += new System.EventHandler(this.DateTimePickerOccurrenceDate1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "事故発生日時";
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(1672, 9);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(180, 36);
            this.ButtonUpdate.TabIndex = 0;
            this.ButtonUpdate.Text = "最 新 化";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // CarAccidentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TableLayoutPanelBase);
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "CarAccidentList";
            this.Text = "CarAccidentList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CarAccidentList_FormClosing);
            this.TableLayoutPanelBase.ResumeLayout(false);
            this.TableLayoutPanelBase.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadList)).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.PanelUp.ResumeLayout(false);
            this.PanelUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private Panel PanelUp;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private Button ButtonUpdate;
        private DateTimePicker DateTimePickerOccurrenceDate2;
        private Label label1;
        private DateTimePicker DateTimePickerOccurrenceDate1;
        private Label label7;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemNew;
        private ToolStripMenuItem ToolStripMenuItemExportExcel;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}