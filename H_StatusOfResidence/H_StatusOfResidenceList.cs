/*
 * 2024-04-10
 */
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using H_Vo;

using Vo;

namespace H_StatusOfResidence {
    public partial class HStatusOfResidenceList : Form {
        /// <summary>
        /// �]���Җ�
        /// </summary>
        private const int _colStaffName = 0;
        /// <summary>
        /// �]���Җ��J�i
        /// </summary>
        private const int _colStaffNameKana = 1;
        /// <summary>
        /// ���N����
        /// </summary>
        private const int _colBirthDate = 2;
        /// <summary>
        /// ����
        /// </summary>
        private const int _colGender = 3;
        /// <summary>
        /// ���ЁE�n��
        /// </summary>
        private const int _colNationality = 4;
        /// <summary>
        /// �Z���n
        /// </summary>
        private const int _colAddress = 5;
        /// <summary>
        /// �ݗ����i
        /// </summary>
        private const int _colStatusOfResidence = 6;
        /// <summary>
        /// �A�J�����̗L��
        /// </summary>
        private const int _colWorkLimit = 7;
        /// <summary>
        /// �ݗ�����
        /// </summary>
        private const int _colPeriodDate = 8;
        /// <summary>
        /// �L������
        /// </summary>
        private const int _colDeadlineDate = 9;
        /*
         * Dao
         */
        private readonly H_StatusOfResidenceMasterDao _hStatusOfResidenceMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// �R���X�g���N�^�[(�V�K�o�^)
        /// </summary>
        /// <param name="connectionVo"></param>
        public HStatusOfResidenceList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStatusOfResidenceMasterDao = new(connectionVo);
            /*
             * Vo 
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeSheetView(SheetViewList);
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.PutSheetViewList(_hStatusOfResidenceMasterDao.SelectAllHStatusOfResidenceMaster());
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        int _spreadListTopRow = 0;
        private void PutSheetViewList(List<H_StatusOfResidenceMasterVo> listHStatusOfResidenceMasterVo) {
            int rowCount = 0;
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            _spreadListTopRow = SpreadList.GetViewportTopRow(0);
            /*
             * Row���폜����
             */
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            foreach (H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo in listHStatusOfResidenceMasterVo) {
                SheetViewList.Rows.Add(rowCount, 1);
                SheetViewList.RowHeader.Columns[0].Label = (rowCount + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[rowCount].ForeColor = hStatusOfResidenceMasterVo.DeleteFlag ? Color.Red : Color.Black; // �ސE�ς̃��R�[�h��ForeColor���Z�b�g
                SheetViewList.Rows[rowCount].Tag = hStatusOfResidenceMasterVo;
                // �]���Җ�
                SheetViewList.Cells[rowCount, _colStaffName].Text = hStatusOfResidenceMasterVo.StaffName;
                // �]���Җ��J�i
                SheetViewList.Cells[rowCount, _colStaffNameKana].Text = hStatusOfResidenceMasterVo.StaffNameKana;
                // ���N����
                SheetViewList.Cells[rowCount, _colBirthDate].Value = hStatusOfResidenceMasterVo.BirthDate;
                // ����
                SheetViewList.Cells[rowCount, _colGender].Text = hStatusOfResidenceMasterVo.Gender;
                // ���ЁE�n��
                SheetViewList.Cells[rowCount, _colNationality].Text = hStatusOfResidenceMasterVo.Nationality;
                // �Z���n
                SheetViewList.Cells[rowCount, _colAddress].Text = hStatusOfResidenceMasterVo.Address;
                // �ݗ����i
                SheetViewList.Cells[rowCount, _colStatusOfResidence].Text = hStatusOfResidenceMasterVo.StatusOfResidence;
                // �A�J�����̗L��
                SheetViewList.Cells[rowCount, _colWorkLimit].Text = hStatusOfResidenceMasterVo.WorkLimit;
                // �ݗ�����
                SheetViewList.Cells[rowCount, _colPeriodDate].Value = hStatusOfResidenceMasterVo.PeriodDate;
                // �L������
                SheetViewList.Cells[rowCount, _colDeadlineDate].Value = hStatusOfResidenceMasterVo.DeadlineDate;
                rowCount++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, _spreadListTopRow);
            // Spread ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", rowCount, " ��");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // �w�b�_�[��DoubleClick�����
            if (e.ColumnHeader)
                return;
            // Shift�������ꂽ�ꍇ
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {

            }
            // �C���L�[�������ꍇ
            int staffCode = ((H_StatusOfResidenceMasterVo)SheetViewList.Rows[SheetViewList.ActiveRowIndex].Tag).StaffCode;
            H_StatusOfResidenceDetail hStatusOfResidenceDetail = new(_connectionVo, staffCode);
            Rectangle rectangleHStatusOfResidenceDetail = new Desktop().GetMonitorWorkingArea(hStatusOfResidenceDetail, _connectionVo.Screen);
            hStatusOfResidenceDetail.KeyPreview = true;
            hStatusOfResidenceDetail.Location = rectangleHStatusOfResidenceDetail.Location;
            hStatusOfResidenceDetail.Size = new Size(1070, 800);
            hStatusOfResidenceDetail.WindowState = FormWindowState.Normal;
            hStatusOfResidenceDetail.Show(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // �V�K���R�[�h��ǉ�����
                case "ToolStripMenuItemNew":
                    H_StatusOfResidenceDetail hStatusOfResidenceDetail = new(_connectionVo);
                    Rectangle rectangleHStatusOfResidenceDetail = new Desktop().GetMonitorWorkingArea(hStatusOfResidenceDetail, _connectionVo.Screen);
                    hStatusOfResidenceDetail.KeyPreview = true;
                    hStatusOfResidenceDetail.Location = rectangleHStatusOfResidenceDetail.Location;
                    hStatusOfResidenceDetail.Size = new Size(1070, 800);
                    hStatusOfResidenceDetail.WindowState = FormWindowState.Normal;
                    hStatusOfResidenceDetail.Show(this);
                    break;
                // �ݗ��J�[�h���폜����
                case "ToolStripMenuItemDelete":
                    DialogResult dialogResult = MessageBox.Show("�I������Ă���ݗ��J�[�h�L�^���폜���܂��B��낵���ł����H", "���b�Z�[�W", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.OK:
                            int staffCode = ((H_StatusOfResidenceMasterVo)SheetViewList.Rows[SheetViewList.ActiveRowIndex].Tag).StaffCode;
                            try {
                                _hStatusOfResidenceMasterDao.DeleteOneHStatusOfResidenceMaster(staffCode);
                            } catch (Exception exception) {
                                MessageBox.Show(exception.Message);
                            }
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
                // �A�v���P�[�V�������I������
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetView(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 24; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 48; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// HStatusOfResidenceList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStatusOfResidenceList_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show("�A�v���P�[�V�������I�����܂��B��낵���ł����H", "���b�Z�[�W", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
