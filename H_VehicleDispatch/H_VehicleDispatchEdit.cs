/*
 * 2024-02-22 
 */
using H_Common;

using H_ControlEx;

using H_Vo;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchEdit : Form {
        private readonly Date _date = new();
        private bool _closeFlag = false;
        private int _selectFiscalYear = 2023;
        private string _selectDayOfWeek = string.Empty;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="dateTime"></param>
        public H_VehicleDispatchEdit(ConnectionVo connectionVo, DateTime dateTime) {
            /*
             * InitializeControl
             */
            InitializeComponent();
            /*
             * 初期値を代入
             */
            HNumericUpDownExFinancialYear.Value = _date.GetFiscalYear(dateTime);
            SelectFiscalYear = _date.GetFiscalYear(dateTime);
            switch (dateTime.DayOfWeek) {
                case DayOfWeek.Monday:
                    HRadioButtonExMonday.Checked = true;
                    _selectDayOfWeek = "月";
                    break;
                case DayOfWeek.Tuesday:
                    HRadioButtonExTuesday.Checked = true;
                    _selectDayOfWeek = "火";
                    break;
                case DayOfWeek.Wednesday:
                    HRadioButtonExWednesday.Checked = true;
                    _selectDayOfWeek = "水";
                    break;
                case DayOfWeek.Thursday:
                    HRadioButtonExThursday.Checked = true;
                    _selectDayOfWeek = "木";
                    break;
                case DayOfWeek.Friday:
                    HRadioButtonExFriday.Checked = true;
                    _selectDayOfWeek = "金";
                    break;
                case DayOfWeek.Saturday:
                    HRadioButtonExSaturday.Checked = true;
                    _selectDayOfWeek = "土";
                    break;
                case DayOfWeek.Sunday:
                    HRadioButtonExSunday.Checked = true;
                    _selectDayOfWeek = "日";
                    break;
            }
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            CloseFlag = true;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HNumericUpDownExFinancialYear_ValueChanged(object sender, EventArgs e) {
            SelectFiscalYear = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HRadioButtonEx_CheckedChanged(object sender, EventArgs e) {
            _selectDayOfWeek = (string)((H_RadioButtonEx)sender).Tag;
        }

        /// <summary>
        /// 閉じられた方法
        /// true:更新して閉じられた false:Closeボタンで閉じられた
        /// </summary>
        public bool CloseFlag {
            get => _closeFlag;
            set => _closeFlag = value;
        }
        /// <summary>
        /// 会計年度
        /// </summary>
        public int SelectFiscalYear {
            get => _selectFiscalYear;
            set => _selectFiscalYear = value;
        }
        /// <summary>
        /// 曜日
        /// </summary>
        public string SelectDayOfWeek {
            get => _selectDayOfWeek;
            set => _selectDayOfWeek = value;
        }
    }
}
