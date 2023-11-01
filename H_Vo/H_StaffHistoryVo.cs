/*
 * 2023-10-31
 * 社歴ファイル
 */
namespace H_Vo {
    public class H_StaffHistoryVo {
        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);

        private int _staffCode;
        private DateTime _historyDate;
        private string _companyName;
        private string _historyNote;
        private string _insertPcName;
        private DateTime _insertYmdHms;
        private string _updatePcName;
        private DateTime _updateYmdHms;
        private string _deletePcName;
        private DateTime _deleteYmdHms;
        private bool _deleteFlag;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_StaffHistoryVo() {
            _staffCode = 0;
            _historyDate = _defaultDateTime;
            _companyName = string.Empty;
            _historyNote = string.Empty;
            _insertPcName = string.Empty;
            _insertYmdHms = _defaultDateTime;
            _updatePcName = string.Empty;
            _updateYmdHms = _defaultDateTime;
            _deletePcName = string.Empty;
            _deleteYmdHms = _defaultDateTime;
            _deleteFlag = false;
        }

        /// <summary>
        /// 従業員コード
        /// </summary>
        public int StaffCode {
            get => _staffCode;
            set => _staffCode = value;
        }
        /// <summary>
        /// 入社日
        /// </summary>
        public DateTime HistoryDate {
            get => _historyDate;
            set => _historyDate = value;
        }
        /// <summary>
        /// 過去に在籍していた会社名
        /// </summary>
        public string CompanyName {
            get => _companyName;
            set => _companyName = value;
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string HistoryNote {
            get => _historyNote;
            set => _historyNote = value;
        }
        public string InsertPcName {
            get => _insertPcName;
            set => _insertPcName = value;
        }
        public DateTime InsertYmdHms {
            get => _insertYmdHms;
            set => _insertYmdHms = value;
        }
        public string UpdatePcName {
            get => _updatePcName;
            set => _updatePcName = value;
        }
        public DateTime UpdateYmdHms {
            get => _updateYmdHms;
            set => _updateYmdHms = value;
        }
        public string DeletePcName {
            get => _deletePcName;
            set => _deletePcName = value;
        }
        public DateTime DeleteYmdHms {
            get => _deleteYmdHms;
            set => _deleteYmdHms = value;
        }
        public bool DeleteFlag {
            get => _deleteFlag;
            set => _deleteFlag = value;
        }
    }
}
