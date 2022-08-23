using Common;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        /// <summary>
        /// Connectionを保持
        /// </summary>
        private readonly ConnectionVo _connectionVo;

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            // Formの表示サイズを初期化
            new InitializeForm().GetWorkingArea(this);
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }


    }
}