using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerJp : UserControl {
        // 和暦設定
        private readonly CultureInfo Japanese = new CultureInfo("ja-JP");

        public DateTimePickerJp() {
            // 和暦設定
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();

            InitializeComponent();
            this.Width = 183;
            this.Height = 23;

        }

        /*
         * 内部のControlの処理
         */
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            TextBox1.Text = ((DateTimePicker)sender).Value.ToString("gg yy年MM月dd日(dddd)", Japanese);
        }

        /*
         * 公開メソッド
         */
        public void SetValue(DateTime dateTime) {
            DateTimePicker1.Value = dateTime;
        }

        public DateTime GetValue() {
            return DateTimePicker1.Value;
        }
    }
}
