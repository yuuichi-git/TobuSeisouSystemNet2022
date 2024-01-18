/*
 * 2023-10-20
 */
using System.Windows.Forms;

using H_Vo;

namespace H_ControlEx {
    public partial class H_SetControl : TableLayoutPanel {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
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
        private bool _oldOnCursorFlag = false;
        private bool _newOnCursorFlag = false;
        /// <summary>
        /// 連絡事項フラグ
        /// </summary>
        private bool _contactInfomationFlag = false;
        /// <summary>
        /// Fax送信確認フラグ
        /// </summary>
        private bool _faxTransmissionFlag = false;
        /*
         * SetControlExを囲うPointと半透明色を設定する
         */
        private readonly SolidBrush _solidBrushContactInformation = new(Color.FromArgb(70, Color.LimeGreen));
        private readonly SolidBrush _solidBrushFaxTransmission = new(Color.FromArgb(70, Color.IndianRed));
        /*
         * StaffLabel用のCellの位置を保持
         */
        private readonly Dictionary<int, Point> _dictionaryCellPoint = new() { { 0, new Point(0, 2) }, { 1, new Point(0, 3) }, { 2, new Point(1, 2) }, { 3, new Point(1, 3) } }; // StaffLabel用のCellの位置
        /*
         * Vo
         */
        private readonly H_ControlVo _hControlVo;
        private readonly H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetControl
         */
        public event MouseEventHandler Event_HSetControl_MouseDown = delegate { };
        public event MouseEventHandler Event_HSetControl_MouseUp = delegate { };
        public event MouseEventHandler Event_HSetControl_MouseMove = delegate { };
        public event DragEventHandler Event_HSetControl_DragEnter = delegate { };
        public event DragEventHandler Event_HSetControl_DragDrop = delegate { };
        public event DragEventHandler Event_HSetControl_DragOver = delegate { };
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetLabel
         */
        public event MouseEventHandler Event_HSetControl_HSetLabel_MouseClick = delegate { };
        public event MouseEventHandler Event_HSetControl_HSetLabel_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HSetControl_HSetLabel_MouseMove = delegate { };
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * CarLabel
         */
        public event MouseEventHandler Event_HSetControl_HCarLabel_MouseClick = delegate { };
        public event MouseEventHandler Event_HSetControl_HCarLabel_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HSetControl_HCarLabel_MouseMove = delegate { };
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * StaffLabel
         */
        public event MouseEventHandler Event_HSetControl_HStaffLabel_MouseClick = delegate { };
        public event MouseEventHandler Event_HSetControl_HStaffLabel_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HSetControl_HStaffLabel_MouseMove = delegate { };

        /// <summary>
        /// コンストラクタ
        /// 配車されているSetControlを作成する
        /// H_SetControlVoに全ての引数を代入しておく
        /// </summary>
        public H_SetControl(H_ControlVo hControlVo) {
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            _hVehicleDispatchDetailVo = hControlVo.HVehicleDispatchDetailVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Name = "H_SetControl";
            this.Padding = new Padding(0);
            this.Tag = _hControlVo;
            /*
             * SetControlの形状(１列か２列か)を決定する
             */
            switch (_hControlVo.PurposeFlag) {
                case false: // １列
                    this.Size = new Size(80, 400);
                    this.ColumnCount = _columnCount;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
                case true: // ２列
                    this.Size = new Size(160, 400);
                    this.ColumnCount = _columnCount + 1;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
            }
            /*
             * H_SetControl特有の動作を設定
             */
            if (_hVehicleDispatchDetailVo is not null) {
                _contactInfomationFlag = _hVehicleDispatchDetailVo.ContactInfomationFlag;
                _faxTransmissionFlag = _hVehicleDispatchDetailVo.FaxTransmissionFlag;
            }
            /*
             * Event
             */
            this.MouseDown += HSetControl_MouseDown;
            this.MouseUp += HSetControl_MouseUp;
            this.MouseMove += HSetControl_MouseMove;
            this.MouseLeave += HSetControl_MouseLeave;
            this.DragEnter += HSetControl_DragEnter;
            this.DragDrop += HSetControl_DragDrop;
            this.DragOver += HSetControl_DragOver;
            /*
             * H_SetControlに格納する各Labelを作成する 
             */
            CreateHSetLabel(_hControlVo); // SetLabel           
            CreateHCarLabel(_hControlVo); // CarLabel
            CreateHStaffLabel(_hControlVo); // StaffLabel
        }

