using Common;

using Dao;

using FarPoint.Excel;
using FarPoint.Win.Spread;

using GrapeCity.Spreadsheet;

using H_Vo;


namespace VehicleDispatchSheet {
    public partial class VehicleDispatchSheetBoad : Form {
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
        private RollCallDetailVo? _rollCallDetailVo;
        /*
         * 初期化
         */
        private InitializeForm _initializeForm = new();
        private string _beforeBlockName = string.Empty;
        /// <summary>
        /// Rowのスタート位置
        /// </summary>
        private int _startRow = 4;
        /// <summary>
        /// Columnのスタート位置
        /// </summary>
        readonly Dictionary<int, int> _dictionaryColNumber = new Dictionary<int, int> { { 0, 0 },{ 1, 26 } };
        /// <summary>
        /// Rowの最大数
        /// Sheetも調整してね！
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
        private readonly Dictionary<int, string> dictionaryBelongs = new Dictionary<int, string> { { 10, "" }, { 11, "" }, { 12, "バ" }, { 13, "派" }, { 20, "新" }, { 21, "自" } };
        private readonly Dictionary<int, string> dictionaryOccupation = new Dictionary<int, string> { { 10, "" }, { 11, "作" }, { 99, "" } };

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public VehicleDispatchSheetBoad(ConnectionVo connectionVo) {
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
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.VehicleDispatchSheet(this);
            /*
             * SPREAD初期化
             */
            SpreadBase.TabStripPolicy = TabStripPolicy.Never;
            SpreadBase.StatusBarVisible = true;
            /*
             * 日付を初期化
             */
            DateTimePickerJpExOperationDate.SetValue(DateTime.Now);

            ToolStripStatusLabelStatus.Text = string.Empty;
            ToolStripStatusLabelPosition.Text = string.Empty;
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
            /*
             * 点呼執行者が選択されているかの確認
             */
            if(ComboBox1.Text == "" || ComboBox2.Text == "" || ComboBox3.Text == "" || ComboBox4.Text == "" || ComboBoxMISATO.Text == "") {
                MessageBox.Show("点呼執行者を選択して下さい", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
             * 天候が選択されているかを確認
             */
            if(ComboBoxWEATHER.Text == "") {
                MessageBox.Show("天候を選択して下さい", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
             * 指示事項が
             */
            if(ComboBoxInstruction1.Text.Length < 10) {
                MessageBox.Show("指示事項(10文字以上)を入力して下さい", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
             * 再更新できないようにする
             */
            ((Button)sender).Enabled = false;

            /*
             * roll_call_detailを記録する
             */
            if(_rollCallDetailDao.CheckRollCallDetail(DateTimePickerJpExOperationDate.GetValue()) > 0) {
                /*
                 * 更新登録(UPDATE)
                 */
                _rollCallDetailVo = new RollCallDetailVo();
                _rollCallDetailVo.Operation_date = DateTimePickerJpExOperationDate.GetValue().Date;
                _rollCallDetailVo.Roll_call_name_1 = ComboBox1.Text;
                _rollCallDetailVo.Roll_call_name_2 = ComboBox2.Text;
                _rollCallDetailVo.Roll_call_name_3 = ComboBox3.Text;
                _rollCallDetailVo.Roll_call_name_4 = ComboBox4.Text;
                _rollCallDetailVo.Roll_call_name_5 = ComboBoxMISATO.Text;
                _rollCallDetailVo.Instruction1 = ComboBoxInstruction1.Text;
                _rollCallDetailVo.Instruction2 = ComboBoxInstruction2.Text;
                _rollCallDetailVo.Weather = ComboBoxWEATHER.Text;
                _rollCallDetailDao.UpdateOneRollCallDetail(_rollCallDetailVo);
            } else {
                /*
                 * 新規登録(INSERT)
                 */
                _rollCallDetailVo = new RollCallDetailVo();
                _rollCallDetailVo.Operation_date = DateTimePickerJpExOperationDate.GetValue().Date;
                _rollCallDetailVo.Roll_call_name_1 = ComboBox1.Text;
                _rollCallDetailVo.Roll_call_name_2 = ComboBox2.Text;
                _rollCallDetailVo.Roll_call_name_3 = ComboBox3.Text;
                _rollCallDetailVo.Roll_call_name_4 = ComboBox4.Text;
                _rollCallDetailVo.Roll_call_name_5 = ComboBoxMISATO.Text;
                _rollCallDetailVo.Instruction1 = ComboBoxInstruction1.Text;
                _rollCallDetailVo.Instruction2 = ComboBoxInstruction2.Text;
                _rollCallDetailVo.Weather = ComboBoxWEATHER.Text;
                _rollCallDetailDao.InsertOneRollCallDetail(_rollCallDetailVo);
            }
            ToolStripStatusLabelPosition.Text = "roll_call_detailを更新しました。";

            EntryCellPosition entryCellPosition;
            int blockRowCount;

            SpreadBase.SuspendLayout();
            /*
             * 配車日時
             */
            SheetView1.Cells[0, 0].Text = DateTimePickerJpExOperationDate.GetValueJp();
            /*
             * 天候
             */
            SheetView1.Cells[0, 12].Text = ComboBoxWEATHER.Text;
            /*
             * 10:☆庸上　小特　コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 * 
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 10) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆庸上　小特　コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 11:☆庸上　小プレ　コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 11) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆庸上　小プレ　コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 12:☆庸上　新大特　コード：2
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 12) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆庸上　新大特　コード：2";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 13:☆庸上　軽小ダンプ　コード：51
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 13) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆庸上　軽小ダンプ　コード：51";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 14:☆庸上　軽小型貨物　コード：11
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 14) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆庸上　軽小型貨物　コード：11";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 15:☆区契　軽小型貨物　コード：11
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 15) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆区契　軽小型貨物　コード：11";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 16:☆区契　小プレ　コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 16) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆区契　小プレ　コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 17:☆区契　小プレ コード：23
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 17) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆区契　小プレ コード：23";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 18:☆区契　小プレ　コード：8
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 18) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆区契　小プレ　コード：8";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 19:☆区契　平ボディ　コード：15
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 19) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆区契　平ボディ　コード：15";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 20:☆区契　小Ｇ　コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 20) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆区契　小Ｇ　コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 21:☆庸上　大Ｇ　コード：5
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 21) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆庸上　大Ｇ　コード：5";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 22:☆臨時　小プレ等　コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                          (_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "小プ" ||
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "小特")) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆臨時　小プレ等　コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);

                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 23:☆臨時　雇上　新大特　コード：2
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "新大") {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆臨時　雇上　新大特　コード：2";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 24:☆臨時　雇上/区契　軽小/軽ダ　コード：11
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                          (_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "軽小" ||
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "軽ダ")) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆臨時　雇上/区契　軽小貨/軽ダ　コード：11";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 25:☆臨時　区契　平ボディ　コード：15　
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 0 &&
                                                           _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code == 12 &&
                                                           _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1 == "平ボ") {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆臨時　区契　平ボディ　コード：15";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 26:☆一廃・産廃【白ナンバー】 コード：12
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 26) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆一廃・産廃【白ナンバー】 コード：12";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 27:☆一廃・産廃【営業ナンバー】 コード：12
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 27) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆一廃・産廃【営業ナンバー】 コード：12";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 28:☆粗大・その他廃棄物【白ナンバー】 コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 28) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆粗大・その他廃棄物【白ナンバー】 コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 29:☆廃家電　他【営業ナンバー】 コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 29) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆廃家電　他【営業ナンバー】 コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 30:☆浄化槽 コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 30) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆浄化槽 コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 31:予備者・社員
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 31) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "予備者・社員";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 32:☆整備 コード：1
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 32) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆整備 コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            /*
             * 33:☆各種研修・処理場・回送等
             */
            blockRowCount = 0;
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(DateTimePickerJpExOperationDate.GetValue())) {
                /*
                 * 運賃対象のレコード以外はBreakする
                 */
                if(vehicleDispatchDetailVo.Set_code > 0 && _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Fare_code == 33) {
                    if(blockRowCount == 0) {
                        _beforeBlockName = "☆各種研修・処理場・回送等 コード：1";
                        CreateSpan(GetNextCellPosition(), _beforeBlockName);
                    }
                    entryCellPosition = GetNextCellPosition();
                    /*
                     * 列が”AA"に変わった場合はBlockNameを挿入する
                     */
                    if(entryCellPosition != null && entryCellPosition.Row == _startRow && entryCellPosition.Col == _dictionaryColNumber[1]) {
                        CreateSpan(entryCellPosition, _beforeBlockName);
                        entryCellPosition.Row++;
                    }
                    if(entryCellPosition != null) {
                        CreateSetRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateCarRow(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator1Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator2Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator3Row(entryCellPosition, vehicleDispatchDetailVo);
                        CreateOperator4Row(entryCellPosition, vehicleDispatchDetailVo);
                    } else {
                        MessageBox.Show("配車表の行数が不足しています。システム管理者へ報告して下さい。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    blockRowCount++;
                }
            }
            SpreadBase.ResumeLayout(true);
        }

        /// <summary>
        /// GetNextCellPosition
        /// 次に挿入するRowを特定する
        /// </summary>
        /// <param name="blockName"></param>
        /// <returns></returns>
        private EntryCellPosition GetNextCellPosition() {
            var entryCellPosition = new EntryCellPosition();
            for(int colPosition = 0; colPosition <= 1; colPosition++) { // 0:A列 1:AA列
                for(int row = _startRow; row <= _rowMax - 1; row++) {
                    if(SheetView1.Cells[row, _dictionaryColNumber[colPosition] + 0].Text == "" &&  // 運賃コード又は配車先の位置
                       SheetView1.Cells[row, _dictionaryColNumber[colPosition] + 8].Text == "" &&  // 運転手の位置
                       SheetView1.Cells[row, _dictionaryColNumber[colPosition] + 11].Text == "" &&  // 作業員2の位置
                       SheetView1.Cells[row + 1, _dictionaryColNumber[colPosition] + 11].Text == "") { // 作業員3の位置
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
        /// SetSpan
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="blockName"></param>
        private void CreateSpan(EntryCellPosition entryCellPosition, string blockName) {
            // セルを結合する
            SheetView1.AddSpanCell(entryCellPosition.Row, entryCellPosition.Col, 1, 24);
            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].BackColor = System.Drawing.Color.LightGreen;
            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].Text = blockName;
        }

        /// <summary>
        /// CreateSetRow
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateSetRow(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string setName1;
            string setName2;
            /*
             * 組がセットされていなければ何もしない
             */
            if(vehicleDispatchDetailVo.Set_code > 0) {
                /*
                 * 区契の場合の表示は”〇〇区”とするため、条件分岐する
                 */
                if(_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Classification_code != 11) {
                    setName1 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_1;
                    /*
                     * 組数に大G・鉄道・飛灰の表示を付ける
                     */
                    switch(vehicleDispatchDetailVo.Cell_number) {
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                        case 86:
                        case 87:
                            if(vehicleDispatchDetailVo.Car_code > 0) {
                                setName2 = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Disguise_kind_1;
                            } else {
                                setName2 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2;
                            }
                            break;
                        default:
                            setName2 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2;
                            break;
                    }
                } else {
                    /*
                     * 配車先が区契の場合、dictionaryWordCodeを参照する
                     */
                    setName1 = dictionaryWordCode[_listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Word_code];
                    setName2 = _listSetMasterVo.Find(x => x.Set_code == vehicleDispatchDetailVo.Set_code).Set_name_2;
                }
                /*
                 * setName1
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col].Text = setName1;
                /*
                 * setName2
                 * 北区軽粗大・資源(１３１１７０６)は金曜日だけ資源車になって、作業員の料金が変わる。だから印を付ける
                 */
                switch(vehicleDispatchDetailVo.Set_code) {
                    case 1311706: // 北区軽粗大・資源
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                        if(DateTimePickerJpExOperationDate.GetValue().DayOfWeek != DayOfWeek.Friday) {
                            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = setName2;
                        } else {
                            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].BackColor = System.Drawing.Color.Yellow;
                            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = "資源";
                        }
                        break;
                    default:
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 1].Text = setName2;
                        break;
                }
            }
        }

        /// <summary>
        /// CreateCarRow
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateCarRow(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string doorNumberHONBAN;
            string registrationNumber;
            /*
             * 組がセットされていなければ何もしない
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Car_code > 0) {
                doorNumberHONBAN = _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Door_number.ToString();
                registrationNumber = string.Concat(_listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_3,
                                                   _listCarMasterVo.Find(x => x.Car_code == vehicleDispatchDetailVo.Car_code).Registration_number_4);
                /*
                 * 本番のドアナンバー
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 2].Text = doorNumberHONBAN;
                /*
                 * 本番の車番
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].ForeColor = vehicleDispatchDetailVo.Operation_flag ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 3].Text = registrationNumber;

            }
        }

        /// <summary>
        /// CreateOperator1Row
        /// 運転手
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator1Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            RichText displayName; // 表示名
            string belongs; // 所属
            string garage; // 出庫地
            System.Drawing.Color _backColor = System.Drawing.Color.White; // セルの背景色
            /*
             * 組がセットされていなければ何もしない
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_1 > 0) {
                displayName = new RichText(_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Display_name);
                belongs = dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_1).Belongs];
                switch(belongs) {
                    case "バ":
                        _backColor = System.Drawing.Color.Wheat;
                        break;
                    case "派":
                        _backColor = System.Drawing.Color.MistyRose;
                        break;
                    default:
                        _backColor = System.Drawing.Color.White;
                        break;
                }
                garage = vehicleDispatchDetailVo.Garage_flag ? "" : "三";
                /*
                 * 表示名
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].BackColor = _backColor;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 8].Value = displayName;
                /*
                 * 所属
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 9].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 9].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 10].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 10].Text = garage;
                /*
                 * 指定された配車先の点呼を除外する
                 */
                switch(vehicleDispatchDetailVo.Set_code) {
                    case 1312109: // 本社事務所
                    case 1312110: // 三郷事務所
                    case 1312111: // 整備本社
                    case 1312112: // 整備三郷
                    case 1312118: // 浄化槽１
                    case 1312123: // 浄化槽２
                        return;
                }
                /*
                 * 点呼方法
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 14].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 14].Text = "対面";
                /*
                 * 点呼時刻
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 16].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 16].Text = vehicleDispatchDetailVo.Operator_1_roll_call_flag ? vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.ToString("HH:mm") : "未点呼";
                /*
                 * 免許・健康・車両・飲酒・検知器
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 17].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 17].Text = vehicleDispatchDetailVo.Operator_1_roll_call_flag ? "✓" : "";
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 18].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 18].Text = vehicleDispatchDetailVo.Operator_1_roll_call_flag ? "✓" : "";
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 19].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 19].Text = vehicleDispatchDetailVo.Operator_1_roll_call_flag ? "✓" : "";
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 20].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 20].Text = vehicleDispatchDetailVo.Operator_1_roll_call_flag ? "✓" : "";
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 21].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 21].Text = vehicleDispatchDetailVo.Operator_1_roll_call_flag ? "有" : "";
                /*
                 * 周知事項
                 */

                /*
                 * 点呼執行者
                 */
                switch(vehicleDispatchDetailVo.Garage_flag) {
                    case true:
                        /*
                         * 点呼時刻の秒数が偶数なら”点呼執行者本社１”、奇数なら”点呼執行者本社２”を選択する
                         */
                        int second = vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms.Second; //秒（0～59）
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        if(vehicleDispatchDetailVo.Operator_1_roll_call_flag)
                            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Text = (second % 2 == 0) ? ComboBox1.Text : ComboBox2.Text;
                        break;
                    case false:
                        /*
                         * ”点呼執行者三郷”を選択する
                         */
                        SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                        if(vehicleDispatchDetailVo.Operator_1_roll_call_flag)
                            SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 23].Text = ComboBoxMISATO.Text;
                        break;
                }
            }
        }

        /// <summary>
        /// CreateOperator2Row
        /// 作業員１
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator2Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string belongs; // 所属
            string garage; // 出庫地
            System.Drawing.Color _backColor = System.Drawing.Color.White; // セルの背景色
            /*
             * 組がセットされていなければ何もしない
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_2 > 0) {
                switch(vehicleDispatchDetailVo.Cell_number) {
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                        garage = vehicleDispatchDetailVo.Garage_flag ? "" : "三";
                        break;
                    default:
                        garage = "";
                        break;
                }
                /*
                 * "作"を追加するかどうか
                 */
                if(vehicleDispatchDetailVo.Operator_2_occupation == 11) {
                    belongs = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs], "作");
                } else {
                    belongs = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2).Belongs]);
                }
                switch(belongs) {
                    case "バ":
                        _backColor = System.Drawing.Color.Wheat;
                        break;
                    case "バ作":
                        _backColor = System.Drawing.Color.LightBlue;
                        break;
                    case "派作":
                        _backColor = System.Drawing.Color.MistyRose;
                        break;
                    default:
                        _backColor = System.Drawing.Color.White;
                        break;
                }
                /*
                 * 表示名
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].BackColor = _backColor;
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 11].Value = GetWorkStaffName(vehicleDispatchDetailVo.Operator_2_occupation,
                                                                                                             _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_2));
                /*
                 * 所属
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 12].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 12].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 13].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row, entryCellPosition.Col + 13].Text = garage;
            }
        }

        /// <summary>
        /// CreateOperator3Row
        /// 作業員２
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator3Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string belongs; // 所属
            System.Drawing.Color _backColor = System.Drawing.Color.White; // セルの背景色
            /*
             * 組がセットされていなければ何もしない
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_3 > 0) {
                /*
                 * "作"を追加するかどうか
                 */
                if(vehicleDispatchDetailVo.Operator_3_occupation == 11) {
                    belongs = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs], "作");
                } else {
                    belongs = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3).Belongs]);
                }
                switch(belongs) {
                    case "バ":
                        _backColor = System.Drawing.Color.Wheat;
                        break;
                    case "バ作":
                        _backColor = System.Drawing.Color.LightBlue;
                        break;
                    case "派作":
                        _backColor = System.Drawing.Color.MistyRose;
                        break;
                    default:
                        _backColor = System.Drawing.Color.White;
                        break;
                }
                /*
                 * 表示名
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].BackColor = _backColor;
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 11].Value = GetWorkStaffName(vehicleDispatchDetailVo.Operator_3_occupation,
                                                                                                                 _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_3));
                /*
                 * 所属
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 12].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 12].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 13].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 13].Text = "";
            }
        }

        /// <summary>
        /// CreateOperator4Row
        /// 作業員３
        /// </summary>
        /// <param name="entryCellPosition"></param>
        /// <param name="vehicleDispatchDetailVo"></param>
        private void CreateOperator4Row(EntryCellPosition entryCellPosition, VehicleDispatchDetailVo vehicleDispatchDetailVo) {
            string belongs; // 所属
            System.Drawing.Color _backColor = System.Drawing.Color.White; // セルの背景色
            /*
             * 組がセットされていなければ何もしない
             */
            if(vehicleDispatchDetailVo.Set_code > 0 && vehicleDispatchDetailVo.Operator_code_4 > 0) {
                /*
                 * "作"を追加するかどうか
                 */
                if(vehicleDispatchDetailVo.Operator_4_occupation == 11) {
                    belongs = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs], "作");
                } else {
                    belongs = string.Concat(dictionaryBelongs[_listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4).Belongs]);
                }
                switch(belongs) {
                    case "バ":
                        _backColor = System.Drawing.Color.Wheat;
                        break;
                    case "バ作":
                        _backColor = System.Drawing.Color.LightBlue;
                        break;
                    case "派作":
                        _backColor = System.Drawing.Color.MistyRose;
                        break;
                    default:
                        _backColor = System.Drawing.Color.White;
                        break;
                }
                /*
                 * 表示名
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].BackColor = _backColor;
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].CellType = new FarPoint.Win.Spread.CellType.RichTextCellType();
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 8].Value = GetWorkStaffName(vehicleDispatchDetailVo.Operator_4_occupation,
                                                                                                                _listStaffMasterVo.Find(x => x.Staff_code == vehicleDispatchDetailVo.Operator_code_4));
                /*
                 * 所属
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 9].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 9].Text = belongs;
                /*
                 * 出庫地
                 */
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 10].Font = new System.Drawing.Font("Yu Gothic UI", 9);
                SheetView1.Cells[entryCellPosition.Row + 1, entryCellPosition.Col + 10].Text = "";
            }
        }

        /// <summary>
        /// GetWorkStaffName
        /// ”作業員”を加えるかどうか
        /// </summary>
        /// <returns></returns>
        private string GetWorkStaffName(int occupation, StaffMasterVo staffMasterVo) {
            string rtfText = "";
            string displayName;
            /*
             * 2023-02-26
             * operator_occupationの値によって”作業員"を追加する処理
             */
            switch(occupation) {
                // 10:運転手 11:作業員 99:その他
                case 11:
                    displayName = string.Concat("作業員", staffMasterVo.Display_name);
                    /*
                     * リッチテキスト文字列の作成
                     */
                    using(RichTextBox temp = new RichTextBox()) {
                        temp.Text = displayName;
                        temp.SelectionStart = 0;
                        temp.SelectionLength = 3;
                        temp.SelectionColor = System.Drawing.Color.Gray;
                        temp.SelectionFont = new System.Drawing.Font("Yu Gothic UI", 6);
                        rtfText = temp.Rtf;
                    }
                    break;
                case 10:
                case 99:
                    rtfText = string.Concat("", staffMasterVo.Display_name);
                    break;
            }
            /*
             * 2023-02-26
             * コメントアウト
             */
            //switch(staffMasterVo.Belongs) {
            //    case 10: // 役員
            //    case 11: // 社員
            //        rtfText = staffMasterVo.Display_name;
            //        break;
            //    case 12: // アルバイト
            //    case 13: // 派遣
            //    case 20: // 新運転
            //    case 21: // 自運労
            //        /*
            //         * ここで指定した配車先の作業員には”作業員”は付けないようにする処理
            //         */
            //        switch(vehicleDispatchDetailVo.Set_code) {
            //            case 1312118: // 浄化槽１
            //            case 1312123: // 浄化槽２
            //            case 1312115: // ルート１（事業用）
            //            case 1312124: // ルート２（事業用）
            //            case 1312116: // 廃棄物１（事業用）
            //            case 1312125: // 廃棄物２（事業用）
            //            case 1312122: // 新井清掃
            //            case 1312111: // 整備本社
            //            case 1312112: // 整備三郷
            //                rtfText = string.Concat("", staffMasterVo.Display_name);
            //                break;
            //            default:
            //                /*
            //                 * ここで指定した作業員には”作業員”は付けないようにする処理
            //                 */
            //                switch(staffMasterVo.Staff_code) {
            //                    case 20675: // 深井翔
            //                    case 22093: // 佐藤貴志
            //                    case 20630: // 大橋祐哉
            //                    case 22038: // 髙﨑慶藏
            //                        rtfText = string.Concat("", staffMasterVo.Display_name);
            //                        break;
            //                    default:
            //                        displayName = string.Concat("作業員", staffMasterVo.Display_name);
            //                        /*
            //                         * リッチテキスト文字列の作成
            //                         */
            //                        using(RichTextBox temp = new RichTextBox()) {
            //                            temp.Text = displayName;
            //                            temp.SelectionStart = 0;
            //                            temp.SelectionLength = 3;
            //                            temp.SelectionColor = System.Drawing.Color.Gray;
            //                            temp.SelectionFont = new System.Drawing.Font("Yu Gothic UI", 6);
            //                            rtfText = temp.Rtf;
            //                        }
            //                        break;
            //                }
            //                break;
            //        }
            //        break;
            //}
            return rtfText;
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemPrint":
                    SpreadBase.PrintSheet(SheetView1);
                    break;
                case "ToolStripMenuItemExport":
                    //xls形式ファイルをエクスポートします
                    string fileName = string.Concat("配車当日", DateTime.Now.ToString("MM月dd日"), "作成");
                    SpreadBase.SaveExcel(new Directry().GetExcelDesktopPassXlsx(fileName), ExcelSaveFlags.UseOOXMLFormat);
                    MessageBox.Show("デスクトップへエクスポートしました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        /// <summary>
        /// CheckBox1_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            if(((CheckBox)sender).Checked) {
                /*
                 * RollCallDetailが存在すれば転記する
                 */
                _rollCallDetailVo = _rollCallDetailDao.SelectOneRollCallDetail(DateTimePickerJpExOperationDate.GetValue());
                if(_rollCallDetailVo != null) {
                    ComboBox1.Text = _rollCallDetailVo.Roll_call_name_1;
                    ComboBox2.Text = _rollCallDetailVo.Roll_call_name_2;
                    ComboBox3.Text = _rollCallDetailVo.Roll_call_name_3;
                    ComboBox4.Text = _rollCallDetailVo.Roll_call_name_4;
                    ComboBoxMISATO.Text = _rollCallDetailVo.Roll_call_name_5;
                    ComboBoxWEATHER.Text = _rollCallDetailVo.Weather;
                    ComboBoxInstruction1.Text = _rollCallDetailVo.Instruction1;
                    ComboBoxInstruction2.Text = _rollCallDetailVo.Instruction2;
                    Application.DoEvents();
                } else {
                    MessageBox.Show("記録は存在しません。", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else {
                ComboBox1.Text = "";
                ComboBox2.Text = "";
                ComboBox3.Text = "";
                ComboBox4.Text = "";
                ComboBoxMISATO.Text = "";
                ComboBoxWEATHER.Text = "";
                ComboBoxInstruction1.Text = "";
                ComboBoxInstruction2.Text = "";
                Application.DoEvents();
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
        /// VehicleDispatchSheetBoad_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchSheetBoad_FormClosing(object sender, FormClosingEventArgs e) {
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

        /// <summary>
        /// EntryCellPosition
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
    }
}