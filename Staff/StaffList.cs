using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Staff {
    public partial class StaffList : Form {
        private InitializeForm _initializeForm = new();
        private List<StaffMasterVo> _listStaffMasterVo;

        // SPREAD��Column�̔ԍ�
        /// <summary>
        /// ����
        /// </summary>
        private const int colBelongs = 0;
        /// <summary>
        /// �`��
        /// </summary>
        private const int colJobForm = 1;
        /// <summary>
        /// �E��
        /// </summary>
        private const int colOccupation = 2;
        /// <summary>
        /// �z�Ԃ̑Ώۂ��ǂ���
        /// </summary>
        private const int colVehicleDispatchTarget = 3;
        /// <summary>
        /// <summary>
        /// �Ј�CD
        /// </summary>
        private const int colStaffCode = 4;
        /// <summary>
        /// ����
        /// </summary>
        private const int colName = 5;
        /// <summary>
        /// �J�i
        /// </summary>
        private const int colNameKana = 6;
        /// <summary>
        /// ����
        /// </summary>
        private const int colToukanpoCard = 7;
        /// <summary>
        /// �Ƌ���
        /// </summary>
        private const int colLicense = 8;
        /// <summary>
        /// �Ƌ��؊���
        /// </summary>
        private const int colLicensExpirationDate = 9;
        /// <summary>
        /// �ʋΓ�
        /// </summary>
        private const int colCommutingNotification = 10;
        /// <summary>
        /// �C�ӕی��I���N����
        /// </summary>
        private const int colMeansOfCommutingEndDate = 11;
        /// <summary>
        /// ���N����
        /// </summary>
        private const int colBirthDate = 12;
        /// <summary>
        /// �N��
        /// </summary>
        private const int colFullAge = 13;
        /// <summary>
        /// �ٗp�N����
        /// </summary>
        private const int colEmploymentDate = 14;
        /// <summary>
        /// �Α��N��
        /// </summary>
        private const int colServiceDate = 15;
        /// <summary>
        /// ���C
        /// </summary>
        private const int colFirstTerm = 16;
        /// <summary>
        /// �K��
        /// </summary>
        private const int colSuitableAge = 17;
        /// <summary>
        /// ���̌���
        /// </summary>
        private const int colCarAccidentCount = 18;
        /// <summary>
        /// �P�N�ȓ��̌��N�f�f
        /// </summary>
        private const int colMedicalExaminationDate = 19;
        /// <summary>
        /// ���Z��
        /// </summary>
        private const int colCurrentAddress = 20;
        /// <summary>
        /// ���N�ی�
        /// </summary>
        private const int colHealthInsuranceNumber = 21;
        /// <summary>
        /// �����N��
        /// </summary>
        private const int colWelfarePensionNumber = 22;
        /// <summary>
        /// �ٗp�ی�
        /// </summary>
        private const int colEmploymentInsuranceNumber = 23;
        /// <summary>
        /// �J�Еی�
        /// </summary>
        private const int colWorkerAccidentInsuranceNumber = 24;

        public StaffList(ConnectionVo connectionVo) {
            /*
             * �R���g���[����������
             */
            InitializeComponent();
            _initializeForm.StaffList(this);

            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();

            // ���̌����W�v�̊�ƂȂ�N�x��������
            ComboBoxAccidentYear.Text = "2022�N�x";
            // FpSpread��������
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = "";
        }

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
        /// TabControlEx1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlEx1_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // �V�[�g�^�u���\��
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 30; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("���C���I", 10); // �s�w�b�_��Font
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
        /// StaffList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffList_FormClosing(object sender, FormClosingEventArgs e) {
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