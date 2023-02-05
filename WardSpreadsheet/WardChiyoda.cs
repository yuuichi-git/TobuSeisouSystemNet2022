using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace WardSpreadsheet {
    public partial class WardChiyoda : Form {
        /*
         * Dao
         */
        private WardSpreadSheetDao _wardSpreadSheetDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        List<WardChiyodaVo> _listWardChiyodaVo;

        public WardChiyoda(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _wardSpreadSheetDao = new WardSpreadSheetDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _listWardChiyodaVo = new();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            InitializeSheetViewList(SheetViewList);
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
            _listWardChiyodaVo = _wardSpreadSheetDao.SelectAllVehicleDispatchDetail(DateTimePicker1.Value, DateTimePicker2.Value);
            SheetViewListOutPut();
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int spreadListTopRow = 0;
        private void SheetViewListOutPut() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(WardChiyodaVo wardChiyodaVo in _listWardChiyodaVo) {


                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelStatus.Text = string.Concat(" ", i, " 件");
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
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }
    }
}