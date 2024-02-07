/*
 * 2022-09-18
 */
using Common;

using ControlEx;

using Dao;

using H_Vo;

namespace Production {
    public partial class ProductionList : Form {
        private readonly InitializeForm _initializeForm = new();
        /// <summary>
        /// 対象年度を格納(ComboBoxFinancialYearのデータ)
        /// </summary>        
        private DateTime _financialDateTime;
        /// <summary>
        /// どのモードで開くかのFlagを退避
        /// </summary>        
        private readonly string _flagName = "";
        /*
         * Dao
         */
        private SetMasterDao _setMasterDao;
        private CarMasterDao _carMasterDao;
        private StaffMasterDao _staffMasterDao;
        private VehicleDispatchHeadDao _vehicleDispatchHeadDao;
        private VehicleDispatchBodyOfficeDao _vehicleDispatchBodyOfficeDao;
        private VehicleDispatchBodyCleanOfficeDao _vehicleDispatchBodyCleanOfficeDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<VehicleDispatchHeadVo> _listVehicleDispatchHeadVo;

        private ExtendsClassSetMasterVo _extendsClassSetMasterVo;
        private CarMasterVo _carMasterVo;
        private StaffMasterVo _staffMasterVo;

        /// <summary>
        /// _vehicleDispatchBodyOfficeDaoと_vehicleDispatchBodyCleanOfficeDaoの統合クラス
        /// </summary>
        private List<VehicleDispatchBodyVo> _listVehicleDispatchBodyVo;
        /// <summary>
        /// 配列に曜日を格納
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

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="flagName"></param>
        public ProductionList(ConnectionVo connectionVo, string flagName) {
            _connectionVo = connectionVo;
            // どのモードで開くかのFlagを退避
            _flagName = flagName;
            /*
             * Dao
             */
            _setMasterDao = new SetMasterDao(connectionVo);
            _carMasterDao = new CarMasterDao(connectionVo);
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _vehicleDispatchHeadDao = new VehicleDispatchHeadDao(connectionVo);
            _vehicleDispatchBodyCleanOfficeDao = new VehicleDispatchBodyCleanOfficeDao(connectionVo);
            _vehicleDispatchBodyOfficeDao = new VehicleDispatchBodyOfficeDao(connectionVo);
            /*
             * Vo
             */
            _listSetMasterVo = _setMasterDao.SelectAllSetMaster();
            _listCarMasterVo = _carMasterDao.SelectAllCarMaster();
            _listStaffMasterVo = _staffMasterDao.SelectAllStaffMaster();
            _listVehicleDispatchHeadVo = new();
            _listVehicleDispatchBodyVo = new();
            /*
             * Controlを初期化する
             */
            InitializeComponent();
            _initializeForm.ProductionList(this);
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
            // ButtonBorderStyleを設定
            TableLayoutPanelExCenter.ButtonBorderStyleDotted = true;
            ClearControls();
            InitializeComboBoxCarLedger();
            InitializeComboBoxStaffMaster1();
            InitializeComboBoxStaffMaster2();
            InitializeComboBoxStaffMaster3();
            InitializeComboBoxStaffMaster4();
            ToolStripStatusLabelDetail.Text = string.Empty;

            // 年度をセット
            ComboBoxFinancialYear.Text = DateTime.Now.AddMonths(-3).ToString("yyyy年度");
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// SetTableLayoutPanelExCenter
        /// </summary>
        private void CreateTableLayoutPanelExCenter() {
            // VehicleDispatchHeadを取得
            _listVehicleDispatchHeadVo = _vehicleDispatchHeadDao.SelectAllVehicleDispatchHeadVo(_financialDateTime);
            switch(_flagName) {
                // VehicleDispatchBodyCleanOfficeを取得
                case "ProductionCleanOfficeList":
                    LabelName.Text = "協議会・清掃事務所へ登録している本番を修正します";
                    _listVehicleDispatchBodyVo = _vehicleDispatchBodyCleanOfficeDao.SelectAllVehicleDispatchBodyVo(_financialDateTime);
                    break;
                // VehicleDispatchBodyOfficeを取得
                case "ProductionOfficeList":
                    LabelName.Text = "社内配車のために登録している本番を修正します";
                    _listVehicleDispatchBodyVo = _vehicleDispatchBodyOfficeDao.SelectAllVehicleDispatchBodyVo(_financialDateTime);
                    break;
            }
            CreateSetLabels(_listVehicleDispatchHeadVo);
            // Controlクリア
            ClearControls();
        }

        /// <summary>
        /// DeleteTableLayoutPanelExCenter
        /// 処理が重いのでなんか考えて！
        /// </summary>
        private void CrearTableLayoutPanelExCenter() {
            /*
             * メソッドを Clear 呼び出しても、コントロール ハンドルはメモリから削除されません。 メモリ リークを回避するには、 メソッドを Dispose 明示的に呼び出す必要があります。
             * ※後ろから解放している点が重要らしい。
             */
            for(int i = TableLayoutPanelExCenter.Controls.Count - 1; 0 <= i; i--) {
                TableLayoutPanelExCenter.Controls[i].Dispose();
            }
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
            if(labelSetNameTag == null) {
                MessageBox.Show(MessageText.Message201, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ProductionListVo> listProductionListVo = new List<ProductionListVo>();
            ExtendsClassSetMasterVo nestedClassSetMasterVo = (ExtendsClassSetMasterVo)LabelSetName.Tag;
            int cellNumber = nestedClassSetMasterVo.Cell_number;
            DateTime financialYear = nestedClassSetMasterVo.Financial_year;

            foreach(CheckBox checkBox in _arrayCheckBoxWeek) {
                if(checkBox.Checked) {
                    var productionListVo = new ProductionListVo();
                    // CellNumber
                    productionListVo.Cell_number = cellNumber;
                    // DayOfWeek
                    productionListVo.Day_of_week = _DayOfWeek[Array.IndexOf(_arrayCheckBoxWeek, checkBox)];
                    // CarCode
                    if(_arrayComboBoxCar[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        ExtendsClassCarMasterVo? nestedClassCarMasterVo = (ExtendsClassCarMasterVo)_arrayComboBoxCar[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if(nestedClassCarMasterVo != null)
                            productionListVo.Car_code = nestedClassCarMasterVo.CarMasterVo.Car_code;
                    }
                    // Staff1
                    if(_arrayComboBoxStaff1[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        ExtendsClassStaffMasterVo? nestedClassStaffMasterVo1 = (ExtendsClassStaffMasterVo)_arrayComboBoxStaff1[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if(nestedClassStaffMasterVo1 != null)
                            productionListVo.Operator_code_1 = nestedClassStaffMasterVo1.StaffMasterVo.Staff_code;
                    }
                    // Staff2
                    if(_arrayComboBoxStaff2[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        ExtendsClassStaffMasterVo? nestedClassStaffMasterVo2 = (ExtendsClassStaffMasterVo)_arrayComboBoxStaff2[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if(nestedClassStaffMasterVo2 != null)
                            productionListVo.Operator_code_2 = nestedClassStaffMasterVo2.StaffMasterVo.Staff_code;
                    }
                    // Staff3
                    if(_arrayComboBoxStaff3[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        ExtendsClassStaffMasterVo? nestedClassStaffMasterVo3 = (ExtendsClassStaffMasterVo)_arrayComboBoxStaff3[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if(nestedClassStaffMasterVo3 != null)
                            productionListVo.Operator_code_3 = nestedClassStaffMasterVo3.StaffMasterVo.Staff_code;
                    }

                    // Staff4
                    if(_arrayComboBoxStaff4[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text != string.Empty) {
                        ExtendsClassStaffMasterVo? nestedClassStaffMasterVo4 = (ExtendsClassStaffMasterVo)_arrayComboBoxStaff4[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].SelectedItem;
                        if(nestedClassStaffMasterVo4 != null)
                            productionListVo.Operator_code_4 = nestedClassStaffMasterVo4.StaffMasterVo.Staff_code;
                    }
                    productionListVo.Note = _arrayTextBoxMemo[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text;
                    productionListVo.Financial_year = _financialDateTime;
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
                switch(_flagName) {
                    case "ProductionCleanOfficeList":
                        _vehicleDispatchBodyCleanOfficeDao.DeleteVehicleDispatchBodyVo(cellNumber, financialYear);
                        _vehicleDispatchBodyCleanOfficeDao.InsertVehicleDispatchBodyVo(listProductionListVo);
                        // 最新のデータに更新(SQL発行)
                        _listVehicleDispatchBodyVo = _vehicleDispatchBodyCleanOfficeDao.SelectAllVehicleDispatchBodyVo(_financialDateTime);
                        break;
                    case "ProductionOfficeList":
                        _vehicleDispatchBodyOfficeDao.DeleteVehicleDispatchBodyVo(cellNumber, financialYear);
                        _vehicleDispatchBodyOfficeDao.InsertVehicleDispatchBodyVo(listProductionListVo);
                        // 最新のデータに更新(SQL発行)
                        _listVehicleDispatchBodyVo = _vehicleDispatchBodyOfficeDao.SelectAllVehicleDispatchBodyVo(_financialDateTime);
                        break;
                }
                MessageBox.Show(MessageText.Message202, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToolStripStatusLabelDetail.Text = string.Concat(nestedClassSetMasterVo.SetMasterVo.Set_name, "を更新に成功しました");
            } catch {
                ToolStripStatusLabelDetail.Text = string.Concat(nestedClassSetMasterVo.SetMasterVo.Set_name, "を更新に失敗しました");
            }

        }

        /// <summary>
        /// CreateSetLabels
        /// </summary>
        private void CreateSetLabels(List<VehicleDispatchHeadVo> listVehicleDispatchHeadVo) {
            int i = 0;
            //レイアウトロジックを停止する
            TableLayoutPanelExCenter.SuspendLayout();
            foreach(var vehicleDispatchHeadVo in listVehicleDispatchHeadVo.OrderBy(x => x.Cell_number)) {
                int column = i % 25;
                int row = i / 25;
                int? setCode = vehicleDispatchHeadVo.Set_code;
                SetMasterVo? setMasterVo;
                if(setCode.HasValue) {
                    setMasterVo = _listSetMasterVo.Find(x => x.Set_code == setCode);
                    if(setMasterVo != null) {
                        var labelEx = new SetLabelEx(setMasterVo, vehicleDispatchHeadVo.Garage_flag).CreateLabel();
                        labelEx.ContextMenuStrip = ContextMenuStrip1;
                        labelEx.Tag = new ExtendsClassSetMasterVo(i + 1, setMasterVo.Working_days, _financialDateTime, setMasterVo);
                        labelEx.Click += new EventHandler(Label_MouseClick);
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
        /// InitializeComboBoxCarLedger
        /// </summary>
        private void InitializeComboBoxCarLedger() {
            foreach(var comboBox in _arrayComboBoxCar) {
                comboBox.Items.Clear();
                foreach(var carMasteVo in _listCarMasterVo.FindAll(x => x.Delete_flag == false).OrderBy(x => x.Registration_number_4))
                    comboBox.Items.Add(new ExtendsClassCarMasterVo(string.Concat(carMasteVo.Registration_number, " (", carMasteVo.Door_number, ")"), carMasteVo));
                comboBox.DisplayMember = "RegistrationNumber";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        /// <summary>
        /// InitializeComboBoxStaffLedger
        /// </summary>
        private void InitializeComboBoxStaffMaster1() {
            foreach(var comboBox in _arrayComboBoxStaff1) {
                comboBox.Items.Clear();
                foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
                    comboBox.Items.Add(new ExtendsClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void InitializeComboBoxStaffMaster2() {
            foreach(var comboBox in _arrayComboBoxStaff2) {
                comboBox.Items.Clear();
                foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
                    comboBox.Items.Add(new ExtendsClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void InitializeComboBoxStaffMaster3() {
            foreach(var comboBox in _arrayComboBoxStaff3) {
                comboBox.Items.Clear();
                foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
                    comboBox.Items.Add(new ExtendsClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void InitializeComboBoxStaffMaster4() {
            foreach(var comboBox in _arrayComboBoxStaff4) {
                comboBox.Items.Clear();
                foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Retirement_flag == false).OrderBy(x => x.Name_kana))
                    comboBox.Items.Add(new ExtendsClassStaffMasterVo(staffMasterVo.Display_name, staffMasterVo));
                comboBox.DisplayMember = "StaffName";
                // オートコンプリートモードの設定
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // コンボボックスのアイテムをオートコンプリートの選択候補とする
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        /// <summary>
        /// ValueCopy
        /// 矢印でのデータコピー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueCopy(object sender, EventArgs e) {
            if(sender == null)
                return;
            switch(Array.IndexOf(_arrayButtonCopy, sender)) {
                case 0: // Car
                    foreach(var comboBox in _arrayComboBoxCar) {
                        if(_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxCar, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxCar[0].Text;
                    }
                    break;
                case 1: // Staff1
                    foreach(var comboBox in _arrayComboBoxStaff1) {
                        if(_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff1, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff1[0].Text;
                    }
                    break;
                case 2: // Staff2
                    foreach(var comboBox in _arrayComboBoxStaff2) {
                        if(_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff2, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff2[0].Text;
                    }
                    break;
                case 3: // Staff3
                    foreach(var comboBox in _arrayComboBoxStaff3) {
                        if(_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff3, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff3[0].Text;
                    }
                    break;
                case 4: // Staff4
                    foreach(var comboBox in _arrayComboBoxStaff4) {
                        if(_arrayCheckBoxWeek[Array.IndexOf(_arrayComboBoxStaff4, comboBox)].Checked)
                            comboBox.Text = _arrayComboBoxStaff4[0].Text;
                    }
                    break;
                case 5: // Memo
                    foreach(var textBox in _arrayTextBoxMemo) {
                        if(_arrayCheckBoxWeek[Array.IndexOf(_arrayTextBoxMemo, textBox)].Checked)
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
            if(labelSetNameTag == null) {
                MessageBox.Show(MessageText.Message201, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var nestedClassSetMasterVo = (ExtendsClassSetMasterVo)LabelSetName.Tag;
            VehicleDispatchHeadVo? vehicleDispatchHeadVo = _listVehicleDispatchHeadVo.Find(x => x.Cell_number == nestedClassSetMasterVo.Cell_number);
            CarMasterVo? carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchHeadVo?.Car_code);
            foreach(var checkBox in _arrayCheckBoxWeek) {
                if(checkBox.Checked) {
                    _arrayComboBoxCar[Array.IndexOf(_arrayCheckBoxWeek, checkBox)].Text = string.Concat(carMasterVo?.Registration_number, " (", carMasterVo?.Door_number, ")");
                }
            }
        }

        /// <summary>
        /// CheckBox_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object? sender, EventArgs e) {
            if(sender == null)
                return;
            var arrayIndex = Array.IndexOf(_arrayCheckBoxWeek, sender);
            _arrayComboBoxCar[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxCar[arrayIndex].Text = string.Empty;
            _arrayComboBoxStaff1[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff1[arrayIndex].Text = string.Empty;
            _arrayComboBoxStaff2[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff2[arrayIndex].Text = string.Empty;
            _arrayComboBoxStaff3[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff3[arrayIndex].Text = string.Empty;
            _arrayComboBoxStaff4[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayComboBoxStaff4[arrayIndex].Text = string.Empty;
            _arrayTextBoxMemo[arrayIndex].Enabled = ((CheckBox)sender).Checked;
            _arrayTextBoxMemo[arrayIndex].Text = string.Empty;
        }

        /// <summary>
        /// Label_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseClick(object? sender, EventArgs e) {
            // 描画を停止
            Panel1.SuspendLayout();
            // Control初期化
            ClearControls();
            // sender Nullチェック
            if(sender == null)
                return;
            // メモリ確保
            _extendsClassSetMasterVo = (ExtendsClassSetMasterVo)((SetLabelEx)sender).Tag;

            LabelCellNumber.Text = _extendsClassSetMasterVo.Cell_number.ToString();
            LabelSetName.Tag = _extendsClassSetMasterVo;
            LabelSetName.Text = string.Concat(_extendsClassSetMasterVo.SetMasterVo.Set_name, "組");
            LabelNumberOfPeople.Text = _extendsClassSetMasterVo.SetMasterVo.Number_of_people.ToString("#人");
            LabelDayOfWeek.Text = _extendsClassSetMasterVo.SetMasterVo.Working_days;
            LabelFiveLap.Text = _extendsClassSetMasterVo.SetMasterVo.Five_lap.ToString();
            LabelMoveFlag.Text = _extendsClassSetMasterVo.SetMasterVo.Move_flag.ToString();

            // Bodyを表示
            foreach(var vehicleDispatchBodyVo in _listVehicleDispatchBodyVo.FindAll(x => x.Cell_number == _extendsClassSetMasterVo.Cell_number)) {
                // CheckBoxWeek
                _arrayCheckBoxWeek[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Checked = true;
                // CarMaster
                _carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchBodyVo.Car_code);
                if(_carMasterVo != null) {
                    _arrayComboBoxCar[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = _carMasterVo;
                    _arrayComboBoxCar[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = string.Concat(_carMasterVo.Registration_number, " (", _carMasterVo.Door_number, ")");
                }
                // Staff1
                _staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_1);
                if(_staffMasterVo != null) {
                    _arrayComboBoxStaff1[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = _staffMasterVo;
                    _arrayComboBoxStaff1[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = _staffMasterVo.Display_name;
                }
                // Staff2
                _staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_2);
                if(_staffMasterVo != null) {
                    _arrayComboBoxStaff2[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = _staffMasterVo;
                    _arrayComboBoxStaff2[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = _staffMasterVo.Display_name;
                }
                // Staff3
                _staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_3);
                if(_staffMasterVo != null) {
                    _arrayComboBoxStaff3[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = _staffMasterVo;
                    _arrayComboBoxStaff3[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = _staffMasterVo.Display_name;
                }
                // Staff4
                _staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchBodyVo.Operator_code_4);
                if(_staffMasterVo != null) {
                    _arrayComboBoxStaff4[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Tag = _staffMasterVo;
                    _arrayComboBoxStaff4[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = _staffMasterVo.Display_name;
                }
                // Note
                _arrayTextBoxMemo[Array.IndexOf(_DayOfWeek, vehicleDispatchBodyVo.Day_of_week)].Text = vehicleDispatchBodyVo.Note;
            }
            // 描画を再開
            Panel1.ResumeLayout();
        }

        /// <summary>
        /// Label_MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseEnter(object? sender, EventArgs e) {
            if(sender == null)
                return;
            ((Label)sender).ForeColor = Color.Red;
        }

        /// <summary>
        /// Label_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseLeave(object? sender, EventArgs e) {
            if(sender == null)
                return;
            ((Label)sender).ForeColor = Color.Black;
        }

        /// <summary>
        /// ClearControls
        /// </summary>
        private void ClearControls() {
            LabelName.Text = string.Empty;
            LabelCellNumber.Text = string.Empty;
            LabelSetName.Tag = null;
            LabelSetName.Text = string.Empty;
            LabelNumberOfPeople.Text = string.Empty;
            LabelDayOfWeek.Text = string.Empty;
            LabelFiveLap.Text = string.Empty;
            LabelMoveFlag.Text = string.Empty;

            Panel1.SuspendLayout();
            foreach(var checkBox in _arrayCheckBoxWeek) {
                checkBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                checkBox.Checked = false;
            }
            foreach(var comboBox in _arrayComboBoxCar)
                comboBox.Text = string.Empty;
            foreach(var comboBox in _arrayComboBoxStaff1)
                comboBox.Text = string.Empty;
            foreach(var comboBox in _arrayComboBoxStaff2)
                comboBox.Text = string.Empty;
            foreach(var comboBox in _arrayComboBoxStaff3)
                comboBox.Text = string.Empty;
            foreach(var comboBox in _arrayComboBoxStaff4)
                comboBox.Text = string.Empty;
            foreach(var textBox in _arrayTextBoxMemo)
                textBox.Text = string.Empty;
            Panel1.ResumeLayout();
        }

        /// <summary>
        /// ComboBoxFinancialYear_SelectedIndexChanged
        /// 対象年度を変えた時の処理  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxFinancialYear_SelectedIndexChanged(object sender, EventArgs e) {
            switch(((ComboBox)sender).Text) {
                case "2022年度":
                    _financialDateTime = new DateTime(2022, 04, 01);
                    break;
                case "2023年度":
                    _financialDateTime = new DateTime(2023, 04, 01);
                    break;
            }
            CrearTableLayoutPanelExCenter();
            // SetLavelEx(TableLayoutPanelExCenter)を更新
            CreateTableLayoutPanelExCenter();
        }

        /// <summary>
        /// ToolStripMenuItemReset_Click
        /// 指定年度の配車をリセット
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemReset_Click(object sender, EventArgs e) {
            try {
                /*
                 * 対象年度のレコードが無ければINSERTする
                 */
                if(!_vehicleDispatchHeadDao.CheckVehicleDispatchHead(_financialDateTime)) {
                    _vehicleDispatchHeadDao.InsertVehicleDispatchHead(_financialDateTime);
                } else {
                    MessageBox.Show("指定した年度の配車パターンデータが存在しています。システム管理者へ連絡して下さい。", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// ContextMenuStrip1_Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opened(object sender, EventArgs e) {
            /*
             * ExtendsClassSetMasterVoを退避
             */
            SetLabelEx setLabelEx  = (SetLabelEx)((ContextMenuStrip)sender).SourceControl;
            _extendsClassSetMasterVo = (ExtendsClassSetMasterVo)setLabelEx.Tag;

        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                /*
                 * 配車先を初期化
                 */
                case "ToolStripMenuItemRemoveSetLabel":
                    var dialogResult = MessageBox.Show("この配車先を削除します。よろしいですか？", MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch(dialogResult) {
                        case DialogResult.OK:
                            try {
                                // VehicleDispatchHeadの対象レコードを初期化する
                                _vehicleDispatchHeadDao.ResetVehicleDispatchHead(_extendsClassSetMasterVo.Cell_number, _extendsClassSetMasterVo.Financial_year);
                                // VehicleDispatchBodyOfficeの対象レコードを削除する
                                _vehicleDispatchBodyOfficeDao.DeleteVehicleDispatchBodyVo(_extendsClassSetMasterVo.Cell_number, _extendsClassSetMasterVo.Financial_year);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                    break;
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
        /// ProductionList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionList_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch(dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        /*
         * 内部クラス
         */
        /// <summary>
        /// ExtendsClassSetMasterVo
        /// </summary>
        private class ExtendsClassSetMasterVo {
            // 配車ナンバー
            private int _cell_number;
            // 稼働曜日
            private string _dayOfWeek;
            // 年度
            private DateTime _financial_year;
            // SetMasterVoを格納
            private SetMasterVo _setMasterVo = new();
            public ExtendsClassSetMasterVo(int cellNumber, string dayOfWeek, DateTime financial_year, SetMasterVo setMasterVo) {
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
        /// ExtendsClassCarMasterVo
        /// </summary>
        private class ExtendsClassCarMasterVo {
            private string _registrationNumber = "";
            private CarMasterVo _carMasterVo = new();
            // プロパティをコンストラクタでセット
            public ExtendsClassCarMasterVo(string registrationNumber, CarMasterVo carMasterVo) {
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
        /// ExtendsClassStaffMasterVo
        /// </summary>
        private class ExtendsClassStaffMasterVo {
            private string _staffName = "";
            private StaffMasterVo _staffMasterVo = new();
            // プロパティをコンストラクタでセット
            public ExtendsClassStaffMasterVo(string staffName, StaffMasterVo staffMasterVo) {
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

        /*
         * TableLayoutPanel上のClickされた位置を計算する
         * X = 74 Y = 72 
         * Column = 25個 Row = 6個
         */
        int _tableLayoutPanel_Selected_Column;
        int _tableLayoutPanel_Selected_Row;
        int _cell_number;
        private void TableLayoutPanelExCenter_MouseDoubleClick(object sender, MouseEventArgs e) {
            // 詳細をクリア
            ClearControls();

            _tableLayoutPanel_Selected_Row = e.Y / 72;
            _tableLayoutPanel_Selected_Column = e.X / 74;
            _cell_number = _tableLayoutPanel_Selected_Column + 1 + (_tableLayoutPanel_Selected_Row * 25);
            ToolStripStatusLabelDetail.Text = string.Concat("cellNumber ", _cell_number, ",column ", _tableLayoutPanel_Selected_Column, ",row ", _tableLayoutPanel_Selected_Row);
            ProductionSelect productionSelect = new ProductionSelect(_connectionVo, _cell_number, _financialDateTime);
            productionSelect.ShowDialog(this);
        }
    }
}