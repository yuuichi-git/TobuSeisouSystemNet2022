using System.Drawing.Printing;

using Common;

using Dao;

using FarPoint.Win.Spread;

using H_Vo;

namespace Staff {
    public partial class StaffPaper : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private readonly LicenseMasterVo _licenseMasterVo;
        private readonly List<CarAccidentMasterVo> _listCarAccidentLedgerVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        Dictionary<int, string> dictionaryBelongsName = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public StaffPaper(ConnectionVo connectionVo, int staffCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _licenseMasterVo = new LicenseMasterDao(connectionVo).SelectOneLicenseMaster(staffCode);
            _listCarAccidentLedgerVo = new CarAccidentMasterDao(connectionVo).SelectOneCarAccidentMaster(staffCode);
            // Form初期化
            // Formの表示サイズを初期化
            _initializeForm.StaffPaper(this);
            InitializeForm();
            // Controlへ表示
            var extendsStaffMasterVo = new StaffMasterDao(_connectionVo).SelectOneStaffMaster(staffCode);
            SheetViewHeadOutPut(SheetStaffRegisterHead, extendsStaffMasterVo);
            SheetViewTailOutPut(SheetStaffRegisterTail, extendsStaffMasterVo);
        }

        /// <summary>
        /// InitializeForm
        /// </summary>
        private void InitializeForm() {
            // Spread初期化
            InitializeSpreadStaffRegisterHead();
            InitializeSpreadStaffRegisterTail();
            ToolStripStatusLabelDetail.Text = "";
        }

