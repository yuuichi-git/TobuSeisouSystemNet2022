/*
 * 2023-08-21
 */
using Common;

using ControlEx;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace LegalTwelveItem {
    public partial class LegalTwelveItemList : Form {
        private Date _date = new();
        private InitializeForm _initializeForm = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        int spreadListTopRow = 0;
        /*
         * Columns
         */
        private const int colBelongsName = 0;
        private const int colJobFormName = 1;
        private const int colOccupation = 2;
        private const int colName = 3;
        private const int colEmploymentDate = 4;
        private const int colStudentsFlag01 = 5;
        private const int colStudentsFlag02 = 6;
        private const int colStudentsFlag03 = 7;
        private const int colStudentsFlag04 = 8;
        private const int colStudentsFlag05 = 9;
        private const int colStudentsFlag06 = 10;
        private const int colStudentsFlag07 = 11;
        private const int colStudentsFlag08 = 12;
        private const int colStudentsFlag09 = 13;
        private const int colStudentsFlag10 = 14;
        private const int colStudentsFlag11 = 15;
        private const int colStudentsFlag12 = 16;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * Dao
         */
        private readonly LegalTwelveItemDao _legalTwelveItemDao;

        public LegalTwelveItemList(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * Dao
             */
            _legalTwelveItemDao = new LegalTwelveItemDao(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            _initializeForm.LegalTwelveItemList(this);
            DateTimePickerJpEx1.Value = _date.GetFiscalYearStartDate(DateTime.Today);
            DateTimePickerJpEx2.Value = _date.GetFiscalYearEndDate(DateTime.Today);
            CheckBoxShortTerm.Checked = false;
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
            /*
             * SheetViewList�̏���
             */
            SpreadList.SuspendLayout(); // Spread �񊈐���
            spreadListTopRow = SpreadList.GetViewportTopRow(0); // �擪�s�i��j�C���f�b�N�X���擾
            if(SheetViewList.Rows.Count > 0) // Row���폜����
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            /*
             * ���R�[�h���擾
             */
            List<LegalTwelveItemListVo> listLegalTwelveItemFormVo = _legalTwelveItemDao.SelectLegalTwelveItemList(DateTimePickerJpEx1.GetValue(), DateTimePickerJpEx2.GetValue(),CheckBoxShortTerm.Checked);
            /*
             * SheetViewList�֕\��
             */
            int i = 0;
            foreach(LegalTwelveItemListVo legalTwelveItemFormVo in listLegalTwelveItemFormVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].ForeColor = legalTwelveItemFormVo.Job_form == 11 ? Color.Red : Color.Black; // �蒠�̃��R�[�h��ForeColor���Z�b�g
                SheetViewList.Cells[i, colBelongsName].Text = legalTwelveItemFormVo.Belongs_name;
                SheetViewList.Cells[i, colJobFormName].Text = legalTwelveItemFormVo.Job_form_name;
                SheetViewList.Cells[i, colOccupation].Text = legalTwelveItemFormVo.Occupation_name;
                SheetViewList.Cells[i, colName].Tag = legalTwelveItemFormVo; // LegalTwelveItemListVo��ޔ�
                SheetViewList.Cells[i, colName].Text = legalTwelveItemFormVo.Staff_name;
                SheetViewList.Cells[i, colEmploymentDate].Text = legalTwelveItemFormVo.Employment_date != _defaultDateTime ? legalTwelveItemFormVo.Employment_date.ToString("yyyy/MM/dd") : "";
                SheetViewList.Cells[i, colStudentsFlag01].Text = legalTwelveItemFormVo.Students_01_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag02].Text = legalTwelveItemFormVo.Students_02_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag03].Text = legalTwelveItemFormVo.Students_03_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag04].Text = legalTwelveItemFormVo.Students_04_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag05].Text = legalTwelveItemFormVo.Students_05_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag06].Text = legalTwelveItemFormVo.Students_06_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag07].Text = legalTwelveItemFormVo.Students_07_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag08].Text = legalTwelveItemFormVo.Students_08_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag09].Text = legalTwelveItemFormVo.Students_09_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag10].Text = legalTwelveItemFormVo.Students_10_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag11].Text = legalTwelveItemFormVo.Students_11_flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag12].Text = legalTwelveItemFormVo.Students_12_flag ? "�Z" : "";
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
            /*
             * �w�b�_�[��DoubleClick�����
             */
            if(e.ColumnHeader)
                return;
            /*
             * Detail�E�C���h�E��\��
             */
            LegalTwelveItemListVo legalTwelveItemListVo = (LegalTwelveItemListVo)SheetViewList.Cells[e.Row,colName].Tag; // Vo���擾
            LegalTwelveItemDetail legalTwelveItemDetail = new LegalTwelveItemDetail(_connectionVo, DateTimePickerJpEx1.Value, DateTimePickerJpEx2.Value, legalTwelveItemListVo);
            legalTwelveItemDetail.ShowDialog(this);
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
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// DateTimePickerJpEx1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx1_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value > DateTimePickerJpEx2.Value) {
                DateTimePickerJpEx2.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }

        /// <summary>
        /// DateTimePickerJpEx2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx2_ValueChanged(object sender, EventArgs e) {
            if(((DateTimePickerJpEx)sender).Value < DateTimePickerJpEx1.Value) {
                DateTimePickerJpEx1.Value = ((DateTimePickerJpEx)sender).Value;
            }
        }

        /// <summary>
        /// ToolStripMenuItemPrintSheet_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPrintSheet_Click(object sender, EventArgs e) {
            //�A�N�e�B�u�V�[�g������܂�
            SpreadList.PrintSheet(SheetViewList);
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
        /// LegalTwelveItemList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LegalTwelveItemList_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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