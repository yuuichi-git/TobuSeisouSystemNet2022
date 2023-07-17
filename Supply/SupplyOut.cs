/*
 * 2023-06-05
 */
using Common;

using Dao;

using Vo;

namespace Supply {
    public partial class SupplyOut : Form {
        private int _staffCode;
        private string _affiliationValue;
        private readonly Panel[] _panels = new Panel[5];
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 10000 },
                                                                                                             { "雇上での備品", 20000 },
                                                                                                             { "産廃での備品", 30000 },
                                                                                                             { "水物での備品", 40000 } };
        /*
         * Dao
         */
        private readonly SupplyOutDao _supplyOutDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private SupplyMoveVo _supplyOutVo;

        /*
         * １・冬ブルゾン
         */
        private bool _winterBlousonFlag = false;
        private int _winterBlousonCode = 0;
        /*
         * ２・冬カーゴパンツ
         */
        private bool _winterCargoFlag = false;
        private int _winterCargoCode = 0;
        /*
         * ３・防寒衣
         */
        private bool _coldProtectionFlag = false;
        private int _coldProtectionCode = 0;
        /*
         * ４・熱中対策用ポケット付シャツ
         */
        private bool _summerShirtFlag = false;
        private int _summerShirtCode = 0;
        /*
         * ５・夏カーゴパンツ
         */
        private bool _summerCargoFlag = false;
        private int _summerCargoCode = 0;
        /*
         * ９・帽子
         */
        private bool _hatFlag = false;
        private int _hatCode = 0;
        /*
         * カッパ
         */
        private bool _rainCoatFlag = false;
        private int _rainCoatCode = 0;
        /*
         * ヘルメット
         */
        private bool _helmetFlag = false;
        private int _helmetCode = 0;
        /*
         * 安全靴
         */
        private bool _safetyShoseFlag = false;
        private int _safetyShoseCode = 0;
        private readonly Dictionary<string, int> _dictionarySafetyShoseCode = new Dictionary<string, int> { { "23.5", 2101 },
                                                                                                            { "24.0", 2102 },
                                                                                                            { "24.5", 2103 },
                                                                                                            { "25.0", 2104 },
                                                                                                            { "25.5", 2105 },
                                                                                                            { "26.0", 2106 },
                                                                                                            { "26.5", 2107 },
                                                                                                            { "27.0", 2108 },
                                                                                                            { "27.5", 2109 },
                                                                                                            { "28.0", 2110 } };
        /*
         * 長靴
         */
        private bool _longShoseFlag = false;
        private int _longShoseCode = 0;
        private readonly Dictionary<string, int> _dictionaryLongShoseCode = new Dictionary<string, int> { { "23.5", 2201 },
                                                                                                          { "24.0", 2202 },
                                                                                                          { "24.5", 2203 },
                                                                                                          { "25.0", 2204 },
                                                                                                          { "25.5", 2205 },
                                                                                                          { "26.0", 2206 },
                                                                                                          { "26.5", 2207 },
                                                                                                          { "27.0", 2208 },
                                                                                                          { "27.5", 2209 },
                                                                                                          { "28.0", 2210 } };
        /*
         * 手袋
         */
        private bool _gloveFlag = false;
        private int _gloveCode = 0;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="affiliation"></param>
        public SupplyOut(ConnectionVo connectionVo, string affiliation, StaffMasterVo staffMasterVo) {
            _affiliationValue = affiliation;
            _staffCode = staffMasterVo.Staff_code;
            /*
             * Dao
             */
            _supplyOutDao = new SupplyOutDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Control初期化
             */
            InitializeComponent();
            _panels = new Panel[] { PanelWinterBlouson, PanelWinterCargo, PanelColdProtection, PanelSummerShirt, PanelSummerCargo, PanelHat, PanelRainCoat, PanelHelmet, PanelGlove };
            LabelAffiliation.Text = string.Concat(staffMasterVo.Display_name, "   (", _affiliationValue, ")");
            // RadioButtonのチェック状態を設定
            InitializeRadioButton();
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // １・冬ブルゾン
            foreach(RadioButton radioButton in PanelWinterBlouson.Controls) {
                if(radioButton.Checked) {
                    _winterBlousonFlag = true;
                    _winterBlousonCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_winterBlousonFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _winterBlousonCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ２・冬カーゴパンツ
            foreach(RadioButton radioButton in PanelWinterCargo.Controls) {
                if(radioButton.Checked) {
                    _winterCargoFlag = true;
                    _winterCargoCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_winterCargoFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _winterCargoCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ３・防寒衣
            foreach(RadioButton radioButton in PanelColdProtection.Controls) {
                if(radioButton.Checked) {
                    _coldProtectionFlag = true;
                    _coldProtectionCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_coldProtectionFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _coldProtectionCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ４・熱中対策用ポケット付シャツ
            foreach(RadioButton radioButton in PanelSummerShirt.Controls) {
                if(radioButton.Checked) {
                    _summerShirtFlag = true;
                    _summerShirtCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_summerShirtFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _summerShirtCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ５・夏カーゴパンツ
            foreach(RadioButton radioButton in PanelSummerCargo.Controls) {
                if(radioButton.Checked) {
                    _summerCargoFlag = true;
                    _summerCargoCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_summerCargoFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _summerCargoCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ９・帽子
            foreach(RadioButton radioButton in PanelHat.Controls) {
                if(radioButton.Checked) {
                    _hatFlag = true;
                    _hatCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_hatFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _hatCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ９・カッパ
            foreach(RadioButton radioButton in PanelRainCoat.Controls) {
                if(radioButton.Checked) {
                    _rainCoatFlag = true;
                    _rainCoatCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_rainCoatFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _rainCoatCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // ヘルメット
            foreach(RadioButton radioButton in PanelHelmet.Controls) {
                if(radioButton.Checked) {
                    _helmetFlag = true;
                    _helmetCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_helmetFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _helmetCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // 安全靴
            if(ComboBoxSafetyShose.Text.Length > 0) {
                _safetyShoseFlag = true;
                _safetyShoseCode = _dictionarySafetyShoseCode[ComboBoxSafetyShose.Text] + _dictionaryAffiliationValue[_affiliationValue];
            }
            if(_safetyShoseFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _safetyShoseCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // 長靴
            if(ComboBoxLongShose.Text.Length > 0) {
                _longShoseFlag = true;
                _longShoseCode = _dictionaryLongShoseCode[ComboBoxLongShose.Text] + _dictionaryAffiliationValue[_affiliationValue];
            }
            if(_longShoseFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _longShoseCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            // 手袋
            foreach(RadioButton radioButton in PanelGlove.Controls) {
                if(radioButton.Checked) {
                    _gloveFlag = true;
                    _gloveCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_gloveFlag) {
                _supplyOutVo = new SupplyMoveVo();
                _supplyOutVo.Staff_code = _staffCode;
                _supplyOutVo.Move_date = DateTime.Now.Date;
                _supplyOutVo.Supply_code = _gloveCode;
                _supplyOutVo.Supply_number = 1;
                _supplyOutVo.Move_flag = false; // true:入庫 false:出庫
                _supplyOutVo.Memo = TextBoxMemo.Text;
                _supplyOutVo.Insert_pc_name = Environment.MachineName;
                _supplyOutVo.Insert_ymd_hms = DateTime.Now;
                try {
                    _supplyOutDao.InsertOneSupplyMove(_supplyOutVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }

            /*
             * 何も選択されていない場合の処理
             */
            if(!_winterBlousonFlag &&
               !_winterCargoFlag &&
               !_coldProtectionFlag &&
               !_summerShirtFlag &&
               !_summerCargoFlag &&
               !_hatFlag &&
               !_rainCoatFlag &&
               !_helmetFlag &&
               !_safetyShoseFlag &&
               !_longShoseFlag &&
               !_gloveFlag) {
                MessageBox.Show("何も選択されていません。終了します。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            this.Close();
        }

        /// <summary>
        /// InitializeRadioButton
        /// Checkedを全てFalseにする
        /// </summary>
        private void InitializeRadioButton() {
            foreach(Panel panel in _panels) {
                foreach(RadioButton radioButton in panel.Controls) {
                    radioButton.Checked = false;
                }
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
        /// SupplyOut_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplyOut_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}
