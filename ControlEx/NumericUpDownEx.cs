/*
 * 2023-07-22
 */
namespace ControlEx {
    public partial class NumericUpDownEx : NumericUpDown {

        /// <summary>
        /// コンストラクター
        /// </summary>
        public NumericUpDownEx() {
            /*
             * Control初期化
             */
            InitializeComponent();
            /*
             * Eventを登録
             */
            this.Enter += NumericUpDownEx_Enter;
        }

        /// <summary>
        /// NumericUpDownEx_Enter
        /// 値を選択状態にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownEx_Enter(object? sender, EventArgs e) {
            this.Select(0, this.Text.Length);
        }
    }
}
