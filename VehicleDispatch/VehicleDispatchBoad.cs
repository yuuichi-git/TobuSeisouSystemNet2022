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
        private List<SetMasterVo> _listDeepCopySetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<CarMasterVo> _listDeepCopyCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<StaffMasterVo> _listDeepCopyStaffMasterVo;
        private TableLayoutPanelEx[] _arrayTableLayoutPanelEx = new TableLayoutPanelEx[2];

        /*
         * Tab�̊J��
         */
        private bool _TabControlLeftOpenFlag = false;
        private int _TabControlLeftOpenBeforeIndex;
        private bool _TabControlRightOpenFlag = false;
        private int _TabControlRightOpenBeforeIndex;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            /*
             * �R���g���[��������
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
            _listDeepCopySetMasterVo = new();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listDeepCopyCarMasterVo = new();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listDeepCopyStaffMasterVo = new();
            _arrayTableLayoutPanelEx = new TableLayoutPanelEx[] { TableLayoutPanelEx1, TableLayoutPanelEx2 };
        }


        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // TabControlExCenter
            CreateLabelVehicleDispatchBoad();
            // TabControlExLeft
            CreateLabelTabControlExLeft();
            // TabControlExRight
            CreateLabelTabControlExRight();
        }

        /// <summary>
        /// TabControlExCenter
        /// </summary>
        private void CreateLabelVehicleDispatchBoad() {
            /*
             * ���R�[�h�̗L���m�F
             */
            DateTime operationDate = DateTimePickerOperationDate.Value;
            if (!_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate)) {
                MessageBox.Show(MessageText.Message302, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // ���C�A�E�g���W�b�N��񊈐���
            _arrayTableLayoutPanelEx[0].SuspendLayout();
            _arrayTableLayoutPanelEx[1].SuspendLayout();
            /*
             * DeepCopy
             */
            _listDeepCopySetMasterVo = new CopyUtility().DeepCopy(_listSetMasterVo.FindAll(x => x.Delete_flag == false));
            _listDeepCopyCarMasterVo = new CopyUtility().DeepCopy(_listCarMasterVo.FindAll(x => x.Delete_flag == false));
            _listDeepCopyStaffMasterVo = new CopyUtility().DeepCopy(_listStaffMasterVo.FindAll(x => x.Delete_flag == false));
            /*
             * TableLayoutPanel���N���A
             */
            TableLayoutPanelControlRemove(TableLayoutPanelEx1);
            TableLayoutPanelControlRemove(TableLayoutPanelEx2);

            var listVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectVehicleDispatchDetail(operationDate);
            int tabNumber = 0;
            int column = 0;
            int row = 0;
            for (int i = 0; i < 150; i++) {
                /*
                 * ���ʐݒ�
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
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Car_code != 0) {
                    setControlEx.CreateLabel(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code), ContextMenuStripCarLabel);
                    _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                }
                /*
                 * StaffLabel1
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_1 != 0) {
                    setControlEx.CreateLabel(0, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1), ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1);
                }
                /*
                 * StaffLabel2
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_2 != 0) {
                    setControlEx.CreateLabel(1, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2), ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2);
                }
                /*
                 * StaffLabel3
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_3 != 0) {
                    setControlEx.CreateLabel(2, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3), ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3);
                }
                /*
                 * StaffLabel4
                 */
                if (vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_4 != 0) {
                    setControlEx.CreateLabel(3, _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4), ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4);
                }
                /*
                 * UserControl�����Event��o�^
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
            // ���C�A�E�g���W�b�N��������
            _arrayTableLayoutPanelEx[1].ResumeLayout();
            _arrayTableLayoutPanelEx[0].ResumeLayout();
        }

        /// <summary>
        /// TabControlExLeft
        /// </summary>
        private void CreateLabelTabControlExLeft() {
            // FlowLayoutPanelExSet
            foreach (var deepCopySetMasterVo in _listDeepCopySetMasterVo.FindAll(x => x.Classification_code != 10 && x.Classification_code != 11)) {
                SetLabelEx labelEx = new SetLabelEx(deepCopySetMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                labelEx.ContextMenuStrip = ContextMenuStripSetLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                labelEx.Click += new EventHandler(SetLabelEx_Click);
                labelEx.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                FlowLayoutPanelExSet.Controls.Add(labelEx);
            }
            // FlowLayoutPanelExCar
            foreach (var deepCopyCarMasterVo in _listDeepCopyCarMasterVo) {
                CarLabelEx labelEx = new CarLabelEx(deepCopyCarMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                labelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                labelEx.Click += new EventHandler(CarLabelEx_Click);
                labelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                FlowLayoutPanelExCar.Controls.Add(labelEx);
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
            ToolStripStatusLabelMemory.Text = string.Concat("���v����������:", info.TotalPhysicalMemory / 1024, " ���p�\����������:", info.AvailablePhysicalMemory / 1024);
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
                // ���|�������֒�o���Ă���{��
                case "ToolStripMenuItemInitializeCleanOffice":
                    MessageBox.Show("ToolStripMenuItemInitializeCleanOffice");
                    break;
                // �Г��ł̖{��
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
             * INSERT�����s����O�ɑΏۃ��R�[�h�����݂��Ă�����DELETE����
             */
            if (_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(operationDate))
                _vehicleDispatchDetailDao.DeleteVehicleDispatchDetail(operationDate);
            /*
             * vehicle_dispatch_head/vehicle_dispatch_body����vehicle_dispatch_detail���쐬����
             */
            // �Г��ł̖{�Ԃ�List<VehicleDispatchDetailVo>�^�Ŏ擾
            List<VehicleDispatchDetailVo> listVehicleDispatch = _vehicleDispatchDetailDao.SelectVehicleDispatch(operationDate.ToString("ddd"));
            // VehicleDispatchDetailVo�̕s������������
            foreach (var vehicleDispatchDetail in listVehicleDispatch.OrderBy(x => x.Cell_number)) {
                VehicleDispatchDetailVo vehicleDispatchDetailVo = new();
                vehicleDispatchDetailVo.Cell_number = vehicleDispatchDetail.Cell_number;
                vehicleDispatchDetailVo.Operation_date = operationDate;
                vehicleDispatchDetailVo.Operation_flag = vehicleDispatchDetail.Day_of_week != string.Empty; // vehicle_dispatch_body.day_of_week��string.Emptyde�łȂ����True(�ғ�)
                vehicleDispatchDetailVo.Garage_flag = vehicleDispatchDetail.Garage_flag;
                vehicleDispatchDetailVo.Five_lap = vehicleDispatchDetail.Five_lap;
                vehicleDispatchDetailVo.Move_flag = vehicleDispatchDetail.Move_flag;
                vehicleDispatchDetailVo.Day_of_week = vehicleDispatchDetail.Day_of_week;
                vehicleDispatchDetailVo.Set_code = vehicleDispatchDetail.Set_code;
                vehicleDispatchDetailVo.Set_note = vehicleDispatchDetail.Set_note; // vehicle_dispatch_body.note
                vehicleDispatchDetailVo.Car_code = vehicleDispatchDetail.Car_code;
                vehicleDispatchDetailVo.Car_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Car_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Number_of_people = vehicleDispatchDetail.Number_of_people;
                vehicleDispatchDetailVo.Operator_code_1 = vehicleDispatchDetail.Operator_code_1;
                vehicleDispatchDetailVo.Operator_1_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_1_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_code_2 = vehicleDispatchDetail.Operator_code_2;
                vehicleDispatchDetailVo.Operator_2_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_2_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_code_3 = vehicleDispatchDetail.Operator_code_3;
                vehicleDispatchDetailVo.Operator_3_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_3_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_code_4 = vehicleDispatchDetail.Operator_code_4;
                vehicleDispatchDetailVo.Operator_4_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_4_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Insert_pc_name = Environment.MachineName; // �l���쐬
                vehicleDispatchDetailVo.Insert_ymd_hms = DateTime.Now; // �l���쐬
                vehicleDispatchDetailVo.Update_pc_name = ""; // �l���쐬
                vehicleDispatchDetailVo.Update_ymd_hms = defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Delete_pc_name = ""; // �l���쐬
                vehicleDispatchDetailVo.Delete_ymd_hms = defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Delete_flag = false; // �l���쐬
                listvehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
            }
            try {
                _vehicleDispatchDetailDao.InsertVehicleDispatchDetail(listvehicleDispatchDetailVo);
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        /*
         * UserControl��Event������
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
            // Drop���󂯓���Ȃ�
            e.Effect = DragDropEffects.None;
            // Label�̌^�𒲂ׂ�
            SetControlEx setControlEx = (SetControlEx)sender;
            /*
             * SetLabelEx
             */
            if (e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                if (((SetMasterVo)dragItem.Tag).Move_flag) {
                    /*
                     * Tab(�z�Ԑ�)�����Drop�̏ꍇSetLabel��Copy����BTableLayoutPanelEx�����Drop�Ȃ�Move����B
                     */
                    if (dragItem.Parent.Parent.Name == "TabPageSet") {
                        if (setControlEx.GetControlFromPosition(0, 0) == null) {
                            /*
                             * Tab(�z�Ԑ�)�����Drop
                             */
                            SetLabelEx newDropItem = new SetLabelEx((SetMasterVo)dragItem.Tag).CreateLabel();
                            // �v���p�e�B��ݒ�
                            newDropItem.ContextMenuStrip = ContextMenuStripSetLabel;
                            /*
                             * �C�x���g��ݒ�
                             */
                            newDropItem.Click += new EventHandler(SetLabelEx_Click);
                            newDropItem.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                            setControlEx.Controls.Add(newDropItem, 0, 0);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�z�Ԑ悪�ݒ肳��Ă��܂��B(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͂����ւ͈ړ��ł��܂���");
                        }
                    } else {
                        /*
                         * TableLayoutPanelEx�����Drop
                         */
                        if (setControlEx.GetControlFromPosition(0, 0) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 0);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�z�Ԑ悪�ݒ肳��Ă��܂��B(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͂����ւ͈ړ��ł��܂���");
                        }
                    }
                } else {
                    ToolStripStatusLabelStatus.Text = string.Concat("(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͈ړ����֎~����Ă��܂�");
                }
            }
            /*
             * CarLabelEx
             */
            if (e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                if (setControlEx.GetControlFromPosition(0, 1) == null) {
                    setControlEx.Controls.Add(dragItem, 0, 1);
                } else {
                    ToolStripStatusLabelStatus.Text = string.Concat("�ԗ����ݒ肳��Ă��܂��B(", ((CarMasterVo)dragItem.Tag).Registration_number, ") �͂����ւ͈ړ��ł��܂���");
                }
            }
            /*
             * StaffLabelEx
             */
            if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                //��ʍ��W(X, Y)���AsetControlEx��̃N���C�A���g���W�ɕϊ�����
                Point point = setControlEx.PointToClient(new Point(e.X, e.Y));
                switch (point.Y) {
                    case int i when i <= 140:
                        ToolStripStatusLabelStatus.Text = string.Concat("SetLabel��CarLabel");
                        break;
                    case int i when i <= 180:
                        if (setControlEx.GetControlFromPosition(0, 2) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 2);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�^�]�肪���܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                    case int i when i <= 220:
                        if (setControlEx.GetControlFromPosition(0, 3) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 3);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�1�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                    case int i when i <= 260:
                        if (setControlEx.GetControlFromPosition(0, 4) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 4);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�2�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                    case int i when i <= 300:
                        if (setControlEx.GetControlFromPosition(0, 5) == null) {
                            setControlEx.Controls.Add(dragItem, 0, 5);
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�3�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
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
            // Drop���󂯓���Ȃ�
            e.Effect = DragDropEffects.None;
            switch (((FlowLayoutPanelEx)sender).Name) {
                // �z�Ԑ�
                case "FlowLayoutPanelExSet":
                    break;
                // �ԗ�
                case "FlowLayoutPanelExCar":
                    /*
                     * CarLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                        CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " ���������܂���");
                    }
                    break;
                // �Ј�
                case "FlowLayoutPanelExFullEmployees":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if (((StaffMasterVo)dragItem.Tag).Belongs == 10 || ((StaffMasterVo)dragItem.Tag).Belongs == 11) {
                            ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " �͎Ј��ł͂���܂���B�����𒆎~���܂��B");
                        }
                    }
                    break;
                // �g������
                case "FlowLayoutPanelExLongTerm":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if ((((StaffMasterVo)dragItem.Tag).Belongs == 20 || ((StaffMasterVo)dragItem.Tag).Belongs == 21) && ((StaffMasterVo)dragItem.Tag).Job_form == 1) {
                            ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " �͑g�������ł͂���܂���B�����𒆎~���܂��B");
                        }
                    }
                    break;
                // �A���o�C�g
                case "FlowLayoutPanelExPartTime":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if (((StaffMasterVo)dragItem.Tag).Belongs == 12) {
                            ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " �̓A���o�C�g�ł͂���܂���B�����𒆎~���܂��B");
                        }
                    }
                    break;
                // �g����(�ĂԐl)
                case "FlowLayoutPanelExWindow":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        if ((((StaffMasterVo)dragItem.Tag).Belongs == 20 || ((StaffMasterVo)dragItem.Tag).Belongs == 21) && ((StaffMasterVo)dragItem.Tag).Job_form == 3) {
                            ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " �͑g�����ł͂���܂���B�����𒆎~���܂��B");
                        }
                    }
                    break;
                // ����
                case "FlowLayoutPanelExMaintenance":
                    /*
                     * CarLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                        CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " ���������܂���");
                    }
                    break;
                // �C��
                case "FlowLayoutPanelExRepair":
                    /*
                     * CarLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                        CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " ���������܂���");
                    }
                    break;
                // �L��
                case "FlowLayoutPanelExSalaried":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                    }
                    break;
                // ���d
                case "FlowLayoutPanelExTelephone":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                    }
                    break;
                // ���f
                case "FlowLayoutPanelExWithoutNotice":
                    /*
                     * StaffLabelEx
                     */
                    if (e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                        StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                    }
                    break;
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
            TableLayoutPanelBase.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, flag ? 364F : 34F);
        }

        /// <summary>
        /// SetTableLayoutPanelRightSide
        /// </summary>
        /// <param name="flag"></param>
        private void SetTableLayoutPanelRightSide(bool flag) {
            TableLayoutPanelBase.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, flag ? 364F : 34F);
        }

        /// <summary>
        /// ����Tab���N���b�N
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
        /// �E��Tab���N���b�N
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