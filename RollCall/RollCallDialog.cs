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
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="setControlEx"></param>
        /// <param name="setLabelEx"></param>
        public RollCallDialog(ConnectionVo connectionVo, DateTime operationDate, SetControlEx setControlEx) {
            _operationDate = operationDate;
            _setControlEx = setControlEx;
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);

            InitializeComponent();
            // 最初のコントロールテキストを選択状態に設定
            NumericLastPlantCount.Select(0, NumericLastPlantCount.Text.Length);
        }

        public static void Main() {
        }

        private void Control_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                // タブオーダー順で次のコントロールにフォーカスを移動
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
        /// 帰庫点呼を登録
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
             * 入力項目のチェック
             */


            try {
                _vehicleDispatchDetailDao.SetLastRollCallFlag(_operationDate, (int)_setControlEx.Tag, last_roll_call_flag, last_plant_count, last_plant_name, last_plant_ymd_hms, last_roll_call_ymd_hms);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// ButtonClear_Click
        /// 帰庫点呼を削除
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