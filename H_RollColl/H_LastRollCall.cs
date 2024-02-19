/*
 * 2024-02-19
 */
using H_Vo;

namespace H_RollColl {
    public partial class H_LastRollCall : Form {
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_LastRollCall(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.Size = new Size(325, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            HDateTimePickerExOperationDate.Value = DateTime.Now.Date;
            HTimeExFirstRollCallTime.SetBlank();
            HComboBoxExLastPlantName.Text = string.Empty;
            HTimeExLastPlantYmdHms.SetBlank();
            HTimeExLastRollCallYmdHms.SetBlank();
            HNumericUpDownExFirstOdoMeter.Value = 0;
            HNumericUpDownExLastOdoMeter.Value = 0;
            HNumericUpDownExOilAmount.Value = 0;
        }


    }
}
