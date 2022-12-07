using System.Globalization;

using Common;

using ControlEx;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Accounting {
    public partial class AccountingParttimeList : Form {
        private ConnectionVo _connectionVo;
        private readonly InitializeForm _initializeForm = new();
        private DateTime _operationDate;
        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<VehicleDispatchDetailVo> _listVehicleDispatchDetailVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public AccountingParttimeList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * 
             */
            _listSetMasterVo = new SetMasterDao(_connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();

            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.AccountingParttimeList(this);
            DateTimePickerExOperationDate.Value = DateTime.Now;
            // �V�[�g
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            // �X�e�[�^�X�o�[
            ToolStripStatusLabelStatus.Text = "";

            InitializeSheetViewList();

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
            InitializeSheetViewList();
            _listVehicleDispatchDetailVo = new VehicleDispatchDetailDao(_connectionVo).SelectAllVehicleDispatchDetail(_operationDate);
            PutSheetViewList();
        }

        private void PutSheetViewList() {
            int startRow = 3;
            int startCol = 1;

            // ���t
            var Japanese = new CultureInfo("ja-JP", true);
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewList.Cells["E2"].Text = _operationDate.ToString("gg y�NM��d��(dddd)", Japanese);

            foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Belongs == 12 && x.Vehicle_dispatch_target == true && x.Retirement_flag == false).OrderBy(x => x.Employment_date)) {
                SheetViewList.Cells[startRow, startCol].Text = staffMasterVo.Display_name;
                var vehicleDispatchDetailVo = _listVehicleDispatchDetailVo.Find(x => (x.Operator_code_1 == staffMasterVo.Staff_code ||
                                                                                      x.Operator_code_2 == staffMasterVo.Staff_code ||
                                                                                      x.Operator_code_3 == staffMasterVo.Staff_code ||
                                                                                      x.Operator_code_4 == staffMasterVo.Staff_code) &&
                                                                                      x.Operation_date == _operationDate.Date);
                if(vehicleDispatchDetailVo != null) {
                    SheetViewList.Cells[startRow, startCol + 1].Text = "�o��";
                    SheetViewList.Cells[startRow, startCol + 2].Text = string.Concat(vehicleDispatchDetailVo.Operator_code_1 == staffMasterVo.Staff_code ? "�y�^�]��z" : "�y��ƈ��z",
                                                                                     _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name);
                    /*
                     * �Ԏ�
                     */
                    var carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                    if(carMasterVo != null && vehicleDispatchDetailVo.Operator_code_1 == staffMasterVo.Staff_code) {
                        var carKidName = "";
                        switch(carMasterVo.Car_kind_code) {
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
                    if(vehicleDispatchDetailVo.Operator_code_1 == staffMasterVo.Staff_code) {
                        SheetViewList.Cells[startRow, startCol + 4].Text = vehicleDispatchDetailVo.Garage_flag ? "�{��" : "�O��";
                    } else {
                        SheetViewList.Cells[startRow, startCol + 4].Text = "�{��";
                    }
                }
                startRow++;
            }
            ToolStripStatusLabelStatus.Text = string.Concat(_operationDate.ToString("yyyy�NMM��dd��(dddd)"),"�̃f�[�^���X�V���܂����B");
        }

        private void InitializeSheetViewList() {
            SheetViewList.Cells["E2"].Text = string.Empty;
            // �w��͈͂̃f�[�^���N���A
            SheetViewList.ClearRange(3, 1, 40, 5, true);
        }

        private void DateTimePickerExOperationDate_ValueChanged(object sender, EventArgs e) {
            _operationDate = ((DateTimePickerEx)sender).Value;
        }

        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //�A�N�e�B�u�V�[�g������܂�
            SpreadList.PrintSheet(SheetViewList);
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void AccountingParttimeList_FormClosing(object sender, FormClosingEventArgs e) {
            Dispose();
        }
    }
}