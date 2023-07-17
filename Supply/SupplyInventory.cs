using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyInventory : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 1 },
                                                                                                             { "雇上での備品", 2 },
                                                                                                             { "産廃での備品", 3 },
                                                                                                             { "水物での備品", 4 } };
        /*
         * Dao
         */
        private readonly SupplyInventoryDao _supplyInventoryDao;
        /// <summary>
        /// 備品コード
        /// </summary>
        private const int _colSupplyCode = 0;
        /// <summary>
        /// 備品名
        /// </summary>
        private const int _colSupplyName = 1;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="supplyType">タイプ</param>
        public SupplyInventory(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _supplyInventoryDao = new SupplyInventoryDao(connectionVo);
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

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            /*
             * ComboBoxSupplyTypeが選択されているかチェックする
             */
            if(ComboBoxSupplyType.Text.Length < 1) {
                MessageBox.Show("在庫種別を選択して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("棚卸データを更新します。よろしいですか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.Cancel:
                    return;
            }
            // 月初・月末を設定
            DateTime startDate = new Date().GetBeginOfMonth(MonthPicker1.Value);
            /*
             * DELETE
             */
            try {
                _supplyInventoryDao.DeleteSupplyInventory(MonthPicker1.Value);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }

            for(int i = 0; i < SheetViewList.RowCount; i++) {
                // Voを作成
                SupplyInventoryVo supplyInventoryVo = new SupplyInventoryVo();
                supplyInventoryVo.Inventory_date = startDate;
                supplyInventoryVo.Code = Convert.ToInt32(SheetViewList.Cells[i, 0].Value);
                supplyInventoryVo.Name = SheetViewList.Cells[i, 1].Text;
                supplyInventoryVo.ProperStock = Convert.ToInt32(SheetViewList.Cells[i, 2].Value);
                supplyInventoryVo.Memo = SheetViewList.Cells[i, 3].Text;
                supplyInventoryVo.Insert_ymd_hms = DateTime.Now;
                supplyInventoryVo.Update_ymd_hms = _defaultDateTime;
                supplyInventoryVo.Delete_ymd_hms = _defaultDateTime;
                supplyInventoryVo.Delete_flag = false;
                /*
                 * INSERT
                 */
                try {
                    _supplyInventoryDao.InsertSupplyInventory(supplyInventoryVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            MessageBox.Show("正常にデータを更新しました。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// SpreadOutput
        /// </summary>
        public void SpreadOutput() {
            /*
             * ColumsHeaderの書換え
             */
            SheetViewList.ColumnHeader.Columns[2].Label = MonthPicker1.Value.ToString("MM月棚卸数"); // 今月

            List<SupplyScreenVo> listSupplyInVo = new();
            try {
                listSupplyInVo = _supplyInventoryDao.SelectSupplyInventory(MonthPicker1.Value, _dictionaryAffiliationValue[ComboBoxSupplyType.Text]);
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
            foreach(SupplyScreenVo supplyInVo in listSupplyInVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                // 備品コード
                SheetViewList.Cells[i, _colSupplyCode].Value = supplyInVo.SupplyCode;
                // 備品名
                SheetViewList.Cells[i, _colSupplyName].Text = supplyInVo.SupplyName;
                // 今月の棚卸数
                SheetViewList.Cells[i, 2].Value = supplyInVo.SupplyCount;
                // メモ
                SheetViewList.Cells[i, 3].Value = supplyInVo.Memo;
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
