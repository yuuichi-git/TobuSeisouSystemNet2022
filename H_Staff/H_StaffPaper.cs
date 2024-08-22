/*
 * 2024-02-16
 */
using System.Drawing.Printing;

using FarPoint.Win.Spread;

using H_Dao;

using H_Vo;

using Vo;

namespace H_Staff {
    public partial class HStaffPaper : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly int _staffCode;
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_StaffHistoryDao _hStaffHistoryDao;
        private readonly H_StaffExperienceDao _hStaffExperienceDao;
        private readonly H_StaffFamilyDao _hStaffFamilyDao;
        private readonly H_StaffMedicalExaminationDao _hStaffMedicalExaminationDao;
        private readonly H_StaffCarViolateDao _hStaffCarViolateDao;
        private readonly H_StaffEducateDao _hStaffEducateDao;
        private readonly H_StaffProperDao _hStaffProperDao;
        private readonly H_StaffPunishmentDao _hStaffPunishmentDao;
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
        private readonly H_CarAccidentMasterDao _hCarAccidentMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private readonly H_StaffMasterVo _hStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public HStaffPaper(ConnectionVo connectionVo, int staffCode) {
            _staffCode = staffCode;
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hStaffHistoryDao = new(connectionVo);
            _hStaffExperienceDao = new(connectionVo);
            _hStaffFamilyDao = new(connectionVo);
            _hStaffMedicalExaminationDao = new(connectionVo);
            _hStaffCarViolateDao = new(connectionVo);
            _hStaffEducateDao = new(connectionVo);
            _hStaffProperDao = new(connectionVo);
            _hStaffPunishmentDao = new(connectionVo);
            _hLicenseMasterDao = new(connectionVo);
            _hCarAccidentMasterDao = new(connectionVo);
            ;
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _hStaffMasterVo = _hStaffMasterDao.SelectOneHStaffMaster(staffCode);
            _hStaffHistoryDao.SelectOneHStaffHistoryMaster(staffCode);
            _hStaffExperienceDao.SelectOneHStaffExperienceMaster(staffCode);
            _hStaffFamilyDao.SelectOneHStaffFamilyMaster(staffCode);
            _hStaffMedicalExaminationDao.SelectOneHStaffMedicalExaminationMaster(staffCode);
            _hStaffCarViolateDao.SelectOneHStaffCarViolateMaster(staffCode);
            _hStaffEducateDao.SelectOneHStaffEducateMaster(staffCode);
            _hStaffProperDao.SelectOneHStaffProperMaster(staffCode);
            _hStaffPunishmentDao.SelectOneHStaffPunishmentMaster(staffCode);



            InitializeComponent();
            // Spread初期化
            InitializeSpreadStaffRegisterHead();
            InitializeSpreadStaffRegisterTail();
            // ToolStrip初期化
            ToolStripStatusLabelDetail.Text = string.Empty;
            /*
             * 表示 
             */
            SheetViewHeadOutPut();
            SheetViewTailOutPut();
        }

