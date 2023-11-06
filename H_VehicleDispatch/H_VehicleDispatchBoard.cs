/*
 * 2023-10-12
 */
using H_Common;

using H_ControlEx;

using H_Vo;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
        private H_Board _hBoard;
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_VehicleDispatchBoard(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            Rectangle rectangle = new Desktop().GetWorkingArea(this);
            this.KeyPreview = true;
            this.Location = rectangle.Location;
            this.Size = rectangle.Size;
            this.WindowState = FormWindowState.Maximized;

            h_DateTimePickerOperationDate.SetValue(DateTime.Today);
            /*
             * 配車用ボードを作成
             */
            _hBoard = new H_Board();
            h_TableLayoutPanelExCenter.Controls.Add(_hBoard, 0, 1);
        }

        private void H_ButtonExUpdate_Click(object sender, EventArgs e) {
            this.CreateVehicleDispatch();

        }

        /// <summary>
        /// CreateVehicleDispatch
        /// 配車データを作成
        /// </summary>
        private void CreateVehicleDispatch() {
            H_SetControlVo hSetControlVo = new();
            hSetControlVo.ColumnNumber = 17;
            hSetControlVo.RowNumber = 1;

            hSetControlVo.HSetMasterVo = new H_SetMasterVo();
            hSetControlVo.HSetMasterVo.NumberOfPeople = 2;
            hSetControlVo.HSetMasterVo.SpareOfPeople = true;

            hSetControlVo.HCarMasterVo = new H_CarMasterVo();

            hSetControlVo.ListHStaffMasterVo = new List<H_StaffMasterVo>();
            hSetControlVo.ListHStaffMasterVo.Add(new H_StaffMasterVo());
            hSetControlVo.ListHStaffMasterVo.Add(new H_StaffMasterVo());

            _hBoard.AddSetControl(hSetControlVo);
        }
    }
}
