/*
 * 2024-05-18
 */
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

using H_Common;

using H_Dao;

using H_Vo;

using Vo;

namespace H_Certification {

    public partial class H_CertificationList : Form {
        private readonly H_Common.Date _date = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly Dictionary<int, string> _dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" }, { 99, "指定なし" } };
        private readonly Dictionary<int, string> _dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 99, "" } };
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
        private readonly H_CertificationMasterDao _hCertificationMasterDao;
        private readonly H_CertificationFileDao _hCertificationFileDao;
        private readonly H_ToukanpoTrainingCardDao _hToukanpoTrainingCardDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_CertificationList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hLicenseMasterDao = new(connectionVo);
            _hCertificationMasterDao = new(connectionVo);
            _hCertificationFileDao = new(connectionVo);
            _hToukanpoTrainingCardDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.OutSheetViewList(SheetViewList);
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            /*
             * CertificationCodeが101/102/103/104/238の場合は別処理をする
             */
            if (e.Column > 6 && e.Row > 3 && ((H_CertificationMasterVo)SheetViewList.Cells[1, e.Column].Tag).CertificationCode != 238) {
                /*
                 * TagからVoを取得
                 */
                H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)SheetViewList.Cells[e.Row, 1].Tag;
                H_CertificationMasterVo hCertificationMasterVo = (H_CertificationMasterVo)SheetViewList.Cells[1, e.Column].Tag;
                ToolStripStatusLabelDetail.Text = string.Empty;
                /*
                 * Formを表示する
                 */
                H_CertificationDetail hCertificationDetail = new(_connectionVo, hStaffMasterVo.StaffCode, hCertificationMasterVo.CertificationCode);
                Rectangle rectangleHCertificationDetail = new Desktop().GetMonitorWorkingArea(hCertificationDetail, _connectionVo.Screen);
                hCertificationDetail.KeyPreview = true;
                hCertificationDetail.Location = rectangleHCertificationDetail.Location;
                hCertificationDetail.Size = new Size(1000, 800);
                hCertificationDetail.WindowState = FormWindowState.Normal;
                hCertificationDetail.Show(this);

            } else {
                // 範囲外なので操作を中断する
                e.Cancel = true;
                ToolStripStatusLabelDetail.Text = "ダブルクリックしたセルは範囲外です。";
            }
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        private void InitializeSheetViewList(SheetView sheetView) {
            SpreadList.SuspendLayout(); // Spread 非活性化
            /*
             * 初期値
             */
            sheetView.ColumnCount = 3;
            sheetView.RowCount = 4;
            /*
             * Columnを追加する
             */
            int columnCount = sheetView.Columns.Count;
            foreach (H_CertificationMasterVo hCertificationMasterVo in _hCertificationMasterDao.SelectAllCertificationMaster()) {
                sheetView.Columns.Add(columnCount, 1);
                sheetView.Columns[columnCount].Width = 25;
                /*
                 * 資格コード
                 */
                sheetView.Cells[0, columnCount].Font = new Font("游ゴシック", 8);
                sheetView.Cells[0, columnCount].Text = hCertificationMasterVo.CertificationCode.ToString("###");
                /*
                 * 資格名
                 */
                sheetView.Cells[1, columnCount].Tag = hCertificationMasterVo;
                TextCellType textCellType = new();
                textCellType.TextOrientation = TextOrientation.TextVertical;
                sheetView.Cells[1, columnCount].CellType = textCellType;
                sheetView.Cells[1, columnCount].Font = new Font("游ゴシック", 9);
                sheetView.Cells[1, columnCount].VerticalAlignment = CellVerticalAlignment.Top;
                sheetView.Cells[1, columnCount].Text = hCertificationMasterVo.CertificationDisplayName;
                /*
                 * 取得計画人数
                 */
                sheetView.Cells[2, columnCount].Font = new Font("游ゴシック", 9);
                sheetView.Cells[2, columnCount].Text = hCertificationMasterVo.NumberOfAppointments.ToString("###");

                columnCount++;
            }

            /*
             * Rowを追加する
             */
            int rowCount = sheetView.RowCount;
            foreach (H_StaffMasterVo hStaffMasterVo in _hStaffMasterDao.SelectAllHStaffMaster().FindAll(x => (x.Belongs == 10 ||
                                                                                                              x.Belongs == 11 ||
                                                                                                              x.Belongs == 12 ||
                                                                                                             (x.Belongs == 20 && x.JobForm == 10) ||
                                                                                                             (x.Belongs == 21 && x.JobForm == 10)) &&
                                                                                                              x.RetirementFlag == false).OrderBy(x => x.Belongs).ThenBy(x => x.NameKana)) {
                sheetView.Rows.Add(rowCount, 1);
                sheetView.Rows[rowCount].Height = 20;
                /*
                 * 所属
                 */
                sheetView.Cells[rowCount, 0].Font = new Font("游ゴシック", 8);
                sheetView.Cells[rowCount, 0].Text = _dictionaryBelongs[hStaffMasterVo.Belongs];
                /*
                 * 従事者名
                 */
                sheetView.Cells[rowCount, 1].Tag = hStaffMasterVo;
                sheetView.Cells[rowCount, 1].Font = new Font("游ゴシック", 9);
                sheetView.Cells[rowCount, 1].Text = hStaffMasterVo.DisplayName;
                /*
                 * 年齢
                 */
                sheetView.Cells[rowCount, 2].Text = string.Concat(_date.GetAge(hStaffMasterVo.BirthDate.Date), "歳");

                rowCount++;
            }

            /*
             * 行列の固定
             */
            SheetViewList.FrozenRowCount = 4;
            SheetViewList.FrozenColumnCount = 3;
            SpreadList.ResumeLayout(); // Spread 活性化
        }

        /// <summary>
        /// OutSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        private void OutSheetViewList(SheetView sheetView) {
            List<H_LicenseMasterVo> listHLicenseMasterVo = _hLicenseMasterDao.SelectAllHLicenseMaster();
            List<H_CertificationFileVo> listHCertificationFileVo = _hCertificationFileDao.SelectAllHCertificationFile();
            /*
             * Rowを追加する
             */
            for (int rowCount = 4; rowCount < sheetView.RowCount; rowCount++) {
                /*
                 * 免許区分
                 */
                H_LicenseMasterVo hLicenseMasterVo = listHLicenseMasterVo.Find(x => x.StaffCode == ((H_StaffMasterVo)sheetView.Cells[rowCount, 1].Tag).StaffCode);
                if (hLicenseMasterVo is not null) {
                    // 大型
                    sheetView.Cells[rowCount, 3].ForeColor = Color.Red;
                    sheetView.Cells[rowCount, 3].Font = new Font("Yu Gothic UI", 12);
                    sheetView.Cells[rowCount, 3].HorizontalAlignment = CellHorizontalAlignment.Center;
                    sheetView.Cells[rowCount, 3].Text = hLicenseMasterVo.Large ? "〇" : "";
                    sheetView.Cells[rowCount, 3].VerticalAlignment = CellVerticalAlignment.Center;
                    // 中型
                    sheetView.Cells[rowCount, 4].ForeColor = Color.Red;
                    sheetView.Cells[rowCount, 4].Font = new Font("Yu Gothic UI", 12);
                    sheetView.Cells[rowCount, 4].HorizontalAlignment = CellHorizontalAlignment.Center;
                    sheetView.Cells[rowCount, 4].Text = hLicenseMasterVo.Medium ? "〇" : "";
                    sheetView.Cells[rowCount, 4].VerticalAlignment = CellVerticalAlignment.Center;
                    // 準中型
                    sheetView.Cells[rowCount, 5].ForeColor = Color.Red;
                    sheetView.Cells[rowCount, 5].Font = new Font("Yu Gothic UI", 12);
                    sheetView.Cells[rowCount, 5].HorizontalAlignment = CellHorizontalAlignment.Center;
                    sheetView.Cells[rowCount, 5].Text = hLicenseMasterVo.QuasiMedium ? "〇" : "";
                    sheetView.Cells[rowCount, 5].VerticalAlignment = CellVerticalAlignment.Center;
                    // 普通
                    sheetView.Cells[rowCount, 6].ForeColor = Color.Red;
                    sheetView.Cells[rowCount, 6].Font = new Font("Yu Gothic UI", 12);
                    sheetView.Cells[rowCount, 6].HorizontalAlignment = CellHorizontalAlignment.Center;
                    sheetView.Cells[rowCount, 6].Text = hLicenseMasterVo.Ordinary ? "〇" : "";
                    sheetView.Cells[rowCount, 6].VerticalAlignment = CellVerticalAlignment.Center;
                }
                /*
                 * 資格区分
                 */
                for (int columnCount = 7; columnCount < sheetView.ColumnCount; columnCount++) {
                    /*
                     * 238:作業員業務は、東環保カードの有無で判断する
                     */
                    if (((H_CertificationMasterVo)sheetView.Cells[1, columnCount].Tag).CertificationCode == 238) {
                        /*
                         * 東環保処理
                         */
                        if (_hToukanpoTrainingCardDao.ExistenceHToukanpoTrainingCardMaster(((H_StaffMasterVo)sheetView.Cells[rowCount, 1].Tag).StaffCode)) {
                            sheetView.Cells[rowCount, columnCount].Font = new Font("Yu Gothic UI", 12);
                            sheetView.Cells[rowCount, columnCount].ForeColor = Color.Blue;
                            sheetView.Cells[rowCount, columnCount].HorizontalAlignment = CellHorizontalAlignment.Center;
                            sheetView.Cells[rowCount, columnCount].Text = "〇";
                            sheetView.Cells[rowCount, columnCount].VerticalAlignment = CellVerticalAlignment.Center;
                        } else {

                        }
                    } else {
                        /*
                         * その他処理
                         */
                        H_CertificationFileVo hCertificationFileVo = listHCertificationFileVo.Find(x => x.StaffCode == ((H_StaffMasterVo)sheetView.Cells[rowCount, 1].Tag).StaffCode &&
                                                                                                        x.CertificationCode == ((H_CertificationMasterVo)sheetView.Cells[1, columnCount].Tag).CertificationCode);
                        if (hCertificationFileVo is not null) {
                            sheetView.Cells[rowCount, columnCount].Font = new Font("Yu Gothic UI", 12);
                            sheetView.Cells[rowCount, columnCount].ForeColor = Color.Blue;
                            sheetView.Cells[rowCount, columnCount].HorizontalAlignment = CellHorizontalAlignment.Center;
                            sheetView.Cells[rowCount, columnCount].Text = "〇";
                            sheetView.Cells[rowCount, columnCount].VerticalAlignment = CellVerticalAlignment.Center;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * アプリケーションを終了する
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// H_CertificationList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CertificationList_FormClosing(object sender, FormClosingEventArgs e) {
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
