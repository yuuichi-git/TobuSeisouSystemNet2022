/*
 * 2024-02-19
 */
using Common;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using GrapeCity.Spreadsheet;

using H_Dao;

using H_Vo;

using Vo;

namespace H_RollColl {
    public partial class H_FirstRollColl : Form {
        /// <summary>
        /// Rowのスタート位置
        /// </summary>
        private int _startRow = 4;
        /// <summary>
        /// Columnのスタート位置
        /// </summary>
        readonly Dictionary<int, int> _dictionaryColNumber = new() { { 0, 0 }, { 1, 26 } };
        /// <summary>
        /// Rowの最大数
        /// Sheetも調整してね！
        /// これ以上Rowを追加すると会計システムが読取らない(確か99まで)
        /// </summary>
        readonly int _rowMax = 79;
        /// <summary>
        /// 配車先の別名
        /// </summary>
        private readonly Dictionary<int, string> dictionaryWordCode = new Dictionary<int, string> { { 13101, "千代田区" },
                                                                                                    { 13102, "中央区" },
                                                                                                    { 13103, "港区" },
                                                                                                    { 13104, "新宿区" },
                                                                                                    { 13105, "文京区" },
                                                                                                    { 13106, "台東区" },
                                                                                                    { 13107, "墨田区" },
                                                                                                    { 13108, "江東区" },
                                                                                                    { 13109, "品川区" },
                                                                                                    { 13110, "目黒区" },
                                                                                                    { 13111, "大田区" },
                                                                                                    { 13112, "世田谷区" },
                                                                                                    { 13113, "渋谷区" },
                                                                                                    { 13114, "中野区" },
                                                                                                    { 13115, "杉並区" },
                                                                                                    { 13116, "豊島区" },
                                                                                                    { 13117, "北区" },
                                                                                                    { 13118, "荒川区" },
                                                                                                    { 13119, "板橋区" },
                                                                                                    { 13120, "練馬区" },
                                                                                                    { 13121, "足立区" },
                                                                                                    { 13122, "葛飾区" },
                                                                                                    { 13123, "江戸川区" } };
        // 所属
        private readonly Dictionary<int, string> dictionaryBelongs = new() { { 10, "" }, { 11, "" }, { 12, "バ" }, { 13, "派" }, { 22, "労供" } };
        // 所属に対応したカラー
        private readonly Dictionary<string, System.Drawing.Color> dictionaryBelongsColor = new Dictionary<string, System.Drawing.Color> { { "", System.Drawing.Color.White }
                                                                                                                                         ,{ "新", System.Drawing.Color.White}
                                                                                                                                         ,{ "新作", System.Drawing.Color.White}
                                                                                                                                         ,{ "自", System.Drawing.Color.White}
                                                                                                                                         ,{ "自作", System.Drawing.Color.White}
                                                                                                                                         ,{ "バ", System.Drawing.Color.Wheat}
                                                                                                                                         ,{ "バ作", System.Drawing.Color.LightBlue}
                                                                                                                                         ,{ "派", System.Drawing.Color.White}
                                                                                                                                         ,{ "派作", System.Drawing.Color.MistyRose} };
        /*
         * Dao
         */
        private readonly H_SetMasterDao _hSetMasterDao;
        private readonly H_CarMasterDao _hCarMasterDao;
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_FareMasterDao _hFareMasterDao;
        private readonly H_FirstRollCallDao _hFirstRollCallDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly List<H_SetMasterVo> _listHSetMasterVo;
        private readonly List<H_CarMasterVo> _listHCarMasterVo;
        private readonly List<H_StaffMasterVo> _listHStaffMasterVo;
        private readonly List<H_FareMasterVo> _listHFareMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_FirstRollColl(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hSetMasterDao = new(connectionVo);
            _hCarMasterDao = new(connectionVo);
            _hStaffMasterDao = new(connectionVo);
            _hFareMasterDao = new(connectionVo);
            _hFirstRollCallDao = new(connectionVo);
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo 
             */
            _listHSetMasterVo = _hSetMasterDao.SelectAllHSetMaster();
            _listHCarMasterVo = _hCarMasterDao.SelectAllHCarMaster();
            _listHStaffMasterVo = _hStaffMasterDao.SelectAllHStaffMaster();
            _listHFareMasterVo = _hFareMasterDao.SelectAllHFareMasterVo();
            /*
             * InitializeControl
             */
            this.InitializeComponent();
            this.InitializeSheetView();
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        private void InitializeSheetView() {
            /*
             * 日付を初期化
             */
            HDateTimePickerExOperationDate.SetValueJp(DateTime.Today);
            /*
             * SPREAD初期化
             */
            SpreadFirstRollCall.TabStripPolicy = TabStripPolicy.Never;
            SpreadFirstRollCall.StatusBarVisible = true;
            /*
             * ToolStrip
             */
            ToolStripStatusLabelDetail.Text = string.Empty;
            ToolStripStatusLabelPosition.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            /*
             * 点呼執行者が選択されているかの確認
             */
            if (HComboBoxEx1.Text == "" || HComboBoxEx2.Text == "" || HComboBoxEx3.Text == "" || HComboBoxEx4.Text == "" || HComboBoxEx5.Text == "") {
                MessageBox.Show("点呼執行者を選択して下さい", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
             * 天候が選択されているかを確認
             */
            if (HComboBoxExWeather.Text == "") {
                MessageBox.Show("天候を選択して下さい", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
             * 指示事項が
             */
            if (HComboBoxExInstruction1.Text.Length < 10) {
                MessageBox.Show("指示事項(10文字以上)を入力して下さい", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
             * 再更新できないようにする
             */
            HDateTimePickerExOperationDate.Enabled = false;
            GroupBox1.Enabled = false;
            GroupBox2.Enabled = false;
            HCheckBoxEx1.Enabled = false;
            ((Button)sender).Enabled = false;
            /*
             * H_FirstRollCallVo書換え
             */
            try {
                if (_hFirstRollCallDao.ExistenceHFirstRollCallVo(HDateTimePickerExOperationDate.GetValue().Date)) {
                    _hFirstRollCallDao.UpdateOneHFirstRollCallVo(SetHFirstRollCallVo());
                } else {
                    _hFirstRollCallDao.InsertOneHFirstRollCallVo(SetHFirstRollCallVo());
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            this.SpreadOutput();
        }

        /// <summary>
        /// SetHFirstRollCallVo
        /// Voに値を代入する
        /// </summary>
        /// <returns></returns>
        private H_FirstRollCallVo SetHFirstRollCallVo() {
            H_FirstRollCallVo hFirstRollCallVo = new();
            hFirstRollCallVo.OperationDate = HDateTimePickerExOperationDate.GetValue();
            hFirstRollCallVo.RollCallName1 = HComboBoxEx1.Text;
            hFirstRollCallVo.RollCallName2 = HComboBoxEx2.Text;
            hFirstRollCallVo.RollCallName3 = HComboBoxEx3.Text;
            hFirstRollCallVo.RollCallName4 = HComboBoxEx4.Text;
            hFirstRollCallVo.RollCallName5 = HComboBoxEx5.Text;
            hFirstRollCallVo.Weather = HComboBoxExWeather.Text;
            hFirstRollCallVo.Instruction1 = HComboBoxExInstruction1.Text;
            hFirstRollCallVo.Instruction2 = HComboBoxExInstruction2.Text;
            return hFirstRollCallVo;
        }

        /// <summary>
        /// SpreadOutput
        /// </summary>
        private void SpreadOutput() {
            // インナークラス　選択行等を保持
            EntryCellPosition entryCellPosition = new();
            int blockRowCount;
            // 非活性化
            SpreadFirstRollCall.SuspendLayout();
            // 配車日時
            SheetViewFirstRollCall.Cells[0, 0].Text = HDateTimePickerExOperationDate.GetValueJp();
            // 天候
            SheetViewFirstRollCall.Cells[0, 12].Text = HComboBoxExWeather.Text;
            /*
             * 解析１
             */
            List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo = _hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(HDateTimePickerExOperationDate.GetValue());
            foreach (H_FareMasterVo hFareMasterVo in _listHFareMasterVo.OrderBy(x => x.FareCode)) {
                blockRowCount = 0;
                foreach (H_VehicleDispatchDetailVo hVehicleDispatchDetailVo in listHVehicleDispatchDetailVo.OrderBy(x => x.CellNumber)) {
                    /*
                     * 配車表に表示する条件
                     * SetCode > 0
                     */
                    if (hVehicleDispatchDetailVo.SetCode > 0 && _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).FareCode == hFareMasterVo.FareCode) {
                        /*
                         * 区分セルを作成する
                         */
                        if (blockRowCount == 0)
                            CreateSpan(GetNextCellPosition(), hFareMasterVo.FareName);
                        entryCellPosition = GetNextCellPosition();
                        /*
                         * 列が”AA"に変わった場合はBlockNameを挿入する
                         */
                        if (entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                            CreateSpan(entryCellPosition, hFareMasterVo.FareName);
                            entryCellPosition.Row++;
                        }
                        /*
                         * セルへ出力する
                         */
                        if (entryCellPosition != null) {
                            CreateSetRow(entryCellPosition, hVehicleDispatchDetailVo);
                            CreateCarRow(entryCellPosition, hVehicleDispatchDetailVo);
                            CreateOperator1Row(entryCellPosition, hVehicleDispatchDetailVo);
                            CreateOperator2Row(entryCellPosition, hVehicleDispatchDetailVo);
                            CreateOperator3Row(entryCellPosition, hVehicleDispatchDetailVo);
                            CreateOperator4Row(entryCellPosition, hVehicleDispatchDetailVo);
                        } else {
                            MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        blockRowCount++;
                    }
                }
            }

            SpreadFirstRollCall.ResumeLayout(true);
        }

        /*
         * 解析２（休み等の処理）
         */



        /// <summary>
        /// CreateSpan
        /// 運賃区分欄用のセル結合処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="blockName"></param>
        private void CreateSpan(EntryCellPosition entryCellPosition, string blockName) {
            // セルを結合する
            SheetViewFirstRollCall.AddSpanCell(entryCellPosition.Row, entryCellPosition.Col, 1, 24);
            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col].BackColor = System.Drawing.Color.LightGreen;
            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col].Text = blockName;
        }

        /// <summary>
        /// GetNextCellPosition
        /// 次に挿入するRowを特定する
        /// </summary>
        /// <returns></returns>
        private EntryCellPosition GetNextCellPosition() {
            EntryCellPosition entryCellPosition = new();
            for (int colPosition = 0; colPosition <= 1; colPosition++) { // 0:A列 1:AA列
                for (int row = _startRow; row <= _rowMax - 1; row++) {
                    if (SheetViewFirstRollCall.Cells[row, _dictionaryColNumber[colPosition] + 0].Text == "" &&  // 運賃コード又は配車先の位置
                        SheetViewFirstRollCall.Cells[row, _dictionaryColNumber[colPosition] + 8].Text == "" &&  // 運転手の位置
                        SheetViewFirstRollCall.Cells[row, _dictionaryColNumber[colPosition] + 11].Text == "" &&  // 作業員2の位置
                        SheetViewFirstRollCall.Cells[row + 1, _dictionaryColNumber[colPosition] + 11].Text == "") { // 作業員3の位置
                        entryCellPosition.Row = row;
                        entryCellPosition.Col = _dictionaryColNumber[colPosition];
                        entryCellPosition.RemainingRows = _rowMax - row;
                        ToolStripStatusLabelPosition.Text = string.Concat("Row:", entryCellPosition.Row, " Col:", entryCellPosition.Col, " 残り", entryCellPosition.RemainingRows);
                        return entryCellPosition;
                    }
                }
            }
            /*
             * Null:行に空きが無い
             */
            return null;
        }

        /// <summary>
        /// CreateSetRow
        /// 配車先情報の作成
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="hVehicleDispatchDetailVo"></param>
        private void CreateSetRow(EntryCellPosition entryCellPosition, H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            string setName1;
            string setName2;
            /*
             * 組がセットされていなければ何もしない
             */
            if (hVehicleDispatchDetailVo.SetCode > 0) {
                /*
                 * 区契の場合の表示は”〇〇区”とするため、条件分岐する
                 */
                if (_listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).ClassificationCode != 11) {

                    setName1 = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName1;
                    setName2 = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName2;
                } else {
                    /*
                     * 配車先が区契の場合、dictionaryWordCodeを参照する
                     */
                    setName1 = dictionaryWordCode[_listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).WordCode];
                    setName2 = _listHSetMasterVo.Find(x => x.SetCode == hVehicleDispatchDetailVo.SetCode).SetName2;
                }
                /*
                 * setName1
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col].ForeColor = hVehicleDispatchDetailVo.OperationFlag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col].Text = setName1;
                /*
                 * setName2
                 * 北区軽粗大・資源(１３１１７０６)は金曜日だけ資源車になって、作業員の料金が変わる。だから印を付ける
                 */
                switch (hVehicleDispatchDetailVo.SetCode) {
                    case 1311706: // 北区軽粗大・資源
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].ForeColor = hVehicleDispatchDetailVo.OperationFlag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                        if (HDateTimePickerExOperationDate.GetValue().DayOfWeek != DayOfWeek.Friday) {
                            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = setName2;
                        } else {
                            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].BackColor = System.Drawing.Color.Yellow;
                            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = "資源";
                        }
                        break;
                    default:
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].ForeColor = hVehicleDispatchDetailVo.OperationFlag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = setName2;
                        break;
                }
                /*
                 * 指示事項・その他連絡事項
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 22].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 22].Text = hVehicleDispatchDetailVo.SetMemo;
            }
        }

        /// <summary>
        /// CreateCarRow
        /// 車両情報の作成
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateCarRow(EntryCellPosition entryCellPosition, H_VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string doorNumberHONBAN;
            string registrationNumber;
            /*
             * 組がセットされていなければ何もしない
             */
            if (vehicleDispatchDetailVo.SetCode > 0 && vehicleDispatchDetailVo.CarCode > 0) {
                doorNumberHONBAN = _listHCarMasterVo.Find(x => x.CarCode == vehicleDispatchDetailVo.CarCode).DoorNumber.ToString();
                registrationNumber = string.Concat(_listHCarMasterVo.Find(x => x.CarCode == vehicleDispatchDetailVo.CarCode).RegistrationNumber3, _listHCarMasterVo.Find(x => x.CarCode == vehicleDispatchDetailVo.CarCode).RegistrationNumber4);
                /*
                 * 本番のドアナンバー
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].ForeColor = vehicleDispatchDetailVo.OperationFlag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].Text = doorNumberHONBAN;
                /*
                 * 本番の車番
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].ForeColor = vehicleDispatchDetailVo.OperationFlag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].Text = registrationNumber;

            }
        }

        /// <summary>
        /// CreateOperator1Row
        /// 運転手の作成
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="hVehicleDispatchDetailVo"></param>
        private void CreateOperator1Row(EntryCellPosition entryCellPosition, H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            RichText displayName; // 表示名
            string belongs = string.Empty; // 所属
            /*
             * 組がセットされていなければ何もしない
             */
            if (hVehicleDispatchDetailVo.SetCode > 0 && hVehicleDispatchDetailVo.StaffCode1 > 0) {
                displayName = new RichText(_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode1).DisplayName);
                switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode1).Belongs) {
                    case 10:
                    case 11:
                        belongs = string.Empty;
                        break;
                    case 12:
                        belongs = "バ";
                        break;
                    case 13:
                        belongs = "派";
                        break;
                    case 14:
                    case 15:
                        belongs = string.Empty;
                        break;
                    case 22:
                        switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode1).JobForm) {
                            case 20:
                            case 21:
                                belongs = "新";
                                break;
                            case 22:
                            case 23:
                                belongs = "自";
                                break;
                        }
                        break;
                }
                /*
                 * 表示名
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].BackColor = dictionaryBelongsColor[belongs];
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].Value = displayName;
                /*
                 * 所属
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 9].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 9].Text = belongs;
                /*
                 * 出庫地
                 * 運転手は配車先の管理地を出勤地とする
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 10].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 10].Text = hVehicleDispatchDetailVo.ManagedSpaceCode == 2 ? "三" : "";
                /*
                 * 指定された配車先の点呼を除外する
                 */
                switch (hVehicleDispatchDetailVo.SetCode) {
                    case 1312109: // 本社事務所
                    case 1312110: // 三郷事務所
                    case 1312111: // 整備本社
                    case 1312112: // 整備三郷
                    case 1312118: // 浄化槽
                    case 1312132: // 浄化槽(品川)
                    case 1312135: // 初任診断
                    case 1312136: // 適齢診断
                    case 1312137: // 初任研修(東環保)
                    case 1312138: // 整備管理講習
                    case 1312139: // 運行管理講習
                    case 1312140: // 当日無断で欠勤
                    case 1312141: // 当日朝電で欠勤
                    case 1312145: // 有給休暇
                    case 1312150: // 組合員欠勤
                    case 1312160: // バイト欠勤
                        return;
                }
                /*
                 * 点呼方法
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 14].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 14].Text = "対面";
                /*
                 * 点呼時刻
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 16].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 16].Text = hVehicleDispatchDetailVo.StaffRollCallFlag1 ? hVehicleDispatchDetailVo.StaffRollCallYmdHms1.ToString("HH:mm") : "未点呼";
                /*
                 * 免許・健康・車両・飲酒・検知器
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 17].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 17].Text = hVehicleDispatchDetailVo.StaffRollCallFlag1 ? "✓" : "";
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 18].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 18].Text = hVehicleDispatchDetailVo.StaffRollCallFlag1 ? "✓" : "";
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 19].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 19].Text = hVehicleDispatchDetailVo.StaffRollCallFlag1 ? "✓" : "";
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 20].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 20].Text = hVehicleDispatchDetailVo.StaffRollCallFlag1 ? "✓" : "";
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 21].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 21].Text = hVehicleDispatchDetailVo.StaffRollCallFlag1 ? "有" : "";
                /*
                 * 周知事項
                 */

                /*
                 * 点呼執行者
                 */
                switch (hVehicleDispatchDetailVo.CarGarageCode) {
                    case 1:
                        /*
                         * 点呼時刻の秒数が偶数なら”点呼執行者本社１”、奇数なら”点呼執行者本社２”を選択する
                         */
                        int second = hVehicleDispatchDetailVo.StaffRollCallYmdHms1.Second; //秒（0～59）
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        if (hVehicleDispatchDetailVo.StaffRollCallFlag1)
                            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Text = (second % 2 == 0) ? HComboBoxEx1.Text : HComboBoxEx2.Text;
                        break;
                    case 2:
                        /*
                         * ”点呼執行者三郷”を選択する
                         */
                        SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        if (hVehicleDispatchDetailVo.StaffRollCallFlag1)
                            SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Text = HComboBoxEx5.Text;
                        break;
                }
            }
        }

