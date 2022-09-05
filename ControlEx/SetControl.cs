/*
 * 
 */
using Vo;

namespace ControlEx {
    public partial class SetControl : UserControl {
        private bool _setFlag;
        private bool _stopCarFlag;
        private bool _garageFlag;
        private int _productionNumberOfPeople;

        public SetControl() {
            /*
             * Controlを初期化
             */
            InitializeComponent();
            Dock = DockStyle.Fill;
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
                    if (e.Row < ProductionNumberOfPeople + 2) {
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

        /// <summary>
        /// SetLabel作成
        /// </summary>
        /// <param name="setLedgerVo"></param>
        public void CreateLabel(SetLedgerVo setLedgerVo) {
            var labelEx = new LabelEx().CreateLabel(setLedgerVo);
            TableLayoutPanelEx1.Controls.Add(labelEx, 0, 0);
        }

        /// <summary>
        /// CarLabel作成
        /// </summary>
        /// <param name="carLedgerVo"></param>
        public void CreateLabel(CarLedgerVo carLedgerVo) {
            var labelEx = new LabelEx().CreateLabel(carLedgerVo);
            TableLayoutPanelEx1.Controls.Add(labelEx, 0, 1);
        }

        /// <summary>
        /// StaffLabel作成
        /// </summary>
        /// <param name="number">1:運転手 2:作業員1 3:作業員2 4:作業員3</param>
        /// <param name="staffLedgerVo"></param>
        public void CreateLabel(int number, StaffLedgerVo staffLedgerVo) {
            var labelEx = new LabelEx().CreateLabel(staffLedgerVo);
            TableLayoutPanelEx1.Controls.Add(labelEx, 0, number + 2);
        }

        /*
         * Setter Getter
         */
        /// <summary>
        /// 表示フラグ
        /// true:表示 false:非表示
        /// </summary>
        public bool SetFlag {
            get => _setFlag;
            set => _setFlag = value;
        }
        /// <summary>
        /// 休車フラグ
        /// true:休車 false:配車
        /// </summary>
        public bool StopCarFlag {
            get => _stopCarFlag;
            set => _stopCarFlag = value;
        }
        /// <summary>
        /// 車庫地
        /// true:足立 false:三郷
        /// </summary>
        public bool GarageFlag {
            get => _garageFlag;
            set => _garageFlag = value;
        }
        /// <summary>
        /// 本番人数
        /// </summary>
        public int ProductionNumberOfPeople {
            get => _productionNumberOfPeople;
            set => _productionNumberOfPeople = value;
        }
    }
}
