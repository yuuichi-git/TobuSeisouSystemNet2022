/*
 * 2022/08/21
 */
using System.Data;

using Accounting;

using Car;

using CarAccident;

using Certification;

using Common;

using CommuterInsurance;

using License;

using Production;

using RollCall;

using Staff;

using StaffDetail;

using Toukanpo;

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
            LabelPcName.Text = string.Concat("〇 PC-Name：", Environment.MachineName);
            LabelIpAddress.Text = string.Concat("〇 IP-Address：", new Ip().GetIpAddress());
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
                            /*
                             * RollCallRecordBook
                             * 点呼記録簿
                             */
                            case "RollCallRecordBook":
                                var rollCallRecordBook = new RollCallRecordBook(_connectionVo);
                                rollCallRecordBook.Show(this);
                                break;
                            /*
                             * 東環保研修センター　修了書
                             */
                            case "ToukanpoTrainingCardDetail":
                                var toukanpoTrainingCardDetail = new ToukanpoTrainingCardDetail(_connectionVo);
                                toukanpoTrainingCardDetail.Show(this);
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

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
             if(_connectionVo.Connection.State == ConnectionState.Open) {
                switch(e.Node.Name) {
                    case "NodeISO0000": // 環境マネジメントマニュアル
                        break;
                    case "NodeISO0100": // 目的
                        break;
                    case "NodeISO0200": // 適用範囲
                        break;
                    case "NodeISO0300": // 用語の定義
                        break;
                    case "NodeISO0400": // 当社をとりまく状況の理解
                        break;
                    case "NodeISO0410": // 外部及び内部の課題
                        break;
                    case "NodeISO0420": // 利害関係者のニーズ及び期待
                        break;
                    case "NodeISO0430": // 環境マネジメントシステムの範囲
                        break;
                    case "NodeISO0440": // 環境マネジメントシステムの概要
                        break;
                    case "NodeISO0500": // リーダーシップ
                        break;
                    case "NodeISO0510": // リーダーシップ及びコミットメント
                        break;
                    case "NodeISO0520": // 環境方針
                        break;
                    case "NodeISO0530": // 役割、責任及び権限
                        break;
                    case "NodeISO0600": // 計画
                        break;
                    case "NodeISO0610": // リスク及び機会への取組み
                        break;
                    case "NodeISO0611": // リスク及び機会の決定
                        break;
                    case "NodeISO0612": // 環境側面
                        break;
                    case "NodeISO0613": // 順守義務(法的及びその他の要求事項)
                        break;
                    case "NodeISO0614": // 取組みの計画策定
                        break;
                    case "NodeISO0620": // 環境目標及びプログラム 
                        break;
                    case "NodeISO0700": // 支援(サポート)
                        break;
                    case "NodeISO0710": // 資源
                        break;
                    case "NodeISO0720": // 力量、教育訓練
                        break;
                    case "NodeISO0721": // 力量(有資格者)
                        CertificationList certificationList = new CertificationList(_connectionVo);
                        certificationList.Show(this);
                        break;
                    case "NodeISO0722": // 教育訓練 
                        break;
                    case "NodeISO0730": // 認識
                        break;
                    case "NodeISO0740": // コミュニケーション
                        break;
                    case "NodeISO0750": // 文章管理
                        break;
                    case "NodeISO0800": // 運用
                        break;
                    case "NodeISO0810": // 運用の計画及び管理
                        break;
                    case "NodeISO0820": // 緊急事態への準備及び対応
                        break;
                    case "NodeISO0821": // 緊急事態の可能性の特定
                        break;
                    case "NodeISO0822": // 緊急事態対応手順書の作成
                        break;
                    case "NodeISO0823": // 緊急事態対応訓練(対応手順のテスト)
                        break;
                    case "NodeISO0824": // 手順書の見直し
                        break;
                    case "NodeISO0825": // 取引先を含む利害関係者への情報提供
                        break;
                    case "NodeISO0900": // パフォーマンス評価
                        break;
                    case "NodeISO0910": // 監視、測定、分析及び評価
                        break;
                    case "NodeISO0911": // 取組み項目の監視、測定
                        break;
                    case "NodeISO0912": // 順守評価(法的及びその他の要求事項)
                        break;
                    case "NodeISO0920": // 内部監査
                        break;
                    case "NodeISO0930": // 経営層による見直し(マネジメントレビュー)
                        break;
                    case "NodeISO1000": // 改善
                        break;
                    case "NodeISO1010": // 一般
                        break;
                    case "NodeISO1020": // 不適合への対応
                        break;
                    case "NodeISO1030": // 継続的改善
                        break;
                    case "NodeTreatmentPlant": // 中間処理場
                        break;
                    default:
                        break;
                }
            } else {
            }
        }
    }
}