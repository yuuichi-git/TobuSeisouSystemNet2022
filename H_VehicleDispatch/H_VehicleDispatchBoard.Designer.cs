namespace H_VehicleDispatch {
    partial class H_VehicleDispatchBoard {
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
            h_TableLayoutPanelExBase = new H_ControlEx.H_TableLayoutPanelEx();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItemMenu = new ToolStripMenuItem();
            ToolStripMenuItemInitialize = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            h_PanelExTop = new H_ControlEx.H_PanelEx();
            h_DateTimePickerOperationDate = new H_ControlEx.H_DateTimePickerEx();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            h_TableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            h_PanelExTop.SuspendLayout();
            SuspendLayout();
            // 
            // h_TableLayoutPanelExBase
            // 
            h_TableLayoutPanelExBase.ColumnCount = 3;
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 218F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 203F));
            h_TableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            h_TableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 4);
            h_TableLayoutPanelExBase.Controls.Add(h_PanelExTop, 0, 1);
            h_TableLayoutPanelExBase.Dock = DockStyle.Fill;
            h_TableLayoutPanelExBase.Location = new Point(0, 0);
            h_TableLayoutPanelExBase.Name = "h_TableLayoutPanelExBase";
            h_TableLayoutPanelExBase.RowCount = 5;
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.Size = new Size(1459, 742);
            h_TableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            h_TableLayoutPanelExBase.SetColumnSpan(MenuStrip1, 3);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemInitialize, ToolStripMenuItemHelp });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(1459, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            ToolStripMenuItemMenu.Size = new Size(52, 20);
            ToolStripMenuItemMenu.Text = "メニュー";
            // 
            // ToolStripMenuItemInitialize
            // 
            ToolStripMenuItemInitialize.Name = "ToolStripMenuItemInitialize";
            ToolStripMenuItemInitialize.Size = new Size(55, 20);
            ToolStripMenuItemInitialize.Text = "初期化";
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            h_TableLayoutPanelExBase.SetColumnSpan(StatusStrip1, 3);
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            StatusStrip1.Location = new Point(0, 720);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1459, 22);
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Status";
            // 
            // h_PanelExTop
            // 
            h_TableLayoutPanelExBase.SetColumnSpan(h_PanelExTop, 3);
            h_PanelExTop.Controls.Add(h_LabelEx1);
            h_PanelExTop.Controls.Add(h_DateTimePickerOperationDate);
            h_PanelExTop.Dock = DockStyle.Fill;
            h_PanelExTop.Location = new Point(1, 25);
            h_PanelExTop.Margin = new Padding(1);
            h_PanelExTop.Name = "h_PanelExTop";
            h_PanelExTop.Size = new Size(1457, 28);
            h_PanelExTop.TabIndex = 2;
            // 
            // h_DateTimePickerOperationDate
            // 
            h_DateTimePickerOperationDate.CustomFormat = " yyyy年MM月dd日(dddd)";
            h_DateTimePickerOperationDate.Format = DateTimePickerFormat.Custom;
            h_DateTimePickerOperationDate.Location = new Point(72, 2);
            h_DateTimePickerOperationDate.Name = "h_DateTimePickerOperationDate";
            h_DateTimePickerOperationDate.Size = new Size(180, 23);
            h_DateTimePickerOperationDate.TabIndex = 0;
            h_DateTimePickerOperationDate.Value = new DateTime(2023, 10, 14, 0, 0, 0, 0);
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(0, 0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(200, 100);
            tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(0, 0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(200, 100);
            tabPage2.TabIndex = 0;
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(24, 6);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(43, 15);
            h_LabelEx1.TabIndex = 1;
            h_LabelEx1.Text = "配車日";
            // 
            // H_VehicleDispatchBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 742);
            Controls.Add(h_TableLayoutPanelExBase);
            MainMenuStrip = MenuStrip1;
            Name = "H_VehicleDispatchBoard";
            Text = "H_VehicleDispatchBoard";
            h_TableLayoutPanelExBase.ResumeLayout(false);
            h_TableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            h_PanelExTop.ResumeLayout(false);
            h_PanelExTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private H_ControlEx.H_TableLayoutPanelEx h_TableLayoutPanelExBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem ToolStripMenuItemInitialize;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private H_ControlEx.H_PanelEx h_PanelExTop;
        private H_ControlEx.H_DateTimePickerEx h_DateTimePickerOperationDate;
        private H_ControlEx.H_LabelEx h_LabelEx1;
    }
}