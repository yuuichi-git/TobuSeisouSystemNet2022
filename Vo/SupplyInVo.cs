/*
 * 2023-06-14
 */
namespace Vo {
    public class SupplyInVo {
        private int _supplyCode;
        private string _supplyName;
        private int _inventoryStock;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyInVo() {
            _supplyCode = 0;
            _supplyName = string.Empty;
            _inventoryStock = 0;
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
        /// 棚卸数１(先々月)
        /// </summary>
        public int InventoryStock {
            get => _inventoryStock;
            set => _inventoryStock = value;
        }
    }
}
