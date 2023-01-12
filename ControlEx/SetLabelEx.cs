using Vo;

namespace ControlEx {
    public partial class SetLabelEx : Label {
        /*
         * setter getter
         */
        // 帰庫点呼フラグ(True:点呼済 False:未点呼)
        private bool _lastRollCallFlag;

        private SetMasterVo _setMasterVo;
        /*
         * SetLabel
         */
        private const int _setLabelHeight = 68;
        private const int _setLabelWidth = 70;
        private  Color _setLabelBorderColor = new();
        private readonly Font _setLabelDrawFont = new Font("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);

        private bool _garageFlag;
        private bool _operationFlag;
        private bool _fiveLapFlag;

        private string _drawStringContactMethod = "";
        private readonly Font _drawFontContactMethod = new Font("Yu Gothic UI", 8, FontStyle.Regular, GraphicsUnit.Pixel);

        /*
         * AddWorkerFlag
         * 作業員付き
         */
        private bool _addWorkerFlag = false;
        private readonly Font _drawFontAddWorkerFlag = new Font("Yu Gothic UI", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly SolidBrush _brushColorAddWorkerFlag = new SolidBrush(Color.Blue);
        /*
        * StandByFlag
        * 待機
        */
        private bool _standByFlag = false;
        private readonly Font _drawFontStandByFlag = new Font("Yu Gothic UI", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly SolidBrush _brushColorStandByFlag = new SolidBrush(Color.Blue);

        private readonly SolidBrush _brushColorBlack = new SolidBrush(Color.Black);

        private  SolidBrush _drowBrushFill = new SolidBrush(Color.White);

        /// <summary>
        /// コンストラクタ(オーバーロード)
        /// FlowLayoutPanel配置用
        /// </summary>
        /// <param name="setMasterVo"></param>
        public SetLabelEx(SetMasterVo setMasterVo) {
            _setMasterVo = setMasterVo;
            // 車庫地は本社で初期化
            _garageFlag = true;
            // 配車状態で初期化
            _operationFlag = true;
            /*
             * Classification_code
             */
            switch(setMasterVo.Classification_code) {
                case 10:
                    _setLabelBorderColor = Color.DarkGray;
                    break;
                case 11:
                    _setLabelBorderColor = Color.DarkOrange;
                    break;
                default:
                    _setLabelBorderColor = Color.White;
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
            /*
             * Classification_code
             */
            switch(setMasterVo.Classification_code) {
                case 10:
                    _setLabelBorderColor = Color.DarkGray;
                    break;
                case 11:
                    _setLabelBorderColor = Color.DarkOrange;
                    break;
                default:
                    _setLabelBorderColor = Color.White;
                    break;
            }
            /*
             * Garage_flag
             */
            _garageFlag = garageFlag;
            /*
             * Operation_flag
             */
            _operationFlag = true;

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
                    _setLabelBorderColor = Color.DarkGray;
                    break;
                case 11:
                    _setLabelBorderColor = Color.DarkOrange;
                    break;
                /*
                 * 臨時配車先だった場合雇上・区契の区別を処理
                 */
                case 12:
                    _setLabelBorderColor = vehicleDispatchDetailVo.Classification_flag ? Color.DarkGray : Color.DarkOrange;
                    break;
                default:
                    _setLabelBorderColor = Color.White;
                    break;
            }
            /*
             * Garage_flag
             */
            _garageFlag = vehicleDispatchDetailVo.Garage_flag;
            /*
             * Operation_flag
             */
            _operationFlag = vehicleDispatchDetailVo.Operation_flag;
            /*
             * 第五週の処理
             * 第五週が休車対象で、第５週になった場合の処理
             */
            if(!vehicleDispatchDetailVo.Five_lap && vehicleDispatchDetailVo.Operation_date.Day > 28)
                _fiveLapFlag = true;
            /*
             * Add_Worker_Flag
             */
            _addWorkerFlag = vehicleDispatchDetailVo.Add_worker_flag;
            /*
             * Stand_By_Flag
             */
            _standByFlag = vehicleDispatchDetailVo.Stand_by_flag;
            /*
             * 帰庫点呼フラグ
             */
            _lastRollCallFlag = vehicleDispatchDetailVo.Last_roll_call_flag;

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
        private void LabelEx_CellPaint(object sender, PaintEventArgs e) {
            /*
             * Boderを描画
             */
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, 68, 66), _setLabelBorderColor, ButtonBorderStyle.Solid);
            /*
             * Fillを描画
             */
            // 配車・休車
            if(_operationFlag && !_fiveLapFlag) {
                // 車庫地
                if(_garageFlag) {
                    _drowBrushFill = new SolidBrush(Color.White);
                } else {
                    _drowBrushFill = new SolidBrush(Color.PowderBlue);
                }
            } else {
                _drowBrushFill = new SolidBrush(Color.Pink);
            }
            e.Graphics.FillRectangle(_drowBrushFill, new Rectangle(2, 2, 64, 62));
            /*
             * 文字(配車先)を描画
             */
            var stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(string.Concat(_setMasterVo.Set_name_1, "\r\n", _setMasterVo.Set_name_2), _setLabelDrawFont, _brushColorBlack, new Rectangle(0, 0, 68, 66), stringFormat);
            /*
             * 文字(TEL/FAX)を描画
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
            e.Graphics.DrawString(_drawStringContactMethod, _drawFontContactMethod, _brushColorBlack, new Point(4, 2));
            /*
             * 作業員付きを描画
             */
            if(_addWorkerFlag) {
                e.Graphics.DrawString("作付", _drawFontAddWorkerFlag, _brushColorAddWorkerFlag, new Point(4, 50));
            }
            /*
             * 待機を描画
             */
            if(_standByFlag) {
                e.Graphics.DrawString("待機", _drawFontStandByFlag, _brushColorStandByFlag, new Point(40, 50));
            }
            /*
             * 帰庫点呼の印を描画
             */
            if(_lastRollCallFlag) {
                Point[] points = { new Point(51, 3), new Point(65, 3), new Point(65, 17) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Blue), points);
            }
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

        /*
         * Setter Getter
         */
        /// <summary>
        /// 稼働フラグ
        /// true:稼働 false:休車
        /// </summary>
        public bool OperationFlag {
            get => _operationFlag;
            set => _operationFlag = value;
        }

        /// <summary>
        /// SetGarageFlag
        /// 本社・三郷で色を変える
        /// </summary>
        /// <param name="garageFlag"></param>
        public void SetGarageFlag(bool garageFlag) {
            _garageFlag = garageFlag;
            this.Refresh();
        }

        /// <summary>
        /// SetClassificationFlag
        /// 臨時の雇上・区契を設定する
        /// </summary>
        /// <param name="classificationFlag"></param>
        public void SetClassificationFlag(bool classificationFlag) {
            if(classificationFlag) {
                _setLabelBorderColor = Color.DarkGray;
            } else {
                _setLabelBorderColor = Color.DarkOrange;
            }
            this.Refresh();
        }

        /// <summary>
        /// SetAddWorkerFlag
        /// 臨時の作業員付きを設定する
        /// </summary>
        /// <param name="addWorkerFlag"></param>
        public void SetAddWorkerFlag(bool addWorkerFlag) {
            _addWorkerFlag = addWorkerFlag;
            this.Refresh();
        }

        /// <summary>
        /// SetStandByFlag
        /// 待機を表示する
        /// </summary>
        /// <param name="standByFlag"></param>
        public void SetStandByFlag(bool standByFlag) {
            _standByFlag = standByFlag;
            this.Refresh();
        }

        /// <summary>
        /// SetOperationFlag
        /// 配車状態
        /// </summary>
        /// <param name="operationFlag"></param>
        public void SetOperationFlag(bool operationFlag) {
            _operationFlag = operationFlag;
            this.Refresh();
        }

        /// <summary>
        /// SetLastRollCallFlag
        /// 帰庫点呼フラグ
        /// </summary>
        /// <param name="operationFlag"></param>
        public void SetLastRollCallFlag(bool lastRollCallFlag) {
            _lastRollCallFlag = lastRollCallFlag;
            this.Refresh();
        }
    }
}
