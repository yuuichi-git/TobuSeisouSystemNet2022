namespace TobuSeisouSystemNet2022 {
    partial class StartProject {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TableLayoutPanelCenter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonDbConnect = new System.Windows.Forms.Button();
            this.LabelServerName = new System.Windows.Forms.Label();
            this.LabelDbName = new System.Windows.Forms.Label();
            this.LabelConnectStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TableLayoutPanelBase.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.TableLayoutPanelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            this.TableLayoutPanelBase.ColumnCount = 3;
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.TableLayoutPanelBase.Controls.Add(this.MenuStrip1, 0, 0);
            this.TableLayoutPanelBase.Controls.Add(this.StatusStrip1, 0, 2);
            this.TableLayoutPanelBase.Controls.Add(this.TableLayoutPanelCenter, 1, 1);
            this.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            this.TableLayoutPanelBase.RowCount = 3;
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.Size = new System.Drawing.Size(1316, 808);
            this.TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            this.TableLayoutPanelBase.SetColumnSpan(this.MenuStrip1, 3);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMenu,
            this.ToolStripMenuItemHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1316, 24);
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
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemHelp.Text = "ヘルプ";
            // 
            // StatusStrip1
            // 
            this.TableLayoutPanelBase.SetColumnSpan(this.StatusStrip1, 3);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 786);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1316, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 1;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.ToolStripStatusLabel1.Text = "Status";
            // 
            // TableLayoutPanelCenter
            // 
            this.TableLayoutPanelCenter.ColumnCount = 2;
            this.TableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TableLayoutPanelCenter.Controls.Add(this.label1, 0, 0);
            this.TableLayoutPanelCenter.Controls.Add(this.label2, 0, 1);
            this.TableLayoutPanelCenter.Controls.Add(this.ButtonDbConnect, 1, 1);
            this.TableLayoutPanelCenter.Controls.Add(this.LabelServerName, 0, 2);
            this.TableLayoutPanelCenter.Controls.Add(this.LabelDbName, 0, 3);
            this.TableLayoutPanelCenter.Controls.Add(this.LabelConnectStatus, 0, 4);
            this.TableLayoutPanelCenter.Controls.Add(this.label3, 0, 6);
            this.TableLayoutPanelCenter.Controls.Add(this.label4, 0, 7);
            this.TableLayoutPanelCenter.Controls.Add(this.label5, 0, 8);
            this.TableLayoutPanelCenter.Controls.Add(this.label6, 0, 10);
            this.TableLayoutPanelCenter.Controls.Add(this.label7, 0, 11);
            this.TableLayoutPanelCenter.Controls.Add(this.label8, 0, 13);
            this.TableLayoutPanelCenter.Controls.Add(this.label9, 0, 14);
            this.TableLayoutPanelCenter.Controls.Add(this.label10, 0, 16);
            this.TableLayoutPanelCenter.Controls.Add(this.label11, 0, 17);
            this.TableLayoutPanelCenter.Controls.Add(this.label12, 0, 19);
            this.TableLayoutPanelCenter.Controls.Add(this.label13, 0, 20);
            this.TableLayoutPanelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelCenter.Location = new System.Drawing.Point(303, 27);
            this.TableLayoutPanelCenter.Name = "TableLayoutPanelCenter";
            this.TableLayoutPanelCenter.RowCount = 26;
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelCenter.Size = new System.Drawing.Size(710, 754);
            this.TableLayoutPanelCenter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "データベース接続";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(504, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "　データベースの接続と切断及びステータスを管理";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonDbConnect
            // 
            this.ButtonDbConnect.Location = new System.Drawing.Point(513, 33);
            this.ButtonDbConnect.Name = "ButtonDbConnect";
            this.TableLayoutPanelCenter.SetRowSpan(this.ButtonDbConnect, 2);
            this.ButtonDbConnect.Size = new System.Drawing.Size(135, 31);
            this.ButtonDbConnect.TabIndex = 3;
            this.ButtonDbConnect.Text = "データベース接続";
            this.ButtonDbConnect.UseVisualStyleBackColor = true;
            this.ButtonDbConnect.Click += new System.EventHandler(this.ButtonDbConnect_Click);
            // 
            // LabelServerName
            // 
            this.LabelServerName.AutoSize = true;
            this.LabelServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelServerName.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelServerName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LabelServerName.Location = new System.Drawing.Point(3, 50);
            this.LabelServerName.Name = "LabelServerName";
            this.LabelServerName.Size = new System.Drawing.Size(504, 20);
            this.LabelServerName.TabIndex = 4;
            this.LabelServerName.Text = "　接続先サーバー：";
            this.LabelServerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDbName
            // 
            this.LabelDbName.AutoSize = true;
            this.LabelDbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDbName.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelDbName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LabelDbName.Location = new System.Drawing.Point(3, 70);
            this.LabelDbName.Name = "LabelDbName";
            this.LabelDbName.Size = new System.Drawing.Size(504, 20);
            this.LabelDbName.TabIndex = 5;
            this.LabelDbName.Text = "　接続先データベース：";
            this.LabelDbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelConnectStatus
            // 
            this.LabelConnectStatus.AutoSize = true;
            this.LabelConnectStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelConnectStatus.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelConnectStatus.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LabelConnectStatus.Location = new System.Drawing.Point(3, 90);
            this.LabelConnectStatus.Name = "LabelConnectStatus";
            this.LabelConnectStatus.Size = new System.Drawing.Size(504, 20);
            this.LabelConnectStatus.TabIndex = 6;
            this.LabelConnectStatus.Text = "　状態：";
            this.LabelConnectStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "アプリケーション";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(504, 20);
            this.label4.TabIndex = 8;
            this.label4.Tag = "VehicleDispatch";
            this.label4.Text = "　配車システム";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.Label_Click);
            this.label4.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(3, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(504, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "　従業員・車両等のパネルをドラッグ＆ドロップ操作で配車します。";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(504, 20);
            this.label6.TabIndex = 10;
            this.label6.Tag = "ProductionList";
            this.label6.Text = "　本番変更";
            this.label6.Click += new System.EventHandler(this.Label_Click);
            this.label6.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(3, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "　本番登録の新規及び修正や削除を行います。";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 12;
            this.label8.Tag = "StaffList";
            this.label8.Text = "　従事者台帳";
            this.label8.Click += new System.EventHandler(this.Label_Click);
            this.label8.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(3, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "　従事者の登録・修正を行います。";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(3, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 14;
            this.label10.Tag = "LicenseList";
            this.label10.Text = "　免許証台帳";
            this.label10.Click += new System.EventHandler(this.Label_Click);
            this.label10.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label10.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(3, 360);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "　運転免許証の管理を行います。";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(3, 400);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 16;
            this.label12.Tag = "CarAccidentList";
            this.label12.Text = "　事故記録台帳";
            this.label12.Click += new System.EventHandler(this.Label_Click);
            this.label12.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label12.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(3, 420);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(296, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "　車両事故・作業事故等のトラブルを記録管理します。";
            // 
            // StartProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 808);
            this.Controls.Add(this.TableLayoutPanelBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartProject";
            this.Text = "StartProject";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartProject_FormClosing);
            this.TableLayoutPanelBase.ResumeLayout(false);
            this.TableLayoutPanelBase.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.TableLayoutPanelCenter.ResumeLayout(false);
            this.TableLayoutPanelCenter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem ToolStripMenuItemMenu;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel ToolStripStatusLabel1;
        private TableLayoutPanel TableLayoutPanelCenter;
        private Label label1;
        private Label label2;
        private Button ButtonDbConnect;
        private Label LabelServerName;
        private Label LabelDbName;
        private Label LabelConnectStatus;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}