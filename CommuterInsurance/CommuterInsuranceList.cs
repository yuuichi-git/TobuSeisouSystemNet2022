using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using H_Vo;

namespace CommuterInsurance {
    public partial class CommuterInsuranceList : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();

        private List<CommuterInsuranceVo> _listCommuterInsuranceVo = new();
        private List<CommuterInsuranceVo> _listFindAllCommuterInsuranceVo = new();

        Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 20, "新運転" }, { 21, "自運労" } };

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

            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.CommuterInsuranceList(this);
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// TabControlExStaff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlExStaff_Click(object sender, EventArgs e) {
            if(_listCommuterInsuranceVo == null)
                return;
            SheetViewListOutPut();
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            _listCommuterInsuranceVo = new CommuterInsuranceDao(_connectionVo).SelectAllCommuterInsurance();
            SheetViewListOutPut();
        }

        /// <summary>
        /// 画面表示
        /// </summary>
        int spreadListTopRow = 0;
        private void SheetViewListOutPut() {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            _listFindAllCommuterInsuranceVo = TabControlExStaff.SelectedTab.Tag switch {
                "ア" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("ア") || x.Name_kana.StartsWith("イ") || x.Name_kana.StartsWith("ウ") || x.Name_kana.StartsWith("エ") || x.Name_kana.StartsWith("オ")),
                "カ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("カ") || x.Name_kana.StartsWith("ガ") || x.Name_kana.StartsWith("キ") || x.Name_kana.StartsWith("ギ") || x.Name_kana.StartsWith("ク") || x.Name_kana.StartsWith("ケ") || x.Name_kana.StartsWith("コ") || x.Name_kana.StartsWith("ゴ")),
                "サ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("サ") || x.Name_kana.StartsWith("シ") || x.Name_kana.StartsWith("ス") || x.Name_kana.StartsWith("セ") || x.Name_kana.StartsWith("ソ")),
                "タ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("タ") || x.Name_kana.StartsWith("チ") || x.Name_kana.StartsWith("ツ") || x.Name_kana.StartsWith("テ") || x.Name_kana.StartsWith("デ") || x.Name_kana.StartsWith("ト") || x.Name_kana.StartsWith("ド")),
                "ナ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("ナ") || x.Name_kana.StartsWith("ニ") || x.Name_kana.StartsWith("ヌ") || x.Name_kana.StartsWith("ネ") || x.Name_kana.StartsWith("ノ")),
                "ハ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("ハ") || x.Name_kana.StartsWith("パ") || x.Name_kana.StartsWith("ヒ") || x.Name_kana.StartsWith("ビ") || x.Name_kana.StartsWith("フ") || x.Name_kana.StartsWith("ブ") || x.Name_kana.StartsWith("ヘ") || x.Name_kana.StartsWith("ベ") || x.Name_kana.StartsWith("ホ")),
                "マ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("マ") || x.Name_kana.StartsWith("ミ") || x.Name_kana.StartsWith("ム") || x.Name_kana.StartsWith("メ") || x.Name_kana.StartsWith("モ")),
                "ヤ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("ヤ") || x.Name_kana.StartsWith("ユ") || x.Name_kana.StartsWith("ヨ")),
                "ラ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("ラ") || x.Name_kana.StartsWith("リ") || x.Name_kana.StartsWith("ル") || x.Name_kana.StartsWith("レ") || x.Name_kana.StartsWith("ロ")),
                "ワ" => _listCommuterInsuranceVo.FindAll(x => x.Name_kana.StartsWith("ワ") || x.Name_kana.StartsWith("ヲ") || x.Name_kana.StartsWith("ン")),
                _ => _listCommuterInsuranceVo,
            };

            int i = 0;
            foreach(var commuterInsuranceVo in _listFindAllCommuterInsuranceVo.OrderBy(x => x.Name_kana)) {
                // 所属
                var _belongs = dictionaryBelongs[commuterInsuranceVo.Belongs];
                // 社員CD
                var _staff_code = commuterInsuranceVo.Staff_code;
                // 氏名
                var _name = commuterInsuranceVo.Name;
                // カナ
                var _name_kana = commuterInsuranceVo.Name_kana;
                // 退職フラグ
                var _retirement_flag = commuterInsuranceVo.Retirement_flag;
                // 通勤手段
                var _means_of_commuting = commuterInsuranceVo.CommuterInsurance;
                // 届出
                var _notification = commuterInsuranceVo.Notification;
                // 任意保険会社
                var _insurance_company_name = commuterInsuranceVo.InsuranceCompanyName;
                // 携帯決済
                var _payment = commuterInsuranceVo.Payment;
                // 車両ナンバー又は防犯登録番号
                var _car_number = commuterInsuranceVo.CarNumber;
                // 期間開始日
                var _start_date = commuterInsuranceVo.StartDate;
                // 期間終了日
                var _end_date = commuterInsuranceVo.EndDate;
                // 備考
                var _note = commuterInsuranceVo.Note;

                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止

                SheetViewList.Cells[i, colBelongs].Text = _belongs;
                SheetViewList.Cells[i, colStaffCode].Value = _staff_code;
                SheetViewList.Cells[i, colName].Text = _name;
                SheetViewList.Cells[i, colNameKana].Text = _name_kana;
                SheetViewList.Cells[i, colRetirementFlag].Text = _retirement_flag ? "×" : "〇";
                SheetViewList.Cells[i, colMeansOfCommuting].Text = _means_of_commuting;
                SheetViewList.Cells[i, colNotification].Text = _notification ? "〇" : "";
                SheetViewList.Cells[i, colInsuranceCompanyName].Text = _insurance_company_name;
                SheetViewList.Cells[i, colPayment].Text = _payment ? "〇" : "";
                SheetViewList.Cells[i, colCarNumber].Text = _car_number;
                SheetViewList.Cells[i, colStartDate].Value = _start_date;
                SheetViewList.Cells[i, colEndDate].Value = _end_date;
                SheetViewList.Cells[i, colNote].Text = _note;
                i++;
            }
            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelStatus.Text = string.Concat(" ", i, " 件");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if(e.ColumnHeader)
                return;
            var commuterInsuranceDetail = new CommuterInsuranceDetail(_connectionVo, (int)SheetViewList.Cells[e.Row, colStaffCode].Value);
            commuterInsuranceDetail.ShowDialog(this);
        }

        /// <summary>
        /// ToolStripMenuItemExcelExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExcelExport_Click(object sender, EventArgs e) {
            //xlsx形式ファイルをエクスポートします
            string fileName = string.Concat("従事者通勤手段一覧表", DateTime.Now.ToString("MM月dd日"), "作成");
            SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
            MessageBox.Show("デスクトップへエクスポートしました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ToolStripMenuItemNewRecord_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemNewRecord_Click(object sender, EventArgs e) {
            var commuterInsuranceDetail = new CommuterInsuranceDetail(_connectionVo);
            commuterInsuranceDetail.ShowDialog(this);
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
