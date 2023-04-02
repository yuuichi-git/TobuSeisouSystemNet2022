namespace SubstituteSheet {
    partial class SubstituteSheet2 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubstituteSheet2));
            TableLayoutPanelEx1 = new ControlEx.TableLayoutPanelEx();
            SpreadList = new FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("TableLayoutPanelEx1.Controls"));
            SheetView1 = SpreadList.GetSheet(0);
            TableLayoutPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpreadList).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelEx1
            // 
            TableLayoutPanelEx1.ButtonBorderStyleDotted = false;
            TableLayoutPanelEx1.ColumnCount = 1;
            TableLayoutPanelEx1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelEx1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanelEx1.Controls.Add(SpreadList, 0, 2);
            TableLayoutPanelEx1.Dock = DockStyle.Fill;
            TableLayoutPanelEx1.Location = new Point(0, 0);
            TableLayoutPanelEx1.Name = "TableLayoutPanelEx1";
            TableLayoutPanelEx1.RowCount = 4;
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            TableLayoutPanelEx1.Size = new Size(821, 1041);
            TableLayoutPanelEx1.TabIndex = 0;
            // 
            // SpreadList
            // 
            SpreadList.AccessibleDescription = "SpreadList, Sheet1, Row 0, Column 0";
            SpreadList.Dock = DockStyle.Fill;
            SpreadList.Font = new Font("ＭＳ Ｐゴシック", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SpreadList.Location = new Point(3, 87);
            SpreadList.Name = "SpreadList";
            SpreadList.Size = new Size(815, 927);
            SpreadList.TabIndex = 0;
            // 
            // SubstituteSheet2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 1041);
            Controls.Add(TableLayoutPanelEx1);
            Name = "SubstituteSheet2";
            Text = "SubstituteSheet2";
            TableLayoutPanelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpreadList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ControlEx.TableLayoutPanelEx TableLayoutPanelEx1;
        private FarPoint.Win.Spread.FpSpread SpreadList;
        private FarPoint.Win.Spread.SheetView SheetView1;
    }
}