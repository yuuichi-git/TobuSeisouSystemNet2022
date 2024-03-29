/*
 * 2023-08-24
 */
namespace Vo {
    public class LegalTwelveItemVo {
        private DateTime _students_date;
        private int _students_code;
        private bool _students_flag;
        private int _staff_code;
        private byte[] _staff_sign;
        private int _sign_number;
        private string _memo;
        private string _insert_pc_name;
        private DateTime _insert_ymd_hms;
        private string _update_pc_name;
        private DateTime _update_ymd_hms;
        private string _delete_pc_name;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private readonly DateTime _default_datetime = new(1900,01,01);
        /// <summary>
        /// コンストラクター
        /// </summary>
        public LegalTwelveItemVo() {
            _students_date = _default_datetime;
            _students_code = 0;
            _students_flag = false;
            _staff_code = 0;
            _staff_sign = Array.Empty<byte>();
            _sign_number = 0;
            _memo = string.Empty;
            _insert_pc_name = string.Empty;
            _insert_ymd_hms = _default_datetime;
            _update_pc_name = string.Empty;
            _update_ymd_hms = _default_datetime;
            _delete_pc_name = string.Empty;
            _delete_ymd_hms = _default_datetime;
            _delete_flag = false;
        }

        /// <summary>
        /// 受講日
        /// </summary>
        public DateTime Students_date {
            get => _students_date;
            set => _students_date = value;
        }
        /// <summary>
        /// 受講コード
        /// </summary>
        public int Students_code {
            get => _students_code;
            set => _students_code = value;
        }
        /// <summary>
        /// 受講フラグ
        /// </summary>
        public bool Students_flag {
            get => _students_flag;
            set => _students_flag = value;
        }
        /// <summary>
        /// 従事者コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 受講サイン
        /// </summary>
        public byte[] Staff_sign {
            get => _staff_sign;
            set => _staff_sign = value;
        }
        /// <summary>
        /// サイン番号
        /// 1→1回目のサイン:2→2回目のサイン:3→3回目のサイン
        /// </summary>
        public int Sign_number {
            get => _sign_number;
            set => _sign_number = value;
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string Memo {
            get => _memo;
            set => _memo = value;
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
