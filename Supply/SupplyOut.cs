/*
 * 2023-06-05
 */
using Dao;

using Vo;

namespace Supply {
    public partial class SupplyOut : Form {
        private readonly SupplyDao _supplyDao;
        private readonly ConnectionVo _connectionVo;
        private readonly Panel[] _panels = new Panel[5];
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
        public SupplyOut(ConnectionVo connectionVo, string affiliation) {
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
            LabelAffiliation.Text = affiliation;
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
            SupplyMoveVo supplyMoveVo = new SupplyMoveVo();
            // 作業着　上
            foreach(RadioButton radioButton in PanelWorkwearUp.Controls) {
                if(radioButton.Checked) {
                    _workwearUpFlag = true;
                    _workwearUpCode = (int)radioButton.Tag;
                }
            }
            // 作業着　下
            foreach(RadioButton radioButton in PanelWorkwearDown.Controls) {
                if(radioButton.Checked) {
                    _workwearDownFlag = true;
                    _workwearDownCode = (int)radioButton.Tag;
                }
            }
            // ヘルメット
            foreach(RadioButton radioButton in PanelHelmet.Controls) {
                if(radioButton.Checked) {
                    _helmetFlag = true;
                    _helmetCode = (int)radioButton.Tag;
                }
            }
            // 帽子
            foreach(RadioButton radioButton in PanelHat.Controls) {
                if(radioButton.Checked) {
                    _hatFlag = true;
                    _hatCode = (int)radioButton.Tag;
                }
            }
            // 安全靴
            if(ComboBoxSafetyShose.Text.Length > 0) {
                _safetyShoseFlag = true;
                _safetyShoseCode = _dictionarySafetyShoseCode[ComboBoxSafetyShose.Text];
            }
            // 長靴
            if(ComboBoxLongShose.Text.Length > 0) {
                _longShoseFlag = true;
                _longShoseCode = _dictionaryLongShoseCode[ComboBoxLongShose.Text];
            }
            // 手袋
            foreach(RadioButton radioButton in PanelGlove.Controls) {
                if(radioButton.Checked) {
                    _gloveFlag = true;
                    _gloveCode = (int)radioButton.Tag;
                }
            }


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

        }
    }
}
