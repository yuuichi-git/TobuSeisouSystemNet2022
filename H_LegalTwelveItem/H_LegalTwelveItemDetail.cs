/*
 * 2024-05-01
 */
using Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_LegalTwelveItem {
    public partial class H_LegalTwelveItemDetail : Form {
        /*
         * Dao
         */
        private readonly H_LegalTwelveItemDao _hLegalTwelveItemDao;
        /*
         * Vo
         */
        private readonly H_LegalTwelveItemListVo _hLegalTwelveItemListVo;
        private readonly int _fiscalYear;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /// <summary>
        /// 0→1回目　1→2回目　2→3回目
        /// </summary>
        private string[] _signNumber = new string[3] { "１回目", "２回目", "３回目" };
        /*
         * Control用の配列を確保
         */
        private H_CheckBoxEx[] _arrayHCheckBoxEx = new H_CheckBoxEx[12];
        private H_DateTimePickerEx[] _arrayHDateTimePickerEx = new H_DateTimePickerEx[12];
        private H_ComboBoxEx[] _arrayHComboBoxEx = new H_ComboBoxEx[12];
        private H_TextBoxEx[] _arrayHTextBoxEx = new H_TextBoxEx[12];
        private H_PictureBoxEx[] _arrayHPictureBoxEx = new H_PictureBoxEx[3];
        private H_ButtonEx[] _arrayHButtonExClip = new H_ButtonEx[3];
        private H_ButtonEx[] _arrayHButtonExDelete = new H_ButtonEx[3];

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="fiscalYear"></param>
        /// <param name="hLegalTwelveItemListVo"></param>
        public H_LegalTwelveItemDetail(ConnectionVo connectionVo, int fiscalYear, H_LegalTwelveItemListVo hLegalTwelveItemListVo) {
            /*
             * Dao
             */
            _hLegalTwelveItemDao = new(connectionVo);
            /*
             * Vo
             */
            _hLegalTwelveItemListVo = hLegalTwelveItemListVo;
            _fiscalYear = fiscalYear;
            /*
             * InitializeControl
             */
            InitializeComponent();
            /*
             * 配列をセット
             */
            _arrayHCheckBoxEx[0] = HCheckBoxEx1;
            _arrayHCheckBoxEx[1] = HCheckBoxEx2;
            _arrayHCheckBoxEx[2] = HCheckBoxEx3;
            _arrayHCheckBoxEx[3] = HCheckBoxEx4;
            _arrayHCheckBoxEx[4] = HCheckBoxEx5;
            _arrayHCheckBoxEx[5] = HCheckBoxEx6;
            _arrayHCheckBoxEx[6] = HCheckBoxEx7;
            _arrayHCheckBoxEx[7] = HCheckBoxEx8;
            _arrayHCheckBoxEx[8] = HCheckBoxEx9;
            _arrayHCheckBoxEx[9] = HCheckBoxEx10;
            _arrayHCheckBoxEx[10] = HCheckBoxEx11;
            _arrayHCheckBoxEx[11] = HCheckBoxEx12;

            _arrayHDateTimePickerEx[0] = HDateTimePickerEx1;
            _arrayHDateTimePickerEx[1] = HDateTimePickerEx2;
            _arrayHDateTimePickerEx[2] = HDateTimePickerEx3;
            _arrayHDateTimePickerEx[3] = HDateTimePickerEx4;
            _arrayHDateTimePickerEx[4] = HDateTimePickerEx5;
            _arrayHDateTimePickerEx[5] = HDateTimePickerEx6;
            _arrayHDateTimePickerEx[6] = HDateTimePickerEx7;
            _arrayHDateTimePickerEx[7] = HDateTimePickerEx8;
            _arrayHDateTimePickerEx[8] = HDateTimePickerEx9;
            _arrayHDateTimePickerEx[9] = HDateTimePickerEx10;
            _arrayHDateTimePickerEx[10] = HDateTimePickerEx11;
            _arrayHDateTimePickerEx[11] = HDateTimePickerEx12;

            _arrayHComboBoxEx[0] = HComboBoxEx1;
            _arrayHComboBoxEx[1] = HComboBoxEx2;
            _arrayHComboBoxEx[2] = HComboBoxEx3;
            _arrayHComboBoxEx[3] = HComboBoxEx4;
            _arrayHComboBoxEx[4] = HComboBoxEx5;
            _arrayHComboBoxEx[5] = HComboBoxEx6;
            _arrayHComboBoxEx[6] = HComboBoxEx7;
            _arrayHComboBoxEx[7] = HComboBoxEx8;
            _arrayHComboBoxEx[8] = HComboBoxEx9;
            _arrayHComboBoxEx[9] = HComboBoxEx10;
            _arrayHComboBoxEx[10] = HComboBoxEx11;
            _arrayHComboBoxEx[11] = HComboBoxEx12;

            _arrayHTextBoxEx[0] = HTextBoxEx1;
            _arrayHTextBoxEx[1] = HTextBoxEx2;
            _arrayHTextBoxEx[2] = HTextBoxEx3;
            _arrayHTextBoxEx[3] = HTextBoxEx4;
            _arrayHTextBoxEx[4] = HTextBoxEx5;
            _arrayHTextBoxEx[5] = HTextBoxEx6;
            _arrayHTextBoxEx[6] = HTextBoxEx7;
            _arrayHTextBoxEx[7] = HTextBoxEx8;
            _arrayHTextBoxEx[8] = HTextBoxEx9;
            _arrayHTextBoxEx[9] = HTextBoxEx10;
            _arrayHTextBoxEx[10] = HTextBoxEx11;
            _arrayHTextBoxEx[11] = HTextBoxEx12;

            _arrayHPictureBoxEx[0] = HPictureBoxEx1;
            _arrayHPictureBoxEx[1] = HPictureBoxEx2;
            _arrayHPictureBoxEx[2] = HPictureBoxEx3;

            HLabelExStaffCode.Text = Convert.ToString(hLegalTwelveItemListVo.StaffCode);
            HLabelExStaffName.Text = hLegalTwelveItemListVo.StaffName;
            HDateTimePickerExBase.SetValue(DateTime.Now);
            for (int i = 0; i < 12; i++) {
                _arrayHDateTimePickerEx[i].Enabled = false;
                _arrayHComboBoxEx[i].Enabled = false;
                _arrayHTextBoxEx[i].Enabled = false;
            }
            HPictureBoxEx1.Image = null;
            HPictureBoxEx2.Image = null;
            HPictureBoxEx3.Image = null;
            ToolStripStatusLabelDetail.Text = string.Empty;

            this.PutSheetViewList(_hLegalTwelveItemDao.SelectHLegalTwelveItemVo(_fiscalYear, _hLegalTwelveItemListVo.StaffCode));
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            for (int i = 0; i < 12; i++) {
                if (_arrayHCheckBoxEx[i].Checked) {
                    /*
                     * Controlの値をLegalTwelveItemVoに代入
                     */
                    H_LegalTwelveItemVo hLegalTwelveItemVo = new();
                    hLegalTwelveItemVo.StudentsDate = _arrayHDateTimePickerEx[i].GetValue();
                    hLegalTwelveItemVo.StudentsCode = Convert.ToInt32(_arrayHCheckBoxEx[i].Tag);
                    hLegalTwelveItemVo.StudentsFlag = _arrayHCheckBoxEx[i].Checked;
                    hLegalTwelveItemVo.StaffCode = _hLegalTwelveItemListVo.StaffCode;
                    hLegalTwelveItemVo.StaffSign = (byte[])new ImageConverter().ConvertTo(_arrayHPictureBoxEx[_arrayHComboBoxEx[i].SelectedIndex].Image, typeof(byte[]));
                    hLegalTwelveItemVo.SignNumber = _arrayHComboBoxEx[i].SelectedIndex;
                    hLegalTwelveItemVo.Memo = _arrayHTextBoxEx[i].Text;
                    hLegalTwelveItemVo.InsertPcName = Environment.MachineName;
                    hLegalTwelveItemVo.InsertYmdHms = DateTime.Now;
                    hLegalTwelveItemVo.UpdatePcName = string.Empty;
                    hLegalTwelveItemVo.UpdateYmdHms = _defaultDateTime;
                    hLegalTwelveItemVo.DeletePcName = string.Empty;
                    hLegalTwelveItemVo.DeleteYmdHms = _defaultDateTime;
                    hLegalTwelveItemVo.DeleteFlag = false;
                    /*
                     * レコードが存在すればUPDATEする。
                     * Tagに退避させてあるVoを渡す。変更前の値でSQLを発行しないとダメだよ！
                     */
                    if ((H_LegalTwelveItemVo)_arrayHTextBoxEx[i].Tag is not null && _hLegalTwelveItemDao.ExistenceHLegalTwelveItem((H_LegalTwelveItemVo)_arrayHTextBoxEx[i].Tag)) {
                        try {
                            _hLegalTwelveItemDao.UpdateOneHLegalTwelveItem((H_LegalTwelveItemVo)_arrayHTextBoxEx[i].Tag, hLegalTwelveItemVo);
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    } else {
                        try {
                            _hLegalTwelveItemDao.InsertOneHLegalTwelveItem(hLegalTwelveItemVo);
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    }
                } else {
                    /*
                     * 最初にセットされた値(Vo)はTagに代入してある
                     * _arrayTextBox[i].Tag = legalTwelveItemVo;
                     */
                    if ((H_LegalTwelveItemVo)_arrayHTextBoxEx[i].Tag is not null) {
                        try {
                            _hLegalTwelveItemDao.DeleteOneHLegalTwelveItemVo((H_LegalTwelveItemVo)_arrayHTextBoxEx[i].Tag);
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    }
                }
            }
            this.Close();
        }

        /// <summary>
        /// HCheckBoxEx_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCheckBoxEx_CheckedChanged(object sender, EventArgs e) {
            if (((H_CheckBoxEx)sender).Checked) {
                _arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = true;
                /*
                 * 指導実施日が空白の場合、値を入力する
                 */
                if (_arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].CustomFormat == " ")
                    _arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].SetValue(HDateTimePickerExBase.GetValue());
                _arrayHComboBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = true;
                _arrayHTextBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = true;
            } else {
                if (_arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].CustomFormat != " " || _arrayHComboBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Text != "" || _arrayHTextBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Text != "") {
                    DialogResult dialogResult = MessageBox.Show("登録されているデータを削除してもよろしいですか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.OK:
                            _arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = false;
                            _arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].SetBlank();
                            _arrayHComboBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = false;
                            _arrayHTextBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = false;
                            break;
                        case DialogResult.Cancel:
                            // 処理を戻す意味で、フラグを反転させる
                            ((H_CheckBoxEx)sender).Checked = !((H_CheckBoxEx)sender).Checked;
                            break;
                    }
                } else {
                    _arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = false;
                    _arrayHDateTimePickerEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].SetBlank();
                    _arrayHComboBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = false;
                    _arrayHTextBoxEx[Convert.ToInt32(((H_CheckBoxEx)sender).Tag)].Enabled = false;
                }
            }
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="listHLegalTwelveItemVo"></param>
        private void PutSheetViewList(List<H_LegalTwelveItemVo> listHLegalTwelveItemVo) {
            /*
             * CheckBox等の処理
             */
            for (int i = 0; i < 12; i++) {
                H_LegalTwelveItemVo hLegalTwelveItemVo = listHLegalTwelveItemVo.Find(x => x.StudentsCode == i);
                /*
                 * _arrayTextBoxのTagにLegalTwelveItemVoを格納
                 * Recordを削除するさいに必要な情報になる
                 */
                _arrayHTextBoxEx[i].Tag = hLegalTwelveItemVo;

                if (hLegalTwelveItemVo is not null) {
                    _arrayHCheckBoxEx[i].Checked = true;
                    _arrayHDateTimePickerEx[i].SetValue(hLegalTwelveItemVo.StudentsDate);
                    _arrayHComboBoxEx[i].Text = _signNumber[hLegalTwelveItemVo.SignNumber];
                    _arrayHTextBoxEx[i].Text = hLegalTwelveItemVo.Memo;
                } else {
                    _arrayHCheckBoxEx[i].Checked = false;
                    _arrayHDateTimePickerEx[i].SetBlank();
                    _arrayHComboBoxEx[i].Text = string.Empty;
                    _arrayHTextBoxEx[i].Text = string.Empty;
                }
            }
            /*
             * PictureBoxの処理
             */
            IEnumerable<H_LegalTwelveItemVo> iEnumerableHLegalTwelveItemVo = listHLegalTwelveItemVo.DistinctByKey(c => c.SignNumber);
            foreach (H_LegalTwelveItemVo hLegalTwelveItemVo in iEnumerableHLegalTwelveItemVo.OrderBy(x => x.SignNumber)) {
                if (hLegalTwelveItemVo.StaffSign is not null && hLegalTwelveItemVo.StaffSign.Length != 0) {
                    ImageConverter imageConv = new ImageConverter();
                    _arrayHPictureBoxEx[hLegalTwelveItemVo.SignNumber].Image = (Image)imageConv.ConvertFrom(hLegalTwelveItemVo.StaffSign);
                } else {
                    _arrayHPictureBoxEx[hLegalTwelveItemVo.SignNumber].Image = null;
                }
            }
        }

        /// <summary>
        /// ToolStripMenuItemがクリックされた時のSourceControlを保持
        /// </summary>
        Control _sourceControl = null;
        /// <summary>
        /// ContextMenuStrip1_Opened
        /// コンテキストが開かれた親コントロールを取得する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opened(object sender, EventArgs e) {
            //ContextMenuStripを表示しているコントロールを取得する
            _sourceControl = ((ContextMenuStrip)sender).SourceControl;
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * Picture Clip
                 */
                case "ToolStripMenuItemClip":
                    ((H_PictureBoxEx)_sourceControl).Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                /*
                 * Picture Delete
                 */
                case "ToolStripMenuItemDelete":
                    ((H_PictureBoxEx)_sourceControl).Image = null;
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
        /// H_LegalTwelveItemDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LegalTwelveItemDetail_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
