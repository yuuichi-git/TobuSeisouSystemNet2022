﻿namespace Yazaki {
    partial class YazakiMaster {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YazakiMaster));
            TableLayoutPanelBase = new TableLayoutPanel();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusDetail = new ToolStripStatusLabel();
            PanelTop = new Panel();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"));
            SheetViewList = SpreadList.GetSheet(0);
            TableLayoutPanelBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            TableLayoutPanelBase.ColumnCount = 1;
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelBase.Controls.Add(MenuStrip1, 0, 0);
            TableLayoutPanelBase.Controls.Add(StatusStrip1, 0, 3);
            TableLayoutPanelBase.Controls.Add(PanelTop, 0, 1);
            TableLayoutPanelBase.Controls.Add(SpreadList, 0, 2);
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
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1904, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
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
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusDetail });
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
            // ToolStripStatusDetail
            // 
            ToolStripStatusDetail.Name = "ToolStripStatusDetail";
            ToolStripStatusDetail.Size = new Size(118, 17);
            ToolStripStatusDetail.Text = "toolStripStatusLabel2";
            // 
            // PanelTop
            // 
            PanelTop.Dock = DockStyle.Fill;
            PanelTop.Location = new Point(3, 27);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1898, 54);
            PanelTop.TabIndex = 2;
            // 
            // SpreadList
            // 
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(1898, 927);
            SpreadList.TabIndex = 3;
            // 
            // YazakiMaster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TableLayoutPanelBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "YazakiMaster";
            Text = "YazakiMaster";
            TableLayoutPanelBase.ResumeLayout(false);
            TableLayoutPanelBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusDetail;
        private Panel PanelTop;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private FarPoint.Win.Spread.SheetView SheetViewList;
    }
}