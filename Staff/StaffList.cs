using Common;

using Vo;

namespace Staff {
    public partial class StaffList : Form {
        private InitializeForm _initializeForm = new();

        public StaffList(ConnectionVo connectionVo) {
            /*
             * ƒRƒ“ƒgƒ[ƒ‹‰Šú‰»
             */
            InitializeComponent();
            _initializeForm.StaffList(this);

        }

        public static void Main() {
        }


    }
}