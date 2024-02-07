/*
 * 2023-06-23
 */
using Common;

using Dao;

using FarPoint.Win.Spread;

using H_Vo;

namespace StatusOfResidence {
    public partial class StatusOfResidenceList : Form {
        private InitializeForm _initializeForm = new();
        private DateTime _defaultDateTime = new DateTime(1900,01,01,00,00,00);
        /*
         * Dao
         */
        private readonly StatusOfResidenceDao _statusOfResidenceDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        // SPREAD��Column�̔ԍ�
        /// <summary>
        /// �]���Җ�
        /// </summary>
        private const int colStaffName = 0;
        /// <summary>
        /// �]���Җ��J�i
        /// </summary>
        private const int colStaffNameKana = 1;
        /// <summary>
        /// ���N����
        /// </summary>
        private const int colBirthDate = 2;
        /// <summary>
        /// ����
        /// </summary>
        private const int colGender = 3;
        /// <summary>
        /// ���ЁE�n��
        /// </summary>
        private const int colNationality = 4;
        /// <summary>
        /// �Z���n
        /// </summary>
        private const int colAddress = 5;
        /// <summary>
        /// �ݗ����i
        /// </summary>
        private const int colStatusOfResidence = 6;
        /// <summary>
        /// �A�J�����̗L��
        /// </summary>
        private const int colWorkLimit = 7;
        /// <summary>
        /// �ݗ�����
        /// </summary>
        private const int colPeriodDate = 8;
        /// <summary>
        /// �L������
        /// </summary>
        private const int colDeadlineDate = 9;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public StatusOfResidenceList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _statusOfResidenceDao = new StatusOfResidenceDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * �R���g���[����������
             */
            InitializeComponent();
            _initializeForm.StatusOfResidenceList(this);
            InitializeSheetViewList(SheetViewList);
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(StatusOfResidenceVo statusOfResidenceVo in _statusOfResidenceDao.SelectAllStatusOfResidenceMaster()) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~

                SheetViewList.Rows[i].ForeColor = statusOfResidenceVo.Delete_flag ? Color.Red : Color.Black; // �폜�ς͐ԐF�ŕ\������
                SheetViewList.Cells[i, colStaffName].Tag = statusOfResidenceVo;
                SheetViewList.Cells[i, colStaffName].Text = statusOfResidenceVo.Staff_name;
                SheetViewList.Cells[i, colStaffNameKana].Text = statusOfResidenceVo.Staff_name_kana;
                SheetViewList.Cells[i, colBirthDate].Value = statusOfResidenceVo.Birth_date;
                SheetViewList.Cells[i, colGender].Text = statusOfResidenceVo.Gender;
                SheetViewList.Cells[i, colNationality].Text = statusOfResidenceVo.Nationality;
                SheetViewList.Cells[i, colAddress].Text = statusOfResidenceVo.Address;
                SheetViewList.Cells[i, colStatusOfResidence].Text = statusOfResidenceVo.Status_of_residence;
                SheetViewList.Cells[i, colWorkLimit].Text = statusOfResidenceVo.Work_limit;
                if(statusOfResidenceVo.Period_date != _defaultDateTime)
                    SheetViewList.Cells[i, colPeriodDate].Value = statusOfResidenceVo.Period_date;
                if(statusOfResidenceVo.Deadline_date != _defaultDateTime)
                    SheetViewList.Cells[i, colDeadlineDate].Value = statusOfResidenceVo.Deadline_date;
                i++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " ��");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // �w�b�_�[��DoubleClick�����
            if(e.ColumnHeader)
                return;
            // �C���L�[�������ꍇ
            StatusOfResidenceInsUp statusOfResidenceNew = new StatusOfResidenceInsUp(_connectionVo, ((StatusOfResidenceVo)SheetViewList.Cells[e.Row, colStaffName].Tag).Staff_code);
            statusOfResidenceNew.ShowDialog(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemNew":
                    StatusOfResidenceInsUp statusOfResidenceNew = new StatusOfResidenceInsUp(_connectionVo);
                    statusOfResidenceNew.ShowDialog(this);
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // �V�[�g�^�u���\���ɂ���
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 28; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 50; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
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
        /// StatusOfResidenceList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusOfResidenceList_FormClosing(object sender, FormClosingEventArgs e) {
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