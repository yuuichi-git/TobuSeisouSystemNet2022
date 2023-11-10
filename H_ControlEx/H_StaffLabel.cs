/*
 * 2023-10-31
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_StaffLabel : Label {
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_StaffLabel(H_StaffMasterVo hStaffMasterVo) {
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = (int)_panelHeight - 4;
            this.Margin = new Padding(2);
            this.Name = "H_StaffLabel";
            this.Tag = hStaffMasterVo;
            this.Width = (int)_panelWidth - 4;
        }

        protected override void OnPaint(PaintEventArgs p) {
            /*
             * Boderを描画
             */
            ControlPaint.DrawBorder(p.Graphics, new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), Color.Gray, ButtonBorderStyle.Solid);
        }
    }
}
