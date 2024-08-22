/*
 * 2024-04-07
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_License {
    public partial class HLicenseDetail : Form {
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_LicenseMasterDao _hLicenseMasterDao;

        /// <summary>
        /// コンストラクター(新規)
        /// </summary>
        /// <param name="connectionVo"></param>
        public HLicenseDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hLicenseMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeHComboBoxExSelectName();
        }

        /// <summary>
        /// コンストラクター(修正)
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="licenseNumber"></param>
        public HLicenseDetail(ConnectionVo connectionVo, int staffCode) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hLicenseMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.PutControl(_hLicenseMasterDao.SelectOneHLicenseMaster(staffCode));
        }

        /// <summary>
        /// HButtonEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonEx_Click(object sender, EventArgs e) {
            switch (((H_ButtonEx)sender).Name) {
                case "HButtonExUpdate":
                    DialogResult dialogResult = MessageBox.Show("データを更新します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.OK:
                            /*
                             * StaffMasterVoに値をセット
                             */
                            H_LicenseMasterVo hLicenseMasterVo = SetHLicenseMasterVo();
                            /*
                             * DBを変更(DBにstaff_codeが存在すればUPDATE、無ければINSERT)
                             */
                            if (_hLicenseMasterDao.ExistenceHLicenseMaster(hLicenseMasterVo.StaffCode)) {
                                try {
                                    _hLicenseMasterDao.UpdateOneHLicenseLedger(hLicenseMasterVo);
                                    this.Close();
                                } catch (Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                            } else {
                                try {
                                    _hLicenseMasterDao.InsertOneHLicenseMaster(hLicenseMasterVo);
                                    this.Close();
                                } catch (Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                            }
                            Close();
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
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
        /// SetHLicenseMasterVo
        /// </summary>
        /// <returns></returns>
        private H_LicenseMasterVo SetHLicenseMasterVo() {
            H_LicenseMasterVo hLicenseMasterVo = new();
            hLicenseMasterVo.StaffCode = int.Parse(HTextBoxExStaffCode.Text); // 社員コード
            hLicenseMasterVo.NameKana = HTextBoxExNameKana.Text; // フリガナ
            hLicenseMasterVo.Name = HTextBoxExName.Text; // 氏名
            hLicenseMasterVo.BirthDate = HDateTimePickerExBirthDate.GetValue(); // 生年月日
            hLicenseMasterVo.CurrentAddress = HTextBoxExCurrentAddress.Text; // 住所
            hLicenseMasterVo.DeliveryDate = HDateTimePickerExDeliveryDate.GetValue(); // 交付
            hLicenseMasterVo.ExpirationDate = HDateTimePickerExExpirationDate.GetValue(); // 有効期限
            hLicenseMasterVo.LicenseCondition = HComboBoxExLicenseCondition.Text; // 条件等
            hLicenseMasterVo.LicenseNumber = HTextBoxExLicenseNumber.Text; // 番号
            hLicenseMasterVo.GetDate1 = HDateTimePickerExGetDate1.GetValue(); // 二・小・原
            hLicenseMasterVo.GetDate2 = HDateTimePickerExGetDate2.GetValue(); // 他
            hLicenseMasterVo.GetDate3 = HDateTimePickerExGetDate3.GetValue(); // 二種
            hLicenseMasterVo.Large = HCheckBoxExLarge.Checked; //
            hLicenseMasterVo.Medium = HCheckBoxExMedium.Checked; //
            hLicenseMasterVo.QuasiMedium = HCheckBoxExQuasiMedium.Checked; //
            hLicenseMasterVo.Ordinary = HCheckBoxExOrdinary.Checked; //
            hLicenseMasterVo.BigSpecial = HCheckBoxExBigSpecial.Checked; //
            hLicenseMasterVo.BigAutoBike = HCheckBoxExBigAutoBike.Checked; //
            hLicenseMasterVo.OrdinaryAutoBike = HCheckBoxExOrdinaryAutoBike.Checked; //
            hLicenseMasterVo.SmallSpecial = HCheckBoxExSmallSpecial.Checked; //
            hLicenseMasterVo.WithARaw = HCheckBoxExWithARaw.Checked; //
            hLicenseMasterVo.BigTwo = HCheckBoxExBigTwo.Checked; //
            hLicenseMasterVo.MediumTwo = HCheckBoxExMediumTwo.Checked; //
            hLicenseMasterVo.OrdinaryTwo = HCheckBoxExOrdinaryTwo.Checked; //
            hLicenseMasterVo.BigSpecialTwo = HCheckBoxExBigSpecialTwo.Checked; //
            hLicenseMasterVo.Traction = HCheckBoxExTraction.Checked; //
            hLicenseMasterVo.PictureHead = (byte[])new ImageConverter().ConvertTo(HPictureBoxExPictureHead.Image, typeof(byte[])); //
            hLicenseMasterVo.PictureTail = (byte[])new ImageConverter().ConvertTo(HPictureBoxExPictureTail.Image, typeof(byte[])); //
            return hLicenseMasterVo;
        }

        /// <summary>
        /// PutControl
        /// </summary>
        /// <param name="hLicenseMasterVo"></param>
        private void PutControl(H_LicenseMasterVo hLicenseMasterVo) {
            HTextBoxExStaffCode.Text = hLicenseMasterVo.StaffCode.ToString("#####"); // 社員コード
            HTextBoxExNameKana.Text = hLicenseMasterVo.NameKana; // フリガナ
            HTextBoxExName.Text = hLicenseMasterVo.Name; // 氏名
            HDateTimePickerExBirthDate.SetValueJp(hLicenseMasterVo.BirthDate.Date); // 生年月日
            HTextBoxExCurrentAddress.Text = hLicenseMasterVo.CurrentAddress; // 住所
            HDateTimePickerExDeliveryDate.SetValueJp(hLicenseMasterVo.DeliveryDate.Date); // 交付
            HDateTimePickerExExpirationDate.SetValueJp(hLicenseMasterVo.ExpirationDate.Date); // 有効期限
            HComboBoxExLicenseCondition.Text = hLicenseMasterVo.LicenseCondition; // 条件等
            HTextBoxExLicenseNumber.Text = hLicenseMasterVo.LicenseNumber; // 番号
            HDateTimePickerExGetDate1.SetValueJp(hLicenseMasterVo.GetDate1.Date); // 二・小・原
            HDateTimePickerExGetDate2.SetValueJp(hLicenseMasterVo.GetDate2.Date); // 他
            HDateTimePickerExGetDate3.SetValueJp(hLicenseMasterVo.GetDate3.Date); // 二種
            HCheckBoxExLarge.Checked = hLicenseMasterVo.Large; //
            HCheckBoxExMedium.Checked = hLicenseMasterVo.Medium; //
            HCheckBoxExQuasiMedium.Checked = hLicenseMasterVo.QuasiMedium; //
            HCheckBoxExOrdinary.Checked = hLicenseMasterVo.Ordinary; //
            HCheckBoxExBigSpecial.Checked = hLicenseMasterVo.BigSpecial; //
            HCheckBoxExBigAutoBike.Checked = hLicenseMasterVo.BigAutoBike; //
            HCheckBoxExOrdinaryAutoBike.Checked = hLicenseMasterVo.OrdinaryAutoBike; //
            HCheckBoxExSmallSpecial.Checked = hLicenseMasterVo.SmallSpecial; //
            HCheckBoxExWithARaw.Checked = hLicenseMasterVo.WithARaw; //
            HCheckBoxExBigTwo.Checked = hLicenseMasterVo.BigTwo; //
            HCheckBoxExMediumTwo.Checked = hLicenseMasterVo.MediumTwo; //
            HCheckBoxExOrdinaryTwo.Checked = hLicenseMasterVo.OrdinaryTwo; //
            HCheckBoxExBigSpecialTwo.Checked = hLicenseMasterVo.BigSpecialTwo; //
            HCheckBoxExTraction.Checked = hLicenseMasterVo.Traction; //
            if (hLicenseMasterVo.PictureHead.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxExPictureHead.Image = (Image)imageConv.ConvertFrom(hLicenseMasterVo.PictureHead); //写真表
            }
            if (hLicenseMasterVo.PictureTail.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxExPictureTail.Image = (Image)imageConv.ConvertFrom(hLicenseMasterVo.PictureTail); //写真裏
            }
        }

        /// <summary>
        /// HComboBoxExSelectNameを初期化
        /// </summary>
        private void InitializeHComboBoxExSelectName() {
            HComboBoxExSelectName.Items.Clear();
            List<HComboBoxExSelectNameVo> listComboBoxSelectNameVo = new();
            foreach (H_StaffMasterVo hStaffMasterVo in _hStaffMasterDao.SelectAllHStaffMaster().OrderBy(x => x.NameKana))
                HComboBoxExSelectName.Items.Add(new HComboBoxExSelectNameVo(hStaffMasterVo.Name, hStaffMasterVo));
            HComboBoxExSelectName.DisplayMember = "Name";
            // ここでイベント追加しないと初期化で発火しちゃうよ
            HComboBoxExSelectName.SelectedIndexChanged += new EventHandler(HComboBoxExSelectName_SelectedIndexChanged);
        }

        /// <summary>
        /// HComboBoxExSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HComboBoxExSelectName_SelectedIndexChanged(object sender, EventArgs e) {
            H_StaffMasterVo hStaffMasterVo = ((HComboBoxExSelectNameVo)((H_ComboBoxEx)sender).SelectedItem).HStaffMasterVo;
            /*
             * StaffLedgerVoの値をControlにセットする
             */
            HTextBoxExStaffCode.Text = hStaffMasterVo.StaffCode.ToString();
            HTextBoxExNameKana.Text = hStaffMasterVo.NameKana;
            HTextBoxExName.Text = hStaffMasterVo.Name;
            HDateTimePickerExBirthDate.SetValueJp(hStaffMasterVo.BirthDate);
            HTextBoxExCurrentAddress.Text = hStaffMasterVo.CurrentAddress;
        }

        /// <summary>
        /// インナークラス
        /// </summary>
        private class HComboBoxExSelectNameVo {
            private string _name;
            private H_StaffMasterVo _hStaffMasterVo;

            // プロパティをコンストラクタでセット
            public HComboBoxExSelectNameVo(string name, H_StaffMasterVo hStaffMasterVo) {
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
        /// HLicenseDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HLicenseDetail_FormClosing(object sender, FormClosingEventArgs e) {
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
