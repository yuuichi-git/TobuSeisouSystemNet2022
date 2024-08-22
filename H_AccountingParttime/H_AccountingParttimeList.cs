/*
 * 2024-04-13
 */
using H_Dao;

using H_Vo;

using Vo;

namespace H_AccountingParttime {
    public partial class HAccountingParttimeList : Form {
        /*
         * Dao
         */
        private readonly H_SetMasterDao _hSetMasterDao;
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly List<H_SetMasterVo> _listHSetMasterVo;
        private readonly List<H_CarMasterVo> _listHCarMasterVo;
        private readonly List<H_StaffMasterVo> _listHStaffMasterVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public HAccountingParttimeList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hSetMasterDao = new(connectionVo);
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMaster();
            /*
             * InitializeControl
             */
            InitializeComponent();
            HDateTimePickerExOperationDate.SetValueJp(DateTime.Now.Date);
            this.InitializeSheetViewList();

        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.InitializeSheetViewList();
            this.SetSheetViewList(_hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(HDateTimePickerExOperationDate.GetValue().Date));
        }


        string _operationName = string.Empty;
        private void SetSheetViewList(List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo) {
            int startRow = 3;
            int startCol = 1;

            // ���t
            SheetViewList.Cells["E2"].Text = HDateTimePickerExOperationDate.GetValueJp();

            foreach (H_StaffMasterVo hStaffMasterVo in _listHStaffMasterVo.FindAll(x => x.Belongs == 12 && x.VehicleDispatchTarget == true && x.RetirementFlag == false).OrderBy(x => x.EmploymentDate)) {
                SheetViewList.Cells[startRow, startCol].Text = hStaffMasterVo.DisplayName;
                var hVehicleDispatchDetailVo = listHVehicleDispatchDetailVo.Find(x => (x.StaffCode1 == hStaffMasterVo.StaffCode ||
                                                                                       x.StaffCode2 == hStaffMasterVo.StaffCode ||
                                                                                       x.StaffCode3 == hStaffMasterVo.StaffCode ||
                                                                                       x.StaffCode4 == hStaffMasterVo.StaffCode) &&
                                                                                       x.OperationDate == HDateTimePickerExOperationDate.GetValue().Date);
                /*
                 * �z�Ԑ悪�ݒ肳��ĂȂ���StaffLabelEx�����u���Ă���ꍇ���������Ȃ�
                 * �hvehicleDispatchDetailVo.Set_code > 0�h �� ���̕���
                 */
                if (hVehicleDispatchDetailVo != null && hVehicleDispatchDetailVo.SetCode > 0) {
                    SheetViewList.Cells[startRow, startCol + 1].Text = "�o��";
                    /*
                     * ���O��ݒ�
                     * �@�����{�Ђ͑S�āy�^�]��z�ɂ���i�^�R������˗��j
                     */
                    switch (hVehicleDispatchDetailVo.SetCode) {
                        case 1312111: // �����{��
                            _operationName = "�y�^�]��z";
                            break;
                        default:
                            _operationName = hVehicleDispatchDetailVo.StaffCode1 == hStaffMasterVo.StaffCode ? "�y�^�]��z" : "�y��ƈ��z";
                            break;
                    }
                    SheetViewList.Cells[startRow, startCol + 2].Text = string.Concat(_operationName, _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName);
                    /*
                     * �Ԏ�
                     */
                    H_CarMasterVo hCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchDetailVo.CarCode);
                    if (hCarMasterVo != null && hVehicleDispatchDetailVo.StaffCode1 == hStaffMasterVo.StaffCode) {
                        var carKidName = "";
                        switch (hCarMasterVo.CarKindCode) {
                            case 10:
                                carKidName = "�y������";
                                break;
                            case 11:
                                carKidName = "���^";
                                break;
                            case 12:
                                carKidName = "����";
                                break;
                        }
                        SheetViewList.Cells[startRow, startCol + 3].Text = carKidName;
                    }
                    /*
                     * �o�Βn
                     */
                    if (hVehicleDispatchDetailVo.StaffCode1 == hStaffMasterVo.StaffCode) {
                        SheetViewList.Cells[startRow, startCol + 4].Text = hVehicleDispatchDetailVo.CarGarageCode == 1 ? "�{��" : "�O��";
                    } else {
                        SheetViewList.Cells[startRow, startCol + 4].Text = "�{��";
                    }
                }
                startRow++;
            }
            ToolStripStatusLabelDetail.Text = string.Concat(HDateTimePickerExOperationDate.GetValueJp(), "�̃f�[�^���X�V���܂����B");
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // A4�ň������
                case "ToolStripMenuItemPrintA4":
                    //�A�N�e�B�u�V�[�g������܂�
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // �A�v���P�[�V�������I������
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        private void InitializeSheetViewList() {
            SheetViewList.Cells["E2"].Text = string.Empty;
            // �w��͈͂̃f�[�^���N���A
            SheetViewList.ClearRange(3, 1, 40, 5, true);
        }

    }
}
