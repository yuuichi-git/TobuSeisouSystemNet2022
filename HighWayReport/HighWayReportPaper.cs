using System.Drawing.Printing;

using FarPoint.Win.Spread;

namespace HighWayReport {
    public partial class HighWayReportPaper : Form {

        /// <summary>
        /// コンストラクター
        /// </summary>
        public HighWayReportPaper() {
            InitializeComponent();
            // シート
            SpreadReport.TabStripPolicy = TabStripPolicy.Never;
            // ステータスバー
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // シートを印刷します。
            SpreadReport.PrintSheet(SheetViewReport);
        }

        /// <summary>
        /// PrintDocument1_PrintPage
        /// 配車表の印刷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {

        }

        private void SpreadReport_PrintDocument(object sender, FarPoint.Win.Spread.PrintDocumentEventArgs e) {

        }
    }
}