/*
 * 2004-03-14
 */
using H_Dao;

using Vo;

namespace H_RollColl {
    public partial class H_RollCallRecordSheet : Form {
        /*
         * Dao
         */
        private H_SetMasterDao _hSetMasterDao;
        private H_CarMasterDao _hCarMasterDao;
        private H_StaffMasterDao _hStaffMasterDao;
        private H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        private H_FirstRollCallDao _hFirstRollCallDao;
        private H_LastRollCallDao _hLastRollCallDao;
        /*
         * Vo
         */
        private List<H_SetMasterVo> _listHSetMasterVo;
        private List<H_CarMasterVo> _listHCarMasterVo;
        private List<H_StaffMasterVo> _listHStaffMasterVo;
        private List<H_VehicleDispatchDetailVo> _listHVehicleDispatchDetailVo;
        private H_FirstRollCallVo _hFirstRollCallVo;
        private H_LastRollCallVo _hLastRollCallVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_RollCallRecordSheet(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hSetMasterDao = new(connectionVo);
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            _hVehicleDispatchDetailDao = new(connectionVo);
            _hFirstRollCallDao = new(connectionVo);
            _hLastRollCallDao = new(connectionVo);
            /*
             * Vo
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMaster();
            _listHVehicleDispatchDetailVo = new();
            _hFirstRollCallVo = new();
            _hLastRollCallVo = new();
            /*
             * InitializeControl
             */
            InitializeComponent();
            HDateTimePickerExOperationDate.SetValueJp(DateTime.Now.Date);
            HComboBoxExManagedSpace.Text = "本社営業所";
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            // SPREADクリア
            SheetViewList.ClearRange(4, 1, 70, 22, true);

            int ManagedSpaceCode = 0; // 0:該当なし 1:本社営業所 2:三郷車庫
            switch (HComboBoxExManagedSpace.Text) {
                case "本社営業所":
                    ManagedSpaceCode = 1;
                    break;
                case "三郷車庫":
                    ManagedSpaceCode = 2;
                    break;
            }

            /*
             * H_FirstRollCallVoを取得
             */
            _hFirstRollCallVo = _hFirstRollCallDao.SelectOneHFirstRollCallVo(HDateTimePickerExOperationDate.GetValue());

            if (_hFirstRollCallVo is null) {
                MessageBox.Show("選択日付の点呼実施者記録が存在しません。処理を終了します。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SheetViewList.Cells[1, 1].Text = string.Concat(HDateTimePickerExOperationDate.GetValueJp(), "  天候：", _hFirstRollCallVo.Weather, "  ", HComboBoxExManagedSpace.Text);
            /*
             * Rowの処理
             */
            int row = 0;
            _listHVehicleDispatchDetailVo = _hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(HDateTimePickerExOperationDate.GetValue());
            foreach (H_VehicleDispatchDetailVo hVehicleDispatchDetailVo in _listHVehicleDispatchDetailVo.FindAll(x => x.OperationFlag == true && x.ManagedSpaceCode == ManagedSpaceCode).OrderBy(x => x.StaffRollCallYmdHms1)) {
                // H_FirstRollCallVoを読込 ※NULLチェックが必要かも
                _hLastRollCallVo = _hLastRollCallDao.SelectOneHLastRollCall(hVehicleDispatchDetailVo);
                // 第五週の状態
                bool fiveLap = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).FiveLap;
                /*
                 * 第五週が休車対象で、第５週になった場合点呼記録簿から除外する
                 */
                if (hVehicleDispatchDetailVo.OperationDate.Day > 28 && fiveLap == false) {
                    /*
                     * 第五週に休車の配車先は、点呼記録簿に記載しない
                     */
                } else {
                    /*
                     * 車両が指定されていないものは、点呼記録簿から除外する
                     */
                    if (hVehicleDispatchDetailVo.CarCode > 0) {
                        // 配車先
                        SheetViewList.Cells[row + 4, 1].Text = string.Concat(_listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName1,
                                                                             _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName2);
                        // 自動車登録番号
                        SheetViewList.Cells[row + 4, 2].Text = _listHCarMasterVo.Find(x => x.CarCode == hVehicleDispatchDetailVo.CarCode).RegistrationNumber;
                        // 運転手
                        SheetViewList.Cells[row + 4, 3].Text = _listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode1).DisplayName;
                        // 点呼方法
                        SheetViewList.Cells[row + 4, 4].Text = "対面";
                        // 点呼時刻
                        SheetViewList.Cells[row + 4, 5].Text = hVehicleDispatchDetailVo.StaffRollCallYmdHms1.ToString("H:mm");
                        // 免許の所持
                        SheetViewList.Cells[row + 4, 6].Text = "✓";
                        // 健康状態・睡眠状況
                        SheetViewList.Cells[row + 4, 7].Text = "✓";
                        // 日常の点検
                        SheetViewList.Cells[row + 4, 9].Text = "✓";
                        // 酒気帯びの有無
                        SheetViewList.Cells[row + 4, 10].Text = "✓";
                        // 検知器使用の有無
                        SheetViewList.Cells[row + 4, 11].Text = "有";
                        // 指示事項・その他の事項
                        SheetViewList.Cells[row + 4, 12].Text = string.Concat(_hFirstRollCallVo.Instruction1, "\r\n\r\n", _hFirstRollCallVo.Instruction2);
                        // 点呼実施者
                        switch (ManagedSpaceCode) {
                            case 1:
                                int secondStart = hVehicleDispatchDetailVo.StaffRollCallYmdHms1.Second; // 秒（0～59）
                                SheetViewList.Cells[row + 4, 13].Text = (secondStart % 2 == 0) ? _hFirstRollCallVo.RollCallName1 : _hFirstRollCallVo.RollCallName2;
                                break;
                            case 2:
                                SheetViewList.Cells[row + 4, 13].Text = _hFirstRollCallVo.RollCallName5;
                                break;
                        }
                        /*
                         * 乗務後点呼
                         */
                        if (hVehicleDispatchDetailVo.LastRollCallFlag) {
                            // 最終搬入先
                            SheetViewList.Cells[row + 4, 14].Text = _hLastRollCallVo.LastPlantName;
                            // 回数
                            SheetViewList.Cells[row + 4, 15].Text = _hLastRollCallVo.LastPlantCount.ToString();
                            // 搬入時刻
                            SheetViewList.Cells[row + 4, 16].Text = _hLastRollCallVo.LastPlantYmdHms.ToString("HH:mm");
                            // 帰庫時刻
                            SheetViewList.Cells[row + 4, 17].Text = _hLastRollCallVo.LastRollCallYmdHms.ToString("HH:mm");
                            // 点呼方法
                            SheetViewList.Cells[row + 4, 18].Text = "対面";
                            // 酒気帯びの有無
                            SheetViewList.Cells[row + 4, 19].Text = "✓";
                            // 検知器使用の有無
                            SheetViewList.Cells[row + 4, 20].Text = "有";
                            // 自動車、道路及び運行の状況　その他必要な事項
                            SheetViewList.Cells[row + 4, 21].Text = hVehicleDispatchDetailVo.SetMemo;
                            // 点呼実施者
                            switch (ManagedSpaceCode) {
                                case 1:
                                    int secondEnd = hVehicleDispatchDetailVo.StaffRollCallYmdHms1.Second; // 秒（0～59）
                                    /*
                                     * 秒の数字によって点呼者を帰る
                                     */
                                    switch (secondEnd.ToString("00").Substring(1, 1)) {
                                        case "0":
                                        case "1":
                                        case "2":
                                        case "3":
                                        case "4":
                                            SheetViewList.Cells[row + 4, 22].Text = _hFirstRollCallVo.RollCallName3;
                                            break;
                                        case "5":
                                        case "6":
                                        case "7":
                                        case "8":
                                        case "9":
                                            SheetViewList.Cells[row + 4, 22].Text = _hFirstRollCallVo.RollCallName4;
                                            break;
                                    }
                                    break;
                                case 2:
                                    SheetViewList.Cells[row + 4, 22].Text = _hFirstRollCallVo.RollCallName5;
                                    break;
                            }
                        }
                        row++;
                    }
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemPrintA4":
                    SpreadBase.PrintSheet(SheetViewList);
                    break;
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// H_RollCallRecordSheet_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_RollCallRecordSheet_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show("アプリケーションを終了します。よろしいですか？", "メッセージ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
