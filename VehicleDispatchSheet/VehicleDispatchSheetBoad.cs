using Common;

using Dao;

using FarPoint.Win.Spread;

using GrapeCity.Spreadsheet;

using Vo;


namespace VehicleDispatchSheet {
    public partial class VehicleDispatchSheetBoad : Form {
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        /*
         * ������
         */
        private InitializeForm _initializeForm = new();
        private EntryCellPosition? _entryCellPosition;
        private string _beforeBlockName = string.Empty;
        /// <summary>
        /// Row�̃X�^�[�g�ʒu
        /// </summary>
        private int _startRow = 4;
        /// <summary>
        /// Column�̃X�^�[�g�ʒu
        /// </summary>
        readonly Dictionary<int, int> _dictionaryColNumber = new Dictionary<int, int> { { 0, 0 },{ 1, 26 } };
        /// <summary>
        /// Row�̍ő吔
        /// Sheet���������ĂˁI
        /// </summary>
        readonly int _rowMax = 75;
        /// <summary>
        /// �z�Ԑ�̕ʖ�
        /// </summary>
        private Dictionary<int, string> dictionaryWordCode = new Dictionary<int, string> { { 13101, "���c��" },
                                                                                           { 13102, "������" },
                                                                                           { 13103, "�`��" },
                                                                                           { 13104, "�V�h��" },
                                                                                           { 13105, "������" },
                                                                                           { 13106, "�䓌��" },
                                                                                           { 13107, "�n�c��" },
                                                                                           { 13108, "�]����" },
                                                                                           { 13109, "�i���" },
                                                                                           { 13110, "�ڍ���" },
                                                                                           { 13111, "��c��" },
                                                                                           { 13112, "���c�J��" },
                                                                                           { 13113, "�a�J��" },
                                                                                           { 13114, "�����" },
                                                                                           { 13115, "������" },
                                                                                           { 13116, "�L����" },
                                                                                           { 13117, "�k��" },
                                                                                           { 13118, "�r���" },
                                                                                           { 13119, "����" },
                                                                                           { 13120, "���n��" },
                                                                                           { 13121, "������" },
                                                                                           { 13122, "������" },
                                                                                           { 13123, "�]�ː��" } };
        private Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "" }, { 11, "" }, { 12, "�o" }, { 20, "�V" }, { 21, "��" } };
        private Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "" }, { 11, "��" }, { 99, "" } };

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public VehicleDispatchSheetBoad(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchDetailCarDao = new VehicleDispatchDetailCarDao(connectionVo);
            _vehicleDispatchDetailStaffDao = new VehicleDispatchDetailStaffDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchSheet(this);
            /*
             * SPREAD������
             */
            SpreadBase.StatusBarVisible = true;
            /*
             * ���t
             */
            // ���t��������
            UcDateTimeJpOperationDate.SetValue(DateTime.Now);
            // �ǎ���p
            UcDateTimeJpOperationDate.SetReadOnly(true);
            ToolStripStatusLabelStatus.Text = string.Empty;
            ToolStripStatusLabelPosition.Text = string.Empty;
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
            EntryCellPosition? entryCellPosition;
            int blockRowCount;

            SpreadBase.SuspendLayout();
            /*
             * 10:���f�@��@���@���R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 10) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���f�@��@���@���R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 11:���f�@��@���v���R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 11) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���f�@��@���v���R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 12:���f�@��@�V����R�[�h�F2
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 12) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���f�@��@�V����R�[�h�F2";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 13:���f�@��@�y���_���v�R�[�h�F51
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 13) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���f�@��@�y���_���v�R�[�h�F51";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 14:���f�@��@�y���^�ݕ��R�[�h�F11
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 14) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���f�@��@�y���^�ݕ��R�[�h�F11";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 15:����@�_�@�y���^�ݕ��R�[�h�F11
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 15) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����@�_�@�y���^�ݕ��R�[�h�F11";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 16:����@�_�@���v���R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 16) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����@�_�@���v���R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 17:����@�_�@���v�� �R�[�h�F23
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 17) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����@�_�@���v�� �R�[�h�F23";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 18:����@�_�@���v���R�[�h�F8
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 18) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����@�_�@���v���R�[�h�F8";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 19:����@�_�@���{�f�B�R�[�h�F15
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 19) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����@�_�@���{�f�B�R�[�h�F15";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 20:����@�_�@���@�f�R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 20) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����@�_�@���@�f�R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 21:���f�@��@��@�f�R�[�h�F5
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 21) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���f�@��@��@�f�R�[�h�F5";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 22:���Ձ@���@���v�����R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "���v") {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���Ձ@���@���v�����R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);

                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 23:���Ձ@���@�ف@��@�V����R�[�h�F2
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "�V��") {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���Ձ@���@�ف@��@�V����R�[�h�F2";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 24:���Ձ@���@�ف@��@�y���^�ݕ��R�[�h�F11
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "�y����") {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���Ձ@���@�ف@��@�y���^�ݕ��R�[�h�F11";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 25:���Ձ@���@��@�_�@���{�f�B�R�[�h�F15�@
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "���{") {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���Ձ@���@��@�_�@���{�f�B�R�[�h�F15";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 26:����p�E�Y�p�y���i���o�[�z �R�[�h�F12
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 26) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����p�E�Y�p�y���i���o�[�z �R�[�h�F12";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 27:����p�E�Y�p�y�c�ƃi���o�[�z �R�[�h�F12
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 27) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "����p�E�Y�p�y�c�ƃi���o�[�z �R�[�h�F12";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 28:���������ځE�}�C���Y�E�������|�@���y���i���o�[�z �R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 28) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���������ځE�}�C���Y�E�������|�@���y���i���o�[�z �R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 29:���p�Ɠd�@���y�c�ƃi���o�[�z �R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 29) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���p�Ɠd�@���y�c�ƃi���o�[�z �R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 30:���򉻑� �R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 30) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "���򉻑� �R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 31:�\���ҁE�Ј�
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 31) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "�\���ҁE�Ј�";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 32:�����@���R�[�h�F1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                /*
                 * �^���Ώۂ̃��R�[�h�ȊO��Break����
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 32) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "�����@���R�[�h�F1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * �񂪁hAA"�ɕς�����ꍇ��BlockName��}������
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("�z�ԕ\�̍s�����s�����Ă��܂��B�V�X�e���Ǘ��҂֕񍐂��ĉ������B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * ���̑��ڍׂ�\������
             */
            SheetView1.Cells[11, 52].Value = _staffDriverSHINUNTEN;
            SheetView1.Cells[12, 52].Value = _staffDriverJIUNROU;
            SheetView1.Cells[13, 52].Value = _staffDriverBAITO;

            SheetView1.Cells[11, 54].Value = _staffOperatoeSHINUNTEN;
            SheetView1.Cells[12, 54].Value = _staffOperatoeJIUNROU;
            SheetView1.Cells[13, 54].Value = _staffOperatoeBAITO;

            SpreadBase.ResumeLayout(true);
        }

        /// <summary>
        /// GetNextCellPosition
        /// ���ɑ}������Row����肷��
        /// </summary>
        /// <param name="blockName"></param>
        /// <returns></returns>
        private EntryCellPosition? GetNextCellPosition() {
            var entryCellPosition = new EntryCellPosition();
            for(int colPosition = 0; colPosition <= 1; colPosition++) { // 0:A�� 1:AA��
                for(int row = _startRow; row <= _rowMax - 1; row++) {
                    if(SheetView1.Cells[row, _dictionaryColNumber[colPosition] + 0].Text == "" &&  // �^���R�[�h���͔z�Ԑ�̈ʒu
                       SheetView1.Cells[row, _dictionaryColNumber[colPosition] + 8].Text == "" &&  // �^�]��̈ʒu
                       SheetView1.Cells[row, _dictionaryColNumber[colPosition] + 11].Text == "" &&  // ��ƈ�2�̈ʒu
                       SheetView1.Cells[row + 1, _dictionaryColNumber[colPosition] + 11].Text == "") { // ��ƈ�3�̈ʒu
                        entryCellPosition.Row = row;
                        entryCellPosition.Col = _dictionaryColNumber[colPosition];
                        entryCellPosition.RemainingRows = _rowMax - row;
                        ToolStripStatusLabelPosition.Text = string.Concat("Row:", entryCellPosition.Row, " Col:", entryCellPosition.Col, " �c��", entryCellPosition.RemainingRows);
                        return entryCellPosition;
                    }
                }
            }
            /*
             * Null:�s�ɋ󂫂�����
             */
            return null;
        }

        /// <summary>
        /// SetSpan
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="blockName"></param>
        private void CreateSpan(EntryCellPosition entryCellPosition, string blockName) {
            // �Z������������
            SheetView1.AddSpanCell(entryCellPosition.Row, entryCellPosition.Col, 1, 24);
            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].BackColor = System.Drawing.Color.Green;
            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].Text = blockName;
        }

        /// <summary>
        /// CreateSetRow
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateSetRow(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string setName1;
            string setName2;
            /*
             * �g���Z�b�g����Ă��Ȃ���Ή������Ȃ�
             */
            if(vehicleDispatchDetailVo.Set_code > 0) {
                /*
                 * ��_�̏ꍇ�̕\���́h�Z�Z��h�Ƃ��邽�߁A�������򂷂�
                 */
                if(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code != 11) {
                    setName1 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1;
                    setName2 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2;
                } else {
                    setName1 = dictionaryWordCode[_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Word_code];
                    setName2 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2;
                }
                /*
                 * setName1
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].Text = setName1;
                /*
                 * setName2
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = setName2;
            }
        }

        /// <summary>
        /// CreateCarRow
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateCarRow(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string doorNumberHONBAN;
            string registrationNumber;
            string doorNumberDAIBAN;
            /*
             * �g���Z�b�g����Ă��Ȃ���Ή������Ȃ�
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Car_code > 0) {
                doorNumberHONBAN = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString();
                registrationNumber = string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3,
                                                   _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4);
                /*
                 * �{�Ԃ̃h�A�i���o�[
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].Text = doorNumberHONBAN;
                /*
                 * �{�Ԃ̎Ԕ�
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].Text = registrationNumber;

            }
        }

        // �^�]��i�o�C�g�j�̐l��
        int _staffDriverBAITO = 0;
        // �^�]��i�V�^�]�j�̐l��
        int _staffDriverSHINUNTEN = 0;
        // �^�]��i���^�J�j�̐l��
        int _staffDriverJIUNROU = 0;

        /// <summary>
        /// CreateOperator1Row
        /// �^�]��
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator1Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            RichText displayName; // �\����
            string occupation; // ����
            string garage; // �o�ɒn
            /*
             * �g���Z�b�g����Ă��Ȃ���Ή������Ȃ�
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_1 > 0) {
                displayName = new RichText(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                occupation = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                /*
                 * �e�l�����v�Z����
                 */
                switch(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs]) {
                    case "�o":
                        _staffDriverBAITO++;
                        break;
                    case "�V":
                        _staffDriverSHINUNTEN++;
                        break;
                    case "��":
                        _staffDriverJIUNROU++;
                        break;
                }
                garage = vehicleDispatchDetailVo.Garage_flag ? "" : "�O";
                /*
                 * �\����
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].Value = displayName;
                /*
                 * ����
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 9].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 9].Text = occupation;
                /*
                 * �o�ɒn
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 10].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 10].Text = garage;
            }
        }

        // ��ƈ��i�o�C�g�j�̐l��
        int _staffOperatoeBAITO = 0;
        // ��ƈ��i�V�^�]�j�̐l��
        int _staffOperatoeSHINUNTEN = 0;
        // ��ƈ��i���^�J�j�̐l��
        int _staffOperatoeJIUNROU = 0;

        /// <summary>
        /// CreateOperator2Row
        /// ��ƈ��P
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator2Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string garage; // �o�ɒn
            /*
             * �g���Z�b�g����Ă��Ȃ���Ή������Ȃ�
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_2 > 0) {
                switch(vehicleDispatchDetailVo.Cell_number) {
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                        garage = vehicleDispatchDetailVo.Garage_flag ? "" : "�O";
                        break;
                    default:
                        garage = "";
                        break;
                }
                /*
                 * �\����
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].Value = GetWorkStaffName(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2));
                /*
                 * ����
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 12].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 12].Text = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs],
                                                                                                         dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Occupation]);
                /*
                 * �e�l�����v�Z����
                 */
                switch(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs]) {
                    case "�o":
                        _staffOperatoeBAITO++;
                        break;
                    case "�V":
                        _staffOperatoeSHINUNTEN++;
                        break;
                    case "��":
                        _staffOperatoeJIUNROU++;
                        break;
                }
                /*
                 * �o�ɒn
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 13].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 13].Text = garage;
            }
        }

        /// <summary>
        /// CreateOperator3Row
        /// ��ƈ��Q
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator3Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            /*
             * �g���Z�b�g����Ă��Ȃ���Ή������Ȃ�
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_3 > 0) {
                /*
                 * �\����
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].Value = GetWorkStaffName(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3));
                /*
                 * ����
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 12].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 12].Text = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs],
                                                                                                             dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Occupation]);
                /*
                 * �e�l�����v�Z����
                 */
                switch(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs]) {
                    case "�o":
                        _staffOperatoeBAITO++;
                        break;
                    case "�V":
                        _staffOperatoeSHINUNTEN++;
                        break;
                    case "��":
                        _staffOperatoeJIUNROU++;
                        break;
                }
                /*
                 * �o�ɒn
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 13].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 13].Text = "";
            }
        }

        /// <summary>
        /// CreateOperator4Row
        /// ��ƈ��R
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator4Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            /*
             * �g���Z�b�g����Ă��Ȃ���Ή������Ȃ�
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_4 > 0) {
                /*
                 * �\����
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].Value = GetWorkStaffName(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4));
                /*
                 * ����
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 9].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 9].Text = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs],
                                                                                                            dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Occupation]);
                /*
                 * �e�l�����v�Z����
                 */
                switch(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs]) {
                    case "�o":
                        _staffOperatoeBAITO++;
                        break;
                    case "�V":
                        _staffOperatoeSHINUNTEN++;
                        break;
                    case "��":
                        _staffOperatoeJIUNROU++;
                        break;
                }
                /*
                 * �o�ɒn
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 10].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 10].Text = "";
            }
        }

        /// <summary>
        /// GetWorkStaffName
        /// �h��ƈ��h�������邩�ǂ���
        /// </summary>
        /// <returns></returns>
        private string GetWorkStaffName(StaffMasterVo staffMasterVo) {
            string rtfText = "";
            string displayName;
            switch(staffMasterVo.Belongs) {
                case 10:
                case 11:
                    rtfText = staffMasterVo.Display_name;
                    break;
                case 12:
                case 20:
                case 21:
                    switch(staffMasterVo.Staff_code) {
                        case 20675: // �[����
                            rtfText = string.Concat("", staffMasterVo.Display_name);
                            break;
                        default:
                            displayName = string.Concat("��ƈ�", staffMasterVo.Display_name);
                            /*
                             * ���b�`�e�L�X�g������̍쐬
                             */
                            using(RichTextBox temp = new RichTextBox()) {
                                temp.Text = displayName;
                                temp.SelectionStart = 0;
                                temp.SelectionLength = 3;
                                temp.SelectionColor = System.Drawing.Color.Gray;
                                temp.SelectionFont = new System.Drawing.Font("Yu Gothic UI", 6);
                                rtfText = temp.Rtf;
                            }
                            break;
                    }
                    break;
            }
            return rtfText;
        }

        /// <summary>
        /// EntryCellPosition
        /// </summary>
        private class EntryCellPosition {
            int _row;
            int _col;
            int _remainingRows;

            public EntryCellPosition() {
                _row = 0;
                _col = 0;
            }
            /// <summary>
            /// �}���\�Ȉʒu��ێ�
            /// </summary>
            public int Row {
                get => _row;
                set => _row = value;
            }
            /// <summary>
            /// �}���\�Ȉʒu��ێ�
            /// </summary>
            public int Col {
                get => _col;
                set => _col = value;
            }
            /// <summary>
            /// �c��̍s��
            /// </summary>
            public int RemainingRows {
                get => _remainingRows;
                set => _remainingRows = value;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemTest1":
                    CreateSpan(GetNextCellPosition(), "Test");
                    break;
                case "ToolStripMenuItemTest2":

                    break;
                case "ToolStripMenuItemTest3":

                    break;
                case "ToolStripMenuItemTest4":

                    break;
                case "ToolStripMenuItemTest5":

                    break;
            }
        }
    }
}