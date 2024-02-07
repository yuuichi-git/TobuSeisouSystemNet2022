/*
 * 各種マスターを元に本番登録を保持する
 */
namespace H_Vo {
    public class VehicleDispatchHeadVo {
        private int _cell_number; // 配車表№
        private bool _garage_flag; // 車庫地
        private string _day_of_week = ""; // 稼働曜日
        private bool _five_lap; // 第５週
        private bool _move_flag; // 移動フラグ
        private int _set_code; // 組№
        private int _car_code; // 車両
        private int _number_of_people; // 配車基本人数
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
        /// 車庫地
        /// true:足立 false:三郷
        /// </summary>
        public bool Garage_flag {
            get => _garage_flag;
            set => _garage_flag = value;
        }
        /// <summary>
        /// 稼働日
        /// 入力例:"月火水木金土日"
        /// </summary>
        public string Day_of_week {
            get => _day_of_week;
            set => _day_of_week = value;
        }
        /// <summary>
        /// 第五週の稼働
        /// true:稼働 false:休車
        /// </summary>
        public bool Five_lap {
            get => _five_lap;
            set => _five_lap = value;
        }
        /// <summary>
        /// 移動フラグ
        /// true:移動できる false:移動できない
        /// </summary>
        public bool Move_flag {
            get => _move_flag;
            set => _move_flag = value;
        }
        /// <summary>
        /// 組コード
        /// </summary>
        public int Set_code {
            get => _set_code;
            set => _set_code = value;
        }
        /// <summary>
        /// 車両コード
        /// </summary>
        public int Car_code {
            get => _car_code;
            set => _car_code = value;
        }
        /// <summary>
        /// 配車基本人数
        /// </summary>
        public int Number_of_people {
            get => _number_of_people;
            set => _number_of_people = value;
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
