namespace ControlEx {
    public partial class TableLayoutPanelEx : TableLayoutPanel {
        /// <summary>
        /// BorderStyle 
        /// true:Dotted false:None
        /// </summary>
        private bool _buttonBorderStyleDotted = false;
        /// <summary>
        /// 内部Controlを削除
        /// true:削除 false:未処理
        /// </summary>
        private bool _controlDelete = false;

        public TableLayoutPanelEx() {
            InitializeComponent();
            /*
             * Eventを定義
             */
            this.CellPaint += new TableLayoutCellPaintEventHandler(this.TableLayoutPanelEx_CellPaint);
        }

        /// <summary>
        /// TableLayoutPanelEx_CellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableLayoutPanelEx_CellPaint(object? sender, TableLayoutCellPaintEventArgs e) {
            /*
             * Borderを描画
             */
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
            ControlPaint.DrawBorder(e.Graphics,
                                    rectangle,
                                    Color.Gray,
                                    _buttonBorderStyleDotted ? ButtonBorderStyle.Dotted : ButtonBorderStyle.None);
            /*
             * 内部Controlを削除
             */
            if(_controlDelete) {
                Control control = this.GetControlFromPosition(e.Column, e.Row);
                if(control is not null) {
                    this.Controls.Remove(control);
                }
            }
        }

        /*
         * Getter Setter
         */
        /// <summary>
        /// true:Dotted false:None
        /// </summary>
        public bool ButtonBorderStyleDotted {
            get => _buttonBorderStyleDotted;
            set => _buttonBorderStyleDotted = value;
        }

        /// <summary>
        /// 内部のControlを全て削除する
        /// </summary>
        public void ControlClear() {
            this._controlDelete = true;
            this.Refresh();
            this._controlDelete = false;
        }
    }
}
