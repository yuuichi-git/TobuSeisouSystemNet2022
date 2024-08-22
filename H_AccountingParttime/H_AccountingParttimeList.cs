/*
 * 2024-04-13
 */
using H_Dao;

using H_Vo;

using Vo;

namespace H_AccountingParttime {
    public partial class HAccountingParttimeList : Form {
        /*
         * Dao
         */
        private readonly H_SetMasterDao _hSetMasterDao;
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly List<H_SetMasterVo> _listHSetMasterVo;
        private readonly List<H_CarMasterVo> _listHCarMasterVo;
        private readonly List<H_StaffMasterVo> _listHStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public HAccountingParttimeList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hSetMasterDao = new(connectionVo);
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMaster();
            /*
             * InitializeControl
             */
            InitializeComponent();
            HDateTimePickerExOperationDate.SetValueJp(DateTime.Now.Date);
            this.InitializeSheetViewList();

        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            this.InitializeSheetViewList();
            this.SetSheetViewList(_hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(HDateTimePickerExOperationDate.GetValue().Date));
        }


        string _operationName = string.Empty;
        private void SetSheetViewList(List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo) {
            int startRow = 3;
            int startCol = 1;

            // 日付
            SheetViewList.Cells["E2"].Text = HDateTimePickerExOperationDate.GetValueJp();

            foreach (H_StaffMasterVo hStaffMasterVo in _listHStaffMasterVo.FindAll(x => x.Belongs == 12 && x.VehicleDispatchTarget == true && x.RetirementFlag == false).OrderBy(x => x.EmploymentDate)) {
                SheetViewList.Cells[startRow, startCol].Text = hStaffMasterVo.DisplayName;
                var hVehicleDispatchDetailVo = listHVehicleDispatchDetailVo.Find(x => (x.StaffCode1 == hStaffMasterVo.StaffCode ||
                                                                                       x.StaffCode2 == hStaffMasterVo.StaffCode ||
                                                                                       x.StaffCode3 == hStaffMasterVo.StaffCode ||
                                                                                       x.StaffCode4 == hStaffMasterVo.StaffCode) &&
                                                                                       x.OperationDate == HDateTimePickerExOperationDate.GetValue().Date);
                /*
                 * 配車先が設定されてなくてStaffLabelExだけ置いてある場合処理をしない
                 * ”vehicleDispatchDetailVo.Set_code > 0” → この部分
                 */
                if (hVehicleDispatchDetailVo != null && hVehicleDispatchDetailVo.SetCode > 0) {
                    SheetViewList.Cells[startRow, startCol + 1].Text = "出勤";
                    /*
                     * 除外を設定
                     * ①整備本社は全て【運転手】にする（真由美さん依頼）
                     */
                    switch (hVehicleDispatchDetailVo.SetCode) {
                        case 1312111: // 整備本社
                            _operationName = "【運転手】";
                            break;
                        default:
                            _operationName = hVehicleDispatchDetailVo.StaffCode1 == hStaffMasterVo.StaffCode ? "【運転手】" : "【作業員】";
                            break;
                    }
                    SheetViewList.Cells[startRow, startCol + 2].Text = string.Concat(_operationName, _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName);
                    /*
                     * 車種
                     */
                    H_CarMasterVo hCarMasterVo = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchDetailVo.CarCode);
                    if (hCarMasterVo != null && hVehicleDispatchDetailVo.StaffCode1 == hStaffMasterVo.StaffCode) {
                        var carKidName = "";
                        switch (hCarMasterVo.CarKindCode) {
                            case 10:
                                carKidName = "軽自動車";
                                break;
                            case 11:
                                carKidName = "小型";
                                break;
                            case 12:
                                carKidName = "普通";
                                break;
                        }
                        SheetViewList.Cells[startRow, startCol + 3].Text = carKidName;
                    }
                    /*
                     * 出勤地
                     */
                    if (hVehicleDispatchDetailVo.StaffCode1 == hStaffMasterVo.StaffCode) {
                        SheetViewList.Cells[startRow, startCol + 4].Text = hVehicleDispatchDetailVo.CarGarageCode == 1 ? "本社" : "三郷";
                    } else {
                        SheetViewList.Cells[startRow, startCol + 4].Text = "本社";
                    }
                }
                startRow++;
            }
            ToolStripStatusLabelDetail.Text = string.Concat(HDateTimePickerExOperationDate.GetValueJp(), "のデータを更新しました。");
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                // A4で印刷する
                case "ToolStripMenuItemPrintA4":
                    //アクティブシート印刷します
                    SpreadList.PrintSheet(SheetViewList);
                    break;
                // アプリケーションを終了する
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// InitializeSheetViewList
        /// </summary>
        private void InitializeSheetViewList() {
            SheetViewList.Cells["E2"].Text = string.Empty;
            // 指定範囲のデータをクリア
            SheetViewList.ClearRange(3, 1, 40, 5, true);
        }

    }
}
