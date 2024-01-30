namespace StockBox {
    partial class H_StockBoxs {
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
            h_TableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemChange = new ToolStripMenuItem();
            ToolStripMenuItemSet = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItemCar = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItemEmployee = new ToolStripMenuItem();
            ToolStripMenuItemPartTime = new ToolStripMenuItem();
            ToolStripMenuItemLongTerm = new ToolStripMenuItem();
            ToolStripMenuItemShortTerm = new ToolStripMenuItem();
            ToolStripMenuItemDispatch = new ToolStripMenuItem();
            ToolStripMenuItemSort = new ToolStripMenuItem();
            ToolStripMenuItemSortAsc = new ToolStripMenuItem();
            ToolStripMenuItemSortDesk = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            h_TableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // h_TableLayoutPanelExBase
            // 
            h_TableLayoutPanelExBase.BackColor = SystemColors.Control;
            h_TableLayoutPanelExBase.ColumnCount = 1;
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            h_TableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            h_TableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 2);
            h_TableLayoutPanelExBase.Dock = DockStyle.Fill;
            h_TableLayoutPanelExBase.Location = new Point(0, 0);
            h_TableLayoutPanelExBase.Name = "h_TableLayoutPanelExBase";
            h_TableLayoutPanelExBase.RowCount = 3;
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.Size = new Size(516, 691);
            h_TableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemChange, ToolStripMenuItemSort, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(516, 24);
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
            ToolStripMenuItemExit.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemChange
            // 
            ToolStripMenuItemChange.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemSet, toolStripSeparator1, ToolStripMenuItemCar, toolStripSeparator2, ToolStripMenuItemEmployee, ToolStripMenuItemPartTime, ToolStripMenuItemLongTerm, ToolStripMenuItemShortTerm, ToolStripMenuItemDispatch });
            ToolStripMenuItemChange.Name = "ToolStripMenuItemChange";
            ToolStripMenuItemChange.Size = new Size(60, 20);
            ToolStripMenuItemChange.Text = "切り替え";
            // 
            // ToolStripMenuItemSet
            // 
            ToolStripMenuItemSet.Name = "ToolStripMenuItemSet";
            ToolStripMenuItemSet.Size = new Size(194, 22);
            ToolStripMenuItemSet.Text = "配車先";
            ToolStripMenuItemSet.Click += ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(191, 6);
            // 
            // ToolStripMenuItemCar
            // 
            ToolStripMenuItemCar.Name = "ToolStripMenuItemCar";
            ToolStripMenuItemCar.Size = new Size(194, 22);
            ToolStripMenuItemCar.Text = "車両";
            ToolStripMenuItemCar.Click += ToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(191, 6);
            // 
            // ToolStripMenuItemEmployee
            // 
            ToolStripMenuItemEmployee.Name = "ToolStripMenuItemEmployee";
            ToolStripMenuItemEmployee.Size = new Size(194, 22);
            ToolStripMenuItemEmployee.Text = "事務職(社員・アルバイト)";
            ToolStripMenuItemEmployee.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemPartTime
            // 
            ToolStripMenuItemPartTime.Name = "ToolStripMenuItemPartTime";
            ToolStripMenuItemPartTime.Size = new Size(194, 22);
            ToolStripMenuItemPartTime.Text = "アルバイト";
            ToolStripMenuItemPartTime.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemLongTerm
            // 
            ToolStripMenuItemLongTerm.Name = "ToolStripMenuItemLongTerm";
            ToolStripMenuItemLongTerm.Size = new Size(194, 22);
            ToolStripMenuItemLongTerm.Text = "長期";
            ToolStripMenuItemLongTerm.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemShortTerm
            // 
            ToolStripMenuItemShortTerm.Name = "ToolStripMenuItemShortTerm";
            ToolStripMenuItemShortTerm.Size = new Size(194, 22);
            ToolStripMenuItemShortTerm.Text = "短期";
            ToolStripMenuItemShortTerm.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemDispatch
            // 
            ToolStripMenuItemDispatch.Name = "ToolStripMenuItemDispatch";
            ToolStripMenuItemDispatch.Size = new Size(194, 22);
            ToolStripMenuItemDispatch.Text = "派遣";
            ToolStripMenuItemDispatch.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemSort
            // 
            ToolStripMenuItemSort.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemSortAsc, ToolStripMenuItemSortDesk });
            ToolStripMenuItemSort.Name = "ToolStripMenuItemSort";
            ToolStripMenuItemSort.Size = new Size(44, 20);
            ToolStripMenuItemSort.Text = "ソート";
            // 
            // ToolStripMenuItemSortAsc
            // 
            ToolStripMenuItemSortAsc.Name = "ToolStripMenuItemSortAsc";
            ToolStripMenuItemSortAsc.Size = new Size(98, 22);
            ToolStripMenuItemSortAsc.Text = "昇順";
            // 
            // ToolStripMenuItemSortDesk
            // 
            ToolStripMenuItemSortDesk.Name = "ToolStripMenuItemSortDesk";
            ToolStripMenuItemSortDesk.Size = new Size(98, 22);
            ToolStripMenuItemSortDesk.Text = "降順";
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 669);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(516, 22);
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(39, 17);
            ToolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelDetail
            // 
            ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            ToolStripStatusLabelDetail.Size = new Size(143, 17);
            ToolStripStatusLabelDetail.Text = "ToolStripStatusLabelDetail";
            // 
            // H_StockBoxs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(516, 691);
            Controls.Add(h_TableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "H_StockBoxs";
            ShowIcon = false;
            Text = "StockBoxs";
            FormClosing += SetStockBox_FormClosing;
            h_TableLayoutPanelExBase.ResumeLayout(false);
            h_TableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx h_TableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel ToolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private ToolStripMenuItem ToolStripMenuItemSort;
        private ToolStripMenuItem ToolStripMenuItemChange;
        private ToolStripMenuItem ToolStripMenuItemSet;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItemCar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ToolStripMenuItemEmployee;
        private ToolStripMenuItem ToolStripMenuItemPartTime;
        private ToolStripMenuItem ToolStripMenuItemLongTerm;
        private ToolStripMenuItem ToolStripMenuItemShortTerm;
        private ToolStripMenuItem ToolStripMenuItemDispatch;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemSortAsc;
        private ToolStripMenuItem ToolStripMenuItemSortDesk;
    }
}
