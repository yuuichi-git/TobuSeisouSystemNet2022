/*
 * 2022-11-23
 */
using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchExcel : Form {
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public VehicleDispatchExcel(ConnectionVo connectionVo) {
            _connectionVo= connectionVo;

            InitializeComponent();
        }

        /// <summary>
        /// ToolStripMenuItemSelectExcel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemSelectExcel_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// VehicleDispatchExcel_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchExcel_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
