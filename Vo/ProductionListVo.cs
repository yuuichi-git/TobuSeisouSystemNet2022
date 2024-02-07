namespace H_Vo {
    public class ProductionListVo {

        private int _cell_number; // (vehicle_dispatch_Body) 配車表№
        private string _day_of_week = ""; // (vehicle_dispatch_Body) 対象の曜日
        private int _car_code; // (vehicle_dispatch_Body) 車両コード
        private int _operator_code_1; // (vehicle_dispatch_Body) 運転手
        private int _operator_code_2; // (vehicle_dispatch_Body) 作業員1
        private int _operator_code_3; // (vehicle_dispatch_Body) 作業員2
        private int _operator_code_4; // (vehicle_dispatch_Body) 作業員3
        private string _note = ""; // (vehicle_dispatch_Body) 組曜日に対するメモ
        private DateTime _financial_year; // (vehicle_dispatch_Body) 事業年度
        private DateTime _insert_ymd_hms; // (vehicle_dispatch_Body) 
        private DateTime _update_ymd_hms; // (vehicle_dispatch_Body)
        private DateTime _delete_ymd_hms; // (vehicle_dispatch_Body)
        private bool _delete_flag; // (vehicle_dispatch_Body)

        /// <summary>
        /// (vehicle_dispatch_Body) 配車表№
        /// </summary>
        public int Cell_number {
            get => _cell_number;
            set => _cell_number = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 対象の曜日
        /// </summary>
        public string Day_of_week {
            get => _day_of_week;
            set => _day_of_week = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 車両コード
        /// </summary>
        public int Car_code {
            get => _car_code;
            set => _car_code = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 運転手
        /// </summary>
        public int Operator_code_1 {
            get => _operator_code_1;
            set => _operator_code_1 = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 作業員1
        /// </summary>
        public int Operator_code_2 {
            get => _operator_code_2;
            set => _operator_code_2 = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 作業員2
        /// </summary>
        public int Operator_code_3 {
            get => _operator_code_3;
            set => _operator_code_3 = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 作業員3
        /// </summary>
        public int Operator_code_4 {
            get => _operator_code_4;
            set => _operator_code_4 = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 組曜日に対するメモ
        /// </summary>
        public string Note {
            get => _note;
            set => _note = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body) 事業年度
        /// </summary>
        public DateTime Financial_year {
            get => _financial_year;
            set => _financial_year = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body)
        /// </summary>
        public DateTime Insert_ymd_hms {
            get => _insert_ymd_hms;
            set => _insert_ymd_hms = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body)
        /// </summary>
        public DateTime Update_ymd_hms {
            get => _update_ymd_hms;
            set => _update_ymd_hms = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body)
        /// </summary>
        public DateTime Delete_ymd_hms {
            get => _delete_ymd_hms;
            set => _delete_ymd_hms = value;
        }
        /// <summary>
        /// (vehicle_dispatch_Body)
        /// </summary>
        public bool Delete_flag {
            get => _delete_flag;
            set => _delete_flag = value;
        }
    }
}
