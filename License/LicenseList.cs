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

        // SPREAD��Column�̔ԍ�
        /// <summary>
        /// �Ј��R�[�h
        /// </summary>
        private const int colStaffCode = 0;
        /// <summary>
        /// ����
        /// </summary>
        private const int colName = 1;
        /// <summary>
        /// ���N����
        /// </summary>
        private const int colBirthDate = 2;
        /// <summary>
        /// �N��
        /// </summary>
        private const int colAge = 3;
        /// <summary>
        /// ���Z��
        /// </summary>
        private const int colCurrentAddress = 4;
        /// <summary>
        /// ��t�N����
        /// </summary>
        private const int colDeliveryDate = 5;
        /// <summary>
        /// �L������
        /// </summary>
        private const int colExpirationDate = 6;
        /// <summary>
        /// ������
        /// </summary>
        private const int colLicenseCondition = 7;
        /// <summary>
        /// �Ƌ��ؔԍ�
        /// </summary>
        private const int colLicenseNumber = 8;
        /// <summary>
        /// �񏬌��擾��
        /// </summary>
        private const int colGetDate1 = 9;
        /// <summary>
        /// ���擾��
        /// </summary>
        private const int colGetDate2 = 10;
        /// <summary>
        /// ���擾��
        /// </summary>
        private const int colGetDate3 = 11;
        /// <summary>
        /// ��^
        /// </summary>
        private const int colLarge = 12;
        /// <summary>
        /// ���^
        /// </summary>
        private const int colMedium = 13;
        /// <summary>
        /// �����^
        /// </summary>
        private const int colQuasiMedium = 14;
        /// <summary>
        /// ����
        /// </summary>
        private const int colOrdinary = 15;
        /// <summary>
        /// ���
        /// </summary>
        private const int colBigSpecial = 16;
        /// <summary>
        /// �厩��
        /// </summary>
        private const int colBigAutoBike = 17;
        /// <summary>
        /// ������
        /// </summary>
        private const int colOrdinaryAutoBike = 18;
        /// <summary>
        /// ����
        /// </summary>
        private const int colSmallSpecial = 19;
        /// <summary>
        /// ���t
        /// </summary>
        private const int colWithARaw = 20;
        /// <summary>
        /// ��^���
        /// </summary>
        private const int colBigTwo = 21;
        /// <summary>
        /// ���^���
        /// </summary>
        private const int colMediumTwo = 22;
        /// <summary>
        /// ���ʓ��
        /// </summary>
        private const int colOrdinaryTwo = 23;
        /// <summary>
        /// ������
        /// </summary>
        private const int colBigSpecialTwo = 24;
        /// <summary>
        /// ����
        /// </summary>
        private const int colTraction = 25;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="connectionVo"></param>
        public LicenseList(ConnectionVo connectionVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listLicenseMasterVo = new List<LicenseMasterVo>();
            _listFindAllLicenseMasterVo = new List<LicenseMasterVo>();
            // Form������
            InitializeForm();
        }

        public static void Main() {
        }

        /// <summary>
        /// Form������
        /// </summary>
        private void InitializeForm() {
            // Form�̕\���T�C�Y��������
            _initializeForm.LicenseList(this);
            // DataGridView������
            SetDataGridView(DataGridView1);
            ToolStripStatusLabelDetail.Text = "";
        }

        /// <summary>
        /// �ŐV��
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
                case "�A":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�A") || x.Name_kana.StartsWith("�C") || x.Name_kana.StartsWith("�E") || x.Name_kana.StartsWith("�G") || x.Name_kana.StartsWith("�I"));
                    break;
                case "�J":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�J") || x.Name_kana.StartsWith("�K") || x.Name_kana.StartsWith("�L") || x.Name_kana.StartsWith("�M") || x.Name_kana.StartsWith("�N") || x.Name_kana.StartsWith("�P") || x.Name_kana.StartsWith("�R") || x.Name_kana.StartsWith("�S"));
                    break;
                case "�T":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�T") || x.Name_kana.StartsWith("�V") || x.Name_kana.StartsWith("�X") || x.Name_kana.StartsWith("�Z") || x.Name_kana.StartsWith("�\"));
                    break;
                case "�^":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�^") || x.Name_kana.StartsWith("�`") || x.Name_kana.StartsWith("�c") || x.Name_kana.StartsWith("�e") || x.Name_kana.StartsWith("�f") || x.Name_kana.StartsWith("�g") || x.Name_kana.StartsWith("�h"));
                    break;
                case "�i":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�i") || x.Name_kana.StartsWith("�j") || x.Name_kana.StartsWith("�k") || x.Name_kana.StartsWith("�l") || x.Name_kana.StartsWith("�m"));
                    break;
                case "�n":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�n") || x.Name_kana.StartsWith("�p") || x.Name_kana.StartsWith("�q") || x.Name_kana.StartsWith("�r") || x.Name_kana.StartsWith("�t") || x.Name_kana.StartsWith("�w") || x.Name_kana.StartsWith("�x") || x.Name_kana.StartsWith("�z"));
                    break;
                case "�}":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("�}") || x.Name_kana.StartsWith("�~") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��"));
                    break;
                case "��":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��"));
                    break;
                case "��":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��"));
                    break;
                case "��":
                    _listFindAllLicenseMasterVo = _listLicenseMasterVo.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��"));
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
                DataGridView1[colBirthDate, i].Value = licenseLedgerVo.Birth_date.ToString("yyyy�NMM��dd��(ddd)");
                DataGridView1[colAge, i].Value = string.Concat(new Date().GetStaffAge(licenseLedgerVo.Birth_date.Date), "��");
                DataGridView1[colCurrentAddress, i].Value = licenseLedgerVo.Current_address;
                DataGridView1[colDeliveryDate, i].Value = licenseLedgerVo.Delivery_date.ToString("yyyy�NMM��dd��(ddd)");
                DataGridView1[colExpirationDate, i].Value = licenseLedgerVo.Expiration_date.ToString("yyyy�NMM��dd��(ddd)");
                DataGridView1[colLicenseCondition, i].Value = licenseLedgerVo.License_condition;
                DataGridView1[colLicenseNumber, i].Value = licenseLedgerVo.License_number;
                DataGridView1[colGetDate1, i].Value = GetDateTime(licenseLedgerVo.Get_date_1);
                DataGridView1[colGetDate2, i].Value = GetDateTime(licenseLedgerVo.Get_date_2);
                DataGridView1[colGetDate3, i].Value = GetDateTime(licenseLedgerVo.Get_date_3);
                DataGridView1[colLarge, i].Value = licenseLedgerVo.Large ? "��" : ""; // ��^
                DataGridView1[colMedium, i].Value = licenseLedgerVo.Medium ? "��" : ""; // ���^
                DataGridView1[colQuasiMedium, i].Value = licenseLedgerVo.Quasi_medium ? "��" : ""; // �����^
                DataGridView1[colOrdinary, i].Value = licenseLedgerVo.Ordinary ? "��" : ""; // ����
                DataGridView1[colBigSpecial, i].Value = licenseLedgerVo.Big_special ? "��" : ""; // ���
                DataGridView1[colBigAutoBike, i].Value = licenseLedgerVo.Big_auto_bike ? "��" : ""; // �厩��
                DataGridView1[colOrdinaryAutoBike, i].Value = licenseLedgerVo.Ordinary_auto_bike ? "��" : ""; // ������
                DataGridView1[colSmallSpecial, i].Value = licenseLedgerVo.Small_special ? "��" : ""; // ����
                DataGridView1[colWithARaw, i].Value = licenseLedgerVo.With_a_raw ? "��" : ""; // ���t
                DataGridView1[colBigTwo, i].Value = licenseLedgerVo.Big_two ? "��" : ""; // ��^���
                DataGridView1[colMediumTwo, i].Value = licenseLedgerVo.Medium_two ? "��" : ""; // ���^���
                DataGridView1[colOrdinaryTwo, i].Value = licenseLedgerVo.Ordinary_two ? "��" : ""; // ���ʓ��
                DataGridView1[colBigSpecialTwo, i].Value = licenseLedgerVo.Big_special_two ? "��" : ""; // ������
                DataGridView1[colTraction, i].Value = licenseLedgerVo.Traction ? "��" : ""; // ����
                i++;
            }
            DataGridView1.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " ��");
        }

        /// <summary>
        /// GetDateTime
        /// ������DefaultDateTime�ȏꍇ�A�������󔒂ɂ��鏈��
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateTime(DateTime dateTime) {
            string stringText;
            if (dateTime != _defaultDateTime) {
                stringText = dateTime.ToString("yyyy�NMM��dd��(ddd)");
            } else {
                stringText = "";
            }
            return stringText;
        }

        private DataGridView SetDataGridView(DataGridView dataGridView) {
            // �I�����[�h
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // �ǂݎ���p
            dataGridView.ReadOnly = true;
            // �S�Ă̍s�̔w�i�F
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            // ��s�̔w�i�F
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            // �V�K�ǉ��s���\��
            dataGridView.AllowUserToAddRows = false;
            // DataGridView1�ŃZ���A�s�A�񂪕����I������Ȃ��悤�ɂ���
            dataGridView.MultiSelect = false;
            // �{�[�_�[�̐ݒ�
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            // Cplumn�w�b�_�[�̍���
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.ColumnHeadersHeight = 30;
            // RowHeadersWidth
            dataGridView.RowHeadersWidth = 50;

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("colStaffCode", "�Ј�CD");
            dataGridView.Columns["colStaffCode"].Width = 80;
            dataGridView.Columns["colStaffCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colName", "����");
            dataGridView.Columns["colName"].Frozen = true; // �Œ����w��
            dataGridView.Columns.Add("colBirthDate", "���N����");
            dataGridView.Columns["colBirthDate"].Width = 120;
            dataGridView.Columns["colBirthDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colAge", "�N��");
            dataGridView.Columns["colAge"].Width = 60;
            dataGridView.Columns["colAge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns.Add("colCurrentAddress", "���Z��");
            dataGridView.Columns["colCurrentAddress"].Width = 240;
            dataGridView.Columns.Add("colDeliveryDate", "��t�N����");
            dataGridView.Columns["colDeliveryDate"].Width = 120;
            dataGridView.Columns["colDeliveryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colExpirationDate", "�L������");
            dataGridView.Columns["colExpirationDate"].Width = 120;
            dataGridView.Columns["colExpirationDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colLicenseCondition", "������");
            dataGridView.Columns["colLicenseCondition"].Width = 200;
            dataGridView.Columns.Add("colLicenseNumber", "�Ƌ��ؔԍ�");
            dataGridView.Columns["colLicenseNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colGetDate1", "�񏬌��擾��");
            dataGridView.Columns["colGetDate1"].Width = 120;
            dataGridView.Columns["colGetDate1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colGetDate2", "���擾��");
            dataGridView.Columns["colGetDate2"].Width = 120;
            dataGridView.Columns["colGetDate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colGetDate3", "���擾��");
            dataGridView.Columns["colGetDate3"].Width = 120;
            dataGridView.Columns["colGetDate3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colLarge", "��^");
            dataGridView.Columns["colLarge"].Width = 70;
            dataGridView.Columns["colLarge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colMedium", "���^");
            dataGridView.Columns["colMedium"].Width = 70;
            dataGridView.Columns["colMedium"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colQuasiMedium", "�����^");
            dataGridView.Columns["colQuasiMedium"].Width = 70;
            dataGridView.Columns["colQuasiMedium"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colOrdinary", "����");
            dataGridView.Columns["colOrdinary"].Width = 70;
            dataGridView.Columns["colOrdinary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigSpecial", "���");
            dataGridView.Columns["colBigSpecial"].Width = 70;
            dataGridView.Columns["colBigSpecial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigAutoBike", "�厩��");
            dataGridView.Columns["colBigAutoBike"].Width = 70;
            dataGridView.Columns["colBigAutoBike"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colOrdinaryAutoBike", "������");
            dataGridView.Columns["colOrdinaryAutoBike"].Width = 70;
            dataGridView.Columns["colOrdinaryAutoBike"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colSmallSpecial", "����");
            dataGridView.Columns["colSmallSpecial"].Width = 70;
            dataGridView.Columns["colSmallSpecial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colWithARaw", "���t");
            dataGridView.Columns["colWithARaw"].Width = 70;
            dataGridView.Columns["colWithARaw"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigTwo", "��^��");
            dataGridView.Columns["colBigTwo"].Width = 70;
            dataGridView.Columns["colBigTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colMediumTwo", "���^��");
            dataGridView.Columns["colMediumTwo"].Width = 70;
            dataGridView.Columns["colMediumTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colOrdinaryTwo", "���ʓ�");
            dataGridView.Columns["colOrdinaryTwo"].Width = 70;
            dataGridView.Columns["colOrdinaryTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colBigSpecialTwo", "�����");
            dataGridView.Columns["colBigSpecialTwo"].Width = 70;
            dataGridView.Columns["colBigSpecialTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add("colTraction", "����");
            dataGridView.Columns["colTraction"].Width = 70;
            dataGridView.Columns["colTraction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return dataGridView;
        }

        /// <summary>
        /// �V�K�Ƌ��؂�o�^����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemNewLicense_Click(object sender, EventArgs e) {
            var licenseLedgerDetail = new LicenseDetail(_connectionVo, _listStaffMasterVo);
            licenseLedgerDetail.ShowDialog();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // �w�b�_�[��DoubleClick�����
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