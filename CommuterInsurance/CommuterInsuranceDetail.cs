/*
 * 2022/05/22
 */
using Common;

using Dao;

using H_Vo;

namespace CommuterInsurance {
    public partial class CommuterInsuranceDetail : Form {
        private readonly ConnectionVo _connectionVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        private readonly List<StaffMasterVo> _listStaffMasterVo;
        private readonly CommuterInsuranceDao _commuterInsuranceDao;

        Dictionary<int, string> dictionaryBelongsCode = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 20, "新運転" }, { 21, "自運労" } };
        Dictionary<string, int> dictionaryBelongsName = new Dictionary<string, int> { { "役員", 10 }, { "社員", 11 }, { "アルバイト", 12 }, { "新運転", 20 }, { "自運労", 21 } };

        /// <summary>
        /// ErrorProviderのインスタンスを生成
        /// </summary>
        private ErrorProvider errorProvider = new ErrorProvider();
        /// <summary>
        /// True: 新規登録モード False:修正登録モード
        /// </summary>
        private readonly bool _openFlag;

        /// <summary>
        /// 新規登録用のコンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public CommuterInsuranceDetail(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
            /*
             * 2022-06-27
             * _listStaffLedgerVoの取得の仕方を変更
             * _listStaffLedgerVo = connectionVo.ListStaffLedgerVo;
             */
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            _commuterInsuranceDao = new CommuterInsuranceDao(_connectionVo);
            _openFlag = true;
            // ComboBoxSelectNameを初期化
            InitializeComboBoxSelectName();
            // Form初期化
            InitializeForm();
            // Controlを初期化
            InitializeControl();
        }

        /// <summary>
        /// 修正登録用のコンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public CommuterInsuranceDetail(ConnectionVo connectionVo, int staffCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            /*
             * 2022-06-27
             * _listStaffLedgerVoの取得の仕方を変更
             * _listStaffLedgerVo = connectionVo.ListStaffLedgerVo;
             */
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            _commuterInsuranceDao = new CommuterInsuranceDao(_connectionVo);
            _openFlag = false;
            // ComboBoxSelectNameを初期化
            InitializeComboBoxSelectName();
            // Form初期化
            InitializeForm();
            // Controlを初期化
            InitializeControl();
            // 画面表示
            ControlOutput(_commuterInsuranceDao.SelectOneCommuterInsurance(staffCode));
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// レコードを更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // 入力項目をチェックする
            if(TextBoxStaffCode.Text.Length < 1) {
                errorProvider.SetError(TextBoxStaffCode, "登録する従事者を選択して下さい");
                return; // メソッドを出る
            } else {
                // ErrorProviderをクリアします。
                errorProvider.Clear();
            }

            var dialogResult = MessageBox.Show(MessageText.Message901, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    // StaffLedgerVoに値をセット
                    var commuterInsuranceVo = SetCommuterInsuranceVo();
                    // DBを変更(DBにstaff_codeが存在すればUPDATE、無ければINSERT)
                    if(_commuterInsuranceDao.CheckCommuterInsurance(commuterInsuranceVo.Staff_code)) {
                        try {
                            _commuterInsuranceDao.UpdateOneCommuterInsurance(commuterInsuranceVo);
                        } catch(Exception exception) {
                            MessageBox.Show(exception.ToString());
                        }
                    } else {
                        try {
                            _commuterInsuranceDao.InsertOneCommuterInsurance(commuterInsuranceVo);
                        } catch(Exception exception) {
                            MessageBox.Show(exception.ToString());
                        }
                    }
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// ControlOutput
        /// 画面へ表示
        /// </summary>
        /// <param name="commuterInsuranceVo"></param>
        private void ControlOutput(CommuterInsuranceVo commuterInsuranceVo) {
            GroupBoxSelectName.Enabled = false; // 修正登録モードで開かれているからFalseにしてね
            TextBoxBelongs.Text = dictionaryBelongsCode[commuterInsuranceVo.Belongs];
            TextBoxStaffCode.Text = commuterInsuranceVo.Staff_code.ToString(); // 社員コード
            TextBoxNameKana.Text = commuterInsuranceVo.Name_kana; // フリガナ
            TextBoxName.Text = commuterInsuranceVo.Name; // 氏名
            ComboBoxMeansOfCommuting.Text = commuterInsuranceVo.CommuterInsurance; //通勤手段
            if(commuterInsuranceVo.Notification) { // 会社への提出
                RadioButtonNotificationTrue.Checked = true;
            } else {
                RadioButtonNotificationFalse.Checked = true;
            }
            ComboBoxInsuranceCompanyName.Text = commuterInsuranceVo.InsuranceCompanyName;
            CheckBoxPayment.Checked = commuterInsuranceVo.Payment; // 携帯決済(自転車)
            TextBoxCarNumber.Text = commuterInsuranceVo.CarNumber;
            DateTimePickerStartDate.Value = commuterInsuranceVo.StartDate;
            DateTimePickerEndDate.Value = commuterInsuranceVo.EndDate;
            TextBoxNote.Text = commuterInsuranceVo.Note;
            if(commuterInsuranceVo.PictureHead is not null && commuterInsuranceVo.PictureHead.Length != 0) {
                ImageConverter imageConv = new ImageConverter();
                PictureBoxHead.Image = (Image?)imageConv.ConvertFrom(commuterInsuranceVo.PictureHead); //写真表
            }
            if(commuterInsuranceVo.PictureTail is not null && commuterInsuranceVo.PictureTail.Length != 0) {
                ImageConverter imageConv = new ImageConverter();
                PictureBoxTail.Image = (Image?)imageConv.ConvertFrom(commuterInsuranceVo.PictureTail); //写真裏
            }
        }

        /// <summary>
        /// SetMeansOfCommutingVo
        /// Voに値をセットする
        /// </summary>
        /// <returns></returns>
        private CommuterInsuranceVo SetCommuterInsuranceVo() {
            var commuterInsuranceVo = new CommuterInsuranceVo();
            commuterInsuranceVo.Belongs = dictionaryBelongsName[TextBoxBelongs.Text]; // 
            commuterInsuranceVo.Staff_code = int.Parse(TextBoxStaffCode.Text); // 社員コード
            commuterInsuranceVo.Name_kana = TextBoxNameKana.Text; // フリガナ
            commuterInsuranceVo.Name = TextBoxName.Text; // 氏名
            commuterInsuranceVo.CommuterInsurance = ComboBoxMeansOfCommuting.Text; // 通勤手段
            commuterInsuranceVo.Notification = RadioButtonNotificationTrue.Checked;
            commuterInsuranceVo.InsuranceCompanyName = ComboBoxInsuranceCompanyName.Text;
            commuterInsuranceVo.Payment = CheckBoxPayment.Checked; // 携帯決済(自転車)
            commuterInsuranceVo.CarNumber = TextBoxCarNumber.Text;
            commuterInsuranceVo.StartDate = GetDateTimePickerValue(DateTimePickerStartDate);
            commuterInsuranceVo.EndDate = GetDateTimePickerValue(DateTimePickerEndDate);
            commuterInsuranceVo.Note = TextBoxNote.Text;
            commuterInsuranceVo.PictureHead = (byte[]?)new ImageConverter().ConvertTo(PictureBoxHead.Image, typeof(byte[])); //
            commuterInsuranceVo.PictureTail = (byte[]?)new ImageConverter().ConvertTo(PictureBoxTail.Image, typeof(byte[])); //
            return commuterInsuranceVo;
        }

        /// <summary>
        /// SetDateTimePicker
        /// </summary>
        /// <param name="dateTimePicker"></param>
        /// <param name="datetime"></param>
        private void SetDateTimePicker(DateTimePicker dateTimePicker, DateTime? datetime) {
            if(datetime == null || datetime == _defaultDateTime) {
                // DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = " ";
            } else {
                // フォーマットを元に戻して、値をセットする。
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "yyyy年MM月dd日(ddd)";
                dateTimePicker.Value = (DateTime)datetime;
            }
        }

        /// <summary>
        /// GetDateTimePickerValue
        /// </summary>
        /// <param name="dateTimePicker"></param>
        /// <returns></returns>
        private DateTime GetDateTimePickerValue(DateTimePicker dateTimePicker) {
            DateTime dateTime;
            if(dateTimePicker.Text != " ") {
                dateTime = dateTimePicker.Value.Date;
            } else {
                dateTime = _defaultDateTime;
            }
            return dateTime;
        }

        /// <summary>
        /// DateTimePicker_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyData == Keys.Delete) {
                //Deleteキーが押されたら、dateTimeにnullを設定してdateTimePicker1を非表示に
                SetDateTimePicker((DateTimePicker)sender, null);
            }
        }

        /// <summary>
        /// DateTimePicker_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e) {
            //dateTimePicker1の値が変更されたら表示する
            var dateTime = ((DateTimePicker)sender).Value;
            SetDateTimePicker((DateTimePicker)sender, dateTime);
        }

        /// <summary>
        /// ComboBoxSelectNameにデータをセットする
        /// </summary>
        private void InitializeComboBoxSelectName() {
            ComboBoxSelectName.Items.Clear();
            var listComboBoxSelectNameVo = new List<ComboBoxSelectNameVo>();
            foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false))
                ComboBoxSelectName.Items.Add(new ComboBoxSelectNameVo(staffMasterVo.Name, staffMasterVo));
            ComboBoxSelectName.DisplayMember = "Name";
            // ここでイベント追加しないと初期化で発火しちゃうよ
            ComboBoxSelectName.SelectedIndexChanged += new EventHandler(ComboBoxSelectName_SelectedIndexChanged);
        }

        /// <summary>
        /// ComboBoxSelectNameVo
        /// インナークラス
        /// </summary>
        private class ComboBoxSelectNameVo {
            private string _name;
            private StaffMasterVo _staffMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectNameVo(string name, StaffMasterVo staffMasterVo) {
                _name = name;
                _staffMasterVo = staffMasterVo;
            }
            public string Name {
                get => _name;
                set => _name = value;
            }
            public StaffMasterVo StaffMasterVo {
                get => _staffMasterVo;
                set => _staffMasterVo = value;
            }
        }

        /// <summary>
        /// InitializeForm
        /// </summary>
        private void InitializeForm() {
            GroupBoxSelectName.Enabled = _openFlag; //
            ToolStripStatusLabelDetail.Text = "";
        }

        /// <summary>
        /// InitializeControl
        /// </summary>
        private void InitializeControl() {
            GroupBoxSelectName.Enabled = _openFlag; //
            TextBoxBelongs.Text = string.Empty;
            TextBoxStaffCode.Text = string.Empty; // 社員コード
            TextBoxNameKana.Text = string.Empty; // フリガナ
            TextBoxName.Text = string.Empty; // 氏名
            ComboBoxMeansOfCommuting.Text = string.Empty; //通勤手段
            RadioButtonNotificationTrue.Checked = true;
            ComboBoxInsuranceCompanyName.Text = string.Empty;
            CheckBoxPayment.Checked = false; // 携帯決済(自転車)
            TextBoxCarNumber.Text = string.Empty;
            SetDateTimePicker(DateTimePickerStartDate, null);
            SetDateTimePicker(DateTimePickerEndDate, null);
            TextBoxNote.Text = string.Empty;
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
        /// PictureBoxを別ウインドウで表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DoubleClick(object sender, EventArgs e) {
            var commuterInsurancePicture = new CommuterInsurancePicture(((PictureBox)sender).Image);
            commuterInsurancePicture.ShowDialog(this);
        }

        /// <summary>
        /// ComboBoxSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectName_SelectedIndexChanged(object? sender, EventArgs e) {
            // Nullチェック
            if(sender is null)
                return;
            var staffMasterVo = ((ComboBoxSelectNameVo)((ComboBox)sender).SelectedItem).StaffMasterVo;
            // StaffLedgerVoの値をControlにセットする
            TextBoxBelongs.Text = dictionaryBelongsCode[staffMasterVo.Belongs];
            TextBoxStaffCode.Text = staffMasterVo.Staff_code.ToString();
            TextBoxNameKana.Text = staffMasterVo.Name_kana;
            TextBoxName.Text = staffMasterVo.Name;

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
        /// CommuterInsuranceDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommuterInsuranceDetail_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}

