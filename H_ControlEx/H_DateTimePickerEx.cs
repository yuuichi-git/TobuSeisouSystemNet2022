using System.Globalization;

namespace H_ControlEx {
    public partial class H_DateTimePickerEx : DateTimePicker {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        /// <summary>
        /// 言語カルチャーを設定
        /// </summary>
        private readonly CultureInfo _cultureInfo = new("Ja-JP", true);
        /// <summary>
        /// 言語フラグ teur:和暦 false:西暦
        /// </summary>
        private bool _cultureFlag = true;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_DateTimePickerEx() {
            // 言語カルチャーを設定
            _cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.CustomFormat = " yyyy年MM月dd日(dddd)";
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
            this.ValueChanged += HDateTimePickerEx_ValueChanged;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="paintEventArgs"></param>
        protected override void OnPaint(PaintEventArgs paintEventArgs) {
            base.OnPaint(paintEventArgs);
        }

        /// <summary>
        /// H_DateTimePickerEx_CloseUp
        /// カレンダーを閉じた時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_DateTimePickerEx_CloseUp(object sender, EventArgs e) {
            if (this.CustomFormat != " ") {
                if (_cultureFlag) {
                    this.CustomFormat = this.Value.ToString(" ggyy年MM月dd日(dddd)", _cultureInfo);
                } else {
                    this.CustomFormat = this.Value.ToString(" yyyy年MM月dd日(dddd)");
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
                    this.Value = _defaultDateTime;
                    this.Refresh();
                    break;
                /*
                 * 西暦で表示
                 * ブランクの場合はDateTime.Nowを入れる。ブランクでない場合はthis.valueを変換する。
                 */
                case Keys.Control | Keys.A:
                    _cultureFlag = false;
                    if (this.CustomFormat == " ") {
                        this.CustomFormat = " yyyy年MM月dd日(dddd)";
                        this.Value = _defaultDateTime;
                        this.Refresh();
                    } else {
                        this.CustomFormat = " yyyy年MM月dd日(dddd)";
                        this.Value = DateTime.Today;
                        this.Refresh();
                    }
                    break;
                /*
                 * 和暦で表示
                 * ブランクの場合はDateTime.Nowを入れる。ブランクでない場合はthis.valueを変換する。
                 */
                case Keys.Control | Keys.J:
                    _cultureFlag = true;
                    if (this.CustomFormat == " ") {
                        this.CustomFormat = DateTime.Now.ToString(" ggyy年MM月dd日(dddd)", _cultureInfo);
                        this.Value = _defaultDateTime;
                        this.Refresh();
                    } else {
                        this.CustomFormat = this.Value.ToString(" ggyy年MM月dd日(dddd)", _cultureInfo);
                        this.Value = DateTime.Today;
                        this.Refresh();
                    }
                    break;
            }
        }

        /// <summary>
        /// Value値を更新したとき、Refreshする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerEx_ValueChanged(object sender, EventArgs e) {
            if (this.CustomFormat != " ") {
                if (_cultureFlag) {
                    this.CustomFormat = this.Value.ToString(" ggyy年MM月dd日(dddd)", _cultureInfo);
                    this.Refresh();
                } else {
                    this.CustomFormat = this.Value.ToString(" yyyy年MM月dd日(dddd)");
                    this.Refresh();
                }
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
        /// <returns>和暦を返す</returns>
        public string GetValueJp() {
            return this.Value.ToString(" ggy年M月d日(dddd)", _cultureInfo);
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
        /// SetValueJp
        /// 和暦で設定する
        /// 1900-01-01の場合はブランクを表示する
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetValueJp(DateTime dateTime) {
            if (dateTime.Date != _defaultDateTime.Date) {
                this.CustomFormat = dateTime.ToString(" ggyy年MM月dd日(dddd)", _cultureInfo);
                this.Value = dateTime;
                this.Refresh();
            } else {
                this.CustomFormat = " ";
                this.Value = _defaultDateTime;
                this.Refresh();
            }
        }

        /// <summary>
        /// SetValue
        /// 西暦で設定する
        /// 1900-01-01の場合はブランクを表示する
        /// </summary>
        public void SetValue(DateTime dateTime) {
            if (dateTime.Date != _defaultDateTime.Date) {
                this.CustomFormat = dateTime.ToString(" yyyy年MM月dd日(dddd)");
                this.Value = dateTime;
                this.Refresh();
            } else {
                this.CustomFormat = " ";
                this.Value = _defaultDateTime;
                this.Refresh();
            }
        }
    }
}
