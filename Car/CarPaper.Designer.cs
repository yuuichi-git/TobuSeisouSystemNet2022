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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarPaper));
            TableLayoutPanelBase = new TableLayoutPanel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemEdit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            PanelTop = new Panel();
            ButtonPrint = new Button();
            SpreadCar = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelBase.Controls"));
            SheetViewCar = SpreadCar.GetSheet(0);
            PanelRight = new Panel();
            PictureBox1 = new PictureBox();
            TableLayoutPanelBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadCar).BeginInit();
            PanelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 2;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.7437F));
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.2563F));
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelTop, 0, 1);
            TableLayoutPanelBase.Controls.Add(SpreadCar);
            TableLayoutPanelBase.Controls.Add(PanelRight, 1, 2);
            TableLayoutPanelBase.Dock = DockStyle.Fill;
            TableLayoutPanelBase.Location = new Point(0, 0);
            TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            TableLayoutPanelBase.RowCount = 4;
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelBase.Size = new Size(1904, 1041);
            TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            TableLayoutPanelBase.SetColumnSpan(MenuStrip1, 2);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemEdit, ToolStripMenuItemHelp });
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
            // ToolStripMenuItemEdit
            // 
            ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            ToolStripMenuItemEdit.Size = new Size(43, 20);
            ToolStripMenuItemEdit.Text = "編集";
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            TableLayoutPanelBase.SetColumnSpan(StatusStrip1, 2);
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
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
            // ToolStripStatusLabelDetail
            // 
            ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            ToolStripStatusLabelDetail.Size = new Size(118, 17);
            ToolStripStatusLabelDetail.Text = "toolStripStatusLabel2";
            // 
            // PanelTop
            // 
            TableLayoutPanelBase.SetColumnSpan(PanelTop, 2);
            PanelTop.Controls.Add(ButtonPrint);
            PanelTop.Dock = DockStyle.Fill;
            PanelTop.Location = new Point(0, 24);
            PanelTop.Margin = new Padding(0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1904, 60);
            PanelTop.TabIndex = 2;
            // 
            // ButtonPrint
            // 
            ButtonPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonPrint.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPrint.Location = new Point(1668, 12);
            ButtonPrint.Name = "ButtonPrint";
            ButtonPrint.Size = new Size(180, 36);
            ButtonPrint.TabIndex = 5;
            ButtonPrint.Text = "両 面 印 刷 す る";
            ButtonPrint.UseVisualStyleBackColor = true;
            ButtonPrint.Click += ButtonPrint_Click;
            // 
            // SpreadCar
            // 
            SpreadCar.AccessibleDescription = "FpSpreadCarLedger, Sheet1, Row 0, Column 0";
            SpreadCar.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadCar.Location = new Point(3, 87);
            SpreadCar.Name = "SpreadCar";
            SpreadCar.Size = new Size(1360, 925);
            SpreadCar.TabIndex = 3;
            SpreadCar.CellClick += FpSpreadCarLedger_CellClick;
            SpreadCar.CellDoubleClick += FpSpreadCarLedger_CellClick;
            // 
            // PanelRight
            // 
            PanelRight.Controls.Add(PictureBox1);
            PanelRight.Dock = DockStyle.Fill;
            PanelRight.Location = new Point(1369, 87);
            PanelRight.Name = "PanelRight";
            PanelRight.Size = new Size(532, 927);
            PanelRight.TabIndex = 4;
            // 
            // PictureBox1
            // 
            PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            PictureBox1.Location = new Point(0, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(532, 368);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // CarPaper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TableLayoutPanelBase);
            MainMenuStrip = MenuStrip1;
            Name = "CarPaper";
            Text = "CarPaper";
            FormClosing += CarPaper_FormClosing;
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpreadCar).EndInit();
            PanelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
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
        //private FarPoint.Win.Spread.SheetView SheetViewCarLedger;
        private FarPoint.Win.Spread.SheetView SheetViewCar;
    }
}