/*
 * 2023-06-19
 */
using Common;

using ControlEx;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyDetail : Form {
        private int _supplyCode;
        /*
         * Dao
         */
        private readonly SupplyDetailDao _supplyDetailDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// 支給日
        /// </summary>
        private const int _colMoveDate = 0;
        /// <summary>
        /// 従事者コード
        /// </summary>
        private const int _colStaffCode = 1;
        /// <summary>
        /// 従事者名
        /// </summary>
        private const int _colStaffName = 2;
        /// <summary>
        /// 備品コード
        /// </summary>
        private const int _colSupplyCode = 3;
        /// <summary>
        /// 備品名
        /// </summary>
        private const int _colSupplyName = 4;
        /// <summary>
        /// 出庫数
        /// </summary>
        private const int _colMoveNumber = 5;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyDetail(ConnectionVo connectionVo, int supplyCode) {
            _supplyCode = supplyCode;
            /*
             * Dao
             */
            _supplyDetailDao = new SupplyDetailDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            InitializeComponent();
            /*
             * 月初・月末を設定
             */
            DateTimePickerJpEx1.Value = new Date().GetBeginOfMonth(DateTimePickerJpEx1.Value);
            DateTimePickerJpEx2.Value = new Date().GetEndOfMonth(DateTimePickerJpEx2.Value);
            /*
             * SPREAD初期化
             */
            InitializeSheetViewList(SheetViewList);
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // 先頭行（列）インデックスを取得
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowを削除する
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(SupplyDetailVo supplyDetailVo in _supplyDetailDao.SelectSupplyDetailVo(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, _supplyCode)) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowヘッダ
                SheetViewList.Rows[i].Height = 22; // Rowの高さ
                SheetViewList.Rows[i].Resizable = false; // RowのResizableを禁止

                SheetViewList.Cells[i, 0].Value = supplyDetailVo.MoveDate;
                SheetViewList.Cells[i, 1].Value = supplyDetailVo.StaffCode;
                SheetViewList.Cells[i, 2].Value = supplyDetailVo.StaffName;
                SheetViewList.Cells[i, 3].Value = supplyDetailVo.SupplyCode;
                SheetViewList.Cells[i, 4].Value = supplyDetailVo.SupplyName;
                i++;
            }

            // 先頭行（列）インデックスをセット
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " 件");
        }


        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        private void InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // シートタブを非表示にする
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 10); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
        }

        /// <summary>
        /// DateTimePickerJpEx_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value > DateTimePickerJpEx2.Value) {
                DateTimePickerJpEx2.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }
        private void DateTimePickerJpEx2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value < DateTimePickerJpEx1.Value) {
                DateTimePickerJpEx1.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// SupplyDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplyDetail_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}
