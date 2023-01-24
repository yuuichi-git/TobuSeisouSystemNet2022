using System.Globalization;

namespace ControlEx {
    public partial class UcDateTimeJp : UserControl {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01, 00, 00, 00, 000);
        // 和暦設定
        private readonly CultureInfo cultureInfo = new CultureInfo("ja-JP");

        /// <summary>
        /// コンストラクター
        /// </summary>
        public UcDateTimeJp() {
            InitializeComponent();
            this.Height = 23;
            this.MaskedTextBox1.ReadOnly = true;
            this.Width = 183;
            // 和暦設定
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
        }

        /*
         * 内部のControlの処理
         */
        /// <summary>
        /// TextBox1_TextChanged
        /// Textが空白だった場合、Valueを"1900-01-01"にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e) {
            if(((TextBox)sender).Text.Length > 0) {
            } else {
                DateTimePicker1.Value = _defaultDateTime;
            }
        }
        /// <summary>
        /// DateTimePicker1_ValueChanged
        /// "0001-01-01"か"1900-01-01"だった場合は空白を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            string outputDate;
            switch(((DateTimePicker)sender).Value.ToString("yyyy-MM-dd")) {
                case "0001-01-01":
                case "1900-01-01":
                    DateTimePicker1.Value = _defaultDateTime;
                    outputDate = "";
                    break;
                default:
                    outputDate = ((DateTimePicker)sender).Value.ToString("ggyy年MM月dd日(dddd)", cultureInfo);
                    break;
            }
            this.MaskedTextBox1.Text = outputDate;
        }

        /*
         * 公開メソッド
         */
        /// <summary>
        /// GetText
        /// 値を取得する
        /// </summary>
        /// <returns></returns>
        public string GetText() {
            return this.MaskedTextBox1.Text;
        }
        /// <summary>
        /// GetValue
        /// 値を取得する
        /// </summary>
        /// <returns></returns>
        public DateTime GetValue() {
            return this.DateTimePicker1.Value;
        }
        /// <summary>
        /// SetBlank
        /// 表示を空白にする
        /// </summary>
        public void SetBlank() {
            this.DateTimePicker1.Value = _defaultDateTime;
            this.MaskedTextBox1.Text = "";
        }
        /// <summary>
        /// SetReadOnly
        /// 表示を読み取り専用にする
        /// </summary>
        /// <param name="readOnly"></param>
        public void SetReadOnly(bool readOnly) {
            this.MaskedTextBox1.ReadOnly = readOnly;
        }
        /// <summary>
        /// SetValue
        /// 値をセットする
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetValue(DateTime dateTime) {
            this.DateTimePicker1.Value = dateTime;
        }
    }
}
