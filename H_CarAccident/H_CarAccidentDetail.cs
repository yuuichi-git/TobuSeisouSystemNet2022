/*
 * 2024-05-09
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_CarAccident {
    public partial class H_CarAccidentDetail : Form {
        /*
         * Dao
         */
        private readonly H_CarAccidentMasterDao _hCarAccidentMasterDao;
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        /*
         * Vo
         */
        private H_CarAccidentMasterVo _hCarAccidentMasterVo;

        private H_PictureBoxEx[] _arrayHPictureBoxEx = new H_PictureBoxEx[8];

        /// <summary>
        /// コンストラクター（新規）
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_CarAccidentDetail(ConnectionVo connectionVo) {
            /*
             * Dao 
             */
            _hCarAccidentMasterDao = new(connectionVo);
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            _arrayHPictureBoxEx = new H_PictureBoxEx[] { HPictureBoxEx1, HPictureBoxEx2, HPictureBoxEx3, HPictureBoxEx4, HPictureBoxEx5, HPictureBoxEx6, HPictureBoxEx7, HPictureBoxEx8 };
            this.InitializeControl();
            HDateTimePickerExOccurrence.Enabled = true;
            HMaskedTextBoxExTime.Enabled = true;
        }

        /// <summary>
        /// コンストラクター（修正）
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hCarAccidentMasterVo"></param>
        public H_CarAccidentDetail(ConnectionVo connectionVo, H_CarAccidentMasterVo hCarAccidentMasterVo) {
            /*
             * Dao 
             */
            _hCarAccidentMasterDao = new(connectionVo);
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _hCarAccidentMasterVo = hCarAccidentMasterVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            _arrayHPictureBoxEx = new H_PictureBoxEx[] { HPictureBoxEx1, HPictureBoxEx2, HPictureBoxEx3, HPictureBoxEx4, HPictureBoxEx5, HPictureBoxEx6, HPictureBoxEx7, HPictureBoxEx8 };
            this.InitializeControl();
            HDateTimePickerExOccurrence.Enabled = false;
            HMaskedTextBoxExTime.Enabled = false;
            try {
                this.ControlOutPut(_hCarAccidentMasterDao.SelectOneHCarAccidentMaster(hCarAccidentMasterVo.StaffCode, hCarAccidentMasterVo.OccurrenceYmdHms));
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            /*
             * バリデーション
             */



            DialogResult dialogResult = MessageBox.Show("データを更新します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            switch (dialogResult) {
                case DialogResult.OK:
                    // DBを変更(DBにinsert_ymd_hmsが存在すればUPDATE、無ければINSERT)
                    if (_hCarAccidentMasterDao.ExistenceHCarAccidentMaster(SetHCarAccidentMasterVo())) {
                        try {
                            _hCarAccidentMasterDao.UpdateOneHCarAccidentMaster(SetHCarAccidentMasterVo());
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    } else {
                        try {
                            _hCarAccidentMasterDao.InsertOneHCarAccidentMaster(SetHCarAccidentMasterVo());
                        } catch (Exception exception) {
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
        /// SetHCarAccidentMasterVo
        /// </summary>
        /// <returns></returns>
        private H_CarAccidentMasterVo SetHCarAccidentMasterVo() {
            // ComboBox.SelectItemからVoを取得する
            H_StaffMasterVo hStaffMasterVo = ((ComboBoxSelectStaffLedgerVo)ComboBoxSelectDisplayName.SelectedItem).HStaffMasterVo;

            H_CarAccidentMasterVo hCarAccidentMasterVo = new();
            // 集計
            hCarAccidentMasterVo.TotallingFlag = RadioButtonTotallingTrue.Checked;
            // 事故発生年月日
            hCarAccidentMasterVo.OccurrenceYmdHms = new DateTime(HDateTimePickerExOccurrence.Value.Year,
                                                                 HDateTimePickerExOccurrence.Value.Month,
                                                                 HDateTimePickerExOccurrence.Value.Day,
                                                                 int.Parse(HMaskedTextBoxExTime.Text.Substring(0, 2)),
                                                                 int.Parse(HMaskedTextBoxExTime.Text.Substring(2, 2)),
                                                                 0);
            // 天候
            foreach (RadioButton radioButton in GroupBoxWeather.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.Weather = radioButton.Text;
            }
            // 事故の種別 
            foreach (RadioButton radioButton in GroupBoxAccidentKind.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.AccidentKind = radioButton.Text;
            }
            // 車両の静動
            foreach (RadioButton radioButton in GroupBoxCarStatic.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.CarStatic = radioButton.Text;
            }
            // 事故の発生原因　
            foreach (RadioButton radioButton in GroupBoxOccurrenceCause.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.OccurrenceCause = radioButton.Text;
            }
            // 過失の有無 
            foreach (RadioButton radioButton in GroupBoxNegligence.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.Negligence = radioButton.Text;
            }
            // 人身事故の詳細　
            foreach (RadioButton radioButton in GroupBoxPersonalInjury.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.PersonalInjury = radioButton.Text;
            }
            // 物件事故の詳細1 
            foreach (RadioButton radioButton in PanelPropertyAccident1.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.PropertyAccident1 = radioButton.Text;
            }
            // 物件事故の詳細2
            foreach (RadioButton radioButton in PanelPropertyAccident2.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.PropertyAccident2 = radioButton.Text;
            }
            // 事故の発生場所
            hCarAccidentMasterVo.OccurrenceAddress = TextBoxOccurrenceAddress.Text;
            // 運転手・作業員の別 
            foreach (RadioButton radioButton in PanelWorkKind.Controls) {
                if (radioButton.Checked)
                    hCarAccidentMasterVo.WorkKind = radioButton.Text;
            }
            // 運転手・作業員の氏名
            if (hStaffMasterVo is not null) {
                hCarAccidentMasterVo.StaffCode = hStaffMasterVo.StaffCode;
                hCarAccidentMasterVo.DisplayName = hStaffMasterVo.DisplayName;
                // 免許証番号
                hCarAccidentMasterVo.LicenseNumber = hStaffMasterVo.HLicenseMasterVo.LicenseNumber;
                // 車両登録番号
                hCarAccidentMasterVo.CarRegistrationNumber = ComboBoxSelectCarRegistrationNumber.Text;
                // 事故概要
                hCarAccidentMasterVo.AccidentSummary = TextBoxAccidentSummary.Text;
                // 事故詳細
                hCarAccidentMasterVo.AccidentDetail = TextBoxAccidentDetail.Text;
                // 事故後の指導
                hCarAccidentMasterVo.Guide = TextBoxGuide.Text;
                // PictureBoxPicture1
                hCarAccidentMasterVo.Picture1 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx1.Image, typeof(byte[]));
                // PictureBoxPicture2
                hCarAccidentMasterVo.Picture2 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx2.Image, typeof(byte[]));
                // PictureBoxPicture3
                hCarAccidentMasterVo.Picture3 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx3.Image, typeof(byte[]));
                // PictureBoxPicture4
                hCarAccidentMasterVo.Picture4 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx4.Image, typeof(byte[]));
                // PictureBoxPicture5
                hCarAccidentMasterVo.Picture5 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx5.Image, typeof(byte[]));
                // PictureBoxPicture6
                hCarAccidentMasterVo.Picture6 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx6.Image, typeof(byte[]));
                // PictureBoxPicture7
                hCarAccidentMasterVo.Picture7 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx7.Image, typeof(byte[]));
                // PictureBoxPicture8
                hCarAccidentMasterVo.Picture8 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx8.Image, typeof(byte[]));
            }
            return hCarAccidentMasterVo;
        }

        /// <summary>
        /// ControlOutPut
        /// </summary>
        /// <param name="hCarAccidentMasterVo"></param>
        private void ControlOutPut(H_CarAccidentMasterVo hCarAccidentMasterVo) {
            // 事故発生日時
            HDateTimePickerExOccurrence.SetValueJp(hCarAccidentMasterVo.OccurrenceYmdHms);
            HMaskedTextBoxExTime.Text = hCarAccidentMasterVo.OccurrenceYmdHms.ToString("HH:mm");
            // 集計表に反映
            switch (hCarAccidentMasterVo.TotallingFlag) {
                case true:
                    RadioButtonTotallingTrue.Checked = true;
                    break;
                case false:
                    RadioButtonTotallingFalse.Checked = true;
                    break;
            }
            // 天候
            switch (hCarAccidentMasterVo.Weather) {
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
            switch (hCarAccidentMasterVo.AccidentKind) {
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
            switch (hCarAccidentMasterVo.CarStatic) {
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
            switch (hCarAccidentMasterVo.OccurrenceCause) {
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
            switch (hCarAccidentMasterVo.Negligence) {
                case "過失なし":
                    radioButton33.Checked = true;
                    break;
                case "過失あり":
                    radioButton28.Checked = true;
                    break;
            }
            // 人身の詳細
            switch (hCarAccidentMasterVo.PersonalInjury) {
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
            switch (hCarAccidentMasterVo.PropertyAccident1) {
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
            switch (hCarAccidentMasterVo.PropertyAccident2) {
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
            TextBoxOccurrenceAddress.Text = hCarAccidentMasterVo.OccurrenceAddress;
            // 運転手・作業員の別
            switch (hCarAccidentMasterVo.WorkKind) {
                case "運転手":
                    RadioButtonDriver.Checked = true;
                    break;
                case "作業員":
                    RadioButtonOperator.Checked = true;
                    break;
            }
            // 運転手・作業員の氏名
            ComboBoxSelectDisplayName.Text = hCarAccidentMasterVo.DisplayName;
            // 免許証番号
            TextBoxLicenseNumber.Text = hCarAccidentMasterVo.LicenseNumber;
            // 車両登録番号
            ComboBoxSelectCarRegistrationNumber.Text = hCarAccidentMasterVo.CarRegistrationNumber;
            // 事故概要
            TextBoxAccidentSummary.Text = hCarAccidentMasterVo.AccidentSummary;
            // 事故詳細
            TextBoxAccidentDetail.Text = hCarAccidentMasterVo.AccidentDetail;
            // 事故後の指導
            TextBoxGuide.Text = hCarAccidentMasterVo.Guide;
            // 写真
            if (hCarAccidentMasterVo.Picture1 is not null && hCarAccidentMasterVo.Picture1.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx1.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture1);
            } else {
                HPictureBoxEx1.Image = null;
            }
            if (hCarAccidentMasterVo.Picture2 is not null && hCarAccidentMasterVo.Picture2.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx2.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture2);
            } else {
                HPictureBoxEx2.Image = null;
            }
            if (hCarAccidentMasterVo.Picture3 is not null && hCarAccidentMasterVo.Picture3.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx3.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture3);
            } else {
                HPictureBoxEx3.Image = null;
            }
            if (hCarAccidentMasterVo.Picture4 is not null && hCarAccidentMasterVo.Picture4.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx4.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture4);
            } else {
                HPictureBoxEx4.Image = null;
            }
            if (hCarAccidentMasterVo.Picture5 is not null && hCarAccidentMasterVo.Picture5.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx5.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture5);
            } else {
                HPictureBoxEx5.Image = null;
            }
            if (hCarAccidentMasterVo.Picture6 is not null && hCarAccidentMasterVo.Picture6.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx6.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture6);
            } else {
                HPictureBoxEx6.Image = null;
            }
            if (hCarAccidentMasterVo.Picture7 is not null && hCarAccidentMasterVo.Picture7.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx7.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture7);
            } else {
                HPictureBoxEx7.Image = null;
            }
            if (hCarAccidentMasterVo.Picture8 is not null && hCarAccidentMasterVo.Picture8.Length != 0) {
                var imageConv = new ImageConverter();
                HPictureBoxEx8.Image = (Image)imageConv.ConvertFrom(hCarAccidentMasterVo.Picture8);
            } else {
                HPictureBoxEx8.Image = null;
            }
        }

        /// <summary>
        /// InitializeControl
        /// </summary>
        private void InitializeControl() {
            // 事故発生年月日
            HDateTimePickerExOccurrence.SetValueJp(DateTime.Now);
            HMaskedTextBoxExTime.Text = DateTime.Now.ToString("HH:mm");
            // 集計表に反映
            RadioButtonTotallingTrue.Checked = false;
            RadioButtonTotallingFalse.Checked = false;
            // 天候
            foreach (RadioButton radioButton in GroupBoxWeather.Controls)
                radioButton.Checked = false;
            // 事故の種別
            foreach (RadioButton radioButton in GroupBoxAccidentKind.Controls)
                radioButton.Checked = false;
            // 車両の静動
            foreach (RadioButton radioButton in GroupBoxCarStatic.Controls)
                radioButton.Checked = false;
            // 事故の発生原因
            foreach (RadioButton radioButton in GroupBoxOccurrenceCause.Controls)
                radioButton.Checked = false;
            // 過失の有無
            foreach (RadioButton radioButton in GroupBoxNegligence.Controls)
                radioButton.Checked = false;
            // 人身の詳細
            foreach (RadioButton radioButton in GroupBoxPersonalInjury.Controls)
                radioButton.Checked = false;
            // 物件の詳細
            foreach (RadioButton radioButton in PanelPropertyAccident1.Controls)
                radioButton.Checked = false;
            foreach (RadioButton radioButton in PanelPropertyAccident2.Controls)
                radioButton.Checked = false;
            // 発生場所
            TextBoxOccurrenceAddress.Text = string.Empty;
            // 運転手・作業員の別
            foreach (RadioButton radioButton in PanelWorkKind.Controls)
                radioButton.Checked = false;
            // 運転手・作業員の氏名
            InitializeComboBoxSelectDisplayName();
            // 免許証番号
            TextBoxLicenseNumber.Text = string.Empty;
            // 車両登録番号
            InitializeComboBoxSelectCarRegistrationNumber();
            // 事故概要
            TextBoxAccidentSummary.Text = string.Empty;
            // 事故詳細
            TextBoxAccidentDetail.Text = string.Empty;
            // 事故後の指導
            TextBoxGuide.Text = string.Empty;
            // 写真
            foreach (H_PictureBoxEx hPictureBoxEx in _arrayHPictureBoxEx)
                hPictureBoxEx.Image = null;
        }

        /// <summary>
        /// ComboBoxSelectNameを初期化
        /// </summary>
        private void InitializeComboBoxSelectDisplayName() {
            ComboBoxSelectDisplayName.Items.Clear();
            foreach (H_StaffMasterVo hStaffMasterVo in _hStaffMasterDao.SelectAllHStaffMaster().OrderBy(x => x.NameKana))
                ComboBoxSelectDisplayName.Items.Add(new ComboBoxSelectStaffLedgerVo(hStaffMasterVo.DisplayName, hStaffMasterVo));
            ComboBoxSelectDisplayName.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// 内部クラス
        /// ComboBoxSelectStaffLedgerVo
        /// </summary>
        private class ComboBoxSelectStaffLedgerVo {
            private string _displayName;
            private H_StaffMasterVo _hStaffMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectStaffLedgerVo(string displayName, H_StaffMasterVo hStaffMasterVo) {
                _displayName = displayName;
                _hStaffMasterVo = hStaffMasterVo;
            }
            public string DisplayName {
                get => _displayName;
                set => _displayName = value;
            }
            public H_StaffMasterVo HStaffMasterVo {
                get => _hStaffMasterVo;
                set => _hStaffMasterVo = value;
            }
        }

        /// <summary>
        /// ComboBoxSelectCarRegistrationNumberを初期化
        /// </summary>
        private void InitializeComboBoxSelectCarRegistrationNumber() {
            ComboBoxSelectCarRegistrationNumber.Items.Clear();
            foreach (H_CarMasterVo hCarMasterVo in _hCarMasterDao.SelectAllHCarMaster().OrderBy(x => x.RegistrationNumber4))
                ComboBoxSelectCarRegistrationNumber.Items.Add(new ComboBoxSelectCarLedgerVo(hCarMasterVo.RegistrationNumber, hCarMasterVo));
            ComboBoxSelectCarRegistrationNumber.DisplayMember = "RegistrationNumber";
        }

        /// <summary>
        /// 内部クラス
        /// </summary>
        private class ComboBoxSelectCarLedgerVo {
            private string _registrationNumber;
            private H_CarMasterVo _hCarMasterVo;

            // プロパティをコンストラクタでセット
            public ComboBoxSelectCarLedgerVo(string registrationNumber, H_CarMasterVo hCarMasterVo) {
                _registrationNumber = registrationNumber;
                _hCarMasterVo = hCarMasterVo;
            }
            public string RegistrationNumber {
                get => _registrationNumber;
                set => _registrationNumber = value;
            }
            public H_CarMasterVo HCarMasterVo {
                get => _hCarMasterVo;
                set => _hCarMasterVo = value;
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
        /// H_CarAccidentDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CarAccidentDetail_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
