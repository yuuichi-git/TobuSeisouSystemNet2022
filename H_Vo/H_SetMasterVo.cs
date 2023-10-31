/*
 * 配車先の基本情報
 * 13101～13123までが23区コード
 */
namespace H_Vo {
    public class H_SetMasterVo {
        private int _set_code;
        private int _word_code;
        private string _set_name;
        private string _set_name_1;
        private string _set_name_2;
        private int _fare_code;
        private bool _garage_flag;
        private int _classification_code;
        private int _contact_method;
        private int _number_of_people;
        private string _working_days;
        private bool _five_lap;
        private bool _move_flag;
        private string _remarks;
        private string _insert_pc_name;
        private DateTime _insert_ymd_hms;
        private string _update_pc_name;
        private DateTime _update_ymd_hms;
        private string _delete_pc_name;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_SetMasterVo() {
            _set_code = 0;
            _word_code = 0;
            _set_name = string.Empty;
            _set_name_1 = string.Empty;
            _set_name_2 = string.Empty;
            _fare_code = 0;
            _garage_flag = true;
            _classification_code = 0;
            _contact_method = 0;
            _number_of_people = 0;
            _working_days = string.Empty;
            _five_lap = true;
            _move_flag = true;
            _remarks = string.Empty;
            _insert_pc_name = string.Empty;
            _insert_ymd_hms = _defaultDateTime;
            _update_pc_name = string.Empty;
            _update_ymd_hms = _defaultDateTime;
            _delete_pc_name = string.Empty;
            _delete_ymd_hms = _defaultDateTime;
            _delete_flag = false;


        }

        /// <summary>
        /// 組番号
        /// </summary>
        public int Set_code {
            get => _set_code;
            set => _set_code = value;
        }
        /// <summary>
        /// 市区町村コード
        /// </summary>
        public int Word_code {
            get => _word_code;
            set => _word_code = value;
        }
        /// <summary>
        /// 組名
        /// </summary>
        public string Set_name {
            get => _set_name;
            set => _set_name = value;
        }
        /// <summary>
        /// 組名 略称1
        /// Label表示の1行目
        /// </summary>
        public string Set_name_1 {
            get => _set_name_1;
            set => _set_name_1 = value;
        }
        /// <summary>
        /// 組名 略称2
        /// Label表示の2行目
        /// </summary>
        public string Set_name_2 {
            get => _set_name_2;
            set => _set_name_2 = value;
        }
        /// <summary>
        /// 運賃コード
        /// </summary>
        public int Fare_code {
            get => _fare_code;
            set => _fare_code = value;
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
        /// 分類コード
        /// 10:雇上 11:区契 12:臨時 20:清掃工場 30:社内 50:一般 51:社用車 99:指定なし
        /// </summary>
        public int Classification_code {
            get => _classification_code;
            set => _classification_code = value;
        }
        /// <summary>
        /// 代番連絡方法
        /// 10:電話 11:Fax 12:しない
        /// </summary>
        public int Contact_method {
            get => _contact_method;
            set => _contact_method = value;
        }
        /// <summary>
        /// 配車基本人数
        /// 入力例:1～4
        /// </summary>
        public int Number_of_people {
            get => _number_of_people;
            set => _number_of_people = value;
        }
        /// <summary>
        /// 稼働日
        /// 入力例:"月火水木金土日"
        /// </summary>
        public string Working_days {
            get => _working_days;
            set => _working_days = value;
        }
        /// <summary>
        /// 第五週の稼働
        /// true:稼働 false:休車
        /// </summary>
        public bool Five_lap {
            get => _five_lap;
            set => _five_lap = value;
        }
        /// <summary>
        /// 移動フラグ
        /// true:移動できる false:移動できない
        /// </summary>
        public bool Move_flag {
            get => _move_flag;
            set => _move_flag = value;
        }
        /// <summary>
        /// 備考
        /// </summary>
        public string Remarks {
            get => _remarks;
            set => _remarks = value;
        }
        public string Insert_pc_name {
            get => _insert_pc_name;
            set => _insert_pc_name = value;
        }
        public DateTime Insert_ymd_hms {
            get => _insert_ymd_hms;
            set => _insert_ymd_hms = value;
        }
        public string Update_pc_name {
            get => _update_pc_name;
            set => _update_pc_name = value;
        }
        public DateTime Update_ymd_hms {
            get => _update_ymd_hms;
            set => _update_ymd_hms = value;
        }
        public string Delete_pc_name {
            get => _delete_pc_name;
            set => _delete_pc_name = value;
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
