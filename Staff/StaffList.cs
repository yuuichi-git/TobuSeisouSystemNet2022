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

        Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "����" }, { 11, "�Ј�" }, { 12, "�A���o�C�g" }, { 20, "�V�^�]" }, { 21, "���^�J" } };
        Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "�����ٗp" }, { 11, "�蒠" }, { 12, "�A���o�C�g" }, { 99, "" } };
        Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "�^�]��" }, { 11, "��ƈ�" }, { 99, "" } };

        // SPREAD��Column�̔ԍ�
        /// <summary>
        /// ����
        /// </summary>
        private const int colBelongs = 0;
        /// <summary>
        /// �`��
        /// </summary>
        private const int colJobForm = 1;
        /// <summary>
        /// �E��
        /// </summary>
        private const int colOccupation = 2;
        /// <summary>
        /// �z�Ԃ̑Ώۂ��ǂ���
        /// </summary>
        private const int colVehicleDispatchTarget = 3;
        /// <summary>
        /// <summary>
        /// �Ј�CD
        /// </summary>
        private const int colStaffCode = 4;
        /// <summary>
        /// ����
        /// </summary>
        private const int colName = 5;
        /// <summary>
        /// �J�i
        /// </summary>
        private const int colNameKana = 6;
        /// <summary>
        /// ����
        /// </summary>
        private const int colToukanpoCard = 7;
        /// <summary>
        /// �Ƌ���
        /// </summary>
        private const int colLicense = 8;
        /// <summary>
        /// �Ƌ��؊���
        /// </summary>
        private const int colLicensExpirationDate = 9;
        /// <summary>
        /// �ʋΓ�
        /// </summary>
        private const int colCommutingNotification = 10;
        /// <summary>
        /// �C�ӕی��I���N����
        /// </summary>
        private const int colMeansOfCommutingEndDate = 11;
        /// <summary>
        /// ���N����
        /// </summary>
        private const int colBirthDate = 12;
        /// <summary>
        /// �N��
        /// </summary>
        private const int colFullAge = 13;
        /// <summary>
        /// �ٗp�N����
        /// </summary>
        private const int colEmploymentDate = 14;
        /// <summary>
        /// �Α��N��
        /// </summary>
        private const int colServiceDate = 15;
        /// <summary>
        /// ���C
        /// </summary>
        private const int colFirstTerm = 16;
        /// <summary>
        /// �K��
        /// </summary>
        private const int colSuitableAge = 17;
        /// <summary>
        /// ���̌���
        /// </summary>
        private const int colCarAccidentCount = 18;
        /// <summary>
        /// �P�N�ȓ��̌��N�f�f
        /// </summary>
        private const int colMedicalExaminationDate = 19;
        /// <summary>
        /// ���Z��
        /// </summary>
        private const int colCurrentAddress = 20;
        /// <summary>
        /// ���N�ی�
        /// </summary>
        private const int colHealthInsuranceNumber = 21;
        /// <summary>
        /// �����N��
        /// </summary>
        private const int colWelfarePensionNumber = 22;
        /// <summary>
        /// �ٗp�ی�
        /// </summary>
        private const int colEmploymentInsuranceNumber = 23;
        /// <summary>
        /// �J�Еی�
        /// </summary>
        private const int colWorkerAccidentInsuranceNumber = 24;

        public StaffList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * �R���g���[����������
             */
            InitializeComponent();
            _initializeForm.StaffList(this);

            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listFindAllStaffMasterVo = null;
            _linqStaffMasterVo = null;

            // ���̌����W�v�̊�ƂȂ�N�x��������
            ComboBoxAccidentYear.Text = "2022�N�x";
            // FpSpread��������
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
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            _listFindAllStaffMasterVo = TabControlExStaff.SelectedTab.Tag switch {
                "�A" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�A") || x.Name_kana.StartsWith("�C") || x.Name_kana.StartsWith("�E") || x.Name_kana.StartsWith("�G") || x.Name_kana.StartsWith("�I")),
                "�J" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�J") || x.Name_kana.StartsWith("�K") || x.Name_kana.StartsWith("�L") || x.Name_kana.StartsWith("�M") || x.Name_kana.StartsWith("�N") || x.Name_kana.StartsWith("�P") || x.Name_kana.StartsWith("�R") || x.Name_kana.StartsWith("�S")),
                "�T" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�T") || x.Name_kana.StartsWith("�V") || x.Name_kana.StartsWith("�X") || x.Name_kana.StartsWith("�Z") || x.Name_kana.StartsWith("�\")),
                "�^" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�^") || x.Name_kana.StartsWith("�`") || x.Name_kana.StartsWith("�c") || x.Name_kana.StartsWith("�e") || x.Name_kana.StartsWith("�f") || x.Name_kana.StartsWith("�g") || x.Name_kana.StartsWith("�h")),
                "�i" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�i") || x.Name_kana.StartsWith("�j") || x.Name_kana.StartsWith("�k") || x.Name_kana.StartsWith("�l") || x.Name_kana.StartsWith("�m")),
                "�n" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�n") || x.Name_kana.StartsWith("�p") || x.Name_kana.StartsWith("�q") || x.Name_kana.StartsWith("�r") || x.Name_kana.StartsWith("�t") || x.Name_kana.StartsWith("�u") || x.Name_kana.StartsWith("�w") || x.Name_kana.StartsWith("�x") || x.Name_kana.StartsWith("�z")),
                "�}" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("�}") || x.Name_kana.StartsWith("�~") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                "��" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                "��" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                "��" => _listStaffMasterVo.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                _ => _listStaffMasterVo,
            };

            // ����
            if (!CheckBoxOfficer.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 10);
            // �Ј�
            if (!CheckBoxCompanyEmployee.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 11);
            // �A���o�C�g
            if (!CheckBoxPartTimeJob.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 12);
            // �V�^�]
            if (!CheckBoxSinunten.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 20);
            // ���^�J
            if (!CheckBoxJiunrou.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Belongs != 21);
            // ����
            if (!CheckBoxFullTimeJob.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 10);
            // �蒠
            if (!CheckBoxNoteBook.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 11);
            // �A���o�C�g
            if (!CheckBoxPartTime.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 12);
            // �^�]��
            if (!CheckBoxDriver.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Occupation != 10);
            // ��ƈ�
            if (!CheckBoxWorkStaff.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Occupation != 11);
            // �w��Ȃ�
            if (!CheckBoxNone.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Occupation != 99);
            // �ސE��
            if (!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo.FindAll(x => x.Retirement_flag != true);
            // �\�[�g
            _linqStaffMasterVo = _listFindAllStaffMasterVo.OrderBy(x => x.Name_kana);

            int i = 0;
            foreach (var staffMasterVo in _linqStaffMasterVo) {
                // ����
                var _belongs = staffMasterVo.Belongs;
                // �`��
                var _jobForm = staffMasterVo.Job_form;
                // �E��
                var _occupation = staffMasterVo.Occupation;
                // �z�ԑΏ�
                var _vehicleDispatchTarget = staffMasterVo.Vehicle_dispatch_target;
                // �g��CD
                var _code = staffMasterVo.Code;
                // ����
                var _name = staffMasterVo.Name;
                // �J�i
                var _name_kana = staffMasterVo.Name_kana;
                // ���N�����E�N��
                DateTime? _birth_date = null;
                string _age = "";
                if (staffMasterVo.Birth_date != _defaultDateTime) {
                    _birth_date = staffMasterVo.Birth_date.Date;
                    // �N��
                    _age = string.Concat(new Date().GetStaffAge(staffMasterVo.Birth_date.Date), "��");
                }
                // �ٗp�N����
                DateTime? _employment_date = null;
                if (staffMasterVo.Employment_date != _defaultDateTime) {
                    _employment_date = staffMasterVo.Employment_date.Date;
                }
                // �Α�
                string _service_date = "";
                if (staffMasterVo.Employment_date != _defaultDateTime) {
                    _service_date = string.Concat(new Date().GetEmploymenteYear(staffMasterVo.Employment_date.Date).ToString("#0�N"), new Date().GetEmploymenteMonth(staffMasterVo.Employment_date.Date).ToString("00��"));
                }
                // ���C
                string _proper_kind_syonin = "";
                if (staffMasterVo.Proper_kind_1 == "���C�f�f" || staffMasterVo.Proper_kind_2 == "���C�f�f" || staffMasterVo.Proper_kind_3 == "���C�f�f")
                    _proper_kind_syonin = "�Z";
                // �K��
                string _proper_kind_tekirei = "";
                var timeSpan = new TimeSpan(0, 0, 0, 0);

                if (staffMasterVo.Proper_kind_1 == "�K��f�f" || staffMasterVo.Proper_kind_2 == "�K��f�f" || staffMasterVo.Proper_kind_3 == "�K��f�f") {
                    if (staffMasterVo.Proper_kind_1 == "�K��f�f") {
                        timeSpan = staffMasterVo.Proper_date_1.AddYears(3) - DateTime.Now.Date;
                    } else if (staffMasterVo.Proper_kind_2 == "�K��f�f") {
                        timeSpan = staffMasterVo.Proper_date_2.AddYears(3) - DateTime.Now.Date;
                    } else if (staffMasterVo.Proper_kind_3 == "�K��f�f") {
                        timeSpan = staffMasterVo.Proper_date_3.AddYears(3) - DateTime.Now.Date;
                    }
                    _proper_kind_tekirei = string.Concat(timeSpan.Days, "����");
                }
                // ���Z��
                var _current_address = staffMasterVo.Current_address;
                // ���N�ی�
                var _health_insurance_number = staffMasterVo.Health_insurance_number == "" ? null : "�Z";
                // �����N��  
                var _welfare_pension_number = staffMasterVo.Welfare_pension_number == "" ? null : "�Z";
                // �ٗp�ی�   
                var _employment_insurance_number = staffMasterVo.Employment_insurance_number == "" ? null : "�Z";
                // �J�Еی�   
                var _worker_accident_insurance_number = staffMasterVo.Worker_accident_insurance_number == "" ? null : "�Z";

                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].ForeColor = staffMasterVo.Retirement_flag ? Color.Red : Color.Black; // �ސE�ς̃��R�[�h��ForeColor���Z�b�g
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~
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
            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " ��");
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // �V�[�g�^�u���\��
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 28; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 50; // �s�w�b�_�̕���ύX���܂�
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