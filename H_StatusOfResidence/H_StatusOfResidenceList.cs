/*
 * 2024-04-10
 */
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using H_Vo;

using Vo;

namespace H_StatusOfResidence {
    public partial class HStatusOfResidenceList : Form {
        /// <summary>
        /// 従事者名
        /// </summary>
        private const int _colStaffName = 0;
        /// <summary>
        /// 従事者名カナ
        /// </summary>
        private const int _colStaffNameKana = 1;
        /// <summary>
        /// 生年月日
        /// </summary>
        private const int _colBirthDate = 2;
        /// <summary>
        /// 性別
        /// </summary>
        private const int _colGender = 3;
        /// <summary>
        /// 国籍・地域
        /// </summary>
        private const int _colNationality = 4;
        /// <summary>
        /// 住居地
        /// </summary>
        private const int _colAddress = 5;
        /// <summary>
        /// 在留資格
        /// </summary>
        private const int _colStatusOfResidence = 6;
        /// <summary>
        /// 就労制限の有無
        /// </summary>
        private const int _colWorkLimit = 7;
        /// <summary>
        /// 在留期間
        /// </summary>
        private const int _colPeriodDate = 8;
        /// <summary>
        /// 有効期限
        /// </summary>
        private const int _colDeadlineDate = 9;
        /*
         * Dao
         */
        private readonly H_StatusOfResidenceMasterDao _hStatusOfResidenceMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// コンストラクター(新規登録)
        /// </summary>
        /// <param name="connectionVo"></param>
        public HStatusOfResidenceList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStatusOfResidenceMasterDao = new(connectionVo);
            /*
             * Vo 
             */
            _connectionVo = connectionVo;
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
            this.PutSheetViewList(_hStatusOfResidenceMasterDao.SelectAllHStatusOfResidenceMaster());
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        int _spreadListTopRow = 0;
        private void PutSheetViewList(List<H_StatusOfResidenceMasterVo> listHStatusOfResidenceMasterVo) {
            int rowCount = 0;
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            _spreadListTopRow = SpreadList.GetViewportTopRow(0);
            /*
             * Rowを削除する
             */
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            foreach (H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo in listHStatusOfResidenceMasterVo) {
                SheetViewList.Rows.Add(rowCount, 1);
                SheetViewList.RowHeader.Columns[0].Label = (rowCount + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[rowCount].ForeColor = hStatusOfResidenceMasterVo.DeleteFlag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                SheetViewList.Rows[rowCount].Tag = hStatusOfResidenceMasterVo;
                // 従事者名
                SheetViewList.Cells[rowCount, _colStaffName].Text = hStatusOfResidenceMasterVo.StaffName;
                // 従事者名カナ
                SheetViewList.Cells[rowCount, _colStaffNameKana].Text = hStatusOfResidenceMasterVo.StaffNameKana;
                // 生年月日
                SheetViewList.Cells[rowCount, _colBirthDate].Value = hStatusOfResidenceMasterVo.BirthDate;
                // 性別
                SheetViewList.Cells[rowCount, _colGender].Text = hStatusOfResidenceMasterVo.Gender;
                // 国籍・地域
                SheetViewList.Cells[rowCount, _colNationality].Text = hStatusOfResidenceMasterVo.Nationality;
                // 住居地
                SheetViewList.Cells[rowCount, _colAddress].Text = hStatusOfResidenceMasterVo.Address;
                // 在留資格
                SheetViewList.Cells[rowCount, _colStatusOfResidence].Text = hStatusOfResidenceMasterVo.StatusOfResidence;
                // 就労制限の有無
                SheetViewList.Cells[rowCount, _colWorkLimit].Text = hStatusOfResidenceMasterVo.WorkLimit;
                // 在留期間
                SheetViewList.Cells[rowCount, _colPeriodDate].Value = hStatusOfResidenceMasterVo.PeriodDate;
                // 有効期限
                SheetViewList.Cells[rowCount, _colDeadlineDate].Value = hStatusOfResidenceMasterVo.DeadlineDate;
                rowCount++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, _spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", rowCount, " 件");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if (e.ColumnHeader)
                return;
            // Shiftが押された場合
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {

            }
            // 修飾キーが無い場合
            int staffCode = ((H_StatusOfResidenceMasterVo)SheetViewList.Rows[SheetViewList.ActiveRowIndex].Tag).StaffCode;
            H_StatusOfResidenceDetail hStatusOfResidenceDetail = new(_connectionVo, staffCode);
            Rectangle rectangleHStatusOfResidenceDetail = new Desktop().GetMonitorWorkingArea(hStatusOfResidenceDetail, _connectionVo.Screen);
            hStatusOfResidenceDetail.KeyPreview = true;
            hStatusOfResidenceDetail.Location = rectangleHStatusOfResidenceDetail.Location;
            hStatusOfResidenceDetail.Size = new Size(1070, 800);
            hStatusOfResidenceDetail.WindowState = FormWindowState.Normal;
            hStatusOfResidenceDetail.Show(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // 新規レコードを追加する
                case "ToolStripMenuItemNew":
                    H_StatusOfResidenceDetail hStatusOfResidenceDetail = new(_connectionVo);
                    Rectangle rectangleHStatusOfResidenceDetail = new Desktop().GetMonitorWorkingArea(hStatusOfResidenceDetail, _connectionVo.Screen);
                    hStatusOfResidenceDetail.KeyPreview = true;
                    hStatusOfResidenceDetail.Location = rectangleHStatusOfResidenceDetail.Location;
                    hStatusOfResidenceDetail.Size = new Size(1070, 800);
                    hStatusOfResidenceDetail.WindowState = FormWindowState.Normal;
                    hStatusOfResidenceDetail.Show(this);
                    break;
                // 在留カードを削除する
                case "ToolStripMenuItemDelete":
                    DialogResult dialogResult = MessageBox.Show("選択されている在留カード記録を削除します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.OK:
                            int staffCode = ((H_StatusOfResidenceMasterVo)SheetViewList.Rows[SheetViewList.ActiveRowIndex].Tag).StaffCode;
                            try {
                                _hStatusOfResidenceMasterDao.DeleteOneHStatusOfResidenceMaster(staffCode);
                            } catch (Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetView(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 24; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 48; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// HStatusOfResidenceList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStatusOfResidenceList_FormClosing(object sender, FormClosingEventArgs e) {
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
