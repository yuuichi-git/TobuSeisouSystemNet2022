/*
 * 2023-08-26
 */
namespace Vo {
    public class LegalTwelveItemListVo {
        private readonly DateTime _default_datetime = new DateTime(1900,01,01);

        private int _occupation_code;
        private string _occupation_name;
        private int _staff_code;
        private string _staff_name;
        private DateTime _employment_date;
        private bool _students_01_flag;
        private bool _students_02_flag;
        private bool _students_03_flag;
        private bool _students_04_flag;
        private bool _students_05_flag;
        private bool _students_06_flag;
        private bool _students_07_flag;
        private bool _students_08_flag;
        private bool _students_09_flag;
        private bool _students_10_flag;
        private bool _students_11_flag;
        private bool _students_12_flag;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LegalTwelveItemListVo() {
            _occupation_code = 0;
            _occupation_name= string.Empty;
            _staff_code = 0;
            _staff_name = string.Empty;
            _employment_date = _default_datetime;
            _students_01_flag = false;
            _students_02_flag = false;
            _students_03_flag = false;
            _students_04_flag = false;
            _students_05_flag = false;
            _students_06_flag = false;
            _students_07_flag = false;
            _students_08_flag = false;
            _students_09_flag = false;
            _students_10_flag = false;
            _students_11_flag = false;
            _students_12_flag = false;
        }

        /// <summary>
        /// 職種コード
        /// </summary>
        public int Occupation_code {
            get => _occupation_code;
            set => _occupation_code = value;
        }
        /// <summary>
        /// 職種名
        /// </summary>
        public string Occupation_name {
            get => _occupation_name;
            set => _occupation_name = value;
        }
        /// <summary>
        /// 従業員コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 従業員名
        /// </summary>
        public string Staff_name {
            get => _staff_name;
            set => _staff_name = value;
        }
        /// <summary>
        /// 雇用年月日
        /// </summary>
        public DateTime Employment_date {
            get => _employment_date;
            set => _employment_date = value;
        }
        /// <summary>
        /// 項目１の受講フラグ
        /// </summary>
        public bool Students_01_flag {
            get => _students_01_flag;
            set => _students_01_flag = value;
        }
        /// <summary>
        /// 項目２の受講フラグ
        /// </summary>
        public bool Students_02_flag {
            get => _students_02_flag;
            set => _students_02_flag = value;
        }
        /// <summary>
        /// 項目３の受講フラグ
        /// </summary>
        public bool Students_03_flag {
            get => _students_03_flag;
            set => _students_03_flag = value;
        }
        /// <summary>
        /// 項目４の受講フラグ
        /// </summary>
        public bool Students_04_flag {
            get => _students_04_flag;
            set => _students_04_flag = value;
        }
        /// <summary>
        /// 項目５の受講フラグ
        /// </summary>
        public bool Students_05_flag {
            get => _students_05_flag;
            set => _students_05_flag = value;
        }
        /// <summary>
        /// 項目６の受講フラグ
        /// </summary>
        public bool Students_06_flag {
            get => _students_06_flag;
            set => _students_06_flag = value;
        }
        /// <summary>
        /// 項目７の受講フラグ
        /// </summary>
        public bool Students_07_flag {
            get => _students_07_flag;
            set => _students_07_flag = value;
        }
        /// <summary>
        /// 項目８の受講フラグ
        /// </summary>
        public bool Students_08_flag {
            get => _students_08_flag;
            set => _students_08_flag = value;
        }
        /// <summary>
        /// 項目９の受講フラグ
        /// </summary>
        public bool Students_09_flag {
            get => _students_09_flag;
            set => _students_09_flag = value;
        }
        /// <summary>
        /// 項目１０の受講フラグ
        /// </summary>
        public bool Students_10_flag {
            get => _students_10_flag;
            set => _students_10_flag = value;
        }
        /// <summary>
        /// 項目１１の受講フラグ
        /// </summary>
        public bool Students_11_flag {
            get => _students_11_flag;
            set => _students_11_flag = value;
        }
        /// <summary>
        /// 項目１２の受講フラグ
        /// </summary>
        public bool Students_12_flag {
            get => _students_12_flag;
            set => _students_12_flag = value;
        }
    }
}
