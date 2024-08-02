/*
 * 2024-07-30
 */
using System.Drawing.Printing;

using FarPoint.Win.Spread;

using Vo;

namespace H_DailyReport {
    public partial class DriversReport : Form {

        /// <summary>
        /// コンストラクター(未記入の日報用)
        /// </summary>
        /// <param name="connectionVo"></param>
        public DriversReport(ConnectionVo connectionVo) {
            InitializeComponent();
            this.InitializeSheetView();
            this.InitializeSheetView(SheetViewDriversReport);
        }

        /// <summary>
        /// コンストラクター(各種データ入力済の日報用)
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hControlVo"></param>
        public DriversReport(ConnectionVo connectionVo, H_ControlVo hControlVo) {
            InitializeComponent();
            this.InitializeSheetView();
            this.InitializeSheetView(SheetViewDriversReport, hControlVo);
        }

        /// <summary>
        /// 運転日報をB5で印刷
        /// 用紙の設定とシート全体を印刷する設定ができてない
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * B5で印刷する
                 */
                case "ToolStripMenuItemPrintB5":
                    PrintDocument printDocument = new();
                    printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                    // 出力先プリンタを指定します。
                    printDocument.PrinterSettings.PrinterName = "FUJI XEROX ApeosPort C5570";
                    // 用紙の向きを設定(横：true、縦：false)
                    printDocument.DefaultPageSettings.Landscape = false;
                    /*
                     * プリンタがサポートしている用紙サイズを調べる
                     */
                    foreach (PaperSize paperSize in printDocument.PrinterSettings.PaperSizes) {
                        // A4用紙に設定する
                        if (paperSize.Kind == PaperKind.B5) {
                            printDocument.DefaultPageSettings.PaperSize = paperSize;
                            break;
                        }
                    }
                    // 印刷部数を指定します。
                    printDocument.PrinterSettings.Copies = 1;
                    // 片面印刷に設定します。
                    printDocument.PrinterSettings.Duplex = Duplex.Default;
                    // カラー印刷に設定します。
                    printDocument.PrinterSettings.DefaultPageSettings.Color = true;
                    // 印刷する
                    printDocument.Print();
                    ///*
                    // * 印刷を実行します
                    // */
                    //SpreadDriversReport.PrintSheet(SheetViewDriversReport);
                    break;
                /*
                 * アプリケーションを終了する
                 */
                case "ToolStripMenuItemExit":
                    Close();
                    break;
            }
        }

        /// <summary>
        /// 運転日報を印刷する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            // 印刷ページ（1ページ目）の描画を行う
            Rectangle rectangle = new(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
            // e.Graphicsへ出力(page パラメータは、０からではなく１から始まります)
            SpreadDriversReport.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
            // 印刷終了を指定
            e.HasMorePages = false;
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        private void InitializeSheetView() {
            // 年表示を設定する
            this.HNumericUpDownExYear.Value = 6;
            // タブストリップボタンを必要に応じて表示します。
            SpreadDriversReport.TabStripPolicy = TabStripPolicy.Never;
            /*
             * セルを初期化する
             */
            SheetViewDriversReport.Cells[3, 17].Text = string.Empty; // 配車先
            SheetViewDriversReport.Cells[3, 23].Text = string.Empty; // 組名
            SheetViewDriversReport.Cells[5, 1].Text = string.Empty; // 運転者氏名
            SheetViewDriversReport.Cells[5, 9].Text = string.Empty; // 交代運転者氏名
            SheetViewDriversReport.Cells[8, 1].Text = string.Empty; // ドア番号
            SheetViewDriversReport.Cells[8, 6].Text = string.Empty; // 登録番号
            SheetViewDriversReport.Cells[10, 17].Text = string.Empty; // 休憩場所

            SheetViewDriversReport.Cells[12, 3].Text = string.Empty; // 運搬先名①
            SheetViewDriversReport.Cells[12, 8].Text = string.Empty; // 正味重量①
            SheetViewDriversReport.Cells[13, 3].Text = string.Empty; // 運搬先名②
            SheetViewDriversReport.Cells[13, 8].Text = string.Empty; // 正味重量②
            SheetViewDriversReport.Cells[14, 3].Text = string.Empty; // 運搬先名③
            SheetViewDriversReport.Cells[14, 8].Text = string.Empty; // 正味重量③
            SheetViewDriversReport.Cells[15, 3].Text = string.Empty; // 運搬先名④
            SheetViewDriversReport.Cells[15, 8].Text = string.Empty; // 正味重量④
            SheetViewDriversReport.Cells[12, 17].Text = string.Empty; // 運搬先名⑤
            SheetViewDriversReport.Cells[12, 22].Text = string.Empty; // 正味重量⑤
            SheetViewDriversReport.Cells[13, 17].Text = string.Empty; // 運搬先名⑥
            SheetViewDriversReport.Cells[13, 22].Text = string.Empty; // 正味重量⑥
            SheetViewDriversReport.Cells[14, 17].Text = string.Empty; // 運搬先名⑦
            SheetViewDriversReport.Cells[14, 22].Text = string.Empty; // 正味重量⑦
            SheetViewDriversReport.Cells[15, 17].Text = string.Empty; // 運搬先名⑧
            SheetViewDriversReport.Cells[15, 22].Text = string.Empty; // 正味重量⑧
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        /// <param name="sheetView"></param>
        /// <returns>SheetView</returns>
        private void InitializeSheetView(SheetView sheetView) {
            // タブストリップボタンを必要に応じて表示します。
            SpreadDriversReport.TabStripPolicy = TabStripPolicy.Never;
        }

        /// <summary>
        /// InitializeSheetView
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="hControlVo"></param>
        /// <returns></returns>
        private void InitializeSheetView(SheetView sheetView, H_ControlVo hControlVo) {
            // タブストリップボタンを必要に応じて表示します。
            SpreadDriversReport.TabStripPolicy = TabStripPolicy.Never;
            // 各種値の取得
            SheetViewDriversReport.Cells[3, 17].Text = hControlVo.HSetMasterVo.SetName1; // 配車先
            SheetViewDriversReport.Cells[3, 23].Text = hControlVo.HSetMasterVo.SetName2; // 組名
            SheetViewDriversReport.Cells[5, 1].Text = hControlVo.ListHStaffMasterVo is not null ? hControlVo.ListHStaffMasterVo[0].OtherName : string.Empty; // 運転者氏名
            SheetViewDriversReport.Cells[8, 1].Text = hControlVo.HCarMasterVo is not null ? hControlVo.HCarMasterVo.DoorNumber.ToString() : string.Empty; // ドア番号
            SheetViewDriversReport.Cells[8, 6].Text = hControlVo.HCarMasterVo is not null ? hControlVo.HCarMasterVo.RegistrationNumber : string.Empty; // 登録番号
            switch (hControlVo.HSetMasterVo.SetCode) {
                case 1311706: // 北区粗大軽
                    SheetViewDriversReport.Cells[3, 23].Text = "粗大軽 / 資源"; // 組名
                    SheetViewDriversReport.Cells[10, 17].Text = "浮間清掃事業所 /"; // 休憩場所
                    break;
                case 1311707: // 北区粗大１
                case 1311708: // 北区粗大２
                case 1311709: // 北区粗大３
                case 1311710: // 北区粗大４
                case 1311711: // 北区粗大５
                case 1311715: // 北区粗大対策
                    SheetViewDriversReport.Cells[3, 23].Text = "粗大　　組"; // 組名
                    SheetViewDriversReport.Cells[10, 17].Text = "浮間清掃事業所 /"; // 休憩場所
                    SheetViewDriversReport.Cells[12, 3].Text = "浮間清掃事業所"; // 運搬先名①
                    SheetViewDriversReport.Cells[13, 3].Text = "浮間清掃事業所"; // 運搬先名②
                    SheetViewDriversReport.Cells[14, 3].Text = "浮間清掃事業所"; // 運搬先名③
                    break;
                case 1310602: // 台東資源１
                case 1310603: // 台東資源２
                case 1310607: // 台東資源４
                    SheetViewDriversReport.Cells[10, 17].Text = "清川車庫 /"; // 休憩場所
                    break;
                case 1310801: // 江東１（新大）
                case 1310802: // 江東４（新大）
                case 1310815: // 江東４（小プ）
                case 1310816: // 江東１１（新大）
                case 1310817: // 江東８（新大）
                    SheetViewDriversReport.Cells[10, 17].Text = "江東区清掃事務所 /"; // 休憩場所
                    break;
                case 1311902: // 板橋西軽１
                case 1311903: // 板橋西軽２
                case 1311904: // 板橋西軽３
                    SheetViewDriversReport.Cells[10, 17].Text = "西台中継所/板橋工場 /"; // 休憩場所
                    break;
                case 1312013: // 石神井不燃５
                    SheetViewDriversReport.Cells[10, 17].Text = "田中駐車場 /"; // 休憩場所
                    break;
                case 1312161: // 足立１６
                case 1312162: // 足立２２
                case 1312164: // 足立２３(２０２４)
                case 1312163: // 足立３７
                case 1312105: // 足立不燃４
                    SheetViewDriversReport.Cells[10, 17].Text = "足立工場 /"; // 休憩場所
                    break;
                case 1312212: // 小岩６
                    SheetViewDriversReport.Cells[10, 17].Text = "小岩清掃事務所 駐車場 /"; // 休憩場所
                    SheetViewDriversReport.Cells[11, 8].Text = "搬　入　時　刻";
                    SheetViewDriversReport.Cells[11, 22].Text = "搬　入　時　刻";
                    SheetViewDriversReport.Cells[12, 8].Text = "："; // 正味重量①
                    SheetViewDriversReport.Cells[13, 8].Text = "："; // 正味重量②
                    SheetViewDriversReport.Cells[14, 8].Text = "："; // 正味重量③
                    SheetViewDriversReport.Cells[15, 8].Text = "："; // 正味重量④
                    SheetViewDriversReport.Cells[12, 22].Text = "："; // 正味重量⑤
                    SheetViewDriversReport.Cells[13, 22].Text = "："; // 正味重量⑥
                    SheetViewDriversReport.Cells[14, 22].Text = "："; // 正味重量⑦
                    SheetViewDriversReport.Cells[15, 22].Text = "："; // 正味重量⑧
                    break;
                case 1310417: // 新宿２－５１
                    SheetViewDriversReport.Cells[10, 17].Text = "新宿清掃事務所　駐車場 /"; // 休憩場所
                    break;

            }
        }

        /// <summary>
        /// 年度を変更する　
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HNumericUpDownExYear_ValueChanged(object sender, EventArgs e) {
            SheetViewDriversReport.Cells[2, 1].Text = string.Concat("令和　", HNumericUpDownExYear.Value, "年　　　　月　　　　日　　　　曜日　天候"); // 日付
        }

        /// <summary>
        /// DriversReport_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DriversReport_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}
