using Common;

using Dao;

using FarPoint.Win.Spread;

using H_Vo;

namespace WardSpreadsheet {
    public partial class WardChiyoda : Form {
        private Dictionary<DateTime, string> _dictionaryHoliday;
        /*
         * Dao
         */
        private WardChiyodaDao _wardSpreadSheetDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        List<WardChiyodaVo> _listWardChiyodaVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public WardChiyoda(ConnectionVo connectionVo) {
            _dictionaryHoliday = new HolidayUtil().GetHoliday();
            /*
             * Dao
             */
            _wardSpreadSheetDao = new WardChiyodaDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            DateTimePicker1.Value = DateTime.Now;
            DateTimePicker2.Value = DateTime.Now;
            InitializeSheetViewList(SheetViewList);
            InitializeSheetViewCount(SheetViewAggregate);
            ToolStripStatusLabelStatus.Text = string.Empty;
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
            _listWardChiyodaVo = _wardSpreadSheetDao.SelectChiyodaVehicleDispatchDetail(DateTimePicker1.Value, DateTimePicker2.Value);
            SheetViewListOutPut();
            SheetViewAggregateOutPut();
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int sheetViewListTopRow = 0;
        private void SheetViewListOutPut() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            // 先頭行（列）インデックスを取得
            sheetViewListTopRow = SpreadList.GetViewportTopRow(0);

            int i = 0;
            foreach(WardChiyodaVo wardChiyodaVo in _listWardChiyodaVo) {
                SheetViewList.AddRows(i, 1);
                if(_dictionaryHoliday.ContainsKey(wardChiyodaVo.Operation_date)) {
                    SheetViewList.Cells[i, 0].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 0].Text = string.Concat(wardChiyodaVo.Operation_date.ToString("yyyy年MM月dd日"), "(", _dictionaryHoliday[wardChiyodaVo.Operation_date], ")");
                    SheetViewList.Cells[i, 1].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 1].Text = wardChiyodaVo.Operator_name_1;
                    SheetViewList.Cells[i, 2].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 2].Text = wardChiyodaVo.Operator_name_2;
                    SheetViewList.Cells[i, 3].ForeColor = Color.Gray;
                    SheetViewList.Cells[i, 3].Text = wardChiyodaVo.Operator_name_3;
                } else {
                    SheetViewList.Cells[i, 0].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 0].Text = wardChiyodaVo.Operation_date.ToString("yyyy年MM月dd日(dddd)");
                    SheetViewList.Cells[i, 1].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 1].Text = wardChiyodaVo.Operator_name_1;
                    SheetViewList.Cells[i, 2].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 2].Text = wardChiyodaVo.Operator_name_2;
                    SheetViewList.Cells[i, 3].ForeColor = Color.Gray;
                    SheetViewList.Cells[i, 3].Text = wardChiyodaVo.Operator_name_3;
                }
                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, sheetViewListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int sheetViewAggregateTopRow = 0;
        private void SheetViewAggregateOutPut() {
            // Spread 非活性化
            SpreadAggregate.SuspendLayout();
            // Rowを削除する
            if(SheetViewAggregate.Rows.Count > 0)
                SheetViewAggregate.RemoveRows(0, SheetViewAggregate.Rows.Count);
            // 先頭行（列）インデックスを取得
            sheetViewAggregateTopRow = SpreadAggregate.GetViewportTopRow(0);
            List<WardChiyodaVo2> listWardChiyodaVo2 = _wardSpreadSheetDao.SelectGroupByChiyodaVehicleDispatchDetail(DateTimePicker1.Value, DateTimePicker2.Value);
            foreach(var wardChiyodaVo2 in listWardChiyodaVo2) {
                bool newRowFlag = true;
                for(int rowNumber = 0; rowNumber < SheetViewAggregate.RowCount; rowNumber++) {
                    string key1 = SheetViewAggregate.Cells[rowNumber, 0].Text;
                    string key2 = SheetViewAggregate.Cells[rowNumber, 1].Text;
                    int key3 = (int)SheetViewAggregate.Cells[rowNumber, 2].Value;
                    int key4 = (int)SheetViewAggregate.Cells[rowNumber, 3].Value;
                    if(wardChiyodaVo2.Operator_name == key1 && wardChiyodaVo2.Occupation == key2) {
                        /*
                         * 祝日かどうかを判定する(日曜日は入っていないので注意してね)
                         */
                        if(_dictionaryHoliday.ContainsKey(wardChiyodaVo2.Operation_date)) {
                            /*
                             * 祝日の場合
                             */
                            key4++;
                            SheetViewAggregate.Cells[rowNumber, 3].Value = key4;
                            newRowFlag = false;
                        } else {
                            /*
                             * 平日の場合
                             */
                            key3++;
                            SheetViewAggregate.Cells[rowNumber, 2].Value = key3;
                            newRowFlag = false;
                        }
                    };
                }
                /*
                 * 新規Rowを挿入する
                 * 祝日かどうかを判定する(日曜日は入っていないので注意してね)
                 */
                if(newRowFlag) {
                    if(_dictionaryHoliday.ContainsKey(wardChiyodaVo2.Operation_date)) {
                        /*
                         * 祝日の場合
                         */
                        SheetViewAggregate.AddRows(0, 1);
                        SheetViewAggregate.Cells[0, 0].Tag = wardChiyodaVo2.Operator_code;
                        SheetViewAggregate.Cells[0, 0].Text = wardChiyodaVo2.Operator_name;
                        SheetViewAggregate.Cells[0, 1].Text = wardChiyodaVo2.Occupation;
                        SheetViewAggregate.Cells[0, 2].Value = 0; // 平日の出勤日数を初期化
                        SheetViewAggregate.Cells[0, 3].Value = 1; // 休日の出勤日数を初期化
                        SheetViewAggregate.Cells[0, 4].Value = 0;
                    } else {
                        /*
                         * 平日の場合
                         */
                        SheetViewAggregate.AddRows(0, 1);
                        SheetViewAggregate.Cells[0, 0].Tag = wardChiyodaVo2.Operator_code;
                        SheetViewAggregate.Cells[0, 0].Text = wardChiyodaVo2.Operator_name;
                        SheetViewAggregate.Cells[0, 1].Text = wardChiyodaVo2.Occupation;
                        SheetViewAggregate.Cells[0, 2].Value = 1; // 平日の出勤日数を初期化
                        SheetViewAggregate.Cells[0, 3].Value = 0; // 休日の出勤日数を初期化
                        SheetViewAggregate.Cells[0, 4].Value = 0;
                    }
                }
            }
            /*
             * Footer集計
             */
            int H_GKI = 0;
            int K_GKI = 0;
            for(int i = 0; i < SheetViewAggregate.RowCount; i++) {
                H_GKI = H_GKI + (int)SheetViewAggregate.Cells[i, 2].Value;
                K_GKI = K_GKI + (int)SheetViewAggregate.Cells[i, 3].Value;
            }
            SheetViewAggregate.ColumnFooter.Cells[0, 2].Text = H_GKI.ToString();
            SheetViewAggregate.ColumnFooter.Cells[0, 3].Text = K_GKI.ToString();
            /*
             * 全ての配車先での出勤日数計算
             */
            for(int i = 0; i < SheetViewAggregate.RowCount; i++) {
                SheetViewAggregate.Cells[i, 4].Value = _wardSpreadSheetDao.GetWorkDaysForStaff(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, (int)SheetViewAggregate.Cells[i, 0].Tag);
            }
            // 先頭行（列）インデックスをセット
            SpreadAggregate.SetViewportTopRow(0, sheetViewAggregateTopRow);
            // Spread 活性化
            SpreadAggregate.ResumeLayout();
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
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            // Rowを削除する
            if(sheetView.Rows.Count > 0)
                sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// InitializeSheetViewCount
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewCount(SheetView sheetView) {
            SpreadAggregate.AllowDragDrop = false; // DrugDropを禁止する
            SpreadAggregate.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadAggregate.TabStripPolicy = TabStripPolicy.Never; // シートタブを非表示
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            // Rowを削除する
            if(sheetView.Rows.Count > 0)
                sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// DateTimePicker1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePicker)sender).Value > DateTimePicker2.Value) {
                DateTimePicker2.Value = ((DateTimePicker)sender).Value;
            }
        }

        /// <summary>
        /// DateTimePicker2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePicker)sender).Value < DateTimePicker1.Value) {
                DateTimePicker1.Value = ((DateTimePicker)sender).Value;
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //アクティブシート印刷します
            SpreadAggregate.PrintSheet(SheetViewAggregate);
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
        /// WardChiyoda_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WardChiyoda_FormClosing(object sender, FormClosingEventArgs e) {
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