namespace H_Vo {
    public class VehicleDispatchDetailStaffVo {
        private int _cell_number;
        private DateTime _operation_date;
        private int _operator_code;
        private bool _operator_proxy_flag;
        private DateTime _operator_roll_call_ymd_hms;
        private string _operator_note = "";
        private string _insert_pc_name = "";
        private DateTime _insert_ymd_hms;
        private string _update_pc_name = "";
        private DateTime _update_ymd_hms;
        private string _delete_pc_name = "";
        private DateTime _delete_ymd_hms;
        private bool _delete_flag = false;

        public int Cell_number {
            get => _cell_number;
            set => _cell_number = value;
        }
        public DateTime Operation_date {
            get => _operation_date;
            set => _operation_date = value;
        }
        public int Operator_code {
            get => _operator_code;
            set => _operator_code = value;
        }
        public bool Operator_proxy_flag {
            get => _operator_proxy_flag;
            set => _operator_proxy_flag = value;
        }
        public DateTime Operator_roll_call_ymd_hms {
            get => _operator_roll_call_ymd_hms;
            set => _operator_roll_call_ymd_hms = value;
        }
        public string Operator_note {
            get => _operator_note;
            set => _operator_note = value;
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
