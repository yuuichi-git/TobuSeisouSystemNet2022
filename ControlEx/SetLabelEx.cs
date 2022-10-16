using Vo;

namespace ControlEx {
    public partial class SetLabelEx : Label {
        private const int _setLabelHeight = 68;
        private const int _setLabelWidth = 70;

        public SetLabelEx() {
            InitializeComponent();
            /*
             * SetControlExのイベントを登録
             */
            this.Paint += new PaintEventHandler(this.LabelEx_CellPaint);
        }

        private void LabelEx_CellPaint(object? sender, PaintEventArgs e) {
        }

        /// <summary>
        /// SetLabel作成
        /// </summary>
        /// <param name="setMasterVo"></param>
        /// <returns></returns>
        public SetLabelEx CreateLabel(SetMasterVo setMasterVo) {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Yu Gothic UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            this.Height = _setLabelHeight;
            this.Margin = new Padding(2);
            this.Tag = setMasterVo;
            this.Text = string.Concat(setMasterVo.Set_name_1, "\r\n", setMasterVo.Set_name_2);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = _setLabelWidth;
            return this;
        }
    }
}
