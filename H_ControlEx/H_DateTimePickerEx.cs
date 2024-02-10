using System.Globalization;

namespace H_ControlEx {
    public partial class H_DateTimePickerEx : DateTimePicker {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        /// <summary>
        /// 言語カルチャーを設定
        /// </summary>
        private readonly CultureInfo cultureInfo = new("Ja-JP", true);
        /// <summary>
        /// 言語フラグ teur:和暦 false:西暦
        /// </summary>
        private bool cultureFlag = true;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_DateTimePickerEx() {
            // 言語カルチャーを設定
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.CustomFormat = string.Concat(" ", DateTime.Now.ToString("yyyy年MM月dd日(dddd)"));
            this.Format = DateTimePickerFormat.Custom;
            this.Height = 23;
            this.Value = DateTime.Today;
            this.Width = 180;
            /*
             * ToolTip初期化
             */
            ToolTip toolTip = new();
            toolTip.InitialDelay = 500; // ToolTipが表示されるまでの時間
            toolTip.ReshowDelay = 1000; // ToolTipが表示されている時に、別のToolTipを表示するまでの時間
            toolTip.AutoPopDelay = 10000; // ToolTipを表示する時間
            toolTip.SetToolTip(this, "Press 'ESC' brank\nPress 'Ctrl+A' 西暦\nPress 'Ctrl+J' 和暦");
            /*
             * Eventを登録
             */
            this.CloseUp += H_DateTimePickerEx_CloseUp;
            this.KeyDown += H_DateTimePickerEx_KeyDown;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        /// <summary>
        /// H_DateTimePickerEx_CloseUp
        /// カレンダーを閉じた時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_DateTimePickerEx_CloseUp(object sender, EventArgs e) {
            if (this.CustomFormat != " ") {
                if (cultureFlag) {
                    this.CustomFormat = string.Concat(" ", this.Value.ToString("ggyy年MM月dd日(dddd)", cultureInfo));
                } else {
                    this.CustomFormat = string.Concat(" ", this.Value.ToString("yyyy年MM月dd日(dddd)"));
                }
            }
        }

        /// <summary>
        /// H_DateTimePicker_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_DateTimePickerEx_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                /*
                 * クリア表示
                 */
                case Keys.Escape:
                    this.CustomFormat = " ";
                    this.Refresh();
                    break;
                /*
                 * 西暦で表示
                 * ブランクの場合はDateTime.Nowを入れる。ブランクでない場合はthis.valueを変換する。
                 */
                case Keys.Control | Keys.A:
                    cultureFlag = false;
                    if (this.CustomFormat == " ") {
                        this.CustomFormat = string.Concat(" ", DateTime.Now.ToString("yyyy年MM月dd日(dddd)"));
                        this.Refresh();
                    } else {
                        this.CustomFormat = string.Concat(" ", this.Value.ToString("yyyy年MM月dd日(dddd)"));
                        this.Refresh();
                    }
                    break;
                /*
                 * 和暦で表示
                 * ブランクの場合はDateTime.Nowを入れる。ブランクでない場合はthis.valueを変換する。
                 */
                case Keys.Control | Keys.J:
                    cultureFlag = true;
                    if (this.CustomFormat == " ") {
                        this.CustomFormat = string.Concat(" ", DateTime.Now.ToString("ggyy年MM月dd日(dddd)", cultureInfo));
                        this.Refresh();
                    } else {
                        this.CustomFormat = string.Concat(" ", this.Value.ToString("ggyy年MM月dd日(dddd)", cultureInfo));
                        this.Refresh();
                    }
                    break;
            }
        }

        /// <summary>
        /// GetValue
        /// ブランクだったら 1900-01-01 を返す
        /// </summary>
        /// <returns></returns>
        public DateTime GetValue() {
            if (this.CustomFormat == " ") {
                return _defaultDateTime;
            } else {
                return this.Value;
            }
        }

        /// <summary>
        /// GetValueJp
        /// </summary>
        /// <returns></returns>
        public string GetValueJp() {
            return this.Value.ToString("ggy年M月d日(dddd)", cultureInfo);
        }

        /// <summary>
        /// SetBlank
        /// </summary>
        public void SetBlank() {
            this.CustomFormat = " ";
            this.Value = _defaultDateTime;
            this.Refresh();
        }

        /// <summary>
        /// SetValue
        /// Value値を設定する
        /// 1900-01-01の場合はブランクを表示する
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetValue(DateTime dateTime) {
            if (dateTime.Date != _defaultDateTime.Date) {
                this.CustomFormat = string.Concat(" ", dateTime.ToString("ggyy年MM月dd日(dddd)", cultureInfo));
                this.Refresh();
            } else {
                this.CustomFormat = " ";
                this.Refresh();
            }
        }
    }
}
