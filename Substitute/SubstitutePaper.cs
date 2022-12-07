using System.Globalization;

using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Substitute {
    public partial class SubstitutePaper : Form {
        private readonly ConnectionVo _connectionVo;
        private readonly InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchBodyCleanOfficeDao _vehicleDispatchBodyCleanOfficeDao;
        private VehicleDispatchBodyOfficeDao _vehicleDispatchBodyOfficeDao;
        /*
         * Vo
         */
        private readonly SetMasterVo _setMasterVo;
        private readonly List<CarMasterVo> _listCarMasterVo;
        private readonly List<StaffMasterVo> _listStaffMasterVo;
        private readonly VehicleDispatchDetailVo _vehicleDispatchDetailVo;
        private readonly VehicleDispatchBodyVo _vehicleDispatchBodyCleanOfficeVo;

        /*
         * ���|���������EFAX�ԍ�
         */
        private string _cleanOfficeName;
        private string _cleanOfficeFax;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="setCode"></param>
        public SubstitutePaper(ConnectionVo connectionVo, int setCode) {
            _connectionVo = connectionVo;

            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchBodyCleanOfficeDao = new VehicleDispatchBodyCleanOfficeDao(connectionVo);
            _vehicleDispatchBodyOfficeDao = new VehicleDispatchBodyOfficeDao(connectionVo);

            _vehicleDispatchDetailVo = new VehicleDispatchDetailDao(_connectionVo).SelectOneVehicleDispatchDetail(DateTime.Now.Date, setCode);

            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // �V�[�g�^�u���\��
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;
            // �z�Ԑ��Ǎ���
            _setMasterVo = new SetMasterDao(_connectionVo).SelectOneSetMaster(setCode);
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            /*
             * FAX�̈���EFAX�ԍ����Z�b�g
             */
            switch(setCode) {
                case 1310101: // ���c�Q
                case 1310102: // ���c�U
                case 1310103: // ���c���P
                    _cleanOfficeName = "�@�����^�A�@�l";
                    _cleanOfficeFax = string.Concat("���c��x��", "\r\n", "�e�`�w �O�R�|�R�U�V�W�|�Q�U�W�W");
                    break;
                case 1310201: // �����y�b�g�V
                case 1310202: // �����y�b�g�W
                    _cleanOfficeName = string.Concat("�@�����s���q�����Ƌ����g��", "\r\n", " �@������x���@�l");
                    _cleanOfficeFax = string.Concat("������x��", "\r\n", " �e�`�w �O�R�|�U�Q�W�O�|�T�W�S�P");
                    break;
                case 1312101: // �����P�W
                case 1312102: // �����Q�R
                case 1312103: // �����Q�S
                case 1312104: // �����R�W
                case 1312105: // �����s�R�S
                    _cleanOfficeName = "�@�������|�������@�䒆";
                    _cleanOfficeFax = string.Concat("�������|������", "\r\n", " �e�`�w �O�R�|�R�W�T�V�|�T�V�S�R");
                    break;
                case 1312204: // �����P�P
                case 1312201: // �����R�R
                case 1312202: // �����T�T
                    _cleanOfficeName = "�@�����搴�|�������@�䒆";
                    _cleanOfficeFax = string.Concat("�����搴�|�������i�V�h�����j", "\r\n", " �e�`�w �O�R�|�R�U�O�W�|�R�R�X�V");
                    break;
                case 1312203: // ����S
                    _cleanOfficeName = "�@���␴�|�������@�䒆";
                    _cleanOfficeFax = string.Concat("���␴�|������", "\r\n", " �e�`�w �O�R�|�R�U�V�R�|�Q�T�R�T");
                    break;
            }

            InitializeSheetViewPaper();
            PutSheetViewPaper();
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// PutSheetViewPaper
        /// </summary>
        private void PutSheetViewPaper() {
            // ���t
            var Japanese = new CultureInfo("ja-JP", true);
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewPaper.Cells["G3"].Text = DateTime.Now.ToString("gg y�NM��d��", Japanese);
            // ����
            SheetViewPaper.Cells["B6"].Text = _cleanOfficeName;
            /*
             * ���
             */
            // �@�܂��͔z�Ԑ悪�i�[����Ă���CellNumber���擾����
            int cellNumber = _vehicleDispatchDetailDao.GetCellNumber(_vehicleDispatchDetailVo.Set_code);
            // �A���|�������ɓo�^����Ă���{�Ԏԗ����擾����
            int carCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetCarCode(cellNumber);
            // �B��Ԃ̏���
            if(_vehicleDispatchDetailVo.Car_code != 0 && carCodeCleanOffice != _vehicleDispatchDetailVo.Car_code) {
                // �ύX�O �g�� �ԗ��i���o�[ �h�A�ԍ�
                SheetViewPaper.Cells["B29"].Text = _setMasterVo.Set_name_2;
                SheetViewPaper.Cells["C29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Registration_number;
                SheetViewPaper.Cells["F29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Door_number.ToString();
                // �ύX�� �ԗ��i���o�[ �h�A�ԍ�
                SheetViewPaper.Cells["H29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Registration_number;
                SheetViewPaper.Cells["L29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Door_number.ToString();
            }
            /*
             * ���
             */
            // �@���|�������ɓo�^����Ă���{��Oprator1���擾���� 
            int operatorCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetOperatorCode1(cellNumber);
            // �A�^�]���Ԃ̏���
            if(_vehicleDispatchDetailVo.Operator_code_1 != 0 && operatorCodeCleanOffice != _vehicleDispatchDetailVo.Operator_code_1) {
                // �ύX�O�@�g���@����
                SheetViewPaper.Cells["B38"].Text = string.Concat(_setMasterVo.Set_name_2, "�g");
                SheetViewPaper.Cells["D38"].Text = _listStaffMasterVo.Find(x => x.Staff_code == operatorCodeCleanOffice).Display_name;
                // �ύX��@�����@�g�єԍ�
                SheetViewPaper.Cells["I38"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Display_name;
                
                string telephoneNumber = "";
                switch(_vehicleDispatchDetailVo.Set_code) {
                    case 1310101: // ���c�Q
                        telephoneNumber = "090-6506-7967";
                        break;
                    case 1310102: // ���c�U
                        telephoneNumber = "080-8868-7459";
                        break;
                    case 1310103: // ���c���P
                        telephoneNumber = "080-8868-8023";
                        break;
                    case 1310201: // �����y�b�g�V
                        telephoneNumber = "080-2202-7713";
                        break;
                    case 1310202: // �����y�b�g�W
                        telephoneNumber = "080-3493-3729";
                        break;
                    case 1312101: // �����P�W
                        telephoneNumber = "�s��";
                        break;
                    case 1312102: // �����Q�R
                        telephoneNumber = "090-5560-0491";
                        break;
                    case 1312103: // �����Q�S
                        telephoneNumber = "090-5560-0677";
                        break;
                    case 1312104: // �����R�W
                        telephoneNumber = "090-5560-0700";
                        break;
                    case 1312105: // �����s�R�S
                        telephoneNumber = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Telephone_number;
                        break;
                    case 1312204: // �����P�P
                        telephoneNumber = "090-9817-8129";
                        break;
                    case 1312201: // �����R�R
                        telephoneNumber = "080-3493-3728";
                        break;
                    case 1312202: // �����T�T
                        telephoneNumber = "080-2202-7269";
                        break;
                    case 1312203: // ����S
                        telephoneNumber = "�s��";
                        break;
                }
                SheetViewPaper.Cells["I40"].Text = telephoneNumber;


            }


            // FAX�ԍ���
            SheetViewPaper.Cells["H51"].Text = _cleanOfficeFax;
        }

        private void InitializeSheetViewPaper() {
            // �쐬���t
            SheetViewPaper.Cells["G3"].ResetValue();
            // �����
            SheetViewPaper.Cells["B6"].ResetValue();
            /*
             * ���
             */
            // �P�s��
            SheetViewPaper.Cells["B29"].ResetValue();
            SheetViewPaper.Cells["C29"].ResetValue();
            SheetViewPaper.Cells["F29"].ResetValue();
            SheetViewPaper.Cells["H29"].ResetValue();
            SheetViewPaper.Cells["L29"].ResetValue();
            // �Q�s��
            SheetViewPaper.Cells["B31"].ResetValue();
            SheetViewPaper.Cells["C31"].ResetValue();
            SheetViewPaper.Cells["F31"].ResetValue();
            SheetViewPaper.Cells["H31"].ResetValue();
            SheetViewPaper.Cells["L31"].ResetValue();
            /*
             * ���
             */
            // �P�s��
            SheetViewPaper.Cells["B38"].ResetValue(); // �g
            SheetViewPaper.Cells["D38"].ResetValue(); // �{�Ԏ���
            SheetViewPaper.Cells["I38"].ResetValue(); // ��Ԏ���
            SheetViewPaper.Cells["I40"].ResetValue(); // ��Ԍg�єԍ�
            // �Q�s��
            SheetViewPaper.Cells["B42"].ResetValue(); // �g
            SheetViewPaper.Cells["D42"].ResetValue(); // �{�Ԏ���
            SheetViewPaper.Cells["I42"].ResetValue(); // ��Ԏ���
            SheetViewPaper.Cells["I44"].ResetValue(); // ��Ԍg�єԍ�
            // �R�s��
            SheetViewPaper.Cells["B46"].ResetValue(); // �g
            SheetViewPaper.Cells["D46"].ResetValue(); // �{�Ԏ���
            SheetViewPaper.Cells["I46"].ResetValue(); // ��Ԏ���
            SheetViewPaper.Cells["I48"].ResetValue(); // ��Ԍg�єԍ�
            // �����
            SheetViewPaper.Cells["H51"].ResetValue();
        }

        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadPaper.PrintSheet(SheetViewPaper);
        }
    }
}