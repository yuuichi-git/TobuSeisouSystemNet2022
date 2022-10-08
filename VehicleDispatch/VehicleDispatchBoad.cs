using Common;

using ControlEx;

using Dao;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        /// <summary>
        /// Connectionを保持
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        /// <summary>
        /// インスタンス作成
        /// </summary>
        private InitializeForm _initializeForm = new();
        private List<SetMasterVo> _listSetMasterVo = new();
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<StaffMasterVo> _listStaffMasterVo = new();
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            // DBを読込
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMasterVo();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMasterVo();
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            // Formを初期化する
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ToolStripMenuItemInitializeOffice_Click
        /// 社内での本番登録で初期化する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInitializeOffice_Click(object sender, EventArgs e) {
            var operationDate = DateTimePickerOperationDate.Value.Date;
            if (_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                var dialogResult = MessageBox.Show(MessageText.Message301, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                switch (dialogResult) {
                    case DialogResult.OK:
                        // DELETE
                        _vehicleDispatchDetailDao.DeleteVehicleDispatchDetail(operationDate);
                        // INSERT
                        SetVehicleDispatchDetail();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            } else {
                // INSERT
                SetVehicleDispatchDetail();
            };
        }

        /// <summary>
        /// SetVehicleDispatchDetail
        /// 本番登録で初期化する
        /// HeadとBodyからデータをSelectして加工
        /// </summary>
        private void SetVehicleDispatchDetail() {
            var defaultDateTime = new DateTime(1900, 01, 01);
            var operationDate = DateTimePickerOperationDate.Value.Date;
            var newListVehicleDispatchDetailVo = new List<VehicleDispatchDetailVo>();
            var oldListVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectVehicleDispatch(new DateTime(2022, 04, 01), "月");
            foreach (var oldVehicleDispatchDetailVo in oldListVehicleDispatchDetailVo) {
                var newVehicleDispatchDetailVo = new VehicleDispatchDetailVo();
                newVehicleDispatchDetailVo.Cell_number = oldVehicleDispatchDetailVo.Cell_number;
                newVehicleDispatchDetailVo.Operation_date = operationDate;
                newVehicleDispatchDetailVo.Garage_flag = oldVehicleDispatchDetailVo.Garage_flag;
                newVehicleDispatchDetailVo.Five_lap = oldVehicleDispatchDetailVo.Five_lap;
                newVehicleDispatchDetailVo.Day_of_week = oldVehicleDispatchDetailVo.Day_of_week;
                newVehicleDispatchDetailVo.Set_code = oldVehicleDispatchDetailVo.Set_code;
                newVehicleDispatchDetailVo.Set_note = "";
                newVehicleDispatchDetailVo.Car_code = oldVehicleDispatchDetailVo.Car_code;
                newVehicleDispatchDetailVo.Car_proxy_flag = false;
                newVehicleDispatchDetailVo.Car_note = "";
                newVehicleDispatchDetailVo.Number_of_people = oldVehicleDispatchDetailVo.Number_of_people;
                newVehicleDispatchDetailVo.Operator_code_1 = oldVehicleDispatchDetailVo.Operator_code_1;
                newVehicleDispatchDetailVo.Operator_1_proxy_flag = false;
                newVehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = defaultDateTime;
                newVehicleDispatchDetailVo.Operator_1_note = "";
                newVehicleDispatchDetailVo.Operator_code_2 = oldVehicleDispatchDetailVo.Operator_code_2;
                newVehicleDispatchDetailVo.Operator_2_proxy_flag = false;
                newVehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = defaultDateTime;
                newVehicleDispatchDetailVo.Operator_2_note = "";
                newVehicleDispatchDetailVo.Operator_code_3 = oldVehicleDispatchDetailVo.Operator_code_3;
                newVehicleDispatchDetailVo.Operator_3_proxy_flag = false;
                newVehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = defaultDateTime;
                newVehicleDispatchDetailVo.Operator_3_note = "";
                newVehicleDispatchDetailVo.Operator_code_4 = oldVehicleDispatchDetailVo.Operator_code_4;
                newVehicleDispatchDetailVo.Operator_4_proxy_flag = false;
                newVehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = defaultDateTime;
                newVehicleDispatchDetailVo.Operator_4_note = "";
                newVehicleDispatchDetailVo.Insert_pc_name = "";
                newVehicleDispatchDetailVo.Insert_ymd_hms = DateTime.Now;
                newVehicleDispatchDetailVo.Update_pc_name = "";
                newVehicleDispatchDetailVo.Update_ymd_hms = defaultDateTime;
                newVehicleDispatchDetailVo.Delete_pc_name = "";
                newVehicleDispatchDetailVo.Delete_ymd_hms = defaultDateTime;
                newVehicleDispatchDetailVo.Delete_flag = false;
                newListVehicleDispatchDetailVo.Add(newVehicleDispatchDetailVo);
            }
            // INSERT
            _vehicleDispatchDetailDao.InsertVehicleDispatchDetail(newListVehicleDispatchDetailVo);
        }

        /// <summary>
        /// 最新化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            var operationDate = DateTimePickerOperationDate.Value.Date;
            if (!_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate))
                MessageBox.Show(MessageText.Message302, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);



            var vehicleDispatchControlVo = new VehicleDispatchBoadVo();
            vehicleDispatchControlVo.Column = 0;
            vehicleDispatchControlVo.Row = 0;
            vehicleDispatchControlVo.SetFlag = true;
            vehicleDispatchControlVo.OperationFlag = true;
            vehicleDispatchControlVo.GarageFlag = false;
            vehicleDispatchControlVo.ProductionNumberOfPeople = 3;
            vehicleDispatchControlVo.SetMasterVo = _listSetMasterVo.Find(x => x.Set_name == "歌舞伎容リ2-1") ?? new SetMasterVo();
            vehicleDispatchControlVo.CarMasterVo = _listCarMasterVo.Find(x => x.Registration_number_4 == "7044") ?? new CarMasterVo();
            /*
             * StaffLabelが無い場合は、何も入れない。(Nullが入っている）
             */
            vehicleDispatchControlVo.ArrayStaffMasterVo[0] = _listStaffMasterVo.Find(x => x.Name == "辻祐一") ?? new StaffMasterVo();
            vehicleDispatchControlVo.ArrayStaffMasterVo[1] = _listStaffMasterVo.Find(x => x.Name == "石原由規") ?? new StaffMasterVo();
            //vehicleDispatchControlVo.ArrayStaffMasterVo[2] = default;
            //vehicleDispatchControlVo.ArrayStaffMasterVo[3] = default;
            CreateSetControl(vehicleDispatchControlVo);
        }

        /// <summary>
        /// CreateSetControl
        /// １組分のLabelセットを作成
        /// </summary>
        /// <param name="vehicleDispatchBoadVo"></param>
        public void CreateSetControl(VehicleDispatchBoadVo vehicleDispatchBoadVo) {
            /*
             * SetControlを作成する仕様は？
             * 
             * 
             * GarageFlag値によってBorderColorが変わる(三郷車庫からの配車を視覚的に表示する)
             * ProductionNumberOfPeople値によってTablLayoutPanelの枠数が決まる(本番人数を明示する)
             */
            var setControlEx = new SetControlEx();
            setControlEx.SetFlag = vehicleDispatchBoadVo.SetFlag;
            setControlEx.StopCarFlag = vehicleDispatchBoadVo.OperationFlag;
            setControlEx.GarageFlag = vehicleDispatchBoadVo.GarageFlag;
            setControlEx.ProductionNumberOfPeople = vehicleDispatchBoadVo.ProductionNumberOfPeople;
            /*
             * SetLedgerVoがNullの場合CreateLabelを呼ばない
             */
            if (vehicleDispatchBoadVo.SetMasterVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.SetMasterVo);
            /*
             * CarLedgerVoがNullの場合CreateLabelを呼ばない
             */
            if (vehicleDispatchBoadVo.CarMasterVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.CarMasterVo);
            /*
             * ArrayStaffLedgerVo.Lengthは最大4だよ(最大で運転手1名と作業員3名)
             */
            for (int i = 0; i < vehicleDispatchBoadVo.ArrayStaffMasterVo.Length; i++) {
                /*
                 * ArrayStaffLedgerVo[i]がNullの場合CreateLabelを呼ばない
                 */
                if (vehicleDispatchBoadVo.ArrayStaffMasterVo[i] != null)
                    setControlEx.CreateLabel(i, vehicleDispatchBoadVo.ArrayStaffMasterVo[i]);
            }
            //レイアウトロジックを停止する
            TableLayoutPanelEx1.SuspendLayout();
            TableLayoutPanelEx1.Controls.Add(setControlEx, vehicleDispatchBoadVo.Column, vehicleDispatchBoadVo.Row);
            //レイアウトロジックを再開する
            TableLayoutPanelEx1.ResumeLayout();
            /*
             * UserControlからイベントを受け取る
             */
            setControlEx.Event_SetControlEx_Click += new EventHandler(SetControlEx_Click);
            setControlEx.Event_SetControlEx_DragDrop += new DragEventHandler(SetControlEx_DragDrop);
            setControlEx.Event_SetControlEx_DragEnter += new DragEventHandler(SetControlEx_DragEnter);
            setControlEx.Event_LabelExControl_Click += new EventHandler(LabelEx_Click);
            setControlEx.Event_LabelExControl_MouseMove += new MouseEventHandler(LabelEx_MouseMove);
        }

        /// <summary>
        /// SetControlEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_Click(object? sender, EventArgs e) {
            MessageBox.Show("SetControl_Click");
        }

        /// <summary>
        /// SetControlEx_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragDrop(object? sender, DragEventArgs e) {
            // e.DataはNullの可能性があるのでチェックする
            if (e.Data == null)
                return;

            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            // Drag側のObjectを退避
            var dragItem = e.Data.GetData(typeof(LabelEx));
            // DragされたLabelExのTagを取得
            var dragLabelTag = ((LabelEx)e.Data.GetData(typeof(LabelEx))).Tag;
            // DragされたLabelExのTableLayoutPanelEx上での位置を取得
            var dragLabelCellPosition = ((TableLayoutPanelEx)((LabelEx)dragItem).Parent).GetCellPosition((Control)dragItem);



            MessageBox.Show("UserControlSetControl_DragDrop");
        }

        /// <summary>
        /// SetControlEx_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            // Iconの状態を変更
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// LabelEx_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_Click(object? sender, EventArgs e) {
            MessageBox.Show("Label_Click");
        }

        /// <summary>
        /// LabelEx_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // ドラッグドロップイベントの開始
                if (sender != null)
                    ((LabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// ToolStripMenuItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemAllScreen":

                    break;
                case "ToolStripMenuItemDefaultScreen":

                    break;
            }
        }

        /// <summary>
        /// VehicleDispatchBoad_KeyDown
        /// ショートカットキー等の処理
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