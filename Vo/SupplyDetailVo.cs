/*
 * 2023-06-20
 */
namespace Vo {
    public class SupplyDetailVo {
        private DateTime _moveDate;
        private int _staffCode;
        private string _staffName;
        private int _supplyCode;
        private string _supplyName;
        private int _moveNumber;

        private readonly DateTime _defaultDateTime = new(1900,01,01);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyDetailVo() {
            _moveDate = _defaultDateTime;
            _staffCode = 0;
            _staffName = string.Empty;
            _supplyCode = 0;
            _supplyName = string.Empty;
            _moveNumber = 0;
        }

        /// <summary>
        /// 支給日
        /// </summary>
        public DateTime MoveDate {
            get => _moveDate;
            set => _moveDate = value;
        }

        /// <summary>
        /// 従事者コード
        /// </summary>
        public int StaffCode {
            get => _staffCode;
            set => _staffCode = value;
        }

        /// <summary>
        /// 従事者名
        /// </summary>
        public string StaffName {
            get => _staffName;
            set => _staffName = value;
        }

        /// <summary>
        /// 備品コード
        /// </summary>
        public int SupplyCode {
            get => _supplyCode;
            set => _supplyCode = value;
        }

        /// <summary>
        /// 備品名
        /// </summary>
        public string SupplyName {
            get => _supplyName;
            set => _supplyName = value;
        }

        /// <summary>
        /// 出庫数
        /// </summary>
        public int MoveNumber {
            get => _moveNumber;
            set => _moveNumber = value;
        }
    }
}
