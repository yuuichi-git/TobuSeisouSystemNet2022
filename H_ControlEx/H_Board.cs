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
            hSetControl.Event_HSetControlEx_MouseDown += H_Board_MouseDown;
            hSetControl.Event_HSetControlEx_MouseUp += H_Board_MouseUp;
            hSetControl.Event_HSetControlEx_MouseMove += H_Board_MouseMove;
            hSetControl.Event_HSetControlEx_DragEnter += HSetControlEx_DragEnter;
            hSetControl.Event_HSetControlEx_DragDrop += HSetControlEx_DragDrop;

            hSetControl.Event_HSetLabelEx_MouseClick += HSetLabelEx_MouseClick;
            hSetControl.Event_HSetLabelEx_MouseDoubleClick += HSetLabelEx_MouseDoubleClick;
            hSetControl.Event_HSetLabelEx_MouseMove += HSetLabelEx_MouseMove;

            hSetControl.Event_HCarLabelEx_MouseClick += HCarLabelEx_MouseClick;
            hSetControl.Event_HCarLabelEx_MouseDoubleClick += HCarLabelEx_MouseDoubleClick;
            hSetControl.Event_HCarLabelEx_MouseMove += HCarLabelEx_MouseMove;

            hSetControl.Event_HStaffLabelEx_MouseClick += HStaffLabelEx_MouseClick;
            hSetControl.Event_HStaffLabelEx_MouseDoubleClick += HStaffLabelEx_MouseDoubleClick;
            hSetControl.Event_HStaffLabelEx_MouseMove += HStaffLabelEx_MouseMove;

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

        /*
         * ----------Event----------
         */
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
        /// HSetControlEx_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControlEx_DragEnter(object sender, DragEventArgs e) {
            if(e.Data.GetDataPresent(typeof(H_SetLabel)) || e.Data.GetDataPresent(typeof(H_CarLabel)) || e.Data.GetDataPresent(typeof(H_StaffLabel)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// HSetControlEx_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControlEx_DragDrop(object sender, DragEventArgs e) {
            H_SetControl hSetControl = (H_SetControl)sender;
            Point clientPoint = hSetControl.PointToClient(new Point(e.X, e.Y));
            Point cellPoint = new(0, 0);
            /*
             * 画面座標(X, Y)を、H_SetControl上のクライアント座標に変換する
             */
            switch(clientPoint.X) {
                case int i when i < 80:
                    cellPoint.X = 0;
                    break;
                case int i when i < 160:
                    cellPoint.X = 1;
                    break;
            }
            switch(clientPoint.Y) {
                case int i when i < 100:
                    cellPoint.Y = 0;
                    break;
                case int i when i < 200:
                    cellPoint.Y = 1;
                    break;
                case int i when i < 300:
                    cellPoint.Y = 2;
                    break;
                case int i when i < 400:
                    cellPoint.Y = 3;
                    break;
            }

            if(e.Data.GetDataPresent(typeof(H_SetLabel))) {
                MessageBox.Show("H_SetLabel");
            }
            if(e.Data.GetDataPresent(typeof(H_CarLabel))) {
                MessageBox.Show("H_CarLabel");
            }
            if(e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                MessageBox.Show("H_StaffLabel");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetLabelEx_MouseClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetLabelEx_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// HSetLabelEx_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetLabelEx_MouseMove(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                ((H_SetLabel)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarLabelEx_MouseClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarLabelEx_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarLabelEx_MouseMove(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                ((H_CarLabel)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabelEx_MouseClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabelEx_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabelEx_MouseMove(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                ((H_StaffLabel)sender).DoDragDrop(sender, DragDropEffects.Move);
        }
    }
}
