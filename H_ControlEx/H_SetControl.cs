/*
 * 2023-10-20
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_SetControl : TableLayoutPanel {
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * プロパティ
         */
        private const int _columnCount = 1; // Column数
        private const int _rowCount = 4; // Row数
        /*
         * StaffLabel用のCellの位置を保持
         */
        private Dictionary<int,Point> _dictionaryCellPoint = new() { { 0, new Point(0, 2) }, { 1, new Point(0, 3) }, { 2, new Point(1, 2) }, { 3, new Point(1, 3) } }; // StaffLabel用のCellの位置
        /*
         * Vo
         */
        private readonly H_SetControlVo _hSetControlVo;
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetControl
         */
        public event MouseEventHandler Event_HSetControlEx_MouseDown = delegate {};
        public event MouseEventHandler Event_HSetControlEx_MouseUp = delegate {};
        public event MouseEventHandler Event_HSetControlEx_MouseMove = delegate {};
        public event DragEventHandler Event_HSetControlEx_DragEnter = delegate {};
        public event DragEventHandler Event_HSetControlEx_DragDrop = delegate {};
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetLabel
         */
        public event MouseEventHandler Event_HSetLabelEx_MouseClick = delegate {};
        public event MouseEventHandler Event_HSetLabelEx_MouseDoubleClick = delegate {};
        public event MouseEventHandler Event_HSetLabelEx_MouseMove = delegate {};
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * CarLabel
         */
        public event MouseEventHandler Event_HCarLabelEx_MouseClick = delegate {};
        public event MouseEventHandler Event_HCarLabelEx_MouseDoubleClick = delegate {};
        public event MouseEventHandler Event_HCarLabelEx_MouseMove = delegate {};
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * StaffLabel
         */
        public event MouseEventHandler Event_HStaffLabelEx_MouseClick = delegate {};
        public event MouseEventHandler Event_HStaffLabelEx_MouseDoubleClick = delegate {};
        public event MouseEventHandler Event_HStaffLabelEx_MouseMove = delegate {};

        /// <summary>
        /// コンストラクタ
        /// 配車されているSetControlを作成する
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
            /*
             * SetControlの形状(１列か２列か)を決定する
             */
            switch(hSetControlVo.Purpose) {
                case true: // ２列
                    this.Size = new Size(160, 400);
                    this.ColumnCount = 2;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
                case false: // １列
                    this.Size = new Size(80, 400);
                    this.ColumnCount = 1;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
            }
            // SetLabelを作成
            CreateHSetLabel(hSetControlVo);
            // CarLabelを作成
            CreateHCarLabel(hSetControlVo);
            // StaffLabelを作成
            CreateHStaffLabel(hSetControlVo);
            /*
             * Event
             */
            this.MouseDown += HSetControlEx_MouseDown;
            this.MouseUp += HSetControlEx_MouseUp;
            this.MouseMove += HSetControlEx_MouseMove;
            this.DragEnter += HSetControlEx_DragEnter;
            this.DragDrop += HSetControlEx_DragDrop;
        }

        /// <summary>
        /// CreateHSetLabel
        /// SetCodeがゼロの場合HSetLabelは作成しない
        /// </summary>
        private void CreateHSetLabel(H_SetControlVo hSetControlVo) {
            if(hSetControlVo.HSetMasterVo is not null && hSetControlVo.HSetMasterVo.SetCode != 0) {
                H_SetLabel hSetLabel = new(hSetControlVo);
                /*
                 * Event
                 */
                hSetLabel.MouseClick += HSetLabelEx_MouseClick;
                hSetLabel.MouseDoubleClick += HSetLabelEx_MouseDoubleClick;
                hSetLabel.MouseMove += HSetLabelEx_MouseMove;
                // SetLabelを追加
                this.Controls.Add(hSetLabel, 0, 0);
            }
        }

        /// <summary>
        /// CreateHCarLabel
        /// CarCodeがゼロの場合HCarLabelは作成しない
        /// </summary>
        private void CreateHCarLabel(H_SetControlVo hSetControlVo) {
            if(hSetControlVo.HCarMasterVo is not null && hSetControlVo.HCarMasterVo.CarCode != 0) {
                H_CarLabel hCarLabel = new(hSetControlVo);
                /*
                 * Event
                 */
                hCarLabel.MouseClick += HCarLabelEx_MouseClick;
                hCarLabel.MouseDoubleClick += HCarLabelEx_MouseDoubleClick;
                hCarLabel.MouseMove += HCarLabelEx_MouseMove;
                // CarLabelを追加
                this.Controls.Add(hCarLabel, 0, 1);
            }
        }

        /// <summary>
        /// CreateHStaffLabel
        /// StaffCodeがゼロの場合HStaffLabelは作成しない
        /// </summary>
        /// <param name="listHStaffMasterVo"></param>
        private void CreateHStaffLabel(H_SetControlVo hSetControlVo) {
            int i = 0;
            foreach(H_StaffMasterVo hStaffMasterVo in hSetControlVo.ListHStaffMasterVo) {
                if(hStaffMasterVo.StaffCode != 0) {
                    Point point = _dictionaryCellPoint[i];
                    H_StaffLabel hStaffLabel = new(hStaffMasterVo);
                    /*
                     * Event
                     */
                    hStaffLabel.MouseClick += HStaffLabelEx_MouseClick;
                    hStaffLabel.MouseDoubleClick += HStaffLabelEx_MouseDoubleClick;
                    hStaffLabel.MouseMove += HStaffLabelEx_MouseMove;
                    // StaffLabelを追加
                    this.Controls.Add(hStaffLabel, point.X, point.Y);
                }
                i++;
            }
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
            if(_hSetControlVo.VehicleDispatchFlag) {
                switch(e.Column) {
                    case 0: // １列目
                        switch(e.Row) {
                            case 2: // StaffLabel(1人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 1)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel1の枠線
                                break;
                            case 3: // StaffLabel(2人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 2)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel2の枠線
                                break;
                        }
                        break;
                    case 1: // ２列目
                        switch(e.Row) {
                            case 2: // StaffLabel(3人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 3)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel3の枠線
                                break;
                            case 3: // StaffLabel(4人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 4)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel4の枠線
                                break;
                        }
                        break;
                }
            } else {
            }
        }

        /*
         * H_SetControlEx
         */
        private void HSetControlEx_MouseDown(object sender, MouseEventArgs e) {
            Event_HSetControlEx_MouseDown.Invoke(sender, e);
        }
        private void HSetControlEx_MouseUp(object sender, MouseEventArgs e) {
            Event_HSetControlEx_MouseUp.Invoke(sender, e);
        }
        private void HSetControlEx_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControlEx_MouseMove.Invoke(sender, e);
        }
        private void HSetControlEx_DragEnter(object sender, DragEventArgs e) {
            Event_HSetControlEx_DragEnter.Invoke(sender, e);
        }
        private void HSetControlEx_DragDrop(object sender, DragEventArgs e) {
            Event_HSetControlEx_DragDrop.Invoke(sender, e);
        }
        /*
         * H_SetLabelEx
         */
        private void HSetLabelEx_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetLabelEx_MouseClick.Invoke(sender, e);
        }
        private void HSetLabelEx_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetLabelEx_MouseDoubleClick.Invoke(sender, e);
        }
        private void HSetLabelEx_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetLabelEx_MouseMove.Invoke(sender, e);
        }
        /*
         * H_CarLabelEx
         */
        private void HCarLabelEx_MouseClick(object sender, MouseEventArgs e) {
            Event_HCarLabelEx_MouseClick.Invoke(sender, e);
        }
        private void HCarLabelEx_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HCarLabelEx_MouseDoubleClick.Invoke(sender, e);
        }
        private void HCarLabelEx_MouseMove(object sender, MouseEventArgs e) {
            Event_HCarLabelEx_MouseMove.Invoke(sender, e);
        }
        /*
         * H_StaffLabelEx
         */
        private void HStaffLabelEx_MouseClick(object sender, MouseEventArgs e) {
            Event_HStaffLabelEx_MouseClick.Invoke(sender, e);
        }
        private void HStaffLabelEx_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HStaffLabelEx_MouseDoubleClick.Invoke(sender, e);
        }
        private void HStaffLabelEx_MouseMove(object sender, MouseEventArgs e) {
            Event_HStaffLabelEx_MouseMove.Invoke(sender, e);
        }
    }
}
