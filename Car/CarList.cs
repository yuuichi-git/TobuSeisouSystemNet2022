using Common;

using Vo;

namespace Car {
    public partial class CarList : Form {
        private InitializeForm _initializeForm = new();

        public CarList(ConnectionVo connectionVo) {
            /*
             * ƒRƒ“ƒgƒ[ƒ‹‰Šú‰»
             */
            InitializeComponent();
            _initializeForm.CarList(this);
        }

        public static void Main() {
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void CarList_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}