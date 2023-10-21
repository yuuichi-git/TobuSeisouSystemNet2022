/*
 * 2023-10-21
 * 外部からH_TableLayoutPanelExSetControlに値を渡す為のVo
 */
namespace H_Vo {
    public class H_TableLayoutPanelExSetControlVo {
        private H_SetMasterVo _hSetMasterVo;
        private H_CarMasterVo _hCarMasterVo;
        private List<H_StaffMasterVo> _listHStaffMasterVo;

        public H_TableLayoutPanelExSetControlVo() {
        }

        /*
         * Setter Getter
         */
        public H_SetMasterVo HSetMasterVo {
            get => _hSetMasterVo;
            set => _hSetMasterVo = value;
        }
        public H_CarMasterVo HCarMasterVo {
            get => _hCarMasterVo;
            set => _hCarMasterVo = value;
        }
        public List<H_StaffMasterVo> ListHStaffMasterVo {
            get => _listHStaffMasterVo;
            set => _listHStaffMasterVo = value;
        }
    }
}
