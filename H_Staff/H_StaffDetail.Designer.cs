namespace H_Staff {
    partial class HStaffDetail {
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
            HTableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            HPanelExUp = new H_ControlEx.H_PanelEx();
            ButtonUpdate = new Button();
            HTableLayoutPanelExMiddle = new H_ControlEx.H_TableLayoutPanelEx();
            HPanelExMiddleLeft = new H_ControlEx.H_PanelEx();
            HPanelExMiddleRight = new H_ControlEx.H_PanelEx();
            HTableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            HPanelExUp.SuspendLayout();
            HTableLayoutPanelExMiddle.SuspendLayout();
            SuspendLayout();
            // 
            // HTableLayoutPanelExBase
            // 
            HTableLayoutPanelExBase.ColumnCount = 1;
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            HTableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 3);
            HTableLayoutPanelExBase.Controls.Add(HPanelExUp, 0, 1);
            HTableLayoutPanelExBase.Controls.Add(HTableLayoutPanelExMiddle, 0, 2);
            HTableLayoutPanelExBase.Dock = DockStyle.Fill;
            HTableLayoutPanelExBase.Location = new Point(0, 0);
            HTableLayoutPanelExBase.Name = "HTableLayoutPanelExBase";
            HTableLayoutPanelExBase.RowCount = 4;
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            HTableLayoutPanelExBase.Size = new Size(1904, 1041);
            HTableLayoutPanelExBase.TabIndex = 0;
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
            ToolStripStatusLabelDetail.Size = new Size(142, 17);
            ToolStripStatusLabelDetail.Text = "toolStripStatusLabelDetail";
            // 
            // HPanelExUp
            // 
            HPanelExUp.Controls.Add(ButtonUpdate);
            HPanelExUp.Dock = DockStyle.Fill;
            HPanelExUp.Location = new Point(3, 27);
            HPanelExUp.Name = "HPanelExUp";
            HPanelExUp.Size = new Size(1898, 54);
            HPanelExUp.TabIndex = 2;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonUpdate.Location = new Point(1680, 8);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(180, 36);
            ButtonUpdate.TabIndex = 10;
            ButtonUpdate.Text = "最 新 化";
            ButtonUpdate.UseVisualStyleBackColor = true;
            // 
            // HTableLayoutPanelExMiddle
            // 
            HTableLayoutPanelExMiddle.ColumnCount = 2;
            HTableLayoutPanelExMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HTableLayoutPanelExMiddle.Controls.Add(HPanelExMiddleLeft, 0, 0);
            HTableLayoutPanelExMiddle.Controls.Add(HPanelExMiddleRight, 1, 0);
            HTableLayoutPanelExMiddle.Dock = DockStyle.Fill;
            HTableLayoutPanelExMiddle.Location = new Point(3, 87);
            HTableLayoutPanelExMiddle.Name = "HTableLayoutPanelExMiddle";
            HTableLayoutPanelExMiddle.RowCount = 1;
            HTableLayoutPanelExMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExMiddle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExMiddle.Size = new Size(1898, 927);
            HTableLayoutPanelExMiddle.TabIndex = 3;
            // 
            // HPanelExMiddleLeft
            // 
            HPanelExMiddleLeft.Dock = DockStyle.Fill;
            HPanelExMiddleLeft.Location = new Point(3, 3);
            HPanelExMiddleLeft.Name = "HPanelExMiddleLeft";
            HPanelExMiddleLeft.Size = new Size(943, 921);
            HPanelExMiddleLeft.TabIndex = 0;
            // 
            // HPanelExMiddleRight
            // 
            HPanelExMiddleRight.Dock = DockStyle.Fill;
            HPanelExMiddleRight.Location = new Point(952, 3);
            HPanelExMiddleRight.Name = "HPanelExMiddleRight";
            HPanelExMiddleRight.Size = new Size(943, 921);
            HPanelExMiddleRight.TabIndex = 1;
            // 
            // HStaffDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(HTableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            MinimumSize = new Size(1918, 1046);
            Name = "HStaffDetail";
            Text = "H_StaffDetail";
            HTableLayoutPanelExBase.ResumeLayout(false);
            HTableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            HPanelExUp.ResumeLayout(false);
            HTableLayoutPanelExMiddle.ResumeLayout(false);
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
        private Button ButtonUpdate;
        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExMiddle;
        private H_ControlEx.H_PanelEx HPanelExMiddleLeft;
        private H_ControlEx.H_PanelEx HPanelExMiddleRight;
    }
}