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

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
            // Form������������
            _initializeForm.VehicleDispatchBoad(this);
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        private void button1_Click(object sender, EventArgs e) {
            /*
             * Test Data
             */
            var setLedgerVo = new SetLedgerVo();
            setLedgerVo.Set_name_1 = "�̕���";
            setLedgerVo.Set_name_2 = "1-61";

            var carLedgerVo = new CarLedgerVo();
            carLedgerVo.Disguise_kind_1 = "���v";
            carLedgerVo.Door_number = "123";
            carLedgerVo.Registration_number_1 = "����";
            carLedgerVo.Registration_number_2 = "444";
            carLedgerVo.Registration_number_3 = "��";
            carLedgerVo.Registration_number_4 = "4444";

            var staffLedgerVo = new StaffLedgerVo();
            staffLedgerVo.Display_name = "�t���[���X�EM";
            /*
             * 
             */

            VehicleDispatchControlVo vehicleDispatchControlVo = new();
            vehicleDispatchControlVo.Column = 1;
            vehicleDispatchControlVo.Row = 0;
            vehicleDispatchControlVo.SetFlag = true;
            vehicleDispatchControlVo.StopCarFlag = false;
            vehicleDispatchControlVo.GarageFlag = true;
            vehicleDispatchControlVo.ProductionNumberOfPeople = 3;
            vehicleDispatchControlVo.SetLedgerVo = setLedgerVo;
            vehicleDispatchControlVo.CarLedgerVo = carLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[0] = staffLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[1] = default;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[2] = staffLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[3] = default;

            CreateSetControl(vehicleDispatchControlVo);

        }

        /// <summary>
        /// CreateSetControl
        /// �P�g����Label�Z�b�g���쐬
        /// </summary>
        /// <param name="vehicleDispatchControlVo"></param>
        public void CreateSetControl(VehicleDispatchControlVo vehicleDispatchControlVo) {
            /*
             * SetControl���쐬����d�l�́H
             * 
             * 
             * GarageFlag�l�ɂ����BorderColor���ς��(�O���Ԍɂ���̔z�Ԃ����o�I�ɕ\������)
             * ProductionNumberOfPeople�l�ɂ����TablLayoutPanel�̘g�������܂�(�{�Ԑl���𖾎�����)
             */
            var setControl = new SetControl();
            setControl.SetFlag = vehicleDispatchControlVo.SetFlag;
            setControl.StopCarFlag = vehicleDispatchControlVo.StopCarFlag;
            setControl.GarageFlag = vehicleDispatchControlVo.GarageFlag;
            setControl.ProductionNumberOfPeople = vehicleDispatchControlVo.ProductionNumberOfPeople;
            /*
             * SetLedgerVo��Null�̏ꍇCreateLabel���Ă΂Ȃ�
             */
            if (vehicleDispatchControlVo.SetLedgerVo != null)
                setControl.CreateLabel(vehicleDispatchControlVo.SetLedgerVo);
            /*
             * CarLedgerVo��Null�̏ꍇCreateLabel���Ă΂Ȃ�
             */
            if (vehicleDispatchControlVo.CarLedgerVo != null)
                setControl.CreateLabel(vehicleDispatchControlVo.CarLedgerVo);
            /*
             * ArrayStaffLedgerVo.Length�͍ő�4����(�ő�ŉ^�]��1���ƍ�ƈ�3��)
             */
            for (int i = 0; i < vehicleDispatchControlVo.ArrayStaffLedgerVo.Length; i++) {
                /*
                 * ArrayStaffLedgerVo[i]��Null�̏ꍇCreateLabel���Ă΂Ȃ�
                 */
                if (vehicleDispatchControlVo.ArrayStaffLedgerVo[i] != null)
                    setControl.CreateLabel(i, vehicleDispatchControlVo.ArrayStaffLedgerVo[i]);
            }
            TableLayoutPanelEx1.Controls.Add(setControl, vehicleDispatchControlVo.Column, vehicleDispatchControlVo.Row);
            /*
             * UserControl����C�x���g���󂯎��
             */
            setControl.UserControl_SetControl_Click += new EventHandler(UserControlSetControl_Click);
            setControl.UserControl_SetControl_DragDrop += new DragEventHandler(UserControlSetControl_DragDrop);
            setControl.UserControl_SetControl_DragEnter += new DragEventHandler(UserControlSetControl_DragEnter);
            setControl.UserControl_LabelControl_Click += new EventHandler(UserControlLabel_Click);
            setControl.UserControl_LabelControl_MouseMove += new MouseEventHandler(UserControl_LabelControl_MouseMove);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlSetControl_Click(object sender, EventArgs e) {
            MessageBox.Show("SetControl_Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlSetControl_DragDrop(object sender, DragEventArgs e) {
            // Drop���󂯓���Ȃ�
            e.Effect = DragDropEffects.None;

            // Drag����Object��ޔ�
            var dragItem = e.Data.GetData(typeof(LabelEx));
            // Drag���ꂽLabelEx��Tag���擾
            var dragLabelTag = ((LabelEx)e.Data.GetData(typeof(LabelEx))).Tag;
            // Drag���ꂽLabelEx��TableLayoutPanelEx��ł̈ʒu���擾
            var dragLabelCellPosition = ((TableLayoutPanelEx)((LabelEx)dragItem).Parent).GetCellPosition((Control)dragItem);



            MessageBox.Show("UserControlSetControl_DragDrop");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlSetControl_DragEnter(object sender, DragEventArgs e) {
            // Icon�̏�Ԃ�ύX
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlLabel_Click(object sender, EventArgs e) {
            MessageBox.Show("Label_Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_LabelControl_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // �h���b�O�h���b�v�C�x���g�̊J�n
                ((LabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
            }
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

        /// <summary>
        /// �I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}