using System.Drawing.Printing;

using FarPoint.Win.Spread;

namespace HighWayReport {
    public partial class HighWayReportPaper : Form {

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public HighWayReportPaper() {
            InitializeComponent();
            // �V�[�g
            SpreadReport.TabStripPolicy = TabStripPolicy.Never;
            // �X�e�[�^�X�o�[
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // �V�[�g��������܂��B
            SpreadReport.PrintSheet(SheetViewReport);
        }

        /// <summary>
        /// PrintDocument1_PrintPage
        /// �z�ԕ\�̈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {

        }

        private void SpreadReport_PrintDocument(object sender, FarPoint.Win.Spread.PrintDocumentEventArgs e) {

        }
    }
}