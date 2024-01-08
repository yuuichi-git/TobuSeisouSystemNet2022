/*
 * 2023-10-12
 */
using H_Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

using StockBox;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly Date _date = new();
        /*
         * 変数定義
         */
        private readonly H_Board _hBoard;
        /*
         * Dao
         */
        private readonly H_VehicleDispatchHeadDao _hVehicleDispatchHeadDao;
        private readonly H_VehicleDispatchDao _hVehicleDispatchDao;
        private readonly H_SetMasterDao _hSetMasterDao;
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private readonly List<H_SetMasterVo> _listHSetMasterVo;
        private readonly List<H_CarMasterVo> _listHCarMasterVo;
        private readonly List<H_StaffMasterVo> _listHStaffMasterVo;
        /*
         * DeepCopy
         */
        private List<H_SetMasterVo>? _listDeepCopyHSetMasterVo;
        private List<H_CarMasterVo>? _listDeepCopyHCarMasterVo;
        private List<H_StaffMasterVo>? _listDeepCopyHStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_VehicleDispatchBoard(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hVehicleDispatchHeadDao = new H_VehicleDispatchHeadDao(connectionVo);
            _hVehicleDispatchDao = new H_VehicleDispatchDao(connectionVo);
            _hSetMasterDao = new H_SetMasterDao(connectionVo);
            _hCarMasterDao = new H_CarMasterDao(connectionVo);
            _hStaffMasterDao = new H_StaffMasterDao(connectionVo);
            _hVehicleDispatchDetailDao = new H_VehicleDispatchDetailDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            Rectangle rectangle = new Desktop().GetWorkingArea(this);
            this.KeyPreview = true;
            this.Location = rectangle.Location;
            this.Size = rectangle.Size;
            this.WindowState = FormWindowState.Maximized;
            H_DateTimePickerOperationDate.SetValue(DateTime.Today);
            /*
             * 関連データを読込む
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMaster();
            /*
             * 配車用ボードを作成
             */
            _hBoard = new H_Board();
            h_TableLayoutPanelExCenter.Controls.Add(_hBoard, 0, 1);
        }

        /// <summary>
        /// 配車データを作成
        /// VehicleDispatch(Head/Body)から作成
        /// </summary>
        private void CreateVehicleDispatchInitialize() {
            /*
             * DeepCopy
             * このListから使用されたレコードを削除していく
             */
            _listDeepCopyHSetMasterVo = new CopyUtility().DeepCopy(_listHSetMasterVo);
            _listDeepCopyHCarMasterVo = new CopyUtility().DeepCopy(_listHCarMasterVo);
            _listDeepCopyHStaffMasterVo = new CopyUtility().DeepCopy(_listHStaffMasterVo);
            // H_Boardを初期化
            this.HBoardControlRemove(_hBoard);
            int financialYear = _date.GetFiscalYear(H_DateTimePickerOperationDate.Value);
            string dayOgWeek = H_DateTimePickerOperationDate.Value.ToString("ddd");
            // H_VehicleDispatchHeadを取得
            List<H_VehicleDispatchHeadVo> listHVehicleDispatchHeadVo = _hVehicleDispatchHeadDao.SelectAllHVehicleDispatchHeadVo(_date.GetFiscalYear());
            // H_VehicleDispatchを取得
            List<H_VehicleDispatchVo> listHVehicleDispatchVo = _hVehicleDispatchDao.SelectHVehicleDispatchVo(financialYear, dayOgWeek);
            foreach (H_VehicleDispatchHeadVo hVehicleDispatchHeadVo in listHVehicleDispatchHeadVo.FindAll(x => (x.Purpose == true && x.SetCode != 0) || x.Purpose == false).OrderBy(x => x.CellNumber)) {
                H_ControlVo hControlVo = new();
                hControlVo.OperationDate = H_DateTimePickerOperationDate.Value;
                hControlVo.CellNumber = hVehicleDispatchHeadVo.CellNumber;
                hControlVo.VehicleDispatchFlag = hVehicleDispatchHeadVo.VehicleDispatchFlag;
                hControlVo.PurposeFlag = hVehicleDispatchHeadVo.Purpose;
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
                H_VehicleDispatchVo? hVehicleDispatchVo = listHVehicleDispatchVo.Find(x => x.SetCode == hVehicleDispatchHeadVo?.SetCode);
                /*
                 * SetLabel作成
                 * SetCodeがゼロの場合Nullを返す
                 */
                hControlVo.HSetMasterVo = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchVo?.SetCode);
                /*
                 * CarLabel作成
                 * CarCodeがゼロの場合Nullを返す
                 */
                hControlVo.HCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchVo?.CarCode);
                // H_Board上に配置されたH_CarLabelを削除する
                _listDeepCopyHCarMasterVo?.RemoveAll(x => x.CarCode == hVehicleDispatchVo?.CarCode);
                /*
                 * StaffLabel作成
                 * Listに入れる順番を保障する必要がある
                 */
                hControlVo.ListHStaffMasterVo = new();
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchVo?.StaffCode1);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode1));
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchVo?.StaffCode2);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode2));
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchVo?.StaffCode3);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode3));
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchVo?.StaffCode4);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchVo?.StaffCode4));
                /*
                 * 配車板の初期化の場合、各LabelのプロパティはDefultで使用するので、Nullを入れておく。
                 */
                hControlVo.HVehicleDispatchDetailVo = null;

                _hBoard.AddSetControl(hControlVo);
            }
        }

        /// <summary>
        /// H_Boardの子コントロールを走査・取得・解析する
        /// </summary>
        private void ReadHBoard() {
            List<H_VehicleDispatchDetailVo> _listHVehicleDispatchDetailVo = new();
            foreach (H_SetControl hSetControl in _hBoard.Controls)
                _listHVehicleDispatchDetailVo.Add(ReadHSetControl(hSetControl));
            try {
                _hVehicleDispatchDetailDao.DeleteHVehicleDispatchDetail(H_DateTimePickerOperationDate.GetValue());
                _hVehicleDispatchDetailDao.InsertHVehicleDispatchDetail(_listHVehicleDispatchDetailVo);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// 配車データを作成
        /// VehicleDispatchDetailから作成
        /// </summary>
        private void CreateVehicleDispatch() {
            /*
             * DeepCopy
             * このListから使用されたレコードを削除していく
             */
            _listDeepCopyHSetMasterVo = new CopyUtility().DeepCopy(_listHSetMasterVo);
            _listDeepCopyHCarMasterVo = new CopyUtility().DeepCopy(_listHCarMasterVo);
            _listDeepCopyHStaffMasterVo = new CopyUtility().DeepCopy(_listHStaffMasterVo);
            // H_Boardを初期化
            this.HBoardControlRemove(_hBoard);

            List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo = _hVehicleDispatchDetailDao.SelectHVehicleDispatchDetail(H_DateTimePickerOperationDate.GetValue());
            foreach (H_VehicleDispatchDetailVo hVehicleDispatchDetailVo in listHVehicleDispatchDetailVo) {
                H_ControlVo hControlVo = new();
                hControlVo.OperationDate = H_DateTimePickerOperationDate.GetValue();
                hControlVo.OperationFlag = hVehicleDispatchDetailVo.OperationFlag;
                hControlVo.CellNumber = hVehicleDispatchDetailVo.CellNumber;
                hControlVo.VehicleDispatchFlag = hVehicleDispatchDetailVo.VehicleDispatchFlag;
                hControlVo.PurposeFlag = hVehicleDispatchDetailVo.PurposeFlag;
                /*
                 * SetLabel作成
                 * SetCodeがゼロの場合Nullを返す
                 */
                hControlVo.HSetMasterVo = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode);
                /*
                 * CarLabel作成
                 * CarCodeがゼロの場合Nullを返す
                 */
                hControlVo.HCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchDetailVo.CarCode);
                // H_Board上に配置されたH_CarLabelを削除する
                _listDeepCopyHCarMasterVo?.RemoveAll(x => x.CarCode == hVehicleDispatchDetailVo.CarCode);
                /*
                 * StaffLabel作成
                 * Listに入れる順番を保障する必要がある
                 */
                hControlVo.ListHStaffMasterVo = new();
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode1);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode1));
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode2);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode2));
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode3);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode3));
                // H_Board上に配置されたH_StaffLabelを削除する
                _listDeepCopyHStaffMasterVo?.RemoveAll(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode4);
                hControlVo.ListHStaffMasterVo.Add(GetHStaffMasterVo(_listHStaffMasterVo, hVehicleDispatchDetailVo.StaffCode4));

                /*
                 * 配車板の初期化の場合、各LabelのプロパティはDefultで使用するので、Nullを入れておく。
                 */
                hControlVo.HVehicleDispatchDetailVo = hVehicleDispatchDetailVo;

                _hBoard.AddSetControl(hControlVo);
            }
        }

        /// <summary>
        /// H_SetControlを解析してH_VehicleDispatchDetailVoに変換(作成)する
        /// </summary>
        /// <param name="hSetControl"></param>
        /// <returns></returns>
        private H_VehicleDispatchDetailVo ReadHSetControl(H_SetControl hSetControl) {
            H_VehicleDispatchDetailVo hVehicleDispatchDetailVo = new();
            H_ControlVo hControlVo = (H_ControlVo)hSetControl.Tag;
            hVehicleDispatchDetailVo.CellNumber = hControlVo.CellNumber;
            hVehicleDispatchDetailVo.OperationDate = hControlVo.OperationDate;
            hVehicleDispatchDetailVo.OperationFlag = hControlVo.OperationFlag;
            hVehicleDispatchDetailVo.VehicleDispatchFlag = hControlVo.VehicleDispatchFlag;
            hVehicleDispatchDetailVo.PurposeFlag = hControlVo.PurposeFlag;
            /*
             * 配車先関連の処理
             * Labelが存在していなければVoのDefault値
             */
            var objectSet = hSetControl.GetControlFromPosition(0, 0); // Controlが存在しなければNULLが返る
            if (objectSet is not null) {
                H_SetLabel hSetLabel = (H_SetLabel)objectSet;
                H_SetMasterVo hSetMasterVo = (H_SetMasterVo)objectSet.Tag;
                hVehicleDispatchDetailVo.SetCode = hSetMasterVo.SetCode;
                hVehicleDispatchDetailVo.ManagedSpaceCode = hSetMasterVo.ManagedSpaceCode;
                hVehicleDispatchDetailVo.ClassificationCode = hSetMasterVo.ClassificationCode;
                hVehicleDispatchDetailVo.LastRollCallFlag = hSetLabel.LastRollCallFlag;
                hVehicleDispatchDetailVo.LastRollCallYmdHms = hSetLabel.LastRollCallYmdHms;
                hVehicleDispatchDetailVo.SetMemoFlag = hSetLabel.MemoFlag;
                hVehicleDispatchDetailVo.SetMemo = hSetLabel.Memo;
                hVehicleDispatchDetailVo.ShiftCode = hSetLabel.ShiftCode;
                hVehicleDispatchDetailVo.StandByFlag = hSetLabel.StandByFlag;
                hVehicleDispatchDetailVo.AddWorkerFlag = hSetLabel.AddWorkerFlag;
                hVehicleDispatchDetailVo.ContactInfomationFlag = hSetLabel.ContactInfomationFlag;
                hVehicleDispatchDetailVo.FaxTransmissionFlag = hSetLabel.FaxTransmissionFlag;
            }
            /*
             * 車両関連の処理
             * Labelが存在していなければVoのDefault値
             */
            var objectCar = hSetControl.GetControlFromPosition(0, 1); // Controlが存在しなければNULLが返る
            if (objectCar is not null) {
                H_CarLabel hCarLabel = (H_CarLabel)objectCar;
                H_CarMasterVo hCarMasterVo = (H_CarMasterVo)objectCar.Tag;
                hVehicleDispatchDetailVo.CarCode = hCarMasterVo.CarCode;
                hVehicleDispatchDetailVo.CarGarageCode = hCarMasterVo.GarageCode;
                hVehicleDispatchDetailVo.CarProxyFlag = hCarLabel.CarProxyFlag;
                hVehicleDispatchDetailVo.CarMemoFlag = hCarLabel.CarMemoFlag;
                hVehicleDispatchDetailVo.CarMemo = hCarLabel.CarMemo;
            }
            /*
             * 従事者関連の処理
             * Labelが存在していなければVoのDefault値
             */
            /*
             * 運転手
             */
            var objectStaff1 = hSetControl.GetControlFromPosition(0, 2); // Controlが存在しなければNULLが返る
            if (objectStaff1 is not null) {
                H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff1;
                H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff1.Tag;
                hVehicleDispatchDetailVo.StaffCode1 = hStaffMasterVo.StaffCode;
                hVehicleDispatchDetailVo.StaffOccupation1 = hStaffMasterVo.Occupation;
                hVehicleDispatchDetailVo.StaffProxyFlag1 = hStaffLabel.StaffProxyFlag;
                hVehicleDispatchDetailVo.StaffRollCallFlag1 = hStaffLabel.StaffRollCallFlag;
                hVehicleDispatchDetailVo.StaffRollCallYmdHms1 = hStaffLabel.StaffRollCallYmdHms;
                hVehicleDispatchDetailVo.StaffMemoFlag1 = hStaffLabel.StaffMemoFlag;
                hVehicleDispatchDetailVo.StaffMemo1 = hStaffLabel.StaffMemo;
            }
            /*
             * 作業員１
             */
            var objectStaff2 = hSetControl.GetControlFromPosition(0, 3); // Controlが存在しなければNULLが返る
            if (objectStaff2 is not null) {
                H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff2;
                H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff2.Tag;
                hVehicleDispatchDetailVo.StaffCode2 = hStaffMasterVo.StaffCode;
                hVehicleDispatchDetailVo.StaffOccupation2 = hStaffMasterVo.Occupation;
                hVehicleDispatchDetailVo.StaffProxyFlag2 = hStaffLabel.StaffProxyFlag;
                hVehicleDispatchDetailVo.StaffRollCallFlag2 = hStaffLabel.StaffRollCallFlag;
                hVehicleDispatchDetailVo.StaffRollCallYmdHms2 = hStaffLabel.StaffRollCallYmdHms;
                hVehicleDispatchDetailVo.StaffMemoFlag2 = hStaffLabel.StaffMemoFlag;
                hVehicleDispatchDetailVo.StaffMemo2 = hStaffLabel.StaffMemo;
            }
            /*
             * H_SetControlの形状が２列の場合、作業員２・３の処理をする
             */
            if (hControlVo.PurposeFlag) {
                /*
                 * 作業員２
                 */
                var objectStaff3 = hSetControl.GetControlFromPosition(1, 2); // Controlが存在しなければNULLが返る
                if (objectStaff3 is not null) {
                    H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff3;
                    H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff3.Tag;
                    hVehicleDispatchDetailVo.StaffCode3 = hStaffMasterVo.StaffCode;
                    hVehicleDispatchDetailVo.StaffOccupation3 = hStaffMasterVo.Occupation;
                    hVehicleDispatchDetailVo.StaffProxyFlag3 = hStaffLabel.StaffProxyFlag;
                    hVehicleDispatchDetailVo.StaffRollCallFlag3 = hStaffLabel.StaffRollCallFlag;
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms3 = hStaffLabel.StaffRollCallYmdHms;
                    hVehicleDispatchDetailVo.StaffMemoFlag3 = hStaffLabel.StaffMemoFlag;
                    hVehicleDispatchDetailVo.StaffMemo3 = hStaffLabel.StaffMemo;
                }
                /*
                 * 作業員３
                 */
                var objectStaff4 = hSetControl.GetControlFromPosition(1, 3); // Controlが存在しなければNULLが返る
                if (objectStaff4 is not null) {
                    H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff4;
                    H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff4.Tag;
                    hVehicleDispatchDetailVo.StaffCode4 = hStaffMasterVo.StaffCode;
                    hVehicleDispatchDetailVo.StaffOccupation4 = hStaffMasterVo.Occupation;
                    hVehicleDispatchDetailVo.StaffProxyFlag4 = hStaffLabel.StaffProxyFlag;
                    hVehicleDispatchDetailVo.StaffRollCallFlag4 = hStaffLabel.StaffRollCallFlag;
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms4 = hStaffLabel.StaffRollCallYmdHms;
                    hVehicleDispatchDetailVo.StaffMemoFlag4 = hStaffLabel.StaffMemoFlag;
                    hVehicleDispatchDetailVo.StaffMemo4 = hStaffLabel.StaffMemo;
                }
            }
            hVehicleDispatchDetailVo.InsertPcName = Environment.MachineName;
            hVehicleDispatchDetailVo.InsertYmdHms = DateTime.Now;
            hVehicleDispatchDetailVo.UpdatePcName = string.Empty;
            hVehicleDispatchDetailVo.UpdateYmdHms = _defaultDateTime;
            hVehicleDispatchDetailVo.DeletePcName = string.Empty;
            hVehicleDispatchDetailVo.DeleteYmdHms = _defaultDateTime;
            hVehicleDispatchDetailVo.DeleteFlag = false;

            return hVehicleDispatchDetailVo;
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
                    H_ControlVo hControlVo = new();
                    hControlVo.OperationDate = H_DateTimePickerOperationDate.GetValue();
                    hControlVo.ListDeepCopyHSetMasterVo = _listDeepCopyHSetMasterVo;
                    hControlVo.ListDeepCopyHCarMasterVo = _listDeepCopyHCarMasterVo;
                    hControlVo.ListDeepCopyHStaffMasterVo = _listDeepCopyHStaffMasterVo;
                    H_StockBoxs hStockBoxs = new(hControlVo);
                    hStockBoxs.Show();
                    break;
                case "h_ButtonExLeft2":
                    break;
                case "h_ButtonExLeft3":
                    break;
                case "h_ButtonExLeft4":
                    break;
                case "h_ButtonExLeft5":
                    break;
                case "h_ButtonExRight1":
                    break;
                case "h_ButtonExRight2":
                    break;
                case "h_ButtonExRight3":
                    break;
                case "h_ButtonExRight4":
                    break;
                case "h_ButtonExRight5":
                    ReadHBoard();
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
                 * 配車を初期化する
                 */
                case "ToolStripMenuItemInitializeVehicleDispatch":
                    this.CreateVehicleDispatchInitialize();
                    break;
            }
        }
    }
}
