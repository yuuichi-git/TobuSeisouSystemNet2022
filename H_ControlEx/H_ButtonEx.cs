namespace H_ControlEx {
    public partial class H_ButtonEx : Button {
        /*
         * Fontの定義
         */
        private readonly Font _drawFontStaffLabel = new("メイリオ", 14, FontStyle.Regular, GraphicsUnit.Pixel);

        private string _textDirectionVertical;

        public H_ButtonEx() {
            InitializeComponent();
            _textDirectionVertical = string.Empty;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            // Buttonの基本描画
            base.OnPaint(e);
            /*
             * 文字(氏名)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(_textDirectionVertical, _drawFontStaffLabel, Brushes.Black, new Rectangle(0, 0, this.Width, this.Height), stringFormat);
        }

        /// <summary>
        /// TextDirectionVertical
        /// 縦書きのテキスト
        /// </summary>
        public string TextDirectionVertical {
            get => _textDirectionVertical;
            set => _textDirectionVertical = value;
        }
    }
}
