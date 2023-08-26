/*
 * 2023-08-26
 */
namespace Vo {
    public class LegalTwelveItemFormVo {
        private int _occupation_code;
        private string _occupation_name;
        private int _staff_code;
        private string _staff_name;
        private DateTime _employment_date;
        private bool _students_01;
        private bool _students_02;
        private bool _students_03;
        private bool _students_04;
        private bool _students_05;
        private bool _students_06;
        private bool _students_07;
        private bool _students_08;
        private bool _students_09;
        private bool _students_10;
        private bool _students_11;
        private bool _students_12;

        private readonly DateTime _default_datetime = new DateTime(1900,01,01);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LegalTwelveItemFormVo() {
            _occupation_code = 0;
            _occupation_name= string.Empty;
            _staff_code = 0;
            _staff_name = string.Empty;
            _employment_date = _default_datetime;
            _students_01 = false;
            _students_02 = false;
            _students_03 = false;
            _students_04 = false;
            _students_05 = false;
            _students_06 = false;
            _students_07 = false;
            _students_08 = false;
            _students_09 = false;
            _students_10 = false;
            _students_11 = false;
            _students_12 = false;
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
        public bool Students_01 {
            get => _students_01;
            set => _students_01 = value;
        }
        /// <summary>
        /// 項目２の受講フラグ
        /// </summary>
        public bool Students_02 {
            get => _students_02;
            set => _students_02 = value;
        }
        /// <summary>
        /// 項目３の受講フラグ
        /// </summary>
        public bool Students_03 {
            get => _students_03;
            set => _students_03 = value;
        }
        /// <summary>
        /// 項目４の受講フラグ
        /// </summary>
        public bool Students_04 {
            get => _students_04;
            set => _students_04 = value;
        }
        /// <summary>
        /// 項目５の受講フラグ
        /// </summary>
        public bool Students_05 {
            get => _students_05;
            set => _students_05 = value;
        }
        /// <summary>
        /// 項目６の受講フラグ
        /// </summary>
        public bool Students_06 {
            get => _students_06;
            set => _students_06 = value;
        }
        /// <summary>
        /// 項目７の受講フラグ
        /// </summary>
        public bool Students_07 {
            get => _students_07;
            set => _students_07 = value;
        }
        /// <summary>
        /// 項目８の受講フラグ
        /// </summary>
        public bool Students_08 {
            get => _students_08;
            set => _students_08 = value;
        }
        /// <summary>
        /// 項目９の受講フラグ
        /// </summary>
        public bool Students_09 {
            get => _students_09;
            set => _students_09 = value;
        }
        /// <summary>
        /// 項目１０の受講フラグ
        /// </summary>
        public bool Students_10 {
            get => _students_10;
            set => _students_10 = value;
        }
        /// <summary>
        /// 項目１１の受講フラグ
        /// </summary>
        public bool Students_11 {
            get => _students_11;
            set => _students_11 = value;
        }
        /// <summary>
        /// 項目１２の受講フラグ
        /// </summary>
        public bool Students_12 {
            get => _students_12;
            set => _students_12 = value;
        }
    }
}
