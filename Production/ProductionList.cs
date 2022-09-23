/*
 * 2022-09-18
 */
using Common;

using ControlEx;

using Dao;

using Vo;

namespace Production {
    public partial class ProductionList : Form {
        /// <summary>
        /// Connectionを保持
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// インスタンス作成
        /// </summary>
        private readonly InitializeForm _initializeForm = new();
        private readonly List<SetMasterVo> _listSetMasterVo = new();
        private readonly List<CarMasterVo> _listCarMasterVo = new();
        private readonly List<StaffMasterVo> _listStaffMasterVo = new();
        private readonly List<VehicleDispatchHeadVo> _listVehicleDispatchHeadVo = new();

        /// <summary>
        /// コントロール配列
        /// </summary>
        private readonly CheckBox[] _arrayCheckBoxWeek;
        private readonly ComboBox[] _arrayComboBoxCar;
        private readonly ComboBox[] _arrayComboBoxStaff1;
        private readonly ComboBox[] _arrayComboBoxStaff2;
        private readonly ComboBox[] _arrayComboBoxStaff3;
        private readonly ComboBox[] _arrayComboBoxStaff4;

        public ProductionList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * DBを読込
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMasterVo();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMasterVo();
            _listVehicleDispatchHeadVo = new VehicleDispatchHeadDao(connectionVo).SelectAllVehicleDispatchHeadVo();
            /*
             * Formを初期化する
             */
            InitializeComponent();
            _initializeForm.ProductionList(this);
            // TableLayoutPanelExを初期化
            TableLayoutPanelExCenter.Controls.Clear();
            CreateSetLabels();
            // Array作成
            _arrayCheckBoxWeek = new CheckBox[] { CheckBoxMonday, CheckBoxTuesday, CheckBoxWednesday, CheckBoxThursday, CheckBoxFriday, CheckBoxSaturday, CheckBoxSunday };
            _arrayComboBoxCar = new ComboBox[] { ComboBoxMondayCar, ComboBoxTuesdayCar, ComboBoxWednesdayCar, ComboBoxThursdayCar, ComboBoxFridayCar, ComboBoxSaturdayCar, ComboBoxSundayCar };
            _arrayComboBoxStaff1 = new ComboBox[] { ComboBoxMondayStaff1, ComboBoxTuesdayStaff1, ComboBoxWednesdayStaff1, ComboBoxThursdayStaff1, ComboBoxFridayStaff1, ComboBoxSaturdayStaff1, ComboBoxSundayStaff1 };
            _arrayComboBoxStaff2 = new ComboBox[] { ComboBoxMondayStaff2, ComboBoxTuesdayStaff2, ComboBoxWednesdayStaff2, ComboBoxThursdayStaff2, ComboBoxFridayStaff2, ComboBoxSaturdayStaff2, ComboBoxSundayStaff2 };
            _arrayComboBoxStaff3 = new ComboBox[] { ComboBoxMondayStaff3, ComboBoxTuesdayStaff3, ComboBoxWednesdayStaff3, ComboBoxThursdayStaff3, ComboBoxFridayStaff3, ComboBoxSaturdayStaff3, ComboBoxSundayStaff3 };
            _arrayComboBoxStaff4 = new ComboBox[] { ComboBoxMondayStaff4, ComboBoxTuesdayStaff4, ComboBoxWednesdayStaff4, ComboBoxThursdayStaff4, ComboBoxFridayStaff4, ComboBoxSaturdayStaff4, ComboBoxSundayStaff4 };

            ClearControls();
            InitializeComboBoxCarLedger();

        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// CreateSetLabels
        /// </summary>
        private void CreateSetLabels() {
            int i = 0;
            //レイアウトロジックを停止する
            TableLayoutPanelExCenter.SuspendLayout();
            foreach (var vehicleDispatchHeadVo in _listVehicleDispatchHeadVo.OrderBy(x => x.Cell_number)) {
                int column = (i % 25);
                int row = i / 25;
                int? setCode = vehicleDispatchHeadVo.Set_code;
                SetMasterVo? setMasterVo;
                if (setCode.HasValue) {
                    setMasterVo = _listSetMasterVo.Find(x => x.Set_code == setCode);
                    if (setMasterVo != null) {
                        var labelEx = new LabelEx().CreateLabel(setMasterVo);
                        labelEx.Tag = new NestedClassSetMasterVo(i + 1, setMasterVo);
                        labelEx.MouseClick += new MouseEventHandler(Label_MouseClick);
                        labelEx.MouseEnter += new EventHandler(Label_MouseEnter);
                        labelEx.MouseLeave += new EventHandler(Label_MouseLeave);
                        TableLayoutPanelExCenter.Controls.Add(labelEx, column, row);
                    }
                }
                i++;
            }
            //レイアウトロジックを再開する
            TableLayoutPanelExCenter.ResumeLayout();
        }

