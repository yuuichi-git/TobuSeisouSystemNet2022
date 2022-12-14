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
         * ???Ԃ̓d?b?ԍ?
         */
        string telephoneNumber = "";
        /*
         * ?z?Ԑ??R?[?h?Ɠd?b?ԍ??̕R?Â?
         */
        Dictionary<int, string> dictionaryTelephoneNumber = new Dictionary<int, string> { { 1310101, "090-6506-7967" }, // ?????c?Q
                                                                                          { 1310102, "080-8868-7459" }, // ?????c?U
                                                                                          { 1310103, "080-8868-8023" }, // ?????c???P
                                                                                          { 1310201, "080-2202-7713" }, // ?????y?b?g?V
                                                                                          { 1310202, "080-3493-3729" }, // ?????y?b?g?W
                                                                                          { 1312101, "" }, // ?????P?W
                                                                                          { 1312102, "090-5560-0491" }, // ?????Q?R
                                                                                          { 1312103, "090-5560-0677" }, // ?????Q?S
                                                                                          { 1312104, "090-5560-0700" }, // ?????R?W
                                                                                          { 1312204, "090-9817-8129" }, // ?????P?P
                                                                                          { 1312201, "080-3493-3728" }, // ?????R?R
                                                                                          { 1312202, "080-2202-7269" } }; // ?????T?T
        /*
         * ???Ԃ̃Z???ʒu?̕R?Â?
         */
        Dictionary<int, string> cellSetName = new Dictionary<int, string> { { 0, "B38" }, { 1, "B42" }, { 2, "B46" } };
        Dictionary<int, string> cellOccupation = new Dictionary<int, string> { { 0, "B40" }, { 1, "B44" }, { 2, "B48" } };
        Dictionary<int, string> cellBeforeStaffDisplayName = new Dictionary<int, string> { { 0, "D38" }, { 1, "D42" }, { 2, "D46" } };
        Dictionary<int, string> cellAfterDisplayName = new Dictionary<int, string> { { 0, "I38" }, { 1, "I42" }, { 2, "I46" } };
        Dictionary<int, string> cellTelephoneNumber = new Dictionary<int, string> { { 0, "I40" }, { 1, "I44" }, { 2, "I48" } };
        /*
         * ???|?????????EFAX?ԍ?
         */
        private string _cleanOfficeName = "";
        private string _cleanOfficeFax = "";
        /*
         * ???Ԃ??L?ڂ????ʒu?̃J?E???^?[
         */
        int _staffPutNumber = 0;

        /// <summary>
        /// ?R???X?g???N?^?[
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="setCode"></param>
        public SubstitutePaper(ConnectionVo connectionVo, int setCode) {
            _connectionVo = connectionVo;
            /*
             * Dao
             */
            _vehicleDispatchBodyCleanOfficeDao = new VehicleDispatchBodyCleanOfficeDao(connectionVo);
            _vehicleDispatchBodyOfficeDao = new VehicleDispatchBodyOfficeDao(connectionVo);
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            /*
             * Vo
             */
            _vehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectOneVehicleDispatchDetail(DateTime.Now.Date, setCode);

            /*
             * ?R???g???[????????
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // ?V?[?g?^?u?????\??
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;
            /*
             * ?z?Ԑ????Ǎ???
             */
            _setMasterVo = new SetMasterDao(_connectionVo).SelectOneSetMaster(setCode);
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            /*
             * FAX?̈????EFAX?ԍ????Z?b?g
             */
            switch(setCode) {
                case 1310101: // ?????c?Q
                case 1310102: // ?????c?U
                case 1310103: // ?????c???P
                    _cleanOfficeName = "?@?????^?A?@?l";
                    _cleanOfficeFax = string.Concat("?????c???x??", "\r\n", "?e?`?w ?O?R?|?R?U?V?W?|?Q?U?W?W");
                    break;
                case 1310201: // ?????y?b?g?V
                case 1310202: // ?????y?b?g?W
                    _cleanOfficeName = string.Concat("?@?????s???q?????Ƌ????g??", "\r\n", " ?@???????x???@?l");
                    _cleanOfficeFax = string.Concat("???????x??", "\r\n", " ?e?`?w ?O?R?|?U?Q?W?O?|?T?W?S?P");
                    break;
                case 1312101: // ?????P?W
                case 1312102: // ?????Q?R
                case 1312103: // ?????Q?S
                case 1312104: // ?????R?W
                case 1312105: // ?????s?R?S
                    _cleanOfficeName = "?@???????|???????@?䒆";
                    _cleanOfficeFax = string.Concat("???????|??????", "\r\n", " ?e?`?w ?O?R?|?R?W?T?V?|?T?V?S?R");
                    break;
                case 1312204: // ?????P?P
                case 1312201: // ?????R?R
                case 1312202: // ?????T?T
                    _cleanOfficeName = "?@?????搴?|???????@?䒆";
                    _cleanOfficeFax = string.Concat("?????搴?|???????i?V?h?????j", "\r\n", " ?e?`?w ?O?R?|?R?U?O?W?|?R?R?X?V");
                    break;
                case 1312203: // ?????S
                    _cleanOfficeName = "?@???␴?|???????@?䒆";
                    _cleanOfficeFax = string.Concat("???␴?|??????", "\r\n", " ?e?`?w ?O?R?|?R?U?V?R?|?Q?T?R?T");
                    break;
            }

            InitializeSheetViewPaper();
            PutSheetViewPaper();
        }

        /// <summary>
        /// ?G???g???[?|?C???g
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// PutSheetViewPaper
        /// </summary>
        private void PutSheetViewPaper() {
            // ???t
            CultureInfo cultureInfo = new CultureInfo("ja-JP", true);
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewPaper.Cells["G3"].Text = DateTime.Now.ToString("gg y?NM??d??", cultureInfo);
            // ????
            SheetViewPaper.Cells["B6"].Text = _cleanOfficeName;
            /*
             * ????
             */
            // ?@?܂??͔z?Ԑ悪?i?[?????Ă???CellNumber???擾????
            int cellNumber = _vehicleDispatchDetailDao.GetCellNumber(_vehicleDispatchDetailVo.Set_code);
            // ?A???|???????ɓo?^?????Ă????{?Ԏԗ????擾????
            int carCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetCarCode(cellNumber);
            // ?B???Ԃ̏???
            if(_vehicleDispatchDetailVo.Car_code != 0 && carCodeCleanOffice != _vehicleDispatchDetailVo.Car_code) {
                // ?ύX?O ?g?? ?ԗ??i???o?[ ?h?A?ԍ?
                SheetViewPaper.Cells["B29"].Text = _setMasterVo.Set_name_2;
                SheetViewPaper.Cells["C29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Registration_number;
                SheetViewPaper.Cells["F29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Door_number.ToString();
                // ?ύX?? ?ԗ??i???o?[ ?h?A?ԍ?
                SheetViewPaper.Cells["H29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Registration_number;
                SheetViewPaper.Cells["L29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Door_number.ToString();
            }
            /*
             * ????
             */
            // ?A?????ԍ????Z?b?g
            switch(_vehicleDispatchDetailVo.Set_code) {
                case 1312105: // ?????s?R?S
                case 1312203: // ?????S
                    telephoneNumber = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Telephone_number;
                    break;
                default:
                    telephoneNumber = dictionaryTelephoneNumber[_vehicleDispatchDetailVo.Set_code];
                    break;
            }
            // ?@???|???????ɓo?^?????Ă????{??Oprator1???擾???? 
            int operatorCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetOperatorCode1(cellNumber);
            // ?A?^?]?????Ԃ̏???
            if(_vehicleDispatchDetailVo.Operator_code_1 != 0 && operatorCodeCleanOffice != _vehicleDispatchDetailVo.Operator_code_1) {
                PutStaff(_staffPutNumber,
                         _setMasterVo.Set_name,
                         "?^?]??",
                         _listStaffMasterVo.Find(x => x.Staff_code == operatorCodeCleanOffice).Display_name,
                         _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Display_name,
                         telephoneNumber);
                _staffPutNumber++; // ???̍s?ɃC???N???????g????
            }
            // ?B???ƈ????Ԃ̏??? List?ɂ??ꂼ???i?[????
            List<int> _arrayCleanOfficeStaffCodes = new List<int>();
            List<int> _arrayVehicleDispatchDetailStaffCodes = new List<int>();
            // VehicleDispatchBodyCleanOffice?̍??ƈ??R?[?h???i?[
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode2(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode2(cellNumber));
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode3(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode3(cellNumber));
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode4(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode4(cellNumber));
            // VehicleDispatchDetailVo?̍??ƈ??R?[?h???i?[
            if(_vehicleDispatchDetailVo.Operator_code_2 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_2);
            if(_vehicleDispatchDetailVo.Operator_code_3 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_3);
            if(_vehicleDispatchDetailVo.Operator_code_4 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_4);
            // ?C?????̏??ԂŁA_arrayCleanOfficeStaffCodes??_arrayVehicleDispatchDetailStaffCodes?Ƀf?[?^???i?[?????Ă???
            bool isEqual = _arrayCleanOfficeStaffCodes.SequenceEqual(_arrayVehicleDispatchDetailStaffCodes);
            // List?????r???ē????Ŗ??????Α??Ԃ????݂???
            if(!isEqual) {
                List<int> staffCodes = new List<int>();
                staffCodes.AddRange(_arrayCleanOfficeStaffCodes);
                staffCodes.AddRange(_arrayVehicleDispatchDetailStaffCodes);
                foreach(int staffCode in staffCodes) {
                    if(_arrayCleanOfficeStaffCodes.Contains(staffCode) && _arrayVehicleDispatchDetailStaffCodes.Contains(staffCode)) {
                        _arrayCleanOfficeStaffCodes.Remove(staffCode);
                        _arrayVehicleDispatchDetailStaffCodes.Remove(staffCode);
                    }
                }

                int arrayLoopCount = 0;
                foreach(int staffCode in _arrayCleanOfficeStaffCodes) {
                    PutStaff(_staffPutNumber,
                             _setMasterVo.Set_name,
                             "?E??",
                             _listStaffMasterVo.Find(x => x.Staff_code == _arrayCleanOfficeStaffCodes[arrayLoopCount]).Display_name,
                             _listStaffMasterVo.Find(x => x.Staff_code == _arrayVehicleDispatchDetailStaffCodes[arrayLoopCount]).Display_name,
                             telephoneNumber);
                    _staffPutNumber++; // ???̍s?ɃC???N???????g????
                    arrayLoopCount++;
                }
            }
            // FAX?ԍ???
            SheetViewPaper.Cells["H51"].Text = _cleanOfficeFax;
        }

        /// <summary>
        /// PutStaff
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="setName"></param>
        /// <param name="occupation"></param>
        /// <param name="beforeDisplayName"></param>
        /// <param name="afterDisplayName"></param>
        /// <param name="telephoneNumber"></param>
        private void PutStaff(int rowNumber, string setName, string occupation, string beforeDisplayName, string afterDisplayName, string telephoneNumber) {
            SheetViewPaper.Cells[cellSetName[rowNumber]].Text = string.Concat(setName, "?g");
            SheetViewPaper.Cells[cellOccupation[rowNumber]].Text = occupation;
            SheetViewPaper.Cells[cellBeforeStaffDisplayName[rowNumber]].Text = beforeDisplayName;
            SheetViewPaper.Cells[cellAfterDisplayName[rowNumber]].Text = afterDisplayName;
            SheetViewPaper.Cells[cellTelephoneNumber[rowNumber]].Text = telephoneNumber;
        }

        private void InitializeSheetViewPaper() {
            // ?쐬???t
            SheetViewPaper.Cells["G3"].ResetValue();
            // ??????
            SheetViewPaper.Cells["B6"].ResetValue();
            /*
             * ????
             */
            // ?P?s??
            SheetViewPaper.Cells["B29"].ResetValue();
            SheetViewPaper.Cells["C29"].ResetValue();
            SheetViewPaper.Cells["F29"].ResetValue();
            SheetViewPaper.Cells["H29"].ResetValue();
            SheetViewPaper.Cells["L29"].ResetValue();
            // ?Q?s??
            SheetViewPaper.Cells["B31"].ResetValue();
            SheetViewPaper.Cells["C31"].ResetValue();
            SheetViewPaper.Cells["F31"].ResetValue();
            SheetViewPaper.Cells["H31"].ResetValue();
            SheetViewPaper.Cells["L31"].ResetValue();
            /*
             * ????
             */
            // ?P?s??
            SheetViewPaper.Cells["B38"].ResetValue(); // ?g
            SheetViewPaper.Cells["B40"].ResetValue(); // ?^?]???E?E??
            SheetViewPaper.Cells["D38"].ResetValue(); // ?{?Ԏ???
            SheetViewPaper.Cells["I38"].ResetValue(); // ???Ԏ???
            SheetViewPaper.Cells["I40"].ResetValue(); // ???Ԍg?єԍ?
                                                      // ?Q?s??
            SheetViewPaper.Cells["B42"].ResetValue(); // ?g
            SheetViewPaper.Cells["B44"].ResetValue(); // ?^?]???E?E??
            SheetViewPaper.Cells["D42"].ResetValue(); // ?{?Ԏ???
            SheetViewPaper.Cells["I42"].ResetValue(); // ???Ԏ???
            SheetViewPaper.Cells["I44"].ResetValue(); // ???Ԍg?єԍ?
                                                      // ?R?s??
            SheetViewPaper.Cells["B46"].ResetValue(); // ?g
            SheetViewPaper.Cells["B48"].ResetValue(); // ?^?]???E?E??
            SheetViewPaper.Cells["D46"].ResetValue(); // ?{?Ԏ???
            SheetViewPaper.Cells["I46"].ResetValue(); // ???Ԏ???
            SheetViewPaper.Cells["I48"].ResetValue(); // ???Ԍg?єԍ?
                                                      // ??????
            SheetViewPaper.Cells["H51"].ResetValue();
        }

        /// <summary>
        /// ButtonPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadPaper.PrintSheet(SheetViewPaper);
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
            Dispose();
        }
    }
}