        /// <summary>
        /// CreateOperator2Row
        /// 作業員１の作成
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="hVehicleDispatchDetailVo"></param>
        private void CreateOperator2Row(EntryCellPosition entryCellPosition, H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            string belongs = string.Empty; // 所属
            /*
             * 組がセットされていなければ何もしない
             */
            if (hVehicleDispatchDetailVo.SetCode > 0 && hVehicleDispatchDetailVo.StaffCode2 > 0) {
                switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode2).Belongs) {
                    case 10:
                    case 11:
                        belongs = string.Empty;
                        break;
                    case 12:
                        belongs = "バ";
                        break;
                    case 13:
                        belongs = "派";
                        break;
                    case 14:
                    case 15:
                        belongs = string.Empty;
                        break;
                    case 22:
                        switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode2).JobForm) {
                            case 20:
                            case 21:
                                belongs = "新";
                                break;
                            case 22:
                            case 23:
                                belongs = "自";
                                break;
                        }
                        break;
                }
                /*
                 * "作"を追加するかどうか
                 */
                if (hVehicleDispatchDetailVo.StaffOccupation2 == 11) {
                    belongs = string.Concat(belongs, "作");
                }
                /*
                 * 表示名
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].BackColor = dictionaryBelongsColor[belongs];
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].Value = GetWorkStaffName(hVehicleDispatchDetailVo.StaffOccupation2, _listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode2));
                /*
                 * 所属
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 12].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 12].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 13].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row, entryCellPosition.Col + 13].Text = string.Empty; // 基本的に作業員が三郷出庫はない(大Gの相乗りは例外)
            }
        }

        /// <summary>
        /// CreateOperator3Row
        /// 作業員２の作成
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="hVehicleDispatchDetailVo"></param>
        private void CreateOperator3Row(EntryCellPosition entryCellPosition, H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            string belongs = string.Empty; // 所属
            /*
             * 組がセットされていなければ何もしない
             */
            if (hVehicleDispatchDetailVo.SetCode > 0 && hVehicleDispatchDetailVo.StaffCode3 > 0) {
                switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode3).Belongs) {
                    case 10:
                    case 11:
                        belongs = string.Empty;
                        break;
                    case 12:
                        belongs = "バ";
                        break;
                    case 13:
                        belongs = "派";
                        break;
                    case 14:
                    case 15:
                        belongs = string.Empty;
                        break;
                    case 22:
                        switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode3).JobForm) {
                            case 20:
                            case 21:
                                belongs = "新";
                                break;
                            case 22:
                            case 23:
                                belongs = "自";
                                break;
                        }
                        break;
                }
                /*
                 * "作"を追加するかどうか
                 */
                if (hVehicleDispatchDetailVo.StaffOccupation3 == 11) {
                    belongs = string.Concat(belongs, "作");
                }
                /*
                 * 表示名
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].BackColor = dictionaryBelongsColor[belongs];
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].Value = GetWorkStaffName(hVehicleDispatchDetailVo.StaffOccupation3, _listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode3));
                /*
                 * 所属
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 12].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 12].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 13].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 13].Text = string.Empty; // 基本的に作業員が三郷出庫はない(大Gの相乗りは例外)
            }
        }

        /// <summary>
        /// CreateOperator4Row
        /// 作業員３の作成
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="hVehicleDispatchDetailVo"></param>
        private void CreateOperator4Row(EntryCellPosition entryCellPosition, H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            string belongs = string.Empty; // 所属
            /*
             * 組がセットされていなければ何もしない
             */
            if (hVehicleDispatchDetailVo.SetCode > 0 && hVehicleDispatchDetailVo.StaffCode4 > 0) {
                switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode4).Belongs) {
                    case 10:
                    case 11:
                        belongs = string.Empty;
                        break;
                    case 12:
                        belongs = "バ";
                        break;
                    case 13:
                        belongs = "派";
                        break;
                    case 14:
                    case 15:
                        belongs = string.Empty;
                        break;
                    case 22:
                        switch (_listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode4).JobForm) {
                            case 20:
                            case 21:
                                belongs = "新";
                                break;
                            case 22:
                            case 23:
                                belongs = "自";
                                break;
                        }
                        break;
                }
                /*
                 * "作"を追加するかどうか
                 */
                if (hVehicleDispatchDetailVo.StaffOccupation4 == 11) {
                    belongs = string.Concat(belongs, "作");
                }
                /*
                 * 表示名
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].BackColor = dictionaryBelongsColor[belongs];
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].Value = GetWorkStaffName(hVehicleDispatchDetailVo.StaffOccupation4, _listHStaffMasterVo.Find(x => x.StaffCode == hVehicleDispatchDetailVo.StaffCode4));
                /*
                 * 所属
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 9].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 9].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 10].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetViewFirstRollCall.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 10].Text = string.Empty; // 基本的に作業員が三郷出庫はない(大Gの相乗りは例外)
            }
        }

        /// <summary>
        /// GetWorkStaffName
        /// ”作業員”を加えるかどうか
        /// </summary>
        /// <returns></returns>
        private string GetWorkStaffName(int occupation, H_StaffMasterVo hStaffMasterVo) {
            string rtfText = "";
            string displayName;
            /*
             * 2023-02-26
             * operator_occupationの値によって”作業員"を追加する処理
             */
            switch (occupation) {
                // 10:運転手 11:作業員 20:事務職　99:指定なし
                case 11:
                    displayName = string.Concat("作業員", hStaffMasterVo.DisplayName);
                    /*
                     * リッチテキスト文字列の作成
                     */
                    using (RichTextBox temp = new RichTextBox()) {
                        temp.Text = displayName;
                        temp.SelectionStart = 0;
                        temp.SelectionLength = 3;
                        temp.SelectionColor = System.Drawing.Color.Gray;
                        temp.SelectionFont = new System.Drawing.Font("Yu Gothic UI", 6);
                        rtfText = temp.Rtf;
                    }
                    break;
                default:
                    rtfText = string.Concat("", hStaffMasterVo.DisplayName);
                    break;
            }
            return rtfText;
        }

        /// <summary>
        /// HCheckBoxEx1_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCheckBoxEx1_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                if (_hFirstRollCallDao.ExistenceHFirstRollCallVo(HDateTimePickerExOperationDate.GetValue())) {
                    /*
                     * レコードを表示
                     */
                    H_FirstRollCallVo hFirstRollCallVo = _hFirstRollCallDao.SelectOneHFirstRollCallVo(HDateTimePickerExOperationDate.GetValue());
                    HComboBoxEx1.Text = hFirstRollCallVo.RollCallName1;
                    HComboBoxEx2.Text = hFirstRollCallVo.RollCallName2;
                    HComboBoxEx3.Text = hFirstRollCallVo.RollCallName3;
                    HComboBoxEx4.Text = hFirstRollCallVo.RollCallName4;
                    HComboBoxEx5.Text = hFirstRollCallVo.RollCallName5;
                    HComboBoxExWeather.Text = hFirstRollCallVo.Weather;
                    HComboBoxExInstruction1.Text = hFirstRollCallVo.Instruction1;
                    HComboBoxExInstruction2.Text = hFirstRollCallVo.Instruction2;
                } else {
                    MessageBox.Show("指定日の点呼記録はありません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else {
                HComboBoxEx1.Text = string.Empty;
                HComboBoxEx2.Text = string.Empty;
                HComboBoxEx3.Text = string.Empty;
                HComboBoxEx4.Text = string.Empty;
                HComboBoxEx5.Text = string.Empty;
                HComboBoxExWeather.Text = string.Empty;
                HComboBoxExInstruction1.Text = string.Empty;
                HComboBoxExInstruction2.Text = string.Empty;
            }
        }

        /// <summary>
        /// EntryCellPosition
        /// Rowの状態を保持する
        /// </summary>
        private class EntryCellPosition {
            int _row;
            int _col;
            int _remainingRows;

            public EntryCellPosition() {
                _row = 0;
                _col = 0;
            }
            /// <summary>
            /// 挿入可能な位置を保持
            /// </summary>
            public int Row {
                get => _row;
                set => _row = value;
            }
            /// <summary>
            /// 挿入可能な位置を保持
            /// </summary>
            public int Col {
                get => _col;
                set => _col = value;
            }
            /// <summary>
            /// 残りの行数
            /// </summary>
            public int RemainingRows {
                get => _remainingRows;
                set => _remainingRows = value;
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemExportExcel":
                    //xls形式ファイルをエクスポートします
                    string fileName = string.Concat("配車当日", DateTime.Now.ToString("MM月dd日"), "作成");
                    SpreadFirstRollCall.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat);
                    MessageBox.Show("デスクトップへエクスポートしました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "ToolStripMenuItemExit":
                    Close();
                    break;
            }
        }

        /// <summary>
        /// H_FirstRollColl_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_FirstRollColl_FormClosing(object sender, FormClosingEventArgs e) {
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
