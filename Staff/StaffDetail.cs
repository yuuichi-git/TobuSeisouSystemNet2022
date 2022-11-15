/*
 * 2022-02-03
 */
using Common;

using Dao;

using Vo;

namespace StaffRegister {
    public partial class StaffDetail : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private readonly StaffMasterDao _staffMasterDao;

        Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 20, "新運転" }, { 21, "自運労" } };
        Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 12, "アルバイト" }, { 99, "" } };
        Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "運転手" }, { 11, "作業員" }, { 99, "" } };

        /// <summary>
        /// True: 新規登録モード False:修正登録モード
        /// </summary>
        private readonly bool _openFlag;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        /// <summary>
        /// ErrorProviderのインスタンスを生成
        /// </summary>
        private ErrorProvider errorProvider = new ErrorProvider();

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
            switch (extendsStaffMasterVo.Belongs) {
                case 10: // 役員
                    RadioButtonOfficer.Checked = true;
                    break;
                case 11: // 社員
                    RadioButtonStaff.Checked = true;
                    break;
                case 12: // アルバイト
                    RadioButtonPart1.Checked = true;
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
            switch (extendsStaffMasterVo.Job_form) {
                case 10: // 長期雇用
                    RadioButtonLongTarm.Checked = true;
                    break;
                case 11: // 手帳
                    RadioButtonNote.Checked = true;
                    break;
                case 12: // アルバイト
                    RadioButtonPart2.Checked = true;
                    break;
            }
            /*
             * 職種
             */
            switch (extendsStaffMasterVo.Occupation) {
                case 10: // 運転手
                    RadioButtonDriver.Checked = true;
                    break;
                case 11: // 作業員
                    RadioButtonOperator.Checked = true;
                    break;
                case 99: // 指定なし
                    RadioButtonNone.Checked = true;
                    break;
            }

            // 個人情報１
            TextBoxStaffDbCd.Text = string.Format("{0:#}", extendsStaffMasterVo.Staff_code); // 社員CD
            TextBoxStaffCd.Text = string.Format("{0:#}", extendsStaffMasterVo.Code); // 組合CD
            TextBoxNameKana.Text = extendsStaffMasterVo.Name_kana; // フリガナ
            TextBoxName.Text = extendsStaffMasterVo.Name; // 氏名
            TextBoxDisplayName.Text = extendsStaffMasterVo.Display_name; // 略称名
            DateBirthDate.Value = extendsStaffMasterVo.Birth_date.Date; // 生年月日
            DateEmploymentDate.Value = extendsStaffMasterVo.Employment_date.Date; // 雇用年月日
            ComboBoxGender.Text = extendsStaffMasterVo.Gender; // 性別
            ComboBoxBloodType.Text = extendsStaffMasterVo.Blood_type; // 血液型
            TextBoxCurrentAddress.Text = extendsStaffMasterVo.Current_address; // 現住所
            TextBoxBeforeChangeAddress.Text = extendsStaffMasterVo.Before_change_address; // 変更後住所
            TextBoxTelephoneNumber.Text = extendsStaffMasterVo.Telephone_number; // 電話番号(自宅)
            TextBoxCellphoneNumber.Text = extendsStaffMasterVo.Cellphone_number; // 電話番号(携帯電話)
            if (extendsStaffMasterVo.Picture.Length == 0) {  // 写真
                PictureBoxPicture.Image = null;
            } else {
                PictureBoxPicture.Image = (Image?)new ImageConverter().ConvertFrom(extendsStaffMasterVo.Picture);
            }
            // 運転に関する情報
            DateSelectionDate.Value = extendsStaffMasterVo.Selection_date; // 運転者に選任された日
            DateNotSelectionDate.Value = extendsStaffMasterVo.Not_selection_date; // 運転者でなくなった日
            TextBoxNotSelectionReason.Text = extendsStaffMasterVo.Not_selection_reason; // 理由
            /*
             * 免許証記録が無ければ処理しない
             */
            if (extendsStaffMasterVo.License_number != "") {
                TextBoxLicenseNumber.Text = extendsStaffMasterVo.License_number; // 免許証番号
                ComboBoxLicenseCondition.Text = extendsStaffMasterVo.LicenseLedgerVo.License_condition; // 条件
                string kind = "";
                if (extendsStaffMasterVo.LicenseLedgerVo.Large)
                    kind += "(大型)";
                if (extendsStaffMasterVo.LicenseLedgerVo.Medium)
                    kind += "(中型)";
                if (extendsStaffMasterVo.LicenseLedgerVo.Quasi_medium)
                    kind += "(準中型)";
                if (extendsStaffMasterVo.LicenseLedgerVo.Ordinary)
                    kind += "(普通)";
                TextBoxLicenseType1.Text = kind; // 免許証の種類１
                DateLicenseTypeDate1.Value = extendsStaffMasterVo.LicenseLedgerVo.Delivery_date; // 免許証の取得日１
                DateLicenseTypeExpirationDate1.Value = extendsStaffMasterVo.LicenseLedgerVo.Expiration_date; // 免許証の有効期限１
            }
            // 履歴
            DateHistoryDate1.Value = extendsStaffMasterVo.History_date_1; // 履歴年月日１
            TextBoxHistoryNote1.Text = extendsStaffMasterVo.History_note_1; // 履歴内容１
            DateHistoryDate2.Value = extendsStaffMasterVo.History_date_2; // 履歴年月日２
            TextBoxHistoryNote2.Text = extendsStaffMasterVo.History_note_2; // 履歴内容２
            DateHistoryDate3.Value = extendsStaffMasterVo.History_date_3; // 履歴年月日３
            TextBoxHistoryNote3.Text = extendsStaffMasterVo.History_note_3; // 履歴内容３
            DateHistoryDate4.Value = extendsStaffMasterVo.History_date_4; // 履歴年月日４
            TextBoxHistoryNote4.Text = extendsStaffMasterVo.History_note_4; // 履歴内容４
            DateHistoryDate5.Value = extendsStaffMasterVo.History_date_5; // 履歴年月日５
            TextBoxHistoryNote5.Text = extendsStaffMasterVo.History_note_5; // 履歴内容５
            DateHistoryDate6.Value = extendsStaffMasterVo.History_date_6; // 履歴年月日６
            TextBoxHistoryNote6.Text = extendsStaffMasterVo.History_note_6; // 履歴内容６
            // 過去に運転経験のある自動車の種類・経験期間等
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
            // 解雇・退職の日付と理由
            CheckBoxRetirementFlag.Checked = extendsStaffMasterVo.Retirement_flag; // 解雇又は退職のフラグ
            DateRetirementDate.Value = extendsStaffMasterVo.Retirement_date; // 解雇又は退職の年月日
            TextBoxRetirementNote.Text = extendsStaffMasterVo.Retirement_note; // 解雇又は退職の理由
            DateDeathDate.Value = extendsStaffMasterVo.Death_date; // 上記理由が死亡の場合その年月日
            TextBoxDeathNote.Text = extendsStaffMasterVo.Death_note; // 上記理由が死亡の場合その原因

            // 家族状況
            TextBoxFamilyName1.Text = extendsStaffMasterVo.Family_name_1; // 家族氏名１
            DateFamilyBirthDate1.Value = extendsStaffMasterVo.Family_birth_date_1; // 生年月日１
            ComboBoxFamilyRelationship1.Text = extendsStaffMasterVo.Family_relationship_1; // 続柄１
            TextBoxFamilyName2.Text = extendsStaffMasterVo.Family_name_2; // 家族氏名２
            DateFamilyBirthDate2.Value = extendsStaffMasterVo.Family_birth_date_2; // 生年月日２
            ComboBoxFamilyRelationship2.Text = extendsStaffMasterVo.Family_relationship_2; // 続柄２
            TextBoxFamilyName3.Text = extendsStaffMasterVo.Family_name_3; // 家族氏名３
            DateFamilyBirthDate3.Value = extendsStaffMasterVo.Family_birth_date_3; // 生年月日３
            ComboBoxFamilyRelationship3.Text = extendsStaffMasterVo.Family_relationship_3; // 続柄３
            TextBoxFamilyName4.Text = extendsStaffMasterVo.Family_name_4; // 家族氏名４
            DateFamilyBirthDate4.Value = extendsStaffMasterVo.Family_birth_date_4; // 生年月日４
            ComboBoxFamilyRelationship4.Text = extendsStaffMasterVo.Family_relationship_4; // 続柄４
            TextBoxFamilyName5.Text = extendsStaffMasterVo.Family_name_5; // 家族氏名５
            DateFamilyBirthDate5.Value = extendsStaffMasterVo.Family_birth_date_5; // 生年月日５
            ComboBoxFamilyRelationship5.Text = extendsStaffMasterVo.Family_relationship_5; // 続柄５
            TextBoxFamilyName6.Text = extendsStaffMasterVo.Family_name_6; // 家族氏名６
            DateFamilyBirthDate6.Value = extendsStaffMasterVo.Family_birth_date_6; // 生年月日６
            ComboBoxFamilyRelationship6.Text = extendsStaffMasterVo.Family_relationship_6; // 続柄６
            TextBoxUrgentTelephoneNumber.Text = extendsStaffMasterVo.Urgent_telephone_number; // 緊急時連絡方法１
            TextBoxUrgentTelephoneMethod.Text = extendsStaffMasterVo.Urgent_telephone_method; // 緊急時連絡方法２
            // 保険関係
            DateHealthInsuranceDate.Value = extendsStaffMasterVo.Health_insurance_date; // (健康保険)加入年月日
            ComboBoxHealthInsuranceNumber.Text = extendsStaffMasterVo.Health_insurance_number; // (健康保険)保険の記号・番号
            TextBoxHealthInsuranceNote.Text = extendsStaffMasterVo.Health_insurance_note; // (健康保険)備考
            DateWelfarePensionDate.Value = extendsStaffMasterVo.Welfare_pension_date; // (厚生年金保険)加入年月日
            TextBoxWelfarePensionNumber.Text = extendsStaffMasterVo.Welfare_pension_number; // (厚生年金保険)保険の記号・番号
            TextBoxWelfarePensionNote.Text = extendsStaffMasterVo.Welfare_pension_note; // (厚生年金保険)備考
            DateEmploymentInsuranceDate.Value = extendsStaffMasterVo.Employment_insurance_date; // (雇用保険)加入年月日
            TextBoxEmploymentInsuranceNumber.Text = extendsStaffMasterVo.Employment_insurance_number; // (雇用保険)保険の記号・番号
            TextBoxEmploymentInsuranceNote.Text = extendsStaffMasterVo.Employment_insurance_note; // (雇用保険)備考
            DateWorkerAccidentInsuranceDate.Value = extendsStaffMasterVo.Worker_accident_insurance_date; // (労災保険)加入年月日
            TextBoxWorkerAccidentInsuranceNumber.Text = extendsStaffMasterVo.Worker_accident_insurance_number; // (労災保険)保険の記号・番号
            TextBoxWorkerAccidentInsuranceNote.Text = extendsStaffMasterVo.Worker_accident_insurance_note; // (労災保険)備考
            // 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
            DateMedicalExaminationDate1.Value = extendsStaffMasterVo.Medical_examination_date_1; // 加入年月日１
            ComboBoxMedicalExaminationNote1.Text = extendsStaffMasterVo.Medical_examination_note_1; // 保険の記号・番号１
            DateMedicalExaminationDate2.Value = extendsStaffMasterVo.Medical_examination_date_2; // 加入年月日２
            TextBoxMedicalExaminationNote2.Text = extendsStaffMasterVo.Medical_examination_note_2; // 保険の記号・番号２
            DateMedicalExaminationDate3.Value = extendsStaffMasterVo.Medical_examination_date_3; // 加入年月日３
            TextBoxMedicalExaminationNote3.Text = extendsStaffMasterVo.Medical_examination_note_3; // 保険の記号・番号３
            DateMedicalExaminationDate4.Value = extendsStaffMasterVo.Medical_examination_date_4; // 加入年月日４
            TextBoxMedicalExaminationNote4.Text = extendsStaffMasterVo.Medical_examination_note_4; // 保険の記号・番号４
            TextBoxMedicalExaminationNote.Text = extendsStaffMasterVo.Medical_examination_note; // 診断以外で気づいた点
            // 業務上の交通違反履歴
            DateCarViolateDate1.Value = extendsStaffMasterVo.Car_violate_date_1; // 発生年月日１
            TextBoxCarViolateContent1.Text = extendsStaffMasterVo.Car_violate_content_1; // 交通違反内容１
            TextBoxCarViolatePlace1.Text = extendsStaffMasterVo.Car_violate_place_1; // 場所１
            DateCarViolateDate2.Value = extendsStaffMasterVo.Car_violate_date_2; // 発生年月日２
            TextBoxCarViolateContent2.Text = extendsStaffMasterVo.Car_violate_content_2; // 交通違反内容２
            TextBoxCarViolatePlace2.Text = extendsStaffMasterVo.Car_violate_place_2; // 場所２
            DateCarViolateDate3.Value = extendsStaffMasterVo.Car_violate_date_3; // 発生年月日３
            TextBoxCarViolateContent3.Text = extendsStaffMasterVo.Car_violate_content_3; // 交通違反内容３
            TextBoxCarViolatePlace3.Text = extendsStaffMasterVo.Car_violate_place_3; // 場所３
            DateCarViolateDate4.Value = extendsStaffMasterVo.Car_violate_date_4; // 発生年月日４
            TextBoxCarViolateContent4.Text = extendsStaffMasterVo.Car_violate_content_4; // 交通違反内容４
            TextBoxCarViolatePlace4.Text = extendsStaffMasterVo.Car_violate_place_4; // 場所４
            DateCarViolateDate5.Value = extendsStaffMasterVo.Car_violate_date_5; // 発生年月日５
            TextBoxCarViolateContent5.Text = extendsStaffMasterVo.Car_violate_content_5; // 交通違反内容５
            TextBoxCarViolatePlace5.Text = extendsStaffMasterVo.Car_violate_place_5; // 場所５
            DateCarViolateDate6.Value = extendsStaffMasterVo.Car_violate_date_6; // 発生年月日６
            TextBoxCarViolateContent6.Text = extendsStaffMasterVo.Car_violate_content_6; // 交通違反内容６
            TextBoxCarViolatePlace6.Text = extendsStaffMasterVo.Car_violate_place_6; // 場所６
            // 社内教育の実施状況
            DateEducateDate1.Value = extendsStaffMasterVo.Educate_date_1; // 実施年月日１
            TextBoxEducateName1.Text = extendsStaffMasterVo.Educate_name_1; // 実施対象理由１
            DateEducateDate2.Value = extendsStaffMasterVo.Educate_date_2; // 実施年月日２
            TextBoxEducateName2.Text = extendsStaffMasterVo.Educate_name_2; // 実施対象理由２
            DateEducateDate3.Value = extendsStaffMasterVo.Educate_date_3; // 実施年月日３
            TextBoxEducateName3.Text = extendsStaffMasterVo.Educate_name_3; // 実施対象理由３
            DateEducateDate4.Value = extendsStaffMasterVo.Educate_date_4; // 実施年月日４
            TextBoxEducateName4.Text = extendsStaffMasterVo.Educate_name_4; // 実施対象理由４
            DateEducateDate5.Value = extendsStaffMasterVo.Educate_date_5; // 実施年月日５
            TextBoxEducateName5.Text = extendsStaffMasterVo.Educate_name_5; // 実施対象理由５
            DateEducateDate6.Value = extendsStaffMasterVo.Educate_date_6; // 実施年月日６
            TextBoxEducateName6.Text = extendsStaffMasterVo.Educate_name_6; // 実施対象理由６
            // 適性診断(NASVA)
            ComboBoxProperKind1.Text = extendsStaffMasterVo.Proper_kind_1; // 種類１
            DateProperDate1.Value = extendsStaffMasterVo.Proper_date_1; // 実施年月日１
            TextBoxProperNote1.Text = extendsStaffMasterVo.Proper_note_1; // 経験期間１
            ComboBoxProperKind2.Text = extendsStaffMasterVo.Proper_kind_2; // 種類２
            DateProperDate2.Value = extendsStaffMasterVo.Proper_date_2; // 実施年月日２
            TextBoxProperNote2.Text = extendsStaffMasterVo.Proper_note_2; // 経験期間２
            ComboBoxProperKind3.Text = extendsStaffMasterVo.Proper_kind_3; // 種類３
            DateProperDate3.Value = extendsStaffMasterVo.Proper_date_3; // 実施年月日３
            TextBoxProperNote3.Text = extendsStaffMasterVo.Proper_note_3; // 経験期間３
            // 賞罰・譴責
            DatePunishmentDate1.Value = extendsStaffMasterVo.Punishment_date_1; // 実施年月日１
            TextBoxPunishmentNote1.Text = extendsStaffMasterVo.Punishment_note_1; // 内容１
            DatePunishmentDate2.Value = extendsStaffMasterVo.Punishment_date_2; // 実施年月日２
            TextBoxPunishmentNote2.Text = extendsStaffMasterVo.Punishment_note_2; // 内容２
            DatePunishmentDate3.Value = extendsStaffMasterVo.Punishment_date_3; // 実施年月日３
            TextBoxPunishmentNote3.Text = extendsStaffMasterVo.Punishment_note_3; // 内容３
            DatePunishmentDate4.Value = extendsStaffMasterVo.Punishment_date_4; // 実施年月日４
            TextBoxPunishmentNote4.Text = extendsStaffMasterVo.Punishment_note_4; // 内容４
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // 入力項目をチェックする
            if (TextBoxStaffDbCd.Text.Length < 1) {
                errorProvider.SetError(TextBoxStaffDbCd, "社員CDを入力して下さい");
                return; // メソッドを出る
            } else {
                // ErrorProviderをクリアします。
                errorProvider.Clear();
            }

            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    // StaffLedgerVoに値をセット
                    var staffLedgerVo = SetStaffMasterVo();
                    // DBを変更(DBにstaff_codeが存在すればUPDATE、無ければINSERT)
                    if (_staffMasterDao.CheckStaffMaster(staffLedgerVo.Staff_code)) {
                        _staffMasterDao.UpdateOneStaffLedger(staffLedgerVo);
                    } else {
                        _staffMasterDao.InsertOneStaffMaster(staffLedgerVo);
                    }
                    Dispose();
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
            // 代入用のインスタンス作成
            var staffMasterVo = new StaffMasterVo();
            /*
             * 役職又は所属
             */



            staffMasterVo.Belongs = ComboBoxBelongs.Text; // 所属名
            staffMasterVo.Vehicle_dispatch_target = CheckBoxTargetFlag.Checked; // 配車の対象になる従事者
            int jobForm = 0; // 「0」には割当ては無い
            if (RadioButtonLongTime.Checked)
                jobForm = 1; // 長期雇用
            if (RadioButtonPartTime.Checked)
                jobForm = 2; // アルバイト
            if (RadioButtonContact.Checked)
                jobForm = 3; // 連絡が必要な従事者
            if (RadioButtonEmployee.Checked)
                jobForm = 4; // 社員
            staffMasterVo.Job_form = jobForm;
            // 雇用形態
            staffMasterVo.Driver = RadioButtonDriver.Checked;
            staffMasterVo.Operator = RadioButtonOperator.Checked;
            // 職種
            if (RadioButtonTypeOfJob1.Checked)
                staffMasterVo.Type_of_job_1 = true;
            if (RadioButtonTypeOfJob2.Checked)
                staffMasterVo.Type_of_job_2 = true;
            if (RadioButtonTypeOfJob3.Checked)
                staffMasterVo.Type_of_job_3 = true;
            if (RadioButtonTypeOfJob4.Checked)
                staffMasterVo.Type_of_job_4 = true;
            if (RadioButtonTypeOfJob5.Checked)
                staffMasterVo.Type_of_job_5 = true;
            if (RadioButtonTypeOfJob6.Checked)
                staffMasterVo.Type_of_job_6 = true;
            // 個人情報１
            staffMasterVo.Staff_code = int.Parse(TextBoxStaffDbCd.Text); // 社員CD
            staffMasterVo.Code = TextBoxStaffCd.Text != "" ? int.Parse(TextBoxStaffCd.Text) : 0; // 組合CD
            staffMasterVo.Name_kana = TextBoxNameKana.Text; // フリガナ
            staffMasterVo.Name = TextBoxName.Text; // 氏名
            staffMasterVo.Display_name = TextBoxDisplayName.Text; // 略称名
            staffMasterVo.Birth_date = GetDateTimePickerValue(DateBirthDate); // 生年月日
            staffMasterVo.Employment_date = GetDateTimePickerValue(DateEmploymentDate); // 雇用年月日
            staffMasterVo.Gender = ComboBoxGender.Text; // 性別
            staffMasterVo.Blood_type = ComboBoxBloodType.Text; // 血液型
            staffMasterVo.Current_address = TextBoxCurrentAddress.Text; // 現住所
            staffMasterVo.Before_change_address = TextBoxBeforeChangeAddress.Text; // 変更後住所
            staffMasterVo.Telephone_number = TextBoxTelephoneNumber.Text; // 電話番号(自宅)
            staffMasterVo.Cellphone_number = TextBoxCellphoneNumber.Text; // 電話番号(携帯電話)
            staffMasterVo.Picture = (byte[]?)new ImageConverter().ConvertTo(PictureBoxPicture.Image, typeof(byte[])); // 写真
            // 運転に関する情報
            staffMasterVo.Selection_date = GetDateTimePickerValue(DateSelectionDate); // 運転者に選任された日
            staffMasterVo.Not_selection_date = GetDateTimePickerValue(DateNotSelectionDate); // 運転者でなくなった日
            staffMasterVo.Not_selection_reason = TextBoxNotSelectionReason.Text; // 理由
            staffMasterVo.License_number = TextBoxLicenseNumber.Text; // 免許証番号
                                                                      // 履歴
            staffMasterVo.History_date_1 = GetDateTimePickerValue(DateHistoryDate1); // 履歴年月日１
            staffMasterVo.History_note_1 = TextBoxHistoryNote1.Text; // 履歴内容１
            staffMasterVo.History_date_2 = GetDateTimePickerValue(DateHistoryDate2); // 履歴年月日２
            staffMasterVo.History_note_2 = TextBoxHistoryNote2.Text; // 履歴内容２
            staffMasterVo.History_date_3 = GetDateTimePickerValue(DateHistoryDate3); // 履歴年月日３
            staffMasterVo.History_note_3 = TextBoxHistoryNote3.Text; // 履歴内容３
            staffMasterVo.History_date_4 = GetDateTimePickerValue(DateHistoryDate4); // 履歴年月日４
            staffMasterVo.History_note_4 = TextBoxHistoryNote4.Text; // 履歴内容４
            staffMasterVo.History_date_5 = GetDateTimePickerValue(DateHistoryDate5); // 履歴年月日５
            staffMasterVo.History_note_5 = TextBoxHistoryNote5.Text; // 履歴内容５
            staffMasterVo.History_date_6 = GetDateTimePickerValue(DateHistoryDate6); // 履歴年月日６
            staffMasterVo.History_note_6 = TextBoxHistoryNote6.Text; // 履歴内容６
                                                                     // 過去に運転経験のある自動車の種類・経験期間等
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
                                                                           // 解雇・退職の日付と理由
            staffMasterVo.Retirement_flag = CheckBoxRetirementFlag.Checked; // 解雇又は退職のフラグ
            staffMasterVo.Retirement_date = GetDateTimePickerValue(DateRetirementDate); // 解雇又は退職の年月日
            staffMasterVo.Retirement_note = TextBoxRetirementNote.Text; // 解雇又は退職の理由
            staffMasterVo.Death_date = GetDateTimePickerValue(DateDeathDate); // 上記理由が死亡の場合その年月日
            staffMasterVo.Death_note = TextBoxDeathNote.Text; // 上記理由が死亡の場合その原因

            // 家族状況
            staffMasterVo.Family_name_1 = TextBoxFamilyName1.Text; // 家族氏名１
            staffMasterVo.Family_birth_date_1 = GetDateTimePickerValue(DateFamilyBirthDate1); // 生年月日１
            staffMasterVo.Family_relationship_1 = ComboBoxFamilyRelationship1.Text; // 続柄１
            staffMasterVo.Family_name_2 = TextBoxFamilyName2.Text; // 家族氏名２
            staffMasterVo.Family_birth_date_2 = GetDateTimePickerValue(DateFamilyBirthDate2); // 生年月日２
            staffMasterVo.Family_relationship_2 = ComboBoxFamilyRelationship2.Text; // 続柄２
            staffMasterVo.Family_name_3 = TextBoxFamilyName3.Text; // 家族氏名３
            staffMasterVo.Family_birth_date_3 = GetDateTimePickerValue(DateFamilyBirthDate3); // 生年月日３
            staffMasterVo.Family_relationship_3 = ComboBoxFamilyRelationship3.Text; // 続柄３
            staffMasterVo.Family_name_4 = TextBoxFamilyName4.Text; // 家族氏名４
            staffMasterVo.Family_birth_date_4 = GetDateTimePickerValue(DateFamilyBirthDate4); // 生年月日４
            staffMasterVo.Family_relationship_4 = ComboBoxFamilyRelationship4.Text; // 続柄４
            staffMasterVo.Family_name_5 = TextBoxFamilyName5.Text; // 家族氏名５
            staffMasterVo.Family_birth_date_5 = GetDateTimePickerValue(DateFamilyBirthDate5); // 生年月日５
            staffMasterVo.Family_relationship_5 = ComboBoxFamilyRelationship5.Text; // 続柄５
            staffMasterVo.Family_name_6 = TextBoxFamilyName6.Text; // 家族氏名６
            staffMasterVo.Family_birth_date_6 = GetDateTimePickerValue(DateFamilyBirthDate6); // 生年月日６
            staffMasterVo.Family_relationship_6 = ComboBoxFamilyRelationship6.Text; // 続柄６
            staffMasterVo.Urgent_telephone_number = TextBoxUrgentTelephoneNumber.Text; // 緊急時連絡方法１
            staffMasterVo.Urgent_telephone_method = TextBoxUrgentTelephoneMethod.Text; // 緊急時連絡方法２
                                                                                       // 保険関係
            staffMasterVo.Health_insurance_date = GetDateTimePickerValue(DateHealthInsuranceDate); // (健康保険)加入年月日
            staffMasterVo.Health_insurance_number = ComboBoxHealthInsuranceNumber.Text; // (健康保険)保険の記号・番号
            staffMasterVo.Health_insurance_note = TextBoxHealthInsuranceNote.Text; // (健康保険)備考
            staffMasterVo.Welfare_pension_date = GetDateTimePickerValue(DateWelfarePensionDate); // (厚生年金保険)加入年月日
            staffMasterVo.Welfare_pension_number = TextBoxWelfarePensionNumber.Text; // (厚生年金保険)保険の記号・番号
            staffMasterVo.Welfare_pension_note = TextBoxWelfarePensionNote.Text; // (厚生年金保険)備考
            staffMasterVo.Employment_insurance_date = GetDateTimePickerValue(DateEmploymentInsuranceDate); // (雇用保険)加入年月日
            staffMasterVo.Employment_insurance_number = TextBoxEmploymentInsuranceNumber.Text; // (雇用保険)保険の記号・番号
            staffMasterVo.Employment_insurance_note = TextBoxEmploymentInsuranceNote.Text; // (雇用保険)備考
            staffMasterVo.Worker_accident_insurance_date = GetDateTimePickerValue(DateWorkerAccidentInsuranceDate); // (労災保険)加入年月日
            staffMasterVo.Worker_accident_insurance_number = TextBoxWorkerAccidentInsuranceNumber.Text; // (労災保険)保険の記号・番号
            staffMasterVo.Worker_accident_insurance_note = TextBoxWorkerAccidentInsuranceNote.Text; // (労災保険)備考
                                                                                                    // 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
            staffMasterVo.Medical_examination_date_1 = GetDateTimePickerValue(DateMedicalExaminationDate1); // 加入年月日１
            staffMasterVo.Medical_examination_note_1 = ComboBoxMedicalExaminationNote1.Text; // 保険の記号・番号１
            staffMasterVo.Medical_examination_date_2 = GetDateTimePickerValue(DateMedicalExaminationDate2); // 加入年月日２
            staffMasterVo.Medical_examination_note_2 = TextBoxMedicalExaminationNote2.Text; // 保険の記号・番号２
            staffMasterVo.Medical_examination_date_3 = GetDateTimePickerValue(DateMedicalExaminationDate3); // 加入年月日３
            staffMasterVo.Medical_examination_note_3 = TextBoxMedicalExaminationNote3.Text; // 保険の記号・番号３
            staffMasterVo.Medical_examination_date_4 = GetDateTimePickerValue(DateMedicalExaminationDate4); // 加入年月日４
            staffMasterVo.Medical_examination_note_4 = TextBoxMedicalExaminationNote4.Text; // 保険の記号・番号４
            staffMasterVo.Medical_examination_note = TextBoxMedicalExaminationNote.Text; // 診断以外で気づいた点
                                                                                         // 業務上の交通違反履歴
            staffMasterVo.Car_violate_date_1 = GetDateTimePickerValue(DateCarViolateDate1); // 発生年月日１
            staffMasterVo.Car_violate_content_1 = TextBoxCarViolateContent1.Text; // 交通違反内容１
            staffMasterVo.Car_violate_place_1 = TextBoxCarViolatePlace1.Text; // 場所１
            staffMasterVo.Car_violate_date_2 = GetDateTimePickerValue(DateCarViolateDate2); // 発生年月日２
            staffMasterVo.Car_violate_content_2 = TextBoxCarViolateContent2.Text; // 交通違反内容２
            staffMasterVo.Car_violate_place_2 = TextBoxCarViolatePlace2.Text; // 場所２
            staffMasterVo.Car_violate_date_3 = GetDateTimePickerValue(DateCarViolateDate3); // 発生年月日３
            staffMasterVo.Car_violate_content_3 = TextBoxCarViolateContent3.Text; // 交通違反内容３
            staffMasterVo.Car_violate_place_3 = TextBoxCarViolatePlace3.Text; // 場所３
            staffMasterVo.Car_violate_date_4 = GetDateTimePickerValue(DateCarViolateDate4); // 発生年月日４
            staffMasterVo.Car_violate_content_4 = TextBoxCarViolateContent4.Text; // 交通違反内容４
            staffMasterVo.Car_violate_place_4 = TextBoxCarViolatePlace4.Text; // 場所４
            staffMasterVo.Car_violate_date_5 = GetDateTimePickerValue(DateCarViolateDate5); // 発生年月日５
            staffMasterVo.Car_violate_content_5 = TextBoxCarViolateContent5.Text; // 交通違反内容５
            staffMasterVo.Car_violate_place_5 = TextBoxCarViolatePlace5.Text; // 場所５
            staffMasterVo.Car_violate_date_6 = GetDateTimePickerValue(DateCarViolateDate6); // 発生年月日６
            staffMasterVo.Car_violate_content_6 = TextBoxCarViolateContent6.Text; // 交通違反内容６
            staffMasterVo.Car_violate_place_6 = TextBoxCarViolatePlace6.Text; // 場所６
                                                                              // 社内教育の実施状況
            staffMasterVo.Educate_date_1 = GetDateTimePickerValue(DateEducateDate1); // 実施年月日１
            staffMasterVo.Educate_name_1 = TextBoxEducateName1.Text; // 実施対象理由１
            staffMasterVo.Educate_date_2 = GetDateTimePickerValue(DateEducateDate2); // 実施年月日２
            staffMasterVo.Educate_name_2 = TextBoxEducateName2.Text; // 実施対象理由２
            staffMasterVo.Educate_date_3 = GetDateTimePickerValue(DateEducateDate3); // 実施年月日３
            staffMasterVo.Educate_name_3 = TextBoxEducateName3.Text; // 実施対象理由３
            staffMasterVo.Educate_date_4 = GetDateTimePickerValue(DateEducateDate4); // 実施年月日４
            staffMasterVo.Educate_name_4 = TextBoxEducateName4.Text; // 実施対象理由４
            staffMasterVo.Educate_date_5 = GetDateTimePickerValue(DateEducateDate5); // 実施年月日５
            staffMasterVo.Educate_name_5 = TextBoxEducateName5.Text; // 実施対象理由５
            staffMasterVo.Educate_date_6 = GetDateTimePickerValue(DateEducateDate6); // 実施年月日６
            staffMasterVo.Educate_name_6 = TextBoxEducateName6.Text; // 実施対象理由６
                                                                     // 適性診断(NASVA)
            staffMasterVo.Proper_kind_1 = ComboBoxProperKind1.Text; // 種類１
            staffMasterVo.Proper_date_1 = GetDateTimePickerValue(DateProperDate1); // 実施年月日１
            staffMasterVo.Proper_note_1 = TextBoxProperNote1.Text; // 経験期間１
            staffMasterVo.Proper_kind_2 = ComboBoxProperKind2.Text; // 種類２
            staffMasterVo.Proper_date_2 = GetDateTimePickerValue(DateProperDate2); // 実施年月日２
            staffMasterVo.Proper_note_2 = TextBoxProperNote2.Text; // 経験期間２
            staffMasterVo.Proper_kind_3 = ComboBoxProperKind3.Text; // 種類３
            staffMasterVo.Proper_date_3 = GetDateTimePickerValue(DateProperDate3); // 実施年月日３
            staffMasterVo.Proper_note_3 = TextBoxProperNote3.Text; // 経験期間３
                                                                   // 賞罰・譴責
            staffMasterVo.Punishment_date_1 = GetDateTimePickerValue(DatePunishmentDate1); // 実施年月日１
            staffMasterVo.Punishment_note_1 = TextBoxPunishmentNote1.Text; // 内容１
            staffMasterVo.Punishment_date_2 = GetDateTimePickerValue(DatePunishmentDate2); // 実施年月日２
            staffMasterVo.Punishment_note_2 = TextBoxPunishmentNote2.Text; // 内容２
            staffMasterVo.Punishment_date_3 = GetDateTimePickerValue(DatePunishmentDate3); // 実施年月日３
            staffMasterVo.Punishment_note_3 = TextBoxPunishmentNote3.Text; // 内容３
            staffMasterVo.Punishment_date_4 = GetDateTimePickerValue(DatePunishmentDate4); // 実施年月日４
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
             */
            // 所属・勤務形態
            ComboBoxBelongs.SelectedIndex = 0; // 所属名
            CheckBoxTargetFlag.Checked = true; // 配車の対象になる従事者
                                               // 業務区分(組合員・アルバイト)
                                               // 業務区分(社員)
                                               // 個人情報１
            TextBoxStaffDbCd.Text = ""; // 社員CD
            TextBoxStaffCd.Text = ""; // 組合CD
            TextBoxNameKana.Text = ""; // フリガナ
            TextBoxName.Text = ""; // 氏名
            TextBoxDisplayName.Text = ""; // 略称名
            SetDateTimePicker(DateBirthDate, null); // 生年月日
            SetDateTimePicker(DateEmploymentDate, null); // 雇用年月日
            ComboBoxGender.SelectedIndex = 0; // 性別
                                              // 血液型
            TextBoxCurrentAddress.Text = ""; // 現住所
            TextBoxBeforeChangeAddress.Text = ""; // 変更後住所
            TextBoxTelephoneNumber.Text = ""; // 電話番号(自宅)
            TextBoxCellphoneNumber.Text = ""; // 電話番号(携帯電話)
            PictureBoxPicture.Image = null; // 写真
                                            // 運転に関する情報
            SetDateTimePicker(DateSelectionDate, null); // 運転者に選任された日
            SetDateTimePicker(DateNotSelectionDate, null); // 運転者でなくなった日
            TextBoxNotSelectionReason.Text = ""; // 理由
            TextBoxLicenseNumber.Text = ""; // 免許証番号
            ComboBoxLicenseCondition.SelectedIndex = -1; // 条件
            TextBoxLicenseType1.Text = ""; // 免許証の種類１
            SetDateTimePicker(DateLicenseTypeDate1, null); // 免許証の取得日１
            SetDateTimePicker(DateLicenseTypeExpirationDate1, null); // 免許証の有効期限１
            TextBoxLicenseType2.Text = ""; // 免許証の種類２
            SetDateTimePicker(DateLicenseTypeDate2, null); // 免許証の取得日２
            SetDateTimePicker(DateLicenseTypeExpirationDate2, null); // 免許証の有効期限２
            TextBoxLicenseType3.Text = ""; // 免許証の種類３
            SetDateTimePicker(DateLicenseTypeDate3, null); // 免許証の取得日３
            SetDateTimePicker(DateLicenseTypeExpirationDate3, null); // 免許証の有効期限３
            TextBoxLicenseType4.Text = ""; // 免許証の種類４
            SetDateTimePicker(DateLicenseTypeDate4, null); // 免許証の取得日４
            SetDateTimePicker(DateLicenseTypeExpirationDate4, null); // 免許証の有効期限４
            TextBoxLicenseType5.Text = ""; // 免許証の種類５
            SetDateTimePicker(DateLicenseTypeDate5, null); // 免許証の取得日５
            SetDateTimePicker(DateLicenseTypeExpirationDate5, null); // 免許証の有効期限５
                                                                     // 履歴
            SetDateTimePicker(DateHistoryDate1, null); // 履歴年月日１
            TextBoxHistoryNote1.Text = ""; // 履歴内容１
            SetDateTimePicker(DateHistoryDate2, null); // 履歴年月日２
            TextBoxHistoryNote2.Text = ""; // 履歴内容２
            SetDateTimePicker(DateHistoryDate3, null); // 履歴年月日３
            TextBoxHistoryNote3.Text = ""; // 履歴内容３
            SetDateTimePicker(DateHistoryDate4, null); // 履歴年月日４
            TextBoxHistoryNote4.Text = ""; // 履歴内容４
            SetDateTimePicker(DateHistoryDate5, null); // 履歴年月日５
            TextBoxHistoryNote5.Text = ""; // 履歴内容５
            SetDateTimePicker(DateHistoryDate6, null); // 履歴年月日６
            TextBoxHistoryNote6.Text = ""; // 履歴内容６
                                           // 過去に運転経験のある自動車の種類・経験期間等
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
                                              // 解雇・退職の日付と理由
            CheckBoxRetirementFlag.Checked = false; // 解雇又は退職のフラグ
            SetDateTimePicker(DateRetirementDate, null); // 解雇又は退職の年月日
            TextBoxRetirementNote.Text = ""; // 解雇又は退職の理由
            SetDateTimePicker(DateDeathDate, null); // 上記理由が死亡の場合その年月日
            TextBoxDeathNote.Text = ""; // 上記理由が死亡の場合その原因
            // 家族状況
            TextBoxFamilyName1.Text = ""; // 家族氏名１
            SetDateTimePicker(DateFamilyBirthDate1, null); // 生年月日１
            ComboBoxFamilyRelationship1.SelectedIndex = -1; // 続柄１
            TextBoxFamilyName2.Text = ""; // 家族氏名２
            SetDateTimePicker(DateFamilyBirthDate2, null); // 生年月日２
            ComboBoxFamilyRelationship2.SelectedIndex = -1; // 続柄２
            TextBoxFamilyName3.Text = ""; // 家族氏名３
            SetDateTimePicker(DateFamilyBirthDate3, null); // 生年月日３
            ComboBoxFamilyRelationship3.SelectedIndex = -1; // 続柄３
            TextBoxFamilyName4.Text = ""; // 家族氏名４
            SetDateTimePicker(DateFamilyBirthDate4, null); // 生年月日４
            ComboBoxFamilyRelationship4.SelectedIndex = -1; // 続柄４
            TextBoxFamilyName5.Text = ""; // 家族氏名５
            SetDateTimePicker(DateFamilyBirthDate5, null); // 生年月日５
            ComboBoxFamilyRelationship5.SelectedIndex = -1; // 続柄５
            TextBoxFamilyName6.Text = ""; // 家族氏名６
            SetDateTimePicker(DateFamilyBirthDate6, null); // 生年月日６
            ComboBoxFamilyRelationship6.SelectedIndex = -1; // 続柄６
            TextBoxUrgentTelephoneNumber.Text = ""; // 緊急時連絡方法１
            TextBoxUrgentTelephoneMethod.Text = ""; // 緊急時連絡方法２
            // 保険関係
            SetDateTimePicker(DateHealthInsuranceDate, null); // (健康保険)加入年月日
            ComboBoxHealthInsuranceNumber.SelectedIndex = -1; // (健康保険)保険の記号・番号
            TextBoxHealthInsuranceNote.Text = ""; // (健康保険)備考
            SetDateTimePicker(DateWelfarePensionDate, null); // (厚生年金保険)加入年月日
            TextBoxWelfarePensionNumber.Text = ""; // (厚生年金保険)保険の記号・番号
            TextBoxWelfarePensionNote.Text = ""; // (厚生年金保険)備考
            SetDateTimePicker(DateEmploymentInsuranceDate, null); // (雇用保険)加入年月日
            TextBoxEmploymentInsuranceNumber.Text = ""; // (雇用保険)保険の記号・番号
            TextBoxEmploymentInsuranceNote.Text = ""; // (雇用保険)備考
            SetDateTimePicker(DateWorkerAccidentInsuranceDate, null); // (労災保険)加入年月日
            TextBoxWorkerAccidentInsuranceNumber.Text = ""; // (労災保険)保険の記号・番号
            TextBoxWorkerAccidentInsuranceNote.Text = ""; // (労災保険)備考
            // 健康状態(健康診断等の実施結果による特記すべき事項)　※運転の可否に十分に留意すること
            SetDateTimePicker(DateMedicalExaminationDate1, null); // 加入年月日１
            ComboBoxMedicalExaminationNote1.SelectedIndex = -1; // 保険の記号・番号１
            SetDateTimePicker(DateMedicalExaminationDate2, null); // 加入年月日２
            TextBoxMedicalExaminationNote2.Text = ""; // 保険の記号・番号２
            SetDateTimePicker(DateMedicalExaminationDate3, null); // 加入年月日３
            TextBoxMedicalExaminationNote3.Text = ""; // 保険の記号・番号３
            SetDateTimePicker(DateMedicalExaminationDate4, null); // 加入年月日４
            TextBoxMedicalExaminationNote4.Text = ""; // 保険の記号・番号４
            TextBoxMedicalExaminationNote.Text = ""; // 診断以外で気づいた点
            // 業務上の交通違反履歴
            SetDateTimePicker(DateCarViolateDate1, null); // 発生年月日１
            TextBoxCarViolateContent1.Text = ""; // 交通違反内容１
            TextBoxCarViolatePlace1.Text = ""; // 場所１
            SetDateTimePicker(DateCarViolateDate2, null); // 発生年月日２
            TextBoxCarViolateContent2.Text = ""; // 交通違反内容２
            TextBoxCarViolatePlace2.Text = ""; // 場所２
            SetDateTimePicker(DateCarViolateDate3, null); // 発生年月日３
            TextBoxCarViolateContent3.Text = ""; // 交通違反内容３
            TextBoxCarViolatePlace3.Text = ""; // 場所３
            SetDateTimePicker(DateCarViolateDate4, null); // 発生年月日４
            TextBoxCarViolateContent4.Text = ""; // 交通違反内容４
            TextBoxCarViolatePlace4.Text = ""; // 場所４
            SetDateTimePicker(DateCarViolateDate5, null); // 発生年月日５
            TextBoxCarViolateContent5.Text = ""; // 交通違反内容５
            TextBoxCarViolatePlace5.Text = ""; // 場所５
            SetDateTimePicker(DateCarViolateDate6, null); // 発生年月日６
            TextBoxCarViolateContent6.Text = ""; // 交通違反内容６
            TextBoxCarViolatePlace6.Text = ""; // 場所６
            // 社内教育の実施状況
            SetDateTimePicker(DateEducateDate1, null); // 実施年月日１
            TextBoxEducateName1.Text = ""; // 実施対象理由１
            SetDateTimePicker(DateEducateDate2, null); // 実施年月日２
            TextBoxEducateName2.Text = ""; // 実施対象理由２
            SetDateTimePicker(DateEducateDate3, null); // 実施年月日３
            TextBoxEducateName3.Text = ""; // 実施対象理由３
            SetDateTimePicker(DateEducateDate4, null); // 実施年月日４
            TextBoxEducateName4.Text = ""; // 実施対象理由４
            SetDateTimePicker(DateEducateDate5, null); // 実施年月日５
            TextBoxEducateName5.Text = ""; // 実施対象理由５
            SetDateTimePicker(DateEducateDate6, null); // 実施年月日６
            TextBoxEducateName6.Text = ""; // 実施対象理由６
            // 適性診断(NASVA)
            ComboBoxProperKind1.SelectedIndex = -1; // 種類１
            SetDateTimePicker(DateProperDate1, null); // 実施年月日１
            TextBoxProperNote1.Text = ""; // 経験期間１
            ComboBoxProperKind2.SelectedIndex = -1; // 種類２
            SetDateTimePicker(DateProperDate2, null); // 実施年月日２
            TextBoxProperNote2.Text = ""; // 経験期間２
            ComboBoxProperKind3.SelectedIndex = -1; // 種類３
            SetDateTimePicker(DateProperDate3, null); // 実施年月日３
            TextBoxProperNote3.Text = ""; // 経験期間３
            // 賞罰・譴責
            SetDateTimePicker(DatePunishmentDate1, null); // 実施年月日１
            TextBoxPunishmentNote1.Text = ""; // 内容１
            SetDateTimePicker(DatePunishmentDate2, null); // 実施年月日２
            TextBoxPunishmentNote2.Text = ""; // 内容２
            SetDateTimePicker(DatePunishmentDate3, null); // 実施年月日３
            TextBoxPunishmentNote3.Text = ""; // 内容３
            SetDateTimePicker(DatePunishmentDate4, null); // 実施年月日４
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
            if (e.KeyData == Keys.Delete) {
                //Deleteキーが押されたら、dateTimeにnullを設定してdateTimePicker1を非表示に
                SetDateTimePicker((DateTimePicker)sender, null);
            }
        }

        /*
         * SetDateTimePicker
         */
        private void SetDateTimePicker(DateTimePicker dateTimePicker, DateTime? datetime) {
            if (datetime == null || datetime == _defaultDateTime) {
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
            if (dateTimePicker.Text != " ") {
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

            if (openFileDialog.ShowDialog() == DialogResult.OK)
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
            if (!_openFlag) // True:新規 False:修正
                ((ContextMenuStrip)sender).Enabled = false;
        }
        private void ToolStripMenuItemNewStaffCode_Click(object sender, EventArgs e) {
            decimal? newStaffCode = null;
            switch ((string)((ToolStripMenuItem)sender).Tag) {
                case "社員":
                    newStaffCode = _staffMasterDao.GetStaffCode(19999);
                    newStaffCode++;
                    break;
                case "組合員":
                    newStaffCode = _staffMasterDao.GetStaffCode(29999);
                    newStaffCode++;
                    break;
            }
            TextBoxStaffDbCd.Text = newStaffCode.ToString();
        }

        /*
         * RadioButtonをクリアする
         */
        private void ToolStripMenuItemRadioButtonClear_Click(object sender, EventArgs e) {
            var groupBox = (GroupBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            foreach (var control in groupBox.Controls) {
                if (control.GetType().Equals(typeof(RadioButton))) {
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

            switch (((Button)sender).Tag) {
                case "2":
                    // 値を退避
                    baseMedicalExaminationDate = DateMedicalExaminationDate1.Value.Date;
                    baseMedicalExaminationNote = ComboBoxMedicalExaminationNote1.Text;
                    // 値を移動
                    DateMedicalExaminationDate1.Value = DateMedicalExaminationDate2.Value;
                    ComboBoxMedicalExaminationNote1.Text = TextBoxMedicalExaminationNote2.Text;
                    // 値を戻す
                    DateMedicalExaminationDate2.Value = baseMedicalExaminationDate.Value;
                    TextBoxMedicalExaminationNote2.Text = baseMedicalExaminationNote;
                    break;
                case "3":
                    // 値を退避
                    baseMedicalExaminationDate = DateMedicalExaminationDate2.Value.Date;
                    baseMedicalExaminationNote = TextBoxMedicalExaminationNote2.Text;
                    // 値を移動
                    DateMedicalExaminationDate2.Value = DateMedicalExaminationDate3.Value;
                    TextBoxMedicalExaminationNote2.Text = TextBoxMedicalExaminationNote3.Text;
                    // 値を戻す
                    DateMedicalExaminationDate3.Value = baseMedicalExaminationDate.Value;
                    TextBoxMedicalExaminationNote3.Text = baseMedicalExaminationNote;
                    break;
                case "4":
                    // 値を退避
                    baseMedicalExaminationDate = DateMedicalExaminationDate3.Value.Date;
                    baseMedicalExaminationNote = TextBoxMedicalExaminationNote3.Text;
                    // 値を移動
                    DateMedicalExaminationDate3.Value = DateMedicalExaminationDate4.Value;
                    TextBoxMedicalExaminationNote3.Text = TextBoxMedicalExaminationNote4.Text;
                    // 値を戻す
                    DateMedicalExaminationDate4.Value = baseMedicalExaminationDate.Value;
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
        }

        /// <summary>
        /// StaffRegisterDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffRegisterDetail_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
