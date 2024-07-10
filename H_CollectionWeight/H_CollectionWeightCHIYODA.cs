/*
 * 2024-03-20
 */
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_CollectionWeight {
    public partial class H_CollectionWeightCHIYODA : Form {
        /*
         * Dao
         */
        private readonly H_CollectionWeightChiyodaDao _hCollectionWeightChiyodaDao;
        /*
         * インターネットから祝日のデータを取得
         */
        private Dictionary<DateTime, string> _dictionaryHoliday = new HolidayUtil().GetHoliday();

        public H_CollectionWeightCHIYODA(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCollectionWeightChiyodaDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            HDateTimePickerEx1.SetValueJp(DateTime.Now);
            HDateTimePickerEx2.SetValueJp(DateTime.Now);
            InitializeSheetViewList(SheetViewList);
            InitializeSheetViewAggregate(SheetViewAggregate);
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.PutSheetViewList();
            this.PutSheetViewAggregate();
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        private void PutSheetViewList() {
            int sheetViewListTopRow;
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // Rowを削除する
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            // 先頭行（列）インデックスを取得
            sheetViewListTopRow = SpreadList.GetViewportTopRow(0);

            int i = 0;
            foreach (H_CollectionWeightChiyodaVo hCollectionWeightChiyodaVo in _hCollectionWeightChiyodaDao.SelectHVehicleDispatchDetail(HDateTimePickerEx1.GetValue(), HDateTimePickerEx2.GetValue())) {
                SheetViewList.AddRows(i, 1);
                if (_dictionaryHoliday.ContainsKey(hCollectionWeightChiyodaVo.OperationDate)) {
                    SheetViewList.Cells[i, 0].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 0].Text = string.Concat(hCollectionWeightChiyodaVo.OperationDate.ToString("yyyy年MM月dd日"), "(", _dictionaryHoliday[hCollectionWeightChiyodaVo.OperationDate], ")");
                    SheetViewList.Cells[i, 1].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 1].Text = hCollectionWeightChiyodaVo.StaffDisplayName1;
                    SheetViewList.Cells[i, 2].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 2].Text = hCollectionWeightChiyodaVo.StaffDisplayName2;
                    SheetViewList.Cells[i, 3].ForeColor = Color.Gray;
                    SheetViewList.Cells[i, 3].Text = hCollectionWeightChiyodaVo.StaffDisplayName3;
                } else {
                    SheetViewList.Cells[i, 0].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 0].Text = hCollectionWeightChiyodaVo.OperationDate.ToString("yyyy年MM月dd日(dddd)");
                    SheetViewList.Cells[i, 1].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 1].Text = hCollectionWeightChiyodaVo.StaffDisplayName1;
                    SheetViewList.Cells[i, 2].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 2].Text = hCollectionWeightChiyodaVo.StaffDisplayName2;
                    SheetViewList.Cells[i, 3].ForeColor = Color.Gray;
                    SheetViewList.Cells[i, 3].Text = hCollectionWeightChiyodaVo.StaffDisplayName3;
                }
                i++;
            }
            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, sheetViewListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
        }

        /// <summary>
        /// PutSheetViewAggregate
        /// </summary>
        private void PutSheetViewAggregate() {
            int sheetViewAggregateTopRow;
            // Spread 非活性化
            SpreadAggregate.SuspendLayout();
            // Rowを削除する
            if (SheetViewAggregate.Rows.Count > 0)
                SheetViewAggregate.RemoveRows(0, SheetViewAggregate.Rows.Count);
            // 先頭行（列）インデックスを取得
            sheetViewAggregateTopRow = SpreadAggregate.GetViewportTopRow(0);
            foreach (H_CollectionWeightGroupChiyodaVo hCollectionWeightGroupChiyodaVo in _hCollectionWeightChiyodaDao.SelectGroupByHVehicleDispatchDetail(HDateTimePickerEx1.GetValue(), HDateTimePickerEx2.GetValue())) {
                bool newRowFlag = true;
                for (int rowNumber = 0; rowNumber < SheetViewAggregate.RowCount; rowNumber++) {
                    string key1 = SheetViewAggregate.Cells[rowNumber, 0].Text;
                    string key2 = SheetViewAggregate.Cells[rowNumber, 1].Text;
                    int key3 = (int)SheetViewAggregate.Cells[rowNumber, 2].Value;
                    int key4 = (int)SheetViewAggregate.Cells[rowNumber, 3].Value;
                    if (hCollectionWeightGroupChiyodaVo.StaffDisplayName == key1 && hCollectionWeightGroupChiyodaVo.Occupation == key2) {
                        /*
                         * 祝日かどうかを判定する(日曜日は入っていないので注意してね)
                         */
                        if (_dictionaryHoliday.ContainsKey(hCollectionWeightGroupChiyodaVo.OperationDate)) {
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
                if (newRowFlag) {
                    if (_dictionaryHoliday.ContainsKey(hCollectionWeightGroupChiyodaVo.OperationDate)) {
                        /*
                         * 祝日の場合
                         */
                        SheetViewAggregate.AddRows(0, 1);
                        SheetViewAggregate.Cells[0, 0].Tag = hCollectionWeightGroupChiyodaVo.StaffCode;
                        SheetViewAggregate.Cells[0, 0].Text = hCollectionWeightGroupChiyodaVo.StaffDisplayName;
                        SheetViewAggregate.Cells[0, 1].Text = hCollectionWeightGroupChiyodaVo.Occupation;
                        SheetViewAggregate.Cells[0, 2].Value = 0; // 平日の出勤日数を初期化
                        SheetViewAggregate.Cells[0, 3].Value = 1; // 休日の出勤日数を初期化
                        SheetViewAggregate.Cells[0, 4].Value = 0;
                    } else {
                        /*
                         * 平日の場合
                         */
                        SheetViewAggregate.AddRows(0, 1);
                        SheetViewAggregate.Cells[0, 0].Tag = hCollectionWeightGroupChiyodaVo.StaffCode;
                        SheetViewAggregate.Cells[0, 0].Text = hCollectionWeightGroupChiyodaVo.StaffDisplayName;
                        SheetViewAggregate.Cells[0, 1].Text = hCollectionWeightGroupChiyodaVo.Occupation;
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
            for (int i = 0; i < SheetViewAggregate.RowCount; i++) {
                H_GKI = H_GKI + (int)SheetViewAggregate.Cells[i, 2].Value;
                K_GKI = K_GKI + (int)SheetViewAggregate.Cells[i, 3].Value;
            }
            SheetViewAggregate.ColumnFooter.Cells[0, 2].Text = H_GKI.ToString();
            SheetViewAggregate.ColumnFooter.Cells[0, 3].Text = K_GKI.ToString();
            /*
             * 全ての配車先での出勤日数計算
             */
            for (int i = 0; i < SheetViewAggregate.RowCount; i++) {
                SheetViewAggregate.Cells[i, 4].Value = _hCollectionWeightChiyodaDao.GetWorkingDaysForStaff(HDateTimePickerEx1.GetValue().Date, HDateTimePickerEx2.GetValue().Date, (int)SheetViewAggregate.Cells[i, 0].Tag);
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
            if (sheetView.Rows.Count > 0)
                sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// InitializeSheetViewAggregate
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewAggregate(SheetView sheetView) {
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
            if (sheetView.Rows.Count > 0)
                sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// HDateTimePickerEx1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerEx1_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value > HDateTimePickerEx2.GetValue()) {
                HDateTimePickerEx2.SetValueJp(((DateTimePicker)sender).Value);
            }
        }

        /// <summary>
        /// HDateTimePickerEx2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerEx2_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value < HDateTimePickerEx1.GetValue()) {
                HDateTimePickerEx1.SetValueJp(((DateTimePicker)sender).Value);
            }
            if (((DateTimePicker)sender).Value > DateTime.Now.Date) {
                ((DateTimePicker)sender).Value = DateTime.Now.Date;
            }
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// ToolStripMenuItemPrintA4_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrintA4_Click(object sender, EventArgs e) {
            //アクティブシート印刷します
            SpreadAggregate.PrintSheet(SheetViewAggregate);
        }

        /// <summary>
        /// H_CollectionWeightCHIYODA_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CollectionWeightCHIYODA_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}
