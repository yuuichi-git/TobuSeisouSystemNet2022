/*
 * 2022/08/21
 */
using System.Data;

using Accounting;

using Car;

using CarAccident;

using Common;

using CommuterInsurance;

using License;

using Production;

using Staff;

using StaffDetail;

using VehicleDispatch;

using VehicleDispatchSheet;

using Vo;

namespace TobuSeisouSystemNet2022 {
    public partial class StartProject : Form {
        /// <summary>
        /// ConnectionVo
        /// </summary>
        private readonly ConnectionVo _connectionVo = new();

        public StartProject() {
            InitializeComponent();
            new InitializeForm().StartProject(this);
            NotifyIcon1.Visible = true;
        }

        /// <summary>
        /// データベース接続
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDbConnect_Click(object sender, EventArgs e) {
            try {
                _connectionVo.Connect();
                ((Button)sender).Enabled = false;
                LabelServerName.Text = string.Concat("　接続先サーバー：", _connectionVo.Connection.DataSource);
                LabelDbName.Text = string.Concat("　接続先データベース：", _connectionVo.Connection.Database);
                LabelConnectStatus.Text = string.Concat("　状態：", _connectionVo.Connection.State);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message, MessageText.Message501, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Label_Click(object sender, EventArgs e) {
            if(_connectionVo.Connection != null) {
                switch(_connectionVo.Connection.State) {
                    case ConnectionState.Closed: //接続が閉じています。
                        break;
                    case ConnectionState.Open: //接続が開いています。
                        switch((string)((Label)sender).Tag) {
                            // VehicleDispatch
                            case "VehicleDispatch":
                                var vehicleDispatchBoad = new VehicleDispatchBoad(_connectionVo);
                                vehicleDispatchBoad.Show(this);
                                break;
                            // VehicleDispatchSheetBoad
                            case "VehicleDispatchSheetBoad":
                                var vehicleDispatchSheetBoad = new VehicleDispatchSheetBoad(_connectionVo);
                                vehicleDispatchSheetBoad.Show(this);
                                break;
                            // ProductionCleanOfficeList
                            case "ProductionCleanOfficeList":
                                var productionCleanOfficeList = new ProductionList(_connectionVo, "ProductionCleanOfficeList");
                                productionCleanOfficeList.Show(this);
                                break;
                            // ProductionList
                            case "ProductionOfficeList":
                                var productionOfficeList = new ProductionList(_connectionVo, "ProductionOfficeList");
                                productionOfficeList.Show(this);
                                break;
                            // StaffList
                            case "StaffList":
                                var staffList = new StaffList(_connectionVo);
                                staffList.Show(this);
                                break;
                            // LicenseList
                            case "LicenseList":
                                var licenseList = new LicenseList(_connectionVo);
                                licenseList.Show(this);
                                break;
                            default:
                                break;
                            // CarAccidentList
                            case "CarAccidentList":
                                var carAccidentList = new CarAccidentList(_connectionVo);
                                carAccidentList.Show(this);
                                break;
                            // CarList
                            case "CarList":
                                var carList = new CarList(_connectionVo);
                                carList.Show(this);
                                break;
                            // CommuterInsuranceList
                            case "CommuterInsuranceList":
                                var commuterInsuranceList = new CommuterInsuranceList(_connectionVo);
                                commuterInsuranceList.Show(this);
                                break;
                            // StaffExcel
                            case "StaffExcel":
                                var staffExcel = new StaffExcel(_connectionVo);
                                staffExcel.Show(this);
                                break;
                            // StaffPartTimeDetail
                            case "AccountingParttimeList":
                                var accountingParttimeList = new AccountingParttimeList(_connectionVo);
                                accountingParttimeList.Show(this);
                                break;
                        }
                        break;
                    case ConnectionState.Connecting: //接続オブジェクトがデータ ソースに接続しています。
                        break;
                    case ConnectionState.Executing: //接続オブジェクトがコマンドを実行しています。
                        break;
                    case ConnectionState.Fetching: //接続オブジェクトがデータを検索しています。
                        break;
                    case ConnectionState.Broken: //データ ソースへの接続が断絶しています。
                        break;
                }
            } else {
                MessageBox.Show(MessageText.Message502, MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Red;
        }

        private void Label_MouseLeave(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Black;
        }

        /// <summary>
        /// ToolStripMenuItemStartProject_Click
        /// タスクバーに入れる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemStartProject_Click(object sender, EventArgs e) {
            this.Visible = true;
        }

        /// <summary>
        /// ToolStripMenuItemTaskBar_Click
        /// Windowを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemTaskBar_Click(object sender, EventArgs e) {
            this.Visible = false;
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
        /// StartProject_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartProject_FormClosing(object sender, FormClosingEventArgs e) {
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