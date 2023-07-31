/*
 * 2023-07-22
 */
using Vo;

namespace CollectionWeight {
    public partial class TaitouCollectionWeight : Form {
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TaitouCollectionWeight(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            /*
             * コントロール初期化
             */
            InitializeComponent();
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// TaitouCollectionWeight_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaitouCollectionWeight_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
