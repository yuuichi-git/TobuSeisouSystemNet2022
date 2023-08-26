/*
 * 2023-08-21
 */
using Common;

using ControlEx;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace LegalTwelveItem {
    public partial class LegalTwelveItemList : Form {
        private Date _date = new();
        private InitializeForm _initializeForm = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * Dao
         */
        private readonly LegalTwelveItemDao _legalTwelveItemDao;

        public LegalTwelveItemList(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Dao
             */
            _legalTwelveItemDao = new LegalTwelveItemDao(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            _initializeForm.LegalTwelveItemList(this);
            DateTimePickerJpEx1.Value = _date.GetFiscalYearStartDate(DateTime.Today);
            DateTimePickerJpEx2.Value = _date.GetFiscalYearEndDate(DateTime.Today);
            InitializeSheetViewList(SheetViewList);
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
            var a = _legalTwelveItemDao.SelectLegalTwelveItemForm(DateTimePickerJpEx1.GetValue(), DateTimePickerJpEx2.GetValue());


        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 50; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// DateTimePickerJpEx1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value > DateTimePickerJpEx2.Value) {
                DateTimePickerJpEx2.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }

        /// <summary>
        /// DateTimePickerJpEx2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            Close();
        }

        /// <summary>
        /// LegalTwelveItemList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LegalTwelveItemList_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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