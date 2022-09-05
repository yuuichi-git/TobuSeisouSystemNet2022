/*
 * 
 */
using Common;

using ControlEx;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        /// <summary>
        /// Connection��ێ�
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// InitializeForm�̃C���X�^���X
        /// </summary>
        private InitializeForm _initializeForm = new();
        private VehicleDispatchControl _vehicleDispatchControl = new();

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
            _vehicleDispatchControl = VehicleDispatchControl1;
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }



        /// <summary>
        /// VehicleDispatchBoad_KeyDown
        /// �V���[�g�J�b�g�L�[���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchBoad_KeyDown(object sender, KeyEventArgs e) {
            // Open
            if (e.KeyData == (Keys.Shift | Keys.O)) {
                _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, true);
            }
            // Close
            if (e.KeyData == (Keys.Shift | Keys.C)) {
                _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, false);
            }

        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// �I������
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

        private void button1_Click(object sender, EventArgs e) {
            /*
             * Test Data
             */
            var setLedgerVo = new SetLedgerVo();
            setLedgerVo.Set_name_1 = "�̕���";
            setLedgerVo.Set_name_2 = "1-61";

            var carLedgerVo = new CarLedgerVo();
            carLedgerVo.Registration_number_1 = "����";
            carLedgerVo.Registration_number_2 = "444";
            carLedgerVo.Registration_number_3 = "��";
            carLedgerVo.Registration_number_4 = 4444;
            carLedgerVo.Disguise_kind_1 = "���v";
            carLedgerVo.Door_number = 123;
            /*
             * 
             */

            var vehicleDispatchControlVo = new VehicleDispatchControlVo();
            vehicleDispatchControlVo.Column = 0;
            vehicleDispatchControlVo.Row = 0;
            vehicleDispatchControlVo.SetFlag = true;
            vehicleDispatchControlVo.StopCarFlag = false;
            vehicleDispatchControlVo.GarageFlag = true;
            vehicleDispatchControlVo.ProductionNumberOfPeople = 2;
            vehicleDispatchControlVo.SetLedgerVo = setLedgerVo;
            vehicleDispatchControlVo.CarLedgerVo = carLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[0] = new StaffLedgerVo();
            vehicleDispatchControlVo.ArrayStaffLedgerVo[1] = default;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[2] = new StaffLedgerVo();
            vehicleDispatchControlVo.ArrayStaffLedgerVo[3] = default;

            _vehicleDispatchControl.CreateSetControl(vehicleDispatchControlVo);

        }
    }
}