        /// <summary>
        /// SheetViewHeadOutPut
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="extendsStaffMasterVo"></param>
        private void SheetViewHeadOutPut(SheetView sheetView, ExtendsStaffMasterVo extendsStaffMasterVo) {
            /*
             * 印刷日時
             */
            sheetView.Cells[0, 32].Text = string.Concat(DateTime.Now.ToString("yyyy年MM月dd日　印刷"));
            /*
             * 初任診断
             */
            // ”運転手”ならForeColorを変える
            if(extendsStaffMasterVo.Occupation == 10) {
                if(extendsStaffMasterVo.Proper_kind_1 == "初任診断" || extendsStaffMasterVo.Proper_kind_2 == "初任診断" || extendsStaffMasterVo.Proper_kind_3 == "初任診断") {
                    sheetView.Cells[2, 9].ForeColor = Color.Red;
                    sheetView.Cells[2, 11].Text = "〇";
                } else {
                    sheetView.Cells[2, 11].Text = "✕";
                }
            } else {
                sheetView.Cells[2, 9].ForeColor = Color.Gray;
                sheetView.Cells[2, 11].Text = "";
            }
            /*
             * 適齢診断
             */
            int age = new Date().GetStaffAge(extendsStaffMasterVo.Birth_date.Date);
            // ”65歳以上”及び”運転手”ならForeColorを変える
            if(age >= 65 && extendsStaffMasterVo.Occupation == 10) {
                sheetView.Cells[3, 9].ForeColor = Color.Red;
                if(extendsStaffMasterVo.Proper_kind_1 == "適齢診断" || extendsStaffMasterVo.Proper_kind_2 == "適齢診断" || extendsStaffMasterVo.Proper_kind_3 == "適齢診断") {
                    sheetView.Cells[3, 11].Text = string.Concat("〇", " (満", age.ToString(), "歳)");
                } else {
                    sheetView.Cells[3, 11].Text = string.Concat("✕", " (満", age.ToString(), "歳)");
                }
            } else {
                sheetView.Cells[3, 9].ForeColor = Color.Gray;
                sheetView.Cells[3, 11].Text = "";
            }
            /*
             * 健康診断
             */
            if(extendsStaffMasterVo.Medical_examination_date_1.AddYears(1) > DateTime.Now) {
                sheetView.Cells[4, 9].ForeColor = Color.Red;
                sheetView.Cells[4, 11].Text = string.Concat("〇 ", extendsStaffMasterVo.Medical_examination_date_1.ToString("yy/MM/dd"));
            } else {
                sheetView.Cells[4, 11].Text = "✕";
            }
            /*
             * 社員
             */
            if(extendsStaffMasterVo.Belongs == 10 || extendsStaffMasterVo.Belongs == 11) {
                sheetView.Cells[2, 1].ForeColor = Color.Red;
                sheetView.Cells[2, 2].ForeColor = Color.Red;
            }
            /*
             * アルバイト
             */
            if(extendsStaffMasterVo.Belongs == 12) {
                sheetView.Cells[3, 1].ForeColor = Color.Red;
                sheetView.Cells[3, 2].ForeColor = Color.Red;
            }
            /*
             * 派遣
             */
            if(extendsStaffMasterVo.Belongs == 13) {
                sheetView.Cells[4, 1].ForeColor = Color.Red;
                sheetView.Cells[4, 2].ForeColor = Color.Red;
            }
            /*
             * 労共(長期)
             */
            if((extendsStaffMasterVo.Belongs == 20 || extendsStaffMasterVo.Belongs == 21) && extendsStaffMasterVo.Job_form == 10) {
                sheetView.Cells[5, 1].ForeColor = Color.Red;
                sheetView.Cells[5, 2].ForeColor = Color.Red;
            }
            /*
             * 労共(短期)
             */
            if((extendsStaffMasterVo.Belongs == 20 || extendsStaffMasterVo.Belongs == 21) && extendsStaffMasterVo.Job_form == 11) {
                sheetView.Cells[6, 1].ForeColor = Color.Red;
                sheetView.Cells[6, 2].ForeColor = Color.Red;
            }
            /*
             * 運転手
             */
            if(extendsStaffMasterVo.Occupation == 10) {
                sheetView.Cells[7, 1].ForeColor = Color.Red;
                sheetView.Cells[7, 2].ForeColor = Color.Red;
            }
            /*
             * 作業員
             */
            if(extendsStaffMasterVo.Occupation == 11) {
                sheetView.Cells[8, 1].ForeColor = Color.Red;
                sheetView.Cells[8, 2].ForeColor = Color.Red;
            }

            sheetView.Cells[10, 5].Text = extendsStaffMasterVo.Name_kana; // フリガナ
            sheetView.Cells[11, 5].Text = string.Concat(extendsStaffMasterVo.Name, " (", dictionaryBelongsName[extendsStaffMasterVo.Belongs], ")"); // 氏名
            sheetView.Cells[11, 18].Text = extendsStaffMasterVo.Gender; // 性別
            sheetView.Cells[11, 20].Value = extendsStaffMasterVo.Birth_date != _defaultDateTime ? extendsStaffMasterVo.Birth_date.Date : null; // 生年月日
            sheetView.Cells[11, 26].Value = extendsStaffMasterVo.Employment_date != _defaultDateTime ? extendsStaffMasterVo.Employment_date.Date : null; // 雇用年月日
            sheetView.Cells[13, 5].Text = extendsStaffMasterVo.Current_address; // 現住所
            sheetView.Cells[15, 5].Text = extendsStaffMasterVo.Remarks; // 変更後住所
            sheetView.Cells[17, 7].Text = extendsStaffMasterVo.Telephone_number; // 電話番号
            sheetView.Cells[17, 21].Text = extendsStaffMasterVo.Cellphone_number; // 携帯電話
            sheetView.Cells[10, 32].Value = extendsStaffMasterVo.Picture.Length != 0 ? (Image?)new ImageConverter().ConvertFrom(extendsStaffMasterVo.Picture) : null;
            sheetView.Cells[19, 35].Text = extendsStaffMasterVo.Blood_type;//血液型
            sheetView.Cells[21, 9].Value = extendsStaffMasterVo.Selection_date != _defaultDateTime ? extendsStaffMasterVo.Selection_date.Date : null;//運転者に選任された日
            sheetView.Cells[23, 9].Value = extendsStaffMasterVo.Not_selection_date != _defaultDateTime ? extendsStaffMasterVo.Not_selection_date.Date : null;//運転者でなくなった日
            sheetView.Cells[25, 4].Text = extendsStaffMasterVo.Not_selection_reason;//運転者でなくなった日　理由
            // 免許証関連
            sheetView.Cells[27, 7].Text = _licenseMasterVo.License_number;//免許証番号
            sheetView.Cells[27, 17].Text = _licenseMasterVo.License_condition;//条件等
            string? kind = null;
            if(_licenseMasterVo.Large)
                kind += "(大型)";
            if(_licenseMasterVo.Medium)
                kind += "(中型)";
            if(_licenseMasterVo.Quasi_medium)
                kind += "(準中型)";
            if(_licenseMasterVo.Ordinary)
                kind += "(普通)";
            if(kind != null) {
                sheetView.Cells[31, 3].Text = string.Concat(kind, ":", _licenseMasterVo.Delivery_date.ToString("yyyy年MM月dd日"));//免許証の種類/取得日1
                sheetView.Cells[31, 27].Value = _licenseMasterVo.Expiration_date.Date;//有効期限1
            }
            //sheetView.Cells[33, 3].Text = "";//免許証の種類/取得日2
            //sheetView.Cells[33, 27].Text = "";//有効期限2
            //sheetView.Cells[35, 3].Text = "";//免許証の種類/取得日3
            //sheetView.Cells[35, 27].Text = "";//有効期限3
            //sheetView.Cells[37, 3].Text = "";//免許証の種類/取得日4
            //sheetView.Cells[37, 27].Text = "";//有効期限4
            //sheetView.Cells[39, 3].Text = "";//免許証の種類/取得日5
            //sheetView.Cells[39, 27].Text = "";//有効期限5
            sheetView.Cells[41, 3].Value = extendsStaffMasterVo.History_date_1 != _defaultDateTime ? extendsStaffMasterVo.History_date_1.Date : null;//履歴日時1
            sheetView.Cells[41, 11].Text = extendsStaffMasterVo.History_note_1;//履歴内容1
            sheetView.Cells[43, 3].Value = extendsStaffMasterVo.History_date_2 != _defaultDateTime ? extendsStaffMasterVo.History_date_2.Date : null;//履歴日時2
            sheetView.Cells[43, 11].Text = extendsStaffMasterVo.History_note_2;//履歴内容2
            sheetView.Cells[45, 3].Value = extendsStaffMasterVo.History_date_3 != _defaultDateTime ? extendsStaffMasterVo.History_date_3.Date : null;//履歴日時3
            sheetView.Cells[45, 11].Text = extendsStaffMasterVo.History_note_3;//履歴内容3
            sheetView.Cells[41, 21].Value = extendsStaffMasterVo.History_date_4 != _defaultDateTime ? extendsStaffMasterVo.History_date_4.Date : null;//履歴日時4
            sheetView.Cells[41, 29].Text = extendsStaffMasterVo.History_note_4;//履歴内容4
            sheetView.Cells[43, 21].Value = extendsStaffMasterVo.History_date_5 != _defaultDateTime ? extendsStaffMasterVo.History_date_5.Date : null;//履歴日時5
            sheetView.Cells[43, 29].Text = extendsStaffMasterVo.History_note_5;//履歴内容5
            sheetView.Cells[45, 21].Value = extendsStaffMasterVo.History_date_6 != _defaultDateTime ? extendsStaffMasterVo.History_date_6.Date : null;//履歴日時6
            sheetView.Cells[45, 29].Text = extendsStaffMasterVo.History_note_6;//履歴内容6
            sheetView.Cells[51, 1].Text = extendsStaffMasterVo.Experience_kind_1;//種類1
            sheetView.Cells[51, 12].Text = extendsStaffMasterVo.Experience_load_1;//積載量又は定員1
            sheetView.Cells[51, 20].Text = extendsStaffMasterVo.Experience_duration_1;//経験期間1
            sheetView.Cells[51, 31].Text = extendsStaffMasterVo.Experience_note_1;//備考1
            sheetView.Cells[53, 1].Text = extendsStaffMasterVo.Experience_kind_2;//種類2
            sheetView.Cells[53, 12].Text = extendsStaffMasterVo.Experience_load_2;//積載量又は定員2
            sheetView.Cells[53, 20].Text = extendsStaffMasterVo.Experience_duration_2;//経験期間2
            sheetView.Cells[53, 31].Text = extendsStaffMasterVo.Experience_note_2;//備考2
            sheetView.Cells[55, 1].Text = extendsStaffMasterVo.Experience_kind_3;//種類3
            sheetView.Cells[55, 12].Text = extendsStaffMasterVo.Experience_load_3;//積載量又は定員3
            sheetView.Cells[55, 20].Text = extendsStaffMasterVo.Experience_duration_3;//経験期間3
            sheetView.Cells[55, 31].Text = extendsStaffMasterVo.Experience_note_3;//備考3
            sheetView.Cells[57, 1].Text = extendsStaffMasterVo.Experience_kind_4;//種類4
            sheetView.Cells[57, 12].Text = extendsStaffMasterVo.Experience_load_4;//積載量又は定員4
            sheetView.Cells[57, 20].Text = extendsStaffMasterVo.Experience_duration_4;//経験期間4
            sheetView.Cells[57, 31].Text = extendsStaffMasterVo.Experience_note_4;//備考4
            sheetView.Cells[60, 10].Value = extendsStaffMasterVo.Retirement_date != _defaultDateTime ? extendsStaffMasterVo.Retirement_date.Date : null;//解雇又は退職の年月日
            sheetView.Cells[60, 17].Text = extendsStaffMasterVo.Retirement_note;//解雇又は退職の理由
            sheetView.Cells[62, 15].Value = extendsStaffMasterVo.Death_date != _defaultDateTime ? extendsStaffMasterVo.Death_date.Date : null;//死亡の場合の年月日
            sheetView.Cells[62, 22].Text = extendsStaffMasterVo.Death_note;//死亡の場合の原因
        }

