using Common;

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
        private readonly SupplyMasterDao _supplyMasterDao;
        private readonly SupplyMoveDao _supplyMoveDao;
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
        /// <summary>
        /// 適正在庫数
        /// </summary>
        private const int colAppropriateStock = 2;
        /// <summary>
        /// 月初在庫数
        /// </summary>
        private const int colBeginingMonthStock = 3;
        /// <summary>
        /// 入庫数
        /// </summary>
        private const int colWarehousing = 4;
        /// <summary>
        /// 出庫数
        /// </summary>
        private const int colDelivery = 5;
        /// <summary>
        /// 在庫数
        /// </summary>
        private const int colStock = 6;

        public SupplyList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _supplyMasterDao = new SupplyMasterDao(connectionVo);
            _supplyMoveDao = new SupplyMoveDao(connectionVo);
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
            DateTimePickerJpEx1.Value = new Date().GetBeginOfMonth(DateTimePickerJpEx1.Value);
            DateTimePickerJpEx2.Value = new Date().GetEndOfMonth(DateTimePickerJpEx2.Value);
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

            List<SupplyMasterVo> listSupplyMasterVo = _supplyMasterDao.SelectOneSupplyMaster(_dictionaryAffiliationValue[ComboBoxSupplyType.Text]);

            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            int _supplyNumber = 0;
            foreach(SupplyMasterVo supplyMasterVo in listSupplyMasterVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                // 備品コード
                SheetViewList.Cells[i, colSupplyCode].Value = supplyMasterVo.Code;
                // 備品名
                SheetViewList.Cells[i, colSupplyName].Text = supplyMasterVo.Name;
                // 適正在庫数
                SheetViewList.Cells[i, colAppropriateStock].Value = supplyMasterVo.Proper_stock;
                /*
                 * 入庫数
                 */
                try {
                    _supplyNumber = _supplyMoveDao.SelectCountSupplyMoveIn(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, supplyMasterVo.Code);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                SheetViewList.Cells[i, colWarehousing].Value = _supplyNumber;
                /*
                 * 出庫数
                 */
                try {
                    _supplyNumber = _supplyMoveDao.SelectCountSupplyMoveOut(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, supplyMasterVo.Code);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                SheetViewList.Cells[i, colDelivery].Value = _supplyNumber;

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
            SupplyIn supplyIn = new SupplyIn(_connectionVo,ComboBoxSupplyType.Text);
            supplyIn.ShowDialog(this);
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