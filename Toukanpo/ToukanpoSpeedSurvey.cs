using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using Vo;

namespace Toukanpo {
    public partial class ToukanpoSpeedSurvey : Form {
        private readonly InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        private ToukanpoSpeedSurveyDao _toukanpoSpeedSurveyDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public ToukanpoSpeedSurvey(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _toukanpoSpeedSurveyDao = new ToukanpoSpeedSurveyDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.ToukanpoSpeedSurvey(this);
            MonthPicker1.Value = DateTime.Now;
            InitializeSheetView(SheetViewList);
            ToolStripStatusLabel2.Text = "";
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // 対象月の日数を調べる
            int days = DateTime.DaysInMonth(MonthPicker1.Value.Year,MonthPicker1.Value.Month);
            /*
             * 集計年月を表示
             */
            SheetViewList.Cells["A1"].Value = MonthPicker1.Value.Year; // 年
            SheetViewList.Cells["C1"].Value = MonthPicker1.Value.Month; // 月

            SheetViewList.Cells["A7"].Value = MonthPicker1.Value.Month; // 月
            for(int i = 0; i < days; i++) {
                // 配車日を作成する
                DateTime operationDate = new DateTime(MonthPicker1.Value.Year, MonthPicker1.Value.Month, i + 1);

                SheetViewList.Cells[i + 6, 1].Value = i + 1;
                string week = operationDate.ToString("ddd");
                switch(week) {
                    case "土":
                        SheetViewList.Cells[i + 6, 2].ForeColor = Color.Blue;
                        break;
                    case "日":
                        SheetViewList.Cells[i + 6, 2].ForeColor = Color.Red;
                        break;
                    default:
                        SheetViewList.Cells[i + 6, 2].ForeColor = Color.Black;
                        break;
                }
                SheetViewList.Cells[i + 6, 2].Value = week;

                // 雇上契約数
                SheetViewList.Cells[i + 6, 3].Value = _toukanpoSpeedSurveyDao.GetEmploymentCount(operationDate);
                // 区契約数
                SheetViewList.Cells[i + 6, 4].Value = _toukanpoSpeedSurveyDao.GetWardCount(operationDate);
            }
        }

        /// <summary>
        /// InitializeSheetView
        /// シートを初期化
        /// </summary>
        private void InitializeSheetView(SheetView sheetView) {
            // Tabを非表示
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            sheetView.Cells["A7"].Value = ""; // 月
            for(int i = 0; i < 31; i++) {
                sheetView.Cells[i + 6, 1].Value = "";
                sheetView.Cells[i + 6, 2].Value = "";
                sheetView.Cells[i + 6, 3].Value = 0;
                sheetView.Cells[i + 6, 4].Value = 0;
            }
        }

        /// <summary>
        /// ToolStripMenuItemExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExport_Click(object sender, EventArgs e) {
            //xlsx形式ファイルをエクスポートします
            string fileName = string.Concat("速度調査", DateTime.Now.ToString("MM月dd日"), "作成");
            SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat);
            MessageBox.Show("デスクトップへエクスポートしました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// ToukanpoSpeedSurvey_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToukanpoSpeedSurvey_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
