/*
 * 2024-03-29
 */
using H_ControlEx;

using H_Dao;

using Vo;

namespace H_Car {
    public partial class HCarDetail : Form {
        private readonly Dictionary<string, int> dictionaryClassificationCode = new Dictionary<string, int> { { "雇上", 10 }, { "区契", 11 }, { "臨時", 12 }, { "清掃工場", 20 }, { "社内", 30 }, { "一般", 50 }, { "社用車", 51 }, { "指定なし", 99 } };
        private readonly Dictionary<int, string> dictionaryClassificationName = new Dictionary<int, string> { { 10, "雇上" }, { 11, "区契" }, { 12, "臨時" }, { 20, "清掃工場" }, { 30, "社内" }, { 50, "一般" }, { 51, "社用車" }, { 99, "指定なし" } };

        private readonly Dictionary<string, int> dictionaryGarageCode = new Dictionary<string, int> { { "指定なし", 0 }, { "足立", 1 }, { "三郷", 2 } };
        private readonly Dictionary<int, string> dictionaryGarageName = new Dictionary<int, string> { { 0, "指定なし" }, { 1, "足立" }, { 2, "三郷" } };

        private readonly Dictionary<string, int> dictionaryCarKindCode = new Dictionary<string, int> { { "軽自動車", 10 }, { "小型", 11 }, { "普通", 12 } };
        private readonly Dictionary<int, string> dictionaryCarKindName = new Dictionary<int, string> { { 10, "軽自動車" }, { 11, "小型" }, { 12, "普通" } };

        private readonly Dictionary<string, int> dictionaryOtherCode = new Dictionary<string, int> { { "事業用", 10 }, { "自家用", 11 } };
        private readonly Dictionary<int, string> dictionaryOtherName = new Dictionary<int, string> { { 10, "事業用" }, { 11, "自家用" } };

        private readonly Dictionary<string, int> dictionaryShapeCode = new Dictionary<string, int> { { "キャブオーバー", 10 }, { "塵芥車", 11 }, { "ダンプ", 12 }, { "コンテナ専用", 13 }, { "脱着装置付コンテナ専用車", 14 }, { "粉粒体運搬車", 15 }, { "糞尿車", 16 }, { "清掃車", 17 } };
        private readonly Dictionary<int, string> dictionaryShapeName = new Dictionary<int, string> { { 10, "キャブオーバー" }, { 11, "塵芥車" }, { 12, "ダンプ" }, { 13, "コンテナ専用" }, { 14, "脱着装置付コンテナ専用車" }, { 15, "粉粒体運搬車" }, { 16, "糞尿車" }, { 17, "清掃車" } };

        private readonly Dictionary<string, int> dictionaryManufacturerCode = new Dictionary<string, int> { { "いすゞ", 10 }, { "日産", 11 }, { "ダイハツ", 12 }, { "日野", 13 }, { "スバル", 14 } };
        private readonly Dictionary<int, string> dictionaryManufacturerName = new Dictionary<int, string> { { 10, "いすゞ" }, { 11, "日産" }, { 12, "ダイハツ" }, { 13, "日野" }, { 14, "スバル" } };
        /*
         * Dao
         */
        private readonly H_CarMasterDao _hCarMasterDao;

        /// <summary>
        /// コンストラクター(新規)
        /// </summary>
        /// <param name="connectionVo"></param>
        public HCarDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCarMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeControl();
            // 新規での車両コード採番
            HTextBoxExCarCode.Text = (_hCarMasterDao.GetCarCode() + 1).ToString("#####");
            ToolStripStatusLabelDetail.Text = "初期化を完了しました";
        }

        /// <summary>
        /// コンストラクター(修正)
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="carCode"></param>
        public HCarDetail(ConnectionVo connectionVo, int carCode) {
            /*
             * Dao
             */
            _hCarMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeControl();
            this.SetControl(_hCarMasterDao.SelectOneHCarMasterP(carCode));
            ToolStripStatusLabelDetail.Text = "読込を完了しました";
        }

