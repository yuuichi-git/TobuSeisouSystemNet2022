﻿/*
 * 2023-10-20
 */
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
        /*
         * StaffLabel用のCellの位置を保持
         */
        private Dictionary<int, Point> _dictionaryCellPoint = new() { { 0, new Point(0, 2) }, { 1, new Point(0, 3) }, { 2, new Point(1, 2) }, { 3, new Point(1, 3) } }; // StaffLabel用のCellの位置
        /*
         * Vo
         */
        private readonly H_ControlVo _hControlVo;
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetControl
         */
        public event MouseEventHandler Event_HSetControlEx_MouseDown = delegate { };
        public event MouseEventHandler Event_HSetControlEx_MouseUp = delegate { };
        public event MouseEventHandler Event_HSetControlEx_MouseMove = delegate { };
        public event DragEventHandler Event_HSetControlEx_DragEnter = delegate { };
        public event DragEventHandler Event_HSetControlEx_DragDrop = delegate { };
        public event DragEventHandler Event_HSetControlEx_DragOver = delegate { };
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetLabel
         */
        public event MouseEventHandler Event_HSetLabelEx_MouseClick = delegate { };
        public event MouseEventHandler Event_HSetLabelEx_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HSetLabelEx_MouseMove = delegate { };
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * CarLabel
         */
        public event MouseEventHandler Event_HCarLabelEx_MouseClick = delegate { };
        public event MouseEventHandler Event_HCarLabelEx_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HCarLabelEx_MouseMove = delegate { };
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * StaffLabel
         */
        public event MouseEventHandler Event_HStaffLabelEx_MouseClick = delegate { };
        public event MouseEventHandler Event_HStaffLabelEx_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HStaffLabelEx_MouseMove = delegate { };

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
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Name = "H_SetControl";
            this.Padding = new Padding(0);
            this.Tag = hControlVo;
            /*
             * SetControlの形状(１列か２列か)を決定する
             */
            switch (hControlVo.PurposeFlag) {
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
            // SetLabelを作成
            CreateHSetLabel(hControlVo);
            // CarLabelを作成
            CreateHCarLabel(hControlVo);
            // StaffLabelを作成
            CreateHStaffLabel(hControlVo);
            /*
             * Event
             */
            this.MouseDown += HSetControlEx_MouseDown;
            this.MouseUp += HSetControlEx_MouseUp;
            this.MouseMove += HSetControlEx_MouseMove;
            this.MouseLeave += HSetControlEx_MouseLeave;
            this.DragEnter += HSetControlEx_DragEnter;
            this.DragDrop += HSetControlEx_DragDrop;
            this.DragOver += HSetControlEx_DragOver;
        }

        /// <summary>
        /// CreateHSetLabel
        /// SetCodeがゼロの場合HSetLabelは作成しない
        /// </summary>
        private void CreateHSetLabel(H_ControlVo hControlVo) {
            if (hControlVo.HSetMasterVo is not null && hControlVo.HSetMasterVo.SetCode != 0) {
                H_SetLabel hSetLabel = new(hControlVo);
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
        private void CreateHCarLabel(H_ControlVo hControlVo) {
            if (hControlVo.HCarMasterVo is not null && hControlVo.HCarMasterVo.CarCode != 0) {
                H_CarLabel hCarLabel = new(hControlVo);
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
        private void CreateHStaffLabel(H_ControlVo hControlVo) {
            int i = 0;
            foreach (H_StaffMasterVo hStaffMasterVo in hControlVo.ListHStaffMasterVo) {
                if (hStaffMasterVo.StaffCode != 0) {
                    hControlVo.HStaffMasterVo = hStaffMasterVo;
                    hControlVo.SelectNumberStaffMasterVo = i; // List内の何番目のデータかを格納
                    H_StaffLabel hStaffLabel = new(hControlVo);
                    /*
                     * Event
                     */
                    hStaffLabel.MouseClick += HStaffLabelEx_MouseClick;
                    hStaffLabel.MouseDoubleClick += HStaffLabelEx_MouseDoubleClick;
                    hStaffLabel.MouseMove += HStaffLabelEx_MouseMove;
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
            /*
             * Boderを描画する
             */
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
            if (_hControlVo.VehicleDispatchFlag) {
                switch (e.Column) {
                    case 0: // １列目
                        switch (e.Row) {
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
        private void HSetControlEx_MouseDown(object sender, MouseEventArgs e) {
            Event_HSetControlEx_MouseDown.Invoke(sender, e);
        }
        private void HSetControlEx_MouseUp(object sender, MouseEventArgs e) {
            Event_HSetControlEx_MouseUp.Invoke(sender, e);
        }
        private void HSetControlEx_MouseMove(object sender, MouseEventArgs e) {
            /*
             * Control上にカーソルがある
             */
            _newOnCursorFlag = true;
            if (_oldOnCursorFlag != _newOnCursorFlag) {
                _oldOnCursorFlag = _newOnCursorFlag;
                Refresh();
            }
            Event_HSetControlEx_MouseMove.Invoke(sender, e);
        }
        private void HSetControlEx_MouseLeave(object sender, EventArgs e) {
            /*
             * Control上にカーソルがない
             */
            _newOnCursorFlag = false;
            if (_oldOnCursorFlag != _newOnCursorFlag) {
                _oldOnCursorFlag = _newOnCursorFlag;
                Refresh();
            }
        }
        private void HSetControlEx_DragEnter(object sender, DragEventArgs e) {
            Event_HSetControlEx_DragEnter.Invoke(sender, e);
        }
        private void HSetControlEx_DragDrop(object sender, DragEventArgs e) {
            Event_HSetControlEx_DragDrop.Invoke(sender, e);
        }
        private void HSetControlEx_DragOver(object sender, DragEventArgs e) {
            Event_HSetControlEx_DragOver.Invoke(sender, e);
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
    }
}
