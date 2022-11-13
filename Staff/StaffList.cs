using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Staff {
    public partial class StaffList : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<StaffMasterVo> _listFindAllStaffMasterVo;
        private IOrderedEnumerable<StaffMasterVo> _linqStaffMasterVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 20, "新運転" }, { 21, "自運労" } };
        Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 12, "アルバイト" }, { 99, "" } };
        Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "運転手" }, { 11, "作業員" }, { 99, "" } };

        // SPREADのColumnの番号
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
        private const int colStaffCode = 4;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colName = 5;
        /// <summary>
        /// カナ
        /// </summary>
        private const int colNameKana = 6;
        /// <summary>
        /// 東環保
        /// </summary>
        private const int colToukanpoCard = 7;
        /// <summary>
        /// 免許証
        /// </summary>
        private const int colLicense = 8;
        /// <summary>
        /// 免許証期限
        /// </summary>
        private const int colLicensExpirationDate = 9;
        /// <summary>
        /// 通勤届
        /// </summary>
        private const int colCommutingNotification = 10;
        /// <summary>
        /// 任意保険終了年月日
        /// </summary>
        private const int colMeansOfCommutingEndDate = 11;
        /// <summary>
        /// 生年月日
        /// </summary>
        private const int colBirthDate = 12;
        /// <summary>
        /// 年齢
        /// </summary>
        private const int colFullAge = 13;
        /// <summary>
        /// 雇用年月日
        /// </summary>
        private const int colEmploymentDate = 14;
        /// <summary>
        /// 勤続年数
        /// </summary>
        private const int colServiceDate = 15;
        /// <summary>
        /// 初任
        /// </summary>
        private const int colFirstTerm = 16;
        /// <summary>
        /// 適齢
        /// </summary>
        private const int colSuitableAge = 17;
        /// <summary>
        /// 事故件数
        /// </summary>
        private const int colCarAccidentCount = 18;
        /// <summary>
        /// １年以内の健康診断
        /// </summary>
        private const int colMedicalExaminationDate = 19;
        /// <summary>
        /// 現住所
        /// </summary>
        private const int colCurrentAddress = 20;
        /// <summary>
        /// 健康保険
        /// </summary>
        private const int colHealthInsuranceNumber = 21;
        /// <summary>
        /// 厚生年金
        /// </summary>
        private const int colWelfarePensionNumber = 22;
        /// <summary>
        /// 雇用保険
        /// </summary>
        private const int colEmploymentInsuranceNumber = 23;
        /// <summary>
        /// 労災保険
        /// </summary>
        private const int colWorkerAccidentInsuranceNumber = 24;

        public StaffList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.StaffList(this);

            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listFindAllStaffMasterVo = null;
            _linqStaffMasterVo = null;

            // 事故件数集計の基準となる年度を初期化
            ComboBoxAccidentYear.Text = "2022年度";
            // FpSpreadを初期化
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = "";
        }

        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            SheetViewListOutPut();
        }

        /// <summary>
        /// TabControlEx1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlEx1_Click(object sender, EventArgs e) {
            if (_listFindAllStaffMasterVo != null)
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
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            _listFindAllStaffMasterVo = TabControlExStaff.SelectedTab.Tag switch {
                "ア" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("ア") || x.Name_kana.StartsWith("イ") || x.Name_kana.StartsWith("ウ") || x.Name_kana.StartsWith("エ") || x.Name_kana.StartsWith("オ")),
                "カ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("カ") || x.Name_kana.StartsWith("ガ") || x.Name_kana.StartsWith("キ") || x.Name_kana.StartsWith("ギ") || x.Name_kana.StartsWith("ク") || x.Name_kana.StartsWith("ケ") || x.Name_kana.StartsWith("コ") || x.Name_kana.StartsWith("ゴ")),
                "サ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("サ") || x.Name_kana.StartsWith("シ") || x.Name_kana.StartsWith("ス") || x.Name_kana.StartsWith("セ") || x.Name_kana.StartsWith("ソ")),
                "タ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("タ") || x.Name_kana.StartsWith("チ") || x.Name_kana.StartsWith("ツ") || x.Name_kana.StartsWith("テ") || x.Name_kana.StartsWith("デ") || x.Name_kana.StartsWith("ト") || x.Name_kana.StartsWith("ド")),
                "ナ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("ナ") || x.Name_kana.StartsWith("ニ") || x.Name_kana.StartsWith("ヌ") || x.Name_kana.StartsWith("ネ") || x.Name_kana.StartsWith("ノ")),
                "ハ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("ハ") || x.Name_kana.StartsWith("パ") || x.Name_kana.StartsWith("ヒ") || x.Name_kana.StartsWith("ビ") || x.Name_kana.StartsWith("フ") || x.Name_kana.StartsWith("ブ") || x.Name_kana.StartsWith("ヘ") || x.Name_kana.StartsWith("ベ") || x.Name_kana.StartsWith("ホ")),
                "マ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("マ") || x.Name_kana.StartsWith("ミ") || x.Name_kana.StartsWith("ム") || x.Name_kana.StartsWith("メ") || x.Name_kana.StartsWith("モ")),
                "ヤ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("ヤ") || x.Name_kana.StartsWith("ユ") || x.Name_kana.StartsWith("ヨ")),
                "ラ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("ラ") || x.Name_kana.StartsWith("リ") || x.Name_kana.StartsWith("ル") || x.Name_kana.StartsWith("レ") || x.Name_kana.StartsWith("ロ")),
                "ワ" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("ワ") || x.Name_kana.StartsWith("ヲ") || x.Name_kana.StartsWith("ン")),
                _ => _listStaffMasterVo,
            };

            // 役員
            if (!CheckBoxOfficer.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 10);
            // 社員
            if (!CheckBoxCompanyEmployee.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 11);
            // アルバイト
            if (!CheckBoxPartTimeJob.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 12);
            // 新運転
            if (!CheckBoxSinunten.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 20);
            // 自運労
            if (!CheckBoxJiunrou.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 21);
            // 長期
            if (!CheckBoxFullTimeJob.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 10);
            // 手帳
            if (!CheckBoxNoteBook.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 11);
            // アルバイト
            if (!CheckBoxPartTime.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 12);
            // 運転手
            if (!CheckBoxDriver.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Occupation != 10);
            // 作業員
            if (!CheckBoxWorkStaff.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Occupation != 11);
            // 指定なし
            if (!CheckBoxNone.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Occupation != 99);
            // 退職者
            if (!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Retirement_flag != true);
            // ソート
            _linqStaffMasterVo = _listFindAllStaffMasterVo.OrderBy(x => x.Name_kana);

            int i = 0;
            foreach (var staffMasterVo in _linqStaffMasterVo) {
                // 所属
                var _belongs = staffMasterVo.Belongs;
                // 形態
                var _jobForm = staffMasterVo.Job_form;
                // 職種
                var _occupation = staffMasterVo.Occupation;
                // 配車対象
                var _vehicleDispatchTarget = staffMasterVo.Vehicle_dispatch_target;
                // 組合CD
                var _code = staffMasterVo.Code;
                // 氏名
                var _name = staffMasterVo.Name;
                // カナ
                var _name_kana = staffMasterVo.Name_kana;
                // 生年月日・年齢
                DateTime? _birth_date = null;
                string _age = "";
                if (staffMasterVo.Birth_date != _defaultDateTime) {
                    _birth_date = staffMasterVo.Birth_date.Date;
                    // 年齢
                    _age = string.Concat(new Date().GetStaffAge(staffMasterVo.Birth_date.Date), "歳");
                }
                // 雇用年月日
                DateTime? _employment_date = null;
                if (staffMasterVo.Employment_date != _defaultDateTime) {
                    _employment_date = staffMasterVo.Employment_date.Date;
                }
                // 勤続
                string _service_date = "";
                if (staffMasterVo.Employment_date != _defaultDateTime) {
                    _service_date = string.Concat(new Date().GetEmploymenteYear(staffMasterVo.Employment_date.Date).ToString("#0年"), new Date().GetEmploymenteMonth(staffMasterVo.Employment_date.Date).ToString("00月"));
                }
                // 初任
                string _proper_kind_syonin = "";
                if (staffMasterVo.Proper_kind_1 == "初任診断" || staffMasterVo.Proper_kind_2 == "初任診断" || staffMasterVo.Proper_kind_3 == "初任診断")
                    _proper_kind_syonin = "〇";
                // 適齢
                string _proper_kind_tekirei = "";
                var timeSpan = new TimeSpan(0, 0, 0, 0);

                if (staffMasterVo.Proper_kind_1 == "適齢診断" || staffMasterVo.Proper_kind_2 == "適齢診断" || staffMasterVo.Proper_kind_3 == "適齢診断") {
                    if (staffMasterVo.Proper_kind_1 == "適齢診断") {
                        timeSpan = staffMasterVo.Proper_date_1.AddYears(3) - DateTime.Now.Date;
                    } else if (staffMasterVo.Proper_kind_2 == "適齢診断") {
                        timeSpan = staffMasterVo.Proper_date_2.AddYears(3) - DateTime.Now.Date;
                    } else if (staffMasterVo.Proper_kind_3 == "適齢診断") {
                        timeSpan = staffMasterVo.Proper_date_3.AddYears(3) - DateTime.Now.Date;
                    }
                    _proper_kind_tekirei = string.Concat(timeSpan.Days, "日後");
                }
                // 現住所
                var _current_address = staffMasterVo.Current_address;
                // 健康保険
                var _health_insurance_number = staffMasterVo.Health_insurance_number == "" ? null : "〇";
                // 厚生年金  
                var _welfare_pension_number = staffMasterVo.Welfare_pension_number == "" ? null : "〇";
                // 雇用保険   
                var _employment_insurance_number = staffMasterVo.Employment_insurance_number == "" ? null : "〇";
                // 労災保険   
                var _worker_accident_insurance_number = staffMasterVo.Worker_accident_insurance_number == "" ? null : "〇";

                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].ForeColor = staffMasterVo.Retirement_flag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                SheetViewList.Cells[i, colBelongs].Value = dictionaryBelongs[_belongs];
                SheetViewList.Cells[i, colJobForm].Value = dictionaryJobForm[_jobForm];
                SheetViewList.Cells[i, colOccupation].Value = dictionaryOccupation[_occupation];
                SheetViewList.Cells[i, colVehicleDispatchTarget].Value = _vehicleDispatchTarget;
                SheetViewList.Cells[i, colStaffCode].Value = _code;
                SheetViewList.Cells[i, colName].Text = _name;
                SheetViewList.Cells[i, colNameKana].Text = _name_kana;
                SheetViewList.Cells[i, colBirthDate].Value = _birth_date;
                SheetViewList.Cells[i, colFullAge].Value = _age;
                SheetViewList.Cells[i, colEmploymentDate].Value = _employment_date;
                SheetViewList.Cells[i, colServiceDate].Value = _service_date;
                SheetViewList.Cells[i, colFirstTerm].Value = _proper_kind_syonin;
                SheetViewList.Cells[i, colSuitableAge].Value = _proper_kind_tekirei;
                SheetViewList.Cells[i, colCurrentAddress].Value = _current_address;
                SheetViewList.Cells[i, colHealthInsuranceNumber].Value = _health_insurance_number;
                SheetViewList.Cells[i, colWelfarePensionNumber].Value = _welfare_pension_number;
                SheetViewList.Cells[i, colEmploymentInsuranceNumber].Value = _employment_insurance_number;
                SheetViewList.Cells[i, colWorkerAccidentInsuranceNumber].Value = _worker_accident_insurance_number;
                i++;
            }
            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
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

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// StaffList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffList_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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