/*
 * 2023-10-31
 */
namespace Vo {
    /*
     * DeepCopyで使用
     */
    [Serializable] // ←DeepCopyする場合には必要
    public class H_StaffMasterVo {
        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);

        private int _staffCode;
        private int _unionCode;
        private int _belongs;
        private bool _vehicleDispatchTarget;
        private int _jobForm;
        private int _occupation;
        private string _nameKana;
        private string _name;
        private string _displayName;
        private string _otherNameKana;
        private string _otherName;
        private string _gender;
        private DateTime _birthDate;
        private DateTime _employmentDate;
        private string _currentAddress;
        private string _beforeChangeAddress;
        private string _remarks;
        private string _telephoneNumber;
        private string _cellphoneNumber;
        private byte[] _picture;
        private string _bloodType;
        private DateTime _selectionDate;
        private DateTime _notSelectionDate;
        private string _notSelectionReason;
        private H_LicenseMasterVo _hLicenseMasterVo;
        private List<H_StaffHistoryVo> _listHStaffHistoryVo;
        private List<H_StaffExperienceVo> _listHStaffExperienceVo;
        private bool _retirementFlag;
        private DateTime _retirementDate;
        private string _retirementNote;
        private DateTime _deathDate;
        private string _deathNote;
        private List<H_StaffFamilyVo> _listHStaffFamilyVo;
        private string _urgentTelephoneNumber;
        private string _urgentTelephoneMethod;
        private DateTime _healthInsuranceDate;
        private string _healthInsuranceNumber;
        private string _healthInsuranceNote;
        private DateTime _welfarePensionDate;
        private string _welfarePensionNumber;
        private string _welfarePensionNote;
        private DateTime _employmentInsuranceDate;
        private string _employmentInsuranceNumber;
        private string _employmentInsuranceNote;
        private DateTime _workerAccidentInsuranceDate;
        private string _workerAccidentInsuranceNumber;
        private string _workerAccidentInsuranceNote;
        private List<H_StaffMedicalExaminationVo> _listHStaffMedicalExaminationVo;
        private List<H_StaffCarViolateVo> _listHStaffCarViolateVo;
        private List<H_StaffEducateVo> _listHStaffEducateVo;
        private List<H_StaffProperVo> _listHStaffProperVo;
        private List<H_StaffPunishmentVo> _listHStaffPunishmentVo;
        private string _insertPcName;
        private DateTime _insertYmdHms;
        private string _updatePcName;
        private DateTime _updateYmdHms;
        private string _deletePcName;
        private DateTime _deleteYmdHms;
        private bool _deleteFlag;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_StaffMasterVo() {
            _staffCode = 0;
            _unionCode = 0;
            _belongs = 0;
            _vehicleDispatchTarget = false;
            _jobForm = 0;
            _occupation = 0;
            _nameKana = string.Empty;
            _name = string.Empty;
            _otherNameKana = string.Empty;
            _otherName = string.Empty;
            _displayName = string.Empty;
            _gender = string.Empty;
            _birthDate = _defaultDateTime;
            _employmentDate = _defaultDateTime;
            _currentAddress = string.Empty;
            _beforeChangeAddress = string.Empty;
            _remarks = string.Empty;
            _telephoneNumber = string.Empty;
            _cellphoneNumber = string.Empty;
            _picture = Array.Empty<byte>();
            _bloodType = string.Empty;
            _selectionDate = _defaultDateTime;
            _notSelectionDate = _defaultDateTime;
            _notSelectionReason = string.Empty;
            _hLicenseMasterVo = new H_LicenseMasterVo();
            _listHStaffHistoryVo = new List<H_StaffHistoryVo>();
            _listHStaffExperienceVo = new List<H_StaffExperienceVo>();
            _retirementFlag = false;
            _retirementDate = _defaultDateTime;
            _retirementNote = string.Empty;
            _deathDate = _defaultDateTime;
            _deathNote = string.Empty;
            _listHStaffFamilyVo = new List<H_StaffFamilyVo>();
            _urgentTelephoneNumber = string.Empty;
            _urgentTelephoneMethod = string.Empty;
            _healthInsuranceDate = _defaultDateTime;
            _healthInsuranceNumber = string.Empty;
            _healthInsuranceNote = string.Empty;
            _welfarePensionDate = _defaultDateTime;
            _welfarePensionNumber = string.Empty;
            _welfarePensionNote = string.Empty;
            _employmentInsuranceDate = _defaultDateTime;
            _employmentInsuranceNumber = string.Empty;
            _employmentInsuranceNote = string.Empty;
            _workerAccidentInsuranceDate = _defaultDateTime;
            _workerAccidentInsuranceNumber = string.Empty;
            _workerAccidentInsuranceNote = string.Empty;
            _listHStaffMedicalExaminationVo = new List<H_StaffMedicalExaminationVo>();
            _listHStaffCarViolateVo = new List<H_StaffCarViolateVo>();
            _listHStaffEducateVo = new List<H_StaffEducateVo>();
            _listHStaffProperVo = new List<H_StaffProperVo>();
            _listHStaffPunishmentVo = new List<H_StaffPunishmentVo>();
            _insertPcName = string.Empty;
            _insertYmdHms = _defaultDateTime;
            _updatePcName = string.Empty;
            _updateYmdHms = _defaultDateTime;
            _deletePcName = string.Empty;
            _deleteYmdHms = _defaultDateTime;
            _deleteFlag = false;
        }

