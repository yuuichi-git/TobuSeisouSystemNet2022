/*
 * 2023-10-12
 */
using H_CollectionWeight;

using H_Common;

using H_ControlEx;

using H_Dao;

using H_RollColl;

using H_Staff;

using Vo;

using StockBox;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
        private readonly Date _date = new();
        /*
         * 変数定義
         */
        private readonly H_FlowLayoutPanelEx _hFlowLayoutPanelExFree;
        private readonly H_Board _hBoard;
        /// <summary>
        /// _hFlowLayoutPanelExFreeをクリアするタイミングを保持する
        /// true:変更された false:変更されていない
        /// </summary>
        private bool _changeDateFlag = false;
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
             * ControlButtonを初期化
             */
            HButtonExLeft1.TextDirectionVertical = "StockBox";

            HDateTimePickerOperationDate.SetValue(DateTime.Today);
            ToolStripStatusLabelDetail.Text = string.Empty;
            ToolStripProgressBar1.Value = 0;
            /*
             * 関連データを読込む
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMaster();
            /*
             * 配車用ボードを作成
             */
            _hBoard = new H_Board(_connectionVo);
            _hBoard.Event_HBoard_HSetControl_HSetLabel_MouseDoubleClick += HBoard_HSetControl_HSetLabel_MouseDoubleClick;
            _hBoard.Event_HBoard_HSetControl_HLabel_ToolStripMenuItem_Click += HBoard_HSetControl_HLabel_ToolStripMenuItem_Click;
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
            int financialYear = _date.GetFiscalYear(HDateTimePickerOperationDate.GetValue());
            string dayOgWeek = HDateTimePickerOperationDate.Value.ToString("ddd");
            // H_VehicleDispatchHeadを取得
            List<H_VehicleDispatchHeadVo> listHVehicleDispatchHeadVo = _hVehicleDispatchHeadDao.SelectAllHVehicleDispatchHeadVo(financialYear);
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
                _hControlVo.OperationDate = HDateTimePickerOperationDate.Value;
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
            /*
             * _hFlowLayoutPanelExFreeを初期化
             */
            if (_changeDateFlag) {
                for (int _hFlowLayoutPanelExFreeControlCount = _hFlowLayoutPanelExFree.Controls.Count - 1; 0 <= _hFlowLayoutPanelExFreeControlCount; _hFlowLayoutPanelExFreeControlCount--) {
                    _hFlowLayoutPanelExFree.Controls[_hFlowLayoutPanelExFreeControlCount].Dispose();
                }
                // 変更後、Flagを戻す
                _changeDateFlag = false;
            }

            // H_Boardを初期化
            this.HBoardControlRemove(_hBoard);

            List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo = _hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(HDateTimePickerOperationDate.GetValue());
            double progressBarCount = 0;
            foreach (H_VehicleDispatchDetailVo hVehicleDispatchDetailVo in listHVehicleDispatchDetailVo) {
                /*
                 * ToolStripStatusLabelDetail
                 */
                ToolStripProgressBar1.Value = (int)Math.Round(progressBarCount++ / listHVehicleDispatchDetailVo.Count() * 100);
                StatusStrip1.Update();
                /*
                 * H_ControlVoを作成する
                 */
                _hControlVo = new();
                _hControlVo.ConnectionVo = _connectionVo;
                _hControlVo.CellNumber = hVehicleDispatchDetailVo.CellNumber;
                _hControlVo.OperationDate = HDateTimePickerOperationDate.GetValue();
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
                _hVehicleDispatchDetailDao.DeleteHVehicleDispatchDetail(HDateTimePickerOperationDate.GetValue());
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

        private H_StockBoxs hStockBoxs = null;
        /// <summary>
        /// HButtonEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonEx_Click(object sender, EventArgs e) {
            switch (((H_ButtonEx)sender).Name) {
                case "HButtonExUpdate":
                    this.CreateVehicleDispatch();
                    break;
                case "HButtonExLeft1":
                    if (hStockBoxs is null || hStockBoxs.IsDisposed) {
                        /*
                         * H_ControlVoを作成する
                         * H_FlowLayoutPanelExFreeに置いてあるLabelも計算してね
                         */
                        _hControlVo = new();
                        _hControlVo.ConnectionVo = _connectionVo;
                        _hControlVo.HBoard = _hBoard;
                        _hControlVo.HFlowLayoutPanelExStockBoxs = _hFlowLayoutPanelExFree;
                        _hControlVo.OperationDate = HDateTimePickerOperationDate.GetValue();
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
            DialogResult dialogResult;
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 配車を初期化する(清掃事務所登録)
                 */
                case "ToolStripMenuItemInitializeVehicleDispatchBody":
                    if (_hVehicleDispatchDetailDao.ExistenceHVehicleDispatchDetail(HDateTimePickerOperationDate.GetValue())) {
                        dialogResult = MessageBox.Show("対象日の配車データが存在します。本番登録で初期化してもよろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        switch (dialogResult) {
                            case DialogResult.Cancel:
                                return;
                        }
                    } else {
                        dialogResult = MessageBox.Show("本番登録で初期化してもよろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        switch (dialogResult) {
                            case DialogResult.Cancel:
                                return;
                        }
                    }
                    /*
                     * _hFlowLayoutPanelExFreeを初期化
                     */
                    for (int i = _hFlowLayoutPanelExFree.Controls.Count - 1; 0 <= i; i--)
                        _hFlowLayoutPanelExFree.Controls[i].Dispose();
                    // 配車を初期化
                    this.CreateVehicleDispatchInitialize();
                    MessageBox.Show("処理が終了しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                /*
                 * 配車を初期化する(前日の配車をコピー)
                 * ※初期化の条件 → 本番で初期化されていること。
                 */
                case "ToolStripMenuItemInitializeVehicleDispatchCopy":
                    /*
                     * H_VehicleDispatchDetailの対象日レコードを前日(前営業日)のコピーで初期化
                     * 前営業日のデータをDeepCopyして必要なカラムだけ書き換える
                     */
                    DateTime beforeDate = HDateTimePickerOperationDate.GetValue().Date;
                    // どうやらAddDaysは新しいインスタンスを作成するらしい。だから入れ物も別で用意しとかないと
                    DateTime beforeDateTime = new();
                    switch (beforeDate.ToString("ddd")) {
                        case "日":
                            beforeDateTime = beforeDate.AddDays(-7); // 先週の日曜日
                            break;
                        case "月":
                            beforeDateTime = beforeDate.AddDays(-2); // 先週の土曜日
                            break;
                        case "火":
                        case "水":
                        case "木":
                        case "金":
                        case "土":
                            beforeDateTime = beforeDate.AddDays(-1); // 前日
                            break;
                    }

                    if (_hVehicleDispatchDetailDao.ExistenceHVehicleDispatchDetail(HDateTimePickerOperationDate.GetValue())) {
                        dialogResult = MessageBox.Show(string.Concat("対象日の配車データが存在します。 ", beforeDateTime.ToString("yyyy/MM/dd"), " の配車データで初期化(従業員のみコピー複製)してもよろしいですか？"), "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        switch (dialogResult) {
                            case DialogResult.Cancel:
                                return;
                        }
                    } else {
                        MessageBox.Show("本番登録で初期化した後にもう一度実行して下さい。", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        return;
                    }

                    // 前営業日のデータをDeepCopyする
                    List<H_VehicleDispatchDetailVo> listBeforeHVehicleDispatchDetailVo = new CopyUtility().DeepCopy(_hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(beforeDateTime.Date));
                    // DB操作
                    foreach (H_VehicleDispatchDetailVo beforeHVehicleDispatchDetailVo in listBeforeHVehicleDispatchDetailVo.FindAll(x => x.ClassificationCode == 10 || x.ClassificationCode == 11 || x.ClassificationCode == 20).OrderBy(x => x.CellNumber)) {
                        // 運賃コードを取得
                        H_VehicleDispatchDetailVo hVehicleDispatchDetailVo = new();
                        hVehicleDispatchDetailVo.CellNumber = beforeHVehicleDispatchDetailVo.CellNumber;
                        hVehicleDispatchDetailVo.OperationDate = HDateTimePickerOperationDate.GetValue().Date;
                        /*
                         * 配車先が清掃工場の場合,値を代入。清掃工場(大G)はCopyの対象とする
                         */
                        if (beforeHVehicleDispatchDetailVo.ClassificationCode == 20) {
                            hVehicleDispatchDetailVo.OperationFlag = beforeHVehicleDispatchDetailVo.OperationFlag;
                            hVehicleDispatchDetailVo.VehicleDispatchFlag = beforeHVehicleDispatchDetailVo.VehicleDispatchFlag;
                            hVehicleDispatchDetailVo.PurposeFlag = beforeHVehicleDispatchDetailVo.PurposeFlag;
                            hVehicleDispatchDetailVo.SetCode = beforeHVehicleDispatchDetailVo.SetCode;
                            hVehicleDispatchDetailVo.ManagedSpaceCode = beforeHVehicleDispatchDetailVo.ManagedSpaceCode;
                            hVehicleDispatchDetailVo.ClassificationCode = beforeHVehicleDispatchDetailVo.ClassificationCode;
                        }
                        //hVehicleDispatchDetailVo.LastRollCallFlag = false;
                        //hVehicleDispatchDetailVo.LastRollCallYmdHms = _defaultDateTime;
                        //hVehicleDispatchDetailVo.SetMemoFlag = beforeHVehicleDispatchDetailVo.SetMemoFlag;
                        //hVehicleDispatchDetailVo.SetMemo = beforeHVehicleDispatchDetailVo.SetMemo;
                        //hVehicleDispatchDetailVo.ShiftCode = beforeHVehicleDispatchDetailVo.ShiftCode;
                        //hVehicleDispatchDetailVo.StandByFlag = beforeHVehicleDispatchDetailVo.StandByFlag;
                        //hVehicleDispatchDetailVo.AddWorkerFlag = beforeHVehicleDispatchDetailVo.AddWorkerFlag;
                        //hVehicleDispatchDetailVo.ContactInfomationFlag = false;
                        //hVehicleDispatchDetailVo.FaxTransmissionFlag = false;
                        hVehicleDispatchDetailVo.CarCode = beforeHVehicleDispatchDetailVo.CarCode;
                        hVehicleDispatchDetailVo.CarGarageCode = beforeHVehicleDispatchDetailVo.CarGarageCode;
                        hVehicleDispatchDetailVo.CarProxyFlag = beforeHVehicleDispatchDetailVo.CarProxyFlag;
                        hVehicleDispatchDetailVo.CarMemoFlag = beforeHVehicleDispatchDetailVo.CarMemoFlag;
                        hVehicleDispatchDetailVo.CarMemo = beforeHVehicleDispatchDetailVo.CarMemo;
                        hVehicleDispatchDetailVo.StaffCode1 = beforeHVehicleDispatchDetailVo.StaffCode1;
                        hVehicleDispatchDetailVo.StaffOccupation1 = beforeHVehicleDispatchDetailVo.StaffOccupation1;
                        hVehicleDispatchDetailVo.StaffProxyFlag1 = beforeHVehicleDispatchDetailVo.StaffProxyFlag1;
                        //hVehicleDispatchDetailVo.StaffRollCallFlag1 = false;
                        //hVehicleDispatchDetailVo.StaffRollCallYmdHms1 = _defaultDateTime;
                        hVehicleDispatchDetailVo.StaffMemoFlag1 = beforeHVehicleDispatchDetailVo.StaffMemoFlag1;
                        hVehicleDispatchDetailVo.StaffMemo1 = beforeHVehicleDispatchDetailVo.StaffMemo1;
                        hVehicleDispatchDetailVo.StaffCode2 = beforeHVehicleDispatchDetailVo.StaffCode2;
                        hVehicleDispatchDetailVo.StaffOccupation2 = beforeHVehicleDispatchDetailVo.StaffOccupation2;
                        hVehicleDispatchDetailVo.StaffProxyFlag2 = beforeHVehicleDispatchDetailVo.StaffProxyFlag2;
                        //hVehicleDispatchDetailVo.StaffRollCallFlag2 = false;
                        //hVehicleDispatchDetailVo.StaffRollCallYmdHms2 = _defaultDateTime;
                        hVehicleDispatchDetailVo.StaffMemoFlag2 = beforeHVehicleDispatchDetailVo.StaffMemoFlag2;
                        hVehicleDispatchDetailVo.StaffMemo2 = beforeHVehicleDispatchDetailVo.StaffMemo2;
                        hVehicleDispatchDetailVo.StaffCode3 = beforeHVehicleDispatchDetailVo.StaffCode3;
                        hVehicleDispatchDetailVo.StaffOccupation3 = beforeHVehicleDispatchDetailVo.StaffOccupation3;
                        hVehicleDispatchDetailVo.StaffProxyFlag3 = beforeHVehicleDispatchDetailVo.StaffProxyFlag3;
                        //hVehicleDispatchDetailVo.StaffRollCallFlag3 = false;
                        //hVehicleDispatchDetailVo.StaffRollCallYmdHms3 = _defaultDateTime;
                        hVehicleDispatchDetailVo.StaffMemoFlag3 = beforeHVehicleDispatchDetailVo.StaffMemoFlag3;
                        hVehicleDispatchDetailVo.StaffMemo3 = beforeHVehicleDispatchDetailVo.StaffMemo3;
                        hVehicleDispatchDetailVo.StaffCode4 = beforeHVehicleDispatchDetailVo.StaffCode4;
                        hVehicleDispatchDetailVo.StaffOccupation4 = beforeHVehicleDispatchDetailVo.StaffOccupation4;
                        hVehicleDispatchDetailVo.StaffProxyFlag4 = beforeHVehicleDispatchDetailVo.StaffProxyFlag4;
                        //hVehicleDispatchDetailVo.StaffRollCallFlag4 = false;
                        //hVehicleDispatchDetailVo.StaffRollCallYmdHms4 = _defaultDateTime;
                        hVehicleDispatchDetailVo.StaffMemoFlag4 = beforeHVehicleDispatchDetailVo.StaffMemoFlag4;
                        hVehicleDispatchDetailVo.StaffMemo4 = beforeHVehicleDispatchDetailVo.StaffMemo4;
                        hVehicleDispatchDetailVo.UpdatePcName = Environment.MachineName;
                        hVehicleDispatchDetailVo.UpdateYmdHms = DateTime.Now;
                        hVehicleDispatchDetailVo.DeleteFlag = false;
                        /*
                         * DBを更新
                         */
                        try {
                            _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetailCopy(hVehicleDispatchDetailVo);
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    MessageBox.Show("処理が終了しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                /*
                 * 台東古紙　収集実績入力
                 */
                case "ToolStripMenuItemInputTAITOU":
                    HCollectionWeightTAITOU hCollectionWeightTAITOU = new(_connectionVo);
                    hCollectionWeightTAITOU.Size = new Size(500, 450);
                    new Desktop().SetPosition(hCollectionWeightTAITOU, _connectionVo.Screen);
                    hCollectionWeightTAITOU.ShowDialog(this);
                    break;
                /*
                 * この配車組を 'H_VehicleDispatchBody' に登録する
                 */
                case "ToolStripMenuItemUpdateVehicleDispatchBody":
                    dialogResult = MessageBox.Show("本番として登録してもしてもよろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.Cancel:
                            return;
                    }
                    /*
                     * ダイアログを表示
                     */
                    H_VehicleDispatchEdit hVehicleDispatchEdit = new(HDateTimePickerOperationDate.GetValue());
                    hVehicleDispatchEdit.StartPosition = FormStartPosition.CenterParent;
                    if (hVehicleDispatchEdit.ShowDialog(this) == DialogResult.OK) {
                        foreach (H_SetControl hSetControl in _hBoard.Controls) {
                            /*
                             * H_VehicleDispatchHeadに存在しないSetCodeはH_VehicleDispatchBodyを更新しない（固定の配車先ではないので）
                             */
                            H_VehicleDispatchBodyVo hVehicleDispatchBodyVo = new();
                            hVehicleDispatchBodyVo.SetCode = hSetControl.GetSetMasterVo() is not null ? hSetControl.GetSetMasterVo().SetCode : 0;
                            hVehicleDispatchBodyVo.DayOfWeek = HDateTimePickerOperationDate.GetValue().ToString("ddd");
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
                            hVehicleDispatchBodyVo.FinancialYear = _date.GetFiscalYear(HDateTimePickerOperationDate.GetValue());
                            /*
                             * DB更新
                             */
                            if (_hVehicleDispatchBodyDao.ExistenceHVehicleDispatchBodyVo(hSetControl.GetSetMasterVo() is not null ? hSetControl.GetSetMasterVo().SetCode : 0,
                                                                                         HDateTimePickerOperationDate.GetValue().ToString("ddd"),
                                                                                         _date.GetFiscalYear(HDateTimePickerOperationDate.GetValue().Date))) {
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
                    MessageBox.Show("処理が終了しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                /*
                 * B4で印刷する
                 */
                case "ToolStripMenuItemPrintB4":

                    break;
                /*
                 * 終了処理
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
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
                            _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(((H_SetControl)_hBoard.GetControlFromPosition(((H_ControlVo)beforeParentControl.Tag).CellNumber % 50, ((H_ControlVo)beforeParentControl.Tag).CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
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
                            _hVehicleDispatchDetailDao.UpdateOneHVehicleDispatchDetail(((H_SetControl)_hBoard.GetControlFromPosition(((H_ControlVo)beforeParentControl.Tag).CellNumber % 50, ((H_ControlVo)beforeParentControl.Tag).CellNumber / 50)).ConvertHVehicleDispatchDetailVo());
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
            H_SetLabel hSetLabel = (H_SetLabel)sender;
            int cellNumber = ((H_ControlVo)((H_SetControl)((H_SetLabel)sender).Parent).Tag).CellNumber;
            int setCode = ((H_SetMasterVo)((H_SetLabel)sender).Tag).SetCode;
            H_LastRollCall hLastRollCall = new(_connectionVo, hSetLabel, cellNumber, setCode, HDateTimePickerOperationDate.GetValue());
            hLastRollCall.ShowDialog(this);

        }

        /// <summary>
        /// HBoard_HSetControl_HLabel_ToolStripMenuItem_Click
        /// 各ControlからのEventを処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HBoard_HSetControl_HLabel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 
                 * SetLabelからのEvent
                 * 
                 */
                case "ToolStripMenuItemSetDetail": // 配車先の情報を表示する
                    MessageBox.Show("ToolStripMenuItemSetDetail");
                    break;
                case "ToolStripMenuItemSetMemo": // メモを作成・編集する
                    H_Memo hSetMemo = new(_connectionVo, (H_SetControl)((H_SetLabel)contextMenuStrip.SourceControl).Parent, (H_SetLabel)contextMenuStrip.SourceControl);
                    hSetMemo.Size = new Size(540, 180);
                    new Desktop().SetPosition(hSetMemo, _connectionVo.Screen);
                    hSetMemo.Show();
                    break;
                case "ToolStripMenuItemCreateFax": // 代車・代番Faxを作成する
                    H_Substitute hSubstitute = new(_connectionVo, (H_SetControl)((H_SetLabel)contextMenuStrip.SourceControl).Parent);
                    Rectangle rectangleHSubstitute = new Desktop().GetMonitorWorkingArea(hSubstitute, _connectionVo.Screen);
                    hSubstitute.KeyPreview = true;
                    hSubstitute.Location = rectangleHSubstitute.Location;
                    hSubstitute.Size = new Size(850, 1080);
                    hSubstitute.WindowState = FormWindowState.Normal;
                    hSubstitute.Show(this);
                    break;
                /*
                 * 
                 * CarLabelからのEvent
                 * 
                 */
                case "ToolStripMenuItemCarDetail": // 車両台帳を表示する
                    MessageBox.Show("ToolStripMenuItemCarDetail");
                    break;
                case "ToolStripMenuItemCarMemo": // メモを作成・編集する
                    H_Memo hCarMemo = new(_connectionVo, (H_SetControl)((H_CarLabel)contextMenuStrip.SourceControl).Parent, (H_CarLabel)contextMenuStrip.SourceControl);
                    hCarMemo.Size = new Size(540, 180);
                    new Desktop().SetPosition(hCarMemo, _connectionVo.Screen);
                    hCarMemo.Show();
                    break;
                case "ToolStripMenuItemCarNippou": // 日報を作成する
                    MessageBox.Show("ToolStripMenuItemCarNippou");
                    break;
                /*
                 * 
                 * StaffLabelからのEvent
                 * 
                 */
                case "ToolStripMenuItemStaffDetail": // 従事者台帳を表示する
                    H_StaffLabel hStaffLabel = (H_StaffLabel)contextMenuStrip.SourceControl;
                    H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)hStaffLabel.Tag;
                    HStaffPaper hStaffPaper = new(_connectionVo, hStaffMasterVo.StaffCode);
                    Rectangle rectangleHStaffPaper = new Desktop().GetMonitorWorkingArea(hStaffPaper, _connectionVo.Screen);
                    hStaffPaper.KeyPreview = true;
                    hStaffPaper.Location = rectangleHStaffPaper.Location;
                    hStaffPaper.Size = new Size(1920, 1080);
                    hStaffPaper.WindowState = FormWindowState.Normal;
                    hStaffPaper.Show(this);
                    break;
                case "ToolStripMenuItemStaffMemo": // メモを作成・編集する
                    H_SetControl hSetControl = (H_SetControl)((H_StaffLabel)contextMenuStrip.SourceControl).Parent;
                    TableLayoutPanelCellPosition tableLayoutPanelCellPosition = hSetControl.GetCellPosition((H_StaffLabel)contextMenuStrip.SourceControl);

                    H_Memo hStaffMemo = new(_connectionVo, (H_SetControl)((H_StaffLabel)contextMenuStrip.SourceControl).Parent, (H_StaffLabel)contextMenuStrip.SourceControl, tableLayoutPanelCellPosition);
                    hStaffMemo.Size = new Size(540, 180);
                    new Desktop().SetPosition(hStaffMemo, _connectionVo.Screen);
                    hStaffMemo.Show();
                    break;
                case "ToolStripMenuItemStaffEquioment": // 備品を支給する
                    MessageBox.Show("ToolStripMenuItemStaffEquioment");
                    break;
            }
        }

        /// <summary>
        /// HDateTimePickerOperationDate_ValueChanged
        /// 日付を変えた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerOperationDate_ValueChanged(object sender, EventArgs e) {
            // 日付変更Flagをセットする
            _changeDateFlag = true;
        }

        /// <summary>
        /// H_VehicleDispatchBoard_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_VehicleDispatchBoard_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show("アプリケーションを終了します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
