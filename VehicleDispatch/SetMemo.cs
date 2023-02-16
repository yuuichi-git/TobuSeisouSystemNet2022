using ControlEx;

using Dao;

using Vo;

namespace VehicleDispatch {
    public partial class SetMemo : Form {
        private DateTime _operationDate;
        private SetControlEx _setControlEx;
        private SetLabelEx _setLabelEx;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="operationDate"></param>
        /// <param name="setControlEx"></param>
        /// <param name="setLabelEx"></param>
        public SetMemo(ConnectionVo connectionVo, DateTime operationDate, SetControlEx setControlEx, SetLabelEx setLabelEx) {
            _operationDate = operationDate;
            _setControlEx = setControlEx;
            _setLabelEx = setLabelEx;
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);

            InitializeComponent();
            /*
             * SetControlEx上でクリックされた時
             * vehicle_dispatch_detailから読出し
             */
            if(_setLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                TextBoxMemo.Text = _vehicleDispatchDetailDao.GetSetNote(_operationDate, Convert.ToInt32(_setControlEx.Tag));
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
                if(_setLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                    _vehicleDispatchDetailDao.SetSetNote(_operationDate, (int)_setControlEx.Tag, TextBoxMemo.Text);
                }
                _setLabelEx.SetMemoFlag(TextBoxMemo.Text.Length > 0 ? true : false);
                this.Close();
            } catch {
                throw;
            }
        }
    }
}
