using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace Certification {
    public partial class CertificationList : Form {
        private InitializeForm _initializeForm = new();
        private readonly string[] _arrayMark = new string[] { "◎", "○", "●" }; // マークの種類
        /*
         * Dao
         */
        private StaffMasterDao _staffMasterDao;
        private LicenseMasterDao _licenseMasterDao;
        private CertificationDao _certificationDao;
        /*
         * Vo
         */
        private List<StaffMasterVo> _listStaffMasterVo;
        private List<LicenseMasterVo> _listLicenseMasterVo;
        private List<CertificationMasterVo> _listCertificationMasterVo;
        private List<CertificationFileVo> _listCertificationFileVo;

        // 実際にデータを入れるスタート位置を指定
        private readonly int startColumnNumber = 2;
        // 実際にデータを入れるスタート位置を指定
        private readonly int startRowNumber = 3;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public CertificationList(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _staffMasterDao = new StaffMasterDao(connectionVo);
            _certificationDao = new CertificationDao(connectionVo);
            _licenseMasterDao = new LicenseMasterDao(connectionVo);
            /*
             * Vo
             */
            _listStaffMasterVo = _staffMasterDao.SelectAllStaffMaster().FindAll(x => (x.Job_form == 10 || x.Job_form == 12 || x.Job_form == 99) && x.Retirement_flag == false);
            _listLicenseMasterVo = _licenseMasterDao.SelectAllLicenseMaster();
            _listCertificationMasterVo = new();
            _listCertificationFileVo = new();
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.CertificationList(this);
            // Spread 非活性化
            SpreadList.SuspendLayout();
            // DrugDropを禁止する
            SpreadList.AllowDragDrop = false;
            // シートタブを非表示
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            // Columnヘッダの高さ
            SheetViewList.ColumnHeader.Rows[0].Height = 250;
            SheetViewList.GrayAreaBackColor = Color.White;
            // 従業員情報をセット
            SetColumnHeader(SheetViewList);
            // 資格名をセット
            SetRowHeader(SheetViewList);
            // Spread 活性化
            SpreadList.ResumeLayout();
            // StatusLabel 初期化
            ToolStripStatusLabelStatus.Text = "";
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
            _listCertificationFileVo = _certificationDao.SelectAllCertificationFile();
            SheetViewListOutPut(SheetViewList);
        }

        /// <summary>
        /// TabControlStaff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlStaff_Click(object sender, EventArgs e) {
            // コレクションをリセット
            if(((TabControl)sender).SelectedTab.Tag != null) {
                switch((string)((TabControl)sender).SelectedTab.Tag) {
                    case "全従業員":
                        SpreadList.SetViewportLeftColumn(0, 2);
                        break;
                    default:
                        // Tabで指定した文字をListから検索し最初に見つかったIndexを保持
                        int findIndexListStaffLedgerVo = _listStaffMasterVo.FindIndex(x => x.Name_kana.StartsWith((string)((TabControl)sender).SelectedTab.Tag));
                        if(findIndexListStaffLedgerVo != -1)
                            SpreadList.SetViewportLeftColumn(0, findIndexListStaffLedgerVo + startColumnNumber);
                        break;
                }
            }
            // 従業員情報をセット
            SetColumnHeader(SheetViewList);
        }

        /// <summary>
        /// SetColumnHeader
        /// Columnに従業員の一覧を作成する
        /// </summary>
        private void SetColumnHeader(SheetView sheetView) {
            /*
             * Columnをクリア
             */
            for(int i = 2; i < sheetView.ColumnCount; i++) {
                sheetView.Cells[0, i].ResetText(); // レコード番号
                sheetView.Cells[1, i].ResetText(); // 従業員名
                sheetView.Cells[2, i].ResetText(); // 年齢
            }
            int columnNumber = startColumnNumber;
            // 処理されるレコードの番号
            int recordNumber = 1;
            foreach(StaffMasterVo staffMasterVo in _listStaffMasterVo) {
                /*
                 * レコード番号
                 */
                sheetView.Cells[0, columnNumber].Font = new Font("Yu Gothic UI", 8);
                sheetView.Cells[0, columnNumber].Value = recordNumber;
                /*
                 * Vo退避 従業員名
                 */
                sheetView.Cells[1, columnNumber].Font = new Font("Yu Gothic UI", 9);
                sheetView.Cells[1, columnNumber].Tag = staffMasterVo;
                sheetView.Cells[1, columnNumber].Text = staffMasterVo.Display_name;
                /*
                 * 年齢
                 */
                sheetView.Cells[2, columnNumber].Font = new Font("Yu Gothic UI", 9);
                sheetView.Cells[2, columnNumber].Value = new Date().GetStaffAge(staffMasterVo.Birth_date.Date);

                columnNumber++;
                recordNumber++;
            }
            sheetView.FrozenColumnCount = 2; // 固定列を指定する
        }

        /// <summary>
        /// SetRowHeader
        /// Rowに資格名の一覧を作成する
        /// </summary>
        private void SetRowHeader(SheetView sheetView) {
            int rowNo = startRowNumber;
            // Rowを初期化します。初期化済だった場合はCountがゼロになるからエラーが出る。
            if(sheetView.Rows.Count > startRowNumber)
                sheetView.RemoveRows(startRowNumber, sheetView.Rows.Count - startRowNumber);
            // _listCertificationLedgerVoの要素数分Rowを作成する
            _listCertificationMasterVo = _certificationDao.SelectAllCertificationMasterVo();
            sheetView.Rows.Add(rowNo, _listCertificationMasterVo.Count);
            foreach(var certificationMasterVo in _listCertificationMasterVo) {
                sheetView.Rows[rowNo].BackColor = certificationMasterVo.Certification_code > 100 && certificationMasterVo.Certification_code < 200 ? Color.WhiteSmoke : Color.White; // 100～199は運転免許証関連のコード
                sheetView.Cells[rowNo, 0].Font = new Font("HP Simplified", 9);
                sheetView.Cells[rowNo, 0].Text = certificationMasterVo.Certification_code.ToString();
                sheetView.Cells[rowNo, 1].Font = new Font("Yu Gothic UI", 10);
                sheetView.Cells[rowNo, 1].Tag = certificationMasterVo;
                sheetView.Cells[rowNo, 1].Text = certificationMasterVo.Certification_display_name;

                rowNo++;
            }
            sheetView.FrozenRowCount = 3; // 固定行を指定する
        }

        /// <summary>
        /// SheetViewListOutPut
        /// 各ヘッダにObjectが入っているCellのみを対象とするように作成
        /// </summary>
        /// <param name="sheetView"></param>
        private void SheetViewListOutPut(SheetView sheetView) {
            StaffMasterVo staffMasterVo;
            CertificationMasterVo certificationMasterVo;

            SpreadList.SuspendLayout(); // Spread 非活性化
            for(int col = startColumnNumber; col < sheetView.ColumnCount; col++) {
                staffMasterVo = (StaffMasterVo)sheetView.Cells[1, col].Tag;
                if(staffMasterVo != null) {
                    // 車両関係
                    LicenseMasterVo licenseMasterVo = _listLicenseMasterVo.Find(x => x.Staff_code == staffMasterVo.Staff_code);
                    if(licenseMasterVo != null) {
                        // 大型
                        sheetView.Cells[startRowNumber, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber, col].Text = licenseMasterVo.Large ? "〇" : "";
                        sheetView.Cells[startRowNumber, col].VerticalAlignment = CellVerticalAlignment.Center;
                        // 中型
                        sheetView.Cells[startRowNumber + 1, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber + 1, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber + 1, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber + 1, col].Text = licenseMasterVo.Medium ? "〇" : "";
                        sheetView.Cells[startRowNumber + 1, col].VerticalAlignment = CellVerticalAlignment.Center;
                        // 準中型
                        sheetView.Cells[startRowNumber + 2, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber + 2, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber + 2, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber + 2, col].Text = licenseMasterVo.Quasi_medium ? "〇" : "";
                        sheetView.Cells[startRowNumber + 2, col].VerticalAlignment = CellVerticalAlignment.Center;
                        // 普通
                        sheetView.Cells[startRowNumber + 3, col].ForeColor = Color.Red;
                        sheetView.Cells[startRowNumber + 3, col].Font = new Font("Yu Gothic UI", 12);
                        sheetView.Cells[startRowNumber + 3, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                        sheetView.Cells[startRowNumber + 3, col].Text = licenseMasterVo.Ordinary ? "〇" : "";
                        sheetView.Cells[startRowNumber + 3, col].VerticalAlignment = CellVerticalAlignment.Center;
                    }
                    // 車両関係から下
                    for(int row = startRowNumber + 4; row < sheetView.RowCount; row++) {
                        certificationMasterVo = (CertificationMasterVo)sheetView.Cells[row, 1].Tag;
                        CertificationFileVo certificationFileVo = _listCertificationFileVo.Find(x => x.Staff_code == staffMasterVo.Staff_code && x.Certification_code == certificationMasterVo.Certification_code);
                        if(certificationFileVo != null) {
                            sheetView.Cells[row, col].Font = new Font("メイリオ", 14);
                            sheetView.Cells[row, col].ForeColor = Color.Blue;
                            sheetView.Cells[row, col].HorizontalAlignment = CellHorizontalAlignment.Center;
                            sheetView.Cells[row, col].Text = _arrayMark[certificationFileVo.Mark_code];
                            sheetView.Cells[row, col].VerticalAlignment = CellVerticalAlignment.Center;
                        } else {
                            sheetView.Cells[row, col].Text = "";
                        }
                    }
                }
            }
            SpreadList.ResumeLayout(); // Spread 活性化
        }

        /// <summary>
        /// SpreadList_CellClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellClick(object sender, CellClickEventArgs e) {
            // Clickの範囲を調査
            if(e.Column >= startColumnNumber && e.Column < startColumnNumber + _listStaffMasterVo.Count && e.Row >= startRowNumber + 4) {
                StaffMasterVo staffMasterVo = (StaffMasterVo)((FpSpread)sender).ActiveSheet.Cells[1, e.Column].Tag;
                CertificationMasterVo certificationLedgerVo = (CertificationMasterVo)((FpSpread)sender).ActiveSheet.Cells[e.Row, 1].Tag;
                ToolStripStatusLabelStatus.Text = string.Concat(staffMasterVo.Display_name, "  ", certificationLedgerVo.Certification_display_name);
            } else {
                ToolStripStatusLabelStatus.Text = "範囲外をクリックしました";
                // Click操作をキャンセルする
                e.Cancel = true;
            }
        }

        /// <summary>
        /// SpreadList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadList_CellDoubleClick(object sender, CellClickEventArgs e) {
            // DoubleClickの範囲を調査
            if(e.Column >= startColumnNumber && e.Column < startColumnNumber + _listStaffMasterVo.Count && e.Row >= startRowNumber + 4) {
                // Shiftが押された場合
                if((ModifierKeys & Keys.Shift) == Keys.Shift) {
                    StaffMasterVo staffMasterVo = (StaffMasterVo)((FpSpread)sender).ActiveSheet.Cells[1, e.Column].Tag;
                    CertificationMasterVo certificationLedgerVo = (CertificationMasterVo)((FpSpread)sender).ActiveSheet.Cells[e.Row, 1].Tag;
                    // SQLはレコードがあればDELETE、無ければINSERT
                    try {
                        _certificationDao.UpdateOneCertificationFile(staffMasterVo, certificationLedgerVo, 2);
                        ToolStripStatusLabelStatus.Text = "更新に成功しました。";
                    } catch(Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    // 最新化ボタンをクリックする
                    ButtonUpdate.PerformClick();
                } else {
                    ToolStripStatusLabelStatus.Text = "登録する場合は”Shift”＋ダブルクリック";
                }
            } else {
                ToolStripStatusLabelStatus.Text = "範囲外をダブルクリックしました";
                // DoubleClick操作をキャンセルする
                e.Cancel = true;
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
        /// CertificationList_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CertificationList_FormClosing(object sender, FormClosingEventArgs e) {
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