        /// <summary>
        /// SheetViewTailOutPut
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="extendsStaffMasterVo"></param>
        private void SheetViewTailOutPut(SheetView sheetView, ExtendsStaffMasterVo extendsStaffMasterVo) {
            sheetView.Cells[3, 3].Value = extendsStaffMasterVo.Family_name_1;//家族状況氏名1
            sheetView.Cells[3, 12].Value = extendsStaffMasterVo.Family_birth_date_1 != _defaultDateTime ? extendsStaffMasterVo.Family_birth_date_1.Date : null;//家族状況生年月日1
            sheetView.Cells[3, 18].Value = extendsStaffMasterVo.Family_relationship_1;//家族状況続柄1
            sheetView.Cells[5, 3].Value = extendsStaffMasterVo.Family_name_2;//家族状況氏名2
            sheetView.Cells[5, 12].Value = extendsStaffMasterVo.Family_birth_date_2 != _defaultDateTime ? extendsStaffMasterVo.Family_birth_date_2.Date : null;//家族状況生年月日2
            sheetView.Cells[5, 18].Value = extendsStaffMasterVo.Family_relationship_2;//家族状況続柄2
            sheetView.Cells[7, 3].Value = extendsStaffMasterVo.Family_name_3;//家族状況氏名3
            sheetView.Cells[7, 12].Value = extendsStaffMasterVo.Family_birth_date_3 != _defaultDateTime ? extendsStaffMasterVo.Family_birth_date_3.Date : null;//家族状況生年月日3
            sheetView.Cells[7, 18].Value = extendsStaffMasterVo.Family_relationship_3;//家族状況続柄3
            sheetView.Cells[3, 21].Value = extendsStaffMasterVo.Family_name_4;//家族状況氏名4
            sheetView.Cells[3, 30].Value = extendsStaffMasterVo.Family_birth_date_4 != _defaultDateTime ? extendsStaffMasterVo.Family_birth_date_4.Date : null;//家族状況生年月日4
            sheetView.Cells[3, 36].Value = extendsStaffMasterVo.Family_relationship_4;//家族状況続柄4
            sheetView.Cells[5, 21].Value = extendsStaffMasterVo.Family_name_5;//家族状況氏名5
            sheetView.Cells[5, 30].Value = extendsStaffMasterVo.Family_birth_date_5 != _defaultDateTime ? extendsStaffMasterVo.Family_birth_date_5.Date : null;//家族状況生年月日5
            sheetView.Cells[5, 36].Value = extendsStaffMasterVo.Family_relationship_5;//家族状況続柄5
            sheetView.Cells[7, 21].Value = extendsStaffMasterVo.Family_name_6;//家族状況氏名6
            sheetView.Cells[7, 30].Value = extendsStaffMasterVo.Family_birth_date_6 != _defaultDateTime ? extendsStaffMasterVo.Family_birth_date_6.Date : null;//家族状況生年月日6
            sheetView.Cells[7, 36].Value = extendsStaffMasterVo.Family_relationship_6;//家族状況続柄6
            sheetView.Cells[9, 9].Value = extendsStaffMasterVo.Urgent_telephone_number;//緊急時連絡方法　電話
            sheetView.Cells[9, 17].Value = extendsStaffMasterVo.Urgent_telephone_method;//緊急時連絡方法　方法
            sheetView.Cells[14, 10].Value = extendsStaffMasterVo.Health_insurance_date != _defaultDateTime ? extendsStaffMasterVo.Health_insurance_date.Date : null;//健康保険加入年月日
            sheetView.Cells[14, 17].Value = extendsStaffMasterVo.Health_insurance_number;//健康保険の記号・番号
            sheetView.Cells[14, 28].Value = extendsStaffMasterVo.Health_insurance_note;//健康保険の備考
            sheetView.Cells[16, 10].Value = extendsStaffMasterVo.Welfare_pension_date != _defaultDateTime ? extendsStaffMasterVo.Welfare_pension_date.Date : null;//厚生年金保険加入年月日
            sheetView.Cells[16, 17].Value = extendsStaffMasterVo.Welfare_pension_number;//厚生年金保険の記号・番号
            sheetView.Cells[16, 28].Value = extendsStaffMasterVo.Welfare_pension_note;//厚生年金保険の備考
            sheetView.Cells[18, 10].Value = extendsStaffMasterVo.Employment_insurance_date != _defaultDateTime ? extendsStaffMasterVo.Employment_insurance_date.Date : null;//雇用保険加入年月日
            sheetView.Cells[18, 17].Value = extendsStaffMasterVo.Employment_insurance_number;//雇用保険の記号・番号
            sheetView.Cells[18, 28].Value = extendsStaffMasterVo.Employment_insurance_note;//雇用保険の備考
            sheetView.Cells[20, 10].Value = extendsStaffMasterVo.Worker_accident_insurance_date != _defaultDateTime ? extendsStaffMasterVo.Worker_accident_insurance_date.Date : null;//労災保険加入年月日
            sheetView.Cells[20, 17].Value = extendsStaffMasterVo.Worker_accident_insurance_number;//労災保険の記号・番号
            sheetView.Cells[20, 28].Value = extendsStaffMasterVo.Worker_accident_insurance_note;//労災保険の備考
            sheetView.Cells[25, 1].Value = extendsStaffMasterVo.Medical_examination_date_1 != _defaultDateTime ? extendsStaffMasterVo.Medical_examination_date_1.Date : null;//健康状態日付1
            sheetView.Cells[25, 10].Value = extendsStaffMasterVo.Medical_examination_note_1;//健康状態備考1
            sheetView.Cells[27, 1].Value = extendsStaffMasterVo.Medical_examination_date_2 != _defaultDateTime ? extendsStaffMasterVo.Medical_examination_date_2.Date : null;//健康状態日付2
            sheetView.Cells[27, 10].Value = extendsStaffMasterVo.Medical_examination_note_2;//健康状態備考2
            sheetView.Cells[29, 1].Value = extendsStaffMasterVo.Medical_examination_date_3 != _defaultDateTime ? extendsStaffMasterVo.Medical_examination_date_3.Date : null;//健康状態日付3
            sheetView.Cells[29, 10].Value = extendsStaffMasterVo.Medical_examination_note_3;//健康状態備考3
            sheetView.Cells[31, 1].Value = extendsStaffMasterVo.Medical_examination_date_4 != _defaultDateTime ? extendsStaffMasterVo.Medical_examination_date_4.Date : null;//健康状態日付4
            sheetView.Cells[31, 10].Value = extendsStaffMasterVo.Medical_examination_note_4;//健康状態備考4
            sheetView.Cells[33, 10].Value = extendsStaffMasterVo.Medical_examination_note;//診断以外で気づいた点
            /*
             * 交通事故発生年月日・概要
             */
            int count = 0;
            foreach(var carAccidentLedgerVo in _listCarAccidentLedgerVo) {
                switch(count) {
                    case 0:
                        sheetView.Cells[39, 1].Value = carAccidentLedgerVo.Occurrence_ymd_hms != _defaultDateTime ? carAccidentLedgerVo.Occurrence_ymd_hms.Date : null;
                        sheetView.Cells[39, 6].Value = carAccidentLedgerVo.Accident_summary;
                        break;
                    case 1:
                        sheetView.Cells[41, 1].Value = carAccidentLedgerVo.Occurrence_ymd_hms != _defaultDateTime ? carAccidentLedgerVo.Occurrence_ymd_hms.Date : null;
                        sheetView.Cells[41, 6].Value = carAccidentLedgerVo.Accident_summary;
                        break;
                    case 2:
                        sheetView.Cells[43, 1].Value = carAccidentLedgerVo.Occurrence_ymd_hms != _defaultDateTime ? carAccidentLedgerVo.Occurrence_ymd_hms.Date : null;
                        sheetView.Cells[43, 6].Value = carAccidentLedgerVo.Accident_summary;
                        break;
                    case 3:
                        sheetView.Cells[39, 20].Value = carAccidentLedgerVo.Occurrence_ymd_hms != _defaultDateTime ? carAccidentLedgerVo.Occurrence_ymd_hms.Date : null;
                        sheetView.Cells[39, 25].Value = carAccidentLedgerVo.Accident_summary;
                        break;
                    case 4:
                        sheetView.Cells[41, 20].Value = carAccidentLedgerVo.Occurrence_ymd_hms != _defaultDateTime ? carAccidentLedgerVo.Occurrence_ymd_hms.Date : null;
                        sheetView.Cells[41, 25].Value = carAccidentLedgerVo.Accident_summary;
                        break;
                    case 5:
                        sheetView.Cells[43, 20].Value = carAccidentLedgerVo.Occurrence_ymd_hms != _defaultDateTime ? carAccidentLedgerVo.Occurrence_ymd_hms.Date : null;
                        sheetView.Cells[43, 25].Value = carAccidentLedgerVo.Accident_summary;
                        break;
                }
                count++;
            }
            sheetView.Cells[47, 1].Value = extendsStaffMasterVo.Car_violate_date_1 != _defaultDateTime ? extendsStaffMasterVo.Car_violate_date_1.Date : null;//交通違反歴発生年月日1
            sheetView.Cells[47, 6].Value = extendsStaffMasterVo.Car_violate_content_1;//交通違反内容1
            sheetView.Cells[47, 15].Value = extendsStaffMasterVo.Car_violate_place_1;//交通違反場所1
            sheetView.Cells[49, 1].Value = extendsStaffMasterVo.Car_violate_date_2 != _defaultDateTime ? extendsStaffMasterVo.Car_violate_date_2.Date : null;//交通違反歴発生年月日2
            sheetView.Cells[49, 6].Value = extendsStaffMasterVo.Car_violate_content_2;//交通違反内容2
            sheetView.Cells[49, 15].Value = extendsStaffMasterVo.Car_violate_place_2;//交通違反場所2
            sheetView.Cells[51, 1].Value = extendsStaffMasterVo.Car_violate_date_3 != _defaultDateTime ? extendsStaffMasterVo.Car_violate_date_3.Date : null;//交通違反歴発生年月日3
            sheetView.Cells[51, 6].Value = extendsStaffMasterVo.Car_violate_content_3;//交通違反内容3
            sheetView.Cells[51, 15].Value = extendsStaffMasterVo.Car_violate_place_3;//交通違反場所3
            sheetView.Cells[47, 20].Value = extendsStaffMasterVo.Car_violate_date_4 != _defaultDateTime ? extendsStaffMasterVo.Car_violate_date_4.Date : null;//交通違反歴発生年月日4
            sheetView.Cells[47, 25].Value = extendsStaffMasterVo.Car_violate_content_4;//交通違反内容4
            sheetView.Cells[47, 34].Value = extendsStaffMasterVo.Car_violate_place_4;//交通違反場所4
            sheetView.Cells[49, 20].Value = extendsStaffMasterVo.Car_violate_date_5 != _defaultDateTime ? extendsStaffMasterVo.Car_violate_date_5.Date : null;//交通違反歴発生年月日5
            sheetView.Cells[49, 25].Value = extendsStaffMasterVo.Car_violate_content_5;//交通違反内容5
            sheetView.Cells[49, 34].Value = extendsStaffMasterVo.Car_violate_place_5;//交通違反場所5
            sheetView.Cells[51, 20].Value = extendsStaffMasterVo.Car_violate_date_6 != _defaultDateTime ? extendsStaffMasterVo.Car_violate_date_6.Date : null;//交通違反歴発生年月日6
            sheetView.Cells[51, 25].Value = extendsStaffMasterVo.Car_violate_content_6;//交通違反内容6
            sheetView.Cells[51, 34].Value = extendsStaffMasterVo.Car_violate_place_6;//交通違反場所6
            sheetView.Cells[57, 1].Value = extendsStaffMasterVo.Educate_date_1 != _defaultDateTime ? extendsStaffMasterVo.Educate_date_1.Date : null;//指導教育実施年月日1
            sheetView.Cells[57, 6].Value = extendsStaffMasterVo.Educate_name_1;//指導教育実施対象理由1
            sheetView.Cells[59, 1].Value = extendsStaffMasterVo.Educate_date_2 != _defaultDateTime ? extendsStaffMasterVo.Educate_date_2.Date : null;//指導教育実施年月日2
            sheetView.Cells[59, 6].Value = extendsStaffMasterVo.Educate_name_2;//指導教育実施対象理由2
            sheetView.Cells[61, 1].Value = extendsStaffMasterVo.Educate_date_3 != _defaultDateTime ? extendsStaffMasterVo.Educate_date_3.Date : null;//指導教育実施年月日3
            sheetView.Cells[61, 6].Value = extendsStaffMasterVo.Educate_name_3;//指導教育実施対象理由3
            sheetView.Cells[57, 20].Value = extendsStaffMasterVo.Educate_date_4 != _defaultDateTime ? extendsStaffMasterVo.Educate_date_4.Date : null;//指導教育実施年月日4
            sheetView.Cells[57, 25].Value = extendsStaffMasterVo.Educate_name_4;//指導教育実施対象理由4
            sheetView.Cells[59, 20].Value = extendsStaffMasterVo.Educate_date_5 != _defaultDateTime ? extendsStaffMasterVo.Educate_date_5.Date : null;//指導教育実施年月日5
            sheetView.Cells[59, 25].Value = extendsStaffMasterVo.Educate_name_5;//指導教育実施対象理由5
            sheetView.Cells[61, 20].Value = extendsStaffMasterVo.Educate_date_6 != _defaultDateTime ? extendsStaffMasterVo.Educate_date_6.Date : null;//指導教育実施年月日6
            sheetView.Cells[61, 25].Value = extendsStaffMasterVo.Educate_name_6;//指導教育実施対象理由6
            sheetView.Cells[65, 3].Value = extendsStaffMasterVo.Proper_kind_1;//適性診断の種類1
            sheetView.Cells[65, 11].Value = extendsStaffMasterVo.Proper_date_1 != _defaultDateTime ? extendsStaffMasterVo.Proper_date_1.Date : null;//適性診断の実施年月日1
            sheetView.Cells[65, 16].Value = extendsStaffMasterVo.Proper_note_1;//適性診断の特記事項1
            sheetView.Cells[67, 3].Value = extendsStaffMasterVo.Proper_kind_2;//適性診断の種類2
            sheetView.Cells[67, 11].Value = extendsStaffMasterVo.Proper_date_2 != _defaultDateTime ? extendsStaffMasterVo.Proper_date_2.Date : null;//適性診断の実施年月日2
            sheetView.Cells[67, 16].Value = extendsStaffMasterVo.Proper_note_2;//適性診断の特記事項2
            sheetView.Cells[69, 3].Value = extendsStaffMasterVo.Proper_kind_3;//適性診断の種類3
            sheetView.Cells[69, 11].Value = extendsStaffMasterVo.Proper_date_3 != _defaultDateTime ? extendsStaffMasterVo.Proper_date_3.Date : null;//適性診断の実施年月日3
            sheetView.Cells[69, 16].Value = extendsStaffMasterVo.Proper_note_3;//適性診断の特記事項3
            sheetView.Cells[71, 3].Value = extendsStaffMasterVo.Punishment_date_1 != _defaultDateTime ? extendsStaffMasterVo.Punishment_date_1.Date : null;//賞罰実施年月日1
            sheetView.Cells[71, 9].Value = extendsStaffMasterVo.Punishment_note_1;//賞罰内容1
            sheetView.Cells[73, 3].Value = extendsStaffMasterVo.Punishment_date_2 != _defaultDateTime ? extendsStaffMasterVo.Punishment_date_2.Date : null;//賞罰実施年月日2
            sheetView.Cells[73, 9].Value = extendsStaffMasterVo.Punishment_note_2;//賞罰内容2
            sheetView.Cells[71, 21].Value = extendsStaffMasterVo.Punishment_date_3 != _defaultDateTime ? extendsStaffMasterVo.Punishment_date_3.Date : null;//賞罰実施年月日3
            sheetView.Cells[71, 27].Value = extendsStaffMasterVo.Punishment_note_3;//賞罰内容3
            sheetView.Cells[73, 21].Value = extendsStaffMasterVo.Punishment_date_4 != _defaultDateTime ? extendsStaffMasterVo.Punishment_date_4.Date : null;//賞罰実施年月日4
            sheetView.Cells[73, 27].Value = extendsStaffMasterVo.Punishment_note_4;//賞罰内容4
        }

