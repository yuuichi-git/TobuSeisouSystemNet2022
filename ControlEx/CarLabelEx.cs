using Vo;

namespace ControlEx {
    public partial class CarLabelEx : Label {
        private const int _carLabelHeight = 68;
        private const int _carLabelWidth = 70;

        public CarLabelEx() {
            InitializeComponent();
            /*
             * CarControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        private void LabelEx_CellPaint(object? sender, PaintEventArgs e) {
        }

        /// <summary>
        /// CarLabel作成
        /// </summary>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public CarLabelEx CreateLabel(CarMasterVo carMasterVo) {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Yu Gothic UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            this.Height = _carLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = carMasterVo;
            this.Text = string.Concat(carMasterVo.Registration_number_1, carMasterVo.Registration_number_2, "\r\n"
                                         , carMasterVo.Registration_number_3, carMasterVo.Registration_number_4, "\r\n"
                                         , carMasterVo.Disguise_kind_1, carMasterVo.Door_number);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = _carLabelWidth;
            return this;
        }
    }
}
