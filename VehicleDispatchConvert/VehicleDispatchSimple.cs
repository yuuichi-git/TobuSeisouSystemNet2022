using Common;

using Dao;

using NPOI.SS.UserModel;

using Vo;

namespace VehicleDispatchConvert {
    public partial class VehicleDispatchSimple : Form {
        private DateTime _operationDate;
        /*
         * NPOI
         * https://teratail.com/questions/338753
         */
        private IWorkbook _iWorkbook;
        private ISheet _iSheet_1;
        private ISheet _iSheet_2; // 帰庫点呼のシート
        private ISheet _iSheet_3; // 本社
        private ISheet _iSheet_4; // 三郷
        private ISheet _iSheet_5; // アルバイトの出勤状況
        /*
         * Dao
         */
        private VehicleDispatchDetailDao _vehicleDispatchDetailDao;
        private VehicleDispatchDetailCarDao _vehicleDispatchDetailCarDao;
        private VehicleDispatchDetailStaffDao _vehicleDispatchDetailStaffDao;
        /*
         * Vo
         */
        private List<SetMasterVo> _listSetMasterVo;
        private List<CarMasterVo> _listCarMasterVo;
        private List<StaffMasterVo> _listStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="operationDate"></param>
        public VehicleDispatchSimple(ConnectionVo connectionVo, DateTime operationDate) {
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

            if(File.Exists(new Directry().GetExcelDesktopPassXls("配車当日"))) {
                /*
                 * ブック読み込み new Directry().GetExcelDesktopPass(fileName)
                 */
                _iWorkbook = WorkbookFactory.Create(new Directry().GetExcelDesktopPassXls("配車当日"));
                /*
                 * シート名からシート取得
                 */
                _iSheet_1 = _iWorkbook.GetSheet("配車表");
                _iSheet_2 = _iWorkbook.GetSheet("帰庫点呼");
                _iSheet_3 = _iWorkbook.GetSheet("本社");
                _iSheet_4 = _iWorkbook.GetSheet("三郷");
                _iSheet_5 = _iWorkbook.GetSheet("アルバイト出勤状況");
                /*
                 * 再計算フラグ
                 */
                _iSheet_1.ForceFormulaRecalculation = true;
                _iSheet_2.ForceFormulaRecalculation = true;
                _iSheet_3.ForceFormulaRecalculation = true;
                _iSheet_4.ForceFormulaRecalculation = true;
                _iSheet_5.ForceFormulaRecalculation = true;
            } else {
                MessageBox.Show("デスクトップに”配車当日.xls”が存在しません。やり直して下さい", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception();
            }

            InitializeComponent();
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
             * 点呼執行者が選択されているかをチェックする
             */
            if(ComboBox1.Text.Length > 0 && ComboBox2.Text.Length != 0 && ComboBox3.Text.Length != 0) {
                string[] arrayTenkoName = new string[]{ ComboBox1.Text, ComboBox2.Text, ComboBox3.Text};
                ConvertXls convertXls = new ConvertXls(_iWorkbook, _iSheet_1, _listSetMasterVo, _listCarMasterVo, _listStaffMasterVo, arrayTenkoName);
                foreach(var vehicleDispatchDetailVo in _vehicleDispatchDetailDao.SelectAllVehicleDispatchDetail(_operationDate)) {
                    convertXls.SetCellString(vehicleDispatchDetailVo);
                }
                try {
                    var fileStream = new FileStream(new Directry().GetExcelDesktopPassXls("配車当日"), FileMode.Open);
                    _iWorkbook.Write(fileStream, false);
                    MessageBox.Show("書き出しを完了しました");
                } catch(Exception exception) { //ファイル作成時に例外が発生した場合の処理
                    MessageBox.Show(exception.Message);
                }
            } else {
                MessageBox.Show("点呼執行者を選択して下さい", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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