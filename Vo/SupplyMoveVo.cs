/*
 * 2023-06-05
 */
namespace Vo {
    public class SupplyMoveVo {
        private int _staff_code;
        private DateTime _move_date;
        private int _supply_code;
        private int _supply_number;
        private bool _move_flag;
        private string _insert_pc_name = string.Empty;
        private DateTime _insert_ymd_hms;
        private string _update_pc_name = string.Empty;
        private DateTime _update_ymd_hms;
        private string _delete_pc_name = string.Empty;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 従事者コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }

        /// <summary>
        /// 入出庫年月日
        /// </summary>
        public DateTime Move_date {
            get => _move_date;
            set => _move_date = value;
        }

        /// <summary>
        /// 備品コード
        /// </summary>
        public int Supply_code {
            get => _supply_code;
            set => _supply_code = value;
        }

        /// <summary>
        /// 備品入出庫数
        /// </summary>
        public int Supply_number {
            get => _supply_number;
            set => _supply_number = value;
        }

        /// <summary>
        /// 入出庫フラグ
        /// true:入庫 false:出庫
        /// </summary>
        public bool Move_flag {
            get => _move_flag;
            set => _move_flag = value;
        }

        /// <summary>
        /// Insert PC名
        /// </summary>
        public string Insert_pc_name {
            get => _insert_pc_name;
            set => _insert_pc_name = value;
        }

        public DateTime Insert_ymd_hms {
            get => _insert_ymd_hms;
            set => _insert_ymd_hms = value;
        }

        /// <summary>
        /// Update PC名
        /// </summary>
        public string Update_pc_name {
            get => _update_pc_name;
            set => _update_pc_name = value;
        }

        public DateTime Update_ymd_hms {
            get => _update_ymd_hms;
            set => _update_ymd_hms = value;
        }

        /// <summary>
        /// Delete PC名
        /// </summary>
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
