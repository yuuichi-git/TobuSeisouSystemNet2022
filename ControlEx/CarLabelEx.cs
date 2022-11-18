using Vo;

namespace ControlEx {
    public partial class CarLabelEx : Label {
        private CarMasterVo _carMasterVo;
        private const int _carLabelHeight = 68;
        private const int _carLabelWidth = 70;

        Font drawFont = new Font("Yu Gothic UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        SolidBrush drawBrushFont = new SolidBrush(Color.Black);
        Color _borderColor = Color.White;
        SolidBrush drowBrushFill;

        public CarLabelEx(CarMasterVo carMasterVo) {
            _carMasterVo = carMasterVo;
            /*
             * 本社・三郷で色を変える
             */
            if (carMasterVo.Garage_flag) {
                _borderColor = Color.White;
                drowBrushFill = new SolidBrush(Color.White);
            } else {
                _borderColor = Color.Blue;
                drowBrushFill = new SolidBrush(Color.PowderBlue);
            }
            InitializeComponent();
            /*
             * CarControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(LabelEx_CellPaint);
        }

        private void LabelEx_CellPaint(object sender, PaintEventArgs e) {
            /*
             * Boderを描画
             */
            Rectangle rectangleBoder = new Rectangle(0, 0, 68, 66);
            ControlPaint.DrawBorder(e.Graphics, rectangleBoder, _borderColor, ButtonBorderStyle.Solid);
            /*
             * Fillを描画
             */
            Rectangle rectangleFill = new Rectangle(2, 2, 64, 62);
            e.Graphics.FillRectangle(drowBrushFill, rectangleFill);

            var stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            var number = string.Concat(_carMasterVo.Registration_number_1, _carMasterVo.Registration_number_2, "\r\n"
                                          , _carMasterVo.Registration_number_3, _carMasterVo.Registration_number_4, "\r\n"
                                          , _carMasterVo.Disguise_kind_1, _carMasterVo.Door_number);
            e.Graphics.DrawString(number, drawFont, drawBrushFont, rectangleFill, stringFormat);
        }

        /// <summary>
        /// CarLabel作成
        /// </summary>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public CarLabelEx CreateLabel() {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = _carLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = _carMasterVo;
            this.Width = _carLabelWidth;
            return this;
        }
    }
}
