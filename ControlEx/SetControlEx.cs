using Vo;

namespace ControlEx {
    public partial class SetControlEx : TableLayoutPanelEx {
        private bool _setFlag = default;
        private int _cellNumber;
        private bool _operationFlag = default;
        private bool _garageFlag = default;
        private bool _classificationFlag = default;
        private int _productionNumberOfPeople = default;
        private bool _lastRollCallFlag = default;

        /// <summary>
        /// SetControlExのContactInformation(Border)を描画
        /// true:表示 false:非表示
        /// </summary>
        private bool _setContactInformation = default;

        /*
         * 空のSetControlExの文字列表示用
         */
        private readonly Rectangle rectangleFill = new(2, 2, 64, 62);
        private readonly Font _drawFont = new("Yu Gothic UI", 12, FontStyle.Italic, GraphicsUnit.Pixel);
        private readonly SolidBrush _drawBrushFont = new(Color.LightGray);
        /*
         * イベントを親へ渡す処理
         */
        public event EventHandler Event_SetControlEx_Click = delegate { };
        public event DragEventHandler Event_SetControlEx_DragDrop = delegate { };
        public event DragEventHandler Event_SetControlEx_DragEnter = delegate { };
        public event EventHandler Event_SetLabelEx_Click = delegate { };
        public event EventHandler Event_SetLabelEx_DoubleClick = delegate { };
        public event MouseEventHandler Event_SetLabelEx_MouseMove = delegate { };
        public event EventHandler Event_CarLabelEx_Click = delegate { };
        public event MouseEventHandler Event_CarLabelEx_MouseMove = delegate { };
        public event EventHandler Event_StaffLabelEx_Click = delegate { };
        public event MouseEventHandler Event_StaffLabelEx_MouseMove = delegate { };
        /*
         * 透かし文字用
         */
        private StringFormat stringFormat;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SetControlEx(int cellNumber) {
            _cellNumber = cellNumber;
            InitializeComponent();

            /*
             * SetControlExのセルを定義する
             */
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            this.RowCount = 6;
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.Size = new Size(74, 300);

            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Name = "SetControlEx";
            /*
             * 透かし文字用のフォーマット
             */
            stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            /*
             * SetControlExのイベントを登録
             */
            this.CellPaint += new TableLayoutCellPaintEventHandler(this.SetControlEx_CellPaint);
            this.Click += new EventHandler(this.SetControlEx_Click);
            this.DragDrop += new DragEventHandler(this.SetControlEx_DragDrop);
            this.DragEnter += new DragEventHandler(this.SetControlEx_DragEnter);
        }

