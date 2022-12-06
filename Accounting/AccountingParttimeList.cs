using Common;

using FarPoint.Win.Spread;

using Vo;

namespace Accounting {
    public partial class AccountingParttimeList : Form {
        private ConnectionVo _connectionVo;
        private readonly InitializeForm _initializeForm = new();

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public AccountingParttimeList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.AccountingParttimeList(this);
            // シートタブを非表示
            SpreadList.TabStripPolicy = TabStripPolicy.Never;

        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }


    }
}