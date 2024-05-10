/*
 * 2024-05-08
 */
using Common;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_CarAccident {
    public partial class H_CarAccidentList : Form {
        /*
         * Column�̔ԍ�
         */
        /// <summary>
        /// �����N����
        /// </summary>
        private const int _colOccurrenceDate = 0;
        /// <summary>
        /// �����ꏊ
        /// </summary>
        private const int _colOccurrenceAddress = 1;
        /// <summary>
        /// ���̏����敪
        /// </summary>
        private const int _colTotallingFlag = 2;
        /// <summary>
        /// ��t�̎��
        /// </summary>
        private const int _colAccident_Kind = 3;
        /// <summary>
        /// ����
        /// </summary>
        private const int _colDisplayName = 4;
        /// <summary>
        /// �E��
        /// </summary>
        private const int _colWorkKind = 5;
        /// <summary>
        /// �ԗ��o�^�ԍ�
        /// </summary>
        private const int _colCarRegistrationNumber = 6;
        /// <summary>
        /// �T�v
        /// </summary>
        private const int _colAccidentSummary = 7;
        /// <summary>
        /// �ڍ�
        /// </summary>
        private const int _colAccidentDetail = 8;
        /// <summary>
        /// �w��
        /// </summary>
        private const int _colGuide = 9;
        /*
         * Dao
         */
        private readonly H_CarAccidentMasterDao _hCarAccidentMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_CarAccidentList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCarAccidentMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            // ���t��������
            HDateTimePickerExOccurrence1.SetValueJp(DateTime.Now.AddMonths(-3));
            HDateTimePickerExOccurrence2.SetValueJp(DateTime.Now.AddDays(1));
            this.InitializeSheetView(SheetViewList);
            ToolStripStatusLabelDetail.Text = "�����R�[�h���F0��";
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            try {
                this.PutSheetViewList(_hCarAccidentMasterDao.SelectAllHCarAccidentMaster(HDateTimePickerExOccurrence1.GetValue(), HDateTimePickerExOccurrence2.GetValue()));
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// PutSheetViewList
        /// </summary>
        /// <param name="listHCarAccidentMasterVo"></param>
        private void PutSheetViewList(List<H_CarAccidentMasterVo> listHCarAccidentMasterVo) {
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach (H_CarAccidentMasterVo hCarAccidentMasterVo in listHCarAccidentMasterVo.OrderBy(x => x.OccurrenceYmdHms)) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~

                SheetViewList.Rows[i].Tag = hCarAccidentMasterVo; //carAccidentLedgerVo��ޔ�����
                SheetViewList.Cells[i, _colOccurrenceDate].Value = hCarAccidentMasterVo.OccurrenceYmdHms;
                SheetViewList.Cells[i, _colOccurrenceAddress].Text = hCarAccidentMasterVo.OccurrenceAddress;
                SheetViewList.Cells[i, _colTotallingFlag].Text = hCarAccidentMasterVo.TotallingFlag ? "���̂Ƃ��Ĉ���" : "";
                SheetViewList.Cells[i, _colAccident_Kind].Text = hCarAccidentMasterVo.AccidentKind;
                SheetViewList.Cells[i, _colDisplayName].Text = hCarAccidentMasterVo.DisplayName;
                SheetViewList.Cells[i, _colWorkKind].Text = hCarAccidentMasterVo.WorkKind;
                SheetViewList.Cells[i, _colCarRegistrationNumber].Text = hCarAccidentMasterVo.CarRegistrationNumber;
                SheetViewList.Cells[i, _colAccidentSummary].Text = hCarAccidentMasterVo.AccidentSummary;
                SheetViewList.Cells[i, _colAccidentDetail].Text = hCarAccidentMasterVo.AccidentDetail;
                SheetViewList.Cells[i, _colGuide].Text = hCarAccidentMasterVo.Guide;
                i++;
            }
            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread ������
            SpreadList.ResumeLayout(true);
            ToolStripStatusLabelDetail.Text = string.Concat("�����R�[�h���F", listHCarAccidentMasterVo.Count, "��");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // �w�b�_�[��DoubleClick�����
            if (e.Row < 0)
                return;
            H_CarAccidentDetail hCarAccidentDetail = new(_connectionVo, (H_CarAccidentMasterVo)SheetViewList.Rows[e.Row].Tag);
            Rectangle rectangleHCarAccidentDetail = new Desktop().GetMonitorWorkingArea(hCarAccidentDetail, _connectionVo.Screen);
            hCarAccidentDetail.KeyPreview = true;
            hCarAccidentDetail.Location = rectangleHCarAccidentDetail.Location;
            hCarAccidentDetail.Size = new Size(1920, 1080);
            hCarAccidentDetail.WindowState = FormWindowState.Normal;
            hCarAccidentDetail.Show(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // Excel�`���ŃG�N�X�|�[�g����
                case "ToolStripMenuItemExportExcel":
                    //xlsx�`���t�@�C�����G�N�X�|�[�g���܂�
                    string fileName = string.Concat("���̃��X�g", DateTime.Now.ToString("MM��dd��"), "�쐬");
                    SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
                    MessageBox.Show("�f�X�N�g�b�v�փG�N�X�|�[�g���܂���", "���b�Z�[�W", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                // �V�K���R�[�h���쐬����
                case "ToolStripMenuItemNewFile":
                    H_CarAccidentDetail hCarAccidentDetail = new(_connectionVo);
                    Rectangle rectangleHCarAccidentDetail = new Desktop().GetMonitorWorkingArea(hCarAccidentDetail, _connectionVo.Screen);
                    hCarAccidentDetail.KeyPreview = true;
                    hCarAccidentDetail.Location = rectangleHCarAccidentDetail.Location;
                    hCarAccidentDetail.Size = new Size(1920, 1080);
                    hCarAccidentDetail.WindowState = FormWindowState.Normal;
                    hCarAccidentDetail.Show(this);
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
        /// <returns>SheetView</returns>
        private SheetView InitializeSheetView(SheetView sheetView) {
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

        private void HDateTimePickerExOccurrence1_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value > HDateTimePickerExOccurrence2.Value) {
                HDateTimePickerExOccurrence2.Value = HDateTimePickerExOccurrence1.Value;
            }
        }

        private void HDateTimePickerExOccurrence2_ValueChanged(object sender, EventArgs e) {
            if (((DateTimePicker)sender).Value < HDateTimePickerExOccurrence1.Value) {
                HDateTimePickerExOccurrence1.Value = HDateTimePickerExOccurrence2.Value;
            }
        }

        /// <summary>
        /// H_CarAccidentList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CarAccidentList_FormClosing(object sender, FormClosingEventArgs e) {
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
