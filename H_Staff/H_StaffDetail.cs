/*
 * 2024-02-07
 */
using H_Vo;

namespace H_Staff {
    public partial class HStaffDetail : Form {
        /*
         * Dao
         */

        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター（新規作成）
        /// </summary>
        /// <param name="connectionVo"></param>
        public HStaffDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */

            /*
             * Vo
             */
            _connectionVo = connectionVo;

            InitializeComponent();
            this.InitializeControls();
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
            HRadioButtonExOfficer.Checked = false;
            HRadioButtonExEmployee1.Checked = false;
            HRadioButtonExPart1.Checked = false;
            HRadioButtonExDispatch.Checked = false;
            HRadioButtonExSinunten.Checked = false;
            HRadioButtonExJiunrou.Checked = false;
            /*
             * GroupBoxJobForm
             * 雇用形態
             */
            HRadioButtonExEmployee2.Checked = false;
            HRadioButtonExLongTarm.Checked = false;
            HRadioButtonExShortTarm.Checked = false;
            HRadioButtonExPart2.Checked = false;
            HRadioButtonExNone1.Checked = false;
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
            HComboBoxExMedicalExaminationNote.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote.Text = string.Empty;
            HDateTimeExMedicalExaminationDate1.SetBlank();
            HComboBoxExMedicalExaminationNote1.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote1.Text = string.Empty;
            HDateTimeExMedicalExaminationDate2.SetBlank();
            HComboBoxExMedicalExaminationNote2.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote2.Text = string.Empty;
            HDateTimeExMedicalExaminationDate3.SetBlank();
            HComboBoxExMedicalExaminationNote3.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote3.Text = string.Empty;
            HDateTimeExMedicalExaminationDate4.SetBlank();
            HComboBoxExMedicalExaminationNote4.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote4.Text = string.Empty;
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
            HDateTimeExCarViolateDate4.SetBlank();
            HComboBoxExCarViolateContent4.SelectedIndex = -1;
            HTextBoxExCarViolatePlace4.Text = string.Empty;
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
            HDateTimeExEducateDate4.SetBlank();
            HComboBoxExEducateName4.SelectedIndex = -1;
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
            HComboBoxExProperKind4.SelectedIndex = -1;
            HDateTimeExProperDate4.SetBlank();
            HTextBoxExProperNote4.Text = string.Empty;
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
            HDateTimeExPunishmentDate4.SetBlank();
            HTextBoxExPunishmentNote4.Text = string.Empty;
        }
    }
}
