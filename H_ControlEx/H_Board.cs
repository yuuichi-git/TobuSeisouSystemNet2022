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
            for (int i = 0; i < _columnCount; i++)
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _columnWidth));
            this.RowCount = _rowCount;
            for (int i = 0; i < _rowCount; i++)
                this.RowStyles.Add(new RowStyle(SizeType.Absolute, _rowHeight));
            /*
             * Event
             */
            this.MouseDown += HSetControl_MouseDown; // Eventを登録
            this.MouseUp += HSetControl_MouseUp; // Eventを登録
            this.MouseMove += HSetControl_MouseMove; // Eventを登録
        }

        /// <summary>
        /// AddSetControl
        /// SetControlを追加する
        /// </summary>
        /// <param name="hSetControlVo"></param>
        public void AddSetControl(H_ControlVo hSetControlVo) {
            // インスタンス作成
            H_SetControl hSetControl = new(hSetControlVo);
            /*
             * イベントを登録
             */
            hSetControl.Event_HSetControl_MouseDown += HSetControl_MouseDown;
            hSetControl.Event_HSetControl_MouseUp += HSetControl_MouseUp;
            hSetControl.Event_HSetControl_MouseMove += HSetControl_MouseMove;
            hSetControl.Event_HSetControl_DragEnter += HSetControl_DragEnter;
            hSetControl.Event_HSetControl_DragDrop += HSetControl_DragDrop;
            hSetControl.Event_HSetControl_DragOver += HSetControl_DragOver;
            hSetControl.Event_HSetControl_HSetLabel_MouseClick += HSetLabel_MouseClick;
            hSetControl.Event_HSetControl_HSetLabel_MouseDoubleClick += HSetLabel_MouseDoubleClick;
            hSetControl.Event_HSetControl_HSetLabel_MouseMove += HSetLabel_MouseMove;
            hSetControl.Event_HSetControl_HCarLabel_MouseClick += HCarLabel_MouseClick;
            hSetControl.Event_HSetControl_HCarLabel_MouseDoubleClick += HCarLabel_MouseDoubleClick;
            hSetControl.Event_HSetControl_HCarLabel_MouseMove += HCarLabel_MouseMove;
            hSetControl.Event_HSetControl_HStaffLabel_MouseClick += HStaffLabel_MouseClick;
            hSetControl.Event_HSetControl_HStaffLabel_MouseDoubleClick += HStaffLabel_MouseDoubleClick;
            hSetControl.Event_HSetControl_HStaffLabel_MouseMove += HStaffLabel_MouseMove;
            /*
             * Controlを配置
             */
            this.Controls.Add(hSetControl, GetAddCellPoint(hSetControlVo.CellNumber).X, GetAddCellPoint(hSetControlVo.CellNumber).Y);
            this.SetColumnSpan(hSetControl, hSetControlVo.PurposeFlag ? 2 : 1);
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
        /// HSetControl_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseDown(object sender, MouseEventArgs e) {
            /*
             * スクロール処理
             */
            if (e.Button == MouseButtons.Left) {
                this._oldMousePoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                this.Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// HSetControl_MouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseUp(object sender, MouseEventArgs e) {
            /*
             * スクロール処理
             */
            this._oldAutoScrollPosition = this.AutoScrollPosition;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// HSetControl_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseMove(object sender, MouseEventArgs e) {
            /*
             * スクロール処理
             */
            if (e.Button == MouseButtons.Left) {
                Point _newMousePoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                int x = this._oldAutoScrollPosition.X + (_newMousePoint.X - this._oldMousePoint.X);
                int y = this._oldAutoScrollPosition.Y + (_newMousePoint.Y - this._oldMousePoint.Y);
                this.AutoScrollPosition = new Point(-x, -y);
            }
        }

        /// <summary>
        /// HSetControl_DragEnter
        /// オブジェクトがコントロールの境界内にドラッグされると一度だけ発生します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragEnter(object sender, DragEventArgs e) {
        }

        /// <summary>
        /// HSetControl_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragDrop(object sender, DragEventArgs e) {
            H_SetControl hSetControl = (H_SetControl)sender;
            Point clientPoint = hSetControl.PointToClient(new Point(e.X, e.Y));
            Point cellPoint = new(clientPoint.X / (int)_panelWidth, clientPoint.Y / (int)_panelHeight);
            if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                H_SetLabel dragItem = (H_SetLabel)e.Data.GetData(typeof(H_SetLabel));
                if (e.Effect == DragDropEffects.Copy) {
                    /*
                     * H_StockBoxsにアイテムを残すのでH_SetLabelのコピーを作成
                     */
                    H_ControlVo hControlVo = (H_ControlVo)hSetControl.Tag;
                    hControlVo.HSetMasterVo = (H_SetMasterVo)dragItem.Tag;
                    H_SetLabel hSetLabel = new(hControlVo);
                    hSetLabel.MouseClick += HSetLabel_MouseClick;
                    hSetLabel.MouseDoubleClick += HSetLabel_MouseDoubleClick;
                    hSetLabel.MouseMove += HSetLabel_MouseMove;
                    hSetControl.Controls.Add(hSetLabel, cellPoint.X, cellPoint.Y);
                } else if (e.Effect == DragDropEffects.Move) {
                    hSetControl.Controls.Add(dragItem, cellPoint.X, cellPoint.Y);
                }
            }
            if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                H_CarLabel dragItem = (H_CarLabel)e.Data.GetData(typeof(H_CarLabel));
                hSetControl.Controls.Add(dragItem, cellPoint.X, cellPoint.Y);
            }
            if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                H_StaffLabel dragItem = (H_StaffLabel)e.Data.GetData(typeof(H_StaffLabel));
                hSetControl.Controls.Add(dragItem, cellPoint.X, cellPoint.Y);
            }
        }

        /// <summary>
        /// HSetControl_DragOver
        /// ドラッグ アンド ドロップ操作中にマウス カーソルがコントロールの境界内を移動したときに発生します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragOver(object sender, DragEventArgs e) {
            Point clientPoint = ((H_SetControl)sender).PointToClient(new Point(e.X, e.Y));
            Point cellPoint = new(clientPoint.X / (int)_panelWidth, clientPoint.Y / (int)_panelHeight);
            if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                if (cellPoint.X == 0 && cellPoint.Y == 0) {
                    switch (((H_SetLabel)e.Data.GetData(typeof(H_SetLabel))).Parent.Name) {
                        case "H_SetControl":
                            e.Effect = DragDropEffects.Move;
                            break;
                        case "H_FlowLayoutPanelExBase":
                            e.Effect = DragDropEffects.Copy;
                            break;
                    }
                } else {
                    e.Effect = DragDropEffects.None;
                }
            } else if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                if (cellPoint.X == 0 && cellPoint.Y == 1) {
                    e.Effect = DragDropEffects.Move;
                } else {
                    e.Effect = DragDropEffects.None;
                }
            } else if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                if (cellPoint.Y == 2 || cellPoint.Y == 3) {
                    e.Effect = DragDropEffects.Move;
                } else {
                    e.Effect = DragDropEffects.None;
                }
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// HSetLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetLabel_MouseClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// HSetLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetLabel_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// HSetLabel_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetLabel_MouseMove(object sender, MouseEventArgs e) {
            H_SetLabel hSetLabel = (H_SetLabel)sender;
            H_SetMasterVo hSetMasterVo = (H_SetMasterVo)hSetLabel.Tag;
            if (e.Button == MouseButtons.Left) {
                if (hSetMasterVo.MoveFlag)
                    hSetLabel.DoDragDrop(sender, DragDropEffects.All);
            }
        }

        /// <summary>
        /// HCarLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarLabel_MouseClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// HCarLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarLabel_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// HCarLabel_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarLabel_MouseMove(object sender, MouseEventArgs e) {
            H_CarLabel hCarLabel = (H_CarLabel)sender;
            if (e.Button == MouseButtons.Left)
                hCarLabel.DoDragDrop(sender, DragDropEffects.All);
        }

        /// <summary>
        /// HStaffLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabel_MouseClick(object sender, MouseEventArgs e) {
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                MessageBox.Show("HStaffLabel_MouseClick");
            }
        }

        /// <summary>
        /// HStaffLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            MessageBox.Show("HStaffLabel_MouseDoubleClick");
        }

        /// <summary>
        /// HStaffLabel_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabel_MouseMove(object sender, MouseEventArgs e) {
            H_StaffLabel hStaffLabel = (H_StaffLabel)sender;
            if (e.Button == MouseButtons.Left)
                hStaffLabel.DoDragDrop(sender, DragDropEffects.All);
        }
    }
}
