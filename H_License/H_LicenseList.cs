/*
 * 2024-04-06
 */
using Common;

using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_License {
    public partial class HLicenseList : Form {
        /*
         * List用
         */
        /// <summary>
        /// 社員コード
        /// </summary>
        private const int _colStaffCode = 0;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int _colName = 1;
        /// <summary>
        /// 交付年月日
        /// </summary>
        private const int _colDeliveryDate = 2;
        /// <summary>
        /// 有効期限
        /// </summary>
        private const int _colExpirationDate = 3;
        /// <summary>
        /// 条件等
        /// </summary>
        private const int _colLicenseCondition = 4;
        /// <summary>
        /// 免許証番号
        /// </summary>
        private const int _colLicenseNumber = 5;
        /// <summary>
        /// 大型
        /// </summary>
        private const int _colLarge = 6;
        /// <summary>
        /// 中型
        /// </summary>
        private const int _colMedium = 7;
        /// <summary>
        /// 準中型
        /// </summary>
        private const int _colQuasiMedium = 8;
        /// <summary>
        /// 普通
        /// </summary>
        private const int _colOrdinary = 9;
        /// <summary>
        /// 大特
        /// </summary>
        private const int _colBigSpecial = 10;
        /// <summary>
        /// 大自二
        /// </summary>
        private const int _colBigAutoBike = 11;
        /// <summary>
        /// 普自二
        /// </summary>
        private const int _colOrdinaryAutoBike = 12;
        /// <summary>
        /// 小特
        /// </summary>
        private const int _colSmallSpecial = 13;
        /// <summary>
        /// 原付
        /// </summary>
        private const int _colWithARaw = 14;

        /*
         * 東海電子用
         */
        /// <summary>
        /// ALC-RECでの通しID
        /// </summary>
        private const int _colTId = 0;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int _colTName = 1;
        /// <summary>
        /// 免許証番号
        /// </summary>
        private const int _colTLicenseNumber = 2;
        /// <summary>
        /// 免許期限
        /// </summary>
        private const int _colTLicenseExpirationDate = 3;
        /// <summary>
        /// 交付日(四輪)
        /// </summary>
        private const int _colTIssuanceDate = 4;
        /// <summary>
        /// 免許種類
        /// </summary>
        private const int _colTLicenseType = 5;
        /// <summary>
        /// PIN登録
        /// </summary>
        private const int _colTPin = 6;
        /// <summary>
        /// 証明写真
        /// </summary>
        private const int _colTPicture = 7;
        /// <summary>
        /// フリガナ
        /// </summary>
        private const int _colTNameKana = 8;
        /*
         * Dao
         */
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public HLicenseList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hLicenseMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            // SpreadList/SheetViewList/SheetViewToukaidenshi
            InitializeSheetView(SheetViewList);
            InitializeSheetView(SheetViewToukaidenshi);
           　// ToolStripStatusLabelDetail
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            switch (SpreadList.ActiveSheetIndex) {
                case 0: // SheetViewList
                    ToolStripMenuItemToukaiCSV.Enabled = false;
                    this.PutSheetViewList(_hLicenseMasterDao.SelectAllHLicenseMaster());
                    break;
                case 1: // SheetViewTokaidenshi
                    ToolStripMenuItemToukaiCSV.Enabled = true;
                    this.PutSheetViewToukaidenshi(_hLicenseMasterDao.SelectAllHLicenseMaster());
                    break;
            }
        }

        /// <summary>
        /// HTabControlExKANA_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HTabControlExKANA_Click(object sender, EventArgs e) {
            this.PutSheetViewList(_hLicenseMasterDao.SelectAllHLicenseMaster());
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        int spreadListTopRow = 0;
        private void PutSheetViewList(List<H_LicenseMasterVo> listHLicenseMasterVo) {
            int rowCount = 0;
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            /*
             * Rowを削除する
             */
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            List<H_LicenseMasterVo> _listHLicenseMasterVo = HTabControlExKANA.SelectedTab.Text switch {
                "あ行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("ア") || x.NameKana.StartsWith("イ") || x.NameKana.StartsWith("ウ") || x.NameKana.StartsWith("エ") || x.NameKana.StartsWith("オ")),
                "か行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("カ") || x.NameKana.StartsWith("ガ") || x.NameKana.StartsWith("キ") || x.NameKana.StartsWith("ギ") || x.NameKana.StartsWith("ク") || x.NameKana.StartsWith("グ") || x.NameKana.StartsWith("ケ") || x.NameKana.StartsWith("ゲ") || x.NameKana.StartsWith("コ") || x.NameKana.StartsWith("ゴ")),
                "さ行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("サ") || x.NameKana.StartsWith("シ") || x.NameKana.StartsWith("ス") || x.NameKana.StartsWith("セ") || x.NameKana.StartsWith("ソ")),
                "た行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("タ") || x.NameKana.StartsWith("ダ") || x.NameKana.StartsWith("チ") || x.NameKana.StartsWith("ツ") || x.NameKana.StartsWith("テ") || x.NameKana.StartsWith("デ") || x.NameKana.StartsWith("ト") || x.NameKana.StartsWith("ド")),
                "な行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("ナ") || x.NameKana.StartsWith("ニ") || x.NameKana.StartsWith("ヌ") || x.NameKana.StartsWith("ネ") || x.NameKana.StartsWith("ノ")),
                "は行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("ハ") || x.NameKana.StartsWith("パ") || x.NameKana.StartsWith("ヒ") || x.NameKana.StartsWith("ビ") || x.NameKana.StartsWith("フ") || x.NameKana.StartsWith("ブ") || x.NameKana.StartsWith("ヘ") || x.NameKana.StartsWith("ベ") || x.NameKana.StartsWith("ホ")),
                "ま行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("マ") || x.NameKana.StartsWith("ミ") || x.NameKana.StartsWith("ム") || x.NameKana.StartsWith("メ") || x.NameKana.StartsWith("モ")),
                "や行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("ヤ") || x.NameKana.StartsWith("ユ") || x.NameKana.StartsWith("ヨ")),
                "ら行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("ラ") || x.NameKana.StartsWith("リ") || x.NameKana.StartsWith("ル") || x.NameKana.StartsWith("レ") || x.NameKana.StartsWith("ロ")),
                "わ行" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("ワ") || x.NameKana.StartsWith("ヲ") || x.NameKana.StartsWith("ン")),
                _ => listHLicenseMasterVo,
            };
            // 削除済のレコードも表示
            if (!ToolStripMenuItemDeleted.Checked)
                _listHLicenseMasterVo = _listHLicenseMasterVo.FindAll(x => x.DeleteFlag == false);
            foreach (H_LicenseMasterVo hLicenseMasterVo in _listHLicenseMasterVo.OrderBy(x => x.NameKana)) {
                SheetViewList.Rows.Add(rowCount, 1);
                SheetViewList.RowHeader.Columns[0].Label = (rowCount + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[rowCount].ForeColor = hLicenseMasterVo.DeleteFlag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                SheetViewList.Rows[rowCount].Height = 20; // Rowの高さ
                SheetViewList.Rows[rowCount].Resizable = false; // RowのResizableを禁止
                SheetViewList.Rows[rowCount].Tag = hLicenseMasterVo;
                // 社員コード
                SheetViewList.Cells[rowCount, _colStaffCode].Text = hLicenseMasterVo.StaffCode.ToString("#####");
                // 氏名
                SheetViewList.Cells[rowCount, _colName].Text = hLicenseMasterVo.Name;
                // 交付年月日
                SheetViewList.Cells[rowCount, _colDeliveryDate].Value = hLicenseMasterVo.DeliveryDate.Date;
                // 有効期限
                SheetViewList.Cells[rowCount, _colExpirationDate].Value = hLicenseMasterVo.ExpirationDate.Date;
                // 条件等
                SheetViewList.Cells[rowCount, _colLicenseCondition].Text = hLicenseMasterVo.LicenseCondition;
                // 免許証番号
                SheetViewList.Cells[rowCount, _colLicenseNumber].Text = hLicenseMasterVo.LicenseNumber;
                // 大型
                SheetViewList.Cells[rowCount, _colLarge].Text = hLicenseMasterVo.Large ? "○" : "";
                // 中型
                SheetViewList.Cells[rowCount, _colMedium].Text = hLicenseMasterVo.Medium ? "○" : "";
                // 準中型
                SheetViewList.Cells[rowCount, _colQuasiMedium].Text = hLicenseMasterVo.QuasiMedium ? "○" : "";
                // 普通
                SheetViewList.Cells[rowCount, _colOrdinary].Text = hLicenseMasterVo.Ordinary ? "○" : "";
                // 大特
                SheetViewList.Cells[rowCount, _colBigSpecial].Text = hLicenseMasterVo.BigSpecial ? "○" : "";
                // 大自二
                SheetViewList.Cells[rowCount, _colBigAutoBike].Text = hLicenseMasterVo.BigAutoBike ? "○" : "";
                // 普自二
                SheetViewList.Cells[rowCount, _colOrdinaryAutoBike].Text = hLicenseMasterVo.OrdinaryAutoBike ? "○" : "";
                // 小特
                SheetViewList.Cells[rowCount, _colSmallSpecial].Text = hLicenseMasterVo.SmallSpecial ? "○" : "";
                // 原付
                SheetViewList.Cells[rowCount, _colWithARaw].Text = hLicenseMasterVo.WithARaw ? "○" : "";
                rowCount++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", rowCount, " 件");
        }

        private void PutSheetViewToukaidenshi(List<H_LicenseMasterVo> listHLicenseMasterVo) {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            if (SheetViewToukaidenshi.Rows.Count > 0)
                SheetViewToukaidenshi.RemoveRows(0, SheetViewToukaidenshi.Rows.Count);
            int i = 0;

            foreach (H_LicenseMasterVo hLicenseMasterVo in listHLicenseMasterVo) {
                /*
                 * 245番は予備で使用するので空けておく処理
                 */
                if (i + 1 == 245)
                    i++;
                SheetViewToukaidenshi.Rows.Add(i, 1);
                SheetViewToukaidenshi.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewToukaidenshi.Rows[i].Height = 22; // Rowの高さ
                SheetViewToukaidenshi.Rows[i].Resizable = false; // RowのResizableを禁止
                SheetViewToukaidenshi.Cells[i, _colTId].Text = string.Concat(i + 1);
                SheetViewToukaidenshi.Cells[i, _colTName].Text = hLicenseMasterVo.Name;
                SheetViewToukaidenshi.Cells[i, _colTLicenseNumber].Text = hLicenseMasterVo.LicenseNumber;
                SheetViewToukaidenshi.Cells[i, _colTLicenseExpirationDate].Text = hLicenseMasterVo.ExpirationDate.ToString("yyyy/MM/dd");
                SheetViewToukaidenshi.Cells[i, _colTIssuanceDate].Text = hLicenseMasterVo.DeliveryDate.ToString("yyyy/MM/dd");
                SheetViewToukaidenshi.Cells[i, _colTLicenseType].Text = string.Empty;
                SheetViewToukaidenshi.Cells[i, _colTPin].Text = "無";
                SheetViewToukaidenshi.Cells[i, _colTPicture].Text = "無";
                SheetViewToukaidenshi.Cells[i, _colTNameKana].Text = hLicenseMasterVo.NameKana;
                i++;
            }
            /*
             * 254番の予備を追加する
             */
            SheetViewToukaidenshi.Rows.Add(i, 1);
            SheetViewToukaidenshi.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
            SheetViewToukaidenshi.Rows[i].Height = 22; // Rowの高さ
            SheetViewToukaidenshi.Rows[i].Resizable = false; // RowのResizableを禁止
            SheetViewToukaidenshi.Cells[i, _colTId].Text = "245";
            SheetViewToukaidenshi.Cells[i, _colTName].Text = "予備";
            SheetViewToukaidenshi.Cells[i, _colTLicenseNumber].Text = string.Empty;
            SheetViewToukaidenshi.Cells[i, _colTLicenseExpirationDate].Text = DateTime.Now.AddYears(2).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTIssuanceDate].Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTLicenseType].Text = "";
            SheetViewToukaidenshi.Cells[i, _colTPin].Text = "無";
            SheetViewToukaidenshi.Cells[i, _colTPicture].Text = "無";
            SheetViewToukaidenshi.Cells[i, _colTNameKana].Text = "ヨビ";
            /*
             * 9999番の予備(点検用)を追加する
             */
            SheetViewToukaidenshi.Rows.Add(i, 1);
            SheetViewToukaidenshi.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
            SheetViewToukaidenshi.Rows[i].Height = 22; // Rowの高さ
            SheetViewToukaidenshi.Rows[i].Resizable = false; // RowのResizableを禁止
            SheetViewToukaidenshi.Cells[i, _colTId].Text = "9999";
            SheetViewToukaidenshi.Cells[i, _colTName].Text = "点検用";
            SheetViewToukaidenshi.Cells[i, _colTLicenseNumber].Text = string.Empty;
            SheetViewToukaidenshi.Cells[i, _colTLicenseExpirationDate].Text = DateTime.Now.AddYears(2).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTIssuanceDate].Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTLicenseType].Text = "";
            SheetViewToukaidenshi.Cells[i, _colTPin].Text = "無";
            SheetViewToukaidenshi.Cells[i, _colTPicture].Text = "無";
            SheetViewToukaidenshi.Cells[i, _colTNameKana].Text = "テンケンヨウ";

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ダブルクリックされたのが従事者リストで無ければReturnする
            if (((FpSpread)sender).ActiveSheet.SheetName != "LicenseList")
                return;
            // ヘッダーのDoubleClickを回避
            if (e.ColumnHeader)
                return;
            // Shiftが押された場合
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {

                return;
            }
            // 修飾キーが無い場合
            HLicenseDetail hLicenseDetail = new(_connectionVo, ((H_LicenseMasterVo)SheetViewList.Rows[e.Row].Tag).StaffCode);
            Rectangle rectangleHLicenseDetail = new Desktop().GetMonitorWorkingArea(hLicenseDetail, _connectionVo.Screen);
            hLicenseDetail.KeyPreview = true;
            hLicenseDetail.Location = rectangleHLicenseDetail.Location;
            hLicenseDetail.Size = new Size(1180, 810);
            hLicenseDetail.WindowState = FormWindowState.Normal;
            hLicenseDetail.Show(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // 新規レコードを作成する
                case "ToolStripMenuItemNewLicense":
                    HLicenseDetail hLicenseDetail = new(_connectionVo);
                    Rectangle rectangleHLicenseDetail = new Desktop().GetMonitorWorkingArea(hLicenseDetail, _connectionVo.Screen);
                    hLicenseDetail.KeyPreview = true;
                    hLicenseDetail.Location = rectangleHLicenseDetail.Location;
                    hLicenseDetail.Size = new Size(1180, 810);
                    hLicenseDetail.WindowState = FormWindowState.Normal;
                    hLicenseDetail.Show(this);
                    break;
                // 東海電子ALC用CSV
                case "ToolStripMenuItemToukaiCSV":
                    //csv形式ファイルをエクスポートします
                    string fileName = string.Concat("東海電子免許証データ", DateTime.Now.ToString("MM月dd日"), "作成");
                    //アクティブシート上の全データをcsv形式ファイルに保存します
                    SheetViewToukaidenshi.SaveTextFile(new Directry().GetExcelDesktopPassCsv(fileName),
                                                       TextFileFlags.None,
                                                       FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly,
                                                       Environment.NewLine,
                                                       ",",
                                                       "");
                    MessageBox.Show("デスクトップへエクスポートしました", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ToolStripMenuItemToukaiCSV.Enabled = false;

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

        /// <summary>
        /// H_LicenseList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LicenseList_FormClosing(object sender, FormClosingEventArgs e) {
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