        /// <summary>
        /// SheetViewHeadOutPut
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="_hStaffMasterVo"></param>
        private void SheetViewHeadOutPut() {
            SheetView sheetView = SheetStaffRegisterHead;
            /*
             * 印刷日時
             */
            sheetView.Cells[0, 32].Text = string.Concat(DateTime.Now.ToString("yyyy年MM月dd日　印刷"));
            /*
             * 初任診断
             */
            if (_hStaffMasterVo.Occupation == 10) {
                DateTime syoninProperDate = _hStaffProperDao.GetSyoninProperDate(_hStaffMasterVo.StaffCode);
                if (syoninProperDate != _defaultDateTime) {
                    sheetView.Cells[2, 10].ForeColor = Color.Black;
                    sheetView.Cells[2, 10].Text = syoninProperDate.ToString("yyyy/MM/dd");
                } else {
                    sheetView.Cells[2, 10].ForeColor = Color.Black;
                    sheetView.Cells[2, 10].Text = "記録なし";
                }
            } else {
                sheetView.Cells[2, 10].ForeColor = Color.White;
                sheetView.Cells[2, 10].Text = string.Empty;
            }
            /*
             * 適齢診断
             */
            int age = new H_Common.Date().GetAge(_hStaffMasterVo.BirthDate);
            // ”65歳以上”及び”運転手”ならForeColorを変える
            if (age >= 65 && _hStaffMasterVo.Occupation == 10) {
                string tekireiProperDate = _hStaffProperDao.GetTekireiProperDate(_hStaffMasterVo.StaffCode);
                if (tekireiProperDate != string.Empty) {
                    sheetView.Cells[3, 10].ForeColor = Color.Black;
                    sheetView.Cells[3, 10].Text = tekireiProperDate;
                } else {
                    sheetView.Cells[3, 10].ForeColor = Color.Black;
                    sheetView.Cells[3, 10].Text = "記録なし";
                }
            } else {
                sheetView.Cells[3, 10].ForeColor = Color.White;
                sheetView.Cells[3, 10].Text = string.Empty;
            }
            /*
             * 健康診断
             */
            DateTime medicalExaminationDate = _hStaffMedicalExaminationDao.GetMedicalExaminationDate(_hStaffMasterVo.StaffCode);
            if (medicalExaminationDate != _defaultDateTime) {
                if (medicalExaminationDate.AddYears(1) > DateTime.Now) {
                    sheetView.Cells[4, 10].ForeColor = Color.Black;
                    sheetView.Cells[4, 10].Text = medicalExaminationDate.ToString("yyyy/MM/dd");
                } else {
                    sheetView.Cells[4, 10].ForeColor = Color.Black;
                    sheetView.Cells[4, 10].Text = "１年以上経過";
                }
            } else {
                sheetView.Cells[4, 10].ForeColor = Color.Black;
                sheetView.Cells[4, 10].Text = "記録なし";
            }
            /*
             * 社員
             */
            if (_hStaffMasterVo.Belongs == 10 || _hStaffMasterVo.Belongs == 11) {
                sheetView.Cells[2, 1].ForeColor = Color.Red;
                sheetView.Cells[2, 2].ForeColor = Color.Red;
            }
            /*
             * アルバイト
             */
            if (_hStaffMasterVo.Belongs == 12) {
                sheetView.Cells[3, 1].ForeColor = Color.Red;
                sheetView.Cells[3, 2].ForeColor = Color.Red;
            }
            /*
             * 派遣
             */
            if (_hStaffMasterVo.Belongs == 13) {
                sheetView.Cells[4, 1].ForeColor = Color.Red;
                sheetView.Cells[4, 2].ForeColor = Color.Red;
            }
            /*
             * 労共(長期)
             */
            if ((_hStaffMasterVo.Belongs == 20 || _hStaffMasterVo.Belongs == 21) && _hStaffMasterVo.JobForm == 10) {
                sheetView.Cells[5, 1].ForeColor = Color.Red;
                sheetView.Cells[5, 2].ForeColor = Color.Red;
            }
            /*
             * 労共(短期)
             */
            if ((_hStaffMasterVo.Belongs == 20 || _hStaffMasterVo.Belongs == 21) && _hStaffMasterVo.JobForm == 11) {
                sheetView.Cells[6, 1].ForeColor = Color.Red;
                sheetView.Cells[6, 2].ForeColor = Color.Red;
            }
            /*
             * 運転手
             */
            if (_hStaffMasterVo.Occupation == 10) {
                sheetView.Cells[7, 1].ForeColor = Color.Red;
                sheetView.Cells[7, 2].ForeColor = Color.Red;
            }
            /*
             * 作業員
             */
            Dictionary<int, string> _dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };
            if (_hStaffMasterVo.Occupation == 11) {
                sheetView.Cells[8, 1].ForeColor = Color.Red;
                sheetView.Cells[8, 2].ForeColor = Color.Red;
            }
            sheetView.Cells[10, 5].Text = _hStaffMasterVo.NameKana; // フリガナ
            sheetView.Cells[11, 5].Text = string.Concat(_hStaffMasterVo.Name, " (", _dictionaryBelongs[_hStaffMasterVo.Belongs], ")"); // 氏名
            sheetView.Cells[11, 18].Text = _hStaffMasterVo.Gender; // 性別
            sheetView.Cells[11, 20].Value = _hStaffMasterVo.BirthDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.BirthDate.Date : null; // 生年月日
            sheetView.Cells[11, 26].Value = _hStaffMasterVo.EmploymentDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.EmploymentDate.Date : null; // 雇用年月日
            sheetView.Cells[13, 5].Text = _hStaffMasterVo.CurrentAddress; // 現住所
            sheetView.Cells[15, 5].Text = _hStaffMasterVo.Remarks; // 変更後住所
            sheetView.Cells[17, 7].Text = _hStaffMasterVo.TelephoneNumber; // 電話番号
            sheetView.Cells[17, 21].Text = _hStaffMasterVo.CellphoneNumber; // 携帯電話
            sheetView.Cells[10, 32].Value = _hStaffMasterVo.Picture.Length != 0 ? (Image?)new ImageConverter().ConvertFrom(_hStaffMasterVo.Picture) : null;
            sheetView.Cells[19, 35].Text = _hStaffMasterVo.BloodType;//血液型
            sheetView.Cells[21, 9].Value = _hStaffMasterVo.SelectionDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.SelectionDate.Date : null;//運転者に選任された日
            sheetView.Cells[23, 9].Value = _hStaffMasterVo.NotSelectionDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.NotSelectionDate.Date : null;//運転者でなくなった日
            sheetView.Cells[25, 4].Text = _hStaffMasterVo.NotSelectionReason;//運転者でなくなった日　理由
            /*
             * 免許証関連
             */
            H_LicenseMasterVo hLicenseMasterVo = new();
            try {
                hLicenseMasterVo = _hLicenseMasterDao.SelectOneHLicenseMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            sheetView.Cells[27, 7].Text = hLicenseMasterVo.LicenseNumber;//免許証番号
            sheetView.Cells[27, 17].Text = hLicenseMasterVo.LicenseCondition;//条件等
            string? kind = null;
            if (hLicenseMasterVo.Large)
                kind += "(大型)";
            if (hLicenseMasterVo.Medium)
                kind += "(中型)";
            if (hLicenseMasterVo.QuasiMedium)
                kind += "(準中型)";
            if (hLicenseMasterVo.Ordinary)
                kind += "(普通)";
            if (kind != null) {
                sheetView.Cells[31, 3].Text = string.Concat(kind, ":", hLicenseMasterVo.DeliveryDate.ToString("yyyy年MM月dd日"));//免許証の種類/取得日1
                sheetView.Cells[31, 27].Value = hLicenseMasterVo.ExpirationDate.Date;//有効期限1
            }
            /*
             * 社歴
             */
            Dictionary<int, Point> _pointHistoryDate = new Dictionary<int, Point> { { 0, new Point(41, 3) }, { 1, new Point(43, 3) }, { 2, new Point(45, 3) }, { 3, new Point(41, 21) }, { 4, new Point(43, 21) }, { 5, new Point(45, 21) } };
            Dictionary<int, Point> _pointHistoryNote = new Dictionary<int, Point> { { 0, new Point(41, 11) }, { 1, new Point(43, 11) }, { 2, new Point(45, 11) }, { 3, new Point(41, 29) }, { 4, new Point(43, 29) }, { 5, new Point(45, 29) } };
            List<H_StaffHistoryVo> listHStaffHistoryVo = new();
            try {
                listHStaffHistoryVo = _hStaffHistoryDao.SelectOneHStaffHistoryMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffHistoryVo = 0;
            foreach (H_StaffHistoryVo hStaffHistoryVo in listHStaffHistoryVo.OrderBy(x => x.HistoryDate)) {
                sheetView.Cells[_pointHistoryDate[countHStaffHistoryVo].X, _pointHistoryDate[countHStaffHistoryVo].Y].Value = hStaffHistoryVo.HistoryDate.Date != _defaultDateTime.Date ? hStaffHistoryVo.HistoryDate.Date : null;
                sheetView.Cells[_pointHistoryNote[countHStaffHistoryVo].X, _pointHistoryNote[countHStaffHistoryVo].Y].Text = hStaffHistoryVo.CompanyName;
                countHStaffHistoryVo++;
                if (countHStaffHistoryVo > 5)
                    break;
            }
            /*
             * 過去に運転経験のある車両
             */
            Dictionary<int, Point> _pointExperienceKind = new Dictionary<int, Point> { { 0, new Point(51, 1) }, { 1, new Point(53, 1) }, { 2, new Point(55, 1) }, { 3, new Point(57, 1) } };
            Dictionary<int, Point> _pointExperienceLoad = new Dictionary<int, Point> { { 0, new Point(51, 12) }, { 1, new Point(53, 12) }, { 2, new Point(55, 12) }, { 3, new Point(57, 12) } };
            Dictionary<int, Point> _pointExperienceDuration = new Dictionary<int, Point> { { 0, new Point(51, 20) }, { 1, new Point(53, 20) }, { 2, new Point(55, 20) }, { 3, new Point(57, 20) } };
            Dictionary<int, Point> _pointExperienceNote = new Dictionary<int, Point> { { 0, new Point(51, 31) }, { 1, new Point(53, 31) }, { 2, new Point(55, 31) }, { 3, new Point(57, 31) } };
            List<H_StaffExperienceVo> listHStaffExperienceVo = new();
            try {
                listHStaffExperienceVo = _hStaffExperienceDao.SelectOneHStaffExperienceMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffExperienceVo = 0;
            foreach (H_StaffExperienceVo hStaffExperienceVo in listHStaffExperienceVo) {
                sheetView.Cells[_pointExperienceKind[countHStaffExperienceVo].X, _pointExperienceKind[countHStaffExperienceVo].Y].Text = hStaffExperienceVo.ExperienceKind;//種類
                sheetView.Cells[_pointExperienceLoad[countHStaffExperienceVo].X, _pointExperienceLoad[countHStaffExperienceVo].Y].Text = hStaffExperienceVo.ExperienceLoad;//積載量又は定員
                sheetView.Cells[_pointExperienceDuration[countHStaffExperienceVo].X, _pointExperienceDuration[countHStaffExperienceVo].Y].Text = hStaffExperienceVo.ExperienceDuration;//経験期間
                sheetView.Cells[_pointExperienceNote[countHStaffExperienceVo].X, _pointExperienceNote[countHStaffExperienceVo].Y].Text = hStaffExperienceVo.ExperienceNote;//備考
                countHStaffExperienceVo++;
                if (countHStaffExperienceVo > 3)
                    break;
            }
            /*
             * 解雇・死亡
             */
            sheetView.Cells[60, 10].Value = _hStaffMasterVo.RetirementDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.RetirementDate.Date : null; // 解雇又は退職の年月日
            sheetView.Cells[60, 17].Text = _hStaffMasterVo.RetirementNote; // 解雇又は退職の理由
            sheetView.Cells[62, 15].Value = _hStaffMasterVo.DeathDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.DeathDate.Date : null; // 死亡の場合の年月日
            sheetView.Cells[62, 22].Text = _hStaffMasterVo.DeathNote; // 死亡の場合の原因
        }


        private void SheetViewTailOutPut() {
            SheetView sheetView = SheetStaffRegisterTail;
            /*
             * 家族状況
             */
            Dictionary<int, Point> _pointFamilyName = new Dictionary<int, Point> { { 0, new Point(3, 3) }, { 1, new Point(5, 3) }, { 2, new Point(7, 3) }, { 3, new Point(3, 21) }, { 4, new Point(5, 21) }, { 5, new Point(7, 21) } };
            Dictionary<int, Point> _pointFamilyBirthDay = new Dictionary<int, Point> { { 0, new Point(3, 12) }, { 1, new Point(5, 12) }, { 2, new Point(7, 12) }, { 3, new Point(3, 30) }, { 4, new Point(5, 30) }, { 5, new Point(7, 30) } };
            Dictionary<int, Point> _pointFamilyRelationship = new Dictionary<int, Point> { { 0, new Point(3, 18) }, { 1, new Point(5, 18) }, { 2, new Point(7, 18) }, { 3, new Point(3, 36) }, { 4, new Point(5, 36) }, { 5, new Point(7, 36) } };
            List<H_StaffFamilyVo> listHStaffFamilyVo = new();
            try {
                listHStaffFamilyVo = _hStaffFamilyDao.SelectOneHStaffFamilyMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countStaffFamilyVo = 0;
            foreach (H_StaffFamilyVo hStaffFamilyVo in listHStaffFamilyVo.OrderBy(x => x.FamilyBirthDay)) {
                sheetView.Cells[_pointFamilyName[countStaffFamilyVo].X, _pointFamilyName[countStaffFamilyVo].Y].Text = hStaffFamilyVo.FamilyName;
                sheetView.Cells[_pointFamilyBirthDay[countStaffFamilyVo].X, _pointFamilyBirthDay[countStaffFamilyVo].Y].Value = hStaffFamilyVo.FamilyBirthDay.Date != _defaultDateTime.Date ? hStaffFamilyVo.FamilyBirthDay.Date : null;
                sheetView.Cells[_pointFamilyRelationship[countStaffFamilyVo].X, _pointFamilyRelationship[countStaffFamilyVo].Y].Text = hStaffFamilyVo.FamilyRelationship;
                countStaffFamilyVo++;
                if (countStaffFamilyVo > 5)
                    break;
            }
            sheetView.Cells[9, 9].Value = _hStaffMasterVo.UrgentTelephoneNumber; // 緊急時連絡方法　電話
            sheetView.Cells[9, 17].Value = _hStaffMasterVo.UrgentTelephoneMethod; // 緊急時連絡方法　方法
            /*
             * 保険関係
             */
            sheetView.Cells[14, 10].Value = _hStaffMasterVo.HealthInsuranceDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.HealthInsuranceDate.Date : null; // 健康保険加入年月日
            sheetView.Cells[14, 17].Value = _hStaffMasterVo.HealthInsuranceNumber; // 健康保険の記号・番号
            sheetView.Cells[14, 28].Value = _hStaffMasterVo.HealthInsuranceNote; // 健康保険の備考
            sheetView.Cells[16, 10].Value = _hStaffMasterVo.WelfarePensionDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.WelfarePensionDate.Date : null; // 厚生年金保険加入年月日
            sheetView.Cells[16, 17].Value = _hStaffMasterVo.WelfarePensionNumber; // 厚生年金保険の記号・番号
            sheetView.Cells[16, 28].Value = _hStaffMasterVo.WelfarePensionNote; // 厚生年金保険の備考
            sheetView.Cells[18, 10].Value = _hStaffMasterVo.EmploymentInsuranceDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.EmploymentInsuranceDate.Date : null; // 雇用保険加入年月日
            sheetView.Cells[18, 17].Value = _hStaffMasterVo.EmploymentInsuranceNumber; // 雇用保険の記号・番号
            sheetView.Cells[18, 28].Value = _hStaffMasterVo.EmploymentInsuranceNote; // 雇用保険の備考
            sheetView.Cells[20, 10].Value = _hStaffMasterVo.WorkerAccidentInsuranceDate.Date != _defaultDateTime.Date ? _hStaffMasterVo.WorkerAccidentInsuranceDate.Date : null; // 労災保険加入年月日
            sheetView.Cells[20, 17].Value = _hStaffMasterVo.WorkerAccidentInsuranceNumber; // 労災保険の記号・番号
            sheetView.Cells[20, 28].Value = _hStaffMasterVo.WorkerAccidentInsuranceNote; // 労災保険の備考
            /*
             * 健康診断
             */
            Dictionary<int, Point> _pointMedicalExaminationDate = new Dictionary<int, Point> { { 0, new Point(25, 1) }, { 1, new Point(27, 1) }, { 2, new Point(29, 1) }, { 3, new Point(31, 1) } };
            Dictionary<int, Point> _pointMedicalInstitutionName = new Dictionary<int, Point> { { 0, new Point(25, 10) }, { 1, new Point(27, 10) }, { 2, new Point(29, 10) }, { 3, new Point(31, 10) } };
            //Dictionary<int, Point> _pointMedicalExaminationNote = new Dictionary<int, Point> { { 0, new Point(25, 10) }, { 1, new Point(27, 10) }, { 2, new Point(29, 10) }, { 3, new Point(31, 10) } };
            List<H_StaffMedicalExaminationVo> listHStaffMedicalExaminationVo = new();
            try {
                listHStaffMedicalExaminationVo = _hStaffMedicalExaminationDao.SelectOneHStaffMedicalExaminationMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffMedicalExaminationVo = 0;
            foreach (H_StaffMedicalExaminationVo hStaffMedicalExaminationVo in listHStaffMedicalExaminationVo.OrderByDescending(x => x.MedicalExaminationDate)) {
                sheetView.Cells[_pointMedicalExaminationDate[countHStaffMedicalExaminationVo].X, _pointMedicalExaminationDate[countHStaffMedicalExaminationVo].Y].Value = hStaffMedicalExaminationVo.MedicalExaminationDate.Date != _defaultDateTime.Date ? hStaffMedicalExaminationVo.MedicalExaminationDate.Date : null;
                sheetView.Cells[_pointMedicalInstitutionName[countHStaffMedicalExaminationVo].X, _pointMedicalInstitutionName[countHStaffMedicalExaminationVo].Y].Text = hStaffMedicalExaminationVo.MedicalInstitutionName;
                //sheetView.Cells[_pointMedicalExaminationNote[countHStaffMedicalExaminationVo].X, _pointMedicalExaminationNote[countHStaffMedicalExaminationVo].Y].Text = hStaffMedicalExaminationVo.MedicalExaminationNote;
                countHStaffMedicalExaminationVo++;
                if (countHStaffMedicalExaminationVo > 3)
                    break;
            }
            sheetView.Cells[33, 10].Value = countHStaffMedicalExaminationVo != 0 ? "診断結果を参照" : ""; // 診断以外で気づいた点
            /*
             * 交通事故発生年月日・概要
             */
            Dictionary<int, Point> _pointOccurrenceYmdHms = new Dictionary<int, Point> { { 0, new Point(39, 1) }, { 1, new Point(41, 1) }, { 2, new Point(43, 1) }, { 3, new Point(39, 20) }, { 4, new Point(41, 20) }, { 5, new Point(43, 20) } };
            Dictionary<int, Point> _pointAccidentSummary = new Dictionary<int, Point> { { 0, new Point(39, 6) }, { 1, new Point(41, 6) }, { 2, new Point(43, 6) }, { 3, new Point(39, 25) }, { 4, new Point(41, 25) }, { 5, new Point(43, 25) } };
            List<H_CarAccidentMasterVo> listHCarAccidentMasterVo = new();
            try {
                listHCarAccidentMasterVo = _hCarAccidentMasterDao.SelectGroupHCarAccidentMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHCarAccidentMasterVo = 0;
            foreach (H_CarAccidentMasterVo hCarAccidentMasterVo in listHCarAccidentMasterVo.OrderByDescending(x => x.OccurrenceYmdHms)) {
                sheetView.Cells[_pointOccurrenceYmdHms[countHCarAccidentMasterVo].X, _pointOccurrenceYmdHms[countHCarAccidentMasterVo].Y].Value = hCarAccidentMasterVo.OccurrenceYmdHms.Date != _defaultDateTime.Date ? hCarAccidentMasterVo.OccurrenceYmdHms.Date : null;
                sheetView.Cells[_pointAccidentSummary[countHCarAccidentMasterVo].X, _pointAccidentSummary[countHCarAccidentMasterVo].Y].Text = hCarAccidentMasterVo.AccidentSummary;
                countHCarAccidentMasterVo++;
                if (countHCarAccidentMasterVo > 5)
                    break;
            }
            /*
             * 交通違反
             */
            Dictionary<int, Point> _pointCarViolateDate = new Dictionary<int, Point> { { 0, new Point(47, 1) }, { 1, new Point(49, 1) }, { 2, new Point(51, 1) }, { 3, new Point(47, 20) }, { 4, new Point(49, 20) }, { 5, new Point(51, 20) } };
            Dictionary<int, Point> _pointCarViolateContent = new Dictionary<int, Point> { { 0, new Point(47, 6) }, { 1, new Point(49, 6) }, { 2, new Point(51, 6) }, { 3, new Point(47, 25) }, { 4, new Point(49, 25) }, { 5, new Point(51, 25) } };
            Dictionary<int, Point> _pointCarViolatePlace = new Dictionary<int, Point> { { 0, new Point(47, 15) }, { 1, new Point(49, 15) }, { 2, new Point(51, 15) }, { 3, new Point(47, 34) }, { 4, new Point(49, 34) }, { 5, new Point(51, 34) } };
            List<H_StaffCarViolateVo> listHStaffCarViolateVo = new();
            try {
                listHStaffCarViolateVo = _hStaffCarViolateDao.SelectOneHStaffCarViolateMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffCarViolateVo = 0;
            foreach (H_StaffCarViolateVo hStaffCarViolateVo in listHStaffCarViolateVo.OrderByDescending(x => x.CarViolateDate)) {
                sheetView.Cells[_pointCarViolateDate[countHStaffCarViolateVo].X, _pointCarViolateDate[countHStaffCarViolateVo].Y].Value = hStaffCarViolateVo.CarViolateDate.Date != _defaultDateTime.Date ? hStaffCarViolateVo.CarViolateDate.Date : null;
                sheetView.Cells[_pointCarViolateContent[countHStaffCarViolateVo].X, _pointCarViolateContent[countHStaffCarViolateVo].Y].Text = hStaffCarViolateVo.CarViolateContent;
                sheetView.Cells[_pointCarViolatePlace[countHStaffCarViolateVo].X, _pointCarViolatePlace[countHStaffCarViolateVo].Y].Text = hStaffCarViolateVo.CarViolatePlace;
                countHStaffCarViolateVo++;
                if (countHStaffCarViolateVo > 5)
                    break;
            }
            /*
             * 教育
             */
            Dictionary<int, Point> _pointEducateDate = new Dictionary<int, Point> { { 0, new Point(57, 1) }, { 1, new Point(59, 1) }, { 2, new Point(61, 1) }, { 3, new Point(57, 20) }, { 4, new Point(59, 20) }, { 5, new Point(61, 20) } };
            Dictionary<int, Point> _pointEducateName = new Dictionary<int, Point> { { 0, new Point(57, 6) }, { 1, new Point(59, 6) }, { 2, new Point(61, 6) }, { 3, new Point(57, 25) }, { 4, new Point(59, 25) }, { 5, new Point(61, 25) } };
            List<H_StaffEducateVo> listHStaffEducateVo = new();
            try {
                listHStaffEducateVo = _hStaffEducateDao.SelectOneHStaffEducateMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffEducateVo = 0;
            foreach (H_StaffEducateVo hStaffEducateVo in listHStaffEducateVo.OrderByDescending(x => x.EducateDate)) {
                sheetView.Cells[_pointEducateDate[countHStaffEducateVo].X, _pointEducateDate[countHStaffEducateVo].Y].Value = hStaffEducateVo.EducateDate.Date != _defaultDateTime.Date ? hStaffEducateVo.EducateDate.Date : null;
                sheetView.Cells[_pointEducateName[countHStaffEducateVo].X, _pointEducateName[countHStaffEducateVo].Y].Text = hStaffEducateVo.EducateName;
                countHStaffEducateVo++;
                if (countHStaffEducateVo > 5)
                    break;
            }
            /*
             * 適正診断
             */
            Dictionary<int, Point> _pointProperKind = new Dictionary<int, Point> { { 0, new Point(65, 3) }, { 1, new Point(67, 3) }, { 2, new Point(69, 3) } };
            Dictionary<int, Point> _pointProperDate = new Dictionary<int, Point> { { 0, new Point(65, 11) }, { 1, new Point(67, 11) }, { 2, new Point(69, 11) } };
            Dictionary<int, Point> _pointProperNote = new Dictionary<int, Point> { { 0, new Point(65, 16) }, { 1, new Point(67, 16) }, { 2, new Point(69, 16) } };
            List<H_StaffProperVo> listHStaffProperVo = new();
            try {
                listHStaffProperVo = _hStaffProperDao.SelectOneHStaffProperMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffProperVo = 0;
            foreach (H_StaffProperVo hStaffProperVo in listHStaffProperVo.OrderByDescending(x => x.ProperDate)) {
                sheetView.Cells[_pointProperKind[countHStaffProperVo].X, _pointProperKind[countHStaffProperVo].Y].Text = hStaffProperVo.ProperKind;
                sheetView.Cells[_pointProperDate[countHStaffProperVo].X, _pointProperDate[countHStaffProperVo].Y].Value = hStaffProperVo.ProperDate.Date != _defaultDateTime.Date ? hStaffProperVo.ProperDate.Date : null;
                sheetView.Cells[_pointProperNote[countHStaffProperVo].X, _pointProperNote[countHStaffProperVo].Y].Text = hStaffProperVo.ProperNote;
                countHStaffProperVo++;
                if (countHStaffProperVo > 2)
                    break;
            }
            /*
             * 賞罰・譴責
             */
            Dictionary<int, Point> _pointPunishmentDate = new Dictionary<int, Point> { { 0, new Point(71, 3) }, { 1, new Point(71, 21) }, { 2, new Point(73, 3) }, { 3, new Point(73, 21) } };
            Dictionary<int, Point> _pointPunishmentNote = new Dictionary<int, Point> { { 0, new Point(71, 9) }, { 1, new Point(71, 27) }, { 2, new Point(73, 9) }, { 3, new Point(73, 27) } };
            List<H_StaffPunishmentVo> listHStaffPunishmentVo = new();
            try {
                listHStaffPunishmentVo = _hStaffPunishmentDao.SelectOneHStaffPunishmentMaster(_staffCode);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            int countHStaffPunishmentVo = 0;
            foreach (H_StaffPunishmentVo hStaffPunishmentVo in listHStaffPunishmentVo.OrderByDescending(x => x.PunishmentDate)) {
                sheetView.Cells[_pointPunishmentDate[countHStaffPunishmentVo].X, _pointPunishmentDate[countHStaffPunishmentVo].Y].Value = hStaffPunishmentVo.PunishmentDate.Date != _defaultDateTime.Date ? hStaffPunishmentVo.PunishmentDate.Date : null;
                sheetView.Cells[_pointPunishmentNote[countHStaffPunishmentVo].X, _pointPunishmentNote[countHStaffPunishmentVo].Y].Text = hStaffPunishmentVo.PunishmentNote;
                countHStaffPunishmentVo++;
                if (countHStaffPunishmentVo > 3)
                    break;
            }
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
        /// ToolStripMenuItemPrintA4_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrintA4_Click(object sender, EventArgs e) {
            PrintDocument _printDocument;
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            // 出力先プリンタを指定します。
            //printDocument.PrinterSettings.PrinterName = "(PrinterName)";
            // 印刷部数を指定します。
            _printDocument.PrinterSettings.Copies = 1;
            // 両面印刷に設定します。
            _printDocument.PrinterSettings.Duplex = Duplex.Vertical;
            // カラー印刷に設定します。
            _printDocument.PrinterSettings.DefaultPageSettings.Color = true;
            _printDocument.Print();
        }

        /// <summary>
        /// printDocument_PrintPage
        /// </summary>
        private int curPageNumber = 0; // 現在のページ番号
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            if (curPageNumber == 0) {
                // 印刷ページ（1ページ目）の描画を行う
                Rectangle rectangle = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
                // 使用するページ数を計算
                //int cnt = SpreadStaffRegisterHead.GetOwnerPrintPageCount(e.Graphics, rectangle, 0);
                // e.Graphicsへ出力
                SpreadStaffRegisterHead.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
                // 印刷継続を指定
                e.HasMorePages = true;
            } else {
                // 印刷ページ（2ページ目）の描画を行う
                Rectangle rectangle = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
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
