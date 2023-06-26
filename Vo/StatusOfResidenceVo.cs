/*
 * 2023-06-23
 */
namespace Vo {
    public class StatusOfResidenceVo {
        private int _staff_code;
        private string _staff_name;
        private string _staff_name_kana;
        private DateTime _birth_date;
        private string _gender;
        private string _nationality;
        private string _address;
        private string _status_of_residence;
        private string _work_limit;
        private DateTime _period_date;
        private DateTime _deadline_date;
        private byte[] _picture_head;
        private byte[] _picture_tail;
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private DateTime _defaultDateTime = new DateTime(1900,01,01);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public StatusOfResidenceVo() {
            _staff_code = 0;
            _staff_name = string.Empty;
            _staff_name_kana = string.Empty;
            _birth_date = _defaultDateTime;
            _gender = string.Empty;
            _nationality = string.Empty;
            _address = string.Empty;
            _status_of_residence = string.Empty;
            _work_limit = string.Empty;
            _period_date = _defaultDateTime;
            _deadline_date = _defaultDateTime;
            _picture_head = Array.Empty<byte>();
            _picture_tail = Array.Empty<byte>();
            _insert_ymd_hms = _defaultDateTime;
            _update_ymd_hms = _defaultDateTime;
            _delete_ymd_hms = _defaultDateTime;
            _delete_flag = false;
        }

        /// <summary>
        /// 従事者コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 従事者名
        /// </summary>
        public string Staff_name {
            get => _staff_name;
            set => _staff_name = value;
        }
        /// <summary>
        /// 従事者名カナ
        /// </summary>
        public string Staff_name_kana {
            get => _staff_name_kana;
            set => _staff_name_kana = value;
        }
        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime Birth_date {
            get => _birth_date;
            set => _birth_date = value;
        }
        /// <summary>
        /// 性別
        /// </summary>
        public string Gender {
            get => _gender;
            set => _gender = value;
        }
        /// <summary>
        /// 国籍・地域
        /// </summary>
        public string Nationality {
            get => _nationality;
            set => _nationality = value;
        }
        /// <summary>
        /// 住居地
        /// </summary>
        public string Address {
            get => _address;
            set => _address = value;
        }
        /// <summary>
        /// 在留資格
        /// </summary>
        public string Status_of_residence {
            get => _status_of_residence;
            set => _status_of_residence = value;
        }
        /// <summary>
        /// 就労制限の有無
        /// </summary>
        public string Work_limit {
            get => _work_limit;
            set => _work_limit = value;
        }
        /// <summary>
        /// 在留期間
        /// </summary>
        public DateTime Period_date {
            get => _period_date;
            set => _period_date = value;
        }
        /// <summary>
        /// 有効期限
        /// </summary>
        public DateTime Deadline_date {
            get => _deadline_date;
            set => _deadline_date = value;
        }
        public byte[] Picture_head {
            get => _picture_head;
            set => _picture_head = value;
        }
        public byte[] Picture_tail {
            get => _picture_tail;
            set => _picture_tail = value;
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