        /*
         * SetControlExを囲うPointと半透明色を設定する
         */
        Point[] _points = {new Point(1,  0), new Point(73, 0), new Point(73,  303), new Point(1, 303)};
        SolidBrush _solidBrush = new(Color.FromArgb(15, Color.LimeGreen));
        /// <summary>
        /// SetControlEx_CellPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_CellPaint(object? sender, TableLayoutCellPaintEventArgs e) {
            /*
             * 連絡事項ありの印
             */
            if(_setContactInformation)
                this.CreateGraphics().FillPolygon(_solidBrush, _points);
            /*
             * SetControlEx全体にBorderを掛ける
             */
            if(SetFlag) {
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
                /*
                 * SetLabelとCarLabelの部分
                 */
                switch(e.Row) {
                    case 0: // SetLabel
                        // SetLabelExの枠線
                        ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted);
                        break;
                    case 1: // CarLabel
                        // CarLabelExの枠線
                        ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted);
                        break;
                }
                /*
                 * StaffLabelの部分
                 */
                if(e.Row < ProductionNumberOfPeople + 2) {
                    switch(e.Row) {
                        // StaffLabelExの枠線
                        case 2: // StaffLabel1
                            ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Dotted);
                            break;
                        // StaffLabelExの枠線
                        case 3: // StaffLabel2
                            ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Dotted);
                            break;
                        // StaffLabelExの枠線
                        case 4: // StaffLabel3
                            ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Dotted);
                            break;
                        // StaffLabelExの枠線
                        case 5: // StaffLabel4
                            ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Dotted);
                            break;
                    }
                }
            } else { //非表示
                /*
                 * 文字を描画
                 */
                switch(_cellNumber) {
                    /*
                     * 大型枠
                     */
                    case 75:
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                        e.Graphics.DrawString("大型", _drawFont, _drawBrushFont, rectangleFill, stringFormat);
                        break;
                    /*
                     * 臨時枠
                     */
                    case 88:
                    case 89:
                    case 90:
                    case 91:
                    case 92:
                    case 93:
                    case 94:
                    case 95:
                    case 96:
                    case 97:
                    case 98:
                    case 99:
                    case 113:
                    case 114:
                    case 115:
                    case 116:
                    case 117:
                    case 118:
                    case 119:
                    case 120:
                    case 121:
                    case 122:
                    case 123:
                    case 124:
                        e.Graphics.DrawString("臨時他", _drawFont, _drawBrushFont, rectangleFill, stringFormat);
                        break;
                }
            }
        }

        /// <summary>
        /// SetLabel作成
        /// Labelのイベントはここで登録する
        /// </summary>
        /// <param name="setMasterVo"></param>
        public void CreateLabel(SetMasterVo setMasterVo, VehicleDispatchDetailVo vehicleDispatchDetailVo, ContextMenuStrip contextMenuStrip) {
            try {
                SetLabelEx labelEx = new SetLabelEx(setMasterVo,
                                                    vehicleDispatchDetailVo).CreateLabel();
                /*
                 * ContextMenuStrip
                 */
                labelEx.ContextMenuStrip = contextMenuStrip;
                /*
                 * Event
                 */
                labelEx.Click += new EventHandler(SetLabelEx_Click);
                labelEx.DoubleClick += new EventHandler(SetLabelEx_DoubleClick);
                labelEx.MouseMove += new MouseEventHandler(SetLabelEx_MouseMove);
                this.Controls.Add(labelEx,
                                  0,
                                  0);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// CarLabel作成
        /// Labelのイベントはここで登録する
        /// </summary>
        /// <param name="carMasterVo"></param>
        public void CreateLabel(VehicleDispatchDetailVo vehicleDispatchDetailVo, CarMasterVo carMasterVo, ContextMenuStrip contextMenuStrip) {
            try {
                CarLabelEx labelEx = new CarLabelEx(vehicleDispatchDetailVo,
                                                    carMasterVo).CreateLabel();
                /*
                 * ContextMenuStrip
                 */
                labelEx.ContextMenuStrip = contextMenuStrip;
                /*
                 * Event
                 */
                labelEx.Click += new EventHandler(CarLabelEx_Click);
                labelEx.MouseMove += new MouseEventHandler(CarLabelEx_MouseMove);
                this.Controls.Add(labelEx,
                                  0,
                                  1);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// CreateLabel
        /// StaffLabel作成
        /// Labelのイベントはここで登録する
        /// </summary>
        /// <param name="number">1:運転手 2:作業員1 3:作業員2 4:作業員3</param>
        /// <param name="staffMasterVo"></param>
        /// <param name="proxyFlag"></param>
        /// <param name="tenkoModeFlag"></param>
        /// <param name="rollCallFlag"></param>
        /// <param name="noteFlag"></param>
        /// <param name="contextMenuStrip"></param>
        public void CreateLabel(int number, StaffMasterVo staffMasterVo, bool proxyFlag, bool tenkoModeFlag, bool rollCallFlag, bool noteFlag, int occupation, ContextMenuStrip contextMenuStrip) {
            try {
                StaffLabelEx labelEx = new StaffLabelEx(staffMasterVo,
                                                        proxyFlag,
                                                        tenkoModeFlag,
                                                        rollCallFlag,
                                                        noteFlag,
                                                        occupation).CreateLabel();
                /*
                 * ContextMenuStrip
                 */
                labelEx.ContextMenuStrip = contextMenuStrip;
                /*
                 * Event
                 */
                labelEx.Click += new EventHandler(StaffLabelEx_Click);
                labelEx.MouseMove += new MouseEventHandler(StaffLabelEx_MouseMove);
                this.Controls.Add(labelEx,
                                  0,
                                  number + 2);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        /*
         * Event
         */
        private void SetControlEx_Click(object? sender, EventArgs e) {
            Event_SetControlEx_Click?.Invoke(sender, e);
        }
        private void SetControlEx_DragDrop(object? sender, DragEventArgs e) {
            Event_SetControlEx_DragDrop?.Invoke(sender, e);
        }
        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            Event_SetControlEx_DragEnter?.Invoke(sender, e);
        }
        private void SetLabelEx_Click(object? sender, EventArgs e) {
            Event_SetLabelEx_Click?.Invoke(sender, e);
        }
        private void SetLabelEx_DoubleClick(object? sender, EventArgs e) {
            Event_SetLabelEx_DoubleClick?.Invoke(sender, e);
        }
        private void SetLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            Event_SetLabelEx_MouseMove?.Invoke(sender, e);
        }
        private void CarLabelEx_Click(object? sender, EventArgs e) {
            Event_CarLabelEx_Click?.Invoke(sender, e);
        }
        private void CarLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            Event_CarLabelEx_MouseMove?.Invoke(sender, e);
        }
        private void StaffLabelEx_Click(object? sender, EventArgs e) {
            Event_StaffLabelEx_Click?.Invoke(sender, e);
        }
        private void StaffLabelEx_MouseMove(object? sender, MouseEventArgs e) {
            Event_StaffLabelEx_MouseMove?.Invoke(sender, e);
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
        public bool OperationFlag {
            get => _operationFlag;
            set => _operationFlag = value;
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
        /// 雇上・区契フラグ
        /// true:雇上 false:区契
        /// </summary>
        public bool ClassificationFlag {
            get => _classificationFlag;
            set => _classificationFlag = value;
        }
        /// <summary>
        /// 本番人数
        /// 枠の数量
        /// </summary>
        public int ProductionNumberOfPeople {
            get => _productionNumberOfPeople;
            set => _productionNumberOfPeople = value;
        }
        /// <summary>
        /// 連絡事項
        /// true:連絡事項あり false:連絡事項なし
        /// </summary>
        public bool ContactInformationFlag {
            get => _setContactInformation;
            set => _setContactInformation = value;
        }
        /// <summary>
        /// 帰庫点呼フラグ
        /// true:実施 false:未実施
        /// </summary>
        public bool LastRollCallFlag {
            get => _lastRollCallFlag;
            set => _lastRollCallFlag = value;
        }

        /*
         * 公開メソッド
         */
        /// <summary>
        /// SetBorder
        /// true:表示 false:非表示
        /// </summary>
        /// <param name="contactInformationFlag"></param>
        public void SetContactInformationFlag(bool contactInformationFlag) {
            _setContactInformation = contactInformationFlag;
            this.Refresh();
        }
    }
}
