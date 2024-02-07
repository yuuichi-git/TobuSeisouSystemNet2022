using System.Globalization;

using Common;

using Dao;

using H_Vo;

namespace RollCall {
    public partial class RollCallRecordBook : Form {
        private InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private RollCallDetailDao _rollCallDetailDao;
        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<VehicleDispatchDetailVo> _listVehicleDispatchDetailVo;
        private RollCallDetailVo? _rollCallDetailVo;

        public RollCallRecordBook(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _rollCallDetailDao = new RollCallDetailDao(connectionVo);
            /*
             * Vo
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            _listVehicleDispatchDetailVo = new();
            _rollCallDetailVo = null;
            /*
             * Control初期化
             */
            InitializeComponent();
            _initializeForm.RollCallRecordBook(this);
            // 本日の日付をセット
            DateTimePickerJpExOperationDate.SetValue(DateTime.Now.Date);
            // 初期値をセット
            ComboBoxArea.Text = "本社営業所";
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            /*
             * SPREADクリア
             */
            SheetViewList.ClearRange(4, 1, 70, 22, true);

            bool garageFlag = true;
            switch(ComboBoxArea.Text) {
                case "本社営業所":
                    garageFlag = true;
                    break;
                case "三郷車庫":
                    garageFlag = false;
                    break;
            }

            /*
             * roll_call_detailを取得
             */
            _rollCallDetailVo = _rollCallDetailDao.SelectOneRollCallDetail(DateTimePickerJpExOperationDate.GetValue().Date);
            if(_rollCallDetailVo == null) {
                MessageBox.Show("点呼実施者記録が存在しません。処理を終了します。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*
             * 和暦設定
             */
            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            SheetViewList.Cells[1, 1].Text = string.Concat(DateTimePickerJpExOperationDate.GetValue().ToString("ggyy年MM月dd日(dddd)", Japanese), "  天候：", _rollCallDetailVo.Weather, "  ", ComboBoxArea.Text);
            /*
             * Rowの処理
             */
            int row = 0;
            _listVehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue());
            foreach(var vehicleDispatchDetailVo in _listVehicleDispatchDetailVo.FindAll(x => x.Operation_flag == true && x.Garage_flag == garageFlag).OrderBy(x => x.Operator_1_roll_call_ymd_hms)) {
                /*
                 * 第五週が休車対象で、第５週になった場合点呼記録簿から除外する
                 */
                if(vehicleDispatchDetailVo.Operation_date.Day > 28 && vehicleDispatchDetailVo.Five_lap == false) {
                } else {
                    /*
                     * 車両が指定されていないものは、点呼記録簿から除外する
                     */
                    if(vehicleDispatchDetailVo.Car_code > 0) {
                        // 配車先
                        SheetViewList.Cells[row + 4, 1].Text = string.Concat(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1,
                                                                             _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2);
                        // 自動車登録番号
                        SheetViewList.Cells[row + 4, 2].Text = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number;
                        // 運転手
                        SheetViewList.Cells[row + 4, 3].Text = _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name;
                        // 点呼方法
                        SheetViewList.Cells[row + 4, 4].Text = "対面";
                        // 点呼時刻
                        SheetViewList.Cells[row + 4, 5].Text = vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.ToString("H:mm");
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
                        SheetViewList.Cells[row + 4, 12].Text = string.Concat(_rollCallDetailVo.Instruction1, "\r\n\r\n", _rollCallDetailVo.Instruction2);
                        // 点呼実施者
                        if(garageFlag) {
                            int secondStart = vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.Second; // 秒（0～59）
                            SheetViewList.Cells[row + 4, 13].Text = (secondStart % 2 == 0) ? _rollCallDetailVo.Roll_call_name_1 : _rollCallDetailVo.Roll_call_name_2;
                        } else {
                            SheetViewList.Cells[row + 4, 13].Text = _rollCallDetailVo.Roll_call_name_5;
                        }
                        /*
                         * 乗務後点呼
                         */
                        if(vehicleDispatchDetailVo.Last_roll_call_flag) {
                            // 最終搬入先
                            SheetViewList.Cells[row + 4, 14].Text = vehicleDispatchDetailVo.Last_plant_name;
                            // 回数
                            SheetViewList.Cells[row + 4, 15].Text = vehicleDispatchDetailVo.Last_plant_count.ToString();
                            // 搬入時刻
                            SheetViewList.Cells[row + 4, 16].Text = vehicleDispatchDetailVo.Last_plant_hm;
                            // 帰庫時刻
                            SheetViewList.Cells[row + 4, 17].Text = vehicleDispatchDetailVo.Last_roll_call_hm;
                            // 点呼方法
                            SheetViewList.Cells[row + 4, 18].Text = "対面";
                            // 酒気帯びの有無
                            SheetViewList.Cells[row + 4, 19].Text = "✓";
                            // 検知器使用の有無
                            SheetViewList.Cells[row + 4, 20].Text = "有";
                            // 自動車、道路及び運行の状況　その他必要な事項
                            SheetViewList.Cells[row + 4, 21].Text = vehicleDispatchDetailVo.Operator_1_note;
                            // 点呼実施者
                            if(garageFlag) {
                                int secondEnd = vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.Second; // 秒（0～59）
                                /*
                                 * 秒の数字によって点呼者を帰る
                                 */
                                switch(secondEnd.ToString("00").Substring(1, 1)) {
                                    case "0":
                                    case "1":
                                    case "2":
                                    case "3":
                                    case "4":
                                        SheetViewList.Cells[row + 4, 22].Text = _rollCallDetailVo.Roll_call_name_3;
                                        break;
                                    case "5":
                                    case "6":
                                    case "7":
                                    case "8":
                                    case "9":
                                        SheetViewList.Cells[row + 4, 22].Text = _rollCallDetailVo.Roll_call_name_4;
                                        break;
                                }
                            } else {
                                SheetViewList.Cells[row + 4, 22].Text = _rollCallDetailVo.Roll_call_name_5;
                            }
                        }
                        row++;
                    }
                }
            }
        }


        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemPrint":
                    SpreadBase.PrintSheet(SheetViewList);
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
        /// RollCallRecordBook_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollCallRecordBook_FormClosing(object sender, FormClosingEventArgs e) {
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
