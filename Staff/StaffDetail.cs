using Common;

using Dao;

using Vo;

namespace Staff {
    public partial class StaffDetail : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        private readonly StaffMasterDao _staffMasterDao;

        /// <summary>
        /// True: 新規登録モード False:修正登録モード
        /// </summary>
        private readonly bool _openFlag;
        private readonly DateTime _defaultDateTime = new(1900, 01, 01, 00, 00, 00, 000);
        /// <summary>
        /// ErrorProviderのインスタンスを生成
        /// </summary>
        private ErrorProvider _errorProvider = new();

        /// <summary>
        /// 新規従事者登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public StaffDetail(ConnectionVo connectionVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _staffMasterDao = new StaffMasterDao(_connectionVo);
            _openFlag = true;
            // formを初期化
            InitializeForm();
            // Controlを初期化
            InitializeControl();
        }

        /// <summary>
        /// 修正従事者登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public StaffDetail(ConnectionVo connectionVo, int staffCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _staffMasterDao = new StaffMasterDao(_connectionVo);
            _openFlag = false;
            // formを初期化
            InitializeForm();
            // Controlを初期化
            InitializeControl();
            // 対象レコードを読込む
            ControlOutPut(_staffMasterDao.SelectOneStaffMaster(staffCode));
        }

        /*
         * ControlにStaffLedgerVoを設定
         */
        private void ControlOutPut(ExtendsStaffMasterVo extendsStaffMasterVo) {
            /*
             * 役職又は所属
             */
            ComboBoxBelongs.Text = extendsStaffMasterVo.Belongs_name; // 所属名
            CheckBoxTargetFlag.Checked = extendsStaffMasterVo.Vehicle_dispatch_target; // 配車の対象になる従事者
            switch(extendsStaffMasterVo.Belongs) {
                case 10: // 役員
                    RadioButtonOfficer.Checked = true;
                    break;
                case 11: // 社員
                    RadioButtonStaff.Checked = true;
                    break;
                case 12: // アルバイト
                    RadioButtonPart1.Checked = true;
                    break;
                case 13: // 派遣
                    RadioButtonDispatch.Checked = true;
                    break;
                case 20: // 新運転
                    RadioButtonSinunten.Checked = true;
                    break;
                case 21: // 自運労
                    RadioButtonJiunrou.Checked = true;
                    break;
            }
            /*
             * 雇用形態
             */
            switch(extendsStaffMasterVo.Job_form) {
                case 10: // 長期雇用
                    RadioButtonLongTarm.Checked = true;
                    break;
                case 11: // 手帳
                    RadioButtonNote.Checked = true;
                    break;
                case 12: // アルバイト
                    RadioButtonPart2.Checked = true;
                    break;
                case 99: // 指定なし
                    RadioButtonNone1.Checked = true;
                    break;
            }
            /*
             * 職種
             */
            switch(extendsStaffMasterVo.Occupation) {
                case 10: // 運転手
                    RadioButtonDriver.Checked = true;
                    break;
                case 11: // 作業員
                    RadioButtonOperator.Checked = true;
                    break;
                case 99: // 指定なし
                    RadioButtonNone2.Checked = true;
                    break;
            }

            /*
             * 個人情報１
             */
            TextBoxStaffCode.Text = string.Format("{0:#}", extendsStaffMasterVo.Staff_code); // 社員CD
            TextBoxCode.Text = string.Format("{0:#}", extendsStaffMasterVo.Code); // 組合CD
            TextBoxNameKana.Text = extendsStaffMasterVo.Name_kana; // フリガナ
            TextBoxName.Text = extendsStaffMasterVo.Name; // 氏名
            TextBoxDisplayName.Text = extendsStaffMasterVo.Display_name; // 略称名
            DateBirthDate.SetValue(extendsStaffMasterVo.Birth_date); // 生年月日
            DateEmploymentDate.SetValue(extendsStaffMasterVo.Employment_date); // 雇用年月日
            ComboBoxGender.Text = extendsStaffMasterVo.Gender; // 性別
            ComboBoxBloodType.Text = extendsStaffMasterVo.Blood_type; // 血液型
            TextBoxCurrentAddress.Text = extendsStaffMasterVo.Current_address; // 現住所
            TextBoxRemarks.Text = extendsStaffMasterVo.Remarks; // その他備考
            TextBoxTelephoneNumber.Text = extendsStaffMasterVo.Telephone_number; // 電話番号(自宅)
            TextBoxCellphoneNumber.Text = extendsStaffMasterVo.Cellphone_number; // 電話番号(携帯電話)
            if(extendsStaffMasterVo.Picture.Length == 0) {  // 写真
                PictureBoxPicture.Image = null;
            } else {
                PictureBoxPicture.Image = (Image?)new ImageConverter().ConvertFrom(extendsStaffMasterVo.Picture);
            }
            /*
             * 運転に関する情報
             */
            DateSelectionDate.SetValue(extendsStaffMasterVo.Selection_date); // 運転者に選任された日
            DateNotSelectionDate.SetValue(extendsStaffMasterVo.Not_selection_date); // 運転者でなくなった日
            TextBoxNotSelectionReason.Text = extendsStaffMasterVo.Not_selection_reason; // 理由
            /*
             * 免許証記録が無ければ処理しない
             */
            if(extendsStaffMasterVo.License_number != "") {
                TextBoxLicenseNumber.Text = extendsStaffMasterVo.License_number; // 免許証番号
                ComboBoxLicenseCondition.Text = extendsStaffMasterVo.LicenseMasterVo.License_condition; // 条件
                string kind = "";
                if(extendsStaffMasterVo.LicenseMasterVo.Large)
                    kind += "(大型)";
                if(extendsStaffMasterVo.LicenseMasterVo.Medium)
                    kind += "(中型)";
                if(extendsStaffMasterVo.LicenseMasterVo.Quasi_medium)
                    kind += "(準中型)";
                if(extendsStaffMasterVo.LicenseMasterVo.Ordinary)
                    kind += "(普通)";
                TextBoxLicenseType1.Text = kind; // 免許証の種類１
                DateLicenseTypeDate1.SetValue(extendsStaffMasterVo.LicenseMasterVo.Delivery_date); // 免許証の取得日１
                DateLicenseTypeExpirationDate1.SetValue(extendsStaffMasterVo.LicenseMasterVo.Expiration_date); // 免許証の有効期限１
            }
            /*
             * 履歴
             */
            DateHistoryDate1.SetValue(extendsStaffMasterVo.History_date_1); // 履歴年月日１
            TextBoxHistoryNote1.Text = extendsStaffMasterVo.History_note_1; // 履歴内容１
            DateHistoryDate2.SetValue(extendsStaffMasterVo.History_date_2); // 履歴年月日２
            TextBoxHistoryNote2.Text = extendsStaffMasterVo.History_note_2; // 履歴内容２
            DateHistoryDate3.SetValue(extendsStaffMasterVo.History_date_3); // 履歴年月日３
            TextBoxHistoryNote3.Text = extendsStaffMasterVo.History_note_3; // 履歴内容３
            DateHistoryDate4.SetValue(extendsStaffMasterVo.History_date_4); // 履歴年月日４
            TextBoxHistoryNote4.Text = extendsStaffMasterVo.History_note_4; // 履歴内容４
            DateHistoryDate5.SetValue(extendsStaffMasterVo.History_date_5); // 履歴年月日５
            TextBoxHistoryNote5.Text = extendsStaffMasterVo.History_note_5; // 履歴内容５
            DateHistoryDate6.SetValue(extendsStaffMasterVo.History_date_6); // 履歴年月日６
            TextBoxHistoryNote6.Text = extendsStaffMasterVo.History_note_6; // 履歴内容６
            /*
             * 過去に運転経験のある自動車の種類・経験期間等
             */
            ComboBoxExperienceKind1.Text = extendsStaffMasterVo.Experience_kind_1; // 種類１
            TextBoxExperienceLoad1.Text = extendsStaffMasterVo.Experience_load_1; // 積載量又は定員１
            TextBoxExperienceDuration1.Text = extendsStaffMasterVo.Experience_duration_1; // 経験期間１
            TextBoxExperienceNote1.Text = extendsStaffMasterVo.Experience_note_1; // 備考１
            ComboBoxExperienceKind2.Text = extendsStaffMasterVo.Experience_kind_2; // 種類２
            TextBoxExperienceLoad2.Text = extendsStaffMasterVo.Experience_load_2; // 積載量又は定員２
            TextBoxExperienceDuration2.Text = extendsStaffMasterVo.Experience_duration_2; // 経験期間２
            TextBoxExperienceNote2.Text = extendsStaffMasterVo.Experience_note_2; // 備考２
            ComboBoxExperienceKind3.Text = extendsStaffMasterVo.Experience_kind_3; // 種類３
            TextBoxExperienceLoad3.Text = extendsStaffMasterVo.Experience_load_3; // 積載量又は定員３
            TextBoxExperienceDuration3.Text = extendsStaffMasterVo.Experience_duration_3; // 経験期間３
            TextBoxExperienceNote3.Text = extendsStaffMasterVo.Experience_note_3; // 備考３
            ComboBoxExperienceKind4.Text = extendsStaffMasterVo.Experience_kind_4; // 種類４
            TextBoxExperienceLoad4.Text = extendsStaffMasterVo.Experience_load_4; // 積載量又は定員４
            TextBoxExperienceDuration4.Text = extendsStaffMasterVo.Experience_duration_4; // 経験期間４
            TextBoxExperienceNote4.Text = extendsStaffMasterVo.Experience_note_4; // 備考４
            /*
             * 解雇・退職の日付と理由
             */
            CheckBoxRetirementFlag.Checked = extendsStaffMasterVo.Retirement_flag; // 解雇又は退職のフラグ
            DateRetirementDate.SetValue(extendsStaffMasterVo.Retirement_date); // 解雇又は退職の年月日
            TextBoxRetirementNote.Text = extendsStaffMasterVo.Retirement_note; // 解雇又は退職の理由
            DateDeathDate.SetValue(extendsStaffMasterVo.Death_date); // 上記理由が死亡の場合その年月日
            TextBoxDeathNote.Text = extendsStaffMasterVo.Death_note; // 上記理由が死亡の場合その原因

            /*
             * 家族状況
             */
            TextBoxFamilyName1.Text = extendsStaffMasterVo.Family_name_1; // 家族氏名１
            DateFamilyBirthDate1.SetValue(extendsStaffMasterVo.Family_birth_date_1); // 生年月日１
            ComboBoxFamilyRelationship1.Text = extendsStaffMasterVo.Family_relationship_1; // 続柄１
            TextBoxFamilyName2.Text = extendsStaffMasterVo.Family_name_2; // 家族氏名２
            DateFamilyBirthDate2.SetValue(extendsStaffMasterVo.Family_birth_date_2); // 生年月日２
            ComboBoxFamilyRelationship2.Text = extendsStaffMasterVo.Family_relationship_2; // 続柄２
            TextBoxFamilyName3.Text = extendsStaffMasterVo.Family_name_3; // 家族氏名３
            DateFamilyBirthDate3.SetValue(extendsStaffMasterVo.Family_birth_date_3); // 生年月日３
            ComboBoxFamilyRelationship3.Text = extendsStaffMasterVo.Family_relationship_3; // 続柄３
            TextBoxFamilyName4.Text = extendsStaffMasterVo.Family_name_4; // 家族氏名４
            DateFamilyBirthDate4.SetValue(extendsStaffMasterVo.Family_birth_date_4); // 生年月日４
            ComboBoxFamilyRelationship4.Text = extendsStaffMasterVo.Family_relationship_4; // 続柄４
            TextBoxFamilyName5.Text = extendsStaffMasterVo.Family_name_5; // 家族氏名５
            DateFamilyBirthDate5.SetValue(extendsStaffMasterVo.Family_birth_date_5); // 生年月日５
            ComboBoxFamilyRelationship5.Text = extendsStaffMasterVo.Family_relationship_5; // 続柄５
            TextBoxFamilyName6.Text = extendsStaffMasterVo.Family_name_6; // 家族氏名６
            DateFamilyBirthDate6.SetValue(extendsStaffMasterVo.Family_birth_date_6); // 生年月日６
            ComboBoxFamilyRelationship6.Text = extendsStaffMasterVo.Family_relationship_6; // 続柄６
            TextBoxUrgentTelephoneNumber.Text = extendsStaffMasterVo.Urgent_telephone_number; // 緊急時連絡方法１
            TextBoxUrgentTelephoneMethod.Text = extendsStaffMasterVo.Urgent_telephone_method; // 緊急時連絡方法２
            /*
             * 保険関係
             */
            DateHealthInsuranceDate.SetValue(extendsStaffMasterVo.Health_insurance_date); // (健康保険)加入年月日
            ComboBoxHealthInsuranceNumber.Text = extendsStaffMasterVo.Health_insurance_number; // (健康保険)保険の記号・番号
            TextBoxHealthInsuranceNote.Text = extendsStaffMasterVo.Health_insurance_note; // (健康保険)備考
            DateWelfarePensionDate.SetValue(extendsStaffMasterVo.Welfare_pension_date); // (厚生年金保険)加入年月日
            TextBoxWelfarePensionNumber.Text = extendsStaffMasterVo.Welfare_pension_number; // (厚生年金保険)保険の記号・番号
            TextBoxWelfarePensionNote.Text = extendsStaffMasterVo.Welfare_pension_note; // (厚生年金保険)備考
            DateEmploymentInsuranceDate.SetValue(extendsStaffMasterVo.Employment_insurance_date); // (雇用保険)加入年月日
            TextBoxEmploymentInsuranceNumber.Text = extendsStaffMasterVo.Employment_insurance_number; // (雇用保険)保険の記号・番号
            TextBoxEmploymentInsuranceNote.Text = extendsStaffMasterVo.Employment_insurance_note; // (雇用保険)備考
            DateWorkerAccidentInsuranceDate.SetValue(extendsStaffMasterVo.Worker_accident_insurance_date); // (労災保険)加入年月日
            TextBoxWorkerAccidentInsuranceNumber.Text = extendsStaffMasterVo.Worker_accident_insurance_number; // (労災保険)保険の記号・番号
            TextBoxWorkerAccidentInsuranceNote.Text = extendsStaffMasterVo.Worker_accident_insurance_note; // (労災保険)備考
            /*
             * 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
             */
            DateMedicalExaminationDate1.SetValue(extendsStaffMasterVo.Medical_examination_date_1); // 加入年月日１
            ComboBoxMedicalExaminationNote1.Text = extendsStaffMasterVo.Medical_examination_note_1; // 保険の記号・番号１
            DateMedicalExaminationDate2.SetValue(extendsStaffMasterVo.Medical_examination_date_2); // 加入年月日２
            TextBoxMedicalExaminationNote2.Text = extendsStaffMasterVo.Medical_examination_note_2; // 保険の記号・番号２
            DateMedicalExaminationDate3.SetValue(extendsStaffMasterVo.Medical_examination_date_3); // 加入年月日３
            TextBoxMedicalExaminationNote3.Text = extendsStaffMasterVo.Medical_examination_note_3; // 保険の記号・番号３
            DateMedicalExaminationDate4.SetValue(extendsStaffMasterVo.Medical_examination_date_4); // 加入年月日４
            TextBoxMedicalExaminationNote4.Text = extendsStaffMasterVo.Medical_examination_note_4; // 保険の記号・番号４
            TextBoxMedicalExaminationNote.Text = extendsStaffMasterVo.Medical_examination_note; // 診断以外で気づいた点
            /*
             * 業務上の交通違反履歴
             */
            DateCarViolateDate1.SetValue(extendsStaffMasterVo.Car_violate_date_1); // 発生年月日１
            TextBoxCarViolateContent1.Text = extendsStaffMasterVo.Car_violate_content_1; // 交通違反内容１
            TextBoxCarViolatePlace1.Text = extendsStaffMasterVo.Car_violate_place_1; // 場所１
            DateCarViolateDate2.SetValue(extendsStaffMasterVo.Car_violate_date_2); // 発生年月日２
            TextBoxCarViolateContent2.Text = extendsStaffMasterVo.Car_violate_content_2; // 交通違反内容２
            TextBoxCarViolatePlace2.Text = extendsStaffMasterVo.Car_violate_place_2; // 場所２
            DateCarViolateDate3.SetValue(extendsStaffMasterVo.Car_violate_date_3); // 発生年月日３
            TextBoxCarViolateContent3.Text = extendsStaffMasterVo.Car_violate_content_3; // 交通違反内容３
            TextBoxCarViolatePlace3.Text = extendsStaffMasterVo.Car_violate_place_3; // 場所３
            DateCarViolateDate4.SetValue(extendsStaffMasterVo.Car_violate_date_4); // 発生年月日４
            TextBoxCarViolateContent4.Text = extendsStaffMasterVo.Car_violate_content_4; // 交通違反内容４
            TextBoxCarViolatePlace4.Text = extendsStaffMasterVo.Car_violate_place_4; // 場所４
            DateCarViolateDate5.SetValue(extendsStaffMasterVo.Car_violate_date_5); // 発生年月日５
            TextBoxCarViolateContent5.Text = extendsStaffMasterVo.Car_violate_content_5; // 交通違反内容５
            TextBoxCarViolatePlace5.Text = extendsStaffMasterVo.Car_violate_place_5; // 場所５
            DateCarViolateDate6.SetValue(extendsStaffMasterVo.Car_violate_date_6); // 発生年月日６
            TextBoxCarViolateContent6.Text = extendsStaffMasterVo.Car_violate_content_6; // 交通違反内容６
            TextBoxCarViolatePlace6.Text = extendsStaffMasterVo.Car_violate_place_6; // 場所６
            /*
             * 社内教育の実施状況
             */
            DateEducateDate1.SetValue(extendsStaffMasterVo.Educate_date_1); // 実施年月日１
            TextBoxEducateName1.Text = extendsStaffMasterVo.Educate_name_1; // 実施対象理由１
            DateEducateDate2.SetValue(extendsStaffMasterVo.Educate_date_2); // 実施年月日２
            TextBoxEducateName2.Text = extendsStaffMasterVo.Educate_name_2; // 実施対象理由２
            DateEducateDate3.SetValue(extendsStaffMasterVo.Educate_date_3); // 実施年月日３
            TextBoxEducateName3.Text = extendsStaffMasterVo.Educate_name_3; // 実施対象理由３
            DateEducateDate4.SetValue(extendsStaffMasterVo.Educate_date_4); // 実施年月日４
            TextBoxEducateName4.Text = extendsStaffMasterVo.Educate_name_4; // 実施対象理由４
            DateEducateDate5.SetValue(extendsStaffMasterVo.Educate_date_5); // 実施年月日５
            TextBoxEducateName5.Text = extendsStaffMasterVo.Educate_name_5; // 実施対象理由５
            DateEducateDate6.SetValue(extendsStaffMasterVo.Educate_date_6); // 実施年月日６
            TextBoxEducateName6.Text = extendsStaffMasterVo.Educate_name_6; // 実施対象理由６
            /*
             * 適性診断(NASVA)
             */
            ComboBoxProperKind1.Text = extendsStaffMasterVo.Proper_kind_1; // 種類１
            DateProperDate1.SetValue(extendsStaffMasterVo.Proper_date_1); // 実施年月日１
            TextBoxProperNote1.Text = extendsStaffMasterVo.Proper_note_1; // 経験期間１
            ComboBoxProperKind2.Text = extendsStaffMasterVo.Proper_kind_2; // 種類２
            DateProperDate2.SetValue(extendsStaffMasterVo.Proper_date_2); // 実施年月日２
            TextBoxProperNote2.Text = extendsStaffMasterVo.Proper_note_2; // 経験期間２
            ComboBoxProperKind3.Text = extendsStaffMasterVo.Proper_kind_3; // 種類３
            DateProperDate3.SetValue(extendsStaffMasterVo.Proper_date_3); // 実施年月日３
            TextBoxProperNote3.Text = extendsStaffMasterVo.Proper_note_3; // 経験期間３
            /*
             * 賞罰・譴責
             */
            DatePunishmentDate1.SetValue(extendsStaffMasterVo.Punishment_date_1); // 実施年月日１
            TextBoxPunishmentNote1.Text = extendsStaffMasterVo.Punishment_note_1; // 内容１
            DatePunishmentDate2.SetValue(extendsStaffMasterVo.Punishment_date_2); // 実施年月日２
            TextBoxPunishmentNote2.Text = extendsStaffMasterVo.Punishment_note_2; // 内容２
            DatePunishmentDate3.SetValue(extendsStaffMasterVo.Punishment_date_3); // 実施年月日３
            TextBoxPunishmentNote3.Text = extendsStaffMasterVo.Punishment_note_3; // 内容３
            DatePunishmentDate4.SetValue(extendsStaffMasterVo.Punishment_date_4); // 実施年月日４
            TextBoxPunishmentNote4.Text = extendsStaffMasterVo.Punishment_note_4; // 内容４
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // 入力項目をチェックする
            if(ComboBoxBelongs.Text.Length < 1) {
                _errorProvider.SetError(ComboBoxBelongs, "所属を選択して下さい");
                return; // メソッドを出る
            }
            if(TextBoxStaffCode.Text.Length < 1) {
                _errorProvider.SetError(TextBoxStaffCode, "社員CDを入力して下さい");
                return; // メソッドを出る
            } else {
                // ErrorProviderをクリアします。
                _errorProvider.Clear();
            }

            var dialogResult = MessageBox.Show(MessageText.Message401, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    // StaffLedgerVoに値をセット
                    var staffLedgerVo = SetStaffMasterVo();
                    // DBを変更(DBにstaff_codeが存在すればUPDATE、無ければINSERT)
                    if(_staffMasterDao.CheckStaffMaster(staffLedgerVo.Staff_code)) {
                        _staffMasterDao.UpdateOneStaffLedger(staffLedgerVo);
                    } else {
                        _staffMasterDao.InsertOneStaffMaster(staffLedgerVo);
                    }

                    Application.DoEvents();

                    this.Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// StaffLedgerVoに値を代入
        /// </summary>
        /// <returns></returns>
        private StaffMasterVo SetStaffMasterVo() {
            /*
             * 代入用のインスタンス作成
             */
            var staffMasterVo = new StaffMasterVo();
            /*
             * 配車の対象
             */
            staffMasterVo.Vehicle_dispatch_target = CheckBoxTargetFlag.Checked;
            /*
             * 役職又は所属
             */
            switch(ComboBoxBelongs.Text) {
                case "役員":
                    staffMasterVo.Belongs = 10;
                    break;
                case "社員":
                    staffMasterVo.Belongs = 11;
                    break;
                case "アルバイト":
                    staffMasterVo.Belongs = 12;
                    break;
                case "派遣":
                    staffMasterVo.Belongs = 13;
                    break;
                case "新運転":
                    staffMasterVo.Belongs = 20;
                    break;
                case "自運労":
                    staffMasterVo.Belongs = 21;
                    break;
            }
            /*
             * 雇用形態
             */
            if(RadioButtonLongTarm.Checked)
                staffMasterVo.Job_form = 10;
            if(RadioButtonNote.Checked)
                staffMasterVo.Job_form = 11;
            if(RadioButtonPart2.Checked)
                staffMasterVo.Job_form = 12;
            if(RadioButtonNone1.Checked)
                staffMasterVo.Job_form = 99;
            /*
             * 職種
             */
            if(RadioButtonDriver.Checked)
                staffMasterVo.Occupation = 10;
            if(RadioButtonOperator.Checked)
                staffMasterVo.Occupation = 11;
            if(RadioButtonNone2.Checked)
                staffMasterVo.Occupation = 99;
            /*
             * 個人情報１
             */
            staffMasterVo.Staff_code = int.Parse(TextBoxStaffCode.Text); // 社員CD
            staffMasterVo.Code = TextBoxCode.Text != "" ? int.Parse(TextBoxCode.Text) : 0; // 組合CD
            staffMasterVo.Name_kana = TextBoxNameKana.Text; // フリガナ
            staffMasterVo.Name = TextBoxName.Text; // 氏名
            staffMasterVo.Display_name = TextBoxDisplayName.Text; // 略称名
            staffMasterVo.Birth_date = DateBirthDate.GetText().Length > 0 ? DateBirthDate.GetValue() : _defaultDateTime; // 生年月日
            staffMasterVo.Employment_date = DateEmploymentDate.GetText().Length > 0 ? DateEmploymentDate.GetValue() : _defaultDateTime; // 雇用年月日
            staffMasterVo.Gender = ComboBoxGender.Text; // 性別
            staffMasterVo.Blood_type = ComboBoxBloodType.Text; // 血液型
            staffMasterVo.Current_address = TextBoxCurrentAddress.Text; // 現住所
            staffMasterVo.Remarks = TextBoxRemarks.Text; // 変更後住所
            staffMasterVo.Telephone_number = TextBoxTelephoneNumber.Text; // 電話番号(自宅)
            staffMasterVo.Cellphone_number = TextBoxCellphoneNumber.Text; // 電話番号(携帯電話)
            staffMasterVo.Picture = (byte[]?)new ImageConverter().ConvertTo(PictureBoxPicture.Image, typeof(byte[])); // 写真
            /*
             * 運転に関する情報
             */
            staffMasterVo.Selection_date = DateSelectionDate.GetText().Length > 0 ? DateSelectionDate.GetValue() : _defaultDateTime; // 運転者に選任された日
            staffMasterVo.Not_selection_date = DateNotSelectionDate.GetText().Length > 0 ? DateNotSelectionDate.GetValue() : _defaultDateTime; // 運転者でなくなった日
            staffMasterVo.Not_selection_reason = TextBoxNotSelectionReason.Text; // 理由
            staffMasterVo.License_number = TextBoxLicenseNumber.Text; // 免許証番号
            /*
             * 履歴
             */
            staffMasterVo.History_date_1 = DateHistoryDate1.GetValue(); // 履歴年月日１
            staffMasterVo.History_note_1 = TextBoxHistoryNote1.Text; // 履歴内容１
            staffMasterVo.History_date_2 = DateHistoryDate2.GetValue(); // 履歴年月日２
            staffMasterVo.History_note_2 = TextBoxHistoryNote2.Text; // 履歴内容２
            staffMasterVo.History_date_3 = DateHistoryDate3.GetValue(); // 履歴年月日３
            staffMasterVo.History_note_3 = TextBoxHistoryNote3.Text; // 履歴内容３
            staffMasterVo.History_date_4 = DateHistoryDate4.GetValue(); // 履歴年月日４
            staffMasterVo.History_note_4 = TextBoxHistoryNote4.Text; // 履歴内容４
            staffMasterVo.History_date_5 = DateHistoryDate5.GetValue(); // 履歴年月日５
            staffMasterVo.History_note_5 = TextBoxHistoryNote5.Text; // 履歴内容５
            staffMasterVo.History_date_6 = DateHistoryDate6.GetValue(); // 履歴年月日６
            staffMasterVo.History_note_6 = TextBoxHistoryNote6.Text; // 履歴内容６
            /*
             * 過去に運転経験のある自動車の種類・経験期間等
             */
            staffMasterVo.Experience_kind_1 = ComboBoxExperienceKind1.Text; // 種類１
            staffMasterVo.Experience_load_1 = TextBoxExperienceLoad1.Text; // 積載量又は定員１
            staffMasterVo.Experience_duration_1 = TextBoxExperienceDuration1.Text; // 経験期間１
            staffMasterVo.Experience_note_1 = TextBoxExperienceNote1.Text; // 備考１
            staffMasterVo.Experience_kind_2 = ComboBoxExperienceKind2.Text; // 種類２
            staffMasterVo.Experience_load_2 = TextBoxExperienceLoad2.Text; // 積載量又は定員２
            staffMasterVo.Experience_duration_2 = TextBoxExperienceDuration2.Text; // 経験期間２
            staffMasterVo.Experience_note_2 = TextBoxExperienceNote2.Text; // 備考２
            staffMasterVo.Experience_kind_3 = ComboBoxExperienceKind3.Text; // 種類３
            staffMasterVo.Experience_load_3 = TextBoxExperienceLoad3.Text; // 積載量又は定員３
            staffMasterVo.Experience_duration_3 = TextBoxExperienceDuration3.Text; // 経験期間３
            staffMasterVo.Experience_note_3 = TextBoxExperienceNote3.Text; // 備考３
            staffMasterVo.Experience_kind_4 = ComboBoxExperienceKind4.Text; // 種類４
            staffMasterVo.Experience_load_4 = TextBoxExperienceLoad4.Text; // 積載量又は定員４
            staffMasterVo.Experience_duration_4 = TextBoxExperienceDuration4.Text; // 経験期間４
            staffMasterVo.Experience_note_4 = TextBoxExperienceNote4.Text; // 備考４
            /*
             * 解雇・退職の日付と理由
             */
            staffMasterVo.Retirement_flag = CheckBoxRetirementFlag.Checked; // 解雇又は退職のフラグ
            staffMasterVo.Retirement_date = DateRetirementDate.GetValue(); // 解雇又は退職の年月日
            staffMasterVo.Retirement_note = TextBoxRetirementNote.Text; // 解雇又は退職の理由
            staffMasterVo.Death_date = DateDeathDate.GetValue(); // 上記理由が死亡の場合その年月日
            staffMasterVo.Death_note = TextBoxDeathNote.Text; // 上記理由が死亡の場合その原因
            /*
             * 家族状況
             */
            staffMasterVo.Family_name_1 = TextBoxFamilyName1.Text; // 家族氏名１
            staffMasterVo.Family_birth_date_1 = DateFamilyBirthDate1.GetValue(); // 生年月日１
            staffMasterVo.Family_relationship_1 = ComboBoxFamilyRelationship1.Text; // 続柄１
            staffMasterVo.Family_name_2 = TextBoxFamilyName2.Text; // 家族氏名２
            staffMasterVo.Family_birth_date_2 = DateFamilyBirthDate2.GetValue(); // 生年月日２
            staffMasterVo.Family_relationship_2 = ComboBoxFamilyRelationship2.Text; // 続柄２
            staffMasterVo.Family_name_3 = TextBoxFamilyName3.Text; // 家族氏名３
            staffMasterVo.Family_birth_date_3 = DateFamilyBirthDate3.GetValue(); // 生年月日３
            staffMasterVo.Family_relationship_3 = ComboBoxFamilyRelationship3.Text; // 続柄３
            staffMasterVo.Family_name_4 = TextBoxFamilyName4.Text; // 家族氏名４
            staffMasterVo.Family_birth_date_4 = DateFamilyBirthDate4.GetValue(); // 生年月日４
            staffMasterVo.Family_relationship_4 = ComboBoxFamilyRelationship4.Text; // 続柄４
            staffMasterVo.Family_name_5 = TextBoxFamilyName5.Text; // 家族氏名５
            staffMasterVo.Family_birth_date_5 = DateFamilyBirthDate5.GetValue(); // 生年月日５
            staffMasterVo.Family_relationship_5 = ComboBoxFamilyRelationship5.Text; // 続柄５
            staffMasterVo.Family_name_6 = TextBoxFamilyName6.Text; // 家族氏名６
            staffMasterVo.Family_birth_date_6 = DateFamilyBirthDate6.GetValue(); // 生年月日６
            staffMasterVo.Family_relationship_6 = ComboBoxFamilyRelationship6.Text; // 続柄６
            staffMasterVo.Urgent_telephone_number = TextBoxUrgentTelephoneNumber.Text; // 緊急時連絡方法１
            staffMasterVo.Urgent_telephone_method = TextBoxUrgentTelephoneMethod.Text; // 緊急時連絡方法２
            /*
             * 保険関係
             */
            staffMasterVo.Health_insurance_date = DateHealthInsuranceDate.GetValue(); // (健康保険)加入年月日
            staffMasterVo.Health_insurance_number = ComboBoxHealthInsuranceNumber.Text; // (健康保険)保険の記号・番号
            staffMasterVo.Health_insurance_note = TextBoxHealthInsuranceNote.Text; // (健康保険)備考
            staffMasterVo.Welfare_pension_date = DateWelfarePensionDate.GetValue(); // (厚生年金保険)加入年月日
            staffMasterVo.Welfare_pension_number = TextBoxWelfarePensionNumber.Text; // (厚生年金保険)保険の記号・番号
            staffMasterVo.Welfare_pension_note = TextBoxWelfarePensionNote.Text; // (厚生年金保険)備考
            staffMasterVo.Employment_insurance_date = DateEmploymentInsuranceDate.GetValue(); // (雇用保険)加入年月日
            staffMasterVo.Employment_insurance_number = TextBoxEmploymentInsuranceNumber.Text; // (雇用保険)保険の記号・番号
            staffMasterVo.Employment_insurance_note = TextBoxEmploymentInsuranceNote.Text; // (雇用保険)備考
            staffMasterVo.Worker_accident_insurance_date = DateWorkerAccidentInsuranceDate.GetValue(); // (労災保険)加入年月日
            staffMasterVo.Worker_accident_insurance_number = TextBoxWorkerAccidentInsuranceNumber.Text; // (労災保険)保険の記号・番号
            staffMasterVo.Worker_accident_insurance_note = TextBoxWorkerAccidentInsuranceNote.Text; // (労災保険)備考
            /*
             * 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
             */
            staffMasterVo.Medical_examination_date_1 = DateMedicalExaminationDate1.GetValue(); // 加入年月日１
            staffMasterVo.Medical_examination_note_1 = ComboBoxMedicalExaminationNote1.Text; // 保険の記号・番号１
            staffMasterVo.Medical_examination_date_2 = DateMedicalExaminationDate2.GetValue(); // 加入年月日２
            staffMasterVo.Medical_examination_note_2 = TextBoxMedicalExaminationNote2.Text; // 保険の記号・番号２
            staffMasterVo.Medical_examination_date_3 = DateMedicalExaminationDate3.GetValue(); // 加入年月日３
            staffMasterVo.Medical_examination_note_3 = TextBoxMedicalExaminationNote3.Text; // 保険の記号・番号３
            staffMasterVo.Medical_examination_date_4 = DateMedicalExaminationDate4.GetValue(); // 加入年月日４
            staffMasterVo.Medical_examination_note_4 = TextBoxMedicalExaminationNote4.Text; // 保険の記号・番号４
            staffMasterVo.Medical_examination_note = TextBoxMedicalExaminationNote.Text; // 診断以外で気づいた点
            /*
             * 業務上の交通違反履歴
             */
            staffMasterVo.Car_violate_date_1 = DateCarViolateDate1.GetValue(); // 発生年月日１
            staffMasterVo.Car_violate_content_1 = TextBoxCarViolateContent1.Text; // 交通違反内容１
            staffMasterVo.Car_violate_place_1 = TextBoxCarViolatePlace1.Text; // 場所１
            staffMasterVo.Car_violate_date_2 = DateCarViolateDate2.GetValue(); // 発生年月日２
            staffMasterVo.Car_violate_content_2 = TextBoxCarViolateContent2.Text; // 交通違反内容２
            staffMasterVo.Car_violate_place_2 = TextBoxCarViolatePlace2.Text; // 場所２
            staffMasterVo.Car_violate_date_3 = DateCarViolateDate3.GetValue(); // 発生年月日３
            staffMasterVo.Car_violate_content_3 = TextBoxCarViolateContent3.Text; // 交通違反内容３
            staffMasterVo.Car_violate_place_3 = TextBoxCarViolatePlace3.Text; // 場所３
            staffMasterVo.Car_violate_date_4 = DateCarViolateDate4.GetValue(); // 発生年月日４
            staffMasterVo.Car_violate_content_4 = TextBoxCarViolateContent4.Text; // 交通違反内容４
            staffMasterVo.Car_violate_place_4 = TextBoxCarViolatePlace4.Text; // 場所４
            staffMasterVo.Car_violate_date_5 = DateCarViolateDate5.GetValue(); // 発生年月日５
            staffMasterVo.Car_violate_content_5 = TextBoxCarViolateContent5.Text; // 交通違反内容５
            staffMasterVo.Car_violate_place_5 = TextBoxCarViolatePlace5.Text; // 場所５
            staffMasterVo.Car_violate_date_6 = DateCarViolateDate6.GetValue(); // 発生年月日６
            staffMasterVo.Car_violate_content_6 = TextBoxCarViolateContent6.Text; // 交通違反内容６
            staffMasterVo.Car_violate_place_6 = TextBoxCarViolatePlace6.Text; // 場所６
            /*
             * 社内教育の実施状況
             */
            staffMasterVo.Educate_date_1 = DateEducateDate1.GetValue(); // 実施年月日１
            staffMasterVo.Educate_name_1 = TextBoxEducateName1.Text; // 実施対象理由１
            staffMasterVo.Educate_date_2 = DateEducateDate2.GetValue(); // 実施年月日２
            staffMasterVo.Educate_name_2 = TextBoxEducateName2.Text; // 実施対象理由２
            staffMasterVo.Educate_date_3 = DateEducateDate3.GetValue(); // 実施年月日３
            staffMasterVo.Educate_name_3 = TextBoxEducateName3.Text; // 実施対象理由３
            staffMasterVo.Educate_date_4 = DateEducateDate4.GetValue(); // 実施年月日４
            staffMasterVo.Educate_name_4 = TextBoxEducateName4.Text; // 実施対象理由４
            staffMasterVo.Educate_date_5 = DateEducateDate5.GetValue(); // 実施年月日５
            staffMasterVo.Educate_name_5 = TextBoxEducateName5.Text; // 実施対象理由５
            staffMasterVo.Educate_date_6 = DateEducateDate6.GetValue(); // 実施年月日６
            staffMasterVo.Educate_name_6 = TextBoxEducateName6.Text; // 実施対象理由６
            /*
             * 適性診断(NASVA)
             */
            staffMasterVo.Proper_kind_1 = ComboBoxProperKind1.Text; // 種類１
            staffMasterVo.Proper_date_1 = DateProperDate1.GetValue(); // 実施年月日１
            staffMasterVo.Proper_note_1 = TextBoxProperNote1.Text; // 経験期間１
            staffMasterVo.Proper_kind_2 = ComboBoxProperKind2.Text; // 種類２
            staffMasterVo.Proper_date_2 = DateProperDate2.GetValue(); // 実施年月日２
            staffMasterVo.Proper_note_2 = TextBoxProperNote2.Text; // 経験期間２
            staffMasterVo.Proper_kind_3 = ComboBoxProperKind3.Text; // 種類３
            staffMasterVo.Proper_date_3 = DateProperDate3.GetValue(); // 実施年月日３
            staffMasterVo.Proper_note_3 = TextBoxProperNote3.Text; // 経験期間３
            /*
             * 賞罰・譴責
             */
            staffMasterVo.Punishment_date_1 = DatePunishmentDate1.GetValue(); // 実施年月日１
            staffMasterVo.Punishment_note_1 = TextBoxPunishmentNote1.Text; // 内容１
            staffMasterVo.Punishment_date_2 = DatePunishmentDate2.GetValue(); // 実施年月日２
            staffMasterVo.Punishment_note_2 = TextBoxPunishmentNote2.Text; // 内容２
            staffMasterVo.Punishment_date_3 = DatePunishmentDate3.GetValue(); // 実施年月日３
            staffMasterVo.Punishment_note_3 = TextBoxPunishmentNote3.Text; // 内容３
            staffMasterVo.Punishment_date_4 = DatePunishmentDate4.GetValue(); // 実施年月日４
            staffMasterVo.Punishment_note_4 = TextBoxPunishmentNote4.Text; // 内容４

            return staffMasterVo;
        }

        /*
         * Formを初期化
         */
        private void InitializeForm() {
            // Formの表示サイズを初期化
            _initializeForm.StaffDetail(this);
        }

        private void InitializeControl() {
            /*
             * controlを初期化
             * 所属・勤務形態
             */
            ComboBoxBelongs.SelectedIndex = 0; // 所属名
            CheckBoxTargetFlag.Checked = true; // 配車の対象になる従事者
                                               // 業務区分(組合員・アルバイト)
                                               // 業務区分(社員)
                                               // 個人情報１
            TextBoxStaffCode.Text = ""; // 社員CD
            TextBoxCode.Text = ""; // 組合CD
            TextBoxNameKana.Text = ""; // フリガナ
            TextBoxName.Text = ""; // 氏名
            TextBoxDisplayName.Text = ""; // 略称名
            DateBirthDate.SetBlank(); // 生年月日
            DateEmploymentDate.SetBlank(); // 雇用年月日
            ComboBoxGender.SelectedIndex = 0; // 性別
            ComboBoxBloodType.SelectedIndex = -1; // 血液型
            TextBoxCurrentAddress.Text = ""; // 現住所
            TextBoxRemarks.Text = ""; // 変更後住所
            TextBoxTelephoneNumber.Text = ""; // 電話番号(自宅)
            TextBoxCellphoneNumber.Text = ""; // 電話番号(携帯電話)
            PictureBoxPicture.Image = null; // 写真
            /*
             * 運転に関する情報
             */
            DateSelectionDate.SetBlank(); // 運転者に選任された日
            DateNotSelectionDate.SetBlank(); // 運転者でなくなった日
            TextBoxNotSelectionReason.Text = ""; // 理由
            TextBoxLicenseNumber.Text = ""; // 免許証番号
            ComboBoxLicenseCondition.SelectedIndex = -1; // 条件
            TextBoxLicenseType1.Text = ""; // 免許証の種類１
            DateLicenseTypeDate1.SetBlank(); // 免許証の取得日１
            DateLicenseTypeExpirationDate1.SetBlank(); // 免許証の有効期限１
            TextBoxLicenseType2.Text = ""; // 免許証の種類２
            DateLicenseTypeDate2.SetBlank(); // 免許証の取得日２
            DateLicenseTypeExpirationDate2.SetBlank(); // 免許証の有効期限２
            TextBoxLicenseType3.Text = ""; // 免許証の種類３
            DateLicenseTypeDate3.SetBlank(); // 免許証の取得日３
            DateLicenseTypeExpirationDate3.SetBlank(); // 免許証の有効期限３
            TextBoxLicenseType4.Text = ""; // 免許証の種類４
            DateLicenseTypeDate4.SetBlank(); // 免許証の取得日４
            DateLicenseTypeExpirationDate4.SetBlank(); // 免許証の有効期限４
            TextBoxLicenseType5.Text = ""; // 免許証の種類５
            DateLicenseTypeDate5.SetBlank(); // 免許証の取得日５
            DateLicenseTypeExpirationDate5.SetBlank(); // 免許証の有効期限５
            /*
             * 履歴
             */
            DateHistoryDate1.SetBlank(); // 履歴年月日１
            TextBoxHistoryNote1.Text = ""; // 履歴内容１
            DateHistoryDate2.SetBlank(); // 履歴年月日２
            TextBoxHistoryNote2.Text = ""; // 履歴内容２
            DateHistoryDate3.SetBlank(); // 履歴年月日３
            TextBoxHistoryNote3.Text = ""; // 履歴内容３
            DateHistoryDate4.SetBlank(); // 履歴年月日４
            TextBoxHistoryNote4.Text = ""; // 履歴内容４
            DateHistoryDate5.SetBlank(); // 履歴年月日５
            TextBoxHistoryNote5.Text = ""; // 履歴内容５
            DateHistoryDate6.SetBlank(); // 履歴年月日６
            TextBoxHistoryNote6.Text = ""; // 履歴内容６
            /*
             * 過去に運転経験のある自動車の種類・経験期間等
             */
            ComboBoxExperienceKind1.SelectedIndex = -1; // 種類１
            TextBoxExperienceLoad1.Text = ""; // 積載量又は定員１
            TextBoxExperienceDuration1.Text = ""; // 経験期間１
            TextBoxExperienceNote1.Text = ""; // 備考１
            ComboBoxExperienceKind2.SelectedIndex = -1; // 種類２
            TextBoxExperienceLoad2.Text = ""; // 積載量又は定員２
            TextBoxExperienceDuration2.Text = ""; // 経験期間２
            TextBoxExperienceNote2.Text = ""; // 備考２
            ComboBoxExperienceKind3.SelectedIndex = -1; // 種類３
            TextBoxExperienceLoad3.Text = ""; // 積載量又は定員３
            TextBoxExperienceDuration3.Text = ""; // 経験期間３
            TextBoxExperienceNote3.Text = ""; // 備考３
            ComboBoxExperienceKind4.SelectedIndex = -1; // 種類４
            TextBoxExperienceLoad4.Text = ""; // 積載量又は定員４
            TextBoxExperienceDuration4.Text = ""; // 経験期間４
            TextBoxExperienceNote4.Text = ""; // 備考４
            /*
             * 解雇・退職の日付と理由
             */
            CheckBoxRetirementFlag.Checked = false; // 解雇又は退職のフラグ
            DateRetirementDate.SetBlank(); // 解雇又は退職の年月日
            TextBoxRetirementNote.Text = ""; // 解雇又は退職の理由
            DateDeathDate.SetBlank(); // 上記理由が死亡の場合その年月日
            TextBoxDeathNote.Text = ""; // 上記理由が死亡の場合その原因
            /*
             * 家族状況
             */
            TextBoxFamilyName1.Text = ""; // 家族氏名１
            DateFamilyBirthDate1.SetBlank(); // 生年月日１
            ComboBoxFamilyRelationship1.SelectedIndex = -1; // 続柄１
            TextBoxFamilyName2.Text = ""; // 家族氏名２
            DateFamilyBirthDate2.SetBlank(); // 生年月日２
            ComboBoxFamilyRelationship2.SelectedIndex = -1; // 続柄２
            TextBoxFamilyName3.Text = ""; // 家族氏名３
            DateFamilyBirthDate3.SetBlank(); // 生年月日３
            ComboBoxFamilyRelationship3.SelectedIndex = -1; // 続柄３
            TextBoxFamilyName4.Text = ""; // 家族氏名４
            DateFamilyBirthDate4.SetBlank(); // 生年月日４
            ComboBoxFamilyRelationship4.SelectedIndex = -1; // 続柄４
            TextBoxFamilyName5.Text = ""; // 家族氏名５
            DateFamilyBirthDate5.SetBlank(); // 生年月日５
            ComboBoxFamilyRelationship5.SelectedIndex = -1; // 続柄５
            TextBoxFamilyName6.Text = ""; // 家族氏名６
            DateFamilyBirthDate6.SetBlank(); // 生年月日６
            ComboBoxFamilyRelationship6.SelectedIndex = -1; // 続柄６
            TextBoxUrgentTelephoneNumber.Text = ""; // 緊急時連絡方法１
            TextBoxUrgentTelephoneMethod.Text = ""; // 緊急時連絡方法２
            /*
             * 保険関係
             */
            DateHealthInsuranceDate.SetBlank(); // (健康保険)加入年月日
            ComboBoxHealthInsuranceNumber.SelectedIndex = -1; // (健康保険)保険の記号・番号
            TextBoxHealthInsuranceNote.Text = ""; // (健康保険)備考
            DateWelfarePensionDate.SetBlank(); // (厚生年金保険)加入年月日
            TextBoxWelfarePensionNumber.Text = ""; // (厚生年金保険)保険の記号・番号
            TextBoxWelfarePensionNote.Text = ""; // (厚生年金保険)備考
            DateEmploymentInsuranceDate.SetBlank(); // (雇用保険)加入年月日
            TextBoxEmploymentInsuranceNumber.Text = ""; // (雇用保険)保険の記号・番号
            TextBoxEmploymentInsuranceNote.Text = ""; // (雇用保険)備考
            DateWorkerAccidentInsuranceDate.SetBlank(); // (労災保険)加入年月日
            TextBoxWorkerAccidentInsuranceNumber.Text = ""; // (労災保険)保険の記号・番号
            TextBoxWorkerAccidentInsuranceNote.Text = ""; // (労災保険)備考
            /*
             * 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
             */
            DateMedicalExaminationDate1.SetBlank(); // 加入年月日１
            ComboBoxMedicalExaminationNote1.SelectedIndex = -1; // 保険の記号・番号１
            DateMedicalExaminationDate2.SetBlank(); // 加入年月日２
            TextBoxMedicalExaminationNote2.Text = ""; // 保険の記号・番号２
            DateMedicalExaminationDate3.SetBlank(); // 加入年月日３
            TextBoxMedicalExaminationNote3.Text = ""; // 保険の記号・番号３
            DateMedicalExaminationDate4.SetBlank(); // 加入年月日４
            TextBoxMedicalExaminationNote4.Text = ""; // 保険の記号・番号４
            TextBoxMedicalExaminationNote.Text = ""; // 診断以外で気づいた点
            /*
             * 業務上の交通違反履歴
             */
            DateCarViolateDate1.SetBlank(); // 発生年月日１
            TextBoxCarViolateContent1.Text = ""; // 交通違反内容１
            TextBoxCarViolatePlace1.Text = ""; // 場所１
            DateCarViolateDate2.SetBlank(); // 発生年月日２
            TextBoxCarViolateContent2.Text = ""; // 交通違反内容２
            TextBoxCarViolatePlace2.Text = ""; // 場所２
            DateCarViolateDate3.SetBlank(); // 発生年月日３
            TextBoxCarViolateContent3.Text = ""; // 交通違反内容３
            TextBoxCarViolatePlace3.Text = ""; // 場所３
            DateCarViolateDate4.SetBlank(); // 発生年月日４
            TextBoxCarViolateContent4.Text = ""; // 交通違反内容４
            TextBoxCarViolatePlace4.Text = ""; // 場所４
            DateCarViolateDate5.SetBlank(); // 発生年月日５
            TextBoxCarViolateContent5.Text = ""; // 交通違反内容５
            TextBoxCarViolatePlace5.Text = ""; // 場所５
            DateCarViolateDate6.SetBlank(); // 発生年月日６
            TextBoxCarViolateContent6.Text = ""; // 交通違反内容６
            TextBoxCarViolatePlace6.Text = ""; // 場所６
            /*
             * 社内教育の実施状況
             */
            DateEducateDate1.SetBlank(); // 実施年月日１
            TextBoxEducateName1.Text = ""; // 実施対象理由１
            DateEducateDate2.SetBlank(); // 実施年月日２
            TextBoxEducateName2.Text = ""; // 実施対象理由２
            DateEducateDate3.SetBlank(); // 実施年月日３
            TextBoxEducateName3.Text = ""; // 実施対象理由３
            DateEducateDate4.SetBlank(); // 実施年月日４
            TextBoxEducateName4.Text = ""; // 実施対象理由４
            DateEducateDate5.SetBlank(); // 実施年月日５
            TextBoxEducateName5.Text = ""; // 実施対象理由５
            DateEducateDate6.SetBlank(); // 実施年月日６
            TextBoxEducateName6.Text = ""; // 実施対象理由６
            /*
             * 適性診断(NASVA)
             */
            ComboBoxProperKind1.SelectedIndex = -1; // 種類１
            DateProperDate1.SetBlank(); // 実施年月日１
            TextBoxProperNote1.Text = ""; // 経験期間１
            ComboBoxProperKind2.SelectedIndex = -1; // 種類２
            DateProperDate2.SetBlank(); // 実施年月日２
            TextBoxProperNote2.Text = ""; // 経験期間２
            ComboBoxProperKind3.SelectedIndex = -1; // 種類３
            DateProperDate3.SetBlank(); // 実施年月日３
            TextBoxProperNote3.Text = ""; // 経験期間３
            /*
             * 賞罰・譴責
             */
            DatePunishmentDate1.SetBlank(); // 実施年月日１
            TextBoxPunishmentNote1.Text = ""; // 内容１
            DatePunishmentDate2.SetBlank(); // 実施年月日２
            TextBoxPunishmentNote2.Text = ""; // 内容２
            DatePunishmentDate3.SetBlank(); // 実施年月日３
            TextBoxPunishmentNote3.Text = ""; // 内容３
            DatePunishmentDate4.SetBlank(); // 実施年月日４
            TextBoxPunishmentNote4.Text = ""; // 内容４
        }

        /*
         * DateTimePicker_ValueChanged
         */
        private void DateTimePicker_ValueChanged(object sender, EventArgs e) {
            //dateTimePicker1の値が変更されたら表示する
            var dateTime = ((DateTimePicker)sender).Value;
            SetDateTimePicker((DateTimePicker)sender, dateTime);
        }

        /*
         * DateTimePicker_KeyDown
         */
        private void DateTimePicker_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyData == Keys.Delete) {
                //Deleteキーが押されたら、dateTimeにnullを設定してdateTimePicker1を非表示に
                SetDateTimePicker((DateTimePicker)sender, null);
            }
        }

        /*
         * SetDateTimePicker
         */
        private void SetDateTimePicker(DateTimePicker dateTimePicker, DateTime? datetime) {
            if(datetime == null || datetime == _defaultDateTime) {
                //DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = " ";
            } else {
                //フォーマットを元に戻して、値をセットする。
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "yyyy年MM月dd日(ddd)";
                dateTimePicker.Value = (DateTime)datetime;
            }
        }

        /*
         * GetDateTimePickerValue
         */
        private DateTime GetDateTimePickerValue(DateTimePicker dateTimePicker) {
            DateTime dateTime;
            if(dateTimePicker.Text != " ") {
                dateTime = dateTimePicker.Value.Date;
            } else {
                dateTime = _defaultDateTime;
            }
            return dateTime;
        }

        /*
         * CheckBoxRetirementFlag_CheckedChanged
         * 2022-02-08
         */
        private void CheckBoxRetirementFlag_CheckedChanged(object sender, EventArgs e) {
            // 解雇・退職の日付と理由の有効・無効化
            DateRetirementDate.Enabled = ((CheckBox)sender).Checked;
            TextBoxRetirementNote.Enabled = ((CheckBox)sender).Checked;
            DateDeathDate.Enabled = ((CheckBox)sender).Checked;
            TextBoxDeathNote.Enabled = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 写真　選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectPicture_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Title = "写真を選択して下さい";//ダイアログのタイトルを指定する
            openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.tif;*.TIF;*.png;*.PNG;";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

            if(openFileDialog.ShowDialog() == DialogResult.OK)
                PictureBoxPicture.ImageLocation = openFileDialog.FileName;//Passをセットする
            openFileDialog.Dispose();// オブジェクトを破棄する
        }

        /// <summary>
        /// 写真　クリップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClipPicture_Click(object sender, EventArgs e) {
            /*
             * クリップボードを転送
             * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
             */
            PictureBoxPicture.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
        }

        /// <summary>
        /// 写真　削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePicture_Click(object sender, EventArgs e) {
            PictureBoxPicture.Image = null;
        }

        /// <summary>
        /// ContextMenuStripTextBoxStaffDbCd_Opening
        /// 採番(StaffCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripTextBoxStaffDbCd_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            if(!_openFlag) // True:新規 False:修正
                ((ContextMenuStrip)sender).Enabled = false;
        }
        private void ToolStripMenuItemNewStaffCode_Click(object sender, EventArgs e) {
            decimal? newStaffCode = null;
            switch((string)((ToolStripMenuItem)sender).Tag) {
                case "社員":
                    newStaffCode = _staffMasterDao.GetStaffCode(19999);
                    newStaffCode++;
                    break;
                case "組合員":
                    newStaffCode = _staffMasterDao.GetStaffCode(29999);
                    newStaffCode++;
                    break;
            }
            TextBoxStaffCode.Text = newStaffCode.ToString();
        }

        /*
         * RadioButtonをクリアする
         */
        private void ToolStripMenuItemRadioButtonClear_Click(object sender, EventArgs e) {
            var groupBox = (GroupBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            foreach(var control in groupBox.Controls) {
                if(control.GetType().Equals(typeof(RadioButton))) {
                    ((RadioButton)control).Checked = false;
                }
            }
        }

        /// <summary>
        /// MedicalExaminationButton_Click
        /// 健康診断項目の入れ替え処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedicalExaminationButton_Click(object sender, EventArgs e) {
            DateTime? baseMedicalExaminationDate;
            string? baseMedicalExaminationNote;

            switch(((Button)sender).Tag) {
                case "2":
                    // 値を退避
                    baseMedicalExaminationDate = DateMedicalExaminationDate1.GetValue();
                    baseMedicalExaminationNote = ComboBoxMedicalExaminationNote1.Text;
                    // 値を移動
                    DateMedicalExaminationDate1.SetValue(DateMedicalExaminationDate2.GetValue());
                    ComboBoxMedicalExaminationNote1.Text = TextBoxMedicalExaminationNote2.Text;
                    // 値を戻す
                    DateMedicalExaminationDate2.SetValue(baseMedicalExaminationDate.Value);
                    TextBoxMedicalExaminationNote2.Text = baseMedicalExaminationNote;
                    break;
                case "3":
                    // 値を退避
                    baseMedicalExaminationDate = DateMedicalExaminationDate2.GetValue();
                    baseMedicalExaminationNote = TextBoxMedicalExaminationNote2.Text;
                    // 値を移動
                    DateMedicalExaminationDate2.SetValue(DateMedicalExaminationDate3.GetValue());
                    TextBoxMedicalExaminationNote2.Text = TextBoxMedicalExaminationNote3.Text;
                    // 値を戻す
                    DateMedicalExaminationDate3.SetValue(baseMedicalExaminationDate.Value);
                    TextBoxMedicalExaminationNote3.Text = baseMedicalExaminationNote;
                    break;
                case "4":
                    // 値を退避
                    baseMedicalExaminationDate = DateMedicalExaminationDate3.GetValue();
                    baseMedicalExaminationNote = TextBoxMedicalExaminationNote3.Text;
                    // 値を移動
                    DateMedicalExaminationDate3.SetValue(DateMedicalExaminationDate4.GetValue());
                    TextBoxMedicalExaminationNote3.Text = TextBoxMedicalExaminationNote4.Text;
                    // 値を戻す
                    DateMedicalExaminationDate4.SetValue(baseMedicalExaminationDate.Value);
                    TextBoxMedicalExaminationNote4.Text = baseMedicalExaminationNote;
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
            Dispose();
        }

        /// <summary>
        /// StaffRegisterDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffRegisterDetail_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
