using Vo;

namespace ControlEx {
    public partial class StaffLabelEx : Label {
        // StaffMasterVo
        private readonly StaffMasterVo _staffMasterVo;
        // 点呼モードフラグ(True:点呼モード False:通常モード)
        private bool _tenkoModeFlag;
        // 点呼フラグ(True:点呼済 False:未点呼)
        private bool _rollCallFlag;
        // ノートフラグ
        private bool _noteFlag;

        private const int _staffLabelHeight = 36;
        private const int _staffLabelWidth = 70;

        private Font drawFont = new Font("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        private Pen _borderColor = Pens.White;
        private SolidBrush drawBrushFont = new SolidBrush(Color.Black);
        private SolidBrush drowBrushFill = new SolidBrush(Color.White);

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// FlowLayoutPanel(左側)に対してのStaffLabelExを作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        public StaffLabelEx(StaffMasterVo staffMasterVo) {
            _staffMasterVo = staffMasterVo;
            _tenkoModeFlag = false;
            _rollCallFlag = false;
            _noteFlag = false;

            switch(staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    this._borderColor = Pens.Gray;
                    drowBrushFill = new SolidBrush(Color.White);
                    break;
                case 12: // アルバイト
                    this._borderColor = Pens.DarkOrange;
                    drowBrushFill = new SolidBrush(Color.Orange);
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch(staffMasterVo.Job_form) {
                        case 10: // 長期雇用
                            this._borderColor = Pens.WhiteSmoke;
                            drowBrushFill = new SolidBrush(Color.White);
                            break;
                        case 11: // 手帳
                            this._borderColor = Pens.Green;
                            drowBrushFill = new SolidBrush(Color.LightGreen);
                            break;
                        case 12: // アルバイト
                            this._borderColor = Pens.DarkOrange;
                            drowBrushFill = new SolidBrush(Color.Orange);
                            break;
                    }
                    break;
            }
            InitializeComponent();
            /*
             * StaffControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// FlowLayoutPanel(右側)に対してのStaffLabelExを作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        public StaffLabelEx(StaffMasterVo? staffMasterVo, bool noteFlag) {
            _staffMasterVo = staffMasterVo;
            _tenkoModeFlag = false;
            _rollCallFlag = false;
            _noteFlag = noteFlag;

            switch(staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    this._borderColor = Pens.Gray;
                    drowBrushFill = new SolidBrush(Color.White);
                    break;
                case 12: // アルバイト
                    this._borderColor = Pens.DarkOrange;
                    drowBrushFill = new SolidBrush(Color.Orange);
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch(staffMasterVo.Job_form) {
                        case 10: // 長期雇用
                            this._borderColor = Pens.WhiteSmoke;
                            drowBrushFill = new SolidBrush(Color.White);
                            break;
                        case 11: // 手帳
                            this._borderColor = Pens.Green;
                            drowBrushFill = new SolidBrush(Color.LightGreen);
                            break;
                        case 12: // アルバイト
                            this._borderColor = Pens.DarkOrange;
                            drowBrushFill = new SolidBrush(Color.Orange);
                            break;
                    }
                    break;
            }
            InitializeComponent();
            /*
             * StaffControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// SetControlExに対してのStaffLabelExを作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <param name="tenkoModeFlag"></param>
        /// <param name="rollCallFlag"></param>
        /// <param name="noteFlag"></param>
        public StaffLabelEx(StaffMasterVo? staffMasterVo, bool tenkoModeFlag, bool rollCallFlag, bool noteFlag) {
            _staffMasterVo = staffMasterVo;
            _tenkoModeFlag = tenkoModeFlag;
            _rollCallFlag = rollCallFlag;
            _noteFlag = noteFlag;

            switch(staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    this._borderColor = Pens.Gray;
                    drowBrushFill = new SolidBrush(Color.White);
                    break;
                case 12: // アルバイト
                    this._borderColor = Pens.DarkOrange;
                    drowBrushFill = new SolidBrush(Color.Orange);
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch(staffMasterVo.Job_form) {
                        case 10: // 長期雇用
                            this._borderColor = Pens.WhiteSmoke;
                            drowBrushFill = new SolidBrush(Color.White);
                            break;
                        case 11: // 手帳
                            this._borderColor = Pens.Green;
                            drowBrushFill = new SolidBrush(Color.LightGreen);
                            break;
                        case 12: // アルバイト
                            this._borderColor = Pens.DarkOrange;
                            drowBrushFill = new SolidBrush(Color.Orange);
                            break;
                    }
                    break;
            }
            InitializeComponent();
            /*
             * StaffControlExのイベントを登録
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
            Rectangle rectangleBorder = new Rectangle(0, 0, 67, 33);
            e.Graphics.DrawRectangle(_borderColor, rectangleBorder);
            /*
             * Fillを描画
             */
            Rectangle rectangleFill = new Rectangle(2, 2, 64, 30);
            e.Graphics.FillRectangle(drowBrushFill, rectangleFill);
            /*
             * 文字(氏名)を描画
             */
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(_staffMasterVo.Display_name, drawFont, drawBrushFont, rectangleFill, stringFormat);
            /*
             * 点呼の印を描画
             */
            if(_tenkoModeFlag) {
                if(!_rollCallFlag)
                    e.Graphics.FillEllipse(Brushes.Crimson, 55, 21, 10, 10);
            }
            /*
             * メモの印を描画
             */
            if(_noteFlag) {
                Point[] points = { new Point(1, 1), new Point(11, 1), new Point(1, 11) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
        }

        /// <summary>
        /// StaffLabel作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public StaffLabelEx CreateLabel() {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = _staffLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = _staffMasterVo;
            this.Width = _staffLabelWidth;
            return this;
        }

        /// <summary>
        /// Roll_call_flag
        /// True:点呼済 False:未点呼
        /// </summary>
        public bool GetRollCallFlag {
            get => _rollCallFlag;
            set => _rollCallFlag = value;
        }

        /// <summary>
        /// SetRollCallFlag
        /// </summary>
        /// <param name="rollCallFlag"></param>
        public void SetRollCallFlag(bool rollCallFlag) {
            _rollCallFlag = rollCallFlag;
            this.Refresh();
        }

        /// <summary>
        /// SetNoteFlag
        /// True:メモあり False:メモなし
        /// </summary>
        /// <param name="noteFlag"></param>
        public void SetNoteFlag(bool noteFlag) {
            _noteFlag = noteFlag;
            this.Refresh();
        }
    }
}
