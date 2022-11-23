using Common;

using Dao;

using Vo;

namespace CarRegister {
    public partial class CarDetail : Form {
        private InitializeForm _initializeForm = new();
        private readonly ConnectionVo _connectionVo;
        private readonly CarMasterDao _carMasterDao;
        /// <summary>
        /// True: 新規登録モード False:修正登録モード
        /// </summary>
        private readonly bool _openFlag;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        /// <summary>
        /// 新規登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public CarDetail(ConnectionVo connectionVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _carMasterDao = new CarMasterDao(_connectionVo);
            _openFlag = true;
            _initializeForm.CarAccidentDetail(this);
            // Controlを初期化
            InitializeControl();
        }

        /// <summary>
        /// 修正登録用コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="carCode"></param>
        public CarDetail(ConnectionVo connectionVo, int carCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            _carMasterDao = new CarMasterDao(_connectionVo);
            _openFlag = false;
            _initializeForm.CarAccidentDetail(this);
            // Controlを初期化
            InitializeControl();
            // 対象レコードを読込む
            ControlOutPut(_carMasterDao.SelectOneCarMaster(carCode));
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message802, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    // StaffLedgerVoに値をセット
                    var carLedgerVo = SetCarMasterVo();
                    if (_carMasterDao.CheckCarMaster(carLedgerVo.Car_code) != 0) {
                        _carMasterDao.UpdateOneCarMaster(carLedgerVo);
                    } else {
                        _carMasterDao.InsertOneCarMaster(carLedgerVo);
                    }
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        Dictionary<string, int> dictionaryClassificationCode = new Dictionary<string, int> { { "雇上", 10 }, { "区契", 11 }, { "一般", 50 }, { "社用車", 51 }, { "指定なし", 99 } };
        Dictionary<string, bool> dictionaryGarageFlag = new Dictionary<string, bool> { { "本社", true }, { "三郷", false } };
        Dictionary<string, int> dictionaryCarKindCode = new Dictionary<string, int> { { "軽自動車", 10 }, { "小型", 11 }, { "普通", 12 } };
        Dictionary<string, int> dictionaryShapeCode = new Dictionary<string, int> { { "キャブオーバー", 10 }, { "塵芥車", 11 }, { "ダンプ", 12 }, { "コンテナ専用", 13 }, { "脱着装置付コンテナ専用車", 14 }, { "粉粒体運搬車", 15 }, { "糞尿車", 16 }, { "清掃車", 17 } };
        Dictionary<string, int> dictionaryManufacturerCode = new Dictionary<string, int> { { "いすゞ", 10 }, { "日産", 11 }, { "ダイハツ", 12 }, { "日野", 13 }, { "スバル", 14 } };
        /// <summary>
        /// SetCarLedgerVo
        /// </summary>
        /// <returns></returns>
        private CarMasterVo SetCarMasterVo() {
            var carMasterVo = new CarMasterVo(); // 代入用のインスタンス作成
            carMasterVo.Car_code = _openFlag ? _carMasterDao.GetCarCode(99999) + 1 : int.Parse(TextBoxCarCode.Text); // 車両コード
            carMasterVo.Classification_code = dictionaryClassificationCode[ComboBoxClassificationName.Text]; // 分類コード　分類名
            carMasterVo.Registration_number = TextBoxRegistrationNumber.Text; // 車両ナンバー
            carMasterVo.Door_number = TextBoxDoorNumber.Text != "" ? int.Parse(TextBoxDoorNumber.Text) : 0; // ドア番号
            carMasterVo.Registration_number_1 = ComboBoxRegistrationNumber1.Text; // 車両ナンバー１
            carMasterVo.Registration_number_2 = TextBoxRegistrationNumber2.Text; // 車両ナンバー２
            carMasterVo.Registration_number_3 = TextBoxRegistrationNumber3.Text; // 車両ナンバー３
            carMasterVo.Registration_number_4 = TextBoxRegistrationNumber4.Text; // 車両ナンバー４
            carMasterVo.Garage_flag = dictionaryGarageFlag[ComboBoxGarage.Text]; // 実際の車庫地
            carMasterVo.Registration_date = DateTimePickerRegistrationDate.Value.Date; // 登録年月日/交付年月日
            carMasterVo.First_registration_date = DateTimePickerFirstRegistrationDate.Value.Date; // 初度登録年月
            carMasterVo.Car_kind_code = dictionaryCarKindCode[ComboBoxCarKindName.Text]; // 自動車の種別
            carMasterVo.Disguise_kind_1 = ComboBoxDisguiseKind1.Text; // 仮装の略称名(配車)
            carMasterVo.Disguise_kind_2 = ComboBoxDisguiseKind2.Text; // 仮装の略称名(事故)
            carMasterVo.Disguise_kind_3 = ComboBoxDisguiseKind3.Text; // 仮装の略称名(整備)
            carMasterVo.Car_use = ComboBoxCarUse.Text; // 用途
            carMasterVo.Other_code = ComboBoxOther.SelectedIndex + 1; // 
            carMasterVo.Other_name = ComboBoxOther.Text; // 自家用・事業用の別
            carMasterVo.Shape_code = dictionaryShapeCode[ComboBoxShape.Text]; // 
            carMasterVo.Manufacturer_code = dictionaryManufacturerCode[ComboBoxManufacturerName.Text]; // 車名(メーカー名)
            carMasterVo.Capacity = NumericUpDownCapacity.Value; // 乗車定員
            carMasterVo.Maximum_load_capacity = NumericUpDownMaximumLoadCapacity.Value; // 最大積載量
            carMasterVo.Vehicle_weight = NumericUpDownVehicleWeight.Value; // 車両重量
            carMasterVo.Total_vehicle_weight = NumericUpDownTotalVehicleWeight.Value; // 車両総重量
            carMasterVo.Vehicle_number = ComboBoxVehicleNumber.Text; // 車台番号
            carMasterVo.Length = NumericUpDownLength.Value; // 長さ
            carMasterVo.Width = NumericUpDownWidth.Value; // 幅
            carMasterVo.Height = NumericUpDownHeight.Value; // 高さ
            carMasterVo.Ff_axis_weight = NumericUpDownFfAxisWeight.Value; // 前前軸重
            carMasterVo.Fr_axis_weight = NumericUpDownFrAxisWeight.Value; // 前後軸重
            carMasterVo.Rf_axis_weight = NumericUpDownRfAxisWeight.Value; // 後前軸重
            carMasterVo.Rr_axis_weight = NumericUpDownRrAxisWeight.Value; // 後後軸重
            carMasterVo.Version = ComboBoxVersion.Text; // 型式
            carMasterVo.Motor_version = ComboBoxMotorVersion.Text; // 原動機の型式
            carMasterVo.Total_displacement = NumericUpDownTotalDisplacement.Value; // 総排気量又は定格出力
            carMasterVo.Types_of_fuel = ComboBoxTypesOfFuel.Text; // 燃料の種類
            carMasterVo.Version_designate_number = ComboBoxVersionDesignateNumber.Text; // 型式指定番号
            carMasterVo.Category_distinguish_number = ComboBoxCategoryDistinguishNumber.Text; // 類似区分番号
            carMasterVo.Owner_name = ComboBoxOwnerName.Text; // 所有者の氏名又は名称
            carMasterVo.Owner_address = ComboBoxOwnerAddress.Text; // 所有者の住所
            carMasterVo.User_name = ComboBoxUserName.Text; // 使用者の氏名又は名称
            carMasterVo.User_address = ComboBoxUserAddress.Text; // 使用者の住所
            carMasterVo.Base_address = ComboBoxBaseAddress.Text; // 使用の本拠の位置
            carMasterVo.Expiration_date = DateTimePickerExpirationDate.Value.Date; // 有効期限の満了する日
            carMasterVo.Remarks = TextBoxRemarks.Text; // 備考
            carMasterVo.Picture = (byte[]?)new ImageConverter().ConvertTo(PictureBox1.Image, typeof(byte[]));
            return carMasterVo;
        }

        /// <summary>
        /// ControlOutPut
        /// </summary>
        /// <param name="carMasterVo"></param>
        private void ControlOutPut(CarMasterVo carMasterVo) {
            ComboBoxClassificationName.Text = carMasterVo.Classification_name; // 使用区分
            TextBoxCarCode.Text = string.Format("{0:#}", carMasterVo.Car_code); // 車両コード
            TextBoxRegistrationNumber.Text = carMasterVo.Registration_number; // 車両ナンバー
            TextBoxDoorNumber.Text = string.Format("{0:#}", carMasterVo.Door_number); // ドア番号
            ComboBoxRegistrationNumber1.Text = carMasterVo.Registration_number_1; // 車両ナンバー１
            TextBoxRegistrationNumber2.Text = carMasterVo.Registration_number_2; // 車両ナンバー２
            TextBoxRegistrationNumber3.Text = carMasterVo.Registration_number_3; // 車両ナンバー３
            TextBoxRegistrationNumber4.Text = string.Format("{0:#}", carMasterVo.Registration_number_4); // 車両ナンバー４
            ComboBoxGarage.Text = carMasterVo.Garage_flag ? "本社" : "三郷"; // 実際の車庫地
            DateTimePickerRegistrationDate.Value = carMasterVo.Registration_date.Date; // 登録年月日/交付年月日
            DateTimePickerFirstRegistrationDate.Text = carMasterVo.First_registration_date.Date.ToString("yyyy年MM月"); // 初度登録年月
            ComboBoxCarKindName.Text = carMasterVo.Car_kind_name; // 自動車の種別
            ComboBoxDisguiseKind1.Text = carMasterVo.Disguise_kind_1; // 仮装の略称名(配車)
            ComboBoxDisguiseKind2.Text = carMasterVo.Disguise_kind_2; // 仮装の略称名(事故)
            ComboBoxDisguiseKind3.Text = carMasterVo.Disguise_kind_3; // 仮装の略称名(整備)
            ComboBoxCarUse.Text = carMasterVo.Car_use; // 用途
            ComboBoxOther.Text = carMasterVo.Other_name; // 自家用・事業用の別
            ComboBoxShape.Text = carMasterVo.Shape_name; // 車体の形状
            ComboBoxManufacturerName.Text = carMasterVo.Manufacturer_name; // 車名
            NumericUpDownCapacity.Value = carMasterVo.Capacity; // 乗車定員
            NumericUpDownMaximumLoadCapacity.Value = carMasterVo.Maximum_load_capacity; // 最大積載量
            NumericUpDownVehicleWeight.Value = carMasterVo.Vehicle_weight; // 車両重量
            NumericUpDownTotalVehicleWeight.Value = carMasterVo.Total_vehicle_weight; // 車両総重量
            ComboBoxVehicleNumber.Text = carMasterVo.Vehicle_number; // 車台番号
            NumericUpDownLength.Value = carMasterVo.Length; // 長さ
            NumericUpDownWidth.Value = carMasterVo.Width; // 幅
            NumericUpDownHeight.Value = carMasterVo.Height; // 高さ
            NumericUpDownFfAxisWeight.Value = carMasterVo.Ff_axis_weight; // 前前軸重
            NumericUpDownFrAxisWeight.Value = carMasterVo.Fr_axis_weight; // 前後軸重
            NumericUpDownRfAxisWeight.Value = carMasterVo.Rf_axis_weight; // 後前軸重
            NumericUpDownRrAxisWeight.Value = carMasterVo.Rr_axis_weight; // 後後軸重
            ComboBoxVersion.Text = carMasterVo.Version; // 型式
            ComboBoxMotorVersion.Text = carMasterVo.Motor_version; // 原動機の型式
            NumericUpDownTotalDisplacement.Value = carMasterVo.Total_displacement; // 総排気量又は定格出力
            ComboBoxTypesOfFuel.Text = carMasterVo.Types_of_fuel; // 燃料の種類
            ComboBoxVersionDesignateNumber.Text = carMasterVo.Version_designate_number; // 型式指定番号
            ComboBoxCategoryDistinguishNumber.Text = carMasterVo.Category_distinguish_number; // 類似区分番号
            ComboBoxOwnerName.Text = carMasterVo.Owner_name; // 所有者の氏名又は名称
            ComboBoxOwnerAddress.Text = carMasterVo.Owner_address; // 所有者の住所
            ComboBoxUserName.Text = carMasterVo.User_name; // 使用者の氏名又は名称
            ComboBoxUserAddress.Text = carMasterVo.User_address; // 使用者の住所
            ComboBoxBaseAddress.Text = carMasterVo.Base_address; // 使用の本拠の位置
            DateTimePickerExpirationDate.Value = carMasterVo.Expiration_date.Date; // 有効期限の満了する日
            TextBoxRemarks.Text = carMasterVo.Remarks; // 備考
            if (carMasterVo.Picture.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox1.Image = (Image?)imageConv.ConvertFrom(carMasterVo.Picture); // 写真
            }
        }


        /// <summary>
        /// Controlを初期化
        /// </summary>
        private void InitializeControl() {
            ComboBoxClassificationName.SelectedIndex = -1; // 使用区分
            TextBoxCarCode.Text = ""; // 車両コード
            TextBoxRegistrationNumber.Text = ""; // 車両ナンバー
            TextBoxDoorNumber.Text = ""; // ドア番号
            ComboBoxRegistrationNumber1.SelectedIndex = -1; // 車両ナンバー１
            TextBoxRegistrationNumber2.Text = ""; // 車両ナンバー２
            TextBoxRegistrationNumber3.Text = ""; // 車両ナンバー３
            TextBoxRegistrationNumber4.Text = ""; // 車両ナンバー４
            ComboBoxGarage.SelectedIndex = -1; // 実際の車庫地
            SetDateTimePicker(DateTimePickerRegistrationDate, null); // 登録年月日/交付年月日
            SetDateTimePicker(DateTimePickerFirstRegistrationDate, null); // 初度登録年月
            ComboBoxCarKindName.SelectedIndex = -1; // 自動車の種別
            ComboBoxDisguiseKind1.SelectedIndex = -1; // 仮装の略称名(配車)
            ComboBoxDisguiseKind2.SelectedIndex = -1; // 仮装の略称名(事故)
            ComboBoxDisguiseKind3.SelectedIndex = -1; // 仮装の略称名(整備)
            ComboBoxCarUse.SelectedIndex = -1; // 用途
            ComboBoxOther.SelectedIndex = -1; // 自家用・事業用の別
            ComboBoxShape.SelectedIndex = -1; // 車体の形状
            ComboBoxManufacturerName.SelectedIndex = -1; // 車名
            NumericUpDownCapacity.Value = 0; // 乗車定員
            NumericUpDownMaximumLoadCapacity.Value = 0; // 最大積載量
            NumericUpDownVehicleWeight.Value = 0; // 車両重量
            NumericUpDownTotalVehicleWeight.Value = 0; // 車両総重量
            ComboBoxVehicleNumber.SelectedIndex = -1; // 車台番号
            NumericUpDownLength.Value = 0; // 長さ
            NumericUpDownWidth.Value = 0; // 幅
            NumericUpDownHeight.Value = 0; // 高さ
            NumericUpDownFfAxisWeight.Value = 0; // 前前軸重
            NumericUpDownFrAxisWeight.Value = 0; // 前後軸重
            NumericUpDownRfAxisWeight.Value = 0; // 後前軸重
            NumericUpDownRrAxisWeight.Value = 0; // 後後軸重
            ComboBoxVersion.SelectedIndex = -1; // 型式
            ComboBoxMotorVersion.SelectedIndex = -1; // 原動機の型式
            NumericUpDownTotalDisplacement.Value = 0; // 総排気量又は定格出力
            ComboBoxTypesOfFuel.SelectedIndex = -1; // 燃料の種類
            ComboBoxVersionDesignateNumber.SelectedIndex = -1; // 型式指定番号
            ComboBoxCategoryDistinguishNumber.SelectedIndex = -1; // 類似区分番号
            ComboBoxOwnerName.SelectedIndex = 0; // 所有者の氏名又は名称
            ComboBoxOwnerAddress.SelectedIndex = 0; // 所有者の住所
            ComboBoxUserName.SelectedIndex = 0; // 使用者の氏名又は名称
            ComboBoxUserAddress.SelectedIndex = 0; // 使用者の住所
            ComboBoxBaseAddress.SelectedIndex = 0; // 使用の本拠の位置
            SetDateTimePicker(DateTimePickerExpirationDate, null); // 有効期限の満了する日
            TextBoxRemarks.Text = ""; // 備考
            PictureBox1.Image = null; // 写真
        }

        /// <summary>
        /// 画像取込　選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectPicture_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Title = "写真を選択して下さい";//ダイアログのタイトルを指定する
            openFileDialog.Filter = "画像ファイル(*.gif,*.GIF,*.jpg,*.JPG,*.tif,*.TIF,*.png,*.PNG)|*.gif;*.GIF;*.jpg;*.JPG;*.tif;*.TIF;*.png;*.PNG;";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                PictureBox1.ImageLocation = openFileDialog.FileName;//Passをセットする
            openFileDialog.Dispose();// オブジェクトを破棄する
        }

