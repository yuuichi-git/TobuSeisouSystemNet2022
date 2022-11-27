using Common;

using Dao;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

using Vo;

namespace VehicleDispatchConvert {
    public partial class VehicleDispatchSimple : Form {
        private ConnectionVo _connectionVo;
        private DateTime _operationDate;
        /*
         * NPOI
         */
        private IWorkbook _iWorkbook;
        private ISheet _iSheet;
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;

        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="operationDate"></param>
        public VehicleDispatchSimple(ConnectionVo connectionVo, DateTime operationDate) {
            _connectionVo = connectionVo;
            _operationDate = operationDate;
            /*
             * Dao
             */
            _vehicleDispatchDetailDao = new VehicleDispatchDetailDao(connectionVo);
            _vehicleDispatchDetailCarDao = new VehicleDispatchDetailCarDao(connectionVo);
            _vehicleDispatchDetailStaffDao = new VehicleDispatchDetailStaffDao(connectionVo);
            /*
             * Vo
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMaster();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMaster();
            /*
             * ブック読み込み new Directry().GetExcelDesktopPass(fileName)
             */
            _iWorkbook = (HSSFWorkbook)WorkbookFactory.Create(new Directry().GetExcelDesktopPassXls("配車当日"));
            /*
             * シート名からシート取得
             */
            _iSheet = _iWorkbook.GetSheet("配車表");
            InitializeComponent();
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            ConvertXls convertXls = new ConvertXls(_iWorkbook, _iSheet, _listSetMasterVo, _listCarMasterVo, _listStaffMasterVo);
            foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectVehicleDispatchDetail(_operationDate)) {
                convertXls.SetCellString(vehicleDispatchDetailVo);
            }
            try {
                using(var fileStream = new FileStream(new Directry().GetExcelDesktopPassXls("配車当日"), FileMode.Create))
                    _iWorkbook.Write(fileStream, true);
                MessageBox.Show("書き出しを完了しました");
                //ファイル作成時に例外が発生した場合の処理
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// VehicleDispatchSimple_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchSimple_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}