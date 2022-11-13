using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Staff {
    public partial class StaffList : Form {
        private InitializeForm _initializeForm = new();
        private List<StaffMasterVo> _listStaffMasterVo;

        // SPREADのColumnの番号
        /// <summary>
        /// 所属
        /// </summary>
        private const int colBelongs = 0;
        /// <summary>
        /// 形態
        /// </summary>
        private const int colJobForm = 1;
        /// <summary>
        /// 職種
        /// </summary>
        private const int colOccupation = 2;
        /// <summary>
        /// 配車の対象かどうか
        /// </summary>
        private const int colVehicleDispatchTarget = 3;
        /// <summary>
        /// <summary>
        /// 社員CD
        /// </summary>
        private const int colStaffCode = 4;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colName = 5;
        /// <summary>
        /// カナ
        /// </summary>
        private const int colNameKana = 6;
        /// <summary>
        /// 東環保
        /// </summary>
        private const int colToukanpoCard = 7;
        /// <summary>
        /// 免許証
        /// </summary>
        private const int colLicense = 8;
        /// <summary>
        /// 免許証期限
        /// </summary>
        private const int colLicensExpirationDate = 9;
        /// <summary>
        /// 通勤届
        /// </summary>
        private const int colCommutingNotification = 10;
        /// <summary>
        /// 任意保険終了年月日
        /// </summary>
        private const int colMeansOfCommutingEndDate = 11;
        /// <summary>
        /// 生年月日
        /// </summary>
        private const int colBirthDate = 12;
        /// <summary>
        /// 年齢
        /// </summary>
        private const int colFullAge = 13;
        /// <summary>
        /// 雇用年月日
        /// </summary>
        private const int colEmploymentDate = 14;
        /// <summary>
        /// 勤続年数
        /// </summary>
        private const int colServiceDate = 15;
        /// <summary>
        /// 初任
        /// </summary>
        private const int colFirstTerm = 16;
        /// <summary>
        /// 適齢
        /// </summary>
        private const int colSuitableAge = 17;
        /// <summary>
        /// 事故件数
        /// </summary>
        private const int colCarAccidentCount = 18;
        /// <summary>
        /// １年以内の健康診断
        /// </summary>
        private const int colMedicalExaminationDate = 19;
        /// <summary>
        /// 現住所
        /// </summary>
        private const int colCurrentAddress = 20;
        /// <summary>
        /// 健康保険
        /// </summary>
        private const int colHealthInsuranceNumber = 21;
        /// <summary>
        /// 厚生年金
        /// </summary>
        private const int colWelfarePensionNumber = 22;
        /// <summary>
        /// 雇用保険
        /// </summary>
        private const int colEmploymentInsuranceNumber = 23;
        /// <summary>
        /// 労災保険
        /// </summary>
        private const int colWorkerAccidentInsuranceNumber = 24;

        public StaffList(ConnectionVo connectionVo) {
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.StaffList(this);

            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();

            // 事故件数集計の基準となる年度を初期化
            ComboBoxAccidentYear.Text = "2022年度";
            // FpSpreadを初期化
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = "";
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
        /// TabControlEx1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlEx1_Click(object sender, EventArgs e) {

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
        /// StaffList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffList_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
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