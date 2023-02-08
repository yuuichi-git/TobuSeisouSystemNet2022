namespace Vo {
    public class WardChiyodaVo2 {
        private DateTime _operation_date;
        private string _operator_name = "";
        private string _occupation = "";

        /// <summary>
        /// Operation_date
        /// </summary>
        public DateTime Operation_date {
            get => _operation_date;
            set => _operation_date = value;
        }
        /// <summary>
        /// Display_Name
        /// </summary>
        public string Operator_name {
            get => _operator_name;
            set => _operator_name = value;
        }
        /// <summary>
        /// Occupation
        /// 運転手 作業員
        /// </summary>
        public string Occupation {
            get => _occupation;
            set => _occupation = value;
        }
    }
}
