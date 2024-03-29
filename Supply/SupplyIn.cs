/*
 * 2023-07-13
 * 備品入庫処理
 */
using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyIn : Form {
        /*
         * 定数
         */
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 1 },
                                                                                                             { "雇上での備品", 2 },
                                                                                                             { "産廃での備品", 3 },
                                                                                                             { "水物での備品", 4 } };
        /// <summary>
        /// 備品コード
        /// </summary>
        private const int _colSupplyCode = 0;
        /// <summary>
        /// 備品名
        /// </summary>
        private const int _colSupplyName = 1;
        /// <summary>
        /// 入庫数量
        /// </summary>
        private const int _colSupplyNumber = 2;
        /// <summary>
        /// メモ
        /// </summary>
        private const int _colSupplyMemo = 3;

        /*
         * Dao
         */
        private readonly SupplyInDao _supplyInDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyIn(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _supplyInDao = new SupplyInDao(connectionVo);
            /*
             * Control初期化
             */
            InitializeComponent();
            DateTimePickerJpExMoveDate.SetValue(DateTime.Now);
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
            /*
             * DELETE
             * 対象年月日の入庫データを削除する
             */
            try {
                _supplyInDao.DeleteSupplyMove(DateTimePickerJpExMoveDate.GetValue().Date);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }

            for(int i = 0; i < SheetViewList.RowCount; i++) {
                // Voを作成
                SupplyMoveVo supplyMoveVo = new SupplyMoveVo();
                supplyMoveVo.Staff_code = 0; // 入庫処理にStaffCodeは必要ない
                supplyMoveVo.Move_date = DateTimePickerJpExMoveDate.GetValue().Date;
                supplyMoveVo.Supply_code = Convert.ToInt32(SheetViewList.Cells[i, _colSupplyCode].Value);
                supplyMoveVo.Supply_number = Convert.ToInt32(SheetViewList.Cells[i, _colSupplyNumber].Value);
                supplyMoveVo.Move_flag = true;
                supplyMoveVo.Memo = SheetViewList.Cells[i, _colSupplyMemo].Text;
                supplyMoveVo.Insert_pc_name = Environment.MachineName;
                supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                supplyMoveVo.Update_pc_name = string.Empty;
                supplyMoveVo.Update_ymd_hms = _defaultDateTime;
                supplyMoveVo.Delete_pc_name = string.Empty;
                supplyMoveVo.Delete_ymd_hms = _defaultDateTime;
                supplyMoveVo.Delete_flag = false;
                /*
                 * INSERT
                 * 入庫数ゼロの物はInsertしない
                 */
                if(supplyMoveVo.Supply_number != 0) {
                    try {
                        _supplyInDao.InsertSupplyMove(supplyMoveVo);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
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
            List<SupplyScreenVo> listSupplyInVo = new();
            try {
                listSupplyInVo = _supplyInDao.SelectSupplyMove(DateTimePickerJpExMoveDate.Value.Date, _dictionaryAffiliationValue[ComboBoxSupplyType.Text]);
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
