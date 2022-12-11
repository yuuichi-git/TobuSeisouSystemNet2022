using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerEx : DateTimePicker {

        public DateTimePickerEx() {
            InitializeComponent();

            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " yyyy年MM月dd日(dddd)";
            /*
             * SetControlExのイベントを登録
             */
            this.KeyPress += new KeyPressEventHandler(this.DateTimePickerEx_KeyPress);
        }

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

        private void SetDateTime() {
            this.CustomFormat = " yyyy年MM月dd日(dddd)";
        }

        public string GetJpValue() {
            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            string jpDate = this.Value.ToString("gg y年", Japanese);
            return jpDate;
        }
    }
}
