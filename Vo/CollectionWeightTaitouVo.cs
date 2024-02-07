/*
 * 2023-07-25
 */
namespace H_Vo {
    public class CollectionWeightTaitouVo {
        private DateTime _operation_date;
        private int _weight1Total;
        private int _weight2Total;
        private int _weight3Total;
        private int _weight4Total;
        private int _weight5Total;
        private int _weight6Total;
        private int _weight7Total;
        private string _insert_pc_name;
        private DateTime _insert_ymd_hms;
        private string _update_pc_name;
        private DateTime _update_ymd_hms;
        private string _delete_pc_name;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private readonly DateTime _defaultDateTime = new(1900,01,01);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CollectionWeightTaitouVo() {
            _operation_date = _defaultDateTime;
            _weight1Total = 0;
            _weight2Total = 0;
            _weight3Total = 0;
            _weight4Total = 0;
            _weight5Total = 0;
            _weight6Total = 0;
            _weight7Total = 0;
            _insert_pc_name = string.Empty;
            _insert_ymd_hms = _defaultDateTime;
            _update_pc_name = string.Empty;
            _update_ymd_hms = _defaultDateTime;
            _delete_pc_name = string.Empty;
            _delete_ymd_hms = _defaultDateTime;
            _delete_flag = false;
        }

        /// <summary>
        /// 収集日
        /// </summary>
        public DateTime Operation_date {
            get => _operation_date;
            set => _operation_date = value;
        }
        /// <summary>
        /// 台東１組(東武)の収集量
        /// </summary>
        public int Weight1Total {
            get => _weight1Total;
            set => _weight1Total = value;
        }
        /// <summary>
        /// 台東２組(東武)の収集量
        /// </summary>
        public int Weight2Total {
            get => _weight2Total;
            set => _weight2Total = value;
        }
        /// <summary>
        /// 台東４組(東武)の収集量
        /// </summary>
        public int Weight3Total {
            get => _weight3Total;
            set => _weight3Total = value;
        }
        /// <summary>
        /// 台東臨時(東武)の収集量
        /// </summary>
        public int Weight4Total {
            get => _weight4Total;
            set => _weight4Total = value;
        }
        /// <summary>
        /// 台東３(三東)組の収集量
        /// </summary>
        public int Weight5Total {
            get => _weight5Total;
            set => _weight5Total = value;
        }
        /// <summary>
        /// 台東軽(三東)の収集量
        /// </summary>
        public int Weight6Total {
            get => _weight6Total;
            set => _weight6Total = value;
        }
        /// <summary>
        /// 台東臨時(三東)の収集量
        /// </summary>
        public int Weight7Total {
            get => _weight7Total;
            set => _weight7Total = value;
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
