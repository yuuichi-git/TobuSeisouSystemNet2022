/*
 * 2023-10-12
 */
using H_Common;

using H_ControlEx;

using H_Dao;

using H_RollColl;

using H_Vo;

using StockBox;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
        private readonly Date _date = new();
        /*
         * 変数定義
         */
        private readonly H_FlowLayoutPanelEx _hFlowLayoutPanelExFree;
        private readonly H_Board _hBoard;
        /*
         * Dao
         */
        private readonly H_SetMasterDao _hSetMasterDao;
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_VehicleDispatchHeadDao _hVehicleDispatchHeadDao;
        private readonly H_VehicleDispatchBodyDao _hVehicleDispatchBodyDao;
        private readonly H_VehicleDispatchDao _hVehicleDispatchDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private H_ControlVo _hControlVo;
        private readonly ConnectionVo _connectionVo;
        private readonly List<H_SetMasterVo> _listHSetMasterVo;
        private readonly List<H_CarMasterVo> _listHCarMasterVo;
        private readonly List<H_StaffMasterVo> _listHStaffMasterVo;
        /*
         * DeepCopy
         */
        private List<H_SetMasterVo>? _removeListHSetMasterVo;
        private List<H_CarMasterVo>? _removeListHCarMasterVo;
        private List<H_StaffMasterVo>? _removeListHStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_VehicleDispatchBoard(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hVehicleDispatchHeadDao = new H_VehicleDispatchHeadDao(connectionVo);
            _hVehicleDispatchBodyDao = new(connectionVo);
            _hVehicleDispatchDao = new H_VehicleDispatchDao(connectionVo);
            _hSetMasterDao = new H_SetMasterDao(connectionVo);
            _hCarMasterDao = new H_CarMasterDao(connectionVo);
            _hStaffMasterDao = new H_StaffMasterDao(connectionVo);
            _hVehicleDispatchDetailDao = new H_VehicleDispatchDetailDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _hControlVo = new();
            /*
             * コントロール初期化
             */
            InitializeComponent();

            h_ButtonExLeft1.TextDirectionVertical = "StockBox";

            H_DateTimePickerOperationDate.SetValue(DateTime.Today);
            ToolStripStatusLabelDetail.Text = string.Empty;
            ToolStripProgressBar1.Value = 0;
            /*
             * 関連データを読込む
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMasterForStaffLabel();
            /*
             * Freeゾーンを作成
             */
            _hFlowLayoutPanelExFree = new();
            _hFlowLayoutPanelExFree.AllowDrop = true;
            _hFlowLayoutPanelExFree.BorderStyle = BorderStyle.FixedSingle;
            _hFlowLayoutPanelExFree.Dock = DockStyle.Fill;
            _hFlowLayoutPanelExFree.Margin = new Padding(20, 0, 20, 0);
            _hFlowLayoutPanelExFree.Name = "H_FlowLayoutPanelExFree";
            _hFlowLayoutPanelExFree.Padding = new Padding(1, 0, 1, 0);
            _hFlowLayoutPanelExFree.DragOver += HFlowLayoutPanelExFree_DragOver;
            _hFlowLayoutPanelExFree.DragDrop += HFlowLayoutPanelExFree_DragDrop;
            HTableLayoutPanelExCenter.Controls.Add(_hFlowLayoutPanelExFree, 0, 1);
            /*
             * 配車用ボードを作成
             */
            _hBoard = new H_Board(_connectionVo);
            _hBoard.Event_HBoard_HSetControl_HSetLabel_MouseDoubleClick += HBoard_HSetControl_HSetLabel_MouseDoubleClick;
            HTableLayoutPanelExCenter.Controls.Add(_hBoard, 0, 2);
        }

        /// <summary>
        /// 配車データを作成
        /// VehicleDispatch(Head/Body)から作成
        /// </summary>
        private void CreateVehicleDispatchInitialize() {
            /*
             * ToolStripStatusLabelDetail
             */
            Application.DoEvents();
            ToolStripStatusLabelDetail.Text = "配車表を作成しています・・・・";
            ToolStripProgressBar1.Value = 0;
            StatusStrip1.Update();

            // H_Boardを初期化
            this.HBoardControlRemove(_hBoard);
            int financialYear = _date.GetFiscalYear(H_DateTimePickerOperationDate.GetValue());
            string dayOgWeek = H_DateTimePickerOperationDate.Value.ToString("ddd");
            // H_VehicleDispatchHeadを取得
            List<H_VehicleDispatchHeadVo> listHVehicleDispatchHeadVo = _hVehicleDispatchHeadDao.SelectAllHVehicleDispatchHeadVo(_date.GetFiscalYear());
            // H_VehicleDispatchを取得
            List<H_VehicleDispatchVo> listHVehicleDispatchVo = _hVehicleDispatchDao.SelectHVehicleDispatchVo(financialYear, dayOgWeek);

            double i = 0;
            foreach (H_VehicleDispatchHeadVo hVehicleDispatchHeadVo in listHVehicleDispatchHeadVo.FindAll(x => (x.Purpose == true && x.SetCode != 0) || x.Purpose == false).OrderBy(x => x.CellNumber)) {
                /*
                 * ToolStripStatusLabelDetail
                 */
                ToolStripProgressBar1.Value = (int)Math.Round(i++ / listHVehicleDispatchHeadVo.Count() * 100);
                StatusStrip1.Update();

                _hControlVo = new();
                _hControlVo.ConnectionVo = _connectionVo;
                _hControlVo.OperationDate = H_DateTimePickerOperationDate.Value;
                _hControlVo.CellNumber = hVehicleDispatchHeadVo.CellNumber;
                _hControlVo.VehicleDispatchFlag = hVehicleDispatchHeadVo.VehicleDispatchFlag;
                _hControlVo.PurposeFlag = hVehicleDispatchHeadVo.Purpose;
                /*
                 * 対象日のレコードを抽出
                 * CellNumber
                 * SetCode
                 * CarCode
                 * StaffCode1
                 * StaffCode2
                 * StaffCode3
                 * StaffCode4
                 */
                H_VehicleDispatchVo? hVehicleDispatchVo = listHVehicleDispatchVo.Find(x => x.SetCode == hVehicleDispatchHeadVo.SetCode);
                /*
                 * SetLabel作成
                 * SetCodeがゼロの場合Nullを返す
                 */
                _hControlVo.HSetMasterVo = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchVo?.SetCode);
                /*
                 * CarLabel作成
                 * CarCodeがゼロの場合Nullを返す
                 */
                _hControlVo.HCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchVo?.CarCode);
                /*
                 * StaffLabel作成
                 * Listに入れる順番を保障する必要がある
                 */
                _hControlVo.ListHStaffMasterVo = new();
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode1));
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode2));
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode3));
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode4));
                /*
                 * 配車板の初期化の場合、各LabelのプロパティはDefultで使用するので、Nullを入れておく。
                 */
                _hControlVo.HVehicleDispatchDetailVo = null;

                _hBoard.AddSetControl(_hControlVo);
            }

            /*
             * ToolStripStatusLabelDetail
             */
            ToolStripStatusLabelDetail.Text = "データベースを初期化しています・・・・";
            ToolStripProgressBar1.Value = 100;
            StatusStrip1.Update();

            // DBへ書き込む
            ReadHBoard();

            ToolStripStatusLabelDetail.Text = string.Empty;
            ToolStripProgressBar1.Value = 0;
            StatusStrip1.Update();
        }

        /// <summary>
        /// 配車データを作成
        /// VehicleDispatchDetailから作成
        /// </summary>
        private void CreateVehicleDispatch() {
            /*
             * ToolStripStatusLabelDetail
             */
            Application.DoEvents();
            ToolStripStatusLabelDetail.Text = "配車表を作成しています・・・・";
            ToolStripProgressBar1.Value = 0;
            StatusStrip1.Update();

            // H_Boardを初期化
            this.HBoardControlRemove(_hBoard);
            List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo = _hVehicleDispatchDetailDao.SelectHVehicleDispatchDetail(H_DateTimePickerOperationDate.GetValue());

            double i = 0;
            foreach (H_VehicleDispatchDetailVo hVehicleDispatchDetailVo in listHVehicleDispatchDetailVo) {
                /*
                 * ToolStripStatusLabelDetail
                 */
                ToolStripProgressBar1.Value = (int)Math.Round(i++ / listHVehicleDispatchDetailVo.Count() * 100);
                StatusStrip1.Update();
                /*
                 * H_ControlVoを作成する
                 */
                _hControlVo = new();
                _hControlVo.ConnectionVo = _connectionVo;
                _hControlVo.CellNumber = hVehicleDispatchDetailVo.CellNumber;
                _hControlVo.OperationDate = H_DateTimePickerOperationDate.GetValue();
                _hControlVo.OperationFlag = hVehicleDispatchDetailVo.OperationFlag;
                _hControlVo.PurposeFlag = hVehicleDispatchDetailVo.PurposeFlag;
                _hControlVo.VehicleDispatchFlag = hVehicleDispatchDetailVo.VehicleDispatchFlag;
                /*
                 * SetLabel作成
                 * SetCodeがゼロの場合Nullを返す
                 */
                _hControlVo.HSetMasterVo = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode);
                /*
                 * CarLabel作成
                 * CarCodeがゼロの場合Nullを返す
                 */
                _hControlVo.HCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchDetailVo.CarCode);
                /*
                 * StaffLabel作成
                 * Listに入れる順番を保障する必要がある
                 */
                _hControlVo.ListHStaffMasterVo = new();
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode1));
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode2));
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode3));
                _hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode4));
                /*
                 * 配車板の初期化の場合、各LabelのプロパティはDefultで使用するので、Nullを入れておく。
                 */
                _hControlVo.HVehicleDispatchDetailVo = hVehicleDispatchDetailVo;

                _hBoard.AddSetControl(_hControlVo);
            }

            /*
             * ToolStripStatusLabelDetail
             */
            ToolStripStatusLabelDetail.Text = string.Empty;
            ToolStripProgressBar1.Value = 0;
            StatusStrip1.Update();
        }

        /// <summary>
        /// H_Boardの子コントロールを走査・取得・解析する HVehicleDispatchDetailVo
        /// </summary>
        private void ReadHBoard() {
            List<H_VehicleDispatchDetailVo> _listHVehicleDispatchDetailVo = new();
            foreach (H_SetControl hSetControl in _hBoard.Controls) {
                _listHVehicleDispatchDetailVo.Add(hSetControl.ConvertHVehicleDispatchDetailVo());
            }
            try {
                _hVehicleDispatchDetailDao.DeleteHVehicleDispatchDetail(H_DateTimePickerOperationDate.GetValue());
                _hVehicleDispatchDetailDao.InsertHVehicleDispatchDetail(_listHVehicleDispatchDetailVo);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// GetHStaffMasterVo
        /// List<H_StaffMasterVo>からH_StaffMasterVoを抽出する
        /// </summary>
        /// <param name="listHStaffMasterVo"></param>
        /// <returns></returns>
        private H_StaffMasterVo GetHStaffMasterVo(List<H_StaffMasterVo> listHStaffMasterVo, int? staffCode) {
            H_StaffMasterVo? hStaffMasterVo = new();
            hStaffMasterVo = listHStaffMasterVo.Find(x => x.StaffCode == staffCode);
            if (hStaffMasterVo is not null) {
                // 検索で見つかったVoを返す
                return hStaffMasterVo;
            } else {
                // StaffCodeがゼロ(存在しない)を返す
                return new H_StaffMasterVo();
            }
        }

        /// <summary>
        /// HBoardControlRemove
        /// </summary>
        /// <param name="hBoard"></param>
        private void HBoardControlRemove(H_Board hBoard) {
            /*
             * メソッドをClear呼び出してもコントロール ハンドルはメモリから削除されません。 メモリリークを回避するにはメソッドをDispose明示的に呼び出す必要があります。
             * ※後ろから解放している点が重要らしい。
             */
            for (int i = hBoard.Controls.Count - 1; 0 <= i; i--)
                hBoard.Controls[i].Dispose();
        }

        private H_StockBoxs? hStockBoxs = null;
        /// <summary>
        /// HButtonEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonEx_Click(object sender, EventArgs e) {
            switch (((H_ButtonEx)sender).Name) {
                case "h_ButtonExUpdate":
                    this.CreateVehicleDispatch();
                    break;
                case "h_ButtonExLeft1":
                    if (hStockBoxs is null || hStockBoxs.IsDisposed) {
                        /*
                         * H_ControlVoを作成する
                         * H_FlowLayoutPanelExFreeに置いてあるLabelも計算してね
                         */
                        _hControlVo = new();
                        _hControlVo.ConnectionVo = _connectionVo;
                        _hControlVo.HBoard = _hBoard;
                        _hControlVo.HFlowLayoutPanelExStockBoxs = _hFlowLayoutPanelExFree;
                        _hControlVo.OperationDate = H_DateTimePickerOperationDate.GetValue();
                        _hControlVo.ListHSetMasterVo = _listHSetMasterVo;
                        _hControlVo.ListHCarMasterVo = _listHCarMasterVo;
                        _hControlVo.ListHStaffMasterVo = _listHStaffMasterVo;
                        _hControlVo.HVehicleDispatchDetailVo = null;
                        /*
                         * Formを作成する
                         */
                        hStockBoxs = new(_hControlVo);
                        Rectangle rectangle = new Desktop().GetMonitorWorkingArea(hStockBoxs, _connectionVo.Screen);
                        hStockBoxs.Location = new Point(rectangle.X + 100, rectangle.Y + 100);
                        hStockBoxs.WindowState = FormWindowState.Normal;
                        hStockBoxs.Show(this);
                    } else {
                        MessageBox.Show("このプログラム（H_StockBoxs）は、既に起動しています。多重起動は禁止されています。", "多重起動メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "h_ButtonExLeft2":
                    break;
                case "h_ButtonExLeft3":
                    break;
                case "h_ButtonExLeft4":
                    break;
                case "h_ButtonExLeft5":
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 配車を初期化する(清掃事務所登録)
                 */
                case "ToolStripMenuItemInitializeVehicleDispatchBody":
                    // _hFlowLayoutPanelExFreeを初期化
                    _hFlowLayoutPanelExFree.Controls.Clear();
                    this.CreateVehicleDispatchInitialize();
                    break;
                /*
                 * 配車を初期化する(前日の配車をコピー)
                 */
                case "ToolStripMenuItemInitializeVehicleDispatchCopy":
                    MessageBox.Show("ToolStripMenuItemInitializeVehicleDispatchCopy");
                    break;
                /*
                 * この配車組を 'H_VehicleDispatchBody' に登録する
                 */
                case "ToolStripMenuItemUpdateVehicleDispatchBody":
                    /*
                     * ダイアログを表示
                     */
                    H_VehicleDispatchEdit hVehicleDispatchEdit = new(H_DateTimePickerOperationDate.GetValue());
                    hVehicleDispatchEdit.StartPosition = FormStartPosition.CenterParent;
                    if (hVehicleDispatchEdit.ShowDialog(this) == DialogResult.OK) {
                        foreach (H_SetControl hSetControl in _hBoard.Controls) {
                            H_VehicleDispatchBodyVo hVehicleDispatchBodyVo = new();
                            hVehicleDispatchBodyVo.SetCode = hSetControl.GetSetMasterVo() is not null ? hSetControl.GetSetMasterVo().SetCode : 0;
                            hVehicleDispatchBodyVo.DayOfWeek = H_DateTimePickerOperationDate.GetValue().ToString("ddd");
                            hVehicleDispatchBodyVo.CarCode = hSetControl.GetCarMasterVo() is not null ? hSetControl.GetCarMasterVo().CarCode : 0;
                            switch (((H_ControlVo)hSetControl.Tag).PurposeFlag) {
                                case true: // ２列
                                    hVehicleDispatchBodyVo.StaffCode1 = hSetControl.GetStaffMasterVo(0) is not null ? hSetControl.GetStaffMasterVo(0).StaffCode : 0;
                                    hVehicleDispatchBodyVo.StaffCode2 = hSetControl.GetStaffMasterVo(1) is not null ? hSetControl.GetStaffMasterVo(1).StaffCode : 0;
                                    hVehicleDispatchBodyVo.StaffCode3 = hSetControl.GetStaffMasterVo(2) is not null ? hSetControl.GetStaffMasterVo(2).StaffCode : 0;
                                    hVehicleDispatchBodyVo.StaffCode4 = hSetControl.GetStaffMasterVo(3) is not null ? hSetControl.GetStaffMasterVo(3).StaffCode : 0;
                                    break;
                                case false: // １列
                                    hVehicleDispatchBodyVo.StaffCode1 = hSetControl.GetStaffMasterVo(0) is not null ? hSetControl.GetStaffMasterVo(0).StaffCode : 0;
                                    hVehicleDispatchBodyVo.StaffCode2 = hSetControl.GetStaffMasterVo(1) is not null ? hSetControl.GetStaffMasterVo(1).StaffCode : 0;
                                    hVehicleDispatchBodyVo.StaffCode3 = 0;
                                    hVehicleDispatchBodyVo.StaffCode4 = 0;
                                    break;
                            }
                            hVehicleDispatchBodyVo.FinancialYear = _date.GetFiscalYear(H_DateTimePickerOperationDate.GetValue());
                            /*
                             * DB更新
                             */
                            if (_hVehicleDispatchBodyDao.ExistenceHVehicleDispatchBodyVo(hSetControl.GetSetMasterVo() is not null ? hSetControl.GetSetMasterVo().SetCode : 0, H_DateTimePickerOperationDate.GetValue().ToString("ddd"))) {
                                // Recordが存在する　UPDATE
                                try {
                                    _hVehicleDispatchBodyDao.UpdateOneHVehicleDispatchBodyVo(hVehicleDispatchBodyVo);
                                } catch (Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                            } else {
                                // Recordが存在しない　INSERT
                                try {
                                    _hVehicleDispatchBodyDao.InsertOneHVehicleDispatchBodyVo(hVehicleDispatchBodyVo);
                                } catch (Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                            }
                        }
                        MessageBox.Show("更新されました", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("更新がキャンセルされました", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    hVehicleDispatchEdit.Dispose();
                    break;
                /*
                 * B4で印刷する
                 */
                case "ToolStripMenuItemPrintB4":
                    MessageBox.Show("ToolStripMenuItemPrintB4");
                    break;
                /*
                 * 終了処理
                 */
                case "ToolStripMenuItemExit":
                    MessageBox.Show("ToolStripMenuItemExit");
                    break;
            }
        }

        /// <summary>
        /// HFlowLayoutPanelExFree_DragOver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HFlowLayoutPanelExFree_DragOver(object sender, DragEventArgs e) {
            if (e.Data is not null) {
                /*
                 * SetLabelはDropを禁止する
                 * CarLabelはDropを許可する
                 * StaffLabelはDropを許可する
                 */
                if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                    e.Effect = DragDropEffects.None;
                } else if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                    e.Effect = DragDropEffects.Move;
                } else if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        /// <summary>
        /// HFlowLayoutPanelExFree_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HFlowLayoutPanelExFree_DragDrop(object sender, DragEventArgs e) {
            if (e.Data is not null) {
                if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                    ToolStripStatusLabelDetail.Text = "H_SetLabelはここへは移動出来ません。";
                    return;
                } else if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                    H_CarLabel dragItem = (H_CarLabel)e.Data.GetData(typeof(H_CarLabel));
                    // Drag元の親Controlを退避
                    Control beforeParentControl = dragItem.Parent;
                    ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                    /*
                     * Drag元の親コントロールを調べる
                     */
                    switch (beforeParentControl.Name) {
                        case "H_SetControl":
                            // Drag元のRecordをUpdateする
                            _hVehicleDispatchDetailDao.UpdateHVehicleDispatchDetail(((H_SetControl)_hBoard.GetControlFromPosition(((H_ControlVo)beforeParentControl.Tag).CellNumber % 50, ((H_ControlVo)beforeParentControl.Tag).CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
                            break;
                        default:
                            break;
                    }
                } else if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                    H_StaffLabel dragItem = (H_StaffLabel)e.Data.GetData(typeof(H_StaffLabel));
                    // Drag元の親Controlを退避
                    Control beforeParentControl = dragItem.Parent;
                    // DragItemをDrop先へ移動
                    ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                    /*
                     * Drag元の親コントロールを調べる
                     */
                    switch (beforeParentControl.Name) {
                        case "H_SetControl":
                            // Drag元のRecordをUpdateする
                            _hVehicleDispatchDetailDao.UpdateHVehicleDispatchDetail(((H_SetControl)_hBoard.GetControlFromPosition(((H_ControlVo)beforeParentControl.Tag).CellNumber % 50, ((H_ControlVo)beforeParentControl.Tag).CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// HBoard_HSetControl_HSetLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HBoard_HSetControl_HSetLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            int setCode = ((H_SetMasterVo)((H_SetLabel)sender).Tag).SetCode;
            DateTime dateTime = H_DateTimePickerOperationDate.GetValue();
            H_LastRollCall hLastRollCall = new(_connectionVo, setCode, dateTime);
            hLastRollCall.Show(this);
        }
    }
}
