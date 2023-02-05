namespace Vo {
    public class WardChiyodaVo {
        private DateTime _operation_date;
        private int _operator_code_1;
        private string _operator_name_1 = "";
        private int _operator_code_2;
        private string _operator_name_2 = "";
        private int _operator_code_3;
        private string _operator_name_3 = "";

        public DateTime Operation_date {
            get => _operation_date;
            set => _operation_date = value;
        }
        public int Operator_code_1 {
            get => _operator_code_1;
            set => _operator_code_1 = value;
        }
        public string Operator_name_1 {
            get => _operator_name_1;
            set => _operator_name_1 = value;
        }
        public int Operator_code_2 {
            get => _operator_code_2;
            set => _operator_code_2 = value;
        }
        public string Operator_name_2 {
            get => _operator_name_2;
            set => _operator_name_2 = value;
        }
        public int Operator_code_3 {
            get => _operator_code_3;
            set => _operator_code_3 = value;
        }
        public string Operator_name_3 {
            get => _operator_name_3;
            set => _operator_name_3 = value;
        }
    }
}
