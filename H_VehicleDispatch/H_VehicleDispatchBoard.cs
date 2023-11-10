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
        private H_SetMasterDao _hSetMasterDao;
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
            _hSetMasterDao = new H_SetMasterDao(connectionVo);
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
            // H_VehicleDispatchHeadを取得
            List<H_VehicleDispatchHeadVo> listHVehicleDispatchHeadVo = _hVehicleDispatchHeadDao.SelectAllHVehicleDispatchHeadVo(_date.GetFiscalYear());
            foreach(H_VehicleDispatchHeadVo hVehicleDispatchHeadVo in listHVehicleDispatchHeadVo.FindAll(x => (x.Purpose == true && x.SetCode != 0) || x.Purpose == false).OrderBy(x => x.CellNumber)) {
                H_SetControlVo hSetControlVo = new();
                hSetControlVo.CellNumber = hVehicleDispatchHeadVo.CellNumber;
                hSetControlVo.VehicleDispatchFlag = hVehicleDispatchHeadVo.VehicleDispatchFlag;
                hSetControlVo.Purpose = hVehicleDispatchHeadVo.Purpose;

                hSetControlVo.HSetMasterVo = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchHeadVo.SetCode);
                hSetControlVo.HCarMasterVo = null;
                hSetControlVo.ListHStaffMasterVo = null;
                _hBoard.AddSetControl(hSetControlVo);
            }
        }
    }
}
