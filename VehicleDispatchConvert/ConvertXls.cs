﻿using System.Globalization;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

using Vo;

using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace VehicleDispatchConvert {

    public class ConvertXls {
        private IWorkbook _iWorkbook;
        private ISheet _iSheet;
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;

        private Dictionary<int, string> dictionaryWordCode = new Dictionary<int, string> { { 13101, "千代田区" }, // 
                                                                                           { 13102, "中央区" }, // 
                                                                                           { 13103, "港区" }, // 
                                                                                           { 13104, "新宿区" }, // 
                                                                                           { 13105, "文京区" }, // 
                                                                                           { 13106, "台東区" }, // 
                                                                                           { 13107, "墨田区" }, // 
                                                                                           { 13108, "江東区" }, // 
                                                                                           { 13109, "品川区" }, // 
                                                                                           { 13110, "目黒区" }, // 
                                                                                           { 13111, "大田区" }, // 
                                                                                           { 13112, "世田谷区" }, // 
                                                                                           { 13113, "渋谷区" }, // 
                                                                                           { 13114, "中野区" }, // 
                                                                                           { 13115, "杉並区" }, // 
                                                                                           { 13116, "豊島区" }, // 
                                                                                           { 13117, "北区" }, // 
                                                                                           { 13118, "荒川区" }, // 
                                                                                           { 13119, "板橋区" }, // 
                                                                                           { 13120, "練馬区" }, // 
                                                                                           { 13121, "足立区" }, // 
                                                                                           { 13122, "葛飾区" }, // 
                                                                                           { 13123, "江戸川区" }, // 
                                                                                                                };

        private Dictionary<int, string> dictionaryCellPoint = new Dictionary<int, string> { { 1310401, "A6" }, // 新宿１－８２
                                                                                            { 1311701, "A7" }, // 北１２
                                                                                            { 1310402, "A11" }, // 新宿１－８１
                                                                                            { 1310403, "A13" }, // 新宿１－６１
                                                                                            { 1310404, "A14" }, // 新宿１－６２
                                                                                            { 1311901, "A16" }, // 板橋西５５
                                                                                            { 1312101, "A18" }, // 足立１８
                                                                                            { 1312102, "A19" }, // 足立２３
                                                                                            { 1312103, "A21" }, // 足立２４
                                                                                            { 1312104, "A23" }, // 足立３８
                                                                                            { 1312201, "A25" }, // 葛飾３３
                                                                                            { 1312202, "A27" }, // 葛飾５５
                                                                                            { 1311702, "A29" }, // 北２０１
                                                                                            { 1310405, "A42" }, // 新宿１－３１
                                                                                            { 1310801, "A43" }, // 江東１
                                                                                            { 1310802, "A44" }, // 江東４
                                                                                            { 1310803, "A45" }, // 江東７
                                                                                            { 1310804, "A47" }, // 江東１４
                                                                                            { 1311501, "A49" }, // 方南１０６
                                                                                            { 1311801, "A50" }, // 荒川５
                                                                                            { 1312203, "A51" }, // 小岩４
                                                                                            { 1311502, "A57" }, // 方南４０８
                                                                                            { 1311705, "A58" }, // 北軽２１
                                                                                            { 1311902, "A59" }, // 板橋西軽１号車
                                                                                            { 1311903, "A60" }, // 板橋西軽３号車
                                                                                            { 1311904, "A61" }, // 板橋西軽７号車
                                                                                            { 1312001, "A62" }, // 石神井軽４
                                                                                            { 1312105, "A63" }, // 足立不燃４
                                                                                            { 1312204, "A64" }, // 葛飾軽１１
                                                                                            { 1310601, "A69" }, // 台東軽小ー６
                                                                                            { 1310406, "A72" }, // 新宿区軽
                                                                                            { 1311706, "A73" }, // 北区粗大・資源
                                                                                            { 1310407, "A76" }, // 新宿区容リ３－１
                                                                                            { 1310408, "A78" }, // 新宿区容リ２－１
                                                                                            { 1312002, "A79" }, // 練馬区容リ２－１
                                                                                            { 1312003, "A80" }, // 練馬区容リ２－２
                                                                                            { 1310409, "A83" }, // 新宿ペット
                                                                                            { 1310410, "A85" }, // 新宿ペット対策
                                                                                            { 1310201, "A88" }, // 中央区ペット７
                                                                                            { 1310202, "A89" }, // 中央区ペット８
                                                                                            { 1310101, "A90" }, // 千代田区容リ２
                                                                                            { 1310102, "A91" }, // 千代田区容リ６
                                                                                            { 1310103, "A92" }, // 千代田区紙１
                                                                                            { 1311905, "A93" }, // 板橋区ペット１
                                                                                            { 1312106, "A103" }, // 足立区瓶缶１
                                                                                            { 1310602, "A105" }, // 台東区資源１
                                                                                            { 1310603, "A107" }, // 台東区資源２
                                                                                            { 1310604, "A109" }, // 台東区資源４
                                                                                            { 1310411, "AA6" }, // 新宿区粗大４
                                                                                            { 1310412, "AA8" }, // 新宿区粗大５
                                                                                            { 1312004, "AA10" }, // 練馬区粗大６
                                                                                            { 1312005, "AA11" }, // 練馬区粗大９
                                                                                            { 1311707, "AA12" }, // 北区粗大１
                                                                                            { 1311708, "AA14" }, // 北区粗大２
                                                                                            { 1311709, "AA16" }, // 北区粗大３
                                                                                            { 1311710, "AA18" }, // 北区粗大４
                                                                                            { 1311711, "AA20" }, // 北区粗大５
                                                                                            { 1311712, "AA22" }, // 北区粗大曜日配車
                                                                                            { 1312111, "AA115" }, // 整備本社
                                                                                            { 1312112, "AA102" }, // 整備三郷
                                                                                            { 1312109, "AA110" }, // 本社事務所
                                                                                            { 1312110, "AA112" }, // 三郷事務所
                                                                                            { 1312118, "AA105" }, // 浄化槽１
                                                                                            { 1312123, "AA107" }, // 浄化槽２
                                                                                                                };

        private Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "" }, { 11, "" }, { 12, "バ" }, { 20, "新" }, { 21, "自" } };
        private Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "" }, { 11, "作" }, { 99, "" } };

        JapaneseCalendar japaneseCalendar;
        CultureInfo cultureInfo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConvertXls(IWorkbook iWorkbook, ISheet iSheet, List<SetMasterVo> listSetMasterVo, List<CarMasterVo> listCarMasterVo, List<StaffMasterVo> listStaffMasterVo) {
            _iWorkbook = iWorkbook;
            _iSheet = iSheet;
            /*
             * Vo
             */
            _listSetMasterVo = listSetMasterVo;
            _listCarMasterVo = listCarMasterVo;
            _listStaffMasterVo = listStaffMasterVo;

            /*
             * 和暦の使用準備
             */
            japaneseCalendar = new JapaneseCalendar();
            cultureInfo = new CultureInfo("Ja-JP", true);
            cultureInfo.DateTimeFormat.Calendar = japaneseCalendar;
        }

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

            string dictionaryCellPointValue;
            /*
             * dictionaryCellPointにリストが無かったらA1形式を作成する
             * 配車先が固定出来ないもの（大G等）
             */
            if(dictionaryCellPoint.TryGetValue(vehicleDispatchDetailVo.Set_code, out dictionaryCellPointValue)) {

            } else {
                /*
                 * 雇上大G　コード５
                 */
                switch(vehicleDispatchDetailVo.Cell_number) {
                    case 76:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA33"; // 破砕コンテナ
                        } else {
                            return;
                        }
                        break;
                    case 77:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA34"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 78:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA35"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 79:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA36"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 80:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA37"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 81:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA38"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 82:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA39"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 83:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA40"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 84:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA41"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 85:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA42"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 86:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA43"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    case 87:
                        if(vehicleDispatchDetailVo.Operation_flag) {
                            dictionaryCellPointValue = "AA44"; // 破砕等
                        } else {
                            return;
                        }
                        break;
                    default:
                        /*
                         * リストに無ければ終了
                         */
                        return;
                }
            }

            CellReference cellReference = new CellReference(dictionaryCellPointValue); // A1形式
            ICell iCell;
            HSSFRichTextString hSSFRichTextString = new HSSFRichTextString();
            /*
             * 点呼日
             */
            hSSFRichTextString = new HSSFRichTextString(DateTime.Now.ToString("ggy年M月d日 [ddd]", cultureInfo));
            iCell = _iSheet.GetRow(0).GetCell(0); // Column Row
            iCell.CellStyle.Alignment = HorizontalAlignment.Center;
            iCell.SetCellValue(hSSFRichTextString);
            /*
             * 配車先
             */
            if(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code != 11) {
                hSSFRichTextString = new HSSFRichTextString(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1);
            } else {
                hSSFRichTextString = new HSSFRichTextString(dictionaryWordCode[_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Word_code]);
            }
            iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
            hSSFRichTextString.ApplyFont(iFont);
            iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col); // Column Row
            iCell.CellStyle.Alignment = HorizontalAlignment.Center;
            iCell.SetCellValue(hSSFRichTextString);
            /*
             * 組数
             */
            hSSFRichTextString = new HSSFRichTextString(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
            iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
            hSSFRichTextString.ApplyFont(iFont);
            iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 1); // Column Row
            iCell.CellStyle.Alignment = HorizontalAlignment.Center;
            iCell.SetCellValue(hSSFRichTextString);
            if(vehicleDispatchDetailVo.Car_code != 0) {
                /*
                 * ドア番号
                 */
                hSSFRichTextString = new HSSFRichTextString(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString());
                iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 2); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                /*
                 * 自動車登録番号
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3.ToString(),
                                                                          _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4.ToString()));
                iFont.IsStrikeout = !vehicleDispatchDetailVo.Operation_flag; // 取り消し線
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 3); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Right;
                iCell.SetCellValue(hSSFRichTextString);
            }
            if(vehicleDispatchDetailVo.Operator_code_1 != 0) {
                /*
                 * 運転手
                 */
                hSSFRichTextString = new HSSFRichTextString(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 8); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                /*
                 * Belongs
                 */
                hSSFRichTextString = new HSSFRichTextString(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs]);
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 9); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                /*
                 * GarageFlag
                 */
                hSSFRichTextString = new HSSFRichTextString(vehicleDispatchDetailVo.Garage_flag ? "" : "三");
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 10); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                /*
                 * 特定の配車先に対して点呼を実施する
                 */
                if(GetOperatorRollCallFlag(vehicleDispatchDetailVo)) {
                    /*
                     * 点呼方法
                     */
                    hSSFRichTextString = new HSSFRichTextString("対面");
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 14); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 点呼時刻
                     */
                    hSSFRichTextString = new HSSFRichTextString(vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.ToString("H:mm"));
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 16); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Right;
                    iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 免許 ✓
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 17); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 健康
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 18); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 点検
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 19); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 飲酒
                     */
                    hSSFRichTextString = new HSSFRichTextString("✓");
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 20); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    iCell.SetCellValue(hSSFRichTextString);
                    /*
                     * 検知器
                     */
                    hSSFRichTextString = new HSSFRichTextString("有");
                    hSSFRichTextString.ApplyFont(iFont);
                    iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 21); // Column Row
                    iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                    iCell.SetCellValue(hSSFRichTextString);

                }
            }
            if(vehicleDispatchDetailVo.Operator_code_2 != 0) {
                /*
                 * 作業員１
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(GetWorkStaff(vehicleDispatchDetailVo), _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Display_name));
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 11); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                if(GetWorkStaff(vehicleDispatchDetailVo) != "")
                    hSSFRichTextString.ApplyFont(0, 3, iFontStaff);
                /*
                 * Occupation
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs],
                                                                          dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Occupation]));
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row).GetCell(cellReference.Col + 12); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
            }
            if(vehicleDispatchDetailVo.Operator_code_3 != 0) {
                /*
                 * 作業員２
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(GetWorkStaff(vehicleDispatchDetailVo), _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Display_name));
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row + 1).GetCell(cellReference.Col + 11); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                if(GetWorkStaff(vehicleDispatchDetailVo) != "")
                    hSSFRichTextString.ApplyFont(0, 3, iFontStaff);
                /*
                 * Occupation
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs],
                                                                          dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Occupation]));
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row + 1).GetCell(cellReference.Col + 12); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
            }
            if(vehicleDispatchDetailVo.Operator_code_4 != 0) {
                /*
                 * 作業員３
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(GetWorkStaff(vehicleDispatchDetailVo), _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Display_name));
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row + 1).GetCell(cellReference.Col + 8); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
                if(GetWorkStaff(vehicleDispatchDetailVo) != "")
                    hSSFRichTextString.ApplyFont(0, 3, iFontStaff);
                /*
                 * Occupation
                 */
                hSSFRichTextString = new HSSFRichTextString(string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs],
                                                                          dictionaryOccupation[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Occupation]));
                hSSFRichTextString.ApplyFont(iFont);
                iCell = _iSheet.GetRow(cellReference.Row + 1).GetCell(cellReference.Col + 9); // Column Row
                iCell.CellStyle.Alignment = HorizontalAlignment.Center;
                iCell.SetCellValue(hSSFRichTextString);
            }
        }

        /// <summary>
        /// ”作業員”を挿入するかどうか
        /// </summary>
        /// <param name="vehicleDispatchDetailVo"></param>
        /// <returns></returns>
        private string GetWorkStaff(VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            switch(vehicleDispatchDetailVo.Set_code) {
                case 1312109: // 本社事務所
                case 1312110: // 三郷事務所
                case 1312111: // 整備本社
                case 1312112: // 整備三郷
                    return "";
                default:
                    return "作業員";
            }
        }

        /// <summary>
        /// 点呼を実施するかどうか
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