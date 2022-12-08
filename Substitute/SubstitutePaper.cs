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
         * 清掃事務所名・FAX番号
         */
        private string _cleanOfficeName;
        private string _cleanOfficeFax;

        /// <summary>
        /// コンストラクター
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
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // シートタブを非表示
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;
            // 配車先を読込む
            _setMasterVo = new SetMasterDao(_connectionVo).SelectOneSetMaster(setCode);
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            /*
             * FAXの宛先・FAX番号をセット
             */
            switch(setCode) {
                case 1310101: // 千代田２
                case 1310102: // 千代田６
                case 1310103: // 千代田紙１
                    _cleanOfficeName = "　日盛運輸　様";
                    _cleanOfficeFax = string.Concat("千代田区支部", "\r\n", "ＦＡＸ ０３−３６７８−２６８８");
                    break;
                case 1310201: // 中央ペット７
                case 1310202: // 中央ペット８
                    _cleanOfficeName = string.Concat("　東京都環境衛生事業協同組合", "\r\n", " 　中央区支部　様");
                    _cleanOfficeFax = string.Concat("中央区支部", "\r\n", " ＦＡＸ ０３−６２８０−５８４１");
                    break;
                case 1312101: // 足立１８
                case 1312102: // 足立２３
                case 1312103: // 足立２４
                case 1312104: // 足立３８
                case 1312105: // 足立不燃４
                    _cleanOfficeName = "　足立清掃事務所　御中";
                    _cleanOfficeFax = string.Concat("足立清掃事務所", "\r\n", " ＦＡＸ ０３−３８５７−５７４３");
                    break;
                case 1312204: // 葛飾１１
                case 1312201: // 葛飾３３
                case 1312202: // 葛飾５５
                    _cleanOfficeName = "　葛飾区清掃事務所　御中";
                    _cleanOfficeFax = string.Concat("葛飾区清掃事務所（新宿分室）", "\r\n", " ＦＡＸ ０３−３６０８−３３９７");
                    break;
                case 1312203: // 小岩４
                    _cleanOfficeName = "　小岩清掃事務所　御中";
                    _cleanOfficeFax = string.Concat("小岩清掃事務所", "\r\n", " ＦＡＸ ０３−３６７３−２５３５");
                    break;
            }

            InitializeSheetViewPaper();
            PutSheetViewPaper();
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// PutSheetViewPaper
        /// </summary>
        private void PutSheetViewPaper() {
            // 日付
            var Japanese = new CultureInfo("ja-JP", true);
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewPaper.Cells["G3"].Text = DateTime.Now.ToString("gg y年M月d日", Japanese);
            // 宛先
            SheetViewPaper.Cells["B6"].Text = _cleanOfficeName;
            /*
             * 代車
             */
            // �@まずは配車先が格納されているCellNumberを取得する
            int cellNumber = _vehicleDispatchDetailDao.GetCellNumber(_vehicleDispatchDetailVo.Set_code);
            // �A清掃事務所に登録されている本番車両を取得する
            int carCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetCarCode(cellNumber);
            // �B代車の処理
            if(_vehicleDispatchDetailVo.Car_code != 0 && carCodeCleanOffice != _vehicleDispatchDetailVo.Car_code) {
                // 変更前 組数 車両ナンバー ドア番号
                SheetViewPaper.Cells["B29"].Text = _setMasterVo.Set_name_2;
                SheetViewPaper.Cells["C29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Registration_number;
                SheetViewPaper.Cells["F29"].Text = _listCarMasterVo.Find(x => x.Car_code == carCodeCleanOffice).Door_number.ToString();
                // 変更後 車両ナンバー ドア番号
                SheetViewPaper.Cells["H29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Registration_number;
                SheetViewPaper.Cells["L29"].Text = _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Door_number.ToString();
            }
            /*
             * 代番
             */
            string telephoneNumber = "";
            Dictionary<int, string> dictionaryTelephoneNumber = new Dictionary<int, string> { { 1310101, "090-6506-7967" }, // 千代田２
                                                                                              { 1310102, "080-8868-7459" }, // 千代田６
                                                                                              { 1310103, "080-8868-8023" }, // 千代田紙１
                                                                                              { 1310201, "080-2202-7713" }, // 中央ペット７
                                                                                              { 1310202, "080-3493-3729" }, // 中央ペット８
                                                                                              { 1312101, "" }, // 足立１８
                                                                                              { 1312102, "090-5560-0491" }, // 足立２３
                                                                                              { 1312103, "090-5560-0677" }, // 足立２４
                                                                                              { 1312104, "090-5560-0700" }, // 足立３８
                                                                                              { 1312204, "090-9817-8129" }, // 葛飾１１
                                                                                              { 1312201, "080-3493-3728" }, // 葛飾３３
                                                                                              { 1312202, "080-2202-7269" }, // 葛飾５５
                                                                                              { 1312203, "" } }; // 小岩４
            // 連絡先番号をセット
            switch(_vehicleDispatchDetailVo.Set_code) {
                case 1312105: // 足立不燃４
                    telephoneNumber = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Telephone_number;
                    break;
                default:
                    telephoneNumber = dictionaryTelephoneNumber[_vehicleDispatchDetailVo.Set_code];
                    break;
            }
            // �@清掃事務所に登録されている本番Oprator1を取得する 
            int operatorCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetOperatorCode1(cellNumber);
            // �A運転手代番の処理
            if(_vehicleDispatchDetailVo.Operator_code_1 != 0 && operatorCodeCleanOffice != _vehicleDispatchDetailVo.Operator_code_1) {
                // 変更前　組数　氏名
                SheetViewPaper.Cells["B38"].Text = string.Concat(_setMasterVo.Set_name, "組");
                SheetViewPaper.Cells["D38"].Text = _listStaffMasterVo.Find(x => x.Staff_code == operatorCodeCleanOffice).Display_name;
                // 変更後　氏名　携帯番号
                SheetViewPaper.Cells["I38"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Display_name;
                SheetViewPaper.Cells["I40"].Text = telephoneNumber;
            }
            // �B作業員代番の処理 Listにそれぞれ格納する
            List<int> _arrayCleanOfficeStaffCodes = new List<int>();
            List<int> _arrayVehicleDispatchDetailStaffCodes = new List<int>();
            // VehicleDispatchBodyCleanOfficeの作業員コードを格納
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode2(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode2(cellNumber));
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode3(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode3(cellNumber));
            if(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode4(cellNumber) != 0)
                _arrayCleanOfficeStaffCodes.Add(_vehicleDispatchBodyCleanOfficeDao.GetOperatorCode4(cellNumber));
            // VehicleDispatchDetailVoの作業員コードを格納
            if(_vehicleDispatchDetailVo.Operator_code_2 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_2);
            if(_vehicleDispatchDetailVo.Operator_code_3 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_3);
            if(_vehicleDispatchDetailVo.Operator_code_4 != 0)
                _arrayVehicleDispatchDetailStaffCodes.Add(_vehicleDispatchDetailVo.Operator_code_4);
            // �Cここの状態で、_arrayCleanOfficeStaffCodesと_arrayVehicleDispatchDetailStaffCodesにデータが格納されている
            bool isEqual = _arrayCleanOfficeStaffCodes.SequenceEqual(_arrayVehicleDispatchDetailStaffCodes);
            // Listを比較して同一で無ければ代番が存在する
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
                int i = 0;
                foreach(int staffCode in _arrayCleanOfficeStaffCodes) {
                    switch(i) {
                        case 0:
                            SheetViewPaper.Cells["B42"].Text = string.Concat(_setMasterVo.Set_name, "組");
                            SheetViewPaper.Cells["D42"].Text = _listStaffMasterVo.Find(x => x.Staff_code == staffCode).Display_name;
                            SheetViewPaper.Cells["I42"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _arrayVehicleDispatchDetailStaffCodes[i]).Display_name;
                            SheetViewPaper.Cells["I44"].Text = telephoneNumber;
                            break;
                        case 1:
                            SheetViewPaper.Cells["B46"].Text = string.Concat(_setMasterVo.Set_name, "組");
                            SheetViewPaper.Cells["D46"].Text = _listStaffMasterVo.Find(x => x.Staff_code == staffCode).Display_name;
                            SheetViewPaper.Cells["I46"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _arrayVehicleDispatchDetailStaffCodes[i]).Display_name;
                            SheetViewPaper.Cells["I48"].Text = telephoneNumber;
                            break;
                        default:
                            MessageBox.Show("代番作業員を３名記録はできません");
                            break;
                    }


                    i++;
                }
            }
            // FAX番号他
            SheetViewPaper.Cells["H51"].Text = _cleanOfficeFax;
        }

        int _staffPutNumber = 0; // 代番を記載するRow番号
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
            Dictionary<int, string> cellSetName = new Dictionary<int, string> { { 0, "B38" }, { 1, "B42" }, { 2, "B46" } };

        }

        private void InitializeSheetViewPaper() {
            // 作成日付
            SheetViewPaper.Cells["G3"].ResetValue();
            // 送り先
            SheetViewPaper.Cells["B6"].ResetValue();
            /*
             * 代車
             */
            // １行目
            SheetViewPaper.Cells["B29"].ResetValue();
            SheetViewPaper.Cells["C29"].ResetValue();
            SheetViewPaper.Cells["F29"].ResetValue();
            SheetViewPaper.Cells["H29"].ResetValue();
            SheetViewPaper.Cells["L29"].ResetValue();
            // ２行目
            SheetViewPaper.Cells["B31"].ResetValue();
            SheetViewPaper.Cells["C31"].ResetValue();
            SheetViewPaper.Cells["F31"].ResetValue();
            SheetViewPaper.Cells["H31"].ResetValue();
            SheetViewPaper.Cells["L31"].ResetValue();
            /*
             * 代番
             */
            // １行目
            SheetViewPaper.Cells["B38"].ResetValue(); // 組
            SheetViewPaper.Cells["D38"].ResetValue(); // 本番氏名
            SheetViewPaper.Cells["I38"].ResetValue(); // 代番氏名
            SheetViewPaper.Cells["I40"].ResetValue(); // 代番携帯番号
                                                      // ２行目
            SheetViewPaper.Cells["B42"].ResetValue(); // 組
            SheetViewPaper.Cells["D42"].ResetValue(); // 本番氏名
            SheetViewPaper.Cells["I42"].ResetValue(); // 代番氏名
            SheetViewPaper.Cells["I44"].ResetValue(); // 代番携帯番号
                                                      // ３行目
            SheetViewPaper.Cells["B46"].ResetValue(); // 組
            SheetViewPaper.Cells["D46"].ResetValue(); // 本番氏名
            SheetViewPaper.Cells["I46"].ResetValue(); // 代番氏名
            SheetViewPaper.Cells["I48"].ResetValue(); // 代番携帯番号
                                                      // 送り先
            SheetViewPaper.Cells["H51"].ResetValue();
        }

        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadPaper.PrintSheet(SheetViewPaper);
        }
    }
}