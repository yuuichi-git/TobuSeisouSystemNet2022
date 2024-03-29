namespace Vo {
    public class CertificationMasterVo {
        private int _certification_code;
        private string _certification_name = "";
        private string _certification_display_name = "";
        private bool _display_flag = false;
        private int _certification_type;
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag = false;

        /// <summary>
        /// 資格コード
        /// 100の位はCertification_typeの数字と同じ
        /// </summary>
        public int Certification_code {
            get => _certification_code;
            set => _certification_code = value;
        }
        /// <summary>
        /// 資格名
        /// </summary>
        public string Certification_name {
            get => _certification_name;
            set => _certification_name = value;
        }
        /// <summary>
        /// 資格表示名
        /// </summary>
        public string Certification_display_name {
            get => _certification_display_name;
            set => _certification_display_name = value;
        }
        /// <summary>
        /// 画面表示フラグ
        /// True:画面に表示する　False:画面に表示しない
        /// </summary>
        public bool Display_flag {
            get => _display_flag;
            set => _display_flag = value;
        }
        /// <summary>
        /// 資格の分類
        /// 1:資格等 2:作業経験の有無等
        /// </summary>
        public int Certification_type {
            get => _certification_type;
            set => _certification_type = value;
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
