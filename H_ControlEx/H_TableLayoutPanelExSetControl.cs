/*
 * 2023-10-20
 */
namespace H_ControlEx {
    public partial class H_TableLayoutPanelExSetControl : TableLayoutPanel {
        /*
         * Cellの数
         */
        private const int _columnCount = 1;
        private const int _rowCount = 4;

        /// <summary>
        /// コンストラクタ
        /// H_TableLayoutPanelExSetControlVoに全ての引数を代入しておく
        /// </summary>
        public H_TableLayoutPanelExSetControl() {
            /*
             * ControlIni
             */
            InitializeComponent();
            /*
             * SetControlExのセルを定義する
             * コンストラクタで書くと、デザイン画面に反映されない。
             */
            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            this.Margin = new Padding(0);
            this.Name = "H_TableLayoutPanelExSetControl";
            this.Padding = new Padding(0);
            this.Size = new Size(80, 360);

            this.ColumnCount = _columnCount;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.RowCount = _rowCount;
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            /*
             * Event
             */
            this.CellPaint += H_TableLayoutPanelExSetControl1_CellPaint;
            this.Paint += H_TableLayoutPanelExSetControl1_Paint;
        }

        /// <summary>
        /// H_TableLayoutPanelExSetControl1_CellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_TableLayoutPanelExSetControl1_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
            switch(e.Row) {
                case 0: // SetLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // SetLabelExの枠線
                    break;
                case 1: // CarLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // CarLabelExの枠線
                    break;
                case 2: // StaffLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                    break;
                case 3: // StaffLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                    break;
            }
        }

        /// <summary>
        /// H_TableLayoutPanelExSetControl1_Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_TableLayoutPanelExSetControl1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
