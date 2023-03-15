/*
 * 2023-03-09
 */
using Common;

using Vo;

namespace WardSpreadsheet {
    public partial class WardTaitou : Form {
        private InitializeForm _initializeForm = new();
        /// <summary>
        /// Key0 → ４月の位置を格納
        /// Key1 → ５月の位置を格納
        /// Key2 → ６月の位置を格納
        /// Key3 → ７月の位置を格納
        /// Key4 → ８月の位置を格納
        /// Key5 → ９月の位置を格納
        /// Key6 → １０月の位置を格納
        /// Key7 → １１月の位置を格納
        /// Key8 → １２月の位置を格納
        /// Key9 → １月の位置を格納(次年度)
        /// Key10 → ２月の位置を格納(次年度)
        /// Key11 → ３月の位置を格納(次年度)
        /// </summary>
        private Dictionary<int, Point> _dictionaryPoint = new Dictionary<int, Point>();

        public WardTaitou(ConnectionVo connectionVo) {
            /*
             * Dictionaryを作成
             * セルの左上の座標を指定
             */
            _dictionaryPoint.Add(0, new Point(2, 1));
            _dictionaryPoint.Add(1, new Point(11, 1));
            _dictionaryPoint.Add(2, new Point(20, 1));
            _dictionaryPoint.Add(3, new Point(29, 1));
            _dictionaryPoint.Add(4, new Point(38, 1));
            _dictionaryPoint.Add(5, new Point(47, 1));
            _dictionaryPoint.Add(6, new Point(2, 11));
            _dictionaryPoint.Add(7, new Point(11, 11));
            _dictionaryPoint.Add(8, new Point(20, 11));
            _dictionaryPoint.Add(9, new Point(29, 11));
            _dictionaryPoint.Add(10, new Point(38, 11));
            _dictionaryPoint.Add(11, new Point(47, 11));
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.WardTaitou(this);
        }

        /// <summary>
        /// InitializeSheetView
        /// シートを初期化
        /// </summary>
        private void InitializeSheetView() {

        }

        /*
         * Dictionaryで使用する値を作成
         */
        private class Point {
            private  int _row;
            private  int _column;
            public Point(int row, int column) {
                _row = row;
                _column = column;
            }
            public int Row {
                get => _row;
                set => _row = value;
            }
            public int Column {
                get => _column;
                set => _column = value;
            }
        }

        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //アクティブシート印刷します
            SpreadList.PrintSheet(SheetViewList);
        }

        private void ToolStripMenuItemExport_Click(object sender, EventArgs e) {

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
        /// WardTaitou_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WardTaitou_FormClosing(object sender, FormClosingEventArgs e) {
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