        /// <summary>
        /// InitializeSpreadSpreadStaffRegisterHead
        /// </summary>
        private void InitializeSpreadStaffRegisterHead() {
            //表面
            SpreadStaffRegisterHead.SuspendLayout();
            SheetStaffRegisterHead.Cells[0, 32].Text = "";//印刷日時
            SheetStaffRegisterHead.Cells[2, 11].Text = "";//初任
            SheetStaffRegisterHead.Cells[3, 11].Text = "";//適齢
            SheetStaffRegisterHead.Cells[4, 11].Text = "";//健診
            SheetStaffRegisterHead.Cells[10, 5].Text = "";//ふりがな
            SheetStaffRegisterHead.Cells[11, 5].Text = "";//氏名
            SheetStaffRegisterHead.Cells[11, 18].Text = "";//性別
            SheetStaffRegisterHead.Cells[11, 20].Text = "";//生年月日
            SheetStaffRegisterHead.Cells[11, 26].Text = "";//雇用年月日
            SheetStaffRegisterHead.Cells[13, 5].Text = "";//現住所
            SheetStaffRegisterHead.Cells[15, 5].Text = "";//変更後住所
            SheetStaffRegisterHead.Cells[17, 7].Text = "";//電話番号
            SheetStaffRegisterHead.Cells[17, 21].Text = "";//携帯電話
            SheetStaffRegisterHead.Cells[10, 32].Value = null;//写真
            SheetStaffRegisterHead.Cells[19, 35].Text = "";//血液型
            SheetStaffRegisterHead.Cells[21, 9].Text = "";//運転者に選任された日
            SheetStaffRegisterHead.Cells[23, 9].Text = "";//運転者でなくなった日
            SheetStaffRegisterHead.Cells[25, 4].Text = "";//運転者でなくなった日　理由
            SheetStaffRegisterHead.Cells[27, 7].Text = "";//免許証番号
            SheetStaffRegisterHead.Cells[27, 17].Text = "";//条件等
            SheetStaffRegisterHead.Cells[31, 3].Text = "";//免許証の種類/取得日1
            SheetStaffRegisterHead.Cells[31, 27].Text = "";//有効期限1
            SheetStaffRegisterHead.Cells[33, 3].Text = "";//免許証の種類/取得日2
            SheetStaffRegisterHead.Cells[33, 27].Text = "";//有効期限2
            SheetStaffRegisterHead.Cells[35, 3].Text = "";//免許証の種類/取得日3
            SheetStaffRegisterHead.Cells[35, 27].Text = "";//有効期限3
            SheetStaffRegisterHead.Cells[37, 3].Text = "";//免許証の種類/取得日4
            SheetStaffRegisterHead.Cells[37, 27].Text = "";//有効期限4
            SheetStaffRegisterHead.Cells[39, 3].Text = "";//免許証の種類/取得日5
            SheetStaffRegisterHead.Cells[39, 27].Text = "";//有効期限5
            SheetStaffRegisterHead.Cells[41, 3].Text = "";//履歴日時1
            SheetStaffRegisterHead.Cells[41, 11].Text = "";//履歴内容1
            SheetStaffRegisterHead.Cells[43, 3].Text = "";//履歴日時2
            SheetStaffRegisterHead.Cells[43, 11].Text = "";//履歴内容2
            SheetStaffRegisterHead.Cells[45, 3].Text = "";//履歴日時3
            SheetStaffRegisterHead.Cells[45, 11].Text = "";//履歴内容3
            SheetStaffRegisterHead.Cells[41, 21].Text = "";//履歴日時4
            SheetStaffRegisterHead.Cells[41, 29].Text = "";//履歴内容4
            SheetStaffRegisterHead.Cells[43, 21].Text = "";//履歴日時5
            SheetStaffRegisterHead.Cells[43, 29].Text = "";//履歴内容5
            SheetStaffRegisterHead.Cells[45, 21].Text = "";//履歴日時6
            SheetStaffRegisterHead.Cells[45, 29].Text = "";//履歴内容6
            SheetStaffRegisterHead.Cells[51, 1].Text = "";//種類1
            SheetStaffRegisterHead.Cells[51, 12].Text = "";//積載量又は定員1
            SheetStaffRegisterHead.Cells[51, 20].Text = "";//経験期間1
            SheetStaffRegisterHead.Cells[51, 31].Text = "";//備考1
            SheetStaffRegisterHead.Cells[53, 1].Text = "";//種類2
            SheetStaffRegisterHead.Cells[53, 12].Text = "";//積載量又は定員2
            SheetStaffRegisterHead.Cells[53, 20].Text = "";//経験期間2
            SheetStaffRegisterHead.Cells[53, 31].Text = "";//備考2
            SheetStaffRegisterHead.Cells[55, 1].Text = "";//種類3
            SheetStaffRegisterHead.Cells[55, 12].Text = "";//積載量又は定員3
            SheetStaffRegisterHead.Cells[55, 20].Text = "";//経験期間3
            SheetStaffRegisterHead.Cells[55, 31].Text = "";//備考3
            SheetStaffRegisterHead.Cells[57, 1].Text = "";//種類4
            SheetStaffRegisterHead.Cells[57, 12].Text = "";//積載量又は定員4
            SheetStaffRegisterHead.Cells[57, 20].Text = "";//経験期間4
            SheetStaffRegisterHead.Cells[57, 31].Text = "";//備考4
            SheetStaffRegisterHead.Cells[60, 10].Text = "";//解雇又は退職の年月日
            SheetStaffRegisterHead.Cells[60, 17].Text = "";//解雇又は退職の理由
            SheetStaffRegisterHead.Cells[62, 15].Text = "";//死亡の場合の年月日
            SheetStaffRegisterHead.Cells[62, 22].Text = "";//死亡の場合の原因
            SpreadStaffRegisterHead.ResumeLayout(true);
        }

