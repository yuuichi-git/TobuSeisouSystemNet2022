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
        /// インスタンス作成
        /// </summary>
        private InitializeForm _initializeForm = new();
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<VehicleDispatchHeadVo> _listVehicleDispatchHeadVo;
        private List<VehicleDispatchBodyVo> _listVehicleDispatchBodyVo;
        private VehicleDispatchHeadDao _vehicleDispatchHeadDao;
        private VehicleDispatchBodyDao _vehicleDispatchBodyDao;
        /// <summary>
        /// コントロール配列
        /// </summary>
        private readonly string[] _DayOfWeek = new string[] { "月", "火", "水", "木", "金", "土", "日" };
        private readonly CheckBox[] _arrayCheckBoxWeek;
        private readonly ComboBox[] _arrayComboBoxCar;
        private readonly ComboBox[] _arrayComboBoxStaff1;
        private readonly ComboBox[] _arrayComboBoxStaff2;
        private readonly ComboBox[] _arrayComboBoxStaff3;
        private readonly ComboBox[] _arrayComboBoxStaff4;
        private readonly TextBox[] _arrayTextBoxMemo;
        private readonly Button[] _arrayButtonCopy;
        public ProductionList(ConnectionVo connectionVo) {
            /*
             * DBを読込
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _vehicleDispatchHeadDao = new VehicleDispatchHeadDao(connectionVo);
            _listVehicleDispatchHeadVo = _vehicleDispatchHeadDao.SelectAllVehicleDispatchHeadVo();
            _vehicleDispatchBodyDao = new VehicleDispatchBodyDao(connectionVo);
            _listVehicleDispatchBodyVo = _vehicleDispatchBodyDao.SelectAllVehicleDispatchBodyVo();
            /*
             * Formを初期化する
             */
            InitializeComponent();
            _initializeForm.ProductionList(this);
            /*
             * TableLayoutPanelExを初期化
             */
            TableLayoutPanelExCenter.Controls.Clear();
            CreateSetLabels();
            /*
             * Array作成
             */
            _arrayCheckBoxWeek = new CheckBox[] { CheckBoxMonday, CheckBoxTuesday, CheckBoxWednesday, CheckBoxThursday, CheckBoxFriday, CheckBoxSaturday, CheckBoxSunday };
            _arrayComboBoxCar = new ComboBox[] { ComboBoxMondayCar, ComboBoxTuesdayCar, ComboBoxWednesdayCar, ComboBoxThursdayCar, ComboBoxFridayCar, ComboBoxSaturdayCar, ComboBoxSundayCar };
            _arrayComboBoxStaff1 = new ComboBox[] { ComboBoxMondayStaff1, ComboBoxTuesdayStaff1, ComboBoxWednesdayStaff1, ComboBoxThursdayStaff1, ComboBoxFridayStaff1, ComboBoxSaturdayStaff1, ComboBoxSundayStaff1 };
            _arrayComboBoxStaff2 = new ComboBox[] { ComboBoxMondayStaff2, ComboBoxTuesdayStaff2, ComboBoxWednesdayStaff2, ComboBoxThursdayStaff2, ComboBoxFridayStaff2, ComboBoxSaturdayStaff2, ComboBoxSundayStaff2 };
            _arrayComboBoxStaff3 = new ComboBox[] { ComboBoxMondayStaff3, ComboBoxTuesdayStaff3, ComboBoxWednesdayStaff3, ComboBoxThursdayStaff3, ComboBoxFridayStaff3, ComboBoxSaturdayStaff3, ComboBoxSundayStaff3 };
            _arrayComboBoxStaff4 = new ComboBox[] { ComboBoxMondayStaff4, ComboBoxTuesdayStaff4, ComboBoxWednesdayStaff4, ComboBoxThursdayStaff4, ComboBoxFridayStaff4, ComboBoxSaturdayStaff4, ComboBoxSundayStaff4 };
            _arrayTextBoxMemo = new TextBox[] { TextBoxMondayMemo, TextBoxTuesdayMemo, TextBoxWednesdayMemo, TextBoxThursdayMemo, TextBoxFridayMemo, TextBoxSaturdayMemo, TextBoxSundayMemo };
            _arrayButtonCopy = new Button[] { ButtonCopyCar, ButtonCopyStaff1, ButtonCopyStaff2, ButtonCopyStaff3, ButtonCopyStaff4, ButtonCopyMemo };

            /*
             * Controlを初期化
             */
            ComboBoxFinancialYear.SelectedIndex = 0;
            ClearControls();
            InitializeComboBoxCarLedger();
            InitializeComboBoxStaffMaster1();
            InitializeComboBoxStaffMaster2();
            InitializeComboBoxStaffMaster3();
            InitializeComboBoxStaffMaster4();
            ToolStripStatusLabelDetail.Text = "";
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
            /*
             * 更新前のチェック
             * ①配車先が選択されているかどうか？
             */
            var labelSetNameTag = LabelSetName.Tag;
            if (labelSetNameTag == null) {
                MessageBox.Show(MessageText.Message201, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DataUpdate();
        }

        /// <summary>
        /// DataUpdate
        /// </summary>
        private void DataUpdate() {
            var listProductionListVo = new List<ProductionListVo>();
            var nestedClassSetMasterVo = (NestedClassSetMasterVo)LabelSetName.Tag;
            var cellNumber = nestedClassSetMasterVo.Cell_number;
            var financialYear = nestedClassSetMasterVo.Financial_year;

            foreach (var checkBox in _arrayCheckBoxWeek) {
                if (checkBox.Checked) {
                    var productionListVo = new ProductionListVo();
                    // CellNumber
                    productionListVo.Cell_number = cellNumber;
                    // DayOfWeek
                    productionListVo.Day_of_week = _DayOfWeek[Array.IndexOf(_arrayCheckBoxWeek, checkBox)];
                    // CarCode
                    if (_arrayComboBoxCar[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        NestedClassCarMasterVo? nestedClassCarMasterVo = (NestedClassCarMasterVo)_arrayComboBoxCar[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if (nestedClassCarMasterVo != null)
                            productionListVo.Car_code = nestedClassCarMasterVo.CarMasterVo.Car_code;
                    }
                    // Staff1
                    if (_arrayComboBoxStaff1[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        NestedClassStaffMasterVo? nestedClassStaffMasterVo1 = (NestedClassStaffMasterVo)_arrayComboBoxStaff1[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if (nestedClassStaffMasterVo1 != null)
                            productionListVo.Operator_code_1 = nestedClassStaffMasterVo1.StaffMasterVo.Staff_code;
                    }
                    // Staff2
                    if (_arrayComboBoxStaff2[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        NestedClassStaffMasterVo? nestedClassStaffMasterVo2 = (NestedClassStaffMasterVo)_arrayComboBoxStaff2[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if (nestedClassStaffMasterVo2 != null)
                            productionListVo.Operator_code_2 = nestedClassStaffMasterVo2.StaffMasterVo.Staff_code;
                    }
                    // Staff3
                    if (_arrayComboBoxStaff3[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        NestedClassStaffMasterVo? nestedClassStaffMasterVo3 = (NestedClassStaffMasterVo)_arrayComboBoxStaff3[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if (nestedClassStaffMasterVo3 != null)
                            productionListVo.Operator_code_3 = nestedClassStaffMasterVo3.StaffMasterVo.Staff_code;
                    }

                    // Staff4
                    if (_arrayComboBoxStaff4[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        NestedClassStaffMasterVo? nestedClassStaffMasterVo4 = (NestedClassStaffMasterVo)_arrayComboBoxStaff4[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if (nestedClassStaffMasterVo4 != null)
                            productionListVo.Operator_code_4 = nestedClassStaffMasterVo4.StaffMasterVo.Staff_code;
                    }
                    productionListVo.Note = _arrayTextBoxMemo[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text;
                    productionListVo.Financial_year = new DateTime(2022, 04, 01);
                    productionListVo.Insert_ymd_hms = DateTime.Now;
                    productionListVo.Update_ymd_hms = new DateTime(1900, 01, 01);
                    productionListVo.Delete_ymd_hms = new DateTime(1900, 01, 01);
                    productionListVo.Delete_flag = false;
                    listProductionListVo.Add(productionListVo);
                }
            }
            try {
                /*
                 * Daoを呼び出す(SQL発行)
                 * ①対象のレコードをDELETE
                 * ②対象レコードをINSERT
                 */
                _vehicleDispatchBodyDao.DeleteVehicleDispatchBodyVo(cellNumber, financialYear);
                _vehicleDispatchBodyDao.InsertVehicleDispatchBodyVo(listProductionListVo);
                /* 
                 * 最新のデータに更新(SQL発行)
                 */
                _listVehicleDispatchBodyVo = _vehicleDispatchBodyDao.SelectAllVehicleDispatchBodyVo();
                MessageBox.Show(MessageText.Message202, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToolStripStatusLabelDetail.Text = string.Concat(nestedClassSetMasterVo.SetMasterVo.Set_name, "を更新に成功しました");
            } catch {
                ToolStripStatusLabelDetail.Text = string.Concat(nestedClassSetMasterVo.SetMasterVo.Set_name, "を更新に失敗しました");
            }

        }

        /// <summary>
        /// CreateSetLabels
        /// </summary>
        private void CreateSetLabels() {
            int i = 0;
            //レイアウトロジックを停止する
            TableLayoutPanelExCenter.SuspendLayout();
            foreach (var vehicleDispatchHeadVo in _listVehicleDispatchHeadVo.OrderBy(x => x.Cell_number)) {
                int column = i % 25;
                int row = i / 25;
                int? setCode = vehicleDispatchHeadVo.Set_code;
                SetMasterVo? setMasterVo;
                if (setCode.HasValue) {
                    setMasterVo = _listSetMasterVo.Find(x => x.Set_code == setCode);
                    if (setMasterVo != null) {
                        var labelEx = new SetLabelEx(setMasterVo, vehicleDispatchHeadVo.Garage_flag).CreateLabel();
                        labelEx.Tag = new NestedClassSetMasterVo(i + 1, setMasterVo.Working_days, new DateTime(2022, 04, 01), setMasterVo);
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
            private string _dayOfWeek;
            private DateTime _financial_year;
            private SetMasterVo _setMasterVo = new();
            public NestedClassSetMasterVo(int cellNumber, string dayOfWeek, DateTime financial_year, SetMasterVo setMasterVo) {
                _cell_number = cellNumber;
                _dayOfWeek = dayOfWeek;
                _financial_year = financial_year;
                _setMasterVo = setMasterVo;
            }
            public int Cell_number {
                get => _cell_number;
                set => _cell_number = value;
            }
            public string DayOfWeek {
                get => _dayOfWeek;
                set => _dayOfWeek = value;
            }
            public DateTime Financial_year {
                get => _financial_year;
                set => _financial_year = value;
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
                foreach (var carMasteVo in _listCarMasterVo.FindAll(x => x.Delete_flag == false).OrderBy(x => x.Registration_number_4))
                    comboBox.Items.Add(new NestedClassCarMasterVo(string.Concat(carMasteVo.Registration_number, " (", carMasteVo.Door_number, ")"), carMasteVo));
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
                foreach (var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
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
                foreach (var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
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
                foreach (var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
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
                foreach (var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
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
        /// ValueCopy
        /// 矢印でのデータコピー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueCopy(object sender, EventArgs e) {
            if (sender == null)
                return;
            switch (Array.IndexOf(_arrayButtonCopy, sender)) {
                case 0: // Car
                    foreach (var comboBox in _arrayComboBoxCar) {
                        if (_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxCar, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxCar[0].Text;
                    }
                    break;
                case 1: // Staff1
                    foreach (var comboBox in _arrayComboBoxStaff1) {
                        if (_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff1, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff1[0].Text;
                    }
                    break;
                case 2: // Staff2
                    foreach (var comboBox in _arrayComboBoxStaff2) {
                        if (_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff2, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff2[0].Text;
                    }
                    break;
                case 3: // Staff3
                    foreach (var comboBox in _arrayComboBoxStaff3) {
                        if (_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff3, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff3[0].Text;
                    }
                    break;
                case 4: // Staff4
                    foreach (var comboBox in _arrayComboBoxStaff4) {
                        if (_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff4, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff4[0].Text;
                    }
                    break;
                case 5: // Memo
                    foreach (var textBox in _arrayTextBoxMemo) {
                        if (_arrayCheckBoxWeek[Array.IndexOf(_arrayTextBoxMemo, textBox)].Checked)
                            textBox.Text = _arrayTextBoxMemo[0].Text;
                    }
                    break;
            }
        }

        /// <summary>
        /// ButtonMasterCarCode_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMasterCarCode_Click(object sender, EventArgs e) {
            var labelSetNameTag = LabelSetName.Tag;
            if (labelSetNameTag == null) {
                MessageBox.Show(MessageText.Message201, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var nestedClassSetMasterVo = (NestedClassSetMasterVo)LabelSetName.Tag;
            var vehicleDispatchHeadVo = _listVehicleDispatchHeadVo.Find(x => x.Cell_number == nestedClassSetMasterVo.Cell_number);
            var carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchHeadVo.Car_code);
            foreach (var checkBox in _arrayCheckBoxWeek) {
                if (checkBox.Checked) {
                    _arrayComboBoxCar[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text = string.Concat(carMasterVo.Registration_number, " (", carMasterVo.Door_number, ")");
                }
            }
        }

        /// <summary>
        /// CheckBox_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _arrayTextBoxMemo[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayTextBoxMemo[arrayIndex].Text = "";
        }

        /// <summary>
        /// Label_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseClick(object? sender, MouseEventArgs e) {
            // 描画を停止
            this.SuspendLayout();
            // Control初期化
            ClearControls();
            // sender Nullチェック
            if (sender == null)
                return;
            // メモリ確保
            var nestedClassSetMasterVo = (NestedClassSetMasterVo)((SetLabelEx)sender).Tag;
            var carMasterVo = new CarMasterVo();
            var staffMasterVo = new StaffMasterVo();

            LabelCellNumber.Text = nestedClassSetMasterVo.Cell_number.ToString();
            LabelSetName.Tag = nestedClassSetMasterVo;
            LabelSetName.Text = string.Concat(nestedClassSetMasterVo.SetMasterVo.Set_name, "組");
            LabelNumberOfPeople.Text = nestedClassSetMasterVo.SetMasterVo.Number_of_people.ToString("#人");
            LabelDayOfWeek.Text = nestedClassSetMasterVo.SetMasterVo.Working_days;

            // Bodyを表示
            foreach (var vehicleDispatchBodyVo in _listVehicleDispatchBodyVo.FindAll(x => x.Cell_number == nestedClassSetMasterVo.Cell_number)) {
                // CheckBoxWeek
                _arrayCheckBoxWeek[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Checked = true;
                // CarMaster
                carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchBodyVo.Car_code);
                if (carMasterVo != null) {
                    _arrayComboBoxCar[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = carMasterVo;
                    _arrayComboBoxCar[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = string.Concat(carMasterVo.Registration_number, " (", carMasterVo.Door_number, ")");
                }
                // Staff1
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_1);
                if (staffMasterVo != null) {
                    _arrayComboBoxStaff1[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = staffMasterVo;
                    _arrayComboBoxStaff1[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = staffMasterVo.Display_name;
                }
                // Staff2
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_2);
                if (staffMasterVo != null) {
                    _arrayComboBoxStaff2[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = staffMasterVo;
                    _arrayComboBoxStaff2[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = staffMasterVo.Display_name;
                }
                // Staff3
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_3);
                if (staffMasterVo != null) {
                    _arrayComboBoxStaff3[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = staffMasterVo;
                    _arrayComboBoxStaff3[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = staffMasterVo.Display_name;
                }
                // Staff4
                staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_4);
                if (staffMasterVo != null) {
                    _arrayComboBoxStaff4[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = staffMasterVo;
                    _arrayComboBoxStaff4[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = staffMasterVo.Display_name;
                }
                // Note
                _arrayTextBoxMemo[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = vehicleDispatchBodyVo.Note;
            }
            // 描画を再開
            this.ResumeLayout();
        }

        /// <summary>
        /// Label_MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseEnter(object? sender, EventArgs e) {
            if (sender == null)
                return;
            ((Label)sender).ForeColor = Color.Red;
        }

        /// <summary>
        /// Label_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseLeave(object? sender, EventArgs e) {
            if (sender == null)
                return;
            ((Label)sender).ForeColor = Color.Black;
        }

        /// <summary>
        /// ClearControls
        /// </summary>
        private void ClearControls() {
            LabelCellNumber.Text = "";
            LabelSetName.Text = "";
            LabelNumberOfPeople.Text = "";
            LabelDayOfWeek.Text = "";
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
            foreach (var textBox in _arrayTextBoxMemo)
                textBox.Text = "";
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