using Common;

using ControlEx;

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
        private readonly SupplyListDao _supplyListDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// ���i�R�[�h
        /// </summary>
        private const int _colSupplyCode = 0;
        /// <summary>
        /// ���i��
        /// </summary>
        private const int _colSupplyName = 1;
        /// <summary>
        /// �K���݌ɐ�
        /// </summary>
        private const int _colAppropriateStock = 2;
        /// <summary>
        /// �����݌ɐ�
        /// </summary>
        private const int _colBeginingMonthStock = 3;
        /// <summary>
        /// ���ɐ�
        /// </summary>
        private const int _colWarehousing = 4;
        /// <summary>
        /// �o�ɐ�
        /// </summary>
        private const int _colDelivery = 5;
        /// <summary>
        /// �݌ɐ�
        /// </summary>
        private const int _colStock = 6;
        /// <summary>
        /// ������
        /// </summary>
        private const int _colOrder = 7;

        public SupplyList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _supplyListDao = new SupplyListDao(connectionVo);
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
            DateTimePickerJpEx1.Value = new Date().GetBeginOfMonth(DateTime.Now.Date);
            DateTimePickerJpEx2.Value = new Date().GetEndOfMonth(DateTime.Now.Date);
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
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(SupplyListVo supplyListVo in _supplyListDao.SelectSupplyListVo(DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, _dictionaryAffiliationValue[ComboBoxSupplyType.Text])) {
                int _appropriateStock = supplyListVo.AppropriateStock;
                int _beginingMonthStock = supplyListVo.BeginingMonthStock;
                int _warehousing = supplyListVo.Warehousing;
                int _delivery = supplyListVo.Delivery;
                int _stock = _beginingMonthStock + _warehousing - _delivery;
                int _order = _appropriateStock - _stock;

                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~
                // ���i�R�[�h
                SheetViewList.Cells[i, _colSupplyCode].Value = supplyListVo.SupplyCode;
                // ���i��
                SheetViewList.Cells[i, _colSupplyName].Text = supplyListVo.SupplyName;
                // �K���݌ɐ�
                SheetViewList.Cells[i, _colAppropriateStock].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colAppropriateStock].ForeColor = Color.Black;
                SheetViewList.Cells[i, _colAppropriateStock].Value = _appropriateStock;
                // �����݌ɐ�
                SheetViewList.Cells[i, _colBeginingMonthStock].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colBeginingMonthStock].ForeColor = Color.Blue;
                SheetViewList.Cells[i, _colBeginingMonthStock].Value = _beginingMonthStock;
                // ���ɐ�
                SheetViewList.Cells[i, _colWarehousing].Value = _warehousing != 0 ? _warehousing : "";
                // �o�ɐ�
                SheetViewList.Cells[i, _colDelivery].Value = _delivery != 0 ? _delivery : "";
                // �݌ɐ�
                SheetViewList.Cells[i, _colStock].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colStock].ForeColor = Color.Red;
                SheetViewList.Cells[i, _colStock].Value = _stock;
                // ������
                SheetViewList.Cells[i, _colOrder].Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
                SheetViewList.Cells[i, _colOrder].ForeColor = Color.Gray;
                SheetViewList.Cells[i, _colOrder].Value = _order > 0 && _order <= _appropriateStock ? _order : "";

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
            SupplyInventory supplyInventory = new SupplyInventory(_connectionVo);
            supplyInventory.ShowDialog(this);
        }

        /// <summary>
        /// ToolStripMenuItemIn_Click
        /// ���ɐ��̓��͉�ʂ��J��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemIn_Click(object sender, EventArgs e) {
            SupplyIn supplyIn = new SupplyIn(_connectionVo);
            supplyIn.ShowDialog(this);
        }

        /// <summary>
        /// DateTimePickerJpEx_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value > DateTimePickerJpEx2.Value) {
                DateTimePickerJpEx2.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }
        private void DateTimePickerJpEx2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value < DateTimePickerJpEx1.Value) {
                DateTimePickerJpEx1.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrint_Click
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            SpreadList.PrintSheet(SheetViewList);
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
            SupplyDetail supplyDetail = new SupplyDetail(_connectionVo,
                                                         (int)SheetViewList.Cells[e.Row, _colSupplyCode].Value,
                                                         DateTimePickerJpEx1.Value.Date,
                                                         DateTimePickerJpEx2.Value.Date);
            supplyDetail.ShowDialog(this);
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