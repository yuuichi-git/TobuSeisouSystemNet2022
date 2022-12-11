using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerEx : DateTimePicker {

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DateTimePickerEx() {
            InitializeComponent();

            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " yyyy年MM月dd日(dddd)";
            /*
             * SetControlExのイベントを登録
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
                SetBrank();
                return;
            } else {
                SetDateTime();
                return;
            }
        }

        /// <summary>
        /// SetBrank
        /// 表示をブランクにする
        /// </summary>
        private void SetBrank() {
            //DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
            this.CustomFormat = " ";
            this.Refresh();
        }

        /// <summary>
        /// SetDateTime
        /// 編集
        /// </summary>
        private void SetDateTime() {
            this.CustomFormat = " yyyy年MM月dd日(dddd)";
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
    }
}
