/*
 * 2024-03-21
 */
namespace Vo {
    public class H_CollectionWeightGroupChiyodaVo {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);

        private DateTime _operationDate;
        private int _staffCode;
        private string _staffDisplayName;
        private string _occupation;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_CollectionWeightGroupChiyodaVo() {
            _operationDate = _defaultDateTime;
            _staffCode = 0;
            _staffDisplayName = string.Empty;
            _occupation = string.Empty;
        }

        public DateTime OperationDate {
            get => _operationDate;
            set => _operationDate = value;
        }
        public int StaffCode {
            get => _staffCode;
            set => _staffCode = value;
        }
        public string StaffDisplayName {
            get => _staffDisplayName;
            set => _staffDisplayName = value;
        }
        /// <summary>
        /// 職種
        /// 10:運転手 11:作業員 20:事務職 99:指定なし
        /// </summary>
        public string Occupation {
            get => _occupation;
            set => _occupation = value;
        }
    }
}
