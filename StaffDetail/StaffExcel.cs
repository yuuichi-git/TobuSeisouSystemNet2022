using Common;

using Dao;

using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

using Vo;

namespace StaffDetail {
    public partial class StaffExcel : Form {
        private InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        private SetMasterDao _setMasterDao;
        private StaffMasterDao _staffMasterDao;
        private StaffExcelDao _staffExcelDao;
        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<StaffMasterExcelVo> _listStaffMasterExcel1Vo;
        private List<StaffMasterExcelVo> _listStaffMasterExcel2Vo;
        private List<VehicleDispatchDetailVo> _listVehicleDispatchDetailVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public StaffExcel(ConnectionVo connectionVo) {
            _setMasterDao = new(connectionVo);
            _staffMasterDao = new(connectionVo);
            _staffExcelDao = new(connectionVo);
            _listSetMasterVo = _setMasterDao.SelectAllSetMaster();
            _listStaffMasterVo = _staffMasterDao.SelectAllStaffMaster();
            _listStaffMasterExcel1Vo = _staffExcelDao.SelectStaffMasterExcel1();
            _listStaffMasterExcel2Vo = _staffExcelDao.SelectStaffMasterExcel2();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.StaffExcel(this);
            MonthPicker1.Value = DateTime.Now.Date;

            InitializeSheet1();
            InitializeSheet2();
            SetDisplayName1();
            SetDisplayName2();
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            switch(SpreadList.ActiveSheetIndex) {
                case 0:
                    SetData1();
                    break;
                case 1:
                    SetData2();
                    break;
            }

        }

        /// <summary>
        /// InitializeSheet1
        /// アルバイトの出勤状況　シート初期化
        /// </summary>
        private void InitializeSheet1() {
            // ヘッダセルをハイライト表示しない
            SpreadList.PaintSelectionHeader = false;
            /*
             * ColumnHeaderを初期化する
             */
            for(int i = 0; i < 31; i++)
                SheetViewList1.ColumnHeader.Columns[3 + i].Label = "-";
            /*
             * ColumnHeaderを設定
             */
            DateTime toDay = MonthPicker1.Value.Date;
            for(int i = 0; i < DateTime.DaysInMonth(toDay.Year, toDay.Month); i++) {
                DateTime date = new DateTime(toDay.Year, toDay.Month, i + 1);
                SheetViewList1.ColumnHeader.Columns[3 + i].Label = string.Concat(date.ToString("d日(ddd)"));
            }
            /*
             * ComboBoxの設定
             */
            int roopCounter = 0;
            string[] _arrayString = new string[_listStaffMasterVo.Count];
            foreach(var staffMasterVo in _listStaffMasterVo) {
                _arrayString[roopCounter] = staffMasterVo.Display_name;
                roopCounter++;
            }

            ComboBoxCellType comboBoxCellType;
            comboBoxCellType = (ComboBoxCellType)SheetViewList1.GetCellType(0, 1);
            comboBoxCellType.Items = null;
            comboBoxCellType.Items = _arrayString;

            // TabStripのFontを設定
            SpreadList.TabStrip[0].Font = new Font("Yu Gothic UI", 10);

        }

        /// <summary>
        /// InitializeSheet2
        /// </summary>
        private void InitializeSheet2() {
            // ヘッダセルをハイライト表示しない
            SpreadList.PaintSelectionHeader = false;
            /*
             * ColumnHeaderを初期化する
             */
            for(int i = 0; i < 31; i++)
                SheetViewList2.ColumnHeader.Columns[3 + i].Label = "-";
            /*
             * ColumnHeaderを設定
             */
            DateTime toDay = MonthPicker1.Value.Date;
            for(int i = 0; i < DateTime.DaysInMonth(toDay.Year, toDay.Month); i++) {
                DateTime date = new DateTime(toDay.Year, toDay.Month, i + 1);
                SheetViewList2.ColumnHeader.Columns[3 + i].Label = string.Concat(date.ToString("d日(ddd)"));
            }
            /*
             * ComboBoxの設定
             */
            int roopCounter = 0;
            string[] _arrayString = new string[_listStaffMasterVo.Count];
            foreach(var staffMasterVo in _listStaffMasterVo) {
                _arrayString[roopCounter] = staffMasterVo.Display_name;
                roopCounter++;
            }

            ComboBoxCellType comboBoxCellType;
            comboBoxCellType = (ComboBoxCellType)SheetViewList2.GetCellType(0, 1);
            comboBoxCellType.Items = null;
            comboBoxCellType.Items = _arrayString;

            // TabStripのFontを設定
            SpreadList.TabStrip[1].Font = new Font("Yu Gothic UI", 10);

        }

        /// <summary>
        /// SetDisplayName1
        /// </summary>
        private void SetDisplayName1() {
            foreach(StaffMasterExcelVo staffMasterExcelVo in _listStaffMasterExcel1Vo) {
                SheetViewList1.Rows[staffMasterExcelVo.Row].Resizable = false;
                SheetViewList1.Cells[staffMasterExcelVo.Row, 0].Font = new Font("Yu Gothic UI", 9);
                SheetViewList1.Cells[staffMasterExcelVo.Row, 0].Value = staffMasterExcelVo.Code;
                SheetViewList1.Cells[staffMasterExcelVo.Row, 1].Font = new Font("Yu Gothic UI", 9);
                SheetViewList1.Cells[staffMasterExcelVo.Row, 1].Value = staffMasterExcelVo.Display_name;
            }
        }