        /// <summary>
        /// CreateHSetLabel
        /// SetCodeがゼロの場合HSetLabelは作成しない
        /// </summary>
        private void CreateHSetLabel(H_ControlVo hControlVo) {
            if (hControlVo.HSetMasterVo is not null && hControlVo.HSetMasterVo.SetCode != 0) {
                H_SetLabel hSetLabel = new(hControlVo);
                /*
                 * イベントを登録
                 */
                hSetLabel.Event_HSetLabel_MouseClick += HSetControl_HSetLabel_MouseClick;
                hSetLabel.Event_HSetLabel_MouseDoubleClick += HSetControl_HSetLabel_MouseDoubleClick;
                hSetLabel.Event_HSetLabel_MouseMove += HSetControl_HSetLabel_MouseMove;
                // SetLabelを追加
                this.Controls.Add(hSetLabel, 0, 0);
            }
        }

        /// <summary>
        /// CreateHCarLabel
        /// CarCodeがゼロの場合HCarLabelは作成しない
        /// </summary>
        private void CreateHCarLabel(H_ControlVo hControlVo) {
            if (hControlVo.HCarMasterVo is not null && hControlVo.HCarMasterVo.CarCode != 0) {
                H_CarLabel hCarLabel = new(hControlVo);
                /*
                 * イベントを登録
                 */
                hCarLabel.Event_HCarLabel_MouseClick += HSetControl_HCarLabel_MouseClick;
                hCarLabel.Event_HCarLabel_MouseDoubleClick += HSetControl_HCarLabel_MouseDoubleClick;
                hCarLabel.Event_HCarLabel_MouseMove += HSetControl_HCarLabel_MouseMove;
                // CarLabelを追加
                this.Controls.Add(hCarLabel, 0, 1);
            }
        }

        /// <summary>
        /// CreateHStaffLabel
        /// StaffCodeがゼロの場合HStaffLabelは作成しない
        /// </summary>
        /// <param name="listHStaffMasterVo"></param>
        private void CreateHStaffLabel(H_ControlVo hControlVo) {
            int i = 0;
            foreach (H_StaffMasterVo hStaffMasterVo in hControlVo.ListHStaffMasterVo) {
                if (hStaffMasterVo.StaffCode != 0) {
                    hControlVo.HStaffMasterVo = hStaffMasterVo;
                    hControlVo.SelectNumberStaffMasterVo = i; // List内の何番目のデータかを格納
                    H_StaffLabel hStaffLabel = new(hControlVo);
                    /*
                     * イベントを登録
                     */
                    hStaffLabel.Event_HStaffLabel_MouseClick += HSetControl_HStaffLabel_MouseClick;
                    hStaffLabel.Event_HStaffLabel_MouseDoubleClick += HSetControl_HStaffLabel_MouseDoubleClick;
                    hStaffLabel.Event_HStaffLabel_MouseMove += HSetControl_HStaffLabel_MouseMove;
                    // StaffLabelを追加
                    this.Controls.Add(hStaffLabel, _dictionaryCellPoint[i].X, _dictionaryCellPoint[i].Y);
                }
                i++;
            }
        }

