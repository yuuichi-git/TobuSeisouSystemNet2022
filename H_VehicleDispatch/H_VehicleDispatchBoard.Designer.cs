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
            ToolStripMenuItemInitializeVehicleDispatchBody = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItemInitializeVehicleDispatchCopy = new ToolStripMenuItem();
            ToolStripMenuItemUpdateVehicleDispatch = new ToolStripMenuItem();
            ToolStripMenuItemUpdateVehicleDispatchBody = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItemInputTAITOU = new ToolStripMenuItem();
            ToolStripMenuItemPrint = new ToolStripMenuItem();
            ToolStripMenuItemPrintB4 = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            StatusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripProgressBar1 = new ToolStripProgressBar();
            ToolStripStatusLabelDetail = new ToolStripStatusLabel();
            h_PanelExLeft = new H_ControlEx.H_PanelEx();
            h_ButtonExLeft5 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft4 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft3 = new H_ControlEx.H_ButtonEx();
            h_ButtonExLeft2 = new H_ControlEx.H_ButtonEx();
            HButtonExLeft1 = new H_ControlEx.H_ButtonEx();
            h_PanelExCenter = new H_ControlEx.H_PanelEx();
            HTableLayoutPanelExCenter = new H_ControlEx.H_TableLayoutPanelEx();
            h_PanelExCenterTop = new H_ControlEx.H_PanelEx();
            HButtonExUpdate = new H_ControlEx.H_ButtonEx();
            HDateTimePickerOperationDate = new H_ControlEx.H_DateTimePickerEx();
            h_LabelEx1 = new H_ControlEx.H_LabelEx();
            h_TableLayoutPanelExBase.SuspendLayout();
            MenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            h_PanelExLeft.SuspendLayout();
            h_PanelExCenter.SuspendLayout();
            HTableLayoutPanelExCenter.SuspendLayout();
            h_PanelExCenterTop.SuspendLayout();
            SuspendLayout();
            // 
            // h_TableLayoutPanelExBase
            // 
            h_TableLayoutPanelExBase.ColumnCount = 2;
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            h_TableLayoutPanelExBase.Controls.Add(MenuStrip1, 0, 0);
            h_TableLayoutPanelExBase.Controls.Add(StatusStrip1, 0, 2);
            h_TableLayoutPanelExBase.Controls.Add(h_PanelExLeft, 0, 1);
            h_TableLayoutPanelExBase.Controls.Add(h_PanelExCenter, 1, 1);
            h_TableLayoutPanelExBase.Dock = DockStyle.Fill;
            h_TableLayoutPanelExBase.Location = new Point(0, 0);
            h_TableLayoutPanelExBase.Name = "h_TableLayoutPanelExBase";
            h_TableLayoutPanelExBase.RowCount = 3;
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            h_TableLayoutPanelExBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            h_TableLayoutPanelExBase.Size = new Size(1904, 1041);
            h_TableLayoutPanelExBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            h_TableLayoutPanelExBase.SetColumnSpan(MenuStrip1, 2);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemMenu, ToolStripMenuItemInitialize, ToolStripMenuItemUpdateVehicleDispatch, ToolStripMenuItemPrint, ToolStripMenuItemHelp });
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
            ToolStripMenuItemExit.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemInitialize
            // 
            ToolStripMenuItemInitialize.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemInitializeVehicleDispatchBody, toolStripSeparator2, ToolStripMenuItemInitializeVehicleDispatchCopy });
            ToolStripMenuItemInitialize.Name = "ToolStripMenuItemInitialize";
            ToolStripMenuItemInitialize.Size = new Size(55, 20);
            ToolStripMenuItemInitialize.Text = "初期化";
            // 
            // ToolStripMenuItemInitializeVehicleDispatchBody
            // 
            ToolStripMenuItemInitializeVehicleDispatchBody.Name = "ToolStripMenuItemInitializeVehicleDispatchBody";
            ToolStripMenuItemInitializeVehicleDispatchBody.Size = new Size(262, 22);
            ToolStripMenuItemInitializeVehicleDispatchBody.Text = "配車を初期化する(本番登録)";
            ToolStripMenuItemInitializeVehicleDispatchBody.Click += ToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(259, 6);
            // 
            // ToolStripMenuItemInitializeVehicleDispatchCopy
            // 
            ToolStripMenuItemInitializeVehicleDispatchCopy.Name = "ToolStripMenuItemInitializeVehicleDispatchCopy";
            ToolStripMenuItemInitializeVehicleDispatchCopy.Size = new Size(262, 22);
            ToolStripMenuItemInitializeVehicleDispatchCopy.Text = "配車を初期化する(前日の配車をコピー)";
            ToolStripMenuItemInitializeVehicleDispatchCopy.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemUpdateVehicleDispatch
            // 
            ToolStripMenuItemUpdateVehicleDispatch.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemUpdateVehicleDispatchBody, toolStripSeparator1, ToolStripMenuItemInputTAITOU });
            ToolStripMenuItemUpdateVehicleDispatch.Name = "ToolStripMenuItemUpdateVehicleDispatch";
            ToolStripMenuItemUpdateVehicleDispatch.Size = new Size(43, 20);
            ToolStripMenuItemUpdateVehicleDispatch.Text = "登録";
            // 
            // ToolStripMenuItemUpdateVehicleDispatchBody
            // 
            ToolStripMenuItemUpdateVehicleDispatchBody.Name = "ToolStripMenuItemUpdateVehicleDispatchBody";
            ToolStripMenuItemUpdateVehicleDispatchBody.Size = new Size(260, 22);
            ToolStripMenuItemUpdateVehicleDispatchBody.Text = "この配車組(指定曜日)を本番登録する";
            ToolStripMenuItemUpdateVehicleDispatchBody.Click += ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(257, 6);
            // 
            // ToolStripMenuItemInputTAITOU
            // 
            ToolStripMenuItemInputTAITOU.Name = "ToolStripMenuItemInputTAITOU";
            ToolStripMenuItemInputTAITOU.Size = new Size(260, 22);
            ToolStripMenuItemInputTAITOU.Text = "台東古紙/収集実績入力";
            ToolStripMenuItemInputTAITOU.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemPrint
            // 
            ToolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemPrintB4 });
            ToolStripMenuItemPrint.Enabled = false;
            ToolStripMenuItemPrint.Name = "ToolStripMenuItemPrint";
            ToolStripMenuItemPrint.Size = new Size(43, 20);
            ToolStripMenuItemPrint.Text = "印刷";
            // 
            // ToolStripMenuItemPrintB4
            // 
            ToolStripMenuItemPrintB4.Name = "ToolStripMenuItemPrintB4";
            ToolStripMenuItemPrintB4.Size = new Size(140, 22);
            ToolStripMenuItemPrintB4.Text = "B4で印刷する";
            ToolStripMenuItemPrintB4.Click += ToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(48, 20);
            ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            h_TableLayoutPanelExBase.SetColumnSpan(StatusStrip1, 2);
            StatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, ToolStripProgressBar1, ToolStripStatusLabelDetail });
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
            // ToolStripProgressBar1
            // 
            ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            ToolStripProgressBar1.Size = new Size(200, 16);
            ToolStripProgressBar1.Step = 1;
            ToolStripProgressBar1.Value = 50;
            // 
            // ToolStripStatusLabelDetail
            // 
            ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            ToolStripStatusLabelDetail.Size = new Size(143, 17);
            ToolStripStatusLabelDetail.Text = "ToolStripStatusLabelDetail";
            // 
            // h_PanelExLeft
            // 
            h_PanelExLeft.Controls.Add(h_ButtonExLeft5);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft4);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft3);
            h_PanelExLeft.Controls.Add(h_ButtonExLeft2);
            h_PanelExLeft.Controls.Add(HButtonExLeft1);
            h_PanelExLeft.Dock = DockStyle.Fill;
            h_PanelExLeft.Location = new Point(0, 24);
            h_PanelExLeft.Margin = new Padding(0);
            h_PanelExLeft.Name = "h_PanelExLeft";
            h_PanelExLeft.Size = new Size(34, 993);
            h_PanelExLeft.TabIndex = 7;
            // 
            // h_ButtonExLeft5
            // 
            h_ButtonExLeft5.Location = new Point(2, 494);
            h_ButtonExLeft5.Name = "h_ButtonExLeft5";
            h_ButtonExLeft5.Size = new Size(30, 100);
            h_ButtonExLeft5.TabIndex = 4;
            h_ButtonExLeft5.TabStop = false;
            h_ButtonExLeft5.TextDirectionVertical = "";
            h_ButtonExLeft5.UseVisualStyleBackColor = true;
            h_ButtonExLeft5.Click += HButtonEx_Click;
            // 
            // h_ButtonExLeft4
            // 
            h_ButtonExLeft4.Location = new Point(2, 392);
            h_ButtonExLeft4.Name = "h_ButtonExLeft4";
            h_ButtonExLeft4.Size = new Size(30, 100);
            h_ButtonExLeft4.TabIndex = 3;
            h_ButtonExLeft4.TabStop = false;
            h_ButtonExLeft4.TextDirectionVertical = "";
            h_ButtonExLeft4.UseVisualStyleBackColor = true;
            h_ButtonExLeft4.Click += HButtonEx_Click;
            // 
            // h_ButtonExLeft3
            // 
            h_ButtonExLeft3.Location = new Point(2, 290);
            h_ButtonExLeft3.Name = "h_ButtonExLeft3";
            h_ButtonExLeft3.Size = new Size(30, 100);
            h_ButtonExLeft3.TabIndex = 2;
            h_ButtonExLeft3.TabStop = false;
            h_ButtonExLeft3.TextDirectionVertical = "";
            h_ButtonExLeft3.UseVisualStyleBackColor = true;
            h_ButtonExLeft3.Click += HButtonEx_Click;
            // 
            // h_ButtonExLeft2
            // 
            h_ButtonExLeft2.Location = new Point(2, 188);
            h_ButtonExLeft2.Name = "h_ButtonExLeft2";
            h_ButtonExLeft2.Size = new Size(30, 100);
            h_ButtonExLeft2.TabIndex = 1;
            h_ButtonExLeft2.TabStop = false;
            h_ButtonExLeft2.TextDirectionVertical = "";
            h_ButtonExLeft2.UseVisualStyleBackColor = true;
            h_ButtonExLeft2.Click += HButtonEx_Click;
            // 
            // HButtonExLeft1
            // 
            HButtonExLeft1.Location = new Point(2, 36);
            HButtonExLeft1.Name = "HButtonExLeft1";
            HButtonExLeft1.Size = new Size(30, 150);
            HButtonExLeft1.TabIndex = 0;
            HButtonExLeft1.TabStop = false;
            HButtonExLeft1.TextDirectionVertical = "";
            HButtonExLeft1.UseVisualStyleBackColor = true;
            HButtonExLeft1.Click += HButtonEx_Click;
            // 
            // h_PanelExCenter
            // 
            h_PanelExCenter.Controls.Add(HTableLayoutPanelExCenter);
            h_PanelExCenter.Dock = DockStyle.Fill;
            h_PanelExCenter.Location = new Point(34, 24);
            h_PanelExCenter.Margin = new Padding(0);
            h_PanelExCenter.Name = "h_PanelExCenter";
            h_PanelExCenter.Size = new Size(1870, 993);
            h_PanelExCenter.TabIndex = 9;
            // 
            // HTableLayoutPanelExCenter
            // 
            HTableLayoutPanelExCenter.ColumnCount = 1;
            HTableLayoutPanelExCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExCenter.Controls.Add(h_PanelExCenterTop, 0, 0);
            HTableLayoutPanelExCenter.Dock = DockStyle.Fill;
            HTableLayoutPanelExCenter.Location = new Point(0, 0);
            HTableLayoutPanelExCenter.Margin = new Padding(0);
            HTableLayoutPanelExCenter.Name = "HTableLayoutPanelExCenter";
            HTableLayoutPanelExCenter.RowCount = 3;
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExCenter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            HTableLayoutPanelExCenter.Size = new Size(1870, 993);
            HTableLayoutPanelExCenter.TabIndex = 0;
            // 
            // h_PanelExCenterTop
            // 
            h_PanelExCenterTop.Controls.Add(HButtonExUpdate);
            h_PanelExCenterTop.Controls.Add(HDateTimePickerOperationDate);
            h_PanelExCenterTop.Controls.Add(h_LabelEx1);
            h_PanelExCenterTop.Dock = DockStyle.Fill;
            h_PanelExCenterTop.Location = new Point(0, 0);
            h_PanelExCenterTop.Margin = new Padding(0);
            h_PanelExCenterTop.Name = "h_PanelExCenterTop";
            h_PanelExCenterTop.Size = new Size(1870, 36);
            h_PanelExCenterTop.TabIndex = 0;
            // 
            // HButtonExUpdate
            // 
            HButtonExUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HButtonExUpdate.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            HButtonExUpdate.Location = new Point(1662, 2);
            HButtonExUpdate.Name = "HButtonExUpdate";
            HButtonExUpdate.Size = new Size(174, 32);
            HButtonExUpdate.TabIndex = 2;
            HButtonExUpdate.Text = "最　新　化 ";
            HButtonExUpdate.TextDirectionVertical = "";
            HButtonExUpdate.UseVisualStyleBackColor = true;
            HButtonExUpdate.Click += HButtonEx_Click;
            // 
            // HDateTimePickerOperationDate
            // 
            HDateTimePickerOperationDate.CustomFormat = " 令和05年10月10日(火曜日)";
            HDateTimePickerOperationDate.Format = DateTimePickerFormat.Custom;
            HDateTimePickerOperationDate.Location = new Point(64, 7);
            HDateTimePickerOperationDate.Name = "HDateTimePickerOperationDate";
            HDateTimePickerOperationDate.Size = new Size(186, 23);
            HDateTimePickerOperationDate.TabIndex = 0;
            HDateTimePickerOperationDate.TabStop = false;
            HDateTimePickerOperationDate.Value = new DateTime(2023, 10, 10, 0, 0, 0, 0);
            HDateTimePickerOperationDate.ValueChanged += HDateTimePickerOperationDate_ValueChanged;
            // 
            // h_LabelEx1
            // 
            h_LabelEx1.AutoSize = true;
            h_LabelEx1.Location = new Point(16, 11);
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
            FormClosing += H_VehicleDispatchBoard_FormClosing;
            h_TableLayoutPanelExBase.ResumeLayout(false);
            h_TableLayoutPanelExBase.PerformLayout();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            h_PanelExLeft.ResumeLayout(false);
            h_PanelExCenter.ResumeLayout(false);
            HTableLayoutPanelExCenter.ResumeLayout(false);
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
        private H_ControlEx.H_DateTimePickerEx HDateTimePickerOperationDate;
        private H_ControlEx.H_LabelEx h_LabelEx1;
        private H_ControlEx.H_ButtonEx HButtonExUpdate;
        private H_ControlEx.H_PanelEx h_PanelExLeft;
        private H_ControlEx.H_ButtonEx HButtonExLeft1;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft5;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft4;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft3;
        private H_ControlEx.H_ButtonEx h_ButtonExLeft2;
        private H_ControlEx.H_PanelEx h_PanelExCenter;
        private H_ControlEx.H_TableLayoutPanelEx HTableLayoutPanelExCenter;
        private H_ControlEx.H_PanelEx h_PanelExCenterTop;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemInitializeVehicleDispatchBody;
        private ToolStripMenuItem ToolStripMenuItemPrint;
        private ToolStripMenuItem ToolStripMenuItemPrintB4;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private ToolStripProgressBar ToolStripProgressBar1;
        private ToolStripMenuItem ToolStripMenuItemInitializeVehicleDispatchCopy;
        private ToolStripMenuItem ToolStripMenuItemUpdateVehicleDispatch;
        private ToolStripMenuItem ToolStripMenuItemUpdateVehicleDispatchBody;
        private ToolStripMenuItem ToolStripMenuItemInputTAITOU;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
    }
}