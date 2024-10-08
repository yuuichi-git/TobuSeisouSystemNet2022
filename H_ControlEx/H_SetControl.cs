﻿/*
 * 2023-10-20
 */
using H_Dao;

using H_Vo;

namespace H_ControlEx {
    public partial class H_SetControl : TableLayoutPanel {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 75; // 2024-02-24 80→75に変更
        private const float _panelHeight = 120;
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
         * 透かし文字用のフォーマット
         */
        private StringFormat _stringFormat;
        /*
         * 空のSetControlExの文字列表示用
         */
        private readonly Rectangle _rectangleFill = new(2, 2, 76, 116);
        private readonly Font _drawFont = new("Yu Gothic UI", 14, FontStyle.Italic, GraphicsUnit.Pixel);
        private readonly SolidBrush _drawBrushFont = new(Color.DarkGray);
        /*
         * StaffLabel用のCellの位置を保持
         */
        private readonly Dictionary<int, Point> _dictionaryCellPoint = new() { { 0, new Point(0, 2) }, { 1, new Point(0, 3) }, { 2, new Point(1, 2) }, { 3, new Point(1, 3) } }; // StaffLabel用のCellの位置
        /*
         * Dao
         */
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
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
        // SetLabel,CarLabel,StaffLabel 共通
        public event EventHandler Event_HSetControl_HLabel_ToolStripMenuItem_Click = delegate { };
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
        /// コンストラクター
        /// 配車されているSetControlを作成する
        /// H_SetControlVoに全ての引数を代入しておく
        /// </summary>
        public H_SetControl(H_ControlVo hControlVo) {
            /*
             * 透かし文字用のフォーマット
             */
            _stringFormat = new StringFormat();
            _stringFormat.LineAlignment = StringAlignment.Center;
            _stringFormat.Alignment = StringAlignment.Center;
            /*
             * Dao
             */
            _hVehicleDispatchDetailDao = new(hControlVo.ConnectionVo);
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            _hVehicleDispatchDetailVo = hControlVo.HVehicleDispatchDetailVo;
            /*
             * InitializeControl
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
            switch (_hControlVo.PurposeFlag) {
                case false: // １列
                    // H_SetControlのサイズ
                    this.Size = new Size(75, 400);
                    /*
                     * Column作成
                     */
                    this.ColumnCount = _columnCount;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    /*
                     * Row作成
                     */
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
                case true: // ２列
                    // H_SetControlのサイズ
                    this.Size = new Size(150, 400);
                    /*
                     * Column作成
                     */
                    this.ColumnCount = _columnCount + 1;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    /*
                     * Row作成
                     */
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
             * Event登録
             */
            this.MouseDown += HSetControl_MouseDown;
            this.MouseEnter += HSetControl_MouseEnter; // 2024-07-18追加
            this.MouseLeave += HSetControl_MouseLeave; // 2024-07-18追加
            this.MouseMove += HSetControl_MouseMove; // 2024-07-18追加
            this.MouseUp += HSetControl_MouseUp;

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
                hSetLabel.MouseClick += HSetControl_HSetLabel_MouseClick;
                hSetLabel.MouseDoubleClick += HSetControl_HSetLabel_MouseDoubleClick;
                hSetLabel.MouseEnter += HSetControl_MouseEnter; // 2024-07-18追加
                hSetLabel.MouseLeave += HSetControl_MouseLeave; // 2024-07-18追加
                hSetLabel.MouseMove += HSetControl_HSetLabel_MouseMove; // H_BoardでD&D用
                hSetLabel.Event_HSetLabel_ToolStripMenuItem_Click += HSetControl_HSetLabel_ToolStripMenuItem_Click;
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
                hCarLabel.MouseClick += HSetControl_HCarLabel_MouseClick;
                hCarLabel.MouseDoubleClick += HSetControl_HCarLabel_MouseDoubleClick;
                hCarLabel.MouseEnter += HSetControl_MouseEnter; // 2024-07-18追加
                hCarLabel.MouseLeave += HSetControl_MouseLeave; // 2024-07-18追加
                hCarLabel.MouseMove += HSetControl_HCarLabel_MouseMove; // H_BoardでD&D用
                hCarLabel.Event_HCarLabel_ToolStripMenuItem_Click += HSetControl_HCarLabel_ToolStripMenuItem_Click;
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
                    /*
                     * イベントを登録
                     */
                    H_StaffLabel hStaffLabel = new(hControlVo);
                    hStaffLabel.MouseClick += HSetControl_HStaffLabel_MouseClick;
                    hStaffLabel.MouseDoubleClick += HSetControl_HStaffLabel_MouseDoubleClick;
                    hStaffLabel.MouseEnter += HSetControl_MouseEnter; // 2024-07-18追加
                    hStaffLabel.MouseLeave += HSetControl_MouseLeave; // 2024-07-18追加
                    hStaffLabel.MouseMove += HSetControl_HStaffLabel_MouseMove; // H_BoardでD&D用
                    hStaffLabel.Event_HStaffLabel_ToolStripMenuItem_Click += HSetControl_HStaffLabel_ToolStripMenuItem_Click;
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
                                if (_hControlVo.HSetMasterVo is not null && _hControlVo.HSetMasterVo.NumberOfPeople >= 1)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel1の枠線
                                break;
                            case 3: // StaffLabel(2人目)
                                if (_hControlVo.HSetMasterVo is not null && _hControlVo.HSetMasterVo.NumberOfPeople >= 2)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel2の枠線
                                break;
                        }
                        break;
                    case 1: // ２列目
                        switch (e.Row) {
                            case 2: // StaffLabel(3人目)
                                if (_hControlVo.HSetMasterVo is not null && _hControlVo.HSetMasterVo.NumberOfPeople >= 3)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel3の枠線
                                break;
                            case 3: // StaffLabel(4人目)
                                if (_hControlVo.HSetMasterVo is not null && _hControlVo.HSetMasterVo.NumberOfPeople >= 4)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabel4の枠線
                                break;
                        }
                        break;
                }
            } else {
                switch (_hControlVo.CellNumber) {
                    /*
                     * 管理者
                     */
                    case 44:
                    case 45:
                        e.Graphics.DrawString(string.Concat("本社", "\r\n", "運行管理"), _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                    case 46:
                        e.Graphics.DrawString(string.Concat("三郷", "\r\n", "運行管理"), _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                    case 47:
                    case 48:
                        e.Graphics.DrawString(string.Concat("本社", "\r\n", "整備管理"), _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                    case 49:
                        e.Graphics.DrawString(string.Concat("三郷", "\r\n", "整備管理"), _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                    /*
                     * 大型枠
                     */
                    case 120:
                        e.Graphics.DrawString("コンテナ", _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                    case 121:
                    case 122:
                    case 123:
                    case 124:
                    case 125:
                    case 126:
                    case 127:
                    case 128:
                    case 129:
                        e.Graphics.DrawString("大型ダンプ", _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                    case 130:
                    case 131:
                        e.Graphics.DrawString("鉄道", _drawFont, _drawBrushFont, _rectangleFill, _stringFormat);
                        break;
                }
            }
            /*
             * H_SetControlの外枠を描画する
             */
            if (_oldOnCursorFlag) {
                if (((H_ControlVo)this.Tag).PurposeFlag) {
                    e.Graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(2, 1, 146, 477));
                } else {
                    e.Graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(2, 1, 71, 477));
                }
            }
        }

        /// <summary>
        /// HSetControl_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseDown(object sender, MouseEventArgs e) {
            Event_HSetControl_MouseDown.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_MouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseUp(object sender, MouseEventArgs e) {
            Event_HSetControl_MouseUp.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_MouseEnter
        /// H_SetControl/H_SetLabel/H_CarLabel/H_StaffLabelからのMouseEnterを受け取り_newOnCursorFlagをセットする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseEnter(object sender, EventArgs e) {
            /*
             * Control上にカーソルがある
             */
            _newOnCursorFlag = true;
            if (_oldOnCursorFlag != _newOnCursorFlag) {
                _oldOnCursorFlag = _newOnCursorFlag;
                this.Refresh();
            }
        }

        /// <summary>
        /// HSetControl_MouseLeave
        /// H_SetControl/H_SetLabel/H_CarLabel/H_StaffLabelからのMouseEnterを受け取り_newOnCursorFlagをセットする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseLeave(object sender, EventArgs e) {
            /*
             * Control上にカーソルがない
             */
            _newOnCursorFlag = false;
            if (_oldOnCursorFlag != _newOnCursorFlag) {
                _oldOnCursorFlag = _newOnCursorFlag;
                this.Refresh();
            }
        }

        /// <summary>
        /// HSetControl_MouseMove
        /// H_SetControlでMouseMoveが発生した時、画面をスクロールさせる為のイベントを親へ転送する
        /// 実際のスクロール処理は、親側で実装している
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_MouseMove.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragEnter(object sender, DragEventArgs e) {
            Event_HSetControl_DragEnter.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragDrop(object sender, DragEventArgs e) {
            /*
             * ここでDrop先にObjectが存在した場合、以降の処理をキャンセルするコードを書く
             */
            bool updateFlag = false; // true:更新不可能 false:更新可能
            /*
             * H_SetLabel
             */
            if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                try {
                    H_SetLabel dragItem = (H_SetLabel)e.Data.GetData(typeof(H_SetLabel));
                    /*
                     * 
                     * Eventを再設定する
                     * 
                     */
                    switch (dragItem.Parent.Name) {
                        case "H_SetControl":
                            /*
                             * H_StaffLabelが移動する前のH_SetControlのEventを削除する
                             */
                            H_SetControl beforeHSetControl = (H_SetControl)dragItem.Parent;
                            dragItem.MouseClick -= beforeHSetControl.HSetControl_HSetLabel_MouseClick;
                            dragItem.MouseDoubleClick -= beforeHSetControl.HSetControl_HSetLabel_MouseDoubleClick;
                            dragItem.MouseMove -= beforeHSetControl.HSetControl_HSetLabel_MouseMove;
                            dragItem.MouseEnter -= beforeHSetControl.HSetControl_MouseEnter;
                            dragItem.MouseLeave -= beforeHSetControl.HSetControl_MouseLeave;
                            /*
                             * Drop後のH_SetControlにEventを追加する
                             */
                            dragItem.MouseClick += HSetControl_HSetLabel_MouseClick;
                            dragItem.MouseDoubleClick += HSetControl_HSetLabel_MouseDoubleClick;
                            dragItem.MouseMove += HSetControl_HSetLabel_MouseMove;
                            dragItem.MouseEnter += HSetControl_MouseEnter;
                            dragItem.MouseLeave += HSetControl_MouseLeave;
                            break;
                    }
                    // Drop先にH_SetLabelExが存在するかチェックする
                    updateFlag = _hVehicleDispatchDetailDao.CheckSetCode(_hControlVo.CellNumber, _hControlVo.OperationDate);
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                if (updateFlag) {
                    MessageBox.Show("ドロップ先のセルには既に配車先ラベルがセットされています。最新化をして下さい", "データベース同期エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } else {
                    // Eventを親へ転送する
                    Event_HSetControl_DragDrop.Invoke(sender, e);
                }
            }
            /*
             * H_CarLabel
             */
            if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                try {
                    H_CarLabel dragItem = (H_CarLabel)e.Data.GetData(typeof(H_CarLabel));
                    /*
                     * 
                     * Eventを再設定する
                     * 
                     */
                    switch (dragItem.Parent.Name) {
                        case "H_SetControl":
                            /*
                             * H_StaffLabelが移動する前のH_SetControlのEventを削除する
                             */
                            H_SetControl beforeHSetControl = (H_SetControl)dragItem.Parent;
                            dragItem.MouseClick -= beforeHSetControl.HSetControl_HCarLabel_MouseClick;
                            dragItem.MouseDoubleClick -= beforeHSetControl.HSetControl_HCarLabel_MouseDoubleClick;
                            dragItem.MouseMove -= beforeHSetControl.HSetControl_HCarLabel_MouseMove;
                            dragItem.MouseEnter -= beforeHSetControl.HSetControl_MouseEnter;
                            dragItem.MouseLeave -= beforeHSetControl.HSetControl_MouseLeave;
                            /*
                             * Drop後のH_SetControlにEventを追加する
                             */
                            dragItem.MouseClick += HSetControl_HCarLabel_MouseClick;
                            dragItem.MouseDoubleClick += HSetControl_HCarLabel_MouseDoubleClick;
                            dragItem.MouseMove += HSetControl_HCarLabel_MouseMove;
                            dragItem.MouseEnter += HSetControl_MouseEnter;
                            dragItem.MouseLeave += HSetControl_MouseLeave;
                            break;
                    }
                    // Drop先にH_CarLabelExが存在するかチェックする
                    updateFlag = _hVehicleDispatchDetailDao.CheckCarCode(_hControlVo.CellNumber, _hControlVo.OperationDate);
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                if (updateFlag) {
                    MessageBox.Show("ドロップ先のセルには既に車両ラベルがセットされています。最新化をして下さい", "データベース同期エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } else {
                    // Eventを親へ転送する
                    Event_HSetControl_DragDrop.Invoke(sender, e);
                }
            }
            /*
             * H_StaffLabel
             */
            if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                /*
                 * カーソル座標からどのセルにDropされたかを調べる 
                 */
                Point clientPoint = ((H_SetControl)sender).PointToClient(new Point(e.X, e.Y));
                Point cellPoint = new(clientPoint.X / (int)_panelWidth, clientPoint.Y / (int)_panelHeight);
                int staffCellNumber = cellPoint.X * 2 + (cellPoint.Y - 2);
                try {
                    H_StaffLabel dragItem = (H_StaffLabel)e.Data.GetData(typeof(H_StaffLabel));
                    /*
                     * 
                     * Eventを再設定する
                     * 
                     */
                    switch (dragItem.Parent.Name) {
                        case "H_SetControl":
                            /*
                             * H_StaffLabelが移動する前のH_SetControlのEventを削除する
                             */
                            H_SetControl beforeHSetControl = (H_SetControl)dragItem.Parent;
                            dragItem.MouseClick -= beforeHSetControl.HSetControl_HStaffLabel_MouseClick;
                            dragItem.MouseDoubleClick -= beforeHSetControl.HSetControl_HStaffLabel_MouseDoubleClick;
                            dragItem.MouseMove -= beforeHSetControl.HSetControl_HStaffLabel_MouseMove;
                            dragItem.MouseEnter -= beforeHSetControl.HSetControl_MouseEnter;
                            dragItem.MouseLeave -= beforeHSetControl.HSetControl_MouseLeave;
                            /*
                             * Drop後のH_SetControlにEventを追加する
                             */
                            dragItem.MouseClick += HSetControl_HStaffLabel_MouseClick;
                            dragItem.MouseDoubleClick += HSetControl_HStaffLabel_MouseDoubleClick;
                            dragItem.MouseMove += HSetControl_HStaffLabel_MouseMove;
                            dragItem.MouseEnter += HSetControl_MouseEnter;
                            dragItem.MouseLeave += HSetControl_MouseLeave;
                            break;
                    }
                    // 2024-07-09 H_StaffLabelExのCellNumberプロパティにDrop先のCellNumberを代入する
                    dragItem.StaffCellNumber = staffCellNumber;
                    // Drop先にH_StaffLabelExが存在するかチェックする
                    updateFlag = _hVehicleDispatchDetailDao.CheckStaffCode(_hControlVo.CellNumber, _hControlVo.OperationDate, staffCellNumber);
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
                /*
                 * Labelの存在チェック
                 */
                if (updateFlag) {
                    MessageBox.Show("ドロップ先のセルには既に従事者ラベルがセットされています。最新化をして下さい", "データベース同期エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                } else {
                    // Eventを親へ転送する
                    Event_HSetControl_DragDrop.Invoke(sender, e);
                }
            }
        }

        /// <summary>
        /// HSetControl_DragOver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_DragOver(object sender, DragEventArgs e) {
            Event_HSetControl_DragOver.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HSetLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HSetLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HSetLabel_MouseClick.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HSetLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HSetLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HSetLabel_MouseDoubleClick.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HSetLabel_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HSetLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_HSetLabel_MouseMove.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HSetLabel_ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HSetLabel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            Event_HSetControl_HLabel_ToolStripMenuItem_Click.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HCarLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HCarLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HCarLabel_MouseClick.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HCarLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HCarLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HCarLabel_MouseDoubleClick.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HCarLabel_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HCarLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_HCarLabel_MouseMove.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HCarLabel_ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HCarLabel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            Event_HSetControl_HLabel_ToolStripMenuItem_Click.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HStaffLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HStaffLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HStaffLabel_MouseClick.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HStaffLabel_MouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HStaffLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetControl_HStaffLabel_MouseDoubleClick.Invoke(sender, e);
        }

        /// <summary>
        /// HSetControl_HStaffLabel_MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HStaffLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetControl_HStaffLabel_MouseMove.Invoke(sender, e);
        }
        /// <summary>
        /// HSetControl_HStaffLabel_ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSetControl_HStaffLabel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            Event_HSetControl_HLabel_ToolStripMenuItem_Click.Invoke(sender, e);
        }
        /*
         * Getter/Setter
         */
        /// <summary>
        /// H_SetControlを解析してH_VehicleDispatchDetailVoに変換(作成)する
        /// 
        /// H_SetControlにLabelが存在しない場合
        /// H_SetControlにLabelが存在する場合
        /// VehicleDispatch(Head/Body)から作成する場合
        /// HVehicleDispatchDetailVoから作成する場合
        /// </summary>
        /// <param name="hSetControl"></param>
        /// <returns></returns>
        public H_VehicleDispatchDetailVo ConvertHVehicleDispatchDetailVo() {
            H_VehicleDispatchDetailVo hVehicleDispatchDetailVo = new();
            H_ControlVo hControlVo = (H_ControlVo)this.Tag;
            /*
             * thisに子Controlが存在するかを調査する
             * ０～６の値
             */
            switch (this.Controls.Count) {
                case 0:
                    /*
                     * ヘッダーを作成
                     * Labelが配置されていない場合
                     */
                    hVehicleDispatchDetailVo.CellNumber = hControlVo.CellNumber;
                    hVehicleDispatchDetailVo.OperationDate = hControlVo.OperationDate;
                    hVehicleDispatchDetailVo.OperationFlag = hControlVo.OperationFlag;
                    hVehicleDispatchDetailVo.PurposeFlag = hControlVo.PurposeFlag;
                    hVehicleDispatchDetailVo.VehicleDispatchFlag = false;
                    break;
                default:
                    /*
                     * ヘッダーを作成
                     * 1つでもLabelが配置されている場合
                     */
                    hVehicleDispatchDetailVo.CellNumber = hControlVo.CellNumber;
                    hVehicleDispatchDetailVo.OperationDate = hControlVo.OperationDate;
                    hVehicleDispatchDetailVo.OperationFlag = hControlVo.OperationFlag;
                    hVehicleDispatchDetailVo.PurposeFlag = hControlVo.PurposeFlag;
                    hVehicleDispatchDetailVo.VehicleDispatchFlag = true;
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
                     *
                     * 運転手
                     */
                    var objectStaff1 = this.GetControlFromPosition(0, 2); // Controlが存在しなければNULLが返る
                    if (objectStaff1 is not null) {
                        H_StaffLabel hStaffLabel = (H_StaffLabel)objectStaff1;
                        H_StaffMasterVo hStaffMasterVo = (H_StaffMasterVo)objectStaff1.Tag;
                        hVehicleDispatchDetailVo.StaffCode1 = hStaffMasterVo.StaffCode;
                        hVehicleDispatchDetailVo.StaffOccupation1 = hStaffMasterVo.Occupation;
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
                    if (this.ColumnCount > 1) {
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
                    break;
            }
            /*
             * フッターを作成
             */
            hVehicleDispatchDetailVo.InsertPcName = Environment.MachineName;
            hVehicleDispatchDetailVo.InsertYmdHms = DateTime.Now;
            hVehicleDispatchDetailVo.UpdatePcName = Environment.MachineName;
            hVehicleDispatchDetailVo.UpdateYmdHms = DateTime.Now;
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

        /// <summary>
        /// GetSetMasterVo
        /// GetControlFromPosition(0, 0)
        /// </summary>
        /// <returns>H_SetMasterVoを返す Labelが存在しなかった場合はNull</returns>
        public H_SetMasterVo GetSetMasterVo() {
            Control control = this.GetControlFromPosition(0, 0);
            if (control is not null && control.GetType() == typeof(H_SetLabel)) {
                return (H_SetMasterVo)((H_SetLabel)control).Tag;
            } else {
                return null;
            }
        }

        /// <summary>
        /// GetSetLabel
        /// </summary>
        /// <returns></returns>
        public H_SetLabel GetSetLabel() {
            Control control = this.GetControlFromPosition(0, 0);
            if (control is not null && control.GetType() == typeof(H_SetLabel)) {
                return (H_SetLabel)control;
            } else {
                return null;
            }
        }

        /// <summary>
        /// GetCarMasterVo
        /// GetControlFromPosition(0, 1)
        /// </summary>
        /// <returns>H_CarMasterVoを返す Labelが存在しなかった場合はNull</returns>
        public H_CarMasterVo GetCarMasterVo() {
            Control control = this.GetControlFromPosition(0, 1);
            if (control is not null && control.GetType() == typeof(H_CarLabel)) {
                return (H_CarMasterVo)((H_CarLabel)control).Tag;
            } else {
                return null;
            }
        }

        /// <summary>
        /// GetStaffMasterVo
        /// GetControlFromPosition(?, ?)
        /// </summary>
        /// <param name="number">0:運転手 1:作業員１ 2:作業員２ 3:作業員３</param>
        /// <returns>H_StaffMasterVoを返す Labelが存在しなかった場合はNull</returns>
        public H_StaffMasterVo GetStaffMasterVo(int number) {
            Control control = this.GetControlFromPosition(_dictionaryCellPoint[number].X, _dictionaryCellPoint[number].Y);
            if (control is not null && control.GetType() == typeof(H_StaffLabel)) {
                return (H_StaffMasterVo)((H_StaffLabel)control).Tag;
            } else {
                return null;
            }
        }
    }
}
