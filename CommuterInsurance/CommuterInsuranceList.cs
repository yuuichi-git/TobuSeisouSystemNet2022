using Common;

using FarPoint.Win.Spread;

using Vo;

namespace CommuterInsurance {
    public partial class CommuterInsuranceList : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();

        private List<CommuterInsuranceVo> _listCommuterInsuranceVo;
        private List<CommuterInsuranceVo> _listFindAllCommuterInsuranceVo;
        private IOrderedEnumerable<CommuterInsuranceVo>? _linqCommuterInsuranceVo;

        /*
         * SPREADのColumnの番号
         */
        /// <summary>
        /// 所属
        /// </summary>
        private const int colBelongs = 0;
        /// <summary>
        /// <summary>
        /// 社員CD
        /// </summary>
        private const int colStaffCode = 1;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colName = 2;
        /// <summary>
        /// カナ
        /// </summary>
        private const int colNameKana = 3;
        /// <summary>
        /// 在籍
        /// </summary>
        private const int colRetirementFlag = 4;
        /// <summary>
        /// 通勤手段
        /// </summary>
        private const int colMeansOfCommuting = 5;
        /// <summary>
        /// 届出
        /// </summary>
        private const int colNotification = 6;
        /// <summary>
        /// 任意保険会社
        /// </summary>
        private const int colInsuranceCompanyName = 7;
        /// <summary>
        /// 携帯決済
        /// </summary>
        private const int colPayment = 8;
        /// <summary>
        /// 車両ナンバー又は防犯登録番号
        /// </summary>
        private const int colCarNumber = 9;
        /// <summary>
        /// 期間開始日
        /// </summary>
        private const int colStartDate = 10;
        /// <summary>
        /// 期間終了日
        /// </summary>
        private const int colEndDate = 11;
        /// <summary>
        /// 備考
        /// </summary>
        private const int colNote = 12;

        public CommuterInsuranceList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            _listCommuterInsuranceVo = null;
            _listFindAllCommuterInsuranceVo = null;

            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.CommuterInsuranceList(this);
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // シートタブを非表示
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 30; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("メイリオ", 10); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
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
        /// CommuterInsuranceList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommuterInsuranceList_FormClosing(object sender, FormClosingEventArgs e) {
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
