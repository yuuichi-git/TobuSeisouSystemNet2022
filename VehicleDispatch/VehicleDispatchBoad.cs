using Common;

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
            _initializeForm.VehicleDispatchBoad(this);
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }



        /// <summary>
        /// VehicleDispatchBoad_KeyDown
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
    }
}