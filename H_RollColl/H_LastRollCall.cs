/*
 * 2024-02-19
 */
using H_Common;

using H_ControlEx;

using H_Dao;

using Vo;

namespace H_RollColl {
    public partial class H_LastRollCall : Form {
        private H_SetLabel _hSetLabel;
        private readonly DateTime _operationDate;
        private readonly int _cellNumber;
        private readonly int _setCode;
        // 2024-06-12 追加
        private readonly H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;
        /*
         * H_Common 
         */
        private readonly Date _date = new();
        /*
         * Dao
         */
        private readonly H_LastRollCallDao _hLastRollCallDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;

        /// <summary>
        /// コンストラクター（オーバーロード）
        /// 2024-06-12
        /// LastRollCallの記録の仕方を変更する。
        /// int cellNumber, int setCode, DateTime operationDateだと、同一のSetCodeに対して区別できないためです。
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hSetLabel"></param>
        /// <param name="hVehicleDispatchDetailVo"></param>
        public H_LastRollCall(ConnectionVo connectionVo, H_SetLabel hSetLabel, H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            _hSetLabel = hSetLabel;
            _operationDate = hVehicleDispatchDetailVo.OperationDate;
            _cellNumber = hVehicleDispatchDetailVo.CellNumber;
            _setCode = hVehicleDispatchDetailVo.SetCode;
            // 2024-06-12 追加
            _hVehicleDispatchDetailVo = hVehicleDispatchDetailVo;
            /*
             * Dao
             */
            _hLastRollCallDao = new(connectionVo);
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.Size = new Size(325, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            // 組名を表示する
            HLabelExSetName.Text = string.Concat(((H_SetMasterVo)hSetLabel.Tag).SetName, " 組");
            if (_hLastRollCallDao.ExistenceHLastRollCall(hVehicleDispatchDetailVo)) {
                this.SetControl(_hLastRollCallDao.SelectOneHLastRollCall(hVehicleDispatchDetailVo));
            } else {
                this.InitializeControl();
            }
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            // 時刻のズレが出ないようにここで１度だけ代入する
            H_LastRollCallVo hLastRollCallVo = SetVo();
            try {
                if (_hLastRollCallDao.ExistenceHLastRollCall(_hVehicleDispatchDetailVo)) {
                    try {
                        _hVehicleDispatchDetailDao.UpdateLastRollCall(HCheckBoxExLastRollCallCancel.Checked, _cellNumber, hLastRollCallVo);
                        _hLastRollCallDao.UpdateOneHLastRollCall(hLastRollCallVo);
                        /*
                         * 2024-06-13追加
                         * LastRollCallYmdHmsに更新した値を入れておかないと、SQLキーが違ってしまうので次の呼び出しのさいに正常に処理されない
                         */
                        _hVehicleDispatchDetailVo.LastRollCallYmdHms = hLastRollCallVo.LastRollCallYmdHms;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                } else {
                    try {
                        _hVehicleDispatchDetailDao.UpdateLastRollCall(HCheckBoxExLastRollCallCancel.Checked, _cellNumber, hLastRollCallVo);
                        _hLastRollCallDao.InsertOneHLastRollCall(hLastRollCallVo);
                        /*
                         * 2024-06-13追加
                         * LastRollCallYmdHmsに更新した値を入れておかないと、SQLキーが違ってしまうので次の呼び出しのさいに正常に処理されない
                         */
                        _hVehicleDispatchDetailVo.LastRollCallYmdHms = hLastRollCallVo.LastRollCallYmdHms;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            _hSetLabel.LastRollCallFlag = !HCheckBoxExLastRollCallCancel.Checked;
            this.Close();
        }

        /// <summary>
        /// H_LastRollCallVoに値をセットする
        /// </summary>
        /// <returns></returns>
        private H_LastRollCallVo SetVo() {
            H_LastRollCallVo hLastRollCallVo = new();
            hLastRollCallVo.SetCode = _setCode;
            hLastRollCallVo.OperationDate = HDateTimePickerExOperationDate.GetValue();
            hLastRollCallVo.FirstRollCallYmdHms = _date.GetStringTimeToDateTime(HDateTimePickerExOperationDate.GetValue(), HMaskedTextBoxExFirstRollCallTime.Text);
            hLastRollCallVo.LastPlantCount = (int)HNumericUpDownExLastPlantCount.Value;
            hLastRollCallVo.LastPlantName = HComboBoxExLastPlantName.Text;
            hLastRollCallVo.LastPlantYmdHms = _date.GetStringTimeToDateTime(HDateTimePickerExOperationDate.GetValue(), HMaskedTextBoxExLastPlantYmdHms.Text);
            hLastRollCallVo.LastRollCallYmdHms = _date.GetStringTimeToDateTime(HDateTimePickerExOperationDate.GetValue(), HMaskedTextBoxExLastRollCallYmdHms.Text);
            hLastRollCallVo.FirstOdoMeter = HNumericUpDownExFirstOdoMeter.Value;
            hLastRollCallVo.LastOdoMeter = HNumericUpDownExLastOdoMeter.Value;
            hLastRollCallVo.OilAmount = HNumericUpDownExOilAmount.Value;
            return hLastRollCallVo;
        }

        /// <summary>
        /// SetControl
        /// </summary>
        /// <param name="hLastRollCallVo"></param>
        private void SetControl(H_LastRollCallVo hLastRollCallVo) {
            HDateTimePickerExOperationDate.SetValueJp(hLastRollCallVo.OperationDate.Date);
            HMaskedTextBoxExFirstRollCallTime.Text = hLastRollCallVo.FirstRollCallYmdHms.ToString("HH:mm");
            HNumericUpDownExLastPlantCount.Value = hLastRollCallVo.LastPlantCount;
            HComboBoxExLastPlantName.Text = hLastRollCallVo.LastPlantName;
            HMaskedTextBoxExLastPlantYmdHms.Text = hLastRollCallVo.LastPlantYmdHms.ToString("HH:mm");
            HMaskedTextBoxExLastRollCallYmdHms.Text = hLastRollCallVo.LastRollCallYmdHms.ToString("HH:mm");
            HNumericUpDownExFirstOdoMeter.Value = hLastRollCallVo.FirstOdoMeter;
            HNumericUpDownExLastOdoMeter.Value = hLastRollCallVo.LastOdoMeter;
            HNumericUpDownExOilAmount.Value = hLastRollCallVo.OilAmount;
        }

        /// <summary>
        /// InitializeControl
        /// </summary>
        private void InitializeControl() {
            HDateTimePickerExOperationDate.Value = _operationDate.Date;
            HMaskedTextBoxExFirstRollCallTime.Text = _hVehicleDispatchDetailDao.GetStaffRollCallYmdHms1(_cellNumber, _operationDate).ToString("HH:mm");
            HNumericUpDownExLastPlantCount.Value = 0;
            HComboBoxExLastPlantName.Text = string.Empty;
            HMaskedTextBoxExLastPlantYmdHms.Text = string.Empty;
            HMaskedTextBoxExLastRollCallYmdHms.Text = string.Empty;
            HNumericUpDownExFirstOdoMeter.Value = 0;
            HNumericUpDownExLastOdoMeter.Value = 0;
            HNumericUpDownExOilAmount.Value = 0;
        }

        private void H_LastRollCall_KeyDown(object sender, KeyEventArgs e) {
            bool forward;
            if (e.KeyCode == Keys.Enter) {
                // Shiftキーが押されているかの判定
                forward = e.Modifiers != Keys.Shift;
                // タブオーダー順で次のコントロールにフォーカスを移動
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
            }
        }

        /// <summary>
        /// H_LastRollCall_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LastRollCall_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
