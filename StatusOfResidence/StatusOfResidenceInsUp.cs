/*
 * 2023-06-24
 */
using Common;

using ControlEx;

using Dao;

using Vo;

namespace StatusOfResidence {
    public partial class StatusOfResidenceInsUp : Form {
        // 新規・修正・削除を判別するためのフラグ
        private string _switch = string.Empty;

        private OpenFileDialog openFileDialog = new();
        private DateTime _defaultDateTime = new DateTime(1900,01,01);
        /*
         * Dao
         */
        private readonly StaffMasterDao _staffMasterDao;
        private readonly StatusOfResidenceDao _statusOfResidenceDao;

        /*
         * Vo
         */
        private readonly ConnectionVo _conectionVo;
        private StatusOfResidenceVo? _statusOfResidenceVo;

        /// <summary>
        /// コンストラクター(新規)
        /// </summary>
        /// <param name="connectionVo"></param>
        public StatusOfResidenceInsUp(ConnectionVo connectionVo) {
            // 呼び出し元を設定する
            _switch = "INSERT";

            /*
             * Dao
             */
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _statusOfResidenceDao = new StatusOfResidenceDao(connectionVo);

            /*
             * Vo
             */
            _conectionVo = connectionVo;
            _statusOfResidenceVo = null;

            InitializeComponent();
            InitializeControlInsert();

            // ToolStripMenuItemEditを無効にする
            ToolStripMenuItemEdit.Enabled = false;
            /*
             * ComboBoxExSerchStaffを初期化する
             */
            ComboBoxExSerchStaff.Enabled = true;
            InitializeComboBoxExSerchStaff();

            this.Text = "StatusOfResidenceInsert";
        }

