using Vo;

namespace RollCall {
    public partial class RollCallRecordBook : Form {
        private ConnectionVo _connectionVo;

        public RollCallRecordBook(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
        }




        /// <summary>
        /// RollCallRecordBook_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollCallRecordBook_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
