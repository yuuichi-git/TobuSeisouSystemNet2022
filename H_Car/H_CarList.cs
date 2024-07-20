/*
 * 2024-03-27
 */
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_Car {
    public partial class HCarList : Form {
        /// <summary>
        /// 10:雇上 11:区契 12:臨時 20:清掃工場 30:社内 50:一般 51:社用車 99:指定なし
        /// </summary>
        private readonly Dictionary<int, string> dictionaryClassificationName = new Dictionary<int, string> { { 10, "雇上" }, { 11, "区契" }, { 12, "臨時" }, { 20, "清掃工場" }, { 30, "社内" }, { 50, "一般" }, { 51, "社用車" }, { 99, "指定なし" } };
        /// <summary>
        /// 0:該当なし 1:足立 2:三郷 3:産廃車庫
        /// </summary>
        private readonly Dictionary<int, string> dictionaryGarageName = new Dictionary<int, string> { { 0, "該当なし" }, { 1, "本社" }, { 2, "三郷" }, { 3, "産廃車庫" } };
        /// <summary>
        /// 10:軽自動車 11:小型 12:普通
        /// </summary>
        private readonly Dictionary<int, string> dictionaryCarKindName = new Dictionary<int, string> { { 10, "軽自動車" }, { 11, "小型" }, { 12, "普通" } };
        /// <summary>
        /// 10:事業用 11:自家用
        /// </summary>
        private readonly Dictionary<int, string> dictionaryOtherName = new Dictionary<int, string> { { 10, "事業用" }, { 11, "自家用" } };
        /// <summary>
        /// 10:キャブオーバー 11:塵芥車 12:ダンプ 13:コンテナ専用 14:脱着装置付コンテナ専用車 15:粉粒体運搬車 16:糞尿車 17:清掃車
        /// </summary>
        private readonly Dictionary<int, string> dictionaryShapeName = new Dictionary<int, string> { { 10, "キャブオーバー" }, { 11, "塵芥車" }, { 12, "ダンプ" }, { 13, "コンテナ専用" }, { 14, "脱着装置付コンテナ専用車" }, { 15, "粉粒体運搬車" }, { 16, "糞尿車" }, { 17, "清掃車" } };
        /*
         * SPREADのColumnの番号
         */
        /// <summary>
        /// 車両コード
        /// </summary>
        private const int _colCarCode = 0;
        /// <summary>
        /// 自動車登録番号1
        /// </summary>
        private const int _colRegistrationNumber1 = 1;
        /// <summary>
        /// 自動車登録番号2(4桁の数字部分)
        /// </summary>
        private const int _colRegistrationNumber2 = 2;
        /// <summary>
        /// Door番号
        /// </summary>
        private const int _colDoorNumber = 3;
        /// <summary>
        /// 区分(雇上・区契・一般)
        /// </summary>
        private const int _colClassificationName = 4;
        /// <summary>
        /// 車庫地
        /// </summary>
        private const int _colGarageName = 5;
        /// <summary>
        /// 名称(配車パネル)
        /// </summary>
        private const int _colDisguiseKind_1 = 6;
        /// <summary>
        /// 名称(事故報告書)
        /// </summary>
        private const int _colDisguiseKind_2 = 7;
        /// <summary>
        /// 名称(整備)
        /// </summary>
        private const int _colDisguiseKind_3 = 8;
        /// <summary>
        /// 登録年月日
        /// </summary>
        private const int _colRegistrationDate = 9;
        /// <summary>
        /// 初年度登録年月
        /// </summary>
        private const int _colFirstRegistrationDate = 10;
        /// <summary>
        /// 自動車の種類
        /// </summary>
        private const int _colCarKindName = 11;
        /// <summary>
        /// 用途
        /// </summary>
        private const int _colCarUse = 12;
        /// <summary>
        /// 自家用・事業用の別
        /// </summary>
        private const int _colOtherCode = 13;
        /// <summary>
        /// 車体の形状
        /// </summary>
        private const int _colShapeName = 14;
        /// <summary>
        /// 有効期限の満了する日
        /// </summary>
        private const int _colExpirationDate = 15;
        /// <summary>
        /// 備考
        /// </summary>
        private const int _colRemarks = 16;
        /*
         * Dao
         */
        private readonly H_CarMasterDao _hCarMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public HCarList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCarMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            InitializeComponent();
            ToolStripMenuItemDeleted.Checked = false;
            this.InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.PutSheetViewList();
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// PutSheetViewList
        /// </summary>
        private void PutSheetViewList() {
            List<H_CarMasterVo> _listHCarMasterVo = new();
            // 削除済のレコードも表示
            if (ToolStripMenuItemDeleted.Checked) {
                _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            } else {
                _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster().FindAll(x => x.DeleteFlag == false);
            }
            // 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach (H_CarMasterVo hCarMasterVo in _listHCarMasterVo.OrderBy(x => x.RegistrationNumber4)) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                SheetViewList.Rows[i].ForeColor = !hCarMasterVo.DeleteFlag ? Color.Black : Color.Red; // 削除済レコードは赤色で表示する

                SheetViewList.Cells[i, _colCarCode].Value = hCarMasterVo.CarCode;
                SheetViewList.Cells[i, _colRegistrationNumber1].Text = string.Concat(hCarMasterVo.RegistrationNumber1, hCarMasterVo.RegistrationNumber2, hCarMasterVo.RegistrationNumber3);
                SheetViewList.Cells[i, _colRegistrationNumber2].Text = hCarMasterVo.RegistrationNumber4.ToString();
                SheetViewList.Cells[i, _colDoorNumber].Text = hCarMasterVo.DoorNumber.ToString("###");
                SheetViewList.Cells[i, _colClassificationName].Text = dictionaryClassificationName[hCarMasterVo.ClassificationCode];
                SheetViewList.Cells[i, _colGarageName].Text = dictionaryGarageName[hCarMasterVo.GarageCode];
                SheetViewList.Cells[i, _colDisguiseKind_1].Text = hCarMasterVo.DisguiseKind1;
                SheetViewList.Cells[i, _colDisguiseKind_2].Text = hCarMasterVo.DisguiseKind2;
                SheetViewList.Cells[i, _colDisguiseKind_3].Text = hCarMasterVo.DisguiseKind3;
                SheetViewList.Cells[i, _colRegistrationDate].Value = hCarMasterVo.RegistrationDate.Date;
                SheetViewList.Cells[i, _colFirstRegistrationDate].Value = hCarMasterVo.FirstRegistrationDate.Date;
                SheetViewList.Cells[i, _colCarKindName].Text = dictionaryCarKindName[hCarMasterVo.CarKindCode];
                SheetViewList.Cells[i, _colCarUse].Text = hCarMasterVo.CarUse;
                SheetViewList.Cells[i, _colOtherCode].Text = dictionaryOtherName[hCarMasterVo.OtherCode];
                SheetViewList.Cells[i, _colShapeName].Text = dictionaryShapeName[hCarMasterVo.ShapeCode];
                SheetViewList.Cells[i, _colExpirationDate].ForeColor = hCarMasterVo.ExpirationDate.Date < DateTime.Now.Date ? Color.Red : Color.Black;
                SheetViewList.Cells[i, _colExpirationDate].Value = hCarMasterVo.ExpirationDate.Date;
                SheetViewList.Cells[i, _colRemarks].Text = hCarMasterVo.Remarks;
                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");

        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 新規車両を作成する
                 */
                case "ToolStripMenuItemNewCar":
                    HCarDetail hCarDetail = new(_connectionVo);
                    new Desktop().SetPosition(hCarDetail, _connectionVo.Screen);
                    hCarDetail.KeyPreview = true;
                    hCarDetail.ShowDialog(this);
                    break;
                case "ToolStripMenuItemDelete":
                    DialogResult dialogResult = MessageBox.Show("選択されている車両を削除します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.OK:
                            var carCode = (int)SheetViewList.Cells[SheetViewList.ActiveRowIndex, _colCarCode].Value;
                            _hCarMasterDao.DeleteOneHCarMaster(carCode);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
                /*
                 * アプリケーションを終了する
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // ヘッダーのDoubleClickを回避
            if (e.Row < 0)
                return;
            // Shiftが押された場合
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                //var carPaper = new CarPaper(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
                //carPaper.ShowDialog();
                return;
            }
            // 修飾キーが無い場合
            HCarDetail hCarDetail = new(_connectionVo, (int)SheetViewList.Cells[e.Row, _colCarCode].Value);
            new Desktop().SetPosition(hCarDetail, _connectionVo.Screen);
            hCarDetail.KeyPreview = true;
            hCarDetail.ShowDialog(this);
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
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// HCarList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarList_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show("アプリケーションを終了します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
