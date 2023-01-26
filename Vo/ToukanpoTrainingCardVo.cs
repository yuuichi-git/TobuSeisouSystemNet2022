namespace Vo {
    public class ToukanpoTrainingCardVo {
        private int _staff_code = 0;
        private string _display_name = "";
        private string _company_name = "";
        private string _card_name = "";
        private DateTime _certificationDate;
        private byte[] _picture = Array.Empty<byte>();
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag = false;

        /// <summary>
        /// 社員コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 略称氏名
        /// </summary>
        public string Display_name {
            get => _display_name;
            set => _display_name = value;
        }
        /// <summary>
        /// 会社名
        /// </summary>
        public string Company_name {
            get => _company_name;
            set => _company_name = value;
        }
        /// <summary>
        /// カード記載の氏名
        /// </summary>
        public string Card_name {
            get => _card_name;
            set => _card_name = value;
        }
        /// <summary>
        /// 認定日
        /// </summary>
        public DateTime CertificationDate {
            get => _certificationDate;
            set => _certificationDate = value;
        }
        /// <summary>
        /// 画像
        /// </summary>
        public byte[] Picture {
            get => _picture;
            set => _picture = value;
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
