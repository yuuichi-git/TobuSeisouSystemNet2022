using CarRegister;

using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Car {
    public partial class CarList : Form {
        private InitializeForm _initializeForm = new();
        private readonly ConnectionVo _connectionVo;
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<CarMasterVo> _listFindAllCarMasterVo = new();
        private IOrderedEnumerable<CarMasterVo> _linqCarMasterVo;

        /*
         * SPREAD��Column�̔ԍ�
         */
        /// <summary>
        /// �ԗ��R�[�h
        /// </summary>
        private const int colCarCode = 0;
        /// <summary>
        /// �����ԓo�^�ԍ�1
        /// </summary>
        private const int colRegistrationNumber1 = 1;
        /// <summary>
        /// �����ԓo�^�ԍ�2(4���̐�������)
        /// </summary>
        private const int colRegistrationNumber2 = 2;
        /// <summary>
        /// Door�ԍ�
        /// </summary>
        private const int colDoorNumber = 3;
        /// <summary>
        /// �敪(�ُ�E��_�E���)
        /// </summary>
        private const int colClassificationName = 4;
        /// <summary>
        /// �Ԍɒn
        /// </summary>
        private const int colGarageFlag = 5;
        /// <summary>
        /// ����(�z�ԃp�l��)
        /// </summary>
        private const int colDisguiseKind_1 = 6;
        /// <summary>
        /// ����(���̕񍐏�)
        /// </summary>
        private const int colDisguiseKind_2 = 7;
        /// <summary>
        /// ����(����)
        /// </summary>
        private const int colDisguiseKind_3 = 8;
        /// <summary>
        /// �o�^�N����
        /// </summary>
        private const int colRegistrationDate = 9;
        /// <summary>
        /// ���N�x�o�^�N��
        /// </summary>
        private const int colFirstRegistrationDate = 10;
        /// <summary>
        /// �����Ԃ̎��
        /// </summary>
        private const int colCarKindName = 11;
        /// <summary>
        /// �p�r
        /// </summary>
        private const int colCarUse = 12;
        /// <summary>
        /// ���Ɨp�E���Ɨp�̕�
        /// </summary>
        private const int colOtherCode = 13;
        /// <summary>
        /// �ԑ̂̌`��
        /// </summary>
        private const int colShapeName = 14;
        /// <summary>
        /// �L�������̖��������
        /// </summary>
        private const int colExpirationDate = 15;
        /// <summary>
        /// ���l
        /// </summary>
        private const int colRemarks = 16;

        public CarList(ConnectionVo connectionVo) {
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.CarList(this);

            _connectionVo = connectionVo;
            // �폜�ς̃��R�[�h���\������
            CheckBoxDeleteFlag.Checked = false;
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelStatus.Text = "";
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
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            SheetViewListOutPut();
        }

        int spreadListTopRow = 0;
        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        private void SheetViewListOutPut() {
            // �폜�ς̃��R�[�h���\��
            if(CheckBoxDeleteFlag.Checked) {
                _listFindAllCarMasterVo = _listCarMasterVo;
            } else {
                _listFindAllCarMasterVo = _listCarMasterVo.FindAll(x => x.Delete_flag == false);
            }
            // Sort
            _linqCarMasterVo = _listFindAllCarMasterVo.OrderBy(x => x.Door_number);
            // �񊈐���
            SpreadList.SuspendLayout();
            // �擪�s�i��j�C���f�b�N�X���擾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Row���폜����
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach(var carMasterVo in _linqCarMasterVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Row�w�b�_
                SheetViewList.Rows[i].Height = 22; // Row�̍���
                SheetViewList.Rows[i].Resizable = false; // Row��Resizable���֎~
                SheetViewList.Rows[i].ForeColor = !carMasterVo.Delete_flag ? Color.Black : Color.Red; // �폜�σ��R�[�h�͐ԐF�ŕ\������

                SheetViewList.Cells[i, colCarCode].Value = carMasterVo.Car_code;
                SheetViewList.Cells[i, colRegistrationNumber1].Text = string.Concat(carMasterVo.Registration_number_1, carMasterVo.Registration_number_2, carMasterVo.Registration_number_3);
                SheetViewList.Cells[i, colRegistrationNumber2].Text = carMasterVo.Registration_number_4.ToString();
                SheetViewList.Cells[i, colDoorNumber].Text = carMasterVo.Door_number.ToString("###");
                SheetViewList.Cells[i, colClassificationName].Text = carMasterVo.Classification_name;
                SheetViewList.Cells[i, colGarageFlag].Text = carMasterVo.Garage_flag ? "�{��" : "�O��";
                SheetViewList.Cells[i, colDisguiseKind_1].Text = carMasterVo.Disguise_kind_1;
                SheetViewList.Cells[i, colDisguiseKind_2].Text = carMasterVo.Disguise_kind_2;
                SheetViewList.Cells[i, colDisguiseKind_3].Text = carMasterVo.Disguise_kind_3;
                SheetViewList.Cells[i, colRegistrationDate].Value = carMasterVo.Registration_date.Date;
                SheetViewList.Cells[i, colFirstRegistrationDate].Value = carMasterVo.First_registration_date.Date;
                SheetViewList.Cells[i, colCarKindName].Text = carMasterVo.Car_kind_name;
                SheetViewList.Cells[i, colCarUse].Text = carMasterVo.Car_use;
                SheetViewList.Cells[i, colOtherCode].Text = carMasterVo.Other_name;
                SheetViewList.Cells[i, colShapeName].Text = carMasterVo.Shape_name;
                SheetViewList.Cells[i, colExpirationDate].ForeColor = carMasterVo.Expiration_date.Date < DateTime.Now.Date ? Color.Red : Color.Black;
                SheetViewList.Cells[i, colExpirationDate].Value = carMasterVo.Expiration_date.Date;
                SheetViewList.Cells[i, colRemarks].Text = carMasterVo.Remarks;
                i++;
            }

            // �擪�s�i��j�C���f�b�N�X���Z�b�g
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // ������
            SpreadList.ResumeLayout();
            ToolStripStatusLabelStatus.Text = string.Concat(" ", i, " ��");

        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // �w�b�_�[��DoubleClick�����
            if(e.Row < 0)
                return;
            // Shift�������ꂽ�ꍇ
            if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                var carPaper = new CarPaper(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
                carPaper.ShowDialog();
                return;
            }
            // �C���L�[�������ꍇ
            var carDetail = new CarDetail(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
            carDetail.ShowDialog();
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
        /// ContextMenuStrip1_Opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            /*
             * SheetView��Row�������ꍇ��ARow���I������Ă��Ȃ��ꍇ��Return����
             */
            if(SheetViewList.RowCount < 1 || !SheetViewList.IsBlockSelected) {
                e.Cancel = true;
                return;
            }

            var spreadList = (FpSpread)((ContextMenuStrip)sender).SourceControl;
            var cellRange = spreadList.ActiveSheet.GetSelections();

            // �폜���j���[��\���E��\��
            if(cellRange[0].RowCount == 1) {
                ContextMenuStrip1.Enabled = true;
            } else {
                ContextMenuStrip1.Enabled = false;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemInsertNewCar":
                    var carDetail = new CarDetail(_connectionVo);
                    carDetail.ShowDialog();
                    break;
                // �I������Ă��郌�R�[�h���폜����
                case "ToolStripMenuItemDelete":
                    var dialogResult = MessageBox.Show(MessageText.Message801, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch(dialogResult) {
                        case DialogResult.OK:
                            var carCode = (int)SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCarCode].Value;
                            new CarMasterDao(_connectionVo).UpdateOneCarMaster(carCode);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
            }
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
        /// CarList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarList_FormClosing(object sender, FormClosingEventArgs e) {
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