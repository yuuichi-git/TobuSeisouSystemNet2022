/*
 * 2024-02-20
 */
namespace H_ControlEx {
    public partial class H_MaskedTextBoxEx : MaskedTextBox {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_MaskedTextBoxEx() {
            InitializeComponent();
            /*
             * Event
             */
            this.Enter += H_MaskedTextBoxEx_Enter;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        /// <summary>
        /// H_MaskedTextBoxEx_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_MaskedTextBoxEx_Enter(object sender, EventArgs e) {
            ((H_MaskedTextBoxEx)sender).SelectAll();
        }
    }
}
