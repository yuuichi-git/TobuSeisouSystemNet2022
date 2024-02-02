/*
 * 2024-02-01
 */
using ControlEx;

using H_Vo;

namespace H_Common
{
    public class ArrayUtility
    {
        /*
         * Vo
         */
        private List<H_CarMasterVo>? _removeListHCarMasterVo;
        private List<H_StaffMasterVo>? _removeListHStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ArrayUtility()
        {
            /*
             * Vo
             */
            _removeListHCarMasterVo = null;
            _removeListHStaffMasterVo = null;
        }
        /// <summary>
        /// RemoveForHBoard
        /// </summary>
        /// <param name="hBoard"></param>
        /// <param name="hSetControl"></param>
        /// <param name="listHCarMasterVo"></param>
        /// <returns></returns>
        public List<H_CarMasterVo> RemoveForHBoard(TableLayoutPanelEx hBoard, FlowLayoutPanelEx hFlowLayoutPanelExFree, List<H_CarMasterVo> listHCarMasterVo)
        {
            // DeepCopy
            _removeListHCarMasterVo = new CopyUtility().DeepCopy(listHCarMasterVo);

            return new();
        }

        /// <summary>
        /// RemoveForHBoard
        /// </summary>
        /// <param name="hBoard"></param>
        /// <param name="hSetControl"></param>
        /// <param name="listHStaffMasterVo"></param>
        /// <returns></returns>
        public List<H_StaffMasterVo> RemoveForHBoard(TableLayoutPanel hBoard, TableLayoutPanel hSetControl, List<H_StaffMasterVo> listHStaffMasterVo)
        {
            // DeepCopy
            _removeListHStaffMasterVo = new CopyUtility().DeepCopy(listHStaffMasterVo);

            return new();
        }

        /// <summary>
        /// RemoveHFlowLayoutPanelExFree
        /// </summary>
        /// <param name="hBoard"></param>
        /// <param name="hSetControl"></param>
        /// <param name="listHCarMasterVo"></param>
        /// <returns></returns>

        public List<H_CarMasterVo> RemoveHFlowLayoutPanelExFree(TableLayoutPanel hBoard, TableLayoutPanel hSetControl, List<H_CarMasterVo> listHCarMasterVo)
        {


            return new();
        }

        /// <summary>
        /// RemoveHFlowLayoutPanelExFree
        /// </summary>
        /// <param name="hBoard"></param>
        /// <param name="hSetControl"></param>
        /// <param name="listHStaffMasterVo"></param>
        /// <returns></returns>
        public List<H_StaffMasterVo> RemoveHFlowLayoutPanelExFree(TableLayoutPanel hBoard, TableLayoutPanel hSetControl, List<H_StaffMasterVo> listHStaffMasterVo)
        {


            return new();
        }
    }
}
