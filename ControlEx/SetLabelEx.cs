using Vo;

namespace ControlEx {
    public partial class SetLabelEx : Label {
        private SetMasterVo _setMasterVo;
        private const int _setLabelHeight = 68;
        private const int _setLabelWidth = 70;

        Color _borderColor = Color.White;

        public SetLabelEx(SetMasterVo setMasterVo) {
            _setMasterVo = setMasterVo;
            switch (setMasterVo.Classification_code) {
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

        private void LabelEx_CellPaint(object? sender, PaintEventArgs e) {
            /*
             * Boderを描画
             */
            Rectangle rectangleBoder = new Rectangle(0, 0, 68, 66);
            ControlPaint.DrawBorder(e.Graphics, rectangleBoder, _borderColor, ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// SetLabel作成
        /// </summary>
        /// <param name="setMasterVo"></param>
        /// <returns></returns>
        public SetLabelEx CreateLabel() {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
            this.Height = _setLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = _setMasterVo;
            this.Text = string.Concat(_setMasterVo.Set_name_1, "\r\n", _setMasterVo.Set_name_2);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = _setLabelWidth;
            return this;
        }
    }
}
