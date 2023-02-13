using Vo;

namespace ControlEx {
    public partial class StaffLabelEx : Label {
        /*
         * Labelのサイズ
         */
        private const int _staffLabelHeight = 36;
        private const int _staffLabelWidth = 70;

        // StaffMasterVo
        private readonly StaffMasterVo _staffMasterVo;
        // 代番フラグ(True:代番 False:本番)
        private bool _proxyFlag;
        // 点呼モードフラグ(True:点呼モード False:通常モード)
        private bool _tenkoModeFlag;
        // 出庫点呼フラグ(True:点呼済 False:未点呼)
        private bool _rollCallFlag;
        // ノートフラグ
        private bool _noteFlag;

        private Font _drawFont = new Font("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        private Pen _borderColor = Pens.White;
        private SolidBrush _drowBrushFill = new SolidBrush(Color.White);

        /*
         * 電話連絡マーク
         */
        private bool _telephoneMark = false;
        private Font _drawTelephoneMarkFont = new Font("Yu Gothic UI", 9, FontStyle.Regular, GraphicsUnit.Pixel);
        private SolidBrush _drawTelephoneMarkBrushFont = new SolidBrush(Color.Blue);

        /*
         * 作業員マーク
         */
        private int _occupation;
        private Font _occupationFont = new Font("Yu Gothic UI", 9, FontStyle.Regular, GraphicsUnit.Pixel);
        private SolidBrush _occupationBrushFont = new SolidBrush(Color.Blue);

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// SetControlExに対してのStaffLabelExを作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <param name="tenkoModeFlag"></param>
        /// <param name="rollCallFlag"></param>
        /// <param name="noteFlag"></param>
        public StaffLabelEx(StaffMasterVo staffMasterVo, bool proxyFlag, bool tenkoModeFlag, bool rollCallFlag, bool noteFlag, int occupation) {
            _staffMasterVo = staffMasterVo;
            _proxyFlag = proxyFlag;
            _tenkoModeFlag = tenkoModeFlag;
            _rollCallFlag = rollCallFlag;
            _noteFlag = noteFlag;
            _occupation = occupation;

            switch(staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    this._borderColor = Pens.Gray;
                    _drowBrushFill = new SolidBrush(Color.White);
                    break;
                case 12: // アルバイト
                case 13: // 派遣
                    this._borderColor = Pens.DarkOrange;
                    _drowBrushFill = new SolidBrush(Color.Orange);
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch(staffMasterVo.Job_form) {
                        case 10: // 長期雇用
                            this._borderColor = Pens.WhiteSmoke;
                            _drowBrushFill = new SolidBrush(Color.White);
                            break;
                        case 11: // 手帳
                            this._borderColor = Pens.Green;
                            _drowBrushFill = new SolidBrush(Color.LightGreen);
                            break;
                        case 12: // アルバイト
                            this._borderColor = Pens.DarkOrange;
                            _drowBrushFill = new SolidBrush(Color.Orange);
                            break;
                    }
                    break;
            }
            InitializeComponent();
            // StaffControlExのイベントを登録
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// FlowLayoutPanel(左側)に対してのStaffLabelExを作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        public StaffLabelEx(StaffMasterVo staffMasterVo) {
            _staffMasterVo = staffMasterVo;
            _proxyFlag = false;
            _tenkoModeFlag = false;
            _rollCallFlag = false;
            _noteFlag = false;

            switch(staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    this._borderColor = Pens.Gray;
                    _drowBrushFill = new SolidBrush(Color.White);
                    break;
                case 12: // アルバイト
                case 13: // 派遣
                    this._borderColor = Pens.DarkOrange;
                    _drowBrushFill = new SolidBrush(Color.Orange);
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch(staffMasterVo.Job_form) {
                        case 10: // 長期雇用
                            this._borderColor = Pens.WhiteSmoke;
                            _drowBrushFill = new SolidBrush(Color.White);
                            break;
                        case 11: // 手帳
                            this._borderColor = Pens.Green;
                            _drowBrushFill = new SolidBrush(Color.LightGreen);
                            break;
                        case 12: // アルバイト
                            this._borderColor = Pens.DarkOrange;
                            _drowBrushFill = new SolidBrush(Color.Orange);
                            break;
                    }
                    break;
            }
            InitializeComponent();
            // StaffControlExのイベントを登録
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        /// <summary>
        /// コンストラクター(オーバーロード)
        /// FlowLayoutPanel(右側)に対してのStaffLabelExを作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        public StaffLabelEx(StaffMasterVo staffMasterVo, bool noteFlag) {
            _staffMasterVo = staffMasterVo;
            _proxyFlag = false;
            _tenkoModeFlag = false;
            _rollCallFlag = false;
            _noteFlag = noteFlag;

            switch(staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    this._borderColor = Pens.Gray;
                    _drowBrushFill = new SolidBrush(Color.White);
                    break;
                case 12: // アルバイト
                case 13: // 派遣
                    this._borderColor = Pens.DarkOrange;
                    _drowBrushFill = new SolidBrush(Color.Orange);
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch(staffMasterVo.Job_form) {
                        case 10: // 長期雇用
                            this._borderColor = Pens.WhiteSmoke;
                            _drowBrushFill = new SolidBrush(Color.White);
                            break;
                        case 11: // 手帳
                            this._borderColor = Pens.Green;
                            _drowBrushFill = new SolidBrush(Color.LightGreen);
                            break;
                        case 12: // アルバイト
                            this._borderColor = Pens.DarkOrange;
                            _drowBrushFill = new SolidBrush(Color.Orange);
                            break;
                    }
                    break;
            }
            InitializeComponent();
            // StaffControlExのイベントを登録
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
            e.Graphics.FillRectangle(_drowBrushFill, rectangleFill);
            /*
             * 代番処理を描画
             */
            if(_proxyFlag) {
                e.Graphics.FillRectangle(Brushes.ForestGreen, 4, 3, 60, 5);
                e.Graphics.DrawLine(new Pen(Color.LawnGreen), new Point(2, 5), new Point(65, 5));
            }
            /*
             * 文字(氏名)を描画
             * 誕生日の従事者の文字色を変える
             */
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            if(_staffMasterVo.Birth_date.Month == DateTime.Now.Month && _staffMasterVo.Birth_date.Day == DateTime.Now.Day) {
                e.Graphics.DrawString(_staffMasterVo.Display_name, _drawFont, new SolidBrush(Color.Red), rectangleFill, stringFormat);
            } else {
                e.Graphics.DrawString(_staffMasterVo.Display_name, _drawFont, new SolidBrush(Color.Black), rectangleFill, stringFormat);
            }
            /*
             * 点呼の印を描画
             */
            if(_tenkoModeFlag) {
                if(!_rollCallFlag) {
                    e.Graphics.FillEllipse(Brushes.Crimson, 55, 21, 10, 10);
                    e.Graphics.FillEllipse(Brushes.LightPink, 59, 25, 4, 4);
                }
            }
            /*
             * メモの印を描画
             */
            if(_noteFlag) {
                Point[] points = { new Point(1, 1), new Point(11, 1), new Point(1, 11) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
            /*
             * 電話連絡マーク
             */
            if(_telephoneMark) {
                Point point = new Point(54, 0);
                e.Graphics.DrawString("☎", _drawTelephoneMarkFont, _drawTelephoneMarkBrushFont, point);
            }
            /*
             * 作業員マーク
             */
            switch(_occupation) {
                case 10:
                    break;
                case 11:
                    e.Graphics.DrawString("作", _occupationFont, _occupationBrushFont, new Point(1, 21));
                    break;
                case 99:
                    break;
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
        /// 出庫点呼フラグ
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

        /// <summary>
        /// SetProxyFlag
        /// </summary>
        /// <param name="proxyFlag"></param>
        public void SetProxyFlag(bool proxyFlag) {
            _proxyFlag = proxyFlag;
            this.Refresh();
        }

        /// <summary>
        /// TelephoneMarkFlag
        /// 電話連絡をするための印を付ける
        /// </summary>
        /// <param name="telephoneMarkFlag"></param>
        public void SetTelephoneMark(bool telephoneMarkFlag) {
            _telephoneMark = telephoneMarkFlag;
            this.Refresh();
        }

        /// <summary>
        /// SetPayFlag
        /// 10:運転手 11:作業員 99:その他
        /// </summary>
        /// <param name="occupation"></param>
        public void SetOccupation(int occupation) {
            _occupation = occupation;
            this.Refresh();
        }
    }
}
