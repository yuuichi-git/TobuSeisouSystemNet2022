namespace LicenseLedger {
    partial class LicenseList {
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
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.TabControlStaff = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelDetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanelBase.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.PanelTop.SuspendLayout();
            this.TabControlStaff.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanelBase
            // 
            this.TableLayoutPanelBase.ColumnCount = 1;
            this.TableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.Controls.Add(this.MenuStrip1, 0, 0);
            this.TableLayoutPanelBase.Controls.Add(this.PanelTop, 0, 1);
            this.TableLayoutPanelBase.Controls.Add(this.StatusStrip1, 0, 3);
            this.TableLayoutPanelBase.Controls.Add(this.DataGridView1, 0, 2);
            this.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelBase.Name = "TableLayoutPanelBase";
            this.TableLayoutPanelBase.RowCount = 4;
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBase.Size = new System.Drawing.Size(1904, 1041);
            this.TableLayoutPanelBase.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "menuStrip1";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemExit});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItemExit.Text = "アプリケーションを終了する";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewLicense});
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // ToolStripMenuItemNewLicense
            // 
            this.ToolStripMenuItemNewLicense.Name = "ToolStripMenuItemNewLicense";
            this.ToolStripMenuItemNewLicense.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemNewLicense.Text = "新規免許証を登録する";
            this.ToolStripMenuItemNewLicense.Click += new System.EventHandler(this.ToolStripMenuItemNewLicense_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.ButtonUpdate);
            this.PanelTop.Controls.Add(this.TabControlStaff);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTop.Location = new System.Drawing.Point(0, 24);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1904, 62);
            this.PanelTop.TabIndex = 1;
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(1670, 8);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(180, 36);
            this.ButtonUpdate.TabIndex = 4;
            this.ButtonUpdate.Text = "最 新 化";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // TabControlStaff
            // 
            this.TabControlStaff.Controls.Add(this.tabPage1);
            this.TabControlStaff.Controls.Add(this.tabPage2);
            this.TabControlStaff.Controls.Add(this.tabPage3);
            this.TabControlStaff.Controls.Add(this.tabPage4);
            this.TabControlStaff.Controls.Add(this.tabPage5);
            this.TabControlStaff.Controls.Add(this.tabPage6);
            this.TabControlStaff.Controls.Add(this.tabPage7);
            this.TabControlStaff.Controls.Add(this.tabPage8);
            this.TabControlStaff.Controls.Add(this.tabPage9);
            this.TabControlStaff.Controls.Add(this.tabPage10);
            this.TabControlStaff.Controls.Add(this.tabPage11);
            this.TabControlStaff.Location = new System.Drawing.Point(0, 36);
            this.TabControlStaff.Name = "TabControlStaff";
            this.TabControlStaff.SelectedIndex = 0;
            this.TabControlStaff.Size = new System.Drawing.Size(1892, 28);
            this.TabControlStaff.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControlStaff.TabIndex = 5;
            this.TabControlStaff.Click += new System.EventHandler(this.TabControlStaff_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1884, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "全従事者";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1884, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "ア";
            this.tabPage2.Text = "あ行";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1884, 0);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "カ";
            this.tabPage3.Text = "か行";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1884, 0);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Tag = "サ";
            this.tabPage4.Text = "さ行";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1884, 0);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Tag = "タ";
            this.tabPage5.Text = "た行";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1884, 0);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Tag = "ナ";
            this.tabPage6.Text = "な行";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1884, 0);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Tag = "ハ";
            this.tabPage7.Text = "は行";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1884, 0);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Tag = "マ";
            this.tabPage8.Text = "ま行";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 24);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1884, 0);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Tag = "ヤ";
            this.tabPage9.Text = "や行";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 24);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1884, 0);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Tag = "ラ";
            this.tabPage10.Text = "ら行";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 24);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1884, 0);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Tag = "ワ";
            this.tabPage11.Text = "わ行";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStatusLabelDetail});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 1019);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1904, 22);
            this.StatusStrip1.TabIndex = 2;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelDetail
            // 
            this.ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            this.ToolStripStatusLabelDetail.Size = new System.Drawing.Size(143, 17);
            this.ToolStripStatusLabelDetail.Text = "ToolStripStatusLabelDetail";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(3, 89);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 25;
            this.DataGridView1.Size = new System.Drawing.Size(1898, 925);
            this.DataGridView1.TabIndex = 3;
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // LicenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TableLayoutPanelBase);
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "LicenseList";
            this.Text = "LicenseLedgerList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LicenseLedgerList_FormClosing);
            this.TableLayoutPanelBase.ResumeLayout(false);
            this.TableLayoutPanelBase.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.PanelTop.ResumeLayout(false);
            this.TabControlStaff.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel TableLayoutPanelBase;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem メニューToolStripMenuItem;
        private ToolStripMenuItem 編集ToolStripMenuItem;
        private ToolStripMenuItem ヘルプToolStripMenuItem;
        private Panel PanelTop;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
        private DataGridView DataGridView1;
        private Button ButtonUpdate;
        private TabControl TabControlStaff;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemNewLicense;
    }
}