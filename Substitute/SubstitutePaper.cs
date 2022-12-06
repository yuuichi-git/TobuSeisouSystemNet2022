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
         * ´|±¼EFAXÔ
         */
        private string _cleanOfficeName;
        private string _cleanOfficeFax;

        /// <summary>
        /// RXgN^[
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="setCode"></param>
        public SubstitutePaper(ConnectionVo connectionVo, int setCode) {
            _connectionVo = connectionVo;
            _vehicleDispatchDetailVo = new VehicleDispatchDetailDao(_connectionVo).SelectOneVehicleDispatchDetail(DateTime.Now.Date, setCode);
            /*
             * Rg[ú»
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // V[g^uðñ\¦
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;
            // zÔæðÇÞ
            _setMasterVo = new SetMasterDao(_connectionVo).SelectOneSetMaster(setCode);

            /*
             * FAXÌ¶æEFAXÔðZbg
             */
            switch(setCode) {
                case 1310101: // çãcQ
                case 1310102: // çãcU
                case 1310103: // çãcP
                    _cleanOfficeName = "@ú·^A@l";
                    _cleanOfficeFax = string.Concat("çãcæx", "\r\n", "e`w OR|RUVW|QUWW");
                    break;
                case 1310201: // ybgV
                case 1310202: // ybgW
                    _cleanOfficeName = string.Concat("@sÂ«q¶Æ¦¯g", "\r\n", " @æx@l");
                    _cleanOfficeFax = string.Concat("æx", "\r\n", " e`w OR|UQWO|TWSP");
                    break;
                case 1312101: // «§PW
                case 1312102: // «§QR
                case 1312103: // «§QS
                case 1312104: // «§RW
                case 1312105: // «§sRS
                    _cleanOfficeName = "@«§´|±@ä";
                    _cleanOfficeFax = string.Concat("«§´|±", "\r\n", " e`w OR|RWTV|TVSR");
                    break;
                case 1312204: // üPP
                case 1312201: // üRR
                case 1312202: // üTT
                    _cleanOfficeName = "@üæ´|±@ä";
                    _cleanOfficeFax = string.Concat("üæ´|±iVhªºj", "\r\n", " e`w OR|RUOW|RRXV");
                    break;
                case 1312203: // ¬âS
                    _cleanOfficeName = "@¬â´|±@ä";
                    _cleanOfficeFax = string.Concat("¬â´|±", "\r\n", " e`w OR|RUVR|QTRT");
                    break;
            }

            InitializeSheetViewPaper();
            PutSheetViewPaper();
        }

        /// <summary>
        /// Gg[|Cg
        /// </summary>
        public static void Main() {
        }

        private void PutSheetViewPaper() {
            // út
            var Japanese = new CultureInfo("ja-JP", true);
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewPaper.Cells["G3"].Text = DateTime.Now.ToString("gg yNMdú", Japanese);
            // ¶æ
            SheetViewPaper.Cells["B6"].Text = _cleanOfficeName;





            // FAXÔ¼
            SheetViewPaper.Cells["H51"].Text = _cleanOfficeFax;
        }

        private void InitializeSheetViewPaper() {
            // ì¬út
            SheetViewPaper.Cells["G3"].ResetValue();
            // èæ
            SheetViewPaper.Cells["B6"].ResetValue();
            /*
             * ãÔ
             */
            // PsÚ
            SheetViewPaper.Cells["B29"].ResetValue();
            SheetViewPaper.Cells["C29"].ResetValue();
            SheetViewPaper.Cells["F29"].ResetValue();
            SheetViewPaper.Cells["H29"].ResetValue();
            SheetViewPaper.Cells["L29"].ResetValue();
            // QsÚ
            SheetViewPaper.Cells["B31"].ResetValue();
            SheetViewPaper.Cells["C31"].ResetValue();
            SheetViewPaper.Cells["F31"].ResetValue();
            SheetViewPaper.Cells["H31"].ResetValue();
            SheetViewPaper.Cells["L31"].ResetValue();
            /*
             * ãÔ
             */
            // PsÚ
            SheetViewPaper.Cells["B38"].ResetValue(); // g
            SheetViewPaper.Cells["D38"].ResetValue(); // {Ô¼
            SheetViewPaper.Cells["I38"].ResetValue(); // ãÔ¼
            SheetViewPaper.Cells["I40"].ResetValue(); // ãÔgÑÔ
            // QsÚ
            SheetViewPaper.Cells["B42"].ResetValue(); // g
            SheetViewPaper.Cells["D42"].ResetValue(); // {Ô¼
            SheetViewPaper.Cells["I42"].ResetValue(); // ãÔ¼
            SheetViewPaper.Cells["I44"].ResetValue(); // ãÔgÑÔ
            // RsÚ
            SheetViewPaper.Cells["B46"].ResetValue(); // g
            SheetViewPaper.Cells["D46"].ResetValue(); // {Ô¼
            SheetViewPaper.Cells["I46"].ResetValue(); // ãÔ¼
            SheetViewPaper.Cells["I48"].ResetValue(); // ãÔgÑÔ
            // èæ
            SheetViewPaper.Cells["H51"].ResetValue();
        }

        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadPaper.PrintSheet(SheetViewPaper);
        }
    }
}