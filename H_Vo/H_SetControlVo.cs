/*
 * 2023-10-21
 * H_SetControlに値を渡す為のVo
 */
namespace H_Vo {
    public class H_SetControlVo {
        /*
         * プロパティ
         */
        private DateTime _operationDate;
        private int _cellNumber;
        private bool _vehicleDispatchFlag;
        private bool _purpose;
        private H_SetMasterVo? _hSetMasterVo;
        private H_CarMasterVo? _hCarMasterVo;
        private List<H_StaffMasterVo>? _listHStaffMasterVo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_SetControlVo() {
            _cellNumber = 0;
            _purpose = false;
            _hSetMasterVo = null;
            _hCarMasterVo = null;
            _listHStaffMasterVo = null;
        }

        /*
         * Setter Getter
         */
        /// <summary>
        /// 稼働日
        /// </summary>
        public DateTime OperationDate {
            get => _operationDate;
            set => _operationDate = value;
        }
        /// <summary>
        /// CellNumber
        /// </summary>
        public int CellNumber {
            get => _cellNumber;
            set => _cellNumber = value;
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
        public bool Purpose {
            get => _purpose;
            set => _purpose = value;
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
        /// StaffMaster
        /// </summary>
        public List<H_StaffMasterVo>? ListHStaffMasterVo {
            get => _listHStaffMasterVo;
            set => _listHStaffMasterVo = value;
        }
    }
}
