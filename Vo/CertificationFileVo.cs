namespace H_Vo {
    public class CertificationFileVo {
        private int _staff_code;
        private string _staff_name = "";
        private int _certification_code;
        private string _certification_name = "";
        private int _mark_code;
        private DateTime _insert_ymd_hms;

        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        public string Staff_name {
            get => _staff_name;
            set => _staff_name = value;
        }
        public int Certification_code {
            get => _certification_code;
            set => _certification_code = value;
        }
        public string Certification_name {
            get => _certification_name;
            set => _certification_name = value;
        }
        /// <summary>
        /// 〇印の種類　"◎", "○", "●"
        /// </summary>
        public int Mark_code {
            get => _mark_code;
            set => _mark_code = value;
        }
        public DateTime Insert_ymd_hms {
            get => _insert_ymd_hms;
            set => _insert_ymd_hms = value;
        }
    }
}
