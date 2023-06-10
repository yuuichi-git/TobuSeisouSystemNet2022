namespace Vo {
    public class SupplyMasterVo {
        private int _code;
        private string _name;
        private int _proper_stock;
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);

        public SupplyMasterVo() {
            _code = 0;
            _name = string.Empty;
            _proper_stock = 0;
            _insert_ymd_hms = _defaultDateTime;
            _update_ymd_hms = _defaultDateTime;
            _delete_ymd_hms = _defaultDateTime;
            _delete_flag = false;
        }

        /// <summary>
        /// 備品コード
        /// </summary>
        public int Code {
            get => _code;
            set => _code = value;
        }
        /// <summary>
        /// 備品名
        /// </summary>
        public string Name {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// 適正在庫数
        /// </summary>
        public int Proper_stock {
            get => _proper_stock;
            set => _proper_stock = value;
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
