namespace H_Vo {
    public class VehicleDispatchDetailCarVo {
        private int _cell_number;
        private DateTime _operation_date;
        private int _car_code;
        private bool _car_proxy_flag;
        private string _car_note = "";
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
        public int Car_code {
            get => _car_code;
            set => _car_code = value;
        }
        public bool Car_proxy_flag {
            get => _car_proxy_flag;
            set => _car_proxy_flag = value;
        }
        public string Car_note {
            get => _car_note;
            set => _car_note = value;
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
