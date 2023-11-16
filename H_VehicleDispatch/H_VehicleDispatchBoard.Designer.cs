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
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemInitialize = new ToolStripMenuItem();
            ToolStripMenuItemInitializeVehicleDispatch = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemPrintB4 = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            h_PanelExLeft = new H_ControlEx.H_PanelEx();
            h_ButtonExLeft5 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft4 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft3 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft2 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft1 = new H_ControlEx.H_ButtonEx();
            h_PanelExRight = new H_ControlEx.H_PanelEx();
            h_ButtonExRight5 = new H_ControlEx.H_ButtonEx();
            h_ButtonExRight4 = new H_ControlEx.H_ButtonEx();
            h_ButtonExRight3 = new H_ControlEx.H_ButtonEx();
            h_ButtonExRight2 = new H_ControlEx.H_ButtonEx();
            h_ButtonExRight1 = new H_ControlEx.H_ButtonEx();
            h_PanelExCenter = new H_ControlEx.H_PanelEx();
            h_TableLayoutPanelExCenter = new H_ControlEx.H_TableLayoutPanelEx();
            h_PanelExCenterTop = new H_ControlEx.H_PanelEx();
            h_ButtonExUpdate = new H_ControlEx.H_ButtonEx();
            H_DateTimePickerOperationDate = new H_ControlEx.H_DateTimePickerEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            h_TableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            h_PanelExLeft.SuspendLayout();
            h_PanelExRight.SuspendLayout();
            h_PanelExCenter.SuspendLayout();
            h_TableLayoutPanelExCenter.SuspendLayout();
            h_PanelExCenterTop.SuspendLayout();
            SuspendLayout();
            // 
            // h_TableLayoutPanelExBase
            // 
            h_TableLayoutPanelExBase.ColumnCount = 3;
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            h_TableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            h_TableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 2);
            h_TableLayoutPanelExBase.Controls.Add(h_PanelExLeft, 0, 1);
            h_TableLayoutPanelExBase.Controls.Add(h_PanelExRight, 2, 1);
            h_TableLayoutPanelExBase.Controls.Add(h_PanelExCenter, 1, 1);
            h_TableLayoutPanelExBase.Dock = DockStyle.Fill;
            h_TableLayoutPanelExBase.Location = new Point(0, 0);
            h_TableLayoutPanelExBase.Name = "h_TableLayoutPanelExBase";
            h_TableLayoutPanelExBase.RowCount = 3;
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            h_TableLayoutPanelExBase.Size = new Size(1904, 1041);
            h_TableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            h_TableLayoutPanelExBase.SetColumnSpan(MenuStrip1, 3);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemInitialize, ToolStripMenuItemPrint, ToolStripMenuItemHelp });
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
            // 
            // ToolStripMenuItemInitialize
            // 
            ToolStripMenuItemInitialize.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemInitializeVehicleDispatch });
            ToolStripMenuItemInitialize.Name = "ToolStripMenuItemInitialize";
            ToolStripMenuItemInitialize.Size = new Size(55, 20);
            ToolStripMenuItemInitialize.Text = "初期化";
            // 
            // ToolStripMenuItemInitializeVehicleDispatch
            // 
            ToolStripMenuItemInitializeVehicleDispatch.Name = "ToolStripMenuItemInitializeVehicleDispatch";
            ToolStripMenuItemInitializeVehicleDispatch.Size = new Size(180, 22);
            ToolStripMenuItemInitializeVehicleDispatch.Text = "配車を初期化する";
            ToolStripMenuItemInitializeVehicleDispatch.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrintB4 });
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(43, 20);
            ToolStripMenuItemPrint.Text = "印刷";
            // 
            // ToolStripMenuItemPrintB4
            // 
            ToolStripMenuItemPrintB4.Name = "ToolStripMenuItemPrintB4";
            ToolStripMenuItemPrintB4.Size = new Size(140, 22);
            ToolStripMenuItemPrintB4.Text = "B4で印刷する";
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
            // h_PanelExLeft
            // 
            h_PanelExLeft.Controls.Add(h_ButtonExLeft5);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft4);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft3);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft2);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft1);
            h_PanelExLeft.Dock = DockStyle.Fill;
            h_PanelExLeft.Location = new Point(0, 24);
            h_PanelExLeft.Margin = new Padding(0);
            h_PanelExLeft.Name = "h_PanelExLeft";
            h_PanelExLeft.Size = new Size(34, 993);
            h_PanelExLeft.TabIndex = 7;
            // 
            // h_ButtonExLeft5
            // 
            h_ButtonExLeft5.Location = new Point(2, 436);
            h_ButtonExLeft5.Name = "h_ButtonExLeft5";
            h_ButtonExLeft5.Size = new Size(30, 100);
            h_ButtonExLeft5.TabIndex = 4;
            h_ButtonExLeft5.TabStop = false;
            h_ButtonExLeft5.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExLeft4
            // 
            h_ButtonExLeft4.Location = new Point(2, 336);
            h_ButtonExLeft4.Name = "h_ButtonExLeft4";
            h_ButtonExLeft4.Size = new Size(30, 100);
            h_ButtonExLeft4.TabIndex = 3;
            h_ButtonExLeft4.TabStop = false;
            h_ButtonExLeft4.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExLeft3
            // 
            h_ButtonExLeft3.Location = new Point(2, 236);
            h_ButtonExLeft3.Name = "h_ButtonExLeft3";
            h_ButtonExLeft3.Size = new Size(30, 100);
            h_ButtonExLeft3.TabIndex = 2;
            h_ButtonExLeft3.TabStop = false;
            h_ButtonExLeft3.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExLeft2
            // 
            h_ButtonExLeft2.Location = new Point(2, 136);
            h_ButtonExLeft2.Name = "h_ButtonExLeft2";
            h_ButtonExLeft2.Size = new Size(30, 100);
            h_ButtonExLeft2.TabIndex = 1;
            h_ButtonExLeft2.TabStop = false;
            h_ButtonExLeft2.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExLeft1
            // 
            h_ButtonExLeft1.Location = new Point(2, 36);
            h_ButtonExLeft1.Name = "h_ButtonExLeft1";
            h_ButtonExLeft1.Size = new Size(30, 100);
            h_ButtonExLeft1.TabIndex = 0;
            h_ButtonExLeft1.TabStop = false;
            h_ButtonExLeft1.UseVisualStyleBackColor = true;
            // 
            // h_PanelExRight
            // 
            h_PanelExRight.Controls.Add(h_ButtonExRight5);
            h_PanelExRight.Controls.Add(h_ButtonExRight4);
            h_PanelExRight.Controls.Add(h_ButtonExRight3);
            h_PanelExRight.Controls.Add(h_ButtonExRight2);
            h_PanelExRight.Controls.Add(h_ButtonExRight1);
            h_PanelExRight.Dock = DockStyle.Fill;
            h_PanelExRight.Location = new Point(1870, 24);
            h_PanelExRight.Margin = new Padding(0);
            h_PanelExRight.Name = "h_PanelExRight";
            h_PanelExRight.Size = new Size(34, 993);
            h_PanelExRight.TabIndex = 8;
            // 
            // h_ButtonExRight5
            // 
            h_ButtonExRight5.Location = new Point(2, 434);
            h_ButtonExRight5.Name = "h_ButtonExRight5";
            h_ButtonExRight5.Size = new Size(30, 100);
            h_ButtonExRight5.TabIndex = 9;
            h_ButtonExRight5.TabStop = false;
            h_ButtonExRight5.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExRight4
            // 
            h_ButtonExRight4.Location = new Point(2, 334);
            h_ButtonExRight4.Name = "h_ButtonExRight4";
            h_ButtonExRight4.Size = new Size(30, 100);
            h_ButtonExRight4.TabIndex = 8;
            h_ButtonExRight4.TabStop = false;
            h_ButtonExRight4.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExRight3
            // 
            h_ButtonExRight3.Location = new Point(2, 234);
            h_ButtonExRight3.Name = "h_ButtonExRight3";
            h_ButtonExRight3.Size = new Size(30, 100);
            h_ButtonExRight3.TabIndex = 7;
            h_ButtonExRight3.TabStop = false;
            h_ButtonExRight3.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExRight2
            // 
            h_ButtonExRight2.Location = new Point(2, 134);
            h_ButtonExRight2.Name = "h_ButtonExRight2";
            h_ButtonExRight2.Size = new Size(30, 100);
            h_ButtonExRight2.TabIndex = 6;
            h_ButtonExRight2.TabStop = false;
            h_ButtonExRight2.UseVisualStyleBackColor = true;
            // 
            // h_ButtonExRight1
            // 
            h_ButtonExRight1.Location = new Point(2, 34);
            h_ButtonExRight1.Name = "h_ButtonExRight1";
            h_ButtonExRight1.Size = new Size(30, 100);
            h_ButtonExRight1.TabIndex = 5;
            h_ButtonExRight1.TabStop = false;
            h_ButtonExRight1.UseVisualStyleBackColor = true;
            // 
            // h_PanelExCenter
            // 
            h_PanelExCenter.Controls.Add(h_TableLayoutPanelExCenter);
            h_PanelExCenter.Dock = DockStyle.Fill;
            h_PanelExCenter.Location = new Point(34, 24);
            h_PanelExCenter.Margin = new Padding(0);
            h_PanelExCenter.Name = "h_PanelExCenter";
            h_PanelExCenter.Size = new Size(1836, 993);
            h_PanelExCenter.TabIndex = 9;
            // 
            // h_TableLayoutPanelExCenter
            // 
            h_TableLayoutPanelExCenter.ColumnCount = 1;
            h_TableLayoutPanelExCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExCenter.Controls.Add(h_PanelExCenterTop, 0, 0);
            h_TableLayoutPanelExCenter.Dock = DockStyle.Fill;
            h_TableLayoutPanelExCenter.Location = new Point(0, 0);
            h_TableLayoutPanelExCenter.Margin = new Padding(0);
            h_TableLayoutPanelExCenter.Name = "h_TableLayoutPanelExCenter";
            h_TableLayoutPanelExCenter.RowCount = 2;
            h_TableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            h_TableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExCenter.Size = new Size(1836, 993);
            h_TableLayoutPanelExCenter.TabIndex = 0;
            // 
            // h_PanelExCenterTop
            // 
            h_PanelExCenterTop.Controls.Add(h_ButtonExUpdate);
            h_PanelExCenterTop.Controls.Add(H_DateTimePickerOperationDate);
            h_PanelExCenterTop.Controls.Add(h_LabelEx1);
            h_PanelExCenterTop.Dock = DockStyle.Fill;
            h_PanelExCenterTop.Location = new Point(0, 0);
            h_PanelExCenterTop.Margin = new Padding(0);
            h_PanelExCenterTop.Name = "h_PanelExCenterTop";
            h_PanelExCenterTop.Size = new Size(1836, 36);
            h_PanelExCenterTop.TabIndex = 0;
            // 
            // h_ButtonExUpdate
            // 
            h_ButtonExUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            h_ButtonExUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            h_ButtonExUpdate.Location = new Point(1659, 2);
            h_ButtonExUpdate.Name = "h_ButtonExUpdate";
            h_ButtonExUpdate.Size = new Size(174, 32);
            h_ButtonExUpdate.TabIndex = 2;
            h_ButtonExUpdate.Text = "最　新　化 ";
            h_ButtonExUpdate.UseVisualStyleBackColor = true;
            h_ButtonExUpdate.Click += H_ButtonExUpdate_Click;
            // 
            // H_DateTimePickerOperationDate
            // 
            H_DateTimePickerOperationDate.CustomFormat = "yyyy年MM月dd日(dddd)";
            H_DateTimePickerOperationDate.Format = DateTimePickerFormat.Custom;
            H_DateTimePickerOperationDate.Location = new Point(54, 7);
            H_DateTimePickerOperationDate.Name = "H_DateTimePickerOperationDate";
            H_DateTimePickerOperationDate.Size = new Size(180, 23);
            H_DateTimePickerOperationDate.TabIndex = 0;
            H_DateTimePickerOperationDate.TabStop = false;
            H_DateTimePickerOperationDate.Value = new DateTime(2023, 10, 10, 0, 0, 0, 0);
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(6, 11);
            h_LabelEx1.Name = "h_LabelEx1";
            h_LabelEx1.Size = new Size(43, 15);
            h_LabelEx1.TabIndex = 1;
            h_LabelEx1.Text = "配車日";
            // 
            // H_VehicleDispatchBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
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
            h_PanelExLeft.ResumeLayout(false);
            h_PanelExRight.ResumeLayout(false);
            h_PanelExCenter.ResumeLayout(false);
            h_TableLayoutPanelExCenter.ResumeLayout(false);
            h_PanelExCenterTop.ResumeLayout(false);
            h_PanelExCenterTop.PerformLayout();
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
        private H_ControlEx.H_DateTimePickerEx H_DateTimePickerOperationDate;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_ButtonEx h_ButtonExUpdate;
        private H_ControlEx.H_PanelEx h_PanelExLeft;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft1;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft5;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft4;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft3;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft2;
        private H_ControlEx.H_PanelEx h_PanelExRight;
        private H_ControlEx.H_ButtonEx h_ButtonExRight5;
        private H_ControlEx.H_ButtonEx h_ButtonExRight4;
        private H_ControlEx.H_ButtonEx h_ButtonExRight3;
        private H_ControlEx.H_ButtonEx h_ButtonExRight2;
        private H_ControlEx.H_ButtonEx h_ButtonExRight1;
        private H_ControlEx.H_PanelEx h_PanelExCenter;
        private H_ControlEx.H_TableLayoutPanelEx h_TableLayoutPanelExCenter;
        private H_ControlEx.H_PanelEx h_PanelExCenterTop;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemInitializeVehicleDispatch;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemPrintB4;
    }
}