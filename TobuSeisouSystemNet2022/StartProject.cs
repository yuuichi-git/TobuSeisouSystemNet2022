/*
 * 2022/08/21
 */
using System.Data;

using Accounting;

using Car;

using CarAccident;

using Certification;

using Common;

using CommuterInsurance;

using License;

using Production;

using RollCall;

using Staff;

using StaffDetail;

using Toukanpo;

using VehicleDispatch;

using VehicleDispatchSheet;

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
            LabelPcName.Text = string.Concat("�Z PC-Name�F", Environment.MachineName);
            LabelIpAddress.Text = string.Concat("�Z IP-Address�F", new Ip().GetIpAddress());
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
            } catch(Exception exception) {
                MessageBox.Show(exception.Message, MessageText.Message501, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Label_Click(object sender, EventArgs e) {
            if(_connectionVo.Connection != null) {
                switch(_connectionVo.Connection.State) {
                    case ConnectionState.Closed: //�ڑ������Ă��܂��B
                        break;
                    case ConnectionState.Open: //�ڑ����J���Ă��܂��B
                        switch((string)((Label)sender).Tag) {
                            // VehicleDispatch
                            case "VehicleDispatch":
                                var vehicleDispatchBoad = new VehicleDispatchBoad(_connectionVo);
                                vehicleDispatchBoad.Show(this);
                                break;
                            // VehicleDispatchSheetBoad
                            case "VehicleDispatchSheetBoad":
                                var vehicleDispatchSheetBoad = new VehicleDispatchSheetBoad(_connectionVo);
                                vehicleDispatchSheetBoad.Show(this);
                                break;
                            // ProductionCleanOfficeList
                            case "ProductionCleanOfficeList":
                                var productionCleanOfficeList = new ProductionList(_connectionVo, "ProductionCleanOfficeList");
                                productionCleanOfficeList.Show(this);
                                break;
                            // ProductionList
                            case "ProductionOfficeList":
                                var productionOfficeList = new ProductionList(_connectionVo, "ProductionOfficeList");
                                productionOfficeList.Show(this);
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
                            // CommuterInsuranceList
                            case "CommuterInsuranceList":
                                var commuterInsuranceList = new CommuterInsuranceList(_connectionVo);
                                commuterInsuranceList.Show(this);
                                break;
                            // StaffExcel
                            case "StaffExcel":
                                var staffExcel = new StaffExcel(_connectionVo);
                                staffExcel.Show(this);
                                break;
                            // StaffPartTimeDetail
                            case "AccountingParttimeList":
                                var accountingParttimeList = new AccountingParttimeList(_connectionVo);
                                accountingParttimeList.Show(this);
                                break;
                            /*
                             * RollCallRecordBook
                             * �_�ċL�^��
                             */
                            case "RollCallRecordBook":
                                var rollCallRecordBook = new RollCallRecordBook(_connectionVo);
                                rollCallRecordBook.Show(this);
                                break;
                            /*
                             * ���ی��C�Z���^�[�@�C����
                             */
                            case "ToukanpoTrainingCardDetail":
                                var toukanpoTrainingCardDetail = new ToukanpoTrainingCardDetail(_connectionVo);
                                toukanpoTrainingCardDetail.Show(this);
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

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
             if(_connectionVo.Connection.State == ConnectionState.Open) {
                switch(e.Node.Name) {
                    case "NodeISO0000": // ���}�l�W�����g�}�j���A��
                        break;
                    case "NodeISO0100": // �ړI
                        break;
                    case "NodeISO0200": // �K�p�͈�
                        break;
                    case "NodeISO0300": // �p��̒�`
                        break;
                    case "NodeISO0400": // ���Ђ��Ƃ�܂��󋵂̗���
                        break;
                    case "NodeISO0410": // �O���y�ѓ����̉ۑ�
                        break;
                    case "NodeISO0420": // ���Q�֌W�҂̃j�[�Y�y�ъ���
                        break;
                    case "NodeISO0430": // ���}�l�W�����g�V�X�e���͈̔�
                        break;
                    case "NodeISO0440": // ���}�l�W�����g�V�X�e���̊T�v
                        break;
                    case "NodeISO0500": // ���[�_�[�V�b�v
                        break;
                    case "NodeISO0510": // ���[�_�[�V�b�v�y�уR�~�b�g�����g
                        break;
                    case "NodeISO0520": // �����j
                        break;
                    case "NodeISO0530": // �����A�ӔC�y�ь���
                        break;
                    case "NodeISO0600": // �v��
                        break;
                    case "NodeISO0610": // ���X�N�y�ы@��ւ̎�g��
                        break;
                    case "NodeISO0611": // ���X�N�y�ы@��̌���
                        break;
                    case "NodeISO0612": // ������
                        break;
                    case "NodeISO0613": // ����`��(�@�I�y�т��̑��̗v������)
                        break;
                    case "NodeISO0614": // ��g�݂̌v�����
                        break;
                    case "NodeISO0620": // ���ڕW�y�уv���O���� 
                        break;
                    case "NodeISO0700": // �x��(�T�|�[�g)
                        break;
                    case "NodeISO0710": // ����
                        break;
                    case "NodeISO0720": // �͗ʁA����P��
                        break;
                    case "NodeISO0721": // �͗�(�L���i��)
                        CertificationList certificationList = new CertificationList(_connectionVo);
                        certificationList.Show(this);
                        break;
                    case "NodeISO0722": // ����P�� 
                        break;
                    case "NodeISO0730": // �F��
                        break;
                    case "NodeISO0740": // �R�~���j�P�[�V����
                        break;
                    case "NodeISO0750": // ���͊Ǘ�
                        break;
                    case "NodeISO0800": // �^�p
                        break;
                    case "NodeISO0810": // �^�p�̌v��y�ъǗ�
                        break;
                    case "NodeISO0820": // �ً}���Ԃւ̏����y�ёΉ�
                        break;
                    case "NodeISO0821": // �ً}���Ԃ̉\���̓���
                        break;
                    case "NodeISO0822": // �ً}���ԑΉ��菇���̍쐬
                        break;
                    case "NodeISO0823": // �ً}���ԑΉ��P��(�Ή��菇�̃e�X�g)
                        break;
                    case "NodeISO0824": // �菇���̌�����
                        break;
                    case "NodeISO0825": // �������܂ޗ��Q�֌W�҂ւ̏���
                        break;
                    case "NodeISO0900": // �p�t�H�[�}���X�]��
                        break;
                    case "NodeISO0910": // �Ď��A����A���͋y�ѕ]��
                        break;
                    case "NodeISO0911": // ��g�ݍ��ڂ̊Ď��A����
                        break;
                    case "NodeISO0912": // ����]��(�@�I�y�т��̑��̗v������)
                        break;
                    case "NodeISO0920": // �����č�
                        break;
                    case "NodeISO0930": // �o�c�w�ɂ�錩����(�}�l�W�����g���r���[)
                        break;
                    case "NodeISO1000": // ���P
                        break;
                    case "NodeISO1010": // ���
                        break;
                    case "NodeISO1020": // �s�K���ւ̑Ή�
                        break;
                    case "NodeISO1030": // �p���I���P
                        break;
                    case "NodeTreatmentPlant": // ���ԏ�����
                        break;
                    default:
                        break;
                }
            } else {
            }
        }
    }
}