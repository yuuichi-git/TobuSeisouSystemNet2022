using System.Drawing.Printing;
using System.Globalization;

using CarRegister;

using Common;

using ControlEx;

using Dao;

using HighWayReport;

using Microsoft.VisualBasic.Devices;

using RollCall;

using Staff;

using SubstituteSheet;

using VehicleDispatchConvert;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        private readonly InitializeForm _initializeForm = new();
        private readonly TableLayoutPanelEx[] _arrayTableLayoutPanelEx = new TableLayoutPanelEx[2];

        /// <summary>
        /// SetControlEx 退避用
        /// </summary>
        private SetControlEx EvacuationSetControlEx;
        /// <summary>
        /// FlowLayoutPanelEx 退避用
        /// </summary>
        private FlowLayoutPanelEx EvacuationFlowLayoutPanelEx;
        /// <summary>
        /// SetLabelEx 退避用
        /// </summary>
        private SetLabelEx EvacuationSetLabelEx;
        /// <summary>
        /// CarLabelEx 退避用
        /// </summary>
        private CarLabelEx EvacuationCarLabelEx;
        /// <summary>
        /// StaffLabelEx 退避用
        /// </summary>
        private StaffLabelEx EvacuationStaffLabelEx;

        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;
        private TriggerCheckDao _triggerCheckDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        private readonly List<SetMasterVo> _listSetMasterVo;
        private List<SetMasterVo> _listDeepCopySetMasterVo;
        private readonly List<CarMasterVo> _listCarMasterVo;
        private List<CarMasterVo> _listDeepCopyCarMasterVo;
        private List<VehicleDispatchDetailCarVo> _listVehicleDispatchDetailCarVo;
        private readonly List<StaffMasterVo> _listStaffMasterVo;
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
        /*
         * DragDrop操作をした瞬間の日時を保持する
         */
        private DateTime _lastOperateDateTime = DateTime.Now;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
            /*
             * 日付
             */
            // 日付を初期化
            DateTimePickerJpExOperationDate.SetValue(DateTime.Now);
            // InitializeComponentの後に初期化してね
            _arrayTableLayoutPanelEx = new TableLayoutPanelEx[] { TableLayoutPanelEx1, TableLayoutPanelEx2 };
            /*
             * Left
             */
            SetTableLayoutPanelLeftSide(false);
            /*
             * Center
             */
            ToolStripStatusLabelMemory.Text = ""; // メモリー使用量
            ToolStripStatusLabelLastUpdate.Text = ""; // 最終更新日時
            ToolStripStatusLabelStatus.Text = ""; // ステータス
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
            _triggerCheckDao = new TriggerCheckDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
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
            /*
             * 最終更新日時
             */
            DateTime? dateTime = _triggerCheckDao.GetLastUpdate(DateTimePickerJpExOperationDate.GetValue());
            ToolStripStatusLabelLastUpdate.Text = dateTime != null ? string.Concat(dateTime) : "更新記録なし";
        }

        /// <summary>
        /// TabControlExCenter
        /// </summary>
        private void CreateLabelForVehicleDispatchBoad() {
            /*
             * レコードの有無確認
             */
            if(!_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                MessageBox.Show(MessageText.Message302, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // レイアウトロジックを非活性化
            _arrayTableLayoutPanelEx[0].SuspendLayout();
            _arrayTableLayoutPanelEx[1].SuspendLayout();
            /*
             * DeepCopy
             * 2023-03-22 なんとなくDeepCopy周りでのエラーな気がしたので改良してみた。
             */
            //_listDeepCopySetMasterVo = new CopyUtility().DeepCopy(_listSetMasterVo.FindAll(x => x.Delete_flag == false));
            //_listDeepCopyCarMasterVo = new CopyUtility().DeepCopy(_listCarMasterVo.FindAll(x => x.Delete_flag == false));
            _listDeepCopySetMasterVo = new CopyUtility().DeepCopy(_listSetMasterVo);
            _listDeepCopyCarMasterVo = new CopyUtility().DeepCopy(_listCarMasterVo);
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

            List<VehicleDispatchDetailVo> listVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue());
            int tabNumber = 0;
            int column = 0;
            int row = 0;
            for(int i = 0; i < 150; i++) {
                /*
                 * 共通設定
                 */
                tabNumber = i / 75;
                column = i % 25;
                row = i / 25 % 3;
                VehicleDispatchDetailVo? vehicleDispatchDetailVo = listVehicleDispatchDetailVo.Find(x => x.Cell_number == i + 1);
                var setControlEx = new SetControlEx(i);
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
                    setControlEx.ContactInformationFlag = vehicleDispatchDetailVo.Contact_infomation_flag;
                    setControlEx.ClassificationFlag = vehicleDispatchDetailVo.Classification_flag;
                    setControlEx.LastRollCallFlag = vehicleDispatchDetailVo.Last_roll_call_flag;
                    setControlEx.ShiftCode = vehicleDispatchDetailVo.Shift_code;
                    /*
                     * 2023-03-28 Findに対するNullチェックを入れる
                     */
                    SetMasterVo? setMasterVo = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code);
                    if(setMasterVo is not null) {
                        setControlEx.CreateLabel(setMasterVo,
                                                 vehicleDispatchDetailVo,
                                                 ContextMenuStripSetLabel);
                    } else {
                        MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(SetLabel)"));
                    }
                }
                /*
                 * CarLabel
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Car_code != 0) {
                    /*
                     * 2023-03-28 Findに対するNullチェックを入れる
                     */
                    CarMasterVo? carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                    if(carMasterVo is not null) {
                        setControlEx.CreateLabel(vehicleDispatchDetailVo,
                                                 carMasterVo,
                                                 ContextMenuStripCarLabel);
                        _listDeepCopyCarMasterVo?.RemoveAll(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                    } else {
                        MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(CarLabel)"));
                    }

                }
                /*
                 * StaffLabel1
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_1 != 0) {
                    /*
                     * 2023-03-28 Findに対するNullチェックを入れる
                     */
                    StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                    if(staffMasterVo is not null) {
                        setControlEx.CreateLabel(0,
                                                 staffMasterVo,
                                                 vehicleDispatchDetailVo.Operator_1_proxy_flag,
                                                 tenkoModeFlag,
                                                 vehicleDispatchDetailVo.Operator_1_roll_call_flag,
                                                 vehicleDispatchDetailVo.Operator_1_note.Length > 0 ? true : false,
                                                 vehicleDispatchDetailVo.Operator_1_occupation,
                                                 ContextMenuStripStaffLabel);
                        _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                        // ToolTip
                        ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 2), vehicleDispatchDetailVo.Operator_1_note);
                    } else {
                        MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel1)"));
                    }
                }
                /*
                 * StaffLabel2
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_2 != 0) {
                    /*
                     * 2023-03-28 Findに対するNullチェックを入れる
                     */
                    StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                    if(staffMasterVo is not null) {
                        setControlEx.CreateLabel(1,
                                                 staffMasterVo,
                                                 vehicleDispatchDetailVo.Operator_2_proxy_flag,
                                                 tenkoModeFlag,
                                                 vehicleDispatchDetailVo.Operator_2_roll_call_flag,
                                                 vehicleDispatchDetailVo.Operator_2_note.Length > 0 ? true : false,
                                                 vehicleDispatchDetailVo.Operator_2_occupation,
                                                 ContextMenuStripStaffLabel);
                        _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                        // ToolTip
                        ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 3), vehicleDispatchDetailVo.Operator_2_note);
                    } else {
                        MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel2)"));
                    }

                }
                /*
                 * StaffLabel3
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_3 != 0) {
                    /*
                     * 2023-03-28 Findに対するNullチェックを入れる
                     */
                    StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3);
                    if(staffMasterVo is not null) {
                        setControlEx.CreateLabel(2,
                                                 staffMasterVo,
                                                 vehicleDispatchDetailVo.Operator_3_proxy_flag,
                                                 tenkoModeFlag,
                                                 vehicleDispatchDetailVo.Operator_3_roll_call_flag,
                                                 vehicleDispatchDetailVo.Operator_3_note.Length > 0 ? true : false,
                                                 vehicleDispatchDetailVo.Operator_3_occupation,
                                                 ContextMenuStripStaffLabel);
                        _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3);
                        // ToolTip
                        ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 4), vehicleDispatchDetailVo.Operator_3_note);
                    } else {
                        MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel3)"));
                    }
                }
                /*
                 * StaffLabel4
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_4 != 0) {
                    /*
                     * 2023-03-28 Findに対するNullチェックを入れる
                     */
                    StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4);
                    if(staffMasterVo is not null) {
                        setControlEx.CreateLabel(3,
                                                 staffMasterVo,
                                                 vehicleDispatchDetailVo.Operator_4_proxy_flag,
                                                 tenkoModeFlag,
                                                 vehicleDispatchDetailVo.Operator_4_roll_call_flag,
                                                 vehicleDispatchDetailVo.Operator_4_note.Length > 0 ? true : false,
                                                 vehicleDispatchDetailVo.Operator_4_occupation,
                                                 ContextMenuStripStaffLabel);
                        _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4);
                        // ToolTip
                        ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 5), vehicleDispatchDetailVo.Operator_4_note);
                    } else {
                        MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel4)"));
                    }
                }

                setControlEx.Event_SetControlEx_Click += new EventHandler(this.SetControlEx_Click);
                setControlEx.Event_SetControlEx_DragDrop += new DragEventHandler(this.SetControlEx_DragDrop);
                setControlEx.Event_SetControlEx_DragEnter += new DragEventHandler(this.SetControlEx_DragEnter);
                // DoubleClickを有効にするために、Clickを無効にしている
                //setControlEx.Event_SetLabelEx_Click += new EventHandler(this.SetLabelEx_Click);
                setControlEx.Event_SetLabelEx_DoubleClick += new EventHandler(this.SetLabelEx_DoubleClick);
                setControlEx.Event_SetLabelEx_MouseMove += new MouseEventHandler(this.SetLabelEx_MouseMove);
                setControlEx.Event_CarLabelEx_Click += new EventHandler(this.CarLabelEx_Click);
                setControlEx.Event_CarLabelEx_MouseMove += new MouseEventHandler(this.CarLabelEx_MouseMove);
                setControlEx.Event_StaffLabelEx_Click += new EventHandler(this.StaffLabelEx_Click);
                setControlEx.Event_StaffLabelEx_MouseMove += new MouseEventHandler(this.StaffLabelEx_MouseMove);
                _arrayTableLayoutPanelEx[tabNumber].Controls.Add(setControlEx,
                                                                 column,
                                                                 row);
            }
            // レイアウトロジックを活性化
            _arrayTableLayoutPanelEx[1].ResumeLayout();
            _arrayTableLayoutPanelEx[0].ResumeLayout();
        }

        /// <summary>
        /// FlowLayoutPanelへの書き出し
        /// </summary>
        private void CreateLabelForFlowLayoutPanelEx() {
            _listVehicleDispatchDetailCarVo = _vehicleDispatchDetailCarDao.SelectVehicleDispatchDetailCar(DateTimePickerJpExOperationDate.GetValue());
            _listVehicleDispatchDetailStaffVo = _vehicleDispatchDetailStaffDao.SelectVehicleDispatchDetailStaff(DateTimePickerJpExOperationDate.GetValue());

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
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 157)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            CarMasterVo? carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            if(carMasterVo != null) {
                                // Controlを作成
                                CarLabelEx carLabelEx = new CarLabelEx(carMasterVo).CreateLabel();
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(CarLabel)"));
                            }
                        }
                        break;
                    case 158: // FlowLayoutPanelExRepair
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 158)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            CarMasterVo? carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            if(carMasterVo != null) {
                                // Controlを作成
                                CarLabelEx carLabelEx = new CarLabelEx(carMasterVo).CreateLabel();
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(CarLabel)"));
                            }
                        }
                        break;
                    case 159: // FlowLayoutPanelExVehicleInspection
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 159)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            CarMasterVo? carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            if(carMasterVo != null) {
                                // Controlを作成
                                CarLabelEx carLabelEx = new CarLabelEx(carMasterVo).CreateLabel();
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(CarLabel)"));
                            }
                        }
                        break;
                    case 160: // FlowLayoutPanelExFullSalaried(組合長期)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 160)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo != null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 161: // FlowLayoutPanelExFullClose(組合長期)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 161)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 162: // FlowLayoutPanelExFullDesignation(組合長期)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 162)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 163: // FlowLayoutPanelExPartSalaried(アルバイト)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 163)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 164: // FlowLayoutPanelExPartClose(アルバイト)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 164)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 165: // FlowLayoutPanelExPartDesignation(アルバイト)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 165)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 166: // FlowLayoutPanelExTelephone
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 166)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 167: // FlowLayoutPanelExWithoutNotice
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 167)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
                        }
                        break;
                    case 168: // FlowLayoutPanelExFree
                        /*
                         * CarLabelExを作成
                         */
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 168).OrderBy(x => x.Insert_ymd_hms)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            CarMasterVo? carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            if(carMasterVo is not null) {
                                // Controlを作成
                                CarLabelEx carLabelEx = new CarLabelEx(carMasterVo).CreateLabel();
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
                                FlowLayoutPanelExFree.Controls.Add(carLabelEx);
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(CarLabel)"));
                            }
                        }
                        /*
                         * StaffLabelExを作成
                         */
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 168)) {
                            /*
                             * 2023-03-28 Findに対するNullチェックを入れる
                             */
                            StaffMasterVo? staffMasterVo = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            if(staffMasterVo is not null) {
                                // Controlを作成
                                StaffLabelEx staffLabelEx = new StaffLabelEx(staffMasterVo,
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
                            } else {
                                MessageBox.Show(string.Concat("cell_number = ", i.ToString(), " でNullを検出しました。(StaffLabel)"));
                            }
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
            foreach(SetMasterVo deepCopySetMasterVo in _listDeepCopySetMasterVo.FindAll(x => x.Classification_code != 10 && x.Classification_code != 11)
                                                                       .OrderBy(x => x.Classification_code).ThenBy(x => x.Set_name)) {
                SetLabelEx setLabelEx = new SetLabelEx(deepCopySetMasterVo).CreateLabel();
                // プロパティを設定
                setLabelEx.ContextMenuStrip = ContextMenuStripSetLabel;
                /*
                 * イベントを設定
                 */
                // DoubleClickを有効にするために、Clickを無効にしている
                //setLabelEx.Click += new EventHandler(SetLabelEx_Click);
                setLabelEx.DoubleClick += new EventHandler(SetLabelEx_DoubleClick);
                setLabelEx.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                FlowLayoutPanelExSet.Controls.Add(setLabelEx);
            }
            // FlowLayoutPanelExCar
            foreach(CarMasterVo deepCopyCarMasterVo in _listDeepCopyCarMasterVo.OrderBy(x => x.Disguise_kind_1)) {
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
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 10 || x.Belongs == 11) && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
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
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form == 10 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
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
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 12 || x.Belongs == 13) && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
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
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form == 11 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
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
        /// ToolStripMenuItemMenu_DropDownOpening
        /// メニューバーを開いたときの挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMenu_DropDownOpening(object sender, EventArgs e) {
            // 表示されている配車表を印刷(B4)する
            ToolStripMenuItemPrint.Enabled = tenkoModeFlag;
        }

        /// <summary>
        /// ContextMenuStrip_Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opened(object sender, EventArgs e) {
            switch(((ContextMenuStrip)sender).Name) {
                /*
                 * ContextMenuStripSetLabel
                 */
                case "ContextMenuStripSetLabel":
                    /*
                     * SetControlEx上でクリックされた時
                     */
                    if(((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx)) {
                        // SetControlExを退避
                        EvacuationSetControlEx = (SetControlEx)((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        // SetLabelExを退避
                        EvacuationSetLabelEx = (SetLabelEx)((ContextMenuStrip)sender).SourceControl;
                        SetMasterVo setMasterVo = (SetMasterVo)EvacuationSetLabelEx.Tag;
                        /*
                         * メニューの表示調整
                         */
                        // 出庫地を変更
                        ToolStripMenuItemSetGarageChange.Enabled = true;
                        // 配車先を削除する
                        ToolStripMenuItemSetDelete.Enabled = setMasterVo.Move_flag;
                        // 配車・休車
                        ToolStripMenuItemOperationFlag.Enabled = true;
                        // 雇上・区契
                        ToolStripMenuItemClassification.Enabled = ((SetMasterVo)EvacuationSetLabelEx.Tag).Classification_code == 12 ? true : false;
                        // 連絡事項
                        ToolStripMenuItemContactInformation.Enabled = true;
                        // 作業員付き
                        ToolStripMenuItemAddWorker.Enabled = ((SetMasterVo)EvacuationSetLabelEx.Tag).Classification_code == 12 ? true : false;
                        // 待機
                        ToolStripMenuItemStandByFlag.Enabled = true;
                        // 代車・代番のFAXを作成する
                        ToolStripMenuItemFax.Enabled = (setMasterVo.Contact_method == 11 && DateTimePickerJpExOperationDate.GetValue().Date == DateTime.Now.Date && EvacuationSetControlEx.OperationFlag) ? true : false;
                        //ToolStripMenuItemFax.Enabled = (setMasterVo.Contact_method == 11) ? true : false;
                        // 高速道路使用報告書
                        ToolStripMenuItemHighWayReport.Enabled = EvacuationSetLabelEx.OperationFlag;
                    }
                    /*
                     * FlowLayoutPanelEx上でクリックされた時
                     */
                    if(((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                        // SetControlExを退避
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        /*
                         * メニューの表示調整
                         */
                        // 出庫地を変更
                        ToolStripMenuItemSetGarageChange.Enabled = false;
                        // 配車先を削除する
                        ToolStripMenuItemSetDelete.Enabled = false;
                        // 配車・休車
                        ToolStripMenuItemOperationFlag.Enabled = false;
                        // 雇上・区契
                        ToolStripMenuItemClassification.Enabled = false;
                        // 連絡事項
                        ToolStripMenuItemContactInformation.Enabled = false;
                        // 作業員付き
                        ToolStripMenuItemAddWorker.Enabled = false;
                        // 待機
                        ToolStripMenuItemStandByFlag.Enabled = false;
                        // 代車・代番のFAXを作成する
                        ToolStripMenuItemFax.Enabled = false;
                        // 高速道路使用報告書
                        ToolStripMenuItemHighWayReport.Enabled = false;
                    }
                    break;
                /*
                 * ContextMenuStripCarLabel
                 */
                case "ContextMenuStripCarLabel":
                    /*
                     * SetControlEx上でクリックされた時
                     */
                    if(((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx)) {
                        // SetControlExを退避
                        EvacuationSetControlEx = (SetControlEx)((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        ToolStripMenuItemCarProxyTrue.Enabled = true;
                        ToolStripMenuItemCarProxyFalse.Enabled = true;
                    }

                    /*
                     * FlowLayoutPanelEx上でクリックされた時
                     */
                    if(((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                        // SetControlExを退避
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        ToolStripMenuItemCarProxyTrue.Enabled = false;
                        ToolStripMenuItemCarProxyFalse.Enabled = false;
                    }
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
                    if(((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx)) {
                        // SetControlExを退避
                        EvacuationSetControlEx = (SetControlEx)((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        // StaffLabelExを退避
                        EvacuationStaffLabelEx = (StaffLabelEx)((ContextMenuStrip)sender).SourceControl;
                        /*
                         * メニューの表示調整
                         */
                        ToolStripMenuItemStaffProxyTrue.Enabled = true;
                        ToolStripMenuItemStaffProxyFalse.Enabled = true;
                        ToolStripMenuItemStaffMemo.Enabled = true;
                        // 運転手料金支払い区分
                        ToolStripMenuItemOccupation10.Enabled = true;
                        ToolStripMenuItemOccupation11.Enabled = true;
                    }
                    /*
                     * FlowLayoutPanelEx上でクリックされた時
                     */
                    if(((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                        // SetControlExを退避
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        // StaffLabelExを退避
                        EvacuationStaffLabelEx = (StaffLabelEx)((ContextMenuStrip)sender).SourceControl;
                        /*
                         * メニューの表示調整
                         */
                        ToolStripMenuItemStaffProxyTrue.Enabled = false;
                        ToolStripMenuItemStaffProxyFalse.Enabled = false;
                        // 運転手料金支払い区分
                        ToolStripMenuItemOccupation10.Enabled = false;
                        ToolStripMenuItemOccupation11.Enabled = false;
                        switch(Convert.ToInt32(EvacuationFlowLayoutPanelEx.Tag)) {
                            /*
                             * 左側のFlowLayoutPanelExではStaffメモは使えなくする
                             */
                            case 153:
                            case 154:
                            case 155:
                            case 156:
                                ToolStripMenuItemStaffMemo.Enabled = false;
                                break;
                            default:
                                ToolStripMenuItemStaffMemo.Enabled = true;
                                break;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 印刷イメージを保持
        /// </summary>
        private Bitmap captureImage;
        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                /*
                 * MenuStrip1
                 */
                // 配車表を作成する  tenkoModeFlag
                case "ToolStripMenuItemConvertExcel":
                    /*
                     * VehicleDispatchSimpleのコンストラクタ内でファイルの存在チェックをしている。
                     * コンストラクタ内で終了させるには、例外を発生させてCatchで受け取りReturnする
                     */
                    try {
                        var vehicleDispatchSimple = new VehicleDispatchSimple(_connectionVo, DateTimePickerJpExOperationDate.GetValue());
                        vehicleDispatchSimple.ShowDialog(this);
                    } catch {
                        return;
                    }
                    break;
                // 配車表を印刷する
                case "ToolStripMenuItemPrint":
                    Control targetControl = new();
                    switch(TabControlExCenter.SelectedTab.Name) {
                        case "TabPage1":
                            targetControl = TableLayoutPanelEx1;
                            break;
                        case "TabPage2":
                            targetControl = TableLayoutPanelEx2;
                            break;
                    }
                    captureImage = new CaptureControl().GetCapture(targetControl); //コントロールのイメージを取得する

                    PrinterSettings printerSettings = new();
                    PrintDocument printDocument = new();

                    IEnumerable<PaperSize> paperSizes = printerSettings.PaperSizes.Cast<PaperSize>();
                    PaperSize paperSize = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.B4);
                    printDocument.DefaultPageSettings.PaperSize = paperSize;

                    printDocument.DefaultPageSettings.Landscape = true; // 用紙の向きを設定(横：true、縦：false)
                    printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                    printDocument.Print();

                    captureImage.Dispose();
                    break;
                // 清掃事務所へ提出している本番
                case "ToolStripMenuItemInitializeCleanOffice":
                    MessageBox.Show("ToolStripMenuItemInitializeCleanOffice");
                    break;
                // 社内での本番
                case "ToolStripMenuItemInitializeCompanyOffice":
                    if(_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
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
                // 配車の状態
                case "ToolStripMenuItemOperationFlagTrue":
                    try {
                        _vehicleDispatchDetailDao.SetOperationFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   true);
                        // 配車状態
                        EvacuationSetLabelEx.SetOperationFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemOperationFlagFalse":
                    try {
                        _vehicleDispatchDetailDao.SetOperationFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   false);
                        // 配車状態
                        EvacuationSetLabelEx.SetOperationFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 雇上・区契の別
                case "ToolStripMenuItemYOUJYOU":
                    try {
                        _vehicleDispatchDetailDao.UpdateClassificationFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                           (int)EvacuationSetControlEx.Tag,
                                                                           true);
                        // SetLabelExを雇上の色に変える
                        EvacuationSetLabelEx.SetClassificationFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemKUKEI":
                    try {
                        _vehicleDispatchDetailDao.UpdateClassificationFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                           (int)EvacuationSetControlEx.Tag,
                                                                           false);
                        // SetLabelExを雇上の色に変える
                        EvacuationSetLabelEx.SetClassificationFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 連絡事項
                case "ToolStripMenuItemContactInformationTrue":
                    try {
                        _vehicleDispatchDetailDao.UpdateContactInformationFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                               (int)EvacuationSetControlEx.Tag,
                                                                               true);
                        // SetLabelExを連絡事項ありにする
                        EvacuationSetControlEx.SetContactInformationFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemContactInformationFalse":
                    try {
                        _vehicleDispatchDetailDao.UpdateContactInformationFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                               (int)EvacuationSetControlEx.Tag,
                                                                               false);
                        // SetLabelExを連絡事項なしにする
                        EvacuationSetControlEx.SetContactInformationFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 作業員の配置
                case "ToolStripMenuItemAddWorkerTrue":
                    try {
                        _vehicleDispatchDetailDao.UpdateAddWorkerFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      true);
                        // SetLabelExを雇上の色に変える
                        EvacuationSetLabelEx.SetAddWorkerFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemAddWorkerFalse":
                    try {
                        _vehicleDispatchDetailDao.UpdateAddWorkerFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      false);
                        // SetLabelExを雇上の色に変える
                        EvacuationSetLabelEx.SetAddWorkerFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 配車先を削除
                case "ToolStripMenuItemSetDelete":
                    try {
                        _vehicleDispatchDetailDao.ResetSetLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                (int)EvacuationSetControlEx.Tag);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    SetControlEx setControlEx = (SetControlEx)EvacuationSetLabelEx.Parent;
                    setControlEx.Controls.Remove(EvacuationSetLabelEx);
                    setControlEx.Refresh();
                    break;
                // 配車先メモ
                case "ToolStripMenuItemSetMemo":
                    try {
                        SetMemo setMemo = new SetMemo(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), EvacuationSetControlEx, EvacuationSetLabelEx);
                        setMemo.ShowDialog(this);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // 足立より出庫
                case "ToolStripMenuItemSetGarageAdachi":
                    try {
                        _vehicleDispatchDetailDao.UpdateGarageFlag(DateTimePickerJpExOperationDate.GetValue(),
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
                        _vehicleDispatchDetailDao.UpdateGarageFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   false);
                        // SetLabelExを三郷の色に変える
                        EvacuationSetLabelEx.SetGarageFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 番手なし
                case "ToolStripMenuItemNoneShift":
                    try {
                        _vehicleDispatchDetailDao.UpdateShiftCode(DateTimePickerJpExOperationDate.GetValue(),
                                                                  (int)EvacuationSetControlEx.Tag,
                                                                  0);
                        EvacuationSetLabelEx.SetShiftCode(0);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 番手早番
                case "ToolStripMenuItemFirstShift":
                    try {
                        _vehicleDispatchDetailDao.UpdateShiftCode(DateTimePickerJpExOperationDate.GetValue(),
                                                                  (int)EvacuationSetControlEx.Tag,
                                                                  1);
                        EvacuationSetLabelEx.SetShiftCode(1);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 番手遅番
                case "ToolStripMenuItemLateShift":
                    try {
                        _vehicleDispatchDetailDao.UpdateShiftCode(DateTimePickerJpExOperationDate.GetValue(),
                                                                  (int)EvacuationSetControlEx.Tag,
                                                                  2);
                        EvacuationSetLabelEx.SetShiftCode(2);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 待機を設定
                case "ToolStripMenuItemStandByTrue":
                    try {
                        _vehicleDispatchDetailDao.UpdateStandByFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                    (int)EvacuationSetControlEx.Tag,
                                                                    true);
                        EvacuationSetLabelEx.SetStandByFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // 待機を解除
                case "ToolStripMenuItemStandByFalse":
                    try {
                        _vehicleDispatchDetailDao.UpdateStandByFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                    (int)EvacuationSetControlEx.Tag,
                                                                    false);
                        EvacuationSetLabelEx.SetStandByFlag(false);
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
                            new SubstituteSheet1(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).Show(this);
                            break;
                        case 1310201: // 中央ペット７
                        case 1310202: // 中央ペット８
                            new SubstituteSheet1(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).Show(this);
                            break;
                        case 1312101: // 足立１８
                        case 1312102: // 足立２３
                        case 1312103: // 足立２４
                        case 1312104: // 足立３８
                        case 1312105: // 足立不燃４
                            new SubstituteSheet1(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).Show(this);
                            break;
                        case 1312204: // 葛飾１１
                        case 1312209: // 葛飾３２
                        case 1312210: // 葛飾５４
                            new SubstituteSheet1(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).Show(this);
                            break;
                        case 1312203: // 小岩４
                        case 1312208: // 小岩５
                            new SubstituteSheet1(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).Show(this);
                            break;
                        case 1312011: // 桜台2-1_
                        case 1312012: // 桜台2-2_
                            new SubstituteSheet2(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).Show(this);
                            break;
                        default:
                            MessageBox.Show("代車代番のFAXを作成画面は作成中です。提案を受付ています。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    break;
                // 高速道路使用報告書
                case "ToolStripMenuItemHighWayReport":
                    HighWayReportPaper highWayReportPaper = new HighWayReportPaper(EvacuationSetControlEx);
                    highWayReportPaper.ShowDialog(this);
                    break;
                /*
                 * ContextMenuStripCarLabel
                 */
                // 車両詳細
                case "ToolStripMenuItemCarDetail":
                    CarPaper carPaper = new CarPaper(_connectionVo,((CarMasterVo)EvacuationCarLabelEx.Tag).Car_code);
                    carPaper.ShowDialog(this);
                    break;
                // 代車処理
                case "ToolStripMenuItemCarProxyTrue":
                    try {
                        /*
                         * SetControlEx上でクリックされた時
                         */
                        if(EvacuationCarLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetCarProxyFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      true);
                            EvacuationCarLabelEx.SetProxyFlag(true);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // 代車処理
                case "ToolStripMenuItemCarProxyFalse":
                    try {
                        /*
                         * SetControlEx上でクリックされた時
                         */
                        if(EvacuationCarLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetCarProxyFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      false);
                            EvacuationCarLabelEx.SetProxyFlag(false);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * ContextMenuStripStaffLabel
                 */
                // 従事者詳細
                case "ToolStripMenuItemStaffDetail":
                    var staffPaper = new StaffPaper(_connectionVo, ((StaffMasterVo)EvacuationStaffLabelEx.Tag).Staff_code);
                    staffPaper.ShowDialog(this);
                    break;
                // 代番処理
                case "ToolStripMenuItemStaffProxyTrue":
                    try {
                        /*
                         * SetControlEx上でクリックされた時
                         */
                        if(EvacuationStaffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetStaffProxyFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                        (int)EvacuationSetControlEx.Tag,
                                                                        EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                        true);
                            EvacuationStaffLabelEx.SetProxyFlag(true);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // 代番処理
                case "ToolStripMenuItemStaffProxyFalse":
                    try {
                        /*
                         * SetControlEx上でクリックされた時
                         */
                        if(EvacuationStaffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetStaffProxyFlag(DateTimePickerJpExOperationDate.GetValue(),
                                                                        (int)EvacuationSetControlEx.Tag,
                                                                        EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                        false);
                            EvacuationStaffLabelEx.SetProxyFlag(false);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // メモを作成・編集
                case "ToolStripMenuItemStaffMemo":
                    try {
                        StaffMemo staffMemo = new StaffMemo(_connectionVo,
                                                            DateTimePickerJpExOperationDate.GetValue(),
                                                            EvacuationSetControlEx,
                                                            EvacuationFlowLayoutPanelEx,
                                                            EvacuationStaffLabelEx);
                        staffMemo.ShowDialog(this);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 職種を変更（10:運転手）
                 */
                case "ToolStripMenuItemOccupation10":
                    try {
                        _vehicleDispatchDetailDao.UpdateOccupation(DateTimePickerJpExOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                   10);
                        EvacuationStaffLabelEx.SetOccupation(10);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 職種を変更（11:作業員）
                 */
                case "ToolStripMenuItemOccupation11":
                    try {
                        _vehicleDispatchDetailDao.UpdateOccupation(DateTimePickerJpExOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                   11);
                        EvacuationStaffLabelEx.SetOccupation(11);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 電話連絡のマークを付ける
                 */
                case "ToolStripMenuItemTelephoneMarkTrue":
                    EvacuationStaffLabelEx.SetTelephoneMark(true);
                    break;
                case "ToolStripMenuItemTelephoneMarkFalse":
                    EvacuationStaffLabelEx.SetTelephoneMark(false);
                    break;
            }
        }

        /// <summary>
        /// InsertVehicleDispatchDetail
        /// </summary>
        private void InsertVehicleDispatchDetail() {
            List<VehicleDispatchDetailVo> listvehicleDispatchDetailVo = new();
            DateTime _defaultDate = new DateTime(1900, 01, 01);
            /*
             * INSERTを実行する前に対象レコードが存在していたらDELETEする
             * ①VehicleDispatchDetailの対象レコードをDELETE
             * ②vehicle_dispatch_detail_carの対象レコードをDELETE
             * ③vehicle_dispatch_detail_staffの対象レコードをDELETE
             */
            if(_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                try {
                    _vehicleDispatchDetailDao.DeleteVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue());
                    _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerJpExOperationDate.GetValue());
                    _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue());
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            /*
             * vehicle_dispatch_head/vehicle_dispatch_bodyからvehicle_dispatch_detailを作成する
             */
            // 社内での本番をList<VehicleDispatchDetailVo>型で取得
            List<VehicleDispatchDetailVo> listVehicleDispatch = _vehicleDispatchDetailDao.SelectVehicleDispatch(DateTimePickerJpExOperationDate.GetValue().AddMonths(-3),DateTimePickerJpExOperationDate.GetValue().ToString("ddd"));
            // VehicleDispatchDetailVoの不足情報を加える
            foreach(var vehicleDispatchDetail in listVehicleDispatch.OrderBy(x => x.Cell_number)) {
                VehicleDispatchDetailVo vehicleDispatchDetailVo = new();
                vehicleDispatchDetailVo.Cell_number = vehicleDispatchDetail.Cell_number;
                vehicleDispatchDetailVo.Operation_date = DateTimePickerJpExOperationDate.GetValue();
                vehicleDispatchDetailVo.Operation_flag = vehicleDispatchDetail.Day_of_week != string.Empty; // vehicle_dispatch_body.day_of_weekがstring.EmptydeでなければTrue(稼働)
                vehicleDispatchDetailVo.Garage_flag = vehicleDispatchDetail.Garage_flag;
                vehicleDispatchDetailVo.Five_lap = vehicleDispatchDetail.Five_lap;
                vehicleDispatchDetailVo.Move_flag = vehicleDispatchDetail.Move_flag;
                vehicleDispatchDetailVo.Day_of_week = vehicleDispatchDetail.Day_of_week;
                vehicleDispatchDetailVo.Stand_by_flag = false;
                vehicleDispatchDetailVo.Classification_flag = false;
                vehicleDispatchDetailVo.Add_worker_flag = false;
                vehicleDispatchDetailVo.Set_code = vehicleDispatchDetail.Set_code;
                vehicleDispatchDetailVo.Set_note = vehicleDispatchDetail.Set_note; // vehicle_dispatch_body.note
                vehicleDispatchDetailVo.Car_code = vehicleDispatchDetail.Car_code;
                vehicleDispatchDetailVo.Car_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Car_note = ""; // 値を作成
                vehicleDispatchDetailVo.Number_of_people = vehicleDispatchDetail.Number_of_people;
                vehicleDispatchDetailVo.Operator_code_1 = vehicleDispatchDetail.Operator_code_1;
                vehicleDispatchDetailVo.Operator_1_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = _defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_1_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_1_occupation = vehicleDispatchDetail.Operator_1_occupation; // staff_masterに登録されている情報
                vehicleDispatchDetailVo.Operator_code_2 = vehicleDispatchDetail.Operator_code_2;
                vehicleDispatchDetailVo.Operator_2_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = _defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_2_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_2_occupation = vehicleDispatchDetail.Operator_2_occupation; // staff_masterに登録されている情報
                vehicleDispatchDetailVo.Operator_code_3 = vehicleDispatchDetail.Operator_code_3;
                vehicleDispatchDetailVo.Operator_3_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = _defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_3_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_3_occupation = vehicleDispatchDetail.Operator_3_occupation; // staff_masterに登録されている情報
                vehicleDispatchDetailVo.Operator_code_4 = vehicleDispatchDetail.Operator_code_4;
                vehicleDispatchDetailVo.Operator_4_proxy_flag = false; // 値を作成
                vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = _defaultDate; // 値を作成
                vehicleDispatchDetailVo.Operator_4_note = ""; // 値を作成
                vehicleDispatchDetailVo.Operator_4_occupation = vehicleDispatchDetail.Operator_4_occupation; // staff_masterに登録されている情報
                vehicleDispatchDetailVo.Last_roll_call_flag = false; // 値を作成
                vehicleDispatchDetailVo.Last_plant_count = 0; // 値を作成
                vehicleDispatchDetailVo.Last_plant_name = ""; // 値を作成
                vehicleDispatchDetailVo.Last_plant_hm = ""; // 値を作成
                vehicleDispatchDetailVo.Last_roll_call_hm = ""; // 値を作成
                vehicleDispatchDetailVo.Insert_pc_name = Environment.MachineName; // 値を作成
                vehicleDispatchDetailVo.Insert_ymd_hms = DateTime.Now; // 値を作成
                vehicleDispatchDetailVo.Update_pc_name = ""; // 値を作成
                vehicleDispatchDetailVo.Update_ymd_hms = _defaultDate; // 値を作成
                vehicleDispatchDetailVo.Delete_pc_name = ""; // 値を作成
                vehicleDispatchDetailVo.Delete_ymd_hms = _defaultDate; // 値を作成
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
        private void SetControlEx_DragDrop(object sender, DragEventArgs e) {
            // Controlを取得
            SetControlEx setControlEx = (SetControlEx)sender;
            /*
             * 2023-04-29
             * ここで画面とDBのデータの同一性をチェックして、更新可能か調べる
             */
            if(e.Data is not null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                switch(dragItem.Parent) {
                    case SetControlEx:

                        break;
                    case FlowLayoutPanelEx:

                        break;
                }
                goto JMP1;
            }
            if(e.Data is not null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                switch(dragItem.Parent) {
                    case SetControlEx:

                        break;
                    case FlowLayoutPanelEx:

                        break;
                }
                goto JMP1;
            }
            if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                /*
                 * 画面座標(X, Y)を、setControlEx上のクライアント座標に変換する
                 */
                Point point = setControlEx.PointToClient(new Point(e.X, e.Y));
                int staffCellNumber = 0;
                switch(point.Y) {
                    // SetLabelかCarLabel
                    case int i when i <= 140:
                        return; // SetLabelかCarLabelの位置でDropされた場合はReturnする
                    // 運転手
                    case int i when i <= 180:
                        staffCellNumber = 1;
                        break;
                    // 作業員１
                    case int i when i <= 220:
                        staffCellNumber = 2;
                        break;
                    // 作業員２
                    case int i when i <= 260:
                        staffCellNumber = 3;
                        break;
                    // 作業員３
                    case int i when i <= 300:
                        staffCellNumber = 4;
                        break;
                }

                int dragCellNumber = 0;
                int dragStaffCellNumber = 0;
                int dbDragStaffCode = 0;
                int dropCellNumber = Convert.ToInt32(setControlEx.Tag);
                int dbDropStaffCode = 0;
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                switch(dragItem.Parent) {
                    case SetControlEx:
                        // Drag元のCellNumberを取得
                        dragCellNumber = Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag);
                        // Drag元のStaffLabelの位置を取得
                        dragStaffCellNumber = ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row - 1;
                        // Drag元のDB上のStaffCodeを取得
                        dbDragStaffCode = _vehicleDispatchDetailDao.GetStaffCodeTableLayoutPanelEx(DateTimePickerJpExOperationDate.GetValue(), dragCellNumber, dragStaffCellNumber);
                        // Drop先のDB上のStaffCodeを取得
                        dbDropStaffCode = _vehicleDispatchDetailDao.GetStaffCodeTableLayoutPanelEx(DateTimePickerJpExOperationDate.GetValue(), dropCellNumber, staffCellNumber);
                        /*
                         * ①Drag側を調査（画面上のStaffCodeとDB上のStaffCodeが同一かどうか？）
                         * ②Drop側を調査（DB上のStaffCodeが０かどうか？）
                         */
                        if(dbDragStaffCode != ((StaffMasterVo)dragItem.Tag).Staff_code) {
                            MessageBox.Show(MessageText.Message303, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        if(dbDropStaffCode != 0) {
                            MessageBox.Show(MessageText.Message304, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        break;
                    case FlowLayoutPanelEx:
                        /*
                         * Drag元のCellNumberを取得
                         * 160-162(組合長期)
                         * 163-165(アルバイト)
                         * 166-167(朝電・無断)
                         * 168(CarLabelとStaffLabelが混在している)
                         */
                        // Drag元のDB上のStaffCodeの有無を保持
                        bool dbDragStaffExist = false;
                        dragCellNumber = Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag);
                        /*
                         * Dragされた親Controlによって処理を返る
                         */
                        switch(dragCellNumber) {
                            case int i when i >= 151 && i <= 156: // 左側のTab(DB上で管理されていないLabel)

                                break;
                            case int i when i >= 157 && i <= 159: // 車両

                                break;
                            case int i when i >= 160 && i <= 168: // 組合長期・アルバイト・朝電/無断
                                // Drag元のDB上のStaffCodeの有無を取得
                                dbDragStaffExist = _vehicleDispatchDetailDao.GetStaffExistFlowLayoutPanelEx(DateTimePickerJpExOperationDate.GetValue(), dragCellNumber, ((StaffMasterVo)dragItem.Tag).Staff_code);
                                // Drop先のDB上のStaffCodeを取得
                                dbDropStaffCode = _vehicleDispatchDetailDao.GetStaffCodeTableLayoutPanelEx(DateTimePickerJpExOperationDate.GetValue(), dropCellNumber, staffCellNumber);
                                /*
                                 * ①Drag側を調査（DB上にDrag元のLabelが存在しているか？）
                                 * ②Drop側を調査（DB上のStaffCodeが０かどうか？）
                                 */
                                if(!dbDragStaffExist) {
                                    MessageBox.Show(MessageText.Message303, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                                if(dbDropStaffCode != 0) {
                                    MessageBox.Show(MessageText.Message304, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                                break;
                        }
                        break;
                }
                goto JMP1;
            }

        /*
         * 更新できる状態の場合の処理はここから
         */
        JMP1:

            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            /*
             * SetLabelEx
             */
            if(e.Data is not null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
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
                            if(setControlEx is not null && setControlEx.GetControlFromPosition(0, 0) == null) {
                                /*
                                 * 移動許可を調査する
                                 */
                                if(CheckSetControlEx(dragItem)) {
                                    try {
                                        _vehicleDispatchDetailDao.CopySetLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                               Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                               Convert.ToInt32(setControlEx.Tag));
                                        _vehicleDispatchDetailDao.ResetSetLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                            if(setControlEx is not null && setControlEx.GetControlFromPosition(0, 0) == null) {
                                /*
                                 * Tab(配車先)からのDrop
                                 */
                                SetLabelEx newDropItem = new SetLabelEx((SetMasterVo)dragItem.Tag).CreateLabel();
                                // プロパティを設定
                                newDropItem.ContextMenuStrip = ContextMenuStripSetLabel;
                                /*
                                 * イベントを設定
                                 */
                                // DoubleClickを有効にするために、Clickを無効にしている
                                //newDropItem.Click += new EventHandler(SetLabelEx_Click);
                                newDropItem.DoubleClick += new EventHandler(SetLabelEx_DoubleClick);
                                newDropItem.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                                _vehicleDispatchDetailDao.CreateSetLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                         Convert.ToInt32(setControlEx.Tag),
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
            if(e.Data is not null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        if(setControlEx is not null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                _vehicleDispatchDetailDao.MoveCarLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                       Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                       Convert.ToInt32(setControlEx.Tag));
                                _vehicleDispatchDetailDao.ResetCarLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                        if(setControlEx is not null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detailをUPDATE
                                _vehicleDispatchDetailDao.CreateCarLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                        if(setControlEx is not null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detailをUPDATE
                                _vehicleDispatchDetailDao.CreateCarLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                         Convert.ToInt32(setControlEx.Tag),
                                                                         (CarMasterVo)dragItem.Tag);
                                // vehicle_dispatch_detail_carからDELETE
                                _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerJpExOperationDate.GetValue(),
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
                        if(setControlEx is not null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detailをUPDATE
                                _vehicleDispatchDetailDao.CreateCarLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                         Convert.ToInt32(setControlEx.Tag),
                                                                         (CarMasterVo)dragItem.Tag);
                                // vehicle_dispatch_detail_carからDELETE
                                _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerJpExOperationDate.GetValue(),
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
            if(setControlEx is not null && e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 Convert.ToInt32(setControlEx.Tag), 2);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 Convert.ToInt32(setControlEx.Tag), 3);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 Convert.ToInt32(setControlEx.Tag), 4);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 Convert.ToInt32(setControlEx.Tag), 5);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 1,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 2,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(operationDate: DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 3,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 4,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 1,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 2,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.Value,
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 3,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                        _vehicleDispatchDetailDao.MoveStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 4,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaffからDELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
            /*
             * 最終更新日時を退避する
             */
            _lastOperateDateTime = DateTime.Now;
        }

        /// <summary>
        /// SetControlEx_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        // DoubleClickを有効にするために、Clickを無効にしている
        //private void SetLabelEx_Click(object sender, EventArgs e) {
        //    MessageBox.Show("SetLabelEx_Click");
        //}

        /// <summary>
        /// SetLabelEx_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetLabelEx_DoubleClick(object? sender, EventArgs e) {
            if(sender is not null) {
                // SetControlExを退避
                EvacuationSetControlEx = (SetControlEx)((SetLabelEx)sender).Parent;
                // SetLabelExを退避
                EvacuationSetLabelEx = (SetLabelEx)sender;
                /*
                 * 入力ダイアログを開く
                 */
                RollCallDialog rollCallDialog = new RollCallDialog(_connectionVo, DateTimePickerJpExOperationDate.GetValue(), EvacuationSetControlEx, EvacuationSetLabelEx);
                rollCallDialog.ShowDialog(this);
            }
        }

        /// <summary>
        /// SetLabelEx_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if(sender is not null && e.Button == MouseButtons.Left)
                ((SetLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        private void CarLabelEx_Click(object? sender, EventArgs e) {
            //MessageBox.Show("CarLabelEx_Click");
        }

        /// <summary>
        /// CarLabelEx_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if(sender is not null && e.Button == MouseButtons.Left)
                ((CarLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        /// <summary>
        /// StaffLabelEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffLabelEx_Click(object? sender, EventArgs e) {
            if(sender is not null) {
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
                            _vehicleDispatchDetailDao.UpdateRollCallFlag(DateTimePickerJpExOperationDate.GetValue(),
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
        }

        /// <summary>
        /// StaffLabelEx_MouseMove
        /// ドラッグの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if(sender is not null && e.Button == MouseButtons.Left)
                ((StaffLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        /// <summary>
        /// FlowLayoutPanelEx_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlowLayoutPanelEx_DragDrop(object sender, DragEventArgs e) {
            /*
             * ここで画面とDBのデータの同一性をチェックして、更新可能か調べる
             */


            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            /*
             * DragアイテムがSetLabelExの場合
             */
            if(e.Data is not null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
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
            if(e.Data is not null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExCar":
                                try {
                                    _vehicleDispatchDetailDao.ResetCarLabel(DateTimePickerJpExOperationDate.GetValue(), Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag));
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
                                    _vehicleDispatchDetailCarDao.InsertCar(DateTimePickerJpExOperationDate.GetValue(),
                                                                           Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                    _vehicleDispatchDetailDao.ResetCarLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailCarDao.InsertNewCar(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailCarDao.DeleteCar(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailCarDao.UpdateCar(DateTimePickerJpExOperationDate.GetValue(),
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
            if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExFullEmployees":
                            case "FlowLayoutPanelExLongTerm":
                            case "FlowLayoutPanelExPartTime":
                            case "FlowLayoutPanelExWindow":
                                try {
                                    _vehicleDispatchDetailDao.ResetStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailStaffDao.InsertStaff(DateTimePickerJpExOperationDate.GetValue(),
                                                                               Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                               ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                               Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                    _vehicleDispatchDetailDao.ResetStaffLabel(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailStaffDao.InsertNewStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailStaffDao.DeleteStaff(DateTimePickerJpExOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailStaffDao.UpdateStaff(DateTimePickerJpExOperationDate.GetValue(),
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
            /*
             * 最終更新日時を退避する
             */
            _lastOperateDateTime = DateTime.Now;
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
            // Copy  :データがドロップ先にコピーされようとしている状態
            // Move  :データがドロップ先に移動されようとしている状態
            // Scroll:データによってドロップ先でスクロールが開始されようとしている状態、あるいは現在スクロール中である状態
            // All   :上の3つを組み合わせたもの
            // Link  :データのリンクがドロップ先に作成されようとしている状態
            // None  :いかなるデータもドロップ先が受け付けようとしない状態
            switch(((FlowLayoutPanelEx)sender).Name) {
                case "SetControlEx":
                    /*
                     * SetLabelExはSetControlEx上にしかDropすることないよね
                     */
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExFullEmployees":
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 10 || ((StaffMasterVo)dragItem.Tag).Belongs == 11)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExLongTerm":
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if((((StaffMasterVo)dragItem.Tag).Belongs == 20 || ((StaffMasterVo)dragItem.Tag).Belongs == 21) && ((StaffMasterVo)dragItem.Tag).Job_form == 10)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExPartTime":
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 12 || ((StaffMasterVo)dragItem.Tag).Job_form == 12)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExWindow":
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
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
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExFullSalaried":
                case "FlowLayoutPanelExFullClose":
                case "FlowLayoutPanelExFullDesignation":
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
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
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if(((StaffMasterVo)dragItem.Tag).Belongs == 12)
                            e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExTelephone":
                case "FlowLayoutPanelExWithoutNotice":
                    if(e.Data is not null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        e.Effect = DragDropEffects.Move;
                    } else {
                        e.Effect = DragDropEffects.None;
                    }
                    break;
                case "FlowLayoutPanelExFree":
                    if(e.Data is not null && (e.Data.GetDataPresent(typeof(CarLabelEx)) || e.Data.GetDataPresent(typeof(StaffLabelEx)))) {
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
        /// PrintDocument1_PrintPage
        /// 配車表の印刷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            Rectangle rectangleFill = new Rectangle(10, 20, 300, 40);
            /*
             * 画像
             */
            e.Graphics?.DrawImage(captureImage, 0, 100, 1400, 740);

            /*
             * 日付
             */
            // 和暦設定
            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();

            Font drawFont = new Font("Yu Gothic UI", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics?.DrawString(DateTimePickerJpExOperationDate.GetValue().ToString("ggyy年MM月dd日(dddd)", Japanese), drawFont, new SolidBrush(Color.Black), rectangleFill, stringFormat);
        }

        /// <summary>
        /// ToolStripMenuItemEquipment_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemEquipment_Click(object sender, EventArgs e) {
            MessageBox.Show("作成中です。もうしばらくお待ちください。");
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