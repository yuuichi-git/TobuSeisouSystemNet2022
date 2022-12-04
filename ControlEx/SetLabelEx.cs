using Vo;

namespace ControlEx {
    public partial class SetLabelEx : Label {
        private SetMasterVo _setMasterVo;
        private bool _garageFlag;

        private const int _setLabelHeight = 68;
        private const int _setLabelWidth = 70;

        private Color _borderColor = Color.White;
        private Font drawFont = new Font("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private SolidBrush drowBrushFill = new SolidBrush(Color.White);
        private SolidBrush drawBrushFont = new SolidBrush(Color.Black);

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
                drowBrushFill = new SolidBrush(Color.White);
            } else {
                drowBrushFill = new SolidBrush(Color.PowderBlue);
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
                drowBrushFill = new SolidBrush(Color.White);
            } else {
                drowBrushFill = new SolidBrush(Color.PowderBlue);
            }
            /*
             * Operation_flag
             */
            if(!vehicleDispatchDetailVo.Operation_flag)
                drowBrushFill = new SolidBrush(Color.Pink);

            InitializeComponent();
            /*
             * SetControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

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
            e.Graphics.FillRectangle(drowBrushFill, rectangleFill);
            /*
             * 文字を描画
             */
            var stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(string.Concat(_setMasterVo.Set_name_1, "\r\n", _setMasterVo.Set_name_2), drawFont, drawBrushFont, rectangleFill, stringFormat);
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
    }
}
