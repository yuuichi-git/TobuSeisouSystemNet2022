namespace Vo {
    public class ExtendsStaffMasterVo : StaffMasterVo {
        private bool _toukanpoTrainingCardFlag;
        private string? _licenseNumber;
        private LicenseMasterVo? _licenseMasterVo;
        private DateTime _licenseMasterExpirationDate;
        private bool _commutingNotification;
        private DateTime _commuterInsuranceEndDate;
        private int _carAccidentMasterCount;

        /// <summary>
        /// 東環保修了証の存在の有無 True:あり False:なし
        /// </summary>
        public bool ToukanpoTrainingCardFlag {
            get => _toukanpoTrainingCardFlag;
            set => _toukanpoTrainingCardFlag = value;
        }
        /// <summary>
        /// 免許証番号
        /// </summary>
        public string? LicenseNumber {
            get => _licenseNumber;
            set => _licenseNumber = value;
        }
        /// <summary>
        /// LicenseLedgerVo
        /// </summary>
        public LicenseMasterVo? LicenseMasterVo {
            get => _licenseMasterVo;
            set => _licenseMasterVo = value;
        }
        /// <summary>
        /// 免許証の有効期限
        /// </summary>
        public DateTime LicenseMasterExpirationDate {
            get => _licenseMasterExpirationDate;
            set => _licenseMasterExpirationDate = value;
        }
        /// <summary>
        /// 通勤届 True:提出済 False:未提出
        /// </summary>
        public bool CommutingNotification {
            get => _commutingNotification;
            set => _commutingNotification = value;
        }
        /// <summary>
        /// 任意保険の期限年月日
        /// </summary>
        public DateTime CommuterInsuranceEndDate {
            get => _commuterInsuranceEndDate;
            set => _commuterInsuranceEndDate = value;
        }
        /// <summary>
        /// 事故歴情報の存在の有無と件数 0:無し 他:件数
        /// </summary>
        public int CarAccidentMasterCount {
            get => _carAccidentMasterCount;
            set => _carAccidentMasterCount = value;
        }
    }
}
