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

using Substitute;

using VehicleDispatchConvert;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        private readonly InitializeForm _initializeForm = new();
        private readonly TableLayoutPanelEx[] _arrayTableLayoutPanelEx = new TableLayoutPanelEx[2];
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
         * Tab�̊J��
         */
        private bool _TabControlLeftOpenFlag = false;
        private int _TabControlLeftOpenBeforeIndex;
        private bool _TabControlRightOpenFlag = false;
        private int _TabControlRightOpenBeforeIndex;
        /*
         * �_�ă��[�h��ێ�
         * �S��ʂ̏ꍇTrue
         * �ҏW��ʂ̏ꍇFalse
         */
        private bool tenkoModeFlag = false;
        /*
         * DragDrop����������u�Ԃ̓�����ێ�����
         */
        private DateTime _lastOperateDateTime = DateTime.Now;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
            /*
             * ���t
             */
            // ���t��������
            UcDateTimeJpOperationDate.SetValue(DateTime.Now);
            // �ǎ���p
            UcDateTimeJpOperationDate.SetReadOnly(true);
            // InitializeComponent�̌�ɏ��������Ă�
            _arrayTableLayoutPanelEx = new TableLayoutPanelEx[] { TableLayoutPanelEx1, TableLayoutPanelEx2 };
            /*
             * Left
             */
            SetTableLayoutPanelLeftSide(false);
            /*
             * Center
             */
            ToolStripStatusLabelMemory.Text = ""; // �������[�g�p��
            ToolStripStatusLabelLastUpdate.Text = ""; // �ŏI�X�V����
            ToolStripStatusLabelStatus.Text = ""; // �X�e�[�^�X
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
            // TabControlExCenter FlowLayoutPanel
            CreateLabelForVehicleDispatchBoad();
            CreateLabelForFlowLayoutPanelEx();
            // TabControlExLeft
            CreateLabelTabControlExLeft();
            // TabControlExRight
            CreateLabelTabControlExRight();
            /*
             * �ŏI�X�V����
             */
            DateTime? dateTime = _triggerCheckDao.GetLastUpdate(UcDateTimeJpOperationDate.GetValue());
            ToolStripStatusLabelLastUpdate.Text = dateTime != null ? string.Concat(dateTime) : "�X�V�L�^�Ȃ�";
        }

        /// <summary>
        /// TabControlExCenter
        /// </summary>
        private void CreateLabelForVehicleDispatchBoad() {
            /*
             * ���R�[�h�̗L���m�F
             */
            if(!_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                MessageBox.Show(MessageText.Message302, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // ���C�A�E�g���W�b�N��񊈐���
            _arrayTableLayoutPanelEx[0].SuspendLayout();
            _arrayTableLayoutPanelEx[1].SuspendLayout();
            /*
             * DeepCopy
             * 2023-03-22 �Ȃ�ƂȂ�DeepCopy����ł̃G���[�ȋC�������̂ŉ��ǂ��Ă݂��B
             */
            //_listDeepCopySetMasterVo = new CopyUtility().DeepCopy(_listSetMasterVo.FindAll(x => x.Delete_flag == false));
            //_listDeepCopyCarMasterVo = new CopyUtility().DeepCopy(_listCarMasterVo.FindAll(x => x.Delete_flag == false));
            _listDeepCopySetMasterVo = new CopyUtility().DeepCopy(_listSetMasterVo);
            _listDeepCopyCarMasterVo = new CopyUtility().DeepCopy(_listCarMasterVo);
            _listDeepCopyStaffMasterVo = new CopyUtility().DeepCopy(_listStaffMasterVo.FindAll(x => x.Vehicle_dispatch_target == true && x.Delete_flag == false));
            /*
             * TabControlExLeft���N���A
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
             * TableLayoutPanel���N���A
             */
            TableLayoutPanelControlRemove(this.TableLayoutPanelEx1);
            TableLayoutPanelControlRemove(this.TableLayoutPanelEx2);

            List<VehicleDispatchDetailVo> listVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue());
            int tabNumber = 0;
            int column = 0;
            int row = 0;
            for(int i = 0; i < 150; i++) {
                /*
                 * ���ʐݒ�
                 */
                tabNumber = i / 75;
                column = i % 25;
                row = i / 25 % 3;
                VehicleDispatchDetailVo vehicleDispatchDetailVo = listVehicleDispatchDetailVo.Find(x => x.Cell_number == i + 1);
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
                    setControlEx.CreateLabel(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code),
                                             vehicleDispatchDetailVo,
                                             ContextMenuStripSetLabel);
                }
                /*
                 * CarLabel
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Car_code != 0) {
                    setControlEx.CreateLabel(vehicleDispatchDetailVo,
                                             _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code),
                                             ContextMenuStripCarLabel);
                    _listDeepCopyCarMasterVo?.RemoveAll(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                }
                /*
                 * StaffLabel1
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Operator_code_1 != 0) {
                    setControlEx.CreateLabel(0,
                                             _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1),
                                             vehicleDispatchDetailVo.Operator_1_proxy_flag,
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_1_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_1_note.Length > 0 ? true : false,
                                             vehicleDispatchDetailVo.Operator_1_occupation,
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
                                             vehicleDispatchDetailVo.Operator_2_proxy_flag,
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_2_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_2_note.Length > 0 ? true : false,
                                             vehicleDispatchDetailVo.Operator_2_occupation,
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
                                             vehicleDispatchDetailVo.Operator_3_proxy_flag,
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_3_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_3_note.Length > 0 ? true : false,
                                             vehicleDispatchDetailVo.Operator_3_occupation,
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
                                             vehicleDispatchDetailVo.Operator_4_proxy_flag,
                                             tenkoModeFlag,
                                             vehicleDispatchDetailVo.Operator_4_roll_call_flag,
                                             vehicleDispatchDetailVo.Operator_4_note.Length > 0 ? true : false,
                                             vehicleDispatchDetailVo.Operator_4_occupation,
                                             ContextMenuStripStaffLabel);
                    _listDeepCopyStaffMasterVo?.RemoveAll(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4);
                    // ToolTip
                    ToolTip1.SetToolTip(setControlEx.GetControlFromPosition(0, 5), vehicleDispatchDetailVo.Operator_4_note);
                }

                setControlEx.Event_SetControlEx_Click += new EventHandler(this.SetControlEx_Click);
                setControlEx.Event_SetControlEx_DragDrop += new DragEventHandler(this.SetControlEx_DragDrop);
                setControlEx.Event_SetControlEx_DragEnter += new DragEventHandler(this.SetControlEx_DragEnter);
                // DoubleClick��L���ɂ��邽�߂ɁAClick�𖳌��ɂ��Ă���
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
            // ���C�A�E�g���W�b�N��������
            _arrayTableLayoutPanelEx[1].ResumeLayout();
            _arrayTableLayoutPanelEx[0].ResumeLayout();
        }

        /// <summary>
        /// FlowLayoutPanel�ւ̏����o��
        /// </summary>
        private void CreateLabelForFlowLayoutPanelEx() {
            _listVehicleDispatchDetailCarVo = _vehicleDispatchDetailCarDao.SelectVehicleDispatchDetailCar(UcDateTimeJpOperationDate.GetValue());
            _listVehicleDispatchDetailStaffVo = _vehicleDispatchDetailStaffDao.SelectVehicleDispatchDetailStaff(UcDateTimeJpOperationDate.GetValue());

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
                            // Control���쐬
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // �v���p�e�B��ݒ�
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * �C�x���g��ݒ�
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Control��ǉ�
                            FlowLayoutPanelExChecking.Controls.Add(carLabelEx);
                        }
                        break;
                    case 158: // FlowLayoutPanelExRepair
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 158)) {
                            // Control���쐬
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // �v���p�e�B��ݒ�
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * �C�x���g��ݒ�
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Control��ǉ�
                            FlowLayoutPanelExRepair.Controls.Add(carLabelEx);
                        }
                        break;
                    case 159: // FlowLayoutPanelExVehicleInspection
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 159)) {
                            // Control���쐬
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // �v���p�e�B��ݒ�
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * �C�x���g��ݒ�
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Control��ǉ�
                            FlowLayoutPanelExVehicleInspection.Controls.Add(carLabelEx);
                        }
                        break;
                    case 160: // FlowLayoutPanelExFullSalaried(�g������)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 160)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();

                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExFullSalaried.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 161: // FlowLayoutPanelExFullClose(�g������)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 161)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExFullClose.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 162: // FlowLayoutPanelExFullDesignation(�g������)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 162)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExFullDesignation.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 163: // FlowLayoutPanelExPartSalaried(�A���o�C�g)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 163)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExPartSalaried.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 164: // FlowLayoutPanelExPartClose(�A���o�C�g)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 164)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExPartClose.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 165: // FlowLayoutPanelExPartDesignation(�A���o�C�g)
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 165)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExPartDesignation.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 166: // FlowLayoutPanelExTelephone
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 166)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExTelephone.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 167: // FlowLayoutPanelExWithoutNotice
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 167)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
                            FlowLayoutPanelExWithoutNotice.Controls.Add(staffLabelEx);
                        }
                        break;
                    case 168: // FlowLayoutPanelExFree
                        /*
                         * CarLabelEx���쐬
                         */
                        foreach(VehicleDispatchDetailCarVo vehicleDispatchDetailCarVo in _listVehicleDispatchDetailCarVo.FindAll(x => x.Cell_number == 168).OrderBy(x => x.Insert_ymd_hms)) {
                            // Control���쐬
                            CarLabelEx carLabelEx = new CarLabelEx(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code)).CreateLabel();
                            // �v���p�e�B��ݒ�
                            carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                            /*
                             * �C�x���g��ݒ�
                             */
                            carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                            carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyCarMasterVo.RemoveAll(x => x.Car_code == vehicleDispatchDetailCarVo.Car_code);
                            // Control��ǉ�
                            FlowLayoutPanelExFree.Controls.Add(carLabelEx);
                        }
                        /*
                         * StaffLabelEx���쐬
                         */
                        foreach(VehicleDispatchDetailStaffVo vehicleDispatchDetailStaffVo in _listVehicleDispatchDetailStaffVo.FindAll(x => x.Cell_number == 168)) {
                            // Control���쐬
                            StaffLabelEx staffLabelEx = new StaffLabelEx(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code),
                                                                         vehicleDispatchDetailStaffVo.Operator_note.Length > 0 ? true : false).CreateLabel();
                            // �v���p�e�B��ݒ�
                            staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                            ToolTip1.SetToolTip(staffLabelEx, vehicleDispatchDetailStaffVo.Operator_note);
                            /*
                             * �C�x���g��ݒ�
                             */
                            staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                            staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                            // DeepCopy����폜
                            _listDeepCopyStaffMasterVo.RemoveAll(x => x.Staff_code == vehicleDispatchDetailStaffVo.Operator_code);
                            // Control��ǉ�
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
            foreach(SetMasterVo deepCopySetMasterVo in _listDeepCopySetMasterVo.FindAll(x => x.Classification_code != 10 && x.Classification_code != 11)
                                                                       .OrderBy(x => x.Classification_code).ThenBy(x => x.Set_name)) {
                SetLabelEx setLabelEx = new SetLabelEx(deepCopySetMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                setLabelEx.ContextMenuStrip = ContextMenuStripSetLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                // DoubleClick��L���ɂ��邽�߂ɁAClick�𖳌��ɂ��Ă���
                //setLabelEx.Click += new EventHandler(SetLabelEx_Click);
                setLabelEx.DoubleClick += new EventHandler(SetLabelEx_DoubleClick);
                setLabelEx.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                FlowLayoutPanelExSet.Controls.Add(setLabelEx);
            }
            // FlowLayoutPanelExCar
            foreach(CarMasterVo deepCopyCarMasterVo in _listDeepCopyCarMasterVo.OrderBy(x => x.Disguise_kind_1)) {
                CarLabelEx carLabelEx = new CarLabelEx(deepCopyCarMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                carLabelEx.ContextMenuStrip = ContextMenuStripCarLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                carLabelEx.Click += new EventHandler(CarLabelEx_Click);
                carLabelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                FlowLayoutPanelExCar.Controls.Add(carLabelEx);
            }
            // FlowLayoutPanelExFullEmployees(����)
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 10 || x.Belongs == 11) && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExFullEmployees.Controls.Add(staffLabelEx);
            }
            // FlowLayoutPanelExLongTerm(����)
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form == 10 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExLongTerm.Controls.Add(staffLabelEx);
            }
            // FlowLayoutPanelExPartTime(����)
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 12 || x.Belongs == 13) && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * �C�x���g��ݒ�
                 */
                staffLabelEx.Click += new EventHandler(StaffLabelEx_Click);
                staffLabelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                FlowLayoutPanelExPartTime.Controls.Add(staffLabelEx);
            }
            // FlowLayoutPanelExWindow(����)
            foreach(StaffMasterVo deepCopyStaffMasterVo in _listDeepCopyStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.Job_form == 11 && x.Retirement_flag == false).OrderBy(x => x.Name_kana)) {
                StaffLabelEx staffLabelEx = new StaffLabelEx(deepCopyStaffMasterVo).CreateLabel();
                // �v���p�e�B��ݒ�
                staffLabelEx.ContextMenuStrip = ContextMenuStripStaffLabel;
                /*
                 * �C�x���g��ݒ�
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
            ToolStripStatusLabelMemory.Text = string.Concat("���v����������:", info.TotalPhysicalMemory / 1024, " ���p�\����������:", info.AvailablePhysicalMemory / 1024);
        }

        /// <summary>
        /// FlowLayoutPanelControlRemove
        /// </summary>
        /// <param name="flowLayoutPanelEx"></param>
        private void FlowLayoutPanelControlRemove(FlowLayoutPanelEx flowLayoutPanelEx) {
            flowLayoutPanelEx.Controls.Clear();

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
            if(e.KeyData == (Keys.Shift | Keys.A)) {
                ModeEdit();
            }
            // Close
            if(e.KeyData == (Keys.Shift | Keys.D)) {
                ModeRollCall();
            }
        }

        /// <summary>
        /// Form��ҏW���[�h�ɂ���
        /// </summary>
        private void ModeEdit() {
            // �X�V����
            TableLayoutPanelBase.SuspendLayout();
            tenkoModeFlag = false;
            ButtonUpdate.PerformClick();
            _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, true);
            TableLayoutPanelBase.ResumeLayout();
        }

        /// <summary>
        /// Form��_�ă��[�h�ɂ���
        /// </summary>
        private void ModeRollCall() {
            // �X�V����
            TableLayoutPanelBase.SuspendLayout();
            tenkoModeFlag = true;
            ButtonUpdate.PerformClick();
            _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, false);
            TableLayoutPanelBase.ResumeLayout();
        }

        /// <summary>
        /// ToolStripMenuItemMenu_DropDownOpening
        /// ���j���[�o�[���J�����Ƃ��̋���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMenu_DropDownOpening(object sender, EventArgs e) {
            // �\������Ă���z�ԕ\�����(B4)����
            ToolStripMenuItemPrint.Enabled = tenkoModeFlag;
        }

        /// <summary>
        /// SetControlEx �ޔ�p
        /// </summary>
        private SetControlEx EvacuationSetControlEx;
        /// <summary>
        /// FlowLayoutPanelEx �ޔ�p
        /// </summary>
        private FlowLayoutPanelEx EvacuationFlowLayoutPanelEx;
        /// <summary>
        /// SetLabelEx �ޔ�p
        /// </summary>
        private SetLabelEx EvacuationSetLabelEx;
        /// <summary>
        /// CarLabelEx �ޔ�p
        /// </summary>
        private CarLabelEx EvacuationCarLabelEx;
        /// <summary>
        /// StaffLabelEx �ޔ�p
        /// </summary>
        private StaffLabelEx EvacuationStaffLabelEx;

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
                     * SetControlEx��ŃN���b�N���ꂽ��
                     */
                    if(((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx)) {
                        // SetControlEx��ޔ�
                        EvacuationSetControlEx = (SetControlEx)((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        // SetLabelEx��ޔ�
                        EvacuationSetLabelEx = (SetLabelEx)((ContextMenuStrip)sender).SourceControl;
                        SetMasterVo setMasterVo = (SetMasterVo)EvacuationSetLabelEx.Tag;
                        /*
                         * ���j���[�̕\������
                         */
                        // �o�ɒn��ύX
                        ToolStripMenuItemSetGarageChange.Enabled = true;
                        // �z�Ԑ���폜����
                        ToolStripMenuItemSetDelete.Enabled = setMasterVo.Move_flag;
                        // �z�ԁE�x��
                        ToolStripMenuItemOperationFlag.Enabled = true;
                        // �ُ�E��_
                        ToolStripMenuItemClassification.Enabled = ((SetMasterVo)EvacuationSetLabelEx.Tag).Classification_code == 12 ? true : false;
                        // �A������
                        ToolStripMenuItemContactInformation.Enabled = true;
                        // ��ƈ��t��
                        ToolStripMenuItemAddWorker.Enabled = ((SetMasterVo)EvacuationSetLabelEx.Tag).Classification_code == 12 ? true : false;
                        // �ҋ@
                        ToolStripMenuItemStandByFlag.Enabled = true;
                        // ��ԁE��Ԃ�FAX���쐬����
                        ToolStripMenuItemFax.Enabled = (setMasterVo.Contact_method == 11 && UcDateTimeJpOperationDate.GetValue().Date == DateTime.Now.Date && EvacuationSetControlEx.OperationFlag) ? true : false;
                        // �������H�g�p�񍐏�
                        ToolStripMenuItemHighWayReport.Enabled = EvacuationSetLabelEx.OperationFlag;
                    }
                    /*
                     * FlowLayoutPanelEx��ŃN���b�N���ꂽ��
                     */
                    if(((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                        // SetControlEx��ޔ�
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((SetLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        /*
                         * ���j���[�̕\������
                         */
                        // �o�ɒn��ύX
                        ToolStripMenuItemSetGarageChange.Enabled = false;
                        // �z�Ԑ���폜����
                        ToolStripMenuItemSetDelete.Enabled = false;
                        // �z�ԁE�x��
                        ToolStripMenuItemOperationFlag.Enabled = false;
                        // �ُ�E��_
                        ToolStripMenuItemClassification.Enabled = false;
                        // �A������
                        ToolStripMenuItemContactInformation.Enabled = false;
                        // ��ƈ��t��
                        ToolStripMenuItemAddWorker.Enabled = false;
                        // �ҋ@
                        ToolStripMenuItemStandByFlag.Enabled = false;
                        // ��ԁE��Ԃ�FAX���쐬����
                        ToolStripMenuItemFax.Enabled = false;
                        // �������H�g�p�񍐏�
                        ToolStripMenuItemHighWayReport.Enabled = false;
                    }
                    break;
                /*
                 * ContextMenuStripCarLabel
                 */
                case "ContextMenuStripCarLabel":
                    /*
                     * SetControlEx��ŃN���b�N���ꂽ��
                     */
                    if(((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx)) {
                        // SetControlEx��ޔ�
                        EvacuationSetControlEx = (SetControlEx)((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        ToolStripMenuItemCarProxyTrue.Enabled = true;
                        ToolStripMenuItemCarProxyFalse.Enabled = true;
                    }

                    /*
                     * FlowLayoutPanelEx��ŃN���b�N���ꂽ��
                     */
                    if(((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                        // SetControlEx��ޔ�
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((CarLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        ToolStripMenuItemCarProxyTrue.Enabled = false;
                        ToolStripMenuItemCarProxyFalse.Enabled = false;
                    }
                    // CarLabelEx��ޔ�
                    EvacuationCarLabelEx = (CarLabelEx)((ContextMenuStrip)sender).SourceControl;
                    break;
                /*
                 * ContextMenuStripStaffLabel
                 */
                case "ContextMenuStripStaffLabel":
                    /*
                     * SetControlEx��ŃN���b�N���ꂽ��
                     */
                    if(((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(SetControlEx)) {
                        // SetControlEx��ޔ�
                        EvacuationSetControlEx = (SetControlEx)((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        // StaffLabelEx��ޔ�
                        EvacuationStaffLabelEx = (StaffLabelEx)((ContextMenuStrip)sender).SourceControl;
                        /*
                         * ���j���[�̕\������
                         */
                        ToolStripMenuItemStaffProxyTrue.Enabled = true;
                        ToolStripMenuItemStaffProxyFalse.Enabled = true;
                        ToolStripMenuItemStaffMemo.Enabled = true;
                        // �^�]�藿���x�����敪
                        ToolStripMenuItemOccupation10.Enabled = true;
                        ToolStripMenuItemOccupation11.Enabled = true;
                    }
                    /*
                     * FlowLayoutPanelEx��ŃN���b�N���ꂽ��
                     */
                    if(((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(FlowLayoutPanelEx)) {
                        // SetControlEx��ޔ�
                        EvacuationFlowLayoutPanelEx = (FlowLayoutPanelEx)((StaffLabelEx)((ContextMenuStrip)sender).SourceControl).Parent;
                        // StaffLabelEx��ޔ�
                        EvacuationStaffLabelEx = (StaffLabelEx)((ContextMenuStrip)sender).SourceControl;
                        /*
                         * ���j���[�̕\������
                         */
                        ToolStripMenuItemStaffProxyTrue.Enabled = false;
                        ToolStripMenuItemStaffProxyFalse.Enabled = false;
                        // �^�]�藿���x�����敪
                        ToolStripMenuItemOccupation10.Enabled = false;
                        ToolStripMenuItemOccupation11.Enabled = false;
                        switch(Convert.ToInt32(EvacuationFlowLayoutPanelEx.Tag)) {
                            /*
                             * ������FlowLayoutPanelEx�ł�Staff�����͎g���Ȃ�����
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
        /// ����C���[�W��ێ�
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
                // �z�ԕ\���쐬����  tenkoModeFlag
                case "ToolStripMenuItemConvertExcel":
                    /*
                     * VehicleDispatchSimple�̃R���X�g���N�^���Ńt�@�C���̑��݃`�F�b�N�����Ă���B
                     * �R���X�g���N�^���ŏI��������ɂ́A��O�𔭐�������Catch�Ŏ󂯎��Return����
                     */
                    try {
                        var vehicleDispatchSimple = new VehicleDispatchSimple(_connectionVo, UcDateTimeJpOperationDate.GetValue());
                        vehicleDispatchSimple.ShowDialog(this);
                    } catch {
                        return;
                    }
                    break;
                // �z�ԕ\���������
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
                    captureImage = new CaptureControl().GetCapture(targetControl); //�R���g���[���̃C���[�W���擾����

                    PrinterSettings printerSettings = new();
                    PrintDocument printDocument = new();

                    IEnumerable<PaperSize> paperSizes = printerSettings.PaperSizes.Cast<PaperSize>();
                    PaperSize paperSize = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.B4);
                    printDocument.DefaultPageSettings.PaperSize = paperSize;

                    printDocument.DefaultPageSettings.Landscape = true; // �p���̌�����ݒ�(���Ftrue�A�c�Ffalse)
                    printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                    printDocument.Print();

                    captureImage.Dispose();
                    break;
                // ���|�������֒�o���Ă���{��
                case "ToolStripMenuItemInitializeCleanOffice":
                    MessageBox.Show("ToolStripMenuItemInitializeCleanOffice");
                    break;
                // �Г��ł̖{��
                case "ToolStripMenuItemInitializeCompanyOffice":
                    if(_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
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
                // �z�Ԑ�ڍ�
                case "ToolStripMenuItemSetDetail":
                    MessageBox.Show("�z�Ԑ�ڍ׉�ʂ͍쐬���ł��B��Ă���t�Ă��܂��B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // �z�Ԃ̏��
                case "ToolStripMenuItemOperationFlagTrue":
                    try {
                        _vehicleDispatchDetailDao.SetOperationFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   true);
                        // �z�ԏ��
                        EvacuationSetLabelEx.SetOperationFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemOperationFlagFalse":
                    try {
                        _vehicleDispatchDetailDao.SetOperationFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   false);
                        // �z�ԏ��
                        EvacuationSetLabelEx.SetOperationFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // �ُ�E��_�̕�
                case "ToolStripMenuItemYOUJYOU":
                    try {
                        _vehicleDispatchDetailDao.UpdateClassificationFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                           (int)EvacuationSetControlEx.Tag,
                                                                           true);
                        // SetLabelEx���ُ�̐F�ɕς���
                        EvacuationSetLabelEx.SetClassificationFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemKUKEI":
                    try {
                        _vehicleDispatchDetailDao.UpdateClassificationFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                           (int)EvacuationSetControlEx.Tag,
                                                                           false);
                        // SetLabelEx���ُ�̐F�ɕς���
                        EvacuationSetLabelEx.SetClassificationFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // �A������
                case "ToolStripMenuItemContactInformationTrue":
                    try {
                        _vehicleDispatchDetailDao.UpdateContactInformationFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                               (int)EvacuationSetControlEx.Tag,
                                                                               true);
                        // SetLabelEx��A����������ɂ���
                        EvacuationSetControlEx.SetContactInformationFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemContactInformationFalse":
                    try {
                        _vehicleDispatchDetailDao.UpdateContactInformationFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                               (int)EvacuationSetControlEx.Tag,
                                                                               false);
                        // SetLabelEx��A�������Ȃ��ɂ���
                        EvacuationSetControlEx.SetContactInformationFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // ��ƈ��̔z�u
                case "ToolStripMenuItemAddWorkerTrue":
                    try {
                        _vehicleDispatchDetailDao.UpdateAddWorkerFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      true);
                        // SetLabelEx���ُ�̐F�ɕς���
                        EvacuationSetLabelEx.SetAddWorkerFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "ToolStripMenuItemAddWorkerFalse":
                    try {
                        _vehicleDispatchDetailDao.UpdateAddWorkerFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      false);
                        // SetLabelEx���ُ�̐F�ɕς���
                        EvacuationSetLabelEx.SetAddWorkerFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // �z�Ԑ���폜
                case "ToolStripMenuItemSetDelete":
                    try {
                        _vehicleDispatchDetailDao.ResetSetLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                (int)EvacuationSetControlEx.Tag);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    var setControlEx = (SetControlEx)EvacuationSetLabelEx.Parent;
                    setControlEx.Controls.Remove(EvacuationSetLabelEx);
                    setControlEx.Refresh();
                    break;
                // �z�Ԑ惁��
                case "ToolStripMenuItemSetMemo":
                    try {
                        SetMemo setMemo = new SetMemo(_connectionVo, UcDateTimeJpOperationDate.GetValue(), EvacuationSetControlEx, EvacuationSetLabelEx);
                        setMemo.ShowDialog(this);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // �������o��
                case "ToolStripMenuItemSetGarageAdachi":
                    try {
                        _vehicleDispatchDetailDao.UpdateGarageFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   true);
                        // SetLabelEx��{�Ђ̐F�ɕς���
                        EvacuationSetLabelEx.SetGarageFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // �O�����o��
                case "ToolStripMenuItemSetGarageMisato":
                    try {
                        _vehicleDispatchDetailDao.UpdateGarageFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   false);
                        // SetLabelEx���O���̐F�ɕς���
                        EvacuationSetLabelEx.SetGarageFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // �ҋ@��ݒ�
                case "ToolStripMenuItemStandByTrue":
                    try {
                        _vehicleDispatchDetailDao.UpdateStandByFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                    (int)EvacuationSetControlEx.Tag,
                                                                    true);
                        EvacuationSetLabelEx.SetStandByFlag(true);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    break;
                // �ҋ@������
                case "ToolStripMenuItemStandByFalse":
                    try {
                        _vehicleDispatchDetailDao.UpdateStandByFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                    (int)EvacuationSetControlEx.Tag,
                                                                    false);
                        EvacuationSetLabelEx.SetStandByFlag(false);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                // ��ԁE���FAX
                case "ToolStripMenuItemFax":
                    SetMasterVo setMasterVo = (SetMasterVo)EvacuationSetLabelEx.Tag;
                    switch(setMasterVo.Set_code) {
                        case 1310101: // ���c�Q
                        case 1310102: // ���c�U
                        case 1310103: // ���c���P
                            new SubstitutePaper(_connectionVo, (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        case 1310201: // �����y�b�g�V
                        case 1310202: // �����y�b�g�W
                            new SubstitutePaper(_connectionVo, (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        case 1312101: // �����P�W
                        case 1312102: // �����Q�R
                        case 1312103: // �����Q�S
                        case 1312104: // �����R�W
                        case 1312105: // �����s�R�S
                            new SubstitutePaper(_connectionVo, (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        case 1312204: // �����P�P
                        case 1312201: // �����R�R
                        case 1312202: // �����T�T
                        case 1312203: // ����S
                            new SubstitutePaper(_connectionVo, (int)EvacuationSetControlEx.Tag, setMasterVo.Set_code).ShowDialog(this);
                            break;
                        default:
                            MessageBox.Show("��ԑ�Ԃ�FAX���쐬��ʂ͍쐬���ł��B��Ă���t�Ă��܂��B", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    break;
                // �������H�g�p�񍐏�
                case "ToolStripMenuItemHighWayReport":
                    HighWayReportPaper highWayReportPaper = new HighWayReportPaper(EvacuationSetControlEx);
                    highWayReportPaper.ShowDialog(this);
                    break;
                /*
                 * ContextMenuStripCarLabel
                 */
                // �ԗ��ڍ�
                case "ToolStripMenuItemCarDetail":
                    CarPaper carPaper = new CarPaper(_connectionVo,((CarMasterVo)EvacuationCarLabelEx.Tag).Car_code);
                    carPaper.ShowDialog(this);
                    break;
                // ��ԏ���
                case "ToolStripMenuItemCarProxyTrue":
                    try {
                        /*
                         * SetControlEx��ŃN���b�N���ꂽ��
                         */
                        if(EvacuationCarLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetCarProxyFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                      (int)EvacuationSetControlEx.Tag,
                                                                      true);
                            EvacuationCarLabelEx.SetProxyFlag(true);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // ��ԏ���
                case "ToolStripMenuItemCarProxyFalse":
                    try {
                        /*
                         * SetControlEx��ŃN���b�N���ꂽ��
                         */
                        if(EvacuationCarLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetCarProxyFlag(UcDateTimeJpOperationDate.GetValue(),
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
                // �]���ҏڍ�
                case "ToolStripMenuItemStaffDetail":
                    var staffPaper = new StaffPaper(_connectionVo, ((StaffMasterVo)EvacuationStaffLabelEx.Tag).Staff_code);
                    staffPaper.ShowDialog(this);
                    break;
                // ��ԏ���
                case "ToolStripMenuItemStaffProxyTrue":
                    try {
                        /*
                         * SetControlEx��ŃN���b�N���ꂽ��
                         */
                        if(EvacuationStaffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetStaffProxyFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                        (int)EvacuationSetControlEx.Tag,
                                                                        EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                        true);
                            EvacuationStaffLabelEx.SetProxyFlag(true);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // ��ԏ���
                case "ToolStripMenuItemStaffProxyFalse":
                    try {
                        /*
                         * SetControlEx��ŃN���b�N���ꂽ��
                         */
                        if(EvacuationStaffLabelEx.Parent.GetType() == typeof(SetControlEx)) {
                            _vehicleDispatchDetailDao.SetStaffProxyFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                        (int)EvacuationSetControlEx.Tag,
                                                                        EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                        false);
                            EvacuationStaffLabelEx.SetProxyFlag(false);
                        }
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                // �������쐬�E�ҏW
                case "ToolStripMenuItemStaffMemo":
                    try {
                        StaffMemo staffMemo = new StaffMemo(_connectionVo,
                                                            UcDateTimeJpOperationDate.GetValue(),
                                                            EvacuationSetControlEx,
                                                            EvacuationFlowLayoutPanelEx,
                                                            EvacuationStaffLabelEx);
                        staffMemo.ShowDialog(this);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * �E���ύX�i10:�^�]��j
                 */
                case "ToolStripMenuItemOccupation10":
                    try {
                        _vehicleDispatchDetailDao.UpdateOccupation(UcDateTimeJpOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                   10);
                        EvacuationStaffLabelEx.SetOccupation(10);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * �E���ύX�i11:��ƈ��j
                 */
                case "ToolStripMenuItemOccupation11":
                    try {
                        _vehicleDispatchDetailDao.UpdateOccupation(UcDateTimeJpOperationDate.GetValue(),
                                                                   (int)EvacuationSetControlEx.Tag,
                                                                   EvacuationSetControlEx.GetPositionFromControl(EvacuationStaffLabelEx).Row,
                                                                   11);
                        EvacuationStaffLabelEx.SetOccupation(11);
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * �d�b�A���̃}�[�N��t����
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
             * INSERT�����s����O�ɑΏۃ��R�[�h�����݂��Ă�����DELETE����
             * �@VehicleDispatchDetail�̑Ώۃ��R�[�h��DELETE
             * �Avehicle_dispatch_detail_car�̑Ώۃ��R�[�h��DELETE
             * �Bvehicle_dispatch_detail_staff�̑Ώۃ��R�[�h��DELETE
             */
            if(_vehicleDispatchDetailDao.CheckVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue())) {
                try {
                    _vehicleDispatchDetailDao.DeleteVehicleDispatchDetail(UcDateTimeJpOperationDate.GetValue());
                    _vehicleDispatchDetailCarDao.DeleteCar(UcDateTimeJpOperationDate.GetValue());
                    _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue());
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
            /*
             * vehicle_dispatch_head/vehicle_dispatch_body����vehicle_dispatch_detail���쐬����
             */
            // �Г��ł̖{�Ԃ�List<VehicleDispatchDetailVo>�^�Ŏ擾
            List<VehicleDispatchDetailVo> listVehicleDispatch = _vehicleDispatchDetailDao.SelectVehicleDispatch(UcDateTimeJpOperationDate.GetValue().AddMonths(-3),UcDateTimeJpOperationDate.GetValue().ToString("ddd"));
            // VehicleDispatchDetailVo�̕s������������
            foreach(var vehicleDispatchDetail in listVehicleDispatch.OrderBy(x => x.Cell_number)) {
                VehicleDispatchDetailVo vehicleDispatchDetailVo = new();
                vehicleDispatchDetailVo.Cell_number = vehicleDispatchDetail.Cell_number;
                vehicleDispatchDetailVo.Operation_date = UcDateTimeJpOperationDate.GetValue();
                vehicleDispatchDetailVo.Operation_flag = vehicleDispatchDetail.Day_of_week != string.Empty; // vehicle_dispatch_body.day_of_week��string.Emptyde�łȂ����True(�ғ�)
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
                vehicleDispatchDetailVo.Car_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Car_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Number_of_people = vehicleDispatchDetail.Number_of_people;
                vehicleDispatchDetailVo.Operator_code_1 = vehicleDispatchDetail.Operator_code_1;
                vehicleDispatchDetailVo.Operator_1_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = _defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_1_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_1_occupation = vehicleDispatchDetail.Operator_1_occupation; // staff_master�ɓo�^����Ă�����
                vehicleDispatchDetailVo.Operator_code_2 = vehicleDispatchDetail.Operator_code_2;
                vehicleDispatchDetailVo.Operator_2_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = _defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_2_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_2_occupation = vehicleDispatchDetail.Operator_2_occupation; // staff_master�ɓo�^����Ă�����
                vehicleDispatchDetailVo.Operator_code_3 = vehicleDispatchDetail.Operator_code_3;
                vehicleDispatchDetailVo.Operator_3_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = _defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_3_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_3_occupation = vehicleDispatchDetail.Operator_3_occupation; // staff_master�ɓo�^����Ă�����
                vehicleDispatchDetailVo.Operator_code_4 = vehicleDispatchDetail.Operator_code_4;
                vehicleDispatchDetailVo.Operator_4_proxy_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = _defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Operator_4_note = ""; // �l���쐬
                vehicleDispatchDetailVo.Operator_4_occupation = vehicleDispatchDetail.Operator_4_occupation; // staff_master�ɓo�^����Ă�����
                vehicleDispatchDetailVo.Last_roll_call_flag = false; // �l���쐬
                vehicleDispatchDetailVo.Last_plant_count = 0; // �l���쐬
                vehicleDispatchDetailVo.Last_plant_name = ""; // �l���쐬
                vehicleDispatchDetailVo.Last_plant_hm = ""; // �l���쐬
                vehicleDispatchDetailVo.Last_roll_call_hm = ""; // �l���쐬
                vehicleDispatchDetailVo.Insert_pc_name = Environment.MachineName; // �l���쐬
                vehicleDispatchDetailVo.Insert_ymd_hms = DateTime.Now; // �l���쐬
                vehicleDispatchDetailVo.Update_pc_name = ""; // �l���쐬
                vehicleDispatchDetailVo.Update_ymd_hms = _defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Delete_pc_name = ""; // �l���쐬
                vehicleDispatchDetailVo.Delete_ymd_hms = _defaultDate; // �l���쐬
                vehicleDispatchDetailVo.Delete_flag = false; // �l���쐬
                listvehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
            }
            try {
                _vehicleDispatchDetailDao.InsertVehicleDispatchDetail(listvehicleDispatchDetailVo);
            } catch(Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// UserControl��Event������
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
            // Drop���󂯓���Ȃ�
            e.Effect = DragDropEffects.None;
            SetControlEx? setControlEx = null;
            if(sender != null) {
                setControlEx = (SetControlEx)sender;
            } else {
                MessageBox.Show("SetControlEx_DragDrop : sender��Null�ł�");
            }
            /*
             * SetLabelEx
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                if(((SetMasterVo)dragItem.Tag).Move_flag) {
                    /*
                     * SetLabelEx
                     * Tab(�z�Ԑ�)�����Drop�̏ꍇSetLabel��Copy����BTableLayoutPanelEx�����Drop�Ȃ�Move����B
                     */
                    switch(dragItem.Parent.Name) {
                        case "SetControlEx":
                            /*
                             * SetControlEx�����Drop
                             */
                            if(setControlEx != null && setControlEx.GetControlFromPosition(0, 0) == null) {
                                /*
                                 * �ړ����𒲍�����
                                 */
                                if(CheckSetControlEx(dragItem)) {
                                    try {
                                        _vehicleDispatchDetailDao.CopySetLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                               (int)((SetControlEx)dragItem.Parent).Tag,
                                                                               (int)setControlEx.Tag);
                                        _vehicleDispatchDetailDao.ResetSetLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                (int)((SetControlEx)dragItem.Parent).Tag);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  0);
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("�ԗ����x�����͏]�ƈ����x�����ݒ肳��Ă��܂��B���̂��ߔz�Ԑ惉�x�����ړ��ł��܂���");
                                }
                            } else {
                                ToolStripStatusLabelStatus.Text = string.Concat("�z�Ԑ悪�ݒ肳��Ă��܂��B(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͂����ւ͈ړ��ł��܂���");
                            }
                            break;
                        case "FlowLayoutPanelExSet":
                            if(setControlEx != null && setControlEx.GetControlFromPosition(0, 0) == null) {
                                /*
                                 * Tab(�z�Ԑ�)�����Drop
                                 */
                                SetLabelEx newDropItem = new SetLabelEx((SetMasterVo)dragItem.Tag).CreateLabel();
                                // �v���p�e�B��ݒ�
                                newDropItem.ContextMenuStrip = ContextMenuStripSetLabel;
                                /*
                                 * �C�x���g��ݒ�
                                 */
                                // DoubleClick��L���ɂ��邽�߂ɁAClick�𖳌��ɂ��Ă���
                                //newDropItem.Click += new EventHandler(SetLabelEx_Click);
                                newDropItem.DoubleClick += new EventHandler(SetLabelEx_DoubleClick);
                                newDropItem.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                                _vehicleDispatchDetailDao.CreateSetLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                         (int)setControlEx.Tag,
                                                                         (SetMasterVo)dragItem.Tag);
                                setControlEx.Controls.Add(newDropItem,
                                                          0,
                                                          0);
                            } else {
                                ToolStripStatusLabelStatus.Text = string.Concat("�z�Ԑ悪�ݒ肳��Ă��܂��B(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͂����ւ͈ړ��ł��܂���");
                            }
                            break;
                        /*
                         * FlowLayoutPanelExFree
                         * FlowLayoutPanelExFree����̈ړ�
                         */
                        case "FlowLayoutPanelExFree":

                            break;
                    }
                } else {
                    ToolStripStatusLabelStatus.Text = string.Concat("(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͈ړ����֎~����Ă��܂�");
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
                                _vehicleDispatchDetailDao.MoveCarLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                       Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                       Convert.ToInt32(setControlEx.Tag));
                                _vehicleDispatchDetailDao.ResetCarLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                        Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag));
                                setControlEx.Controls.Add(dragItem,
                                                          0,
                                                          1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�ԗ����ݒ肳��Ă��܂��B(", ((CarMasterVo)dragItem.Tag).Registration_number, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                    case "FlowLayoutPanelExCar":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detail��UPDATE
                                _vehicleDispatchDetailDao.CreateCarLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                         Convert.ToInt32(setControlEx.Tag),
                                                                         (CarMasterVo)dragItem.Tag);
                                setControlEx.Controls.Add(dragItem,
                                                          0,
                                                          1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�ԗ����ݒ肳��Ă��܂��B(", ((CarMasterVo)dragItem.Tag).Registration_number, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                    case "FlowLayoutPanelExChecking":
                    case "FlowLayoutPanelExRepair":
                    case "FlowLayoutPanelExVehicleInspection":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detail��UPDATE
                                _vehicleDispatchDetailDao.CreateCarLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                 (CarMasterVo)dragItem.Tag);
                                // vehicle_dispatch_detail_car����DELETE
                                _vehicleDispatchDetailCarDao.DeleteCar(UcDateTimeJpOperationDate.GetValue(),
                                                                       Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                       ((CarMasterVo)dragItem.Tag).Car_code);
                                setControlEx.Controls.Add(dragItem,
                                                          0,
                                                          1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�ԗ����ݒ肳��Ă��܂��B(", ((CarMasterVo)dragItem.Tag).Registration_number, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                    case "FlowLayoutPanelExFree":
                        if(setControlEx != null && setControlEx.GetControlFromPosition(0, 1) == null) {
                            try {
                                // vehicle_dispatch_detail��UPDATE
                                _vehicleDispatchDetailDao.CreateCarLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                         Convert.ToInt32(setControlEx.Tag),
                                                                         (CarMasterVo)dragItem.Tag);
                                // vehicle_dispatch_detail_car����DELETE
                                _vehicleDispatchDetailCarDao.DeleteCar(UcDateTimeJpOperationDate.GetValue(),
                                                                       Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                       ((CarMasterVo)dragItem.Tag).Car_code);
                                setControlEx.Controls.Add(dragItem,
                                                          0,
                                                          1);
                            } catch(Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                        } else {
                            ToolStripStatusLabelStatus.Text = string.Concat("�ԗ����ݒ肳��Ă��܂��B(", ((CarMasterVo)dragItem.Tag).Registration_number, ") �͂����ւ͈ړ��ł��܂���");
                        }
                        break;
                }
            }
            /*
             * StaffLabelEx
             */
            if(setControlEx != null && e.Data != null && e.Data.GetDataPresent(typeof(StaffLabelEx))) {
                StaffLabelEx dragItem = (StaffLabelEx)e.Data.GetData(typeof(StaffLabelEx));
                //��ʍ��W(X, Y)���AsetControlEx��̃N���C�A���g���W�ɕϊ�����
                Point point = setControlEx.PointToClient(new Point(e.X, e.Y));
                switch(dragItem.Parent.Name) {
                    /*
                     * StaffLabelEx
                     * SetControlEx���m�ł̈ړ�
                     */
                    case "SetControlEx":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabel��CarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 (int)setControlEx.Tag, 2);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                  (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                  ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("�^�]�肪���܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 (int)setControlEx.Tag, 3);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                  (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                  ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�1�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 (int)setControlEx.Tag, 4);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                  (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                  ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�2�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                 ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                                 (int)setControlEx.Tag, 5);
                                        _vehicleDispatchDetailDao.ResetStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                  (int)((SetControlEx)dragItem.Parent).Tag,
                                                                                  ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�3�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                        }
                        break;
                    /*
                     * StaffLabelEx
                     * Tab��������̈ړ���Drag���̌㏈��(DB�̏���)���K�v��������
                     */
                    case "FlowLayoutPanelExFullEmployees":
                    case "FlowLayoutPanelExLongTerm":
                    case "FlowLayoutPanelExPartTime":
                    case "FlowLayoutPanelExWindow":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabel��CarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 1,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }

                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("�^�]�肪���܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 2,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�1�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 3,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�2�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 4,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�3�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                        }
                        break;
                    /*
                     * StaffLabelEx
                     * Tab�E������̈ړ���Drag���̌㏈��(DB�̏���)���K�v�Ȃ���
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
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabel��CarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 1,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItem���ړ�
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("�^�]�肪���܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 2,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItem���ړ�
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�1�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(operationDate: UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 3,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItem���ړ�
                                        setControlEx.Controls.Add(dragItem,
                                                                  0,
                                                                  4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�2�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 4,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItem���ړ�
                                        setControlEx.Controls.Add(dragItem, 0, 5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�3�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                        }
                        break;
                    /*
                     * FlowLayoutPanelExFree
                     * FlowLayoutPanelExFree����̈ړ�
                     */
                    case "FlowLayoutPanelExFree":
                        switch(point.Y) {
                            case int i when i <= 140:
                                ToolStripStatusLabelStatus.Text = string.Concat("SetLabel��CarLabel");
                                break;
                            case int i when i <= 180:
                                if(setControlEx.GetControlFromPosition(0, 2) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 1,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        // dragItem���ړ�
                                        setControlEx.Controls.Add(dragItem, 0, 2);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }

                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("�^�]�肪���܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 220:
                                if(setControlEx.GetControlFromPosition(0, 3) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 2,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        setControlEx.Controls.Add(dragItem, 0, 3);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�1�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 260:
                                if(setControlEx.GetControlFromPosition(0, 4) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 3,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        setControlEx.Controls.Add(dragItem, 0, 4);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�2�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                            case int i when i <= 300:
                                if(setControlEx.GetControlFromPosition(0, 5) == null) {
                                    try {
                                        // VehicleDispatchDetail��UPDATE
                                        _vehicleDispatchDetailDao.MoveStaffLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                                 Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                 Convert.ToInt32(setControlEx.Tag),
                                                                                 4,
                                                                                 (StaffMasterVo)dragItem.Tag);
                                        // VehicleDispatchDetailStaff����DELETE
                                        _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                                   Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                                   ((StaffMasterVo)dragItem.Tag).Staff_code);
                                        setControlEx.Controls.Add(dragItem, 0, 5);
                                        ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
                                    } catch(Exception exception) {
                                        MessageBox.Show(exception.Message);
                                    }
                                } else {
                                    ToolStripStatusLabelStatus.Text = string.Concat("��ƈ�3�����܂��Ă��܂��B(", ((StaffMasterVo)dragItem.Tag).Name, ") �͂����ւ͈ړ��ł��܂���");
                                }
                                break;
                        }
                        break;
                }
            }
            /*
             * �ŏI�X�V������ޔ�����
             */
            _lastOperateDateTime = DateTime.Now;
        }

        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        // DoubleClick��L���ɂ��邽�߂ɁAClick�𖳌��ɂ��Ă���
        //private void SetLabelEx_Click(object sender, EventArgs e) {
        //    MessageBox.Show("SetLabelEx_Click");
        //}

        private void SetLabelEx_DoubleClick(object? sender, EventArgs e) {
            if(sender is not null) {
                // SetControlEx��ޔ�
                EvacuationSetControlEx = (SetControlEx)((SetLabelEx)sender).Parent;
                // SetLabelEx��ޔ�
                EvacuationSetLabelEx = (SetLabelEx)sender;
                /*
                 * ���̓_�C�A���O���J��
                 */
                RollCallDialog rollCallDialog = new RollCallDialog(_connectionVo, UcDateTimeJpOperationDate.GetValue(), EvacuationSetControlEx, EvacuationSetLabelEx);
                rollCallDialog.ShowDialog(this);
            }
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
            if(sender is not null) {
                /*
                 * tenkoFlag �� True:StaffLabelEx��Click������_�Ď��Ԃ��L�^
                 */
                if(tenkoModeFlag) {
                    if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                        SetControlEx setControlEx = (SetControlEx)((StaffLabelEx)sender).Parent;
                        StaffLabelEx staffLabelEx = (StaffLabelEx)sender;
                        /*
                         * vehicle_dispatch_detail����������
                         */
                        var tableLayoutPanelCellPosition = setControlEx.GetCellPosition(staffLabelEx);
                        try {
                            _vehicleDispatchDetailDao.UpdateRollCallFlag(UcDateTimeJpOperationDate.GetValue(),
                                                                         (int)setControlEx.Tag,
                                                                         tableLayoutPanelCellPosition.Row,
                                                                         staffLabelEx.GetRollCallFlag);
                            staffLabelEx.SetRollCallFlag(!staffLabelEx.GetRollCallFlag);
                        } catch(Exception exception) {
                            MessageBox.Show(exception.Message);
                        }

                        ToolStripStatusLabelStatus.Text = string.Concat(" ", ((StaffMasterVo)staffLabelEx.Tag).Display_name, " �̓_�ċL�^��ύX���܂���");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// StaffLabelEx_MouseMove
        /// �h���b�O�̏���
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
            // Drop���󂯓���Ȃ�
            e.Effect = DragDropEffects.None;
            /*
             * Drag�A�C�e����SetLabelEx�̏ꍇ
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(SetLabelEx))) {
                SetLabelEx dragItem = (SetLabelEx)e.Data.GetData(typeof(SetLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                    case "FlowLayoutPanelExFree":
                        break;
                }
                ToolStripStatusLabelStatus.Text = string.Concat("(", ((SetMasterVo)dragItem.Tag).Set_name, ") �͈ړ��ł��܂���");
            }
            /*
             * Drag�A�C�e����CarLabelEx�̏ꍇ
             */
            if(e.Data != null && e.Data.GetDataPresent(typeof(CarLabelEx))) {
                CarLabelEx dragItem = (CarLabelEx)e.Data.GetData(typeof(CarLabelEx));
                switch(dragItem.Parent.Name) {
                    case "SetControlEx":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExCar":
                                try {
                                    _vehicleDispatchDetailDao.ResetCarLabel(UcDateTimeJpOperationDate.GetValue(),
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
                                     * Insert�̌��Reset���Ȃ��ƃ_������(vehicleDispatchDetail�̃��R�[�h�𕛖⍇�����Ă��邩��)
                                     */
                                    _vehicleDispatchDetailCarDao.InsertCar(UcDateTimeJpOperationDate.GetValue(),
                                                                           Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                    _vehicleDispatchDetailDao.ResetCarLabel(UcDateTimeJpOperationDate.GetValue(),
                                                                            Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag));
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " ���������܂���");
                        break;
                    case "FlowLayoutPanelExCar":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExChecking":
                            case "FlowLayoutPanelExRepair":
                            case "FlowLayoutPanelExVehicleInspection":
                            case "FlowLayoutPanelExFree":
                                try {
                                    // vehicle_dispatch_detail_car��INSERT
                                    _vehicleDispatchDetailCarDao.InsertNewCar(UcDateTimeJpOperationDate.GetValue(),
                                                                              Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag),
                                                                              ((CarMasterVo)dragItem.Tag).Car_code);
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " ���������܂���");
                        break;
                    case "FlowLayoutPanelExChecking":
                    case "FlowLayoutPanelExRepair":
                    case "FlowLayoutPanelExVehicleInspection":
                    case "FlowLayoutPanelExFree":
                        switch(((FlowLayoutPanelEx)sender).Name) {
                            case "FlowLayoutPanelExCar":
                                try {
                                    // vehicle_dispatch_detail_car����DELETE
                                    _vehicleDispatchDetailCarDao.DeleteCar(UcDateTimeJpOperationDate.GetValue(),
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
                                    _vehicleDispatchDetailCarDao.UpdateCar(UcDateTimeJpOperationDate.GetValue(),
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)dragItem.Parent).Tag),
                                                                           ((CarMasterVo)dragItem.Tag).Car_code,
                                                                           Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                } catch(Exception exception) {
                                    MessageBox.Show(exception.Message);
                                }
                                break;
                        }
                        ((FlowLayoutPanelEx)sender).Controls.Add(dragItem);
                        ToolStripStatusLabelStatus.Text = string.Concat(((CarMasterVo)dragItem.Tag).Registration_number, " ���������܂���");
                        break;
                }
            }
            /*
             * Drag�A�C�e����StaffLabelEx�̏ꍇ
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
                                    _vehicleDispatchDetailDao.ResetStaffLabel(UcDateTimeJpOperationDate.GetValue(),
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
                                     * Insert�̌��Reset���Ȃ��ƃ_������(vehicleDispatchDetail�̃��R�[�h�𕛖⍇�����Ă��邩��)
                                     */
                                    _vehicleDispatchDetailStaffDao.InsertStaff(UcDateTimeJpOperationDate.GetValue(),
                                                                               Convert.ToInt32(((SetControlEx)dragItem.Parent).Tag),
                                                                               ((SetControlEx)dragItem.Parent).GetPositionFromControl(dragItem).Row,
                                                                               Convert.ToInt32(((FlowLayoutPanelEx)sender).Tag));
                                    _vehicleDispatchDetailDao.ResetStaffLabel(UcDateTimeJpOperationDate.GetValue(),
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
                                    // vehicle_dispatch_detail_staff��INSERT
                                    _vehicleDispatchDetailStaffDao.InsertNewStaff(UcDateTimeJpOperationDate.GetValue(),
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
                                    // vehicle_dispatch_detail_staff����DELETE
                                    _vehicleDispatchDetailStaffDao.DeleteStaff(UcDateTimeJpOperationDate.GetValue(),
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
                                    // vehicle_dispatch_detail_staff��UPDATE
                                    _vehicleDispatchDetailStaffDao.UpdateStaff(UcDateTimeJpOperationDate.GetValue(),
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
                ToolStripStatusLabelStatus.Text = string.Concat(((StaffMasterVo)dragItem.Tag).Display_name, " ���������܂���");
            }
            /*
             * �ŏI�X�V������ޔ�����
             */
            _lastOperateDateTime = DateTime.Now;
        }

        /// <summary>
        /// FlowLayoutPanelEx_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlowLayoutPanelEx_DragEnter(object sender, DragEventArgs e) {
            // �}�E�X�|�C���^�[�`��ύX
            //
            // DragDropEffects
            // Copy  :�f�[�^���h���b�v��ɃR�s�[����悤�Ƃ��Ă�����
            // Move  :�f�[�^���h���b�v��Ɉړ�����悤�Ƃ��Ă�����
            // Scroll:�f�[�^�ɂ���ăh���b�v��ŃX�N���[�����J�n����悤�Ƃ��Ă����ԁA���邢�͌��݃X�N���[�����ł�����
            // All   :���3��g�ݍ��킹������
            // Link  :�f�[�^�̃����N���h���b�v��ɍ쐬����悤�Ƃ��Ă�����
            // None  :�����Ȃ�f�[�^���h���b�v�悪�󂯕t���悤�Ƃ��Ȃ����
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
        /// SetLabelEx���ړ��ł��邩���`�F�b�N����
        /// true:�ړ��\ false:�ړ��s��
        /// ��CarLabel��StaffLabel�����݂���ꍇ�͈ړ����֎~����
        /// </summary>
        /// <returns></returns>
        private bool CheckSetControlEx(SetLabelEx dragItem) {
            SetControlEx dragItemForSetControlEx = (SetControlEx)dragItem.Parent;
            // �Ώۂ�SetControlEx�ɂ�Drag����SetLabelEx�������Ă���̂ŁhCount == 1�h�ƂȂ�
            return dragItemForSetControlEx.Controls.Count == 1 ? true : false;
        }

        /// <summary>
        /// SetTableLayoutPanelLeftSide
        /// ���T�C�h�p�l���̊J����
        /// </summary>
        /// <param name="flag"></param>
        private void SetTableLayoutPanelLeftSide(bool flag) {
            TableLayoutPanelBase.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, flag ? 364F : 34F);
        }

        /// <summary>
        /// SetTableLayoutPanelRightSide
        /// �E�T�C�h�p�l���̊J����
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
        /// �E��Tab���N���b�N
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
        /// �z�ԕ\�̈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            Rectangle rectangleFill = new Rectangle(10, 20, 300, 40);
            /*
             * �摜
             */
            e.Graphics?.DrawImage(captureImage, 0, 100, 1400, 740);

            /*
             * ���t
             */
            // �a��ݒ�
            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();

            Font drawFont = new Font("Yu Gothic UI", 14, FontStyle.Regular, GraphicsUnit.Pixel);

            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics?.DrawString(UcDateTimeJpOperationDate.GetValue().ToString("ggyy�NMM��dd��(dddd)", Japanese), drawFont, new SolidBrush(Color.Black), rectangleFill, stringFormat);
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