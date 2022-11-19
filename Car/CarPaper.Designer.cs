namespace CarRegister {
    partial class CarPaper {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarPaper));
            this.TableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelDetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.ButtonPrint = new System.Windows.Forms.Button();
            this.SpreadCar = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"));
            this.SheetViewCar = this.SpreadCar.GetSheet(0);
            this.PanelRight = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TableLayoutPanelBase.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadCar)).BeginInit();
            this.PanelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            this.TableLayoutPanelBase.ColumnCount = 2;
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.7437F));
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.2563F));
            this.TableLayoutPanelBase.Controls.Add(this.MenuStrip1, 0, 0);
            this.TableLayoutPanelBase.Controls.Add(this.StatusStrip1, 0, 3);
            this.TableLayoutPanelBase.Controls.Add(this.PanelTop, 0, 1);
            this.TableLayoutPanelBase.Controls.Add(this.SpreadCar);
            this.TableLayoutPanelBase.Controls.Add(this.PanelRight, 1, 2);
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
            // MenuStrip1
            // 
            this.TableLayoutPanelBase.SetColumnSpan(this.MenuStrip1, 2);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMenu,
            this.ToolStripMenuItemEdit,
            this.ToolStripMenuItemHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.MenuStrip1.TabIndex = 0;
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
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(43, 20);
            this.ToolStripMenuItemEdit.Text = "編集";
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            this.TableLayoutPanelBase.SetColumnSpan(this.StatusStrip1, 2);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStatusLabelDetail});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 1019);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1904, 22);
            this.StatusStrip1.TabIndex = 1;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelDetail
            // 
            this.ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            this.ToolStripStatusLabelDetail.Size = new System.Drawing.Size(118, 17);
            this.ToolStripStatusLabelDetail.Text = "toolStripStatusLabel2";
            // 
            // PanelTop
            // 
            this.TableLayoutPanelBase.SetColumnSpan(this.PanelTop, 2);
            this.PanelTop.Controls.Add(this.ButtonPrint);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTop.Location = new System.Drawing.Point(0, 24);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1904, 60);
            this.PanelTop.TabIndex = 2;
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPrint.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonPrint.Location = new System.Drawing.Point(1668, 12);
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.Size = new System.Drawing.Size(180, 36);
            this.ButtonPrint.TabIndex = 5;
            this.ButtonPrint.Text = "両 面 印 刷 す る";
            this.ButtonPrint.UseVisualStyleBackColor = true;
            this.ButtonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // SpreadCar
            // 
            this.SpreadCar.AccessibleDescription = "FpSpreadCarLedger, Sheet1, Row 0, Column 0";
            this.SpreadCar.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SpreadCar.Location = new System.Drawing.Point(3, 87);
            this.SpreadCar.Name = "SpreadCar";
            this.SpreadCar.Size = new System.Drawing.Size(1360, 925);
            this.SpreadCar.TabIndex = 3;
            this.SpreadCar.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.FpSpreadCarLedger_CellClick);
            this.SpreadCar.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.FpSpreadCarLedger_CellClick);
            // 
            // PanelRight
            // 
            this.PanelRight.Controls.Add(this.PictureBox1);
            this.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRight.Location = new System.Drawing.Point(1369, 87);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(532, 927);
            this.PanelRight.TabIndex = 4;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(532, 368);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // CarPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TableLayoutPanelBase);
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "CarPaper";
            this.Text = "CarPaper";
            this.TableLayoutPanelBase.ResumeLayout(false);
            this.TableLayoutPanelBase.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpreadCar)).EndInit();
            this.PanelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private Panel PanelTop;
        private FarPoint.Win.Spread.FpSpread SpreadCar;
        private Panel PanelRight;
        private PictureBox PictureBox1;
        private Button ButtonPrint;
        private FarPoint.Win.Spread.SheetView SheetViewCarLedger;
        private FarPoint.Win.Spread.SheetView SheetViewCar;
    }
}