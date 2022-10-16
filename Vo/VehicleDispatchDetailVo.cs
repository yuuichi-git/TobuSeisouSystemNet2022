namespace Vo {
    public class VehicleDispatchDetailVo {
        private int _cell_number;
        private DateTime _operation_date;
        private bool _operation_flag;
        private bool _garage_flag;
        private bool _five_lap;
        private bool _move_flag;
        private string _day_of_week = "";
        private int _set_code;
        private string _set_note = "";
        private int _car_code;
        private bool _car_proxy_flag;
        private string _car_note = "";
        private int _number_of_people;
        private int _operator_code_1;
        private bool _operator_1_proxy_flag;
        private DateTime _operator_1_roll_call_ymd_hms;
        private string _operator_1_note = "";
        private int _operator_code_2;
        private bool _operator_2_proxy_flag;
        private DateTime _operator_2_roll_call_ymd_hms;
        private string _operator_2_note = "";
        private int _operator_code_3;
        private bool _operator_3_proxy_flag;
        private DateTime _operator_3_roll_call_ymd_hms;
        private string _operator_3_note = "";
        private int _operator_code_4;
        private bool _operator_4_proxy_flag;
        private DateTime _operator_4_roll_call_ymd_hms;
        private string _operator_4_note = "";
        private string _insert_pc_name = "";
        private DateTime _insert_ymd_hms;
        private string _update_pc_name = "";
        private DateTime _update_ymd_hms;
        private string _delete_pc_name = "";
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 配車表№
        /// </summary>
        public int Cell_number {
            get => _cell_number;
            set => _cell_number = value;
        }
        /// <summary>
        /// 稼働日
        /// </summary>
        public DateTime Operation_date {
            get => _operation_date;
            set => _operation_date = value;
        }
        /// <summary>
        /// 稼働フラグ
        /// true:稼働 false:休車
        /// </summary>
        public bool Operation_flag {
            get => _operation_flag;
            set => _operation_flag = value;
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
        /// 稼働日
        /// 入力例:"月火水木金土日"
        /// </summary>
        public string Day_of_week {
            get => _day_of_week;
            set => _day_of_week = value;
        }
        /// <summary>
        /// 組コード
        /// </summary>
        public int Set_code {
            get => _set_code;
            set => _set_code = value;
        }
        /// <summary>
        /// 組メモ
        /// </summary>
        public string Set_note {
            get => _set_note;
            set => _set_note = value;
        }
        /// <summary>
        /// 車両コード
        /// </summary>
        public int Car_code {
            get => _car_code;
            set => _car_code = value;
        }
        /// <summary>
        /// 車両代車フラグ
        /// true:代番 false:本番
        /// </summary>
        public bool Car_proxy_flag {
            get => _car_proxy_flag;
            set => _car_proxy_flag = value;
        }
        /// <summary>
        /// 車両メモ
        /// </summary>
        public string Car_note {
            get => _car_note;
            set => _car_note = value;
        }
        /// <summary>
        /// 配車基本人数
        /// </summary>
        public int Number_of_people {
            get => _number_of_people;
            set => _number_of_people = value;
        }
        /// <summary>
        /// 社員コード1
        /// </summary>
        public int Operator_code_1 {
            get => _operator_code_1;
            set => _operator_code_1 = value;
        }
        /// <summary>
        /// 代番フラグ1
        /// true:代番 false:本番
        /// </summary>
        public bool Operator_1_proxy_flag {
            get => _operator_1_proxy_flag;
            set => _operator_1_proxy_flag = value;
        }
        /// <summary>
        /// 点呼日時1
        /// </summary>
        public DateTime Operator_1_roll_call_ymd_hms {
            get => _operator_1_roll_call_ymd_hms;
            set => _operator_1_roll_call_ymd_hms = value;
        }
        /// <summary>
        /// 社員メモ1
        /// </summary>
        public string Operator_1_note {
            get => _operator_1_note;
            set => _operator_1_note = value;
        }
        /// <summary>
        /// 社員コード2
        /// </summary>
        public int Operator_code_2 {
            get => _operator_code_2;
            set => _operator_code_2 = value;
        }
        /// <summary>
        /// 代番フラグ2
        /// true:代番 false:本番
        /// </summary>
        public bool Operator_2_proxy_flag {
            get => _operator_2_proxy_flag;
            set => _operator_2_proxy_flag = value;
        }
        /// <summary>
        /// 点呼日時2
        /// </summary>
        public DateTime Operator_2_roll_call_ymd_hms {
            get => _operator_2_roll_call_ymd_hms;
            set => _operator_2_roll_call_ymd_hms = value;
        }
        /// <summary>
        /// 社員メモ2
        /// </summary>
        public string Operator_2_note {
            get => _operator_2_note;
            set => _operator_2_note = value;
        }
        /// <summary>
        /// 社員コード3
        /// </summary>
        public int Operator_code_3 {
            get => _operator_code_3;
            set => _operator_code_3 = value;
        }
        /// <summary>
        /// 代番フラグ3
        /// true:代番 false:本番
        /// </summary>
        public bool Operator_3_proxy_flag {
            get => _operator_3_proxy_flag;
            set => _operator_3_proxy_flag = value;
        }
        /// <summary>
        /// 点呼日時3
        /// </summary>
        public DateTime Operator_3_roll_call_ymd_hms {
            get => _operator_3_roll_call_ymd_hms;
            set => _operator_3_roll_call_ymd_hms = value;
        }
        /// <summary>
        /// 社員メモ3
        /// </summary>
        public string Operator_3_note {
            get => _operator_3_note;
            set => _operator_3_note = value;
        }
        /// <summary>
        /// 社員コード4
        /// </summary>
        public int Operator_code_4 {
            get => _operator_code_4;
            set => _operator_code_4 = value;
        }
        /// <summary>
        /// 代番フラグ4
        /// true:代番 false:本番
        /// </summary>
        public bool Operator_4_proxy_flag {
            get => _operator_4_proxy_flag;
            set => _operator_4_proxy_flag = value;
        }
        /// <summary>
        /// 点呼日時4
        /// </summary>
        public DateTime Operator_4_roll_call_ymd_hms {
            get => _operator_4_roll_call_ymd_hms;
            set => _operator_4_roll_call_ymd_hms = value;
        }
        /// <summary>
        /// 社員メモ4
        /// </summary>
        public string Operator_4_note {
            get => _operator_4_note;
            set => _operator_4_note = value;
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
