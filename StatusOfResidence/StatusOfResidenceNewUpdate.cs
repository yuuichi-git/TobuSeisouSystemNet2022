/*
 * 2023-06-24
 */
using Common;

using Dao;

using Vo;

namespace StatusOfResidence {
    public partial class StatusOfResidenceNewUpdate : Form {
        OpenFileDialog openFileDialog = new();
        /*
         * Dao
         */
        private readonly StaffMasterDao _staffMasterDao;
        private readonly StatusOfResidenceDao _statusOfResidenceDao;

        /*
         * Vo
         */
        private readonly ConnectionVo _conectionVo;
        private StatusOfResidenceListVo? _statusOfResidenceListVo;

        /// <summary>
        /// コンストラクター(新規)
        /// </summary>
        /// <param name="connectionVo"></param>
        public StatusOfResidenceNewUpdate(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _statusOfResidenceDao = new StatusOfResidenceDao(connectionVo);

            /*
             * Vo
             */
            _conectionVo = connectionVo;
            _statusOfResidenceListVo = null;

            InitializeComponent();
            InitializeControl();
            InitializeComboBoxExSerchStaff();

            this.Text = "StatusOfResidenceNew";
        }

        /// <summary>
        /// コンストラクター(修正)
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="statusOfResidenceListVo"></param>
        public StatusOfResidenceNewUpdate(ConnectionVo connectionVo, StatusOfResidenceListVo statusOfResidenceListVo) {
            /*
             * Dao
             */
            _statusOfResidenceDao = new StatusOfResidenceDao(connectionVo);

            /*
             * Vo
             */
            _conectionVo = connectionVo;
            _statusOfResidenceListVo = statusOfResidenceListVo;

            InitializeComponent();
            InitializeControl();
            InitializeComboBoxExSerchStaff();

            this.Text = "StatusOfResidenceUpdate";
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            StatusOfResidenceVo statusOfResidenceVo = new StatusOfResidenceVo();


            statusOfResidenceVo.Picture_head = (byte[]?)new ImageConverter().ConvertTo(PictureBoxHead.Image, typeof(byte[]));
            statusOfResidenceVo.Picture_tail = (byte[]?)new ImageConverter().ConvertTo(PictureBoxTail.Image, typeof(byte[]));

            try {
                _statusOfResidenceDao.InsertOneStatusOfResidenceMaster(statusOfResidenceVo);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
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
        /// InitializeControl
        /// </summary>
        private void InitializeControl() {
            TextBoxStaffName.Text = string.Empty;
            TextBoxStaffNameKana.Text = string.Empty;
            DateTimePickerExBirthDay.Value = DateTime.Now.Date;
            ComboBoxExSex.Text = string.Empty;
            ComboBoxExNationarity.Text = string.Empty;
            ComboBoxExAddress.Text = string.Empty;
            ComboBoxExStatusOfResidence.Text = string.Empty;
            ComboBoxExWorkLimit.Text = string.Empty;
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
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
