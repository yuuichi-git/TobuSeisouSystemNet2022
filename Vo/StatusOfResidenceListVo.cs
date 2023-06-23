/*
 * 2023-06-23
 */
namespace Vo {
    public class StatusOfResidenceListVo {
        private string _staff_name;
        private string _staff_name_kana;
        private DateTime _birth_date;
        private string _sex;
        private string _nationality;
        private string _address;
        private string _status_of_residence;
        private string _work_limit;
        private DateTime _period_date;
        private DateTime _deadline_date;

        private DateTime _defaultDateTime = new DateTime(1900,01,01);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public StatusOfResidenceListVo() {
            _staff_name = string.Empty;
            _staff_name_kana = string.Empty;
            _birth_date = _defaultDateTime;
            _sex = string.Empty;
            _nationality = string.Empty;
            _address = string.Empty;
            _status_of_residence = string.Empty;
            _work_limit = string.Empty;
            _period_date = _defaultDateTime;
            _deadline_date = _defaultDateTime;
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
        public string Sex {
            get => _sex;
            set => _sex = value;
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
    }
}
