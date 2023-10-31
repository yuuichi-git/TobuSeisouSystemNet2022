/*
 * 2023-10-19
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_Board : TableLayoutPanel {
        /*
         * 変数定義
         */
        private TableLayoutColumnStyleCollection _tableLayoutColumnStyleCollection;
        private TableLayoutRowStyleCollection _tableLayoutRowStyleCollection;
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
        public H_Board() {
            _tableLayoutColumnStyleCollection = this.ColumnStyles;
            _tableLayoutRowStyleCollection = this.RowStyles;
            /*
             * ControlIni
             */
            InitializeComponent();
            /*
             * Event
             */
            this.MouseMove += H_Board_MouseMove; // Eventを登録
        }

        /// <summary>
        /// H_TableLayoutPanelExBoard_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_Board_MouseMove(object sender, MouseEventArgs e) {
            /*
             * 左右を自動でスクロールさせる
             * 子コントロール空のイベントからも呼び出されるからScreen座標からForm座標に変換する
             */
            Point point = this.PointToClient(Control.MousePosition);
            int autoScrollPositionX = ((_colWidth * _colCount - this.Size.Width) / 2) + point.X - this.Size.Width / 2;
            int autoScrollPositionY = ((_rowHeight * _rowCount - this.Size.Height) / 2) + point.Y - this.Size.Height / 2;
            this.AutoScrollPosition = new Point(autoScrollPositionX, autoScrollPositionY);
        }

        /// <summary>
        /// OnCellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e) {
            /*
             * Styleを初期化
             * デザイン画面で見たいので、苦肉の策でここに書いた。ここに書くと毎回描画される。
             */
            foreach(ColumnStyle style in _tableLayoutColumnStyleCollection) {
                style.SizeType = SizeType.Absolute;
                style.Width = _colWidth;
            }
            foreach(RowStyle style in _tableLayoutRowStyleCollection) {
                style.SizeType = SizeType.Absolute;
                style.Height = _rowHeight;
            }
        }

        /// <summary>
        /// AddSetControl
        /// </summary>
        /// <param name="hSetControlVo"></param>
        public void AddSetControl(H_SetControlVo hSetControlVo) {
            H_SetControl hSetControl = new H_SetControl(hSetControlVo);
            hSetControl.Event_SetControl_MouseMove += H_Board_MouseMove; // Eventを登録
            this.Controls.Add(hSetControl, hSetControlVo.ColumnNumber, 0);
        }
    }
}
