using System.ComponentModel;

using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using LicenseLedger;

using Vo;

namespace Staff {
    public partial class StaffList : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private List<ExtendsStaffMasterVo>? _listExtendsStaffMasterVo;
        private List<ExtendsStaffMasterVo>? _listFindAllStaffMasterVo;
        private IOrderedEnumerable<ExtendsStaffMasterVo>? _linqExtendsStaffMasterVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        private readonly Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "����" }, { 11, "�Ј�" }, { 12, "�A���o�C�g" }, { 20, "�V�^�]" }, { 21, "���^�J" } };
        private readonly Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "�����ٗp" }, { 11, "�蒠" }, { 12, "�A���o�C�g" }, { 99, "" } };
        private readonly Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "�^�]��" }, { 11, "��ƈ�" }, { 99, "" } };

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
        private const int colCode = 4;
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

            _listExtendsStaffMasterVo = null;
            _listFindAllStaffMasterVo = null;
            _linqExtendsStaffMasterVo = null;

            // ���̌����W�v�̊�ƂȂ�N�x��������
            ComboBoxAccidentYear.Text = "2022�N�x";
            // FpSpread��������
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = "";
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            _listExtendsStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllExtendsStaffMasterVo();
            SheetViewListOutPut();
        }

        /// <summary>
        /// TabControlEx1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlEx1_Click(object sender, EventArgs e) {
            if(_listFindAllStaffMasterVo != null)
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
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            _listFindAllStaffMasterVo = TabControlExStaff.SelectedTab.Tag switch {
                "�A" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�A") || x.Name_kana.StartsWith("�C") || x.Name_kana.StartsWith("�E") || x.Name_kana.StartsWith("�G") || x.Name_kana.StartsWith("�I")),
                "�J" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�J") || x.Name_kana.StartsWith("�K") || x.Name_kana.StartsWith("�L") || x.Name_kana.StartsWith("�M") || x.Name_kana.StartsWith("�N") || x.Name_kana.StartsWith("�P") || x.Name_kana.StartsWith("�R") || x.Name_kana.StartsWith("�S")),
                "�T" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�T") || x.Name_kana.StartsWith("�V") || x.Name_kana.StartsWith("�X") || x.Name_kana.StartsWith("�Z") || x.Name_kana.StartsWith("�\")),
                "�^" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�^") || x.Name_kana.StartsWith("�`") || x.Name_kana.StartsWith("�c") || x.Name_kana.StartsWith("�e") || x.Name_kana.StartsWith("�f") || x.Name_kana.StartsWith("�g") || x.Name_kana.StartsWith("�h")),
                "�i" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�i") || x.Name_kana.StartsWith("�j") || x.Name_kana.StartsWith("�k") || x.Name_kana.StartsWith("�l") || x.Name_kana.StartsWith("�m")),
                "�n" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�n") || x.Name_kana.StartsWith("�p") || x.Name_kana.StartsWith("�q") || x.Name_kana.StartsWith("�r") || x.Name_kana.StartsWith("�t") || x.Name_kana.StartsWith("�u") || x.Name_kana.StartsWith("�w") || x.Name_kana.StartsWith("�x") || x.Name_kana.StartsWith("�z")),
                "�}" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("�}") || x.Name_kana.StartsWith("�~") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                "��" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                "��" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                "��" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��") || x.Name_kana.StartsWith("��")),
                _ => _listExtendsStaffMasterVo,
            };

            // ����
            if(!CheckBoxOfficer.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Belongs != 10); // ����
            // �Ј�
            if(!CheckBoxCompanyEmployee.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Belongs != 11); // �Ј�
            // �A���o�C�g
            if(!CheckBoxPartTimeJob1.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Belongs != 12); // �A���o�C�g
            // �V�^�]
            if(!CheckBoxSinunten.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Belongs != 20); // �V�^�]
            // ���^�J
            if(!CheckBoxJiunrou.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Belongs != 21); // ���^�J
            // ����
            if(!CheckBoxFullTimeJob.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 10); // �J���Œ���
            // �蒠
            if(!CheckBoxNoteBook.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 11); // �J���Ŏ蒠
            // �A���o�C�g
            if(!CheckBoxPartTimeJob2.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form != 12); //�@�J���ŃA���o�C�g
            // �w��Ȃ�
            if(!CheckBoxNone1.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Job_form != 99);
            // �^�]��
            if(!CheckBoxDriver.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Occupation != 10); // �^�]��
            // ��ƈ�
            if(!CheckBoxWorkStaff.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Occupation != 11); // ��ƈ�
            // �w��Ȃ�
            if(!CheckBoxNone2.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Occupation != 99); // �w��Ȃ�
            // �ސE��
            if(!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Retirement_flag != true);
            // �\�[�g
            _linqExtendsStaffMasterVo = _listFindAllStaffMasterVo?.OrderBy(x => x.Name_kana);

            int i = 0;
            if(_linqExtendsStaffMasterVo is not null)
                foreach(var extendsStaffMasterVo in _linqExtendsStaffMasterVo) {
                    // ����
                    var _belongs = extendsStaffMasterVo.Belongs;
                    // �`��
                    var _jobForm = extendsStaffMasterVo.Job_form;
                    // �E��
                    var _occupation = extendsStaffMasterVo.Occupation;
                    // �z�ԑΏ�
                    var _vehicleDispatchTarget = extendsStaffMasterVo.Vehicle_dispatch_target;
                    // �g��CD
                    var _code = extendsStaffMasterVo.Code;
                    // ����
                    var _name = extendsStaffMasterVo.Name;
                    // �J�i
                    var _name_kana = extendsStaffMasterVo.Name_kana;
                    // ����
                    var _toukanpoTrainingCardFlag = extendsStaffMasterVo.ToukanpoTrainingCardFlag;
                    // �Ƌ���
                    bool _licenseLedgerFlag = false;
                    DateTime? _licenseLedgerExpirationDate = null;
                    if(extendsStaffMasterVo?.LicenseNumber?.Length > 0) {
                        // �Ƌ���
                        _licenseLedgerFlag = true;
                        // �Ƌ��؊���
                        _licenseLedgerExpirationDate = extendsStaffMasterVo.LicenseMasterExpirationDate.Date;
                    }
                    // �ʋΓ�
                    var _commutingNotificationFlag = extendsStaffMasterVo?.CommutingNotification;
                    // �C�ӕی��I���N����
                    DateTime? _meansOfCommutingEndDate = null;
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.CommutingNotification) {
                        if(extendsStaffMasterVo.CommuterInsuranceEndDate.Date != _defaultDateTime.Date)
                            _meansOfCommutingEndDate = extendsStaffMasterVo.CommuterInsuranceEndDate.Date;
                    } else {
                        _meansOfCommutingEndDate = null;
                    }
                    // ���N�����E�N��
                    DateTime? _birth_date = null;
                    string _age = "";
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.Birth_date != _defaultDateTime) {
                        _birth_date = extendsStaffMasterVo.Birth_date.Date;
                        // �N��
                        _age = string.Concat(new Date().GetStaffAge(extendsStaffMasterVo.Birth_date.Date), "��");
                    }
                    // �ٗp�N����
                    DateTime? _employment_date = null;
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.Employment_date != _defaultDateTime) {
                        _employment_date = extendsStaffMasterVo.Employment_date.Date;
                    }
                    // �Α�
                    string _service_date = "";
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.Employment_date != _defaultDateTime) {
                        _service_date = string.Concat(new Date().GetEmploymenteYear(extendsStaffMasterVo.Employment_date.Date).ToString("#0�N"), new Date().GetEmploymenteMonth(extendsStaffMasterVo.Employment_date.Date).ToString("00��"));
                    }
                    // ���C
                    DateTime? _proper_kind_syonin = null;
                    if(extendsStaffMasterVo?.Proper_kind_1 == "���C�f�f")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_1;
                    if(extendsStaffMasterVo?.Proper_kind_2 == "���C�f�f")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_2;
                    if(extendsStaffMasterVo?.Proper_kind_3 == "���C�f�f")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_3;
                    // �K��
                    string _proper_kind_tekirei = "";
                    var timeSpan = new TimeSpan(0, 0, 0, 0);

                    if(extendsStaffMasterVo is not null && (extendsStaffMasterVo.Proper_kind_1 == "�K��f�f" || extendsStaffMasterVo.Proper_kind_2 == "�K��f�f" || extendsStaffMasterVo.Proper_kind_3 == "�K��f�f")) {
                        if(extendsStaffMasterVo.Proper_kind_1 == "�K��f�f") {
                            timeSpan = extendsStaffMasterVo.Proper_date_1.AddYears(3) - DateTime.Now.Date;
                        } else if(extendsStaffMasterVo.Proper_kind_2 == "�K��f�f") {
                            timeSpan = extendsStaffMasterVo.Proper_date_2.AddYears(3) - DateTime.Now.Date;
                        } else if(extendsStaffMasterVo.Proper_kind_3 == "�K��f�f") {
                            timeSpan = extendsStaffMasterVo.Proper_date_3.AddYears(3) - DateTime.Now.Date;
                        }
                        _proper_kind_tekirei = string.Concat(timeSpan.Days, "����");
                    }
                    // ���̐�
                    string _car_accident_count = "";
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.CarAccidentMasterCount != 0) {
                        _car_accident_count = string.Concat(extendsStaffMasterVo.CarAccidentMasterCount, "��");
                    }
                    // ���Z��
                    var _current_address = extendsStaffMasterVo?.Current_address;
                    // ���N�ی�
                    var _health_insurance_number = extendsStaffMasterVo?.Health_insurance_number != "" ? true : false;
                    // �����N��  
                    var _welfare_pension_number = extendsStaffMasterVo?.Welfare_pension_number != "" ? true : false;
                    // �ٗp�ی�   
                    var _employment_insurance_number = extendsStaffMasterVo?.Employment_insurance_number != "" ? true : false;
                    // �J�Еی�   
                    var _worker_accident_insurance_number = extendsStaffMasterVo?.Worker_accident_insurance_number != "" ? true : false;

                    SheetViewList.Rows.Add(i, 1);
                    SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                    SheetViewList.Rows[i].ForeColor = extendsStaffMasterVo is not null && extendsStaffMasterVo.Retirement_flag ? Color.Red : Color.Black; // �ސE�ς̃��R�[�h��ForeColor���Z�b�g
                    SheetViewList.Rows[i].Height = 22; // Row�̍���
                    SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~
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
                    SheetViewList.Cells[i, colLicensExpirationDate].Value = _licenseLedgerExpirationDate; // �Ƌ��؊���
                    SheetViewList.Cells[i, colCommutingNotification].Value = _commutingNotificationFlag; // 2022/05/24 �ʋΓ�
                    SheetViewList.Cells[i, colMeansOfCommutingEndDate].Value = _meansOfCommutingEndDate; // 2022/05/24 �C�ӕی��I���N����
                    SheetViewList.Cells[i, colBirthDate].Value = _birth_date;
                    SheetViewList.Cells[i, colFullAge].Value = _age;
                    SheetViewList.Cells[i, colEmploymentDate].Value = _employment_date;
                    SheetViewList.Cells[i, colServiceDate].Value = _service_date;
                    SheetViewList.Cells[i, colFirstTerm].Value = _proper_kind_syonin;
                    SheetViewList.Cells[i, colSuitableAge].Value = _proper_kind_tekirei;
                    SheetViewList.Cells[i, colCarAccidentCount].Value = _car_accident_count;
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
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // �w�b�_�[��DoubleClick�����
            if(e.ColumnHeader)
                return;
            // Shift�������ꂽ�ꍇ
            if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                var staffRegisterPaper = new StaffPaper(_connectionVo, ((ExtendsStaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).Staff_code);
                staffRegisterPaper.ShowDialog();
                return;
            }
            // �C���L�[�������ꍇ
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
        /// ToolStripMenuItemExcelExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExcelExport_Click(object sender, EventArgs e) {
            //xlsx�`���t�@�C�����G�N�X�|�[�g���܂�
            string fileName = string.Concat("�]���҃��X�g", DateTime.Now.ToString("MM��dd��"), "�쐬");
            SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
            MessageBox.Show("�f�X�N�g�b�v�փG�N�X�|�[�g���܂���", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ContextMenuStrip1_Opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            /*
             * SheetView��Row�������ꍇ��ARow���I������Ă��Ȃ��ꍇ��Return����
             */
            if(SheetViewList.RowCount < 1 || !SheetViewList.IsBlockSelected) {
                e.Cancel = true;
                return;
            }

            var spreadList = (FpSpread)((ContextMenuStrip)sender).SourceControl;
            var cellRange = spreadList.ActiveSheet.GetSelections();
            /*
             * �Ƌ���
             */
            if(cellRange[0].RowCount == 1) {
                var license = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colLicense].Value;
                if((bool)license) {
                    ToolStripMenuItemLicense.Enabled = true;
                } else {
                    ToolStripMenuItemLicense.Enabled = false;
                }
            } else {
                ToolStripMenuItemLicense.Enabled = false;
            }
            /*
             * ����
             */
            if(cellRange[0].RowCount == 1) {
                var toukanpoCard = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colToukanpoCard].Value;
                if((bool)toukanpoCard) {
                    ToolStripMenuItemToukanpo.Enabled = true;
                } else {
                    ToolStripMenuItemToukanpo.Enabled = false;
                }
            } else {
                ToolStripMenuItemLicense.Enabled = false;
            }
            /*
             * �n�}��\������
             */
            if(cellRange[0].RowCount == 1) {
                var currentAddress = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCurrentAddress].Text;
                if(!string.IsNullOrEmpty(currentAddress)) {
                    ToolStripMenuItemMap.Enabled = true;
                } else {
                    ToolStripMenuItemMap.Enabled = false;
                }
            } else {
                ToolStripMenuItemMap.Enabled = false;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                /*
                 * �Ƌ��؂�\��
                 */
                case "ToolStripMenuItemLicense":
                    var staffCode = ((ExtendsStaffMasterVo)SheetViewList.Cells[SheetViewList.ActiveRowIndex, colName].Tag).Staff_code;
                    var licenseMasterPicture = new LicenseCard(_connectionVo, staffCode);
                    licenseMasterPicture.ShowDialog();
                    break;
                /*
                 * ���ۏC���؂�\��
                 */
                case "ToolStripMenuItemToukanpo":

                    break;
                /*
                 * �n�}��\��
                 */
                case "ToolStripMenuItemMap":
                    var currentAddress = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCurrentAddress].Text;
                    new Maps().MapOpen(currentAddress);
                    break;
            }
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