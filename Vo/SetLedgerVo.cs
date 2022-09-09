namespace Vo {
    /*
     * DeepCopyで使用
     */
    [Serializable] // ←DeepCopyする場合には必要
    public class SetLedgerVo {
        private int _set_code;
        private string? _set_name;
        private string? _set_name_1;
        private string? _set_name_2;
        private bool _garage_flag;
        private int _classification_code;
        private int _contact_method;
        private int _number_of_people;
        private string? _working_days;
        private bool _five_lap;
        private string? _remarks;
        private DateTime _insert_ymd_hms;
        private DateTime? _update_ymd_hms;
        private DateTime? _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 組番号
        /// </summary>
        public int Set_code {
            get => _set_code;
            set => _set_code = value;
        }
        /// <summary>
        /// 組名
        /// </summary>
        public string? Set_name {
            get => _set_name;
            set => _set_name = value;
        }
        /// <summary>
        /// 組名 略称1
        /// Label表示の1行目
        /// </summary>
        public string? Set_name_1 {
            get => _set_name_1;
            set => _set_name_1 = value;
        }
        /// <summary>
        /// 組名 略称2
        /// Label表示の2行目
        /// </summary>
        public string? Set_name_2 {
            get => _set_name_2;
            set => _set_name_2 = value;
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
        /// 10:雇上 11:区契約 12:臨時 20:清掃工場 30:社内
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
        /// </summary>
        public int Number_of_people {
            get => _number_of_people;
            set => _number_of_people = value;
        }
        /// <summary>
        /// 稼働日
        /// 入力例:"月火水木金土日"
        /// </summary>
        public string? Working_days {
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
        /// 備考
        /// </summary>
        public string? Remarks {
            get => _remarks;
            set => _remarks = value;
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
        /// <summary>
        /// 削除フラグ
        /// </summary>
        public bool Delete_flag {
            get => _delete_flag;
            set => _delete_flag = value;
        }
    }
}
