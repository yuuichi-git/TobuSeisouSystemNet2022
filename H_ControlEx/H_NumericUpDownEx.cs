/*
 * 2024-02-19
 */
namespace H_ControlEx {
    public partial class H_NumericUpDownEx : NumericUpDown {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_NumericUpDownEx() {
            InitializeComponent();
            /*
             * Event
             */
            this.Enter += H_NumericUpDownEx_Enter;

        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        /// <summary>
        /// フォーカスを受け取った時に全選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_NumericUpDownEx_Enter(object sender, EventArgs e) {
            ((H_NumericUpDownEx)sender).Select(0, this.Value.ToString().Length);
        }
    }
}
