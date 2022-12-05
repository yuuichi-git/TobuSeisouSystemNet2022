using Common;

using FarPoint.Win.Spread;

using Vo;

namespace Substitute {
    public partial class SubstitutePaper : Form {
        private ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();

        public SubstitutePaper(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;

            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // シートタブを非表示
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;

        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }


    }
}