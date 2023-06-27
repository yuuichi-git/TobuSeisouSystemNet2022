using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Accounting {
    public partial class AccountingParttimeList : Form {
        private ConnectionVo _connectionVo;
        private readonly InitializeForm _initializeForm = new();
        private string _operationName = "";

        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<VehicleDispatchDetailVo> _listVehicleDispatchDetailVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public AccountingParttimeList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * Dao
             */
            _listSetMasterVo = new SetMasterDao(_connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.AccountingParttimeList(this);
            DateTimePickerJpExOperationDate.SetValue(DateTime.Now.Date);
            // シート
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            // ステータスバー
            ToolStripStatusLabelStatus.Text = "";

            InitializeSheetViewList();

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
            InitializeSheetViewList();
            _listVehicleDispatchDetailVo = new VehicleDispatchDetailDao(_connectionVo).SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue());
            PutSheetViewList();
        }

        private void PutSheetViewList() {
            int startRow = 3;
            int startCol = 1;

            // 日付
            SheetViewList.Cells["E2"].Text = DateTimePickerJpExOperationDate.GetValueJp();

            foreach(var staffMasterVo in _listStaffMasterVo.FindAll(x => x.Belongs == 12 && x.Vehicle_dispatch_target == true && x.Retirement_flag == false).OrderBy(x => x.Employment_date)) {
                SheetViewList.Cells[startRow, startCol].Text = staffMasterVo.Display_name;
                var vehicleDispatchDetailVo = _listVehicleDispatchDetailVo.Find(x => (x.Operator_code_1 == staffMasterVo.Staff_code ||
                                                                                      x.Operator_code_2 == staffMasterVo.Staff_code ||
                                                                                      x.Operator_code_3 == staffMasterVo.Staff_code ||
                                                                                      x.Operator_code_4 == staffMasterVo.Staff_code) &&
                                                                                      x.Operation_date == DateTimePickerJpExOperationDate.GetValue().Date);
                /*
                 * 配車先が設定されてなくてStaffLabelExだけ置いてある場合処理をしない
                 * ”vehicleDispatchDetailVo.Set_code > 0” → この部分
                 */
                if(vehicleDispatchDetailVo != null && vehicleDispatchDetailVo.Set_code > 0) {
                    SheetViewList.Cells[startRow, startCol + 1].Text = "出勤";
                    /*
                     * 除外を設定
                     * ①整備本社は全て【運転手】にする（真由美さん依頼）
                     */
                    switch(vehicleDispatchDetailVo.Set_code) {
                        case 1312111: // 整備本社
                            _operationName = "【運転手】";
                            break;
                        default:
                            _operationName = vehicleDispatchDetailVo.Operator_code_1 == staffMasterVo.Staff_code ? "【運転手】" : "【作業員】";
                            break;
                    }
                    SheetViewList.Cells[startRow, startCol + 2].Text = string.Concat(_operationName, _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name);
                    /*
                     * 車種
                     */
                    var carMasterVo = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code);
                    if(carMasterVo != null && vehicleDispatchDetailVo.Operator_code_1 == staffMasterVo.Staff_code) {
                        var carKidName = "";
                        switch(carMasterVo.Car_kind_code) {
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
                    if(vehicleDispatchDetailVo.Operator_code_1 == staffMasterVo.Staff_code) {
                        SheetViewList.Cells[startRow, startCol + 4].Text = vehicleDispatchDetailVo.Garage_flag ? "本社" : "三郷";
                    } else {
                        SheetViewList.Cells[startRow, startCol + 4].Text = "本社";
                    }
                }
                startRow++;
            }
            ToolStripStatusLabelStatus.Text = string.Concat(DateTimePickerJpExOperationDate.GetValueJp(), "のデータを更新しました。");
        }

        private void InitializeSheetViewList() {
            SheetViewList.Cells["E2"].Text = string.Empty;
            // 指定範囲のデータをクリア
            SheetViewList.ClearRange(3, 1, 40, 5, true);
        }

        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            //アクティブシート印刷します
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
        /// AccountingParttimeList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountingParttimeList_FormClosing(object sender, FormClosingEventArgs e) {
            Dispose();
        }
    }
}