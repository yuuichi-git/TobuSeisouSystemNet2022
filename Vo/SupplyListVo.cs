/*
 * 2023-06-16
 * SupplyList 画面表示用Vo
 */
namespace H_Vo {
    public class SupplyListVo {
        private int _supplyCode;
        private  string _supplyName;
        private  int _appropriateStock;
        private  int _beginingMonthStock;
        private  int _warehousing;
        private  int _delivery;
        private  int _stock;

        public SupplyListVo() {
            _supplyCode = 0;
            _supplyName = string.Empty;
            _appropriateStock = 0;
            _beginingMonthStock = 0;
            _warehousing = 0;
            _delivery = 0;
            _stock = 0;
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
        /// 適正在庫数
        /// </summary>
        public int AppropriateStock {
            get => _appropriateStock;
            set => _appropriateStock = value;
        }

        /// <summary>
        /// 月初在庫数
        /// </summary>
        public int BeginingMonthStock {
            get => _beginingMonthStock;
            set => _beginingMonthStock = value;
        }

        /// <summary>
        /// 入庫数
        /// </summary>
        public int Warehousing {
            get => _warehousing;
            set => _warehousing = value;
        }

        /// <summary>
        /// 出庫数
        /// </summary>
        public int Delivery {
            get => _delivery;
            set => _delivery = value;
        }

        /// <summary>
        /// 在庫数
        /// </summary>
        public int Stock {
            get => _stock;
            set => _stock = value;
        }
    }
}
