/*
 * 2024-04-23
 */
using FarPoint.Win.Spread;

using H_Dao;

using H_Vo;

using Vo;

namespace H_CollectionWeight {
    public partial class H_CollectionWeightTAITOUDetail : Form {
        /*
         * Dao
         */
        private readonly H_CollectionWeightTaitouDao _hCollectionWeightTaitouDao;

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
        /// SetCodeが対応するRowの増し分
        /// </summary>
        private Dictionary<int, int> _dictionaryGroup = new Dictionary<int, int>{ {1310602, 0},
                                                                                  {1310603, 1},
                                                                                  {1310607, 3},
                                                                                  {1310606, 5}};
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

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_CollectionWeightTAITOUDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCollectionWeightTaitouDao = new(connectionVo);
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
             * InitializeControl 
             */
            InitializeComponent();
            this.InitializeSheetView(SheetViewList);
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            // SheetViewを初期化
            InitializeSheetView(SheetViewList);

            DateTime selectDateTime = new DateTime((int)HNumericUpDownExYear.Value, 4, 1);
            /*
             * 対象配車先の割当て
             * 1310602　１組
             * 1310603　２組
             * 1310607　４組
             * 1310606　臨時
             */
            Dictionary<int, int> _dictionaryTargetSetCode = new() { { 0, 1310602 }, { 1, 1310603 }, { 2, 1310607 }, { 3, 1310606 } };
            /*
             * １年分のデータ処理
             */
            for (int i = 0; i < 12; i++) {
                /*
                 * １か月分のデータ処理
                 */
                for (int count = 0; count < 4; count++) {
                    PutSheetViewList(selectDateTime.Year, selectDateTime.Month, _dictionaryTargetSetCode[count]);
                }
                selectDateTime = selectDateTime.AddMonths(1);
            }
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="setCode"></param>
        private void PutSheetViewList(int year, int month, int setCode) {
            /*
             * 稼働日数を取得
             */
            int operationDays = _hCollectionWeightTaitouDao.GetOperationDaysVehicleDispatchDetail(year, month, setCode);
            SheetViewList.Cells[_dictionaryPoint[_dictionaryMonth[month]].Row + _dictionaryGroup[setCode], _dictionaryPoint[_dictionaryMonth[month]].Column].Value = operationDays;
            /*
             * 曜日別人工数(３人目)を取得
             */
            List<H_CollectionWeightTAITOUDetailVo> listHCollectionWeightTAITOUDetailVo = _hCollectionWeightTaitouDao.GetStaffsVehicleDispatchDetail(year, month, setCode);
            foreach (H_CollectionWeightTAITOUDetailVo hCollectionWeightTAITOUDetailVo in listHCollectionWeightTAITOUDetailVo) {
                int oldNumber = (int)SheetViewList.Cells[_dictionaryPoint[_dictionaryMonth[month]].Row + _dictionaryGroup[setCode], _dictionaryPoint[_dictionaryMonth[month]].Column + hCollectionWeightTAITOUDetailVo.OperationWeekDay].Value;
                SheetViewList.Cells[_dictionaryPoint[_dictionaryMonth[month]].Row + _dictionaryGroup[setCode], _dictionaryPoint[_dictionaryMonth[month]].Column + hCollectionWeightTAITOUDetailVo.OperationWeekDay].Value = oldNumber + 1;
            }
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
                    //アクティブシート印刷します
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
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
            for (int monthCount = 0; monthCount < 12; monthCount++) {
                // ひと月中の行数分繰り返す
                for (int rowNumber = 0; rowNumber < 6; rowNumber++) {
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column].Value = 0; // 配車日数
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 2].Value = 0; // 月曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 3].Value = 0; // 火曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 4].Value = 0; // 水曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 5].Value = 0; // 木曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 6].Value = 0; // 金曜日
                    sheetView.Cells[_dictionaryPoint[monthCount].Row + rowNumber, _dictionaryPoint[monthCount].Column + 7].Value = 0; // 土曜日
                }
            }
        }

        ///*
        // * Dictionaryで使用する値を作成
        // */
        private class Point {
            private int _row;
            private int _column;
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

        /// <summary>
        /// H_CollectionWeightTAITOUDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CollectionWeightTAITOUDetail_FormClosing(object sender, FormClosingEventArgs e) {
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
