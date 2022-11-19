using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using Vo;

namespace CarAccident {
    public partial class CarAccidentList : Form {
        private InitializeForm _initializeForm = new();
        private readonly ConnectionVo _connectionVo;
        private List<CarAccidentMasterVo>? _listCarAccidentMasterVo;

        /*
         * Columnの番号
         */
        /// <summary>
        /// 発生年月日
        /// </summary>
        private const int colOccurrenceDate = 0;
        /// <summary>
        /// 発生場所
        /// </summary>
        private const int colOccurrenceAddress = 1;
        /// <summary>
        /// 事故処理区分
        /// </summary>
        private const int colTotallingFlag = 2;
        /// <summary>
        /// 受付の種類
        /// </summary>
        private const int colAccident_Kind = 3;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colDisplayName = 4;
        /// <summary>
        /// 職種
        /// </summary>
        private const int colWorkKind = 5;
        /// <summary>
        /// 車両登録番号
        /// </summary>
        private const int colCarRegistrationNumber = 6;
        /// <summary>
        /// 概要
        /// </summary>
        private const int colAccidentSummary = 7;
        /// <summary>
        /// 詳細
        /// </summary>
        private const int colAccidentDetail = 8;
        /// <summary>
        /// 指導
        /// </summary>
        private const int colGuide = 9;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public CarAccidentList(ConnectionVo connectionVo) {
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.CarAccidentList(this);
            // 日付を初期化
            DateTimePickerOccurrenceDate1.Value = DateTime.Now.AddMonths(-3);
            DateTimePickerOccurrenceDate2.Value = DateTime.Now.AddDays(1);
            // SheetViewを初期化
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelStatus.Text = "総レコード数：0件";

            _connectionVo = connectionVo;
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
            _listCarAccidentMasterVo = new CarAccidentMasterDao(_connectionVo).SelectAllCarAccidentMaster(DateTimePickerOccurrenceDate1.Value, DateTimePickerOccurrenceDate2.Value);
            SheetViewListOutput();
        }

        int spreadListTopRow = 0;
        private void SheetViewListOutput() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach (var carAccidentMasterVo in _listCarAccidentMasterVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止

                SheetViewList.Rows[i].Tag = carAccidentMasterVo; //carAccidentLedgerVoを退避する
                SheetViewList.Cells[i, colOccurrenceDate].Value = carAccidentMasterVo.Occurrence_ymd_hms;
                SheetViewList.Cells[i, colOccurrenceAddress].Text = carAccidentMasterVo.Occurrence_address;
                SheetViewList.Cells[i, colTotallingFlag].Text = carAccidentMasterVo.Totalling_flag ? "事故として扱う" : "";
                SheetViewList.Cells[i, colAccident_Kind].Text = carAccidentMasterVo.Accident_kind;
                SheetViewList.Cells[i, colDisplayName].Text = carAccidentMasterVo.Display_name;
                SheetViewList.Cells[i, colWorkKind].Text = carAccidentMasterVo.Work_kind;
                SheetViewList.Cells[i, colCarRegistrationNumber].Text = carAccidentMasterVo.Car_registration_number;
                SheetViewList.Cells[i, colAccidentSummary].Text = carAccidentMasterVo.Accident_summary;
                SheetViewList.Cells[i, colAccidentDetail].Text = carAccidentMasterVo.Accident_detail;
                SheetViewList.Cells[i, colGuide].Text = carAccidentMasterVo.Guide;
                i++;
            }
            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout(true);
            ToolStripStatusLabelStatus.Text = string.Concat("総レコード数：", _listCarAccidentMasterVo.Count, "件");
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // シートタブを非表示
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 30; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("メイリオ", 10); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
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
                    SpreadList.SaveExcel(new Directry().GetExcelDesktopPass(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
                    MessageBox.Show("デスクトップへエクスポートしました", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // 新規レコードを作成する
                case "ToolStripMenuItemNew":
                    var carAccidentDetail = new CarAccidentDetail(_connectionVo);
                    carAccidentDetail.ShowDialog();
                    break;
            }
        }

        private void DateTimePickerOccurrenceDate1_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value > DateTimePickerOccurrenceDate2.Value) {
                DateTimePickerOccurrenceDate2.Value = DateTimePickerOccurrenceDate1.Value;
            }
        }

        private void DateTimePickerOccurrenceDate2_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value < DateTimePickerOccurrenceDate1.Value) {
                DateTimePickerOccurrenceDate1.Value = DateTimePickerOccurrenceDate2.Value;
            }
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
            var carAccidentDetail = new CarAccidentDetail(_connectionVo, ((CarAccidentMasterVo)SheetViewList.Rows[e.Row].Tag).Insert_ymd_hms);
            carAccidentDetail.ShowDialog();
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarAccidentList_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
