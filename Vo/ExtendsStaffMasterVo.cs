namespace Vo {
    public class ExtendsStaffMasterVo : StaffMasterVo {
        private bool _toukanpoTrainingCardFlag;
        private string? _licenseLedgerNumber;
        private LicenseMasterVo? _licenseLedgerVo;
        private DateTime _licenseLedgerExpirationDate;
        private bool _commutingNotification;
        private DateTime _meansOfCommutingEndDate;
        private int _carAccidentLedgerCount;

        /// <summary>
        /// 東環保修了証の存在の有無 True:あり False:なし
        /// </summary>
        public bool ToukanpoTrainingCardFlag {
            get => _toukanpoTrainingCardFlag;
            set => _toukanpoTrainingCardFlag = value;
        }
        /// <summary>
        /// 免許証情報の番号
        /// </summary>
        public string? LicenseLedgerNumber {
            get => _licenseLedgerNumber;
            set => _licenseLedgerNumber = value;
        }
        /// <summary>
        /// LicenseLedgerVo
        /// </summary>
        public LicenseMasterVo? LicenseLedgerVo {
            get => _licenseLedgerVo;
            set => _licenseLedgerVo = value;
        }
        /// <summary>
        /// 免許証の有効期限
        /// </summary>
        public DateTime LicenseLedgerExpirationDate {
            get => _licenseLedgerExpirationDate;
            set => _licenseLedgerExpirationDate = value;
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
        public DateTime MeansOfCommutingEndDate {
            get => _meansOfCommutingEndDate;
            set => _meansOfCommutingEndDate = value;
        }
        /// <summary>
        /// 事故歴情報の存在の有無と件数 0:無し 他:件数
        /// </summary>
        public int CarAccidentLedgerCount {
            get => _carAccidentLedgerCount;
            set => _carAccidentLedgerCount = value;
        }
    }
}
