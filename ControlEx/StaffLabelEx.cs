using Vo;

namespace ControlEx {
    public partial class StaffLabelEx : Label {
        private const int _staffLabelHeight = 38;
        private const int _staffLabelWidth = 70;

        public StaffLabelEx() {
            InitializeComponent();
            /*
             * StaffControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        private void LabelEx_CellPaint(object? sender, PaintEventArgs e) {
            Rectangle rectangle = e.ClipRectangle;
            rectangle.Inflate(-2, -2); // 枠のサイズを小さくする
            e.Graphics.DrawRectangle(Pens.Green, rectangle);
        }

        /// <summary>
        /// StaffLabel作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public StaffLabelEx CreateLabel(StaffMasterVo staffMasterVo) {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
            this.Height = _staffLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = staffMasterVo;
            this.Text = staffMasterVo.Display_name;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = _staffLabelWidth;
            return this;
        }
    }
}
