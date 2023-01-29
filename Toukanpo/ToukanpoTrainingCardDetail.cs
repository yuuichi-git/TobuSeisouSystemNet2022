using Common;

using Dao;

using Vo;

namespace Toukanpo {
    public partial class ToukanpoTrainingCardDetail : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Dao
         */
        private readonly ToukanpoTrainingCardDao _toukanpoTrainingCardDao;
        private StaffMasterDao _staffMasterDao;
        /*
         * Vo
         */
        private List<StaffMasterVo> _listStaffMasterVo;
        /// <summary>
        /// ComboBoxSelectNameで選択されたStaffLedgerVoを保持
        /// </summary>
        private StaffMasterVo _selectedStaffMasterVo;
        /// <summary>
        /// ComboBoxSelectNameで選択されたToukanpoTrainingCardVoを保持
        /// </summary>
        private ToukanpoTrainingCardVo _selectedToukanpoVo;

        public ToukanpoTrainingCardDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _toukanpoTrainingCardDao = new ToukanpoTrainingCardDao(connectionVo);
            /*
             * Vo
             */
            _listStaffMasterVo = _staffMasterDao.SelectAllStaffMaster();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            // ComboBoxSelectNameを初期化
            InitializeComboBoxSelectName();
            ComboBoxCompanyName.Text = "東武清掃株式会社";
            ComboBoxSelectName.Text = "";
            DateTimeCertificationDate.Value = DateTime.Now;

        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            if(_selectedToukanpoVo == null) {
                MessageBox.Show("この名前は従業員台帳に登録されていません。リストから選択して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dialogResult = MessageBox.Show("更新しますか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    switch(_selectedToukanpoVo.Staff_code) {
                        // 新規
                        case 0:
                            _toukanpoTrainingCardDao.InsertOneToukanpoTrainingCard(SetToukanpoTrainingCardVo());
                            break;
                        // 修正
                        default:
                            _toukanpoTrainingCardDao.UpdateOneToukanpoTrainingCard(SetToukanpoTrainingCardVo());
                            break;
                    }
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// SetToukanpoTrainingCardVo
        /// </summary>
        /// <returns></returns>
        private ToukanpoTrainingCardVo SetToukanpoTrainingCardVo() {
            ToukanpoTrainingCardVo toukanpoTrainingCardVo = new ToukanpoTrainingCardVo();
            toukanpoTrainingCardVo.Staff_code = _selectedStaffMasterVo.Staff_code;
            toukanpoTrainingCardVo.Display_name = _selectedStaffMasterVo.Display_name;
            toukanpoTrainingCardVo.Company_name = ComboBoxCompanyName.Text;
            toukanpoTrainingCardVo.Card_name = _selectedStaffMasterVo.Display_name;
            toukanpoTrainingCardVo.CertificationDate = DateTimeCertificationDate.Value.Date;
            toukanpoTrainingCardVo.Picture = (byte[]?)new ImageConverter().ConvertTo(PictureBoxCard.Image, typeof(byte[])); // 写真
            toukanpoTrainingCardVo.Insert_ymd_hms = _selectedToukanpoVo != null ? _selectedToukanpoVo.Insert_ymd_hms : DateTime.Now;
            toukanpoTrainingCardVo.Update_ymd_hms = DateTime.Now;
            toukanpoTrainingCardVo.Delete_ymd_hms = _defaultDateTime;
            toukanpoTrainingCardVo.Delete_flag = false;
            return toukanpoTrainingCardVo;
        }

        /// <summary>
        /// InitializeComboBoxSelectName
        /// </summary>
        private void InitializeComboBoxSelectName() {
            ComboBoxSelectName.Items.Clear();
            List<ComboBoxSelectNameVo> listComboBoxSelectNameVo = new List<ComboBoxSelectNameVo>();
            foreach(StaffMasterVo staffMasterVo in _listStaffMasterVo)
                ComboBoxSelectName.Items.Add(new ComboBoxSelectNameVo(staffMasterVo.Name, staffMasterVo));
            ComboBoxSelectName.DisplayMember = "Name";
            // ここでイベント追加しないと初期化で発火しちゃうよ
            ComboBoxSelectName.SelectedIndexChanged += new EventHandler(ComboBoxSelectName_SelectedIndexChanged);
            // オートコンプリートモードの設定
            ComboBoxSelectName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // コンボボックスのアイテムをオートコンプリートの選択候補とする
            ComboBoxSelectName.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxSelectName.Focus();
        }

        /// <summary>
        /// ComboBoxSelectNameVo
        /// 内部クラス
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
        /// ComboBoxSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectName_SelectedIndexChanged(object sender, EventArgs e) {
            _selectedStaffMasterVo = ((ComboBoxSelectNameVo)((ComboBox)sender).SelectedItem).StaffMasterVo;
            _selectedToukanpoVo = _toukanpoTrainingCardDao.SelectOneToukanpoTrainingCard(_selectedStaffMasterVo.Staff_code);
            if(_selectedToukanpoVo.Staff_code > 0) {
                ToolStripStatusLabelDetail.Text = "登録されています";
                // Controlに値をセット
                ComboBoxCompanyName.Text = _selectedToukanpoVo.Company_name;
                DateTimeCertificationDate.Value = _selectedToukanpoVo.CertificationDate.Date;
                if(_selectedToukanpoVo.Picture.Length != 0) {
                    PictureBoxCard.Image = (Image?)new ImageConverter().ConvertFrom(_selectedToukanpoVo.Picture);
                } else {
                    PictureBoxCard.Image = null;
                }
            } else {
                ToolStripStatusLabelDetail.Text = "登録されていません";
                // Controlに値をセット
                ComboBoxCompanyName.SelectedIndex = -1;
                //ComboBoxSelectName.Text = "";
                DateTimeCertificationDate.Value = DateTime.Now.Date;
                PictureBoxCard.Image = null;
            }
        }

        /// <summary>
        /// ButtonSelectPicture_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectPicture_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Title = "写真を選択して下さい"; // ダイアログのタイトルを指定する
            openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.tif;*.TIF;*.png;*.PNG;";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            if(openFileDialog.ShowDialog() == DialogResult.OK)
                // Passをセットする
                PictureBoxCard.ImageLocation = openFileDialog.FileName;
            openFileDialog.Dispose(); // オブジェクトを破棄する
        }

        /// <summary>
        /// ButtonClipPicture_Click
        /// クリップボードを転送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClipPicture_Click(object sender, EventArgs e) {
            /*
             * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
             */
            PictureBoxCard.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
        }

        /// <summary>
        /// ButtonDeletePicture_Click
        /// 写真削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePicture_Click(object sender, EventArgs e) {
            PictureBoxCard.Image = null;
        }
    }
}