        /// <summary>
        /// NestedClassSetMasterVo
        /// </summary>
        private class NestedClassSetMasterVo {
            private int _cell_number;
            private SetMasterVo _setMasterVo = new();
            public NestedClassSetMasterVo(int cellNumber, SetMasterVo setMasterVo) {
                _cell_number = cellNumber;
                _setMasterVo = setMasterVo;
            }
            public int Cell_number {
                get => _cell_number;
                set => _cell_number = value;
            }
            public SetMasterVo SetMasterVo {
                get => _setMasterVo;
                set => _setMasterVo = value;
            }
        }

        /// <summary>
        /// InitializeComboBoxCarLedger
        /// </summary>
        private void InitializeComboBoxCarLedger() {
            foreach (var comboBox in _arrayComboBoxCar) {
                comboBox.Items.Clear();
                foreach (var carMasteVo in _listCarMasterVo.FindAll(x => x.Delete_flag == false))
                    comboBox.Items.Add(new NestedClassCarMasterVo(carMasteVo.Registration_number, carMasteVo));
                comboBox.DisplayMember = "RegistrationNumber";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        /// <summary>
        /// NestedClassCarMasterVo
        /// </summary>
        private class NestedClassCarMasterVo {
            private string _registrationNumber = "";
            private CarMasterVo _carMasterVo = new();
            // プロパティをコンストラクタでセット
            public NestedClassCarMasterVo(string registrationNumber, CarMasterVo carMasterVo) {
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
        /// InitializeComboBoxStaffLedger
        /// </summary>
        private void InitializeComboBoxStaffMaster1() {
            foreach (var comboBox in _arrayComboBoxStaff1) {
                comboBox.Items.Clear();
                foreach (var staffMasterVo in _listStaffMasterVo)
                    comboBox.Items.Add(new NestedClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void InitializeComboBoxStaffMaster2() {
            foreach (var comboBox in _arrayComboBoxStaff2) {
                comboBox.Items.Clear();
                foreach (var staffMasterVo in _listStaffMasterVo)
                    comboBox.Items.Add(new NestedClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void InitializeComboBoxStaffMaster3() {
            foreach (var comboBox in _arrayComboBoxStaff3) {
                comboBox.Items.Clear();
                foreach (var staffMasterVo in _listStaffMasterVo)
                    comboBox.Items.Add(new NestedClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void InitializeComboBoxStaffMaster4() {
            foreach (var comboBox in _arrayComboBoxStaff4) {
                comboBox.Items.Clear();
                foreach (var staffMasterVo in _listStaffMasterVo)
                    comboBox.Items.Add(new NestedClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        /// <summary>
        /// NestedClassStaffMasterVo
        /// </summary>
        private class NestedClassStaffMasterVo {
            private string _staffName = "";
            private StaffMasterVo _staffMasterVo = new();
            // プロパティをコンストラクタでセット
            public NestedClassStaffMasterVo(string staffName, StaffMasterVo staffMasterVo) {
                _staffName = staffName;
                _staffMasterVo = staffMasterVo;
            }
            public string StaffName {
                get => _staffName;
                set => _staffName = value;
            }
            public StaffMasterVo StaffMasterVo {
                get => _staffMasterVo;
                set => _staffMasterVo = value;
            }
        }

        /// <summary>
        /// ClearControls
        /// </summary>
        private void ClearControls() {
            foreach (var checkBox in _arrayCheckBoxWeek) {
                checkBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                checkBox.Checked = false;
            }
            foreach (var comboBox in _arrayComboBoxCar)
                comboBox.Text = "";
            foreach (var comboBox in _arrayComboBoxStaff1)
                comboBox.Text = "";
            foreach (var comboBox in _arrayComboBoxStaff2)
                comboBox.Text = "";
            foreach (var comboBox in _arrayComboBoxStaff3)
                comboBox.Text = "";
            foreach (var comboBox in _arrayComboBoxStaff4)
                comboBox.Text = "";
        }

        /*
         * Event
         */
        private void CheckBox_CheckedChanged(object? sender, EventArgs e) {
            if (sender == null)
                return;
            var arrayIndex = Array.IndexOf(_arrayCheckBoxWeek, sender);
            _arrayComboBoxCar[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxCar[arrayIndex].Text = "";
            _arrayComboBoxStaff1[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff1[arrayIndex].Text = "";
            _arrayComboBoxStaff2[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff2[arrayIndex].Text = "";
            _arrayComboBoxStaff3[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff3[arrayIndex].Text = "";
            _arrayComboBoxStaff4[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff4[arrayIndex].Text = "";
        }
        private void Label_MouseClick(object? sender, MouseEventArgs e) {
            if (sender == null)
                return;
            var nestedClassSetMasterVo = (NestedClassSetMasterVo)((LabelEx)sender).Tag;
            MessageBox.Show(nestedClassSetMasterVo.Cell_number.ToString());

        }
        private void Label_MouseEnter(object? sender, EventArgs e) {
            if (sender == null)
                return;
            ((Label)sender).ForeColor = Color.Red;
        }

        private void Label_MouseLeave(object? sender, EventArgs e) {
            if (sender == null)
                return;
            ((Label)sender).ForeColor = Color.Black;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionList_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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