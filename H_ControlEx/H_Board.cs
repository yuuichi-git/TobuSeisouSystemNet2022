/*
 * 2023-10-19
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_Board : TableLayoutPanel {
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * Cellの数
         */
        private const int _columnCount = 50; // Columnの数
        private const int _rowCount = 4; // Rowの数
        /*
         * 変数定義
         */
        private Point _oldMousePoint;
        private Point _oldAutoScrollPosition;
        /*
         * Cellのサイズ
         */
        private const float _columnWidth = _panelWidth;
        private const float _rowHeight = _panelHeight * _rowCount;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_Board() {
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.AutoScroll = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Name = "H_Board";
            this.Padding = new Padding(0);

            this.ColumnCount = _columnCount;
            for(int i = 0; i < _columnCount; i++)
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _columnWidth));
            this.RowCount = _rowCount;
            for(int i = 0; i < _rowCount; i++)
                this.RowStyles.Add(new RowStyle(SizeType.Absolute, _rowHeight));
            /*
             * Event
             */
            this.MouseDown += H_Board_MouseDown; // Eventを登録
            this.MouseUp += H_Board_MouseUp; // Eventを登録
            this.MouseMove += H_Board_MouseMove; // Eventを登録
        }

        /// <summary>
        /// H_Board_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_Board_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                this._oldMousePoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                this.Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// H_Board_MouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_Board_MouseUp(object sender, MouseEventArgs e) {
            this._oldAutoScrollPosition = this.AutoScrollPosition;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// H_Board_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_Board_MouseMove(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                Point _newMousePoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                int x = this._oldAutoScrollPosition.X + (_newMousePoint.X - this._oldMousePoint.X);
                int y = this._oldAutoScrollPosition.Y + (_newMousePoint.Y - this._oldMousePoint.Y);
                this.AutoScrollPosition = new Point(-x, -y);
            }
        }

        /// <summary>
        /// OnCellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e) {

        }

        /// <summary>
        /// AddSetControl
        /// SetControlを追加する
        /// </summary>
        /// <param name="hSetControlVo"></param>
        public void AddSetControl(H_SetControlVo hSetControlVo) {
            /*
             * 配車用
             */
            H_SetControl hSetControl = new(hSetControlVo);
            hSetControl.Event_SetControl_MouseDown += H_Board_MouseDown; // Eventを登録
            hSetControl.Event_SetControl_MouseUp += H_Board_MouseUp; // Eventを登録
            hSetControl.Event_SetControl_MouseMove += H_Board_MouseMove; // Eventを登録

            this.Controls.Add(hSetControl, GetAddCellPoint(hSetControlVo.CellNumber).X, GetAddCellPoint(hSetControlVo.CellNumber).Y);
            this.SetColumnSpan(hSetControl, hSetControlVo.Purpose ? 2 : 1);
        }

        /// <summary>
        /// GetAddCellPoint
        /// CellNumberをTableLayoutPanelのCell座標に変換する
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        private Point GetAddCellPoint(int cellNumber) {
            return new Point(cellNumber % _columnCount, cellNumber / _columnCount);
        }
    }
}
