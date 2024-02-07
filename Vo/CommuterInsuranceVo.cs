/*
 * 2022/05/21
 */

namespace H_Vo {
    public class CommuterInsuranceVo {
        private int _belongs;
        private int _staff_code;
        private string _name = "";
        private string _name_kana = "";
        private bool _retirement_flag;
        private string _commuterInsurance = "";
        private bool _notification;
        private string _insuranceCompanyName = "";
        private bool _payment;
        private string _carNumber = "";
        private DateTime _startDate;
        private DateTime _endDate;
        private string _note = "";
        private byte[]? _pictureHead;
        private byte[]? _pictureTail;
        private DateTime _insert_ymd_hms;
        private DateTime _update_ymd_hms;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        /// <summary>
        /// 所属
        /// </summary>
        public int Belongs {
            get => _belongs;
            set => _belongs = value;
        }
        /// <summary>
        /// 社員CD
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 氏名
        /// </summary>
        public string Name {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// カナ
        /// </summary>
        public string Name_kana {
            get => _name_kana;
            set => _name_kana = value;
        }
        /// <summary>
        /// 退職フラグ
        /// </summary>
        public bool Retirement_flag {
            get => _retirement_flag;
            set => _retirement_flag = value;
        }
        /// <summary>
        /// 通勤手段
        /// </summary>
        public string CommuterInsurance {
            get => _commuterInsurance;
            set => _commuterInsurance = value;
        }
        /// <summary>
        /// 会社への届出の有無
        /// </summary>
        public bool Notification {
            get => _notification;
            set => _notification = value;
        }
        /// <summary>
        /// 任意保険会社
        /// </summary>
        public string InsuranceCompanyName {
            get => _insuranceCompanyName;
            set => _insuranceCompanyName = value;
        }
        /// <summary>
        /// 携帯決済(自転車)
        /// </summary>
        public bool Payment {
            get => _payment;
            set => _payment = value;
        }
        /// <summary>
        /// 車両ナンバー又は防犯登録番号
        /// </summary>
        public string CarNumber {
            get => _carNumber;
            set => _carNumber = value;
        }
        /// <summary>
        /// 保険期間開始日
        /// </summary>
        public DateTime StartDate {
            get => _startDate;
            set => _startDate = value;
        }
        /// <summary>
        /// 保険期間終了日
        /// </summary>
        public DateTime EndDate {
            get => _endDate;
            set => _endDate = value;
        }
        /// <summary>
        /// 備考
        /// </summary>
        public string Note {
            get => _note;
            set => _note = value;
        }
        /// <summary>
        /// 画像表
        /// </summary>
        public byte[]? PictureHead {
            get => _pictureHead;
            set => _pictureHead = value;
        }
        /// <summary>
        /// 画像裏
        /// </summary>
        public byte[]? PictureTail {
            get => _pictureTail;
            set => _pictureTail = value;
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
