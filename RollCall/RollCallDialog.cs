using ControlEx;

using Dao;

using Vo;

namespace RollCall {
    public partial class RollCallDialog : Form {
        private readonly DateTime _operationDate;
        private readonly SetControlEx _setControlEx;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;

        private DateTime _defaultDateTime = new DateTime(1900, 01, 01);

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="setControlEx"></param>
        /// <param name="setLabelEx"></param>
        public RollCallDialog(ConnectionVo connectionVo, DateTime operationDate, SetControlEx setControlEx) {
            _operationDate = operationDate;
            _setControlEx = setControlEx;
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);

            InitializeComponent();
            // �ŏ��̃R���g���[���e�L�X�g��I����Ԃɐݒ�
            NumericLastPlantCount.Select(0, NumericLastPlantCount.Text.Length);
        }

        public static void Main() {
        }

        private void Control_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                // �^�u�I�[�_�[���Ŏ��̃R���g���[���Ƀt�H�[�J�X���ړ�
                SendKeys.Send("{TAB}");
                switch(this.ActiveControl.GetType().Name) {
                    case "NumericLastPlantCount":
                        NumericLastPlantCount.Select(0, NumericLastPlantCount.Text.Length);
                        break;
                    case "ComboBoxLastPlantName":
                        ComboBoxLastPlantName.Select(0, ComboBoxLastPlantName.Text.Length);
                        break;
                    case "DateTimePickerLastPlantTime":

                        break;
                    case "DateTimePickerLastRollCallTime":

                        break;
                    case "ButtonUpdate":

                        break;
                }
            }
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// �A�ɓ_�Ă�o�^
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            bool last_roll_call_flag = true;
            int last_plant_count = 0;
            string last_plant_name = "";
            DateTime last_plant_ymd_hms = _defaultDateTime;
            DateTime last_roll_call_ymd_hms = _defaultDateTime;
            /*
             * ���͍��ڂ̃`�F�b�N
             */


            try {
                _vehicleDispatchDetailDao.SetLastRollCallFlag(_operationDate, (int)_setControlEx.Tag, last_roll_call_flag, last_plant_count, last_plant_name, last_plant_ymd_hms, last_roll_call_ymd_hms);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// ButtonClear_Click
        /// �A�ɓ_�Ă��폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e) {
            bool last_roll_call_flag = false;
            int last_plant_count = 0;
            string last_plant_name = "";
            DateTime last_plant_ymd_hms = _defaultDateTime;
            DateTime last_roll_call_ymd_hms = _defaultDateTime;

        }
    }
}