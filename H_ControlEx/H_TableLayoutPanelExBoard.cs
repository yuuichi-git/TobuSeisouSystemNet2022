/*
 * 2023-10-19
 */
namespace H_ControlEx {
    public partial class H_TableLayoutPanelExBoard : TableLayoutPanel {
        /*
         * 変数定義
         */
        TableLayoutColumnStyleCollection tableLayoutColumnStyleCollection;
        TableLayoutRowStyleCollection tableLayoutRowStyleCollection;
        /*
         * Cellの数
         */
        private const int _colCount = 35; // Rowの数
        private const int _rowCount = 3; // Columnの数
        /*
         * Cellのサイズ
         */
        private const int _colWidth = 80;
        private const int _rowHeight = 360;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_TableLayoutPanelExBoard() {
            tableLayoutColumnStyleCollection = this.ColumnStyles;
            tableLayoutRowStyleCollection = this.RowStyles;
            /*
             * ControlIni
             */
            InitializeComponent();
            /*
             * Event
             */
            this.MouseMove += H_TableLayoutPanelExBoard_MouseMove;
            this.Paint += H_TableLayoutPanelExBoard_Paint;
        }

        /// <summary>
        /// H_TableLayoutPanelExBoard_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_TableLayoutPanelExBoard_MouseMove(object sender, MouseEventArgs e) {
            /*
             * 左右を自動でスクロールさせる
             */
            int autoScrollPositionX = ((_colWidth * _colCount - this.Size.Width) / 2) + e.X - this.Size.Width / 2;
            int autoScrollPositionY = ((_rowHeight * _rowCount - this.Size.Height) / 2) + e.Y - this.Size.Height / 2;
            this.AutoScrollPosition = new Point(autoScrollPositionX, autoScrollPositionY);
        }

        /// <summary>
        /// H_TableLayoutPanelExBoard_Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_TableLayoutPanelExBoard_Paint(object sender, PaintEventArgs e) {
            /*
             * Styleを初期化
             * デザイン画面で見たいので、苦肉の策でここに書いた。ここに書くと毎回描画される。
             */
            foreach(ColumnStyle style in tableLayoutColumnStyleCollection) {
                style.SizeType = SizeType.Absolute;
                style.Width = _colWidth;
            }
            foreach(RowStyle style in tableLayoutRowStyleCollection) {
                style.SizeType = SizeType.Absolute;
                style.Height = _rowHeight;
            }
        }
    }
}
