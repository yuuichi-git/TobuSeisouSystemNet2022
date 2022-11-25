/*
 * 2022-11-23
 */
using Dao;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

using Vo;

using IFont = NPOI.SS.UserModel.IFont;

namespace VehicleDispatch {
    public partial class VehicleDispatchExcel : Form {
        private readonly DateTime _oprationDate;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;

        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;


        IWorkbook _iWorkbook;
        ISheet _iSheet;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public VehicleDispatchExcel(ConnectionVo connectionVo, DateTime oprationDate) {
            _oprationDate = oprationDate;

            InitializeComponent();

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

            /*
             * ブック読み込み
             */
            _iWorkbook = (HSSFWorkbook?)WorkbookFactory.Create("C:\\Users\\yuuic\\Desktop\\配車当日.xls");
            /*
             * シート名からシート取得
             */
            _iSheet = _iWorkbook?.GetSheet("配車表");
        }

        /// <summary>
        /// WriteCell
        /// ("作業員"が入るもの以外の文字列)
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="value"></param>
        private void WriteCell(int columnIndex, int rowIndex, string value) {
            ICell iCell = _iSheet.GetRow(rowIndex).GetCell(columnIndex);
            IFont iFont = _iWorkbook.CreateFont();
            HSSFRichTextString hSSFRichTextString = new HSSFRichTextString(value);

            iFont.FontName = "ＭＳ Ｐ明朝";
            iFont.FontHeightInPoints = 11;
            hSSFRichTextString.ApplyFont(iFont);
            iCell.SetCellValue(hSSFRichTextString);
        }

        /// <summary>
        /// WriteCellIsStrikeout
        /// 取り消し線
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="value"></param>
        private void WriteCellIsStrikeout(int columnIndex, int rowIndex, string value) {
            ICell iCell = _iSheet.GetRow(rowIndex).GetCell(columnIndex);
            IFont iFont = _iWorkbook.CreateFont();
            HSSFRichTextString hSSFRichTextString = new HSSFRichTextString(value);

            iFont.FontName = "ＭＳ Ｐ明朝";
            iFont.FontHeightInPoints = 11;
            iFont.IsStrikeout = true; // 取り消し線
            hSSFRichTextString.ApplyFont(iFont);
            iCell.SetCellValue(hSSFRichTextString);
        }

