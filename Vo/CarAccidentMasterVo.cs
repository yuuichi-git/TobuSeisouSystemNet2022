namespace Vo {
    public class CarAccidentMasterVo {
        private bool _totalling_flag;
        private DateTime _occurrence_ymd_hms;
        private string _weather = "";
        private string _accident_kind = "";
        private string _car_static = "";
        private string _occurrence_cause = "";
        private string _negligence = "";
        private string _personal_injury = "";
        private string _property_accident_1 = "";
        private string _property_accident_2 = "";
        private string _occurrence_address = "";
        private string _work_kind = "";
        private decimal _staff_code;
        private string _display_name = "";
        private string _license_number = "";
        private string _car_registration_number = "";
        private string _accident_summary = "";
        private string _accident_detail = "";
        private string _guide = "";
        private byte[]? _picture1 = null;
        private byte[]? _picture2 = null;
        private byte[]? _picture3 = null;
        private byte[]? _picture4 = null;
        private byte[]? _picture5 = null;
        private byte[]? _picture6 = null;
        private byte[]? _picture7 = null;
        private byte[]? _picture8 = null;
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 集計表に反映
        /// True:反映する False:反映しない
        /// </summary>
        public bool Totalling_flag {
            get => _totalling_flag;
            set => _totalling_flag = value;
        }
        /// <summary>
        /// 事故発生日時
        /// </summary>
        public DateTime Occurrence_ymd_hms {
            get => _occurrence_ymd_hms;
            set => _occurrence_ymd_hms = value;
        }
        /// <summary>
        /// 天候
        /// </summary>
        public string Weather {
            get => _weather;
            set => _weather = value;
        }
        /// <summary>
        /// 事故の種別
        /// </summary>
        public string Accident_kind {
            get => _accident_kind;
            set => _accident_kind = value;
        }
        /// <summary>
        /// 車両の静動
        /// </summary>
        public string Car_static {
            get => _car_static;
            set => _car_static = value;
        }
        /// <summary>
        /// 事故の発生原因
        /// </summary>
        public string Occurrence_cause {
            get => _occurrence_cause;
            set => _occurrence_cause = value;
        }
        /// <summary>
        /// 過失の有無
        /// </summary>
        public string Negligence {
            get => _negligence;
            set => _negligence = value;
        }
        /// <summary>
        /// 人身事故の詳細
        /// </summary>
        public string Personal_injury {
            get => _personal_injury;
            set => _personal_injury = value;
        }
        /// <summary>
        /// 物件事故の詳細1
        /// </summary>
        public string Property_accident_1 {
            get => _property_accident_1;
            set => _property_accident_1 = value;
        }
        /// <summary>
        /// 物件事故の詳細2
        /// </summary>
        public string Property_accident_2 {
            get => _property_accident_2;
            set => _property_accident_2 = value;
        }
        /// <summary>
        /// 事故の発生場所
        /// </summary>
        public string Occurrence_address {
            get => _occurrence_address;
            set => _occurrence_address = value;
        }
        /// <summary>
        /// 運転者・作業員の別
        /// </summary>
        public string Work_kind {
            get => _work_kind;
            set => _work_kind = value;
        }
        /// <summary>
        /// 従業員コード
        /// </summary>
        public decimal Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 従業員名
        /// </summary>
        public string Display_name {
            get => _display_name;
            set => _display_name = value;
        }
        /// <summary>
        /// 免許証番号
        /// </summary>
        public string License_number {
            get => _license_number;
            set => _license_number = value;
        }
        /// <summary>
        /// 車両登録番号
        /// </summary>
        public string Car_registration_number {
            get => _car_registration_number;
            set => _car_registration_number = value;
        }
        /// <summary>
        /// 事故概要
        /// </summary>
        public string Accident_summary {
            get => _accident_summary;
            set => _accident_summary = value;
        }
        /// <summary>
        /// 事故詳細
        /// </summary>
        public string Accident_detail {
            get => _accident_detail;
            set => _accident_detail = value;
        }
        /// <summary>
        /// 事故後の指導
        /// </summary>
        public string Guide {
            get => _guide;
            set => _guide = value;
        }
        public byte[]? Picture1 {
            get => _picture1;
            set => _picture1 = value;
        }
        public byte[]? Picture2 {
            get => _picture2;
            set => _picture2 = value;
        }
        public byte[]? Picture3 {
            get => _picture3;
            set => _picture3 = value;
        }
        public byte[]? Picture4 {
            get => _picture4;
            set => _picture4 = value;
        }
        public byte[]? Picture5 {
            get => _picture5;
            set => _picture5 = value;
        }
        public byte[]? Picture6 {
            get => _picture6;
            set => _picture6 = value;
        }
        public byte[]? Picture7 {
            get => _picture7;
            set => _picture7 = value;
        }
        public byte[]? Picture8 {
            get => _picture8;
            set => _picture8 = value;
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
        public bool Delete_flag {
            get => _delete_flag;
            set => _delete_flag = value;
        }
    }
}
