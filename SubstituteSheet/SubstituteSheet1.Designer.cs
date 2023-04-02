namespace SubstituteSheet {
    partial class SubstituteSheet1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubstituteSheet1));
            TableLayoutPanelEx1 = new ControlEx.TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            PanelTop = new Panel();
            ButtonPrint = new Button();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelEx1.Controls"));
            SheetView1 = SpreadList.GetSheet(0);
            TableLayoutPanelEx1.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelEx1
            // 
            TableLayoutPanelEx1.ButtonBorderStyleDotted = false;
            TableLayoutPanelEx1.ColumnCount = 1;
            TableLayoutPanelEx1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelEx1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelEx1.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelEx1.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelEx1.Controls.Add(PanelTop, 0, 1);
            TableLayoutPanelEx1.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelEx1.Dock = DockStyle.Fill;
            TableLayoutPanelEx1.Location = new Point(0, 0);
            TableLayoutPanelEx1.Name = "TableLayoutPanelEx1";
            TableLayoutPanelEx1.RowCount = 4;
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelEx1.Size = new Size(821, 1041);
            TableLayoutPanelEx1.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(821, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrint, ToolStripMenuItemExit });
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(195, 22);
            ToolStripMenuItemPrint.Text = "代番連絡票を印刷する";
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(195, 22);
            ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2 });
            StatusStrip1.Location = new Point(0, 1019);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(821, 22);
            StatusStrip1.SizingGrip = false;
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(39, 17);
            ToolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabel2
            // 
            ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            ToolStripStatusLabel2.Size = new Size(113, 17);
            ToolStripStatusLabel2.Text = "ToolStripStatusLabel";
            // 
            // PanelTop
            // 
            PanelTop.Controls.Add(ButtonPrint);
            PanelTop.Dock = DockStyle.Fill;
            PanelTop.Location = new Point(3, 27);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(815, 54);
            PanelTop.TabIndex = 2;
            // 
            // ButtonPrint
            // 
            ButtonPrint.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPrint.Location = new Point(600, 8);
            ButtonPrint.Name = "ButtonPrint";
            ButtonPrint.Size = new Size(180, 36);
            ButtonPrint.TabIndex = 1;
            ButtonPrint.Text = "既定のプリンターへ印刷";
            ButtonPrint.UseVisualStyleBackColor = true;
            ButtonPrint.Click += ButtonPrint_Click;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(815, 927);
            SpreadList.TabIndex = 3;
            // 
            // SubstituteSheet1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 1041);
            Controls.Add(TableLayoutPanelEx1);
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SubstituteSheet1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SubstituteSheet1";
            TableLayoutPanelEx1.ResumeLayout(false);
            TableLayoutPanelEx1.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ControlEx.TableLayoutPanelEx TableLayoutPanelEx1;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel ToolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabel2;
        private Panel PanelTop;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private Button ButtonPrint;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private FarPoint.Win.Spread.SheetView SheetView1;
    }
}