        /// <summary>
        /// 画像選択　クリップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClipPicture_Click(object sender, EventArgs e) {
            /*
             * クリップボードを転送
             * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
             */
            PictureBox1.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
        }

        /// <summary>
        /// 画像選択　削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePicture_Click(object sender, EventArgs e) {
            PictureBox1.Image = null;
        }

        /*
         * DateTimePicker_ValueChanged
         */
        private void DateTimePicker_ValueChanged(object sender, EventArgs e) {
            //dateTimePicker1の値が変更されたら表示する
            var dateTime = ((DateTimePicker)sender).Value;
            SetDateTimePicker((DateTimePicker)sender, dateTime);
        }

        /*
         * DateTimePicker_KeyDown
         */
        private void DateTimePicker_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Delete) {
                //Deleteキーが押されたら、dateTimeにnullを設定してdateTimePicker1を非表示に
                SetDateTimePicker((DateTimePicker)sender, null);
            }
        }

        /*
         * SetDateTimePicker
         */
        private void SetDateTimePicker(DateTimePicker dateTimePicker, DateTime? datetime) {
            if (datetime == null || datetime == _defaultDateTime) {
                //DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = " ";
            } else {
                //フォーマットを元に戻して、値をセットする。
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                switch (dateTimePicker.Name) {
                    case "DateTimePickerFirstRegistrationDate": // 初度登録年月
                        dateTimePicker.CustomFormat = "yyyy年MM月";
                        break;
                    default:
                        dateTimePicker.CustomFormat = "yyyy年MM月dd日(ddd)";
                        break;
                }

                dateTimePicker.Value = (DateTime)datetime;
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
        /// CarDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarDetail_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}
