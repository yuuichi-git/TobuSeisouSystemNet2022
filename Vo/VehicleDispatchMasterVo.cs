/*
 * 各種マスターを元に本番登録を記録する
 */
namespace Vo {
    public class VehicleDispatchMasterVo {
        private int _cell_number; // 配車表№
        private bool _garage_flag; // 車庫地
        private bool _service_day; // 稼働日フラグ
        private string _day_of_week = ""; // 稼働曜日
        private int _set_code; // 組№
        private int _car_code; // 車両
        private int _number_of_people; // 配車基本人数
        private int _operator_code_1; // 運転手
        private int _operator_code_2; // 作業員1
        private int _operator_code_3; // 作業員2
        private int _operator_code_4; // 作業員3
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        public VehicleDispatchMasterVo() {
        }

    }
}
