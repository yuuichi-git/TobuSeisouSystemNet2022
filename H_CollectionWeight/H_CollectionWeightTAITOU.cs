/*
 * 2024-03-16
 */
using H_Dao;

using H_Vo;

using Vo;

namespace H_CollectionWeight {
    public partial class HCollectionWeightTAITOU : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Dao
         */
        private readonly H_CollectionWeightTaitouDao _hCollectionWeightTaitouDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public HCollectionWeightTAITOU(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCollectionWeightTaitouDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            HDateTimePickerExOperationDate.SetValueJp(DateTime.Now.Date);
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            /*
             * Voを作成して値を代入する
             */
            H_CollectionWeightTaitouVo hCollectionWeightTaitouVo = new();
            hCollectionWeightTaitouVo.OperationDate = HDateTimePickerExOperationDate.GetValue().Date;
            hCollectionWeightTaitouVo.Weight1Total = (int)HNumericUpDownEx1.Value;
            hCollectionWeightTaitouVo.Weight2Total = (int)HNumericUpDownEx2.Value;
            hCollectionWeightTaitouVo.Weight3Total = (int)HNumericUpDownEx3.Value;
            hCollectionWeightTaitouVo.Weight4Total = (int)HNumericUpDownEx4.Value;
            // 予備
            hCollectionWeightTaitouVo.Weight6Total = (int)HNumericUpDownEx5.Value;
            hCollectionWeightTaitouVo.Weight7Total = (int)HNumericUpDownEx6.Value;
            hCollectionWeightTaitouVo.Weight8Total = (int)HNumericUpDownEx7.Value;
            // 予備
            hCollectionWeightTaitouVo.InsertPcName = string.Empty;
            hCollectionWeightTaitouVo.InsertYmdHms = _defaultDateTime;
            hCollectionWeightTaitouVo.UpdatePcName = string.Empty;
            hCollectionWeightTaitouVo.UpdateYmdHms = _defaultDateTime;
            hCollectionWeightTaitouVo.DeletePcName = string.Empty;
            hCollectionWeightTaitouVo.DeleteYmdHms = _defaultDateTime;
            hCollectionWeightTaitouVo.DeleteFlag = false;

            if (_hCollectionWeightTaitouDao.ExistenceCollectionWeightTaitou(HDateTimePickerExOperationDate.GetValue().Date)) {
                try {
                    _hCollectionWeightTaitouDao.UpdateOneCollectionWeightTaitou(hCollectionWeightTaitouVo);
                    this.Close();
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            } else {
                try {
                    _hCollectionWeightTaitouDao.InsertOneCollectionWeightTaitou(hCollectionWeightTaitouVo);
                    this.Close();
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// HDateTimePickerExOperationDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerExOperationDate_ValueChanged(object sender, EventArgs e) {
            // 対象日のレコードを取得する
            H_CollectionWeightTaitouVo hCollectionWeightTaitouVo = _hCollectionWeightTaitouDao.SelectCollectionWeightTaitou(HDateTimePickerExOperationDate.GetValue().Date);
            if (hCollectionWeightTaitouVo is not null) {
                HNumericUpDownEx1.Value = hCollectionWeightTaitouVo.Weight1Total;
                HNumericUpDownEx2.Value = hCollectionWeightTaitouVo.Weight2Total;
                HNumericUpDownEx3.Value = hCollectionWeightTaitouVo.Weight3Total;
                HNumericUpDownEx4.Value = hCollectionWeightTaitouVo.Weight4Total;
                HNumericUpDownEx5.Value = hCollectionWeightTaitouVo.Weight5Total;
                HNumericUpDownEx6.Value = hCollectionWeightTaitouVo.Weight6Total;
                HNumericUpDownEx7.Value = hCollectionWeightTaitouVo.Weight7Total;
                ToolStripStatusLabelDetail.Text = string.Concat(HDateTimePickerExOperationDate.GetValueJp()," の記録を読込ました");
            } else {
                HNumericUpDownEx1.Value = 0;
                HNumericUpDownEx2.Value = 0;
                HNumericUpDownEx3.Value = 0;
                HNumericUpDownEx4.Value = 0;
                HNumericUpDownEx5.Value = 0;
                HNumericUpDownEx6.Value = 0;
                HNumericUpDownEx7.Value = 0;
                ToolStripStatusLabelDetail.Text = "記録が存在しません";
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
    }
}
