namespace Vo {
    public class RollCallDetailVo {
        private DateTime _operation_date;
        private string _roll_call_name_1 = "";
        private string _roll_call_name_2 = "";
        private string _roll_call_name_3 = "";
        private string _roll_call_name_4 = "";
        private string _roll_call_name_5 = "";
        private string _weather = "";
        private string _instruction1 = "";
        private string _instruction2 = "";
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag = false;

        /// <summary>
        /// 点呼日付
        /// </summary>
        public DateTime Operation_date {
            get => _operation_date;
            set => _operation_date = value;
        }
        /// <summary>
        /// 出庫時点呼執行者１
        /// </summary>
        public string Roll_call_name_1 {
            get => _roll_call_name_1;
            set => _roll_call_name_1 = value;
        }
        /// <summary>
        /// 出庫時点呼執行者２
        /// </summary>
        public string Roll_call_name_2 {
            get => _roll_call_name_2;
            set => _roll_call_name_2 = value;
        }
        /// <summary>
        /// 帰庫時点呼執行者１
        /// </summary>
        public string Roll_call_name_3 {
            get => _roll_call_name_3;
            set => _roll_call_name_3 = value;
        }
        /// <summary>
        /// 帰庫時点呼執行者２
        /// </summary>
        public string Roll_call_name_4 {
            get => _roll_call_name_4;
            set => _roll_call_name_4 = value;
        }
        /// <summary>
        /// 三郷車庫点呼執行者
        /// </summary>
        public string Roll_call_name_5 {
            get => _roll_call_name_5;
            set => _roll_call_name_5 = value;
        }
        /// <summary>
        /// 天候
        /// </summary>
        public string Weather {
            get => _weather;
            set => _weather = value;
        }
        /// <summary>
        /// 指示事項１
        /// </summary>
        public string Instruction1 {
            get => _instruction1;
            set => _instruction1 = value;
        }
        /// <summary>
        /// 指示事項２
        /// </summary>
        public string Instruction2 {
            get => _instruction2;
            set => _instruction2 = value;
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
