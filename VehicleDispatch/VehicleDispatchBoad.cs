using Common;

using ControlEx;

using Dao;

using Microsoft.VisualBasic.Devices;

using Staff;

using Substitute;

using VehicleDispatchConvert;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        private ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private TableLayoutPanelEx[] _arrayTableLayoutPanelEx = new TableLayoutPanelEx[2];
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;
        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<SetMasterVo> _listDeepCopySetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<CarMasterVo> _listDeepCopyCarMasterVo;
        private List<VehicleDispatchDetailCarVo> _listVehicleDispatchDetailCarVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<StaffMasterVo> _listDeepCopyStaffMasterVo;
        private List<VehicleDispatchDetailStaffVo> _listVehicleDispatchDetailStaffVo;
        /*
         * Tabの開閉
         */
        private bool _TabControlLeftOpenFlag = false;
        private int _TabControlLeftOpenBeforeIndex;
        private bool _TabControlRightOpenFlag = false;
        private int _TabControlRightOpenBeforeIndex;
        /*
         * 点呼モードを保持
         * 全画面の場合True
         * 編集画面の場合False
         */
        private bool tenkoModeFlag = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
            // InitializeComponentの後に初期化してね
            _arrayTableLayoutPanelEx = new TableLayoutPanelEx[] { TableLayoutPanelEx1, TableLayoutPanelEx2 };
            /*
             * Left
             */
            SetTableLayoutPanelLeftSide(false);
            /*
             * Center
             */
            DateTimePickerOperationDate.Value = DateTime.Now;
            ToolStripStatusLabelMemory.Text = "";
            ToolStripStatusLabelStatus.Text = "";
            /*
             * Right
             */
            SetTableLayoutPanelRightSide(false);
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchDetailCarDao = new VehicleDispatchDetailCarDao(connectionVo);
            _vehicleDispatchDetailStaffDao = new VehicleDispatchDetailStaffDao(connectionVo);
            /*
             * Vo
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listDeepCopySetMasterVo = new();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listDeepCopyCarMasterVo = new();
            _listVehicleDispatchDetailCarVo = new();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listDeepCopyStaffMasterVo = new();
            _listVehicleDispatchDetailStaffVo = new();
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
            // TabControlExCenter FlowLayoutPanel
            CreateLabelForVehicleDispatchBoad();
            CreateLabelForFlowLayoutPanelEx();
            // TabControlExLeft
            CreateLabelTabControlExLeft();
            // TabControlExRight
            CreateLabelTabControlExRight();
        }

        /// <summary>
        /// TabControlExCenter
        /// </summary>
        private void CreateLabelForVehicleDispatchBoad() {
            /*
             * レコードの有無確認
             */
            DateTime operationDate = DateTimePickerOperationDate.Value;
            if(!_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                MessageBox.Show(MessageText.Message302, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // レイアウトロジックを非活性化
            _arrayTableLayoutPanelEx[0].SuspendLayout();
            _arrayTableLayoutPanelEx[1].SuspendLayout();
            /*
             * DeepCopy
             */
            _listDeepCopySetMasterVo = new CopyUtility().DeepCopy(_listSetMasterVo.FindAll(x => x.Delete_flag == false));
            _listDeepCopyCarMasterVo = new CopyUtility().DeepCopy(_listCarMasterVo.FindAll(x => x.Delete_flag == false));
            _listDeepCopyStaffMasterVo = new CopyUtility().DeepCopy(_listStaffMasterVo.FindAll(x => x.Vehicle_dispatch_target == true && x.Delete_flag == false));
            /*
             * TabControlExLeftをクリア
             */
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExSet);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExCar);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExFullEmployees);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExLongTerm);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExPartTime);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExWindow);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExChecking);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExRepair);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExVehicleInspection);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExFullSalaried);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExFullClose);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExFullDesignation);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExPartSalaried);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExPartClose);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExPartDesignation);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExTelephone);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExWithoutNotice);
            FlowLayoutPanelControlRemove(this.FlowLayoutPanelExFree);
            /*
             * TableLayoutPanelをクリア
             */
            TableLayoutPanelControlRemove(this.TableLayoutPanelEx1);
            TableLayoutPanelControlRemove(this.TableLayoutPanelEx2);

            var listVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(operationDate);
            int tabNumber = 0;
            int column = 0;
            int row = 0;
            for(int i = 0; i < 150; i++) {
                /*
                 * 共通設定
                 */
                tabNumber = i / 75;
                column = i % 25;
                row = (i / 25) % 3;
                var vehicleDispatchDetailVo = listVehicleDispatchDetailVo.Find(x => x.Cell_number == i + 1);
                var setControlEx = new SetControlEx();
                setControlEx.AllowDrop = true;
                setControlEx.Tag = i;
                /*
                 * SetLabel
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Set_code != 0) {
                    setControlEx.GarageFlag = vehicleDispatchDetailVo.Garage_flag;
                    setControlEx.ProductionNumberOfPeople = vehicleDispatchDetailVo.Number_of_people;
                    setControlEx.SetFlag = true;
                    setControlEx.OperationFlag = vehicleDispatchDetailVo.Operation_flag;
                    setControlEx.CreateLabel(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code), vehicleDispatchDetailVo, ContextMenuStripSetLabel);
                }
                /*
                 * CarLabel
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Car_code != 0) {
                    setControlEx.CreateLabel(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code), ContextMenuStripCarLabel);
                    _listDeepCopyCarMasterVo?.RemoveAll(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                }
                /*
                 * StaffLabel1
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_1 != 0) {
                    setControlEx.CreateLabel(0,
                                             _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1),
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_1_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_1_note.Length > 0 ? true : false,
                                             ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                    // ToolTip
                    ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 2), vehicleDispatchDetailVo.Operator_1_note);
                }
                /*
                 * StaffLabel2
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_2 != 0) {
                    setControlEx.CreateLabel(1,
                                             _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2),
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_2_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_2_note.Length > 0 ? true : false,
                                             ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                    // ToolTip
                    ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 3), vehicleDispatchDetailVo.Operator_2_note);
                }
                /*
                 * StaffLabel3
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_3 != 0) {
                    setControlEx.CreateLabel(2,
                                             _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3),
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_3_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_3_note.Length > 0 ? true : false,
                                             ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3);
                    // ToolTip
                    ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 4), vehicleDispatchDetailVo.Operator_3_note);
                }
                /*
                 * StaffLabel4
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_4 != 0) {
                    setControlEx.CreateLabel(3,
                                             _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4),
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_4_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_4_note.Length > 0 ? true : false,
                                             ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4);
                    // ToolTip
                    ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 5), vehicleDispatchDetailVo.Operator_4_note);
                }
                /*
                 * UserControlからのEventを登録
                 */
                setControlEx.Event_SetControlEx_Click += new EventHandler(this.SetControlEx_Click);
                setControlEx.Event_SetControlEx_DragDrop += new DragEventHandler(this.SetControlEx_DragDrop);
                setControlEx.Event_SetControlEx_DragEnter += new DragEventHandler(this.SetControlEx_DragEnter);
                setControlEx.Event_SetLabelEx_Click += new EventHandler(this.SetLabelEx_Click);
                setControlEx.Event_SetLabelEx_MouseMove += new MouseEventHandler(this.SetLabelEx_MouseMove);
                setControlEx.Event_CarLabelEx_Click += new EventHandler(this.CarLabelEx_Click);
                setControlEx.Event_CarLabelEx_MouseMove += new MouseEventHandler(this.CarLabelEx_MouseMove);
                setControlEx.Event_StaffLabelEx_Click += new EventHandler(this.StaffLabelEx_Click);
                setControlEx.Event_StaffLabelEx_MouseMove += new MouseEventHandler(this.StaffLabelEx_MouseMove);
                _arrayTableLayoutPanelEx[tabNumber].Controls.Add(setControlEx, column, row);
            }
            // レイアウトロジックを活性化
            _arrayTableLayoutPanelEx[1].ResumeLayout();
            _arrayTableLayoutPanelEx[0].ResumeLayout();
        }

        /// <summary>
        /// FlowLayoutPanelへの書き出し
        /// </summary>
        private void CreateLabelForFlowLayoutPanelEx() {
            _listVehicleDispatchDetailCarVo = _vehicleDispatchDetailCarDao.SelectVehicleDispatchDetailCar(DateTimePickerOperationDate.Value);
            _listVehicleDispatchDetailStaffVo = _vehicleDispatchDetailStaffDao.SelectVehicleDispatchDetailStaff(DateTimePickerOperationDate.Value);

            for(int i = 151; i < 169; i++) {
                switch(i) {
                    case 151: // FlowLayoutPanelExSet
                    case 152: // FlowLayoutPanelExCar
                    case 153: // FlowLayoutPanelExFullEmployees
                    case 154: // FlowLayoutPanelExLongTerm
                    case 155: // FlowLayoutPanelExPartTime
                    case 156: // FlowLayoutPanelExWindow
                        break;
                    case 157: // FlowLayoutPanelExChecking
                        foreach(var vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 157)) {
                            // Controlを作成
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // プロパティを設定
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * イベントを設定
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Controlを追加
                            FlowLayoutPanelExChecking.Controls.Add(carLabelEx);
                        }
                        break;
                    case 158: // FlowLayoutPanelExRepair
                        foreach(var vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 158)) {
                            // Controlを作成
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // プロパティを設定
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * イベントを設定
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Controlを追加
                            FlowLayoutPanelExRepair.Controls.Add(carLabelEx);
                        }
                        break;
                    case 159: // FlowLayoutPanelExVehicleInspection
                        foreach(var vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 159)) {
                            // Controlを作成
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // プロパティを設定
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * イベントを設定
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Controlを追加
                            FlowLayoutPanelExVehicleInspection.Controls.Add(carLabelEx);
                        }
                        break;
                    case 160: // FlowLayoutPanelExFullSalaried(組合長期)
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 160)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();

                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExFullSalaried.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 161: // FlowLayoutPanelExFullClose(組合長期)
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 161)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExFullClose.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 162: // FlowLayoutPanelExFullDesignation(組合長期)
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 162)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExFullDesignation.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 163: // FlowLayoutPanelExPartSalaried(アルバイト)
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 163)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExPartSalaried.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 164: // FlowLayoutPanelExPartClose(アルバイト)
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 164)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExPartClose.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 165: // FlowLayoutPanelExPartDesignation(アルバイト)
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 165)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExPartDesignation.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 166: // FlowLayoutPanelExTelephone
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 166)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExTelephone.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 167: // FlowLayoutPanelExWithoutNotice
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 167)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExWithoutNotice.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 168: // FlowLayoutPanelExFree
                        /*
                         * CarLabelExを作成
                         */
                        foreach(var vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 168).OrderBy(x => x.Insert_ymd_hms)) {
                            // Controlを作成
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // プロパティを設定
                            carLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            /*
                             * イベントを設定
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Controlを追加
                            FlowLayoutPanelExFree.Controls.Add(carLabelEx);
                        }
                        /*
                         * StaffLabelExを作成
                         */
                        foreach(var vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 168)) {
                            // Controlを作成
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                        vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // プロパティを設定
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * イベントを設定
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopyから削除
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Controlを追加
                            FlowLayoutPanelExFree.Controls.Add(staffLabelEx);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// TabControlExLeft
        /// </summary>
        private void CreateLabelTabControlExLeft() {
            // FlowLayoutPanelExSet
            foreach(var deepCopySetMasterVo in _listDeepCopySetMasterVo.FindAll(x => x.Classification_code != 10 && x.Classification_code != 11).OrderBy(x => x.Classification_code)) {
                SetLabelEx setLabelEx = new SetLabelEx(deepCopySetMasterVo).CreateLabel();
                // プロパティを設定
                setLabelEx.ContextMenuStrip = ContextMenuStripSetLabel;
                /*
                 * イベントを設定
                 */
                setLabelEx.Click += new EventHandler(SetLabelEx_Click);
                setLabelEx.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                FlowLayoutPanelExSet.Controls.Add(setLabelEx);
            }
            // FlowLayoutPanelExCar
            foreach(var deepCopyCarMasterVo in _listDeepCopyCarMasterVo.OrderBy(x => x.Disguise_kind_1)) {
                CarLabelEx carLabelEx = new CarLabelEx(deepCopyCarMasterVo).CreateLabel();
                // プロパティを設定
                carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                /*
                 * イベントを設定
                 */
                carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                FlowLayoutPanelExCar.Controls.Add(carLabelEx);
            }
            // FlowLayoutPanelExFullEmployees(左側)
            foreach(var deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 10 || x.Belongs == 11) && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // プロパティを設定
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * イベントを設定
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExFullEmployees.Controls.Add(staffLabelEx);
            }
            // FlowLayoutPanelExLongTerm(左側)
            foreach(var deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form == 10 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // プロパティを設定
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * イベントを設定
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExLongTerm.Controls.Add(staffLabelEx);
            }
            // FlowLayoutPanelExPartTime(左側)
            foreach(var deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => x.Belongs == 12 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // プロパティを設定
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * イベントを設定
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExPartTime.Controls.Add(staffLabelEx);
            }
            // FlowLayoutPanelExWindow(左側)
            foreach(var deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form == 11 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // プロパティを設定
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * イベントを設定
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExWindow.Controls.Add(staffLabelEx);
            }
        }

        /// <summary>
        /// TabControlExRight
        /// </summary>
        private void CreateLabelTabControlExRight() {

        }

        /// <summary>
        /// TableLayoutPanelControlRemove
        /// </summary>
        /// <param name="tableLayoutPanelEx"></param>
        private void TableLayoutPanelControlRemove(TableLayoutPanelEx tableLayoutPanelEx) {
            tableLayoutPanelEx.Controls.Clear();

            ComputerInfo info = new ComputerInfo();
            ToolStripStatusLabelMemory.Text = string.Concat("合計物理メモリ:", info.TotalPhysicalMemory / 1024, " 利用可能物理メモリ:", info.AvailablePhysicalMemory / 1024);
        }

        /// <summary>
        /// FlowLayoutPanelControlRemove
        /// </summary>
        /// <param name="flowLayoutPanelEx"></param>
        private void FlowLayoutPanelControlRemove(FlowLayoutPanelEx flowLayoutPanelEx) {
            flowLayoutPanelEx.Controls.Clear();

            ComputerInfo info = new ComputerInfo();
            ToolStripStatusLabelMemory.Text = string.Concat("合計物理メモリ:", info.TotalPhysicalMemory / 1024, " 利用可能物理メモリ:", info.AvailablePhysicalMemory / 1024);
        }

        /// <summary>
        /// VehicleDispatchBoad_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchBoad_KeyDown(object sender, KeyEventArgs e) {
            // Open
            if(e.KeyData == (Keys.Shift | Keys.A)) {
                ModeEdit();
            }
            // Close
            if(e.KeyData == (Keys.Shift | Keys.D)) {
                ModeRollCall();
            }
        }

        /// <summary>
        /// Formを編集モードにする
        /// </summary>
        private void ModeEdit() {
            // 更新する
            TableLayoutPanelBase.SuspendLayout();
            tenkoModeFlag = false;
            ButtonUpdate.PerformClick();
            _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, true);
            TableLayoutPanelBase.ResumeLayout();
        }

        /// <summary>
        /// Formを点呼モードにする
        /// </summary>
        private void ModeRollCall() {
            // 更新する
            TableLayoutPanelBase.SuspendLayout();
            tenkoModeFlag = true;
            ButtonUpdate.PerformClick();
            _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, false);
            TableLayoutPanelBase.ResumeLayout();
        }

        /// <summary>
        /// SetControlEx 退避用
        /// </summary>
        SetControlEx EvacuationSetControlEx;
        /// <summary>
        /// FlowLayoutPanelEx 退避用
        /// </summary>
        FlowLayoutPanelEx EvacuationFlowLayoutPanelEx;
        /// <summary>
        /// SetLabelEx 退避用
        /// </summary>
        SetLabelEx EvacuationSetLabelEx;
        /// <summary>
        /// CarLabelEx 退避用
        /// </summary>
        CarLabelEx EvacuationCarLabelEx;
        /// <summary>
        /// StaffLabelEx 退避用
        /// </summary>
        StaffLabelEx EvacuationStaffLabelEx;

        /// <summary>
        /// ContextMenuStrip_Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opened(object sender, EventArgs e) {
            DateTime operationDate = DateTimePickerOperationDate.Value;

            switch(((ContextMenuStrip)sender).Name) {
                /*
                 * ContextMenuStripSetLabel
                 */
                case "ContextMenuStripSetLabel":
                    /*
                     * SetControlEx上でクリックされた時
                     */
                    if(((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx))
                        EvacuationSetControlEx = (SetControlEx)((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent; // SetControlExを退避
                    /*
                     * FlowLayoutPanelEx上でクリックされた時
                     */
                    if(((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx))
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent; // SetControlExを退避
                    // SetLabelExを退避
                    EvacuationSetLabelEx = (SetLabelEx)((ContextMenuStrip)sender).SourceControl;
                    /*
                     * メニューの表示調整
                     */
                    SetMasterVo setMasterVo = (SetMasterVo)EvacuationSetLabelEx.Tag;
                    ToolStripMenuItemSetDelete.Enabled = setMasterVo.Move_flag; // 配車先を削除する
                    ToolStripMenuItemFax.Enabled = (setMasterVo.Contact_method == 11 && operationDate.Date == DateTime.Now.Date && EvacuationSetControlEx.OperationFlag) ? true : false; // 代車・代番のFAXを作成する
                    break;
                /*
                 * ContextMenuStripCarLabel
                 */
                case "ContextMenuStripCarLabel":
                    /*
                     * SetControlEx上でクリックされた時
                     */
                    if(((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx))
                        EvacuationSetControlEx = (SetControlEx)((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent; // SetControlExを退避
                    /*
                     * FlowLayoutPanelEx上でクリックされた時
                     */
                    if(((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx))
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent; // SetControlExを退避
                    // CarLabelExを退避
                    EvacuationCarLabelEx = (CarLabelEx)((ContextMenuStrip)sender).SourceControl;
                    break;
                /*
                 * ContextMenuStripStaffLabel
                 */
                case "ContextMenuStripStaffLabel":
                    /*
                     * SetControlEx上でクリックされた時
                     */
                    if(((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx))
                        EvacuationSetControlEx = (SetControlEx)((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent; // SetControlExを退避
                    /*
                     * FlowLayoutPanelEx上でクリックされた時
                     */
                    if(((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx))
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent; // SetControlExを退避
                    // StaffLabelExを退避
                    EvacuationStaffLabelEx = (StaffLabelEx)((ContextMenuStrip)sender).SourceControl;
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            DateTime operationDate = DateTimePickerOperationDate.Value;
            switch(((ToolStripMenuItem)sender).Name) {
                /*
                 * MenuStrip1
                 */
                // 配車表を作成する
                case "ToolStripMenuItemConvertExcel":
                    /*
                     * VehicleDispatchSimpleのコンストラクタ内でファイルの存在チェックをしている。
                     * コンストラクタ内で終了させるには、例外を発生させてCatchで受け取りReturnする
                     */
                    try {
                        var vehicleDispatchSimple = new VehicleDispatchSimple(_connectionVo, DateTimePickerOperationDate.Value);
                        vehicleDispatchSimple.ShowDialog(this);
                    } catch {
                        return;
                    }
                    break;
                // 清掃事務所へ提出している本番
                case "ToolStripMenuItemInitializeCleanOffice":
                    MessageBox.Show("ToolStripMenuItemInitializeCleanOffice");
                    break;
                // 社内での本番
                case "ToolStripMenuItemInitializeCompanyOffice":
                    if(_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                        DialogResult dialogResult = MessageBox.Show(MessageText.Message301, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if(dialogResult == DialogResult.OK)
                            InsertVehicleDispatchDetail();
                        return;
                    } else {
                        InsertVehicleDispatchDetail();
                    }
                    break;
                case "ToolStripMenuItemAllScreen":
                    ModeRollCall();
                    break;
                case "ToolStripMenuItemDefaultScreen":
                    ModeEdit();
                    break;

                /*
                 * ContextMenuStripSetLabel
                 */
                // 配車先詳細
                case "ToolStripMenuItemSetDetail":
                    MessageBox.Show("配車先詳細画面は作成中です。提案を受付ています。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // 配車先を削除
                case "ToolStripMenuItemSetDelete":
                    try {
                        _vehicleDispatchDetailDao.ResetSet(DateTimePickerOperationDate.Value,
                                                           (int)EvacuationSetControlEx.Tag);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    var setControlEx = (SetControlEx)EvacuationSetLabelEx.Parent;
                    setControlEx.Controls.Remove(EvacuationSetLabelEx);
                    setControlEx.Refresh();
                    break;
                // 足立より出庫
                case "ToolStripMenuItemSetGarageAdachi":
                    try {
                        _vehicleDispatchDetailDao.UpdateGarageFlag(DateTimePickerOperationDate.Value,
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   true);
                        // SetLabelExを本社の色に変える
                        EvacuationSetLabelEx.SetGarageFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 三郷より出庫
                case "ToolStripMenuItemSetGarageMisato":
                    try {
                        _vehicleDispatchDetailDao.UpdateGarageFlag(DateTimePickerOperationDate.Value,
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   false);
                        // SetLabelExを三郷の色に変える
                        EvacuationSetLabelEx.SetGarageFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 代車・代番FAX
                case "ToolStripMenuItemFax":
                    SetMasterVo setMasterVo = (SetMasterVo)EvacuationSetLabelEx.Tag;
                    switch(setMasterVo.Set_code) {
                        case 1310101: // 千代田２
                        case 1310102: // 千代田６
                        case 1310103: // 千代田紙１
                            new SubstitutePaper(_connectionVo, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        case 1310201: // 中央ペット７
                        case 1310202: // 中央ペット８
                            new SubstitutePaper(_connectionVo, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        case 1312101: // 足立１８
                        case 1312102: // 足立２３
                        case 1312103: // 足立２４
                        case 1312104: // 足立３８
                        case 1312105: // 足立不燃４
                            new SubstitutePaper(_connectionVo, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        case 1312204: // 葛飾１１
                        case 1312201: // 葛飾３３
                        case 1312202: // 葛飾５５
                        case 1312203: // 小岩４
                            new SubstitutePaper(_connectionVo, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        default:
                            MessageBox.Show("代車代番のFAXを作成画面は作成中です。提案を受付ています。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    MessageBox.Show("印刷を完了しました", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                /*
                 * ContextMenuStripCarLabel
                 */
                // 車両詳細
                case "ToolStripMenuItemCarDetail":
                    MessageBox.Show("車両詳細画面は作成中です。提案を受付ています。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                /*
                 * ContextMenuStripStaffLabel
                 */
                // 従事者詳細
                case "ToolStripMenuItemStaffDetail":
                    var staffPaper = new StaffPaper(_connectionVo, ((StaffMasterVo)EvacuationStaffLabelEx.Tag).Staff_code);
                    staffPaper.ShowDialog(this);
                    break;
                // メモを書き込む
                case "ToolStripMenuItemMemo":
                    string stringMemo = Microsoft.VisualBasic.Interaction.InputBox("従事者メモを書き込んで下さい", "メモ");
                    try {
                        /*
                         * SetControlEx上でクリックされた時
                         */
                        if(EvacuationStaffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetOperatorNote(DateTimePickerOperationDate.Value,
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                      stringMemo);
                        }
                        /*
                         * FlowLayoutPanelEx上でクリックされた時
                         */
                        if(EvacuationStaffLabelEx.Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                            _vehicleDispatchDetailStaffDao.SetOperatorNote(DateTimePickerOperationDate.Value,
                                                                           ((StaffMasterVo)EvacuationStaffLabelEx.Tag).Staff_code,
                                                                           stringMemo);
                        }
                        EvacuationStaffLabelEx.SetNoteFlag(stringMemo.Length > 0 ? true : false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
            }
        }

        /// <summary>
        /// InsertVehicleDispatchDetail
        /// </summary>
        private void InsertVehicleDispatchDetail() {
            List<VehicleDispatchDetailVo> listvehicleDispatchDetailVo = new();
            DateTime defaultDate = new DateTime(1900, 01, 01);
            DateTime operationDate = DateTimePickerOperationDate.Value;
            /*
             * INSERTを実行する前に対象レコードが存在していたらDELETEする
             * �@VehicleDispatchDetailの対象レコードをDELETE
             * �Avehicle_dispatch_detail_carの対象レコードをDELETE
             * �Bvehicle_dispatch_detail_staffの対象レコードをDELETE
             */
            if(_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                try {
                    _vehicleDispatchDetailDao.DeleteVehicleDispatchDetail(operationDate);
                    _vehicleDispatchDetailCarDao.DeleteCar(operationDate);
                    _vehicleDispatchDetailStaffDao.DeleteStaff(operationDate);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            /*
             * vehicle_dispatch_head/vehicle_dispatch_bodyからvehicle_dispatch_detailを作成する
             */
            // 社内での本番をList<VehicleDispatchDetailVo>型で取得
            List<VehicleDispatchDetailVo> listVehicleDispatch = _vehicleDispatchDetailDao.SelectVehicleDispatch(operationDate.ToString("ddd"));
            // VehicleDispatchDetailVoの不足情報を加える
            foreach(var vehicleDispatchDetail in listVehicleDispatch.OrderBy(x => x.Cell_number)) {
                VehicleDispatchDetailVo vehicleDispatchDetailVo = new();
                vehicleDispatchDetailVo.Cell_number = vehicleDispatchDetail.Cell_number;
                vehicleDispatchDetailVo.Operation_date = operationDate;
                vehicleDispatchDetailVo.Operation_flag = vehicleDispatchDetail.Day_of_week != string.Empty; // vehicle_dispatch_body.day_of_weekがstring.EmptydeでなければTrue(稼働)
                vehicleDispatchDetailVo.Garage_flag = vehicleDispatchDetail.Garage_flag;
                vehicleDispatchDetailVo.Five_lap = vehicleDispatchDetail.Five_lap;
                vehicleDispatchDetailVo.Move_flag = vehicleDispatchDetail.Move_flag;
                vehicleDispatchDetailVo.Day_of_week = vehicleDispatchDetail.Day_of_week;
                vehicleDispatchDetailVo.Set_code = vehicleDispatchDetail.Set_code;
                vehicleDispatchDetailVo.Set_note = vehicleDispatchDetail.Set_note; // vehicle_dispatch_body.note
                vehicleDispatchDetailVo.Car_code = vehicleDispatchDetail.Car_code;
                vehicleDispatchDetailVo.Car_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Car_note = ""; // 値を作成
                vehicleDispatchDetailVo.Number_of_people = vehicleDispatchDetail.Number_of_people;
                vehicleDispatchDetailVo.Operator_code_1 = vehicleDispatchDetail.Operator_code_1;
                vehicleDispatchDetailVo.Operator_1_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_1_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_code_2 = vehicleDispatchDetail.Operator_code_2;
                vehicleDispatchDetailVo.Operator_2_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_2_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_code_3 = vehicleDispatchDetail.Operator_code_3;
                vehicleDispatchDetailVo.Operator_3_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_3_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_code_4 = vehicleDispatchDetail.Operator_code_4;
                vehicleDispatchDetailVo.Operator_4_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_4_note = ""; // 値を作成
                vehicleDispatchDetailVo.Insert_pc_name = Environment.MachineName; // 値を作成
                vehicleDispatchDetailVo.Insert_ymd_hms = DateTime.Now; // 値を作成
                vehicleDispatchDetailVo.Update_pc_name = ""; // 値を作成
                vehicleDispatchDetailVo.Update_ymd_hms = defaultDate; // 値を作成
                vehicleDispatchDetailVo.Delete_pc_name = ""; // 値を作成
                vehicleDispatchDetailVo.Delete_ymd_hms = defaultDate; // 値を作成
                vehicleDispatchDetailVo.Delete_flag = false; // 値を作成
                listvehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
            }
            try {
                _vehicleDispatchDetailDao.InsertVehicleDispatchDetail(listvehicleDispatchDetailVo);
            } catch(Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// UserControlのEventを処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_Click(object? sender, EventArgs e) {
            //MessageBox.Show("SetControlEx_Click");
        }

        /// <summary>
        /// SetControlEx_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragDrop(object? sender, DragEventArgs e) {
            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            SetControlEx setControlEx = new();
            if(sender != null) {
                setControlEx = (SetControlEx)sender;
            } else {
                MessageBox.Show("SetControlEx_DragDrop : senderがNullです");
            }
            /*
             * SetLabelEx
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                if(((SetMasterVo)dragItem.Tag).Move_flag) {
                    /*
                     * SetLabelEx
                     * Tab(配車先)からのDropの場合SetLabelをCopyする。TableLayoutPanelExからのDropならMoveする。
                     */
                    switch(dragItem.Parent.Name) {
                        case "SetControlEx":
                            /*
                             * SetControlExからのDrop
                             */
                            if(setControlEx != null && setControlEx.GetControlFromPosition(0, 0) == null) {
                                /*
                                 * 移動許可を調査する
                                 */
                                if(CheckSetControlEx(dragItem)) {
                                    try {
                                        _vehicleDispatchDetailDao.CopySet(DateTimePickerOperationDate.Value,
                                                                          (int)((SetControlEx)dragItem.Parent).Tag,
                                                                          (int)setControlEx.Tag);
                                        _vehicleDispatchDetailDao.ResetSet(DateTimePickerOperationDate.Value,
                                                                           (int)((SetControlEx)dragItem.Parent).Tag);
                                        setControlEx.Controls.Add(dragItem, 0, 0);
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("車両ラベル又は従業員ラベルが設定されています。そのため配車先ラベルを移動できません");
                                }
                            } else {
                                ToolStripStatusLabelStatus.Text = string.Concat("配車先が設定されています。(", ((SetMasterVo)dragItem.Tag).Set_name, ") はここへは移動できません");
                            }
                            break;
                        case "FlowLayoutPanelExSet":
                            if(setControlEx != null && setControlEx.GetControlFromPosition(0, 0) == null) {
                                /*
                                 * Tab(配車先)からのDrop
                                 */
                                SetLabelEx newDropItem = new SetLabelEx((SetMasterVo)dragItem.Tag).CreateLabel();
                                // プロパティを設定
                                newDropItem.ContextMenuStrip = ContextMenuStripSetLabel;
                                /*
                                 * イベントを設定
                                 */
                                newDropItem.Click += new EventHandler(SetLabelEx_Click);
                                newDropItem.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                                _vehicleDispatchDetailDao.SetSet(DateTimePickerOperationDate.Value,
                                                                (int)setControlEx.Tag,
                                                                (SetMasterVo)dragItem.Tag);
                                setControlEx.Controls.Add(newDropItem, 0, 0);
                            } else {
                                ToolStripStatusLabelStatus.Text = string.Concat("配車先が設定されています。(", ((SetMasterVo)dragItem.Tag).Set_name, ") はここへは移動できません");
                            }
                            break;
                        /*
                         * FlowLayoutPanelExFree
                         * FlowLayoutPanelExFreeからの移動
                         */
                        case "FlowLayoutPanelExFree":

                            break;
                    }
                } else {
                    ToolStripStatusLabelStatus.Text = string.Concat("(", ((SetMasterVo)dragItem.Tag).Set_name, ") は移動が禁止されています");
                }
            }
            /*
             * CarLabelEx
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                _vehicleDispatchDetailDao.SetCar(DateTimePickerOperationDate.Value,
                                                              Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                              Convert.ToInt32(setControlEx.Tag));
                                _vehicleDispatchDetailDao.ResetCar(DateTimePickerOperationDate.Value,
                                                                   Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag));
                                setControlEx.Controls.Add(dragItem, 0, 1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("車両が設定されています。(", ((CarMasterVo)dragItem.Tag).Registration_number, ") はここへは移動できません");
                        }
                        break;
                    case "FlowLayoutPanelExCar":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detailをUPDATE
                                _vehicleDispatchDetailDao.SetCar(DateTimePickerOperationDate.Value,
                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                (CarMasterVo)dragItem.Tag);
                                setControlEx.Controls.Add(dragItem, 0, 1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("車両が設定されています。(", ((CarMasterVo)dragItem.Tag).Registration_number, ") はここへは移動できません");
                        }
                        break;
                    case "FlowLayoutPanelExChecking":
                    case "FlowLayoutPanelExRepair":
                    case "FlowLayoutPanelExVehicleInspection":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detailをUPDATE
                                _vehicleDispatchDetailDao.SetCar(DateTimePickerOperationDate.Value,
                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                 (CarMasterVo)dragItem.Tag);
                                // vehicle_dispatch_detail_carからDELETE
                                _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerOperationDate.Value,
                                                                       Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                       ((CarMasterVo)dragItem.Tag).Car_code);
                                setControlEx.Controls.Add(dragItem, 0, 1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("車両が設定されています。(", ((CarMasterVo)dragItem.Tag).Registration_number, ") はここへは移動できません");
                        }
                        break;
                    case "FlowLayoutPanelExFree":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detailをUPDATE
                                _vehicleDispatchDetailDao.SetCar(DateTimePickerOperationDate.Value,
                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                 (CarMasterVo)dragItem.Tag);
                                // vehicle_dispatch_detail_carからDELETE
                                _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerOperationDate.Value,
                                                                       Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                       ((CarMasterVo)dragItem.Tag).Car_code);
                                setControlEx.Controls.Add(dragItem, 0, 1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("車両が設定されています。(", ((CarMasterVo)dragItem.Tag).Registration_number, ") はここへは移動できません");
                        }
                        break;
                }
            }
            /*
             * StaffLabelEx
             */
            if(setControlEx != null && e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                //画面座標(X, Y)を、setControlEx上のクライアント座標に変換する
                Point point = setControlEx.PointToClient(new Point(e.X, e.Y));
                switch(dragItem.Parent.Name) {
                    /*
                     * StaffLabelEx
                     * SetControlEx同士での移動
                     */
                    case "SetControlEx":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabelかCarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           (int)((SetControlEx)dragItem.Parent).Tag,
                                                                           ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                           (int)setControlEx.Tag, 2);
                                        _vehicleDispatchDetailDao.ResetStaff(DateTimePickerOperationDate.Value,
                                                                             (int)((SetControlEx)dragItem.Parent).Tag,
                                                                             ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem, 0, 2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("運転手が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           (int)((SetControlEx)dragItem.Parent).Tag,
                                                                           ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                           (int)setControlEx.Tag, 3);
                                        _vehicleDispatchDetailDao.ResetStaff(DateTimePickerOperationDate.Value,
                                                                             (int)((SetControlEx)dragItem.Parent).Tag,
                                                                             ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem, 0, 3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員1が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                            (int)((SetControlEx)dragItem.Parent).Tag,
                                                                            ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                            (int)setControlEx.Tag, 4);
                                        _vehicleDispatchDetailDao.ResetStaff(DateTimePickerOperationDate.Value,
                                                                             (int)((SetControlEx)dragItem.Parent).Tag,
                                                                             ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem, 0, 4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員2が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           (int)((SetControlEx)dragItem.Parent).Tag,
                                                                           ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                           (int)setControlEx.Tag, 5);
                                        _vehicleDispatchDetailDao.ResetStaff(DateTimePickerOperationDate.Value,
                                                                             (int)((SetControlEx)dragItem.Parent).Tag,
                                                                             ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem, 0, 5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員3が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                        }
                        break;
                    /*
                     * StaffLabelEx
                     * Tab左側からの移動でDrag側の後処理(DBの処理)が必要無いもの
                     */
                    case "FlowLayoutPanelExFullEmployees":
                    case "FlowLayoutPanelExLongTerm":
                    case "FlowLayoutPanelExPartTime":
                    case "FlowLayoutPanelExWindow":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabelかCarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        // VehicleDispatchDetailをUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           1,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem, 0, 2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }

                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("運転手が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        // VehicleDispatchDetailをUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           2,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem, 0, 3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員1が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        // VehicleDispatchDetailをUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           3,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem, 0, 4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員2が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        // VehicleDispatchDetailをUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           4,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem, 0, 5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員3が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                        }
                        break;
                    /*
                     * StaffLabelEx
                     * Tab右側からの移動でDrag側の後処理(DBの処理)が必要なもの
                     */
                    case "FlowLayoutPanelExFullSalaried":
                    case "FlowLayoutPanelExFullClose":
                    case "FlowLayoutPanelExFullDesignation":
                    case "FlowLayoutPanelExPartSalaried":
                    case "FlowLayoutPanelExPartClose":
                    case "FlowLayoutPanelExPartDesignation":
                    case "FlowLayoutPanelExTelephone":
                    case "FlowLayoutPanelExWithoutNotice":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabelかCarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           1,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItemを移動
                                        setControlEx.Controls.Add(dragItem, 0, 2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("運転手が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           2,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItemを移動
                                        setControlEx.Controls.Add(dragItem, 0, 3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員1が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           3,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItemを移動
                                        setControlEx.Controls.Add(dragItem, 0, 4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員2が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           4,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItemを移動
                                        setControlEx.Controls.Add(dragItem, 0, 5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員3が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                        }
                        break;
                    /*
                     * FlowLayoutPanelExFree
                     * FlowLayoutPanelExFreeからの移動
                     */
                    case "FlowLayoutPanelExFree":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabelかCarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           1,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItemを移動
                                        setControlEx.Controls.Add(dragItem, 0, 2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }

                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("運転手が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           2,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        setControlEx.Controls.Add(dragItem, 0, 3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員1が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                              3,
                                                                              (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        setControlEx.Controls.Add(dragItem, 0, 4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員2が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        // VehicleDispatchDetailにUPDATE
                                        _vehicleDispatchDetailDao.SetStaff(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(setControlEx.Tag),
                                                                           4,
                                                                           (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        setControlEx.Controls.Add(dragItem, 0, 5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("作業員3が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                                }
                                break;
                        }
                        break;
                }
            }
        }

        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void SetLabelEx_Click(object? sender, EventArgs e) {
            //MessageBox.Show("SetLabelEx_Click");
        }

        private void SetLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if(sender != null && e.Button == MouseButtons.Left)
                ((SetLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        private void CarLabelEx_Click(object? sender, EventArgs e) {
            //MessageBox.Show("CarLabelEx_Click");
        }

        private void CarLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if(sender != null && e.Button == MouseButtons.Left)
                ((CarLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        /// <summary>
        /// StaffLabelEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffLabelEx_Click(object? sender, EventArgs e) {
            /*
             * tenkoFlag → True:StaffLabelExをClickしたら点呼時間を記録
             */
            if(tenkoModeFlag) {
                if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                    SetControlEx setControlEx = (SetControlEx)((StaffLabelEx)sender).Parent;
                    StaffLabelEx staffLabelEx = (StaffLabelEx)sender;
                    /*
                     * vehicle_dispatch_detailを書き換え
                     */
                    var tableLayoutPanelCellPosition = setControlEx.GetCellPosition(staffLabelEx);
                    try {
                        _vehicleDispatchDetailDao.UpdateRollCallFlag(DateTimePickerOperationDate.Value,
                                                                     (int)setControlEx.Tag,
                                                                     tableLayoutPanelCellPosition.Row,
                                                                     staffLabelEx.GetRollCallFlag);
                        staffLabelEx.SetRollCallFlag(!staffLabelEx.GetRollCallFlag);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }

                    ToolStripStatusLabelStatus.Text = string.Concat(" ", ((StaffMasterVo)staffLabelEx.Tag).Display_name, " の点呼記録を変更しました");
                    return;
                }
            }
        }

        /// <summary>
        /// StaffLabelEx_MouseMove
        /// ドラッグの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if(sender != null && e.Button == MouseButtons.Left)
                ((StaffLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        /// <summary>
        /// FlowLayoutPanelEx_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlowLayoutPanelEx_DragDrop(object sender, DragEventArgs e) {
            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            /*
             * DragアイテムがSetLabelExの場合
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                    case "FlowLayoutPanelExFree":
                        break;
                }
                ToolStripStatusLabelStatus.Text = string.Concat("(", ((SetMasterVo)dragItem.Tag).Set_name, ") は移動できません");
            }
            /*
             * DragアイテムがCarLabelExの場合
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExCar":
                                try {
                                    _vehicleDispatchDetailDao.ResetCar(DateTimePickerOperationDate.Value,
                                                                       Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag));
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                            case "FlowLayoutPanelExChecking":
                            case "FlowLayoutPanelExRepair":
                            case "FlowLayoutPanelExVehicleInspection":
                            case "FlowLayoutPanelExFree":
                                try {
                                    /*
                                     * Insertの後にResetしないとダメだよ(vehicleDispatchDetailのレコードを副問合せしているから)
                                     */
                                    _vehicleDispatchDetailCarDao.InsertCar(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                    _vehicleDispatchDetailDao.ResetCar(DateTimePickerOperationDate.Value,
                                                                       Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag));
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " を処理しました");
                        break;
                    case "FlowLayoutPanelExCar":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExChecking":
                            case "FlowLayoutPanelExRepair":
                            case "FlowLayoutPanelExVehicleInspection":
                            case "FlowLayoutPanelExFree":
                                try {
                                    // vehicle_dispatch_detail_carにINSERT
                                    _vehicleDispatchDetailCarDao.InsertNewCar(DateTimePickerOperationDate.Value,
                                                                              Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag),
                                                                              ((CarMasterVo)dragItem.Tag).Car_code);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " を処理しました");
                        break;
                    case "FlowLayoutPanelExChecking":
                    case "FlowLayoutPanelExRepair":
                    case "FlowLayoutPanelExVehicleInspection":
                    case "FlowLayoutPanelExFree":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExCar":
                                try {
                                    // vehicle_dispatch_detail_carからDELETE
                                    _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           ((CarMasterVo)dragItem.Tag).Car_code);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                            case "FlowLayoutPanelExChecking":
                            case "FlowLayoutPanelExRepair":
                            case "FlowLayoutPanelExVehicleInspection":
                            case "FlowLayoutPanelExFree":
                                try {
                                    _vehicleDispatchDetailCarDao.UpdateCar(DateTimePickerOperationDate.Value,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           ((CarMasterVo)dragItem.Tag).Car_code,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " を処理しました");
                        break;
                }
            }
            /*
             * DragアイテムがStaffLabelExの場合
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExFullEmployees":
                            case "FlowLayoutPanelExLongTerm":
                            case "FlowLayoutPanelExPartTime":
                            case "FlowLayoutPanelExWindow":
                                try {
                                    _vehicleDispatchDetailDao.ResetStaff(DateTimePickerOperationDate.Value,
                                                                         Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                         ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                    dragItem.SetNoteFlag(false);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }

                                break;
                            case "FlowLayoutPanelExFullSalaried":
                            case "FlowLayoutPanelExFullClose":
                            case "FlowLayoutPanelExFullDesignation":
                            case "FlowLayoutPanelExPartSalaried":
                            case "FlowLayoutPanelExPartClose":
                            case "FlowLayoutPanelExPartDesignation":
                            case "FlowLayoutPanelExTelephone":
                            case "FlowLayoutPanelExWithoutNotice":
                            case "FlowLayoutPanelExFree":
                                try {
                                    /*
                                     * Insertの後にResetしないとダメだよ(vehicleDispatchDetailのレコードを副問合せしているから)
                                     */
                                    _vehicleDispatchDetailStaffDao.InsertStaff(DateTimePickerOperationDate.Value,
                                                                               Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                               ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                               Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                    _vehicleDispatchDetailDao.ResetStaff(DateTimePickerOperationDate.Value,
                                                                         Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                         ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }

                                break;
                        }
                        break;
                    case "FlowLayoutPanelExFullEmployees":
                    case "FlowLayoutPanelExLongTerm":
                    case "FlowLayoutPanelExPartTime":
                    case "FlowLayoutPanelExWindow":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExFullSalaried":
                            case "FlowLayoutPanelExFullClose":
                            case "FlowLayoutPanelExFullDesignation":
                            case "FlowLayoutPanelExPartSalaried":
                            case "FlowLayoutPanelExPartClose":
                            case "FlowLayoutPanelExPartDesignation":
                            case "FlowLayoutPanelExTelephone":
                            case "FlowLayoutPanelExWithoutNotice":
                            case "FlowLayoutPanelExFree":
                                try {
                                    // vehicle_dispatch_detail_staffにINSERT
                                    _vehicleDispatchDetailStaffDao.InsertNewStaff(DateTimePickerOperationDate.Value,
                                                                                  Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag),
                                                                                  ((StaffMasterVo)dragItem.Tag).Staff_code);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        break;
                    case "FlowLayoutPanelExFullSalaried":
                    case "FlowLayoutPanelExFullClose":
                    case "FlowLayoutPanelExFullDesignation":
                    case "FlowLayoutPanelExPartSalaried":
                    case "FlowLayoutPanelExPartClose":
                    case "FlowLayoutPanelExPartDesignation":
                    case "FlowLayoutPanelExTelephone":
                    case "FlowLayoutPanelExWithoutNotice":
                    case "FlowLayoutPanelExFree":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExFullEmployees":
                            case "FlowLayoutPanelExLongTerm":
                            case "FlowLayoutPanelExPartTime":
                            case "FlowLayoutPanelExWindow":
                                try {
                                    // vehicle_dispatch_detail_staffからDELETE
                                    _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerOperationDate.Value,
                                                                               Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                               ((StaffMasterVo)dragItem.Tag).Staff_code);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }

                                break;
                            case "FlowLayoutPanelExFullSalaried":
                            case "FlowLayoutPanelExFullClose":
                            case "FlowLayoutPanelExFullDesignation":
                            case "FlowLayoutPanelExPartSalaried":
                            case "FlowLayoutPanelExPartClose":
                            case "FlowLayoutPanelExPartDesignation":
                            case "FlowLayoutPanelExTelephone":
                            case "FlowLayoutPanelExWithoutNotice":
                            case "FlowLayoutPanelExFree":
                                try {
                                    // vehicle_dispatch_detail_staffをUPDATE
                                    _vehicleDispatchDetailStaffDao.UpdateStaff(DateTimePickerOperationDate.Value,
                                                                               Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                               ((StaffMasterVo)dragItem.Tag).Staff_code,
                                                                               Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        break;
                }
                ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " を処理しました");
            }
        }

        /// <summary>
        /// FlowLayoutPanelEx_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlowLayoutPanelEx_DragEnter(object sender, DragEventArgs e) {
            // マウスポインター形状変更
            //
            // DragDropEffects
            //  Copy  :データがドロップ先にコピーされようとしている状態
            //  Move  :データがドロップ先に移動されようとしている状態
            //  Scroll:データによってドロップ先でスクロールが開始されようとしている状態、あるいは現在スクロール中である状態
            //  All   :上の3つを組み合わせたもの
            //  Link  :データのリンクがドロップ先に作成されようとしている状態
            //  None  :いかなるデータもドロップ先が受け付けようとしない状態
            switch(((FlowLayoutPanelEx)sender).Name) {
                case "SetControlEx":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExFullEmployees":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 10 || ((StaffMasterVo)dragItem.Tag).Belongs == 11)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExLongTerm":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if((((StaffMasterVo)dragItem.Tag).Belongs == 20 || ((StaffMasterVo)dragItem.Tag).Belongs == 21) && ((StaffMasterVo)dragItem.Tag).Job_form == 10)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExPartTime":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 12 || ((StaffMasterVo)dragItem.Tag).Job_form == 12)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExWindow":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if((((StaffMasterVo)dragItem.Tag).Belongs == 20 || ((StaffMasterVo)dragItem.Tag).Belongs == 21) && ((StaffMasterVo)dragItem.Tag).Job_form == 11)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExCar":
                case "FlowLayoutPanelExChecking":
                case "FlowLayoutPanelExRepair":
                case "FlowLayoutPanelExVehicleInspection":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExFullSalaried":
                case "FlowLayoutPanelExFullClose":
                case "FlowLayoutPanelExFullDesignation":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 20 || ((StaffMasterVo)dragItem.Tag).Belongs == 21)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExPartSalaried":
                case "FlowLayoutPanelExPartClose":
                case "FlowLayoutPanelExPartDesignation":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 12)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExTelephone":
                case "FlowLayoutPanelExWithoutNotice":
                    if(e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExFree":
                    if(e.Data != null && (e.Data.GetDataPresent(typeof(CarLabelEx)) || e.Data.GetDataPresent(typeof(StaffLabelEx)))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
            }
        }

        /// <summary>
        /// SetLabelExを移動できるかをチェックする
        /// true:移動可能 false:移動不可
        /// ※CarLabelやStaffLabelが存在する場合は移動を禁止する
        /// </summary>
        /// <returns></returns>
        private bool CheckSetControlEx(SetLabelEx dragItem) {
            SetControlEx dragItemForSetControlEx = (SetControlEx)dragItem.Parent;
            // 対象のSetControlExにはDragしたSetLabelExが入っているので”Count == 1”となる
            return dragItemForSetControlEx.Controls.Count == 1 ? true : false;
        }

        /// <summary>
        /// SetTableLayoutPanelLeftSide
        /// 左サイドパネルの開閉処理
        /// </summary>
        /// <param name="flag"></param>
        private void SetTableLayoutPanelLeftSide(bool flag) {
            TableLayoutPanelBase.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, flag ? 364F : 34F);
        }

        /// <summary>
        /// SetTableLayoutPanelRightSide
        /// 右サイドパネルの開閉処理
        /// </summary>
        /// <param name="flag"></param>
        private void SetTableLayoutPanelRightSide(bool flag) {
            TableLayoutPanelBase.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, flag ? 364F : 34F);
        }

        /// <summary>
        /// 左側Tabをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlExLeft_Click(object sender, EventArgs e) {
            if(_TabControlLeftOpenFlag) {
                if(((TabControlEx)sender).SelectedIndex == _TabControlLeftOpenBeforeIndex) {
                    _TabControlLeftOpenFlag = false;
                    SetTableLayoutPanelLeftSide(false);
                } else {
                    _TabControlLeftOpenBeforeIndex = ((TabControlEx)sender).SelectedIndex;
                }
            } else {
                _TabControlLeftOpenFlag = true;
                SetTableLayoutPanelLeftSide(true);
                _TabControlLeftOpenBeforeIndex = ((TabControlEx)sender).SelectedIndex;
            }
        }

        /// <summary>
        /// 右側Tabをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlExRight_Click(object sender, EventArgs e) {
            if(_TabControlRightOpenFlag) {
                if(((TabControlEx)sender).SelectedIndex == _TabControlRightOpenBeforeIndex) {
                    _TabControlRightOpenFlag = false;
                    SetTableLayoutPanelRightSide(false);
                } else {
                    _TabControlRightOpenBeforeIndex = ((TabControlEx)sender).SelectedIndex;
                }
            } else {
                _TabControlRightOpenFlag = true;
                SetTableLayoutPanelRightSide(true);
                _TabControlRightOpenBeforeIndex = ((TabControlEx)sender).SelectedIndex;
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
        /// VehicleDispatchBoad_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchBoad_FormClosing(object sender, FormClosingEventArgs e) {
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
    }
}