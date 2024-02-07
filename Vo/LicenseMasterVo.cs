namespace H_Vo {
    public class LicenseMasterVo {
        private int _staff_code;
        private string? _name_kana;
        private string? _name;
        private DateTime _birth_date;
        private string? _current_address;
        private DateTime _delivery_date;
        private DateTime _expiration_date;
        private string? _license_condition;
        private string? _license_number;
        private DateTime _get_date_1;
        private DateTime _get_date_2;
        private DateTime _get_date_3;
        private byte[]? _picture_head;
        private byte[]? _picture_tail;
        private bool _large;
        private bool _medium;
        private bool _quasi_medium;
        private bool _ordinary;
        private bool _big_special;
        private bool _big_auto_bike;
        private bool _ordinary_auto_bike;
        private bool _small_special;
        private bool _with_a_raw;
        private bool _big_two;
        private bool _medium_two;
        private bool _ordinary_two;
        private bool _big_special_two;
        private bool _traction;
        private DateTime _insert_ymd_hms;
        private DateTime? _update_ymd_hms;
        private DateTime? _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 社員コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 氏名カナ
        /// </summary>
        public string? Name_kana {
            get => _name_kana;
            set => _name_kana = value;
        }
        /// <summary>
        /// 氏名
        /// </summary>
        public string? Name {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime Birth_date {
            get => _birth_date;
            set => _birth_date = value;
        }
        /// <summary>
        /// 住所
        /// </summary>
        public string? Current_address {
            get => _current_address;
            set => _current_address = value;
        }
        /// <summary>
        /// 交付年月日
        /// </summary>
        public DateTime Delivery_date {
            get => _delivery_date;
            set => _delivery_date = value;
        }
        /// <summary>
        /// 有効期限
        /// </summary>
        public DateTime Expiration_date {
            get => _expiration_date;
            set => _expiration_date = value;
        }
        /// <summary>
        /// 条件等
        /// </summary>
        public string? License_condition {
            get => _license_condition;
            set => _license_condition = value;
        }
        /// <summary>
        /// 免許証番号
        /// </summary>
        public string? License_number {
            get => _license_number;
            set => _license_number = value;
        }
        /// <summary>
        /// 二小原取得日
        /// </summary>
        public DateTime Get_date_1 {
            get => _get_date_1;
            set => _get_date_1 = value;
        }
        /// <summary>
        /// 他取得日
        /// </summary>
        public DateTime Get_date_2 {
            get => _get_date_2;
            set => _get_date_2 = value;
        }
        /// <summary>
        /// 二種取得日
        /// </summary>
        public DateTime Get_date_3 {
            get => _get_date_3;
            set => _get_date_3 = value;
        }
        /// <summary>
        /// 写真表
        /// </summary>
        public byte[]? Picture_head {
            get => _picture_head;
            set => _picture_head = value;
        }
        /// <summary>
        /// 写真裏
        /// </summary>
        public byte[]? Picture_tail {
            get => _picture_tail;
            set => _picture_tail = value;
        }
        /// <summary>
        /// 大型
        /// </summary>
        public bool Large {
            get => _large;
            set => _large = value;
        }
        /// <summary>
        /// 中型
        /// </summary>
        public bool Medium {
            get => _medium;
            set => _medium = value;
        }
        /// <summary>
        /// 準中型
        /// </summary>
        public bool Quasi_medium {
            get => _quasi_medium;
            set => _quasi_medium = value;
        }
        /// <summary>
        /// 普通
        /// </summary>
        public bool Ordinary {
            get => _ordinary;
            set => _ordinary = value;
        }
        /// <summary>
        /// 大特
        /// </summary>
        public bool Big_special {
            get => _big_special;
            set => _big_special = value;
        }
        /// <summary>
        /// 大自二
        /// </summary>
        public bool Big_auto_bike {
            get => _big_auto_bike;
            set => _big_auto_bike = value;
        }
        /// <summary>
        /// 普自二
        /// </summary>
        public bool Ordinary_auto_bike {
            get => _ordinary_auto_bike;
            set => _ordinary_auto_bike = value;
        }
        /// <summary>
        /// 小特
        /// </summary>
        public bool Small_special {
            get => _small_special;
            set => _small_special = value;
        }
        /// <summary>
        /// 原付
        /// </summary>
        public bool With_a_raw {
            get => _with_a_raw;
            set => _with_a_raw = value;
        }
        /// <summary>
        /// 大型二種
        /// </summary>
        public bool Big_two {
            get => _big_two;
            set => _big_two = value;
        }
        /// <summary>
        /// 中型二種
        /// </summary>
        public bool Medium_two {
            get => _medium_two;
            set => _medium_two = value;
        }
        /// <summary>
        /// 普通二種
        /// </summary>
        public bool Ordinary_two {
            get => _ordinary_two;
            set => _ordinary_two = value;
        }
        /// <summary>
        /// 大特二種
        /// </summary>
        public bool Big_special_two {
            get => _big_special_two;
            set => _big_special_two = value;
        }
        /// <summary>
        /// 牽引
        /// </summary>
        public bool Traction {
            get => _traction;
            set => _traction = value;
        }
        public DateTime Insert_ymd_hms {
            get => _insert_ymd_hms;
            set => _insert_ymd_hms = value;
        }
        public DateTime? Update_ymd_hms {
            get => _update_ymd_hms;
            set => _update_ymd_hms = value;
        }
        public DateTime? Delete_ymd_hms {
            get => _delete_ymd_hms;
            set => _delete_ymd_hms = value;
        }
        public bool Delete_flag {
            get => _delete_flag;
            set => _delete_flag = value;
        }
    }
}
