/*
 * 2023-10-31
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_StaffLabel : Label {
        private Image _imageStaffLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * Vo
         */
        private readonly H_StaffMasterVo _staffMasterVo;
        /*
          * Fontの定義
          */
        private readonly Font _drawFontStaffLabel = new("メイリオ", 13, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_StaffLabel(H_StaffMasterVo hStaffMasterVo) {
            /*
             * Vo
             */
            _staffMasterVo = hStaffMasterVo;

            _imageStaffLabel = Properties.Resources.StaffLabel;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 4;
            this.Margin = new Padding(2);
            this.Name = "H_StaffLabel";
            this.Tag = hStaffMasterVo;
            this.Width = (int)_panelWidth - 4;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            /*
             * Label Fill
             */
            e.Graphics.DrawImage(_imageStaffLabel, 2, 1, _panelWidth - 8, _panelHeight - 6);
            /*
             * 文字(車両)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat.LineAlignment = StringAlignment.Center;
            string number = string.Concat(_staffMasterVo.DisplayName);
            e.Graphics.DrawString(number, _drawFontStaffLabel, new SolidBrush(Color.Black), new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
        }
    }
}
