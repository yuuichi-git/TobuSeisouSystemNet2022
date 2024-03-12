/*
 * 2024-02-19
 */
using System.Diagnostics;

using H_Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

namespace H_RollColl {
    public partial class H_LastRollCall : Form {
        private H_SetLabel _hSetLabel;
        private readonly DateTime _operationDateTime;
        private readonly int _cellNumber;
        private readonly int _setCode;
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
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_LastRollCall(ConnectionVo connectionVo, H_SetLabel hSetLabel, int cellNumber, int setCode, DateTime operationDate) {
            _hSetLabel = hSetLabel;
            _operationDateTime = operationDate;
            _cellNumber = cellNumber;
            _setCode = setCode;
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

            if (_hLastRollCallDao.ExistenceHLastRollCallVo(setCode, operationDate.Date)) {
                this.SetControl(_hLastRollCallDao.SelectOneHLastRollCallVo(setCode, operationDate.Date));
            } else {
                InitializeControl();
            }
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            /*
             * バリデーション
             */

            try {
                if (_hLastRollCallDao.ExistenceHLastRollCallVo(_setCode, _operationDateTime.Date)) {
                    try {
                        _hVehicleDispatchDetailDao.UpdateLastRollCall(HCheckBoxExLastRollCallCancel.Checked, _cellNumber, CreateHLastRollCallVo());
                        _hLastRollCallDao.UpdateOneHLastRollCallVo(CreateHLastRollCallVo());
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                } else {
                    try {
                        _hVehicleDispatchDetailDao.UpdateLastRollCall(HCheckBoxExLastRollCallCancel.Checked, _cellNumber, CreateHLastRollCallVo());
                        _hLastRollCallDao.InsertOneHLastRollCallVo(CreateHLastRollCallVo());
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
        /// CreateHLastRollCallVo
        /// </summary>
        /// <returns></returns>
        private H_LastRollCallVo CreateHLastRollCallVo() {
            H_LastRollCallVo hLastRollCallVo = new();
            hLastRollCallVo.SetCode = _setCode;
            hLastRollCallVo.OperationDate = HDateTimePickerExOperationDate.GetValue();
            Debug.WriteLine(HMaskedTextBoxExFirstRollCallTime.Text);
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
            HDateTimePickerExOperationDate.SetValue(hLastRollCallVo.OperationDate.Date);
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
            HDateTimePickerExOperationDate.Value = _operationDateTime.Date;
            HMaskedTextBoxExFirstRollCallTime.Text = string.Empty;
            HNumericUpDownExLastPlantCount.Value = 0;
            HComboBoxExLastPlantName.Text = string.Empty;
            HMaskedTextBoxExLastPlantYmdHms.Text = string.Empty;
            HMaskedTextBoxExLastRollCallYmdHms.Text = string.Empty;
            HNumericUpDownExFirstOdoMeter.Value = 0;
            HNumericUpDownExLastOdoMeter.Value = 0;
            HNumericUpDownExOilAmount.Value = 0;
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
