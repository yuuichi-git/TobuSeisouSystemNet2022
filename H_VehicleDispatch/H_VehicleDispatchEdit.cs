/*
 * 2024-02-22 
 */
using H_Common;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchEdit : Form {
        private readonly Date _date = new();

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="dateTime"></param>
        public H_VehicleDispatchEdit(DateTime dateTime) {
            /*
             * InitializeControl
             */
            InitializeComponent();
            /*
             * 初期値を代入
             */
            HNumericUpDownExFinancialYear.Value = _date.GetFiscalYear(dateTime);
            switch (dateTime.DayOfWeek) {
                case DayOfWeek.Monday:
                    HRadioButtonExMonday.Checked = true;
                    break;
                case DayOfWeek.Tuesday:
                    HRadioButtonExTuesday.Checked = true;
                    break;
                case DayOfWeek.Wednesday:
                    HRadioButtonExWednesday.Checked = true;
                    break;
                case DayOfWeek.Thursday:
                    HRadioButtonExThursday.Checked = true;
                    break;
                case DayOfWeek.Friday:
                    HRadioButtonExFriday.Checked = true;
                    break;
                case DayOfWeek.Saturday:
                    HRadioButtonExSaturday.Checked = true;
                    break;
                case DayOfWeek.Sunday:
                    HRadioButtonExSunday.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// HButtonExCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
