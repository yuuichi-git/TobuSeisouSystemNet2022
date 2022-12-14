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
         * SPREADÌColumnÌÔ
         */
        /// <summary>
        /// Ô¼R[h
        /// </summary>
        private const int colCarCode = 0;
        /// <summary>
        /// ©®Ôo^Ô1
        /// </summary>
        private const int colRegistrationNumber1 = 1;
        /// <summary>
        /// ©®Ôo^Ô2(4Ìª)
        /// </summary>
        private const int colRegistrationNumber2 = 2;
        /// <summary>
        /// DoorÔ
        /// </summary>
        private const int colDoorNumber = 3;
        /// <summary>
        /// æª(ÙãEæ_EêÊ)
        /// </summary>
        private const int colClassificationName = 4;
        /// <summary>
        /// ÔÉn
        /// </summary>
        private const int colGarageFlag = 5;
        /// <summary>
        /// ¼Ì(zÔpl)
        /// </summary>
        private const int colDisguiseKind_1 = 6;
        /// <summary>
        /// ¼Ì(Ìñ)
        /// </summary>
        private const int colDisguiseKind_2 = 7;
        /// <summary>
        /// ¼Ì(®õ)
        /// </summary>
        private const int colDisguiseKind_3 = 8;
        /// <summary>
        /// o^Nú
        /// </summary>
        private const int colRegistrationDate = 9;
        /// <summary>
        /// Nxo^N
        /// </summary>
        private const int colFirstRegistrationDate = 10;
        /// <summary>
        /// ©®ÔÌíÞ
        /// </summary>
        private const int colCarKindName = 11;
        /// <summary>
        /// pr
        /// </summary>
        private const int colCarUse = 12;
        /// <summary>
        /// ©ÆpEÆpÌÊ
        /// </summary>
        private const int colOtherCode = 13;
        /// <summary>
        /// ÔÌÌ`ó
        /// </summary>
        private const int colShapeName = 14;
        /// <summary>
        /// LøúÀÌ¹·éú
        /// </summary>
        private const int colExpirationDate = 15;
        /// <summary>
        /// õl
        /// </summary>
        private const int colRemarks = 16;

        public CarList(ConnectionVo connectionVo) {
            /*
             * Rg[ú»
             */
            InitializeComponent();
            _initializeForm.CarList(this);

            _connectionVo = connectionVo;
            // íÏÌR[hà\¦·é
            CheckBoxDeleteFlag.Checked = false;
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// Gg[|Cg
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
            // íÏÌR[hà\¦
            if (CheckBoxDeleteFlag.Checked) {
                _listFindAllCarMasterVo = _listCarMasterVo;
            } else {
                _listFindAllCarMasterVo = _listCarMasterVo.FindAll(x => x.Delete_flag == false);
            }
            // Sort
            _linqCarMasterVo = _listFindAllCarMasterVo.OrderBy(x => x.Door_number);
            // ñ«»
            SpreadList.SuspendLayout();
            // æªsiñjCfbNXðæ¾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowðí·é
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            int i = 0;
            foreach (var carMasterVo in _linqCarMasterVo) {
                SheetViewList.Rows.Add(i, 1);
                SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowwb_
                SheetViewList.Rows[i].Height = 22; // RowÌ³
                SheetViewList.Rows[i].Resizable = false; // RowÌResizableðÖ~
                SheetViewList.Rows[i].ForeColor = !carMasterVo.Delete_flag ? Color.Black : Color.Red; // íÏR[hÍÔFÅ\¦·é

                SheetViewList.Cells[i, colCarCode].Value = carMasterVo.Car_code;
                SheetViewList.Cells[i, colRegistrationNumber1].Text = string.Concat(carMasterVo.Registration_number_1, carMasterVo.Registration_number_2, carMasterVo.Registration_number_3);
                SheetViewList.Cells[i, colRegistrationNumber2].Text = carMasterVo.Registration_number_4.ToString();
                SheetViewList.Cells[i, colDoorNumber].Text = carMasterVo.Door_number.ToString("###");
                SheetViewList.Cells[i, colClassificationName].Text = carMasterVo.Classification_name;
                SheetViewList.Cells[i, colGarageFlag].Text = carMasterVo.Garage_flag ? "{Ð" : "O½";
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

            // æªsiñjCfbNXðZbg
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // «»
            SpreadList.ResumeLayout();
            ToolStripStatusLabelStatus.Text = string.Concat(" ", i, " ");

        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // wb_[ÌDoubleClickðñð
            if (e.Row < 0)
                return;
            // Shiftª³ê½ê
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                var carPaper = new CarPaper(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
                carPaper.ShowDialog();
                return;
            }
            // CüL[ª³¢ê
            var carDetail = new CarDetail(_connectionVo, (int)SheetViewList.Cells[e.Row, colCarCode].Value);
            carDetail.ShowDialog();
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns></returns>
        private SheetView InitializeSheetViewList(SheetView sheetView) {
            SpreadList.AllowDragDrop = false; // DrugDropðÖ~·é
            SpreadList.PaintSelectionHeader = false; // wb_ÌIðóÔðµÈ¢
            SpreadList.TabStripPolicy = TabStripPolicy.Never; // V[g^uðñ\¦
            sheetView.AlternatingRows.Count = 2; // sX^CðQsPÊÆµÜ·
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1sÚÌwiFðÝèµÜ·
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2sÚÌwiFðÝèµÜ·
            sheetView.ColumnHeader.Rows[0].Height = 30; // Columnwb_Ì³
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("CI", 10); // swb_ÌFont
            sheetView.RowHeader.Columns[0].Width = 50; // swb_ÌðÏXµÜ·
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
             * SheetViewÉRowª³¢êâARowªIð³êÄ¢È¢êÍReturn·é
             */
            if (SheetViewList.RowCount < 1 || !SheetViewList.IsBlockSelected) {
                e.Cancel = true;
                return;
            }

            var spreadList = (FpSpread)((ContextMenuStrip)sender).SourceControl;
            var cellRange = spreadList.ActiveSheet.GetSelections();

            // íj[ð\¦Eñ\¦
            if (cellRange[0].RowCount == 1) {
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
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemInsertNewCar":
                    var carDetail = new CarDetail(_connectionVo);
                    carDetail.ShowDialog();
                    break;
                // Ið³êÄ¢éR[hðí·é
                case "ToolStripMenuItemDelete":
                    var dialogResult = MessageBox.Show(MessageText.Message801, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (dialogResult) {
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