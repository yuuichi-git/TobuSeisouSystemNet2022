namespace H_Vo {
    public class StaffMasterExcelVo {
        private int _row;
        private int _code;
        private string _display_name = "";
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        public int Row {
            get => _row;
            set => _row = value;
        }
        public int Code {
            get => _code;
            set => _code = value;
        }
        public string Display_name {
            get => _display_name;
            set => _display_name = value;
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
