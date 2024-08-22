/*
 * 2024-04-20 
 */
using FarPoint.Win.Spread;

using H_Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_CollectionWeight {
    public partial class H_CollectionWeightTAITOUList : Form {
        /*
         * Dao
         */
        private readonly H_CollectionWeightTaitouDao _hCollectionWeightTaitouDao;
        /*
         * Vo
         */
        private List<H_CollectionWeightTaitouVo> _listHCollectionWeightTaitouVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_CollectionWeightTAITOUList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCollectionWeightTaitouDao = new(connectionVo);
            /*
             * Vo
             */
            _listHCollectionWeightTaitouVo = new();
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.HDateTimePickerExOperationDate1.SetValueJp(new Date().GetBeginOfMonth(DateTime.Now));
            this.HDateTimePickerExOperationDate2.SetValueJp(new Date().GetEndOfMonth(DateTime.Now));
            this.InitializeSheetViewList(SheetViewList);
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            try {
                _listHCollectionWeightTaitouVo = _hCollectionWeightTaitouDao.SelectListHCollectionWeightTaitou(HDateTimePickerExOperationDate1.GetValue(), HDateTimePickerExOperationDate2.GetValue());
                PutSheetViewList(_listHCollectionWeightTaitouVo);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="listHCollectionWeightTaitouVo"></param>
        private void PutSheetViewList(List<H_CollectionWeightTaitouVo> listHCollectionWeightTaitouVo) {
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // Rowを削除する
            SheetViewList.ClearRange(1, 0, 31, 9, true);

            int rowNumber = 1;
            for (int day = 1; day <= new Date().GetDaysInMonth(HDateTimePickerExOperationDate2.GetValue()); day++) {
                /*
                 * レコードを抽出する
                 */
                H_CollectionWeightTaitouVo? hCollectionWeightTaitouVo = listHCollectionWeightTaitouVo.Find(x => x.OperationDate == new DateTime(HDateTimePickerExOperationDate1.GetValue().Year, HDateTimePickerExOperationDate1.GetValue().Month, day));
                /*
                 * 出力する
                 */
                SheetViewList.Cells[rowNumber, 0].Value = new DateTime(HDateTimePickerExOperationDate1.GetValue().Year, HDateTimePickerExOperationDate1.GetValue().Month, day);
                SheetViewList.Cells[rowNumber, 1].Text = new DateTime(HDateTimePickerExOperationDate1.GetValue().Year, HDateTimePickerExOperationDate1.GetValue().Month, day).ToString("ddd");
                if (hCollectionWeightTaitouVo is not null) {
                    SheetViewList.Cells[rowNumber, 2].Value = hCollectionWeightTaitouVo.Weight1Total;
                    SheetViewList.Cells[rowNumber, 3].Value = hCollectionWeightTaitouVo.Weight2Total;
                    SheetViewList.Cells[rowNumber, 4].Value = hCollectionWeightTaitouVo.Weight3Total;
                    SheetViewList.Cells[rowNumber, 5].Value = hCollectionWeightTaitouVo.Weight4Total;
                    SheetViewList.Cells[rowNumber, 6].Value = hCollectionWeightTaitouVo.Weight5Total;
                    SheetViewList.Cells[rowNumber, 7].Value = hCollectionWeightTaitouVo.Weight6Total;
                    SheetViewList.Cells[rowNumber, 8].Value = hCollectionWeightTaitouVo.Weight7Total;
                }
                rowNumber++;
            }
            // Spread 活性化
            SpreadList.ResumeLayout();
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // A4で印刷
                case "ToolStripMenuItemPrintA4":
                    //アクティブシート印刷します
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
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

        private void HDateTimePickerExOperationDate1_ValueChanged(object sender, EventArgs e) {
            if (((H_DateTimePickerEx)sender).Value > HDateTimePickerExOperationDate2.GetValue()) {
                HDateTimePickerExOperationDate2.SetValueJp(new Date().GetEndOfMonth(((H_DateTimePickerEx)sender).GetValue()));
            }
        }

        private void HDateTimePickerExOperationDate2_ValueChanged(object sender, EventArgs e) {
            if (((H_DateTimePickerEx)sender).Value < HDateTimePickerExOperationDate1.GetValue()) {
                HDateTimePickerExOperationDate1.SetValueJp(new Date().GetBeginOfMonth(((H_DateTimePickerEx)sender).GetValue()));
            }
        }

        /// <summary>
        /// H_CollectionWeightTAITOUList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CollectionWeightTAITOUList_FormClosing(object sender, FormClosingEventArgs e) {
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
