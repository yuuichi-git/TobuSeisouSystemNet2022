using Vo;

namespace ControlEx {
    public partial class CarLabelEx : Label {
        private CarMasterVo _carMasterVo;
        private const int _carLabelHeight = 68;
        private const int _carLabelWidth = 70;

        public CarLabelEx(CarMasterVo carMasterVo) {
            _carMasterVo = carMasterVo;
            InitializeComponent();
            /*
             * CarControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        private void LabelEx_CellPaint(object sender, PaintEventArgs e) {
            Rectangle rectangle = e.ClipRectangle;
            rectangle.Inflate(0, 0); // 枠のサイズを調整する
            if (!_carMasterVo.Garage_flag)
                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Blue, ButtonBorderStyle.Dotted);
        }

        /// <summary>
        /// CarLabel作成
        /// </summary>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public CarLabelEx CreateLabel() {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Yu Gothic UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            this.Height = _carLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = _carMasterVo;
            this.Text = string.Concat(_carMasterVo.Registration_number_1, _carMasterVo.Registration_number_2, "\r\n"
                                         , _carMasterVo.Registration_number_3, _carMasterVo.Registration_number_4, "\r\n"
                                         , _carMasterVo.Disguise_kind_1, _carMasterVo.Door_number);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = _carLabelWidth;
            return this;
        }
    }
}
