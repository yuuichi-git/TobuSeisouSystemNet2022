/*
 * 2023-10-21
 * H_SetControlに値を渡す為のVo
 */
using Vo;

namespace H_Vo {
    public class H_ControlVo {
        /*
         * プロパティ
         */
        private int _cellNumber;
        private DateTime _operationDate;
        private bool _operationFlag;
        private bool _vehicleDispatchFlag;
        private bool _purposeFlag;
        private H_SetMasterVo? _hSetMasterVo;
        private H_CarMasterVo? _hCarMasterVo;
        private H_StaffMasterVo? _hStaffMasterVo;
        private List<H_StaffMasterVo>? _listHStaffMasterVo;
        private List<H_SetMasterVo>? _listDeepCopyHSetMasterVo;
        private List<H_CarMasterVo>? _listDeepCopyHCarMasterVo;
        private List<H_StaffMasterVo>? _listDeepCopyHStaffMasterVo;
        private H_VehicleDispatchDetailVo? _hVehicleDispatchDetailVo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_ControlVo() {
            _operationDate = new DateTime(1900, 01, 01);
            _operationFlag = false;
            _cellNumber = 0;
            _vehicleDispatchFlag = false;
            _purposeFlag = false;
            _hSetMasterVo = null;
            _hCarMasterVo = null;
            _hStaffMasterVo = null;
            _listHStaffMasterVo = null;
            _listDeepCopyHSetMasterVo = null;
            _listDeepCopyHCarMasterVo = null;
            _listDeepCopyHStaffMasterVo = null;
            _hVehicleDispatchDetailVo = null;
        }

        /*
         * Setter Getter
         */
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
        public H_SetMasterVo? HSetMasterVo {
            get => _hSetMasterVo;
            set => _hSetMasterVo = value;
        }
        /// <summary>
        /// CarMaster
        /// </summary>
        public H_CarMasterVo? HCarMasterVo {
            get => _hCarMasterVo;
            set => _hCarMasterVo = value;
        }
        /// <summary>
        /// HStaffMasterVo
        /// </summary>
        public H_StaffMasterVo? HStaffMasterVo {
            get => _hStaffMasterVo;
            set => _hStaffMasterVo = value;
        }
        /// <summary>
        /// ListHStaffMasterVo
        /// </summary>
        public List<H_StaffMasterVo>? ListHStaffMasterVo {
            get => _listHStaffMasterVo;
            set => _listHStaffMasterVo = value;
        }
        /// <summary>
        /// ListDeepCopyHSetMasterVo
        /// </summary>
        public List<H_SetMasterVo>? ListDeepCopyHSetMasterVo {
            get => _listDeepCopyHSetMasterVo;
            set => _listDeepCopyHSetMasterVo = value;
        }
        /// <summary>
        /// ListDeepCopyHCarMasterVo
        /// </summary>
        public List<H_CarMasterVo>? ListDeepCopyHCarMasterVo {
            get => _listDeepCopyHCarMasterVo;
            set => _listDeepCopyHCarMasterVo = value;
        }
        /// <summary>
        /// ListDeepCopyHStaffMasterVo
        /// </summary>
        public List<H_StaffMasterVo>? ListDeepCopyHStaffMasterVo {
            get => _listDeepCopyHStaffMasterVo;
            set => _listDeepCopyHStaffMasterVo = value;
        }
        /// <summary>
        /// テーブル(H_VehicleDispatchDetail)を格納
        /// </summary>
        public H_VehicleDispatchDetailVo? HVehicleDispatchDetailVo {
            get => _hVehicleDispatchDetailVo;
            set => _hVehicleDispatchDetailVo = value;
        }
    }
}
