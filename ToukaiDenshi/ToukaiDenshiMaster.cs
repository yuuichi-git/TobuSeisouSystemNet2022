using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace ToukaiDenshi {
    public partial class ToukaiDenshiMaster : Form {
        private readonly InitializeForm _initializeForm = new();

        // SPREADのColumnの番号
        /// <summary>
        /// ALC-RECでの通しID
        /// </summary>
        private const int colId = 0;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colName = 1;
        /// <summary>
        /// 免許証番号
        /// </summary>
        private const int colLicenseNumber = 2;
        /// <summary>
        /// 免許期限
        /// </summary>
        private const int colLicenseExpirationDate = 3;
        /// <summary>
        /// 交付日(四輪)
        /// </summary>
        private const int colIssuanceDate = 4;
        /// <summary>
        /// 免許種類
        /// </summary>
        private const int colLicenseType = 5;
        /// <summary>
        /// PIN登録
        /// </summary>
        private const int colPin = 6;
        /// <summary>
        /// 証明写真
        /// </summary>
        private const int colPicture = 7;
        /// <summary>
        /// フリガナ
        /// </summary>
        private const int colNameKana = 8;

        /*
         * Dao
         */
        private ToukaiDenshiDao _toukaiDenshiDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        List<LicenseMasterVo> _listLicenseMasterVo;

        public ToukaiDenshiMaster(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _toukaiDenshiDao = new ToukaiDenshiDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _listLicenseMasterVo = new();
            /*
             * 初期化
             */
            InitializeComponent();
            _initializeForm.ToukaiDenshiMaster(this);
            InitializeSheetViewList(SheetViewList);
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
            _listLicenseMasterVo = _toukaiDenshiDao.SelectAllLicenseMaster();
            SheetViewListOutput();
        }

        int spreadListTopRow = 0;
        private void SheetViewListOutput() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            if(_listLicenseMasterVo is not null) {
                foreach(var licenseMasterVo in _listLicenseMasterVo) {
                    /*
                     * 245番は予備で使用するので空けておく処理
                     */
                    if(i + 1 == 245)
                        i++;
                    SheetViewList.Rows.Add(i, 1);
                    SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                    SheetViewList.Rows[i].Height = 22; // Rowの高さ
                    SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                    SheetViewList.Cells[i, colId].Text = string.Concat(i + 1);
                    SheetViewList.Cells[i, colName].Text = licenseMasterVo.Name;
                    SheetViewList.Cells[i, colLicenseNumber].Text = licenseMasterVo.License_number;
                    SheetViewList.Cells[i, colLicenseExpirationDate].Text = licenseMasterVo.Expiration_date.ToString("yyyy/MM/dd");
                    SheetViewList.Cells[i, colIssuanceDate].Text = licenseMasterVo.Delivery_date.ToString("yyyy/MM/dd");
                    SheetViewList.Cells[i, colLicenseType].Text = "";
                    SheetViewList.Cells[i, colPin].Text = "無";
                    SheetViewList.Cells[i, colPicture].Text = "無";
                    SheetViewList.Cells[i, colNameKana].Text = licenseMasterVo.Name_kana;
                    i++;
                }
            }
            /*
             * 254番の予備を追加する
             */
            SheetViewList.Rows.Add(i, 1);
            SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
            SheetViewList.Rows[i].Height = 22; // Rowの高さ
            SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
            SheetViewList.Cells[i, colId].Text = "245";
            SheetViewList.Cells[i, colName].Text = "予備";
            SheetViewList.Cells[i, colLicenseNumber].Text = "";
            SheetViewList.Cells[i, colLicenseExpirationDate].Text = DateTime.Now.AddYears(2).ToString("yyyy/MM/dd");
            SheetViewList.Cells[i, colIssuanceDate].Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            SheetViewList.Cells[i, colLicenseType].Text = "";
            SheetViewList.Cells[i, colPin].Text = "無";
            SheetViewList.Cells[i, colPicture].Text = "無";
            SheetViewList.Cells[i, colNameKana].Text = "ヨビ";

            /*
             * 9999番の予備(点検用)を追加する
             */
            SheetViewList.Rows.Add(i, 1);
            SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
            SheetViewList.Rows[i].Height = 22; // Rowの高さ
            SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
            SheetViewList.Cells[i, colId].Text = "9999";
            SheetViewList.Cells[i, colName].Text = "点検用";
            SheetViewList.Cells[i, colLicenseNumber].Text = "";
            SheetViewList.Cells[i, colLicenseExpirationDate].Text = DateTime.Now.AddYears(2).ToString("yyyy/MM/dd");
            SheetViewList.Cells[i, colIssuanceDate].Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            SheetViewList.Cells[i, colLicenseType].Text = "";
            SheetViewList.Cells[i, colPin].Text = "無";
            SheetViewList.Cells[i, colPicture].Text = "無";
            SheetViewList.Cells[i, colNameKana].Text = "テンケンヨウ";

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }

        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// ToolStripMenuItemCsvExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemCsvExport_Click(object sender, EventArgs e) {
            //csv形式ファイルをエクスポートします
            string fileName = string.Concat("LicenseMaster", DateTime.Now.ToString("MM月dd日"), "作成");
            //アクティブシート上の全データをcsv形式ファイルに保存します
            SpreadList.ActiveSheet.SaveTextFile(new Directry().GetExcelDesktopPassCsv(fileName),
                                                TextFileFlags.None,
                                                FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly,
                                                Environment.NewLine,
                                                ",",
                                                "");
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
        /// ToukaiDenshiMaster_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToukaiDenshiMaster_FormClosing(object sender, FormClosingEventArgs e) {
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
