/*
 * 2023-10-19
 */
using H_Dao;

using Vo;

namespace H_ControlEx {
    public partial class H_Board : TableLayoutPanel {
        /*
         * H_Boardで扱うEventの中でH_VehicleDispatchBoardに公開するもの
         */
        public event MouseEventHandler Event_HBoard_HSetControl_HSetLabel_MouseDoubleClick = delegate { };
        public event EventHandler Event_HBoard_HSetControl_HLabel_ToolStripMenuItem_Click = delegate { };
        /*
         * Dao
         */
        private H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * １つのパネルのサイズ(TableLayoutPanelのCellの事だよ)
         */
        private const float _panelWidth = 75; // 2024-02-24 80→75に変更
        private const float _panelHeight = 120;
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
        /// コンストラクター
        /// </summary>
        public H_Board(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
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
            // 共通Event
            hSetControl.Event_HSetControl_HLabel_ToolStripMenuItem_Click += HSetControl_HLabel_ToolStripMenuItem_Click;
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
        /// Drag元のH_ControlVo
        /// </summary>
        H_ControlVo beforeHControlVo;
        /// <summary>
        /// HSetControl_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragDrop(object sender, DragEventArgs e) {
            // DropされたH_SetControlを退避
            H_SetControl afterHSetControl = (H_SetControl)sender;
            Point clientPoint = afterHSetControl.PointToClient(new Point(e.X, e.Y));
            Point cellPoint = new(clientPoint.X / (int)_panelWidth, clientPoint.Y / (int)_panelHeight);
            /*
             * ①Dragされたオブジェクトを退避
             * ②Drag元のCellNumberを操作する
             * ③Drop先のDBRecordを操作する
             * ④Labelを移動する
             */
            if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                H_SetLabel dragItem = (H_SetLabel)e.Data.GetData(typeof(H_SetLabel));
                // ①Dragされたオブジェクトを退避
                Control beforeParentControl = dragItem.Parent;
                /*
                 * Drag元のCellNumberを退避させておく(DB上からDragデータを削除するのに使用)
                 */
                switch (beforeParentControl.Name) {
                    case "H_SetControl": // (e.Effect == DragDropEffects.Move)
                        beforeHControlVo = (H_ControlVo)beforeParentControl.Tag;
                        /*
                         * H_SetControl間での移動
                         */
                        H_ControlVo afterHControlVoForHSetControl = (H_ControlVo)afterHSetControl.Tag; // H_SetControl上にH_SetLabelが存在していない時のH_ControlVoを取得している
                        afterHControlVoForHSetControl.ConnectionVo = _connectionVo;
                        //afterHControlVoForHSetControl.HBoard = this;
                        //afterHControlVoForHSetControl.HFlowLayoutPanelExStockBoxs
                        //afterHControlVoForHSetControl.CellNumber
                        afterHControlVoForHSetControl.OperationDate = beforeHControlVo.OperationDate;
                        afterHControlVoForHSetControl.OperationFlag = beforeHControlVo.OperationFlag;
                        afterHControlVoForHSetControl.VehicleDispatchFlag = true;
                        //afterHControlVoForHSetControl.PurposeFlag
                        afterHControlVoForHSetControl.HSetMasterVo = (H_SetMasterVo)dragItem.Tag; // DropされたH_SetMasterVoを代入
                        //afterHControlVoForHSetControl.HCarMasterVo
                        //afterHControlVoForHSetControl.HStaffMasterVo

                        // Controlを追加する
                        afterHSetControl.Controls.Add(dragItem, cellPoint.X, cellPoint.Y);
                        break;
                    case "H_FlowLayoutPanelExBase": // (e.Effect == DragDropEffects.Copy)
                        /*
                         * H_StockBoxsからのコピーなのでH_SetLabelのコピーを新規作成
                         */
                        H_ControlVo afterHControlVoForHFlowLayoutPanelExBase = (H_ControlVo)afterHSetControl.Tag; // H_SetControl上にH_SetLabelが存在していない時のH_ControlVoを取得している
                        afterHControlVoForHFlowLayoutPanelExBase.ConnectionVo = _connectionVo;
                        afterHControlVoForHFlowLayoutPanelExBase.OperationFlag = true;
                        afterHControlVoForHFlowLayoutPanelExBase.VehicleDispatchFlag = true;
                        afterHControlVoForHFlowLayoutPanelExBase.HSetMasterVo = (H_SetMasterVo)dragItem.Tag; // DropされたH_SetMasterVoを代入
                        afterHControlVoForHFlowLayoutPanelExBase.HVehicleDispatchDetailVo = null; // このパラメータをNullにしておけばH_SetLabelが新規として作成される
                        H_SetLabel hSetLabel = new(afterHControlVoForHFlowLayoutPanelExBase);
                        hSetLabel.MouseClick += HSetLabel_MouseClick;
                        hSetLabel.MouseDoubleClick += HSetLabel_MouseDoubleClick;
                        hSetLabel.MouseMove += HSetLabel_MouseMove;
                        // Controlを追加する
                        afterHSetControl.Controls.Add(hSetLabel, cellPoint.X, cellPoint.Y);
                        break;

                }
                /*
                 * Drag元の親コントロールを調べる
                 */
                switch (beforeParentControl.Name) {
                    case "H_SetControl": // H_SetControl→H_SetControlへの移動
                        beforeHControlVo = (H_ControlVo)beforeParentControl.Tag;
                        // Drag元のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(((H_SetControl)this.GetControlFromPosition(beforeHControlVo.CellNumber % 50, beforeHControlVo.CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
                        // Drop先のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(afterHSetControl.ConvertHVehicleDispatchDetailVo());
                        break;
                    case "H_FlowLayoutPanelExFree": // H_FlowLayoutPanelExFree→H_SetControlへの移動
                    case "H_FlowLayoutPanelExBase": // H_FlowLayoutPanelExBase→H_SetControlへの移動
                        // Drop先のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(afterHSetControl.ConvertHVehicleDispatchDetailVo());
                        break;
                }
            }
            /*
             * ①Dragされたオブジェクトを退避
             * ②Drag元のCellNumberを操作する
             * ③Drop先のDBRecordを操作する
             * ④Labelを移動する
             */
            if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                H_CarLabel dragItem = (H_CarLabel)e.Data.GetData(typeof(H_CarLabel));
                // ①Dragされたオブジェクトを退避
                Control beforeParentControl = dragItem.Parent;
                afterHSetControl.Controls.Add(dragItem, cellPoint.X, cellPoint.Y);
                /*
                 * Drag元の親コントロールを調べる
                 */
                switch (beforeParentControl.Name) {
                    case "H_SetControl": // H_SetControl→H_SetControlへの移動
                        beforeHControlVo = (H_ControlVo)beforeParentControl.Tag;
                        // Drag元のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(((H_SetControl)this.GetControlFromPosition(beforeHControlVo.CellNumber % 50, beforeHControlVo.CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
                        // Drop先のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(afterHSetControl.ConvertHVehicleDispatchDetailVo());
                        break;
                    case "H_FlowLayoutPanelExFree": // H_FlowLayoutPanelExFree→H_SetControlへの移動
                    case "H_FlowLayoutPanelExBase": // H_FlowLayoutPanelExBase→H_SetControlへの移動
                        // Drop先のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(afterHSetControl.ConvertHVehicleDispatchDetailVo());
                        break;
                }
            }
            /*
             * ①Dragされたオブジェクトを退避
             * ②Drag元のCellNumberを操作する
             * ③Drop先のDBRecordを操作する
             * ④Labelを移動する
             */
            if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                H_StaffLabel dragItem = (H_StaffLabel)e.Data.GetData(typeof(H_StaffLabel));
                // ①Dragされたオブジェクトを退避
                Control beforeParentControl = dragItem.Parent;
                afterHSetControl.Controls.Add(dragItem, cellPoint.X, cellPoint.Y);
                /*
                 * Drag元の親コントロールを調べる
                 */
                switch (beforeParentControl.Name) {
                    case "H_SetControl": // H_SetControl→H_SetControlへの移動
                        beforeHControlVo = (H_ControlVo)beforeParentControl.Tag;
                        // Drag元のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(((H_SetControl)this.GetControlFromPosition(beforeHControlVo.CellNumber % 50, beforeHControlVo.CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
                        // Drop先のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(afterHSetControl.ConvertHVehicleDispatchDetailVo());
                        break;
                    case "H_FlowLayoutPanelExFree": // H_FlowLayoutPanelExFree→H_SetControlへの移動
                    case "H_FlowLayoutPanelExBase": // H_FlowLayoutPanelExBase→H_SetControlへの移動
                        // Drop先のRecordをUpdateする
                        _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(afterHSetControl.ConvertHVehicleDispatchDetailVo());
                        break;
                }
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
            Event_HBoard_HSetControl_HSetLabel_MouseDoubleClick.Invoke(sender, e);
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

        }

        /// <summary>
        /// HStaffLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabel_MouseDoubleClick(object sender, MouseEventArgs e) {

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

        /// <summary>
        /// HSetControl_HStaffLabel_ToolStripMenuItem_Click
        /// 共通Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HLabel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            Event_HBoard_HSetControl_HLabel_ToolStripMenuItem_Click.Invoke(sender, e);
        }
    }
}
