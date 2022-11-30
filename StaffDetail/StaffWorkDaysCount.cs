using Common;

using Dao;

using GrapeCity.Win.Spread.InputMan.CellType;

using Vo;

namespace StaffDetail {
    public partial class StaffWorkDaysCount : Form {
        private ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private List<StaffMasterVo> _listStaffMasterVo;

        public StaffWorkDaysCount(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.StaffWorkDaysCount(this);
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();

            InitializeSheetViewList();
        }

        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// initializeSheetViewList
        /// </summary>
        private void InitializeSheetViewList() {
            /*
             * SheetViewMEIBO
             */
            GcComboBoxCellType gcComboBoxCellType = new GcComboBoxCellType();
            /*
             * ヘッダを非表示にします
             */
            gcComboBoxCellType.ListHeaderPane.Visible = false;
            /*
             * Font他　スタイル設定
             */
            ItemTemplateInfo itemTemplateInfo = new ItemTemplateInfo(0, null, Color.White, Color.Black, -1, new Font("Yu Gothic UI", 10), null);
            gcComboBoxCellType.ListItemTemplates.Add(itemTemplateInfo);
            /*
             * オートコンプリートを設定
             */
            gcComboBoxCellType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            gcComboBoxCellType.AutoCompleteSource = AutoCompleteSource.ListItems;
            gcComboBoxCellType.AutoComplete.HighlightMatchedText = true;
            gcComboBoxCellType.AutoComplete.HighlightStyle.ForeColor = Color.Red;
            gcComboBoxCellType.AutoComplete.MatchingMode = AutoCompleteMatchingMode.AmbiguousMatchStartWith;

            /*
             * リストボックスに項目を追加
             */
            foreach(StaffMasterVo staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                gcComboBoxCellType.Items.Add(new ListItemInfo(staffMasterVo.Display_name));
            }
            /*
             * Rowを必要人数分追加する
             */
            int staffNameColumn = 2;
            int staffRowStartRow = 3;
            for(int i = 0; i < 20; i++) {
                SheetViewMEIBO.Cells[staffRowStartRow + i, staffNameColumn].CellType = gcComboBoxCellType;
            }

            /*
             * SheetViewList
             * ColumnHeaderをクリア
             */
            for(int i = 0; i < 31; i++) {
                SheetViewList.Columns[i + 3].Label = "-";
            }
            /*
             * ColumnHeaderをセット
             */
            SheetViewList.RowHeader.Columns[0].Width = 30;
            SheetViewList.Columns[0].Label = "コード";
            SheetViewList.Columns[1].Label = "氏　名";
            for(int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++) {
                DateTime sourceDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i + 1);
                SheetViewList.Columns[i + 3].Label = string.Concat(i + 1, "日(", sourceDate.ToString("ddd"), ")");
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