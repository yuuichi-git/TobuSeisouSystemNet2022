namespace Staff {
    partial class StaffList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffList));
            this.tableLayoutPanelEx1 = new ControlEx.TableLayoutPanelEx();
            this.FpSpreadStaffList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, ((object)(resources.GetObject("tableLayoutPanelEx1.Controls"))));
            this.FpSpreadStaffList_Sheet1 = this.FpSpreadStaffList.GetSheet(0);
            this.tableLayoutPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpSpreadStaffList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelEx1
            // 
            this.tableLayoutPanelEx1.ColumnCount = 1;
            this.tableLayoutPanelEx1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEx1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelEx1.Controls.Add(this.FpSpreadStaffList, 0, 2);
            this.tableLayoutPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEx1.Name = "tableLayoutPanelEx1";
            this.tableLayoutPanelEx1.RowCount = 4;
            this.tableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelEx1.Size = new System.Drawing.Size(1904, 1041);
            this.tableLayoutPanelEx1.TabIndex = 0;
            // 
            // FpSpreadStaffList
            // 
            this.FpSpreadStaffList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FpSpreadStaffList.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FpSpreadStaffList.Location = new System.Drawing.Point(3, 107);
            this.FpSpreadStaffList.Name = "FpSpreadStaffList";
            this.FpSpreadStaffList.Size = new System.Drawing.Size(1898, 907);
            this.FpSpreadStaffList.TabIndex = 0;
            // 
            // StaffList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tableLayoutPanelEx1);
            this.DoubleBuffered = true;
            this.Name = "StaffList";
            this.Text = "Form1";
            this.tableLayoutPanelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FpSpreadStaffList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlEx.TableLayoutPanelEx tableLayoutPanelEx1;
        private FarPoint.Win.Spread.FpSpread FpSpreadStaffList;
        private FarPoint.Win.Spread.SheetView FpSpreadStaffList_Sheet1;
    }
}