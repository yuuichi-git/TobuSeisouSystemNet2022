/*
 * 2024-04-23
 */
using Vo;

namespace H_CollectionWeight {
    public partial class H_CollectionWeightTAITOUDetail : Form {

        public H_CollectionWeightTAITOUDetail(ConnectionVo connectionVo) {
            InitializeComponent();
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // A4で印刷
                case "ToolStripMenuItemPrintA4":
                    //アクティブシート印刷します
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        private void H_CollectionWeightTAITOUDetail_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
