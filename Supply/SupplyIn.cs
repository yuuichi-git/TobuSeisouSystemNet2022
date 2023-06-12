using Common;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyIn : Form {
        private InitializeForm _initializeForm = new();
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 1 },
                                                                                                             { "雇上での備品", 2 },
                                                                                                             { "産廃での備品", 3 },
                                                                                                             { "水物での備品", 4 } };
        /*
         * Dao
         */

        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public SupplyIn(ConnectionVo connectionVo, string division) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            /*
             * Control初期化
             */
            InitializeComponent();
            MonthPicker1.Value = DateTime.Now.Date;
            ComboBoxSupplyType.Text = division;
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

        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        private void InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 10); // 行ヘッダのFont
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
        }
    }
}
