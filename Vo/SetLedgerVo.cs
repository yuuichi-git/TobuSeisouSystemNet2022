namespace Vo {
    public class SetLedgerVo {
        /// <summary>
        /// 組番号
        /// </summary>
        private decimal _set_code;
        /// <summary>
        /// 組名
        /// </summary>
        private string? _set_name;
        /// <summary>
        /// 組名 略称1
        /// Label表示の1行目
        /// </summary>
        private string? _set_name_1;
        /// <summary>
        /// 組名 略称2
        /// Label表示の2行目
        /// </summary>
        private string? _set_name_2;
        /// <summary>
        /// 車庫地
        /// true:足立 false:三郷
        /// </summary>
        private bool _garage_flag;
        /// <summary>
        /// 分類コード
        /// 1:雇上 2:区契約 3:臨時 4:清掃工場 5:社内
        /// </summary>
        private int _classification_code;
        /// <summary>
        /// 代番連絡方法
        /// 1:電話 2:Fax 3:しない
        /// </summary>
        private string? _contact_method;
        /// <summary>
        /// 配車基本人数
        /// </summary>
        private int _number_of_people;
        /// <summary>
        /// 稼働日
        /// </summary>
        private string? _working_days;
        /// <summary>
        /// 第五週の稼働
        /// </summary>
        private bool _five_lap;
        /// <summary>
        /// 備考
        /// </summary>
        private string? _remarks;
        private DateTime _insert_ymd_hms;
        private DateTime? _update_ymd_hms;
        private DateTime? _delete_ymd_hms;
        private bool _delete_flag;

        public decimal Set_code {
            get => _set_code;
            set => _set_code = value;
        }
        public string? Set_name {
            get => _set_name;
            set => _set_name = value;
        }
        public string? Set_name_1 {
            get => _set_name_1;
            set => _set_name_1 = value;
        }
        public string? Set_name_2 {
            get => _set_name_2;
            set => _set_name_2 = value;
        }
        public bool Garage_flag {
            get => _garage_flag;
            set => _garage_flag = value;
        }
        public int Classification_code {
            get => _classification_code;
            set => _classification_code = value;
        }
        public string? Contact_method {
            get => _contact_method;
            set => _contact_method = value;
        }
        public int Number_of_people {
            get => _number_of_people;
            set => _number_of_people = value;
        }
        public string? Working_days {
            get => _working_days;
            set => _working_days = value;
        }
        public bool Five_lap {
            get => _five_lap;
            set => _five_lap = value;
        }
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
        public bool Delete_flag {
            get => _delete_flag;
            set => _delete_flag = value;
        }
    }
}
