﻿/*
 * 2023-01-08
 * 帰庫点呼関連
 * 2023-02-10 
 * 職種コードを追加(occupation)
 * 2023-05-04
 * 早番遅番コード
 * 2023-09-21
 * _fax_transmission_flagを追加
 */
namespace Vo {
    public class VehicleDispatchDetailVo {
        private readonly DateTime _default_datetime = new DateTime(1900,01,01);

        private int _cell_number;
        private DateTime _operation_date;
        private bool _operation_flag;
        private bool _garage_flag;
        private bool _five_lap;
        private bool _move_flag;
        private string _day_of_week;
        private int _shift_code;
        private bool _stand_by_flag;
        private bool _classification_flag;
        private bool _add_worker_flag;
        private bool _contact_infomation_flag;
        private bool _fax_transmission_flag;
        private int _set_code;
        private string _set_note;
        private int _car_code;
        private bool _car_proxy_flag;
        private string _car_note;
        private int _number_of_people;
        private int _operator_code_1;
        private bool _operator_1_proxy_flag;
        private bool _operator_1_roll_call_flag;
        private DateTime _operator_1_roll_call_ymd_hms;
        private string _operator_1_note;
        private int _operator_1_occupation; // 職種
        private int _operator_code_2;
        private bool _operator_2_proxy_flag;
        private bool _operator_2_roll_call_flag;
        private DateTime _operator_2_roll_call_ymd_hms;
        private string _operator_2_note;
        private int _operator_2_occupation; // 職種
        private int _operator_code_3;
        private bool _operator_3_proxy_flag;
        private bool _operator_3_roll_call_flag;
        private DateTime _operator_3_roll_call_ymd_hms;
        private string _operator_3_note;
        private int _operator_3_occupation; // 職種
        private int _operator_code_4;
        private bool _operator_4_proxy_flag;
        private bool _operator_4_roll_call_flag;
        private DateTime _operator_4_roll_call_ymd_hms;
        private string _operator_4_note;
        private int _operator_4_occupation; // 職種

        private bool _last_roll_call_flag; // 帰庫点呼関連
        private int _last_plant_count; // 帰庫点呼関連
        private string _last_plant_name; // 帰庫点呼関連
        private string _last_plant_hm; // 帰庫点呼関連
        private string _last_roll_call_hm; // 帰庫点呼関連

