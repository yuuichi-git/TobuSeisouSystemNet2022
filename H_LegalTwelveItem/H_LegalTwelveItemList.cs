/*
 * 2024-04-27
 */
using System.Drawing.Printing;

using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using H_Vo;

using Vo;

namespace H_LegalTwelveItem {
    public partial class H_LegalTwelveItemList : Form {
        /*
         * Columns
         */
        private const int colBelongsName = 0;
        private const int colJobFormName = 1;
        private const int colOccupation = 2;
        private const int colName = 3;
        private const int colEmploymentDate = 4;
        private const int colStudentsFlag01 = 5;
        private const int colStudentsFlag02 = 6;
        private const int colStudentsFlag03 = 7;
        private const int colStudentsFlag04 = 8;
        private const int colStudentsFlag05 = 9;
        private const int colStudentsFlag06 = 10;
        private const int colStudentsFlag07 = 11;
        private const int colStudentsFlag08 = 12;
        private const int colStudentsFlag09 = 13;
        private const int colStudentsFlag10 = 14;
        private const int colStudentsFlag11 = 15;
        private const int colStudentsFlag12 = 16;
        private readonly DateTime _defaultDatetime = new DateTime(1900, 01, 01);
        /*
         * 
         */
        private readonly Date _date;
        /*
         * Dao
         */
        private readonly H_LegalTwelveItemDao _hLegalTwelveItemDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_LegalTwelveItemList(ConnectionVo connectionVo) {
            /*
             * 
             */
            _date = new();
            /*
             * Dao
             */
            _hLegalTwelveItemDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.HCheckBoxExJobForm.Checked = false;
            this.InitializeSheetViewList(SheetViewList);
            this.ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.PutSheetViewList(_hLegalTwelveItemDao.SelectHLegalTwelveItemListVo(_date.GetFiscalYearStartDate((int)HNumericUpDownExFiscalYear.Value), _date.GetFiscalYearEndDate((int)HNumericUpDownExFiscalYear.Value), HCheckBoxExJobForm.Checked));
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="listHLegalTwelveItemVo"></param>
        private void PutSheetViewList(List<H_LegalTwelveItemListVo> listHLegalTwelveItemVo) {
            /*
             * SheetViewListの準備
             */
            SpreadList.SuspendLayout(); // Spread 非活性化
            spreadListTopRow = SpreadList.GetViewportTopRow(0); // 先頭行（列）インデックスを取得
            if (SheetViewList.Rows.Count > 0) // Rowを削除する
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            /*
             * SheetViewListへ表示
             */
            int i = 0;
            foreach (H_LegalTwelveItemListVo hLegalTwelveItemVo in listHLegalTwelveItemVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].ForeColor = hLegalTwelveItemVo.JobForm == 11 ? Color.Blue : Color.Black; // 手帳のレコードのForeColorをセット
                SheetViewList.Rows[i].Tag = hLegalTwelveItemVo; // H_LegalTwelveItemVoを退避
                SheetViewList.Cells[i, colBelongsName].Text = hLegalTwelveItemVo.BelongsName;
                SheetViewList.Cells[i, colJobFormName].Text = hLegalTwelveItemVo.JobFormName;
                SheetViewList.Cells[i, colOccupation].Text = hLegalTwelveItemVo.OccupationName;
                SheetViewList.Cells[i, colName].Text = hLegalTwelveItemVo.StaffName;
                SheetViewList.Cells[i, colEmploymentDate].Text = hLegalTwelveItemVo.EmploymentDate != _defaultDatetime ? hLegalTwelveItemVo.EmploymentDate.ToString("yyyy/MM/dd") : "";
                SheetViewList.Cells[i, colStudentsFlag01].Text = hLegalTwelveItemVo.Students01Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag02].Text = hLegalTwelveItemVo.Students02Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag03].Text = hLegalTwelveItemVo.Students03Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag04].Text = hLegalTwelveItemVo.Students04Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag05].Text = hLegalTwelveItemVo.Students05Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag06].Text = hLegalTwelveItemVo.Students06Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag07].Text = hLegalTwelveItemVo.Students07Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag08].Text = hLegalTwelveItemVo.Students08Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag09].Text = hLegalTwelveItemVo.Students09Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag10].Text = hLegalTwelveItemVo.Students10Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag11].Text = hLegalTwelveItemVo.Students11Flag ? "〇" : "";
                SheetViewList.Cells[i, colStudentsFlag12].Text = hLegalTwelveItemVo.Students12Flag ? "〇" : "";
                i++;
            }
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
            /*
             * ヘッダーのDoubleClickを回避
             */
            if (e.ColumnHeader)
                return;
            /*
             * Detailウインドウを表示
             */
            H_LegalTwelveItemDetail hLegalTwelveItemDetail = new(_connectionVo, (int)HNumericUpDownExFiscalYear.Value, (H_LegalTwelveItemListVo)SheetViewList.Rows[e.Row].Tag);
            new Desktop().SetPosition(hLegalTwelveItemDetail, _connectionVo.Screen);
            hLegalTwelveItemDetail.KeyPreview = true;
            hLegalTwelveItemDetail.Show(this);
            return;
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
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
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // A4で印刷
                case "ToolStripMenuItemPrintA4":
                    PrintDocument _printDocument = new();
                    // Eventを登録
                    _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                    // 出力先プリンタを指定します。
                    //_printDocument.PrinterSettings.PrinterName = this.HComboBoxExPrinterName.Text;
                    // 用紙の向きを設定(横：true、縦：false)
                    _printDocument.DefaultPageSettings.Landscape = false;
                    /*
                     * プリンタがサポートしている用紙サイズを調べる
                     */
                    foreach (PaperSize paperSize in _printDocument.PrinterSettings.PaperSizes) {
                        // A4用紙に設定する
                        if (paperSize.Kind == PaperKind.A4) {
                            _printDocument.DefaultPageSettings.PaperSize = paperSize;
                            break;
                        }
                    }
                    // 印刷部数を指定します。
                    _printDocument.PrinterSettings.Copies = 1;
                    // 片面印刷に設定します。
                    _printDocument.PrinterSettings.Duplex = Duplex.Default;
                    // カラー印刷に設定します。
                    _printDocument.PrinterSettings.DefaultPageSettings.Color = true;
                    // 印刷する
                    _printDocument.Print();
                    break;
                case "ToolStripMenuItemPrintA4Dialog":
                    // Excelライクなプレビューダイアログを有効にします
                    SheetViewList.PrintInfo.EnhancePreview = true;
                    SheetViewList.PrintInfo.Preview = true;
                    SheetViewList.PrintInfo.ShowBorder = false;
                    SheetViewList.PrintInfo.ShowColor = true;
                    // 印刷を実行します
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            // 印刷ページ（1ページ目）の描画を行う
            Rectangle rectangle = new(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
            // e.Graphicsへ出力(page パラメータは、０からではなく１から始まります)
            SpreadList.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
            // 印刷終了を指定
            e.HasMorePages = false;
        }

        /// <summary>
        /// H_LegalTwelveItemList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LegalTwelveItemList_FormClosing(object sender, FormClosingEventArgs e) {
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
