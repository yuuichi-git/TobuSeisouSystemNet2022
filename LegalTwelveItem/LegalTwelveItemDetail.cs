/*
 * 2023-08-31
 */
using Common;

using ControlEx;

using Dao;

using Vo;

namespace LegalTwelveItem {
    public partial class LegalTwelveItemDetail : Form {
        private DateTime _dateTime1;
        private DateTime _dateTime2;
        /// <summary>
        /// 0→1回目　1→2回目　2→3回目
        /// </summary>
        private string[] _signNumber = new string[]{ "１回目","２回目","３回目"};
        /*
         * Control用の配列を確保
         */
        private CheckBox[] _arrayCheckBox = new CheckBox[12];
        private DateTimePickerJpEx[] _arrayDateTimePickerJpEx = new DateTimePickerJpEx[12];
        private ComboBoxEx[] _arrayComboBoxEx = new ComboBoxEx[12];
        private TextBox[] _arrayTextBox = new TextBox[12];
        /*
         * Dao
         */
        private readonly LegalTwelveItemDao _legalTwelveItemDao;
        /*
         *Vo
         */
        private readonly ConnectionVo _connectionVo;
        private LegalTwelveItemListVo _legalTwelveItemListVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public LegalTwelveItemDetail(ConnectionVo connectionVo, DateTime datetime1, DateTime datetime2, LegalTwelveItemListVo legalTwelveItemListVo) {
            _dateTime1 = datetime1;
            _dateTime2 = datetime2;
            /*
             * Dao
             */
            _legalTwelveItemDao = new LegalTwelveItemDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _legalTwelveItemListVo = legalTwelveItemListVo;
            /*
             * Controlを初期化
             */
            InitializeComponent();
            LabelStaffCode.Text = Convert.ToString(legalTwelveItemListVo.Staff_code);
            LabelStaffName.Text = legalTwelveItemListVo.Staff_name;
            /*
             * Controlを配列にセット
             */
            _arrayCheckBox[0] = checkBox1;
            _arrayCheckBox[1] = checkBox2;
            _arrayCheckBox[2] = checkBox3;
            _arrayCheckBox[3] = checkBox4;
            _arrayCheckBox[4] = checkBox5;
            _arrayCheckBox[5] = checkBox6;
            _arrayCheckBox[6] = checkBox7;
            _arrayCheckBox[7] = checkBox8;
            _arrayCheckBox[8] = checkBox9;
            _arrayCheckBox[9] = checkBox10;
            _arrayCheckBox[10] = checkBox11;
            _arrayCheckBox[11] = checkBox12;

            _arrayDateTimePickerJpEx[0] = dateTimePickerJpEx1;
            _arrayDateTimePickerJpEx[1] = dateTimePickerJpEx2;
            _arrayDateTimePickerJpEx[2] = dateTimePickerJpEx3;
            _arrayDateTimePickerJpEx[3] = dateTimePickerJpEx4;
            _arrayDateTimePickerJpEx[4] = dateTimePickerJpEx5;
            _arrayDateTimePickerJpEx[5] = dateTimePickerJpEx6;
            _arrayDateTimePickerJpEx[6] = dateTimePickerJpEx7;
            _arrayDateTimePickerJpEx[7] = dateTimePickerJpEx8;
            _arrayDateTimePickerJpEx[8] = dateTimePickerJpEx9;
            _arrayDateTimePickerJpEx[9] = dateTimePickerJpEx10;
            _arrayDateTimePickerJpEx[10] = dateTimePickerJpEx11;
            _arrayDateTimePickerJpEx[11] = dateTimePickerJpEx12;

            _arrayComboBoxEx[0] = comboBoxEx1;
            _arrayComboBoxEx[1] = comboBoxEx2;
            _arrayComboBoxEx[2] = comboBoxEx3;
            _arrayComboBoxEx[3] = comboBoxEx4;
            _arrayComboBoxEx[4] = comboBoxEx5;
            _arrayComboBoxEx[5] = comboBoxEx6;
            _arrayComboBoxEx[6] = comboBoxEx7;
            _arrayComboBoxEx[7] = comboBoxEx8;
            _arrayComboBoxEx[8] = comboBoxEx9;
            _arrayComboBoxEx[9] = comboBoxEx10;
            _arrayComboBoxEx[10] = comboBoxEx11;
            _arrayComboBoxEx[11] = comboBoxEx12;

            _arrayTextBox[0] = textBox1;
            _arrayTextBox[1] = textBox2;
            _arrayTextBox[2] = textBox3;
            _arrayTextBox[3] = textBox4;
            _arrayTextBox[4] = textBox5;
            _arrayTextBox[5] = textBox6;
            _arrayTextBox[6] = textBox7;
            _arrayTextBox[7] = textBox8;
            _arrayTextBox[8] = textBox9;
            _arrayTextBox[9] = textBox10;
            _arrayTextBox[10] = textBox11;
            _arrayTextBox[11] = textBox12;

            this.SheetViewOutput();
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            /*
             * 入力項目のバリデーション
             */

            /*
             * Controlの値をLegalTwelveItemVoに代入
             */
            LegalTwelveItemVo legalTwelveItemVo = new LegalTwelveItemVo();


        }

