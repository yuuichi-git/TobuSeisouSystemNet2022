/*
 * 2023-10-19
 */
using FarPoint.PDF;

using H_Vo;

namespace H_ControlEx {
    public partial class H_Board : TableLayoutPanel {
        /*
         * 変数定義
         */
        private Point _oldMousePoint;
        private Point _oldAutoScrollPosition;
        /*
         * Cellの数
         */
        private const int _columnCount = 40; // Columnの数
        private const int _rowCount = 3; // Rowの数
        /*
         * Cellのサイズ
         */
        private const float _colWidth = 80;
        private const float _rowHeight = 360;

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
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _colWidth));
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
                _oldMousePoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
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
            H_SetControl hSetControl = new(hSetControlVo);
            hSetControl.Event_SetControl_MouseDown += H_Board_MouseDown; // Eventを登録
            hSetControl.Event_SetControl_MouseUp += H_Board_MouseUp; // Eventを登録
            hSetControl.Event_SetControl_MouseMove += H_Board_MouseMove; // Eventを登録
            this.Controls.Add(hSetControl, hSetControlVo.ColumnNumber, hSetControlVo.RowNumber);
            this.SetColumnSpan(hSetControl, hSetControlVo.HSetMasterVo.NumberOfPeople > 2 || hSetControlVo.HSetMasterVo.SpareOfPeople ? 2 : 1); // SetControlが１列用か２列用かを特定する
        }
    }
}
