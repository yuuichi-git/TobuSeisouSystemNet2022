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
         * Vo
         */
        private readonly SetMasterVo _setMasterVo;
        private readonly CarMasterVo _carMasterVo;
        private readonly StaffMasterVo _staffMasterVo;
        private readonly VehicleDispatchDetailVo _vehicleDispatchDetailVo;
        private readonly VehicleDispatchBodyVo _vehicleDispatchBodyCleanOfficeVo;
        private readonly VehicleDispatchBodyVo _vehicleDispatchBodyOfficeVo;
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

        private void PutSheetViewPaper() {
            // ���t
            var Japanese = new CultureInfo("ja-JP", true);
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewPaper.Cells["G3"].Text = DateTime.Now.ToString("gg y�NM��d��", Japanese);
            // ����
            SheetViewPaper.Cells["B6"].Text = _cleanOfficeName;





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