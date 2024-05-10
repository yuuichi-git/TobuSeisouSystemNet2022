/*
 * 2024-05-08
 */
using Common;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_CarAccident {
    public partial class H_CarAccidentList : Form {
        /*
         * Columnの番号
         */
        /// <summary>
        /// 発生年月日
        /// </summary>
        private const int _colOccurrenceDate = 0;
        /// <summary>
        /// 発生場所
        /// </summary>
        private const int _colOccurrenceAddress = 1;
        /// <summary>
        /// 事故処理区分
        /// </summary>
        private const int _colTotallingFlag = 2;
        /// <summary>
        /// 受付の種類
        /// </summary>
        private const int _colAccident_Kind = 3;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int _colDisplayName = 4;
        /// <summary>
        /// 職種
        /// </summary>
        private const int _colWorkKind = 5;
        /// <summary>
        /// 車両登録番号
        /// </summary>
        private const int _colCarRegistrationNumber = 6;
        /// <summary>
        /// 概要
        /// </summary>
        private const int _colAccidentSummary = 7;
        /// <summary>
        /// 詳細
        /// </summary>
        private const int _colAccidentDetail = 8;
        /// <summary>
        /// 指導
        /// </summary>
        private const int _colGuide = 9;
        /*
         * Dao
         */
        private readonly H_CarAccidentMasterDao _hCarAccidentMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_CarAccidentList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCarAccidentMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            // 日付を初期化
            HDateTimePickerExOccurrence1.SetValueJp(DateTime.Now.AddMonths(-3));
            HDateTimePickerExOccurrence2.SetValueJp(DateTime.Now.AddDays(1));
            this.InitializeSheetView(SheetViewList);
            ToolStripStatusLabelDetail.Text = "総レコード数：0件";
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            try {
                this.PutSheetViewList(_hCarAccidentMasterDao.SelectAllHCarAccidentMaster(HDateTimePickerExOccurrence1.GetValue(), HDateTimePickerExOccurrence2.GetValue()));
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="listHCarAccidentMasterVo"></param>
        private void PutSheetViewList(List<H_CarAccidentMasterVo> listHCarAccidentMasterVo) {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach (H_CarAccidentMasterVo hCarAccidentMasterVo in listHCarAccidentMasterVo.OrderBy(x => x.OccurrenceYmdHms)) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止

                SheetViewList.Rows[i].Tag = hCarAccidentMasterVo; //carAccidentLedgerVoを退避する
                SheetViewList.Cells[i, _colOccurrenceDate].Value = hCarAccidentMasterVo.OccurrenceYmdHms;
                SheetViewList.Cells[i, _colOccurrenceAddress].Text = hCarAccidentMasterVo.OccurrenceAddress;
                SheetViewList.Cells[i, _colTotallingFlag].Text = hCarAccidentMasterVo.TotallingFlag ? "事故として扱う" : "";
                SheetViewList.Cells[i, _colAccident_Kind].Text = hCarAccidentMasterVo.AccidentKind;
                SheetViewList.Cells[i, _colDisplayName].Text = hCarAccidentMasterVo.DisplayName;
                SheetViewList.Cells[i, _colWorkKind].Text = hCarAccidentMasterVo.WorkKind;
                SheetViewList.Cells[i, _colCarRegistrationNumber].Text = hCarAccidentMasterVo.CarRegistrationNumber;
                SheetViewList.Cells[i, _colAccidentSummary].Text = hCarAccidentMasterVo.AccidentSummary;
                SheetViewList.Cells[i, _colAccidentDetail].Text = hCarAccidentMasterVo.AccidentDetail;
                SheetViewList.Cells[i, _colGuide].Text = hCarAccidentMasterVo.Guide;
                i++;
            }
            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout(true);
            ToolStripStatusLabelDetail.Text = string.Concat("総レコード数：", listHCarAccidentMasterVo.Count, "件");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if (e.Row < 0)
                return;
            H_CarAccidentDetail hCarAccidentDetail = new(_connectionVo, (H_CarAccidentMasterVo)SheetViewList.Rows[e.Row].Tag);
            Rectangle rectangleHCarAccidentDetail = new Desktop().GetMonitorWorkingArea(hCarAccidentDetail, _connectionVo.Screen);
            hCarAccidentDetail.KeyPreview = true;
            hCarAccidentDetail.Location = rectangleHCarAccidentDetail.Location;
            hCarAccidentDetail.Size = new Size(1920, 1080);
            hCarAccidentDetail.WindowState = FormWindowState.Normal;
            hCarAccidentDetail.Show(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // Excel形式でエクスポートする
                case "ToolStripMenuItemExportExcel":
                    //xlsx形式ファイルをエクスポートします
                    string fileName = string.Concat("事故リスト", DateTime.Now.ToString("MM月dd日"), "作成");
                    SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
                    MessageBox.Show("デスクトップへエクスポートしました", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // 新規レコードを作成する
                case "ToolStripMenuItemNewFile":
                    H_CarAccidentDetail hCarAccidentDetail = new(_connectionVo);
                    Rectangle rectangleHCarAccidentDetail = new Desktop().GetMonitorWorkingArea(hCarAccidentDetail, _connectionVo.Screen);
                    hCarAccidentDetail.KeyPreview = true;
                    hCarAccidentDetail.Location = rectangleHCarAccidentDetail.Location;
                    hCarAccidentDetail.Size = new Size(1920, 1080);
                    hCarAccidentDetail.WindowState = FormWindowState.Normal;
                    hCarAccidentDetail.Show(this);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns>SheetView</returns>
        private SheetView InitializeSheetView(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 26; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 48; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        private void HDateTimePickerExOccurrence1_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value > HDateTimePickerExOccurrence2.Value) {
                HDateTimePickerExOccurrence2.Value = HDateTimePickerExOccurrence1.Value;
            }
        }

        private void HDateTimePickerExOccurrence2_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value < HDateTimePickerExOccurrence1.Value) {
                HDateTimePickerExOccurrence1.Value = HDateTimePickerExOccurrence2.Value;
            }
        }

        /// <summary>
        /// H_CarAccidentList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CarAccidentList_FormClosing(object sender, FormClosingEventArgs e) {
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
