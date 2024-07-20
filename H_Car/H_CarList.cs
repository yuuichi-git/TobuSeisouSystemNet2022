/*
 * 2024-03-27
 */
using FarPoint.Win.Spread;

using H_Common;

using H_Dao;

using Vo;

namespace H_Car {
    public partial class HCarList : Form {
        /// <summary>
        /// 10:�ُ� 11:��_ 12:�Վ� 20:���|�H�� 30:�Г� 50:��� 51:�Зp�� 99:�w��Ȃ�
        /// </summary>
        private readonly Dictionary<int, string> dictionaryClassificationName = new Dictionary<int, string> { { 10, "�ُ�" }, { 11, "��_" }, { 12, "�Վ�" }, { 20, "���|�H��" }, { 30, "�Г�" }, { 50, "���" }, { 51, "�Зp��" }, { 99, "�w��Ȃ�" } };
        /// <summary>
        /// 0:�Y���Ȃ� 1:���� 2:�O�� 3:�Y�p�Ԍ�
        /// </summary>
        private readonly Dictionary<int, string> dictionaryGarageName = new Dictionary<int, string> { { 0, "�Y���Ȃ�" }, { 1, "�{��" }, { 2, "�O��" }, { 3, "�Y�p�Ԍ�" } };
        /// <summary>
        /// 10:�y������ 11:���^ 12:����
        /// </summary>
        private readonly Dictionary<int, string> dictionaryCarKindName = new Dictionary<int, string> { { 10, "�y������" }, { 11, "���^" }, { 12, "����" } };
        /// <summary>
        /// 10:���Ɨp 11:���Ɨp
        /// </summary>
        private readonly Dictionary<int, string> dictionaryOtherName = new Dictionary<int, string> { { 10, "���Ɨp" }, { 11, "���Ɨp" } };
        /// <summary>
        /// 10:�L���u�I�[�o�[ 11:�o�H�� 12:�_���v 13:�R���e�i��p 14:�E�����u�t�R���e�i��p�� 15:�����̉^���� 16:���A�� 17:���|��
        /// </summary>
        private readonly Dictionary<int, string> dictionaryShapeName = new Dictionary<int, string> { { 10, "�L���u�I�[�o�[" }, { 11, "�o�H��" }, { 12, "�_���v" }, { 13, "�R���e�i��p" }, { 14, "�E�����u�t�R���e�i��p��" }, { 15, "�����̉^����" }, { 16, "���A��" }, { 17, "���|��" } };
        /*
         * SPREAD��Column�̔ԍ�
         */
        /// <summary>
        /// �ԗ��R�[�h
        /// </summary>
        private const int _colCarCode = 0;
        /// <summary>
        /// �����ԓo�^�ԍ�1
        /// </summary>
        private const int _colRegistrationNumber1 = 1;
        /// <summary>
        /// �����ԓo�^�ԍ�2(4���̐�������)
        /// </summary>
        private const int _colRegistrationNumber2 = 2;
        /// <summary>
        /// Door�ԍ�
        /// </summary>
        private const int _colDoorNumber = 3;
        /// <summary>
        /// �敪(�ُ�E��_�E���)
        /// </summary>
        private const int _colClassificationName = 4;
        /// <summary>
        /// �Ԍɒn
        /// </summary>
        private const int _colGarageName = 5;
        /// <summary>
        /// ����(�z�ԃp�l��)
        /// </summary>
        private const int _colDisguiseKind_1 = 6;
        /// <summary>
        /// ����(���̕񍐏�)
        /// </summary>
        private const int _colDisguiseKind_2 = 7;
        /// <summary>
        /// ����(����)
        /// </summary>
        private const int _colDisguiseKind_3 = 8;
        /// <summary>
        /// �o�^�N����
        /// </summary>
        private const int _colRegistrationDate = 9;
        /// <summary>
        /// ���N�x�o�^�N��
        /// </summary>
        private const int _colFirstRegistrationDate = 10;
        /// <summary>
        /// �����Ԃ̎��
        /// </summary>
        private const int _colCarKindName = 11;
        /// <summary>
        /// �p�r
        /// </summary>
        private const int _colCarUse = 12;
        /// <summary>
        /// ���Ɨp�E���Ɨp�̕�
        /// </summary>
        private const int _colOtherCode = 13;
        /// <summary>
        /// �ԑ̂̌`��
        /// </summary>
        private const int _colShapeName = 14;
        /// <summary>
        /// �L�������̖��������
        /// </summary>
        private const int _colExpirationDate = 15;
        /// <summary>
        /// ���l
        /// </summary>
        private const int _colRemarks = 16;
        /*
         * Dao
         */
        private readonly H_CarMasterDao _hCarMasterDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public HCarList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hCarMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            InitializeComponent();
            ToolStripMenuItemDeleted.Checked = false;
            this.InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.PutSheetViewList();
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// PutSheetViewList
        /// </summary>
        private void PutSheetViewList() {
            List<H_CarMasterVo> _listHCarMasterVo = new();
            // �폜�ς̃��R�[�h���\��
            if (ToolStripMenuItemDeleted.Checked) {
                _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            } else {
                _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster().FindAll(x => x.DeleteFlag == false);
            }
            // �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach (H_CarMasterVo hCarMasterVo in _listHCarMasterVo.OrderBy(x => x.RegistrationNumber4)) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~
                SheetViewList.Rows[i].ForeColor = !hCarMasterVo.DeleteFlag ? Color.Black : Color.Red; // �폜�σ��R�[�h�͐ԐF�ŕ\������

                SheetViewList.Cells[i, _colCarCode].Value = hCarMasterVo.CarCode;
                SheetViewList.Cells[i, _colRegistrationNumber1].Text = string.Concat(hCarMasterVo.RegistrationNumber1, hCarMasterVo.RegistrationNumber2, hCarMasterVo.RegistrationNumber3);
                SheetViewList.Cells[i, _colRegistrationNumber2].Text = hCarMasterVo.RegistrationNumber4.ToString();
                SheetViewList.Cells[i, _colDoorNumber].Text = hCarMasterVo.DoorNumber.ToString("###");
                SheetViewList.Cells[i, _colClassificationName].Text = dictionaryClassificationName[hCarMasterVo.ClassificationCode];
                SheetViewList.Cells[i, _colGarageName].Text = dictionaryGarageName[hCarMasterVo.GarageCode];
                SheetViewList.Cells[i, _colDisguiseKind_1].Text = hCarMasterVo.DisguiseKind1;
                SheetViewList.Cells[i, _colDisguiseKind_2].Text = hCarMasterVo.DisguiseKind2;
                SheetViewList.Cells[i, _colDisguiseKind_3].Text = hCarMasterVo.DisguiseKind3;
                SheetViewList.Cells[i, _colRegistrationDate].Value = hCarMasterVo.RegistrationDate.Date;
                SheetViewList.Cells[i, _colFirstRegistrationDate].Value = hCarMasterVo.FirstRegistrationDate.Date;
                SheetViewList.Cells[i, _colCarKindName].Text = dictionaryCarKindName[hCarMasterVo.CarKindCode];
                SheetViewList.Cells[i, _colCarUse].Text = hCarMasterVo.CarUse;
                SheetViewList.Cells[i, _colOtherCode].Text = dictionaryOtherName[hCarMasterVo.OtherCode];
                SheetViewList.Cells[i, _colShapeName].Text = dictionaryShapeName[hCarMasterVo.ShapeCode];
                SheetViewList.Cells[i, _colExpirationDate].ForeColor = hCarMasterVo.ExpirationDate.Date < DateTime.Now.Date ? Color.Red : Color.Black;
                SheetViewList.Cells[i, _colExpirationDate].Value = hCarMasterVo.ExpirationDate.Date;
                SheetViewList.Cells[i, _colRemarks].Text = hCarMasterVo.Remarks;
                i++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " ��");

        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * �V�K�ԗ����쐬����
                 */
                case "ToolStripMenuItemNewCar":
                    HCarDetail hCarDetail = new(_connectionVo);
                    new Desktop().SetPosition(hCarDetail, _connectionVo.Screen);
                    hCarDetail.KeyPreview = true;
                    hCarDetail.ShowDialog(this);
                    break;
                case "ToolStripMenuItemDelete":
                    DialogResult dialogResult = MessageBox.Show("�I������Ă���ԗ����폜���܂��B��낵���ł����H", "���b�Z�[�W", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
                        case DialogResult.OK:
                            var carCode = (int)SheetViewList.Cells[SheetViewList.ActiveRowIndex, _colCarCode].Value;
                            _hCarMasterDao.DeleteOneHCarMaster(carCode);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
                /*
                 * �A�v���P�[�V�������I������
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
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
            // Shift�������ꂽ�ꍇ
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                //var carPaper = new CarPaper(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
                //carPaper.ShowDialog();
                return;
            }
            // �C���L�[�������ꍇ
            HCarDetail hCarDetail = new(_connectionVo, (int)SheetViewList.Cells[e.Row, _colCarCode].Value);
            new Desktop().SetPosition(hCarDetail, _connectionVo.Screen);
            hCarDetail.KeyPreview = true;
            hCarDetail.ShowDialog(this);
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
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // �s�w�b�_��Font
            sheetView.RowHeader.Columns[0].Width = 50; // �s�w�b�_�̕���ύX���܂�
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// HCarList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCarList_FormClosing(object sender, FormClosingEventArgs e) {
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
