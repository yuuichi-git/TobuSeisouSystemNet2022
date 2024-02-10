/*
 * 2024-02-03
 */
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using H_Vo;

namespace H_Staff {
    public partial class HStaffList : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };
        private readonly Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 12, "アルバイト" }, { 99, "" } };
        private readonly Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "運転手" }, { 11, "作業員" }, { 20, "事務職" }, { 99, "" } };
        private readonly Date _date = new();
        private List<H_StaffMasterVo>? _listStaffMasterVo = null;
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_ToukanpoTrainingCardDao _hToukanpoTrainingCardDao;
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
        private readonly H_StaffProperDao _hStaffProperDao;
        private readonly H_StaffMedicalExaminationDao _hStaffMedicalExaminationDao;
        private readonly H_CarAccidentMasterDao _hCarAccidentMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * SPREADのColumnの番号
         */
        /// <summary>
        /// 所属
        /// </summary>
        private const int colBelongs = 0;
        /// <summary>
        /// 形態
        /// </summary>
        private const int colJobForm = 1;
        /// <summary>
        /// 職種
        /// </summary>
        private const int colOccupation = 2;
        /// <summary>
        /// 配車の対象かどうか
        /// </summary>
        private const int colVehicleDispatchTarget = 3;
        /// <summary>
        /// <summary>
        /// 社員CD
        /// </summary>
        private const int colCode = 4;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colName = 5;
        /// <summary>
        /// カナ
        /// </summary>
        private const int colNameKana = 6;
        /// <summary>
        /// 生年月日
        /// </summary>
        private const int colBirthDate = 7;
        /// <summary>
        /// 年齢
        /// </summary>
        private const int colFullAge = 8;
        /// <summary>
        /// 雇用年月日
        /// </summary>
        private const int colEmploymentDate = 9;
        /// <summary>
        /// 勤続年数
        /// </summary>
        private const int colServiceDate = 10;
        /// <summary>
        /// 東環保
        /// </summary>
        private const int colToukanpoCard = 11;
        /// <summary>
        /// 免許証期限
        /// </summary>
        private const int colLicensExpirationDate = 12;
        /// <summary>
        /// 初任
        /// </summary>
        private const int colFirstTerm = 13;
        /// <summary>
        /// 適齢
        /// </summary>
        private const int colSuitableAge = 14;
        /// <summary>
        /// 事故件数
        /// </summary>
        private const int colCarAccidentCount = 15;
        /// <summary>
        /// １年以内の健康診断
        /// </summary>
        private const int colMedicalExaminationDate = 16;
        /// <summary>
        /// 現住所
        /// </summary>
        private const int colCurrentAddress = 17;
        /// <summary>
        /// 健康保険
        /// </summary>
        private const int colHealthInsuranceNumber = 18;
        /// <summary>
        /// 厚生年金
        /// </summary>
        private const int colWelfarePensionNumber = 19;
        /// <summary>
        /// 雇用保険
        /// </summary>
        private const int colEmploymentInsuranceNumber = 20;
        /// <summary>
        /// 労災保険
        /// </summary>
        private const int colWorkerAccidentInsuranceNumber = 21;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public HStaffList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hToukanpoTrainingCardDao = new(connectionVo);
            _hLicenseMasterDao = new(connectionVo);
            _hStaffProperDao = new(connectionVo);
            _hStaffMedicalExaminationDao = new(connectionVo);
            _hCarAccidentMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            /*
             * FpSpread/Viewを初期化
             */
            InitializeSheetViewList(SheetViewList);
            /*
             * ToolStripStatusLabelDetail
             */
            ToolStripStatusLabelDetail.Text = "";
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
        /// Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e) {
            switch (((Button)sender).Name) {
                case "ButtonUpdate":
                    _listStaffMasterVo = _hStaffMasterDao.SelectHStaffMasterForStaffList();
                    this.SheetViewListOutPut();
                    break;
            }
        }

        /// <summary>
        /// HTabControlExKANA_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HTabControlExKANA_Click(object sender, EventArgs e) {
            if (_listStaffMasterVo != null) {
                switch (SpreadList.ActiveSheet.SheetName) {
                    case "従事者リスト":
                        this.SheetViewListOutPut();
                        break;
                }
            }
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int spreadListTopRow = 0;
        private void SheetViewListOutPut() {
            int rowCount = 0;
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            List<H_StaffMasterVo>? findListStaffMasterVo = HTabControlExKANA.SelectedTab.Text switch {
                "ア" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("ア") || x.NameKana.StartsWith("イ") || x.NameKana.StartsWith("ウ") || x.NameKana.StartsWith("エ") || x.NameKana.StartsWith("オ")),
                "カ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("カ") || x.NameKana.StartsWith("ガ") || x.NameKana.StartsWith("キ") || x.NameKana.StartsWith("ギ") || x.NameKana.StartsWith("ク") || x.NameKana.StartsWith("グ") || x.NameKana.StartsWith("ケ") || x.NameKana.StartsWith("ゲ") || x.NameKana.StartsWith("コ") || x.NameKana.StartsWith("ゴ")),
                "サ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("サ") || x.NameKana.StartsWith("シ") || x.NameKana.StartsWith("ス") || x.NameKana.StartsWith("セ") || x.NameKana.StartsWith("ソ")),
                "タ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("タ") || x.NameKana.StartsWith("ダ") || x.NameKana.StartsWith("チ") || x.NameKana.StartsWith("ツ") || x.NameKana.StartsWith("テ") || x.NameKana.StartsWith("デ") || x.NameKana.StartsWith("ト") || x.NameKana.StartsWith("ド")),
                "ナ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("ナ") || x.NameKana.StartsWith("ニ") || x.NameKana.StartsWith("ヌ") || x.NameKana.StartsWith("ネ") || x.NameKana.StartsWith("ノ")),
                "ハ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("ハ") || x.NameKana.StartsWith("パ") || x.NameKana.StartsWith("ヒ") || x.NameKana.StartsWith("ビ") || x.NameKana.StartsWith("フ") || x.NameKana.StartsWith("ブ") || x.NameKana.StartsWith("ヘ") || x.NameKana.StartsWith("ベ") || x.NameKana.StartsWith("ホ")),
                "マ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("マ") || x.NameKana.StartsWith("ミ") || x.NameKana.StartsWith("ム") || x.NameKana.StartsWith("メ") || x.NameKana.StartsWith("モ")),
                "ヤ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("ヤ") || x.NameKana.StartsWith("ユ") || x.NameKana.StartsWith("ヨ")),
                "ラ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("ラ") || x.NameKana.StartsWith("リ") || x.NameKana.StartsWith("ル") || x.NameKana.StartsWith("レ") || x.NameKana.StartsWith("ロ")),
                "ワ" => _listStaffMasterVo?.FindAll(x => x.NameKana.StartsWith("ワ") || x.NameKana.StartsWith("ヲ") || x.NameKana.StartsWith("ン")),
                _ => _listStaffMasterVo,
            };
            // 退職者
            if (!CheckBoxRetired.Checked)
                findListStaffMasterVo = findListStaffMasterVo?.FindAll(x => x.RetirementFlag != true);
            if (findListStaffMasterVo is not null) {
                foreach (H_StaffMasterVo hStaffMasterVo in findListStaffMasterVo) {
                    SheetViewList.Rows.Add(rowCount, 1);
                    SheetViewList.RowHeader.Columns[0].Label = (rowCount + 1).ToString(); // Rowヘッダ
                    SheetViewList.Rows[rowCount].ForeColor = hStaffMasterVo.RetirementFlag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                    SheetViewList.Rows[rowCount].Height = 22; // Rowの高さ
                    SheetViewList.Rows[rowCount].Resizable = false; // RowのResizableを禁止
                    SheetViewList.Cells[rowCount, colName].Tag = hStaffMasterVo;
                    // 所属
                    SheetViewList.Cells[rowCount, colBelongs].Value = dictionaryBelongs[hStaffMasterVo.Belongs];
                    // 雇用形態
                    SheetViewList.Cells[rowCount, colJobForm].Value = dictionaryJobForm[hStaffMasterVo.JobForm];
                    // 職種
                    SheetViewList.Cells[rowCount, colOccupation].Value = dictionaryOccupation[hStaffMasterVo.Occupation];
                    // 配車の対象かどうか
                    SheetViewList.Cells[rowCount, colVehicleDispatchTarget].Value = hStaffMasterVo.VehicleDispatchTarget;
                    // 組合コード
                    SheetViewList.Cells[rowCount, colCode].Value = hStaffMasterVo.UnionCode;
                    // 名前
                    SheetViewList.Cells[rowCount, colName].Text = hStaffMasterVo.Name;
                    // カナ
                    SheetViewList.Cells[rowCount, colNameKana].Text = hStaffMasterVo.NameKana;
                    // 生年月日
                    SheetViewList.Cells[rowCount, colBirthDate].Value = _date.GetBirthday(hStaffMasterVo.BirthDate);
                    // 年齢
                    SheetViewList.Cells[rowCount, colFullAge].Value = string.Concat(_date.GetAge(hStaffMasterVo.BirthDate.Date), "歳");
                    // 雇用年月日
                    SheetViewList.Cells[rowCount, colEmploymentDate].Value = _date.GetEmploymentDate(hStaffMasterVo.EmploymentDate.Date);
                    // 勤続年数
                    SheetViewList.Cells[rowCount, colServiceDate].Value = string.Concat(_date.GetEmploymenteYear(hStaffMasterVo.EmploymentDate.Date).ToString("#0年"), _date.GetEmploymenteMonth(hStaffMasterVo.EmploymentDate.Date).ToString("00月"));
                    // 東環保研修カード
                    SheetViewList.Cells[rowCount, colToukanpoCard].Value = _hToukanpoTrainingCardDao.ExistenceToukanpoTrainingCard(hStaffMasterVo.StaffCode);
                    // 免許証期限
                    SheetViewList.Cells[rowCount, colLicensExpirationDate].Value = _hLicenseMasterDao.GetExpirationDate(hStaffMasterVo.StaffCode);
                   　// 初任診断
                    SheetViewList.Cells[rowCount, colFirstTerm].Value = _hStaffProperDao.GetSyoninProperDate(hStaffMasterVo.StaffCode);
                    // 適齢診断の残日数
                    SheetViewList.Cells[rowCount, colSuitableAge].Value = _hStaffProperDao.GetTekireiProperDate(hStaffMasterVo.StaffCode);
                    // 年度内事故回数
                    SheetViewList.Cells[rowCount, colCarAccidentCount].Value = _hCarAccidentMasterDao.GetHCarAccidentCount(hStaffMasterVo.StaffCode);
                    /*
                     * 1年以内の健康診断
                     */
                    string medicalExaminationDate = _hStaffMedicalExaminationDao.GetMedicalExaminationDate(hStaffMasterVo.StaffCode);
                    if (medicalExaminationDate != string.Empty) {
                        SheetViewList.Cells[rowCount, colMedicalExaminationDate].Value = string.Concat("受診日(", medicalExaminationDate, ")");
                    } else {
                        SheetViewList.Cells[rowCount, colMedicalExaminationDate].Value = "健康診断の記録無し";
                    }
                    // 現住所
                    SheetViewList.Cells[rowCount, colCurrentAddress].Value = hStaffMasterVo.CurrentAddress;
                    // 健康保険加入
                    SheetViewList.Cells[rowCount, colHealthInsuranceNumber].Value = hStaffMasterVo.HealthInsuranceDate != _defaultDateTime ? true : false;
                    // 厚生年金加入
                    SheetViewList.Cells[rowCount, colWelfarePensionNumber].Value = hStaffMasterVo.WelfarePensionDate != _defaultDateTime ? true : false;
                    // 雇用保険加入
                    SheetViewList.Cells[rowCount, colEmploymentInsuranceNumber].Value = hStaffMasterVo.EmploymentInsuranceDate != _defaultDateTime ? true : false;
                    // 労災保険
                    SheetViewList.Cells[rowCount, colWorkerAccidentInsuranceNumber].Value = hStaffMasterVo.WorkerAccidentInsuranceDate != _defaultDateTime ? true : false;
                    rowCount++;
                }
            }
            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", rowCount, " 件");
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
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
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ダブルクリックされたのが従事者リストで無ければReturnする
            if (((FpSpread)sender).ActiveSheet.SheetName != "従事者リスト")
                return;
            // ヘッダーのDoubleClickを回避
            if (e.ColumnHeader)
                return;
            // Shiftが押された場合
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                //var staffRegisterPaper = new StaffPaper(_connectionVo, ((ExtendsStaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).Staff_code);
                //staffRegisterPaper.ShowDialog();
                return;
            }
            // 修飾キーが無い場合
            HStaffDetail hStaffDetail = new(_connectionVo, ((H_StaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).StaffCode);
            Rectangle rectangleHStaffDetail = new Desktop().GetMonitorWorkingArea(hStaffDetail, _connectionVo.Screen);
            hStaffDetail.KeyPreview = true;
            hStaffDetail.Location = rectangleHStaffDetail.Location;
            hStaffDetail.Size = new Size(1920, 1080);
            hStaffDetail.WindowState = FormWindowState.Normal;
            hStaffDetail.ShowDialog();
        }

        /// <summary>
        /// H_StaffList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_StaffList_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
