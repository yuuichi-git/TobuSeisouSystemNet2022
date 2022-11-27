using Common;

using Vo;

namespace StaffDetail {
    public partial class StaffWorkDaysCount : Form {
        private ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();

        public StaffWorkDaysCount(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.StaffWorkDaysCount(this);

            initializeSheetViewList();
        }

        public static void Main() {
        }

        /// <summary>
        /// initializeSheetViewList
        /// </summary>
        private void initializeSheetViewList() {
            /*
             * ColumnHeaderをクリア
             */
            for(int i = 0; i < 31; i++) {
                SheetViewList.Columns[i + 2].Label = "-";
            }
            /*
             * ColumnHeaderをセット
             */
            SheetViewList.RowHeader.Columns[0].Width = 100;
            SheetViewList.Columns[0].Label = "コード";
            SheetViewList.Columns[1].Label = "氏　名";
            for(int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++) {
                DateTime sourceDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i + 1);
                SheetViewList.Columns[i + 2].Label = string.Concat(i + 1, "日(", sourceDate.ToString("ddd"), ")");
            }
            SheetViewList.Rows.Clear();
        }


        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// StaffWorkDaysCount_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffWorkDaysCount_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}