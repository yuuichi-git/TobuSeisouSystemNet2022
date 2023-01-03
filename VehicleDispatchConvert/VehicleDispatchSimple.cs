using Common;

using Dao;

using NPOI.SS.UserModel;

using Vo;

namespace VehicleDispatchConvert {
    public partial class VehicleDispatchSimple : Form {
        private DateTime _operationDate;
        /*
         * NPOI
         * https://teratail.com/questions/338753
         */
        private IWorkbook _iWorkbook;
        private ISheet _iSheet_1;
        private ISheet _iSheet_2; // �A�ɓ_�ẴV�[�g
        private ISheet _iSheet_3; // �{��
        private ISheet _iSheet_4; // �O��
        private ISheet _iSheet_5; // �A���o�C�g�̏o�Ώ�
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;
        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="operationDate"></param>
        public VehicleDispatchSimple(ConnectionVo connectionVo, DateTime operationDate) {
            _operationDate = operationDate;
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchDetailCarDao = new VehicleDispatchDetailCarDao(connectionVo);
            _vehicleDispatchDetailStaffDao = new VehicleDispatchDetailStaffDao(connectionVo);
            /*
             * Vo
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();

            if(File.Exists(new Directry().GetExcelDesktopPassXls("�z�ԓ���"))) {
                /*
                 * �u�b�N�ǂݍ��� new Directry().GetExcelDesktopPass(fileName)
                 */
                _iWorkbook = WorkbookFactory.Create(new Directry().GetExcelDesktopPassXls("�z�ԓ���"));
                /*
                 * �V�[�g������V�[�g�擾
                 */
                _iSheet_1 = _iWorkbook.GetSheet("�z�ԕ\");
                _iSheet_2 = _iWorkbook.GetSheet("�A�ɓ_��");
                _iSheet_3 = _iWorkbook.GetSheet("�{��");
                _iSheet_4 = _iWorkbook.GetSheet("�O��");
                _iSheet_5 = _iWorkbook.GetSheet("�A���o�C�g�o�Ώ�");
                /*
                 * �Čv�Z�t���O
                 */
                _iSheet_1.ForceFormulaRecalculation = true;
                _iSheet_2.ForceFormulaRecalculation = true;
                _iSheet_3.ForceFormulaRecalculation = true;
                _iSheet_4.ForceFormulaRecalculation = true;
                _iSheet_5.ForceFormulaRecalculation = true;
            } else {
                MessageBox.Show("�f�X�N�g�b�v�Ɂh�z�ԓ���.xls�h�����݂��܂���B��蒼���ĉ�����", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception();
            }

            InitializeComponent();
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
            /*
             * �_�Ď��s�҂��I������Ă��邩���`�F�b�N����
             */
            if(ComboBox1.Text.Length > 0 && ComboBox2.Text.Length != 0 && ComboBox3.Text.Length != 0) {
                string[] arrayTenkoName = new string[]{ ComboBox1.Text, ComboBox2.Text, ComboBox3.Text};
                ConvertXls convertXls = new ConvertXls(_iWorkbook, _iSheet_1, _listSetMasterVo, _listCarMasterVo, _listStaffMasterVo, arrayTenkoName);
                foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(_operationDate)) {
                    convertXls.SetCellString(vehicleDispatchDetailVo);
                }
                try {
                    var fileStream = new FileStream(new Directry().GetExcelDesktopPassXls("�z�ԓ���"), FileMode.Open);
                    _iWorkbook.Write(fileStream, false);
                    MessageBox.Show("�����o�����������܂���");
                } catch(Exception exception) { //�t�@�C���쐬���ɗ�O�����������ꍇ�̏���
                    MessageBox.Show(exception.Message);
                }
            } else {
                MessageBox.Show("�_�Ď��s�҂�I�����ĉ�����", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// VehicleDispatchSimple_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchSimple_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}