/*
 * 2023-10-12
 */
using H_Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
        private Date _date = new();
        /*
         * 変数定義
         */
        private H_Board _hBoard;
        /*
         * Dao
         */
        private readonly H_VehicleDispatchHeadDao _hVehicleDispatchHeadDao;
        private readonly H_VehicleDispatchDao _hVehicleDispatchDao;
        private H_SetMasterDao _hSetMasterDao;
        private H_CarMasterDao _hCarMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private List<H_SetMasterVo> _listHSetMasterVo;
        private List<H_CarMasterVo> _listHCarMasterVo;

        /// <summary>
        /// コンストラクタ
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
            _listHCarMasterVo = _hCarMasterDao.SelectAllCarMaster();
            /*
             * 配車用ボードを作成
             */
            _hBoard = new H_Board();
            h_TableLayoutPanelExCenter.Controls.Add(_hBoard, 0, 1);
        }


        private void H_ButtonExUpdate_Click(object sender, EventArgs e) {
            this.CreateVehicleDispatch();

        }

        /// <summary>
        /// CreateVehicleDispatch
        /// 配車データを作成
        /// </summary>
        private void CreateVehicleDispatch() {
            int financialYear = _date.GetFiscalYear(H_DateTimePickerOperationDate.Value);
            string dayOgWeek = H_DateTimePickerOperationDate.Value.ToString("ddd");
            // H_VehicleDispatchHeadを取得
            List<H_VehicleDispatchHeadVo> listHVehicleDispatchHeadVo = _hVehicleDispatchHeadDao.SelectAllHVehicleDispatchHeadVo(_date.GetFiscalYear());
            // H_VehicleDispatchを取得
            List< H_VehicleDispatchVo> listHVehicleDispatchVo = _hVehicleDispatchDao.SelectHVehicleDispatchVo(financialYear,dayOgWeek);
            foreach(H_VehicleDispatchHeadVo hVehicleDispatchHeadVo in listHVehicleDispatchHeadVo.FindAll(x => (x.Purpose == true && x.SetCode != 0) || x.Purpose == false).OrderBy(x => x.CellNumber)) {
                H_SetControlVo hSetControlVo = new();
                hSetControlVo.CellNumber = hVehicleDispatchHeadVo.CellNumber;
                hSetControlVo.VehicleDispatchFlag = hVehicleDispatchHeadVo.VehicleDispatchFlag;
                hSetControlVo.Purpose = hVehicleDispatchHeadVo.Purpose;
                /*
                 * SetLabel作成
                 */
                if(hVehicleDispatchHeadVo.SetCode != 0) {
                    hSetControlVo.HSetMasterVo = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchHeadVo.SetCode);
                } else {
                    hSetControlVo.HSetMasterVo = null;
                }
                /*
                 * CarLabel作成
                 * SetCodeがゼロの場合を考えて
                 */
                H_VehicleDispatchVo? hVehicleDispatchVo = listHVehicleDispatchVo.Find(x => x.SetCode == hVehicleDispatchHeadVo.SetCode);
                if(hVehicleDispatchVo is not null) {
                    hSetControlVo.HCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchVo.CarCode);
                } else {
                    hSetControlVo.HCarMasterVo = null;
                }
                /*
                 * StaffLabel作成
                 */
                hSetControlVo.ListHStaffMasterVo = null;

                _hBoard.AddSetControl(hSetControlVo);
            }
        }
    }
}
