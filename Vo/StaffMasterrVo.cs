namespace Vo {
    /*
     * DeepCopyで使用
     */
    [Serializable] // ←DeepCopyする場合には必要
    public class StaffMasterVo {
        private int _staff_code;
        private int _belongs;
        private string _belongs_name = ""; // 外部結合で取得
        private bool _vehicle_dispatch_target;
        private int _job_form;
        private int _occupation;
        private string _occupation_name = ""; // 外部結合で取得
        private string _name_kana = "";
        private string _name = "";
        private string _display_name = "";
        private string _gender = "";
        private DateTime _birth_date;
        private DateTime _employment_date;
        private int _code;
        private string _current_address = "";
        private string _remarks = "";
        private string _telephone_number = "";
        private string _cellphone_number = "";
        private byte[] _picture = new byte[0];
        private string _blood_type = "";
        private DateTime _selection_date;
        private DateTime _not_selection_date;
        private string _not_selection_reason = "";
        private string _license_number = "";
        private DateTime _history_date_1;
        private string _history_note_1 = "";
        private DateTime _history_date_2;
        private string _history_note_2 = "";
        private DateTime _history_date_3;
        private string _history_note_3 = "";
        private DateTime _history_date_4;
        private string _history_note_4 = "";
        private DateTime _history_date_5;
        private string _history_note_5 = "";
        private DateTime _history_date_6;
        private string _history_note_6 = "";
        private string _experience_kind_1 = "";
        private string _experience_load_1 = "";
        private string _experience_duration_1 = "";
        private string _experience_note_1 = "";
        private string _experience_kind_2 = "";
        private string _experience_load_2 = "";
        private string _experience_duration_2 = "";
        private string _experience_note_2 = "";
        private string _experience_kind_3 = "";
        private string _experience_load_3 = "";
        private string _experience_duration_3 = "";
        private string _experience_note_3 = "";
        private string _experience_kind_4 = "";
        private string _experience_load_4 = "";
        private string _experience_duration_4 = "";
        private string _experience_note_4 = "";
        private bool _retirement_flag;
        private DateTime _retirement_date;
        private string _retirement_note = "";
        private DateTime _death_date;
        private string _death_note = "";
        private string _family_name_1 = "";
        private DateTime _family_birth_date_1;
        private string _family_relationship_1 = "";
        private string _family_name_2 = "";
        private DateTime _family_birth_date_2;
        private string _family_relationship_2 = "";
        private string _family_name_3 = "";
        private DateTime _family_birth_date_3;
        private string _family_relationship_3 = "";
        private string _family_name_4 = "";
        private DateTime _family_birth_date_4;
        private string _family_relationship_4 = "";
        private string _family_name_5 = "";
        private DateTime _family_birth_date_5;
        private string _family_relationship_5 = "";
        private string _family_name_6 = "";
        private DateTime _family_birth_date_6;
        private string _family_relationship_6 = "";
        private string _urgent_telephone_number = "";
        private string _urgent_telephone_method = "";
        private DateTime _health_insurance_date;
        private string _health_insurance_number = "";
        private string _health_insurance_note = "";
        private DateTime _welfare_pension_date;
        private string _welfare_pension_number = "";
        private string _welfare_pension_note = "";
        private DateTime _employment_insurance_date;
        private string _employment_insurance_number = "";
        private string _employment_insurance_note = "";
        private DateTime _worker_accident_insurance_date;
        private string _worker_accident_insurance_number = "";
        private string _worker_accident_insurance_note = "";
        private DateTime _medical_examination_date_1;
        private string _medical_examination_note_1 = "";
        private DateTime _medical_examination_date_2;
        private string _medical_examination_note_2 = "";
        private DateTime _medical_examination_date_3;
        private string _medical_examination_note_3 = "";
        private DateTime _medical_examination_date_4;
        private string _medical_examination_note_4 = "";
        private string _medical_examination_note = "";
        private DateTime _car_violate_date_1;
        private string _car_violate_content_1 = "";
        private string _car_violate_place_1 = "";
        private DateTime _car_violate_date_2;
        private string _car_violate_content_2 = "";
        private string _car_violate_place_2 = "";
        private DateTime _car_violate_date_3;
        private string _car_violate_content_3 = "";
        private string _car_violate_place_3 = "";
        private DateTime _car_violate_date_4;
        private string _car_violate_content_4 = "";
        private string _car_violate_place_4 = "";
        private DateTime _car_violate_date_5;
        private string _car_violate_content_5 = "";
        private string _car_violate_place_5 = "";
        private DateTime _car_violate_date_6;
        private string _car_violate_content_6 = "";
        private string _car_violate_place_6 = "";
        private DateTime _educate_date_1;
        private string _educate_name_1 = "";
        private DateTime _educate_date_2;
        private string _educate_name_2 = "";
        private DateTime _educate_date_3;
        private string _educate_name_3 = "";
        private DateTime _educate_date_4;
        private string _educate_name_4 = "";
        private DateTime _educate_date_5;
        private string _educate_name_5 = "";
        private DateTime _educate_date_6;
        private string _educate_name_6 = "";
        private string _proper_kind_1 = "";
        private DateTime _proper_date_1;
        private string _proper_note_1 = "";
        private string _proper_kind_2 = "";
        private DateTime _proper_date_2;
        private string _proper_note_2 = "";
        private string _proper_kind_3 = "";
        private DateTime _proper_date_3;
        private string _proper_note_3 = "";
        private DateTime _punishment_date_1;
        private string _punishment_note_1 = "";
        private DateTime _punishment_date_2;
        private string _punishment_note_2 = "";
        private DateTime _punishment_date_3;
        private string _punishment_note_3 = "";
        private DateTime _punishment_date_4;
        private string _punishment_note_4 = "";
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 従業員コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 所属
        /// 10:役員 11:社員 12:アルバイト 20:新運転 21:自運労
        /// </summary>
        public int Belongs {
            get => _belongs;
            set => _belongs = value;
        }
        /// <summary>
        /// 外部結合で取得
        /// </summary>
        public string Belongs_name {
            get => _belongs_name;
            set => _belongs_name = value;
        }
        /// <summary>
        /// 配車の対象かどうか
        /// true:対象 false:非対象
        /// </summary>
        public bool Vehicle_dispatch_target {
            get => _vehicle_dispatch_target;
            set => _vehicle_dispatch_target = value;
        }
        /// <summary>
        /// 形態
        /// 10:長期雇用 11:手帳 12:アルバイト
        /// </summary>
        public int Job_form {
            get => _job_form;
            set => _job_form = value;
        }
        /// <summary>
        /// 職種
        /// 10:運転手 11:作業員 99:指定なし
        /// </summary>
        public int Occupation {
            get => _occupation;
            set => _occupation = value;
        }
        /// <summary>
        /// 外部結合で取得
        /// </summary>
        public string Occupation_name {
            get => _occupation_name;
            set => _occupation_name = value;
        }
        /// <summary>
        /// 氏名カナ
        /// </summary>
        public string Name_kana {
            get => _name_kana;
            set => _name_kana = value;
        }
        /// <summary>
        /// 氏名
        /// </summary>
        public string Name {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// 画面表示名
        /// </summary>
        public string Display_name {
            get => _display_name;
            set => _display_name = value;
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
        public DateTime Birth_date {
            get => _birth_date;
            set => _birth_date = value;
        }
        /// <summary>
        /// 雇用年月日
        /// </summary>
        public DateTime Employment_date {
            get => _employment_date;
            set => _employment_date = value;
        }
        /// <summary>
        /// コード(組合)
        /// </summary>
        public int Code {
            get => _code;
            set => _code = value;
        }
        /// <summary>
        /// 現住所
        /// </summary>
        public string Current_address {
            get => _current_address;
            set => _current_address = value;
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
        public string Telephone_number {
            get => _telephone_number;
            set => _telephone_number = value;
        }
        /// <summary>
        /// 携帯番号
        /// </summary>
        public string Cellphone_number {
            get => _cellphone_number;
            set => _cellphone_number = value;
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
        public string Blood_type {
            get => _blood_type;
            set => _blood_type = value;
        }
        /// <summary>
        /// 選任された日
        /// </summary>
        public DateTime Selection_date {
            get => _selection_date;
            set => _selection_date = value;
        }
        /// <summary>
        /// 選任されなくなった日
        /// </summary>
        public DateTime Not_selection_date {
            get => _not_selection_date;
            set => _not_selection_date = value;
        }
        /// <summary>
        /// 選任されなくなった理由
        /// </summary>
        public string Not_selection_reason {
            get => _not_selection_reason;
            set => _not_selection_reason = value;
        }
        /// <summary>
        /// 免許証番号
        /// </summary>
        public string License_number {
            get => _license_number;
            set => _license_number = value;
        }
        /// <summary>
        /// 履歴年月日1
        /// </summary>
        public DateTime History_date_1 {
            get => _history_date_1;
            set => _history_date_1 = value;
        }
        /// <summary>
        /// 履歴内容1
        /// </summary>
        public string History_note_1 {
            get => _history_note_1;
            set => _history_note_1 = value;
        }
        /// <summary>
        /// 履歴年月日2
        /// </summary>
        public DateTime History_date_2 {
            get => _history_date_2;
            set => _history_date_2 = value;
        }
        /// <summary>
        /// 履歴内容2
        /// </summary>
        public string History_note_2 {
            get => _history_note_2;
            set => _history_note_2 = value;
        }
        /// <summary>
        /// 履歴年月日3
        /// </summary>
        public DateTime History_date_3 {
            get => _history_date_3;
            set => _history_date_3 = value;
        }
        /// <summary>
        /// 履歴内容3
        /// </summary>
        public string History_note_3 {
            get => _history_note_3;
            set => _history_note_3 = value;
        }
        /// <summary>
        /// 履歴年月日4
        /// </summary>
        public DateTime History_date_4 {
            get => _history_date_4;
            set => _history_date_4 = value;
        }
        /// <summary>
        /// 履歴内容4
        /// </summary>
        public string History_note_4 {
            get => _history_note_4;
            set => _history_note_4 = value;
        }
        /// <summary>
        /// 履歴年月日5
        /// </summary>
        public DateTime History_date_5 {
            get => _history_date_5;
            set => _history_date_5 = value;
        }
        /// <summary>
        /// 履歴内容5
        /// </summary>
        public string History_note_5 {
            get => _history_note_5;
            set => _history_note_5 = value;
        }
        /// <summary>
        /// 履歴年月日6
        /// </summary>
        public DateTime History_date_6 {
            get => _history_date_6;
            set => _history_date_6 = value;
        }
        /// <summary>
        /// 履歴内容6
        /// </summary>
        public string History_note_6 {
            get => _history_note_6;
            set => _history_note_6 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の種類1
        /// </summary>
        public string Experience_kind_1 {
            get => _experience_kind_1;
            set => _experience_kind_1 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の積載量又は定員1
        /// </summary>
        public string Experience_load_1 {
            get => _experience_load_1;
            set => _experience_load_1 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の経験期間1
        /// </summary>
        public string Experience_duration_1 {
            get => _experience_duration_1;
            set => _experience_duration_1 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の備考1
        /// </summary>
        public string Experience_note_1 {
            get => _experience_note_1;
            set => _experience_note_1 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の種類2
        /// </summary>
        public string Experience_kind_2 {
            get => _experience_kind_2;
            set => _experience_kind_2 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の積載量又は定員2
        /// </summary>
        public string Experience_load_2 {
            get => _experience_load_2;
            set => _experience_load_2 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の経験期間2
        /// </summary>
        public string Experience_duration_2 {
            get => _experience_duration_2;
            set => _experience_duration_2 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の備考2
        /// </summary>
        public string Experience_note_2 {
            get => _experience_note_2;
            set => _experience_note_2 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の種類3
        /// </summary>
        public string Experience_kind_3 {
            get => _experience_kind_3;
            set => _experience_kind_3 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の積載量又は定員3
        /// </summary>
        public string Experience_load_3 {
            get => _experience_load_3;
            set => _experience_load_3 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の経験期間3
        /// </summary>
        public string Experience_duration_3 {
            get => _experience_duration_3;
            set => _experience_duration_3 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の備考3
        /// </summary>
        public string Experience_note_3 {
            get => _experience_note_3;
            set => _experience_note_3 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の種類4
        /// </summary>
        public string Experience_kind_4 {
            get => _experience_kind_4;
            set => _experience_kind_4 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の積載量又は定員4
        /// </summary>
        public string Experience_load_4 {
            get => _experience_load_4;
            set => _experience_load_4 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の経験期間4
        /// </summary>
        public string Experience_duration_4 {
            get => _experience_duration_4;
            set => _experience_duration_4 = value;
        }
        /// <summary>
        /// 過去に運転経験のある自動車の備考4
        /// </summary>
        public string Experience_note_4 {
            get => _experience_note_4;
            set => _experience_note_4 = value;
        }
        /// <summary>
        /// 退職フラグ
        /// </summary>
        public bool Retirement_flag {
            get => _retirement_flag;
            set => _retirement_flag = value;
        }
        /// <summary>
        /// 退職日
        /// </summary>
        public DateTime Retirement_date {
            get => _retirement_date;
            set => _retirement_date = value;
        }
        /// <summary>
        /// 退職理由
        /// </summary>
        public string Retirement_note {
            get => _retirement_note;
            set => _retirement_note = value;
        }
        public DateTime Death_date {
            get => _death_date;
            set => _death_date = value;
        }
        public string Death_note {
            get => _death_note;
            set => _death_note = value;
        }
        /// <summary>
        /// 家族氏名1
        /// </summary>
        public string Family_name_1 {
            get => _family_name_1;
            set => _family_name_1 = value;
        }
        /// <summary>
        /// 家族生年月日1
        /// </summary>
        public DateTime Family_birth_date_1 {
            get => _family_birth_date_1;
            set => _family_birth_date_1 = value;
        }
        /// <summary>
        /// 家族続柄1
        /// </summary>
        public string Family_relationship_1 {
            get => _family_relationship_1;
            set => _family_relationship_1 = value;
        }
        /// <summary>
        /// 家族氏名2
        /// </summary>
        public string Family_name_2 {
            get => _family_name_2;
            set => _family_name_2 = value;
        }
        /// <summary>
        /// 家族生年月日2
        /// </summary>
        public DateTime Family_birth_date_2 {
            get => _family_birth_date_2;
            set => _family_birth_date_2 = value;
        }
        /// <summary>
        /// 家族続柄2
        /// </summary>
        public string Family_relationship_2 {
            get => _family_relationship_2;
            set => _family_relationship_2 = value;
        }
        /// <summary>
        /// 家族氏名3
        /// </summary>
        public string Family_name_3 {
            get => _family_name_3;
            set => _family_name_3 = value;
        }
        /// <summary>
        /// 家族生年月日3
        /// </summary>
        public DateTime Family_birth_date_3 {
            get => _family_birth_date_3;
            set => _family_birth_date_3 = value;
        }
        /// <summary>
        /// 家族続柄3
        /// </summary>
        public string Family_relationship_3 {
            get => _family_relationship_3;
            set => _family_relationship_3 = value;
        }
        /// <summary>
        /// 家族氏名4
        /// </summary>
        public string Family_name_4 {
            get => _family_name_4;
            set => _family_name_4 = value;
        }
        /// <summary>
        /// 家族生年月日4
        /// </summary>
        public DateTime Family_birth_date_4 {
            get => _family_birth_date_4;
            set => _family_birth_date_4 = value;
        }
        /// <summary>
        /// 家族続柄4
        /// </summary>
        public string Family_relationship_4 {
            get => _family_relationship_4;
            set => _family_relationship_4 = value;
        }
        /// <summary>
        /// 家族氏名5
        /// </summary>
        public string Family_name_5 {
            get => _family_name_5;
            set => _family_name_5 = value;
        }
        /// <summary>
        /// 家族生年月日5
        /// </summary>
        public DateTime Family_birth_date_5 {
            get => _family_birth_date_5;
            set => _family_birth_date_5 = value;
        }
        /// <summary>
        /// 家族続柄5
        /// </summary>
        public string Family_relationship_5 {
            get => _family_relationship_5;
            set => _family_relationship_5 = value;
        }
        /// <summary>
        /// 家族氏名6
        /// </summary>
        public string Family_name_6 {
            get => _family_name_6;
            set => _family_name_6 = value;
        }
        /// <summary>
        /// 家族生年月日6
        /// </summary>
        public DateTime Family_birth_date_6 {
            get => _family_birth_date_6;
            set => _family_birth_date_6 = value;
        }
        /// <summary>
        /// 家族続柄6
        /// </summary>
        public string Family_relationship_6 {
            get => _family_relationship_6;
            set => _family_relationship_6 = value;
        }
        public string Urgent_telephone_number {
            get => _urgent_telephone_number;
            set => _urgent_telephone_number = value;
        }
        public string Urgent_telephone_method {
            get => _urgent_telephone_method;
            set => _urgent_telephone_method = value;
        }
        public DateTime Health_insurance_date {
            get => _health_insurance_date;
            set => _health_insurance_date = value;
        }
        public string Health_insurance_number {
            get => _health_insurance_number;
            set => _health_insurance_number = value;
        }
        public string Health_insurance_note {
            get => _health_insurance_note;
            set => _health_insurance_note = value;
        }
        public DateTime Welfare_pension_date {
            get => _welfare_pension_date;
            set => _welfare_pension_date = value;
        }
        public string Welfare_pension_number {
            get => _welfare_pension_number;
            set => _welfare_pension_number = value;
        }
        public string Welfare_pension_note {
            get => _welfare_pension_note;
            set => _welfare_pension_note = value;
        }
        public DateTime Employment_insurance_date {
            get => _employment_insurance_date;
            set => _employment_insurance_date = value;
        }
        public string Employment_insurance_number {
            get => _employment_insurance_number;
            set => _employment_insurance_number = value;
        }
        public string Employment_insurance_note {
            get => _employment_insurance_note;
            set => _employment_insurance_note = value;
        }
        public DateTime Worker_accident_insurance_date {
            get => _worker_accident_insurance_date;
            set => _worker_accident_insurance_date = value;
        }
        public string Worker_accident_insurance_number {
            get => _worker_accident_insurance_number;
            set => _worker_accident_insurance_number = value;
        }
        public string Worker_accident_insurance_note {
            get => _worker_accident_insurance_note;
            set => _worker_accident_insurance_note = value;
        }
        /// <summary>
        /// 健康診断　受診年月日1
        /// </summary>
        public DateTime Medical_examination_date_1 {
            get => _medical_examination_date_1;
            set => _medical_examination_date_1 = value;
        }
        /// <summary>
        /// 健康診断　受診機関他1
        /// </summary>
        public string Medical_examination_note_1 {
            get => _medical_examination_note_1;
            set => _medical_examination_note_1 = value;
        }
        /// <summary>
        /// 健康診断　受診年月日2
        /// </summary>
        public DateTime Medical_examination_date_2 {
            get => _medical_examination_date_2;
            set => _medical_examination_date_2 = value;
        }
        /// <summary>
        /// 健康診断　受診機関他2
        /// </summary>
        public string Medical_examination_note_2 {
            get => _medical_examination_note_2;
            set => _medical_examination_note_2 = value;
        }
        /// <summary>
        /// 健康診断　受診年月日3
        /// </summary>
        public DateTime Medical_examination_date_3 {
            get => _medical_examination_date_3;
            set => _medical_examination_date_3 = value;
        }
        /// <summary>
        /// 健康診断　受診機関他3
        /// </summary>
        public string Medical_examination_note_3 {
            get => _medical_examination_note_3;
            set => _medical_examination_note_3 = value;
        }
        /// <summary>
        /// 健康診断　受診年月日4
        /// </summary>
        public DateTime Medical_examination_date_4 {
            get => _medical_examination_date_4;
            set => _medical_examination_date_4 = value;
        }
        /// <summary>
        /// 健康診断　受診機関他4
        /// </summary>
        public string Medical_examination_note_4 {
            get => _medical_examination_note_4;
            set => _medical_examination_note_4 = value;
        }
        /// <summary>
        /// 診療以外で気づいた点
        /// </summary>
        public string Medical_examination_note {
            get => _medical_examination_note;
            set => _medical_examination_note = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・発生年月日1
        /// </summary>
        public DateTime Car_violate_date_1 {
            get => _car_violate_date_1;
            set => _car_violate_date_1 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・違反内容1
        /// </summary>
        public string Car_violate_content_1 {
            get => _car_violate_content_1;
            set => _car_violate_content_1 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・場所1
        /// </summary>
        public string Car_violate_place_1 {
            get => _car_violate_place_1;
            set => _car_violate_place_1 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・発生年月日2
        /// </summary>
        public DateTime Car_violate_date_2 {
            get => _car_violate_date_2;
            set => _car_violate_date_2 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・違反内容2
        /// </summary>
        public string Car_violate_content_2 {
            get => _car_violate_content_2;
            set => _car_violate_content_2 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・場所2
        /// </summary>
        public string Car_violate_place_2 {
            get => _car_violate_place_2;
            set => _car_violate_place_2 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・発生年月日3
        /// </summary>
        public DateTime Car_violate_date_3 {
            get => _car_violate_date_3;
            set => _car_violate_date_3 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・違反内容3
        /// </summary>
        public string Car_violate_content_3 {
            get => _car_violate_content_3;
            set => _car_violate_content_3 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・場所3
        /// </summary>
        public string Car_violate_place_3 {
            get => _car_violate_place_3;
            set => _car_violate_place_3 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・発生年月日4
        /// </summary>
        public DateTime Car_violate_date_4 {
            get => _car_violate_date_4;
            set => _car_violate_date_4 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・違反内容4
        /// </summary>
        public string Car_violate_content_4 {
            get => _car_violate_content_4;
            set => _car_violate_content_4 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・場所4
        /// </summary>
        public string Car_violate_place_4 {
            get => _car_violate_place_4;
            set => _car_violate_place_4 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・発生年月日5
        /// </summary>
        public DateTime Car_violate_date_5 {
            get => _car_violate_date_5;
            set => _car_violate_date_5 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・違反内容5
        /// </summary>
        public string Car_violate_content_5 {
            get => _car_violate_content_5;
            set => _car_violate_content_5 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・場所5
        /// </summary>
        public string Car_violate_place_5 {
            get => _car_violate_place_5;
            set => _car_violate_place_5 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・発生年月日6
        /// </summary>
        public DateTime Car_violate_date_6 {
            get => _car_violate_date_6;
            set => _car_violate_date_6 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・違反内容6
        /// </summary>
        public string Car_violate_content_6 {
            get => _car_violate_content_6;
            set => _car_violate_content_6 = value;
        }
        /// <summary>
        /// 業務上の交通違反履歴・場所6
        /// </summary>
        public string Car_violate_place_6 {
            get => _car_violate_place_6;
            set => _car_violate_place_6 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施年月日1
        /// </summary>
        public DateTime Educate_date_1 {
            get => _educate_date_1;
            set => _educate_date_1 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施対象事由1
        /// </summary>
        public string Educate_name_1 {
            get => _educate_name_1;
            set => _educate_name_1 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施年月日2
        /// </summary>
        public DateTime Educate_date_2 {
            get => _educate_date_2;
            set => _educate_date_2 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施対象事由2
        /// </summary>
        public string Educate_name_2 {
            get => _educate_name_2;
            set => _educate_name_2 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施年月日3
        /// </summary>
        public DateTime Educate_date_3 {
            get => _educate_date_3;
            set => _educate_date_3 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施対象事由3
        /// </summary>
        public string Educate_name_3 {
            get => _educate_name_3;
            set => _educate_name_3 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施年月日4
        /// </summary>
        public DateTime Educate_date_4 {
            get => _educate_date_4;
            set => _educate_date_4 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施対象事由4
        /// </summary>
        public string Educate_name_4 {
            get => _educate_name_4;
            set => _educate_name_4 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施年月日5
        /// </summary>
        public DateTime Educate_date_5 {
            get => _educate_date_5;
            set => _educate_date_5 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施対象事由5
        /// </summary>
        public string Educate_name_5 {
            get => _educate_name_5;
            set => _educate_name_5 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施年月日6
        /// </summary>
        public DateTime Educate_date_6 {
            get => _educate_date_6;
            set => _educate_date_6 = value;
        }
        /// <summary>
        /// 社内教育の実施状況・実施対象事由6
        /// </summary>
        public string Educate_name_6 {
            get => _educate_name_6;
            set => _educate_name_6 = value;
        }
        /// <summary>
        /// 適性診断・種類1
        /// </summary>
        public string Proper_kind_1 {
            get => _proper_kind_1;
            set => _proper_kind_1 = value;
        }
        /// <summary>
        /// 適性診断・実施年月日1
        /// </summary>
        public DateTime Proper_date_1 {
            get => _proper_date_1;
            set => _proper_date_1 = value;
        }
        /// <summary>
        /// 適性診断・備考1
        /// </summary>
        public string Proper_note_1 {
            get => _proper_note_1;
            set => _proper_note_1 = value;
        }
        /// <summary>
        /// 適性診断・種類2
        /// </summary>
        public string Proper_kind_2 {
            get => _proper_kind_2;
            set => _proper_kind_2 = value;
        }
        /// <summary>
        /// 適性診断・実施年月日2
        /// </summary>
        public DateTime Proper_date_2 {
            get => _proper_date_2;
            set => _proper_date_2 = value;
        }
        /// <summary>
        /// 適性診断・備考2
        /// </summary>
        public string Proper_note_2 {
            get => _proper_note_2;
            set => _proper_note_2 = value;
        }
        /// <summary>
        /// 適性診断・種類3
        /// </summary>
        public string Proper_kind_3 {
            get => _proper_kind_3;
            set => _proper_kind_3 = value;
        }
        /// <summary>
        /// 適性診断・実施年月日3
        /// </summary>
        public DateTime Proper_date_3 {
            get => _proper_date_3;
            set => _proper_date_3 = value;
        }
        /// <summary>
        /// 適性診断・備考3
        /// </summary>
        public string Proper_note_3 {
            get => _proper_note_3;
            set => _proper_note_3 = value;
        }
        /// <summary>
        /// 賞罰・譴責1
        /// </summary>
        public DateTime Punishment_date_1 {
            get => _punishment_date_1;
            set => _punishment_date_1 = value;
        }
        /// <summary>
        /// 賞罰・譴責の内容1
        /// </summary>
        public string Punishment_note_1 {
            get => _punishment_note_1;
            set => _punishment_note_1 = value;
        }
        /// <summary>
        /// 賞罰・譴責2
        /// </summary>
        public DateTime Punishment_date_2 {
            get => _punishment_date_2;
            set => _punishment_date_2 = value;
        }
        /// <summary>
        /// 賞罰・譴責の内容2
        /// </summary>
        public string Punishment_note_2 {
            get => _punishment_note_2;
            set => _punishment_note_2 = value;
        }
        /// <summary>
        /// 賞罰・譴責3
        /// </summary>
        public DateTime Punishment_date_3 {
            get => _punishment_date_3;
            set => _punishment_date_3 = value;
        }
        /// <summary>
        /// 賞罰・譴責の内容3
        /// </summary>
        public string Punishment_note_3 {
            get => _punishment_note_3;
            set => _punishment_note_3 = value;
        }
        /// <summary>
        /// 賞罰・譴責4
        /// </summary>
        public DateTime Punishment_date_4 {
            get => _punishment_date_4;
            set => _punishment_date_4 = value;
        }
        /// <summary>
        /// 賞罰・譴責の内容4
        /// </summary>
        public string Punishment_note_4 {
            get => _punishment_note_4;
            set => _punishment_note_4 = value;
        }
        public DateTime Insert_ymd_hms {
            get => _insert_ymd_hms;
            set => _insert_ymd_hms = value;
        }
        public DateTime Update_ymd_hms {
            get => _update_ymd_hms;
            set => _update_ymd_hms = value;
        }
        public DateTime Delete_ymd_hms {
            get => _delete_ymd_hms;
            set => _delete_ymd_hms = value;
        }
        /// <summary>
        /// 削除フラグ
        /// </summary>
        public bool Delete_flag {
            get => _delete_flag;
            set => _delete_flag = value;
        }
    }
}
