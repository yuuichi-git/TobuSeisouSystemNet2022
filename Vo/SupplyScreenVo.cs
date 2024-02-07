/*
 * 2023-06-14
 * 表示用のVo
 * SupplyInventory SupplyIn 共通
 */
namespace H_Vo {
    /// <summary>
    /// 画面表示用のVo
    /// </summary>
    public class SupplyScreenVo {
        private int _supplyCode;
        private string _supplyName;
        private int _supplyCount;
        private string _memo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyScreenVo() {
            _supplyCode = 0;
            _supplyName = string.Empty;
            _supplyCount = 0;
            _memo = string.Empty;
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
        /// SupplyInventory→棚卸数 SupplyIn1→入庫数
        /// </summary>
        public int SupplyCount {
            get => _supplyCount;
            set => _supplyCount = value;
        }

        /// <summary>
        /// メモ
        /// </summary>
        public string Memo {
            get => _memo;
            set => _memo = value;
        }
    }
}