        /// <summary>
        /// WriteCellStaff
        /// "作業員"の文字のサイズを6に設定する
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="value"></param>
        private void WriteCellStaff(int columnIndex, int rowIndex, string value) {
            ICell iCell = _iSheet.GetRow(rowIndex).GetCell(columnIndex);
            IFont iFont = _iWorkbook.CreateFont();
            HSSFRichTextString hSSFRichTextString = new HSSFRichTextString(value);

            iFont.FontName = "ＭＳ Ｐ明朝";
            iFont.FontHeightInPoints = 6; //フォントサイズを6pointにする(作業員の部分)
            iFont.Color = IndexedColors.Grey40Percent.Index;
            hSSFRichTextString.ApplyFont(0, 3, iFont);

            iCell.SetCellValue(hSSFRichTextString);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOutputExcel_Click(object sender, EventArgs e) {
            ExcelDataOutput();
        }

        /// <summary>
        /// ToolStripMenuItemSelectExcel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelDataOutput() {
            try {
                /*
                 * セルに値をセット
                 */
                foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectVehicleDispatchDetail(_oprationDate)) {
                    switch(vehicleDispatchDetailVo.Set_code) {
                        /*
                         * 雇上小特　コード１
                         */
                        case 1310401: // 新宿１－８２
                            SetOperator1(vehicleDispatchDetailVo, 0, 5);
                            break;
                        case 1311701: // 北１２
                            SetOperator1(vehicleDispatchDetailVo, 0, 6);
                            break;
                        /*
                         * 雇上小プレ　コード１
                         */
                        case 1310402: // 新宿１－８１
                            SetOperator3(vehicleDispatchDetailVo, 0, 8);
                            break;
                        case 1310403: // 新宿１－６１
                            SetOperator1(vehicleDispatchDetailVo, 0, 10);
                            break;
                        case 1310404: // 新宿１－６２
                            SetOperator3(vehicleDispatchDetailVo, 0, 11);
                            break;
                        case 1311901: // 板橋西５５
                            SetOperator3(vehicleDispatchDetailVo, 0, 13);
                            break;
                        case 1312101: // 足立１８
                            SetOperator1(vehicleDispatchDetailVo, 0, 15);
                            break;
                        case 1312102: // 足立２３
                            SetOperator3(vehicleDispatchDetailVo, 0, 16);
                            break;
                        case 1312103: // 足立２４
                            SetOperator3(vehicleDispatchDetailVo, 0, 18);
                            break;
                        case 1312104: // 足立３８
                            SetOperator3(vehicleDispatchDetailVo, 0, 20);
                            break;
                        case 1312201: // 葛飾３３
                            SetOperator3(vehicleDispatchDetailVo, 0, 22);
                            break;
                        case 1312202: // 葛飾５５
                            SetOperator3(vehicleDispatchDetailVo, 0, 24);
                            break;
                        case 1311702: // 北２０１
                            SetOperator3(vehicleDispatchDetailVo, 0, 26);
                            break;
                        /*
                         * 雇上新大特　コード２
                         */
                        case 1310405: // 新宿１－３１
                            SetOperator1(vehicleDispatchDetailVo, 0, 31);
                            break;
                        case 1310801: // 江東１
                            SetOperator1(vehicleDispatchDetailVo, 0, 32);
                            break;
                        case 1310802: // 江東４
                            SetOperator1(vehicleDispatchDetailVo, 0, 33);
                            break;
                        case 1310803: // 江東７
                            SetOperator4(vehicleDispatchDetailVo, 0, 34);
                            break;
                        case 1310804: // 江東１４
                            SetOperator4(vehicleDispatchDetailVo, 0, 36);
                            break;
                        case 1311501: // 方南１０６
                            SetOperator1(vehicleDispatchDetailVo, 0, 38);
                            break;
                        case 1311801: // 荒川５
                            SetOperator1(vehicleDispatchDetailVo, 0, 39);
                            break;
                        case 1312203: // 小岩４
                            SetOperator1(vehicleDispatchDetailVo, 0, 40);
                            break;
                        /*
                         * 雇上軽小ダンプ　コード５１
                         */
                        case 1311502: // 方南４０８
                            SetOperator1(vehicleDispatchDetailVo, 0, 42);
                            break;
                        case 1311705: // 北軽２１
                            SetOperator2(vehicleDispatchDetailVo, 0, 43);
                            break;
                        case 1311902: // 板橋西軽１号車
                            SetOperator2(vehicleDispatchDetailVo, 0, 44);
                            break;
                        case 1311903: // 板橋西軽３号車
                            SetOperator2(vehicleDispatchDetailVo, 0, 45);
                            break;
                        case 1311904: // 板橋西軽７号車
                            SetOperator2(vehicleDispatchDetailVo, 0, 46);
                            break;
                        case 1312001: // 石神井軽４
                            SetOperator1(vehicleDispatchDetailVo, 0, 47);
                            break;
                        case 1312105: // 足立不燃４
                            SetOperator1(vehicleDispatchDetailVo, 0, 48);
                            break;
                        case 1312204: // 葛飾軽１１
                            SetOperator2(vehicleDispatchDetailVo, 0, 49);
                            break;
                        /*
                         * 雇上軽小型貨物　コード１１
                         */
                        case 1310601: // 台東軽小ー６
                            SetOperator1(vehicleDispatchDetailVo, 0, 51);
                            break;
                        /*
                         * 区契軽小型貨物　コード１１
                         */
                        case 1310406: // 新宿区契
                            SetOperator1(vehicleDispatchDetailVo, 0, 53);
                            break;
                        case 1311706: // 北区粗大
                            SetOperator2(vehicleDispatchDetailVo, 0, 54);
                            break;
                        /*
                         * 区契小プレ　コード１
                         */
                        case 1310407: // 新宿区容リ３－１
                            SetOperator2(vehicleDispatchDetailVo, 0, 56);
                            break;
                        case 1310408: // 新宿区容リ２－１
                            SetOperator2(vehicleDispatchDetailVo, 0, 57);
                            break;
                        case 1312002: // 練馬区容リ２－１
                            SetOperator1(vehicleDispatchDetailVo, 0, 58);
                            break;
                        case 1312003: // 練馬区容リ２－２
                            SetOperator1(vehicleDispatchDetailVo, 0, 59);
                            break;
                        /*
                         * 区契小プレ　コード２３
                         */
                        case 1310409: // 新宿ペット
                            SetOperator2(vehicleDispatchDetailVo, 0, 61);
                            break;
                        case 1310410: // 新宿ペット(曜日)
                            SetOperator2(vehicleDispatchDetailVo, 0, 62);
                            break;
                        /*
                         *  区契小プレ　コード８
                         */
                        case 1310201: // 中央ペット７
                            SetOperator2(vehicleDispatchDetailVo, 0, 64);
                            break;
                        case 1310202: // 中央ペット８
                            SetOperator2(vehicleDispatchDetailVo, 0, 65);
                            break;
                        case 1310101: // 千代田区容リ２
                            SetOperator2(vehicleDispatchDetailVo, 0, 66);
                            break;
                        case 1310102: // 千代田区容リ６
                            SetOperator2(vehicleDispatchDetailVo, 0, 67);
                            break;
                        case 1310103: // 千代田区紙１
                            SetOperator2(vehicleDispatchDetailVo, 0, 68);
                            break;
                        case 1311905: // 板橋区ペット１
                            SetOperator3(vehicleDispatchDetailVo, 0, 69);
                            break;
                        /*
                         * 区契平ボディー　コード１５
                         */
                        case 1312106: // 足立区瓶・缶１
                            SetOperator3(vehicleDispatchDetailVo, 0, 72);
                            break;
                        case 1310602: // 台東区資源１
                            SetOperator3(vehicleDispatchDetailVo, 0, 74);
                            break;
                        case 1310603: // 台東区資源２
                            SetOperator3(vehicleDispatchDetailVo, 0, 76);
                            break;
                        case 1310604: // 台東区資源４(臨時区契平ボディーに入れる)
                            SetOperator3(vehicleDispatchDetailVo, 26, 52);
                            break;
                        /*
                         * 区契小G　コード１
                         */
                        case 1310411: // 新宿区粗大４
                            SetOperator3(vehicleDispatchDetailVo, 26, 5);
                            break;
                        case 1310412: // 新宿区粗大５
                            SetOperator3(vehicleDispatchDetailVo, 26, 7);
                            break;
                        case 1312004: // 練馬区粗大６
                            SetOperator1(vehicleDispatchDetailVo, 26, 9);
                            break;
                        case 1312005: // 練馬区粗大９
                            SetOperator1(vehicleDispatchDetailVo, 26, 10);
                            break;
                        case 1311707: // 北区粗大１
                            SetOperator3(vehicleDispatchDetailVo, 26, 11);
                            break;
                        case 1311708: // 北区粗大２
                            SetOperator3(vehicleDispatchDetailVo, 26, 13);
                            break;
                        case 1311709: // 北区粗大３
                            SetOperator3(vehicleDispatchDetailVo, 26, 15);
                            break;
                        case 1311710: // 北区粗大４
                            SetOperator3(vehicleDispatchDetailVo, 26, 17);
                            break;
                        case 1311711: // 北区粗大５
                            SetOperator3(vehicleDispatchDetailVo, 26, 19);
                            break;
                        case 1311712: // 北区粗大臨時
                            SetOperator3(vehicleDispatchDetailVo, 26, 21);
                            break;

                        /*
                         * 整備　コード１
                         */
                        case 1312111: // 整備本社
                            SetOperator2(vehicleDispatchDetailVo, 26, 76);
                            break;
                        case 1312112: // 整備三郷
                            SetOperator2(vehicleDispatchDetailVo, 26, 66);
                            break;

                        default:
                            /*
                             * 雇上大G　コード５
                             */
                            switch(vehicleDispatchDetailVo.Cell_number) {
                                case 76:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 24); // 破砕コンテナ
                                    break;
                                case 77:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 25); // 破砕等
                                    break;
                                case 78:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 26); // 破砕等
                                    break;
                                case 79:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 27); // 破砕等
                                    break;
                                case 80:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 28); // 破砕等
                                    break;
                                case 81:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 29); // 破砕等
                                    break;
                                case 82:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 30); // 破砕等
                                    break;
                                case 83:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 31); // 破砕等
                                    break;
                                case 84:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 32); // 破砕等
                                    break;
                                case 85:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 33); // 破砕等
                                    break;
                                case 86:
                                    if(vehicleDispatchDetailVo.Operation_flag)
                                        SetOperator1(vehicleDispatchDetailVo, 26, 34); // 破砕等
                                    break;
                            }
                            break;
                    }
                }

                using(var fileStream = new FileStream("C:\\Users\\yuuic\\Desktop\\配車当日.xls", FileMode.Create))
                    _iWorkbook.Write(fileStream, true);

                MessageBox.Show("書き出しを完了しました");
            }
          //ファイル作成時に例外が発生した場合の処理
          catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "" }, { 11, "" }, { 12, "バ" }, { 20, "新" }, { 21, "自" } };
        private Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "" }, { 11, "作" }, { 99, "" } };
        /// <summary>
        /// SetOperator1
        /// 運転手１名
        /// </summary>
        /// <param name="iSheet"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void SetOperator1(VehicleDispatchDetailVo vehicleDispatchDetailVo, int col, int row) {
            StaffMasterVo staffMasterVo;
            string stringBelongs;

            if(vehicleDispatchDetailVo.Operation_flag) {
                // 配車先
                WriteCell(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1);
                // 組数
                WriteCell(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
                if(vehicleDispatchDetailVo.Car_code != 0) {
                    // ドア番号
                    WriteCell(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString());
                    // ナンバー(数字部分)
                    WriteCell(col + 3, row, string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3.ToString()
                                                                            ,_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()));
                    // 代車のドア番

                }
                // 運転手
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                if(staffMasterVo != null) {
                    WriteCell(col + 8, row, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Occupation];
                    WriteCell(col + 9, row, stringBelongs);
                    // 運転手(本社・三郷)
                    WriteCell(col + 10, row, vehicleDispatchDetailVo.Garage_flag ? "" : "三");
                    // 点呼項目（点呼方法・点呼時刻・免許・健康・点検・飲酒・検知器）
                    WriteCell(col + 14, row, "対面");
                    WriteCell(col + 16, row, vehicleDispatchDetailVo.Operation_date.ToString("mm:ss"));
                    WriteCell(col + 17, row, "✓");
                    WriteCell(col + 18, row, "✓");
                    WriteCell(col + 19, row, "✓");
                    WriteCell(col + 20, row, "✓");
                    WriteCell(col + 21, row, "有");
                } else {
                    WriteCell(col + 8, row, "");
                    WriteCell(col + 9, row, "");
                    WriteCell(col + 10, row, "");
                    WriteCell(col + 14, row, ""); // 点呼方法
                    WriteCell(col + 16, row, ""); // 点呼時間
                    WriteCell(col + 17, row, ""); // 免許
                    WriteCell(col + 18, row, ""); // 健康
                    WriteCell(col + 19, row, ""); // 点検
                    WriteCell(col + 20, row, ""); // 飲酒
                    WriteCell(col + 21, row, ""); // 検知器
                }
            } else {
                WriteCellIsStrikeout(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1); // 配車先
                WriteCellIsStrikeout(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2); // 組数
                WriteCellIsStrikeout(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString()); // ドア番号
                WriteCellIsStrikeout(col + 3, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()); // ナンバー(数字部分)
                WriteCell(col + 8, row, "休　車"); // 運転手
                WriteCell(col + 9, row, ""); // 新・自・新作・自作・バ・バ作
                WriteCell(col + 10, row, ""); // 運転手(本社・三郷)
            }
        }

        /// <summary>
        /// SetOperator2
        /// 運転手１名と作業員１名
        /// </summary>
        /// <param name="iWorkbook"></param>
        /// <param name="iSheet"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void SetOperator2(VehicleDispatchDetailVo vehicleDispatchDetailVo, int col, int row) {
            StaffMasterVo staffMasterVo;
            string stringStaffDisplayName;
            string stringBelongs;

            if(vehicleDispatchDetailVo.Operation_flag) {
                // 配車先
                WriteCell(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1);
                // 組数
                WriteCell(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
                if(vehicleDispatchDetailVo.Car_code != 0) {
                    // ドア番号
                    WriteCell(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString());
                    // ナンバー(数字部分)
                    WriteCell(col + 3, row, string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3.ToString()
                                                                            , _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()));
                    // 代車のドア番

                }
                // 運転手
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                if(staffMasterVo != null) {
                    WriteCell(col + 8, row, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Occupation];
                    WriteCell(col + 9, row, stringBelongs);
                    // 運転手(本社・三郷)
                    WriteCell(col + 10, row, vehicleDispatchDetailVo.Garage_flag ? "" : "三");
                    // 点呼項目（点呼方法・点呼時刻・免許・健康・点検・飲酒・検知器）
                    WriteCell(col + 14, row, "対面");
                    WriteCell(col + 16, row, vehicleDispatchDetailVo.Operation_date.ToString("mm:ss"));
                    WriteCell(col + 17, row, "✓");
                    WriteCell(col + 18, row, "✓");
                    WriteCell(col + 19, row, "✓");
                    WriteCell(col + 20, row, "✓");
                    WriteCell(col + 21, row, "有");
                } else {
                    WriteCell(col + 8, row, "");
                    WriteCell(col + 9, row, "");
                    WriteCell(col + 10, row, "");
                    WriteCell(col + 14, row, ""); // 点呼方法
                    WriteCell(col + 16, row, ""); // 点呼時間
                    WriteCell(col + 17, row, ""); // 免許
                    WriteCell(col + 18, row, ""); // 健康
                    WriteCell(col + 19, row, ""); // 点検
                    WriteCell(col + 20, row, ""); // 飲酒
                    WriteCell(col + 21, row, ""); // 検知器
                }
                // 新・自・新作・自作・バ・バ作
                stringBelongs = "";
                stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Occupation];
                WriteCell(col + 9, row, stringBelongs);
                // 運転手(本社・三郷)
                WriteCell(col + 10, row, vehicleDispatchDetailVo.Garage_flag ? "" : "三");

                // 作業員１
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                if(staffMasterVo != null) {
                    stringStaffDisplayName = string.Concat("作業員", staffMasterVo.Display_name);
                    WriteCellStaff(col + 11, row, stringStaffDisplayName);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = "";
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Occupation];
                    WriteCell(col + 12, row, stringBelongs);
                } else {
                    WriteCell(col + 11, row, "");
                    WriteCell(col + 12, row, "");
                }

            } else {
                WriteCellIsStrikeout(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1); // 配車先
                WriteCellIsStrikeout(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2); // 組数
                WriteCellIsStrikeout(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString()); // ドア番号
                WriteCellIsStrikeout(col + 3, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()); // ナンバー(数字部分)
                WriteCell(col + 8, row, "休　車"); // 運転手
                WriteCell(col + 9, row, ""); // 新・自・新作・自作・バ・バ作
                WriteCell(col + 10, row, ""); // 運転手(本社・三郷)
            }
        }

        /// <summary>
        /// SetOperator3
        /// 運転手１名と作業員２名
        /// </summary>
        /// <param name="iWorkbook"></param>
        /// <param name="iSheet"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void SetOperator3(VehicleDispatchDetailVo vehicleDispatchDetailVo, int col, int row) {
            StaffMasterVo staffMasterVo;
            string stringStaffDisplayName;
            string stringBelongs;

            if(vehicleDispatchDetailVo.Operation_flag) {
                // 配車先
                WriteCell(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1);
                // 組数
                WriteCell(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
                if(vehicleDispatchDetailVo.Car_code != 0) {
                    // ドア番号
                    WriteCell(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString());
                    // ナンバー(数字部分)
                    WriteCell(col + 3, row, string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3.ToString()
                                                                            , _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()));
                    // 代車のドア番

                }
                // 運転手
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                if(staffMasterVo != null) {
                    WriteCell(col + 8, row, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Occupation];
                    WriteCell(col + 9, row, stringBelongs);
                    // 運転手(本社・三郷)
                    WriteCell(col + 10, row, vehicleDispatchDetailVo.Garage_flag ? "" : "三");
                    // 点呼項目（点呼方法・点呼時刻・免許・健康・点検・飲酒・検知器）
                    WriteCell(col + 14, row, "対面");
                    WriteCell(col + 16, row, vehicleDispatchDetailVo.Operation_date.ToString("mm:ss"));
                    WriteCell(col + 17, row, "✓");
                    WriteCell(col + 18, row, "✓");
                    WriteCell(col + 19, row, "✓");
                    WriteCell(col + 20, row, "✓");
                    WriteCell(col + 21, row, "有");
                } else {
                    WriteCell(col + 8, row, "");
                    WriteCell(col + 9, row, "");
                    WriteCell(col + 10, row, "");
                    WriteCell(col + 14, row, ""); // 点呼方法
                    WriteCell(col + 16, row, ""); // 点呼時間
                    WriteCell(col + 17, row, ""); // 免許
                    WriteCell(col + 18, row, ""); // 健康
                    WriteCell(col + 19, row, ""); // 点検
                    WriteCell(col + 20, row, ""); // 飲酒
                    WriteCell(col + 21, row, ""); // 検知器
                }
                // 作業員１
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                if(staffMasterVo != null) {
                    stringStaffDisplayName = string.Concat("作業員", staffMasterVo.Display_name);
                    WriteCellStaff(col + 11, row, stringStaffDisplayName);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = "";
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Occupation];
                    WriteCell(col + 12, row, stringBelongs);
                } else {
                    WriteCell(col + 11, row, "");
                    WriteCell(col + 12, row, "");
                }


                // 作業員２
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3);
                if(staffMasterVo != null) {
                    stringStaffDisplayName = string.Concat("作業員", staffMasterVo.Display_name);
                    WriteCellStaff(col + 11, row + 1, stringStaffDisplayName);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = "";
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Occupation];
                    WriteCell(col + 12, row + 1, stringBelongs);
                } else {
                    WriteCell(col + 11, row + 1, "");
                    WriteCell(col + 12, row + 1, "");
                }

            } else {
                WriteCellIsStrikeout(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1); // 配車先
                WriteCellIsStrikeout(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2); // 組数
                WriteCellIsStrikeout(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString()); // ドア番号
                WriteCellIsStrikeout(col + 3, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()); // ナンバー(数字部分)
                WriteCell(col + 8, row, "休　車"); // 運転手
                WriteCell(col + 9, row, ""); // 新・自・新作・自作・バ・バ作
                WriteCell(col + 10, row, ""); // 運転手(本社・三郷)
            }

        }

        /// <summary>
        /// SetOperator3
        /// 運転手１名と作業員３名
        /// </summary>
        /// <param name="iWorkbook"></param>
        /// <param name="iSheet"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void SetOperator4(VehicleDispatchDetailVo vehicleDispatchDetailVo, int col, int row) {
            StaffMasterVo staffMasterVo;
            string stringStaffDisplayName;
            string stringBelongs;

            if(vehicleDispatchDetailVo.Operation_flag) {
                // 配車先
                WriteCell(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1);
                // 組数
                WriteCell(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
                if(vehicleDispatchDetailVo.Car_code != 0) {
                    // ドア番号
                    WriteCell(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString());
                    // ナンバー(数字部分)
                    WriteCell(col + 3, row, string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3.ToString()
                                                                            , _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()));
                    // 代車のドア番

                }
                // 運転手
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                if(staffMasterVo != null) {
                    WriteCell(col + 8, row, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Occupation];
                    WriteCell(col + 9, row, stringBelongs);
                    // 運転手(本社・三郷)
                    WriteCell(col + 10, row, vehicleDispatchDetailVo.Garage_flag ? "" : "三");
                    // 点呼項目（点呼方法・点呼時刻・免許・健康・点検・飲酒・検知器）
                    WriteCell(col + 14, row, "対面");
                    WriteCell(col + 16, row, vehicleDispatchDetailVo.Operation_date.ToString("mm:ss"));
                    WriteCell(col + 17, row, "✓");
                    WriteCell(col + 18, row, "✓");
                    WriteCell(col + 19, row, "✓");
                    WriteCell(col + 20, row, "✓");
                    WriteCell(col + 21, row, "有");
                } else {
                    WriteCell(col + 8, row, "");
                    WriteCell(col + 9, row, "");
                    WriteCell(col + 10, row, "");
                    WriteCell(col + 14, row, ""); // 点呼方法
                    WriteCell(col + 16, row, ""); // 点呼時間
                    WriteCell(col + 17, row, ""); // 免許
                    WriteCell(col + 18, row, ""); // 健康
                    WriteCell(col + 19, row, ""); // 点検
                    WriteCell(col + 20, row, ""); // 飲酒
                    WriteCell(col + 21, row, ""); // 検知器
                }
                // 作業員１
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                if(staffMasterVo != null) {
                    stringStaffDisplayName = string.Concat("作業員", staffMasterVo.Display_name);
                    WriteCellStaff(col + 11, row, stringStaffDisplayName);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = "";
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Occupation];
                    WriteCell(col + 12, row, stringBelongs);
                } else {
                    WriteCell(col + 11, row, "");
                    WriteCell(col + 12, row, "");
                }


                // 作業員２
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3);
                if(staffMasterVo != null) {
                    stringStaffDisplayName = string.Concat("作業員", staffMasterVo.Display_name);
                    WriteCellStaff(col + 8, row + 1, stringStaffDisplayName);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = "";
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Occupation];
                    WriteCell(col + 9, row + 1, stringBelongs);
                } else {
                    WriteCell(col + 8, row + 1, "");
                    WriteCell(col + 9, row + 1, "");
                }


                // 作業員３
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4);
                if(staffMasterVo != null) {
                    stringStaffDisplayName = string.Concat("作業員", staffMasterVo.Display_name);
                    WriteCellStaff(col + 11, row + 1, stringStaffDisplayName);
                    // 新・自・新作・自作・バ・バ作
                    stringBelongs = "";
                    stringBelongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs];
                    stringBelongs = stringBelongs + dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Occupation];
                    WriteCell(col + 12, row + 1, stringBelongs);
                } else {
                    WriteCell(col + 11, row + 1, "");
                    WriteCell(col + 12, row + 1, "");
                }
            } else {
                WriteCellIsStrikeout(col, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1); // 配車先
                WriteCellIsStrikeout(col + 1, row, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2); // 組数
                WriteCellIsStrikeout(col + 2, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString()); // ドア番号
                WriteCellIsStrikeout(col + 3, row, _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()); // ナンバー(数字部分)
                WriteCell(col + 8, row, "休　車"); // 運転手
                WriteCell(col + 9, row, ""); // 新・自・新作・自作・バ・バ作
                WriteCell(col + 10, row, ""); // 運転手(本社・三郷)
            }
        }

        /// <summary>
        /// VehicleDispatchExcel_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchExcel_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
