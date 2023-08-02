/*
 * 2023-07-22
 */
using Dao;

using Vo;

namespace CollectionWeight {
    public partial class CollectionWeightTaitouInput : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);
        /*
         * Dao
         */
        private readonly CollectionWeightTaitouDao _collectionWeightTaitouDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CollectionWeightTaitouInput(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _collectionWeightTaitouDao = new CollectionWeightTaitouDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            DateTimePickerJpExOperationDate.Value = DateTime.Now.Date;
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// EntryPoint
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            /*
             * Voを作成して値を代入する
             */
            CollectionWeightTaitouVo collectionWeightTaitouVo = new CollectionWeightTaitouVo();
            collectionWeightTaitouVo.Operation_date = DateTimePickerJpExOperationDate.Value.Date;
            collectionWeightTaitouVo.Weight1Total = (int)NumericUpDownEx1.Value;
            collectionWeightTaitouVo.Weight2Total = (int)NumericUpDownEx2.Value;
            collectionWeightTaitouVo.Weight3Total = (int)NumericUpDownEx3.Value;
            collectionWeightTaitouVo.Weight4Total = (int)NumericUpDownEx4.Value;
            collectionWeightTaitouVo.Weight5Total = (int)NumericUpDownEx5.Value;
            collectionWeightTaitouVo.Weight6Total = (int)NumericUpDownEx6.Value;
            collectionWeightTaitouVo.Weight7Total = (int)NumericUpDownEx7.Value;
            collectionWeightTaitouVo.Insert_pc_name = string.Empty;
            collectionWeightTaitouVo.Insert_ymd_hms = _defaultDateTime;
            collectionWeightTaitouVo.Update_pc_name = string.Empty;
            collectionWeightTaitouVo.Update_ymd_hms = _defaultDateTime;
            collectionWeightTaitouVo.Delete_pc_name = string.Empty;
            collectionWeightTaitouVo.Delete_ymd_hms = _defaultDateTime;
            collectionWeightTaitouVo.Delete_flag = false;

            if(_collectionWeightTaitouDao.CheckCollectionWeightTaitou(DateTimePickerJpExOperationDate.GetValue())) {
                try {
                    /*
                     * 固有の値を代入する
                     */
                    collectionWeightTaitouVo.Update_pc_name = Environment.MachineName;
                    collectionWeightTaitouVo.Update_ymd_hms = DateTime.Now;
                    _collectionWeightTaitouDao.UpdateCollectionWeightTaitou(collectionWeightTaitouVo);
                    this.Close();
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            } else {
                try {
                    /*
                     * 固有の値を代入する
                     */
                    collectionWeightTaitouVo.Insert_pc_name = Environment.MachineName;
                    collectionWeightTaitouVo.Insert_ymd_hms = DateTime.Now;
                    _collectionWeightTaitouDao.InsertCollectionWeightTaitou(collectionWeightTaitouVo);
                    this.Close();
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// DateTimePickerJpExOperationDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpExOperationDate_ValueChanged(object sender, EventArgs e) {
            // 対象日のレコードを取得する
            CollectionWeightTaitouVo collectionWeightTaitouVo = _collectionWeightTaitouDao.SelectCollectionWeightTaitou(DateTimePickerJpExOperationDate.GetValue().Date);
            NumericUpDownEx1.Value = collectionWeightTaitouVo.Weight1Total;
            NumericUpDownEx2.Value = collectionWeightTaitouVo.Weight2Total;
            NumericUpDownEx3.Value = collectionWeightTaitouVo.Weight3Total;
            NumericUpDownEx4.Value = collectionWeightTaitouVo.Weight4Total;
            NumericUpDownEx5.Value = collectionWeightTaitouVo.Weight5Total;
            NumericUpDownEx6.Value = collectionWeightTaitouVo.Weight6Total;
            NumericUpDownEx7.Value = collectionWeightTaitouVo.Weight7Total;
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
        /// TaitouCollectionWeight_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaitouCollectionWeight_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
