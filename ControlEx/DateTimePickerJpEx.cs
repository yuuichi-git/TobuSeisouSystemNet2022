/*
 * 2023-05-12
 */
using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerJpEx : DateTimePicker {
        // 言語カルチャーを設定
        private readonly CultureInfo Japanese = new("Ja-JP", true);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DateTimePickerJpEx() {
            /*
             * Controlを初期化
             */
            InitializeComponent();
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " ";
            /*
             * イベントを登録
             */
            this.ValueChanged += new EventHandler(this.DateTimePickerJpEx_ValueChanged);
            this.KeyPress += new KeyPressEventHandler(this.DateTimePickerJpEx_KeyPress);
        }

        /// <summary>
        /// DateTimePickerJpEx_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx_ValueChanged(object? sender, EventArgs e) {
                this.CustomFormat = string.Concat(" ", this.Value.ToString("ggyy", Japanese) + "年MM月dd日(dddd)");
        }

        /// <summary>
        /// DateTimePickerJpEx_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx_KeyPress(object? sender, KeyPressEventArgs e) {
            if((e.KeyChar & (char)Keys.Escape) == (char)Keys.Escape) {
                this.CustomFormat = string.Concat(" ");
                this.Refresh();
            } else {
                this.CustomFormat = string.Concat(" ", this.Value.ToString("ggyy", Japanese) + "年MM月dd日(dddd)");
                this.Value = DateTime.Now;
                this.Refresh();
                return;
            }
        }
    }
}