        /// <summary>
        /// OnCellPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e) {
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
            /*
             * Boderを描画する
             */
            if (_hControlVo.VehicleDispatchFlag) {
                switch (e.Column) {
                    case 0: // １列目
                        switch (e.Row) {
                            case 0: // H_SetLabel
                                if (_contactInfomationFlag)
                                    e.Graphics.FillRectangle(_solidBrushContactInformation, rectangle);
                                if (_faxTransmissionFlag)
                                    e.Graphics.FillRectangle(_solidBrushFaxTransmission, rectangle);
                                break;
                            case 1: // H_CarLabel
                                if (_contactInfomationFlag)
                                    e.Graphics.FillRectangle(_solidBrushContactInformation, rectangle);
                                if (_faxTransmissionFlag)
                                    e.Graphics.FillRectangle(_solidBrushFaxTransmission, rectangle);
                                break;
                            case 2: // StaffLabel(1人目)
                                if (_hControlVo.HSetMasterVo.NumberOfPeople >= 1)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel1の枠線
                                break;
                            case 3: // StaffLabel(2人目)
                                if (_hControlVo.HSetMasterVo.NumberOfPeople >= 2)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel2の枠線
                                break;
                        }
                        break;
                    case 1: // ２列目
                        switch (e.Row) {
                            case 2: // StaffLabel(3人目)
                                if (_hControlVo.HSetMasterVo.NumberOfPeople >= 3)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel3の枠線
                                break;
                            case 3: // StaffLabel(4人目)
                                if (_hControlVo.HSetMasterVo.NumberOfPeople >= 4)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel4の枠線
                                break;
                        }
                        break;
                }
            } else {
            }
            /*
             * H_SetControlの外枠を描画する
             */
            if (_oldOnCursorFlag) {
                if (((H_ControlVo)this.Tag).PurposeFlag) {
                    e.Graphics.DrawRectangle(new Pen(Color.DarkBlue, 2), new Rectangle(1, 1, 158, 398));
                } else {
                    e.Graphics.DrawRectangle(new Pen(Color.DarkBlue, 2), new Rectangle(1, 1, 78, 398));
                }
            }
        }

