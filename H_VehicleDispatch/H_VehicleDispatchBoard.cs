/*
 * 2023-10-12
 */
using H_Common;

using H_ControlEx;

using Vo;

namespace H_VehicleDispatch {
    public partial class H_VehicleDispatchBoard : Form {
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_VehicleDispatchBoard(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            Rectangle desktop = new Desktop().GetWorkingArea(this);
            this.Location = desktop.Location;
            this.Size = desktop.Size;
            this.WindowState = FormWindowState.Maximized;

            h_DateTimePickerOperationDate.SetValue(DateTime.Today);

        }

        private void h_ButtonExUpdate_Click(object sender, EventArgs e) {
            H_TableLayoutPanelExSetControl h_TableLayoutPanelExSetControl = new H_TableLayoutPanelExSetControl();
            h_TableLayoutPanelExBoard.Controls.Add(h_TableLayoutPanelExSetControl, 6, 0);

        }
    }
}
