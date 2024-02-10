/*
 * 2024-02-07
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

namespace H_Staff {
    public partial class HStaffDetail : Form {
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private readonly H_StaffMasterVo? _hStaffMasterVo;

        /// <summary>
        /// コンストラクター（新規作成）
        /// </summary>
        /// <param name="connectionVo"></param>
        public HStaffDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            InitializeComponent();
            this.InitializeControls();
        }

        /// <summary>
        /// コンストラクター（修正登録）
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public HStaffDetail(ConnectionVo connectionVo, int staffCode) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            InitializeComponent();
            this.InitializeControls();
            this.OutPut(_hStaffMasterDao.SelectOneHStaffMasterForStaffDetail(staffCode));
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// 入力データを更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// CreateHStaffMasterVo
        /// Voを作成してUpdateする
        /// </summary>
        private void CreateHStaffMasterVo() {
            H_StaffMasterVo hStaffMasterVo = new();





        }

        /// <summary>
        /// Controlに出力する
        /// </summary>
        /// <param name="hStaffMasterVo"></param>
        private void OutPut(H_StaffMasterVo? hStaffMasterVo) {
            /*
             * Nullチェック 
             */
            if (hStaffMasterVo is null)
                return;
            /*
             * GroupBoxBelongs
             * 所属
             */
            Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };
            HCheckBoxExTargetFlag.Checked = hStaffMasterVo.VehicleDispatchTarget;
            HComboBoxExBelongs.Text = dictionaryBelongs[hStaffMasterVo.Belongs];
            /*
             * GroupBoxJobForm
             * 雇用形態
             */
            switch (hStaffMasterVo.JobForm) {
                case 10:
                    HRadioButtonExLongTarm.Checked = true;
                    break;
                case 11:
                    HRadioButtonExShortTarm.Checked = true;
                    break;
            }
            /*
             * GroupBoxExOccupation
             * 職種
             */
            switch (hStaffMasterVo.Occupation) {
                case 10:
                    HRadioButtonExDriver.Checked = true;
                    break;
                case 11:
                    HRadioButtonExOperator.Checked = true;
                    break;
                case 20:
                    HRadioButtonExOfficeWork.Checked = true;
                    break;
                case 99:
                    HRadioButtonExNone2.Checked = true;
                    break;
            }
            /*
             * HGroupBoxExPersonalData
             * 個人情報
             */
            HTextBoxExStaffCode.Text = hStaffMasterVo.StaffCode.ToString();
            HTextBoxExUnionCode.Text = hStaffMasterVo.UnionCode.ToString();
            HTextBoxExNameKana.Text = hStaffMasterVo.NameKana;
            HTextBoxExName.Text = hStaffMasterVo.Name;
            HTextBoxExDisplayName.Text = hStaffMasterVo.DisplayName;
            HDateTimeExBirthDate.SetValue(hStaffMasterVo.BirthDate);
            HDateTimeExEmploymentDate.SetValue(hStaffMasterVo.EmploymentDate);
            HComboBoxExGender.Text = hStaffMasterVo.Gender;
            HComboBoxExBloodType.Text = hStaffMasterVo.BloodType;
            HTextBoxExCurrentAddress.Text = hStaffMasterVo.CurrentAddress;
            HTextBoxExRemarks.Text = hStaffMasterVo.Remarks;
            HTextBoxExTelephoneNumber.Text = hStaffMasterVo.TelephoneNumber;
            HTextBoxExCellphoneNumber.Text = hStaffMasterVo.CellphoneNumber;
            HPictureBoxExStaff.Image = (Image?)new ImageConverter().ConvertFrom(hStaffMasterVo.Picture);
            /*
             * HGroupBoxExDrive
             * 運転に関する情報
             */
            HDateTimeExSelectionDate.SetValue(hStaffMasterVo.SelectionDate);
            HDateTimeExNotSelectionDate.SetValue(hStaffMasterVo.NotSelectionDate);
            HTextBoxExNotSelectionReason.Text = hStaffMasterVo.NotSelectionReason;
            HTextBoxExLicenseNumber.Text = hStaffMasterVo.HLicenseMasterVo.LicenseNumber;
            HComboBoxExLicenseCondition.Text = hStaffMasterVo.HLicenseMasterVo.LicenseCondition;
            string type = string.Empty;
            if (hStaffMasterVo.HLicenseMasterVo.Large)
                type += "(大型) ";
            if (hStaffMasterVo.HLicenseMasterVo.Medium)
                type += "(中型) ";
            if (hStaffMasterVo.HLicenseMasterVo.QuasiMedium)
                type += "(準中型) ";
            if (hStaffMasterVo.HLicenseMasterVo.Ordinary)
                type += "(普通)";
            HTextBoxExLicenseType.Text = type; // 免許証の種類１
            HDateTimeExLicenseTypeDate.SetValue(hStaffMasterVo.HLicenseMasterVo.DeliveryDate);
            HDateTimeExLicenseTypeExpirationDate.SetValue(hStaffMasterVo.HLicenseMasterVo.ExpirationDate);
            /*
             * HGroupBoxExHistory 
             * 職業履歴
             */
            Dictionary<int, H_DateTimePickerEx> dictionaryHistoryDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExHistoryDate1 }, { 1, HDateTimeExHistoryDate2 }, { 2, HDateTimeExHistoryDate3 } };
            Dictionary<int, H_TextBoxEx> dictionaryHistoryNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExHistoryNote1 }, { 1, HTextBoxExHistoryNote2 }, { 2, HTextBoxExHistoryNote3 } };
            HDateTimeExHistoryDate.SetBlank();
            HTextBoxExHistoryNote.Text = string.Empty;
            int countHGroupBoxExHistory = 0;
            foreach (H_StaffHistoryVo hStaffHistoryVo in hStaffMasterVo.ListHStaffHistoryVo) {
                dictionaryHistoryDate[countHGroupBoxExHistory].SetValue(hStaffHistoryVo.HistoryDate);
                dictionaryHistoryNote[countHGroupBoxExHistory].Text = hStaffHistoryVo.HistoryNote;
                countHGroupBoxExHistory++;
            }
            /*
             * HGroupBoxExExperience
             * 過去に運転経験のある自動車の種類・経験期間等
             */
            Dictionary<int, H_ComboBoxEx> dictionaryExperienceKind = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExExperienceKind1 }, { 1, HComboBoxExExperienceKind2 }, { 2, HComboBoxExExperienceKind3 } };
            Dictionary<int, H_TextBoxEx> dictionaryExperienceLoad = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExExperienceLoad1 }, { 1, HTextBoxExExperienceLoad2 }, { 2, HTextBoxExExperienceLoad3 } };
            Dictionary<int, H_TextBoxEx> dictionaryExperienceDuration = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExExperienceDuration1 }, { 1, HTextBoxExExperienceDuration2 }, { 2, HTextBoxExExperienceDuration3 } };
            Dictionary<int, H_TextBoxEx> dictionaryExperienceNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExExperienceNote1 }, { 1, HTextBoxExExperienceNote2 }, { 2, HTextBoxExExperienceNote3 } };
            HComboBoxExExperienceKind.SelectedIndex = -1;
            HTextBoxExExperienceLoad.Text = string.Empty;
            HTextBoxExExperienceDuration.Text = string.Empty;
            HTextBoxExExperienceNote.Text = string.Empty;
            int countHGroupBoxExExperience = 0;
            foreach (H_StaffExperienceVo hStaffExperienceVo in hStaffMasterVo.ListHStaffExperienceVo) {
                dictionaryExperienceKind[countHGroupBoxExExperience].Text = hStaffExperienceVo.ExperienceKind;
                dictionaryExperienceLoad[countHGroupBoxExExperience].Text = hStaffExperienceVo.ExperienceLoad;
                dictionaryExperienceDuration[countHGroupBoxExExperience].Text = hStaffExperienceVo.ExperienceDuration;
                dictionaryExperienceNote[countHGroupBoxExExperience].Text += hStaffExperienceVo.ExperienceNote;
                countHGroupBoxExExperience++;
            }
            /*
             * HGroupBoxExRetirement
             * 解雇・退職の日付と理由
             */
            HCheckBoxExRetirementFlag.Checked = hStaffMasterVo.RetirementFlag;
            HDateTimeExRetirementDate.SetValue(hStaffMasterVo.RetirementDate);
            HTextBoxExRetirementNote.Text = hStaffMasterVo.RetirementNote;
            HDateTimeExDeathDate.SetValue(hStaffMasterVo.DeathDate);
            HTextBoxExDeathNote.Text = hStaffMasterVo.DeathNote;
            /*
             * HGroupBoxExFamily
             * 家族構成
             */
            Dictionary<int, H_TextBoxEx> dictionaryFamilyName = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExFamilyName1 }, { 1, HTextBoxExFamilyName2 }, { 2, HTextBoxExFamilyName3 } };
            Dictionary<int, H_DateTimePickerEx> dictionaryFamilyBirthDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExFamilyBirthDate1 }, { 1, HDateTimeExFamilyBirthDate2 }, { 2, HDateTimeExFamilyBirthDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryFamilyRelationship = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExFamilyRelationship1 }, { 1, HComboBoxExFamilyRelationship2 }, { 2, HComboBoxExFamilyRelationship3 } };
            HTextBoxExFamilyName.Text = string.Empty;
            HDateTimeExFamilyBirthDate.SetBlank();
            HComboBoxExFamilyRelationship.SelectedIndex = -1;
            int countHGroupBoxExFamily = 0;
            foreach (H_StaffFamilyVo hStaffFamilyVo in hStaffMasterVo.ListHStaffFamilyVo) {
                dictionaryFamilyName[countHGroupBoxExFamily].Text = hStaffFamilyVo.FamilyName;
                dictionaryFamilyBirthDate[countHGroupBoxExFamily].SetValue(hStaffFamilyVo.FamilyBirthDay);
                dictionaryFamilyRelationship[countHGroupBoxExFamily].Text = hStaffFamilyVo.FamilyRelationship;
                countHGroupBoxExFamily++;
            }
            HTextBoxExUrgentTelephoneNumber.Text = hStaffMasterVo.TelephoneNumber;
            HTextBoxExUrgentTelephoneMethod.Text = hStaffMasterVo.UrgentTelephoneMethod;
            /*
             * HGroupBoxExInsurance
             * 保険関係
             */
            HDateTimeExHealthInsuranceDate.SetValue(hStaffMasterVo.HealthInsuranceDate);
            HComboBoxExHealthInsuranceNumber.Text = hStaffMasterVo.HealthInsuranceNumber;
            HTextBoxExHealthInsuranceNote.Text = hStaffMasterVo.HealthInsuranceNote;
            HDateTimeExWelfarePensionDate.SetValue(hStaffMasterVo.WelfarePensionDate);
            HComboBoxExWelfarePensionNumber.Text = hStaffMasterVo.WelfarePensionNumber;
            HTextBoxExWelfarePensionNote.Text = hStaffMasterVo.WelfarePensionNote;
            HDateTimeExEmploymentInsuranceDate.SetValue(hStaffMasterVo.EmploymentInsuranceDate);
            HComboBoxExEmploymentInsuranceNumber.Text = hStaffMasterVo.EmploymentInsuranceNumber;
            HTextBoxExEmploymentInsuranceNote.Text = hStaffMasterVo.EmploymentInsuranceNote;
            HDateTimeExWorkerAccidentInsuranceDate.SetValue(hStaffMasterVo.WorkerAccidentInsuranceDate);
            HComboBoxExWorkerAccidentInsuranceNumber.Text = hStaffMasterVo.WorkerAccidentInsuranceNumber;
            HTextBoxExWorkerAccidentInsuranceNote.Text = hStaffMasterVo.WorkerAccidentInsuranceNote;
            /*
             * HGroupBoxExMedical
             * 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
             */
            Dictionary<int, H_DateTimePickerEx> dictionaryMedicalDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExMedicalExaminationDate1 }, { 1, HDateTimeExMedicalExaminationDate2 }, { 2, HDateTimeExMedicalExaminationDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryMedicalName = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExMedicalInstitutionName1 }, { 1, HComboBoxExMedicalInstitutionName2 }, { 2, HComboBoxExMedicalInstitutionName3 } };
            Dictionary<int, H_TextBoxEx> dictionaryMedicalNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExMedicalExaminationNote1 }, { 1, HTextBoxExMedicalExaminationNote2 }, { 2, HTextBoxExMedicalExaminationNote3 } };
            HDateTimeExMedicalExaminationDate.SetBlank();
            HComboBoxExMedicalInstitutionName.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote.Text = string.Empty;
            int countHGroupBoxExMedical = 0;
            foreach (H_StaffMedicalExaminationVo hStaffMedicalExaminationVo in hStaffMasterVo.ListHStaffMedicalExaminationVo) {
                dictionaryMedicalDate[countHGroupBoxExMedical].SetValue(hStaffMedicalExaminationVo.MedicalExaminationDate);
                dictionaryMedicalName[countHGroupBoxExMedical].Text = hStaffMedicalExaminationVo.MedicalInstitutionName;
                dictionaryMedicalNote[countHGroupBoxExMedical].Text += hStaffMedicalExaminationVo.MedicalExaminationNote;
                countHGroupBoxExMedical++;
            }
            /*
             * HGroupBoxExCarViolate
             * 業務上の交通違反歴
             */
            Dictionary<int, H_DateTimePickerEx> dictionaryCarViolateDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExCarViolateDate1 }, { 1, HDateTimeExCarViolateDate2 }, { 2, HDateTimeExCarViolateDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryCarViolateContent = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExCarViolateContent1 }, { 1, HComboBoxExCarViolateContent2 }, { 2, HComboBoxExCarViolateContent3 } };
            Dictionary<int, H_TextBoxEx> dictionaryCarViolatePlace = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExCarViolatePlace1 }, { 1, HTextBoxExCarViolatePlace2 }, { 2, HTextBoxExCarViolatePlace3 } };
            HDateTimeExCarViolateDate.SetBlank();
            HComboBoxExCarViolateContent.SelectedIndex = -1;
            HTextBoxExCarViolatePlace.Text = string.Empty;
            int countHGroupBoxExCarViolate = 0;
            foreach (H_StaffCarViolateVo hStaffCarViolateVo in hStaffMasterVo.ListHStaffCarViolateVo) {
                dictionaryCarViolateDate[countHGroupBoxExCarViolate].SetValue(hStaffCarViolateVo.CarViolateDate);
                dictionaryCarViolateContent[countHGroupBoxExCarViolate].Text = hStaffCarViolateVo.CarViolateContent;
                dictionaryCarViolatePlace[countHGroupBoxExCarViolate].Text += hStaffCarViolateVo.CarViolatePlace;
                countHGroupBoxExCarViolate++;
            }
            /*
             * HGroupBoxEducate
             * 社内教育の実施記録
             */
            Dictionary<int, H_DateTimePickerEx> dictionaryEducateDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExEducateDate1 }, { 1, HDateTimeExEducateDate2 }, { 2, HDateTimeExEducateDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryEducateName = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExEducateName1 }, { 1, HComboBoxExEducateName2 }, { 2, HComboBoxExEducateName3 } };
            HDateTimeExEducateDate.SetBlank();
            HComboBoxExEducateName.SelectedIndex = -1;
            int countHGroupBoxEducate = 0;
            foreach (H_StaffEducateVo hStaffEducateVo in hStaffMasterVo.ListHStaffEducateVo) {
                dictionaryEducateDate[countHGroupBoxEducate].SetValue(hStaffEducateVo.EducateDate);
                dictionaryEducateName[countHGroupBoxEducate].Text = hStaffEducateVo.EducateName;
                countHGroupBoxEducate++;
            }
            /*
             * HGroupBoxProper
             * 適正診断(NASVA他)
             */
            Dictionary<int, H_ComboBoxEx> dictionaryProperKind = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExProperKind1 }, { 1, HComboBoxExProperKind2 }, { 2, HComboBoxExProperKind3 } };
            Dictionary<int, H_DateTimePickerEx> dictionaryProperDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExProperDate1 }, { 1, HDateTimeExProperDate2 }, { 2, HDateTimeExProperDate3 } };
            Dictionary<int, H_TextBoxEx> dictionaryProperNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExProperNote1 }, { 1, HTextBoxExProperNote2 }, { 2, HTextBoxExProperNote3 } };
            HComboBoxExProperKind.SelectedIndex = -1;
            HDateTimeExProperDate.SetBlank();
            HTextBoxExProperNote.Text = string.Empty;
            int countHGroupBoxProper = 0;
            foreach (H_StaffProperVo hStaffProperVo in hStaffMasterVo.ListHStaffProperVo) {
                dictionaryProperKind[countHGroupBoxProper].Text = hStaffProperVo.ProperKind;
                dictionaryProperDate[countHGroupBoxProper].SetValue(hStaffProperVo.ProperDate);
                dictionaryProperNote[countHGroupBoxProper].Text = hStaffProperVo.ProperNote;
                countHGroupBoxProper++;
            }
            /*
             * HGroupBoxExPunishment
             * 賞罰・譴責
             */
            Dictionary<int, H_DateTimePickerEx> dictionaryPunishmentDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExPunishmentDate1 }, { 1, HDateTimeExPunishmentDate2 }, { 2, HDateTimeExPunishmentDate3 } };
            Dictionary<int, H_TextBoxEx> dictionaryPunishmentNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExPunishmentNote1 }, { 1, HTextBoxExPunishmentNote2 }, { 2, HTextBoxExPunishmentNote3 } };
            HDateTimeExPunishmentDate.SetBlank();
            HTextBoxExPunishmentNote.Text = string.Empty;
            int countHGroupBoxExPunishment = 0;
            foreach (H_StaffPunishmentVo hStaffPunishmentVo in hStaffMasterVo.ListHStaffPunishmentVo) {
                dictionaryPunishmentDate[countHGroupBoxExPunishment].SetValue(hStaffPunishmentVo.PunishmentDate);
                dictionaryPunishmentNote[countHGroupBoxExPunishment].Text = hStaffPunishmentVo.PunishmentNote;
                countHGroupBoxExPunishment++;
            }
        }

        /// <summary>
        /// Controlを初期化する
        /// </summary>
        public void InitializeControls() {
            this.Size = new Size(1920, 1080);
            /*
             * GroupBoxBelongs
             * 所属
             */
            HCheckBoxExTargetFlag.Checked = false;
            HComboBoxExBelongs.SelectedIndex = -1;
            /*
             * GroupBoxJobForm
             * 雇用形態
             */
            HRadioButtonExLongTarm.Checked = false;
            HRadioButtonExShortTarm.Checked = false;
            /*
             * GroupBoxExOccupation
             * 職種
             */
            HRadioButtonExOfficeWork.Checked = false;
            HRadioButtonExDriver.Checked = false;
            HRadioButtonExOperator.Checked = false;
            HRadioButtonExNone2.Checked = false;
            /*
             * HGroupBoxExPersonalData
             * 個人情報
             */
            HTextBoxExStaffCode.Text = string.Empty;
            HTextBoxExUnionCode.Text = string.Empty;
            HTextBoxExNameKana.Text = string.Empty;
            HTextBoxExName.Text = string.Empty;
            HTextBoxExDisplayName.Text = string.Empty;
            HDateTimeExBirthDate.SetBlank();
            HDateTimeExEmploymentDate.SetBlank();
            HComboBoxExGender.SelectedIndex = -1;
            HComboBoxExBloodType.SelectedIndex = -1;
            HTextBoxExCurrentAddress.Text = string.Empty;
            HTextBoxExRemarks.Text = string.Empty;
            HTextBoxExTelephoneNumber.Text = string.Empty;
            HTextBoxExCellphoneNumber.Text = string.Empty;
            /*
             * HGroupBoxExDrive
             * 運転に関する情報
             */
            HDateTimeExSelectionDate.SetBlank();
            HDateTimeExNotSelectionDate.SetBlank();
            HTextBoxExNotSelectionReason.Text = string.Empty;
            HTextBoxExLicenseNumber.Text = string.Empty;
            HComboBoxExLicenseCondition.Text = string.Empty;
            HTextBoxExLicenseType.Text = string.Empty;
            HDateTimeExLicenseTypeDate.SetBlank();
            HDateTimeExLicenseTypeExpirationDate.SetBlank();
            /*
             * HGroupBoxExHistory
             * 職業履歴
             */
            HDateTimeExHistoryDate.SetBlank();
            HTextBoxExHistoryNote.Text = string.Empty;
            HDateTimeExHistoryDate1.SetBlank();
            HTextBoxExHistoryNote1.Text = string.Empty;
            HDateTimeExHistoryDate2.SetBlank();
            HTextBoxExHistoryNote2.Text = string.Empty;
            HDateTimeExHistoryDate3.SetBlank();
            HTextBoxExHistoryNote3.Text = string.Empty;
            /*
             * HGroupBoxExExperience
             * 過去に運転経験のある自動車の種類・経験期間等
             */
            HComboBoxExExperienceKind.SelectedIndex = -1;
            HTextBoxExExperienceLoad.Text = string.Empty;
            HTextBoxExExperienceDuration.Text = string.Empty;
            HTextBoxExExperienceNote.Text = string.Empty;
            HComboBoxExExperienceKind1.SelectedIndex = -1;
            HTextBoxExExperienceLoad1.Text = string.Empty;
            HTextBoxExExperienceDuration1.Text = string.Empty;
            HTextBoxExExperienceNote1.Text = string.Empty;
            HComboBoxExExperienceKind2.SelectedIndex = -1;
            HTextBoxExExperienceLoad2.Text = string.Empty;
            HTextBoxExExperienceDuration2.Text = string.Empty;
            HTextBoxExExperienceNote2.Text = string.Empty;
            HComboBoxExExperienceKind3.SelectedIndex = -1;
            HTextBoxExExperienceLoad3.Text = string.Empty;
            HTextBoxExExperienceDuration3.Text = string.Empty;
            HTextBoxExExperienceNote3.Text = string.Empty;
            /*
             * HGroupBoxExRetirement
             * 解雇・退職の日付と理由
             */
            HCheckBoxExRetirementFlag.Checked = false;
            HDateTimeExRetirementDate.SetBlank();
            HTextBoxExRetirementNote.Text = string.Empty;
            HDateTimeExDeathDate.SetBlank();
            HTextBoxExDeathNote.Text = string.Empty;
            /*
             * HGroupBoxExFamily
             * 家族構成
             */
            HTextBoxExFamilyName.Text = string.Empty;
            HDateTimeExFamilyBirthDate.SetBlank();
            HComboBoxExFamilyRelationship.SelectedIndex = -1;
            HTextBoxExFamilyName1.Text = string.Empty;
            HDateTimeExFamilyBirthDate1.SetBlank();
            HComboBoxExFamilyRelationship1.SelectedIndex = -1;
            HTextBoxExFamilyName2.Text = string.Empty;
            HDateTimeExFamilyBirthDate2.SetBlank();
            HComboBoxExFamilyRelationship2.SelectedIndex = -1;
            HTextBoxExFamilyName3.Text = string.Empty;
            HDateTimeExFamilyBirthDate3.SetBlank();
            HComboBoxExFamilyRelationship3.SelectedIndex = -1;
            HTextBoxExFamilyName4.Text = string.Empty;
            HDateTimeExFamilyBirthDate4.SetBlank();
            HComboBoxExFamilyRelationship4.SelectedIndex = -1;
            HTextBoxExUrgentTelephoneNumber.Text = string.Empty;
            HTextBoxExUrgentTelephoneMethod.Text = string.Empty;
            /*
             * HGroupBoxExInsurance
             * 保険関係
             */
            HDateTimeExHealthInsuranceDate.SetBlank();
            HComboBoxExHealthInsuranceNumber.SelectedIndex = -1;
            HTextBoxExHealthInsuranceNote.Text = string.Empty;
            HDateTimeExWelfarePensionDate.SetBlank();
            HComboBoxExWelfarePensionNumber.SelectedIndex = -1;
            HTextBoxExWelfarePensionNote.Text = string.Empty;
            HDateTimeExEmploymentInsuranceDate.SetBlank();
            HComboBoxExEmploymentInsuranceNumber.Text = string.Empty;
            HTextBoxExEmploymentInsuranceNote.Text = string.Empty;
            HDateTimeExWorkerAccidentInsuranceDate.SetBlank();
            HComboBoxExWorkerAccidentInsuranceNumber.SelectedIndex = -1;
            HTextBoxExWorkerAccidentInsuranceNote.Text = string.Empty;
            /*
             * HGroupBoxExMedicalExamination
             * 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
             */
            HDateTimeExMedicalExaminationDate.SetBlank();
            HComboBoxExMedicalInstitutionName.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote.Text = string.Empty;
            HDateTimeExMedicalExaminationDate1.SetBlank();
            HComboBoxExMedicalInstitutionName1.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote1.Text = string.Empty;
            HDateTimeExMedicalExaminationDate2.SetBlank();
            HComboBoxExMedicalInstitutionName2.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote2.Text = string.Empty;
            HDateTimeExMedicalExaminationDate3.SetBlank();
            HComboBoxExMedicalInstitutionName3.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote3.Text = string.Empty;
            /*
             * HGroupBoxExCarViolate
             * 業務上の交通違反歴
             */
            HDateTimeExCarViolateDate.SetBlank();
            HComboBoxExCarViolateContent.SelectedIndex = -1;
            HTextBoxExCarViolatePlace.Text = string.Empty;
            HDateTimeExCarViolateDate1.SetBlank();
            HComboBoxExCarViolateContent1.SelectedIndex = -1;
            HTextBoxExCarViolatePlace1.Text = string.Empty;
            HDateTimeExCarViolateDate2.SetBlank();
            HComboBoxExCarViolateContent2.SelectedIndex = -1;
            HTextBoxExCarViolatePlace2.Text = string.Empty;
            HDateTimeExCarViolateDate3.SetBlank();
            HComboBoxExCarViolateContent3.SelectedIndex = -1;
            HTextBoxExCarViolatePlace3.Text = string.Empty;
            /*
             * HGroupBoxEducate
             * 社内教育の実施記録
             */
            HDateTimeExEducateDate.SetBlank();
            HComboBoxExEducateName.SelectedIndex = -1;
            HDateTimeExEducateDate1.SetBlank();
            HComboBoxExEducateName1.SelectedIndex = -1;
            HDateTimeExEducateDate2.SetBlank();
            HComboBoxExEducateName2.SelectedIndex = -1;
            HDateTimeExEducateDate3.SetBlank();
            HComboBoxExEducateName3.SelectedIndex = -1;
            /*
             * HGroupBoxProper
             * 適正診断(NASVA他)
             */
            HComboBoxExProperKind.SelectedIndex = -1;
            HDateTimeExProperDate.SetBlank();
            HTextBoxExProperNote.Text = string.Empty;
            HComboBoxExProperKind1.SelectedIndex = -1;
            HDateTimeExProperDate1.SetBlank();
            HTextBoxExProperNote1.Text = string.Empty;
            HComboBoxExProperKind2.SelectedIndex = -1;
            HDateTimeExProperDate2.SetBlank();
            HTextBoxExProperNote2.Text = string.Empty;
            HComboBoxExProperKind3.SelectedIndex = -1;
            HDateTimeExProperDate3.SetBlank();
            HTextBoxExProperNote3.Text = string.Empty;
            /*
             * HGroupBoxExPunishment
             * 賞罰・譴責
             */
            HDateTimeExPunishmentDate.SetBlank();
            HTextBoxExPunishmentNote.Text = string.Empty;
            HDateTimeExPunishmentDate1.SetBlank();
            HTextBoxExPunishmentNote1.Text = string.Empty;
            HDateTimeExPunishmentDate2.SetBlank();
            HTextBoxExPunishmentNote2.Text = string.Empty;
            HDateTimeExPunishmentDate3.SetBlank();
            HTextBoxExPunishmentNote3.Text = string.Empty;
        }

        /// <summary>
        /// HComboBoxExBelongs_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HComboBoxExBelongs_SelectedIndexChanged(object sender, EventArgs e) {
            switch (((H_ComboBoxEx)sender).Text) {
                case "役員":
                case "社員":
                    HRadioButtonExLongTarm.Enabled = false;
                    HRadioButtonExShortTarm.Enabled = false;
                    HRadioButtonExOfficeWork.Enabled = true;
                    HRadioButtonExDriver.Enabled = true;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = true;
                    break;
                case "アルバイト":
                    HRadioButtonExLongTarm.Enabled = false;
                    HRadioButtonExShortTarm.Enabled = false;
                    HRadioButtonExOfficeWork.Enabled = false;
                    HRadioButtonExDriver.Enabled = true;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = false;
                    break;
                case "派遣":
                    HRadioButtonExLongTarm.Enabled = false;
                    HRadioButtonExShortTarm.Enabled = false;
                    HRadioButtonExOfficeWork.Enabled = false;
                    HRadioButtonExDriver.Enabled = false;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = false;
                    break;
                case "新運転":
                case "自運労":
                    HRadioButtonExLongTarm.Enabled = true;
                    HRadioButtonExShortTarm.Enabled = true;
                    HRadioButtonExOfficeWork.Enabled = false;
                    HRadioButtonExDriver.Enabled = true;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCheckBoxExRetirementFlag_Click(object sender, EventArgs e) {
            HDateTimeExRetirementDate.Enabled = ((H_CheckBoxEx)sender).Checked;
        }
    }
}
