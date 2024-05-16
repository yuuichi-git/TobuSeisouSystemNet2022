/*
 * 2024-02-07
 */
using H_ControlEx;

using H_Dao;

using Vo;

namespace H_Staff {
    public partial class HStaffDetail : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        // ErrorProviderのインスタンスを生成
        readonly ErrorProvider _errorProvider = new();
        /// <summary>
        /// StaffCode
        /// </summary>
        private int _staffCode;
        /// <summary>
        /// true:新規 false:修正
        /// </summary>
        private bool _modeFlag;
        /// <summary>
        /// true:項目が更新されている false:項目は更新されていない
        /// </summary>
        private bool _updateFlag;
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
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター（新規作成）
        /// </summary>
        /// <param name="connectionVo"></param>
        public HStaffDetail(ConnectionVo connectionVo) {
            // 新規モードで初期化
            _modeFlag = true;
            // update情報なしで初期化
            _updateFlag = false;
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
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            InitializeComponent();
            // 新規従事者コードを採番
            HTextBoxExStaffCode.Text = (_hStaffMasterDao.GetStaffCode(24000) + 1).ToString("#####");
            // アイコンを常に点滅に設定する
            _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            this.InitializeControls();
        }

        /// <summary>
        /// コンストラクター（修正登録）
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public HStaffDetail(ConnectionVo connectionVo, int staffCode) {
            // 修正モード
            _modeFlag = false;
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
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            // StaffCode
            _staffCode = staffCode;
            InitializeComponent();
            // 従事者コード
            HTextBoxExStaffCode.Text = _staffCode.ToString();
            // アイコンを常に点滅に設定する
            _errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            this.InitializeControls();
            try {
                this.SetControl(_hStaffMasterDao.SelectOneHStaffMaster(staffCode));
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// SetVo
        /// Voを作成してUpdateする
        /// </summary>
        private H_StaffMasterVo SetVo() {
            H_StaffMasterVo hStaffMasterVo = new();
            /*
             * GroupBoxBelongs
             * 所属
             */
            Dictionary<string, int> dictionaryBelongs = new Dictionary<string, int> { { "役員", 10 }, { "社員", 11 }, { "アルバイト", 12 }, { "派遣", 13 }, { "新運転", 20 }, { "自運労", 21 } };
            hStaffMasterVo.VehicleDispatchTarget = HCheckBoxExTargetFlag.Checked;
            hStaffMasterVo.Belongs = dictionaryBelongs[HComboBoxExBelongs.Text];
            /*
             * GroupBoxJobForm
             * 雇用形態
             */
            Dictionary<string, int> dictionaryJobForm = new Dictionary<string, int> { { "長期", 10 }, { "短期", 11 }, { "指定なし", 99 } };
            foreach (Control control in GroupBoxJobForm.Controls) {
                H_RadioButtonEx hRadioButtonEx = (H_RadioButtonEx)control;
                if (hRadioButtonEx.Checked)
                    hStaffMasterVo.JobForm = dictionaryJobForm[hRadioButtonEx.Text];
            }
            /*
             * GroupBoxExOccupation
             * 職種
             */
            Dictionary<string, int> dictionaryOccupation = new Dictionary<string, int> { { "事務職", 20 }, { "運転手", 10 }, { "作業員", 11 }, { "指定なし", 99 } };
            foreach (Control control in GroupBoxExOccupation.Controls) {
                H_RadioButtonEx hRadioButtonEx = (H_RadioButtonEx)control;
                if (hRadioButtonEx.Checked)
                    hStaffMasterVo.Occupation = dictionaryOccupation[hRadioButtonEx.Text];
            }
            /*
             * HGroupBoxExPersonalData
             * 個人情報
             */
            int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
            hStaffMasterVo.StaffCode = _staffCode;
            int.TryParse(HTextBoxExUnionCode.Text, out int _unionCode); // 組合コード
            hStaffMasterVo.UnionCode = _unionCode;
            hStaffMasterVo.NameKana = HTextBoxExNameKana.Text; // カナ
            hStaffMasterVo.Name = HTextBoxExName.Text; // 氏名
            hStaffMasterVo.DisplayName = HTextBoxExDisplayName.Text; // 氏名
            hStaffMasterVo.OtherNameKana = HTextBoxExOtherNameKana.Text; // カナ(健康診断用)
            hStaffMasterVo.OtherName = HTextBoxExOtherName.Text; // 氏名(健康診断用)
            hStaffMasterVo.BirthDate = HDateTimeExBirthDate.GetValue(); // 生年月日
            hStaffMasterVo.EmploymentDate = HDateTimeExEmploymentDate.GetValue(); // 雇用年月日
            hStaffMasterVo.ContractFlag = HCheckBoxExContractFlag.Checked;
            hStaffMasterVo.ContractDate = HCheckBoxExContractFlag.Checked ? HDateTimePickerExContractDate.GetValue() : _defaultDateTime;
            hStaffMasterVo.Gender = HComboBoxExGender.Text; // 性別
            hStaffMasterVo.BloodType = HComboBoxExBloodType.Text; // 血液型
            hStaffMasterVo.CurrentAddress = HTextBoxExCurrentAddress.Text; // 現住所
            hStaffMasterVo.Remarks = HTextBoxExRemarks.Text; // その他備考
            hStaffMasterVo.TelephoneNumber = HTextBoxExTelephoneNumber.Text; // 電話番号
            hStaffMasterVo.CellphoneNumber = HTextBoxExCellphoneNumber.Text; // 携帯電話番号
            hStaffMasterVo.Picture = (byte[]?)new ImageConverter().ConvertTo(HPictureBoxExStaff.Image, typeof(byte[])); // 写真
            /*
             * HGroupBoxExDrive
             * 運転に関する情報
             */
            hStaffMasterVo.SelectionDate = HDateTimeExSelectionDate.GetValue(); // 運転手として選任された日
            hStaffMasterVo.NotSelectionDate = HDateTimeExNotSelectionDate.GetValue(); // 運転手として選任されなくなった日
            hStaffMasterVo.NotSelectionReason = HTextBoxExNotSelectionReason.Text; // 選任されなくなった理由
            /*
             * HGroupBoxExRetirement
             * 解雇・退職の日付と理由
             */
            hStaffMasterVo.RetirementFlag = HCheckBoxExRetirementFlag.Checked; // 退職フラグ
            hStaffMasterVo.RetirementDate = HDateTimeExRetirementDate.GetValue(); // 退職日
            hStaffMasterVo.RetirementNote = HTextBoxExRetirementNote.Text; // 退職理由
            hStaffMasterVo.DeathDate = HDateTimeExDeathDate.GetValue(); // 死亡日
            hStaffMasterVo.DeathNote = HTextBoxExDeathNote.Text; // 死亡理由
            /*
             * HGroupBoxExFamily
             * 家族構成
             */
            hStaffMasterVo.UrgentTelephoneNumber = HTextBoxExUrgentTelephoneNumber.Text; // 緊急連絡先
            hStaffMasterVo.UrgentTelephoneMethod = HTextBoxExUrgentTelephoneMethod.Text; // 緊急連絡方法
            /*
             * HGroupBoxExInsurance
             * 保険関係
             */
            hStaffMasterVo.HealthInsuranceDate = HDateTimeExHealthInsuranceDate.GetValue(); // 健康保険加入日
            hStaffMasterVo.HealthInsuranceNumber = HComboBoxExHealthInsuranceNumber.Text; // 健康保険番号
            hStaffMasterVo.HealthInsuranceNote = HTextBoxExHealthInsuranceNote.Text; // 健康保険備考
            hStaffMasterVo.WelfarePensionDate = HDateTimeExWelfarePensionDate.GetValue(); // 年金保険加入日
            hStaffMasterVo.WelfarePensionNumber = HComboBoxExWelfarePensionNumber.Text; // 年金保険番号
            hStaffMasterVo.WelfarePensionNote = HTextBoxExWelfarePensionNote.Text; // 年金保険備考
            hStaffMasterVo.EmploymentInsuranceDate = HDateTimeExEmploymentInsuranceDate.GetValue(); // 雇用保険加入日
            hStaffMasterVo.EmploymentInsuranceNumber = HComboBoxExEmploymentInsuranceNumber.Text; // 雇用保険番号
            hStaffMasterVo.EmploymentInsuranceNote = HTextBoxExEmploymentInsuranceNote.Text; // 雇用保険備考
            hStaffMasterVo.WorkerAccidentInsuranceDate = HDateTimeExWorkerAccidentInsuranceDate.GetValue(); // 労災保険加入日
            hStaffMasterVo.WorkerAccidentInsuranceNumber = HComboBoxExWorkerAccidentInsuranceNumber.Text; // 労災保険番号
            hStaffMasterVo.WorkerAccidentInsuranceNote = HTextBoxExWorkerAccidentInsuranceNote.Text; // 労災保険備考

            return hStaffMasterVo;
        }

        /// <summary>
        /// Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e) {
            switch (((Button)sender).Name) {
                /*
                 * INSERT/UPDATE
                 */
                case "ButtonUpdate":
                    try {
                        int.TryParse(HTextBoxExStaffCode.Text, out int staffCode);
                        if (_hStaffMasterDao.ExistenceHStaffMaster(staffCode)) {
                            // UPDATE
                            _hStaffMasterDao.UpdateOneHStaffMaster(SetVo());
                            _updateFlag = false;
                            this.Close();
                        } else {
                            // INSERT
                            _hStaffMasterDao.InsertOneHStaffMaster(SetVo());
                            _updateFlag = false;
                            this.Close();
                        }
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "AddHGroupBoxExHistory": // 職業履歴
                    try {
                        // 更新
                        H_StaffHistoryVo hStaffHistoryVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffHistoryVo.StaffCode = _staffCode;
                        hStaffHistoryVo.HistoryDate = HDateTimeExHistoryDate.GetValue();
                        hStaffHistoryVo.CompanyName = HTextBoxExCompanyName.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExHistoryDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExHistoryDate, "入社日");
                            break;
                        } else if (HTextBoxExCompanyName.Text.Length == 0) {
                            _errorProvider.SetError(HTextBoxExCompanyName, "在籍記録");
                            break;
                        }
                        _hStaffHistoryDao.InsertOneHStaffHistoryMaster(hStaffHistoryVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExHistoryを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HDateTimeExHistoryDate.SetBlank();
                        HTextBoxExCompanyName.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxExHistory(_hStaffHistoryDao.SelectOneHStaffHistoryMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
                case "AddHGroupBoxExExperience": // 過去に運転経験のある自動車の種類・経験期間等
                    try {
                        // 更新
                        H_StaffExperienceVo hStaffExperienceVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffExperienceVo.StaffCode = _staffCode;
                        hStaffExperienceVo.ExperienceKind = HComboBoxExExperienceKind.Text;
                        hStaffExperienceVo.ExperienceLoad = HTextBoxExExperienceLoad.Text;
                        hStaffExperienceVo.ExperienceDuration = HTextBoxExExperienceDuration.Text;
                        hStaffExperienceVo.ExperienceNote = HTextBoxExExperienceNote.Text;
                        /*
                         * Validation
                         */
                        if (HComboBoxExExperienceKind.Text.Length == 0) {
                            _errorProvider.SetError(HComboBoxExExperienceKind, "過去に運転経験のある自動車の種類");
                            break;
                        } else if (HTextBoxExExperienceLoad.Text.Length == 0) {
                            _errorProvider.SetError(HTextBoxExExperienceLoad, "過去に運転経験のある自動車の積載量");
                            break;
                        } else if (HTextBoxExExperienceDuration.Text.Length == 0) {
                            _errorProvider.SetError(HTextBoxExExperienceDuration, "過去に運転経験のある自動車の経験期間");
                            break;
                        }
                        _hStaffExperienceDao.InsertOneHStaffExperienceMaster(hStaffExperienceVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExExperienceを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HComboBoxExExperienceKind.Text = string.Empty;
                        HTextBoxExExperienceLoad.Text = string.Empty;
                        HTextBoxExExperienceDuration.Text = string.Empty;
                        HTextBoxExExperienceNote.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxExExperience(_hStaffExperienceDao.SelectOneHStaffExperienceMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
                case "AddHGroupBoxExFamily": // 家族構成
                    try {
                        // 更新
                        H_StaffFamilyVo hStaffFamilyVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffFamilyVo.StaffCode = _staffCode;
                        hStaffFamilyVo.FamilyName = HTextBoxExFamilyName.Text;
                        hStaffFamilyVo.FamilyBirthDay = HDateTimeExFamilyBirthDate.GetValue();
                        hStaffFamilyVo.FamilyRelationship = HComboBoxExFamilyRelationship.Text;
                        /*
                         * Validation
                         */
                        if (HTextBoxExFamilyName.Text.Length == 0) {
                            _errorProvider.SetError(HTextBoxExFamilyName, "家族氏名");
                            break;
                        } else if (HDateTimeExFamilyBirthDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExFamilyBirthDate, "生年月日");
                            break;
                        } else if (HComboBoxExFamilyRelationship.Text.Length == 0) {
                            _errorProvider.SetError(HComboBoxExFamilyRelationship, "従業員との関係");
                            break;
                        }
                        _hStaffFamilyDao.InsertOneHStaffFamilyMaster(hStaffFamilyVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExFamilyを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HTextBoxExFamilyName.Text = string.Empty;
                        HDateTimeExFamilyBirthDate.SetBlank();
                        HComboBoxExFamilyRelationship.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxExFamily(_hStaffFamilyDao.SelectOneHStaffFamilyMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
                case "AddHGroupBoxExMedical": // 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
                    try {
                        // 更新
                        H_StaffMedicalExaminationVo hStaffMedicalExaminationVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffMedicalExaminationVo.StaffCode = _staffCode;
                        hStaffMedicalExaminationVo.MedicalExaminationDate = HDateTimeExMedicalExaminationDate.GetValue();
                        hStaffMedicalExaminationVo.MedicalInstitutionName = HComboBoxExMedicalInstitutionName.Text;
                        hStaffMedicalExaminationVo.MedicalExaminationNote = HTextBoxExMedicalExaminationNote.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExMedicalExaminationDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExMedicalExaminationDate, "健診実施日");
                            break;
                        } else if (HComboBoxExMedicalInstitutionName.Text.Length == 0) {
                            _errorProvider.SetError(HComboBoxExMedicalInstitutionName, "受診機関名");
                            break;
                        }
                        _hStaffMedicalExaminationDao.InsertOneHStaffMedicalExaminationMaster(hStaffMedicalExaminationVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExMedicalを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HDateTimeExMedicalExaminationDate.SetBlank();
                        HComboBoxExMedicalInstitutionName.Text = string.Empty;
                        HTextBoxExMedicalExaminationNote.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxExMedical(_hStaffMedicalExaminationDao.SelectOneHStaffMedicalExaminationMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
                case "AddHGroupBoxExCarViolate": // 業務上の交通違反歴
                    try {
                        // 更新
                        H_StaffCarViolateVo hStaffCarViolateVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffCarViolateVo.StaffCode = _staffCode;
                        hStaffCarViolateVo.CarViolateDate = HDateTimeExCarViolateDate.GetValue();
                        hStaffCarViolateVo.CarViolateContent = HComboBoxExCarViolateContent.Text;
                        hStaffCarViolateVo.CarViolatePlace = HTextBoxExCarViolatePlace.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExCarViolateDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExCarViolateDate, "違反年月日");
                            break;
                        } else if (HComboBoxExCarViolateContent.Text.Length == 0) {
                            _errorProvider.SetError(HComboBoxExCarViolateContent, "違反名");
                            break;
                        }
                        _hStaffCarViolateDao.InsertOneHStaffCarViolateMaster(hStaffCarViolateVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExCarViolateを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HDateTimeExCarViolateDate.SetBlank();
                        HComboBoxExCarViolateContent.Text = string.Empty;
                        HTextBoxExCarViolatePlace.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxExCarViolate(_hStaffCarViolateDao.SelectOneHStaffCarViolateMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
                case "AddHGroupBoxEducate": // 社内教育の実施記録    
                    try {
                        // 更新
                        H_StaffEducateVo hStaffEducateVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffEducateVo.StaffCode = _staffCode;
                        hStaffEducateVo.EducateDate = HDateTimeExEducateDate.GetValue();
                        hStaffEducateVo.EducateName = HComboBoxExEducateName.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExEducateDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExEducateDate, "教育を受けた年月日");
                            break;
                        } else if (HComboBoxExEducateName.Text.Length == 0) {
                            _errorProvider.SetError(HComboBoxExEducateName, "教育名称");
                            break;
                        }
                        _hStaffEducateDao.InsertOneHStaffEducateMaster(hStaffEducateVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxEducateを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HDateTimeExEducateDate.SetBlank();
                        HComboBoxExEducateName.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxEducate(_hStaffEducateDao.SelectOneHStaffEducateMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
                case "AddHGroupBoxProper": // 適正診断(NASVA他)
                    try {
                        // 更新
                        H_StaffProperVo hStaffProperVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffProperVo.StaffCode = _staffCode;
                        hStaffProperVo.ProperKind = HComboBoxExProperKind.Text;
                        hStaffProperVo.ProperDate = HDateTimeExProperDate.GetValue();
                        hStaffProperVo.ProperNote = HTextBoxExProperNote.Text;
                        /*
                        * Validation
                        */
                        if (HComboBoxExProperKind.Text.Length == 0) {
                            _errorProvider.SetError(HComboBoxExProperKind, "診断の種類");
                            break;
                        } else if (HDateTimeExProperDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExProperDate, "診断年月日");
                            break;
                        } else if (HTextBoxExProperNote.Text.Length == 0) {
                            _errorProvider.SetError(HTextBoxExProperNote, "");
                            break;
                        }
                        _hStaffProperDao.InsertOneHStaffProperMaster(hStaffProperVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxProperを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HComboBoxExProperKind.Text = string.Empty;
                        HDateTimeExProperDate.SetBlank();
                        HTextBoxExProperNote.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxProper(_hStaffProperDao.SelectOneHStaffProperMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;

                case "AddHGroupBoxExPunishment": // 賞罰・譴責
                    try {
                        // 更新
                        H_StaffPunishmentVo hStaffPunishmentVo = new();
                        int.TryParse(HTextBoxExStaffCode.Text, out int _staffCode); // StaffCode
                        hStaffPunishmentVo.StaffCode = _staffCode;
                        hStaffPunishmentVo.PunishmentDate = HDateTimeExPunishmentDate.GetValue();
                        hStaffPunishmentVo.PunishmentNote = HTextBoxExPunishmentNote.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExPunishmentDate.GetValue().Date == _defaultDateTime.Date) {
                            _errorProvider.SetError(HDateTimeExPunishmentDate, "年月日");
                            break;
                        } else if (HTextBoxExPunishmentNote.Text.Length == 0) {
                            _errorProvider.SetError(HTextBoxExPunishmentNote, "備考");
                            break;
                        }
                        _hStaffPunishmentDao.InsertOneHStaffPunishmentMasters(hStaffPunishmentVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExPunishmentを更新しました。";
                        /*
                         * 更新後の初期化
                         */
                        _errorProvider.Clear();
                        HDateTimeExPunishmentDate.SetBlank();
                        HTextBoxExPunishmentNote.Text = string.Empty;
                        // 再表示
                        this.ScreenOutputHGroupBoxExPunishment(_hStaffPunishmentDao.SelectOneHStaffPunishmentMaster(_staffCode));
                        _updateFlag = true;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                        _updateFlag = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * Picture クリップボード
                 */
                case "ToolStripMenuItemPictureClipCopy":
                    HPictureBoxExStaff.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                /*
                 * Picture 削除
                 */
                case "ToolStripMenuItemPictureDelete":
                    HPictureBoxExStaff.Image = null;
                    break;
                /*
                 * アプリケーションを終了する
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Controlに出力する
        /// </summary>
        /// <param name="hStaffMasterVo"></param>
        private void SetControl(H_StaffMasterVo? hStaffMasterVo) {
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
                case 99:
                    HRadioButtonExNone1.Checked = true;
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
            HTextBoxExOtherNameKana.Text = hStaffMasterVo.OtherNameKana;
            HTextBoxExOtherName.Text = hStaffMasterVo.OtherName;
            HDateTimeExBirthDate.SetValueJp(hStaffMasterVo.BirthDate);
            HDateTimeExEmploymentDate.SetValueJp(hStaffMasterVo.EmploymentDate);
            HCheckBoxExContractFlag.Checked = hStaffMasterVo.ContractFlag;
            HDateTimePickerExContractDate.SetValue(hStaffMasterVo.ContractDate);
            HComboBoxExGender.Text = hStaffMasterVo.Gender;
            HComboBoxExBloodType.Text = hStaffMasterVo.BloodType;
            HTextBoxExCurrentAddress.Text = hStaffMasterVo.CurrentAddress;
            HTextBoxExRemarks.Text = hStaffMasterVo.Remarks;
            HTextBoxExTelephoneNumber.Text = hStaffMasterVo.TelephoneNumber;
            HTextBoxExCellphoneNumber.Text = hStaffMasterVo.CellphoneNumber;
            HPictureBoxExStaff.Image = hStaffMasterVo.Picture.Length != 0 ? (Image?)new ImageConverter().ConvertFrom(hStaffMasterVo.Picture) : null;
            /*
             * HGroupBoxExDrive
             * 運転に関する情報
             */
            HDateTimeExSelectionDate.SetValueJp(hStaffMasterVo.SelectionDate);
            HDateTimeExNotSelectionDate.SetValueJp(hStaffMasterVo.NotSelectionDate);
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
            HDateTimeExLicenseTypeDate.SetValueJp(hStaffMasterVo.HLicenseMasterVo.DeliveryDate);
            HDateTimeExLicenseTypeExpirationDate.SetValueJp(hStaffMasterVo.HLicenseMasterVo.ExpirationDate);
            /*
             * HGroupBoxExHistory 
             * 職業履歴
             */
            this.ScreenOutputHGroupBoxExHistory(hStaffMasterVo.ListHStaffHistoryVo);
            /*
             * HGroupBoxExExperience
             * 過去に運転経験のある自動車の種類・経験期間等
             */
            this.ScreenOutputHGroupBoxExExperience(hStaffMasterVo.ListHStaffExperienceVo);
            /*
             * HGroupBoxExRetirement
             * 解雇・退職の日付と理由
             */
            HCheckBoxExRetirementFlag.Checked = hStaffMasterVo.RetirementFlag;
            HDateTimeExRetirementDate.SetValueJp(hStaffMasterVo.RetirementDate);
            HTextBoxExRetirementNote.Text = hStaffMasterVo.RetirementNote;
            HDateTimeExDeathDate.SetValueJp(hStaffMasterVo.DeathDate);
            HTextBoxExDeathNote.Text = hStaffMasterVo.DeathNote;
            /*
             * HGroupBoxExFamily
             * 家族構成
             */
            this.ScreenOutputHGroupBoxExFamily(hStaffMasterVo.ListHStaffFamilyVo);
            HTextBoxExUrgentTelephoneNumber.Text = hStaffMasterVo.UrgentTelephoneNumber;
            HTextBoxExUrgentTelephoneMethod.Text = hStaffMasterVo.UrgentTelephoneMethod;
            /*
             * HGroupBoxExInsurance
             * 保険関係
             */
            HDateTimeExHealthInsuranceDate.SetValueJp(hStaffMasterVo.HealthInsuranceDate);
            HComboBoxExHealthInsuranceNumber.Text = hStaffMasterVo.HealthInsuranceNumber;
            HTextBoxExHealthInsuranceNote.Text = hStaffMasterVo.HealthInsuranceNote;
            HDateTimeExWelfarePensionDate.SetValueJp(hStaffMasterVo.WelfarePensionDate);
            HComboBoxExWelfarePensionNumber.Text = hStaffMasterVo.WelfarePensionNumber;
            HTextBoxExWelfarePensionNote.Text = hStaffMasterVo.WelfarePensionNote;
            HDateTimeExEmploymentInsuranceDate.SetValueJp(hStaffMasterVo.EmploymentInsuranceDate);
            HComboBoxExEmploymentInsuranceNumber.Text = hStaffMasterVo.EmploymentInsuranceNumber;
            HTextBoxExEmploymentInsuranceNote.Text = hStaffMasterVo.EmploymentInsuranceNote;
            HDateTimeExWorkerAccidentInsuranceDate.SetValueJp(hStaffMasterVo.WorkerAccidentInsuranceDate);
            HComboBoxExWorkerAccidentInsuranceNumber.Text = hStaffMasterVo.WorkerAccidentInsuranceNumber;
            HTextBoxExWorkerAccidentInsuranceNote.Text = hStaffMasterVo.WorkerAccidentInsuranceNote;
            /*
             * HGroupBoxExMedical
             * 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
             */
            this.ScreenOutputHGroupBoxExMedical(hStaffMasterVo.ListHStaffMedicalExaminationVo);
            /*
             * HGroupBoxExCarViolate
             * 業務上の交通違反歴
             */
            this.ScreenOutputHGroupBoxExCarViolate(hStaffMasterVo.ListHStaffCarViolateVo);
            /*
             * HGroupBoxEducate
             * 社内教育の実施記録
             */
            this.ScreenOutputHGroupBoxEducate(hStaffMasterVo.ListHStaffEducateVo);
            /*
             * HGroupBoxProper
             * 適正診断(NASVA他)
             */
            this.ScreenOutputHGroupBoxProper(hStaffMasterVo.ListHStaffProperVo);
            /*
             * HGroupBoxExPunishment
             * 賞罰・譴責
             */
            this.ScreenOutputHGroupBoxExPunishment(hStaffMasterVo.ListHStaffPunishmentVo);
        }

        /// <summary>
        /// 職業履歴
        /// </summary>
        private void ScreenOutputHGroupBoxExHistory(List<H_StaffHistoryVo> listHStaffHistoryVo) {
            Dictionary<int, H_DateTimePickerEx> dictionaryHistoryDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExHistoryDate1 }, { 1, HDateTimeExHistoryDate2 }, { 2, HDateTimeExHistoryDate3 } };
            Dictionary<int, H_TextBoxEx> dictionaryHistoryNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExCompanyName1 }, { 1, HTextBoxExCompanyName2 }, { 2, HTextBoxExCompanyName3 } };
            HDateTimeExHistoryDate.SetBlank();
            HTextBoxExCompanyName.Text = string.Empty;
            int countHGroupBoxExHistory = 0;
            foreach (H_StaffHistoryVo hStaffHistoryVo in listHStaffHistoryVo) {
                dictionaryHistoryDate[countHGroupBoxExHistory].SetValueJp(hStaffHistoryVo.HistoryDate);
                dictionaryHistoryNote[countHGroupBoxExHistory].Text = hStaffHistoryVo.CompanyName;
                countHGroupBoxExHistory++;
                if (countHGroupBoxExHistory > 2)
                    break;
            }
        }

        /// <summary>
        /// 過去に運転経験のある自動車の種類・経験期間等
        /// </summary>
        private void ScreenOutputHGroupBoxExExperience(List<H_StaffExperienceVo> listHStaffExperienceVo) {
            Dictionary<int, H_ComboBoxEx> dictionaryExperienceKind = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExExperienceKind1 }, { 1, HComboBoxExExperienceKind2 }, { 2, HComboBoxExExperienceKind3 } };
            Dictionary<int, H_TextBoxEx> dictionaryExperienceLoad = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExExperienceLoad1 }, { 1, HTextBoxExExperienceLoad2 }, { 2, HTextBoxExExperienceLoad3 } };
            Dictionary<int, H_TextBoxEx> dictionaryExperienceDuration = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExExperienceDuration1 }, { 1, HTextBoxExExperienceDuration2 }, { 2, HTextBoxExExperienceDuration3 } };
            Dictionary<int, H_TextBoxEx> dictionaryExperienceNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExExperienceNote1 }, { 1, HTextBoxExExperienceNote2 }, { 2, HTextBoxExExperienceNote3 } };
            HComboBoxExExperienceKind.SelectedIndex = -1;
            HTextBoxExExperienceLoad.Text = string.Empty;
            HTextBoxExExperienceDuration.Text = string.Empty;
            HTextBoxExExperienceNote.Text = string.Empty;
            int countHGroupBoxExExperience = 0;
            foreach (H_StaffExperienceVo hStaffExperienceVo in listHStaffExperienceVo) {
                dictionaryExperienceKind[countHGroupBoxExExperience].Text = hStaffExperienceVo.ExperienceKind;
                dictionaryExperienceLoad[countHGroupBoxExExperience].Text = hStaffExperienceVo.ExperienceLoad;
                dictionaryExperienceDuration[countHGroupBoxExExperience].Text = hStaffExperienceVo.ExperienceDuration;
                dictionaryExperienceNote[countHGroupBoxExExperience].Text += hStaffExperienceVo.ExperienceNote;
                countHGroupBoxExExperience++;
                if (countHGroupBoxExExperience > 2)
                    break;
            }
        }

        /// <summary>
        /// 家族構成
        /// </summary>
        private void ScreenOutputHGroupBoxExFamily(List<H_StaffFamilyVo> listHStaffFamilyVo) {
            Dictionary<int, H_TextBoxEx> dictionaryFamilyName = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExFamilyName1 }, { 1, HTextBoxExFamilyName2 }, { 2, HTextBoxExFamilyName3 } };
            Dictionary<int, H_DateTimePickerEx> dictionaryFamilyBirthDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExFamilyBirthDate1 }, { 1, HDateTimeExFamilyBirthDate2 }, { 2, HDateTimeExFamilyBirthDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryFamilyRelationship = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExFamilyRelationship1 }, { 1, HComboBoxExFamilyRelationship2 }, { 2, HComboBoxExFamilyRelationship3 } };
            HTextBoxExFamilyName.Text = string.Empty;
            HDateTimeExFamilyBirthDate.SetBlank();
            HComboBoxExFamilyRelationship.SelectedIndex = -1;
            int countHGroupBoxExFamily = 0;
            foreach (H_StaffFamilyVo hStaffFamilyVo in listHStaffFamilyVo) {
                dictionaryFamilyName[countHGroupBoxExFamily].Text = hStaffFamilyVo.FamilyName;
                dictionaryFamilyBirthDate[countHGroupBoxExFamily].SetValueJp(hStaffFamilyVo.FamilyBirthDay);
                dictionaryFamilyRelationship[countHGroupBoxExFamily].Text = hStaffFamilyVo.FamilyRelationship;
                countHGroupBoxExFamily++;
                if (countHGroupBoxExFamily > 2)
                    break;
            }

        }

        /// <summary>
        /// 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
        /// </summary>
        private void ScreenOutputHGroupBoxExMedical(List<H_StaffMedicalExaminationVo> listHStaffMedicalExaminationVo) {
            Dictionary<int, H_DateTimePickerEx> dictionaryMedicalDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExMedicalExaminationDate1 }, { 1, HDateTimeExMedicalExaminationDate2 }, { 2, HDateTimeExMedicalExaminationDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryMedicalName = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExMedicalInstitutionName1 }, { 1, HComboBoxExMedicalInstitutionName2 }, { 2, HComboBoxExMedicalInstitutionName3 } };
            Dictionary<int, H_TextBoxEx> dictionaryMedicalNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExMedicalExaminationNote1 }, { 1, HTextBoxExMedicalExaminationNote2 }, { 2, HTextBoxExMedicalExaminationNote3 } };
            HDateTimeExMedicalExaminationDate.SetBlank();
            HComboBoxExMedicalInstitutionName.SelectedIndex = -1;
            HTextBoxExMedicalExaminationNote.Text = string.Empty;
            int countHGroupBoxExMedical = 0;
            foreach (H_StaffMedicalExaminationVo hStaffMedicalExaminationVo in listHStaffMedicalExaminationVo) {
                dictionaryMedicalDate[countHGroupBoxExMedical].SetValueJp(hStaffMedicalExaminationVo.MedicalExaminationDate);
                dictionaryMedicalName[countHGroupBoxExMedical].Text = hStaffMedicalExaminationVo.MedicalInstitutionName;
                dictionaryMedicalNote[countHGroupBoxExMedical].Text += hStaffMedicalExaminationVo.MedicalExaminationNote;
                countHGroupBoxExMedical++;
                if (countHGroupBoxExMedical > 2)
                    break;
            }
        }

        /// <summary>
        /// 業務上の交通違反歴
        /// </summary>
        private void ScreenOutputHGroupBoxExCarViolate(List<H_StaffCarViolateVo> listHStaffCarViolateVo) {
            Dictionary<int, H_DateTimePickerEx> dictionaryCarViolateDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExCarViolateDate1 }, { 1, HDateTimeExCarViolateDate2 }, { 2, HDateTimeExCarViolateDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryCarViolateContent = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExCarViolateContent1 }, { 1, HComboBoxExCarViolateContent2 }, { 2, HComboBoxExCarViolateContent3 } };
            Dictionary<int, H_TextBoxEx> dictionaryCarViolatePlace = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExCarViolatePlace1 }, { 1, HTextBoxExCarViolatePlace2 }, { 2, HTextBoxExCarViolatePlace3 } };
            HDateTimeExCarViolateDate.SetBlank();
            HComboBoxExCarViolateContent.SelectedIndex = -1;
            HTextBoxExCarViolatePlace.Text = string.Empty;
            int countHGroupBoxExCarViolate = 0;
            foreach (H_StaffCarViolateVo hStaffCarViolateVo in listHStaffCarViolateVo) {
                dictionaryCarViolateDate[countHGroupBoxExCarViolate].SetValueJp(hStaffCarViolateVo.CarViolateDate);
                dictionaryCarViolateContent[countHGroupBoxExCarViolate].Text = hStaffCarViolateVo.CarViolateContent;
                dictionaryCarViolatePlace[countHGroupBoxExCarViolate].Text += hStaffCarViolateVo.CarViolatePlace;
                countHGroupBoxExCarViolate++;
                if (countHGroupBoxExCarViolate > 2)
                    break;
            }
        }

        /// <summary>
        /// 社内教育の実施記録
        /// </summary>
        private void ScreenOutputHGroupBoxEducate(List<H_StaffEducateVo> listHStaffEducateVo) {
            Dictionary<int, H_DateTimePickerEx> dictionaryEducateDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExEducateDate1 }, { 1, HDateTimeExEducateDate2 }, { 2, HDateTimeExEducateDate3 } };
            Dictionary<int, H_ComboBoxEx> dictionaryEducateName = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExEducateName1 }, { 1, HComboBoxExEducateName2 }, { 2, HComboBoxExEducateName3 } };
            HDateTimeExEducateDate.SetBlank();
            HComboBoxExEducateName.SelectedIndex = -1;
            int countHGroupBoxEducate = 0;
            foreach (H_StaffEducateVo hStaffEducateVo in listHStaffEducateVo) {
                dictionaryEducateDate[countHGroupBoxEducate].SetValueJp(hStaffEducateVo.EducateDate);
                dictionaryEducateName[countHGroupBoxEducate].Text = hStaffEducateVo.EducateName;
                countHGroupBoxEducate++;
                if (countHGroupBoxEducate > 2)
                    break;
            }
        }

        /// <summary>
        /// 適正診断(NASVA他)
        /// </summary>
        private void ScreenOutputHGroupBoxProper(List<H_StaffProperVo> listHStaffProperVo) {
            Dictionary<int, H_ComboBoxEx> dictionaryProperKind = new Dictionary<int, H_ComboBoxEx> { { 0, HComboBoxExProperKind1 }, { 1, HComboBoxExProperKind2 }, { 2, HComboBoxExProperKind3 } };
            Dictionary<int, H_DateTimePickerEx> dictionaryProperDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExProperDate1 }, { 1, HDateTimeExProperDate2 }, { 2, HDateTimeExProperDate3 } };
            Dictionary<int, H_TextBoxEx> dictionaryProperNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExProperNote1 }, { 1, HTextBoxExProperNote2 }, { 2, HTextBoxExProperNote3 } };
            HComboBoxExProperKind.SelectedIndex = -1;
            HDateTimeExProperDate.SetBlank();
            HTextBoxExProperNote.Text = string.Empty;
            int countHGroupBoxProper = 0;
            foreach (H_StaffProperVo hStaffProperVo in listHStaffProperVo) {
                dictionaryProperKind[countHGroupBoxProper].Text = hStaffProperVo.ProperKind;
                dictionaryProperDate[countHGroupBoxProper].SetValueJp(hStaffProperVo.ProperDate);
                dictionaryProperNote[countHGroupBoxProper].Text = hStaffProperVo.ProperNote;
                countHGroupBoxProper++;
                if (countHGroupBoxProper > 2)
                    break;
            }
        }

        /// <summary>
        /// 賞罰・譴責
        /// </summary>
        private void ScreenOutputHGroupBoxExPunishment(List<H_StaffPunishmentVo> listHStaffPunishmentVo) {
            Dictionary<int, H_DateTimePickerEx> dictionaryPunishmentDate = new Dictionary<int, H_DateTimePickerEx> { { 0, HDateTimeExPunishmentDate1 }, { 1, HDateTimeExPunishmentDate2 }, { 2, HDateTimeExPunishmentDate3 } };
            Dictionary<int, H_TextBoxEx> dictionaryPunishmentNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExPunishmentNote1 }, { 1, HTextBoxExPunishmentNote2 }, { 2, HTextBoxExPunishmentNote3 } };
            HDateTimeExPunishmentDate.SetBlank();
            HTextBoxExPunishmentNote.Text = string.Empty;
            int countHGroupBoxExPunishment = 0;
            foreach (H_StaffPunishmentVo hStaffPunishmentVo in listHStaffPunishmentVo) {
                dictionaryPunishmentDate[countHGroupBoxExPunishment].SetValueJp(hStaffPunishmentVo.PunishmentDate);
                dictionaryPunishmentNote[countHGroupBoxExPunishment].Text = hStaffPunishmentVo.PunishmentNote;
                countHGroupBoxExPunishment++;
                if (countHGroupBoxExPunishment > 2)
                    break;
            }
        }

        /// <summary>
        /// Controlを初期化する
        /// </summary>
        public void InitializeControls() {
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
            //HTextBoxExStaffCode.Text = string.Empty;
            HTextBoxExUnionCode.Text = string.Empty;
            HTextBoxExNameKana.Text = string.Empty;
            HTextBoxExName.Text = string.Empty;
            HTextBoxExDisplayName.Text = string.Empty;
            HTextBoxExOtherNameKana.Text = string.Empty;
            HTextBoxExOtherName.Text = string.Empty;
            HDateTimeExBirthDate.SetBlank();
            HDateTimeExEmploymentDate.SetBlank();
            HCheckBoxExContractFlag.Checked = false;
            HDateTimePickerExContractDate.Enabled = false;
            HDateTimePickerExContractDate.SetBlank();
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
            HTextBoxExCompanyName.Text = string.Empty;
            HDateTimeExHistoryDate1.SetBlank();
            HTextBoxExCompanyName1.Text = string.Empty;
            HDateTimeExHistoryDate2.SetBlank();
            HTextBoxExCompanyName2.Text = string.Empty;
            HDateTimeExHistoryDate3.SetBlank();
            HTextBoxExCompanyName3.Text = string.Empty;
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

            ToolStripStatusLabelDetail.Text = string.Empty;
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
                    HRadioButtonExNone1.Enabled = true;
                    HRadioButtonExOfficeWork.Enabled = true;
                    HRadioButtonExDriver.Enabled = true;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = true;
                    break;
                case "アルバイト":
                    HRadioButtonExLongTarm.Enabled = false;
                    HRadioButtonExShortTarm.Enabled = false;
                    HRadioButtonExNone1.Enabled = true;
                    HRadioButtonExOfficeWork.Enabled = true;
                    HRadioButtonExDriver.Enabled = true;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = true;
                    break;
                case "派遣":
                    HRadioButtonExLongTarm.Enabled = false;
                    HRadioButtonExShortTarm.Enabled = false;
                    HRadioButtonExNone1.Enabled = true;
                    HRadioButtonExOfficeWork.Enabled = false;
                    HRadioButtonExDriver.Enabled = false;
                    HRadioButtonExOperator.Enabled = true;
                    HRadioButtonExNone2.Enabled = false;
                    break;
                case "新運転":
                case "自運労":
                    HRadioButtonExLongTarm.Enabled = true;
                    HRadioButtonExShortTarm.Enabled = true;
                    HRadioButtonExNone1.Enabled = false;
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

        private void HCheckBoxExContractFlag_CheckedChanged(object sender, EventArgs e) {
            HDateTimePickerExContractDate.Enabled = ((H_CheckBoxEx)sender).Checked;
        }

        /// <summary>
        /// HStaffDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffDetail_FormClosing(object sender, FormClosingEventArgs e) {
            /*
             * 各詳細が更新されていた場合、全てを更新しなければ終了させない
             */
            if (_updateFlag) {
                MessageBox.Show("一部詳細が更新(INSERT)されています。UPDATEボタンを押下して下さい。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
            DialogResult dialogResult = MessageBox.Show("アプリケーションを終了します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
