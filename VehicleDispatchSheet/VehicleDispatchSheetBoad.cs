using Common;

using Vo;

namespace VehicleDispatchSheet {
    public partial class VehicleDispatchSheetBoad : Form {
        private ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();

        public VehicleDispatchSheetBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * ƒRƒ“ƒgƒ[ƒ‹‰Šú‰»
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchSheet(this);

        }

        public static void Main() {
        }


    }
}