using System.Globalization;

using Common;

using Dao;

using FarPoint.Win.Spread;

using Vo;

namespace SubstituteSheet {
    public partial class SubstituteSheet2 : Form {
        private readonly ConnectionVo _connectionVo;
        private readonly DateTime _operationDate;
        private readonly InitializeForm _initializeForm = new();
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchBodyCleanOfficeDao _vehicleDispatchBodyCleanOfficeDao;
        /*
         * Vo
         */
        private readonly SetMasterVo _setMasterVo;
        private readonly List<CarMasterVo> _listCarMasterVo;
        private readonly List<StaffMasterVo> _listStaffMasterVo;
        private readonly VehicleDispatchDetailVo _vehicleDispatchDetailVo;

        /// <summary>
        /// SubstituteSheet2
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="setCode"></param>
        public SubstituteSheet2(ConnectionVo connectionVo, DateTime operationDate, int cellNumber, int setCode) {
            _operationDate = operationDate;
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchBodyCleanOfficeDao = new VehicleDispatchBodyCleanOfficeDao(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _vehicleDispatchDetailVo = _vehicleDispatchDetailDao.SelectOneVehicleDispatchDetail(operationDate.Date, cellNumber + 1);
            /*
             * コントロール初期化
             */
            InitializeComponent();
            _initializeForm.SubstituteSheet2(this);
            // シートタブを非表示
            SpreadList.TabStripPolicy = TabStripPolicy.Never;
            /*
             * 配車先を読込む
             */
            _setMasterVo = new SetMasterDao(_connectionVo).SelectOneSetMaster(setCode);
            _listCarMasterVo = new CarMasterDao(_connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(_connectionVo).SelectAllStaffMaster();

            InitializeSheetViewPaper();
            PutSheetViewPaper();
        }

        /// <summary>
        /// PutSheetViewPaper
        /// </summary>
        private void PutSheetViewPaper() {
            // 日付
            CultureInfo cultureInfo = new CultureInfo("ja-JP", true);
            // 和暦を設定
            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            // 作成日
            SheetView1.Cells["J3"].Text = DateTime.Now.ToString("gg y年M月d日", cultureInfo);
            // まずは配車先が格納されているCellNumberを取得する
            int cellNumber = _vehicleDispatchDetailDao.GetCellNumber(_vehicleDispatchDetailVo.Set_code);
            /*
             * １
             */
            SheetView1.Cells["H18"].Text = string.Concat(_setMasterVo.Set_name, " 組");
            SheetView1.Cells["K18"].Text = string.Concat(_operationDate.ToString("dddd"));
            /*
             * ２
             * 運転手代番の判定
             */
            int operatorCode1CleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetOperatorCode1(cellNumber);
            // 運転手代番だった場合の処理
            if(_vehicleDispatchDetailVo.Operator_code_1 != 0 && operatorCode1CleanOffice != _vehicleDispatchDetailVo.Operator_code_1) {
                // 運転手名
                SheetView1.Cells["D21"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Display_name;
                // 携帯番号 とりあえず車載携帯がくるまでは個人携帯で登録
                SheetView1.Cells["J21"].Text = _listStaffMasterVo.Find(x => x.Staff_code == _vehicleDispatchDetailVo.Operator_code_1).Cellphone_number;
                // 代番
                SheetView1.Cells["D25"].Text = DateTime.Now.ToString("gg y年M月d日", cultureInfo);
                SheetView1.Cells["I25"].Text = string.Concat(DateTime.Now.ToString("gg y年M月d日", cultureInfo), " 迄");
            }
            /*
             * ３
             * 作業員代番の判定
             */


            /*
             * ４
             * 清掃事務所に登録されている本番車両を取得する
             * 代車の処理
             */
            int carCodeCleanOffice = _vehicleDispatchBodyCleanOfficeDao.GetCarCode(cellNumber);
            // 代車の処理
            if(_vehicleDispatchDetailVo.Car_code != 0 && carCodeCleanOffice != _vehicleDispatchDetailVo.Car_code) {
                SheetView1.Cells["G45"].Text = string.Concat(_listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Registration_number,
                                                                " (" ,
                                                                _listCarMasterVo.Find(x => x.Car_code == _vehicleDispatchDetailVo.Car_code).Door_number,
                                                                ")");
                SheetView1.Cells["D49"].Text = DateTime.Now.ToString("gg y年M月d日", cultureInfo);
                SheetView1.Cells["I49"].Text = string.Concat(DateTime.Now.ToString("gg y年M月d日", cultureInfo), " 迄");
            }
        }

        /// <summary>
        /// InitializeSheetViewPaper
        /// </summary>
        private void InitializeSheetViewPaper() {
            // 作成日付
            SheetView1.Cells["J3"].ResetValue();
            // １-組名・曜日
            SheetView1.Cells["H18"].ResetValue();
            SheetView1.Cells["K18"].ResetValue();
            // ２-運転手名・携帯番号・交代・代番
            SheetView1.Cells["D21"].ResetValue();
            SheetView1.Cells["J21"].ResetValue();
            SheetView1.Cells["D23"].ResetValue();
            SheetView1.Cells["D25"].ResetValue();
            SheetView1.Cells["I25"].ResetValue();
            // ３-作業員名・交代・代番
            SheetView1.Cells["D30"].ResetValue();
            SheetView1.Cells["D33"].ResetValue();
            SheetView1.Cells["H33"].ResetValue();
            SheetView1.Cells["D35"].ResetValue();
            SheetView1.Cells["H35"].ResetValue();
            SheetView1.Cells["D37"].ResetValue();
            SheetView1.Cells["I37"].ResetValue();
            SheetView1.Cells["D40"].ResetValue();
            SheetView1.Cells["H40"].ResetValue();
            SheetView1.Cells["D42"].ResetValue();
            SheetView1.Cells["H42"].ResetValue();
            // ４-収集車両・交代・代番
            SheetView1.Cells["G45"].ResetValue();
            SheetView1.Cells["D47"].ResetValue();
            SheetView1.Cells["D49"].ResetValue();
            SheetView1.Cells["I49"].ResetValue();

        }

        /// <summary>
        /// ButtonPrint_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrint_Click(object sender, EventArgs e) {
            SpreadList.PrintSheet(SheetView1);
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// SubstituteSheet2_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubstituteSheet2_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
