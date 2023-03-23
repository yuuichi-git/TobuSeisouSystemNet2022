/*
 * 2023-03-09
 */
using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using Vo;

namespace WardSpreadsheet {
    public partial class WardTaitou : Form {
        private InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        WardTaitouDao _wardTaitouDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;

        /// <summary>
        /// Key0 → ４月の位置を格納
        /// Key1 → ５月の位置を格納
        /// Key2 → ６月の位置を格納
        /// Key3 → ７月の位置を格納
        /// Key4 → ８月の位置を格納
        /// Key5 → ９月の位置を格納
        /// Key6 → １０月の位置を格納
        /// Key7 → １１月の位置を格納
        /// Key8 → １２月の位置を格納
        /// Key9 → １月の位置を格納(次年度)
        /// Key10 → ２月の位置を格納(次年度)
        /// Key11 → ３月の位置を格納(次年度)
        /// </summary>
        private Dictionary<int, Point> _dictionaryPoint = new Dictionary<int, Point>();
        /// <summary>
        /// 曜日
        /// </summary>
        private Dictionary<int, string> _dictionaryDayOfWeek = new Dictionary<int, string>{ {0,"月" },
                                                                                            {1,"火" },
                                                                                            {2,"水" },
                                                                                            {3,"木" },
                                                                                            {4,"金" },
                                                                                            {5,"土" } };
        /// <summary>
        /// SetCodeが対応するRowの増し分
        /// </summary>
        private Dictionary<int, int> _dictionaryGroup = new Dictionary<int, int>{ {1310602, 0},
                                                                                  {1310603, 1},
                                                                                  {1310604, 3},
                                                                                  {1310606, 5},
                                                                                  {1310607, 5} };
        /// <summary>
        /// 月と_dictionaryPointの紐づけ
        /// </summary>
        private Dictionary<int, int> _dictionaryMonth = new Dictionary<int, int>{ {4, 0},
                                                                                  {5, 1},
                                                                                  {6, 2},
                                                                                  {7, 3},
                                                                                  {8, 4},
                                                                                  {9, 5},
                                                                                  {10, 6},
                                                                                  {11, 7},
                                                                                  {12, 8},
                                                                                  {1, 9},
                                                                                  {2, 10},
                                                                                  {3, 11} };
        public WardTaitou(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _wardTaitouDao = new WardTaitouDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Dictionaryを作成
             * セルの左上の座標を指定
             */
            _dictionaryPoint.Add(0, new Point(2, 1));
            _dictionaryPoint.Add(1, new Point(11, 1));
            _dictionaryPoint.Add(2, new Point(20, 1));
            _dictionaryPoint.Add(3, new Point(29, 1));
            _dictionaryPoint.Add(4, new Point(38, 1));
            _dictionaryPoint.Add(5, new Point(47, 1));
            _dictionaryPoint.Add(6, new Point(2, 11));
            _dictionaryPoint.Add(7, new Point(11, 11));
            _dictionaryPoint.Add(8, new Point(20, 11));
            _dictionaryPoint.Add(9, new Point(29, 11));
            _dictionaryPoint.Add(10, new Point(38, 11));
            _dictionaryPoint.Add(11, new Point(47, 11));
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.WardTaitou(this);
            // 年度設定
            ComboBoxFiscalYear.Text = "２０２２年度";
            // SheetViewを初期化
            InitializeSheetView(SheetViewList);
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // SheetViewを初期化
            InitializeSheetView(SheetViewList);
            /*
             * 1310602 台東資源1
             * 1310603 台東資源2
             * 1310604 台東資源4
             * 1310606 台東資源臨
             * 1310607 台東資源4(2023年度版)
             */
            DateTime targetDateTime = new();
            switch(ComboBoxFiscalYear.Text) {
                case "２０２２年度":
                    targetDateTime = new DateTime(2022, 4, 1);
                    break;
                case "２０２３年度":
                    targetDateTime = new DateTime(2023, 4, 1);
                    break;
            }
            DateTime selectDateTime = targetDateTime;

            // 対象配車先の割当て
            Dictionary<int, int> _dictionaryTargetSetCode = new (){ {0, 1310602}, {1, 1310603}, {2, 1310604}, {3, 1310606}, {4, 1310607} };
            /*
             * １年分のデータ処理
             */
            for(int i = 0; i < 12; i++) {
                /*
                 * １か月分のデータ処理
                 */
                for(int count = 0; count < 5; count++) {
                    OutputSheetView(selectDateTime.Year, selectDateTime.Month, _dictionaryTargetSetCode[count]);
                }
                selectDateTime = selectDateTime.AddMonths(1);
            }
        }

        /// <summary>
        /// OutputSheetView
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="setCode"></param>
        private void OutputSheetView(int year, int month, int setCode) {
            List<WardTaitouVo> listWardTaitouVo = _wardTaitouDao.SelectStaffsVehicleDispatchDetail(year, month, setCode);
            /*
             * 稼働日数を取得
             */
            int operationDays = _wardTaitouDao.SelectOperationDaysVehicleDispatchDetail(year, month, setCode);
            SheetViewList.Cells[_dictionaryPoint[_dictionaryMonth[month]].Row + _dictionaryGroup[setCode], _dictionaryPoint[_dictionaryMonth[month]].Column].Value = operationDays;
            /*
             * 曜日を処理
             * 0 → 月曜日
             * 1 → 火曜日
             * 2 → 水曜日
             * 3 → 木曜日
             * 4 → 金曜日
             * 5 → 土曜日
             */
            for(int i = 0; i < 6; i++) {
                if(listWardTaitouVo.Find(x => x.Day_of_week == _dictionaryDayOfWeek[i]) is not null) { // 組によって値が存在しない曜日があるためNullチェックを入れる
                    int staffCount = listWardTaitouVo.Find(x => x.Day_of_week == _dictionaryDayOfWeek[i]).Operator_code_3;
                    SheetViewList.Cells[_dictionaryPoint[_dictionaryMonth[month]].Row + _dictionaryGroup[setCode], _dictionaryPoint[_dictionaryMonth[month]].Column + 2 + i].Value = staffCount;
                }
            }
        }

        /// <summary>
        /// InitializeSheetView
        /// シートを初期化
        /// </summary>
        private void InitializeSheetView(SheetView sheetView) {
            // Tabを非表示
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            // １２ケ月分繰り返す
            for(int monthCount = 0; monthCount < 12; monthCount++) {
                // ひと月中の行数分繰り返す
                for(int rowNumber = 0; rowNumber < 6; rowNumber++) {
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column].Text = ""; // 配車日数
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 2].Text = ""; // 月曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 3].Text = ""; // 火曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 4].Text = ""; // 水曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 5].Text = ""; // 木曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 6].Text = ""; // 金曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 7].Text = ""; // 土曜日
                }
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //アクティブシート印刷します
            SpreadList.PrintSheet(SheetViewList);
        }

        /// <summary>
        /// ToolStripMenuItemExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExport_Click(object sender, EventArgs e) {
            //xlsx形式ファイルをエクスポートします
            string fileName = string.Concat("台東区資源　配車人数管理表", DateTime.Now.ToString("MM月dd日"), "作成");
            SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
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
        /// WardTaitou_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WardTaitou_FormClosing(object sender, FormClosingEventArgs e) {
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

        /*
         * Dictionaryで使用する値を作成
         */
        private class Point {
            private  int _row;
            private  int _column;
            public Point(int row, int column) {
                _row = row;
                _column = column;
            }
            public int Row {
                get => _row;
                set => _row = value;
            }
            public int Column {
                get => _column;
                set => _column = value;
            }
        }
    }
}
