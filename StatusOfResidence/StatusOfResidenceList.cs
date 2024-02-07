/*
 * 2023-06-23
 */
using Common;

using Dao;

using FarPoint.Win.Spread;

using H_Vo;

namespace StatusOfResidence {
    public partial class StatusOfResidenceList : Form {
        private InitializeForm _initializeForm = new();
        private DateTime _defaultDateTime = new DateTime(1900,01,01,00,00,00);
        /*
         * Dao
         */
        private readonly StatusOfResidenceDao _statusOfResidenceDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        // SPREADのColumnの番号
        /// <summary>
        /// 従事者名
        /// </summary>
        private const int colStaffName = 0;
        /// <summary>
        /// 従事者名カナ
        /// </summary>
        private const int colStaffNameKana = 1;
        /// <summary>
        /// 生年月日
        /// </summary>
        private const int colBirthDate = 2;
        /// <summary>
        /// 性別
        /// </summary>
        private const int colGender = 3;
        /// <summary>
        /// 国籍・地域
        /// </summary>
        private const int colNationality = 4;
        /// <summary>
        /// 住居地
        /// </summary>
        private const int colAddress = 5;
        /// <summary>
        /// 在留資格
        /// </summary>
        private const int colStatusOfResidence = 6;
        /// <summary>
        /// 就労制限の有無
        /// </summary>
        private const int colWorkLimit = 7;
        /// <summary>
        /// 在留期間
        /// </summary>
        private const int colPeriodDate = 8;
        /// <summary>
        /// 有効期限
        /// </summary>
        private const int colDeadlineDate = 9;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public StatusOfResidenceList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _statusOfResidenceDao = new StatusOfResidenceDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.StatusOfResidenceList(this);
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
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(StatusOfResidenceVo statusOfResidenceVo in _statusOfResidenceDao.SelectAllStatusOfResidenceMaster()) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止

                SheetViewList.Rows[i].ForeColor = statusOfResidenceVo.Delete_flag ? Color.Red : Color.Black; // 削除済は赤色で表示する
                SheetViewList.Cells[i, colStaffName].Tag = statusOfResidenceVo;
                SheetViewList.Cells[i, colStaffName].Text = statusOfResidenceVo.Staff_name;
                SheetViewList.Cells[i, colStaffNameKana].Text = statusOfResidenceVo.Staff_name_kana;
                SheetViewList.Cells[i, colBirthDate].Value = statusOfResidenceVo.Birth_date;
                SheetViewList.Cells[i, colGender].Text = statusOfResidenceVo.Gender;
                SheetViewList.Cells[i, colNationality].Text = statusOfResidenceVo.Nationality;
                SheetViewList.Cells[i, colAddress].Text = statusOfResidenceVo.Address;
                SheetViewList.Cells[i, colStatusOfResidence].Text = statusOfResidenceVo.Status_of_residence;
                SheetViewList.Cells[i, colWorkLimit].Text = statusOfResidenceVo.Work_limit;
                if(statusOfResidenceVo.Period_date != _defaultDateTime)
                    SheetViewList.Cells[i, colPeriodDate].Value = statusOfResidenceVo.Period_date;
                if(statusOfResidenceVo.Deadline_date != _defaultDateTime)
                    SheetViewList.Cells[i, colDeadlineDate].Value = statusOfResidenceVo.Deadline_date;
                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if(e.ColumnHeader)
                return;
            // 修飾キーが無い場合
            StatusOfResidenceInsUp statusOfResidenceNew = new StatusOfResidenceInsUp(_connectionVo, ((StatusOfResidenceVo)SheetViewList.Cells[e.Row, colStaffName].Tag).Staff_code);
            statusOfResidenceNew.ShowDialog(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemNew":
                    StatusOfResidenceInsUp statusOfResidenceNew = new StatusOfResidenceInsUp(_connectionVo);
                    statusOfResidenceNew.ShowDialog(this);
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // シートタブを非表示にする
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

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// StatusOfResidenceList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusOfResidenceList_FormClosing(object sender, FormClosingEventArgs e) {
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