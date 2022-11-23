using System.Drawing.Printing;

using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace CarRegister {
    public partial class CarPaper : Form {
        private InitializeForm _initializeForm = new();
        private readonly ConnectionVo _connectionVo;

        public CarPaper(ConnectionVo connectionVo, int carCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            // Form初期化
            InitializeForm();
            SpreadOutput(SheetViewCar, new CarMasterDao(_connectionVo).SelectOneCarMaster(carCode));
        }

        private void InitializeForm() {
            // Formの表示サイズを初期化
            _initializeForm.CarPaper(this);
            // Spread初期化
            InitializeSpreadCarLedger(SheetViewCar);
            ToolStripStatusLabelDetail.Text = "";
        }

        /// <summary>
        /// SpreadOutput
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="carMasterVo"></param>
        public void SpreadOutput(SheetView sheetView, CarMasterVo carMasterVo) {
            SpreadCar.SuspendLayout();
            // No
            sheetView.Cells[0, 0].Text = "";
            // 作成年月日
            sheetView.Cells[0, 6].Value = DateTime.Now;
            // 自動車登録番号又は車両番号
            sheetView.Cells[2, 0].Text = carMasterVo.Registration_number;
            // 登録年月日/交付年月日
            sheetView.Cells[2, 1].Value = carMasterVo.Registration_date;
            // 初年度登録
            sheetView.Cells[2, 2].Value = carMasterVo.First_registration_date;
            // 自家用・事業用の別
            sheetView.Cells[2, 3].Text = carMasterVo.Other_name;
            // 乗車定員
            sheetView.Cells[2, 4].Text = carMasterVo.Capacity.ToString();
            // 最大積載量
            sheetView.Cells[2, 6].Text = carMasterVo.Maximum_load_capacity.ToString();
            // 車名
            sheetView.Cells[4, 0].Text = carMasterVo.Manufacturer_name;
            // 車体の形状
            sheetView.Cells[4, 1].Text = carMasterVo.Shape_name;
            // 自動車の種類
            sheetView.Cells[4, 2].Text = carMasterVo.Car_kind_name;
            // 用途
            sheetView.Cells[4, 3].Text = carMasterVo.Car_use;
            // 車両重量
            sheetView.Cells[4, 4].Text = carMasterVo.Vehicle_weight.ToString("##,##0");
            // 車両総重量
            sheetView.Cells[4, 6].Text = carMasterVo.Total_vehicle_weight.ToString("##,##0");
            // 車台番号
            sheetView.Cells[6, 0].Text = carMasterVo.Vehicle_number;
            // 原動機の型式
            sheetView.Cells[6, 1].Text = carMasterVo.Motor_version;
            // 型式
            sheetView.Cells[6, 2].Text = carMasterVo.Version;
            // 燃料の種類
            sheetView.Cells[6, 3].Text = carMasterVo.Types_of_fuel;
            // 長さ
            sheetView.Cells[6, 4].Text = carMasterVo.Length.ToString("##,##0");
            // 幅
            sheetView.Cells[6, 6].Text = carMasterVo.Width.ToString("##,##0");
            // 所有者の氏名又は名称
            sheetView.Cells[7, 1].Text = carMasterVo.Owner_name;
            // 型式指定番号
            sheetView.Cells[8, 2].Text = carMasterVo.Version_designate_number;
            // 類別区分番号
            sheetView.Cells[8, 3].Text = carMasterVo.Category_distinguish_number;
            // 高さ
            sheetView.Cells[8, 4].Text = carMasterVo.Height.ToString("##,##0");
            // 総排気量又は定格出力
            sheetView.Cells[8, 6].Text = carMasterVo.Total_displacement.ToString("##.00");
            // 所有者の住所
            sheetView.Cells[8, 1].Text = carMasterVo.Owner_address;
            // 使用者の氏名又は名称
            sheetView.Cells[9, 1].Text = carMasterVo.User_name;
            // 備考
            sheetView.Cells[10, 2].Text = carMasterVo.Remarks;
            // 前前軸重
            sheetView.Cells[10, 4].Text = carMasterVo.Ff_axis_weight.ToString("#,##0");
            // 前後軸重
            sheetView.Cells[10, 6].Text = carMasterVo.Fr_axis_weight.ToString("#,##0");
            // 使用者の住所
            sheetView.Cells[10, 1].Text = carMasterVo.User_address;
            // 使用の本拠の位置
            sheetView.Cells[11, 1].Text = carMasterVo.Base_address;
            // 後前軸重
            sheetView.Cells[12, 4].Text = carMasterVo.Rf_axis_weight.ToString("#,##0");
            // 後後軸重
            sheetView.Cells[12, 6].Text = carMasterVo.Rr_axis_weight.ToString("#,##0");
            // 有効期限の満了する日1
            sheetView.Cells[13, 0].Value = carMasterVo.Expiration_date;
            sheetView.Cells[13, 1].Text = "";//
            SpreadCar.ResumeLayout(true);
            // 車検証画像
            if(carMasterVo.Picture.Length != 0) {
                var imageConv = new ImageConverter();
                PictureBox1.Image = (Image?)imageConv.ConvertFrom(carMasterVo.Picture);
            } else {
                PictureBox1.Image = null;
            }
        }

        /// <summary>
        /// InitializeSpreadCarLedger
        /// </summary>
        /// <param name="sheetView"></param>
        private void InitializeSpreadCarLedger(SheetView sheetView) {
            SpreadCar.SuspendLayout();
            // シート名タブが常時表示されるように設定します。
            SpreadCar.TabStripPolicy = TabStripPolicy.Never;
            sheetView.Cells[0, 0].Text = "";//NO
            sheetView.Cells[0, 6].Text = "";//作成年月日
            sheetView.Cells[2, 0].Text = "";//自動車登録番号又は車両番号
            sheetView.Cells[2, 1].Text = "";//登録年月日/交付年月日  
            sheetView.Cells[2, 2].Text = "";//初年度登録    
            sheetView.Cells[2, 3].Text = "";//自家用・事業用の別
            sheetView.Cells[2, 4].Text = "";//乗車定員
            sheetView.Cells[2, 6].Text = "";//最大積載量
            sheetView.Cells[4, 0].Text = "";//車名
            sheetView.Cells[4, 1].Text = "";//車体の形状
            sheetView.Cells[4, 2].Text = "";//自動車の種類
            sheetView.Cells[4, 3].Text = "";//用途
            sheetView.Cells[4, 4].Text = "";//車両重量
            sheetView.Cells[4, 6].Text = "";//車両総重量
            sheetView.Cells[6, 0].Text = "";//車台番号
            sheetView.Cells[6, 1].Text = "";//原動機の型式
            sheetView.Cells[6, 2].Text = "";//型式
            sheetView.Cells[6, 3].Text = "";//燃料の種類
            sheetView.Cells[6, 4].Text = "";//長さ
            sheetView.Cells[6, 6].Text = "";//幅
            sheetView.Cells[7, 1].Text = "";//所有者の氏名又は名称
            sheetView.Cells[8, 2].Text = "";//型式指定番号
            sheetView.Cells[8, 3].Text = "";//類別区分番号
            sheetView.Cells[8, 4].Text = "";//高さ
            sheetView.Cells[8, 6].Text = "";//総排気量又は定格出力
            sheetView.Cells[8, 1].Text = "";//所有者の住所
            sheetView.Cells[9, 1].Text = "";//使用者の氏名又は名称
            sheetView.Cells[10, 2].Text = "";//備考
            sheetView.Cells[10, 4].Text = "";//前前軸重
            sheetView.Cells[10, 6].Text = "";//前後軸重
            sheetView.Cells[10, 1].Text = "";//使用者の住所
            sheetView.Cells[11, 1].Text = "";//使用の本拠の位置
            sheetView.Cells[12, 4].Text = "";//後前軸重
            sheetView.Cells[12, 6].Text = "";//後後軸重
            sheetView.Cells[13, 0].Text = "";//有効期限の満了する日1
            sheetView.Cells[13, 1].Text = "";//
            sheetView.Cells[14, 0].Text = "";//有効期限の満了する日2
            sheetView.Cells[14, 1].Text = "";//
            sheetView.Cells[15, 0].Text = "";//有効期限の満了する日3
            sheetView.Cells[15, 1].Text = "";//
            sheetView.Cells[16, 0].Text = "";//有効期限の満了する日4
            sheetView.Cells[16, 1].Text = "";//
            sheetView.Cells[17, 0].Text = "";//有効期限の満了する日5
            sheetView.Cells[17, 1].Text = "";//
            sheetView.Cells[18, 0].Text = "";//有効期限の満了する日6
            sheetView.Cells[18, 1].Text = "";//
            sheetView.Cells[19, 0].Text = "";//有効期限の満了する日7
            sheetView.Cells[19, 1].Text = "";//
            //損害賠償責任保険
            sheetView.Cells[15, 3].Text = "";//加入年月日1
            sheetView.Cells[15, 4].Text = "";//期限
            sheetView.Cells[15, 5].Text = "";//契約先
            sheetView.Cells[15, 6].Text = "";//保険証番号
            sheetView.Cells[15, 7].Text = "";//月数
            sheetView.Cells[16, 3].Text = "";//加入年月日2
            sheetView.Cells[16, 4].Text = "";//期限
            sheetView.Cells[16, 5].Text = "";//契約先
            sheetView.Cells[16, 6].Text = "";//保険証番号
            sheetView.Cells[16, 7].Text = "";//月数
            sheetView.Cells[17, 3].Text = "";//加入年月日3
            sheetView.Cells[17, 4].Text = "";//期限
            sheetView.Cells[17, 5].Text = "";//契約先
            sheetView.Cells[17, 6].Text = "";//保険証番号
            sheetView.Cells[17, 7].Text = "";//月数
            sheetView.Cells[18, 3].Text = "";//加入年月日4
            sheetView.Cells[18, 4].Text = "";//期限
            sheetView.Cells[18, 5].Text = "";//契約先
            sheetView.Cells[18, 6].Text = "";//保険証番号
            sheetView.Cells[18, 7].Text = "";//月数
            sheetView.Cells[19, 3].Text = "";//加入年月日5
            sheetView.Cells[19, 4].Text = "";//期限
            sheetView.Cells[19, 5].Text = "";//契約先
            sheetView.Cells[19, 6].Text = "";//保険証番号
            sheetView.Cells[19, 7].Text = "";//月数
            //配置営業所
            sheetView.Cells[22, 0].Text = "";//配置年月日1
            sheetView.Cells[22, 1].Text = "";//営業所名
            sheetView.Cells[22, 2].Text = "";//転出先
            sheetView.Cells[23, 0].Text = "";//配置年月日2
            sheetView.Cells[23, 1].Text = "";//営業所名
            sheetView.Cells[23, 2].Text = "";//転出先
            sheetView.Cells[24, 0].Text = "";//配置年月日3
            sheetView.Cells[24, 1].Text = "";//営業所名
            sheetView.Cells[24, 2].Text = "";//転出先
            sheetView.Cells[25, 0].Text = "";//配置年月日4
            sheetView.Cells[25, 1].Text = "";//営業所名
            sheetView.Cells[25, 2].Text = "";//転出先
            sheetView.Cells[26, 0].Text = "";//配置年月日5
            sheetView.Cells[26, 1].Text = "";//営業所名
            sheetView.Cells[26, 2].Text = "";//転出先
            //任意保険
            sheetView.Cells[22, 3].Text = "";//加入年月日
            sheetView.Cells[22, 4].Text = "";//期限
            sheetView.Cells[22, 5].Text = "";//契約先
            sheetView.Cells[22, 6].Text = "";//保険証番号
            sheetView.Cells[22, 7].Text = "";//月数
            sheetView.Cells[23, 3].Text = "";//加入年月日
            sheetView.Cells[23, 4].Text = "";//期限
            sheetView.Cells[23, 5].Text = "";//契約先
            sheetView.Cells[23, 6].Text = "";//保険証番号
            sheetView.Cells[23, 7].Text = "";//月数
            sheetView.Cells[24, 3].Text = "";//加入年月日
            sheetView.Cells[24, 4].Text = "";//期限
            sheetView.Cells[24, 5].Text = "";//契約先
            sheetView.Cells[24, 6].Text = "";//保険証番号
            sheetView.Cells[24, 7].Text = "";//月数
            sheetView.Cells[25, 3].Text = "";//加入年月日
            sheetView.Cells[25, 4].Text = "";//期限
            sheetView.Cells[25, 5].Text = "";//契約先
            sheetView.Cells[25, 6].Text = "";//保険証番号
            sheetView.Cells[25, 7].Text = "";//月数
            sheetView.Cells[26, 3].Text = "";//加入年月日
            sheetView.Cells[26, 4].Text = "";//期限
            sheetView.Cells[26, 5].Text = "";//契約先
            sheetView.Cells[26, 6].Text = "";//保険証番号
            sheetView.Cells[26, 7].Text = "";//月数
            SpreadCar.ResumeLayout(true);
        }

        /// <summary>
        /// FpSpreadCarLedger_CellClick
        /// FpSpreadCarLedger_CellDoubleClick
        /// FpSpreadCarLedger上でのClick・DoubleClickをキャンセルする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpSpreadCarLedger_CellClick(object sender, CellClickEventArgs e) {
            e.Cancel = true;
        }

        /// <summary>
        /// ButtonPrint_Click
        /// 印刷する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private PrintDocument? printDocument;
        private void ButtonPrint_Click(object sender, EventArgs e) {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            // 出力先プリンタを指定します。
            //printDocument.PrinterSettings.PrinterName = "(PrinterName)";
            // 印刷部数を指定します。
            printDocument.PrinterSettings.Copies = 1;
            // PrintDocument#DefaultPageSettings.Landscapeにtrue=ヨコ/false=タテを設定
            printDocument.DefaultPageSettings.Landscape = true;
            // 両面印刷に設定します。
            printDocument.PrinterSettings.Duplex = Duplex.Vertical;
            // カラー印刷に設定します。
            printDocument.PrinterSettings.DefaultPageSettings.Color = true;

            printDocument.Print();
        }

        /// <summary>
        /// printDocument_PrintPage
        /// </summary>
        private int curPageNumber = 0; // 現在のページ番号
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            if(curPageNumber == 0) {
                // 印刷ページ（1ページ目）の描画を行う
                var rectangle = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
                // 使用するページ数を計算
                //int cnt = SpreadStaffRegisterHead.GetOwnerPrintPageCount(e.Graphics, rectangle, 0);
                // e.Graphicsへ出力
                SpreadCar.OwnerPrintDraw(e.Graphics, rectangle, 0, 1);
                // 印刷継続を指定
                e.HasMorePages = true;
            } else {
                // 印刷ページ（2ページ目）の描画を行う
                // e.Graphicsへ出力
                e.Graphics?.DrawImage(PictureBox1.Image, 18, 18, 1136, 796);
                // 印刷終了を指定
                e.HasMorePages = false;
            }
            //ページ番号を繰り上げる
            curPageNumber++;
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
