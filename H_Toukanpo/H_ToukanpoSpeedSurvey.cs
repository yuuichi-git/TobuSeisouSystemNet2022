/*
 * 2024-04-19
 */
using Common;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using H_Dao;

using Vo;

namespace H_Toukanpo {
    public partial class H_ToukanpoSpeedSurvey : Form {
        /*
         * Dao
         */
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_ToukanpoSpeedSurvey(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeSheetView(SheetViewList);
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.ToolStripStatusLabelDetail.Text = "集計中・・・・";

            // 対象月の日数を調べる
            int days = DateTime.DaysInMonth((int)HNumericUpDownExYear.Value, (int)HNumericUpDownExMonth.Value);
            /*
             * 集計年月を表示
             */
            SheetViewList.Cells["A1"].Value = (int)HNumericUpDownExYear.Value; // 年
            SheetViewList.Cells["C1"].Value = (int)HNumericUpDownExMonth.Value; // 月
            SheetViewList.Cells["D1"].Value = string.Concat("速度超過実態調査表（", (int)HNumericUpDownExYear.Value, "年", (int)HNumericUpDownExMonth.Value, "月）");

            SheetViewList.Cells["A7"].Value = (int)HNumericUpDownExMonth.Value; // 月
            for (int i = 0; i < days; i++) {
                // 配車日を作成する
                DateTime operationDate = new DateTime((int)HNumericUpDownExYear.Value, (int)HNumericUpDownExMonth.Value, i + 1);

                SheetViewList.Cells[i + 6, 1].Value = i + 1;
                string week = operationDate.ToString("ddd");
                switch (week) {
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
                SheetViewList.Cells[i + 6, 3].Value = _hVehicleDispatchDetailDao.GetEmploymentCount(operationDate);
                // 区契約数
                SheetViewList.Cells[i + 6, 4].Value = _hVehicleDispatchDetailDao.GetWardCount(operationDate);
            }

            this.ToolStripStatusLabelDetail.Text = "集計が完了しました";
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        private void InitializeSheetView(SheetView sheetView) {
            // Tabを非表示
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            // 現在年月
            this.HNumericUpDownExYear.Value = DateTime.Now.Year;
            this.HNumericUpDownExMonth.Value = DateTime.Now.Month;
            // SheetViewList
            SheetViewList.Cells["D1"].Value = string.Empty;
            sheetView.Cells["A7"].Value = string.Empty; // 月
            for (int i = 0; i < 31; i++) {
                sheetView.Cells[i + 6, 1].Value = string.Empty;
                sheetView.Cells[i + 6, 2].Value = string.Empty;
                sheetView.Cells[i + 6, 3].Value = 0;
                sheetView.Cells[i + 6, 4].Value = 0;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // Excel(xlsx)形式でエクスポートする
                case "ToolStripMenuItemExportExcel":
                    //xlsx形式ファイルをエクスポートします
                    string fileName = string.Concat("速度調査", DateTime.Now.ToString("MM月dd日"), "作成");
                    SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat);
                    MessageBox.Show("デスクトップへエクスポートしました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// H_ToukanpoSpeedSurvey_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_ToukanpoSpeedSurvey_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show("アプリケーションを終了します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
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
