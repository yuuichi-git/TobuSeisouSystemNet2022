/*
 * 2023-06-05
 */
using Dao;

using Vo;

namespace Supply {
    public partial class SupplyOut : Form {
        private int _staffCode;
        private string _affiliationValue;
        private readonly Panel[] _panels = new Panel[5];
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "事務での備品", 1000 },
                                                                                                             { "雇上での備品", 2000 },
                                                                                                             { "産廃での備品", 3000 },
                                                                                                             { "水物での備品", 4000 } };
        /*
         * Dao
         */
        private readonly SupplyDao _supplyDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private SupplyMoveVo _supplyMoveVo;
        /*
         * 作業着　上
         */
        private bool _workwearUpFlag = false;
        private int _workwearUpCode = 0;
        /*
         * 作業着　下
         */
        private bool _workwearDownFlag = false;
        private int _workwearDownCode = 0;
        /*
         * ヘルメット
         */
        private bool _helmetFlag = false;
        private int _helmetCode = 0;
        /*
         * 帽子
         */
        private bool _hatFlag = false;
        private int _hatCode = 0;
        /*
         * 安全靴
         */
        private bool _safetyShoseFlag = false;
        private int _safetyShoseCode = 0;
        private readonly Dictionary<string, int> _dictionarySafetyShoseCode = new Dictionary<string, int> { { "24.0", 501 },
                                                                                                            { "24.5", 502 },
                                                                                                            { "25.0", 503 },
                                                                                                            { "25.5", 504 },
                                                                                                            { "26.0", 505 },
                                                                                                            { "26.5", 506 },
                                                                                                            { "27.0", 507 },
                                                                                                            { "27.5", 508 },
                                                                                                            { "28.0", 509 } };
        /*
         * 長靴
         */
        private bool _longShoseFlag = false;
        private int _longShoseCode = 0;
        private readonly Dictionary<string, int> _dictionaryLongShoseCode = new Dictionary<string, int> { { "24.0", 601 },
                                                                                                          { "24.5", 602 },
                                                                                                          { "25.0", 603 },
                                                                                                          { "25.5", 604 },
                                                                                                          { "26.0", 605 },
                                                                                                          { "26.5", 606 },
                                                                                                          { "27.0", 607 },
                                                                                                          { "27.5", 608 },
                                                                                                          { "28.0", 609 } };
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
        public SupplyOut(ConnectionVo connectionVo, string affiliation, int staffCode) {
            _affiliationValue = affiliation;
            _staffCode = staffCode;
            /*
             * Dao
             */
            _supplyDao = new SupplyDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Control初期化
             */
            InitializeComponent();
            _panels = new Panel[] { PanelWorkwearUp, PanelWorkwearDown, PanelHelmet, PanelHat, PanelGlove };
            LabelAffiliation.Text = _affiliationValue;
            // RadioButtonのチェック状態を設定
            InitializeRadioButton();
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            /*
             * 値をVoへ代入する
             */
            // 作業着　上
            foreach(RadioButton radioButton in PanelWorkwearUp.Controls) {
                if(radioButton.Checked) {
                    _workwearUpFlag = true;
                    _workwearUpCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_workwearUpFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _workwearUpCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
            }
            // 作業着　下
            foreach(RadioButton radioButton in PanelWorkwearDown.Controls) {
                if(radioButton.Checked) {
                    _workwearDownFlag = true;
                    _workwearDownCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_workwearDownFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _workwearDownCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
            }
            // ヘルメット
            foreach(RadioButton radioButton in PanelHelmet.Controls) {
                if(radioButton.Checked) {
                    _helmetFlag = true;
                    _helmetCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_helmetFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _helmetCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
            }
            // 帽子
            foreach(RadioButton radioButton in PanelHat.Controls) {
                if(radioButton.Checked) {
                    _hatFlag = true;
                    _hatCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_hatFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _hatCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
            }
            // 安全靴
            if(ComboBoxSafetyShose.Text.Length > 0) {
                _safetyShoseFlag = true;
                _safetyShoseCode = _dictionarySafetyShoseCode[ComboBoxSafetyShose.Text];
            }
            if(_safetyShoseFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _safetyShoseCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
            }
            // 長靴
            if(ComboBoxLongShose.Text.Length > 0) {
                _longShoseFlag = true;
                _longShoseCode = _dictionaryLongShoseCode[ComboBoxLongShose.Text];
            }
            if(_longShoseFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _longShoseCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
            }
            // 手袋
            foreach(RadioButton radioButton in PanelGlove.Controls) {
                if(radioButton.Checked) {
                    _gloveFlag = true;
                    _gloveCode = int.Parse((string)radioButton.Tag) + _dictionaryAffiliationValue[_affiliationValue];
                }
            }
            if(_gloveFlag) {
                _supplyMoveVo = new SupplyMoveVo();
                _supplyMoveVo.Staff_code = _staffCode;
                _supplyMoveVo.Move_date = DateTime.Now.Date;
                _supplyMoveVo.Supply_code = _gloveCode;
                _supplyMoveVo.Supply_number = 1;
                _supplyMoveVo.Move_flag = false; // true:入庫 false:出庫
                _supplyMoveVo.Insert_pc_name = Environment.MachineName;
                _supplyMoveVo.Insert_ymd_hms = DateTime.Now;
                _supplyDao.InsertOneSupplyMove(_supplyMoveVo);
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