        /// <summary>
        /// コンストラクター(修正)
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="statusOfResidenceListVo"></param>
        public StatusOfResidenceInsUp(ConnectionVo connectionVo, StatusOfResidenceVo statusOfResidenceVo) {
            // 呼び出し元を設定する
            _switch = "UPDATE";

            /*
             * Dao
             */
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _statusOfResidenceDao = new StatusOfResidenceDao(connectionVo);

            /*
             * Vo
             */
            _conectionVo = connectionVo;
            _statusOfResidenceVo = statusOfResidenceVo;

            InitializeComponent();
            InitializeControlUpdate(statusOfResidenceVo);

            // ToolStripMenuItemEditを有効にする
            ToolStripMenuItemEdit.Enabled = true;
            /*
             * ComboBoxExSerchStaffを初期化する
             */
            ComboBoxExSerchStaff.Enabled = false;

            this.Text = "StatusOfResidenceUpdate";
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            /*
             * 入力のチェック
             */
            if(TextBoxStaffCode.Text.Length == 0) {
                MessageBox.Show("従事者が選択されていません。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*
             * 値をセット
             */
            StatusOfResidenceVo statusOfResidenceVo = new StatusOfResidenceVo();
            statusOfResidenceVo.Staff_code = int.Parse(TextBoxStaffCode.Text);
            statusOfResidenceVo.Staff_name = TextBoxStaffName.Text;
            statusOfResidenceVo.Staff_name_kana = TextBoxStaffNameKana.Text;
            statusOfResidenceVo.Birth_date = DateTimePickerExBirthDay.Value.Date;
            statusOfResidenceVo.Gender = ComboBoxExGender.Text;
            statusOfResidenceVo.Nationality = ComboBoxExNationarity.Text;
            statusOfResidenceVo.Address = TextBoxExAddress.Text;
            statusOfResidenceVo.Status_of_residence = ComboBoxExStatusOfResidence.Text;
            statusOfResidenceVo.Work_limit = ComboBoxExWorkLimit.Text;
            statusOfResidenceVo.Period_date = DateTimePickerExPeriodDate.GetValue();
            statusOfResidenceVo.Deadline_date = DateTimePickerExDeadlineDate.GetValue();
            statusOfResidenceVo.Picture_head = (byte[]?)new ImageConverter().ConvertTo(PictureBoxHead.Image, typeof(byte[]));
            statusOfResidenceVo.Picture_tail = (byte[]?)new ImageConverter().ConvertTo(PictureBoxTail.Image, typeof(byte[]));
            statusOfResidenceVo.Insert_ymd_hms = DateTime.Now;
            statusOfResidenceVo.Update_ymd_hms = _defaultDateTime;
            statusOfResidenceVo.Delete_ymd_hms = _defaultDateTime;
            statusOfResidenceVo.Delete_flag = false;
            /*
             * Dao処理
             */
            DialogResult dialogResult;
            try {
                switch(_switch) {
                    case "INSERT":
                        dialogResult = MessageBox.Show("この情報で新規登録してもよろしいですか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        switch(dialogResult) {
                            case DialogResult.OK:
                                _statusOfResidenceDao.InsertOneStatusOfResidenceMaster(statusOfResidenceVo);
                                this.Close();
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                        break;
                    case "UPDATE":
                        dialogResult = MessageBox.Show("この情報で修正登録してもよろしいですか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        switch(dialogResult) {
                            case DialogResult.OK:
                                _statusOfResidenceDao.UpdateOneStatusOfResidenceMaster(statusOfResidenceVo);
                                this.Close();
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                        break;
                }
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// ToolStripMenuItemDelete_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e) {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("この情報を削除してもよろしいですか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    //_statusOfResidenceDao.UpdateOneStatusOfResidenceMaster(statusOfResidenceVo);
                    this.Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e) {
            switch(((Button)sender).Name) {
                case "ButtonSelectPictureHead":
                    openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    openFileDialog.Title = "写真を選択して下さい"; // ダイアログのタイトルを指定する
                    openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.tif;*.TIF;*.png;*.PNG;";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true; // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                    if(openFileDialog.ShowDialog() == DialogResult.OK)
                        // Passをセットする
                        PictureBoxHead.ImageLocation = openFileDialog.FileName;
                    openFileDialog.Dispose(); // オブジェクトを破棄する
                    break;
                case "ButtonClipPictureHead":
                    /*
                     * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
                     */
                    PictureBoxHead.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                case "ButtonDeletePictureHead":
                    PictureBoxHead.Image = null;
                    break;
                case "ButtonSelectPictureTail":
                    openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    openFileDialog.Title = "写真を選択して下さい"; // ダイアログのタイトルを指定する
                    openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.tif;*.TIF;*.png;*.PNG;";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true; // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                    if(openFileDialog.ShowDialog() == DialogResult.OK)
                        // Passをセットする
                        PictureBoxTail.ImageLocation = openFileDialog.FileName;
                    openFileDialog.Dispose(); // オブジェクトを破棄する
                    break;
                case "ButtonClipPictureTail":
                    /*
                     * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
                     */
                    PictureBoxTail.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                case "ButtonDeletePictureTail":
                    PictureBoxTail.Image = null;
                    break;
            }
        }

        /// <summary>
        /// InitializeControlNew
        /// </summary>
        private void InitializeControlInsert() {
            //オートコンプリートモードの設定
            ComboBoxExSerchStaff.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //コンボボックスのアイテムをオートコンプリートの選択候補とする
            ComboBoxExSerchStaff.AutoCompleteSource = AutoCompleteSource.ListItems;

            TextBoxStaffCode.Text = string.Empty;
            TextBoxStaffNameMaster.Text = string.Empty;
            TextBoxStaffName.Text = string.Empty;
            TextBoxStaffNameKana.Text = string.Empty;
            DateTimePickerExBirthDay.Value = DateTime.Now.Date;
            ComboBoxExGender.Text = string.Empty;
            ComboBoxExNationarity.Text = string.Empty;
            TextBoxExAddress.Text = string.Empty;
            ComboBoxExStatusOfResidence.Text = string.Empty;
            ComboBoxExWorkLimit.Text = string.Empty;
            DateTimePickerExPeriodDate.Value = DateTime.Now.Date;
            DateTimePickerExDeadlineDate.Value = DateTime.Now.Date;
            PictureBoxHead.Image = null;
            PictureBoxTail.Image = null;
        }

        /// <summary>
        /// InitializeControlUpdate
        /// </summary>
        private void InitializeControlUpdate(StatusOfResidenceVo statusOfResidenceVo) {
            TextBoxStaffCode.Text = statusOfResidenceVo.Staff_code.ToString();
            TextBoxStaffNameMaster.Text = string.Empty;
            TextBoxStaffName.Text = statusOfResidenceVo.Staff_name;
            TextBoxStaffNameKana.Text = statusOfResidenceVo.Staff_name_kana;
            DateTimePickerExBirthDay.Value = statusOfResidenceVo.Birth_date;
            ComboBoxExGender.Text = statusOfResidenceVo.Gender;
            ComboBoxExNationarity.Text = statusOfResidenceVo.Nationality;
            TextBoxExAddress.Text = statusOfResidenceVo.Address;
            ComboBoxExStatusOfResidence.Text = statusOfResidenceVo.Status_of_residence;
            ComboBoxExWorkLimit.Text = statusOfResidenceVo.Work_limit;
            DateTimePickerExPeriodDate.Value = statusOfResidenceVo.Period_date;
            DateTimePickerExDeadlineDate.Value = statusOfResidenceVo.Deadline_date;
            if(statusOfResidenceVo.Picture_head.Length != 0)
                PictureBoxHead.Image = (Image?)new ImageConverter().ConvertFrom(statusOfResidenceVo.Picture_head);
            if(statusOfResidenceVo.Picture_tail.Length != 0)
                PictureBoxTail.Image = (Image?)new ImageConverter().ConvertFrom(statusOfResidenceVo.Picture_tail);
        }

        /// <summary>
        /// ComboBoxExSerchStaff_SelectionChangeCommitted
        /// 新規の場合のみ使う機能だよ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxExSerchStaff_SelectionChangeCommitted(object sender, EventArgs e) {
            // StaffMasterVoを取得
            StaffMasterVo staffMasterVo = ((ComboBoxSelectStaffMasterVo)((ComboBoxEx)sender).SelectedItem).StaffMasterVo;
            /*
             * 値をセット
             */
            TextBoxStaffCode.Text = staffMasterVo.Staff_code.ToString();
            TextBoxStaffNameMaster.Text = staffMasterVo.Name;
            TextBoxStaffName.Text = staffMasterVo.Name;
            TextBoxStaffNameKana.Text = staffMasterVo.Name_kana;
            DateTimePickerExBirthDay.Value = staffMasterVo.Birth_date;
            ComboBoxExGender.Text = staffMasterVo.Gender;
            TextBoxExAddress.Text = staffMasterVo.Current_address;
            DateTimePickerExPeriodDate.Value = DateTime.Now.Date;
            DateTimePickerExDeadlineDate.Value = DateTime.Now.Date;
            PictureBoxHead.Image = null;
            PictureBoxTail.Image = null;
        }

        /// <summary>
        /// InitializeComboBoxExSerchStaff
        /// </summary>
        private void InitializeComboBoxExSerchStaff() {
            ComboBoxExSerchStaff.Items.Clear();
            foreach(StaffMasterVo staffMasterVo in _staffMasterDao.SelectAllStaffMaster())
                ComboBoxExSerchStaff.Items.Add(new ComboBoxSelectStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
            ComboBoxExSerchStaff.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// ComboBoxSelectStaffMasterVo
        /// インナークラス
        /// </summary>
        private class ComboBoxSelectStaffMasterVo {
            private string _displayName;
            private StaffMasterVo _staffMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectStaffMasterVo(string displayName, StaffMasterVo staffMasterVo) {
                _displayName = displayName;
                _staffMasterVo = staffMasterVo;
            }

            public string DisplayName {
                get => _displayName;
                set => _displayName = value;
            }
            public StaffMasterVo StaffMasterVo {
                get => _staffMasterVo;
                set => _staffMasterVo = value;
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
        /// StatusOfResidenceNew_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusOfResidenceNew_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}
