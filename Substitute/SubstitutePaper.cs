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
         * ´‘|––±Š–¼EFAX”Ô†
         */
        private string _cleanOfficeName;
        private string _cleanOfficeFax;

        /// <summary>
        /// ƒRƒ“ƒXƒgƒ‰ƒNƒ^[
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
             * ƒRƒ“ƒgƒ[ƒ‹‰Šú‰»
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // ƒV[ƒgƒ^ƒu‚ğ”ñ•\¦
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;
            // ”zÔæ‚ğ“Ç‚Ş
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
                case 1312201: // Š‹ü‚R‚R
                case 1312202: // Š‹ü‚T‚T
                    _cleanOfficeName = "@Š‹ü‹æ´‘|––±Š@Œä’†";
                    _cleanOfficeFax = string.Concat("Š‹ü‹æ´‘|––±ŠiVh•ªºj", "\r\n", " ‚e‚`‚w ‚O‚R|‚R‚U‚O‚W|‚R‚R‚X‚V");
                    break;
                case 1312203: // ¬Šâ‚S
                    _cleanOfficeName = "@¬Šâ´‘|––±Š@Œä’†";
                    _cleanOfficeFax = string.Concat("¬Šâ´‘|––±Š", "\r\n", " ‚e‚`‚w ‚O‚R|‚R‚U‚V‚R|‚Q‚T‚R‚T");
                    break;
            }

            InitializeSheetViewPaper();
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
            var Japanese = new CultureInfo("ja-JP", true);
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewPaper.Cells["G3"].Text = DateTime.Now.ToString("gg y”NMŒd“ú", Japanese);
            // ˆ¶æ
            SheetViewPaper.Cells["B6"].Text = _cleanOfficeName;
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
                SheetViewPaper.Cells["B29"].Text = _setMasterVo.Set_name_2;
                SheetViewPaper.Cells["C29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Registration_number;
                SheetViewPaper.Cells["F29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Door_number.ToString();
                // •ÏXŒã Ô—¼ƒiƒ“ƒo[ ƒhƒA”Ô†
                SheetViewPaper.Cells["H29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Registration_number;
                SheetViewPaper.Cells["L29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Door_number.ToString();
            }
            /*
             * ‘ã”Ô
             */
            // ‡@´‘|––±Š‚É“o˜^‚³‚ê‚Ä‚¢‚é–{”ÔOprator1‚ğæ“¾‚·‚é 
            int operatorCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetOperatorCode1(cellNumber);
            // ‡A‰^“]è‘ã”Ô‚Ìˆ—
            if(_vehicleDispatchDetailVo.Operator_code_1 != 0 && operatorCodeCleanOffice != _vehicleDispatchDetailVo.Operator_code_1) {
                // •ÏX‘O@‘g”@–¼
                SheetViewPaper.Cells["B38"].Text = string.Concat(_setMasterVo.Set_name_2, "‘g");
                SheetViewPaper.Cells["D38"].Text = _listStaffMasterVo.Find(x => x.Staff_code == operatorCodeCleanOffice).Display_name;
                // •ÏXŒã@–¼@Œg‘Ñ”Ô†
                SheetViewPaper.Cells["I38"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Display_name;
                
                string telephoneNumber = "";
                switch(_vehicleDispatchDetailVo.Set_code) {
                    case 1310101: // ç‘ã“c‚Q
                        telephoneNumber = "090-6506-7967";
                        break;
                    case 1310102: // ç‘ã“c‚U
                        telephoneNumber = "080-8868-7459";
                        break;
                    case 1310103: // ç‘ã“c†‚P
                        telephoneNumber = "080-8868-8023";
                        break;
                    case 1310201: // ’†‰›ƒyƒbƒg‚V
                        telephoneNumber = "080-2202-7713";
                        break;
                    case 1310202: // ’†‰›ƒyƒbƒg‚W
                        telephoneNumber = "080-3493-3729";
                        break;
                    case 1312101: // ‘«—§‚P‚W
                        telephoneNumber = "•s–¾";
                        break;
                    case 1312102: // ‘«—§‚Q‚R
                        telephoneNumber = "090-5560-0491";
                        break;
                    case 1312103: // ‘«—§‚Q‚S
                        telephoneNumber = "090-5560-0677";
                        break;
                    case 1312104: // ‘«—§‚R‚W
                        telephoneNumber = "090-5560-0700";
                        break;
                    case 1312105: // ‘«—§•s”R‚S
                        telephoneNumber = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Telephone_number;
                        break;
                    case 1312204: // Š‹ü‚P‚P
                        telephoneNumber = "090-9817-8129";
                        break;
                    case 1312201: // Š‹ü‚R‚R
                        telephoneNumber = "080-3493-3728";
                        break;
                    case 1312202: // Š‹ü‚T‚T
                        telephoneNumber = "080-2202-7269";
                        break;
                    case 1312203: // ¬Šâ‚S
                        telephoneNumber = "•s–¾";
                        break;
                }
                SheetViewPaper.Cells["I40"].Text = telephoneNumber;


            }


            // FAX”Ô†‘¼
            SheetViewPaper.Cells["H51"].Text = _cleanOfficeFax;
        }

        private void InitializeSheetViewPaper() {
            // ì¬“ú•t
            SheetViewPaper.Cells["G3"].ResetValue();
            // ‘—‚èæ
            SheetViewPaper.Cells["B6"].ResetValue();
            /*
             * ‘ãÔ
             */
            // ‚Ps–Ú
            SheetViewPaper.Cells["B29"].ResetValue();
            SheetViewPaper.Cells["C29"].ResetValue();
            SheetViewPaper.Cells["F29"].ResetValue();
            SheetViewPaper.Cells["H29"].ResetValue();
            SheetViewPaper.Cells["L29"].ResetValue();
            // ‚Qs–Ú
            SheetViewPaper.Cells["B31"].ResetValue();
            SheetViewPaper.Cells["C31"].ResetValue();
            SheetViewPaper.Cells["F31"].ResetValue();
            SheetViewPaper.Cells["H31"].ResetValue();
            SheetViewPaper.Cells["L31"].ResetValue();
            /*
             * ‘ã”Ô
             */
            // ‚Ps–Ú
            SheetViewPaper.Cells["B38"].ResetValue(); // ‘g
            SheetViewPaper.Cells["D38"].ResetValue(); // –{”Ô–¼
            SheetViewPaper.Cells["I38"].ResetValue(); // ‘ã”Ô–¼
            SheetViewPaper.Cells["I40"].ResetValue(); // ‘ã”ÔŒg‘Ñ”Ô†
            // ‚Qs–Ú
            SheetViewPaper.Cells["B42"].ResetValue(); // ‘g
            SheetViewPaper.Cells["D42"].ResetValue(); // –{”Ô–¼
            SheetViewPaper.Cells["I42"].ResetValue(); // ‘ã”Ô–¼
            SheetViewPaper.Cells["I44"].ResetValue(); // ‘ã”ÔŒg‘Ñ”Ô†
            // ‚Rs–Ú
            SheetViewPaper.Cells["B46"].ResetValue(); // ‘g
            SheetViewPaper.Cells["D46"].ResetValue(); // –{”Ô–¼
            SheetViewPaper.Cells["I46"].ResetValue(); // ‘ã”Ô–¼
            SheetViewPaper.Cells["I48"].ResetValue(); // ‘ã”ÔŒg‘Ñ”Ô†
            // ‘—‚èæ
            SheetViewPaper.Cells["H51"].ResetValue();
        }

        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadPaper.PrintSheet(SheetViewPaper);
        }
    }
}