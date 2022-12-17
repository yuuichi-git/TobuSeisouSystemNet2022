using System.Globalization;

namespace ControlEx {
    public partial class UcDateTimeJp : UserControl {
        // 和暦設定
        private readonly CultureInfo Japanese = new CultureInfo("ja-JP");

        /// <summary>
        /// コンストラクター
        /// </summary>
        public UcDateTimeJp() {
            InitializeComponent();
            this.Height = 23;
            this.TextBox1.ReadOnly = false;
            this.Width = 183;
            // 和暦設定
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
        }

        /*
         * 内部のControlの処理
         */
        /// <summary>
        /// DateTimePicker1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            this.TextBox1.Text = ((DateTimePicker)sender).Value.ToString("ggyy年MM月dd日(dddd)", Japanese);
        }

        /*
         * 公開メソッド
         */
        /// <summary>
        /// SetValue
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetValue(DateTime dateTime) {
            this.DateTimePicker1.Value = dateTime;
        }

        /// <summary>
        /// GetValue
        /// </summary>
        /// <returns></returns>
        public DateTime GetValue() {
            return this.DateTimePicker1.Value;
        }

        public void SetReadOnly(bool readOnly) {
            this.TextBox1.ReadOnly = readOnly;
        }
    }
}