        private string _insert_pc_name;
        private DateTime _insert_ymd_hms;
        private string _update_pc_name;
        private DateTime _update_ymd_hms;
        private string _delete_pc_name;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public VehicleDispatchDetailVo() {
            _cell_number = 0;
            _operation_date = _default_datetime;
            _operation_flag = false;
            _garage_flag = false;
            _five_lap = false;
            _move_flag = false;
            _day_of_week = string.Empty;
            _shift_code = 0;
            _stand_by_flag = false;
            _classification_flag = false;
            _add_worker_flag = false;
            _contact_infomation_flag = false;
            _fax_transmission_flag = false;
            _set_code = 0;
            _set_note = string.Empty;
            _car_code = 0;
            _car_proxy_flag = false;
            _car_note = string.Empty;
            _number_of_people = 0;
            _operator_code_1 = 0;
            _operator_1_proxy_flag = false;
            _operator_1_roll_call_flag = false;
            _operator_1_roll_call_ymd_hms = _default_datetime;
            _operator_1_note = string.Empty;
            _operator_1_occupation = 0; // 職種
            _operator_code_2 = 0;
            _operator_2_proxy_flag = false;
            _operator_2_roll_call_flag = false;
            _operator_2_roll_call_ymd_hms = _default_datetime;
            _operator_2_note = string.Empty;
            _operator_2_occupation = 0; // 職種
            _operator_code_3 = 0;
            _operator_3_proxy_flag = false;
            _operator_3_roll_call_flag = false;
            _operator_3_roll_call_ymd_hms = _default_datetime;
            _operator_3_note = string.Empty;
            _operator_3_occupation = 0; // 職種
            _operator_code_4 = 0;
            _operator_4_proxy_flag = false;
            _operator_4_roll_call_flag = false;
            _operator_4_roll_call_ymd_hms = _default_datetime;
            _operator_4_note = string.Empty;
            _operator_4_occupation = 0; // 職種

            _last_roll_call_flag = false; // 帰庫点呼関連
            _last_plant_count = 0; // 帰庫点呼関連
            _last_plant_name = string.Empty; // 帰庫点呼関連
            _last_plant_hm = string.Empty; // 帰庫点呼関連
            _last_roll_call_hm = string.Empty; // 帰庫点呼関連

            _insert_pc_name = string.Empty;
            _insert_ymd_hms = _default_datetime;
            _update_pc_name = string.Empty;
            _update_ymd_hms = _default_datetime;
            _delete_pc_name = string.Empty;
            _delete_ymd_hms = _default_datetime;
            _delete_flag = false;
        }
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
        /// 番手コード
        /// 0:指定なし 1:早番 2:遅番
        /// </summary>
        public int Shift_code {
            get => _shift_code;
            set => _shift_code = value;
        }
        /// <summary>
        /// 待機フラグ(北粗大・台東資源)
        /// </summary>
        public bool Stand_by_flag {
            get => _stand_by_flag;
            set => _stand_by_flag = value;
        }
        /// <summary>
        /// 雇上・区契フラグ
        /// true:雇上 false:区契
        /// </summary>
        public bool Classification_flag {
            get => _classification_flag;
            set => _classification_flag = value;
        }
        /// <summary>
        /// 作業員付きフラグ
        /// true:作業員付き false:作業員なし
        /// </summary>
        public bool Add_worker_flag {
            get => _add_worker_flag;
            set => _add_worker_flag = value;
        }
        /// <summary>
        /// 連絡事項フラグ
        /// true:連絡事項あり false:連絡事項なし
        /// </summary>
        public bool Contact_infomation_flag {
            get => _contact_infomation_flag;
            set => _contact_infomation_flag = value;
        }
        /// <summary>
        /// Fax送信フラグ
        /// true:Fax送信対象 false:なし
        /// </summary>
        public bool Fax_transmission_flag {
            get => _fax_transmission_flag;
            set => _fax_transmission_flag = value;
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
        /// 点呼フラグ1
        /// </summary>
        public bool Operator_1_roll_call_flag {
            get => _operator_1_roll_call_flag;
            set => _operator_1_roll_call_flag = value;
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
        /// 職種
        /// 10:運転手 11:作業員 99 指定なし
        /// </summary>
        public int Operator_1_occupation {
            get => _operator_1_occupation;
            set => _operator_1_occupation = value;
        }
        /// <summary>
        /// 社員コード2
        /// </summary>
        public int Operator_code_2 {
            get => _operator_code_2;
            set => _operator_code_2 = value;
        }
        /// <summary>
        /// 点呼フラグ2
        /// </summary>
        public bool Operator_2_roll_call_flag {
            get => _operator_2_roll_call_flag;
            set => _operator_2_roll_call_flag = value;
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
        /// 職種
        /// 10:運転手 11:作業員 99 指定なし
        /// </summary>
        public int Operator_2_occupation {
            get => _operator_2_occupation;
            set => _operator_2_occupation = value;
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
        /// 点呼フラグ3
        /// </summary>
        public bool Operator_3_roll_call_flag {
            get => _operator_3_roll_call_flag;
            set => _operator_3_roll_call_flag = value;
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
        /// 職種
        /// 10:運転手 11:作業員 99 指定なし
        /// </summary>
        public int Operator_3_occupation {
            get => _operator_3_occupation;
            set => _operator_3_occupation = value;
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
        /// 点呼フラグ4
        /// </summary>
        public bool Operator_4_roll_call_flag {
            get => _operator_4_roll_call_flag;
            set => _operator_4_roll_call_flag = value;
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
        /// <summary>
        /// 職種
        /// 10:運転手 11:作業員 99 指定なし
        /// </summary>
        public int Operator_4_occupation {
            get => _operator_4_occupation;
            set => _operator_4_occupation = value;
        }
        /// <summary>
        /// 帰庫点呼フラグ
        /// true:帰庫点呼を実施 false:未実施
        /// </summary>
        public bool Last_roll_call_flag {
            get => _last_roll_call_flag;
            set => _last_roll_call_flag = value;
        }
        /// <summary>
        /// 収集回数
        /// </summary>
        public int Last_plant_count {
            get => _last_plant_count;
            set => _last_plant_count = value;
        }
        /// <summary>
        /// 最終空け場名
        /// </summary>
        public string Last_plant_name {
            get => _last_plant_name;
            set => _last_plant_name = value;
        }
        /// <summary>
        /// 最終空け日時
        /// </summary>
        public string Last_plant_hm {
            get => _last_plant_hm;
            set => _last_plant_hm = value;
        }
        /// <summary>
        /// 帰庫点呼日時
        /// </summary>
        public string Last_roll_call_hm {
            get => _last_roll_call_hm;
            set => _last_roll_call_hm = value;
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
