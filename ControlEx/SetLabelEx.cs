using Vo;

namespace ControlEx {
    public partial class SetLabelEx : Label {
        private const int _setLabelHeight = 68;
        private const int _setLabelWidth = 70;

        private SetMasterVo _setMasterVo;
        private bool _garageFlag;
        private string _drawStringContactMethod = "";
        private readonly Color _borderColor = Color.White;
        private readonly Font _drawFont = new Font("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly Font _drawFontContactMethod = new Font("Yu Gothic UI", 8, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly SolidBrush _drawBrushFont = new SolidBrush(Color.Black);
        private  SolidBrush _drowBrushFill = new SolidBrush(Color.White);

        /// <summary>
        /// コンストラクタ(オーバーロード)
        /// FlowLayoutPanel配置用
        /// </summary>
        /// <param name="setMasterVo"></param>
        public SetLabelEx(SetMasterVo setMasterVo) {
            _setMasterVo = setMasterVo;

            /*
             * Classification_code
             */
            switch(setMasterVo.Classification_code) {
                case 10:
                    _borderColor = Color.DarkGray;
                    break;
                case 11:
                    _borderColor = Color.DarkOrange;
                    break;
                default:
                    _borderColor = Color.White;
                    break;
            }
            InitializeComponent();
            /*
             * SetControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクタ(オーバーロード)
        /// ProductionList用
        /// </summary>
        /// <param name="setMasterVo"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        public SetLabelEx(SetMasterVo setMasterVo, bool garageFlag) {
            _setMasterVo = setMasterVo;
            _garageFlag = garageFlag;

            /*
             * Classification_code
             */
            switch(setMasterVo.Classification_code) {
                case 10:
                    _borderColor = Color.DarkGray;
                    break;
                case 11:
                    _borderColor = Color.DarkOrange;
                    break;
                default:
                    _borderColor = Color.White;
                    break;
            }
            /*
             * Garage_flag
             */
            if(_garageFlag) {
                _drowBrushFill = new SolidBrush(Color.White);
            } else {
                _drowBrushFill = new SolidBrush(Color.PowderBlue);
            }

            InitializeComponent();
            /*
             * SetControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクタ(オーバーロード)
        /// SetLabelEx用
        /// </summary>
        /// <param name="setMasterVo"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        public SetLabelEx(SetMasterVo setMasterVo, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            _setMasterVo = setMasterVo;

            /*
             * Classification_code
             */
            switch(setMasterVo.Classification_code) {
                case 10:
                    _borderColor = Color.DarkGray;
                    break;
                case 11:
                    _borderColor = Color.DarkOrange;
                    break;
                default:
                    _borderColor = Color.White;
                    break;
            }
            /*
             * Garage_flag
             */
            if(vehicleDispatchDetailVo.Garage_flag) {
                _drowBrushFill = new SolidBrush(Color.White);
            } else {
                _drowBrushFill = new SolidBrush(Color.PowderBlue);
            }
            /*
             * Operation_flag
             */
            if(!vehicleDispatchDetailVo.Operation_flag)
                _drowBrushFill = new SolidBrush(Color.Pink);

            InitializeComponent();
            /*
             * SetControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
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
             * 文字(配車先)を描画
             */
            var stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(string.Concat(_setMasterVo.Set_name_1, "\r\n", _setMasterVo.Set_name_2), _drawFont, _drawBrushFont, rectangleFill, stringFormat);
            /*
             * 文字(ContactMethod)を描画
             */
            switch(_setMasterVo.Contact_method) {
                case 10:
                    _drawStringContactMethod = "TEL";
                    break;
                case 11:
                    _drawStringContactMethod = "FAX";
                    break;
                default:
                    _drawStringContactMethod = "";
                    break;
            }
            Point point = new Point(4, 2);
            e.Graphics.DrawString(_drawStringContactMethod, _drawFontContactMethod, _drawBrushFont, point);
        }

        /// <summary>
        /// SetLabel作成
        /// </summary>
        /// <param name="setMasterVo"></param>
        /// <returns></returns>
        public SetLabelEx CreateLabel() {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = _setLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = _setMasterVo;
            this.Width = _setLabelWidth;
            return this;
        }

        /// <summary>
        /// SetGarageFlag
        /// 本社・三郷で色を変える
        /// </summary>
        /// <param name="garageFlag"></param>
        public void SetGarageFlag(bool garageFlag) {
            /*
             * Garage_flag
             */
            if(garageFlag) {
                _drowBrushFill = new SolidBrush(Color.White);
            } else {
                _drowBrushFill = new SolidBrush(Color.PowderBlue);
            }
            this.Refresh();
        }
    }
}
