/*
 * 2023-10-24
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_SetLabel : Label {
        /*
         * プロパティ
         */
        private const int _height = 76;
        private const int _width = 76;
        private bool _firstRollCallFlag = false; // 出庫点呼フラグ true:出庫点呼済 false:未点呼
        private bool _fiveLapFlag = false; // 第五週稼働フラグ true:第五週稼働 false:第五週休車
        private int _garageCode = 1; // 出庫地コード 1:本社 2:三郷
        private bool _lastRollCallFlag = false; // 帰庫点呼フラグ true:帰庫点呼済 false:未点呼
        private bool _memoFlag = false; // メモフラグ true:メモあり false:メモなし
        private int _shiftCode = 0; // 番手コード 0→指定なし 1→早番 2→遅番
        private bool _standByFlag = false; // 待機フラグ true:待機あり false:待機なし
        private bool _workerFlag = false; // 作業員付フラグ true:サ付 false:サ無し
        private int _workerCount = 0; // 従事者数 1～4

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hSetMasterVo"></param>
        public H_SetLabel(H_SetMasterVo hSetMasterVo) {
            /*
             * ControlIni
             */
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = _height;
            this.Margin = new Padding(2);
            this.Name = "H_SetLabel";
            this.Tag = hSetMasterVo;
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
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, 74, 74), Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
