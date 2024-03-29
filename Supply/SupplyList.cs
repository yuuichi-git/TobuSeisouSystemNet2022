using Common;

using ControlEx;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyList : Form {
        private InitializeForm _initializeForm = new();
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 1 },
                                                                                                             { "雇上での備品", 2 },
                                                                                                             { "産廃での備品", 3 },
                                                                                                             { "水物での備品", 4 } };
        /*
         * Dao
         */
        private readonly SupplyListDao _supplyListDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// 備品コード
        /// </summary>
        private const int _colSupplyCode = 0;
        /// <summary>
        /// 備品名
        /// </summary>
        private const int _colSupplyName = 1;
        /// <summary>
        /// 適正在庫数
        /// </summary>
        private const int _colAppropriateStock = 2;
        /// <summary>
        /// 月初在庫数
        /// </summary>
        private const int _colBeginingMonthStock = 3;
        /// <summary>
        /// 入庫数
        /// </summary>
        private const int _colWarehousing = 4;
        /// <summary>
        /// 出庫数
        /// </summary>
        private const int _colDelivery = 5;
        /// <summary>
        /// 在庫数
        /// </summary>
        private const int _colStock = 6;
        /// <summary>
        /// 発注数
        /// </summary>
        private const int _colOrder = 7;

        public SupplyList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _supplyListDao = new SupplyListDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Control初期化
             */
            InitializeComponent();
            _initializeForm.SupplyList(this);
            /*
             * 在庫種別を設定
             */
            ComboBoxSupplyType.SelectedIndex = 1;
            /*
             * 月初・月末を設定
             */
            DateTimePickerJpEx1.Value = new Date().GetBeginOfMonth(DateTime.Now.Date);
            DateTimePickerJpEx2.Value = new Date().GetEndOfMonth(DateTime.Now.Date);
            /*
             * SPREAD初期化
             */
            InitializeSheetViewList(SheetViewList);
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(SupplyListVo supplyListVo in _supplyListDao.SelectSupplyListVo(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, _dictionaryAffiliationValue[ComboBoxSupplyType.Text])) {
                int _appropriateStock = supplyListVo.AppropriateStock;
                int _beginingMonthStock = supplyListVo.BeginingMonthStock;
                int _warehousing = supplyListVo.Warehousing;
                int _delivery = supplyListVo.Delivery;
                int _stock = _beginingMonthStock + _warehousing - _delivery;
                int _order = _appropriateStock - _stock;

                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                // 備品コード
                SheetViewList.Cells[i, _colSupplyCode].Value = supplyListVo.SupplyCode;
                // 備品名
                SheetViewList.Cells[i, _colSupplyName].Text = supplyListVo.SupplyName;
                // 適正在庫数
                SheetViewList.Cells[i, _colAppropriateStock].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colAppropriateStock].ForeColor = Color.Black;
                SheetViewList.Cells[i, _colAppropriateStock].Value = _appropriateStock;
                // 月初在庫数
                SheetViewList.Cells[i, _colBeginingMonthStock].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colBeginingMonthStock].ForeColor = Color.Blue;
                SheetViewList.Cells[i, _colBeginingMonthStock].Value = _beginingMonthStock;
                // 入庫数
                SheetViewList.Cells[i, _colWarehousing].Value = _warehousing != 0 ? _warehousing : "";
                // 出庫数
                SheetViewList.Cells[i, _colDelivery].Value = _delivery != 0 ? _delivery : "";
                // 在庫数
                SheetViewList.Cells[i, _colStock].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colStock].ForeColor = Color.Red;
                SheetViewList.Cells[i, _colStock].Value = _stock;
                // 発注数
                SheetViewList.Cells[i, _colOrder].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colOrder].ForeColor = Color.Gray;
                SheetViewList.Cells[i, _colOrder].Value = _order > 0 && _order <= _appropriateStock ? _order : "";

                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        private void InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // シートタブを非表示にする
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 10); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
        }

        /// <summary>
        /// ToolStripMenuItemInventory_Click
        /// 棚卸数の入力画面を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInventory_Click(object sender, EventArgs e) {
            SupplyInventory supplyInventory = new SupplyInventory(_connectionVo);
            supplyInventory.ShowDialog(this);
        }

        /// <summary>
        /// ToolStripMenuItemIn_Click
        /// 入庫数の入力画面を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemIn_Click(object sender, EventArgs e) {
            SupplyIn supplyIn = new SupplyIn(_connectionVo);
            supplyIn.ShowDialog(this);
        }

        /// <summary>
        /// DateTimePickerJpEx_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value > DateTimePickerJpEx2.Value) {
                DateTimePickerJpEx2.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }
        private void DateTimePickerJpEx2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value < DateTimePickerJpEx1.Value) {
                DateTimePickerJpEx1.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrint_Click
        /// 印刷する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            SpreadList.PrintSheet(SheetViewList);
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if(e.ColumnHeader)
                return;
            SupplyDetail supplyDetail = new SupplyDetail(_connectionVo,
                                                         (int)SheetViewList.Cells[e.Row, _colSupplyCode].Value,
                                                         DateTimePickerJpEx1.Value.Date,
                                                         DateTimePickerJpEx2.Value.Date);
            supplyDetail.ShowDialog(this);
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
        /// SupplyList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplyList_FormClosing(object sender, FormClosingEventArgs e) {
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