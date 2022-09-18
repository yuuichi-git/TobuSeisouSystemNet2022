/*
 * 2022-09-18
 */
using Common;

using Vo;

namespace Production {
    public partial class ProductionList : Form {
        /// <summary>
        /// Connectionを保持
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// インスタンス作成
        /// </summary>
        private InitializeForm _initializeForm = new();
        private List<SetMasterVo> _listSetMasterVo = new();
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<StaffMasterVo> _listStaffMasterVo = new();

        public ProductionList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
            // Formを初期化する
            _initializeForm.ProductionList(this);
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

    }
}