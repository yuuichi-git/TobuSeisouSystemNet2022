/*
 * 2024-03-09
 */
using H_ControlEx;

using H_Vo;

namespace H_VehicleDispatch {
    public partial class H_Memo : Form {

        public H_Memo(ConnectionVo connectionVo, H_SetControl hSetControl, H_SetLabel hSetLabel) {
            InitializeComponent();
        }

        public H_Memo(ConnectionVo connectionVo, H_SetControl hSetControl, H_CarLabel hCarLabel) {
            InitializeComponent();
        }

        public H_Memo(ConnectionVo connectionVo, H_SetControl hSetControl, H_StaffLabel hStaffLabel) {
            InitializeComponent();
        }


    }
}
