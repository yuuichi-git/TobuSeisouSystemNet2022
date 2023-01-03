namespace VehicleDispatchSheet {
    partial class VehicleDispatchSheetBoad {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleDispatchSheetBoad));
            this.TableLayoutPanelExBase = new ControlEx.TableLayoutPanelEx();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.SpreadBase = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, ((object)(resources.GetObject("TableLayoutPanelExBase.Controls"))));
            this.SheetView1 = this.SpreadBase.GetSheet(0);
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelUp = new System.Windows.Forms.Panel();
            this.UcDateTimeJpOperationDate = new ControlEx.UcDateTimeJp();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.TableLayoutPanelExBase.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadBase)).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.PanelUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanelExBase
            // 
            this.TableLayoutPanelExBase.ColumnCount = 1;
            this.TableLayoutPanelExBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelExBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelExBase.Controls.Add(this.StatusStrip1, 0, 3);
            this.TableLayoutPanelExBase.Controls.Add(this.SpreadBase, 0, 2);
            this.TableLayoutPanelExBase.Controls.Add(this.MenuStrip1, 0, 0);
            this.TableLayoutPanelExBase.Controls.Add(this.PanelUp, 0, 1);
            this.TableLayoutPanelExBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelExBase.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelExBase.Name = "TableLayoutPanelExBase";
            this.TableLayoutPanelExBase.RowCount = 4;
            this.TableLayoutPanelExBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelExBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TableLayoutPanelExBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelExBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelExBase.Size = new System.Drawing.Size(1904, 1041);
            this.TableLayoutPanelExBase.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStatusLabelStatus,
            this.toolStripStatusLabel2,
            this.ToolStripStatusLabelPosition});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 1019);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1904, 22);
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel2.Text = "　Position";
            // 
            // ToolStripStatusLabelPosition
            // 
            this.ToolStripStatusLabelPosition.Name = "ToolStripStatusLabelPosition";
            this.ToolStripStatusLabelPosition.Size = new System.Drawing.Size(156, 17);
            this.ToolStripStatusLabelPosition.Text = "ToolStripStatusLabelPosition";
            // 
            // SpreadBase
            // 
            this.SpreadBase.AccessibleDescription = "SpreadBase, 配車表, Row 0, Column 0";
            this.SpreadBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpreadBase.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SpreadBase.Location = new System.Drawing.Point(3, 87);
            this.SpreadBase.Name = "SpreadBase";
            this.SpreadBase.Size = new System.Drawing.Size(1898, 927);
            this.SpreadBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMenu,
            this.ToolStripMenuItemTest,
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
            this.ToolStripMenuItemExit});
            this.ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            this.ToolStripMenuItemMenu.Size = new System.Drawing.Size(52, 20);
            this.ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            // 
            // ToolStripMenuItemTest
            // 
            this.ToolStripMenuItemTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemTest1,
            this.ToolStripMenuItemTest2,
            this.ToolStripMenuItemTest3,
            this.ToolStripMenuItemTest4,
            this.ToolStripMenuItemTest5});
            this.ToolStripMenuItemTest.Name = "ToolStripMenuItemTest";
            this.ToolStripMenuItemTest.Size = new System.Drawing.Size(45, 20);
            this.ToolStripMenuItemTest.Text = "テスト";
            // 
            // ToolStripMenuItemTest1
            // 
            this.ToolStripMenuItemTest1.Name = "ToolStripMenuItemTest1";
            this.ToolStripMenuItemTest1.Size = new System.Drawing.Size(193, 22);
            this.ToolStripMenuItemTest1.Text = "運賃項目を挿入する";
            this.ToolStripMenuItemTest1.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemTest2
            // 
            this.ToolStripMenuItemTest2.Name = "ToolStripMenuItemTest2";
            this.ToolStripMenuItemTest2.Size = new System.Drawing.Size(193, 22);
            this.ToolStripMenuItemTest2.Text = "１名のレコードを挿入する";
            this.ToolStripMenuItemTest2.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemTest3
            // 
            this.ToolStripMenuItemTest3.Name = "ToolStripMenuItemTest3";
            this.ToolStripMenuItemTest3.Size = new System.Drawing.Size(193, 22);
            this.ToolStripMenuItemTest3.Text = "２名のレコードを挿入する";
            this.ToolStripMenuItemTest3.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemTest4
            // 
            this.ToolStripMenuItemTest4.Name = "ToolStripMenuItemTest4";
            this.ToolStripMenuItemTest4.Size = new System.Drawing.Size(193, 22);
            this.ToolStripMenuItemTest4.Text = "３名のレコードを挿入する";
            this.ToolStripMenuItemTest4.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemTest5
            // 
            this.ToolStripMenuItemTest5.Name = "ToolStripMenuItemTest5";
            this.ToolStripMenuItemTest5.Size = new System.Drawing.Size(193, 22);
            this.ToolStripMenuItemTest5.Text = "４名のレコードを挿入する";
            this.ToolStripMenuItemTest5.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // PanelUp
            // 
            this.PanelUp.Controls.Add(this.UcDateTimeJpOperationDate);
            this.PanelUp.Controls.Add(this.label1);
            this.PanelUp.Controls.Add(this.ButtonUpdate);
            this.PanelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelUp.Location = new System.Drawing.Point(3, 27);
            this.PanelUp.Name = "PanelUp";
            this.PanelUp.Size = new System.Drawing.Size(1898, 54);
            this.PanelUp.TabIndex = 3;
            // 
            // UcDateTimeJpOperationDate
            // 
            this.UcDateTimeJpOperationDate.Location = new System.Drawing.Point(96, 16);
            this.UcDateTimeJpOperationDate.Name = "UcDateTimeJpOperationDate";
            this.UcDateTimeJpOperationDate.Size = new System.Drawing.Size(183, 23);
            this.UcDateTimeJpOperationDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "配車日付";
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(1672, 8);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(180, 36);
            this.ButtonUpdate.TabIndex = 1;
            this.ButtonUpdate.Text = "最 新 化";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // VehicleDispatchSheetBoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TableLayoutPanelExBase);
            this.MainMenuStrip = this.MenuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "VehicleDispatchSheetBoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VehicleDispatchSheetBoad";
            this.TableLayoutPanelExBase.ResumeLayout(false);
            this.TableLayoutPanelExBase.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadBase)).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.PanelUp.ResumeLayout(false);
            this.PanelUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlEx.TableLayoutPanelEx TableLayoutPanelExBase;
        private FarPoint.Win.Spread.FpSpread SpreadBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelStatus;
        private Panel PanelUp;
        private Button ButtonUpdate;
        private ToolStripMenuItem ToolStripMenuItemTest;
        private ToolStripMenuItem ToolStripMenuItemTest1;
        private ToolStripMenuItem ToolStripMenuItemTest2;
        private ToolStripMenuItem ToolStripMenuItemTest3;
        private ToolStripMenuItem ToolStripMenuItemTest4;
        private ToolStripMenuItem ToolStripMenuItemTest5;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel ToolStripStatusLabelPosition;
        private ControlEx.UcDateTimeJp UcDateTimeJpOperationDate;
        private Label label1;
        private FarPoint.Win.Spread.SheetView SheetView1;
    }
}