/*
 * 2024-01-29
 */
namespace H_ControlEx {
    public partial class H_ComboBoxEx : ComboBox {
        public H_ComboBoxEx() {
            /*
             * InitializeControl
             */
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        /// <summary>
        /// クリア
        /// </summary>
        public void Clear() {
            this.SelectedIndex = -1;
            this.Text = string.Empty;
        }
    }
}
