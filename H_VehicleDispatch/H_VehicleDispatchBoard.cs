/*
 * 2023-10-12
 */
using H_Common;

using H_Vo;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
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

        }

        private void H_ButtonExUpdate_Click(object sender, EventArgs e) {
            H_SetControlVo hSetControlVo = new();
            hSetControlVo.ColumnNumber = 10;
            h_TableLayoutPanelExBoard.AddSetControl(hSetControlVo);

            H_SetControlVo hSetControlVo1 = new();
            hSetControlVo1.ColumnNumber = 12;
            h_TableLayoutPanelExBoard.AddSetControl(hSetControlVo1);

        }
    }
}
