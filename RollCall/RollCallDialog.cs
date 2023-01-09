using Common;

using ControlEx;

using Dao;

using Vo;

namespace RollCall {
    public partial class RollCallDialog : Form {
        private DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DateTime _operationDate;
        private readonly SetControlEx _setControlEx;
        private readonly SetLabelEx _setLabelEx;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        /*
         * Vo
         */
        VehicleDispatchDetailVo _vehicleDispatchDetailVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="setControlEx"></param>
        /// <param name="setLabelEx"></param>
        public RollCallDialog(ConnectionVo connectionVo, DateTime operationDate, SetControlEx setControlEx, SetLabelEx setLabelEx) {
            _operationDate = operationDate;
            _setControlEx = setControlEx;
            _setLabelEx = setLabelEx;
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);

            InitializeComponent();
            /*
             * DBから読込んでControlへ入れる
             */
            _vehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectOneVehicleDispatchDetail(operationDate.Date, ((SetMasterVo)setLabelEx.Tag).Set_code);
            NumericLastPlantCount.Value = _vehicleDispatchDetailVo.Last_plant_count;
            ComboBoxLastPlantName.Text = _vehicleDispatchDetailVo.Last_plant_name;
            MaskedTextBoxLastPlantTime.Text = _vehicleDispatchDetailVo.Last_plant_hm;
            MaskedTextBoxLastRollCallTime.Text = _vehicleDispatchDetailVo.Last_roll_call_hm;

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
                    case "MaskedTextBoxLastPlantTime":

                        break;
                    case "MaskedTextBoxLastRollCallTime":

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
            bool last_roll_call_flag;
            int last_plant_count;
            string last_plant_name;
            string last_plant_ymd_hms;
            string last_roll_call_ymd_hms;
            /*
             * 入力項目のチェック
             */
            last_roll_call_flag = true;
            if((int)NumericLastPlantCount.Value > 0) {
                last_plant_count = (int)NumericLastPlantCount.Value;
            } else {
                MessageBox.Show("搬入回数が不正です", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(ComboBoxLastPlantName.Text.Length > 0) {
                last_plant_name = ComboBoxLastPlantName.Text;
            } else {
                MessageBox.Show("最終搬入場所が不正です", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MaskedTextBoxLastPlantTime.Text != "") {
                last_plant_ymd_hms = MaskedTextBoxLastPlantTime.Text;
            } else {
                MessageBox.Show("最終搬入時間が不正です", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MaskedTextBoxLastRollCallTime.Text != "") {
                last_roll_call_ymd_hms = MaskedTextBoxLastRollCallTime.Text;
            } else {
                MessageBox.Show("帰庫点呼時間が不正です", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                _vehicleDispatchDetailDao.SetLastRollCallFlag(_operationDate,
                                                              (int)_setControlEx.Tag,
                                                              last_roll_call_flag,
                                                              last_plant_count,
                                                              last_plant_name,
                                                              last_plant_ymd_hms,
                                                              last_roll_call_ymd_hms);
                // Labelをセット
                _setLabelEx.SetLastRollCallFlag(true);
                var dialogResult = MessageBox.Show("帰庫点呼記録を登録しました", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                switch(dialogResult) {
                    case DialogResult.OK:
                        Dispose();
                        break;
                }
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
            /*
             * データをリセットする
             */
            bool last_roll_call_flag = false;
            int last_plant_count = 0;
            string last_plant_name = "";
            string last_plant_ymd_hms = "";
            string last_roll_call_ymd_hms = "";
            try {
                _vehicleDispatchDetailDao.SetLastRollCallFlag(_operationDate,
                                                              (int)_setControlEx.Tag,
                                                              last_roll_call_flag,
                                                              last_plant_count,
                                                              last_plant_name,
                                                              last_plant_ymd_hms,
                                                              last_roll_call_ymd_hms);
                // Labelをセット
                _setLabelEx.SetLastRollCallFlag(false);
                var dialogResult = MessageBox.Show("帰庫点呼記録を削除しました", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                switch(dialogResult) {
                    case DialogResult.OK:
                        Dispose();
                        break;
                }
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }
    }
}