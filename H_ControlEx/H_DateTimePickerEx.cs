using System.Globalization;

namespace H_ControlEx {
    public partial class H_DateTimePickerEx : DateTimePicker {
        // 言語カルチャーを設定
        private readonly CultureInfo cultureInfo = new("Ja-JP", true);

        public H_DateTimePickerEx() {
            // 言語カルチャーを設定
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.CustomFormat = "yyyy年MM月dd日(dddd)";
            this.Format = DateTimePickerFormat.Custom;
            this.Height = 23;
            this.Value = DateTime.Today;
            this.Width = 180;
            this.Refresh();
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
            this.KeyDown += H_DateTimePicker_KeyDown;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        private void H_DateTimePicker_KeyDown(object sender, KeyEventArgs e) {
            switch(e.KeyData) {
                /*
                 * クリア表示
                 */
                case Keys.Escape:
                    this.CustomFormat = " ";
                    this.Refresh();
                    break;
                /*
                 * 西暦で表示
                 */
                case Keys.Control | Keys.A:
                    this.CustomFormat = string.Concat(" ", this.Value.ToString("yyyy年MM月dd日(dddd)"));
                    this.Refresh();
                    break;
                /*
                 * 和暦で表示
                 */
                case Keys.Control | Keys.J:
                    this.CustomFormat = string.Concat(this.Value.ToString("ggyy", cultureInfo) + "年MM月dd日(dddd)");
                    this.Refresh();
                    break;
            }
        }
    }
}
