using System.ComponentModel;

using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using Vo;

using License;

using Toukanpo;

namespace Staff {
    public partial class StaffList : Form {
        private InitializeForm _initializeForm = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };
        private readonly Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 12, "アルバイト" }, { 99, "" } };
        private readonly Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "運転手" }, { 11, "作業員" }, { 99, "" } };
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private List<ExtendsStaffMasterVo>? _listExtendsStaffMasterVo;
        private List<ExtendsStaffMasterVo>? _listFindAllStaffMasterVo;
        private IOrderedEnumerable<ExtendsStaffMasterVo>? _linqExtendsStaffMasterVo;

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

            _listExtendsStaffMasterVo = null;
            _listFindAllStaffMasterVo = null;
            _linqExtendsStaffMasterVo = null;

            // 事故件数集計の基準となる年度を初期化
            ComboBoxAccidentYear.Text = "2022年度";
            /*
             * FpSpreadを初期化
             */
            SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            InitializeSheetViewList(SheetViewList);
            InitializeSheetViewList2(SheetViewList2);
            InitializeSheetViewList3(SheetViewList3);
            ToolStripStatusLabelDetail.Text = "";
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
            /*
             * SQL条件を作成する
             * SQLを作成する際に、全てのチェック項目のチェックが外れていないかを確認する
             */
            bool check;
            check = false;
            foreach (CheckBox checkBox in GroupBox1.Controls) {
                if (checkBox.Checked)
                    check = true;
            }
            if (!check) {
                MessageBox.Show("役職又は所属(第一条件)の全てのチェックを外す事は出来ません", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            check = false;
            foreach (CheckBox checkBox in GroupBox2.Controls) {
                if (checkBox.Checked)
                    check = true;
            }
            if (!check) {
                MessageBox.Show("雇用形態(第二条件)の全てのチェックを外す事は出来ません", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            check = false;
            foreach (CheckBox checkBox in GroupBox3.Controls) {
                if (checkBox.Checked)
                    check = true;
            }
            if (!check) {
                MessageBox.Show("職種(第三条件)の全てのチェックを外す事は出来ません", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _listExtendsStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllExtendsStaffMasterVo(CreateSqlString(GroupBox1), CreateSqlString(GroupBox2), CreateSqlString(GroupBox3));
            switch (SpreadList.ActiveSheet.SheetName) {
                case "従事者リスト":
                    SheetViewListOutPut();
                    break;
                case "健康診断用リスト":
                    SheetViewList2OutPut();
                    break;
                case "運転者リスト":
                    SheetViewList3OutPut();
                    break;
            }
        }

        /// <summary>
        /// CreateSqlString
        /// SQL文を作成する
        /// IN区を利用する
        /// </summary>
        /// <param name="groupBox"></param>
        /// <returns></returns>
        private string CreateSqlString(GroupBox groupBox) {
            int i = 0;
            string sql = "";
            foreach (CheckBox checkBox in groupBox.Controls) {
                if (checkBox.Checked) {
                    if (i == 0) {
                        sql += string.Concat(checkBox.Tag.ToString());
                    } else {
                        sql += string.Concat(",", checkBox.Tag.ToString());
                    }
                    i++;
                }
            }
            return sql;
        }

        /// <summary>
        /// TabControlEx1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlEx1_Click(object sender, EventArgs e) {
            if (_listFindAllStaffMasterVo != null) {
                switch (SpreadList.ActiveSheet.SheetName) {
                    case "従事者リスト":
                        SheetViewListOutPut();
                        break;
                    case "健康診断用リスト":
                        SheetViewList2OutPut();
                        break;
                    case "運転者リスト":
                        SheetViewList3OutPut();
                        break;
                }
            }
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
                "ア" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ア") || x.Name_kana.StartsWith("イ") || x.Name_kana.StartsWith("ウ") || x.Name_kana.StartsWith("エ") || x.Name_kana.StartsWith("オ")),
                "カ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("カ") || x.Name_kana.StartsWith("ガ") || x.Name_kana.StartsWith("キ") || x.Name_kana.StartsWith("ギ") || x.Name_kana.StartsWith("ク") || x.Name_kana.StartsWith("グ") || x.Name_kana.StartsWith("ケ") || x.Name_kana.StartsWith("コ") || x.Name_kana.StartsWith("ゴ")),
                "サ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("サ") || x.Name_kana.StartsWith("シ") || x.Name_kana.StartsWith("ス") || x.Name_kana.StartsWith("セ") || x.Name_kana.StartsWith("ソ")),
                "タ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("タ") || x.Name_kana.StartsWith("ダ") || x.Name_kana.StartsWith("チ") || x.Name_kana.StartsWith("ツ") || x.Name_kana.StartsWith("テ") || x.Name_kana.StartsWith("デ") || x.Name_kana.StartsWith("ト") || x.Name_kana.StartsWith("ド")),
                "ナ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ナ") || x.Name_kana.StartsWith("ニ") || x.Name_kana.StartsWith("ヌ") || x.Name_kana.StartsWith("ネ") || x.Name_kana.StartsWith("ノ")),
                "ハ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ハ") || x.Name_kana.StartsWith("パ") || x.Name_kana.StartsWith("ヒ") || x.Name_kana.StartsWith("ビ") || x.Name_kana.StartsWith("フ") || x.Name_kana.StartsWith("ブ") || x.Name_kana.StartsWith("ヘ") || x.Name_kana.StartsWith("ベ") || x.Name_kana.StartsWith("ホ")),
                "マ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("マ") || x.Name_kana.StartsWith("ミ") || x.Name_kana.StartsWith("ム") || x.Name_kana.StartsWith("メ") || x.Name_kana.StartsWith("モ")),
                "ヤ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ヤ") || x.Name_kana.StartsWith("ユ") || x.Name_kana.StartsWith("ヨ")),
                "ラ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ラ") || x.Name_kana.StartsWith("リ") || x.Name_kana.StartsWith("ル") || x.Name_kana.StartsWith("レ") || x.Name_kana.StartsWith("ロ")),
                "ワ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ワ") || x.Name_kana.StartsWith("ヲ") || x.Name_kana.StartsWith("ン")),
                _ => _listExtendsStaffMasterVo,
            };

            // 退職者
            if (!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Retirement_flag != true);
            // ソート
            _linqExtendsStaffMasterVo = _listFindAllStaffMasterVo?.OrderBy(x => x.Name_kana);

            int i = 0;
            if (_linqExtendsStaffMasterVo is not null)
                foreach (var extendsStaffMasterVo in _linqExtendsStaffMasterVo) {
                    // 所属
                    var _belongs = extendsStaffMasterVo.Belongs;
                    // 形態
                    var _jobForm = extendsStaffMasterVo.Job_form;
                    // 職種
                    var _occupation = extendsStaffMasterVo.Occupation;
                    // 配車対象
                    var _vehicleDispatchTarget = extendsStaffMasterVo.Vehicle_dispatch_target;
                    // 組合CD
                    var _code = extendsStaffMasterVo.Code;
                    // 氏名
                    var _name = extendsStaffMasterVo.Name;
                    // カナ
                    var _name_kana = extendsStaffMasterVo.Name_kana;
                    // 東環保
                    var _toukanpoTrainingCardFlag = extendsStaffMasterVo.ToukanpoTrainingCardFlag;
                    // 免許証
                    bool _licenseLedgerFlag = false;
                    DateTime? _licenseLedgerExpirationDate = null;
                    if (extendsStaffMasterVo?.LicenseNumber?.Length > 0) {
                        // 免許証
                        _licenseLedgerFlag = true;
                        // 免許証期限
                        _licenseLedgerExpirationDate = extendsStaffMasterVo.LicenseMasterExpirationDate.Date;
                    }
                    // 通勤届
                    var _commutingNotificationFlag = extendsStaffMasterVo?.CommutingNotification;
                    // 任意保険終了年月日
                    DateTime? _meansOfCommutingEndDate = null;
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.CommutingNotification) {
                        if (extendsStaffMasterVo.CommuterInsuranceEndDate.Date != _defaultDateTime.Date)
                            _meansOfCommutingEndDate = extendsStaffMasterVo.CommuterInsuranceEndDate.Date;
                    } else {
                        _meansOfCommutingEndDate = null;
                    }
                    // 生年月日・年齢
                    DateTime? _birth_date = null;
                    string _age = "";
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.Birth_date != _defaultDateTime) {
                        _birth_date = extendsStaffMasterVo.Birth_date.Date;
                        // 年齢
                        _age = string.Concat(new Date().GetStaffAge(extendsStaffMasterVo.Birth_date.Date), "歳");
                    }
                    // 雇用年月日
                    DateTime? _employment_date = null;
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.Employment_date != _defaultDateTime) {
                        _employment_date = extendsStaffMasterVo.Employment_date.Date;
                    }
                    // 勤続
                    string _service_date = "";
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.Employment_date != _defaultDateTime) {
                        _service_date = string.Concat(new Date().GetEmploymenteYear(extendsStaffMasterVo.Employment_date.Date).ToString("#0年"), new Date().GetEmploymenteMonth(extendsStaffMasterVo.Employment_date.Date).ToString("00月"));
                    }
                    // 初任
                    DateTime? _proper_kind_syonin = null;
                    if (extendsStaffMasterVo?.Proper_kind_1 == "初任診断")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_1;
                    if (extendsStaffMasterVo?.Proper_kind_2 == "初任診断")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_2;
                    if (extendsStaffMasterVo?.Proper_kind_3 == "初任診断")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_3;
                    // 適齢
                    string _proper_kind_tekirei = "";
                    var timeSpan = new TimeSpan(0, 0, 0, 0);

                    if (extendsStaffMasterVo is not null && (extendsStaffMasterVo.Proper_kind_1 == "適齢診断" || extendsStaffMasterVo.Proper_kind_2 == "適齢診断" || extendsStaffMasterVo.Proper_kind_3 == "適齢診断")) {
                        if (extendsStaffMasterVo.Proper_kind_1 == "適齢診断") {
                            timeSpan = extendsStaffMasterVo.Proper_date_1.AddYears(3) - DateTime.Now.Date;
                        } else if (extendsStaffMasterVo.Proper_kind_2 == "適齢診断") {
                            timeSpan = extendsStaffMasterVo.Proper_date_2.AddYears(3) - DateTime.Now.Date;
                        } else if (extendsStaffMasterVo.Proper_kind_3 == "適齢診断") {
                            timeSpan = extendsStaffMasterVo.Proper_date_3.AddYears(3) - DateTime.Now.Date;
                        }
                        _proper_kind_tekirei = string.Concat(timeSpan.Days, "日後");
                    }
                    // 事故数
                    string _car_accident_count = "";
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.CarAccidentMasterCount != 0) {
                        _car_accident_count = string.Concat(extendsStaffMasterVo.CarAccidentMasterCount, "件");
                    }
                    /*
                     * １年以内の健康診断
                     */
                    string _medical_examination;
                    if (extendsStaffMasterVo.Medical_examination_date_1 < DateTime.Now.Date.AddYears(-1)) {
                        _medical_examination = "健康診断を受けて下さい";
                    } else {
                        _medical_examination = string.Concat("受診(", extendsStaffMasterVo.Medical_examination_date_1.ToString("yyyy/MM/dd"), ")");
                    }

                    // 現住所
                    var _current_address = extendsStaffMasterVo?.Current_address;
                    // 健康保険
                    var _health_insurance_number = extendsStaffMasterVo?.Health_insurance_number != "" ? true : false;
                    // 厚生年金  
                    var _welfare_pension_number = extendsStaffMasterVo?.Welfare_pension_number != "" ? true : false;
                    // 雇用保険   
                    var _employment_insurance_number = extendsStaffMasterVo?.Employment_insurance_number != "" ? true : false;
                    // 労災保険   
                    var _worker_accident_insurance_number = extendsStaffMasterVo?.Worker_accident_insurance_number != "" ? true : false;

                    SheetViewList.Rows.Add(i, 1);
                    SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                    SheetViewList.Rows[i].ForeColor = extendsStaffMasterVo is not null && extendsStaffMasterVo.Retirement_flag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                    SheetViewList.Rows[i].Height = 22; // Rowの高さ
                    SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                    SheetViewList.Cells[i, colBelongs].Value = dictionaryBelongs[_belongs];
                    SheetViewList.Cells[i, colJobForm].Value = dictionaryJobForm[_jobForm];
                    SheetViewList.Cells[i, colOccupation].Value = dictionaryOccupation[_occupation];
                    SheetViewList.Cells[i, colVehicleDispatchTarget].Value = _vehicleDispatchTarget;
                    SheetViewList.Cells[i, colCode].Value = _code;
                    SheetViewList.Cells[i, colName].Text = _name;
                    SheetViewList.Cells[i, colName].Tag = extendsStaffMasterVo;
                    SheetViewList.Cells[i, colNameKana].Text = _name_kana;
                    SheetViewList.Cells[i, colToukanpoCard].Value = _toukanpoTrainingCardFlag;
                    SheetViewList.Cells[i, colLicense].Value = _licenseLedgerFlag;
                    SheetViewList.Cells[i, colLicensExpirationDate].Value = _licenseLedgerExpirationDate; // 免許証期限
                    SheetViewList.Cells[i, colCommutingNotification].Value = _commutingNotificationFlag; // 2022/05/24 通勤届
                    SheetViewList.Cells[i, colMeansOfCommutingEndDate].Value = _meansOfCommutingEndDate; // 2022/05/24 任意保険終了年月日
                    SheetViewList.Cells[i, colBirthDate].Value = _birth_date;
                    SheetViewList.Cells[i, colFullAge].Value = _age;
                    SheetViewList.Cells[i, colEmploymentDate].Value = _employment_date;
                    SheetViewList.Cells[i, colServiceDate].Value = _service_date;
                    SheetViewList.Cells[i, colFirstTerm].Value = _proper_kind_syonin;
                    SheetViewList.Cells[i, colSuitableAge].Value = _proper_kind_tekirei;
                    SheetViewList.Cells[i, colCarAccidentCount].Value = _car_accident_count;
                    SheetViewList.Cells[i, colMedicalExaminationDate].Value = _medical_examination;
                    SheetViewList.Cells[i, colMedicalExaminationDate].ForeColor = _medical_examination == "健康診断を受けて下さい" ? Color.Red : Color.Black;
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
        /// SheetViewList2OutPut
        /// 健康診断用リスト
        /// </summary>
        public void SheetViewList2OutPut() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if (SheetViewList2.Rows.Count > 0)
                SheetViewList2.RemoveRows(0, SheetViewList2.Rows.Count);

            _listFindAllStaffMasterVo = TabControlExStaff.SelectedTab.Tag switch {
                "ア" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ア") || x.Name_kana.StartsWith("イ") || x.Name_kana.StartsWith("ウ") || x.Name_kana.StartsWith("エ") || x.Name_kana.StartsWith("オ")),
                "カ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("カ") || x.Name_kana.StartsWith("ガ") || x.Name_kana.StartsWith("キ") || x.Name_kana.StartsWith("ギ") || x.Name_kana.StartsWith("ク") || x.Name_kana.StartsWith("グ") || x.Name_kana.StartsWith("ケ") || x.Name_kana.StartsWith("コ") || x.Name_kana.StartsWith("ゴ")),
                "サ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("サ") || x.Name_kana.StartsWith("シ") || x.Name_kana.StartsWith("ス") || x.Name_kana.StartsWith("セ") || x.Name_kana.StartsWith("ソ")),
                "タ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("タ") || x.Name_kana.StartsWith("ダ") || x.Name_kana.StartsWith("チ") || x.Name_kana.StartsWith("ツ") || x.Name_kana.StartsWith("テ") || x.Name_kana.StartsWith("デ") || x.Name_kana.StartsWith("ト") || x.Name_kana.StartsWith("ド")),
                "ナ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ナ") || x.Name_kana.StartsWith("ニ") || x.Name_kana.StartsWith("ヌ") || x.Name_kana.StartsWith("ネ") || x.Name_kana.StartsWith("ノ")),
                "ハ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ハ") || x.Name_kana.StartsWith("パ") || x.Name_kana.StartsWith("ヒ") || x.Name_kana.StartsWith("ビ") || x.Name_kana.StartsWith("フ") || x.Name_kana.StartsWith("ブ") || x.Name_kana.StartsWith("ヘ") || x.Name_kana.StartsWith("ベ") || x.Name_kana.StartsWith("ホ")),
                "マ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("マ") || x.Name_kana.StartsWith("ミ") || x.Name_kana.StartsWith("ム") || x.Name_kana.StartsWith("メ") || x.Name_kana.StartsWith("モ")),
                "ヤ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ヤ") || x.Name_kana.StartsWith("ユ") || x.Name_kana.StartsWith("ヨ")),
                "ラ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ラ") || x.Name_kana.StartsWith("リ") || x.Name_kana.StartsWith("ル") || x.Name_kana.StartsWith("レ") || x.Name_kana.StartsWith("ロ")),
                "ワ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ワ") || x.Name_kana.StartsWith("ヲ") || x.Name_kana.StartsWith("ン")),
                _ => _listExtendsStaffMasterVo,
            };

            // 退職者
            if (!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Retirement_flag != true);
            // ソート
            _linqExtendsStaffMasterVo = _listFindAllStaffMasterVo?.OrderBy(x => x.Belongs).ThenBy(x => x.Code).ThenBy(x => x.Name_kana);

            int i = 0;
            if (_linqExtendsStaffMasterVo is not null)
                foreach (var extendsStaffMasterVo in _linqExtendsStaffMasterVo) {
                    // 所属
                    var _belongs = extendsStaffMasterVo.Belongs;
                    // 種別
                    var _occupation = extendsStaffMasterVo.Occupation;
                    // 組合CD
                    var _code = extendsStaffMasterVo.Code;
                    // 氏名
                    var _name = extendsStaffMasterVo.Name;
                    // カナ
                    var _name_kana = extendsStaffMasterVo.Name_kana;
                    // 生年月日・年齢
                    DateTime? _birth_date = null;
                    string _age = "";
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.Birth_date != _defaultDateTime) {
                        _birth_date = extendsStaffMasterVo.Birth_date.Date;
                        // 年齢
                        _age = string.Concat(new Date().GetStaffAge(extendsStaffMasterVo.Birth_date.Date), "歳");
                    }
                    // 健康保険番号
                    string _health_insurance_number = extendsStaffMasterVo.Health_insurance_number;

                    SheetViewList2.Rows.Add(i, 1);
                    SheetViewList2.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                    SheetViewList2.Rows[i].ForeColor = extendsStaffMasterVo is not null && extendsStaffMasterVo.Retirement_flag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                    SheetViewList2.Rows[i].Height = 22; // Rowの高さ
                    SheetViewList2.Rows[i].Resizable = false; // RowのResizableを禁止

                    SheetViewList2.Cells[i, 0].Value = "";
                    SheetViewList2.Cells[i, 1].Value = dictionaryBelongs[_belongs];
                    SheetViewList2.Cells[i, 2].Value = dictionaryOccupation[_occupation] == "運転手" ? "運転手" : "";
                    SheetViewList2.Cells[i, 3].Value = _code;
                    SheetViewList2.Cells[i, 4].Text = _name;
                    SheetViewList2.Cells[i, 5].Text = _name_kana;
                    SheetViewList2.Cells[i, 6].Value = _birth_date;
                    SheetViewList2.Cells[i, 7].Value = _age;
                    SheetViewList2.Cells[i, 8].Value = _health_insurance_number;
                    i++;
                }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }

        /// <summary>
        /// SheetViewList3OutPut
        /// 運転者リスト
        /// </summary>
        public void SheetViewList3OutPut() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if (SheetViewList3.Rows.Count > 0)
                SheetViewList3.RemoveRows(0, SheetViewList3.Rows.Count);

            _listFindAllStaffMasterVo = TabControlExStaff.SelectedTab.Tag switch {
                "ア" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ア") || x.Name_kana.StartsWith("イ") || x.Name_kana.StartsWith("ウ") || x.Name_kana.StartsWith("エ") || x.Name_kana.StartsWith("オ")),
                "カ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("カ") || x.Name_kana.StartsWith("ガ") || x.Name_kana.StartsWith("キ") || x.Name_kana.StartsWith("ギ") || x.Name_kana.StartsWith("ク") || x.Name_kana.StartsWith("グ") || x.Name_kana.StartsWith("ケ") || x.Name_kana.StartsWith("コ") || x.Name_kana.StartsWith("ゴ")),
                "サ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("サ") || x.Name_kana.StartsWith("シ") || x.Name_kana.StartsWith("ス") || x.Name_kana.StartsWith("セ") || x.Name_kana.StartsWith("ソ")),
                "タ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("タ") || x.Name_kana.StartsWith("ダ") || x.Name_kana.StartsWith("チ") || x.Name_kana.StartsWith("ツ") || x.Name_kana.StartsWith("テ") || x.Name_kana.StartsWith("デ") || x.Name_kana.StartsWith("ト") || x.Name_kana.StartsWith("ド")),
                "ナ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ナ") || x.Name_kana.StartsWith("ニ") || x.Name_kana.StartsWith("ヌ") || x.Name_kana.StartsWith("ネ") || x.Name_kana.StartsWith("ノ")),
                "ハ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ハ") || x.Name_kana.StartsWith("パ") || x.Name_kana.StartsWith("ヒ") || x.Name_kana.StartsWith("ビ") || x.Name_kana.StartsWith("フ") || x.Name_kana.StartsWith("ブ") || x.Name_kana.StartsWith("ヘ") || x.Name_kana.StartsWith("ベ") || x.Name_kana.StartsWith("ホ")),
                "マ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("マ") || x.Name_kana.StartsWith("ミ") || x.Name_kana.StartsWith("ム") || x.Name_kana.StartsWith("メ") || x.Name_kana.StartsWith("モ")),
                "ヤ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ヤ") || x.Name_kana.StartsWith("ユ") || x.Name_kana.StartsWith("ヨ")),
                "ラ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ラ") || x.Name_kana.StartsWith("リ") || x.Name_kana.StartsWith("ル") || x.Name_kana.StartsWith("レ") || x.Name_kana.StartsWith("ロ")),
                "ワ" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("ワ") || x.Name_kana.StartsWith("ヲ") || x.Name_kana.StartsWith("ン")),
                _ => _listExtendsStaffMasterVo,
            };

            // 退職者
            if (!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Retirement_flag != true);
            // ソート
            _linqExtendsStaffMasterVo = _listFindAllStaffMasterVo?.OrderBy(x => x.Belongs).ThenBy(x => x.Code).ThenBy(x => x.Name_kana);

            int i = 0;
            if (_linqExtendsStaffMasterVo is not null)
                foreach (var extendsStaffMasterVo in _linqExtendsStaffMasterVo) {
                    // 所属
                    var _belongs = extendsStaffMasterVo.Belongs;
                    // 種別
                    var _occupation = extendsStaffMasterVo.Occupation;
                    // 氏名
                    var _name = extendsStaffMasterVo.Name;
                    // カナ
                    var _name_kana = extendsStaffMasterVo.Name_kana;
                    // 年齢
                    string _age = "";
                    if (extendsStaffMasterVo is not null && extendsStaffMasterVo.Birth_date != _defaultDateTime) {
                        // 年齢
                        _age = string.Concat(new Date().GetStaffAge(extendsStaffMasterVo.Birth_date.Date), "歳");
                    }

                    SheetViewList3.Rows.Add(i, 1);
                    SheetViewList3.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                    SheetViewList3.Rows[i].ForeColor = extendsStaffMasterVo is not null && extendsStaffMasterVo.Retirement_flag ? Color.Red : Color.Black; // 退職済のレコードのForeColorをセット
                    SheetViewList3.Rows[i].Height = 22; // Rowの高さ
                    SheetViewList3.Rows[i].Resizable = false; // RowのResizableを禁止

                    SheetViewList3.Cells[i, 0].Value = i + 1;
                    SheetViewList3.Cells[i, 1].Value = dictionaryBelongs[_belongs];
                    SheetViewList3.Cells[i, 2].Value = dictionaryOccupation[_occupation] == "運転手" ? "運転手" : "";
                    SheetViewList3.Cells[i, 3].Text = _name;
                    SheetViewList3.Cells[i, 4].Text = _name_kana;
                    SheetViewList3.Cells[i, 5].Value = _age;
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
            // ダブルクリックされたのが従事者リストで無ければReturnする
            if (((FpSpread)sender).ActiveSheet.SheetName != "従事者リスト")
                return;
            // ヘッダーのDoubleClickを回避
            if (e.ColumnHeader)
                return;
            // Shiftが押された場合
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                var staffRegisterPaper = new StaffPaper(_connectionVo, ((ExtendsStaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).Staff_code);
                staffRegisterPaper.ShowDialog();
                return;
            }
            // 修飾キーが無い場合
            var staffRegisterDetail = new StaffDetail(_connectionVo, ((ExtendsStaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).Staff_code);
            staffRegisterDetail.ShowDialog();
        }

        /// <summary>
        /// ToolStripMenuItemNewStaff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemNewStaff_Click(object sender, EventArgs e) {
            var staffDetail = new StaffDetail(_connectionVo);
            staffDetail.ShowDialog();
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
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
        /// InitializeSheetViewList2
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList2(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
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
        /// InitializeSheetViewList3
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList3(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
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
        /// ContextMenuStrip1_Opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            switch (SpreadList.ActiveSheet.SheetName) {
                case "従事者リスト":
                    ContextMenuStrip1.Enabled = true;
                    /*
                     * SheetViewにRowが無い場合や、Rowが選択されていない場合はReturnする
                     */
                    if (SheetViewList.RowCount < 1 || !SheetViewList.IsBlockSelected) {
                        e.Cancel = true;
                        return;
                    }

                    var spreadList = (FpSpread)((ContextMenuStrip)sender).SourceControl;
                    var cellRange = spreadList.ActiveSheet.GetSelections();
                    /*
                     * 免許証
                     */
                    if (cellRange[0].RowCount == 1) {
                        var license = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colLicense].Value;
                        if ((bool)license) {
                            ToolStripMenuItemLicense.Enabled = true;
                        } else {
                            ToolStripMenuItemLicense.Enabled = false;
                        }
                    } else {
                        ToolStripMenuItemLicense.Enabled = false;
                    }
                    /*
                     * 東環保
                     */
                    if (cellRange[0].RowCount == 1) {
                        var toukanpoCard = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colToukanpoCard].Value;
                        if ((bool)toukanpoCard) {
                            ToolStripMenuItemToukanpo.Enabled = true;
                        } else {
                            ToolStripMenuItemToukanpo.Enabled = false;
                        }
                    } else {
                        ToolStripMenuItemLicense.Enabled = false;
                    }
                    /*
                     * 地図を表示する
                     */
                    if (cellRange[0].RowCount == 1) {
                        var currentAddress = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCurrentAddress].Text;
                        if (!string.IsNullOrEmpty(currentAddress)) {
                            ToolStripMenuItemMap.Enabled = true;
                        } else {
                            ToolStripMenuItemMap.Enabled = false;
                        }
                    } else {
                        ToolStripMenuItemMap.Enabled = false;
                    }
                    break;
                case "健康診断用リスト":
                    ContextMenuStrip1.Enabled = false;
                    break;
                case "運転者リスト":
                    ContextMenuStrip1.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            int staffCode = ((ExtendsStaffMasterVo)SheetViewList.Cells[SheetViewList.ActiveRowIndex, colName].Tag).Staff_code;
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 免許証を表示
                 */
                case "ToolStripMenuItemLicense":
                    var licenseMasterPicture = new LicenseCard(_connectionVo, staffCode);
                    licenseMasterPicture.ShowDialog();
                    break;
                /*
                 * 東環保修了証を表示
                 */
                case "ToolStripMenuItemToukanpo":
                    MessageBox.Show("ToolStripMenuItemToukanpo");
                    break;
                /*
                 * 地図を表示
                 */
                case "ToolStripMenuItemMap":
                    var currentAddress = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCurrentAddress].Text;
                    new Maps().MapOpen(currentAddress);
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItemExport1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExport_Click(object sender, EventArgs e) {
            //xlsx形式ファイルをエクスポートします
            string fileName = string.Concat("StaffList", DateTime.Now.ToString("MM月dd日"), "作成");
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
        /// StaffList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffList_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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