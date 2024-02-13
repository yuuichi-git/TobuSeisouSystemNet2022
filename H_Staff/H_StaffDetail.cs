/*
 * 2024-02-07
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

namespace H_Staff {
    public partial class HStaffDetail : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        // ErrorProviderのインスタンスを生成
        ErrorProvider errorProvider = new();
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
            // アイコンを常に点滅に設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            this.InitializeControls();
        }

        /// <summary>
        /// コンストラクター（修正登録）
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public HStaffDetail(ConnectionVo connectionVo, int staffCode) {
            // StaffCode
            _staffCode = 0;
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

            InitializeComponent();
            this.InitializeControls();
            this.ScreenOutput(_hStaffMasterDao.SelectOneHStaffMasterForStaffDetail(staffCode));
        }

        /// <summary>
        /// CreateHStaffMasterVo
        /// Voを作成してUpdateする
        /// </summary>
        private void CreateHStaffMasterVo() {
            H_StaffMasterVo hStaffMasterVo = new();





        }

        /// <summary>
        /// Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e) {
            switch (((Button)sender).Name) {
                case "ButtonUpdate":


                    break;
                case "AddHGroupBoxExHistory": // 職業履歴
                    try {
                        // 更新
                        H_StaffHistoryVo hStaffHistoryVo = new();
                        hStaffHistoryVo.HistoryDate = HDateTimeExHistoryDate.GetValue();
                        hStaffHistoryVo.HistoryNote = HTextBoxExHistoryNote.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExHistoryDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExHistoryDate, "入社日を入力して下さい。");
                            break;
                        } else if (HTextBoxExHistoryNote.Text == string.Empty) {
                            errorProvider.SetError(HTextBoxExHistoryNote, "在籍記録を入力して下さい。");
                            break;
                        }
                        _hStaffHistoryDao.InsertOneHStaffHistoryMaster(hStaffHistoryVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExHistoryを更新しました。";
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
                        hStaffExperienceVo.ExperienceKind = HComboBoxExExperienceKind.Text;
                        hStaffExperienceVo.ExperienceLoad = HTextBoxExExperienceLoad.Text;
                        hStaffExperienceVo.ExperienceDuration = HTextBoxExExperienceDuration.Text;
                        hStaffExperienceVo.ExperienceNote = HTextBoxExExperienceNote.Text;
                        /*
                         * Validation
                         */
                        if (HComboBoxExExperienceKind.Text == string.Empty) {
                            errorProvider.SetError(HComboBoxExExperienceKind, "");
                            break;
                        } else if (HTextBoxExExperienceLoad.Text == string.Empty) {
                            errorProvider.SetError(HTextBoxExExperienceLoad, "");
                            break;
                        } else if (HTextBoxExExperienceDuration.Text == string.Empty) {
                            errorProvider.SetError(HTextBoxExExperienceDuration, "");
                            break;
                        }
                        _hStaffExperienceDao.InsertOneHStaffExperienceMaster(hStaffExperienceVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExExperienceを更新しました。";
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
                        hStaffFamilyVo.FamilyName = HTextBoxExFamilyName.Text;
                        hStaffFamilyVo.FamilyBirthDay = HDateTimeExFamilyBirthDate.GetValue();
                        hStaffFamilyVo.FamilyRelationship = HComboBoxExFamilyRelationship.Text;
                        /*
                         * Validation
                         */
                        if (HTextBoxExFamilyName.Text == string.Empty) {
                            errorProvider.SetError(HTextBoxExFamilyName, "");
                            break;
                        } else if (HDateTimeExFamilyBirthDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExFamilyBirthDate, "");
                            break;
                        } else if (HComboBoxExFamilyRelationship.Text == string.Empty) {
                            errorProvider.SetError(HComboBoxExFamilyRelationship, "");
                            break;
                        }
                        _hStaffFamilyDao.InsertOneHStaffFamilyMaster(hStaffFamilyVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExFamilyを更新しました。";
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
                        hStaffMedicalExaminationVo.MedicalExaminationDate = HDateTimeExMedicalExaminationDate.GetValue();
                        hStaffMedicalExaminationVo.MedicalInstitutionName = HComboBoxExMedicalInstitutionName.Text;
                        hStaffMedicalExaminationVo.MedicalExaminationNote = HTextBoxExMedicalExaminationNote.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExMedicalExaminationDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExMedicalExaminationDate, "");
                            break;
                        } else if (HComboBoxExMedicalInstitutionName.Text == string.Empty) {
                            errorProvider.SetError(HComboBoxExMedicalInstitutionName, "");
                            break;
                        }
                        _hStaffMedicalExaminationDao.InsertOneHStaffMedicalExaminationMaster(hStaffMedicalExaminationVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExMedicalを更新しました。";
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
                        hStaffCarViolateVo.CarViolateDate = HDateTimeExCarViolateDate.GetValue();
                        hStaffCarViolateVo.CarViolateContent = HComboBoxExCarViolateContent.Text;
                        hStaffCarViolateVo.CarViolatePlace = HTextBoxExCarViolatePlace.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExCarViolateDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExCarViolateDate, "");
                            break;
                        } else if (HComboBoxExCarViolateContent.Text == string.Empty) {
                            errorProvider.SetError(HComboBoxExCarViolateContent, "");
                            break;
                        }
                        _hStaffCarViolateDao.InsertOneHStaffCarViolateMaster(hStaffCarViolateVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExCarViolateを更新しました。";
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
                        hStaffEducateVo.EducateDate = HDateTimeExEducateDate.GetValue();
                        hStaffEducateVo.EducateName = HComboBoxExEducateName.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExEducateDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExEducateDate, "");
                            break;
                        } else if (HComboBoxExEducateName.Text == string.Empty) {
                            errorProvider.SetError(HComboBoxExEducateName, "");
                            break;
                        }
                        _hStaffEducateDao.InsertOneHStaffEducateMaster(hStaffEducateVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxEducateを更新しました。";
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
                        hStaffProperVo.ProperKind = HComboBoxExProperKind.Text;
                        hStaffProperVo.ProperDate = HDateTimeExProperDate.GetValue();
                        hStaffProperVo.ProperNote = HTextBoxExProperNote.Text;
                        /*
                        * Validation
                        */
                        if (HComboBoxExProperKind.Text == string.Empty) {
                            errorProvider.SetError(HComboBoxExProperKind, "");
                            break;
                        } else if (HDateTimeExProperDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExProperDate, "");
                            break;
                        } else if (HTextBoxExProperNote.Text == string.Empty) {
                            errorProvider.SetError(HTextBoxExProperNote, "");
                            break;
                        }
                        _hStaffProperDao.InsertOneHStaffProperMaster(hStaffProperVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxProperを更新しました。";
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
                        hStaffPunishmentVo.PunishmentDate = HDateTimeExPunishmentDate.GetValue();
                        hStaffPunishmentVo.PunishmentNote = HTextBoxExPunishmentNote.Text;
                        /*
                         * Validation
                         */
                        if (HDateTimeExPunishmentDate.Value.Date == _defaultDateTime.Date) {
                            errorProvider.SetError(HDateTimeExPunishmentDate, "");
                            break;
                        } else if (HTextBoxExPunishmentNote.Text == string.Empty) {
                            errorProvider.SetError(HTextBoxExPunishmentNote, "");
                            break;
                        }
                        _hStaffPunishmentDao.InsertOneHStaffPunishmentMasters(hStaffPunishmentVo);
                        ToolStripStatusLabelDetail.Text = "AddHGroupBoxExPunishmentを更新しました。";
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
        private void ScreenOutput(H_StaffMasterVo? hStaffMasterVo) {
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
            HDateTimeExRetirementDate.SetValue(hStaffMasterVo.RetirementDate);
            HTextBoxExRetirementNote.Text = hStaffMasterVo.RetirementNote;
            HDateTimeExDeathDate.SetValue(hStaffMasterVo.DeathDate);
            HTextBoxExDeathNote.Text = hStaffMasterVo.DeathNote;
            /*
             * HGroupBoxExFamily
             * 家族構成
             */
            this.ScreenOutputHGroupBoxExFamily(hStaffMasterVo.ListHStaffFamilyVo);
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
            Dictionary<int, H_TextBoxEx> dictionaryHistoryNote = new Dictionary<int, H_TextBoxEx> { { 0, HTextBoxExHistoryNote1 }, { 1, HTextBoxExHistoryNote2 }, { 2, HTextBoxExHistoryNote3 } };
            HDateTimeExHistoryDate.SetBlank();
            HTextBoxExHistoryNote.Text = string.Empty;
            int countHGroupBoxExHistory = 0;
            foreach (H_StaffHistoryVo hStaffHistoryVo in listHStaffHistoryVo) {
                dictionaryHistoryDate[countHGroupBoxExHistory].SetValue(hStaffHistoryVo.HistoryDate);
                dictionaryHistoryNote[countHGroupBoxExHistory].Text = hStaffHistoryVo.HistoryNote;
                countHGroupBoxExHistory++;
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
                dictionaryFamilyBirthDate[countHGroupBoxExFamily].SetValue(hStaffFamilyVo.FamilyBirthDay);
                dictionaryFamilyRelationship[countHGroupBoxExFamily].Text = hStaffFamilyVo.FamilyRelationship;
                countHGroupBoxExFamily++;
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
                dictionaryMedicalDate[countHGroupBoxExMedical].SetValue(hStaffMedicalExaminationVo.MedicalExaminationDate);
                dictionaryMedicalName[countHGroupBoxExMedical].Text = hStaffMedicalExaminationVo.MedicalInstitutionName;
                dictionaryMedicalNote[countHGroupBoxExMedical].Text += hStaffMedicalExaminationVo.MedicalExaminationNote;
                countHGroupBoxExMedical++;
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
                dictionaryCarViolateDate[countHGroupBoxExCarViolate].SetValue(hStaffCarViolateVo.CarViolateDate);
                dictionaryCarViolateContent[countHGroupBoxExCarViolate].Text = hStaffCarViolateVo.CarViolateContent;
                dictionaryCarViolatePlace[countHGroupBoxExCarViolate].Text += hStaffCarViolateVo.CarViolatePlace;
                countHGroupBoxExCarViolate++;
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
                dictionaryEducateDate[countHGroupBoxEducate].SetValue(hStaffEducateVo.EducateDate);
                dictionaryEducateName[countHGroupBoxEducate].Text = hStaffEducateVo.EducateName;
                countHGroupBoxEducate++;
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
                dictionaryProperDate[countHGroupBoxProper].SetValue(hStaffProperVo.ProperDate);
                dictionaryProperNote[countHGroupBoxProper].Text = hStaffProperVo.ProperNote;
                countHGroupBoxProper++;
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

        /// <summary>
        /// HStaffDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffDetail_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
