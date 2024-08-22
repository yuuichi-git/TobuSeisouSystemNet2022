/*
 * 2024-02-01
 * 循環参照が発生したので分離
 */
using H_Common;

using H_ControlEx;

using H_Vo;

namespace H_Utility {
    public class H_ArrayUtility {
        /*
         * Vo
         */
        private List<H_CarMasterVo>? _removeListHCarMasterVo;
        private List<H_StaffMasterVo>? _removeListHStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_ArrayUtility() {
            /*
             * Vo
             */
            _removeListHCarMasterVo = null;
            _removeListHStaffMasterVo = null;
        }

        /// <summary>
        /// RemoveHCarMasterVo
        /// </summary>
        /// <param name="hBoard"></param>
        /// <param name="hFlowLayoutPanelExFree"></param>
        /// <param name="listHCarMasterVo"></param>
        /// <returns></returns>
        public List<H_CarMasterVo>? RemoveHCarMasterVo(TableLayoutPanel hBoard, FlowLayoutPanel hFlowLayoutPanelExFree, List<H_CarMasterVo> listHCarMasterVo) {
            // DeepCopy
            _removeListHCarMasterVo = new CopyUtility().DeepCopy(listHCarMasterVo);
            /*
             * H_Board,H_SetControlを走査する
             */
            foreach (H_SetControl hSetControl in hBoard.Controls) {
                foreach (Control control in hSetControl.Controls) {
                    switch (control) {
                        case H_CarLabel hCarLabel:
                            _removeListHCarMasterVo?.RemoveAll(x => x.CarCode == ((H_CarMasterVo)hCarLabel.Tag).CarCode);
                            break;
                    }
                }
            }
            /*
             * H_FlowLayoutPanelExを走査する
             */
            foreach (Control control in hFlowLayoutPanelExFree.Controls) {
                switch (control) {
                    case H_CarLabel hCarLabel:
                        _removeListHCarMasterVo?.RemoveAll(x => x.CarCode == ((H_CarMasterVo)hCarLabel.Tag).CarCode);
                        break;
                }
            }
            return _removeListHCarMasterVo;
        }

        /// <summary>
        /// RemoveHStaffMasterVo
        /// </summary>
        /// <param name="hBoard"></param>
        /// <param name="hFlowLayoutPanelExFree"></param>
        /// <param name="listHStaffMasterVo"></param>
        /// <returns></returns>
        public List<H_StaffMasterVo>? RemoveHStaffMasterVo(TableLayoutPanel hBoard, FlowLayoutPanel hFlowLayoutPanelExFree, List<H_StaffMasterVo> listHStaffMasterVo) {
            // DeepCopy
            _removeListHStaffMasterVo = new CopyUtility().DeepCopy(listHStaffMasterVo);
            /*
             * H_Board,H_SetControlを走査する
             */
            foreach (H_SetControl hSetControl in hBoard.Controls) {
                foreach (Control control in hSetControl.Controls) {
                    switch (control) {
                        case H_StaffLabel hStaffLabel:
                            _removeListHStaffMasterVo?.RemoveAll(x => x.StaffCode == ((H_StaffMasterVo)hStaffLabel.Tag).StaffCode);
                            break;
                    }
                }
            }
            /*
             * H_FlowLayoutPanelExを走査する
             */
            foreach (Control control in hFlowLayoutPanelExFree.Controls) {
                switch (control) {
                    case H_StaffLabel hStaffLabel:
                        _removeListHStaffMasterVo?.RemoveAll(x => x.StaffCode == ((H_StaffMasterVo)hStaffLabel.Tag).StaffCode);
                        break;
                }
            }
            return _removeListHStaffMasterVo;
        }
    }
}