        /// <summary>
        /// コントロールを初期化
        /// </summary>
        private void InitializeControl() {
            /*
             * システム情報
             */
            HTextBoxExCarCode.Text = string.Empty; // 車両コード
            HTextBoxExRegistrationNumber.Text = string.Empty; // 車両ナンバー
            HTextBoxExDoorNumber.Text = string.Empty; // ドア番号
            HComboBoxExRegistrationNumber1.Clear(); // 車両ナンバー１
            HTextBoxExRegistrationNumber2.Text = string.Empty; // 車両ナンバー２
            HTextBoxExRegistrationNumber3.Text = string.Empty; // 車両ナンバー３
            HTextBoxExRegistrationNumber4.Text = string.Empty; // 車両ナンバー４
            HComboBoxExClassificationCode.Clear(); // 使用区分
            HComboBoxExGarageCode.Clear(); // 車庫地
            HComboBoxExDisguiseKind1.Clear(); // 仮装の名称(システム表示)
            HComboBoxExDisguiseKind2.Clear(); // 仮装の名称(事故報告書)
            HComboBoxExDisguiseKind3.Clear(); // 仮装の名称(整備工場等)
            /*
             * １．基本情報
             */
            HTextBoxExVehicleNumber.Text = string.Empty; // 車台番号
            HDateTimePickerExRegistrationDate.SetValueJp(DateTime.Now.Date); // 登録年月日/交付年月日
            HDateTimePickerExFirstRegistrationDate.SetValueJp(DateTime.Now.Date); // 初度登録年月
            HDateTimePickerExExpirationDate.SetValueJp(DateTime.Now.Date); // 有効期限の満了する日
            /*
             * ２．所有者・使用者情報
             */
            HComboBoxExOwnerName.Clear(); // 所有者の氏名又は名称
            HComboBoxExOwnerAddress.Clear(); // 所有者の住所
            HComboBoxExUserName.Clear(); // 使用者の氏名又は名称
            HComboBoxExUserAddress.Clear(); // 使用者の住所
            HComboBoxExBaseAddress.Clear(); // 使用の本拠の位置
            /*
             * ３．車両詳細情報
             */
            HComboBoxExManufacturerCode.Clear(); // 車名
            HTextBoxExVersion.Text = string.Empty; // 型式
            HTextBoxExMotorVersion.Text = string.Empty; // 原動機の型式
            HComboBoxExCarKindCode.Clear(); // 自動車の種別
            HComboBoxExCarUse.Clear(); // 用途
            HComboBoxExOtherCode.Clear(); // 自家用・事業用の別
            HComboBoxExShapeCode.Clear(); // 車体の形状
            HNumericUpDownExCapacity.Value = 0; // 乗車定員
            HNumericUpDownExMaximumLoadCapacity.Value = 0; // 最大積載量
            HNumericUpDownExVehicleWeight.Value = 0; // 車両重量
            HNumericUpDownExTotalVehicleWeight.Value = 0; // 車両総重量
            HNumericUpDownExLength.Value = 0; // 長さ
            HNumericUpDownExWidth.Value = 0; // 幅
            HNumericUpDownExHeight.Value = 0; // 高さ 
            HNumericUpDownExFfAxisWeight.Value = 0; // 前前軸重
            HNumericUpDownExFrAxisWeight.Value = 0; // 前後軸重
            HNumericUpDownExRfAxisWeight.Value = 0; // 後前軸重
            HNumericUpDownExRrAxisWeight.Value = 0; // 後後軸重
            HNumericUpDownExTotalDisplacement.Value = 0; // 総排気量又は定格出力
            HComboBoxExTypesOfFuel.Clear(); // 燃料の種類
            HTextBoxExVersionDesignateNumber.Text = string.Empty; // 型式指定番号
            HTextBoxExCategoryDistinguishNumber.Text = string.Empty; // 類別区分番号
            HTextBoxExRemarks.Text = string.Empty; // 備考
            HPictureBoxExPicture.Image = null; // 写真

            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// SetVo
        /// Voに値をセットする
        /// </summary>
        /// <returns></returns>
        private H_CarMasterVo SetVo() {
            H_CarMasterVo hCarMasterVo = new();
            /*
             * システム情報
             */
            hCarMasterVo.CarCode = int.Parse(HTextBoxExCarCode.Text); // 車両コード
            hCarMasterVo.RegistrationNumber = HTextBoxExRegistrationNumber.Text; // 車両ナンバー
            hCarMasterVo.DoorNumber = HTextBoxExDoorNumber.Text.Length > 0 ? int.Parse(HTextBoxExDoorNumber.Text) : 0; // ドア番号
            hCarMasterVo.RegistrationNumber1 = HComboBoxExRegistrationNumber1.Text; // 車両ナンバー１
            hCarMasterVo.RegistrationNumber2 = HTextBoxExRegistrationNumber2.Text; // 車両ナンバー２
            hCarMasterVo.RegistrationNumber3 = HTextBoxExRegistrationNumber3.Text; // 車両ナンバー３
            hCarMasterVo.RegistrationNumber4 = HTextBoxExRegistrationNumber4.Text; // 車両ナンバー４
            hCarMasterVo.ClassificationCode = dictionaryClassificationCode[HComboBoxExClassificationCode.Text]; // 使用区分
            hCarMasterVo.GarageCode = dictionaryGarageCode[HComboBoxExGarageCode.Text]; // 車庫地
            hCarMasterVo.DisguiseKind1 = HComboBoxExDisguiseKind1.Text; // 仮装の名称(システム表示)
            hCarMasterVo.DisguiseKind2 = HComboBoxExDisguiseKind2.Text; // 仮装の名称(事故報告書)
            hCarMasterVo.DisguiseKind3 = HComboBoxExDisguiseKind3.Text; // 仮装の名称(整備工場等)
            /*
             * １．基本情報
             */
            hCarMasterVo.VehicleNumber = HTextBoxExVehicleNumber.Text; // 車台番号
            hCarMasterVo.RegistrationDate = HDateTimePickerExRegistrationDate.GetValue().Date; // 登録年月日/交付年月日
            hCarMasterVo.FirstRegistrationDate = HDateTimePickerExFirstRegistrationDate.GetValue().Date; // 初度登録年月
            hCarMasterVo.ExpirationDate = HDateTimePickerExExpirationDate.GetValue().Date; // 有効期限の満了する日
            /*
             * ２．所有者・使用者情報
             */
            hCarMasterVo.OwnerName = HComboBoxExOwnerName.Text; // 所有者の氏名又は名称
            hCarMasterVo.OwnerAddress = HComboBoxExOwnerAddress.Text; // 所有者の住所
            hCarMasterVo.UserName = HComboBoxExUserName.Text; // 使用者の氏名又は名称
            hCarMasterVo.UserAddress = HComboBoxExUserAddress.Text; // 使用者の住所
            hCarMasterVo.BaseAddress = HComboBoxExBaseAddress.Text; // 使用の本拠の位置
            /*
             * ３．車両詳細情報
             */
            hCarMasterVo.ManufacturerCode = dictionaryManufacturerCode[HComboBoxExManufacturerCode.Text]; // 車名
            hCarMasterVo.Version = HTextBoxExVersion.Text; // 型式
            hCarMasterVo.MotorVersion = HTextBoxExMotorVersion.Text; // 原動機の型式
            hCarMasterVo.CarKindCode = dictionaryCarKindCode[HComboBoxExCarKindCode.Text]; // 自動車の種別
            hCarMasterVo.CarUse = HComboBoxExCarUse.Text; // 用途
            hCarMasterVo.OtherCode = dictionaryOtherCode[HComboBoxExOtherCode.Text]; // 自家用・事業用の別
            hCarMasterVo.ShapeCode = dictionaryShapeCode[HComboBoxExShapeCode.Text]; // 車体の形状
            hCarMasterVo.Capacity = HNumericUpDownExCapacity.Value; // 乗車定員
            hCarMasterVo.MaximumLoadCapacity = HNumericUpDownExMaximumLoadCapacity.Value; // 最大積載量
            hCarMasterVo.VehicleWeight = HNumericUpDownExVehicleWeight.Value; // 車両重量
            hCarMasterVo.TotalVehicleWeight = HNumericUpDownExTotalVehicleWeight.Value; // 車両総重量
            hCarMasterVo.Length = HNumericUpDownExLength.Value; // 長さ
            hCarMasterVo.Width = HNumericUpDownExWidth.Value; // 幅
            hCarMasterVo.Height = HNumericUpDownExHeight.Value; // 高さ 
            hCarMasterVo.FfAxisWeight = HNumericUpDownExFfAxisWeight.Value; // 前前軸重
            hCarMasterVo.FrAxisWeight = HNumericUpDownExFrAxisWeight.Value; // 前後軸重
            hCarMasterVo.RfAxisWeight = HNumericUpDownExRfAxisWeight.Value; // 後前軸重
            hCarMasterVo.RrAxisWeight = HNumericUpDownExRrAxisWeight.Value; // 後後軸重
            hCarMasterVo.TotalDisplacement = HNumericUpDownExTotalDisplacement.Value; // 総排気量又は定格出力
            hCarMasterVo.TypesOfFuel = HComboBoxExTypesOfFuel.Text; // 燃料の種類
            hCarMasterVo.VersionDesignateNumber = HTextBoxExVersionDesignateNumber.Text; // 型式指定番号
            hCarMasterVo.CategoryDistinguishNumber = HTextBoxExCategoryDistinguishNumber.Text; // 類別区分番号
            hCarMasterVo.Remarks = HTextBoxExRemarks.Text; // 備考

            hCarMasterVo.Picture = (byte[]?)new ImageConverter().ConvertTo(HPictureBoxExPicture.Image, typeof(byte[]));

            return hCarMasterVo;
        }

        /// <summary>
        /// VoをControlにセット
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        private void SetControl(H_CarMasterVo hCarMasterVo) {
            /*
             * システム情報
             */
            HTextBoxExCarCode.Text = hCarMasterVo.CarCode.ToString("#####"); // 車両コード
            HTextBoxExRegistrationNumber.Text = hCarMasterVo.RegistrationNumber; // 車両ナンバー
            HTextBoxExDoorNumber.Text = hCarMasterVo.DoorNumber.ToString("#####"); // ドア番号
            HComboBoxExRegistrationNumber1.Text = hCarMasterVo.RegistrationNumber1; // 車両ナンバー１
            HTextBoxExRegistrationNumber2.Text = hCarMasterVo.RegistrationNumber2; // 車両ナンバー２
            HTextBoxExRegistrationNumber3.Text = hCarMasterVo.RegistrationNumber3; // 車両ナンバー３
            HTextBoxExRegistrationNumber4.Text = hCarMasterVo.RegistrationNumber4; // 車両ナンバー４
            HComboBoxExClassificationCode.Text = dictionaryClassificationName[hCarMasterVo.ClassificationCode]; // 使用区分
            HComboBoxExGarageCode.Text = dictionaryGarageName[hCarMasterVo.GarageCode]; // 車庫地
            HComboBoxExDisguiseKind1.Text = hCarMasterVo.DisguiseKind1; // 仮装の名称(システム表示)
            HComboBoxExDisguiseKind2.Text = hCarMasterVo.DisguiseKind2; // 仮装の名称(事故報告書)
            HComboBoxExDisguiseKind3.Text = hCarMasterVo.DisguiseKind3; // 仮装の名称(整備工場等)
            /*
             * １．基本情報
             */
            HTextBoxExVehicleNumber.Text = hCarMasterVo.VehicleNumber; // 車台番号
            HDateTimePickerExRegistrationDate.SetValueJp(hCarMasterVo.RegistrationDate.Date); // 登録年月日/交付年月日
            HDateTimePickerExFirstRegistrationDate.SetValueJp(hCarMasterVo.FirstRegistrationDate.Date); // 初度登録年月
            HDateTimePickerExExpirationDate.SetValueJp(hCarMasterVo.ExpirationDate.Date); // 有効期限の満了する日
            /*
             * ２．所有者・使用者情報
             */
            HComboBoxExOwnerName.Text = hCarMasterVo.OwnerName; // 所有者の氏名又は名称
            HComboBoxExOwnerAddress.Text = hCarMasterVo.OwnerAddress; // 所有者の住所
            HComboBoxExUserName.Text = hCarMasterVo.UserName; // 使用者の氏名又は名称
            HComboBoxExUserAddress.Text = hCarMasterVo.UserAddress; // 使用者の住所
            HComboBoxExBaseAddress.Text = hCarMasterVo.BaseAddress; // 使用の本拠の位置
            /*
             * ３．車両詳細情報
             */
            HComboBoxExManufacturerCode.Text = dictionaryManufacturerName[hCarMasterVo.ManufacturerCode]; // 車名
            HTextBoxExVersion.Text = hCarMasterVo.Version; // 型式
            HTextBoxExMotorVersion.Text = hCarMasterVo.MotorVersion; // 原動機の型式
            HComboBoxExCarKindCode.Text = dictionaryCarKindName[hCarMasterVo.CarKindCode]; // 自動車の種別
            HComboBoxExCarUse.Text = hCarMasterVo.CarUse; // 用途
            HComboBoxExOtherCode.Text = dictionaryOtherName[hCarMasterVo.OtherCode]; // 自家用・事業用の別
            HComboBoxExShapeCode.Text = dictionaryShapeName[hCarMasterVo.ShapeCode]; // 車体の形状
            HNumericUpDownExCapacity.Value = hCarMasterVo.Capacity; // 乗車定員
            HNumericUpDownExMaximumLoadCapacity.Value = hCarMasterVo.MaximumLoadCapacity; // 最大積載量
            HNumericUpDownExVehicleWeight.Value = hCarMasterVo.VehicleWeight; // 車両重量
            HNumericUpDownExTotalVehicleWeight.Value = hCarMasterVo.TotalVehicleWeight; // 車両総重量
            HNumericUpDownExLength.Value = hCarMasterVo.Length; // 長さ
            HNumericUpDownExWidth.Value = hCarMasterVo.Width; // 幅
            HNumericUpDownExHeight.Value = hCarMasterVo.Height; // 高さ 
            HNumericUpDownExFfAxisWeight.Value = hCarMasterVo.FfAxisWeight; // 前前軸重
            HNumericUpDownExFrAxisWeight.Value = hCarMasterVo.FrAxisWeight; // 前後軸重
            HNumericUpDownExRfAxisWeight.Value = hCarMasterVo.RfAxisWeight; // 後前軸重
            HNumericUpDownExRrAxisWeight.Value = hCarMasterVo.RrAxisWeight; // 後後軸重
            HNumericUpDownExTotalDisplacement.Value = hCarMasterVo.TotalDisplacement; // 総排気量又は定格出力
            HComboBoxExTypesOfFuel.Text = hCarMasterVo.TypesOfFuel; // 燃料の種類
            HTextBoxExVersionDesignateNumber.Text = hCarMasterVo.VersionDesignateNumber; // 型式指定番号
            HTextBoxExCategoryDistinguishNumber.Text = hCarMasterVo.CategoryDistinguishNumber; // 類別区分番号
            HTextBoxExRemarks.Text = hCarMasterVo.Remarks; // 備考
            if (hCarMasterVo.Picture.Length != 0) {
                ImageConverter imageConverter = new();
                HPictureBoxExPicture.Image = (Image?)imageConverter.ConvertFrom(hCarMasterVo.Picture); // 写真
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
        /// HButtonEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonEx_Click(object sender, EventArgs e) {
            switch (((H_ButtonEx)sender).Name) {
                case "HButtonExClip":
                    /*
                     * クリップボードを転送
                     * なんか型のチェックはいらなさそう・・・エラーが出ないし・・・
                     */
                    HPictureBoxExPicture.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                case "HButtonExDelete":
                    HPictureBoxExPicture.Image = null;
                    break;
                case "HButtonExUpdate":
                    DialogResult dialogResult = MessageBox.Show("データを更新します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    H_CarMasterVo hCarMasterVo = SetVo();
                    switch (dialogResult) {
                        case DialogResult.OK:
                            if (_hCarMasterDao.ExistenceHCarMaster(hCarMasterVo.CarCode)) {
                                try {
                                    _hCarMasterDao.UpdateOneHCarMaster(SetVo());
                                    ToolStripStatusLabelDetail.Text = "UPDATEが完了しました。";
                                } catch (Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                            } else {
                                try {
                                    _hCarMasterDao.InsertOneHCarMaster(SetVo());
                                    ToolStripStatusLabelDetail.Text = "INSERTが完了しました。";
                                } catch (Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                            }
                            Close();
                            break;
                        case DialogResult.Cancel:
                            ToolStripStatusLabelDetail.Text = "処理を中止しました。";
                            break;
                    }
                    break;
                case "HButtonExRotate":
                    this.HPictureBoxExPicture.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    this.HPictureBoxExPicture.Refresh();
                    break;
            }
        }

        /// <summary>
        /// HCarDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarDetail_FormClosing(object sender, FormClosingEventArgs e) {
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
