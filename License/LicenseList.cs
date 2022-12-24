using Common;

using Dao;

using Vo;

namespace License {
    public partial class LicenseList : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private readonly List<StaffMasterVo> _listStaffMasterVo;
        private List<LicenseMasterVo> _listLicenseMasterVo;
        private List<LicenseMasterVo> _listFindAllLicenseMasterVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        // SPREADのColumnの番号
        /// <summary>
        /// 社員コード
        /// </summary>
        private const int colStaffCode = 0;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colName = 1;
        /// <summary>
        /// 生年月日
        /// </summary>
        private const int colBirthDate = 2;
        /// <summary>
        /// 年齢
        /// </summary>
        private const int colAge = 3;
        /// <summary>
        /// 現住所
        /// </summary>
        private const int colCurrentAddress = 4;
        /// <summary>
        /// 交付年月日
        /// </summary>
        private const int colDeliveryDate = 5;
        /// <summary>
        /// 有効期限
        /// </summary>
        private const int colExpirationDate = 6;
        /// <summary>
        /// 条件等
        /// </summary>
        private const int colLicenseCondition = 7;
        /// <summary>
        /// 免許証番号
        /// </summary>
        private const int colLicenseNumber = 8;
        /// <summary>
        /// 二小原取得日
        /// </summary>
        private const int colGetDate1 = 9;
        /// <summary>
        /// 他取得日
        /// </summary>
        private const int colGetDate2 = 10;
        /// <summary>
        /// 二種取得日
        /// </summary>
        private const int colGetDate3 = 11;
        /// <summary>
        /// 大型
        /// </summary>
        private const int colLarge = 12;
        /// <summary>
        /// 中型
        /// </summary>
        private const int colMedium = 13;
        /// <summary>
        /// 準中型
        /// </summary>
        private const int colQuasiMedium = 14;
        /// <summary>
        /// 普通
        /// </summary>
        private const int colOrdinary = 15;
        /// <summary>
        /// 大特
        /// </summary>
        private const int colBigSpecial = 16;
        /// <summary>
        /// 大自二
        /// </summary>
        private const int colBigAutoBike = 17;
        /// <summary>
        /// 普自二
        /// </summary>
        private const int colOrdinaryAutoBike = 18;
        /// <summary>
        /// 小特
        /// </summary>
        private const int colSmallSpecial = 19;
        /// <summary>
        /// 原付
        /// </summary>
        private const int colWithARaw = 20;
        /// <summary>
        /// 大型二種
        /// </summary>
        private const int colBigTwo = 21;
        /// <summary>
        /// 中型二種
        /// </summary>
        private const int colMediumTwo = 22;
        /// <summary>
        /// 普通二種
        /// </summary>
        private const int colOrdinaryTwo = 23;
        /// <summary>
        /// 大特二種
        /// </summary>
        private const int colBigSpecialTwo = 24;
        /// <summary>
        /// 牽引
        /// </summary>
        private const int colTraction = 25;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public LicenseList(ConnectionVo connectionVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listLicenseMasterVo = new List<LicenseMasterVo>();
            _listFindAllLicenseMasterVo = new List<LicenseMasterVo>();
            // Form初期化
            InitializeForm();
        }

        public static void Main() {
        }

        /// <summary>
        /// Form初期化
        /// </summary>
        private void InitializeForm() {
            // Formの表示サイズを初期化
            _initializeForm.LicenseList(this);
            // DataGridView初期化
            SetDataGridView(DataGridView1);
            ToolStripStatusLabelDetail.Text = "";
        }

