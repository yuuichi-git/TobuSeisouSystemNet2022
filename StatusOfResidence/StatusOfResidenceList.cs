/*
 * 2023-06-23
 */
using Common;

using FarPoint.Win.Spread;

using Vo;

namespace StatusOfResidence {
    public partial class StatusOfResidenceList : Form {
        private InitializeForm _initializeForm = new();
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
        private const int colSex = 3;
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

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {



        }



        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
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