using Common;

using Dao;

using FarPoint.Win.Spread;

using H_Vo;

namespace WardSpreadsheet {
    public partial class WardChiyoda : Form {
        private Dictionary<DateTime, string> _dictionaryHoliday;
        /*
         * Dao
         */
        private WardChiyodaDao _wardSpreadSheetDao;
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;
        List<WardChiyodaVo> _listWardChiyodaVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public WardChiyoda(ConnectionVo connectionVo) {
            _dictionaryHoliday = new HolidayUtil().GetHoliday();
            /*
             * Dao
             */
            _wardSpreadSheetDao = new WardChiyodaDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            DateTimePicker1.Value = DateTime.Now;
            DateTimePicker2.Value = DateTime.Now;
            InitializeSheetViewList(SheetViewList);
            InitializeSheetViewCount(SheetViewAggregate);
            ToolStripStatusLabelStatus.Text = string.Empty;
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
            _listWardChiyodaVo = _wardSpreadSheetDao.SelectChiyodaVehicleDispatchDetail(DateTimePicker1.Value, DateTimePicker2.Value);
            SheetViewListOutPut();
            SheetViewAggregateOutPut();
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int sheetViewListTopRow = 0;
        private void SheetViewListOutPut() {
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // Row���폜����
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            // �擪�s�i��j�C���f�b�N�X���擾
            sheetViewListTopRow = SpreadList.GetViewportTopRow(0);

            int i = 0;
            foreach(WardChiyodaVo wardChiyodaVo in _listWardChiyodaVo) {
                SheetViewList.AddRows(i, 1);
                if(_dictionaryHoliday.ContainsKey(wardChiyodaVo.Operation_date)) {
                    SheetViewList.Cells[i, 0].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 0].Text = string.Concat(wardChiyodaVo.Operation_date.ToString("yyyy�NMM��dd��"), "(", _dictionaryHoliday[wardChiyodaVo.Operation_date], ")");
                    SheetViewList.Cells[i, 1].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 1].Text = wardChiyodaVo.Operator_name_1;
                    SheetViewList.Cells[i, 2].ForeColor = Color.Red;
                    SheetViewList.Cells[i, 2].Text = wardChiyodaVo.Operator_name_2;
                    SheetViewList.Cells[i, 3].ForeColor = Color.Gray;
                    SheetViewList.Cells[i, 3].Text = wardChiyodaVo.Operator_name_3;
                } else {
                    SheetViewList.Cells[i, 0].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 0].Text = wardChiyodaVo.Operation_date.ToString("yyyy�NMM��dd��(dddd)");
                    SheetViewList.Cells[i, 1].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 1].Text = wardChiyodaVo.Operator_name_1;
                    SheetViewList.Cells[i, 2].ForeColor = Color.Black;
                    SheetViewList.Cells[i, 2].Text = wardChiyodaVo.Operator_name_2;
                    SheetViewList.Cells[i, 3].ForeColor = Color.Gray;
                    SheetViewList.Cells[i, 3].Text = wardChiyodaVo.Operator_name_3;
                }
                i++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, sheetViewListTopRow);
            // Spread ������
            SpreadList.ResumeLayout();
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int sheetViewAggregateTopRow = 0;
        private void SheetViewAggregateOutPut() {
            // Spread �񊈐���
            SpreadAggregate.SuspendLayout();
            // Row���폜����
            if(SheetViewAggregate.Rows.Count > 0)
                SheetViewAggregate.RemoveRows(0, SheetViewAggregate.Rows.Count);
            // �擪�s�i��j�C���f�b�N�X���擾
            sheetViewAggregateTopRow = SpreadAggregate.GetViewportTopRow(0);
            List<WardChiyodaVo2> listWardChiyodaVo2 = _wardSpreadSheetDao.SelectGroupByChiyodaVehicleDispatchDetail(DateTimePicker1.Value, DateTimePicker2.Value);
            foreach(var wardChiyodaVo2 in listWardChiyodaVo2) {
                bool newRowFlag = true;
                for(int rowNumber = 0; rowNumber < SheetViewAggregate.RowCount; rowNumber++) {
                    string key1 = SheetViewAggregate.Cells[rowNumber, 0].Text;
                    string key2 = SheetViewAggregate.Cells[rowNumber, 1].Text;
                    int key3 = (int)SheetViewAggregate.Cells[rowNumber, 2].Value;
                    int key4 = (int)SheetViewAggregate.Cells[rowNumber, 3].Value;
                    if(wardChiyodaVo2.Operator_name == key1 && wardChiyodaVo2.Occupation == key2) {
                        /*
                         * �j�����ǂ����𔻒肷��(���j���͓����Ă��Ȃ��̂Œ��ӂ��Ă�)
                         */
                        if(_dictionaryHoliday.ContainsKey(wardChiyodaVo2.Operation_date)) {
                            /*
                             * �j���̏ꍇ
                             */
                            key4++;
                            SheetViewAggregate.Cells[rowNumber, 3].Value = key4;
                            newRowFlag = false;
                        } else {
                            /*
                             * �����̏ꍇ
                             */
                            key3++;
                            SheetViewAggregate.Cells[rowNumber, 2].Value = key3;
                            newRowFlag = false;
                        }
                    };
                }
                /*
                 * �V�KRow��}������
                 * �j�����ǂ����𔻒肷��(���j���͓����Ă��Ȃ��̂Œ��ӂ��Ă�)
                 */
                if(newRowFlag) {
                    if(_dictionaryHoliday.ContainsKey(wardChiyodaVo2.Operation_date)) {
                        /*
                         * �j���̏ꍇ
                         */
                        SheetViewAggregate.AddRows(0, 1);
                        SheetViewAggregate.Cells[0, 0].Tag = wardChiyodaVo2.Operator_code;
                        SheetViewAggregate.Cells[0, 0].Text = wardChiyodaVo2.Operator_name;
                        SheetViewAggregate.Cells[0, 1].Text = wardChiyodaVo2.Occupation;
                        SheetViewAggregate.Cells[0, 2].Value = 0; // �����̏o�Γ�����������
                        SheetViewAggregate.Cells[0, 3].Value = 1; // �x���̏o�Γ�����������
                        SheetViewAggregate.Cells[0, 4].Value = 0;
                    } else {
                        /*
                         * �����̏ꍇ
                         */
                        SheetViewAggregate.AddRows(0, 1);
                        SheetViewAggregate.Cells[0, 0].Tag = wardChiyodaVo2.Operator_code;
                        SheetViewAggregate.Cells[0, 0].Text = wardChiyodaVo2.Operator_name;
                        SheetViewAggregate.Cells[0, 1].Text = wardChiyodaVo2.Occupation;
                        SheetViewAggregate.Cells[0, 2].Value = 1; // �����̏o�Γ�����������
                        SheetViewAggregate.Cells[0, 3].Value = 0; // �x���̏o�Γ�����������
                        SheetViewAggregate.Cells[0, 4].Value = 0;
                    }
                }
            }
            /*
             * Footer�W�v
             */
            int H_GKI = 0;
            int K_GKI = 0;
            for(int i = 0; i < SheetViewAggregate.RowCount; i++) {
                H_GKI = H_GKI + (int)SheetViewAggregate.Cells[i, 2].Value;
                K_GKI = K_GKI + (int)SheetViewAggregate.Cells[i, 3].Value;
            }
            SheetViewAggregate.ColumnFooter.Cells[0, 2].Text = H_GKI.ToString();
            SheetViewAggregate.ColumnFooter.Cells[0, 3].Text = K_GKI.ToString();
            /*
             * �S�Ă̔z�Ԑ�ł̏o�Γ����v�Z
             */
            for(int i = 0; i < SheetViewAggregate.RowCount; i++) {
                SheetViewAggregate.Cells[i, 4].Value = _wardSpreadSheetDao.GetWorkDaysForStaff(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, (int)SheetViewAggregate.Cells[i, 0].Tag);
            }
            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadAggregate.SetViewportTopRow(0, sheetViewAggregateTopRow);
            // Spread ������
            SpreadAggregate.ResumeLayout();
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
            sheetView.ColumnHeader.Rows[0].Height = 28; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 50; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            // Row���폜����
            if(sheetView.Rows.Count > 0)
                sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// InitializeSheetViewCount
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewCount(SheetView sheetView) {
            SpreadAggregate.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadAggregate.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadAggregate.TabStripPolicy = TabStripPolicy.Never; // �V�[�g�^�u���\��
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 28; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 50; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            // Row���폜����
            if(sheetView.Rows.Count > 0)
                sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// DateTimePicker1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePicker)sender).Value > DateTimePicker2.Value) {
                DateTimePicker2.Value = ((DateTimePicker)sender).Value;
            }
        }

        /// <summary>
        /// DateTimePicker2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePicker)sender).Value < DateTimePicker1.Value) {
                DateTimePicker1.Value = ((DateTimePicker)sender).Value;
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //�A�N�e�B�u�V�[�g������܂�
            SpreadAggregate.PrintSheet(SheetViewAggregate);
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
        /// WardChiyoda_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WardChiyoda_FormClosing(object sender, FormClosingEventArgs e) {
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