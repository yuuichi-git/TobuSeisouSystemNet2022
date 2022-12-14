using System.ComponentModel;

using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using License;

using Vo;

namespace Staff {
    public partial class StaffList : Form {
        private readonly ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();
        private List<ExtendsStaffMasterVo>? _listExtendsStaffMasterVo;
        private List<ExtendsStaffMasterVo>? _listFindAllStaffMasterVo;
        private List<ExtendsStaffMasterVo>? _listFindAllStaffMasterVo1;
        private List<ExtendsStaffMasterVo>? _listFindAllStaffMasterVo2;
        private List<ExtendsStaffMasterVo>? _listFindAllStaffMasterVo3;
        private IOrderedEnumerable<ExtendsStaffMasterVo>? _linqExtendsStaffMasterVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        private readonly Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "ðõ" }, { 11, "Ðõ" }, { 12, "AoCg" }, { 13, "h­" }, { 20, "V^]" }, { 21, "©^J" } };
        private readonly Dictionary<int, string> dictionaryJobForm = new Dictionary<int, string> { { 10, "·úÙp" }, { 11, "è " }, { 12, "AoCg" }, { 99, "" } };
        private readonly Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "^]è" }, { 11, "ìÆõ" }, { 99, "" } };

        // SPREADÌColumnÌÔ
        /// <summary>
        /// ®
        /// </summary>
        private const int colBelongs = 0;
        /// <summary>
        /// `Ô
        /// </summary>
        private const int colJobForm = 1;
        /// <summary>
        /// Eí
        /// </summary>
        private const int colOccupation = 2;
        /// <summary>
        /// zÔÌÎÛ©Ç¤©
        /// </summary>
        private const int colVehicleDispatchTarget = 3;
        /// <summary>
        /// <summary>
        /// ÐõCD
        /// </summary>
        private const int colCode = 4;
        /// <summary>
        /// ¼
        /// </summary>
        private const int colName = 5;
        /// <summary>
        /// Ji
        /// </summary>
        private const int colNameKana = 6;
        /// <summary>
        /// ÂÛ
        /// </summary>
        private const int colToukanpoCard = 7;
        /// <summary>
        /// ÆØ
        /// </summary>
        private const int colLicense = 8;
        /// <summary>
        /// ÆØúÀ
        /// </summary>
        private const int colLicensExpirationDate = 9;
        /// <summary>
        /// ÊÎÍ
        /// </summary>
        private const int colCommutingNotification = 10;
        /// <summary>
        /// CÓÛ¯I¹Nú
        /// </summary>
        private const int colMeansOfCommutingEndDate = 11;
        /// <summary>
        /// ¶Nú
        /// </summary>
        private const int colBirthDate = 12;
        /// <summary>
        /// Nî
        /// </summary>
        private const int colFullAge = 13;
        /// <summary>
        /// ÙpNú
        /// </summary>
        private const int colEmploymentDate = 14;
        /// <summary>
        /// Î±N
        /// </summary>
        private const int colServiceDate = 15;
        /// <summary>
        /// C
        /// </summary>
        private const int colFirstTerm = 16;
        /// <summary>
        /// Kî
        /// </summary>
        private const int colSuitableAge = 17;
        /// <summary>
        /// Ì
        /// </summary>
        private const int colCarAccidentCount = 18;
        /// <summary>
        /// PNÈàÌNff
        /// </summary>
        private const int colMedicalExaminationDate = 19;
        /// <summary>
        /// »Z
        /// </summary>
        private const int colCurrentAddress = 20;
        /// <summary>
        /// NÛ¯
        /// </summary>
        private const int colHealthInsuranceNumber = 21;
        /// <summary>
        /// ú¶Nà
        /// </summary>
        private const int colWelfarePensionNumber = 22;
        /// <summary>
        /// ÙpÛ¯
        /// </summary>
        private const int colEmploymentInsuranceNumber = 23;
        /// <summary>
        /// JÐÛ¯
        /// </summary>
        private const int colWorkerAccidentInsuranceNumber = 24;

        public StaffList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * Rg[ðú»
             */
            InitializeComponent();
            _initializeForm.StaffList(this);

            _listExtendsStaffMasterVo = null;
            _listFindAllStaffMasterVo = null;
            _linqExtendsStaffMasterVo = null;

            // ÌWvÌîÆÈéNxðú»
            ComboBoxAccidentYear.Text = "2022Nx";
            // FpSpreadðú»
            InitializeSheetViewList(SheetViewList);
            ToolStripStatusLabelDetail.Text = "";
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
            /*
             * SQLððì¬·é
             * SQLðì¬·éÛÉASÄÌ`FbNÚÌ`FbNªOêÄ¢È¢©ðmF·é
             */
            bool check;
            check = false;
            foreach(CheckBox checkBox in GroupBox1.Controls) {
                if(checkBox.Checked)
                    check = true;
            }
            if(!check) {
                MessageBox.Show("ðEÍ®(æêð)ÌSÄÌ`FbNðO·ÍoÜ¹ñ", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            check = false;
            foreach(CheckBox checkBox in GroupBox2.Controls) {
                if(checkBox.Checked)
                    check = true;
            }
            if(!check) {
                MessageBox.Show("Ùp`Ô(æñð)ÌSÄÌ`FbNðO·ÍoÜ¹ñ", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            check = false;
            foreach(CheckBox checkBox in GroupBox3.Controls) {
                if(checkBox.Checked)
                    check = true;
            }
            if(!check) {
                MessageBox.Show("Eí(æOð)ÌSÄÌ`FbNðO·ÍoÜ¹ñ", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _listExtendsStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllExtendsStaffMasterVo(CreateSqlString(GroupBox1), CreateSqlString(GroupBox2), CreateSqlString(GroupBox3));
            SheetViewListOutPut();
        }

        /// <summary>
        /// CreateSqlString
        /// SQL¶ðì¬·é
        /// INæðp·é
        /// </summary>
        /// <param name="groupBox"></param>
        /// <returns></returns>
        private string CreateSqlString(GroupBox groupBox) {
            int i = 0;
            string sql = "";
            foreach(CheckBox checkBox in groupBox.Controls) {
                if(checkBox.Checked) {
                    if(i == 0) {
                        sql += string.Concat(checkBox.Tag.ToString());
                    } else {
                        sql += string.Concat(",", checkBox.Tag.ToString());
                    }
                    i++;
                }
            }
            return sql;
        }

        /// <summary>
        /// TabControlEx1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlEx1_Click(object sender, EventArgs e) {
            if(_listFindAllStaffMasterVo != null)
                SheetViewListOutPut();
        }

        /// <summary>
        /// SheetViewListOutPut
        /// </summary>
        int spreadListTopRow = 0;
        private void SheetViewListOutPut() {
            // Spread ñ«»
            SpreadList.SuspendLayout();
            // æªsiñjCfbNXðæ¾
            spreadListTopRow = SpreadList.GetViewportTopRow(0);
            // Rowðí·é
            if(SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);

            _listFindAllStaffMasterVo = TabControlExStaff.SelectedTab.Tag switch {
                "A" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("A") || x.Name_kana.StartsWith("C") || x.Name_kana.StartsWith("E") || x.Name_kana.StartsWith("G") || x.Name_kana.StartsWith("I")),
                "J" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("J") || x.Name_kana.StartsWith("K") || x.Name_kana.StartsWith("L") || x.Name_kana.StartsWith("M") || x.Name_kana.StartsWith("N") || x.Name_kana.StartsWith("P") || x.Name_kana.StartsWith("R") || x.Name_kana.StartsWith("S")),
                "T" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("T") || x.Name_kana.StartsWith("V") || x.Name_kana.StartsWith("X") || x.Name_kana.StartsWith("Z") || x.Name_kana.StartsWith("\")),
                "^" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("^") || x.Name_kana.StartsWith("`") || x.Name_kana.StartsWith("c") || x.Name_kana.StartsWith("e") || x.Name_kana.StartsWith("f") || x.Name_kana.StartsWith("g") || x.Name_kana.StartsWith("h")),
                "i" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("i") || x.Name_kana.StartsWith("j") || x.Name_kana.StartsWith("k") || x.Name_kana.StartsWith("l") || x.Name_kana.StartsWith("m")),
                "n" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("n") || x.Name_kana.StartsWith("p") || x.Name_kana.StartsWith("q") || x.Name_kana.StartsWith("r") || x.Name_kana.StartsWith("t") || x.Name_kana.StartsWith("u") || x.Name_kana.StartsWith("w") || x.Name_kana.StartsWith("x") || x.Name_kana.StartsWith("z")),
                "}" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("}") || x.Name_kana.StartsWith("~") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("")),
                "" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("")),
                "" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("")),
                "" => _listExtendsStaffMasterVo?.FindAll(x => x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("") || x.Name_kana.StartsWith("")),
                _ => _listExtendsStaffMasterVo,
            };

            // ÞEÒ
            if(!CheckBoxRetired.Checked)
                _listFindAllStaffMasterVo = _listFindAllStaffMasterVo?.FindAll(x => x.Retirement_flag != true);
            // \[g
            _linqExtendsStaffMasterVo = _listFindAllStaffMasterVo?.OrderBy(x => x.Name_kana);

            int i = 0;
            if(_linqExtendsStaffMasterVo is not null)
                foreach(var extendsStaffMasterVo in _linqExtendsStaffMasterVo) {
                    // ®
                    var _belongs = extendsStaffMasterVo.Belongs;
                    // `Ô
                    var _jobForm = extendsStaffMasterVo.Job_form;
                    // Eí
                    var _occupation = extendsStaffMasterVo.Occupation;
                    // zÔÎÛ
                    var _vehicleDispatchTarget = extendsStaffMasterVo.Vehicle_dispatch_target;
                    // gCD
                    var _code = extendsStaffMasterVo.Code;
                    // ¼
                    var _name = extendsStaffMasterVo.Name;
                    // Ji
                    var _name_kana = extendsStaffMasterVo.Name_kana;
                    // ÂÛ
                    var _toukanpoTrainingCardFlag = extendsStaffMasterVo.ToukanpoTrainingCardFlag;
                    // ÆØ
                    bool _licenseLedgerFlag = false;
                    DateTime? _licenseLedgerExpirationDate = null;
                    if(extendsStaffMasterVo?.LicenseNumber?.Length > 0) {
                        // ÆØ
                        _licenseLedgerFlag = true;
                        // ÆØúÀ
                        _licenseLedgerExpirationDate = extendsStaffMasterVo.LicenseMasterExpirationDate.Date;
                    }
                    // ÊÎÍ
                    var _commutingNotificationFlag = extendsStaffMasterVo?.CommutingNotification;
                    // CÓÛ¯I¹Nú
                    DateTime? _meansOfCommutingEndDate = null;
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.CommutingNotification) {
                        if(extendsStaffMasterVo.CommuterInsuranceEndDate.Date != _defaultDateTime.Date)
                            _meansOfCommutingEndDate = extendsStaffMasterVo.CommuterInsuranceEndDate.Date;
                    } else {
                        _meansOfCommutingEndDate = null;
                    }
                    // ¶NúENî
                    DateTime? _birth_date = null;
                    string _age = "";
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.Birth_date != _defaultDateTime) {
                        _birth_date = extendsStaffMasterVo.Birth_date.Date;
                        // Nî
                        _age = string.Concat(new Date().GetStaffAge(extendsStaffMasterVo.Birth_date.Date), "Î");
                    }
                    // ÙpNú
                    DateTime? _employment_date = null;
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.Employment_date != _defaultDateTime) {
                        _employment_date = extendsStaffMasterVo.Employment_date.Date;
                    }
                    // Î±
                    string _service_date = "";
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.Employment_date != _defaultDateTime) {
                        _service_date = string.Concat(new Date().GetEmploymenteYear(extendsStaffMasterVo.Employment_date.Date).ToString("#0N"), new Date().GetEmploymenteMonth(extendsStaffMasterVo.Employment_date.Date).ToString("00"));
                    }
                    // C
                    DateTime? _proper_kind_syonin = null;
                    if(extendsStaffMasterVo?.Proper_kind_1 == "Cff")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_1;
                    if(extendsStaffMasterVo?.Proper_kind_2 == "Cff")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_2;
                    if(extendsStaffMasterVo?.Proper_kind_3 == "Cff")
                        _proper_kind_syonin = extendsStaffMasterVo.Proper_date_3;
                    // Kî
                    string _proper_kind_tekirei = "";
                    var timeSpan = new TimeSpan(0, 0, 0, 0);

                    if(extendsStaffMasterVo is not null && (extendsStaffMasterVo.Proper_kind_1 == "Kîff" || extendsStaffMasterVo.Proper_kind_2 == "Kîff" || extendsStaffMasterVo.Proper_kind_3 == "Kîff")) {
                        if(extendsStaffMasterVo.Proper_kind_1 == "Kîff") {
                            timeSpan = extendsStaffMasterVo.Proper_date_1.AddYears(3) - DateTime.Now.Date;
                        } else if(extendsStaffMasterVo.Proper_kind_2 == "Kîff") {
                            timeSpan = extendsStaffMasterVo.Proper_date_2.AddYears(3) - DateTime.Now.Date;
                        } else if(extendsStaffMasterVo.Proper_kind_3 == "Kîff") {
                            timeSpan = extendsStaffMasterVo.Proper_date_3.AddYears(3) - DateTime.Now.Date;
                        }
                        _proper_kind_tekirei = string.Concat(timeSpan.Days, "úã");
                    }
                    // Ì
                    string _car_accident_count = "";
                    if(extendsStaffMasterVo is not null && extendsStaffMasterVo.CarAccidentMasterCount != 0) {
                        _car_accident_count = string.Concat(extendsStaffMasterVo.CarAccidentMasterCount, "");
                    }
                    /*
                     * PNÈàÌNff
                     */
                    string _medical_examination;
                    if(extendsStaffMasterVo.Medical_examination_date_1 < DateTime.Now.Date.AddYears(-1)) {
                        _medical_examination = "Nffðó¯Äº³¢";
                    } else {
                        _medical_examination = string.Concat("óf(", extendsStaffMasterVo.Medical_examination_date_1.ToString("yyyy/MM/dd"), ")");
                    }

                    // »Z
                    var _current_address = extendsStaffMasterVo?.Current_address;
                    // NÛ¯
                    var _health_insurance_number = extendsStaffMasterVo?.Health_insurance_number != "" ? true : false;
                    // ú¶Nà  
                    var _welfare_pension_number = extendsStaffMasterVo?.Welfare_pension_number != "" ? true : false;
                    // ÙpÛ¯   
                    var _employment_insurance_number = extendsStaffMasterVo?.Employment_insurance_number != "" ? true : false;
                    // JÐÛ¯   
                    var _worker_accident_insurance_number = extendsStaffMasterVo?.Worker_accident_insurance_number != "" ? true : false;

                    SheetViewList.Rows.Add(i, 1);
                    SheetViewList.RowHeader.Columns[0].Label = (i + 1).ToString(); // Rowwb_
                    SheetViewList.Rows[i].ForeColor = extendsStaffMasterVo is not null && extendsStaffMasterVo.Retirement_flag ? Color.Red : Color.Black; // ÞEÏÌR[hÌForeColorðZbg
                    SheetViewList.Rows[i].Height = 22; // RowÌ³
                    SheetViewList.Rows[i].Resizable = false; // RowÌResizableðÖ~
                    SheetViewList.Cells[i, colBelongs].Value = dictionaryBelongs[_belongs];
                    SheetViewList.Cells[i, colJobForm].Value = dictionaryJobForm[_jobForm];
                    SheetViewList.Cells[i, colOccupation].Value = dictionaryOccupation[_occupation];
                    SheetViewList.Cells[i, colVehicleDispatchTarget].Value = _vehicleDispatchTarget;
                    SheetViewList.Cells[i, colCode].Value = _code;
                    SheetViewList.Cells[i, colName].Text = _name;
                    SheetViewList.Cells[i, colName].Tag = extendsStaffMasterVo;
                    SheetViewList.Cells[i, colNameKana].Text = _name_kana;
                    SheetViewList.Cells[i, colToukanpoCard].Value = _toukanpoTrainingCardFlag;
                    SheetViewList.Cells[i, colLicense].Value = _licenseLedgerFlag;
                    SheetViewList.Cells[i, colLicensExpirationDate].Value = _licenseLedgerExpirationDate; // ÆØúÀ
                    SheetViewList.Cells[i, colCommutingNotification].Value = _commutingNotificationFlag; // 2022/05/24 ÊÎÍ
                    SheetViewList.Cells[i, colMeansOfCommutingEndDate].Value = _meansOfCommutingEndDate; // 2022/05/24 CÓÛ¯I¹Nú
                    SheetViewList.Cells[i, colBirthDate].Value = _birth_date;
                    SheetViewList.Cells[i, colFullAge].Value = _age;
                    SheetViewList.Cells[i, colEmploymentDate].Value = _employment_date;
                    SheetViewList.Cells[i, colServiceDate].Value = _service_date;
                    SheetViewList.Cells[i, colFirstTerm].Value = _proper_kind_syonin;
                    SheetViewList.Cells[i, colSuitableAge].Value = _proper_kind_tekirei;
                    SheetViewList.Cells[i, colCarAccidentCount].Value = _car_accident_count;
                    SheetViewList.Cells[i, colMedicalExaminationDate].Value = _medical_examination;
                    SheetViewList.Cells[i, colMedicalExaminationDate].ForeColor = _medical_examination == "Nffðó¯Äº³¢" ? Color.Red : Color.Black;
                    SheetViewList.Cells[i, colCurrentAddress].Value = _current_address;
                    SheetViewList.Cells[i, colHealthInsuranceNumber].Value = _health_insurance_number;
                    SheetViewList.Cells[i, colWelfarePensionNumber].Value = _welfare_pension_number;
                    SheetViewList.Cells[i, colEmploymentInsuranceNumber].Value = _employment_insurance_number;
                    SheetViewList.Cells[i, colWorkerAccidentInsuranceNumber].Value = _worker_accident_insurance_number;
                    i++;
                }
            // æªsiñjCfbNXðZbg
            SpreadList.SetViewportTopRow(0, spreadListTopRow);
            // Spread «»
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", i, " ");
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // wb_[ÌDoubleClickðñð
            if(e.ColumnHeader)
                return;
            // Shiftª³ê½ê
            if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                var staffRegisterPaper = new StaffPaper(_connectionVo, ((ExtendsStaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).Staff_code);
                staffRegisterPaper.ShowDialog();
                return;
            }
            // CüL[ª³¢ê
            var staffRegisterDetail = new StaffDetail(_connectionVo, ((ExtendsStaffMasterVo)SheetViewList.Cells[e.Row, colName].Tag).Staff_code);
            staffRegisterDetail.ShowDialog();
        }

        /// <summary>
        /// ToolStripMenuItemNewStaff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemNewStaff_Click(object sender, EventArgs e) {
            var staffDetail = new StaffDetail(_connectionVo);
            staffDetail.ShowDialog();
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
            sheetView.ColumnHeader.Rows[0].Height = 28; // Columnwb_Ì³
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // swb_ÌFont
            sheetView.RowHeader.Columns[0].Width = 50; // swb_ÌðÏXµÜ·
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// ToolStripMenuItemExcelExport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExcelExport_Click(object sender, EventArgs e) {
            //xlsx`®t@CðGNX|[gµÜ·
            string fileName = string.Concat("]ÒXg", DateTime.Now.ToString("MMddú"), "ì¬");
            SpreadList.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat | ExcelSaveFlags.Exchangeable);
            MessageBox.Show("fXNgbvÖGNX|[gµÜµ½", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ContextMenuStrip1_Opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            /*
             * SheetViewÉRowª³¢êâARowªIð³êÄ¢È¢êÍReturn·é
             */
            if(SheetViewList.RowCount < 1 || !SheetViewList.IsBlockSelected) {
                e.Cancel = true;
                return;
            }

            var spreadList = (FpSpread)((ContextMenuStrip)sender).SourceControl;
            var cellRange = spreadList.ActiveSheet.GetSelections();
            /*
             * ÆØ
             */
            if(cellRange[0].RowCount == 1) {
                var license = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colLicense].Value;
                if((bool)license) {
                    ToolStripMenuItemLicense.Enabled = true;
                } else {
                    ToolStripMenuItemLicense.Enabled = false;
                }
            } else {
                ToolStripMenuItemLicense.Enabled = false;
            }
            /*
             * ÂÛ
             */
            if(cellRange[0].RowCount == 1) {
                var toukanpoCard = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colToukanpoCard].Value;
                if((bool)toukanpoCard) {
                    ToolStripMenuItemToukanpo.Enabled = true;
                } else {
                    ToolStripMenuItemToukanpo.Enabled = false;
                }
            } else {
                ToolStripMenuItemLicense.Enabled = false;
            }
            /*
             * n}ð\¦·é
             */
            if(cellRange[0].RowCount == 1) {
                var currentAddress = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCurrentAddress].Text;
                if(!string.IsNullOrEmpty(currentAddress)) {
                    ToolStripMenuItemMap.Enabled = true;
                } else {
                    ToolStripMenuItemMap.Enabled = false;
                }
            } else {
                ToolStripMenuItemMap.Enabled = false;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                /*
                 * ÆØð\¦
                 */
                case "ToolStripMenuItemLicense":
                    var staffCode = ((ExtendsStaffMasterVo)SheetViewList.Cells[SheetViewList.ActiveRowIndex, colName].Tag).Staff_code;
                    var licenseMasterPicture = new LicenseCard(_connectionVo, staffCode);
                    licenseMasterPicture.ShowDialog();
                    break;
                /*
                 * ÂÛC¹Øð\¦
                 */
                case "ToolStripMenuItemToukanpo":

                    break;
                /*
                 * n}ð\¦
                 */
                case "ToolStripMenuItemMap":
                    var currentAddress = SheetViewList.Cells[SheetViewList.ActiveRowIndex, colCurrentAddress].Text;
                    new Maps().MapOpen(currentAddress);
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
        /// StaffList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffList_FormClosing(object sender, FormClosingEventArgs e) {
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