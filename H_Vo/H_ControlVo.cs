/*
 * 2023-10-21
 * H_SetControlに値を渡す為のVo
 */
namespace Vo {

    public class H_ControlVo {
        /*
         * プロパティ
         */
        private ConnectionVo _connectionVo;
        private Control _hBoard;
        private Control _hFlowLayoutPanelExStockBoxs;
        private int _cellNumber;
        private DateTime _operationDate;
        private bool _operationFlag;
        private bool _vehicleDispatchFlag;
        private bool _purposeFlag;
        private H_SetMasterVo _hSetMasterVo;
        private H_CarMasterVo _hCarMasterVo;
        private H_StaffMasterVo _hStaffMasterVo;
        private int _selectNumberStaffMasterVo;
        private List<H_SetMasterVo> _listHSetMasterVo;
        private List<H_CarMasterVo> _listHCarMasterVo;
        private List<H_StaffMasterVo> _listHStaffMasterVo;
        private List<H_SetMasterVo> _removeListHSetMasterVo;
        private List<H_CarMasterVo> _removeListHCarMasterVo;
        private List<H_StaffMasterVo> _removeListHStaffMasterVo;
        private H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_ControlVo() {
            _connectionVo = null;
            _hBoard = null;
            _hFlowLayoutPanelExStockBoxs = null;
            _cellNumber = 0;
            _operationDate = new DateTime(1900, 01, 01);
            _operationFlag = false;
            _vehicleDispatchFlag = false;
            _purposeFlag = false;
            _hSetMasterVo = null;
            _hCarMasterVo = null;
            _hStaffMasterVo = null;
            _selectNumberStaffMasterVo = 0;
            _listHSetMasterVo = null;
            _listHCarMasterVo = null;
            _listHStaffMasterVo = null;
            _removeListHSetMasterVo = null;
            _removeListHCarMasterVo = null;
            _removeListHStaffMasterVo = null;
            _hVehicleDispatchDetailVo = null;
        }

        /*
         * Setter Getter
         */
        /// <summary>
        /// ConnectionVo
        /// </summary>
        public ConnectionVo ConnectionVo {
            get => _connectionVo;
            set => _connectionVo = value;
        }
        /// <summary>
        /// HBoard
        /// </summary>
        public Control HBoard {
            get => _hBoard;
            set => _hBoard = value;
        }
        /// <summary>
        /// HFlowLayoutPanelExStockBoxs
        /// </summary>
        public Control HFlowLayoutPanelExStockBoxs {
            get => _hFlowLayoutPanelExStockBoxs;
            set => _hFlowLayoutPanelExStockBoxs = value;
        }
        /// <summary>
        /// CellNumber
        /// </summary>
        public int CellNumber {
            get => _cellNumber;
            set => _cellNumber = value;
        }
        /// <summary>
        /// 稼働日
        /// </summary>
        public DateTime OperationDate {
            get => _operationDate;
            set => _operationDate = value;
        }
        /// <summary>
        /// 稼働フラグ
        /// true:稼働日 false:休車
        /// </summary>
        public bool OperationFlag {
            get => _operationFlag;
            set => _operationFlag = value;
        }
        /// <summary>
        /// 配車フラグ
        /// true:配車の割当てが有る false:割当てが無い
        /// </summary>
        public bool VehicleDispatchFlag {
            get => _vehicleDispatchFlag;
            set => _vehicleDispatchFlag = value;
        }
        /// <summary>
        /// SetControlの列数
        /// true:２列 false:１列
        /// </summary>
        public bool PurposeFlag {
            get => _purposeFlag;
            set => _purposeFlag = value;
        }
        /// <summary>
        /// SetMaster
        /// </summary>
        public H_SetMasterVo HSetMasterVo {
            get => _hSetMasterVo;
            set => _hSetMasterVo = value;
        }
        /// <summary>
        /// CarMaster
        /// </summary>
        public H_CarMasterVo HCarMasterVo {
            get => _hCarMasterVo;
            set => _hCarMasterVo = value;
        }
        /// <summary>
        /// HStaffMasterVo
        /// </summary>
        public H_StaffMasterVo HStaffMasterVo {
            get => _hStaffMasterVo;
            set => _hStaffMasterVo = value;
        }
        /// <summary>
        /// H_StaffLabelを作成する際に必要なパラメータだよ
        /// 0:運転手 1:作業員① 2:作業員② 3:作業員③
        /// </summary>
        public int SelectNumberStaffMasterVo {
            get => _selectNumberStaffMasterVo;
            set => _selectNumberStaffMasterVo = value;
        }
        /// <summary>
        /// ListHSetMasterVo
        /// 未加工
        /// </summary>
        public List<H_SetMasterVo> ListHSetMasterVo {
            get => _listHSetMasterVo;
            set => _listHSetMasterVo = value;
        }
        /// <summary>
        /// ListHCarMasterVo
        /// 未加工
        /// </summary>
        public List<H_CarMasterVo> ListHCarMasterVo {
            get => _listHCarMasterVo;
            set => _listHCarMasterVo = value;
        }
        /// <summary>
        /// ListHStaffMasterVo
        /// 未加工
        /// </summary>
        public List<H_StaffMasterVo> ListHStaffMasterVo {
            get => _listHStaffMasterVo;
            set => _listHStaffMasterVo = value;
        }
        /// <summary>
        /// 配車されているH_SetMasterVoを除いたもの
        /// </summary>
        public List<H_SetMasterVo> RemoveListHSetMasterVo {
            get => _removeListHSetMasterVo;
            set => _removeListHSetMasterVo = value;
        }
        /// <summary>
        /// 配車されているH_CarMasterVoを除いたもの
        /// </summary>
        public List<H_CarMasterVo> RemoveListHCarMasterVo {
            get => _removeListHCarMasterVo;
            set => _removeListHCarMasterVo = value;
        }
        /// <summary>
        /// 配車されているH_StaffMasterVoを除いたもの
        /// </summary>
        public List<H_StaffMasterVo> RemoveListHStaffMasterVo {
            get => _removeListHStaffMasterVo;
            set => _removeListHStaffMasterVo = value;
        }
        /// <summary>
        /// テーブル(H_VehicleDispatchDetail)を格納
        /// </summary>
        public H_VehicleDispatchDetailVo HVehicleDispatchDetailVo {
            get => _hVehicleDispatchDetailVo;
            set => _hVehicleDispatchDetailVo = value;
        }
    }
}
