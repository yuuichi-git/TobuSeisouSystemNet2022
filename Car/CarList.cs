using CarRegister;

using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Car {
    public partial class CarList : Form {
        private InitializeForm _initializeForm = new();
        private readonly ConnectionVo _connectionVo;
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<CarMasterVo> _listFindAllCarMasterVo = new();
        private IOrderedEnumerable<CarMasterVo> _linqCarMasterVo;

        /*
         * SPREADのColumnの番号
         */
        /// <summary>
        /// 車両コード
        /// </summary>
        private const int colCarCode = 0;
        /// <summary>
        /// 自動車登録番号1
        /// </summary>
        private const int colRegistrationNumber1 = 1;
        /// <summary>
        /// 自動車登録番号2(4桁の数字部分)
        /// </summary>
        private const int colRegistrationNumber2 = 2;
        /// <summary>
        /// Door番号
        /// </summary>
        private const int colDoorNumber = 3;
        /// <summary>
        /// 区分(雇上・区契・一般)
        /// </summary>
        private const int colClassificationName = 4;
        /// <summary>
        /// 車庫地
        /// </summary>
        private const int colGarageFlag = 5;
        /// <summary>
        /// 名称(配車パネル)
        /// </summary>
        private const int colDisguiseKind_1 = 6;
        /// <summary>
        /// 名称(事故報告書)
        /// </summary>
        private const int colDisguiseKind_2 = 7;
        /// <summary>
        /// 名称(整備)
        /// </summary>
        private const int colDisguiseKind_3 = 8;
        /// <summary>
        /// 登録年月日
        /// </summary>
        private const int colRegistrationDate = 9;
        /// <summary>
        /// 初年度登録年月
        /// </summary>
        private const int colFirstRegistrationDate = 10;
        /// <summary>
        /// 自動車の種類
        /// </summary>
        private const int colCarKindName = 11;
        /// <summary>
        /// 用途
        /// </summary>
        private const int colCarUse = 12;
        /// <summary>
        /// 自家用・事業用の別
        /// </summary>
        private const int colOtherCode = 13;
        /// <summary>
        /// 車体の形状
        /// </summary>
        private const int colShapeName = 14;
        /// <summary>
        /// 有効期限の満了する日
        /// </summary>
        private const int colExpirationDate = 15;
        /// <summary>
        /// 備考
        /// </summary>
        private const int colRemarks = 16;

        public CarList(ConnectionVo connectionVo) {
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.CarList(this);

            _connectionVo = connectionVo;
            // 削除済のレコードも表示する
            CheckBoxDeleteFlag.Checked = false;
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            SheetViewListOutPut();
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        private void SheetViewListOutPut() {
            // 削除済のレコードも表示
            if(CheckBoxDeleteFlag.Checked) {
                _listFindAllCarMasterVo = _listCarMasterVo;
            } else {
                _listFindAllCarMasterVo = _listCarMasterVo.FindAll(x => x.Delete_flag == false);
            }
            // Sort
            _linqCarMasterVo = _listFindAllCarMasterVo.OrderBy(x => x.Door_number);
            // 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(var carMasterVo in _linqCarMasterVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止
                SheetViewList.Rows[i].ForeColor = !carMasterVo.Delete_flag ? Color.Black : Color.Red; // 削除済レコードは赤色で表示する

                SheetViewList.Cells[i, colCarCode].Value = carMasterVo.Car_code;
                SheetViewList.Cells[i, colRegistrationNumber1].Text = string.Concat(carMasterVo.Registration_number_1, carMasterVo.Registration_number_2, carMasterVo.Registration_number_3);
                SheetViewList.Cells[i, colRegistrationNumber2].Text = carMasterVo.Registration_number_4.ToString();
                SheetViewList.Cells[i, colDoorNumber].Text = carMasterVo.Door_number.ToString("###");
                SheetViewList.Cells[i, colClassificationName].Text = carMasterVo.Classification_name;
                SheetViewList.Cells[i, colGarageFlag].Text = carMasterVo.Garage_flag ? "本社" : "三郷";
                SheetViewList.Cells[i, colDisguiseKind_1].Text = carMasterVo.Disguise_kind_1;
                SheetViewList.Cells[i, colDisguiseKind_2].Text = carMasterVo.Disguise_kind_2;
                SheetViewList.Cells[i, colDisguiseKind_3].Text = carMasterVo.Disguise_kind_3;
                SheetViewList.Cells[i, colRegistrationDate].Value = carMasterVo.Registration_date.Date;
                SheetViewList.Cells[i, colFirstRegistrationDate].Value = carMasterVo.First_registration_date.Date;
                SheetViewList.Cells[i, colCarKindName].Text = carMasterVo.Car_kind_name;
                SheetViewList.Cells[i, colCarUse].Text = carMasterVo.Car_use;
                SheetViewList.Cells[i, colOtherCode].Text = carMasterVo.Other_name;
                SheetViewList.Cells[i, colShapeName].Text = carMasterVo.Shape_name;
                SheetViewList.Cells[i, colExpirationDate].ForeColor = carMasterVo.Expiration_date.Date < DateTime.Now.Date ? Color.Red : Color.Black;
                SheetViewList.Cells[i, colExpirationDate].Value = carMasterVo.Expiration_date.Date;
                SheetViewList.Cells[i, colRemarks].Text = carMasterVo.Remarks;
                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // 活性化
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
            if(e.Row < 0)
                return;
            // Shiftが押された場合
            if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                var carPaper = new CarPaper(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
                carPaper.ShowDialog();
                return;
            }
            // 修飾キーが無い場合
            var carDetail = new CarDetail(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
            carDetail.ShowDialog();
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
        /// ContextMenuStrip1_Opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            /*
             * SheetViewにRowが無い場合や、Rowが選択されていない場合はReturnする
             */
            if(SheetViewList.RowCount < 1 || !SheetViewList.IsBlockSelected) {
                e.Cancel = true;
                return;
            }

            var spreadList = (FpSpread)((ContextMenuStrip)sender).SourceControl;
            var cellRange = spreadList.ActiveSheet.GetSelections();

            // 削除メニューを表示・非表示
            if(cellRange[0].RowCount == 1) {
                ContextMenuStrip1.Enabled = true;
            } else {
                ContextMenuStrip1.Enabled = false;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemInsertNewCar":
                    var carDetail = new CarDetail(_connectionVo);
                    carDetail.ShowDialog();
                    break;
                // 選択されているレコードを削除する
                case "ToolStripMenuItemDelete":
                    var dialogResult = MessageBox.Show(MessageText.Message801, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch(dialogResult) {
                        case DialogResult.OK:
                            var carCode = (int)SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCarCode].Value;
                            new CarMasterDao(_connectionVo).UpdateOneCarMaster(carCode);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
            }
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
        /// CarList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarList_FormClosing(object sender, FormClosingEventArgs e) {
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