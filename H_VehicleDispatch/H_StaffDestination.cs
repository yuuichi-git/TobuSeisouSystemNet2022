/*
 * 2024--7-04
 */
using FarPoint.Win.Spread;

using H_Common;

using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_StaffDestination : Form {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly Dictionary<int, string> _dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };
        private readonly Dictionary<int, string> _dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 12, "アルバイト" }, { 99, "指定なし" } };
        private readonly Dictionary<int, string> _dictionaryOccupation = new Dictionary<int, string> { { 10, "運転手" }, { 11, "作業員" }, { 20, "事務職" }, { 99, "指定なし" } };
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * SPREADのColumnの番号
         */
        /// <summary>
        /// 配車日
        /// </summary>
        private const int colOperationDate = 0;
        /// <summary>
        /// 出庫点呼時刻
        /// </summary>
        private const int colStaffRollCallYmdHms = 1;
        /// <summary>
        /// 役職又は所属
        /// </summary>
        private const int colBelongs = 2;
        /// <summary>
        /// 雇用形態
        /// </summary>
        private const int colJobForm = 3;
        /// <summary>
        /// 氏名
        /// </summary>
        private const int colDisplayName = 4;
        /// <summary>
        /// 配車先
        /// </summary>
        private const int colSetName = 5;
        /// <summary>
        /// 職種
        /// </summary>
        private const int colStaffOccupation = 6;
        /// <summary>
        /// メモ
        /// </summary>
        private const int colStaffMemo = 7;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_StaffDestination(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * InitializeControl
             */
            InitializeComponent();
            /*
             * 配車日を設定
             */
            this.HDateTimePickerExOperationDate1.SetValueJp(new Date().GetBeginOfMonth(DateTime.Now));
            this.HDateTimePickerExOperationDate2.SetValueJp(new Date().GetEndOfMonth(DateTime.Now));
            /*
             * 氏名を初期化
             */
            this.InitializeHComboBoxExSelectName();
            /*
             * FpSpread/Viewを初期化
             */
            this.InitializeSheetView(SheetViewList);
            /*
             * ToolStripStatusLabelDetail
             */
            ToolStripStatusLabelDetail.Text = string.Empty;
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            /*
             * HComboBoxExSelectNameが未選択ならreturnする
             */
            if (HComboBoxExSelectName.SelectedIndex == -1)
                return;
            H_StaffMasterVo hStaffMasterVo = ((HComboBoxExSelectNameVo)HComboBoxExSelectName.SelectedItem).HStaffMasterVo;
            List<H_VehicleDispatchDetailVoForStaffDestination> listHVehicleDispatchDetailVoForStaffDestination = _hVehicleDispatchDetailDao.SelectAllHVehicleDispatchDetail(HDateTimePickerExOperationDate1.GetValue(), 
                                                                                                                                                                            HDateTimePickerExOperationDate2.GetValue(), 
                                                                                                                                                                            hStaffMasterVo.StaffCode);
            int rowCount = 0;
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // Rowを削除する
            if (SheetViewList.Rows.Count > 0)
                SheetViewList.RemoveRows(0, SheetViewList.Rows.Count);
            if (listHVehicleDispatchDetailVoForStaffDestination is not null) {
                /*
                 * 変数定義
                 */
                int _staffOccupation = 99; // 職種
                DateTime _staffRollCallYmdHms = _defaultDateTime; //点呼日時
                string _staffMemo = string.Empty; // メモ

                foreach (H_VehicleDispatchDetailVoForStaffDestination hVehicleDispatchDetailVoForStaffDestination in listHVehicleDispatchDetailVoForStaffDestination.OrderBy(x => x.OperationDate)) {
                    /*
                     * 該当する従事者のカラムからデータを抽出して代入
                     */
                    if (hVehicleDispatchDetailVoForStaffDestination.StaffCode1 == hStaffMasterVo.StaffCode) {
                        _staffOccupation = hVehicleDispatchDetailVoForStaffDestination.StaffOccupation1;
                        _staffRollCallYmdHms = hVehicleDispatchDetailVoForStaffDestination.StaffRollCallYmdHms1;
                        _staffMemo = hVehicleDispatchDetailVoForStaffDestination.StaffMemo1;
                    } else if (hVehicleDispatchDetailVoForStaffDestination.StaffCode2 == hStaffMasterVo.StaffCode) {
                        _staffOccupation = hVehicleDispatchDetailVoForStaffDestination.StaffOccupation2;
                        _staffRollCallYmdHms = hVehicleDispatchDetailVoForStaffDestination.StaffRollCallYmdHms2;
                        _staffMemo = hVehicleDispatchDetailVoForStaffDestination.StaffMemo2;
                    } else if (hVehicleDispatchDetailVoForStaffDestination.StaffCode3 == hStaffMasterVo.StaffCode) {
                        _staffOccupation = hVehicleDispatchDetailVoForStaffDestination.StaffOccupation3;
                        _staffRollCallYmdHms = hVehicleDispatchDetailVoForStaffDestination.StaffRollCallYmdHms3;
                        _staffMemo = hVehicleDispatchDetailVoForStaffDestination.StaffMemo3;
                    } else if (hVehicleDispatchDetailVoForStaffDestination.StaffCode4 == hStaffMasterVo.StaffCode) {
                        _staffOccupation = hVehicleDispatchDetailVoForStaffDestination.StaffOccupation4;
                        _staffRollCallYmdHms = hVehicleDispatchDetailVoForStaffDestination.StaffRollCallYmdHms4;
                        _staffMemo = hVehicleDispatchDetailVoForStaffDestination.StaffMemo4;
                    }

                    SheetViewList.Rows.Add(rowCount, 1);
                    SheetViewList.RowHeader.Columns[0].Label = (rowCount + 1).ToString(); // Rowヘッダ
                    SheetViewList.Rows[rowCount].Height = 20; // Rowの高さ
                    SheetViewList.Rows[rowCount].Resizable = false; // RowのResizableを禁止
                    // 配車日
                    SheetViewList.Cells[rowCount, colOperationDate].Value = hVehicleDispatchDetailVoForStaffDestination.OperationDate.Date;
                    // 点呼時刻
                    SheetViewList.Cells[rowCount, colStaffRollCallYmdHms].Text = _staffRollCallYmdHms.ToString("HH:mm");
                    // 役職又は所属
                    SheetViewList.Cells[rowCount, colBelongs].Value = _dictionaryBelongs[hStaffMasterVo.Belongs];
                    // 雇用形態
                    SheetViewList.Cells[rowCount, colJobForm].Value = _dictionaryJobForm[hStaffMasterVo.JobForm];
                    // 氏名
                    SheetViewList.Cells[rowCount, colDisplayName].Text = hStaffMasterVo.DisplayName;
                    // 配車先
                    SheetViewList.Cells[rowCount, colSetName].Value = hVehicleDispatchDetailVoForStaffDestination.SetName;
                    // 職種
                    SheetViewList.Cells[rowCount, colStaffOccupation].Value = _dictionaryOccupation[_staffOccupation];
                    // メモ
                    SheetViewList.Cells[rowCount, colStaffMemo].Text = _staffMemo;
                    rowCount++;
                }
            }
            // Spread 活性化
            SpreadList.ResumeLayout();
            ToolStripStatusLabelDetail.Text = string.Concat(" ", rowCount, " 件");

        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns>SheetView</returns>
        private SheetView InitializeSheetView(SheetView sheetView) {
            this.SpreadList.AllowDragDrop = false; // DrugDropを禁止する
            this.SpreadList.PaintSelectionHeader = false; // ヘッダの選択状態をしない
            this.SpreadList.TabStrip.DefaultSheetTab.Font = new Font("Yu Gothic UI", 9);
            this.SpreadList.TabStripPolicy = TabStripPolicy.Never; // Tab非表示
            sheetView.AlternatingRows.Count = 2; // 行スタイルを２行単位とします
            sheetView.AlternatingRows[0].BackColor = Color.WhiteSmoke; // 1行目の背景色を設定します
            sheetView.AlternatingRows[1].BackColor = Color.White; // 2行目の背景色を設定します
            sheetView.ColumnHeader.Rows[0].Height = 26; // Columnヘッダの高さ
            sheetView.GrayAreaBackColor = Color.White;
            sheetView.HorizontalGridLine = new GridLine(GridLineType.None);
            sheetView.RowHeader.Columns[0].Font = new Font("Yu Gothic UI", 9); // 行ヘッダのFont
            sheetView.RowHeader.Columns[0].Width = 48; // 行ヘッダの幅を変更します
            sheetView.VerticalGridLine = new GridLine(GridLineType.Flat, Color.LightGray);
            sheetView.RemoveRows(0, sheetView.Rows.Count);
            return sheetView;
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 印刷する(A4)
                 */
                case "ToolStripMenuItemPrintA4":

                    break;
                /*
                 * アプリケーションを終了する
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// HDateTimePickerExOperationDate1_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerExOperationDate1_ValueChanged(object sender, EventArgs e) {
            if (((H_DateTimePickerEx)sender).Value > this.HDateTimePickerExOperationDate2.GetValue()) {
                this.HDateTimePickerExOperationDate2.SetValueJp(new Date().GetEndOfMonth(((H_DateTimePickerEx)sender).GetValue()));
            }
        }

        /// <summary>
        /// HDateTimePickerExOperationDate2_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDateTimePickerExOperationDate2_ValueChanged(object sender, EventArgs e) {
            if (((H_DateTimePickerEx)sender).Value < this.HDateTimePickerExOperationDate1.GetValue()) {
                this.HDateTimePickerExOperationDate1.SetValueJp(new Date().GetBeginOfMonth(((H_DateTimePickerEx)sender).GetValue()));
            }
        }

        /// <summary>
        /// HComboBoxExSelectNameを初期化
        /// </summary>
        private void InitializeHComboBoxExSelectName() {
            HComboBoxExSelectName.Items.Clear();
            List<HComboBoxExSelectNameVo> listComboBoxSelectNameVo = new();
            foreach (H_StaffMasterVo hStaffMasterVo in _hStaffMasterDao.SelectAllHStaffMasterForHStaffDestination().OrderBy(x => x.NameKana))
                HComboBoxExSelectName.Items.Add(new HComboBoxExSelectNameVo(hStaffMasterVo.Name, hStaffMasterVo));
            HComboBoxExSelectName.DisplayMember = "Name";
        }

        /// <summary>
        /// インナークラス
        /// </summary>
        private class HComboBoxExSelectNameVo {
            private string _name;
            private H_StaffMasterVo _hStaffMasterVo;

            // プロパティをコンストラクタでセット
            public HComboBoxExSelectNameVo(string name, H_StaffMasterVo hStaffMasterVo) {
                _name = name;
                _hStaffMasterVo = hStaffMasterVo;
            }

            public string Name {
                get => _name;
                set => _name = value;
            }
            public H_StaffMasterVo HStaffMasterVo {
                get => _hStaffMasterVo;
                set => _hStaffMasterVo = value;
            }
        }

        /// <summary>
        /// H_StaffDestination_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_StaffDestination_FormClosing(object sender, FormClosingEventArgs e) {
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
