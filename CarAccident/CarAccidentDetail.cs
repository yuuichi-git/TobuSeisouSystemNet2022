using Common;

using Dao;

using Vo;

namespace CarAccident {
    public partial class CarAccidentDetail : Form {
        private InitializeForm _initializeForm = new();
        private readonly ConnectionVo _connectionVo;
        private readonly List<StaffMasterVo> _listStaffMasterVo;
        private readonly List<CarMasterVo> _listCarMasterVo;
        private readonly DateTime _insertYmdHms;
        private PictureBox[] _arrayPictureBox = new PictureBox[8];

        /// <summary>
        /// 新規登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public CarAccidentDetail(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            // 新規登録だとinsert_ymd_hmsは存在しないので_defaultDateTimeを入れておく
            _insertYmdHms = new DateTime(1900, 01, 01, 00, 00, 00, 000);
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.CarAccidentDetail(this);
            _arrayPictureBox = new PictureBox[] { PictureBox1, PictureBox2, PictureBox3, PictureBox4, PictureBox5, PictureBox6, PictureBox7, PictureBox8 };
            InitializeControl();
        }

        /// <summary>
        /// 修正登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="insertYmsHms"></param>
        public CarAccidentDetail(ConnectionVo connectionVo, DateTime insertYmsHms) {
            _connectionVo = connectionVo;
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _insertYmdHms = insertYmsHms;
            /*
             * コントロールを初期化
             */
            InitializeComponent();
            _initializeForm.CarAccidentDetail(this);
            _arrayPictureBox = new PictureBox[] { PictureBox1, PictureBox2, PictureBox3, PictureBox4, PictureBox5, PictureBox6, PictureBox7, PictureBox8 };
            InitializeControl();

            ControlOutPut(new CarAccidentMasterDao(_connectionVo).SelectOneCarAccidentMaster(insertYmsHms));
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonUpdate_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show(MessageText.Message701, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            switch(dialogResult) {
                case DialogResult.OK:
                    // DBを変更(DBにinsert_ymd_hmsが存在すればUPDATE、無ければINSERT)
                    if(new CarAccidentMasterDao(_connectionVo).CheckCarAccidentMaster(_insertYmdHms)) {
                        try {
                            new CarAccidentMasterDao(_connectionVo).UpdateOneCarAccidentMaster(SetCarAccidentMasterVo(), _insertYmdHms);
                        } catch(Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    } else {
                        try {
                            new CarAccidentMasterDao(_connectionVo).InsertOneCarAccidentMaster(SetCarAccidentMasterVo());
                        } catch(Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// SetCarAccidentLedgerVo
        /// Voに値をセット
        /// </summary>
        /// <returns></returns>
        private CarAccidentMasterVo SetCarAccidentMasterVo() {
            // ComboBox.SelectItemからVoを取得する
            var staffMasterVo = ((ComboBoxSelectStaffLedgerVo)ComboBoxSelectDisplayName.SelectedItem).StaffMasterVo;
            //var carLedgerVo = ((ComboBoxSelectCarLedgerVo)ComboBoxSelectCarRegistrationNumber.SelectedItem).CarLedgerVo;

            var carAccidentMasterVo = new CarAccidentMasterVo();
            // 集計
            carAccidentMasterVo.Totalling_flag = RadioButtonTotallingTrue.Checked;
            // 事故発生年月日
            carAccidentMasterVo.Occurrence_ymd_hms = DateTimePickerOccurrenceDate.Value;
            // 天候
            foreach(RadioButton radioButton in GroupBoxWeather.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Weather = radioButton.Text;
            }
            // 事故の種別 
            foreach(RadioButton radioButton in GroupBoxAccidentKind.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Accident_kind = radioButton.Text;
            }
            // 車両の静動
            foreach(RadioButton radioButton in GroupBoxCarStatic.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Car_static = radioButton.Text;
            }
            // 事故の発生原因　
            foreach(RadioButton radioButton in GroupBoxOccurrenceCause.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Occurrence_cause = radioButton.Text;
            }
            // 過失の有無 
            foreach(RadioButton radioButton in GroupBoxNegligence.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Negligence = radioButton.Text;
            }
            // 人身事故の詳細　
            foreach(RadioButton radioButton in GroupBoxPersonalInjury.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Personal_injury = radioButton.Text;
            }
            // 物件事故の詳細1 
            foreach(RadioButton radioButton in PanelPropertyAccident1.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Property_accident_1 = radioButton.Text;
            }
            // 物件事故の詳細2
            foreach(RadioButton radioButton in PanelPropertyAccident2.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Property_accident_2 = radioButton.Text;
            }
            // 事故の発生場所
            carAccidentMasterVo.Occurrence_address = TextBoxOccurrenceAddress.Text;
            // 運転手・作業員の別 
            foreach(RadioButton radioButton in PanelWorkKind.Controls) {
                if(radioButton.Checked)
                    carAccidentMasterVo.Work_kind = radioButton.Text;
            }
            // 運転手・作業員の氏名
            if(staffMasterVo is not null) {
                carAccidentMasterVo.Staff_code = staffMasterVo.Staff_code;
                carAccidentMasterVo.Display_name = staffMasterVo.Display_name;
                // 免許証番号
                carAccidentMasterVo.License_number = staffMasterVo.License_number;
                // 車両登録番号
                carAccidentMasterVo.Car_registration_number = ComboBoxSelectCarRegistrationNumber.Text;
                // 事故概要
                carAccidentMasterVo.Accident_summary = TextBoxAccidentSummary.Text;
                // 事故詳細
                carAccidentMasterVo.Accident_detail = TextBoxAccidentDetail.Text;
                // 事故後の指導
                carAccidentMasterVo.Guide = TextBoxGuide.Text;
                // PictureBoxPicture1
                carAccidentMasterVo.Picture1 = (byte[]?)new ImageConverter().ConvertTo(PictureBox1.Image, typeof(byte[]));
                // PictureBoxPicture2
                carAccidentMasterVo.Picture2 = (byte[]?)new ImageConverter().ConvertTo(PictureBox2.Image, typeof(byte[]));
                // PictureBoxPicture3
                carAccidentMasterVo.Picture3 = (byte[]?)new ImageConverter().ConvertTo(PictureBox3.Image, typeof(byte[]));
                // PictureBoxPicture4
                carAccidentMasterVo.Picture4 = (byte[]?)new ImageConverter().ConvertTo(PictureBox4.Image, typeof(byte[]));
                // PictureBoxPicture5
                carAccidentMasterVo.Picture5 = (byte[]?)new ImageConverter().ConvertTo(PictureBox5.Image, typeof(byte[]));
                // PictureBoxPicture6
                carAccidentMasterVo.Picture6 = (byte[]?)new ImageConverter().ConvertTo(PictureBox6.Image, typeof(byte[]));
                // PictureBoxPicture7
                carAccidentMasterVo.Picture7 = (byte[]?)new ImageConverter().ConvertTo(PictureBox7.Image, typeof(byte[]));
                // PictureBoxPicture8
                carAccidentMasterVo.Picture8 = (byte[]?)new ImageConverter().ConvertTo(PictureBox8.Image, typeof(byte[]));
            }
            return carAccidentMasterVo;
        }

        /// <summary>
        /// ControlOutPut
        /// 画面表示
        /// </summary>
        /// <param name="carAccidentMasterVo"></param>
        private void ControlOutPut(CarAccidentMasterVo carAccidentMasterVo) {
            // 事故発生日時
            DateTimePickerOccurrenceDate.Value = carAccidentMasterVo.Occurrence_ymd_hms;
            // 集計表に反映
            switch(carAccidentMasterVo.Totalling_flag) {
                case true:
                    RadioButtonTotallingTrue.Checked = true;
                    break;
                case false:
                    RadioButtonTotallingFalse.Checked = true;
                    break;
            }
            // 天候
            switch(carAccidentMasterVo.Weather) {
                case "晴れ":
                    radioButton3.Checked = true;
                    break;
                case "曇り":
                    radioButton4.Checked = true;
                    break;
                case "小雨":
                    radioButton5.Checked = true;
                    break;
                case "雨":
                    radioButton6.Checked = true;
                    break;
                case "雪":
                    radioButton7.Checked = true;
                    break;
                case "路面凍結":
                    radioButton8.Checked = true;
                    break;
            }
            // 事故の種別
            switch(carAccidentMasterVo.Accident_kind) {
                case "人身事故":
                    radioButton14.Checked = true;
                    break;
                case "物件事故":
                    radioButton9.Checked = true;
                    break;
                case "作業事故":
                    radioButton10.Checked = true;
                    break;
                case "労災事故":
                    radioButton11.Checked = true;
                    break;
                case "被害事故":
                    radioButton12.Checked = true;
                    break;
                case "飛び石":
                    radioButton13.Checked = true;
                    break;
                case "参考":
                    radioButton15.Checked = true;
                    break;
            }
            // 車両の静動
            switch(carAccidentMasterVo.Car_static) {
                case "前進時":
                    radioButton21.Checked = true;
                    break;
                case "後退時":
                    radioButton16.Checked = true;
                    break;
                case "Uターン時":
                    radioButton17.Checked = true;
                    break;
                case "停車時":
                    radioButton18.Checked = true;
                    break;
                case "右折時":
                    radioButton19.Checked = true;
                    break;
                case "左折時":
                    radioButton20.Checked = true;
                    break;
            }
            // 事故の発生原因
            switch(carAccidentMasterVo.Occurrence_cause) {
                case "前方不確認":
                    radioButton27.Checked = true;
                    break;
                case "後方不確認":
                    radioButton22.Checked = true;
                    break;
                case "左方不確認":
                    radioButton23.Checked = true;
                    break;
                case "右方不確認":
                    radioButton24.Checked = true;
                    break;
                case "運転操作ミス":
                    radioButton25.Checked = true;
                    break;
                case "一時停止をしていない":
                    radioButton26.Checked = true;
                    break;
                case "被害側なので原因無し":
                    RadioButton52.Checked = true;
                    break;
            }
            // 過失の有無
            switch(carAccidentMasterVo.Negligence) {
                case "過失なし":
                    radioButton33.Checked = true;
                    break;
                case "過失あり":
                    radioButton28.Checked = true;
                    break;
            }
            // 人身の詳細
            switch(carAccidentMasterVo.Personal_injury) {
                case "怪我なし":
                    radioButton30.Checked = true;
                    break;
                case "軽傷":
                    radioButton29.Checked = true;
                    break;
                case "重症":
                    radioButton31.Checked = true;
                    break;
                case "通院":
                    radioButton32.Checked = true;
                    break;
                case "入院":
                    radioButton34.Checked = true;
                    break;
            }
            // 物件の詳細
            switch(carAccidentMasterVo.Property_accident_1) {
                case "衝突":
                    radioButton39.Checked = true;
                    break;
                case "接触":
                    radioButton35.Checked = true;
                    break;
                case "追突":
                    radioButton36.Checked = true;
                    break;
                case "その他":
                    radioButton37.Checked = true;
                    break;
            }
            switch(carAccidentMasterVo.Property_accident_2) {
                case "電柱":
                    radioButton40.Checked = true;
                    break;
                case "電柱支線":
                    radioButton38.Checked = true;
                    break;
                case "ガードレール":
                    radioButton41.Checked = true;
                    break;
                case "道路標識":
                    radioButton42.Checked = true;
                    break;
                case "集積所":
                    radioButton43.Checked = true;
                    break;
                case "看板":
                    radioButton44.Checked = true;
                    break;
                case "塀":
                    radioButton45.Checked = true;
                    break;
                case "雨樋":
                    radioButton46.Checked = true;
                    break;
                case "車両":
                    radioButton47.Checked = true;
                    break;
                case "バイク":
                    radioButton48.Checked = true;
                    break;
                case "自転車":
                    radioButton49.Checked = true;
                    break;
                case "車止め":
                    radioButton50.Checked = true;
                    break;
                case "車止めポール":
                    radioButton51.Checked = true;
                    break;
                case "ポスト":
                    radioButton1.Checked = true;
                    break;
                case "その他":
                    radioButton2.Checked = true;
                    break;
            }
            // 発生場所
            TextBoxOccurrenceAddress.Text = carAccidentMasterVo.Occurrence_address;
            // 運転手・作業員の別
            switch(carAccidentMasterVo.Work_kind) {
                case "運転手":
                    RadioButtonDriver.Checked = true;
                    break;
                case "作業員":
                    RadioButtonOperator.Checked = true;
                    break;
            }
            // 運転手・作業員の氏名
            ComboBoxSelectDisplayName.Text = carAccidentMasterVo.Display_name;
            // 免許証番号
            TextBoxLicenseNumber.Text = carAccidentMasterVo.License_number;
            // 車両登録番号
            ComboBoxSelectCarRegistrationNumber.Text = carAccidentMasterVo.Car_registration_number;
            // 事故概要
            TextBoxAccidentSummary.Text = carAccidentMasterVo.Accident_summary;
            // 事故詳細
            TextBoxAccidentDetail.Text = carAccidentMasterVo.Accident_detail;
            // 事故後の指導
            TextBoxGuide.Text = carAccidentMasterVo.Guide;
            // 写真
            if(carAccidentMasterVo.Picture1 is not null && carAccidentMasterVo.Picture1.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox1.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture1);
            } else {
                PictureBox1.Image = null;
            }
            if(carAccidentMasterVo.Picture2 is not null && carAccidentMasterVo.Picture2.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox2.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture2);
            } else {
                PictureBox2.Image = null;
            }
            if(carAccidentMasterVo.Picture3 is not null && carAccidentMasterVo.Picture3.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox3.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture3);
            } else {
                PictureBox3.Image = null;
            }
            if(carAccidentMasterVo.Picture4 is not null && carAccidentMasterVo.Picture4.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox4.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture4);
            } else {
                PictureBox4.Image = null;
            }
            if(carAccidentMasterVo.Picture5 is not null && carAccidentMasterVo.Picture5.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox5.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture5);
            } else {
                PictureBox5.Image = null;
            }
            if(carAccidentMasterVo.Picture6 is not null && carAccidentMasterVo.Picture6.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox6.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture6);
            } else {
                PictureBox6.Image = null;
            }
            if(carAccidentMasterVo.Picture7 is not null && carAccidentMasterVo.Picture7.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox7.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture7);
            } else {
                PictureBox7.Image = null;
            }
            if(carAccidentMasterVo.Picture8 is not null && carAccidentMasterVo.Picture8.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox8.Image = (Image?)imageConv.ConvertFrom(carAccidentMasterVo.Picture8);
            } else {
                PictureBox8.Image = null;
            }
        }

        /// <summary>
        /// Control初期化
        /// </summary>
        private void InitializeControl() {
            // 事故発生年月日
            DateTimePickerOccurrenceDate.Value = DateTime.Now;
            // 集計表に反映
            RadioButtonTotallingTrue.Checked = false;
            RadioButtonTotallingFalse.Checked = false;
            // 天候
            foreach(RadioButton radioButton in GroupBoxWeather.Controls)
                radioButton.Checked = false;
            // 事故の種別
            foreach(RadioButton radioButton in GroupBoxAccidentKind.Controls)
                radioButton.Checked = false;
            // 車両の静動
            foreach(RadioButton radioButton in GroupBoxCarStatic.Controls)
                radioButton.Checked = false;
            // 事故の発生原因
            foreach(RadioButton radioButton in GroupBoxOccurrenceCause.Controls)
                radioButton.Checked = false;
            // 過失の有無
            foreach(RadioButton radioButton in GroupBoxNegligence.Controls)
                radioButton.Checked = false;
            // 人身の詳細
            foreach(RadioButton radioButton in GroupBoxPersonalInjury.Controls)
                radioButton.Checked = false;
            // 物件の詳細
            foreach(RadioButton radioButton in PanelPropertyAccident1.Controls)
                radioButton.Checked = false;
            foreach(RadioButton radioButton in PanelPropertyAccident2.Controls)
                radioButton.Checked = false;
            // 発生場所
            TextBoxOccurrenceAddress.Text = "";
            // 運転手・作業員の別
            foreach(RadioButton radioButton in PanelWorkKind.Controls)
                radioButton.Checked = false;
            // 運転手・作業員の氏名
            InitializeComboBoxSelectDisplayName();
            // 免許証番号
            TextBoxLicenseNumber.Text = "";
            // 車両登録番号
            InitializeComboBoxSelectCarRegistrationNumber();
            // 事故概要
            TextBoxAccidentSummary.Text = "";
            // 事故詳細
            TextBoxAccidentDetail.Text = "";
            // 事故後の指導
            TextBoxGuide.Text = "";
            // 写真
            foreach(PictureBox pictureBox in _arrayPictureBox)
                pictureBox.Image = null;
        }

        /// <summary>
        /// ComboBoxSelectNameを初期化
        /// </summary>
        private void InitializeComboBoxSelectDisplayName() {
            ComboBoxSelectDisplayName.Items.Clear();
            foreach(var staffMasterVo in _listStaffMasterVo)
                ComboBoxSelectDisplayName.Items.Add(new ComboBoxSelectStaffLedgerVo(staffMasterVo.Display_name, staffMasterVo));
            ComboBoxSelectDisplayName.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// ComboBoxSelectStaffLedgerVo
        /// </summary>
        private class ComboBoxSelectStaffLedgerVo {
            private string _displayName;
            private StaffMasterVo _staffMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectStaffLedgerVo(string displayName, StaffMasterVo staffMasterVo) {
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
        /// ComboBoxSelectCarRegistrationNumberを初期化
        /// </summary>
        private void InitializeComboBoxSelectCarRegistrationNumber() {
            ComboBoxSelectCarRegistrationNumber.Items.Clear();
            foreach(var carMasterVo in _listCarMasterVo)
                ComboBoxSelectCarRegistrationNumber.Items.Add(new ComboBoxSelectCarLedgerVo(carMasterVo.Registration_number, carMasterVo));
            ComboBoxSelectCarRegistrationNumber.DisplayMember = "RegistrationNumber";
        }

        private class ComboBoxSelectCarLedgerVo {
            private string _registrationNumber;
            private CarMasterVo _carMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectCarLedgerVo(string registrationNumber, CarMasterVo carMasterVo) {
                _registrationNumber = registrationNumber;
                _carMasterVo = carMasterVo;
            }
            public string RegistrationNumber {
                get => _registrationNumber;
                set => _registrationNumber = value;
            }
            public CarMasterVo CarMasterVo {
                get => _carMasterVo;
                set => _carMasterVo = value;
            }
        }

        /// <summary>
        /// 画像を選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPictureSelect_Click(object sender, EventArgs e) {
            int arrayNumber = Convert.ToInt32(((Button)sender).Tag);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Title = "写真を選択して下さい"; // ダイアログのタイトルを指定する
            openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.jpeg,*.JPEG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.jpeg;*.JPEG;*.tif;*.TIF;*.png;*.PNG;";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            if(openFileDialog.ShowDialog() == DialogResult.OK) {
                _arrayPictureBox[arrayNumber - 1].ImageLocation = openFileDialog.FileName; // Passをセットする
            }
            openFileDialog.Dispose(); // オブジェクトを破棄する
        }

        /// <summary>
        /// 画像をクリップボードから選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPictureClip_Click(object sender, EventArgs e) {
            int arrayNumber = Convert.ToInt32(((Button)sender).Tag);
            _arrayPictureBox[arrayNumber - 1].Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
        }

        /// <summary>
        /// 画像を削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPictureDelete_Click(object sender, EventArgs e) {
            int arrayNumber = Convert.ToInt32(((Button)sender).Tag);
            _arrayPictureBox[arrayNumber - 1].Image = null;
        }

        /// <summary>
        /// PictureBoxを別ウインドウで表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DoubleClick(object sender, EventArgs e) {
            var carAccidentLedgerPicture = new CarAccidentPicture(((PictureBox)sender).Image);
            carAccidentLedgerPicture.ShowDialog(this);
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
        /// CarAccidentLedgerDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarAccidentLedgerDetail_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
