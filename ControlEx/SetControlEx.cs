using Vo;

namespace ControlEx {
    public partial class SetControlEx : TableLayoutPanelEx {
        private bool _setFlag = default;
        private bool _stopCarFlag = default;
        private bool _garageFlag = default;
        private int _productionNumberOfPeople = default;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetControlEx() {
            InitializeComponent();
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            this.RowCount = 6;
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.Size = new Size(74, 300);

            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            /*
             * イベントを登録
             */
            this.CellPaint += new TableLayoutCellPaintEventHandler(this.SetControlEx_CellPaint);
            this.Click += new EventHandler(this.SetControlEx_Click);
            this.DragDrop += new DragEventHandler(this.SetControlEx_DragDrop);
            this.DragEnter += new DragEventHandler(this.SetControlEx_DragEnter);
        }

        /*
         * イベントを親へ返す処理
         */
        public event EventHandler? Event_SetControlEx_Click;
        public event DragEventHandler? Event_SetControlEx_DragDrop;
        public event DragEventHandler? Event_SetControlEx_DragEnter;
        public event EventHandler? Event_LabelExControl_Click;
        public event MouseEventHandler? Event_LabelExControl_MouseMove;

        /// <summary>
        /// SetControlEx_CellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_CellPaint(object? sender, TableLayoutCellPaintEventArgs e) {
            if (SetFlag) { // 表示
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
                if (StopCarFlag) { // 配車日の場合
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
        /// Labelのイベントはここで登録する
        /// </summary>
        /// <param name="setLedgerVo"></param>
        public void CreateLabel(SetLedgerVo setLedgerVo) {
            var labelEx = new LabelEx().CreateLabel(setLedgerVo);
            labelEx.Click += new EventHandler(LabelControl_Click);
            labelEx.MouseMove += new MouseEventHandler(LabelControl_MouseMove);
            this.Controls.Add(labelEx, 0, 0);
        }

        /// <summary>
        /// CarLabel作成
        /// Labelのイベントはここで登録する
        /// </summary>
        /// <param name="carLedgerVo"></param>
        public void CreateLabel(CarLedgerVo carLedgerVo) {
            var labelEx = new LabelEx().CreateLabel(carLedgerVo);
            labelEx.Click += new EventHandler(LabelControl_Click);
            labelEx.MouseMove += new MouseEventHandler(LabelControl_MouseMove);
            this.Controls.Add(labelEx, 0, 1);
        }

        /// <summary>
        /// StaffLabel作成
        /// Labelのイベントはここで登録する
        /// </summary>
        /// <param name="number">1:運転手 2:作業員1 3:作業員2 4:作業員3</param>
        /// <param name="staffLedgerVo"></param>
        public void CreateLabel(int number, StaffLedgerVo staffLedgerVo) {
            var labelEx = new LabelEx().CreateLabel(staffLedgerVo);
            labelEx.Click += new EventHandler(LabelControl_Click);
            labelEx.MouseMove += new MouseEventHandler(LabelControl_MouseMove);
            this.Controls.Add(labelEx, 0, number + 2);
        }

        private void SetControlEx_Click(object? sender, EventArgs e) {
            if (Event_SetControlEx_Click != null)
                Event_SetControlEx_Click(sender, e);
        }
        private void SetControlEx_DragDrop(object? sender, DragEventArgs e) {
            if (Event_SetControlEx_DragDrop != null)
                Event_SetControlEx_DragDrop(sender, e);
        }
        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            if (Event_SetControlEx_DragEnter != null)
                Event_SetControlEx_DragEnter(sender, e);
        }
        private void LabelControl_Click(object? sender, EventArgs e) {
            if (Event_LabelExControl_Click != null)
                Event_LabelExControl_Click(sender, e);
        }
        private void LabelControl_MouseMove(object? sender, MouseEventArgs e) {
            if (Event_LabelExControl_MouseMove != null)
                Event_LabelExControl_MouseMove(sender, e);
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
        /// 稼働フラグ
        /// true:稼働 false:休車
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
        /// 枠の数量
        /// </summary>
        public int ProductionNumberOfPeople {
            get => _productionNumberOfPeople;
            set => _productionNumberOfPeople = value;
        }
    }
}
