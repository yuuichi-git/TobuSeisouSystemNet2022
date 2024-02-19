/*
 * 2024-02-19
 */
namespace H_ControlEx {
    public partial class H_TimeEx : DateTimePicker {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01, 00, 00, 00);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_TimeEx() {
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.CustomFormat = " HH時mm分";
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
            toolTip.SetToolTip(this, "Press 'ESC' brank\nPress 'Ctrl+A' 時刻表示");
            /*
             * Eventを登録
             */
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
        /// H_DateTimePickerEx_KeyDown
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
                    if (this.CustomFormat == " ") {
                        this.CustomFormat = " HH時mm分";
                        this.Value = _defaultDateTime;
                        this.Refresh();
                    } else {
                        this.CustomFormat = " HH時mm分";
                        this.Value = DateTime.Today;
                        this.Refresh();
                    }
                    break;
            }
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
        /// GetValue
        /// ブランクの場合は'1900-01-01 0:00:00'を入れる。ブランクでない場合はthis.value。
        /// </summary>
        /// <returns></returns>
        public DateTime GetValue() {
            if (this.CustomFormat == " ") {
                return _defaultDateTime;
            } else {
                return this.Value;
            }
        }
    }
}
