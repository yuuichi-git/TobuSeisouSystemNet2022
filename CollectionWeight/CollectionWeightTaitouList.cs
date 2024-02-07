/*
 * 2023-08-01
 */
using Common;

using ControlEx;

using Dao;

using FarPoint.Win.Spread;

using H_Vo;

namespace CollectionWeight {
    public partial class CollectionWeightTaitouList : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Dao
         */
        private readonly CollectionWeightTaitouDao _collectionWeightTaitouDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private List<CollectionWeightTaitouVo> _listCollectionWeightTaitouVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public CollectionWeightTaitouList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _collectionWeightTaitouDao = new CollectionWeightTaitouDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _listCollectionWeightTaitouVo = new();
            /*
             * InitializeControl
             */
            InitializeComponent();
            DateTimePickerJpExOperationDate1.Value = new Date().GetBeginOfMonth(DateTime.Now);
            DateTimePickerJpExOperationDate2.Value = new Date().GetEndOfMonth(DateTime.Now);
            InitializeSheetViewList(SheetViewList);
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            try {
                _listCollectionWeightTaitouVo = _collectionWeightTaitouDao.SelectListCollectionWeightTaitou(DateTimePickerJpExOperationDate1.GetValue(), DateTimePickerJpExOperationDate2.GetValue());
                SheetViewListOutPut(_listCollectionWeightTaitouVo);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        /// <param name="_listCollectionWeightTaitouVo"></param>
        private void SheetViewListOutPut(List<CollectionWeightTaitouVo> _listCollectionWeightTaitouVo) {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // Rowを削除する
            SheetViewList.ClearRange(1, 0, 31, 9, true);

            int rowNumber = 1;
            for(int day = 1; day <= new Date().GetDaysInMonth(DateTimePickerJpExOperationDate2.Value); day++) {
                /*
                 * レコードを抽出する
                 */
                var collectionWeightTaitouVo = _listCollectionWeightTaitouVo.Find(x => x.Operation_date == new DateTime(DateTimePickerJpExOperationDate1.Value.Year, DateTimePickerJpExOperationDate1.Value.Month, day));
                /*
                 * 出力する
                 */
                SheetViewList.Cells[rowNumber, 0].Value = new DateTime(DateTimePickerJpExOperationDate1.Value.Year, DateTimePickerJpExOperationDate1.Value.Month, day);
                SheetViewList.Cells[rowNumber, 1].Text = new DateTime(DateTimePickerJpExOperationDate1.Value.Year, DateTimePickerJpExOperationDate1.Value.Month, day).ToString("ddd");
                if(collectionWeightTaitouVo is not null) {
                    SheetViewList.Cells[rowNumber, 2].Value = collectionWeightTaitouVo.Weight1Total;
                    SheetViewList.Cells[rowNumber, 3].Value = collectionWeightTaitouVo.Weight2Total;
                    SheetViewList.Cells[rowNumber, 4].Value = collectionWeightTaitouVo.Weight3Total;
                    SheetViewList.Cells[rowNumber, 5].Value = collectionWeightTaitouVo.Weight4Total;
                    SheetViewList.Cells[rowNumber, 6].Value = collectionWeightTaitouVo.Weight5Total;
                    SheetViewList.Cells[rowNumber, 7].Value = collectionWeightTaitouVo.Weight6Total;
                    SheetViewList.Cells[rowNumber, 8].Value = collectionWeightTaitouVo.Weight7Total;
                }
                rowNumber++;
            }
            // Spread 活性化
            SpreadList.ResumeLayout();
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            SheetViewList.ClearRange(1, 0, 31, 9, true);
            return sheetView;
        }

        /// <summary>
        /// DateTimePickerJpExOperationDate1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpExOperationDate1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value > DateTimePickerJpExOperationDate2.Value) {
                DateTimePickerJpExOperationDate2.Value = new Date().GetEndOfMonth(((DateTimePickerJpEx)sender).Value);
            }
        }

        /// <summary>
        /// DateTimePickerJpExOperationDate2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpExOperationDate2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value < DateTimePickerJpExOperationDate1.Value) {
                DateTimePickerJpExOperationDate1.Value = new Date().GetBeginOfMonth(((DateTimePickerJpEx)sender).Value);
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrintting_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrintting_Click(object sender, EventArgs e) {
            //アクティブシート印刷します
            SpreadList.PrintSheet(SheetViewList);
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
        /// CollectionWeightTaitouList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectionWeightTaitouList_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
