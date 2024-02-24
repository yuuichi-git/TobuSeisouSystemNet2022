/*
 * 2024-02-19
 */
using H_Dao;

using H_Vo;

namespace H_RollColl {
    public partial class H_LastRollCall : Form {
        private readonly int _setCode;
        private readonly DateTime _operationDateTime;
        /*
         * Dao
         */
        private readonly H_LastRollCallDao _hLastRollCallDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_LastRollCall(ConnectionVo connectionVo, int setCode, DateTime dateTime) {
            _setCode = setCode;
            _operationDateTime = dateTime;
            /*
             * Dao
             */
            _hLastRollCallDao = new H_LastRollCallDao(connectionVo);
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.Size = new Size(325, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            if (_hLastRollCallDao.ExistenceHLastRollCallVo(setCode, dateTime.Date)) {
                this.SetControl(_hLastRollCallDao.SelectOneHLastRollCallVo(setCode, dateTime.Date));
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
                    _hLastRollCallDao.UpdateOneHLastRollCallVo(CreateHLastRollCallVo());
                } else {
                    _hLastRollCallDao.InsertOneHLastRollCallVo(CreateHLastRollCallVo());
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            this.Close();
        }

        /// <summary>
        /// CreateHLastRollCallVo
        /// </summary>
        /// <returns></returns>
        private H_LastRollCallVo CreateHLastRollCallVo() {
            H_LastRollCallVo hLastRollCallVo = new();
            hLastRollCallVo.SetCode = _setCode;
            hLastRollCallVo.OperationDate = _operationDateTime;
            hLastRollCallVo.FirstRollCallHms = HMaskedTextBoxExFirstRollCallTime.Text;
            hLastRollCallVo.LastPlantCount = (int)HNumericUpDownExLastPlantCount.Value;
            hLastRollCallVo.LastPlantName = HComboBoxExLastPlantName.Text;
            hLastRollCallVo.LastPlantHms = HMaskedTextBoxExLastPlantYmdHms.Text;
            hLastRollCallVo.LastRollCallHms = HMaskedTextBoxExLastRollCallYmdHms.Text;
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
            HDateTimePickerExOperationDate.Value = hLastRollCallVo.OperationDate.Date;
            HMaskedTextBoxExFirstRollCallTime.Text = hLastRollCallVo.FirstRollCallHms;
            HNumericUpDownExLastPlantCount.Value = hLastRollCallVo.LastPlantCount;
            HComboBoxExLastPlantName.Text = hLastRollCallVo.LastPlantName;
            HMaskedTextBoxExLastPlantYmdHms.Text = hLastRollCallVo.LastPlantHms;
            HMaskedTextBoxExLastRollCallYmdHms.Text = hLastRollCallVo.LastRollCallHms;
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
