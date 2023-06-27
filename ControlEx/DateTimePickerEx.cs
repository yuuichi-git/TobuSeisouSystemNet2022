/*
 * 2023-05-12
 */
using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerEx : DateTimePicker {
        private string _customFormat = "yyyy年MM月dd日(dddd)";

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DateTimePickerEx() {
            /*
             * Controlを初期化
             */
            InitializeComponent();
            /*
             * カスタムに設定
             */
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = _customFormat;
            /*
             * イベントを登録
             */
            this.KeyPress += new KeyPressEventHandler(this.DateTimePickerEx_KeyPress);
        }

        /// <summary>
        /// DateTimePickerEx_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerEx_KeyPress(object? sender, KeyPressEventArgs e) {
            if((e.KeyChar & (char)Keys.Escape) == (char)Keys.Escape) {
                this.CustomFormat = string.Concat(" ");
                this.Refresh();
            } else {
                this.CustomFormat = string.Concat(" ", _customFormat);
                this.Refresh();
                return;
            }
        }

        /// <summary>
        /// GetValue
        /// ブランクの場合、_DefaultDateTimeで返す
        /// </summary>
        /// <returns></returns>
        public DateTime GetValue() {
            if(this.CustomFormat != " ") {
                return this.Value;
            } else {
                return new DateTime(1900, 01, 01, 00, 00, 00);
            }
        }

        /// <summary>
        /// GetJpValue
        /// 和暦表記をstringで返す
        /// </summary>
        /// <returns></returns>
        public string GetJpValue() {
            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            string jpDate = this.Value.ToString("gg y年", Japanese);
            return jpDate;
        }

        /// <summary>
        /// SetBlank
        /// </summary>
        public void SetBlank() {
            this.Value = new DateTime(1900, 01, 01, 0, 00, 00);
            this.CustomFormat = string.Concat(" ");
            this.Refresh();
        }

        /// <summary>
        /// SetValue
        /// Value値を設定する
        /// 1900-01-01の場合はブランクを表示する
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetValue(DateTime dateTime) {
            if(dateTime.Date != new DateTime(1900, 01, 01) || this.CustomFormat != " ") {
                this.Value = dateTime;
                this.CustomFormat = string.Concat(" ", dateTime.ToString("yyyy年MM月dd日(dddd)"));
                this.Refresh();
            } else {
                this.Value = new DateTime(1900, 01, 01, 0, 00, 00);
                this.CustomFormat = string.Concat(" ");
                this.Refresh();
            }
        }
    }
}
