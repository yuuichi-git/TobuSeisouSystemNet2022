using System.Drawing.Printing;

using Common;

using Dao;

using Vo;

namespace License {
    public partial class LicenseDetail : Form {
        private readonly ConnectionVo _connectionVo;

        private readonly LicenseMasterDao _licenseMasterDao;
        private readonly List<StaffMasterVo> _listStaffMasterVo;

        /// <summary>
        /// True: 新規登録モード False:修正登録モード
        /// </summary>
        private readonly bool _openFlag;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        /// <summary>
        /// 新規登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public LicenseDetail(ConnectionVo connectionVo, List<StaffMasterVo> listStaffMasterVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _listStaffMasterVo = listStaffMasterVo;
            _licenseMasterDao = new LicenseMasterDao(_connectionVo);
            _openFlag = true;
            // ComboBoxSelectNameを初期化
            InitializeComboBoxSelectName();
            // Controlを初期化
            InitializeControl();
        }

        /// <summary>
        /// 修正登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public LicenseDetail(ConnectionVo connectionVo, int staffCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _listStaffMasterVo = new();
            _licenseMasterDao = new LicenseMasterDao(_connectionVo);
            _openFlag = false;
            // Controlを初期化
            InitializeControl();
            ControlOutPut(_licenseMasterDao.SelectOneLicenseMaster(staffCode));
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message601, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    /*
                     * StaffMasterVoに値をセット
                     */
                    var licenseMasterVo = SetLicenseMasterVo();
                    /*
                     * DBを変更(DBにstaff_codeが存在すればUPDATE、無ければINSERT)
                     */
                    if(_licenseMasterDao.CheckLicenseMaster(licenseMasterVo.Staff_code)) {
                        _licenseMasterDao.UpdateOneLicenseLedger(licenseMasterVo);
                    } else {
                        _licenseMasterDao.InsertOneLicenseMaster(licenseMasterVo);
                    }
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// SetLicenseMasterVo
        /// VoにControl値を代入
        /// </summary>
        /// <returns></returns>
        private LicenseMasterVo SetLicenseMasterVo() {
            var licenseMasterVo = new LicenseMasterVo();
            licenseMasterVo.Staff_code = int.Parse(TextBoxStaffCode.Text); // 社員コード
            licenseMasterVo.Name_kana = TextBoxNameKana.Text; // フリガナ
            licenseMasterVo.Name = TextBoxName.Text; // 氏名
            licenseMasterVo.Birth_date = DateBirthDate.GetValue(); // 生年月日
            licenseMasterVo.Current_address = TextBoxCurrentAddress.Text; // 住所
            licenseMasterVo.Delivery_date = DateTimePickerJpEx1.Value; // 交付
            licenseMasterVo.Expiration_date = DateExpirationDate.Value; // 有効期限
            licenseMasterVo.License_condition = ComboBoxLicenseCondition.Text; // 条件等
            licenseMasterVo.License_number = TextBoxLicenseNumber.Text; // 番号
            licenseMasterVo.Get_date_1 = DateTimePickerGetDate1.GetValue(); // 二・小・原
            licenseMasterVo.Get_date_2 = DateTimePickerGetDate2.GetValue(); // 他
            licenseMasterVo.Get_date_3 = DateTimePickerGetDate3.GetValue(); // 二種
            licenseMasterVo.Large = CheckBoxLarge.Checked; //
            licenseMasterVo.Medium = CheckBoxMedium.Checked; //
            licenseMasterVo.Quasi_medium = CheckBoxQuasiMedium.Checked; //
            licenseMasterVo.Ordinary = CheckBoxOrdinary.Checked; //
            licenseMasterVo.Big_special = CheckBoxBigSpecial.Checked; //
            licenseMasterVo.Big_auto_bike = CheckBoxBigAutoBike.Checked; //
            licenseMasterVo.Ordinary_auto_bike = CheckBoxOrdinaryAutoBike.Checked; //
            licenseMasterVo.Small_special = CheckBoxSmallSpecial.Checked; //
            licenseMasterVo.With_a_raw = CheckBoxWithARaw.Checked; //
            licenseMasterVo.Big_two = CheckBoxBigTwo.Checked; //
            licenseMasterVo.Medium_two = CheckBoxMediumTwo.Checked; //
            licenseMasterVo.Ordinary_two = CheckBoxOrdinaryTwo.Checked; //
            licenseMasterVo.Big_special_two = CheckBoxBigSpecialTwo.Checked; //
            licenseMasterVo.Traction = CheckBoxTraction.Checked; //
            licenseMasterVo.Picture_head = (byte[]?)new ImageConverter().ConvertTo(PictureBoxHead.Image, typeof(byte[])); //
            licenseMasterVo.Picture_tail = (byte[]?)new ImageConverter().ConvertTo(PictureBoxTail.Image, typeof(byte[])); //
            return licenseMasterVo;
        }

