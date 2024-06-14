/*
 * 2024-04-06
 */
using Common;

using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_License {
    public partial class HLicenseList : Form {
        /*
         * List�p
         */
        /// <summary>
        /// �Ј��R�[�h
        /// </summary>
        private const int _colStaffCode = 0;
        /// <summary>
        /// ����
        /// </summary>
        private const int _colName = 1;
        /// <summary>
        /// ��t�N����
        /// </summary>
        private const int _colDeliveryDate = 2;
        /// <summary>
        /// �L������
        /// </summary>
        private const int _colExpirationDate = 3;
        /// <summary>
        /// ������
        /// </summary>
        private const int _colLicenseCondition = 4;
        /// <summary>
        /// �Ƌ��ؔԍ�
        /// </summary>
        private const int _colLicenseNumber = 5;
        /// <summary>
        /// ��^
        /// </summary>
        private const int _colLarge = 6;
        /// <summary>
        /// ���^
        /// </summary>
        private const int _colMedium = 7;
        /// <summary>
        /// �����^
        /// </summary>
        private const int _colQuasiMedium = 8;
        /// <summary>
        /// ����
        /// </summary>
        private const int _colOrdinary = 9;
        /// <summary>
        /// ���
        /// </summary>
        private const int _colBigSpecial = 10;
        /// <summary>
        /// �厩��
        /// </summary>
        private const int _colBigAutoBike = 11;
        /// <summary>
        /// ������
        /// </summary>
        private const int _colOrdinaryAutoBike = 12;
        /// <summary>
        /// ����
        /// </summary>
        private const int _colSmallSpecial = 13;
        /// <summary>
        /// ���t
        /// </summary>
        private const int _colWithARaw = 14;

        /*
         * ���C�d�q�p
         */
        /// <summary>
        /// ALC-REC�ł̒ʂ�ID
        /// </summary>
        private const int _colTId = 0;
        /// <summary>
        /// ����
        /// </summary>
        private const int _colTName = 1;
        /// <summary>
        /// �Ƌ��ؔԍ�
        /// </summary>
        private const int _colTLicenseNumber = 2;
        /// <summary>
        /// �Ƌ�����
        /// </summary>
        private const int _colTLicenseExpirationDate = 3;
        /// <summary>
        /// ��t��(�l��)
        /// </summary>
        private const int _colTIssuanceDate = 4;
        /// <summary>
        /// �Ƌ����
        /// </summary>
        private const int _colTLicenseType = 5;
        /// <summary>
        /// PIN�o�^
        /// </summary>
        private const int _colTPin = 6;
        /// <summary>
        /// �ؖ��ʐ^
        /// </summary>
        private const int _colTPicture = 7;
        /// <summary>
        /// �t���K�i
        /// </summary>
        private const int _colTNameKana = 8;
        /*
         * Dao
         */
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public HLicenseList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hLicenseMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            // SpreadList/SheetViewList/SheetViewToukaidenshi
            InitializeSheetView(SheetViewList);
            InitializeSheetView(SheetViewToukaidenshi);
           �@// ToolStripStatusLabelDetail
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            switch (SpreadList.ActiveSheetIndex) {
                case 0: // SheetViewList
                    ToolStripMenuItemToukaiCSV.Enabled = false;
                    this.PutSheetViewList(_hLicenseMasterDao.SelectAllHLicenseMaster());
                    break;
                case 1: // SheetViewTokaidenshi
                    ToolStripMenuItemToukaiCSV.Enabled = true;
                    this.PutSheetViewToukaidenshi(_hLicenseMasterDao.SelectAllHLicenseMaster());
                    break;
            }
        }

        /// <summary>
        /// HTabControlExKANA_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HTabControlExKANA_Click(object sender, EventArgs e) {
            this.PutSheetViewList(_hLicenseMasterDao.SelectAllHLicenseMaster());
        }

        /// <summary>
        /// PutSheetViewList
        /// </summary>
        int spreadListTopRow = 0;
        private void PutSheetViewList(List<H_LicenseMasterVo> listHLicenseMasterVo) {
            int rowCount = 0;
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            /*
             * Row���폜����
             */
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            List<H_LicenseMasterVo> _listHLicenseMasterVo = HTabControlExKANA.SelectedTab.Text switch {
                "���s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�A") || x.NameKana.StartsWith("�C") || x.NameKana.StartsWith("�E") || x.NameKana.StartsWith("�G") || x.NameKana.StartsWith("�I")),
                "���s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�J") || x.NameKana.StartsWith("�K") || x.NameKana.StartsWith("�L") || x.NameKana.StartsWith("�M") || x.NameKana.StartsWith("�N") || x.NameKana.StartsWith("�O") || x.NameKana.StartsWith("�P") || x.NameKana.StartsWith("�Q") || x.NameKana.StartsWith("�R") || x.NameKana.StartsWith("�S")),
                "���s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�T") || x.NameKana.StartsWith("�V") || x.NameKana.StartsWith("�X") || x.NameKana.StartsWith("�Z") || x.NameKana.StartsWith("�\")),
                "���s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�^") || x.NameKana.StartsWith("�_") || x.NameKana.StartsWith("�`") || x.NameKana.StartsWith("�c") || x.NameKana.StartsWith("�e") || x.NameKana.StartsWith("�f") || x.NameKana.StartsWith("�g") || x.NameKana.StartsWith("�h")),
                "�ȍs" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�i") || x.NameKana.StartsWith("�j") || x.NameKana.StartsWith("�k") || x.NameKana.StartsWith("�l") || x.NameKana.StartsWith("�m")),
                "�͍s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�n") || x.NameKana.StartsWith("�p") || x.NameKana.StartsWith("�q") || x.NameKana.StartsWith("�r") || x.NameKana.StartsWith("�t") || x.NameKana.StartsWith("�u") || x.NameKana.StartsWith("�w") || x.NameKana.StartsWith("�x") || x.NameKana.StartsWith("�z")),
                "�܍s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("�}") || x.NameKana.StartsWith("�~") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��")),
                "��s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��")),
                "��s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��")),
                "��s" => listHLicenseMasterVo.FindAll(x => x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��") || x.NameKana.StartsWith("��")),
                _ => listHLicenseMasterVo,
            };
            // �폜�ς̃��R�[�h���\��
            if (!ToolStripMenuItemDeleted.Checked)
                _listHLicenseMasterVo = _listHLicenseMasterVo.FindAll(x => x.DeleteFlag == false);
            foreach (H_LicenseMasterVo hLicenseMasterVo in _listHLicenseMasterVo.OrderBy(x => x.NameKana)) {
                SheetViewList.Rows.Add(rowCount, 1);
                SheetViewList.RowHeader.Columns[0].Label = (rowCount + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[rowCount].ForeColor = hLicenseMasterVo.DeleteFlag ? Color.Red : Color.Black; // �ސE�ς̃��R�[�h��ForeColor���Z�b�g
                SheetViewList.Rows[rowCount].Height = 20; // Row�̍���
                SheetViewList.Rows[rowCount].Resizable = false; // Row��Resizable���֎~
                SheetViewList.Rows[rowCount].Tag = hLicenseMasterVo;
                // �Ј��R�[�h
                SheetViewList.Cells[rowCount, _colStaffCode].Text = hLicenseMasterVo.StaffCode.ToString("#####");
                // ����
                SheetViewList.Cells[rowCount, _colName].Text = hLicenseMasterVo.Name;
                // ��t�N����
                SheetViewList.Cells[rowCount, _colDeliveryDate].Value = hLicenseMasterVo.DeliveryDate.Date;
                // �L������
                SheetViewList.Cells[rowCount, _colExpirationDate].Value = hLicenseMasterVo.ExpirationDate.Date;
                // ������
                SheetViewList.Cells[rowCount, _colLicenseCondition].Text = hLicenseMasterVo.LicenseCondition;
                // �Ƌ��ؔԍ�
                SheetViewList.Cells[rowCount, _colLicenseNumber].Text = hLicenseMasterVo.LicenseNumber;
                // ��^
                SheetViewList.Cells[rowCount, _colLarge].Text = hLicenseMasterVo.Large ? "��" : "";
                // ���^
                SheetViewList.Cells[rowCount, _colMedium].Text = hLicenseMasterVo.Medium ? "��" : "";
                // �����^
                SheetViewList.Cells[rowCount, _colQuasiMedium].Text = hLicenseMasterVo.QuasiMedium ? "��" : "";
                // ����
                SheetViewList.Cells[rowCount, _colOrdinary].Text = hLicenseMasterVo.Ordinary ? "��" : "";
                // ���
                SheetViewList.Cells[rowCount, _colBigSpecial].Text = hLicenseMasterVo.BigSpecial ? "��" : "";
                // �厩��
                SheetViewList.Cells[rowCount, _colBigAutoBike].Text = hLicenseMasterVo.BigAutoBike ? "��" : "";
                // ������
                SheetViewList.Cells[rowCount, _colOrdinaryAutoBike].Text = hLicenseMasterVo.OrdinaryAutoBike ? "��" : "";
                // ����
                SheetViewList.Cells[rowCount, _colSmallSpecial].Text = hLicenseMasterVo.SmallSpecial ? "��" : "";
                // ���t
                SheetViewList.Cells[rowCount, _colWithARaw].Text = hLicenseMasterVo.WithARaw ? "��" : "";
                rowCount++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", rowCount, " ��");
        }

        private void PutSheetViewToukaidenshi(List<H_LicenseMasterVo> listHLicenseMasterVo) {
            // Spread �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            if (SheetViewToukaidenshi.Rows.Count > 0)
                SheetViewToukaidenshi.RemoveRows(0, SheetViewToukaidenshi.Rows.Count);
            int i = 0;

            foreach (H_LicenseMasterVo hLicenseMasterVo in listHLicenseMasterVo) {
                /*
                 * 245�Ԃ͗\���Ŏg�p����̂ŋ󂯂Ă�������
                 */
                if (i + 1 == 245)
                    i++;
                SheetViewToukaidenshi.Rows.Add(i, 1);
                SheetViewToukaidenshi.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewToukaidenshi.Rows[i].Height = 22; // Row�̍���
                SheetViewToukaidenshi.Rows[i].Resizable = false; // Row��Resizable���֎~
                SheetViewToukaidenshi.Cells[i, _colTId].Text = string.Concat(i + 1);
                SheetViewToukaidenshi.Cells[i, _colTName].Text = hLicenseMasterVo.Name;
                SheetViewToukaidenshi.Cells[i, _colTLicenseNumber].Text = hLicenseMasterVo.LicenseNumber;
                SheetViewToukaidenshi.Cells[i, _colTLicenseExpirationDate].Text = hLicenseMasterVo.ExpirationDate.ToString("yyyy/MM/dd");
                SheetViewToukaidenshi.Cells[i, _colTIssuanceDate].Text = hLicenseMasterVo.DeliveryDate.ToString("yyyy/MM/dd");
                SheetViewToukaidenshi.Cells[i, _colTLicenseType].Text = string.Empty;
                SheetViewToukaidenshi.Cells[i, _colTPin].Text = "��";
                SheetViewToukaidenshi.Cells[i, _colTPicture].Text = "��";
                SheetViewToukaidenshi.Cells[i, _colTNameKana].Text = hLicenseMasterVo.NameKana;
                i++;
            }
            /*
             * 254�Ԃ̗\����ǉ�����
             */
            SheetViewToukaidenshi.Rows.Add(i, 1);
            SheetViewToukaidenshi.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
            SheetViewToukaidenshi.Rows[i].Height = 22; // Row�̍���
            SheetViewToukaidenshi.Rows[i].Resizable = false; // Row��Resizable���֎~
            SheetViewToukaidenshi.Cells[i, _colTId].Text = "245";
            SheetViewToukaidenshi.Cells[i, _colTName].Text = "�\��";
            SheetViewToukaidenshi.Cells[i, _colTLicenseNumber].Text = string.Empty;
            SheetViewToukaidenshi.Cells[i, _colTLicenseExpirationDate].Text = DateTime.Now.AddYears(2).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTIssuanceDate].Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTLicenseType].Text = "";
            SheetViewToukaidenshi.Cells[i, _colTPin].Text = "��";
            SheetViewToukaidenshi.Cells[i, _colTPicture].Text = "��";
            SheetViewToukaidenshi.Cells[i, _colTNameKana].Text = "���r";
            /*
             * 9999�Ԃ̗\��(�_���p)��ǉ�����
             */
            SheetViewToukaidenshi.Rows.Add(i, 1);
            SheetViewToukaidenshi.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
            SheetViewToukaidenshi.Rows[i].Height = 22; // Row�̍���
            SheetViewToukaidenshi.Rows[i].Resizable = false; // Row��Resizable���֎~
            SheetViewToukaidenshi.Cells[i, _colTId].Text = "9999";
            SheetViewToukaidenshi.Cells[i, _colTName].Text = "�_���p";
            SheetViewToukaidenshi.Cells[i, _colTLicenseNumber].Text = string.Empty;
            SheetViewToukaidenshi.Cells[i, _colTLicenseExpirationDate].Text = DateTime.Now.AddYears(2).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTIssuanceDate].Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            SheetViewToukaidenshi.Cells[i, _colTLicenseType].Text = "";
            SheetViewToukaidenshi.Cells[i, _colTPin].Text = "��";
            SheetViewToukaidenshi.Cells[i, _colTPicture].Text = "��";
            SheetViewToukaidenshi.Cells[i, _colTNameKana].Text = "�e���P�����E";

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
            // �_�u���N���b�N���ꂽ�̂��]���҃��X�g�Ŗ������Return����
            if (((FpSpread)sender).ActiveSheet.SheetName != "LicenseList")
                return;
            // �w�b�_�[��DoubleClick�����
            if (e.ColumnHeader)
                return;
            // Shift�������ꂽ�ꍇ
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {

                return;
            }
            // �C���L�[�������ꍇ
            HLicenseDetail hLicenseDetail = new(_connectionVo, ((H_LicenseMasterVo)SheetViewList.Rows[e.Row].Tag).StaffCode);
            Rectangle rectangleHLicenseDetail = new Desktop().GetMonitorWorkingArea(hLicenseDetail, _connectionVo.Screen);
            hLicenseDetail.KeyPreview = true;
            hLicenseDetail.Location = rectangleHLicenseDetail.Location;
            hLicenseDetail.Size = new Size(1180, 810);
            hLicenseDetail.WindowState = FormWindowState.Normal;
            hLicenseDetail.Show(this);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // �V�K���R�[�h���쐬����
                case "ToolStripMenuItemNewLicense":
                    HLicenseDetail hLicenseDetail = new(_connectionVo);
                    Rectangle rectangleHLicenseDetail = new Desktop().GetMonitorWorkingArea(hLicenseDetail, _connectionVo.Screen);
                    hLicenseDetail.KeyPreview = true;
                    hLicenseDetail.Location = rectangleHLicenseDetail.Location;
                    hLicenseDetail.Size = new Size(1180, 810);
                    hLicenseDetail.WindowState = FormWindowState.Normal;
                    hLicenseDetail.Show(this);
                    break;
                // ���C�d�qALC�pCSV
                case "ToolStripMenuItemToukaiCSV":
                    //csv�`���t�@�C�����G�N�X�|�[�g���܂�
                    string fileName = string.Concat("���C�d�q�Ƌ��؃f�[�^", DateTime.Now.ToString("MM��dd��"), "�쐬");
                    //�A�N�e�B�u�V�[�g��̑S�f�[�^��csv�`���t�@�C���ɕۑ����܂�
                    SheetViewToukaidenshi.SaveTextFile(new Directry().GetExcelDesktopPassCsv(fileName),
                                                       TextFileFlags.None,
                                                       FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly,
                                                       Environment.NewLine,
                                                       ",",
                                                       "");
                    MessageBox.Show("�f�X�N�g�b�v�փG�N�X�|�[�g���܂���", "���b�Z�[�W", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ToolStripMenuItemToukaiCSV.Enabled = false;

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
        /// H_LicenseList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LicenseList_FormClosing(object sender, FormClosingEventArgs e) {
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
