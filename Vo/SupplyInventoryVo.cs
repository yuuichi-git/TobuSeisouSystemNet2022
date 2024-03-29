/*
 * 2023-06-12
 */
namespace Vo {
    public class SupplyInventoryVo {
        private DateTime _inventory_date;
        private int _code;
        private string _name;
        private int _properStock;
        private string _memo;
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private DateTime _defaultDateTime = new(1900,01,01);
        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyInventoryVo() {
            _inventory_date = _defaultDateTime;
            _code = 0;
            _name = string.Empty;
            _properStock = 0;
            _memo = string.Empty;
            _insert_ymd_hms = _defaultDateTime;
            _update_ymd_hms = _defaultDateTime;
            _delete_ymd_hms = _defaultDateTime;
            _delete_flag = false;


        }

        /// <summary>
        /// 棚卸年月(xx年xx月01日)
        /// </summary>
        public DateTime Inventory_date {
            get => _inventory_date;
            set => _inventory_date = value;
        }
        /// <summary>
        /// 備品コード 1:事務 2:雇上 3:産廃 4:水物
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
        /// 在庫数
        /// </summary>
        public int ProperStock {
            get => _properStock;
            set => _properStock = value;
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string Memo {
            get => _memo;
            set => _memo = value;
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
