namespace Vo {
    public class VehicleDispatchBodyVo {
        private int _cell_number; // 配車表№
        private string _day_of_week = ""; //対象の曜日
        private int _car_code;
        private int _operator_code_1; // 運転手
        private int _operator_code_2; // 作業員1
        private int _operator_code_3; // 作業員2
        private int _operator_code_4; // 作業員3
        private string _note = ""; // 組曜日に対するメモ
        private DateTime _financial_year; // 事業年度
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 配車№
        /// </summary>
        public int Cell_number {
            get => _cell_number;
            set => _cell_number = value;
        }
        /// <summary>
        /// 対象の曜日
        /// </summary>
        public string Day_of_week {
            get => _day_of_week;
            set => _day_of_week = value;
        }
        /// <summary>
        /// 車両コード
        /// </summary>
        public int Car_code {
            get => _car_code;
            set => _car_code = value;
        }
        /// <summary>
        /// 社員コード1
        /// </summary>
        public int Operator_code_1 {
            get => _operator_code_1;
            set => _operator_code_1 = value;
        }
        /// <summary>
        /// 社員コード2
        /// </summary>
        public int Operator_code_2 {
            get => _operator_code_2;
            set => _operator_code_2 = value;
        }
        /// <summary>
        /// 社員コード3
        /// </summary>
        public int Operator_code_3 {
            get => _operator_code_3;
            set => _operator_code_3 = value;
        }
        /// <summary>
        /// 社員コード4
        /// </summary>
        public int Operator_code_4 {
            get => _operator_code_4;
            set => _operator_code_4 = value;
        }
        /// <summary>
        /// 組曜日に対するメモ
        /// </summary>
        public string Note {
            get => _note;
            set => _note = value;
        }
        /// <summary>
        /// 事業年度
        /// </summary>
        public DateTime Financial_year {
            get => _financial_year;
            set => _financial_year = value;
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
