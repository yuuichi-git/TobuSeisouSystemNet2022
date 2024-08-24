/*
 * 2024-04-27
 */
using System.Drawing.Printing;

using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using H_Vo;

using Vo;

namespace H_LegalTwelveItem {
    public partial class H_LegalTwelveItemList : Form {
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
        private readonly DateTime _defaultDatetime = new DateTime(1900, 01, 01);
        /*
         * 
         */
        private readonly Date _date;
        /*
         * Dao
         */
        private readonly H_LegalTwelveItemDao _hLegalTwelveItemDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_LegalTwelveItemList(ConnectionVo connectionVo) {
            /*
             * 
             */
            _date = new();
            /*
             * Dao
             */
            _hLegalTwelveItemDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.HCheckBoxExJobForm.Checked = false;
            this.InitializeSheetViewList(SheetViewList);
            this.ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.PutSheetViewList(_hLegalTwelveItemDao.SelectHLegalTwelveItemListVo(_date.GetFiscalYearStartDate((int)HNumericUpDownExFiscalYear.Value), _date.GetFiscalYearEndDate((int)HNumericUpDownExFiscalYear.Value), HCheckBoxExJobForm.Checked));
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="listHLegalTwelveItemVo"></param>
        private void PutSheetViewList(List<H_LegalTwelveItemListVo> listHLegalTwelveItemVo) {
            /*
             * SheetViewList�̏���
             */
            SpreadList.SuspendLayout(); // Spread �񊈐���
            spreadListTopRow = SpreadList.GetViewportTopRow(0); // �擪�s�i��j�C���f�b�N�X���擾
            if (SheetViewList.Rows.Count > 0) // Row���폜����
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            /*
             * SheetViewList�֕\��
             */
            int i = 0;
            foreach (H_LegalTwelveItemListVo hLegalTwelveItemVo in listHLegalTwelveItemVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].ForeColor = hLegalTwelveItemVo.JobForm == 11 ? Color.Blue : Color.Black; // �蒠�̃��R�[�h��ForeColor���Z�b�g
                SheetViewList.Rows[i].Tag = hLegalTwelveItemVo; // H_LegalTwelveItemVo��ޔ�
                SheetViewList.Cells[i, colBelongsName].Text = hLegalTwelveItemVo.BelongsName;
                SheetViewList.Cells[i, colJobFormName].Text = hLegalTwelveItemVo.JobFormName;
                SheetViewList.Cells[i, colOccupation].Text = hLegalTwelveItemVo.OccupationName;
                SheetViewList.Cells[i, colName].Text = hLegalTwelveItemVo.StaffName;
                SheetViewList.Cells[i, colEmploymentDate].Text = hLegalTwelveItemVo.EmploymentDate != _defaultDatetime ? hLegalTwelveItemVo.EmploymentDate.ToString("yyyy/MM/dd") : "";
                SheetViewList.Cells[i, colStudentsFlag01].Text = hLegalTwelveItemVo.Students01Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag02].Text = hLegalTwelveItemVo.Students02Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag03].Text = hLegalTwelveItemVo.Students03Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag04].Text = hLegalTwelveItemVo.Students04Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag05].Text = hLegalTwelveItemVo.Students05Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag06].Text = hLegalTwelveItemVo.Students06Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag07].Text = hLegalTwelveItemVo.Students07Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag08].Text = hLegalTwelveItemVo.Students08Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag09].Text = hLegalTwelveItemVo.Students09Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag10].Text = hLegalTwelveItemVo.Students10Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag11].Text = hLegalTwelveItemVo.Students11Flag ? "�Z" : "";
                SheetViewList.Cells[i, colStudentsFlag12].Text = hLegalTwelveItemVo.Students12Flag ? "�Z" : "";
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
            if (e.ColumnHeader)
                return;
            /*
             * Detail�E�C���h�E��\��
             */
            H_LegalTwelveItemDetail hLegalTwelveItemDetail = new(_connectionVo, (int)HNumericUpDownExFiscalYear.Value, (H_LegalTwelveItemListVo)SheetViewList.Rows[e.Row].Tag);
            new Desktop().SetPosition(hLegalTwelveItemDetail, _connectionVo.Screen);
            hLegalTwelveItemDetail.KeyPreview = true;
            hLegalTwelveItemDetail.Show(this);
            return;
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDrop���֎~����
            SpreadList.PaintSelectionHeader = false; // �w�b�_�̑I����Ԃ����Ȃ�
            SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            sheetView.AlternatingRows.Count = 2; // �s�X�^�C�����Q�s�P�ʂƂ��܂�
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2�s�ڂ̔w�i�F��ݒ肵�܂�
            sheetView.ColumnHeader.Rows[0].Height = 26; // Column�w�b�_�̍���
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 48; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // A4�ň��
                case "ToolStripMenuItemPrintA4":
                    PrintDocument _printDocument = new();
                    // Event��o�^
                    _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                    // �o�͐�v�����^���w�肵�܂��B
                    //_printDocument.PrinterSettings.PrinterName = this.HComboBoxExPrinterName.Text;
                    // �p���̌�����ݒ�(���Ftrue�A�c�Ffalse)
                    _printDocument.DefaultPageSettings.Landscape = false;
                    /*
                     * �v�����^���T�|�[�g���Ă���p���T�C�Y�𒲂ׂ�
                     */
                    foreach (PaperSize paperSize in _printDocument.PrinterSettings.PaperSizes) {
                        // A4�p���ɐݒ肷��
                        if (paperSize.Kind == PaperKind.A4) {
                            _printDocument.DefaultPageSettings.PaperSize = paperSize;
                            break;
                        }
                    }
                    // ����������w�肵�܂��B
                    _printDocument.PrinterSettings.Copies = 1;
                    // �Жʈ���ɐݒ肵�܂��B
                    _printDocument.PrinterSettings.Duplex = Duplex.Default;
                    // �J���[����ɐݒ肵�܂��B
                    _printDocument.PrinterSettings.DefaultPageSettings.Color = true;
                    // �������
                    _printDocument.Print();
                    break;
                case "ToolStripMenuItemPrintA4Dialog":
                    // Excel���C�N�ȃv���r���[�_�C�A���O��L���ɂ��܂�
                    SheetViewList.PrintInfo.EnhancePreview = true;
                    SheetViewList.PrintInfo.Preview = true;
                    SheetViewList.PrintInfo.ShowBorder = false;
                    SheetViewList.PrintInfo.ShowColor = true;
                    // ��������s���܂�
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // �A�v���P�[�V�������I������
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            // ����y�[�W�i1�y�[�W�ځj�̕`����s��
            Rectangle rectangle = new(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
            // e.Graphics�֏o��(page �p�����[�^�́A�O����ł͂Ȃ��P����n�܂�܂�)
            SpreadList.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
            // ����I�����w��
            e.HasMorePages = false;
        }

        /// <summary>
        /// H_LegalTwelveItemList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LegalTwelveItemList_FormClosing(object sender, FormClosingEventArgs e) {
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
