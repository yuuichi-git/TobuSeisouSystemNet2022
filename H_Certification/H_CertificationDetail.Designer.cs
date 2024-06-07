namespace H_Certification {
    partial class H_CertificationDetail {
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
            components = new System.ComponentModel.Container();
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HTableLayoutPanelExCenter = new H_ControlEx.H_TableLayoutPanelEx();
            HPictureBoxEx1 = new H_ControlEx.H_PictureBoxEx();
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ToolStripMenuItemClip = new ToolStripMenuItem();
            ToolStripMenuItemDelete = new ToolStripMenuItem();
            HPictureBoxEx2 = new H_ControlEx.H_PictureBoxEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            HTableLayoutPanelExBase.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HTableLayoutPanelExCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxEx1).BeginInit();
            ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HPictureBoxEx2).BeginInit();
            MenuStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(HTableLayoutPanelExCenter, 0, 2);
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(984, 761);
            HTableLayoutPanelExBase.TabIndex = 0;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripStatusLabelDetail });
            StatusStrip1.Location = new Point(0, 739);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(984, 22);
            StatusStrip1.TabIndex = 2;
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
            // HTableLayoutPanelExCenter
            // 
            HTableLayoutPanelExCenter.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            HTableLayoutPanelExCenter.ColumnCount = 2;
            HTableLayoutPanelExCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExCenter.Controls.Add(HPictureBoxEx1, 0, 0);
            HTableLayoutPanelExCenter.Controls.Add(HPictureBoxEx2, 1, 0);
            HTableLayoutPanelExCenter.Dock = DockStyle.Fill;
            HTableLayoutPanelExCenter.Location = new Point(3, 87);
            HTableLayoutPanelExCenter.Name = "HTableLayoutPanelExCenter";
            HTableLayoutPanelExCenter.RowCount = 1;
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExCenter.Size = new Size(978, 647);
            HTableLayoutPanelExCenter.TabIndex = 0;
            // 
            // HPictureBoxEx1
            // 
            HPictureBoxEx1.ContextMenuStrip = ContextMenuStrip1;
            HPictureBoxEx1.Dock = DockStyle.Fill;
            HPictureBoxEx1.Location = new Point(6, 6);
            HPictureBoxEx1.Name = "HPictureBoxEx1";
            HPictureBoxEx1.Size = new Size(478, 635);
            HPictureBoxEx1.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxEx1.TabIndex = 0;
            HPictureBoxEx1.TabStop = false;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemClip, ToolStripMenuItemDelete });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size(108, 48);
            ContextMenuStrip1.Opened += ContextMenuStrip1_Opened;
            // 
            // ToolStripMenuItemClip
            // 
            ToolStripMenuItemClip.Name = "ToolStripMenuItemClip";
            ToolStripMenuItemClip.Size = new Size(107, 22);
            ToolStripMenuItemClip.Text = "Clip";
            ToolStripMenuItemClip.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemDelete
            // 
            ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            ToolStripMenuItemDelete.Size = new Size(107, 22);
            ToolStripMenuItemDelete.Text = "Delete";
            ToolStripMenuItemDelete.Click += ToolStripMenuItem_Click;
            // 
            // HPictureBoxEx2
            // 
            HPictureBoxEx2.ContextMenuStrip = ContextMenuStrip1;
            HPictureBoxEx2.Dock = DockStyle.Fill;
            HPictureBoxEx2.Location = new Point(493, 6);
            HPictureBoxEx2.Name = "HPictureBoxEx2";
            HPictureBoxEx2.Size = new Size(479, 635);
            HPictureBoxEx2.SizeMode = PictureBoxSizeMode.Zoom;
            HPictureBoxEx2.TabIndex = 1;
            HPictureBoxEx2.TabStop = false;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(984, 24);
            MenuStrip1.TabIndex = 1;
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
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // HPanelExUp
            // 
            HPanelExUp.Controls.Add(HButtonExUpdate);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(978, 54);
            HPanelExUp.TabIndex = 3;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HButtonExUpdate.Location = new Point(796, 10);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(140, 32);
            HButtonExUpdate.TabIndex = 0;
            HButtonExUpdate.Text = "UPDATE";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonExUpdate_Click;
            // 
            // H_CertificationDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            Name = "H_CertificationDetail";
            Text = "H_CertificationDetail";
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HTableLayoutPanelExCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HPictureBoxEx1).EndInit();
            ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HPictureBoxEx2).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExBase;
        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExCenter;
        private StatusStrip StatusStrip1;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private H_ControlEx.H_PanelEx HPanelExUp;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private H_ControlEx.H_PictureBoxEx HPictureBoxEx1;
        private ContextMenuStrip ContextMenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemClip;
        private ToolStripMenuItem ToolStripMenuItemDelete;
        private H_ControlEx.H_PictureBoxEx HPictureBoxEx2;
        private ToolStripMenuItem ToolStripMenuItemExit;
    }
}