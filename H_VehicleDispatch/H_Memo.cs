/*
 * 2024-03-09
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_Memo : Form {
        private string _initializeKey = string.Empty;
        /*
         * Dao
         */
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        private readonly H_SetControl _hSetControl;
        private readonly H_SetLabel _hSetLabel;
        private readonly H_CarLabel _hCarLabel;
        private readonly H_StaffLabel _hStaffLabel;
        private readonly TableLayoutPanelCellPosition _tableLayoutPanelCellPosition;

        /// <summary>
        /// H_SetLabel用のコンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hSetControl"></param>
        /// <param name="hSetLabel"></param>
        public H_Memo(ConnectionVo connectionVo, H_SetControl hSetControl, H_SetLabel hSetLabel) {
            _initializeKey = "H_SetLabel";
            /*
             * Dao
             */
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            _hSetControl = hSetControl;
            _hSetLabel = hSetLabel;
            InitializeComponent();
            this.Text = string.Concat(((H_SetMasterVo)hSetLabel.Tag).SetName, " のメモを編集します");
            SetHTextBoxExMemo(_initializeKey);
        }

        /// <summary>
        /// H_CarLabel用のコンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hSetControl"></param>
        /// <param name="hCarLabel"></param>
        public H_Memo(ConnectionVo connectionVo, H_SetControl hSetControl, H_CarLabel hCarLabel) {
            _initializeKey = "H_CarLabel";
            /*
             * Dao
             */
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            _hSetControl = hSetControl;
            _hCarLabel = hCarLabel;
            InitializeComponent();
            this.Text = string.Concat(((H_CarMasterVo)hCarLabel.Tag).RegistrationNumber, " のメモを編集します");
            SetHTextBoxExMemo(_initializeKey);
        }

        /// <summary>
        /// H_StaffLabel用のコンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="hSetControl"></param>
        /// <param name="hStaffLabel"></param>
        public H_Memo(ConnectionVo connectionVo, H_SetControl hSetControl, H_StaffLabel hStaffLabel, TableLayoutPanelCellPosition tableLayoutPanelCellPosition) {
            _initializeKey = "H_StaffLabel";
            /*
             * Dao
             */
            _hVehicleDispatchDetailDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;

            _hSetControl = hSetControl;
            _hStaffLabel = hStaffLabel;
            _tableLayoutPanelCellPosition = tableLayoutPanelCellPosition;
            InitializeComponent();
            this.Text = string.Concat(((H_StaffMasterVo)hStaffLabel.Tag).Name, " のメモを編集します");
            SetHTextBoxExMemo(_initializeKey);
        }

        /// <summary>
        /// 各Memoを表示
        /// </summary>
        /// <param name="initializeKey"></param>
        private void SetHTextBoxExMemo(string initializeKey) {
            H_ControlVo hControlVo = (H_ControlVo)_hSetControl.Tag;
            switch (initializeKey) {
                case "H_SetLabel":
                    HTextBoxExMemo.Text = _hVehicleDispatchDetailDao.SelectOneSetMemo(hControlVo.CellNumber, hControlVo.OperationDate);
                    break;
                case "H_CarLabel":
                    HTextBoxExMemo.Text = _hVehicleDispatchDetailDao.SelectOneCarMemo(hControlVo.CellNumber, hControlVo.OperationDate);
                    break;
                case "H_StaffLabel":
                    int staffNumber = _tableLayoutPanelCellPosition.Column * 2 + (_tableLayoutPanelCellPosition.Row - 2);
                    HTextBoxExMemo.Text = _hVehicleDispatchDetailDao.SelectOneStaffMemo(hControlVo.CellNumber, hControlVo.OperationDate, staffNumber);
                    break;
            }
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            H_ControlVo hControlVo = (H_ControlVo)_hSetControl.Tag;
            bool memoFlag = HTextBoxExMemo.Text.Length > 0 ? true : false;
            string memo = HTextBoxExMemo.Text;
            switch (_initializeKey) {
                case "H_SetLabel":
                    try {
                        _hVehicleDispatchDetailDao.UpdateOneSetMemo(hControlVo.CellNumber, hControlVo.OperationDate, memoFlag, memo);
                        _hSetLabel.MemoFlag = memoFlag;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "H_CarLabel":
                    try {
                        _hVehicleDispatchDetailDao.UpdateOneCarMemo(hControlVo.CellNumber, hControlVo.OperationDate, memoFlag, memo);
                        _hCarLabel.CarMemoFlag = memoFlag;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "H_StaffLabel":
                    try {
                        int staffNumber = _tableLayoutPanelCellPosition.Column * 2 + (_tableLayoutPanelCellPosition.Row - 2);
                        _hVehicleDispatchDetailDao.UpdateOneStaffMemo(hControlVo.CellNumber, hControlVo.OperationDate, staffNumber, memoFlag, memo);
                        _hStaffLabel.StaffMemoFlag = memoFlag;
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
            }
            this.Close();
            this.Dispose();
        }
    }
}