        /// <summary>
        /// ControlOutPut
        /// </summary>
        /// <param name="licenseMasterVo"></param>
        private void ControlOutPut(LicenseMasterVo licenseMasterVo) {
            TextBoxStaffCode.Text = licenseMasterVo.Staff_code.ToString(); // 社員コード
            TextBoxNameKana.Text = licenseMasterVo.Name_kana; // フリガナ
            TextBoxName.Text = licenseMasterVo.Name; // 氏名
            DateBirthDate.SetValue(licenseMasterVo.Birth_date.Date); // 生年月日
            TextBoxCurrentAddress.Text = licenseMasterVo.Current_address; // 住所
            DateTimePickerJpEx1.Value = licenseMasterVo.Delivery_date.Date; // 交付
            DateExpirationDate.Value = licenseMasterVo.Expiration_date.Date; // 有効期限
            ComboBoxLicenseCondition.Text = licenseMasterVo.License_condition; // 条件等
            TextBoxLicenseNumber.Text = licenseMasterVo.License_number; // 番号
            DateTimePickerGetDate1.SetValue(licenseMasterVo.Get_date_1.Date); // 二・小・原
            DateTimePickerGetDate2.SetValue(licenseMasterVo.Get_date_2.Date); // 他
            DateTimePickerGetDate3.SetValue(licenseMasterVo.Get_date_3.Date); // 二種
            CheckBoxLarge.Checked = licenseMasterVo.Large; //
            CheckBoxMedium.Checked = licenseMasterVo.Medium; //
            CheckBoxQuasiMedium.Checked = licenseMasterVo.Quasi_medium; //
            CheckBoxOrdinary.Checked = licenseMasterVo.Ordinary; //
            CheckBoxBigSpecial.Checked = licenseMasterVo.Big_special; //
            CheckBoxBigAutoBike.Checked = licenseMasterVo.Big_auto_bike; //
            CheckBoxOrdinaryAutoBike.Checked = licenseMasterVo.Ordinary_auto_bike; //
            CheckBoxSmallSpecial.Checked = licenseMasterVo.Small_special; //
            CheckBoxWithARaw.Checked = licenseMasterVo.With_a_raw; //
            CheckBoxBigTwo.Checked = licenseMasterVo.Big_two; //
            CheckBoxMediumTwo.Checked = licenseMasterVo.Medium_two; //
            CheckBoxOrdinaryTwo.Checked = licenseMasterVo.Ordinary_two; //
            CheckBoxBigSpecialTwo.Checked = licenseMasterVo.Big_special_two; //
            CheckBoxTraction.Checked = licenseMasterVo.Traction; //
            if(licenseMasterVo.Picture_head.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBoxHead.Image = (Image?)imageConv.ConvertFrom(licenseMasterVo.Picture_head); //写真表
            }
            if(licenseMasterVo.Picture_tail.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBoxTail.Image = (Image?)imageConv.ConvertFrom(licenseMasterVo.Picture_tail); //写真裏
            }
        }

        private void InitializeComboBoxSelectName() {
            ComboBoxSelectName.Items.Clear();
            var listComboBoxSelectNameVo = new List<ComboBoxSelectNameVo>();
            foreach(var staffLedgerVo in _listStaffMasterVo)
                ComboBoxSelectName.Items.Add(new ComboBoxSelectNameVo(staffLedgerVo.Name, staffLedgerVo));
            ComboBoxSelectName.DisplayMember = "Name";
            // ここでイベント追加しないと初期化で発火しちゃうよ
            ComboBoxSelectName.SelectedIndexChanged += new EventHandler(ComboBoxSelectName_SelectedIndexChanged);
        }

        /// <summary>
        /// インナークラス
        /// </summary>
        private class ComboBoxSelectNameVo {
            private string? _name;
            private StaffMasterVo? _staffMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectNameVo(string name, StaffMasterVo staffMasterVo) {
                _name = name;
                _staffMasterVo = staffMasterVo;
            }

            public string? Name {
                get => _name;
                set => _name = value;
            }
            public StaffMasterVo? StaffMasterVo {
                get => _staffMasterVo;
                set => _staffMasterVo = value;
            }
        }

