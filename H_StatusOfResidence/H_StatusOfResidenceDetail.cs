/*
 * 2024-04-11
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_StatusOfResidence {
    public partial class H_StatusOfResidenceDetail : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_StatusOfResidenceMasterDao _hStatusOfResidenceMasterDao;
        /// <summary>
        /// コンストラクター(新規)
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StatusOfResidenceDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hStatusOfResidenceMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeControl();
            this.InitializeComboBoxSelectName();
            HComboBoxExStaffName.Enabled = true;
        }

        /// <summary>
        /// コンストラクター(修正)
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public H_StatusOfResidenceDetail(ConnectionVo connectionVo, int staffCode) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hStatusOfResidenceMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeControl();
            this.SetControl(staffCode);
            HComboBoxExStaffName.Enabled = false;
        }

        /// <summary>
        /// InitializeControl
        /// </summary>
        private void InitializeControl() {
            HComboBoxExStaffName.Text = string.Empty;
            HTextBoxExStaffCode.Text = string.Empty;
            HTextBoxExStaffDisplayName.Text = string.Empty;
            HTextBoxExNameKana.Text = string.Empty;
            HTextBoxExName.Text = string.Empty;
            HDateTimeExBirthDate.SetValue(DateTime.Now.Date);
            HComboBoxExGender.Text = string.Empty;
            HComboBoxExNationality.Text = string.Empty;
            HTextBoxExAddress.Text = string.Empty;
            HComboBoxExStatusOfResidence.Text = string.Empty;
            HComboBoxExWorkLimit.Text = string.Empty;
            HDateTimePickerExPeriodDate.SetValue(DateTime.Now.Date);
            HDateTimePickerExDeadlineDate.SetValue(DateTime.Now.Date);
            HPictureBoxExHead.Image = null;
            HPictureBoxExTail.Image = null;
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// SetControl
        /// </summary>
        /// <param name="staffCode"></param>
        private void SetControl(int staffCode) {
            H_StaffMasterVo hStaffMasterVo = _hStaffMasterDao.SelectOneHStaffMaster(staffCode);
            H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo = _hStatusOfResidenceMasterDao.SelectOneHStatusOfResidenceMasterP(staffCode);
            HComboBoxExStaffName.Text = string.Empty;
            HTextBoxExStaffCode.Text = hStaffMasterVo.StaffCode.ToString("#####");
            HTextBoxExStaffDisplayName.Text = hStaffMasterVo.DisplayName;
            HTextBoxExNameKana.Text = hStatusOfResidenceMasterVo.StaffNameKana;
            HTextBoxExName.Text = hStatusOfResidenceMasterVo.StaffName;
            HDateTimeExBirthDate.SetValue(hStatusOfResidenceMasterVo.BirthDate);
            HComboBoxExGender.Text = hStatusOfResidenceMasterVo.Gender;
            HComboBoxExNationality.Text = hStatusOfResidenceMasterVo.Nationality;
            HTextBoxExAddress.Text = hStatusOfResidenceMasterVo.Address;
            HComboBoxExStatusOfResidence.Text = hStatusOfResidenceMasterVo.StatusOfResidence;
            HComboBoxExWorkLimit.Text = hStatusOfResidenceMasterVo.WorkLimit;
            HDateTimePickerExPeriodDate.SetValue(hStatusOfResidenceMasterVo.PeriodDate);
            HDateTimePickerExDeadlineDate.SetValue(hStatusOfResidenceMasterVo.DeadlineDate);
            if (hStatusOfResidenceMasterVo.PictureHead.Length != 0) {
                ImageConverter imageConverter = new();
                HPictureBoxExHead.Image = (Image)imageConverter.ConvertFrom(hStatusOfResidenceMasterVo.PictureHead); // 写真
            }
            if (hStatusOfResidenceMasterVo.PictureTail.Length != 0) {
                ImageConverter imageConverter = new();
                HPictureBoxExTail.Image = (Image)imageConverter.ConvertFrom(hStatusOfResidenceMasterVo.PictureTail); // 写真
            }
        }

        /// <summary>
        /// SetVo
        /// </summary>
        /// <returns></returns>
        private H_StatusOfResidenceMasterVo SetVo() {
            H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo = new();
            hStatusOfResidenceMasterVo.StaffCode = int.Parse(HTextBoxExStaffCode.Text);
            hStatusOfResidenceMasterVo.StaffNameKana = HTextBoxExNameKana.Text;
            hStatusOfResidenceMasterVo.StaffName = HTextBoxExName.Text;
            hStatusOfResidenceMasterVo.BirthDate = HDateTimeExBirthDate.GetValue();
            hStatusOfResidenceMasterVo.Gender = HComboBoxExGender.Text;
            hStatusOfResidenceMasterVo.Nationality = HComboBoxExNationality.Text;
            hStatusOfResidenceMasterVo.Address = HTextBoxExAddress.Text;
            hStatusOfResidenceMasterVo.StatusOfResidence = HComboBoxExStatusOfResidence.Text;
            hStatusOfResidenceMasterVo.WorkLimit = HComboBoxExWorkLimit.Text;
            hStatusOfResidenceMasterVo.PeriodDate = HDateTimePickerExPeriodDate.GetValue();
            hStatusOfResidenceMasterVo.DeadlineDate = HDateTimePickerExDeadlineDate.GetValue();
            hStatusOfResidenceMasterVo.PictureHead = (byte[])new ImageConverter().ConvertTo(HPictureBoxExHead.Image, typeof(byte[])); // 写真
            hStatusOfResidenceMasterVo.PictureTail = (byte[])new ImageConverter().ConvertTo(HPictureBoxExTail.Image, typeof(byte[])); // 写真
            hStatusOfResidenceMasterVo.InsertPcName = string.Empty;
            hStatusOfResidenceMasterVo.InsertYmdHms = _defaultDateTime;
            hStatusOfResidenceMasterVo.UpdatePcName = string.Empty;
            hStatusOfResidenceMasterVo.UpdateYmdHms = _defaultDateTime;
            hStatusOfResidenceMasterVo.DeletePcName = string.Empty;
            hStatusOfResidenceMasterVo.DeleteYmdHms = _defaultDateTime;
            hStatusOfResidenceMasterVo.DeleteFlag = false;
            return hStatusOfResidenceMasterVo;
        }

        /// <summary>
        /// InitializeComboBoxSelectName
        /// ComboBoxにデータを入れる
        /// </summary>
        private void InitializeComboBoxSelectName() {
            HComboBoxExStaffName.Items.Clear();
            foreach (H_StaffMasterVo hStaffMasterVo in _hStaffMasterDao.SelectAllHStaffMaster().OrderBy(x => x.NameKana))
                HComboBoxExStaffName.Items.Add(new ComboBoxSelectNameVo(hStaffMasterVo.Name, hStaffMasterVo));
            HComboBoxExStaffName.DisplayMember = "Name";
            // ここでイベント追加しないと初期化で発火しちゃうよ
            HComboBoxExStaffName.SelectedIndexChanged += ComboBoxSelectName_SelectedIndexChanged;
            // オートコンプリートモードの設定
            HComboBoxExStaffName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // コンボボックスのアイテムをオートコンプリートの選択候補とする
            HComboBoxExStaffName.AutoCompleteSource = AutoCompleteSource.ListItems;
            HComboBoxExStaffName.Focus();
        }

        /// <summary>
        /// ComboBoxSelectNameVo
        /// 内部クラス
        /// </summary>
        private class ComboBoxSelectNameVo {
            private string _name;
            private H_StaffMasterVo _hStaffMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectNameVo(string name, H_StaffMasterVo hStaffMasterVo) {
                _name = name;
                _hStaffMasterVo = hStaffMasterVo;
            }

            public string Name {
                get => _name;
                set => _name = value;
            }
            public H_StaffMasterVo HStaffMasterVo {
                get => _hStaffMasterVo;
                set => _hStaffMasterVo = value;
            }
        }

        /// <summary>
        /// ComboBoxSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectName_SelectedIndexChanged(object sender, EventArgs e) {
            H_StaffMasterVo hStaffMasterVo = ((ComboBoxSelectNameVo)((H_ComboBoxEx)sender).SelectedItem).HStaffMasterVo;
            HTextBoxExStaffCode.Text = hStaffMasterVo.StaffCode.ToString("#####");
            HTextBoxExStaffDisplayName.Text = hStaffMasterVo.DisplayName;
            HTextBoxExNameKana.Text = hStaffMasterVo.NameKana;
            HTextBoxExName.Text = hStaffMasterVo.Name;
            HDateTimeExBirthDate.SetValue(hStaffMasterVo.BirthDate);
            HComboBoxExGender.Text = hStaffMasterVo.Gender;
            HTextBoxExAddress.Text = hStaffMasterVo.CurrentAddress;
            ToolStripStatusLabelDetail.Text = string.Concat(hStaffMasterVo.DisplayName, " のデータを読込みました。");
        }

        /// <summary>
        /// HButtonEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonEx_Click(object sender, EventArgs e) {
            switch (((H_ButtonEx)sender).Name) {
                case "HButtonExUpdate":
                    try {
                        int.TryParse(HTextBoxExStaffCode.Text, out int staffCode);
                        if (_hStatusOfResidenceMasterDao.ExistenceHStatusOfResidenceMaster(staffCode)) {
                            try {
                                _hStatusOfResidenceMasterDao.UpdateOneHStatusOfResidenceMaster(this.SetVo());
                            } catch (Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                            this.Close();
                        } else {
                            try {
                                _hStatusOfResidenceMasterDao.InsertOneHStatusOfResidenceMaster(this.SetVo());
                            } catch (Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                            this.Close();
                        }
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "HButtonExHeadClip":
                    /*
                     * クリップボードを転送
                     * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
                     */
                    HButtonExHeadClip.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                case "HButtonExHeadDelete":
                    HButtonExHeadDelete.Image = null;
                    break;
                case "HButtonExTailClip":
                    /*
                     * クリップボードを転送
                     * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
                     */
                    HButtonExTailClip.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                case "HButtonExTailDelete":
                    HButtonExTailDelete.Image = null;
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// H_StatusOfResidenceDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_StatusOfResidenceDetail_FormClosing(object sender, FormClosingEventArgs e) {
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
