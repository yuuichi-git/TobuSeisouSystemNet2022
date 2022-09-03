namespace ControlEx {
    public partial class SetControl : UserControl {
        /// <summary>
        /// 表示フラグ
        /// true:表示 false:非表示
        /// </summary>
        private bool _setFlag;
        /// <summary>
        /// 休車フラグ
        /// true:休車 false:配車
        /// </summary>
        private bool _stopCarFlag;
        /// <summary>
        /// 車庫フラグ
        /// true:足立 false:三郷
        /// </summary>
        private bool _garageFlag;
        /// <summary>
        /// 本番人数
        /// </summary>
        private int _productionNumberOfPeople;

        public SetControl() {
            /*
             * プロパティを初期化
             */
            SetFlag = true;
            StopCarFlag = false;
            GarageFlag = true;
            ProductionNumberOfPeople = 4;
            /*
             * Controlを初期化
             */
            InitializeComponent();
            Margin = new Padding(0);
        }

        /// <summary>
        /// TableLayoutPanelEx1_CellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableLayoutPanelEx1_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            if (_setFlag) { // 表示
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
                /*
                 * SetLabelとCarLabelの部分
                 */
                switch (e.Row) {
                    case 0: // SetLabel
                        ControlPaint.DrawBorder(e.Graphics, rectangle, GarageFlag ? Color.DarkGray : Color.Blue, ButtonBorderStyle.Solid);
                        break;
                    case 1: // CarLabel
                        ControlPaint.DrawBorder(e.Graphics, rectangle, Color.DarkGray, ButtonBorderStyle.Dotted);
                        break;
                }
                /*
                 * StaffLabelの部分
                 */
                if (!StopCarFlag) { // 配車日の場合
                    if (e.Row - 2 < ProductionNumberOfPeople) {
                        switch (e.Row) {
                            case 2: // StaffLabel1
                                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.DarkGray, ButtonBorderStyle.Dotted);
                                break;
                            case 3: // StaffLabel2
                                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.DarkGray, ButtonBorderStyle.Dotted);
                                break;
                            case 4: // StaffLabel3
                                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.DarkGray, ButtonBorderStyle.Dotted);
                                break;
                            case 5: // StaffLabel4
                                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.DarkGray, ButtonBorderStyle.Dotted);
                                break;
                        }
                    }
                } else { // 休車日の場合
                }
            } else { //非表示
            }
        }

        public void SetSetLabel() {
            var labelEx = new LabelEx();

        }

        public void SetCarLabel() {
        
        }

        public void SetStaffLabel() {
        
        }

        /*
         * Setter Getter
         */
        public bool SetFlag {
            get => _setFlag;
            set => _setFlag = value;
        }
        public bool StopCarFlag {
            get => _stopCarFlag;
            set => _stopCarFlag = value;
        }
        public bool GarageFlag {
            get => _garageFlag;
            set => _garageFlag = value;
        }
        public int ProductionNumberOfPeople {
            get => _productionNumberOfPeople;
            set => _productionNumberOfPeople = value;
        }
    }
}
