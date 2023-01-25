using ControlEx;

using Dao;

using Vo;

namespace VehicleDispatch {
    public partial class StaffMemo : Form {
        private DateTime _operationDate;
        private SetControlEx _setControlEx;
        private StaffLabelEx _staffLabelEx;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="setControlEx"></param>
        /// <param name="staffLabelEx"></param>
        public StaffMemo(ConnectionVo connectionVo, DateTime operationDate, SetControlEx setControlEx, FlowLayoutPanelEx flowLayoutPanelEx, StaffLabelEx staffLabelEx) {
            _operationDate = operationDate;
            _setControlEx = setControlEx;
            _staffLabelEx = staffLabelEx;
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchDetailStaffDao = new VehicleDispatchDetailStaffDao(connectionVo);

            InitializeComponent();
            /*
             * SetControlEx上でクリックされた時
             * vehicle_dispatch_detailから読出し
             */
            if(_staffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                TextBoxMemo.Text = _vehicleDispatchDetailDao.GetOperatorNote(_operationDate,
                                                                             Convert.ToInt32(_setControlEx.Tag),
                                                                             _setControlEx.GetPositionFromControl(_staffLabelEx).Row);
            }
            /*
             * FlowLayoutPanelEx上でクリックされた時
             * vehicle_dispatch_detail_staffから読出し
             */
            if(_staffLabelEx.Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                TextBoxMemo.Text = _vehicleDispatchDetailStaffDao.GetOperatorNote(_operationDate,
                                                                                  Convert.ToInt32(flowLayoutPanelEx.Tag),
                                                                                  ((StaffMasterVo)_staffLabelEx.Tag).Staff_code);
            }
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            try {
                /*
                 * SetControlEx上でクリックされた時
                 * vehicle_dispatch_detailに記録する
                 */
                if(_staffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                    _vehicleDispatchDetailDao.SetOperatorNote(_operationDate,
                                                              (int)_setControlEx.Tag,
                                                              _setControlEx.GetPositionFromControl(_staffLabelEx).Row,
                                                              TextBoxMemo.Text);
                }
                /*
                 * FlowLayoutPanelEx上でクリックされた時
                 * vehicle_dispatch_detail_staffに記録する
                 */
                if(_staffLabelEx.Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                    _vehicleDispatchDetailStaffDao.SetOperatorNote(_operationDate,
                                                                   ((StaffMasterVo)_staffLabelEx.Tag).Staff_code,
                                                                   TextBoxMemo.Text);
                }
                _staffLabelEx.SetNoteFlag(TextBoxMemo.Text.Length > 0 ? true : false);
                this.Close();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// StaffMemo_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffMemo_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