        /// <summary>
        /// ComboBoxSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectName_SelectedIndexChanged(object sender, EventArgs e) {
            var staffMasterVo = ((ComboBoxSelectNameVo)((ComboBox)sender).SelectedItem).StaffMasterVo;
            // StaffLedgerVoの値をControlにセットする
            TextBoxStaffCode.Text = staffMasterVo.Staff_code.ToString();
            TextBoxNameKana.Text = staffMasterVo.Name_kana;
            TextBoxName.Text = staffMasterVo.Name;

        }

        /// <summary>
        /// InitializeControl
        /// </summary>
        private void InitializeControl() {
            GroupBoxSelectName.Enabled = _openFlag; //
            TextBoxStaffCode.Text = ""; // 社員コード
            TextBoxNameKana.Text = ""; // フリガナ
            TextBoxName.Text = ""; // 氏名
            DateBirthDate.SetBlank(); // 生年月日
            TextBoxCurrentAddress.Text = ""; // 住所
            //DateTimePickerJpEx1.Value =  // 交付
            //DateExpirationDate.Value = ; // 有効期限
            ComboBoxLicenseCondition.Text = ""; // 条件等
            TextBoxLicenseNumber.Text = ""; // 番号
            DateTimePickerGetDate1.SetBlank(); // 二・小・原
            DateTimePickerGetDate2.SetBlank(); // 他
            DateTimePickerGetDate3.SetBlank(); // 二種
            CheckBoxLarge.Checked = false; //
            CheckBoxMedium.Checked = false; //
            CheckBoxQuasiMedium.Checked = false; //
            CheckBoxOrdinary.Checked = false; //
            CheckBoxBigSpecial.Checked = false; //
            CheckBoxBigAutoBike.Checked = false; //
            CheckBoxOrdinaryAutoBike.Checked = false; //
            CheckBoxSmallSpecial.Checked = false; //
            CheckBoxWithARaw.Checked = false; //
            CheckBoxBigTwo.Checked = false; //
            CheckBoxMediumTwo.Checked = false; //
            CheckBoxOrdinaryTwo.Checked = false; //
            CheckBoxBigSpecialTwo.Checked = false; //
            CheckBoxTraction.Checked = false; //
            PictureBoxHead.Image = null; // 写真表
            PictureBoxTail.Image = null; // 写真裏
        }

        /// <summary>
        /// 写真選択(表裏共通)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectPicture_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Title = "写真を選択して下さい"; // ダイアログのタイトルを指定する
            openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.tif;*.TIF;*.png;*.PNG;";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            if(openFileDialog.ShowDialog() == DialogResult.OK) {
                switch((string)((Button)sender).Tag) {
                    case "PictureBoxHead":
                        PictureBoxHead.ImageLocation = openFileDialog.FileName; // Passをセットする
                        break;
                    case "PictureBoxTail":
                        PictureBoxTail.ImageLocation = openFileDialog.FileName; // Passをセットする
                        break;
                }
            }
            openFileDialog.Dispose(); // オブジェクトを破棄する
        }

        /// <summary>
        /// クリップボードからのコピー(表裏共通)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClipPicture_Click(object sender, EventArgs e) {
            // クリップボードを転送
            // なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
            switch((string)((Button)sender).Tag) {
                case "PictureBoxHead":
                    PictureBoxHead.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                case "PictureBoxTail":
                    PictureBoxTail.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
            }
        }

        /// <summary>
        /// 写真削除(表裏共通)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePicture_Click(object sender, EventArgs e) {
            switch((string)((Button)sender).Tag) {
                case "PictureBoxHead":
                    PictureBoxHead.Image = null;
                    break;
                case "PictureBoxTail":
                    PictureBoxTail.Image = null;
                    break;
            }
        }

        /// <summary>
        /// ContextMenuStrip1_Opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            var pictureBox = (PictureBox)((ContextMenuStrip)sender).SourceControl;
            if(pictureBox.Image != null) {
                ((ContextMenuStrip)sender).Enabled = true;
            } else {
                ((ContextMenuStrip)sender).Enabled = false;
            }
        }

        /// <summary>
        /// 免許証を印刷する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //PrintDocumentオブジェクトの作成
            var printDocument = new PrintDocument();
            //PrintPageイベントハンドラの追加
            printDocument.PrintPage += new PrintPageEventHandler(Pd_PrintPage);
            //印刷を開始する
            printDocument.Print();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e) {
            //画像を読み込む
            var image = PictureBoxHead.Image;
            //画像を描画する
            e.Graphics.DrawImage(image, 0, 0, 340, 216);//8.56 5.40
            //次のページがないことを通知する
            e.HasMorePages = false;
            //後始末をする
            image.Dispose();
        }

        /// <summary>
        /// アプリケーションを終了する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
