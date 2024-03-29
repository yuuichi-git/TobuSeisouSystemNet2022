﻿using System.Globalization;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

using H_Vo;

using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace VehicleDispatchConvert {

    public class ConvertXls {
        private ICell _iCell;
        private ISheet _iSheet;
        private IWorkbook _iWorkbook;
        /// <summary>
        /// A1形式を格納する
        /// </summary>
        private CellReference _cellReference;
        private HSSFRichTextString hSSFRichTextString = new();

        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private string[] _arrayTenkoName;
        private Dictionary<int, string> dictionaryWordCode = new Dictionary<int, string> { { 13101, "千代田区" },
                                                                                           { 13102, "中央区" },
                                                                                           { 13103, "港区" },
                                                                                           { 13104, "新宿区" },
                                                                                           { 13105, "文京区" },
                                                                                           { 13106, "台東区" },
                                                                                           { 13107, "墨田区" },
                                                                                           { 13108, "江東区" },
                                                                                           { 13109, "品川区" },
                                                                                           { 13110, "目黒区" },
                                                                                           { 13111, "大田区" },
                                                                                           { 13112, "世田谷区" },
                                                                                           { 13113, "渋谷区" },
                                                                                           { 13114, "中野区" },
                                                                                           { 13115, "杉並区" },
                                                                                           { 13116, "豊島区" },
                                                                                           { 13117, "北区" },
                                                                                           { 13118, "荒川区" },
                                                                                           { 13119, "板橋区" },
                                                                                           { 13120, "練馬区" },
                                                                                           { 13121, "足立区" },
                                                                                           { 13122, "葛飾区" },
                                                                                           { 13123, "江戸川区" } };

        private Dictionary<int, string> dictionaryCellPoint = new Dictionary<int, string> { { 1310401, "A6" }, // 新宿１－８２
                                                                                            { 1311701, "A7" }, // 北１２
                                                                                            { 1310402, "A10" }, // 新宿１－８１
                                                                                            { 1310403, "A12" }, // 新宿１－６１
                                                                                            { 1310404, "A13" }, // 新宿１－６２
                                                                                            { 1311901, "A15" }, // 板橋西５５
                                                                                            { 1312101, "A17" }, // 足立１８
                                                                                            { 1312102, "A18" }, // 足立２３
                                                                                            { 1312103, "A20" }, // 足立２４
                                                                                            { 1312104, "A22" }, // 足立３８
                                                                                            { 1312201, "A24" }, // 葛飾３３
                                                                                            { 1312202, "A26" }, // 葛飾５５
                                                                                            { 1311702, "A28" }, // 北２０１

                                                                                            { 1310405, "A35" }, // 新宿１－３１
                                                                                            { 1310801, "A36" }, // 江東１
                                                                                            { 1310802, "A37" }, // 江東４
                                                                                            { 1310803, "A38" }, // 江東７
                                                                                            { 1310804, "A40" }, // 江東１４
                                                                                            { 1311501, "A42" }, // 方南１０６
                                                                                            { 1311801, "A43" }, // 荒川５
                                                                                            { 1312203, "A44" }, // 小岩４

                                                                                            { 1311502, "A48" }, // 方南４０８
                                                                                            { 1311705, "A49" }, // 北軽２１
                                                                                            { 1311902, "A50" }, // 板橋西軽１号車
                                                                                            { 1311903, "A51" }, // 板橋西軽３号車
                                                                                            { 1311904, "A52" }, // 板橋西軽７号車
                                                                                            { 1312001, "A53" }, // 石神井軽４
                                                                                            { 1312105, "A54" }, // 足立不燃４
                                                                                            { 1312204, "A55" }, // 葛飾軽１１

                                                                                            { 1310601, "A59" }, // 台東軽小ー６

                                                                                            { 1310406, "A62" }, // 新宿区軽
                                                                                            { 1311706, "A63" }, // 北区粗大・資源

                                                                                            { 1310407, "A66" }, // 新宿区容リ３－１
                                                                                            { 1310408, "A68" }, // 新宿区容リ２－１
                                                                                            { 1312002, "A69" }, // 練馬区容リ２－１
                                                                                            { 1312003, "A70" }, // 練馬区容リ２－２

                                                                                            { 1310409, "A73" }, // 新宿ペット
                                                                                            { 1310410, "A75" }, // 新宿ペット対策

                                                                                            { 1310201, "A78" }, // 中央区ペット７
                                                                                            { 1310202, "A79" }, // 中央区ペット８
                                                                                            { 1310101, "A80" }, // 千代田区容リ２
                                                                                            { 1310102, "A81" }, // 千代田区容リ６
                                                                                            { 1310103, "A82" }, // 千代田区紙１
                                                                                            { 1311905, "A83" }, // 板橋区ペット１

                                                                                            { 1312106, "A90" }, // 足立区瓶缶１
                                                                                            { 1310602, "A92" }, // 台東区資源１
                                                                                            { 1310603, "A94" }, // 台東区資源２
                                                                                            { 1310604, "A96" }, // 台東区資源４

                                                                                            { 1310411, "AA6" }, // 新宿区粗大４
                                                                                            { 1310412, "AA8" }, // 新宿区粗大５
                                                                                            { 1312004, "AA10" }, // 練馬区粗大６
                                                                                            { 1312005, "AA11" }, // 練馬区粗大９
                                                                                            { 1311707, "AA12" }, // 北区粗大１
                                                                                            { 1311708, "AA14" }, // 北区粗大２
                                                                                            { 1311709, "AA16" }, // 北区粗大３
                                                                                            { 1311710, "AA18" }, // 北区粗大４
                                                                                            { 1311711, "AA20" }, // 北区粗大５
                                                                                            { 1311715, "AA22" }, // 北区粗大曜日配車

                                                                                            { 1312111, "AA97" }, // 整備本社
                                                                                            { 1312112, "AA99" }, // 整備三郷
                                                                                            { 1312109, "AA93" }, // 本社事務所
                                                                                            { 1312110, "AA95" }, // 三郷事務所
                                                                                            { 1312118, "AA88" }, // 浄化槽１
                                                                                            { 1312123, "AA90" }, // 浄化槽２

                                                                                            { 1312115, "AA75" }, // ルート１(事業用)
                                                                                            { 1312124, "AA76" }, // ルート２(事業用)
                                                                                            { 1312129, "AA70" }, // ルート１(自家用)
                                                                                            { 1312130, "AA71" }, // ルート２(自家用)

                                                                                            { 1312117, "AA84" }  // 廃家電(事業用)
                                                                                                              };

        private Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "" }, { 11, "" }, { 12, "バ" }, { 20, "新" }, { 21, "自" } };
        private Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "" }, { 11, "作" }, { 99, "" } };

        private JapaneseCalendar japaneseCalendar;
        private CultureInfo cultureInfo;

        /*
         * 登録された行数(臨時　小プ)
         * クラスが解放されるまで値を維持するのでここで宣言する
         */
        private int RINJI_SINDAI = 0; // 臨時　新大　カウント用
        private int RINJI_KOPURE = 0; // 臨時　小プ　カウント用
        private int RINJI_HIRABO = 0; // 臨時　平ボ
        private int RINJI_KEIDA = 0; // 臨時　軽ダ・軽小　カウント用

        /// <summary> 
        /// コンストラクター
        /// </summary>
        public ConvertXls(IWorkbook iWorkbook, ISheet iSheet, List<SetMasterVo> listSetMasterVo, List<CarMasterVo> listCarMasterVo, List<StaffMasterVo> listStaffMasterVo, string[] arrayTenkoName) {
            _iWorkbook = iWorkbook;
            _iSheet = iSheet;
            /*
             * Vo
             */
            _listSetMasterVo = listSetMasterVo;
            _listCarMasterVo = listCarMasterVo;
            _listStaffMasterVo = listStaffMasterVo;
            _arrayTenkoName = arrayTenkoName;
            /*
             * 和暦の使用準備
             */
            japaneseCalendar = new JapaneseCalendar();
            cultureInfo = new CultureInfo("Ja-JP", true);
            cultureInfo.DateTimeFormat.Calendar = japaneseCalendar;
        }

        /// <summary>
        /// SetCellString
        /// </summary>
        /// <param name="vehicleDispatchDetailVo"></param>
        public void SetCellString(VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            IFont iFont = _iWorkbook.CreateFont();
            iFont.FontName = "ＭＳ Ｐ明朝";
            iFont.FontHeightInPoints = 11;
            /*
             * 作業員明記用
             */
            IFont iFontStaff = _iWorkbook.CreateFont();
            iFontStaff.FontName = "ＭＳ Ｐ明朝";
            iFontStaff.FontHeightInPoints = 6;
            /*
             * 作業員明記用
             */
            IFont iFontDate = _iWorkbook.CreateFont();
            iFontDate.FontName = "ＭＳ Ｐ明朝";
            iFontDate.FontHeightInPoints = 18;
            /*
             * dictionaryCellPointにリストが無かったらA1形式を作成する
             * 配車先が固定出来ないもの（大G等）
             */
            if(dictionaryCellPoint.TryGetValue(vehicleDispatchDetailVo.Set_code, out string? dictionaryCellPointValue)) {

            } else {
                /*
                 * 雇上大G　コード５
                 */
                switch(vehicleDispatchDetailVo.Cell_number) {
                    case 76:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA25"; // 破砕コンテナ１
                        } else {
                            return;
                        }
                        goto goto1;
                    case 77:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA26"; // 破砕等２
                        } else {
                            return;
                        }
                        goto goto1;
                    case 78:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA27"; // 破砕等３
                        } else {
                            return;
                        }
                        goto goto1;
                    case 79:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA28"; // 破砕等４
                        } else {
                            return;
                        }
                        goto goto1;
                    case 80:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA29"; // 破砕等５
                        } else {
                            return;
                        }
                        goto goto1;
                    case 81:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA30"; // 破砕等６
                        } else {
                            return;
                        }
                        goto goto1;
                    case 82:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA31"; // 破砕等７
                        } else {
                            return;
                        }
                        goto goto1;
                    case 83:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA32"; // 破砕等８
                        } else {
                            return;
                        }
                        goto goto1;
                    case 84:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA33"; // 破砕等９
                        } else {
                            return;
                        }
                        goto goto1;
                    case 85:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA34"; // 破砕等１０
                        } else {
                            return;
                        }
                        goto goto1;
                    case 86:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA35"; // 破砕等１１
                        } else {
                            return;
                        }
                        goto goto1;
                    case 87:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA36"; // 破砕等１２
                        } else {
                            return;
                        }
                        goto goto1;
                        //default:
                        //    /*
                        //     * リストに無ければ終了
                        //     */
                        //    return;
                }

                /*
                 * 臨時
                 * 上詰めで表示する処理
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Car_code > 0) {
                    SetMasterVo? setMasterVo = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code);
                    string disguiseKind = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1;

                    CellReference cellReference;
                    if(setMasterVo is not null && setMasterVo.Classification_code == 12) {
                        switch(disguiseKind) {
                            case "新大":
                                dictionaryCellPointValue = string.Concat("AA", 55 + RINJI_SINDAI);
                                RINJI_SINDAI++;
                                break;
                            case "小プ":
                                /*
                                 * 基本的に臨時の作付は１人まで。もし2人付いていたら、行を繰り下げないと消えてしまうよ
                                 * 単純に３人目のセルに文字列が入っていればインクリメントする
                                 * もしかしたら行数が足りなくなるかもね
                                 */
                                cellReference = new(string.Concat("AL", 38 + RINJI_KOPURE));
                                _iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col);
                                if(_iCell.StringCellValue != "")
                                    RINJI_KOPURE++;

                                dictionaryCellPointValue = string.Concat("AA", 38 + RINJI_KOPURE);
                                RINJI_KOPURE++;
                                break;
                            case "平ボ":
                                /*
                                 * 基本的に臨時の作付は１人まで。もし2人付いていたら、行を繰り下げないと消えてしまうよ
                                 * 単純に３人目のセルに文字列が入っていればインクリメントする
                                 * もしかしたら行数が足りなくなるかもね
                                 */
                                cellReference = new(string.Concat("AL", 65 + RINJI_HIRABO));
                                _iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col);
                                if(_iCell.StringCellValue != "")
                                    RINJI_HIRABO++;

                                dictionaryCellPointValue = string.Concat("AA", 65 + RINJI_HIRABO);
                                RINJI_HIRABO++;
                                break;
                            case "軽ダ":
                            case "軽小":
                                dictionaryCellPointValue = string.Concat("AA", 60 + RINJI_KEIDA);
                                RINJI_KEIDA++;
                                break;
                            default:
                                return;
                        }
                    } else {
                        /*
                         * 配車先が臨時ではない場合はReturn
                         */
                        return;
                    }
                } else {
                    /*
                     * Set_codeとCar_codeが入っていなかったらReturn
                     */
                    return;
                }
            }
        goto1:
            _cellReference = new(dictionaryCellPointValue); // A1形式
            /*
             * 点呼日 
             */
            hSSFRichTextString = new HSSFRichTextString(DateTime.Now.ToString("ggy年M月d日 [ddd]", cultureInfo));
            _iCell = _iSheet.GetRow(0).GetCell(0); // Column Row
            _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
            _iCell.SetCellValue(hSSFRichTextString);
            /*
             * 配車先
             * 区契約は配車先名で、それ以外は”区”で表示する
             */
            if(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code != 11) {
                hSSFRichTextString = new HSSFRichTextString(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1);
            } else {
                hSSFRichTextString = new HSSFRichTextString(dictionaryWordCode[_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Word_code]);
            }
            iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
            hSSFRichTextString.ApplyFont(iFont);
            _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col); // Column Row
            _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
            _iCell.SetCellValue(hSSFRichTextString);
            /*
             * 組数
             */
            hSSFRichTextString = new HSSFRichTextString(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
            iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
            hSSFRichTextString.ApplyFont(iFont);
            _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 1); // Column Row
            _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
            _iCell.SetCellValue(hSSFRichTextString);
            if(vehicleDispatchDetailVo.Car_code != 0) {
                /*
                 * ドア番号
                 */
                hSSFRichTextString = new HSSFRichTextString(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString());
                iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 2); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                /*
                 * 自動車登録番号
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3.ToString(),
                                                                             _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()));
                iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 3); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Right;
                _iCell.SetCellValue(hSSFRichTextString);
            }
            /*
             * 休車
             */
            if(!vehicleDispatchDetailVo.Operation_flag) {
                hSSFRichTextString = new HSSFRichTextString("休　車");
                //hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 8); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
            }
            /*
             * 運転手と点呼
             */
            if(vehicleDispatchDetailVo.Operator_code_1 != 0) {
                /*
                 * 運転手
                 */
                hSSFRichTextString = new HSSFRichTextString(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 8); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                /*
                 * Belongs
                 */
                hSSFRichTextString = new HSSFRichTextString(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs]);
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 9); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                /*
                 * GarageFlag
                 */
                hSSFRichTextString = new HSSFRichTextString(vehicleDispatchDetailVo.Garage_flag ? "" : "三");
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 10); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                /*
                 * 特定の配車先に対して点呼を実施する
                 */
                if(GetOperatorRollCallFlag(vehicleDispatchDetailVo)) {
                    /*
                     * 点呼方法
                     */
                    hSSFRichTextString = new HSSFRichTextString("対面");
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 14); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 点呼時刻
                     */
                    hSSFRichTextString = new HSSFRichTextString(vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.ToString("H:mm"));
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 16); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Right;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 免許 ✓
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 17); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 健康
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 18); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 点検
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 19); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 飲酒
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 20); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 検知器
                     */
                    hSSFRichTextString = new HSSFRichTextString("有");
                    hSSFRichTextString.ApplyFont(iFont);
                    _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 21); // Column Row
                    _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    _iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 点呼執行者
                     */
                    switch(vehicleDispatchDetailVo.Garage_flag) {
                        case true:
                            /*
                             * 点呼時刻の秒数が偶数なら”点呼執行者本社１”、奇数なら”点呼執行者本社２”を選択する
                             */
                            int second = vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.Second; //秒（0～59）
                            hSSFRichTextString = new HSSFRichTextString((second % 2 == 0) ? _arrayTenkoName[0] : _arrayTenkoName[1]);
                            hSSFRichTextString.ApplyFont(iFont);
                            _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 23); // Column Row
                            _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                            _iCell.SetCellValue(hSSFRichTextString);
                            break;
                        case false:
                            /*
                             * ”点呼執行者三郷”を選択する
                             */
                            hSSFRichTextString = new HSSFRichTextString(_arrayTenkoName[2]);
                            hSSFRichTextString.ApplyFont(iFont);
                            _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 23); // Column Row
                            _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                            _iCell.SetCellValue(hSSFRichTextString);
                            break;
                    }
                }
            }
            if(vehicleDispatchDetailVo.Operator_code_2 != 0) {
                /*
                 * 作業員１
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(GetWorkStaff(vehicleDispatchDetailVo), _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Display_name));
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 11); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                if(GetWorkStaff(vehicleDispatchDetailVo) != "")
                    hSSFRichTextString.ApplyFont(0, 3, iFontStaff);
                /*
                 * Occupation
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs],
                                                                          dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Occupation]));
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row).GetCell(_cellReference.Col + 12); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
            }
            if(vehicleDispatchDetailVo.Operator_code_3 != 0) {
                /*
                 * 作業員２
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(GetWorkStaff(vehicleDispatchDetailVo), _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Display_name));
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row + 1).GetCell(_cellReference.Col + 11); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                if(GetWorkStaff(vehicleDispatchDetailVo) != "")
                    hSSFRichTextString.ApplyFont(0, 3, iFontStaff);
                /*
                 * Occupation
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs],
                                                                          dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Occupation]));
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row + 1).GetCell(_cellReference.Col + 12); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
            }
            if(vehicleDispatchDetailVo.Operator_code_4 != 0) {
                /*
                 * 作業員３
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(GetWorkStaff(vehicleDispatchDetailVo), _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Display_name));
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row + 1).GetCell(_cellReference.Col + 8); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
                if(GetWorkStaff(vehicleDispatchDetailVo) != "")
                    hSSFRichTextString.ApplyFont(0, 3, iFontStaff);
                /*
                 * Occupation
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs],
                                                                          dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Occupation]));
                hSSFRichTextString.ApplyFont(iFont);
                _iCell = _iSheet.GetRow(_cellReference.Row + 1).GetCell(_cellReference.Col + 9); // Column Row
                _iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                _iCell.SetCellValue(hSSFRichTextString);
            }
        }

        /// <summary>
        /// ”作業員”を挿入するかどうか
        /// リストにいれたら”作業員”を挿入する
        /// </summary>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <returns></returns>
        private string GetWorkStaff(VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            switch(vehicleDispatchDetailVo.Set_code) {
                case 1312109: // 本社事務所
                case 1312110: // 三郷事務所
                case 1312111: // 整備本社
                case 1312112: // 整備三郷
                case 1312118: // 浄化槽１
                case 1312123: // 浄化槽２
                case 1312115: // ルート１(事業用)
                case 1312124: // ルート２(事業用)
                    return "";
                default:
                    switch(vehicleDispatchDetailVo.Cell_number) {
                        /*
                         * 大Gの場合”作業員”を付けない
                         */
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
                            return "";
                        /*
                         * リストに無ければ終了
                         */
                        default:
                            return "作業員";
                    }
            }
        }

        /// <summary>
        /// 点呼を実施するかどうか
        /// リストにいれたら点呼はしない
        /// </summary>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <returns></returns>
        private bool GetOperatorRollCallFlag(VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            switch(vehicleDispatchDetailVo.Set_code) {
                case 1312109: // 本社事務所
                case 1312110: // 三郷事務所
                case 1312111: // 整備本社
                case 1312112: // 整備三郷
                    return false;
                default:
                    return true;
            }
        }
    }
}
