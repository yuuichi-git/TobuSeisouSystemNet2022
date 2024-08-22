/*
 * 2024-03-22
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_Toukanpo {
    public partial class H_ToukanpoTrainingCardDetail : Form {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_ToukanpoTrainingCardDao _hToukanpoTrainingCardDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_ToukanpoTrainingCardDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hToukanpoTrainingCardDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeComboBoxSelectName();
            this.InitializeControl();
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            if (_selectedHToukanpoTrainingCardVo == null) {
                MessageBox.Show("この名前は従業員台帳に登録されていません。リストから選択して下さい。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("更新しますか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    if (_hToukanpoTrainingCardDao.ExistenceHToukanpoTrainingCardMaster(_selectedHToukanpoTrainingCardVo.StaffCode)) {
                        try {
                            _hToukanpoTrainingCardDao.UpdateOneHToukanpoTrainingCardMaster(this.SetToukanpoTrainingCardVo());
                            MessageBox.Show("修正登録を完了しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.InitializeControl();
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    } else {
                        try {
                            _hToukanpoTrainingCardDao.InsertOneHToukanpoTrainingCardMaster(this.SetToukanpoTrainingCardVo());
                            MessageBox.Show("新規登録を完了しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.InitializeControl();
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// SetToukanpoTrainingCardVo
        /// </summary>
        /// <returns></returns>
        private H_ToukanpoTrainingCardVo SetToukanpoTrainingCardVo() {
            H_ToukanpoTrainingCardVo hToukanpoTrainingCardVo = new();
            hToukanpoTrainingCardVo.StaffCode = _selectedHStaffMasterVo.StaffCode;
            hToukanpoTrainingCardVo.DisplayName = _selectedHStaffMasterVo.DisplayName;
            hToukanpoTrainingCardVo.CompanyName = HComboBoxExCompany.Text;
            hToukanpoTrainingCardVo.CardName = _selectedHStaffMasterVo.DisplayName;
            hToukanpoTrainingCardVo.CertificationDate = HDateTimePickerExCertificationDate.GetValue().Date;
            hToukanpoTrainingCardVo.Picture = (byte[])new ImageConverter().ConvertTo(PictureBoxCard.Image, typeof(byte[])); // 写真
            hToukanpoTrainingCardVo.InsertPcName = Environment.MachineName;
            hToukanpoTrainingCardVo.InsertYmdHms = DateTime.Now;
            hToukanpoTrainingCardVo.UpdatePcName = Environment.MachineName;
            hToukanpoTrainingCardVo.UpdateYmdHms = DateTime.Now;
            hToukanpoTrainingCardVo.DeletePcName = Environment.MachineName;
            hToukanpoTrainingCardVo.DeleteYmdHms = DateTime.Now;
            hToukanpoTrainingCardVo.DeleteFlag = false;
            return hToukanpoTrainingCardVo;
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
        /// コントロールを初期化
        /// </summary>
        private void InitializeControl() {
            HComboBoxExCompany.Text = "東武清掃株式会社";
            HComboBoxExStaffName.Text = "";
            HDateTimePickerExCertificationDate.SetValue(DateTime.Now.Date);
            PictureBoxCard.Image = null;
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
        /// ComboBoxSelectNameで選択されたStaffLedgerVoを保持
        /// </summary>
        private H_StaffMasterVo _selectedHStaffMasterVo = new();
        /// <summary>
        /// ComboBoxSelectNameで選択されたToukanpoTrainingCardVoを保持
        /// </summary>
        private H_ToukanpoTrainingCardVo _selectedHToukanpoTrainingCardVo = new();
        /// <summary>
        /// ComboBoxSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectName_SelectedIndexChanged(object sender, EventArgs e) {
            _selectedHStaffMasterVo = ((ComboBoxSelectNameVo)((H_ComboBoxEx)sender).SelectedItem).HStaffMasterVo;
            _selectedHToukanpoTrainingCardVo = _hToukanpoTrainingCardDao.SelectOneHToukanpoTrainingCardMaster(_selectedHStaffMasterVo.StaffCode);
            if (_selectedHToukanpoTrainingCardVo.StaffCode > 0) {
                ToolStripStatusLabelDetail.Text = "登録されています";
                // Controlに値をセット
                HComboBoxExCompany.Text = _selectedHToukanpoTrainingCardVo.CompanyName;
                HDateTimePickerExCertificationDate.SetValue(_selectedHToukanpoTrainingCardVo.CertificationDate.Date);
                if (_selectedHToukanpoTrainingCardVo.Picture.Length != 0) {
                    PictureBoxCard.Image = (Image)new ImageConverter().ConvertFrom(_selectedHToukanpoTrainingCardVo.Picture);
                } else {
                    PictureBoxCard.Image = null;
                }
            } else {
                ToolStripStatusLabelDetail.Text = "登録されていません";
                // Controlに値をセット
                HComboBoxExCompany.SelectedIndex = -1;
                //ComboBoxSelectName.Text = "";
                HDateTimePickerExCertificationDate.SetValue(DateTime.Now.Date);
                PictureBoxCard.Image = null;
            }
        }

        /// <summary>
        /// HButtonExClip_Click
        /// クリップボードのデータを利用する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExClip_Click(object sender, EventArgs e) {
            /*
             * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
             */
            PictureBoxCard.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
        }

        /// <summary>
        /// PictureBoxCardをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExDelete_Click(object sender, EventArgs e) {
            PictureBoxCard.Image = null;
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
        /// H_ToukanpoTrainingCardDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_ToukanpoTrainingCardDetail_FormClosing(object sender, FormClosingEventArgs e) {
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
