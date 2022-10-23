using Vo;

namespace ControlEx {
    public partial class StaffLabelEx : Label {
        private StaffMasterVo _staffMasterVo;
        private const int _staffLabelHeight = 36;
        private const int _staffLabelWidth = 70;
        private Pen _borderColor = Pens.White;

        public StaffLabelEx(StaffMasterVo staffMasterVo) {
            _staffMasterVo = staffMasterVo;
            switch (staffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    _borderColor = Pens.Gray;
                    break;
                case 12: // アルバイト
                    _borderColor = Pens.DarkOrange;
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch (staffMasterVo.Job_form) {
                        case 1: // 長期雇用
                            _borderColor = Pens.WhiteSmoke;
                            break;
                        case 2: // アルバイト
                        case 3: // 窓
                            _borderColor = Pens.Green;
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

        private void LabelEx_CellPaint(object? sender, PaintEventArgs e) {
            Rectangle rectangle = new Rectangle(0, 0, 67, 33);
            e.Graphics.DrawRectangle(_borderColor, rectangle);
        }

        /// <summary>
        /// StaffLabel作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public StaffLabelEx CreateLabel() {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
            this.Height = _staffLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = _staffMasterVo;
            this.Text = _staffMasterVo.Display_name;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = _staffLabelWidth;
            return this;
        }
    }
}
