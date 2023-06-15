using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Supply {
    public partial class SupplyList : Form {
        private InitializeForm _initializeForm = new();
        private readonly Dictionary<string, int> _dictionaryAffiliationValue = new Dictionary<string, int> { { "�����ł̔��i", 1 },
                                                                                                             { "�ُ�ł̔��i", 2 },
                                                                                                             { "�Y�p�ł̔��i", 3 },
                                                                                                             { "�����ł̔��i", 4 } };
        /*
         * Dao
         */
        private readonly SupplyMasterDao _supplyMasterDao;
        private readonly SupplyMoveDao _supplyMoveDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// ���i�R�[�h
        /// </summary>
        private const int colSupplyCode = 0;
        /// <summary>
        /// ���i��
        /// </summary>
        private const int colSupplyName = 1;
        /// <summary>
        /// �K���݌ɐ�
        /// </summary>
        private const int colAppropriateStock = 2;
        /// <summary>
        /// �����݌ɐ�
        /// </summary>
        private const int colBeginingMonthStock = 3;
        /// <summary>
        /// ���ɐ�
        /// </summary>
        private const int colWarehousing = 4;
        /// <summary>
        /// �o�ɐ�
        /// </summary>
        private const int colDelivery = 5;
        /// <summary>
        /// �݌ɐ�
        /// </summary>
        private const int colStock = 6;

        public SupplyList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _supplyMasterDao = new SupplyMasterDao(connectionVo);
            _supplyMoveDao = new SupplyMoveDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Control������
             */
            InitializeComponent();
            _initializeForm.SupplyList(this);
            /*
             * �݌Ɏ�ʂ�ݒ�
             */
            ComboBoxSupplyType.SelectedIndex = 1;
            /*
             * �����E������ݒ�
             */
            DateTimePickerJpEx1.Value = new Date().GetBeginOfMonth(DateTimePickerJpEx1.Value);
            DateTimePickerJpEx2.Value = new Date().GetEndOfMonth(DateTimePickerJpEx2.Value);
            /*
             * SPREAD������
             */
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

            List<SupplyMasterVo> listSupplyMasterVo = _supplyMasterDao.SelectOneSupplyMaster(_dictionaryAffiliationValue[ComboBoxSupplyType.Text]);

            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            int _supplyNumber = 0;
            foreach(SupplyMasterVo supplyMasterVo in listSupplyMasterVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~
                // ���i�R�[�h
                SheetViewList.Cells[i, colSupplyCode].Value = supplyMasterVo.Code;
                // ���i��
                SheetViewList.Cells[i, colSupplyName].Text = supplyMasterVo.Name;
                // �K���݌ɐ�
                SheetViewList.Cells[i, colAppropriateStock].Value = supplyMasterVo.Proper_stock;
                /*
                 * ���ɐ�
                 */
                try {
                    _supplyNumber = _supplyMoveDao.SelectCountSupplyMoveIn(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, supplyMasterVo.Code);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                SheetViewList.Cells[i, colWarehousing].Value = _supplyNumber;
                /*
                 * �o�ɐ�
                 */
                try {
                    _supplyNumber = _supplyMoveDao.SelectCountSupplyMoveOut(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, supplyMasterVo.Code);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                SheetViewList.Cells[i, colDelivery].Value = _supplyNumber;

                i++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " ��");
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        private void InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // �V�[�g�^�u���\���ɂ���
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 28; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 10); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 50; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
        }

        /// <summary>
        /// ToolStripMenuItemInventory_Click
        /// �I�����̓��͉�ʂ��J��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInventory_Click(object sender, EventArgs e) {
            SupplyIn supplyIn = new SupplyIn(_connectionVo,ComboBoxSupplyType.Text);
            supplyIn.ShowDialog(this);
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
        /// SupplyList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplyList_FormClosing(object sender, FormClosingEventArgs e) {
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