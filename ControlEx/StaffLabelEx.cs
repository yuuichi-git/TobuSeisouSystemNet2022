using Vo;

namespace ControlEx {
    public partial class StaffLabelEx : Label {
        private StaffMasterVo _staffMasterVo;
        private const int _staffLabelHeight = 36;
        private const int _staffLabelWidth = 70;
        private Pen _borderColor = Pens.White;
        
        Font drawFont = new Font("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        SolidBrush drawBrushFont = new SolidBrush(Color.Black);
        SolidBrush drowBrushFill;

        public StaffLabelEx(StaffMasterVo staffMasterVo) {
            _staffMasterVo = staffMasterVo;
            switch (staffMasterVo.Belongs) {
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
                    switch (staffMasterVo.Job_form) {
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

            var stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(_staffMasterVo.Display_name, drawFont, drawBrushFont, rectangleFill, stringFormat);
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
    }
}
