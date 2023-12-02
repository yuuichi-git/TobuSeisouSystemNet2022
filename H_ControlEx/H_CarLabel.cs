/*
 * 2023-10-25
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_CarLabel : Label {
        private Image _imageCarLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * プロパティ
         */
        private int _garageCode = 0; // 出庫地フラグ 0:本社 1:三郷
        private bool _memoFlag = false; // メモフラグ true:メモあり false:メモなし
        /*
         * Vo
         */
        private readonly H_SetControlVo _hSetControlVo;
        private readonly H_CarMasterVo _hCarMasterVo;
        /*
         * 色の定義
         */
        private readonly SolidBrush _brushColorBlack = new(Color.Black);
        private readonly SolidBrush _brushColorWhite = new SolidBrush(Color.White);
        private readonly SolidBrush _brushFillColor;
        /*
         * Fontの定義
         */
        private readonly Font _drawFontCarLabel = new("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        public H_CarLabel(H_SetControlVo hSetControlVo) {
            /*
             * Vo
             */
            _hSetControlVo = hSetControlVo;
            _hCarMasterVo = hSetControlVo.HCarMasterVo;
            /*
             * GarageCode
             * Classification_code
             */
            switch(hSetControlVo.HCarMasterVo.GarageCode) {
                case 1:
                    switch(hSetControlVo.HCarMasterVo.ClassificationCode) {
                        case 10:
                            _imageCarLabel = Properties.Resources.CarLabelWhiteY;
                            break;
                        case 11:
                            _imageCarLabel = Properties.Resources.CarLabelWhiteK;
                            break;
                        default:
                            _imageCarLabel = Properties.Resources.CarLabelWhite;
                            break;
                    }
                    break;
                case 2:
                    switch(hSetControlVo.HCarMasterVo.ClassificationCode) {
                        case 10:
                            _imageCarLabel = Properties.Resources.CarLabelPowerBlueY;
                            break;
                        case 11:
                            _imageCarLabel = Properties.Resources.CarLabelPowerBlueK;
                            break;
                        default:
                            _imageCarLabel = Properties.Resources.CarLabelPowerBlue;
                            break;
                    }
                    break;
            }
            /*
             * 本社・三郷で色を変える
             */
            switch(hSetControlVo.HCarMasterVo.GarageCode) {
                case 1:
                    _brushFillColor = new SolidBrush(Color.White);
                    break;
                case 2:
                    _brushFillColor = new SolidBrush(Color.PowderBlue);
                    break;
            }
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 4;
            this.Margin = new Padding(2);
            this.Name = "H_CarLabel";
            this.Tag = hSetControlVo.HCarMasterVo;
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
            e.Graphics.DrawImage(_imageCarLabel, 2, 0, _panelWidth - 8, _panelHeight - 6);
            /*
             * 文字(車両)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            string number = string.Concat(_hCarMasterVo.RegistrationNumber1, _hCarMasterVo.RegistrationNumber2, "\r\n"
                                        , _hCarMasterVo.RegistrationNumber3, _hCarMasterVo.RegistrationNumber4, "\r\n"
                                        , _hCarMasterVo.DisguiseKind1, _hCarMasterVo.DoorNumber != 0 ? _hCarMasterVo.DoorNumber : " ");
            e.Graphics.DrawString(number, _drawFontCarLabel, new SolidBrush(Color.Black), new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
        }
    }
}
