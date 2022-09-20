/*
 * 
 */
using Common;

using ControlEx;

using Dao;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        /// <summary>
        /// Connection��ێ�
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// �C���X�^���X�쐬
        /// </summary>
        private InitializeForm _initializeForm = new();
        private List<SetMasterVo> _listSetMasterVo = new();
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<StaffMasterVo> _listStaffMasterVo = new();

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            // DB��Ǎ�
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMasterVo();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMasterVo();
            // Form������������
            InitializeComponent();
            _initializeForm.VehicleDispatchBoad(this);
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        private void button1_Click(object sender, EventArgs e) {

            var vehicleDispatchControlVo = new VehicleDispatchBoadVo();
            vehicleDispatchControlVo.Column = 0;
            vehicleDispatchControlVo.Row = 0;
            vehicleDispatchControlVo.SetFlag = true;
            vehicleDispatchControlVo.OperationFlag = true;
            vehicleDispatchControlVo.GarageFlag = false;
            vehicleDispatchControlVo.ProductionNumberOfPeople = 3;
            vehicleDispatchControlVo.SetMasterVo = _listSetMasterVo.Find(x => x.Set_name == "�̕���e��2-1") ?? new SetMasterVo();
            vehicleDispatchControlVo.CarMasterVo = _listCarMasterVo.Find(x => x.Registration_number_4 == "7044") ?? new CarMasterVo();
            /*
             * StaffLabel�������ꍇ�́A��������Ȃ��B(Null�������Ă���j
             */
            vehicleDispatchControlVo.ArrayStaffMasterVo[0] = _listStaffMasterVo.Find(x => x.Name == "�җS��") ?? new StaffMasterVo();
            vehicleDispatchControlVo.ArrayStaffMasterVo[1] = _listStaffMasterVo.Find(x => x.Name == "�Ό��R�K") ?? new StaffMasterVo();
            //vehicleDispatchControlVo.ArrayStaffMasterVo[2] = default;
            //vehicleDispatchControlVo.ArrayStaffMasterVo[3] = default;
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
            if (vehicleDispatchBoadVo.SetMasterVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.SetMasterVo);
            /*
             * CarLedgerVo��Null�̏ꍇCreateLabel���Ă΂Ȃ�
             */
            if (vehicleDispatchBoadVo.CarMasterVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.CarMasterVo);
            /*
             * ArrayStaffLedgerVo.Length�͍ő�4����(�ő�ŉ^�]��1���ƍ�ƈ�3��)
             */
            for (int i = 0; i < vehicleDispatchBoadVo.ArrayStaffMasterVo.Length; i++) {
                /*
                 * ArrayStaffLedgerVo[i]��Null�̏ꍇCreateLabel���Ă΂Ȃ�
                 */
                if (vehicleDispatchBoadVo.ArrayStaffMasterVo[i] != null)
                    setControlEx.CreateLabel(i, vehicleDispatchBoadVo.ArrayStaffMasterVo[i]);
            }
            //���C�A�E�g���W�b�N���~����
            TableLayoutPanelEx1.SuspendLayout();
            TableLayoutPanelEx1.Controls.Add(setControlEx, vehicleDispatchBoadVo.Column, vehicleDispatchBoadVo.Row);
            //���C�A�E�g���W�b�N���ĊJ����
            TableLayoutPanelEx1.ResumeLayout();
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
        /// SetControlEx_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            // Icon�̏�Ԃ�ύX
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
                // �h���b�O�h���b�v�C�x���g�̊J�n
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
        /// �V���[�g�J�b�g�L�[���̏���
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