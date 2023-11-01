/*
 * 2023-10-20
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_SetControl : TableLayoutPanel {
        /*
         * プロパティ
         */
        private const int _columnCount = 1; // Column数
        private const int _rowCount = 4; // Row数
        /*
         * Vo
         */
        private readonly H_SetControlVo _hSetControlVo;
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         */
        public event MouseEventHandler Event_SetControl_MouseMove = delegate {};

        /// <summary>
        /// コンストラクタ
        /// H_SetControlVoに全ての引数を代入しておく
        /// </summary>
        public H_SetControl(H_SetControlVo hSetControlVo) {
            /*
             * Vo
             */
            _hSetControlVo = hSetControlVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Name = "H_SetControl";
            this.Padding = new Padding(0);
            this.Size = new Size(80, 360);

            this.ColumnCount = _columnCount;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.RowCount = _rowCount;
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            /*
             * Event
             */
            this.MouseMove += SetControl_MouseMove;
            /*
             * H_SetLabel
             */
            H_SetLabel hSetLabel = new(_hSetControlVo.HSetMasterVo);
            hSetLabel.MouseMove += SetControl_MouseMove; // SetLabelのEventをSetControlのEventとして登録
            this.Controls.Add(hSetLabel, 0, 0); // SetLabelを追加
            /*
             * H_CarLabel
             */
            H_CarLabel hCarLabel = new(_hSetControlVo.HCarMasterVo);
            hCarLabel.MouseMove += SetControl_MouseMove; // CarLabelのEventをSetControlのEventとして登録
            this.Controls.Add(hCarLabel, 0, 1); // CarLabelを追加
            /*
             * H_StaffLabel(最大４名)
             * 配車人数が３名以上の場合、SetControlは２列になる
             */

        }

        /// <summary>
        /// OnCellPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e) {
            /*
             * Boderを描画
             */
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
            switch(e.Row) {
                case 0: // SetLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // SetLabelExの枠線
                    break;
                case 1: // CarLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // CarLabelExの枠線
                    break;
                case 2: // StaffLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                    break;
                case 3: // StaffLabel
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                    break;
            }
        }

        /*
         * Event
         */
        private void SetControl_MouseMove(object sender, MouseEventArgs e) {
            Event_SetControl_MouseMove.Invoke(sender, e);
        }
    }
}
