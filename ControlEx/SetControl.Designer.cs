namespace ControlEx {
    partial class SetControl {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.TableLayoutPanelEx1 = new ControlEx.TableLayoutPanelEx();
            this.SuspendLayout();
            // 
            // TableLayoutPanelEx1
            // 
            this.TableLayoutPanelEx1.ColumnCount = 1;
            this.TableLayoutPanelEx1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelEx1.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanelEx1.Name = "TableLayoutPanelEx1";
            this.TableLayoutPanelEx1.RowCount = 6;
            this.TableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanelEx1.Size = new System.Drawing.Size(74, 300);
            this.TableLayoutPanelEx1.TabIndex = 0;
            this.TableLayoutPanelEx1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TableLayoutPanelEx1_CellPaint);
            // 
            // SetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanelEx1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "SetControl";
            this.Size = new System.Drawing.Size(74, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanelEx TableLayoutPanelEx1;
    }
}
