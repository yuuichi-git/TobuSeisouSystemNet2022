namespace Vo {
    /*
     * DeepCopyで使用
     */
    [Serializable] // ←DeepCopyする場合には必要
    public class CarMasterVo {
        private int _car_code;
        private int _classification_code;
        private string _classification_name = ""; // 外部結合で取得
        private string _registration_number = "";
        private string _registration_number_1 = "";
        private string _registration_number_2 = "";
        private string _registration_number_3 = "";
        private string _registration_number_4 = "";
        private bool _garage_flag;
        private int _door_number;
        private DateTime _registration_date;
        private DateTime _first_registration_date;
        private int _car_kind_code;
        private string _car_kind_name = ""; // 外部結合で取得
        private string _disguise_kind_1 = "";
        private string _disguise_kind_2 = "";
        private string _disguise_kind_3 = "";
        private string _car_use = "";
        private int _other_code;
        private string _other_name = "";
        private int _shape_code;
        private string _shape_name = ""; // 外部結合で取得
        private int _manufacturer_code;
        private string _manufacturer_name = ""; // 外部結合で取得
        private decimal _capacity;
        private decimal _maximum_load_capacity;
        private decimal _vehicle_weight;
        private decimal _total_vehicle_weight;
        private string _vehicle_number = "";
        private decimal _length;
        private decimal _width;
        private decimal _height;
        private decimal _ff_axis_weight;
        private decimal _fr_axis_weight;
        private decimal _rf_axis_weight;
        private decimal _rr_axis_weight;
        private string _version = "";
        private string _motor_version = "";
        private decimal _total_displacement;
        private string _types_of_fuel = "";
        private string _version_designate_number = "";
        private string _category_distinguish_number = "";
        private string _owner_name = "";
        private string _owner_address = "";
        private string _user_name = "";
        private string _user_address = "";
        private string _base_address = "";
        private DateTime _expiration_date;
        private string _remarks = "";
        private byte[] _picture = new byte[0];
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 車両コード
        /// </summary>
        public int Car_code {
            get => _car_code;
            set => _car_code = value;
        }
        /// <summary>
        /// 分類コード
        /// 10:雇上 11:区契 12:臨時 20:清掃工場 30:社内 50:一般 51:社用車 99:指定なし
        /// </summary>
        public int Classification_code {
            get => _classification_code;
            set => _classification_code = value;
        }
        public string Classification_name {
            get => _classification_name;
            set => _classification_name = value;
        }
        /// <summary>
        /// 自動車登録番号又は車両番号
        /// </summary>
        public string Registration_number {
            get => _registration_number;
            set => _registration_number = value;
        }
        /// <summary>
        /// 自動車登録番号又は車両番号1
        /// </summary>
        public string Registration_number_1 {
            get => _registration_number_1;
            set => _registration_number_1 = value;
        }
        /// <summary>
        /// 自動車登録番号又は車両番号2
        /// </summary>
        public string Registration_number_2 {
            get => _registration_number_2;
            set => _registration_number_2 = value;
        }
        /// <summary>
        /// 自動車登録番号又は車両番号3
        /// </summary>
        public string Registration_number_3 {
            get => _registration_number_3;
            set => _registration_number_3 = value;
        }
        /// <summary>
        /// 自動車登録番号又は車両番号4
        /// </summary>
        public string Registration_number_4 {
            get => _registration_number_4;
            set => _registration_number_4 = value;
        }
        /// <summary>
        /// 車庫地
        /// true:足立 false:三郷
        /// </summary>
        public bool Garage_flag {
            get => _garage_flag;
            set => _garage_flag = value;
        }
        /// <summary>
        /// ドア番号
        /// "78-1"等の文字で表すドア番が存在するためstring型で
        /// </summary>
        public int Door_number {
            get => _door_number;
            set => _door_number = value;
        }
        /// <summary>
        /// 登録年月日/交付年月日
        /// </summary>
        public DateTime Registration_date {
            get => _registration_date;
            set => _registration_date = value;
        }
        /// <summary>
        /// 初年度登録年月
        /// </summary>
        public DateTime First_registration_date {
            get => _first_registration_date;
            set => _first_registration_date = value;
        }
        /// <summary>
        /// 自動車の種別
        /// </summary>
        public int Car_kind_code {
            get => _car_kind_code;
            set => _car_kind_code = value;
        }
        public string Car_kind_name {
            get => _car_kind_name;
            set => _car_kind_name = value;
        }
        /// <summary>
        /// 仮装の種類1(配車での名称)
        /// </summary>
        public string Disguise_kind_1 {
            get => _disguise_kind_1;
            set => _disguise_kind_1 = value;
        }
        /// <summary>
        /// 仮装の種類2(事故報告書での名称)
        /// </summary>
        public string Disguise_kind_2 {
            get => _disguise_kind_2;
            set => _disguise_kind_2 = value;
        }
        /// <summary>
        /// 仮装の種類3(整備での名称)
        /// </summary>
        public string Disguise_kind_3 {
            get => _disguise_kind_3;
            set => _disguise_kind_3 = value;
        }
        /// <summary>
        /// 用途
        /// </summary>
        public string Car_use {
            get => _car_use;
            set => _car_use = value;
        }
        /// <summary>
        /// 自家用・事業用の別コード
        /// 10:事業用 11:自家用
        /// </summary>
        public int Other_code {
            get => _other_code;
            set => _other_code = value;
        }
        public string Other_name {
            get => _other_name;
            set => _other_name = value;
        }
        /// <summary>
        /// 車体の形状コード
        /// 10:キャブオーバー 11:塵芥車 12:ダンプ 13:コンテナ専用 14:脱着装置付コンテナ専用車 15:粉粒体運搬車 16:糞尿車 17:清掃車
        /// </summary>
        public int Shape_code {
            get => _shape_code;
            set => _shape_code = value;
        }
        public string Shape_name {
            get => _shape_name;
            set => _shape_name = value;
        }
        /// <summary>
        /// 車両メーカーコード
        /// </summary>
        public int Manufacturer_code {
            get => _manufacturer_code;
            set => _manufacturer_code = value;
        }
        public string Manufacturer_name {
            get => _manufacturer_name;
            set => _manufacturer_name = value;
        }
        /// <summary>
        /// 乗車定員
        /// </summary>
        public decimal Capacity {
            get => _capacity;
            set => _capacity = value;
        }
        /// <summary>
        /// 最大積載量
        /// </summary>
        public decimal Maximum_load_capacity {
            get => _maximum_load_capacity;
            set => _maximum_load_capacity = value;
        }
        /// <summary>
        /// 車両重量
        /// </summary>
        public decimal Vehicle_weight {
            get => _vehicle_weight;
            set => _vehicle_weight = value;
        }
        /// <summary>
        /// 車両総重量
        /// </summary>
        public decimal Total_vehicle_weight {
            get => _total_vehicle_weight;
            set => _total_vehicle_weight = value;
        }
        /// <summary>
        /// 車台番号
        /// </summary>
        public string Vehicle_number {
            get => _vehicle_number;
            set => _vehicle_number = value;
        }
        /// <summary>
        /// 長さ
        /// </summary>
        public decimal Length {
            get => _length;
            set => _length = value;
        }
        /// <summary>
        /// 幅
        /// </summary>
        public decimal Width {
            get => _width;
            set => _width = value;
        }
        /// <summary>
        /// 高さ
        /// </summary>
        public decimal Height {
            get => _height;
            set => _height = value;
        }
        /// <summary>
        /// 前前軸重
        /// </summary>
        public decimal Ff_axis_weight {
            get => _ff_axis_weight;
            set => _ff_axis_weight = value;
        }
        /// <summary>
        /// 前後軸重
        /// </summary>
        public decimal Fr_axis_weight {
            get => _fr_axis_weight;
            set => _fr_axis_weight = value;
        }
        /// <summary>
        /// 後前軸重
        /// </summary>
        public decimal Rf_axis_weight {
            get => _rf_axis_weight;
            set => _rf_axis_weight = value;
        }
        /// <summary>
        /// 後後軸重
        /// </summary>
        public decimal Rr_axis_weight {
            get => _rr_axis_weight;
            set => _rr_axis_weight = value;
        }
        /// <summary>
        /// 型式
        /// </summary>
        public string Version {
            get => _version;
            set => _version = value;
        }
        /// <summary>
        /// 原動機の型式
        /// </summary>
        public string Motor_version {
            get => _motor_version;
            set => _motor_version = value;
        }
        /// <summary>
        /// 総排気量又は定格出力
        /// </summary>
        public decimal Total_displacement {
            get => _total_displacement;
            set => _total_displacement = value;
        }
        /// <summary>
        /// 燃料の種類
        /// </summary>
        public string Types_of_fuel {
            get => _types_of_fuel;
            set => _types_of_fuel = value;
        }
        /// <summary>
        /// 型式指定番号
        /// </summary>
        public string Version_designate_number {
            get => _version_designate_number;
            set => _version_designate_number = value;
        }
        /// <summary>
        /// 類別区分番号
        /// </summary>
        public string Category_distinguish_number {
            get => _category_distinguish_number;
            set => _category_distinguish_number = value;
        }
        /// <summary>
        /// 所有者の氏名又は名称
        /// </summary>
        public string Owner_name {
            get => _owner_name;
            set => _owner_name = value;
        }
        /// <summary>
        /// 所有者の住所
        /// </summary>
        public string Owner_address {
            get => _owner_address;
            set => _owner_address = value;
        }
        /// <summary>
        /// 使用者の氏名又は名称
        /// </summary>
        public string User_name {
            get => _user_name;
            set => _user_name = value;
        }
        /// <summary>
        /// 使用者の住所
        /// </summary>
        public string User_address {
            get => _user_address;
            set => _user_address = value;
        }
        /// <summary>
        /// 使用の本拠の位置
        /// </summary>
        public string Base_address {
            get => _base_address;
            set => _base_address = value;
        }
        /// <summary>
        /// 有効期限の満了する日
        /// </summary>
        public DateTime Expiration_date {
            get => _expiration_date;
            set => _expiration_date = value;
        }
        /// <summary>
        /// 備考
        /// </summary>
        public string Remarks {
            get => _remarks;
            set => _remarks = value;
        }
        /// <summary>
        /// 車検証画像  
        /// </summary>
        public byte[] Picture {
            get => _picture;
            set => _picture = value;
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