        /// <summary>
        /// 最新化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            _listLicenseMasterVo = new LicenseMasterDao(_connectionVo).SelectAllLicenseMaster();
            DataGridViewOutPut();

        }

        private void TabControlStaff_Click(object sender, EventArgs e) {
            if (_listLicenseMasterVo == null)
                return;
            DataGridViewOutPut();
        }

        /// <summary>
        /// DataGridViewOutPut
        /// </summary>
        private void DataGridViewOutPut() {
            switch (TabControlStaff.SelectedTab.Tag) {
                case "ア":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("ア") || x.Name_kana.StartsWith("イ") || x.Name_kana.StartsWith("ウ") || x.Name_kana.StartsWith("エ") || x.Name_kana.StartsWith("オ"));
                    break;
                case "カ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("カ") || x.Name_kana.StartsWith("ガ") || x.Name_kana.StartsWith("キ") || x.Name_kana.StartsWith("ギ") || x.Name_kana.StartsWith("ク") || x.Name_kana.StartsWith("ケ") || x.Name_kana.StartsWith("コ") || x.Name_kana.StartsWith("ゴ"));
                    break;
                case "サ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("サ") || x.Name_kana.StartsWith("シ") || x.Name_kana.StartsWith("ス") || x.Name_kana.StartsWith("セ") || x.Name_kana.StartsWith("ソ"));
                    break;
                case "タ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("タ") || x.Name_kana.StartsWith("チ") || x.Name_kana.StartsWith("ツ") || x.Name_kana.StartsWith("テ") || x.Name_kana.StartsWith("デ") || x.Name_kana.StartsWith("ト") || x.Name_kana.StartsWith("ド"));
                    break;
                case "ナ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("ナ") || x.Name_kana.StartsWith("ニ") || x.Name_kana.StartsWith("ヌ") || x.Name_kana.StartsWith("ネ") || x.Name_kana.StartsWith("ノ"));
                    break;
                case "ハ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("ハ") || x.Name_kana.StartsWith("パ") || x.Name_kana.StartsWith("ヒ") || x.Name_kana.StartsWith("ビ") || x.Name_kana.StartsWith("フ") || x.Name_kana.StartsWith("ヘ") || x.Name_kana.StartsWith("ベ") || x.Name_kana.StartsWith("ホ"));
                    break;
                case "マ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("マ") || x.Name_kana.StartsWith("ミ") || x.Name_kana.StartsWith("ム") || x.Name_kana.StartsWith("メ") || x.Name_kana.StartsWith("モ"));
                    break;
                case "ヤ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("ヤ") || x.Name_kana.StartsWith("ユ") || x.Name_kana.StartsWith("ヨ"));
                    break;
                case "ラ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("ラ") || x.Name_kana.StartsWith("リ") || x.Name_kana.StartsWith("ル") || x.Name_kana.StartsWith("レ") || x.Name_kana.StartsWith("ロ"));
                    break;
                case "ワ":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("ワ") || x.Name_kana.StartsWith("ヲ") || x.Name_kana.StartsWith("ン"));
                    break;
                default:
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo;
                    break;
            }
            // Sort
            var _linqLicenseLedgerVo = _listFindAllLicenseMasterVo.OrderBy(x => x.Name_kana);

            DataGridView1.SuspendLayout();
            DataGridView1.Rows.Clear();
            int i = 0;
            foreach (var licenseLedgerVo in _linqLicenseLedgerVo) {
                DataGridView1.Rows.Add(1);
                DataGridView1.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                DataGridView1[colStaffCode, i].Value = licenseLedgerVo.Staff_code;
                DataGridView1[colName, i].Value = licenseLedgerVo.Name;
                DataGridView1[colBirthDate, i].Value = licenseLedgerVo.Birth_date.ToString("yyyy年MM月dd日(ddd)");
                DataGridView1[colAge, i].Value = string.Concat(new Date().GetStaffAge(licenseLedgerVo.Birth_date.Date), "歳");
                DataGridView1[colCurrentAddress, i].Value = licenseLedgerVo.Current_address;
                DataGridView1[colDeliveryDate, i].Value = licenseLedgerVo.Delivery_date.ToString("yyyy年MM月dd日(ddd)");
                DataGridView1[colExpirationDate, i].Value = licenseLedgerVo.Expiration_date.ToString("yyyy年MM月dd日(ddd)");
                DataGridView1[colLicenseCondition, i].Value = licenseLedgerVo.License_condition;
                DataGridView1[colLicenseNumber, i].Value = licenseLedgerVo.License_number;
                DataGridView1[colGetDate1, i].Value = GetDateTime(licenseLedgerVo.Get_date_1);
                DataGridView1[colGetDate2, i].Value = GetDateTime(licenseLedgerVo.Get_date_2);
                DataGridView1[colGetDate3, i].Value = GetDateTime(licenseLedgerVo.Get_date_3);
                DataGridView1[colLarge, i].Value = licenseLedgerVo.Large ? "●" : ""; // 大型
                DataGridView1[colMedium, i].Value = licenseLedgerVo.Medium ? "●" : ""; // 中型
                DataGridView1[colQuasiMedium, i].Value = licenseLedgerVo.Quasi_medium ? "●" : ""; // 準中型
                DataGridView1[colOrdinary, i].Value = licenseLedgerVo.Ordinary ? "●" : ""; // 普通
                DataGridView1[colBigSpecial, i].Value = licenseLedgerVo.Big_special ? "●" : ""; // 大特
                DataGridView1[colBigAutoBike, i].Value = licenseLedgerVo.Big_auto_bike ? "●" : ""; // 大自二
                DataGridView1[colOrdinaryAutoBike, i].Value = licenseLedgerVo.Ordinary_auto_bike ? "●" : ""; // 普自二
                DataGridView1[colSmallSpecial, i].Value = licenseLedgerVo.Small_special ? "●" : ""; // 小特
                DataGridView1[colWithARaw, i].Value = licenseLedgerVo.With_a_raw ? "●" : ""; // 原付
                DataGridView1[colBigTwo, i].Value = licenseLedgerVo.Big_two ? "●" : ""; // 大型二種
                DataGridView1[colMediumTwo, i].Value = licenseLedgerVo.Medium_two ? "●" : ""; // 中型二種
                DataGridView1[colOrdinaryTwo, i].Value = licenseLedgerVo.Ordinary_two ? "●" : ""; // 普通二種
                DataGridView1[colBigSpecialTwo, i].Value = licenseLedgerVo.Big_special_two ? "●" : ""; // 大特二種
                DataGridView1[colTraction, i].Value = licenseLedgerVo.Traction ? "●" : ""; // 牽引
                i++;
            }
            DataGridView1.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }

        /// <summary>
        /// GetDateTime
        /// 引数がDefaultDateTimeな場合、日時を空白にする処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateTime(DateTime dateTime) {
            string stringText;
            if (dateTime != _defaultDateTime) {
                stringText = dateTime.ToString("yyyy年MM月dd日(ddd)");
            } else {
                stringText = "";
            }
            return stringText;
        }

        private DataGridView SetDataGridView(DataGridView dataGridView) {
            // 選択モード
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 読み取り専用
            dataGridView.ReadOnly = true;
            // 全ての行の背景色
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            // 奇数行の背景色
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            // 新規追加行を非表示
            dataGridView.AllowUserToAddRows = false;
            // DataGridView1でセル、行、列が複数選択されないようにする
            dataGridView.MultiSelect = false;
            // ボーダーの設定
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            // Cplumnヘッダーの高さ
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.ColumnHeadersHeight = 30;
            // RowHeadersWidth
            dataGridView.RowHeadersWidth = 50;

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("colStaffCode", "社員CD");
            dataGridView.Columns["colStaffCode"].Width = 80;
            dataGridView.Columns["colStaffCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colName", "氏名");
            dataGridView.Columns["colName"].Frozen = true; // 固定列を指定
            dataGridView.Columns.Add("colBirthDate", "生年月日");
            dataGridView.Columns["colBirthDate"].Width = 120;
            dataGridView.Columns["colBirthDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colAge", "年齢");
            dataGridView.Columns["colAge"].Width = 60;
            dataGridView.Columns["colAge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns.Add("colCurrentAddress", "現住所");
            dataGridView.Columns["colCurrentAddress"].Width = 240;
            dataGridView.Columns.Add("colDeliveryDate", "交付年月日");
            dataGridView.Columns["colDeliveryDate"].Width = 120;
            dataGridView.Columns["colDeliveryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colExpirationDate", "有効期限");
            dataGridView.Columns["colExpirationDate"].Width = 120;
            dataGridView.Columns["colExpirationDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colLicenseCondition", "条件等");
            dataGridView.Columns["colLicenseCondition"].Width = 200;
            dataGridView.Columns.Add("colLicenseNumber", "免許証番号");
            dataGridView.Columns["colLicenseNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colGetDate1", "二小原取得日");
            dataGridView.Columns["colGetDate1"].Width = 120;
            dataGridView.Columns["colGetDate1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colGetDate2", "他取得日");
            dataGridView.Columns["colGetDate2"].Width = 120;
            dataGridView.Columns["colGetDate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colGetDate3", "二種取得日");
            dataGridView.Columns["colGetDate3"].Width = 120;
            dataGridView.Columns["colGetDate3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colLarge", "大型");
            dataGridView.Columns["colLarge"].Width = 70;
            dataGridView.Columns["colLarge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colMedium", "中型");
            dataGridView.Columns["colMedium"].Width = 70;
            dataGridView.Columns["colMedium"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colQuasiMedium", "準中型");
            dataGridView.Columns["colQuasiMedium"].Width = 70;
            dataGridView.Columns["colQuasiMedium"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colOrdinary", "普通");
            dataGridView.Columns["colOrdinary"].Width = 70;
            dataGridView.Columns["colOrdinary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigSpecial", "大特");
            dataGridView.Columns["colBigSpecial"].Width = 70;
            dataGridView.Columns["colBigSpecial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigAutoBike", "大自二");
            dataGridView.Columns["colBigAutoBike"].Width = 70;
            dataGridView.Columns["colBigAutoBike"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colOrdinaryAutoBike", "普自二");
            dataGridView.Columns["colOrdinaryAutoBike"].Width = 70;
            dataGridView.Columns["colOrdinaryAutoBike"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colSmallSpecial", "小特");
            dataGridView.Columns["colSmallSpecial"].Width = 70;
            dataGridView.Columns["colSmallSpecial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colWithARaw", "原付");
            dataGridView.Columns["colWithARaw"].Width = 70;
            dataGridView.Columns["colWithARaw"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigTwo", "大型二");
            dataGridView.Columns["colBigTwo"].Width = 70;
            dataGridView.Columns["colBigTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colMediumTwo", "中型二");
            dataGridView.Columns["colMediumTwo"].Width = 70;
            dataGridView.Columns["colMediumTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colOrdinaryTwo", "普通二");
            dataGridView.Columns["colOrdinaryTwo"].Width = 70;
            dataGridView.Columns["colOrdinaryTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigSpecialTwo", "大特二");
            dataGridView.Columns["colBigSpecialTwo"].Width = 70;
            dataGridView.Columns["colBigSpecialTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colTraction", "牽引");
            dataGridView.Columns["colTraction"].Width = 70;
            dataGridView.Columns["colTraction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return dataGridView;
        }

        /// <summary>
        /// 新規免許証を登録する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemNewLicense_Click(object sender, EventArgs e) {
            var licenseLedgerDetail = new LicenseDetail(_connectionVo, _listStaffMasterVo);
            licenseLedgerDetail.ShowDialog();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if (e.RowIndex < 0)
                return;
            var licenseDetail = new LicenseDetail(_connectionVo, (int)DataGridView1[colStaffCode, e.RowIndex].Value);
            licenseDetail.ShowDialog();
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
        /// LicenseLedgerList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LicenseLedgerList_FormClosing(object sender, FormClosingEventArgs e) {
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