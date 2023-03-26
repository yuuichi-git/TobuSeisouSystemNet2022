using Vo;

namespace ControlEx {
    public partial class CarLabelEx : Label {
        /*
         * Labelのサイズ
         */
        private const int _carLabelHeight = 68;
        private const int _carLabelWidth = 70;

        private CarMasterVo _carMasterVo;
        private bool _proxyFlag; // 代番フラグ
        private readonly Color _borderColor = Color.White;
        private readonly Font _drawFont = new Font("Yu Gothic UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly SolidBrush _drowBrushFill;
        private readonly SolidBrush _drawBrushFont = new SolidBrush(Color.Black);

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// </summary>
        /// <param name="carMasterVo"></param>
        public CarLabelEx(CarMasterVo carMasterVo) {
            _carMasterVo = carMasterVo;
            _proxyFlag = false;
            /*
             * 本社・三郷で色を変える
             */
            if(carMasterVo.Garage_flag) {
                _borderColor = Color.White;
                _drowBrushFill = new SolidBrush(Color.White);
            } else {
                _borderColor = Color.Blue;
                _drowBrushFill = new SolidBrush(Color.PowderBlue);
            }
            InitializeComponent();
            /*
             * CarControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// </summary>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <param name="carMasterVo"></param>
        public CarLabelEx(VehicleDispatchDetailVo vehicleDispatchDetailVo, CarMasterVo carMasterVo) {
            _carMasterVo = carMasterVo;
            _proxyFlag = vehicleDispatchDetailVo.Car_proxy_flag;
            /*
             * 本社・三郷で色を変える
             */
            if(carMasterVo.Garage_flag) {
                _borderColor = Color.White;
                _drowBrushFill = new SolidBrush(Color.White);
            } else {
                _borderColor = Color.Blue;
                _drowBrushFill = new SolidBrush(Color.PowderBlue);
            }
            InitializeComponent();
            /*
             * CarControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(LabelEx_CellPaint);
        }

        /// <summary>
        /// LabelEx_CellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_CellPaint(object? sender, PaintEventArgs e) {
            /*
             * Boderを描画
             */
            Rectangle rectangleBoder = new Rectangle(0, 0, 68, 66);
            ControlPaint.DrawBorder(e.Graphics, rectangleBoder, _borderColor, ButtonBorderStyle.Solid);
            /*
             * Fillを描画
             */
            Rectangle rectangleFill = new Rectangle(2, 2, 64, 62);
            e.Graphics.FillRectangle(_drowBrushFill, rectangleFill);
            /*
             * 代車処理を描画
             */
            if(_proxyFlag) {
                e.Graphics.FillRectangle(Brushes.ForestGreen, 4, 3, 60, 5);
                e.Graphics.DrawLine(new Pen(Color.LawnGreen), new Point(2, 5), new Point(65, 5));
            }
            /*
             * 文字(ナンバー)を描画
             */
            var stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            var number = string.Concat(_carMasterVo.Registration_number_1, _carMasterVo.Registration_number_2, "\r\n"
                                     , _carMasterVo.Registration_number_3, _carMasterVo.Registration_number_4, "\r\n"
                                     , _carMasterVo.Disguise_kind_1, _carMasterVo.Door_number != 0 ? _carMasterVo.Door_number : " ");
            e.Graphics.DrawString(number,
                                  _drawFont,
                                  _drawBrushFont,
                                  rectangleFill,
                                  stringFormat);
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

        /// <summary>
        /// SetProxyFlag
        /// </summary>
        /// <param name="proxyFlag"></param>
        public void SetProxyFlag(bool proxyFlag) {
            _proxyFlag = proxyFlag;
            this.Refresh();
        }
    }
}
