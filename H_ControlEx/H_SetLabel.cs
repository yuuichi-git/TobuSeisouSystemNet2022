/*
 * 2023-10-24
 */
using H_Common;

using H_Vo;

namespace H_ControlEx {
    public partial class H_SetLabel : Label {
        private Date _date = new();
        private Image _imageSetLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * プロパティ
         */
        private bool _operationFlag = true; // 稼働フラグ true:稼働 false:休車
        private bool _fiveLapFlag = false; // 第五週稼働フラグ true:第五週稼働 false:第五週休車
        private int _garageCode = 1; // 出庫地コード 1:本社 2:三郷
        private bool _firstRollCallFlag = false; // 出庫点呼フラグ true:出庫点呼済 false:未点呼
        private bool _lastRollCallFlag = false; // 帰庫点呼フラグ true:帰庫点呼済 false:未点呼
        private bool _memoFlag = false; // メモフラグ true:メモあり false:メモなし
        private int _shiftCode = 0; // 番手コード 0→指定なし 1→早番 2→遅番
        private bool _standByFlag = false; // 待機フラグ true:待機あり false:待機なし
        private bool _workerFlag = false; // 作業員付フラグ true:サ付 false:サ無し
        private int _workerCount = 0; // 従事者数 1～4
        /*
         * Vo
         */
        private readonly H_SetControlVo _hSetControlVo;
        private readonly H_SetMasterVo _hSetMasterVo;
        /*
         * 色の定義
         */
        private readonly SolidBrush _brushColorBlack = new(Color.Black);
        private readonly SolidBrush _brushColorWhite = new SolidBrush(Color.White);
        private readonly SolidBrush _brushFillColor;
        private Color _setLabelBorderColor = new();
        /*
         * Fontの定義
         */
        private readonly Font _drawFontSetLabel = new("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly Font _drawFontContactMethod = new("Yu Gothic UI", 10, FontStyle.Regular, GraphicsUnit.Pixel);

        private string _drawStringContactMethod = string.Empty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hSetMasterVo"></param>
        public H_SetLabel(H_SetControlVo hSetControlVo) {
            /*
             * GarageCode
             * Classification_code
             */
            switch(hSetControlVo.HSetMasterVo.GarageCode) {
                case 1:
                    switch(hSetControlVo.HSetMasterVo.ClassificationCode) {
                        case 10:
                            _imageSetLabel = Properties.Resources.SetLabelWhiteY;
                            break;
                        case 11:
                            _imageSetLabel = Properties.Resources.SetLabelWhiteK;
                            break;
                        default:
                            _imageSetLabel = Properties.Resources.SetLabelWhite;
                            break;
                    }
                    break;
                case 2:
                    switch(hSetControlVo.HSetMasterVo.ClassificationCode) {
                        case 10:
                            _imageSetLabel = Properties.Resources.SetLabelPowerBlueY;
                            break;
                        case 11:
                            _imageSetLabel = Properties.Resources.SetLabelPowerBlueK;
                            break;
                        default:
                            _imageSetLabel = Properties.Resources.SetLabelPowerBlue;
                            break;
                    }
                    break;
            }
            /*
             * 稼働・休車
             */
            if(!_date.GetWorkingDays(hSetControlVo.OperationDate, hSetControlVo.HSetMasterVo.WorkingDays, hSetControlVo.HSetMasterVo.FiveLap))
                _imageSetLabel = Properties.Resources.SetLabelRed;
            /*
             * Vo
             */
            _hSetControlVo = hSetControlVo;
            _hSetMasterVo = hSetControlVo.HSetMasterVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 2;
            this.Margin = new Padding(2);
            this.Name = "H_SetLabel";
            this.Tag = hSetControlVo.HSetMasterVo;
            this.Width = (int)_panelWidth - 2;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            /*
             * Label Fill
             */
            e.Graphics.DrawImage(_imageSetLabel, 2, 2, _panelWidth - 8, _panelHeight - 6);

            /*
             * 文字(TEL/FAX)を描画
             */
            switch(_hSetMasterVo.ContactMethod) {
                case 10: // TEL
                    _drawStringContactMethod = "TEL";
                    break;
                case 11: // FAX
                    _drawStringContactMethod = "FAX";
                    break;
                case 13: // TEL/FAX
                    _drawStringContactMethod = "TEL/FAX";
                    break;
                default: // 連絡なし
                    _drawStringContactMethod = string.Empty;
                    break;
            }
            e.Graphics.DrawString(_drawStringContactMethod, _drawFontContactMethod, _brushColorBlack, new Point(6, 1));
            /*
             * 文字(配車先)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(string.Concat(_hSetMasterVo.SetName1, "\r\n", _hSetMasterVo.SetName2),
                                                  _drawFontSetLabel, new SolidBrush(Color.Black), new Rectangle(0, 10, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
        }
    }
}
