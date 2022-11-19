/*
 * 2022/08/21
 */
using System.Data;

using Car;

using CarAccident;

using Common;

using LicenseLedger;

using Production;

using Staff;

using VehicleDispatch;

using Vo;

namespace TobuSeisouSystemNet2022 {
    public partial class StartProject : Form {
        /// <summary>
        /// ConnectionVo
        /// </summary>
        private readonly ConnectionVo _connectionVo = new();

        public StartProject() {
            InitializeComponent();
            new InitializeForm().StartProject(this);
        }

        /// <summary>
        /// �f�[�^�x�[�X�ڑ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDbConnect_Click(object sender, EventArgs e) {
            try {
                _connectionVo.Connect();
                ((Button)sender).Enabled = false;
                LabelServerName.Text = string.Concat("�@�ڑ���T�[�o�[�F", _connectionVo.Connection.DataSource);
                LabelDbName.Text = string.Concat("�@�ڑ���f�[�^�x�[�X�F", _connectionVo.Connection.Database);
                LabelConnectStatus.Text = string.Concat("�@��ԁF", _connectionVo.Connection.State);
            } catch (Exception exception) {
                MessageBox.Show(exception.Message, MessageText.Message501, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Label_Click(object sender, EventArgs e) {
            if (_connectionVo.Connection != null) {
                switch (_connectionVo.Connection.State) {
                    case ConnectionState.Closed: //�ڑ������Ă��܂��B
                        break;
                    case ConnectionState.Open: //�ڑ����J���Ă��܂��B
                        switch ((string)((Label)sender).Tag) {
                            // VehicleDispatch
                            case "VehicleDispatch":
                                var vehicleDispatchBoad = new VehicleDispatchBoad(_connectionVo);
                                vehicleDispatchBoad.Show(this);
                                break;
                            // ProductionList
                            case "ProductionList":
                                var productionList = new ProductionList(_connectionVo);
                                productionList.Show(this);
                                break;
                            // StaffList
                            case "StaffList":
                                var staffList = new StaffList(_connectionVo);
                                staffList.Show(this);
                                break;
                            // LicenseList
                            case "LicenseList":
                                var licenseList = new LicenseList(_connectionVo);
                                licenseList.Show(this);
                                break;
                            default:
                                break;
                            // CarAccidentList
                            case "CarAccidentList":
                                var carAccidentList = new CarAccidentList(_connectionVo);
                                carAccidentList.Show(this);
                                break;
                            // CarList
                            case "CarList":
                                var carList = new CarList(_connectionVo);
                                carList.Show(this);
                                break;
                        }
                        break;
                    case ConnectionState.Connecting: //�ڑ��I�u�W�F�N�g���f�[�^ �\�[�X�ɐڑ����Ă��܂��B
                        break;
                    case ConnectionState.Executing: //�ڑ��I�u�W�F�N�g���R�}���h�����s���Ă��܂��B
                        break;
                    case ConnectionState.Fetching: //�ڑ��I�u�W�F�N�g���f�[�^���������Ă��܂��B
                        break;
                    case ConnectionState.Broken: //�f�[�^ �\�[�X�ւ̐ڑ����f�₵�Ă��܂��B
                        break;
                }
            } else {
                MessageBox.Show(MessageText.Message502, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Red;
        }

        private void Label_MouseLeave(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Black;
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
        /// StartProject_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartProject_FormClosing(object sender, FormClosingEventArgs e) {
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