        /// <summary>
        /// InitializeSpreadSpreadStaffRegisterTail
        /// </summary>
        private void InitializeSpreadStaffRegisterTail() {
            //裏面
            SpreadStaffRegisterTail.SuspendLayout();
            SheetStaffRegisterTail.Cells[3, 3].Text = "";//家族状況氏名1
            SheetStaffRegisterTail.Cells[3, 12].Text = "";//家族状況生年月日1
            SheetStaffRegisterTail.Cells[3, 18].Text = "";//家族状況続柄1
            SheetStaffRegisterTail.Cells[5, 3].Text = "";//家族状況氏名2
            SheetStaffRegisterTail.Cells[5, 12].Text = "";//家族状況生年月日2
            SheetStaffRegisterTail.Cells[5, 18].Text = "";//家族状況続柄2
            SheetStaffRegisterTail.Cells[7, 3].Text = "";//家族状況氏名3
            SheetStaffRegisterTail.Cells[7, 12].Text = "";//家族状況生年月日3
            SheetStaffRegisterTail.Cells[7, 18].Text = "";//家族状況続柄3
            SheetStaffRegisterTail.Cells[3, 21].Text = "";//家族状況氏名4
            SheetStaffRegisterTail.Cells[3, 30].Text = "";//家族状況生年月日4
            SheetStaffRegisterTail.Cells[3, 36].Text = "";//家族状況続柄4
            SheetStaffRegisterTail.Cells[5, 21].Text = "";//家族状況氏名5
            SheetStaffRegisterTail.Cells[5, 30].Text = "";//家族状況生年月日5
            SheetStaffRegisterTail.Cells[5, 36].Text = "";//家族状況続柄5
            SheetStaffRegisterTail.Cells[7, 21].Text = "";//家族状況氏名6
            SheetStaffRegisterTail.Cells[7, 30].Text = "";//家族状況生年月日6
            SheetStaffRegisterTail.Cells[7, 36].Text = "";//家族状況続柄6
            SheetStaffRegisterTail.Cells[9, 9].Text = "";//緊急時連絡方法　電話
            SheetStaffRegisterTail.Cells[9, 17].Text = "";//緊急時連絡方法　方法
            SheetStaffRegisterTail.Cells[14, 10].Text = "";//健康保険加入年月日
            SheetStaffRegisterTail.Cells[14, 17].Text = "";//健康保険の記号・番号
            SheetStaffRegisterTail.Cells[14, 28].Text = "";//健康保険の備考
            SheetStaffRegisterTail.Cells[16, 10].Text = "";//厚生年金保険加入年月日
            SheetStaffRegisterTail.Cells[16, 17].Text = "";//厚生年金保険の記号・番号
            SheetStaffRegisterTail.Cells[16, 28].Text = "";//厚生年金保険の備考
            SheetStaffRegisterTail.Cells[18, 10].Text = "";//雇用保険加入年月日
            SheetStaffRegisterTail.Cells[18, 17].Text = "";//雇用保険の記号・番号
            SheetStaffRegisterTail.Cells[18, 28].Text = "";//雇用保険の備考
            SheetStaffRegisterTail.Cells[20, 10].Text = "";//労災保険加入年月日
            SheetStaffRegisterTail.Cells[20, 17].Text = "";//労災保険の記号・番号
            SheetStaffRegisterTail.Cells[20, 28].Text = "";//労災保険の備考
            SheetStaffRegisterTail.Cells[25, 1].Text = "";//健康状態日付1
            SheetStaffRegisterTail.Cells[25, 10].Text = "";//健康状態備考1
            SheetStaffRegisterTail.Cells[27, 1].Text = "";//健康状態日付2
            SheetStaffRegisterTail.Cells[27, 10].Text = "";//健康状態備考2
            SheetStaffRegisterTail.Cells[29, 1].Text = "";//健康状態日付3
            SheetStaffRegisterTail.Cells[29, 10].Text = "";//健康状態備考3
            SheetStaffRegisterTail.Cells[31, 1].Text = "";//健康状態日付4
            SheetStaffRegisterTail.Cells[31, 10].Text = "";//健康状態備考4
            SheetStaffRegisterTail.Cells[33, 10].Text = "";//診断以外で気づいた点
            SheetStaffRegisterTail.Cells[39, 1].Text = "";//交通事故歴発生年月日1
            SheetStaffRegisterTail.Cells[39, 6].Text = "";//交通事故概要1
            SheetStaffRegisterTail.Cells[41, 1].Text = "";//交通事故歴発生年月日2
            SheetStaffRegisterTail.Cells[41, 6].Text = "";//交通事故概要2
            SheetStaffRegisterTail.Cells[43, 1].Text = "";//交通事故歴発生年月日3
            SheetStaffRegisterTail.Cells[43, 6].Text = "";//交通事故概要3
            SheetStaffRegisterTail.Cells[39, 20].Text = "";//交通事故歴発生年月日4
            SheetStaffRegisterTail.Cells[39, 25].Text = "";//交通事故概要4
            SheetStaffRegisterTail.Cells[41, 20].Text = "";//交通事故歴発生年月日5
            SheetStaffRegisterTail.Cells[41, 25].Text = "";//交通事故概要5
            SheetStaffRegisterTail.Cells[43, 20].Text = "";//交通事故歴発生年月日6
            SheetStaffRegisterTail.Cells[43, 25].Text = "";//交通事故概要6
            SheetStaffRegisterTail.Cells[47, 1].Text = "";//交通違反歴発生年月日1
            SheetStaffRegisterTail.Cells[47, 6].Text = "";//交通違反内容1
            SheetStaffRegisterTail.Cells[47, 15].Text = "";//交通違反場所1
            SheetStaffRegisterTail.Cells[49, 1].Text = "";//交通違反歴発生年月日2
            SheetStaffRegisterTail.Cells[49, 6].Text = "";//交通違反内容2
            SheetStaffRegisterTail.Cells[49, 15].Text = "";//交通違反場所2
            SheetStaffRegisterTail.Cells[51, 1].Text = "";//交通違反歴発生年月日3
            SheetStaffRegisterTail.Cells[51, 6].Text = "";//交通違反内容3
            SheetStaffRegisterTail.Cells[51, 15].Text = "";//交通違反場所3
            SheetStaffRegisterTail.Cells[47, 20].Text = "";//交通違反歴発生年月日4
            SheetStaffRegisterTail.Cells[47, 25].Text = "";//交通違反内容4
            SheetStaffRegisterTail.Cells[47, 34].Text = "";//交通違反場所4
            SheetStaffRegisterTail.Cells[49, 20].Text = "";//交通違反歴発生年月日5
            SheetStaffRegisterTail.Cells[49, 25].Text = "";//交通違反内容5
            SheetStaffRegisterTail.Cells[49, 34].Text = "";//交通違反場所5
            SheetStaffRegisterTail.Cells[51, 20].Text = "";//交通違反歴発生年月日6
            SheetStaffRegisterTail.Cells[51, 25].Text = "";//交通違反内容6
            SheetStaffRegisterTail.Cells[51, 34].Text = "";//交通違反場所6
            SheetStaffRegisterTail.Cells[57, 1].Text = "";//指導教育実施年月日1
            SheetStaffRegisterTail.Cells[57, 6].Text = "";//指導教育実施対象理由1
            SheetStaffRegisterTail.Cells[59, 1].Text = "";//指導教育実施年月日2
            SheetStaffRegisterTail.Cells[59, 6].Text = "";//指導教育実施対象理由2
            SheetStaffRegisterTail.Cells[61, 1].Text = "";//指導教育実施年月日3
            SheetStaffRegisterTail.Cells[61, 6].Text = "";//指導教育実施対象理由3
            SheetStaffRegisterTail.Cells[57, 20].Text = "";//指導教育実施年月日4
            SheetStaffRegisterTail.Cells[57, 25].Text = "";//指導教育実施対象理由4
            SheetStaffRegisterTail.Cells[59, 20].Text = "";//指導教育実施年月日5
            SheetStaffRegisterTail.Cells[59, 25].Text = "";//指導教育実施対象理由5
            SheetStaffRegisterTail.Cells[61, 20].Text = "";//指導教育実施年月日6
            SheetStaffRegisterTail.Cells[61, 25].Text = "";//指導教育実施対象理由6
            SheetStaffRegisterTail.Cells[65, 3].Text = "";//適性診断の種類1
            SheetStaffRegisterTail.Cells[65, 11].Text = "";//適性診断の実施年月日1
            SheetStaffRegisterTail.Cells[65, 16].Text = "";//適性診断の特記事項1
            SheetStaffRegisterTail.Cells[67, 3].Text = "";//適性診断の種類2
            SheetStaffRegisterTail.Cells[67, 11].Text = "";//適性診断の実施年月日2
            SheetStaffRegisterTail.Cells[67, 16].Text = "";//適性診断の特記事項2
            SheetStaffRegisterTail.Cells[69, 3].Text = "";//適性診断の種類3
            SheetStaffRegisterTail.Cells[69, 11].Text = "";//適性診断の実施年月日3
            SheetStaffRegisterTail.Cells[69, 16].Text = "";//適性診断の特記事項3
            SheetStaffRegisterTail.Cells[71, 3].Text = "";//賞罰実施年月日1
            SheetStaffRegisterTail.Cells[71, 9].Text = "";//賞罰内容1
            SheetStaffRegisterTail.Cells[73, 3].Text = "";//賞罰実施年月日2
            SheetStaffRegisterTail.Cells[73, 9].Text = "";//賞罰内容2
            SheetStaffRegisterTail.Cells[71, 21].Text = "";//賞罰実施年月日3
            SheetStaffRegisterTail.Cells[71, 27].Text = "";//賞罰内容3
            SheetStaffRegisterTail.Cells[73, 21].Text = "";//賞罰実施年月日4
            SheetStaffRegisterTail.Cells[73, 27].Text = "";//賞罰内容4
            SpreadStaffRegisterTail.ResumeLayout(true);
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// ButtonPrint_Click
        /// 印刷する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        PrintDocument? printDocument;
        private void ButtonPrint_Click(object sender, EventArgs e) {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            // 出力先プリンタを指定します。
            //printDocument.PrinterSettings.PrinterName = "(PrinterName)";
            // 印刷部数を指定します。
            printDocument.PrinterSettings.Copies = 1;
            // 両面印刷に設定します。
            printDocument.PrinterSettings.Duplex = Duplex.Vertical;
            // カラー印刷に設定します。
            printDocument.PrinterSettings.DefaultPageSettings.Color = true;

            printDocument.Print();
        }

        /// <summary>
        /// printDocument_PrintPage
        /// </summary>
        private int curPageNumber = 0; // 現在のページ番号
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            if(curPageNumber == 0) {
                // 印刷ページ（1ページ目）の描画を行う
                var rectangle = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
                // 使用するページ数を計算
                //int cnt = SpreadStaffRegisterHead.GetOwnerPrintPageCount(e.Graphics, rectangle, 0);
                // e.Graphicsへ出力
                SpreadStaffRegisterHead.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
                // 印刷継続を指定
                e.HasMorePages = true;
            } else {
                // 印刷ページ（2ページ目）の描画を行う
                var rectangle = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
                // 使用するページ数を計算
                //int cnt = SpreadStaffRegisterHead.GetOwnerPrintPageCount(e.Graphics, rectangle, 0);
                // e.Graphicsへ出力
                SpreadStaffRegisterTail.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
                // 印刷終了を指定
                e.HasMorePages = false;
            }
            //ページ番号を繰り上げる
            curPageNumber++;
        }
    }
}