        /// <summary>
        /// 従業員コード
        /// </summary>
        public int StaffCode {
            get => _staffCode;
            set => _staffCode = value;
        }
        /// <summary>
        /// 組合コード
        /// </summary>
        public int UnionCode {
            get => _unionCode;
            set => _unionCode = value;
        }
        /// <summary>
        /// 所属
        /// 10:役員 11:社員 12:アルバイト 13:派遣 20:新運転 21:自運労
        /// </summary>
        public int Belongs {
            get => _belongs;
            set => _belongs = value;
        }
        /// <summary>
        /// 配車の対象かどうか
        /// true:対象 false:非対象
        /// </summary>
        public bool VehicleDispatchTarget {
            get => _vehicleDispatchTarget;
            set => _vehicleDispatchTarget = value;
        }
        /// <summary>
        /// 雇用形態
        /// 10:長期雇用 11:手帳 99:指定なし
        /// </summary>
        public int JobForm {
            get => _jobForm;
            set => _jobForm = value;
        }
        /// <summary>
        /// 職種
        /// 10:運転手 11:作業員 20:事務職 99:指定なし
        /// </summary>
        public int Occupation {
            get => _occupation;
            set => _occupation = value;
        }
        /// <summary>
        /// 氏名カナ
        /// </summary>
        public string NameKana {
            get => _nameKana;
            set => _nameKana = value;
        }
        /// <summary>
        /// 氏名
        /// </summary>
        public string Name {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// 健康診断用の表記
        /// </summary>
        public string OtherNameKana {
            get => _otherNameKana;
            set => _otherNameKana = value;
        }
        /// <summary>
        /// 健康診断用の表記
        /// </summary>
        public string OtherName {
            get => _otherName;
            set => _otherName = value;
        }
        /// <summary>
        /// 画面表示・配車表用氏名
        /// 全角６文字以内
        /// </summary>
        public string DisplayName {
            get => _displayName;
            set => _displayName = value;
        }
        /// <summary>
        /// 性別
        /// </summary>
        public string Gender {
            get => _gender;
            set => _gender = value;
        }
        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime BirthDate {
            get => _birthDate;
            set => _birthDate = value;
        }
        /// <summary>
        /// 雇用年月日
        /// アルバイト開始日又は長期雇用開始日
        /// </summary>
        public DateTime EmploymentDate {
            get => _employmentDate;
            set => _employmentDate = value;
        }
        /// <summary>
        /// 現住所
        /// </summary>
        public string CurrentAddress {
            get => _currentAddress;
            set => _currentAddress = value;
        }
        /// <summary>
        /// 変更前住所
        /// </summary>
        public string BeforeChangeAddress {
            get => _beforeChangeAddress;
            set => _beforeChangeAddress = value;
        }
        /// <summary>
        /// その他備考
        /// </summary>
        public string Remarks {
            get => _remarks;
            set => _remarks = value;
        }
        /// <summary>
        /// 電話番号
        /// </summary>
        public string TelephoneNumber {
            get => _telephoneNumber;
            set => _telephoneNumber = value;
        }
        /// <summary>
        /// 携帯番号
        /// </summary>
        public string CellphoneNumber {
            get => _cellphoneNumber;
            set => _cellphoneNumber = value;
        }
        /// <summary>
        /// 写真
        /// </summary>
        public byte[] Picture {
            get => _picture;
            set => _picture = value;
        }
        /// <summary>
        /// 血液型
        /// </summary>
        public string BloodType {
            get => _bloodType;
            set => _bloodType = value;
        }
        /// <summary>
        /// 運転手として選任された日
        /// </summary>
        public DateTime SelectionDate {
            get => _selectionDate;
            set => _selectionDate = value;
        }
        /// <summary>
        /// 運転手として選任されなっくなった日
        /// </summary>
        public DateTime NotSelectionDate {
            get => _notSelectionDate;
            set => _notSelectionDate = value;
        }
        /// <summary>
        /// 選任されなくなった理由
        /// </summary>
        public string NotSelectionReason {
            get => _notSelectionReason;
            set => _notSelectionReason = value;
        }
        /// <summary>
        /// 免許証番号
        /// </summary>
        public H_LicenseMasterVo HLicenseMasterVo {
            get => _hLicenseMasterVo;
            set => _hLicenseMasterVo = value;
        }
        /// <summary>
        /// 職業履歴
        /// </summary>
        public List<H_StaffHistoryVo> ListHStaffHistoryVo {
            get => _listHStaffHistoryVo;
            set => _listHStaffHistoryVo = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車
        /// </summary>
        public List<H_StaffExperienceVo> ListHStaffExperienceVo {
            get => _listHStaffExperienceVo;
            set => _listHStaffExperienceVo = value;
        }
        /// <summary>
        /// 退職フラグ
        /// </summary>
        public bool RetirementFlag {
            get => _retirementFlag;
            set => _retirementFlag = value;
        }
        /// <summary>
        /// 退職日
        /// </summary>
        public DateTime RetirementDate {
            get => _retirementDate;
            set => _retirementDate = value;
        }
        /// <summary>
        /// 退職理由
        /// </summary>
        public string RetirementNote {
            get => _retirementNote;
            set => _retirementNote = value;
        }
        /// <summary>
        /// 死亡日
        /// </summary>
        public DateTime DeathDate {
            get => _deathDate;
            set => _deathDate = value;
        }
        /// <summary>
        /// 死亡理由
        /// </summary>
        public string DeathNote {
            get => _deathNote;
            set => _deathNote = value;
        }
        /// <summary>
        /// 家族構成
        /// </summary>
        public List<H_StaffFamilyVo> ListHStaffFamilyVo {
            get => _listHStaffFamilyVo;
            set => _listHStaffFamilyVo = value;
        }
        /// <summary>
        /// 緊急連絡先
        /// </summary>
        public string UrgentTelephoneNumber {
            get => _urgentTelephoneNumber;
            set => _urgentTelephoneNumber = value;
        }
        /// <summary>
        /// 緊急連絡方法
        /// </summary>
        public string UrgentTelephoneMethod {
            get => _urgentTelephoneMethod;
            set => _urgentTelephoneMethod = value;
        }
        /// <summary>
        /// 健康保険
        /// </summary>
        public DateTime HealthInsuranceDate {
            get => _healthInsuranceDate;
            set => _healthInsuranceDate = value;
        }
        public string HealthInsuranceNumber {
            get => _healthInsuranceNumber;
            set => _healthInsuranceNumber = value;
        }
        public string HealthInsuranceNote {
            get => _healthInsuranceNote;
            set => _healthInsuranceNote = value;
        }
        /// <summary>
        /// 年金保険
        /// </summary>
        public DateTime WelfarePensionDate {
            get => _welfarePensionDate;
            set => _welfarePensionDate = value;
        }
        public string WelfarePensionNumber {
            get => _welfarePensionNumber;
            set => _welfarePensionNumber = value;
        }
        public string WelfarePensionNote {
            get => _welfarePensionNote;
            set => _welfarePensionNote = value;
        }
        /// <summary>
        /// 雇用保険
        /// </summary>
        public DateTime EmploymentInsuranceDate {
            get => _employmentInsuranceDate;
            set => _employmentInsuranceDate = value;
        }
        public string EmploymentInsuranceNumber {
            get => _employmentInsuranceNumber;
            set => _employmentInsuranceNumber = value;
        }
        public string EmploymentInsuranceNote {
            get => _employmentInsuranceNote;
            set => _employmentInsuranceNote = value;
        }
        /// <summary>
        /// 労災保険
        /// </summary>
        public DateTime WorkerAccidentInsuranceDate {
            get => _workerAccidentInsuranceDate;
            set => _workerAccidentInsuranceDate = value;
        }
        public string WorkerAccidentInsuranceNumber {
            get => _workerAccidentInsuranceNumber;
            set => _workerAccidentInsuranceNumber = value;
        }
        public string WorkerAccidentInsuranceNote {
            get => _workerAccidentInsuranceNote;
            set => _workerAccidentInsuranceNote = value;
        }
        /// <summary>
        /// 健康診断記録
        /// </summary>
        public List<H_StaffMedicalExaminationVo> ListHStaffMedicalExaminationVo {
            get => _listHStaffMedicalExaminationVo;
            set => _listHStaffMedicalExaminationVo = value;
        }
        /// <summary>
        /// 免許証違反記録
        /// </summary>
        public List<H_StaffCarViolateVo> ListHStaffCarViolateVo {
            get => _listHStaffCarViolateVo;
            set => _listHStaffCarViolateVo = value;
        }
        /// <summary>
        /// 教育指導記録
        /// </summary>
        public List<H_StaffEducateVo> ListHStaffEducateVo {
            get => _listHStaffEducateVo;
            set => _listHStaffEducateVo = value;
        }
        /// <summary>
        /// 適正診断記録
        /// </summary>
        public List<H_StaffProperVo> ListHStaffProperVo {
            get => _listHStaffProperVo;
            set => _listHStaffProperVo = value;
        }
        /// <summary>
        /// 賞罰・譴責記録
        /// </summary>
        public List<H_StaffPunishmentVo> ListHStaffPunishmentVo {
            get => _listHStaffPunishmentVo;
            set => _listHStaffPunishmentVo = value;
        }
        public string InsertPcName {
            get => _insertPcName;
            set => _insertPcName = value;
        }
        public DateTime InsertYmdHms {
            get => _insertYmdHms;
            set => _insertYmdHms = value;
        }
        public string UpdatePcName {
            get => _updatePcName;
            set => _updatePcName = value;
        }
        public DateTime UpdateYmdHms {
            get => _updateYmdHms;
            set => _updateYmdHms = value;
        }
        public string DeletePcName {
            get => _deletePcName;
            set => _deletePcName = value;
        }
        public DateTime DeleteYmdHms {
            get => _deleteYmdHms;
            set => _deleteYmdHms = value;
        }
        public bool DeleteFlag {
            get => _deleteFlag;
            set => _deleteFlag = value;
        }
    }
}
