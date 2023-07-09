using System.Globalization;

using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace SubstituteSheet {
    public partial class SubstituteSheet1 : Form {
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
        /*
         * ‘ã”Ô‚Ì“d˜b”Ô†
         */
        string _cellphoneNumber = "";
        /*
         * ”zÔæƒR[ƒh‚Æ“d˜b”Ô†‚Ì•R‚Ã‚¯
         */
        Dictionary<int, string> dictionaryTelephoneNumber = new Dictionary<int, string> { { 1310101, "090-6506-7967" }, // ç‘ã“c‚Q
                                                                                          { 1310102, "080-8868-7459" }, // ç‘ã“c‚U
                                                                                          { 1310103, "080-8868-8023" }, // ç‘ã“c†‚P
                                                                                          { 1310201, "080-2202-7713" }, // ’†‰›ƒyƒbƒg‚V
                                                                                          { 1310202, "080-3493-3729" }, // ’†‰›ƒyƒbƒg‚W
                                                                                          { 1312101, "" }, // ‘«—§‚P‚W
                                                                                          { 1312102, "090-5560-0491" }, // ‘«—§‚Q‚R
                                                                                          { 1312103, "090-5560-0677" }, // ‘«—§‚Q‚S
                                                                                          { 1312104, "090-5560-0700" }, // ‘«—§‚R‚W
                                                                                          { 1312204, "090-9817-8129" }, // Š‹ü‚P‚P
                                                                                          { 1312209, "080-3493-3728" }, // Š‹ü‚R‚Q
                                                                                          { 1312210, "080-2202-7269" } }; // Š‹ü‚T‚S
        /*
         * ‘ã”Ô‚ÌƒZƒ‹ˆÊ’u‚Ì•R‚Ã‚¯
         */
        Dictionary<int, string> _dictionarySetName = new Dictionary<int, string> { { 0, "B38" }, { 1, "B42" }, { 2, "B46" } };
        Dictionary<int, string> _dictionaryOccupation = new Dictionary<int, string> { { 0, "B40" }, { 1, "B44" }, { 2, "B48" } };
        Dictionary<int, string> _dictionaryBeforeStaffDisplayName = new Dictionary<int, string> { { 0, "D38" }, { 1, "D42" }, { 2, "D46" } };
        Dictionary<int, string> _dictionaryAfterDisplayName = new Dictionary<int, string> { { 0, "I38" }, { 1, "I42" }, { 2, "I46" } };
        Dictionary<int, string> _dictionaryCellphoneNumber = new Dictionary<int, string> { { 0, "I40" }, { 1, "I44" }, { 2, "I48" } };
        /*
         * ´‘|––±Š–¼EFAX”Ô†
         */
        private string _cleanOfficeName = "";
        private string _cleanOfficeFax = "";
        /*
         * ‘ã”Ô‚ğ‹LÚ‚·‚éˆÊ’u‚ÌƒJƒEƒ“ƒ^[
         */
        int _staffPutNumber = 0;

        /// <summary>
        /// ƒRƒ“ƒXƒgƒ‰ƒNƒ^[
        /// </summary>
        public SubstituteSheet1(ConnectionVo connectionVo, DateTime operationDate, int cellNumber, int setCode) {
            /*
             * Dao
             */
            _vehicleDispatchBodyCleanOfficeDao = new VehicleDispatchBodyCleanOfficeDao(connectionVo);
            _vehicleDispatchBodyOfficeDao = new VehicleDispatchBodyOfficeDao(connectionVo);
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _vehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectOneVehicleDispatchDetail(operationDate.Date, cellNumber + 1);
            /*
             * ƒRƒ“ƒgƒ[ƒ‹‰Šú‰»
             */
            InitializeComponent();
            _initializeForm.SubstituteSheet1(this);
            // ƒV[ƒgƒ^ƒu‚ğ”ñ•\¦
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            /*
             * ”zÔæ‚ğ“Ç‚Ş
             */
            _setMasterVo = new SetMasterDao(_connectionVo).SelectOneSetMaster(setCode);
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            /*
             * FAX‚Ìˆ¶æEFAX”Ô†‚ğƒZƒbƒg
             */
            switch(setCode) {
                case 1310101: // ç‘ã“c‚Q
                case 1310102: // ç‘ã“c‚U
                case 1310103: // ç‘ã“c†‚P
                    _cleanOfficeName = "@“ú·‰^—A@—l";
                    _cleanOfficeFax = string.Concat("ç‘ã“c‹æx•”", "\r\n", "‚e‚`‚w ‚O‚R|‚R‚U‚V‚W|‚Q‚U‚W‚W");
                    break;
                case 1310201: // ’†‰›ƒyƒbƒg‚V
                case 1310202: // ’†‰›ƒyƒbƒg‚W
                    _cleanOfficeName = string.Concat("@“Œ‹“sŠÂ‹«‰q¶–‹Æ‹¦“¯‘g‡", "\r\n", " @’†‰›‹æx•”@—l");
                    _cleanOfficeFax = string.Concat("’†‰›‹æx•”", "\r\n", " ‚e‚`‚w ‚O‚R|‚U‚Q‚W‚O|‚T‚W‚S‚P");
                    break;
                case 1312101: // ‘«—§‚P‚W
                case 1312102: // ‘«—§‚Q‚R
                case 1312103: // ‘«—§‚Q‚S
                case 1312104: // ‘«—§‚R‚W
                case 1312105: // ‘«—§•s”R‚S
                    _cleanOfficeName = "@‘«—§´‘|––±Š@Œä’†";
                    _cleanOfficeFax = string.Concat("‘«—§´‘|––±Š", "\r\n", " ‚e‚`‚w ‚O‚R|‚R‚W‚T‚V|‚T‚V‚S‚R");
                    break;
                case 1312204: // Š‹ü‚P‚P
                case 1312209: // Š‹ü‚R‚Q
                case 1312210: // Š‹ü‚T‚S
                    _cleanOfficeName = "@Š‹ü‹æ´‘|––±Š@Œä’†";
                    _cleanOfficeFax = string.Concat("Š‹ü‹æ´‘|––±ŠiVh•ªºj", "\r\n", " ‚e‚`‚w ‚O‚R|‚R‚U‚O‚W|‚R‚R‚X‚V");
                    break;
                case 1312203: // ¬Šâ‚S
                case 1312208: // ¬Šâ‚T
                    _cleanOfficeName = "@¬Šâ´‘|––±Š@Œä’†";
                    _cleanOfficeFax = string.Concat("¬Šâ´‘|––±Š", "\r\n", " ‚e‚`‚w ‚O‚R|‚R‚U‚V‚R|‚Q‚T‚R‚T");
                    break;
            }

            InitializeSheetView();
            PutSheetViewPaper();
        }

        /// <summary>
        /// ƒGƒ“ƒgƒŠ[ƒ|ƒCƒ“ƒg
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// PutSheetViewPaper
        /// </summary>
        private void PutSheetViewPaper() {
            // “ú•t
            CultureInfo cultureInfo = new CultureInfo("ja-JP", true);
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetView1.Cells["G3"].Text = DateTime.Now.ToString("gg y”NMŒd“ú", cultureInfo);
            // ˆ¶æ
            SheetView1.Cells["B6"].Text = _cleanOfficeName;
            /*
             * ‘ãÔ
             */
            // ‡@‚Ü‚¸‚Í”zÔæ‚ªŠi”[‚³‚ê‚Ä‚¢‚éCellNumber‚ğæ“¾‚·‚é
            int cellNumber = _vehicleDispatchDetailDao.GetCellNumber(_vehicleDispatchDetailVo.Set_code);
            // ‡A´‘|––±Š‚É“o˜^‚³‚ê‚Ä‚¢‚é–{”ÔÔ—¼‚ğæ“¾‚·‚é
            int carCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetCarCode(cellNumber);
            // ‡B‘ãÔ‚Ìˆ—
            if(_vehicleDispatchDetailVo.Car_code != 0 && carCodeCleanOffice != _vehicleDispatchDetailVo.Car_code) {
                // •ÏX‘O ‘g” Ô—¼ƒiƒ“ƒo[ ƒhƒA”Ô†
                SheetView1.Cells["B29"].Text = _setMasterVo.Set_name_2;
                SheetView1.Cells["C29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Registration_number;
                SheetView1.Cells["F29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Door_number.ToString();
                // •ÏXŒã Ô—¼ƒiƒ“ƒo[ ƒhƒA”Ô†
                SheetView1.Cells["H29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Registration_number;
                SheetView1.Cells["L29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Door_number.ToString();
            }
            /*
             * ‘ã”Ô
             */
            // ˜A—æ”Ô†‚ğƒZƒbƒg
            switch(_vehicleDispatchDetailVo.Set_code) {
                case 1312105: // ‘«—§•s”R‚S
                case 1312203: // ¬Šâ‚S
                case 1312208: // ¬Šâ‚T
                    _cellphoneNumber = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Cellphone_number;
                    break;
                default:
                    _cellphoneNumber = dictionaryTelephoneNumber[_vehicleDispatchDetailVo.Set_code];
                    break;
            }
            // ‡@´‘|––±Š‚É“o˜^‚³‚ê‚Ä‚¢‚é–{”ÔOprator1‚ğæ“¾‚·‚é 
            int operatorCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetOperatorCode1(cellNumber);
            // ‡A‰^“]è‘ã”Ô‚Ìˆ—
            if(_vehicleDispatchDetailVo.Operator_code_1 != 0 && operatorCodeCleanOffice != _vehicleDispatchDetailVo.Operator_code_1) {
                PutStaff(_staffPutNumber,
                         _setMasterVo.Set_name,
                         "‰^“]è",
                         _listStaffMasterVo.Find(x => x.Staff_code == operatorCodeCleanOffice).Display_name,
                         _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Display_name,
                         _cellphoneNumber);
                _staffPutNumber++; // Ÿ‚Ìs‚ÉƒCƒ“ƒNƒŠƒƒ“ƒg‚·‚é
            }
            // ‡Bì‹Æˆõ‘ã”Ô‚Ìˆ— List‚É‚»‚ê‚¼‚êŠi”[‚·‚é
            List<int> _arrayCleanOfficeStaffCodes = new List<int>();
            List<int> _arrayVehicleDispatchDetailStaffCodes = new List<int>();
            // VehicleDispatchBodyCleanOffice‚Ìì‹ÆˆõƒR[ƒh‚ğŠi”[
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode2(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode2(cellNumber));
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode3(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode3(cellNumber));
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode4(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode4(cellNumber));
            // VehicleDispatchDetailVo‚Ìì‹ÆˆõƒR[ƒh‚ğŠi”[
            if(_vehicleDispatchDetailVo.Operator_code_2 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_2);
            if(_vehicleDispatchDetailVo.Operator_code_3 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_3);
            if(_vehicleDispatchDetailVo.Operator_code_4 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_4);
            // ‡C‚±‚±‚Ìó‘Ô‚ÅA_arrayCleanOfficeStaffCodes‚Æ_arrayVehicleDispatchDetailStaffCodes‚Éƒf[ƒ^‚ªŠi”[‚³‚ê‚Ä‚¢‚é
            bool isEqual = _arrayCleanOfficeStaffCodes.SequenceEqual(_arrayVehicleDispatchDetailStaffCodes);
            // List‚ğ”äŠr‚µ‚Ä“¯ˆê‚Å–³‚¯‚ê‚Î‘ã”Ô‚ª‘¶İ‚·‚é
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
                             "Eˆõ",
                             _listStaffMasterVo.Find(x => x.Staff_code == _arrayCleanOfficeStaffCodes[arrayLoopCount]).Display_name,
                             _listStaffMasterVo.Find(x => x.Staff_code == _arrayVehicleDispatchDetailStaffCodes[arrayLoopCount]).Display_name,
                             _cellphoneNumber);
                    _staffPutNumber++; // Ÿ‚Ìs‚ÉƒCƒ“ƒNƒŠƒƒ“ƒg‚·‚é
                    arrayLoopCount++;
                }
            }
            // FAX”Ô†‘¼
            SheetView1.Cells["H51"].Text = _cleanOfficeFax;
        }

        /// <summary>
        /// PutStaff
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="setName"></param>
        /// <param name="occupation"></param>
        /// <param name="beforeDisplayName"></param>
        /// <param name="afterDisplayName"></param>
        /// <param name="cellphoneNumber"></param>
        private void PutStaff(int rowNumber, string setName, string occupation, string beforeDisplayName, string afterDisplayName, string cellphoneNumber) {
            SheetView1.Cells[_dictionarySetName[rowNumber]].Text = string.Concat(setName, "‘g");
            SheetView1.Cells[_dictionaryOccupation[rowNumber]].Text = occupation;
            SheetView1.Cells[_dictionaryBeforeStaffDisplayName[rowNumber]].Text = beforeDisplayName;
            SheetView1.Cells[_dictionaryAfterDisplayName[rowNumber]].Text = afterDisplayName;
            SheetView1.Cells[_dictionaryCellphoneNumber[rowNumber]].Text = cellphoneNumber;
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        private void InitializeSheetView() {
            // ì¬“ú•t
            SheetView1.Cells["G3"].ResetValue();
            // ‘—‚èæ
            SheetView1.Cells["B6"].ResetValue();
            /*
             * ‘ãÔ
             */
            // ‚Ps–Ú
            SheetView1.Cells["B29"].ResetValue();
            SheetView1.Cells["C29"].ResetValue();
            SheetView1.Cells["F29"].ResetValue();
            SheetView1.Cells["H29"].ResetValue();
            SheetView1.Cells["L29"].ResetValue();
            // ‚Qs–Ú
            SheetView1.Cells["B31"].ResetValue();
            SheetView1.Cells["C31"].ResetValue();
            SheetView1.Cells["F31"].ResetValue();
            SheetView1.Cells["H31"].ResetValue();
            SheetView1.Cells["L31"].ResetValue();
            /*
             * ‘ã”Ô
             */
            // ‚Ps–Ú
            SheetView1.Cells["B38"].ResetValue(); // ‘g
            SheetView1.Cells["B40"].ResetValue(); // ‰^“]èEEˆõ
            SheetView1.Cells["D38"].ResetValue(); // –{”Ô–¼
            SheetView1.Cells["I38"].ResetValue(); // ‘ã”Ô–¼
            SheetView1.Cells["I40"].ResetValue(); // ‘ã”ÔŒg‘Ñ”Ô†
                                                  // ‚Qs–Ú
            SheetView1.Cells["B42"].ResetValue(); // ‘g
            SheetView1.Cells["B44"].ResetValue(); // ‰^“]èEEˆõ
            SheetView1.Cells["D42"].ResetValue(); // –{”Ô–¼
            SheetView1.Cells["I42"].ResetValue(); // ‘ã”Ô–¼
            SheetView1.Cells["I44"].ResetValue(); // ‘ã”ÔŒg‘Ñ”Ô†
                                                  // ‚Rs–Ú
            SheetView1.Cells["B46"].ResetValue(); // ‘g
            SheetView1.Cells["B48"].ResetValue(); // ‰^“]èEEˆõ
            SheetView1.Cells["D46"].ResetValue(); // –{”Ô–¼
            SheetView1.Cells["I46"].ResetValue(); // ‘ã”Ô–¼
            SheetView1.Cells["I48"].ResetValue(); // ‘ã”ÔŒg‘Ñ”Ô†
                                                  // ‘—‚èæ
            SheetView1.Cells["H51"].ResetValue();
        }

        /// <summary>
        /// ButtonPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadList.PrintSheet(SheetView1);
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// SubstituteSheet1_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubstituteSheet1_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}