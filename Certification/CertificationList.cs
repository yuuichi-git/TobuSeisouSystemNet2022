using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Certification {
    public partial class CertificationList : Form {
        private InitializeForm _initializeForm = new();
        private readonly string[] _arrayMark = new string[] { "��", "��", "��" }; // �}�[�N�̎��
        /*
         * Dao
         */
        private StaffMasterDao _staffMasterDao;
        private LicenseMasterDao _licenseMasterDao;
        private CertificationDao _certificationDao;
        /*
         * Vo
         */
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<LicenseMasterVo> _listLicenseMasterVo;
        private List<CertificationMasterVo> _listCertificationMasterVo;
        private List<CertificationFileVo> _listCertificationFileVo;

        // ���ۂɃf�[�^������X�^�[�g�ʒu���w��
        private readonly int startColumnNumber = 2;
        // ���ۂɃf�[�^������X�^�[�g�ʒu���w��
        private readonly int startRowNumber = 3;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public CertificationList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _certificationDao = new CertificationDao(connectionVo);
            _licenseMasterDao = new LicenseMasterDao(connectionVo);
            /*
             * Vo
             */
            _listStaffMasterVo = _staffMasterDao.SelectAllStaffMaster().FindAll(x => (x.Job_form == 10 || x.Job_form == 12 || x.Job_form == 99) && x.Retirement_flag == false);
            _listLicenseMasterVo = _licenseMasterDao.SelectAllLicenseMaster();
            _listCertificationMasterVo = new();
            _listCertificationFileVo = new();
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.CertificationList(this);
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // DrugDrop���֎~����
            SpreadList.AllowDragDrop = false;
            // �V�[�g�^�u���\��
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            // Column�w�b�_�̍���
            SheetViewList.ColumnHeader.Rows[0].Height = 250;
            SheetViewList.GrayAreaBackColor = Color.White;
            // �]�ƈ������Z�b�g
            SetColumnHeader(SheetViewList);
            // ���i�����Z�b�g
            SetRowHeader(SheetViewList);
            // Spread ������
            SpreadList.ResumeLayout();
            // StatusLabel ������
            ToolStripStatusLabelStatus.Text = "";
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
            _listCertificationFileVo = _certificationDao.SelectAllCertificationFile();
            SheetViewListOutPut(SheetViewList);
        }

        /// <summary>
        /// TabControlStaff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlStaff_Click(object sender, EventArgs e) {
            // �R���N�V���������Z�b�g
            if(((TabControl)sender).SelectedTab.Tag != null) {
                switch((string)((TabControl)sender).SelectedTab.Tag) {
                    case "�S�]�ƈ�":
                        SpreadList.SetViewportLeftColumn(0, 2);
                        break;
                    default:
                        // Tab�Ŏw�肵��������List���猟�����ŏ��Ɍ�������Index��ێ�
                        int findIndexListStaffLedgerVo = _listStaffMasterVo.FindIndex(x => x.Name_kana.StartsWith((string)((TabControl)sender).SelectedTab.Tag));
                        if(findIndexListStaffLedgerVo != -1)
                            SpreadList.SetViewportLeftColumn(0, findIndexListStaffLedgerVo + startColumnNumber);
                        break;
                }
            }
            // �]�ƈ������Z�b�g
            SetColumnHeader(SheetViewList);
        }

        /// <summary>
        /// SetColumnHeader
        /// Column�ɏ]�ƈ��̈ꗗ���쐬����
        /// </summary>
        private void SetColumnHeader(SheetView sheetView) {
            /*
             * Column���N���A
             */
            for(int i = 2; i < sheetView.ColumnCount; i++) {
                sheetView.Cells[0, i].ResetText(); // ���R�[�h�ԍ�
                sheetView.Cells[1, i].ResetText(); // �]�ƈ���
                sheetView.Cells[2, i].ResetText(); // �N��
            }
            int columnNumber = startColumnNumber;
            // ��������郌�R�[�h�̔ԍ�
            int recordNumber = 1;
            foreach(StaffMasterVo staffMasterVo in _listStaffMasterVo) {
                /*
                 * ���R�[�h�ԍ�
                 */
                sheetView.Cells[0, columnNumber].Font = new Font("Yu Gothic UI", 8);
                sheetView.Cells[0, columnNumber].Value = recordNumber;
                /*
                 * Vo�ޔ� �]�ƈ���
                 */
                sheetView.Cells[1, columnNumber].Font = new Font("Yu Gothic UI", 9);
                sheetView.Cells[1, columnNumber].Tag = staffMasterVo;
                sheetView.Cells[1, columnNumber].Text = staffMasterVo.Display_name;
                /*
                 * �N��
                 */
                sheetView.Cells[2, columnNumber].Font = new Font("Yu Gothic UI", 9);
                sheetView.Cells[2, columnNumber].Value = new Date().GetStaffAge(staffMasterVo.Birth_date.Date);

                columnNumber++;
                recordNumber++;
            }
            sheetView.FrozenColumnCount = 2; // �Œ����w�肷��
        }

        /// <summary>
        /// SetRowHeader
        /// Row�Ɏ��i���̈ꗗ���쐬����
        /// </summary>
        private void SetRowHeader(SheetView sheetView) {
            int rowNo = startRowNumber;
            // Row�����������܂��B�������ς������ꍇ��Count���[���ɂȂ邩��G���[���o��B
            if(sheetView.Rows.Count > startRowNumber)
                sheetView.RemoveRows(startRowNumber, sheetView.Rows.Count - startRowNumber);
            // _listCertificationLedgerVo�̗v�f����Row���쐬����
            _listCertificationMasterVo = _certificationDao.SelectAllCertificationMasterVo();
            sheetView.Rows.Add(rowNo, _listCertificationMasterVo.Count);
            foreach(var certificationMasterVo in _listCertificationMasterVo) {
                sheetView.Rows[rowNo].BackColor = certificationMasterVo.Certification_code > 100 && certificationMasterVo.Certification_code < 200 ? Color.WhiteSmoke : Color.White; // 100�`199�͉^�]�Ƌ��؊֘A�̃R�[�h
                sheetView.Cells[rowNo, 0].Font = new Font("HP Simplified", 9);
                sheetView.Cells[rowNo, 0].Text = certificationMasterVo.Certification_code.ToString();
                sheetView.Cells[rowNo, 1].Font = new Font("Yu Gothic UI", 10);
                sheetView.Cells[rowNo, 1].Tag = certificationMasterVo;
                sheetView.Cells[rowNo, 1].Text = certificationMasterVo.Certification_display_name;

                rowNo++;
            }
            sheetView.FrozenRowCount = 3; // �Œ�s���w�肷��
        }

        /// <summary>
        /// SheetViewListOutPut
        /// �e�w�b�_��Object�������Ă���Cell�݂̂�ΏۂƂ���悤�ɍ쐬
        /// </summary>
        /// <param name="sheetView"></param>
        private void SheetViewListOutPut(SheetView sheetView) {
            StaffMasterVo staffMasterVo;
            CertificationMasterVo certificationMasterVo;

            SpreadList.SuspendLayout(); // Spread �񊈐���
            for(int col = startColumnNumber; col < sheetView.ColumnCount; col++) {
                staffMasterVo = (StaffMasterVo)sheetView.Cells[1, col].Tag;
                if(staffMasterVo != null) {
                    // �ԗ��֌W
                    LicenseMasterVo licenseMasterVo = _listLicenseMasterVo.Find(x => x.Staff_code == staffMasterVo.Staff_code);
                    if(licenseMasterVo != null) {
                        // ��^
                        sheetView.Cells[startRowNumber, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber, col].Text = licenseMasterVo.Large ? "�Z" : "";
                        sheetView.Cells[startRowNumber, col].VerticalAlignment = CellVerticalAlignment.Center;
                        // ���^
                        sheetView.Cells[startRowNumber + 1, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber + 1, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber + 1, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber + 1, col].Text = licenseMasterVo.Medium ? "�Z" : "";
                        sheetView.Cells[startRowNumber + 1, col].VerticalAlignment = CellVerticalAlignment.Center;
                        // �����^
                        sheetView.Cells[startRowNumber + 2, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber + 2, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber + 2, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber + 2, col].Text = licenseMasterVo.Quasi_medium ? "�Z" : "";
                        sheetView.Cells[startRowNumber + 2, col].VerticalAlignment = CellVerticalAlignment.Center;
                        // ����
                        sheetView.Cells[startRowNumber + 3, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber + 3, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber + 3, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber + 3, col].Text = licenseMasterVo.Ordinary ? "�Z" : "";
                        sheetView.Cells[startRowNumber + 3, col].VerticalAlignment = CellVerticalAlignment.Center;
                    }
                    // �ԗ��֌W���牺
                    for(int row = startRowNumber + 4; row < sheetView.RowCount; row++) {
                        certificationMasterVo = (CertificationMasterVo)sheetView.Cells[row, 1].Tag;
                        CertificationFileVo certificationFileVo = _listCertificationFileVo.Find(x => x.Staff_code == staffMasterVo.Staff_code && x.Certification_code == certificationMasterVo.Certification_code);
                        if(certificationFileVo != null) {
                            sheetView.Cells[row, col].Font = new Font("���C���I", 14);
                            sheetView.Cells[row, col].ForeColor = Color.Blue;
                            sheetView.Cells[row, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                            sheetView.Cells[row, col].Text = _arrayMark[certificationFileVo.Mark_code];
                            sheetView.Cells[row, col].VerticalAlignment = CellVerticalAlignment.Center;
                        } else {
                            sheetView.Cells[row, col].Text = "";
                        }
                    }
                }
            }
            SpreadList.ResumeLayout(); // Spread ������
        }

        /// <summary>
        /// SpreadList_CellClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellClick(object sender, CellClickEventArgs e) {
            // Click�͈̔͂𒲍�
            if(e.Column >= startColumnNumber && e.Column < startColumnNumber + _listStaffMasterVo.Count && e.Row >= startRowNumber + 4) {
                StaffMasterVo staffMasterVo = (StaffMasterVo)((FpSpread)sender).ActiveSheet.Cells[1, e.Column].Tag;
                CertificationMasterVo certificationLedgerVo = (CertificationMasterVo)((FpSpread)sender).ActiveSheet.Cells[e.Row, 1].Tag;
                ToolStripStatusLabelStatus.Text = string.Concat(staffMasterVo.Display_name, "  ", certificationLedgerVo.Certification_display_name);
            } else {
                ToolStripStatusLabelStatus.Text = "�͈͊O���N���b�N���܂���";
                // Click������L�����Z������
                e.Cancel = true;
            }
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // DoubleClick�͈̔͂𒲍�
            if(e.Column >= startColumnNumber && e.Column < startColumnNumber + _listStaffMasterVo.Count && e.Row >= startRowNumber + 4) {
                // Shift�������ꂽ�ꍇ
                if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                    StaffMasterVo staffMasterVo = (StaffMasterVo)((FpSpread)sender).ActiveSheet.Cells[1, e.Column].Tag;
                    CertificationMasterVo certificationLedgerVo = (CertificationMasterVo)((FpSpread)sender).ActiveSheet.Cells[e.Row, 1].Tag;
                    // SQL�̓��R�[�h�������DELETE�A�������INSERT
                    try {
                        _certificationDao.UpdateOneCertificationFile(staffMasterVo, certificationLedgerVo, 2);
                        ToolStripStatusLabelStatus.Text = "�X�V�ɐ������܂����B";
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    // �ŐV���{�^�����N���b�N����
                    ButtonUpdate.PerformClick();
                } else {
                    ToolStripStatusLabelStatus.Text = "�o�^����ꍇ�́hShift�h�{�_�u���N���b�N";
                }
            } else {
                ToolStripStatusLabelStatus.Text = "�͈͊O���_�u���N���b�N���܂���";
                // DoubleClick������L�����Z������
                e.Cancel = true;
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
        /// CertificationList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CertificationList_FormClosing(object sender, FormClosingEventArgs e) {
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