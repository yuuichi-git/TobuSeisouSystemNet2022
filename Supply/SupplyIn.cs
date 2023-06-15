using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyIn : Form {
        private InitializeForm _initializeForm = new();
        private string _affiliationValue = string.Empty;
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 1 },
                                                                                                             { "雇上での備品", 2 },
                                                                                                             { "産廃での備品", 3 },
                                                                                                             { "水物での備品", 4 } };
        /*
         * Dao
         */
        private readonly SupplyMasterDao _supplyMasterDao;
        private readonly SupplyInDao _supplyInDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// 備品コード
        /// </summary>
        private const int colSupplyCode = 0;
        /// <summary>
        /// 備品名
        /// </summary>
        private const int colSupplyName = 1;

        public SupplyIn(ConnectionVo connectionVo, string supplyType) {
            _affiliationValue = supplyType;
            /*
             * Dao
             */
            _supplyMasterDao = new SupplyMasterDao(connectionVo);
            _supplyInDao = new SupplyInDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            /*
             * Control初期化
             */
            InitializeComponent();
            MonthPicker1.Value = DateTime.Now.Date;
            /*
             * SPREAD初期化
             */
            InitializeSheetViewList(SheetViewList);
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// SpreadOutput
        /// </summary>
        public void SpreadOutput() {
            /*
             * ColumsHeaderの書換え
             */
            SheetViewList.ColumnHeader.Columns[2].Label = MonthPicker1.Value.ToString("MM月棚卸数"); // 今月

            List<SupplyInVo> listSupplyInVo = new();
            try {
                listSupplyInVo = _supplyInDao.SelectSupplyInventory(MonthPicker1.Value, _dictionaryAffiliationValue[ComboBoxSupplyType.Text]);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }

            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(SupplyInVo supplyInVo in listSupplyInVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                // 備品コード
                SheetViewList.Cells[i, colSupplyCode].Value = supplyInVo.SupplyCode;
                // 備品名
                SheetViewList.Cells[i, colSupplyName].Text = supplyInVo.SupplyName;

                // 今月の棚卸数
                SheetViewList.Cells[i, 2].Value = supplyInVo.InventoryStock;
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

            sheetView.ColumnHeader.Columns[2].Label = " "; // 今月
        }

        /// <summary>
        /// ComboBoxSupplyType_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSupplyType_SelectedIndexChanged(object sender, EventArgs e) {
            SpreadOutput();
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
        /// SupplyIn_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplyIn_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
