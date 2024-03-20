/*
 * 2023-10-25
 */
using H_Dao;

using H_Vo;

namespace H_ControlEx {
    public partial class H_CarLabel : Label {
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * CarLabel
         */
        public event MouseEventHandler Event_HCarLabel_MouseClick = delegate { };
        public event MouseEventHandler Event_HCarLabel_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HCarLabel_MouseMove = delegate { };
        public event EventHandler Event_HCarLabel_ToolStripMenuItem_Click = delegate { };

        private Image _imageCarLabel;
        /*
         * H_Dao 
         */
        private H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private H_ControlVo _hControlVo;
        private readonly H_CarMasterVo _hCarMasterVo;
        private H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 75; // 2024-02-24 80→75に変更
        private const float _panelHeight = 100;
        /*
         * プロパティ
         */
        /// <summary>
        /// 車庫地コード
        /// 0:該当なし 1:本社 2:三郷
        /// </summary>
        private int _carGarageCode = 0;
        /// <summary>
        /// メモ
        /// </summary>
        private string _carMemo = string.Empty;
        /// <summary>
        /// メモフラグ
        /// true:メモが存在する false:メモが存在しない
        /// </summary>
        private bool _carMemoFlag = false;
        /// <summary>
        /// 代車フラグ
        /// true:代車 false:本番車
        /// </summary>
        private bool _carProxyFlag = false;
        /*
         * H_SetControlのアクセサーを操作するのに使うので退避させておく
         */
        private H_SetControl _evacuationHSetControl;
        /*
         * Fontの定義
         */
        private readonly Font _drawFontCarLabel = new("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        public H_CarLabel(H_ControlVo hControlVo) {
            /*
             * H_Dao 
             */
            _hVehicleDispatchDetailDao = new(hControlVo.ConnectionVo);
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            _hCarMasterVo = hControlVo.HCarMasterVo;
            _hVehicleDispatchDetailVo = hControlVo.HVehicleDispatchDetailVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 4;
            this.Margin = new Padding(2);
            this.Name = "H_CarLabel";
            this.Tag = _hCarMasterVo;
            this.Width = (int)_panelWidth - 4;
            this.CreateContextMenuStrip();

            /*
             * プロパティーの設定
             */
            if (_hVehicleDispatchDetailVo is not null) {
                this.CarGarageCode = _hVehicleDispatchDetailVo.CarGarageCode; // 車庫地
                this.CarMemo = _hVehicleDispatchDetailVo.CarMemo; // メモ
                this.CarMemoFlag = _hVehicleDispatchDetailVo.CarMemoFlag; // メモフラグ
                this.CarProxyFlag = _hVehicleDispatchDetailVo.CarProxyFlag; // 代車フラグ
                /*
                 * ToolTip初期化
                 */
                if (this.CarMemoFlag) {
                    ToolTip toolTip = new();
                    toolTip.InitialDelay = 500; // ToolTipが表示されるまでの時間
                    toolTip.ReshowDelay = 1000; // ToolTipが表示されている時に、別のToolTipを表示するまでの時間
                    toolTip.AutoPopDelay = 10000; // ToolTipを表示する時間
                    toolTip.SetToolTip(this, this.CarMemo);
                }
            } else {
                this.CarGarageCode = _hCarMasterVo.GarageCode; // 車庫地
            }
            /*
             * Event
             */
            this.MouseClick += HCarLabel_MouseClick;
            this.MouseDoubleClick += HCarLabel_MouseDoubleClick;
            this.MouseMove += HCarLabel_MouseMove;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            /*
             * H_CarLbelのImage選択
             */
            switch (_hCarMasterVo.GarageCode) {
                case 1:
                    _imageCarLabel = _hCarMasterVo.ClassificationCode switch {
                        10 => Properties.Resources.CarLabelWhiteY,
                        11 => Properties.Resources.CarLabelWhiteK,
                        _ => Properties.Resources.CarLabelWhite,
                    };
                    break;
                case 2:
                    _imageCarLabel = _hCarMasterVo.ClassificationCode switch {
                        10 => Properties.Resources.CarLabelPowerBlueY,
                        11 => Properties.Resources.CarLabelPowerBlueK,
                        _ => Properties.Resources.CarLabelPowerBlue,
                    };
                    break;
            }
            e.Graphics.DrawImage(_imageCarLabel, 2, 0, _panelWidth - 8, _panelHeight - 6);
            /*
             * 文字(車両)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            string number = string.Concat(_hCarMasterVo.RegistrationNumber1, _hCarMasterVo.RegistrationNumber2, "\r\n"
                                        , _hCarMasterVo.RegistrationNumber3, _hCarMasterVo.RegistrationNumber4, "\r\n"
                                        , _hCarMasterVo.DisguiseKind1, _hCarMasterVo.DoorNumber != 0 ? _hCarMasterVo.DoorNumber : " ");
            e.Graphics.DrawString(number, _drawFontCarLabel, new SolidBrush(Color.Black), new Rectangle(0, 0, (int)_panelWidth - 2, (int)_panelHeight - 6), stringFormat);
            /*
             * 代車処理を描画
             */
            if (_carProxyFlag) {
                e.Graphics.FillRectangle(Brushes.ForestGreen, 8, 5, 55, 5);
                e.Graphics.DrawLine(new Pen(Color.LawnGreen), new Point(7, 7), new Point(64, 7));
            }
            /*
             * メモを描画
             */
            if (_carMemoFlag) {
                Point[] points = { new Point(7, 5), new Point(21, 5), new Point(7, 19) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
        }

        /// <summary>
        /// ContextMenuStrip_Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opened(object sender, EventArgs e) {
            if (((H_CarLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_SetControl)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        ((ToolStripMenuItem)item).Enabled = true;
                }
                /*
                 * H_SetControlのアクセサーを操作するのに使うので退避させておく
                 */
                _evacuationHSetControl = (H_SetControl)((H_CarLabel)((ContextMenuStrip)sender).SourceControl).Parent;
            } else if (((H_CarLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_FlowLayoutPanelEx)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem)) {
                        switch (((ToolStripMenuItem)item).Name) {
                            case "ToolStripMenuItemCarDetail":
                            case "ToolStripMenuItemCarMemo":
                                ((ToolStripMenuItem)item).Enabled = true;
                                break;
                            default:
                                ((ToolStripMenuItem)item).Enabled = false;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CreateContextMenuStrip
        /// </summary>
        private void CreateContextMenuStrip() {
            ContextMenuStrip contextMenuStrip = new();
            contextMenuStrip.Name = "ContextMenuStripHCarLabel";
            contextMenuStrip.Opened += ContextMenuStrip_Opened;
            this.ContextMenuStrip = contextMenuStrip;
            /*
             * 車両台帳を表示する
             */
            ToolStripMenuItem toolStripMenuItem00 = new("車両台帳を表示する");
            toolStripMenuItem00.Name = "ToolStripMenuItemCarDetail";
            toolStripMenuItem00.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem00);
            /*
             * スペーサー
             */
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            /*
             * 車庫地コード
             */
            ToolStripMenuItem toolStripMenuItem01 = new("出庫地"); // 親アイテム
            toolStripMenuItem01.Name = "ToolStripMenuItemCarWarehouse";
            ToolStripMenuItem toolStripMenuItem01_0 = new("本社から出庫"); // 子アイテム１
            toolStripMenuItem01_0.Name = "ToolStripMenuItemCarWarehouseAdachi";
            toolStripMenuItem01_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_0);
            contextMenuStrip.Items.Add(toolStripMenuItem01);

            ToolStripMenuItem toolStripMenuItem01_1 = new("三郷から出庫"); // 子アイテム２
            toolStripMenuItem01_1.Name = "ToolStripMenuItemCarWarehouseMisato";
            toolStripMenuItem01_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_1);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            /*
             * 代番処理
             */
            ToolStripMenuItem toolStripMenuItem02 = new("代車処理"); // 親アイテム
            toolStripMenuItem02.Name = "ToolStripMenuItemCarProxy";
            ToolStripMenuItem toolStripMenuItem02_0 = new("代車として記録する"); // 子アイテム１
            toolStripMenuItem02_0.Name = "ToolStripMenuItemCarProxyTrue";
            toolStripMenuItem02_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_0);
            contextMenuStrip.Items.Add(toolStripMenuItem02);

            ToolStripMenuItem toolStripMenuItem02_1 = new("代車を解除する"); // 子アイテム２
            toolStripMenuItem02_1.Name = "ToolStripMenuItemCarProxyFalse";
            toolStripMenuItem02_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_1);
            contextMenuStrip.Items.Add(toolStripMenuItem02);
            /*
             * メモを作成・編集する
             */
            ToolStripMenuItem toolStripMenuItem03 = new("メモを作成・編集する");
            toolStripMenuItem03.Name = "ToolStripMenuItemCarMemo";
            toolStripMenuItem03.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem03);
            /*
             * 日報を作成する
             */
            ToolStripMenuItem toolStripMenuItem04 = new("日報を作成する");
            toolStripMenuItem04.Name = "ToolStripMenuItemCarNippou";
            toolStripMenuItem04.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem04);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                    /*
                     * H_Boardに処理を回している
                     * H_CarLabel→H_SetControl→H_Board
                     */
                case "ToolStripMenuItemCarDetail": // 車両台帳を表示する
                    Event_HCarLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
                case "ToolStripMenuItemCarWarehouseAdachi": // 本社から出庫
                    this.CarGarageCode = 1;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateCarGarageCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.CarGarageCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemCarWarehouseMisato": // 三郷から出庫
                    this.CarGarageCode = 2;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateCarGarageCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.CarGarageCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemCarProxyTrue": // 代車として記録する
                    this.CarProxyFlag = true;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateCarProxyFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.CarProxyFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemCarProxyFalse": // 代車を解除する
                    this.CarProxyFlag = false;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateCarProxyFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.CarProxyFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemCarMemo": // メモを作成・編集する
                    /*
                     * H_Boardに処理を回している
                     * H_CarLabel→H_SetControl→H_Board
                     */
                    Event_HCarLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
                case "ToolStripMenuItemCarNippou": // 日報を作成する
                    /*
                     * H_Boardに処理を回している
                     * H_CarLabel→H_SetControl→H_Board
                     */
                    Event_HCarLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
            }
        }

        /*
         * アクセサー
         */

        /// <summary>
        /// 車庫地コード
        /// 0:該当なし 1:本社 2:三郷
        /// </summary>
        public int CarGarageCode {
            get => _carGarageCode;
            set {
                _carGarageCode = value;
                _hCarMasterVo.GarageCode = value;
            }
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string CarMemo {
            get => _carMemo;
            set => _carMemo = value;
        }
        /// <summary>
        /// メモフラグ
        /// true:メモが存在する false:メモが存在しない
        /// </summary>
        public bool CarMemoFlag {
            get => _carMemoFlag;
            set {
                _carMemoFlag = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 代車フラグ
        /// true:代車 false:本番車
        /// </summary>
        public bool CarProxyFlag {
            get => _carProxyFlag;
            set {
                _carProxyFlag = value;
            }
        }

        /*
         * H_CarLabelEx
         */
        private void HCarLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HCarLabel_MouseClick.Invoke(sender, e);
        }
        private void HCarLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HCarLabel_MouseDoubleClick.Invoke(sender, e);
        }
        private void HCarLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HCarLabel_MouseMove.Invoke(sender, e);
        }
    }
}
