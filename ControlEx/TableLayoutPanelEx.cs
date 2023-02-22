namespace ControlEx {
    public partial class TableLayoutPanelEx : TableLayoutPanel {
        /// <summary>
        /// BorderStyle 
        /// true:Dotted false:None
        /// </summary>
        private bool _buttonBorderStyleDotted = false;

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
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする

            ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, _buttonBorderStyleDotted ? ButtonBorderStyle.Dotted : ButtonBorderStyle.None);
        }

        /*
         * Getter Setter
         */
        public bool ButtonBorderStyleDotted {
            get => _buttonBorderStyleDotted;
            set => _buttonBorderStyleDotted = value;
        }
    }
}
