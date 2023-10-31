/*
 * 2023-10-25
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_CarLabel : Label {
        /*
         * プロパティ
         */
        private const int _height = 76;
        private const int _width = 76;
        private int _garageCode = 0; // 出庫地フラグ 0:本社 1:三郷
        private bool _memoFlag = false; // メモフラグ true:メモあり false:メモなし

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        public H_CarLabel(H_CarMasterVo hCarMasterVo) {
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = _height;
            this.Margin = new Padding(2);
            this.Name = "H_CarLabel";
            this.Tag = hCarMasterVo;
            this.Width = _width;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            /*
             * Boderを描画
             */
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, 74, 74), Color.Blue, ButtonBorderStyle.Solid);
        }
    }
}
