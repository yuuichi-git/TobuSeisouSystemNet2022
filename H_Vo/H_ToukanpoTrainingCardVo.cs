﻿/*
 * 2024-02-07
 */
namespace Vo {
    public class H_ToukanpoTrainingCardVo {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);

        private int _staffCode;
        private string _displayName;
        private string _companyName;
        private string _cardName;
        private DateTime _certificationDate;
        private byte[] _picture;
        private string _insertPcName;
        private DateTime _insertYmdHms;
        private string _updatePcName;
        private DateTime _updateYmdHms;
        private string _deletePcName;
        private DateTime _deleteYmdHms;
        private bool _deleteFlag;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_ToukanpoTrainingCardVo() {
            _staffCode = 0;
            _displayName = string.Empty;
            _companyName = string.Empty;
            _cardName = string.Empty;
            _certificationDate = _defaultDateTime;
            _picture = Array.Empty<byte>();
            _insertPcName = string.Empty;
            _insertYmdHms = _defaultDateTime;
            _updatePcName = string.Empty;
            _updateYmdHms = _defaultDateTime;
            _deletePcName = string.Empty;
            _deleteYmdHms = _defaultDateTime;
            _deleteFlag = false;
        }

        /// <summary>
        /// 従事者コード
        /// </summary>
        public int StaffCode {
            get => _staffCode;
            set => _staffCode = value;
        }
        /// <summary>
        /// 略称氏名
        /// </summary>
        public string DisplayName {
            get => _displayName;
            set => _displayName = value;
        }
        /// <summary>
        /// 会社名
        /// </summary>
        public string CompanyName {
            get => _companyName;
            set => _companyName = value;
        }
        /// <summary>
        /// カード記載の氏名
        /// </summary>
        public string CardName {
            get => _cardName;
            set => _cardName = value;
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
