/*
 * 2023-08-21
 */
using Common;

using Vo;

namespace LegalTwelveItem {
    public partial class LegalTwelveItemList : Form {
        private InitializeForm _initializeForm = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * Dao
         */

        public LegalTwelveItemList(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Dao
             */

            /*
             * InitializeControl
             */
            InitializeComponent();
            _initializeForm.LegalTwelveItemList(this);
        }

        public static void Main() {
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
        /// LegalTwelveItemList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LegalTwelveItemList_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}