        /// <summary>
        /// SheetViewOutput
        /// </summary>
        private void SheetViewOutput() {
            List<LegalTwelveItemVo> listLegalTwelveItemVo = _legalTwelveItemDao.SelectAllLegalTwelveItem(_dateTime1,_dateTime2,_legalTwelveItemListVo.Staff_code);
            for(int i = 0; i < 12; i++) {
                LegalTwelveItemVo? legalTwelveItemVo = listLegalTwelveItemVo.Find(x => x.Students_code == i + 1);
                if(legalTwelveItemVo is not null) {
                    _arrayCheckBox[i].Checked = true;
                    _arrayDateTimePickerJpEx[i].SetValue(legalTwelveItemVo.Students_date);
                    _arrayComboBoxEx[i].Text = _signNumber[legalTwelveItemVo.Sign_number];
                    _arrayTextBox[i].Text = legalTwelveItemVo.Memo;
                } else {
                    _arrayCheckBox[i].Checked = false;
                    _arrayDateTimePickerJpEx[i].SetBlank();
                    _arrayComboBoxEx[i].Text = string.Empty;
                    _arrayTextBox[i].Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// CheckBox_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e) {
            if(((CheckBox)sender).Checked) {
                _arrayDateTimePickerJpEx[Convert.ToInt32(((CheckBox)sender).Tag)].Enabled = ((CheckBox)sender).Checked;
                _arrayDateTimePickerJpEx[Convert.ToInt32(((CheckBox)sender).Tag)].SetValue(DateTime.Today);
                _arrayComboBoxEx[Convert.ToInt32(((CheckBox)sender).Tag)].Enabled = ((CheckBox)sender).Checked;
                _arrayTextBox[Convert.ToInt32(((CheckBox)sender).Tag)].Enabled = ((CheckBox)sender).Checked;
            } else {
                _arrayDateTimePickerJpEx[Convert.ToInt32(((CheckBox)sender).Tag)].Enabled = ((CheckBox)sender).Checked;
                _arrayDateTimePickerJpEx[Convert.ToInt32(((CheckBox)sender).Tag)].SetBlank();
                _arrayComboBoxEx[Convert.ToInt32(((CheckBox)sender).Tag)].Enabled = ((CheckBox)sender).Checked;
                _arrayTextBox[Convert.ToInt32(((CheckBox)sender).Tag)].Enabled = ((CheckBox)sender).Checked;
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
        /// LegalTwelveItemDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LegalTwelveItemDetail_FormClosing(object sender, FormClosingEventArgs e) {
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
