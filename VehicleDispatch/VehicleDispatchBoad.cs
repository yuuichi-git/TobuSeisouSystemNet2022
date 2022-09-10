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

            var vehicleDispatchControlVo = new VehicleDispatchBoadVo();
            vehicleDispatchControlVo.Column = 0;
            vehicleDispatchControlVo.Row = 0;
            vehicleDispatchControlVo.SetFlag = true;
            vehicleDispatchControlVo.OperationFlag = true;
            vehicleDispatchControlVo.GarageFlag = false;
            vehicleDispatchControlVo.ProductionNumberOfPeople = 3;
            vehicleDispatchControlVo.SetLedgerVo = setLedgerVo;
            vehicleDispatchControlVo.CarLedgerVo = carLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[0] = staffLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[1] = default;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[2] = default;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[3] = default;

            CreateSetControl(vehicleDispatchControlVo);
        }

        /// <summary>
        /// CreateSetControl
        /// �P�g����Label�Z�b�g���쐬
        /// </summary>
        /// <param name="vehicleDispatchBoadVo"></param>
        public void CreateSetControl(VehicleDispatchBoadVo vehicleDispatchBoadVo) {
            /*
             * SetControl���쐬����d�l�́H
             * 
             * 
             * GarageFlag�l�ɂ����BorderColor���ς��(�O���Ԍɂ���̔z�Ԃ����o�I�ɕ\������)
             * ProductionNumberOfPeople�l�ɂ����TablLayoutPanel�̘g�������܂�(�{�Ԑl���𖾎�����)
             */
            var setControlEx = new SetControlEx();
            setControlEx.SetFlag = vehicleDispatchBoadVo.SetFlag;
            setControlEx.StopCarFlag = vehicleDispatchBoadVo.OperationFlag;
            setControlEx.GarageFlag = vehicleDispatchBoadVo.GarageFlag;
            setControlEx.ProductionNumberOfPeople = vehicleDispatchBoadVo.ProductionNumberOfPeople;
            /*
             * SetLedgerVo��Null�̏ꍇCreateLabel���Ă΂Ȃ�
             */
            if (vehicleDispatchBoadVo.SetLedgerVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.SetLedgerVo);
            /*
             * CarLedgerVo��Null�̏ꍇCreateLabel���Ă΂Ȃ�
             */
            if (vehicleDispatchBoadVo.CarLedgerVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.CarLedgerVo);
            /*
             * ArrayStaffLedgerVo.Length�͍ő�4����(�ő�ŉ^�]��1���ƍ�ƈ�3��)
             */
            for (int i = 0; i < vehicleDispatchBoadVo.ArrayStaffLedgerVo.Length; i++) {
                /*
                 * ArrayStaffLedgerVo[i]��Null�̏ꍇCreateLabel���Ă΂Ȃ�
                 */
                if (vehicleDispatchBoadVo.ArrayStaffLedgerVo[i] != null)
                    setControlEx.CreateLabel(i, vehicleDispatchBoadVo.ArrayStaffLedgerVo[i]);
            }
            TableLayoutPanelEx1.Controls.Add(setControlEx, vehicleDispatchBoadVo.Column, vehicleDispatchBoadVo.Row);
            /*
             * UserControl����C�x���g���󂯎��
             */
            setControlEx.Event_SetControlEx_Click += new EventHandler(SetControlEx_Click);
            setControlEx.Event_SetControlEx_DragDrop += new DragEventHandler(SetControlEx_DragDrop);
            setControlEx.Event_SetControlEx_DragEnter += new DragEventHandler(SetControlEx_DragEnter);
            setControlEx.Event_LabelExControl_Click += new EventHandler(LabelEx_Click);
            setControlEx.Event_LabelExControl_MouseMove += new MouseEventHandler(LabelEx_MouseMove);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_Click(object? sender, EventArgs e) {
            MessageBox.Show("SetControl_Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragDrop(object? sender, DragEventArgs e) {
            // e.Data��Null�̉\��������̂Ń`�F�b�N����
            if (e.Data == null)
                return;

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
        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            // Icon�̏�Ԃ�ύX
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_Click(object? sender, EventArgs e) {
            MessageBox.Show("Label_Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // �h���b�O�h���b�v�C�x���g�̊J�n
                if (sender != null)
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