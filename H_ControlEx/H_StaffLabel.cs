/*
 * 2023-10-31
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_StaffLabel : Label {
        /*
         * プロパティ
         */
        private const int _height = 96;
        private const int _width = 76;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public H_StaffLabel(H_StaffMasterVo hStaffMasterVo) {
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = _height;
            this.Margin = new Padding(2);
            this.Name = "H_StaffLabel";
            this.Tag = hStaffMasterVo;
            this.Width = _width;
        }

        protected override void OnPaint(PaintEventArgs p) {
            /*
             * Boderを描画
             */
            ControlPaint.DrawBorder(p.Graphics, new Rectangle(0, 0, _width - 2, _height - 2), Color.Gray, ButtonBorderStyle.Solid);
        }
    }
}
