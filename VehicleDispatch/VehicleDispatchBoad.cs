using Common;

using ControlEx;

using Dao;

using Microsoft.VisualBasic.Devices;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        private InitializeForm _initializeForm = new();
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private TableLayoutPanelEx[] _arrayTableLayoutPanelEx = new TableLayoutPanelEx[2];

        /*
         * Tabの開閉
         */
        private bool _TabControlLeftOpenFlag = false;
        private int _TabControlLeftOpenBeforeIndex;
        private bool _TabControlRightOpenFlag = false;
        private int _TabControlRightOpenBeforeIndex;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
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

            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _arrayTableLayoutPanelEx = new TableLayoutPanelEx[] { TableLayoutPanelEx1, TableLayoutPanelEx2 };
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
             * レコードの有無確認
             */
            DateTime operationDate = DateTimePickerOperationDate.Value;
            if (!_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                MessageBox.Show(MessageText.Message302, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*
             * パネルを表示
             */
            // レイアウトロジックを非活性化
            _arrayTableLayoutPanelEx[0].SuspendLayout();
            _arrayTableLayoutPanelEx[1].SuspendLayout();
            // TableLayoutPanelをクリア
            TableLayoutPanelControlRemove(TableLayoutPanelEx1);
            TableLayoutPanelControlRemove(TableLayoutPanelEx2);

            var listVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectVehicleDispatchDetail(operationDate);
            int tabNumber = 0;
            int column = 0;
            int row = 0;
            for (int i = 0; i < 150; i++) {
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
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Set_code != 0) {
                    setControlEx.GarageFlag = vehicleDispatchDetailVo.Garage_flag;
                    setControlEx.ProductionNumberOfPeople = vehicleDispatchDetailVo.Number_of_people;
                    setControlEx.SetFlag = true;
                    setControlEx.OperationFlag = vehicleDispatchDetailVo.Operation_flag;
                    setControlEx.CreateLabel(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code), ContextMenuStripSetLabel);
                }
                /*
                 * CarLabel
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Car_code != 0)
                    setControlEx.CreateLabel(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code), ContextMenuStripCarLabel);
                /*
                 * StaffLabel1
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_1 != 0)
                    setControlEx.CreateLabel(0, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1), ContextMenuStripStaffLabel);
                /*
                 * StaffLabel2
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_2 != 0)
                    setControlEx.CreateLabel(1, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2), ContextMenuStripStaffLabel);
                /*
                 * StaffLabel3
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_3 != 0)
                    setControlEx.CreateLabel(2, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3), ContextMenuStripStaffLabel);
                /*
                 * StaffLabel4
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_4 != 0)
                    setControlEx.CreateLabel(3, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4), ContextMenuStripStaffLabel);
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
        /// TableLayoutPanelControlRemove
        /// </summary>
        /// <param name="tableLayoutPanelEx"></param>
        private void TableLayoutPanelControlRemove(TableLayoutPanelEx tableLayoutPanelEx) {
            tableLayoutPanelEx.Controls.Clear();

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
            if (e.KeyData == (Keys.Shift | Keys.A)) {
                _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, true);
            }
            // Close
            if (e.KeyData == (Keys.Shift | Keys.D)) {
                _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, false);
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            DateTime operationDate = DateTimePickerOperationDate.Value;
            switch (((ToolStripMenuItem)sender).Name) {
                // 清掃事務所へ提出している本番
                case "ToolStripMenuItemInitializeCleanOffice":
                    MessageBox.Show("ToolStripMenuItemInitializeCleanOffice");
                    break;
                // 社内での本番
                case "ToolStripMenuItemInitializeCompanyOffice":
                    if (_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                        DialogResult dialogResult = MessageBox.Show(MessageText.Message301, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                            this.InsertVehicleDispatchDetail();
                        return;
                    } else {
                        this.InsertVehicleDispatchDetail();
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
             */
            if (_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate))
                _vehicleDispatchDetailDao.DeleteVehicleDispatchDetail(operationDate);
            /*
             * vehicle_dispatch_head/vehicle_dispatch_bodyからvehicle_dispatch_detailを作成する
             */
            // 社内での本番をList<VehicleDispatchDetailVo>型で取得
            List<VehicleDispatchDetailVo> listVehicleDispatch = _vehicleDispatchDetailDao.SelectVehicleDispatch(operationDate.ToString("ddd"));
            // VehicleDispatchDetailVoの不足情報を加える
            foreach (var vehicleDispatchDetail in listVehicleDispatch.OrderBy(x => x.Cell_number)) {
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
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        /*
         * UserControlのEventを処理
         */
        private void SetControlEx_Click(object sender, EventArgs e) {
            MessageBox.Show("SetControlEx_Click");
        }

        /// <summary>
        /// SetControlEx_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragDrop(object sender, DragEventArgs e) {
            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            // Labelの型を調べる
            SetControlEx setControlEx = (SetControlEx)sender;
            /*
             * SetLabelEx
             */
            if (e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                if (((SetMasterVo)dragItem.Tag).Move_flag) {
                    if (setControlEx.GetControlFromPosition(0, 0) == null) {
                        setControlEx.Controls.Add(dragItem, 0, 0);
                    } else {
                        ToolStripStatusLabelStatus.Text = string.Concat("配車先が設定されています。(", ((SetMasterVo)dragItem.Tag).Set_name, ") はここへは移動できません");
                    }
                } else {
                    ToolStripStatusLabelStatus.Text = string.Concat("(", ((SetMasterVo)dragItem.Tag).Set_name, ") は移動が禁止されています");
                }
            }
            /*
             * CarLabelEx
             */
            if (e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                if (setControlEx.GetControlFromPosition(0, 1) == null) {
                    setControlEx.Controls.Add(dragItem, 0, 1);
                } else {
                    ToolStripStatusLabelStatus.Text = string.Concat("車両が設定されています。(", ((CarMasterVo)dragItem.Tag).Registration_number, ") はここへは移動できません");
                }
            }
            /*
             * StaffLabelEx
             */
            if (e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                //画面座標(X, Y)を、setControlEx上のクライアント座標に変換する
                Point point = setControlEx.PointToClient(new Point(e.X, e.Y));
                switch (point.Y) {
                    case int i when i <= 140:
                        ToolStripStatusLabelStatus.Text = string.Concat("SetLabelかCarLabel");
                        break;
                    case int i when i <= 180:
                        if (setControlEx.GetControlFromPosition(0, 2) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 2);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("運転手が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                        }
                        break;
                    case int i when i <= 220:
                        if (setControlEx.GetControlFromPosition(0, 3) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 3);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("作業員1が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                        }
                        break;
                    case int i when i <= 260:
                        if (setControlEx.GetControlFromPosition(0, 4) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 4);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("作業員2が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                        }
                        break;
                    case int i when i <= 300:
                        if (setControlEx.GetControlFromPosition(0, 5) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 5);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("作業員3が決まっています。(", ((StaffMasterVo)dragItem.Tag).Name, ") はここへは移動できません");
                        }
                        break;
                }
            }
        }

        private void SetControlEx_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void SetLabelEx_Click(object sender, EventArgs e) {
            MessageBox.Show("SetLabelEx_Click");
        }

        private void SetLabelEx_MouseMove(object sender, MouseEventArgs e) {
            if (sender != null && e.Button == MouseButtons.Left)
                ((SetLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        private void CarLabelEx_Click(object sender, EventArgs e) {
            MessageBox.Show("CarLabelEx_Click");
        }

        private void CarLabelEx_MouseMove(object sender, MouseEventArgs e) {
            if (sender != null && e.Button == MouseButtons.Left)
                ((CarLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        private void StaffLabelEx_Click(object sender, EventArgs e) {
            MessageBox.Show("StaffLabelEx_Click");
        }

        private void StaffLabelEx_MouseMove(object sender, MouseEventArgs e) {
            if (sender != null && e.Button == MouseButtons.Left)
                ((StaffLabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
        }

        private void FlowLayoutPanelEx_DragDrop(object sender, DragEventArgs e) {
            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            /*
             * CarLabelEx
             */
            if (e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                MessageBox.Show("CarLabelEx");
            }
            /*
             * StaffLabelEx
             */
            if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                MessageBox.Show("StaffLabelEx");
            }
        }

        private void FlowLayoutPanelEx_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// SetTableLayoutPanelLeftSide
        /// </summary>
        /// <param name="flag"></param>
        private void SetTableLayoutPanelLeftSide(bool flag) {
            TableLayoutPanelBase.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, flag ? 360F : 34F);
        }

        /// <summary>
        /// SetTableLayoutPanelRightSide
        /// </summary>
        /// <param name="flag"></param>
        private void SetTableLayoutPanelRightSide(bool flag) {
            TableLayoutPanelBase.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, flag ? 360F : 34F);
        }

        /// <summary>
        /// 左側Tabをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlExLeft_Click(object sender, EventArgs e) {
            if (_TabControlLeftOpenFlag) {
                if (((TabControlEx)sender).SelectedIndex == _TabControlLeftOpenBeforeIndex) {
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
            if (_TabControlRightOpenFlag) {
                if (((TabControlEx)sender).SelectedIndex == _TabControlRightOpenBeforeIndex) {
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