        /*
         * H_SetControlEx
         */
        private void HSetControl_MouseDown(object sender, MouseEventArgs e) {
            Event_HSetControl_MouseDown.Invoke(sender, e);
        }
        private void HSetControl_MouseUp(object sender, MouseEventArgs e) {
            Event_HSetControl_MouseUp.Invoke(sender, e);
        }
        private void HSetControl_MouseMove(object sender, MouseEventArgs e) {
            /*
             * Control上にカーソルがある
             */
            _newOnCursorFlag = true;
            if (_oldOnCursorFlag != _newOnCursorFlag) {
                _oldOnCursorFlag = _newOnCursorFlag;
                Refresh();
            }
            Event_HSetControl_MouseMove.Invoke(sender, e);
        }
        private void HSetControl_MouseLeave(object sender, EventArgs e) {
            /*
             * Control上にカーソルがない
             */
            _newOnCursorFlag = false;
            if (_oldOnCursorFlag != _newOnCursorFlag) {
                _oldOnCursorFlag = _newOnCursorFlag;
                Refresh();
            }
        }
        private void HSetControl_DragEnter(object sender, DragEventArgs e) {
            Event_HSetControl_DragEnter.Invoke(sender, e);
        }
        private void HSetControl_DragDrop(object sender, DragEventArgs e) {
            Event_HSetControl_DragDrop.Invoke(sender, e);
        }
        private void HSetControl_DragOver(object sender, DragEventArgs e) {
            Event_HSetControl_DragOver.Invoke(sender, e);
        }
        /*
         * H_SetLabelEx
         */
        private void HSetControl_HSetLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HSetLabel_MouseClick.Invoke(sender, e);
        }
        private void HSetControl_HSetLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HSetLabel_MouseDoubleClick.Invoke(sender, e);
        }
        private void HSetControl_HSetLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_HSetLabel_MouseMove.Invoke(sender, e);
        }
        /*
         * H_CarLabelEx
         */
        private void HSetControl_HCarLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HCarLabel_MouseClick.Invoke(sender, e);
        }
        private void HSetControl_HCarLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HCarLabel_MouseDoubleClick.Invoke(sender, e);
        }
        private void HSetControl_HCarLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_HCarLabel_MouseMove.Invoke(sender, e);
        }
        /*
         * H_StaffLabelEx
         */
        private void HSetControl_HStaffLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HStaffLabel_MouseClick.Invoke(sender, e);
        }
        private void HSetControl_HStaffLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HStaffLabel_MouseDoubleClick.Invoke(sender, e);
        }
        private void HSetControl_HStaffLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_HStaffLabel_MouseMove.Invoke(sender, e);
        }

        /*
         * Getter/Setter
         */
        /// <summary>
        /// H_SetControlを解析してH_VehicleDispatchDetailVoに変換(作成)する
        /// </summary>
        /// <param name="hSetControl"></param>
        /// <returns></returns>
        public H_VehicleDispatchDetailVo CreateHVehicleDispatchDetailVo() {
            H_VehicleDispatchDetailVo hVehicleDispatchDetailVo = new();
            H_ControlVo hControlVo = (H_ControlVo)this.Tag;
            hVehicleDispatchDetailVo.CellNumber = hControlVo.CellNumber;
            hVehicleDispatchDetailVo.OperationDate = hControlVo.OperationDate;
            hVehicleDispatchDetailVo.OperationFlag = hControlVo.OperationFlag;
            hVehicleDispatchDetailVo.PurposeFlag = hControlVo.PurposeFlag;
            hVehicleDispatchDetailVo.VehicleDispatchFlag = hControlVo.VehicleDispatchFlag;
            /*
             * 配車先関連の処理
             * Labelが存在していなければVoのDefault値
             */
            var objectSet = this.GetControlFromPosition(0, 0); // Controlが存在しなければNULLが返る
            if (objectSet is not null) {
                H_SetLabel hSetLabel = (H_SetLabel)objectSet;
                H_SetMasterVo hSetMasterVo = (H_SetMasterVo)objectSet.Tag;
                hVehicleDispatchDetailVo.AddWorkerFlag = hSetLabel.AddWorkerFlag;
                hVehicleDispatchDetailVo.ClassificationCode = hSetLabel.ClassificationCode;
                hVehicleDispatchDetailVo.ContactInfomationFlag = hSetLabel.ContactInfomationFlag;
                hVehicleDispatchDetailVo.FaxTransmissionFlag = hSetLabel.FaxTransmissionFlag;
                hVehicleDispatchDetailVo.LastRollCallFlag = hSetLabel.LastRollCallFlag;
                hVehicleDispatchDetailVo.LastRollCallYmdHms = hSetLabel.LastRollCallYmdHms;
                hVehicleDispatchDetailVo.ManagedSpaceCode = hSetLabel.ManagedSpaceCode;
                hVehicleDispatchDetailVo.SetCode = hSetMasterVo.SetCode;
                hVehicleDispatchDetailVo.SetMemo = hSetLabel.Memo;
                hVehicleDispatchDetailVo.SetMemoFlag = hSetLabel.MemoFlag;
                hVehicleDispatchDetailVo.ShiftCode = hSetLabel.ShiftCode;
                hVehicleDispatchDetailVo.StandByFlag = hSetLabel.StandByFlag;
            }
            /*
             * 車両関連の処理
             * Labelが存在していなければVoのDefault値
             */
            var objectCar = this.GetControlFromPosition(0, 1); // Controlが存在しなければNULLが返る
            if (objectCar is not null) {
                H_CarLabel hCarLabel = (H_CarLabel)objectCar;
                H_CarMasterVo hCarMasterVo = (H_CarMasterVo)objectCar.Tag;
                hVehicleDispatchDetailVo.CarCode = hCarMasterVo.CarCode;
                hVehicleDispatchDetailVo.CarGarageCode = hCarMasterVo.GarageCode;
                hVehicleDispatchDetailVo.CarMemo = hCarLabel.CarMemo;
                hVehicleDispatchDetailVo.CarMemoFlag = hCarLabel.CarMemoFlag;
                hVehicleDispatchDetailVo.CarProxyFlag = hCarLabel.CarProxyFlag;
            }
            /*
             * 従事者関連の処理
             * Labelが存在していなければVoのDefault値
             */
            /*
             * 運転手
             */
            var objectStaff1 = this.GetControlFromPosition(0, 2); // Controlが存在しなければNULLが返る
            if (objectStaff1 is not null) {
                H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff1;
                H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff1.Tag;
                hVehicleDispatchDetailVo.StaffCode1 = hStaffMasterVo.StaffCode;
                hVehicleDispatchDetailVo.StaffOccupation1 = hStaffLabel.StaffOccupationCode;
                hVehicleDispatchDetailVo.StaffProxyFlag1 = hStaffLabel.StaffProxyFlag;
                hVehicleDispatchDetailVo.StaffRollCallFlag1 = hStaffLabel.StaffRollCallFlag;
                hVehicleDispatchDetailVo.StaffRollCallYmdHms1 = hStaffLabel.StaffRollCallYmdHms;
                hVehicleDispatchDetailVo.StaffMemoFlag1 = hStaffLabel.StaffMemoFlag;
                hVehicleDispatchDetailVo.StaffMemo1 = hStaffLabel.StaffMemo;
            }
            /*
             * 作業員１
             */
            var objectStaff2 = this.GetControlFromPosition(0, 3); // Controlが存在しなければNULLが返る
            if (objectStaff2 is not null) {
                H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff2;
                H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff2.Tag;
                hVehicleDispatchDetailVo.StaffCode2 = hStaffMasterVo.StaffCode;
                hVehicleDispatchDetailVo.StaffOccupation2 = hStaffMasterVo.Occupation;
                hVehicleDispatchDetailVo.StaffProxyFlag2 = hStaffLabel.StaffProxyFlag;
                hVehicleDispatchDetailVo.StaffRollCallFlag2 = hStaffLabel.StaffRollCallFlag;
                hVehicleDispatchDetailVo.StaffRollCallYmdHms2 = hStaffLabel.StaffRollCallYmdHms;
                hVehicleDispatchDetailVo.StaffMemoFlag2 = hStaffLabel.StaffMemoFlag;
                hVehicleDispatchDetailVo.StaffMemo2 = hStaffLabel.StaffMemo;
            }
            /*
             * H_SetControlの形状が２列の場合、作業員２・３の処理をする
             */
            if (hControlVo.PurposeFlag) {
                /*
                 * 作業員２
                 */
                var objectStaff3 = this.GetControlFromPosition(1, 2); // Controlが存在しなければNULLが返る
                if (objectStaff3 is not null) {
                    H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff3;
                    H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff3.Tag;
                    hVehicleDispatchDetailVo.StaffCode3 = hStaffMasterVo.StaffCode;
                    hVehicleDispatchDetailVo.StaffOccupation3 = hStaffMasterVo.Occupation;
                    hVehicleDispatchDetailVo.StaffProxyFlag3 = hStaffLabel.StaffProxyFlag;
                    hVehicleDispatchDetailVo.StaffRollCallFlag3 = hStaffLabel.StaffRollCallFlag;
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms3 = hStaffLabel.StaffRollCallYmdHms;
                    hVehicleDispatchDetailVo.StaffMemoFlag3 = hStaffLabel.StaffMemoFlag;
                    hVehicleDispatchDetailVo.StaffMemo3 = hStaffLabel.StaffMemo;
                }
                /*
                 * 作業員３
                 */
                var objectStaff4 = this.GetControlFromPosition(1, 3); // Controlが存在しなければNULLが返る
                if (objectStaff4 is not null) {
                    H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff4;
                    H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff4.Tag;
                    hVehicleDispatchDetailVo.StaffCode4 = hStaffMasterVo.StaffCode;
                    hVehicleDispatchDetailVo.StaffOccupation4 = hStaffMasterVo.Occupation;
                    hVehicleDispatchDetailVo.StaffProxyFlag4 = hStaffLabel.StaffProxyFlag;
                    hVehicleDispatchDetailVo.StaffRollCallFlag4 = hStaffLabel.StaffRollCallFlag;
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms4 = hStaffLabel.StaffRollCallYmdHms;
                    hVehicleDispatchDetailVo.StaffMemoFlag4 = hStaffLabel.StaffMemoFlag;
                    hVehicleDispatchDetailVo.StaffMemo4 = hStaffLabel.StaffMemo;
                }
            }
            hVehicleDispatchDetailVo.InsertPcName = Environment.MachineName;
            hVehicleDispatchDetailVo.InsertYmdHms = DateTime.Now;
            hVehicleDispatchDetailVo.UpdatePcName = string.Empty;
            hVehicleDispatchDetailVo.UpdateYmdHms = _defaultDateTime;
            hVehicleDispatchDetailVo.DeletePcName = string.Empty;
            hVehicleDispatchDetailVo.DeleteYmdHms = _defaultDateTime;
            hVehicleDispatchDetailVo.DeleteFlag = false;

            return hVehicleDispatchDetailVo;
        }

        /*
         * アクセサー
         */
        /// <summary>
        /// 連絡事項フラグ
        /// true:連絡事項あり false:なし
        /// </summary>
        public bool ContactInfomationFlag {
            get => _contactInfomationFlag;
            set {
                _contactInfomationFlag = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// Fax送信確認フラグ
        /// true:Fax送信あり false:なし
        /// </summary>
        public bool FaxTransmissionFlag {
            get => _faxTransmissionFlag;
            set {
                _faxTransmissionFlag = value;
                this.Refresh();
            }
        }
    }
}
