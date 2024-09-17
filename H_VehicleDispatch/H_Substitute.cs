/*
 * 2024-02-26
 */
using System.Drawing.Printing;
using System.Globalization;

using FarPoint.Win.Spread;

using H_Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_Substitute : Form {
        PrintDocument _printDocument = new();
        Date _date = new();

        /// <summary>
        /// 代番の電話番号
        /// </summary>
        string _cellphoneNumber = string.Empty;
        /// <summary>
        /// 配車先コードと電話番号の紐づけ
        /// </summary>
        readonly Dictionary<int, string> _dictionaryTelephoneNumber = new Dictionary<int, string> { { 1310101, "090-6506-7967" }, // 千代田２
                                                                                                    { 1310102, "080-8868-7459" }, // 千代田６
                                                                                                    { 1310103, "080-8868-8023" }, // 千代田紙１
                                                                                                    { 1310201, "080-2202-7713" }, // 中央ペット７
                                                                                                    { 1310202, "080-3493-3729" }, // 中央ペット８
                                                                                                    //{ 1310207, "" }, // 中央ペット１１
                                                                                                    { 1312162, "090-5560-0491" }, // 足立２２(2024)
                                                                                                    { 1312164, "090-5560-0677" }, // 足立２３(2024)
                                                                                                    { 1312163, "090-5560-0700" }, // 足立３７(2024)
                                                                                                    { 1312204, "090-9817-8129" }, // 葛飾１１
                                                                                                    { 1312211, "090-9817-8129" }, // 葛飾軽１２(2024)
                                                                                                    { 1312209, "080-3493-3728" }, // 葛飾３２
                                                                                                    { 1312210, "080-2202-7269" } }; // 葛飾５４
        /*
         * 代番のセル位置の紐づけ(SheetView1用)
         */
        readonly Dictionary<int, string> _dictionarySheetView1SetName = new Dictionary<int, string> { { 0, "B38" }, { 1, "B42" }, { 2, "B46" } };
        readonly Dictionary<int, string> _dictionarySheetView1Occupation = new Dictionary<int, string> { { 0, "B40" }, { 1, "B44" }, { 2, "B48" } };
        readonly Dictionary<int, string> _dictionarySheetView1BeforeStaffDisplayName = new Dictionary<int, string> { { 0, "D38" }, { 1, "D42" }, { 2, "D46" } };
        readonly Dictionary<int, string> _dictionarySheetView1AfterDisplayName = new Dictionary<int, string> { { 0, "I38" }, { 1, "I42" }, { 2, "I46" } };
        readonly Dictionary<int, string> _dictionarySheetView1CellphoneNumber = new Dictionary<int, string> { { 0, "I40" }, { 1, "I44" }, { 2, "I48" } };
        /*
         * 代番のセル位置の紐づけ(SheetView2用)
         */
        Dictionary<int, string> _dictionarySheetView2BeforeStaffDisplayName = new Dictionary<int, string> { { 0, "D40" }, { 1, "D42" } };
        Dictionary<int, string> _dictionarySheetView2AfterDisplayName = new Dictionary<int, string> { { 0, "H40" }, { 1, "H42" } };

        private string _cleanOfficeName;
        private string _cleanOfficeFax;
        /*
         * Dao
         */
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_VehicleDispatchBodyDao _hVehicleDispatchBodyDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hSetControl"></param>
        public H_Substitute(ConnectionVo connectionVo, H_SetControl hSetControl) {
            /*
             * Dao
             */
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            _hVehicleDispatchBodyDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            /*
             * プリンターの一覧を取得後、通常使うプリンター名をセットする
             */
            foreach (string item in new Print().GetAllPrinterName()) {
                this.HComboBoxExPrinterName.Items.Add(item);
            }
            this.HComboBoxExPrinterName.Text = _printDocument.PrinterSettings.PrinterName;
            /*
             * 送信先FAX番号
             */
            this.HLabelExFaxNumber.Text = string.Empty;
            /*
             * FpSpreadを初期化
             */
            SpreadHSubstitute.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            InitializeSheetViewKYOTUU();
            InitializeSheetViewSAKURADAI();

            /*
             * FAXの宛先・FAX番号をセット
             */
            switch (((H_ControlVo)hSetControl.Tag).HSetMasterVo.SetCode) {
                case 1310101: // 千代田２
                case 1310102: // 千代田６
                case 1310103: // 千代田紙１
                    _cleanOfficeName = "　日盛運輸　様";
                    _cleanOfficeFax = string.Concat("千代田区支部", "\r\n", "ＦＡＸ ０３－３６７８－２６８８");
                    OutputSheetViewKYOTUU(SheetView1, hSetControl);
                    break;
                case 1310201: // 中央ペット７
                case 1310202: // 中央ペット８
                case 1310207: // 中央ペット１１
                    _cleanOfficeName = string.Concat("　東京都環境衛生事業協同組合", "\r\n", " 　中央区支部　様");
                    _cleanOfficeFax = string.Concat("中央区支部", "\r\n", " ＦＡＸ ０３－６２８０－５８４１");
                    OutputSheetViewKYOTUU(SheetView1, hSetControl);
                    break;
                case 1312161: // 足立１６
                case 1312134: // 足立１８
                case 1312162: // 足立２２
                case 1312164: // 足立２３
                case 1312103: // 足立２４
                case 1312163: // 足立３７
                case 1312104: // 足立３８
                case 1312105: // 足立不燃４
                    _cleanOfficeName = "　足立清掃事務所　御中";
                    _cleanOfficeFax = string.Concat("足立清掃事務所", "\r\n", " ＦＡＸ ０３－３８５７－５７４３");
                    OutputSheetViewKYOTUU(SheetView1, hSetControl);
                    break;
                case 1312204: // 葛飾１１
                case 1312211: // 葛飾軽１２
                case 1312209: // 葛飾３２
                case 1312210: // 葛飾５４
                    _cleanOfficeName = "　葛飾区清掃事務所　御中";
                    _cleanOfficeFax = string.Concat("葛飾区清掃事務所（新宿分室）", "\r\n", " ＦＡＸ ０３－３６０８－３３９７");
                    OutputSheetViewKYOTUU(SheetView1, hSetControl);
                    break;
                case 1312203: // 小岩４
                case 1312208: // 小岩５
                case 1312212: // 小岩６
                    _cleanOfficeName = "　小岩清掃事務所　御中";
                    _cleanOfficeFax = string.Concat("小岩清掃事務所", "\r\n", " ＦＡＸ ０３－３６７３－２５３５");
                    OutputSheetViewKYOTUU(SheetView1, hSetControl);
                    break;
                case 1312011: // 桜台2-1
                case 1312012: // 桜台2-2
                case 1312006: // 桜台臨時
                    _cleanOfficeName = string.Empty;
                    _cleanOfficeFax = string.Concat("東京都環境衛生事業協同組合 練馬区支部事務局", "\r\n", " ＦＡＸ ０３－５９４７－３４４１");
                    OutputSheetViewSAKURADAI(SheetView2, hSetControl);
                    break;
                default:
                    _cleanOfficeName = "";
                    _cleanOfficeFax = "";
                    OutputSheetViewKYOTUU(SheetView1, hSetControl);
                    break;
            }
        }

        /// <summary>
        /// OutputSheetViewKYOTUU
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="hSetControl"></param>
        private void OutputSheetViewKYOTUU(SheetView sheetView, H_SetControl hSetControl) {
            // シートを選択
            SpreadHSubstitute.ActiveSheetIndex = 0;
            int staffPutNumber = 0;
            int arrayLoopCount = 0;
            H_ControlVo hControlVo = (H_ControlVo)hSetControl.Tag;
            /*
             * 各要素を取得
             */
            // 本番登録のデータ
            H_VehicleDispatchBodyVo hVehicleDispatchBodyVo = _hVehicleDispatchBodyDao.SelectOneHVehicleDispatchBody(hControlVo.HSetMasterVo.SetCode, hControlVo.OperationDate.Date, _date.GetFiscalYear(hControlVo.OperationDate.Date));
            // 配車パネルのデータ
            H_SetMasterVo hSetMasterVo = hSetControl.GetSetMasterVo();
            H_CarMasterVo hCarMasterVo = hSetControl.GetCarMasterVo();

            // 日付
            CultureInfo cultureInfo = new CultureInfo("ja-JP", true);
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            sheetView.Cells["G3"].Text = DateTime.Now.ToString("gg y年M月d日", cultureInfo);
            // 宛先
            sheetView.Cells["B6"].Text = _cleanOfficeName;
            /*
             * 代車
             */
            if (hVehicleDispatchBodyVo.CarCode != hCarMasterVo.CarCode) {
                // 本番 組数 車両ナンバー ドア番号
                sheetView.Cells["B29"].Text = hSetMasterVo.SetName2;
                sheetView.Cells["C29"].Text = _hCarMasterDao.SelectOneHCarMasterP(hVehicleDispatchBodyVo.CarCode).RegistrationNumber;
                sheetView.Cells["F29"].Text = _hCarMasterDao.SelectOneHCarMasterP(hVehicleDispatchBodyVo.CarCode).DoorNumber.ToString();
                // 代車 車両ナンバー ドア番号
                sheetView.Cells["H29"].Text = _hCarMasterDao.SelectOneHCarMasterP(hCarMasterVo.CarCode).RegistrationNumber;
                sheetView.Cells["L29"].Text = _hCarMasterDao.SelectOneHCarMasterP(hCarMasterVo.CarCode).DoorNumber.ToString();
            }
            /*
             * 連絡先番号をセット
             */
            switch (hSetMasterVo.SetCode) {
                case 1312161: // 足立１６組
                case 1312105: // 足立不燃４
                case 1312203: // 小岩４
                case 1312212: // 小岩６
                case 1310207: // 中央ペット１１
                    _cellphoneNumber = _hStaffMasterDao.SelectOneHStaffMaster(hSetControl.GetStaffMasterVo(0).StaffCode).CellphoneNumber.ToString();
                    break;
                default:
                    _cellphoneNumber = _dictionaryTelephoneNumber[hSetMasterVo.SetCode];
                    break;
            }
            /*
             * 運転手
             */
            if (hSetControl.GetStaffMasterVo(0) is not null && hVehicleDispatchBodyVo.StaffCode1 != hSetControl.GetStaffMasterVo(0).StaffCode) {
                PutSheetView1(staffPutNumber, hSetMasterVo.SetName, "運転手", _hStaffMasterDao.SelectOneHStaffMaster(hVehicleDispatchBodyVo.StaffCode1).DisplayName, hSetControl.GetStaffMasterVo(0).DisplayName, _cellphoneNumber);
                staffPutNumber++;  // 次の行にインクリメントする
            }

            List<int> _arrayHONBANStaffCodes = new List<int>();
            List<int> _arrayDAIBANStaffCodes = new List<int>();
            // 本番の作業員コードを格納
            if (hVehicleDispatchBodyVo.StaffCode2 != 0)
                _arrayHONBANStaffCodes.Add(hVehicleDispatchBodyVo.StaffCode2);
            if (hVehicleDispatchBodyVo.StaffCode3 != 0)
                _arrayHONBANStaffCodes.Add(hVehicleDispatchBodyVo.StaffCode3);
            if (hVehicleDispatchBodyVo.StaffCode4 != 0)
                _arrayHONBANStaffCodes.Add(hVehicleDispatchBodyVo.StaffCode4);
            // 代番の作業員コードを格納
            if (hSetControl.GetStaffMasterVo(1) is not null)
                _arrayDAIBANStaffCodes.Add(hSetControl.GetStaffMasterVo(1).StaffCode);
            if (hSetControl.GetStaffMasterVo(2) is not null)
                _arrayDAIBANStaffCodes.Add(hSetControl.GetStaffMasterVo(2).StaffCode);
            if (hSetControl.GetStaffMasterVo(3) is not null)
                _arrayDAIBANStaffCodes.Add(hSetControl.GetStaffMasterVo(3).StaffCode);

            bool isEqual = _arrayHONBANStaffCodes.SequenceEqual(_arrayDAIBANStaffCodes);
            // Listを比較して同一で無ければ代番が存在する
            if (!isEqual) {
                List<int> staffCodes = new List<int>();
                staffCodes.AddRange(_arrayHONBANStaffCodes);
                staffCodes.AddRange(_arrayDAIBANStaffCodes);
                foreach (int staffCode in staffCodes) {
                    if (_arrayHONBANStaffCodes.Contains(staffCode) && _arrayDAIBANStaffCodes.Contains(staffCode)) {
                        _arrayHONBANStaffCodes.Remove(staffCode);
                        _arrayDAIBANStaffCodes.Remove(staffCode);
                    }
                }

                foreach (int staffCode in _arrayHONBANStaffCodes) {
                    PutSheetView1(staffPutNumber, hSetMasterVo.SetName, "職員",
                                  _hStaffMasterDao.SelectOneHStaffMaster(_arrayHONBANStaffCodes[arrayLoopCount]).DisplayName,
                                  _hStaffMasterDao.SelectOneHStaffMaster(_arrayDAIBANStaffCodes[arrayLoopCount]).DisplayName,
                                  _hStaffMasterDao.SelectOneHStaffMaster(_arrayDAIBANStaffCodes[arrayLoopCount]).CellphoneNumber);
                    staffPutNumber++; // 次の行にインクリメントする
                    arrayLoopCount++;
                }
            }
            // FAX番号他
            sheetView.Cells["H51"].Text = _cleanOfficeFax;
            /*
             * 送信先FAX番号
             */
            this.HLabelExFaxNumber.Text = _cleanOfficeFax;
        }

        /// <summary>
        /// OutputSheetViewSAKURADAI
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="hSetControl"></param>
        private void OutputSheetViewSAKURADAI(SheetView sheetView, H_SetControl hSetControl) {
            // シートを選択
            SpreadHSubstitute.ActiveSheetIndex = 1;
            int staffPutNumber = 0;
            int arrayLoopCount = 0;
            H_ControlVo hControlVo = (H_ControlVo)hSetControl.Tag;
            /*
             * 各要素を取得
             */
            // 本番登録のデータ
            H_VehicleDispatchBodyVo hVehicleDispatchBodyVo = _hVehicleDispatchBodyDao.SelectOneHVehicleDispatchBody(hControlVo.HSetMasterVo.SetCode, hControlVo.OperationDate.Date, _date.GetFiscalYear(hControlVo.OperationDate.Date));
            // 配車パネルのデータ
            H_SetMasterVo hSetMasterVo = hSetControl.GetSetMasterVo();
            /*
             * 作成日・組・曜日
             */
            CultureInfo cultureInfo = new CultureInfo("ja-JP", true);
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            sheetView.Cells["J3"].Text = DateTime.Now.ToString("gg y年M月d日", cultureInfo);
            sheetView.Cells["H18"].Text = string.Concat(hSetMasterVo.SetName2, " 組");
            sheetView.Cells["K18"].Text = string.Concat(hControlVo.OperationDate.ToString("dddd"));
            /*
             * 運転手代番の処理
             */
            if (hVehicleDispatchBodyVo.StaffCode1 != 0 && hVehicleDispatchBodyVo.StaffCode1 != hSetControl.GetStaffMasterVo(0).StaffCode) {
                // 運転手名
                sheetView.Cells["D21"].Text = hSetControl.GetStaffMasterVo(0).DisplayName;
                // 携帯番号 とりあえず車載携帯がくるまでは個人携帯で登録
                sheetView.Cells["J21"].Text = hSetControl.GetStaffMasterVo(0).CellphoneNumber.Length > 0 ? hSetControl.GetStaffMasterVo(0).CellphoneNumber : "☆携帯電話未登録☆";
                // 代番
                sheetView.Cells["D25"].Text = hControlVo.OperationDate.ToString("gg y年M月d日", cultureInfo);
                sheetView.Cells["I25"].Text = string.Concat(hControlVo.OperationDate.ToString("gg y年M月d日", cultureInfo), " 迄");
            }
            /*
             * 作業員代番の処理
             */
            List<int> _arrayHONBANStaffCodes = new();
            List<int> _arrayDAIBANStaffCodes = new();
            // 本番の作業員コードを格納
            if (hVehicleDispatchBodyVo.StaffCode2 != 0)
                _arrayHONBANStaffCodes.Add(hVehicleDispatchBodyVo.StaffCode2);
            if (hVehicleDispatchBodyVo.StaffCode3 != 0)
                _arrayHONBANStaffCodes.Add(hVehicleDispatchBodyVo.StaffCode3);
            // 代番の作業員コードを格納
            if (hSetControl.GetStaffMasterVo(1) is not null)
                _arrayDAIBANStaffCodes.Add(hSetControl.GetStaffMasterVo(1).StaffCode);
            if (hSetControl.GetStaffMasterVo(2) is not null)
                _arrayDAIBANStaffCodes.Add(hSetControl.GetStaffMasterVo(2).StaffCode);

            // Listを比較して同一で無ければ代番が存在する
            if (!_arrayHONBANStaffCodes.SequenceEqual(_arrayDAIBANStaffCodes)) {
                // 代番日付
                sheetView.Cells["D37"].Text = hControlVo.OperationDate.ToString("gg y年M月d日", cultureInfo);
                sheetView.Cells["I37"].Text = string.Concat(hControlVo.OperationDate.ToString("gg y年M月d日", cultureInfo), " 迄");

                List<int> staffCodes = new List<int>();
                staffCodes.AddRange(_arrayHONBANStaffCodes);
                staffCodes.AddRange(_arrayDAIBANStaffCodes);
                foreach (int staffCode in staffCodes) {
                    if (_arrayHONBANStaffCodes.Contains(staffCode) && _arrayDAIBANStaffCodes.Contains(staffCode)) {
                        _arrayHONBANStaffCodes.Remove(staffCode);
                        _arrayDAIBANStaffCodes.Remove(staffCode);
                    }
                }
                foreach (int staffCode in _arrayHONBANStaffCodes) {
                    PutSheetView2(staffPutNumber,
                                  _hStaffMasterDao.SelectOneHStaffMaster(_arrayHONBANStaffCodes[arrayLoopCount]).DisplayName,
                                  _hStaffMasterDao.SelectOneHStaffMaster(_arrayDAIBANStaffCodes[arrayLoopCount]).DisplayName);
                    staffPutNumber++; // 次の行にインクリメントする
                    arrayLoopCount++;
                }
            }
            /*
             * 代車の処理
             */
            if (hVehicleDispatchBodyVo.CarCode != 0 && hVehicleDispatchBodyVo.CarCode != hSetControl.GetCarMasterVo().CarCode) {
                sheetView.Cells["G45"].Text = string.Concat(hSetControl.GetCarMasterVo().RegistrationNumber, " (", hSetControl.GetCarMasterVo().DoorNumber, ")");
                sheetView.Cells["D49"].Text = hControlVo.OperationDate.ToString("gg y年M月d日", cultureInfo);
                sheetView.Cells["I49"].Text = string.Concat(hControlVo.OperationDate.ToString("gg y年M月d日", cultureInfo), " 迄");
            }
            /*
             * 送信先FAX番号
             */
            this.HLabelExFaxNumber.Text = _cleanOfficeFax;
        }

        /// <summary>
        /// PutSheetView1
        /// 共通のシート
        /// </summary>
        /// <param name="rowNumber">挿入位置</param>
        /// <param name="setName">配車先名</param>
        /// <param name="occupation"></param>
        /// <param name="beforeDisplayName"></param>
        /// <param name="afterDisplayName"></param>
        /// <param name="cellphoneNumber"></param>
        private void PutSheetView1(int rowNumber, string setName, string occupation, string beforeDisplayName, string afterDisplayName, string cellphoneNumber) {
            SheetView1.Cells[_dictionarySheetView1SetName[rowNumber]].Text = string.Concat(setName, "組");
            SheetView1.Cells[_dictionarySheetView1Occupation[rowNumber]].Text = occupation;
            SheetView1.Cells[_dictionarySheetView1BeforeStaffDisplayName[rowNumber]].Text = beforeDisplayName;
            SheetView1.Cells[_dictionarySheetView1AfterDisplayName[rowNumber]].Text = afterDisplayName;
            SheetView1.Cells[_dictionarySheetView1CellphoneNumber[rowNumber]].Text = cellphoneNumber;
        }

        /// <summary>
        /// PutSheetView2
        /// 桜台用のシート
        /// </summary>
        /// <param name="rowNumber">挿入位置</param>
        /// <param name="beforeDisplayName">本番従事者名</param>
        /// <param name="afterDisplayName">代番従事者名</param>
        private void PutSheetView2(int rowNumber, string beforeDisplayName, string afterDisplayName) {
            SheetView2.Cells[_dictionarySheetView2BeforeStaffDisplayName[rowNumber]].Text = beforeDisplayName;
            SheetView2.Cells[_dictionarySheetView2AfterDisplayName[rowNumber]].Text = afterDisplayName;
        }

        /// <summary>
        /// InitializeSheetViewList1
        /// </summary>
        private void InitializeSheetViewKYOTUU() {
            // 作成日付
            SheetView1.Cells["G3"].ResetValue();
            // 送り先
            SheetView1.Cells["B6"].ResetValue();
            /*
             * 代車
             */
            // １行目
            SheetView1.Cells["B29"].ResetValue();
            SheetView1.Cells["C29"].ResetValue();
            SheetView1.Cells["F29"].ResetValue();
            SheetView1.Cells["H29"].ResetValue();
            SheetView1.Cells["L29"].ResetValue();
            // ２行目
            SheetView1.Cells["B31"].ResetValue();
            SheetView1.Cells["C31"].ResetValue();
            SheetView1.Cells["F31"].ResetValue();
            SheetView1.Cells["H31"].ResetValue();
            SheetView1.Cells["L31"].ResetValue();
            /*
             * 代番
             */
            // １行目
            SheetView1.Cells["B38"].ResetValue(); // 組
            SheetView1.Cells["B40"].ResetValue(); // 運転手・職員
            SheetView1.Cells["D38"].ResetValue(); // 本番氏名
            SheetView1.Cells["I38"].ResetValue(); // 代番氏名
            SheetView1.Cells["I40"].ResetValue(); // 代番携帯番号
            // ２行目
            SheetView1.Cells["B42"].ResetValue(); // 組
            SheetView1.Cells["B44"].ResetValue(); // 運転手・職員
            SheetView1.Cells["D42"].ResetValue(); // 本番氏名
            SheetView1.Cells["I42"].ResetValue(); // 代番氏名
            SheetView1.Cells["I44"].ResetValue(); // 代番携帯番号
            // ３行目
            SheetView1.Cells["B46"].ResetValue(); // 組
            SheetView1.Cells["B48"].ResetValue(); // 運転手・職員
            SheetView1.Cells["D46"].ResetValue(); // 本番氏名
            SheetView1.Cells["I46"].ResetValue(); // 代番氏名
            SheetView1.Cells["I48"].ResetValue(); // 代番携帯番号
            SheetView1.Cells["H51"].ResetValue(); // 送り先
        }

        /// <summary>
        /// InitializeSheetViewList2
        /// </summary>
        private void InitializeSheetViewSAKURADAI() {
            // 作成日付
            SheetView2.Cells["J3"].ResetValue();
            // １-組名・曜日
            SheetView2.Cells["H18"].ResetValue();
            SheetView2.Cells["K18"].ResetValue();
            // ２-運転手名・携帯番号・交代・代番
            SheetView2.Cells["D21"].ResetValue();
            SheetView2.Cells["J21"].ResetValue();
            SheetView2.Cells["D23"].ResetValue();
            SheetView2.Cells["D25"].ResetValue();
            SheetView2.Cells["I25"].ResetValue();
            // ３-作業員名・交代・代番
            SheetView2.Cells["D30"].ResetValue();
            SheetView2.Cells["D33"].ResetValue();
            SheetView2.Cells["H33"].ResetValue();
            SheetView2.Cells["D35"].ResetValue();
            SheetView2.Cells["H35"].ResetValue();
            SheetView2.Cells["D37"].ResetValue();
            SheetView2.Cells["I37"].ResetValue();
            SheetView2.Cells["D40"].ResetValue();
            SheetView2.Cells["H40"].ResetValue();
            SheetView2.Cells["D42"].ResetValue();
            SheetView2.Cells["H42"].ResetValue();
            // ４-収集車両・交代・代番
            SheetView2.Cells["G45"].ResetValue();
            SheetView2.Cells["D47"].ResetValue();
            SheetView2.Cells["D49"].ResetValue();
            SheetView2.Cells["I49"].ResetValue();
        }

        /// <summary>
        /// HButtonExPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExPrint_Click(object sender, EventArgs e) {
            // Eventを登録
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            // 出力先プリンタを指定します。
            _printDocument.PrinterSettings.PrinterName = this.HComboBoxExPrinterName.Text;
            // 用紙の向きを設定(横：true、縦：false)
            _printDocument.DefaultPageSettings.Landscape = false;
            /*
             * プリンタがサポートしている用紙サイズを調べる
             */
            foreach (PaperSize paperSize in _printDocument.PrinterSettings.PaperSizes) {
                // B5用紙に設定する
                if (paperSize.Kind == PaperKind.A4) {
                    _printDocument.DefaultPageSettings.PaperSize = paperSize;
                    break;
                }
            }
            // 印刷部数を指定します。
            _printDocument.PrinterSettings.Copies = 1;
            // 片面印刷に設定します。
            _printDocument.PrinterSettings.Duplex = Duplex.Default;
            // カラー印刷に設定します。
            _printDocument.PrinterSettings.DefaultPageSettings.Color = true;
            // 印刷する
            _printDocument.Print();
        }

        /// <summary>
        /// PrintDocument_PrintPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            int sheetNumber = SpreadHSubstitute.ActiveSheetIndex;
            // 印刷ページ（1ページ目）の描画を行う
            Rectangle rectangle = new(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
            // e.Graphicsへ出力(page パラメータは、０からではなく１から始まります)
            SpreadHSubstitute.OwnerPrintDraw(e.Graphics, rectangle, sheetNumber, 1);
            // 印刷終了を指定
            e.HasMorePages = false;
        }

        /// <summary>
        /// H_Substitute_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_Substitute_FormClosing(object sender, FormClosingEventArgs e) {
            _printDocument.Dispose();
            this.Dispose();
        }
    }
}