        /// <summary>
        /// SetDisplayName2
        /// </summary>
        private void SetDisplayName2() {
            foreach(StaffMasterExcelVo staffMasterExcelVo in _listStaffMasterExcel2Vo) {
                SheetViewList2.Rows[staffMasterExcelVo.Row].Resizable = false;
                SheetViewList2.Cells[staffMasterExcelVo.Row, 0].Font = new Font("Yu Gothic UI", 9);
                SheetViewList2.Cells[staffMasterExcelVo.Row, 0].Value = staffMasterExcelVo.Code;
                SheetViewList2.Cells[staffMasterExcelVo.Row, 1].Font = new Font("Yu Gothic UI", 9);
                SheetViewList2.Cells[staffMasterExcelVo.Row, 1].Value = staffMasterExcelVo.Display_name;
            }
        }

        /// <summary>
        /// SetData1
        /// </summary>
        private void SetData1() {
            // 指定範囲のデータをクリア
            SheetViewList1.ClearRange(0, 3, 50, 34, true);

            DateTime targetDate = MonthPicker1.Value.Date;
            _listVehicleDispatchDetailVo = _staffExcelDao.SelectAllVehicleDispatchDetailVo(targetDate);

            for(int row = 0; row < 50; row++) {
                if(SheetViewList1.Cells[row, 0].Text.Length > 0) { // 従事者コードの有無を調べる
                    int operationCode = (int)SheetViewList1.Cells[row, 0].Value;
                    for(int column = 0; column < DateTime.DaysInMonth(targetDate.Year, targetDate.Month); column++) {
                        // 検索用の日付を作成
                        DateTime operationDate = new DateTime(targetDate.Year, targetDate.Month, column + 1);
                        var vehicleDispatchDetailVo = _listVehicleDispatchDetailVo.Find(x => (x.Operator_code_1 == operationCode ||
                                                                                              x.Operator_code_2 == operationCode ||
                                                                                              x.Operator_code_3 == operationCode ||
                                                                                              x.Operator_code_4 == operationCode) &&
                                                                                              x.Operation_date == operationDate);
                        if(vehicleDispatchDetailVo != null) {
                            string setName = vehicleDispatchDetailVo.Set_code != 0 ? _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name : "未登録";
                            SheetViewList1.Cells[row, column + 3].Font = new Font("Yu Gothic UI", 9);
                            SheetViewList1.Cells[row, column + 3].Value = string.Concat((vehicleDispatchDetailVo.Operator_code_1 == operationCode) ? "【運】" : "【作】", setName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// SetData2
        /// </summary>
        private void SetData2() {
            // 指定範囲のデータをクリア
            SheetViewList2.ClearRange(0, 3, 50, 34, true);

            DateTime targetDate = MonthPicker1.Value.Date;
            _listVehicleDispatchDetailVo = _staffExcelDao.SelectAllVehicleDispatchDetailVo(targetDate);

            for(int row = 0; row < 50; row++) {
                if(SheetViewList2.Cells[row, 0].Text.Length > 0) { // 従事者コードの有無を調べる
                    int operationCode = (int)SheetViewList2.Cells[row, 0].Value;
                    for(int column = 0; column < DateTime.DaysInMonth(targetDate.Year, targetDate.Month); column++) {
                        // 検索用の日付を作成
                        DateTime operationDate = new DateTime(targetDate.Year, targetDate.Month, column + 1);
                        var vehicleDispatchDetailVo = _listVehicleDispatchDetailVo.Find(x => (x.Operator_code_1 == operationCode ||
                                                                                              x.Operator_code_2 == operationCode ||
                                                                                              x.Operator_code_3 == operationCode ||
                                                                                              x.Operator_code_4 == operationCode) &&
                                                                                              x.Operation_date == operationDate);
                        if(vehicleDispatchDetailVo != null) {
                            string setName = vehicleDispatchDetailVo.Set_code != 0 ? _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name : "未登録";
                            SheetViewList2.Cells[row, column + 3].Font = new Font("Yu Gothic UI", 9);
                            SheetViewList2.Cells[row, column + 3].Value = string.Concat((vehicleDispatchDetailVo.Operator_code_1 == operationCode) ? "【運】" : "【作】", setName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// SpreadList_ComboCloseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_ComboCloseUp(object sender, EditorNotifyEventArgs e) {
            FpCombo fpCombo = (FpCombo)e.EditingControl;
            SheetView sheetView = ((FpSpread)sender).ActiveSheet;
            StaffMasterVo staffMasterVo = _listStaffMasterVo.Find(x => x.Display_name == fpCombo.SelectedText);
            if(staffMasterVo != null) {
                sheetView.Cells[e.Row, e.Column - 1].Font = new Font("Yu Gothic UI", 9);
                sheetView.Cells[e.Row, e.Column - 1].Value = staffMasterVo.Staff_code;
            }


            /*
             * データベース操作
             */
            StaffMasterExcelVo staffMasterExcelVo = new();
            staffMasterExcelVo.Row = e.Row;
            staffMasterExcelVo.Code = staffMasterVo.Staff_code;
            staffMasterExcelVo.Display_name = fpCombo.SelectedText;
            switch(SpreadList.ActiveSheetIndex) {
                case 0: // アルバイトの出勤日数
                    if(_staffExcelDao.CheckStaffMasterExcel1(e.Row)) {
                        _staffExcelDao.UpdateStaffMasterExcel1(staffMasterExcelVo);
                    } else {
                        _staffExcelDao.InsertStaffMasterExcel1(staffMasterExcelVo);
                    }
                    break;
                case 1: // スペア配車先一覧表
                    if(_staffExcelDao.CheckStaffMasterExcel2(e.Row)) {
                        _staffExcelDao.UpdateStaffMasterExcel2(staffMasterExcelVo);
                    } else {
                        _staffExcelDao.InsertStaffMasterExcel2(staffMasterExcelVo);
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
        /// StaffExcel_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffExcel_FormClosing(object sender, FormClosingEventArgs e) {
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