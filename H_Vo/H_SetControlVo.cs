/*
 * 2023-10-21
 * H_SetControlに値を渡す為のVo
 */
namespace H_Vo {
    public class H_SetControlVo {
        /*
         * プロパティ
         */
        private int _columnNumber;
        private H_SetMasterVo _hSetMasterVo;
        private H_CarMasterVo _hCarMasterVo;
        private List<H_StaffMasterVo> _listHStaffMasterVo;

        /*
         * Setter Getter
         */
        /// <summary>
        /// ColumnNumber
        /// SetControlのColum番号
        /// </summary>
        public int ColumnNumber {
            get => _columnNumber;
            set => _columnNumber = value;
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
        /// StaffMaster
        /// </summary>
        public List<H_StaffMasterVo> ListHStaffMasterVo {
            get => _listHStaffMasterVo;
            set => _listHStaffMasterVo = value;
        }
        
    }
}
