using Common;

using Dao;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

using Vo;

namespace VehicleDispatchConvert {
    public partial class VehicleDispatchSimple : Form {
        private DateTime _operationDate;
        /*
         * NPOI
         */
        private IWorkbook _iWorkbook;
        private ISheet _iSheet;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;

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
                _iWorkbook = (HSSFWorkbook)WorkbookFactory.Create(new Directry().GetExcelDesktopPassXls("�z�ԓ���"));
                /*
                 * �V�[�g������V�[�g�擾
                 */
                _iSheet = _iWorkbook.GetSheet("�z�ԕ\");
            } else {
                MessageBox.Show("�f�X�N�g�b�v�Ɂh�z�ԓ���.xls�h�����݂��܂���B��蒼���ĉ�����", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            ConvertXls convertXls = new ConvertXls(_iWorkbook, _iSheet, _listSetMasterVo, _listCarMasterVo, _listStaffMasterVo);
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(_operationDate)) {
                convertXls.SetCellString(vehicleDispatchDetailVo);
            }
            try {
                using(var fileStream = new FileStream(new Directry().GetExcelDesktopPassXls("�z�ԓ���"), FileMode.Create))
                    _iWorkbook.Write(fileStream, true);
                MessageBox.Show("�����o�����������܂���");
                //�t�@�C���쐬���ɗ�O�����������ꍇ�̏���
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
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