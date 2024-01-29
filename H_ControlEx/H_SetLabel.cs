/*
 * 2023-10-24
 */
using H_Common;

using H_Dao;

using H_Vo;

namespace H_ControlEx {
    public partial class H_SetLabel : Label {
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * SetLabel
         */
        public event MouseEventHandler Event_HSetLabel_MouseClick = delegate { };
        public event MouseEventHandler Event_HSetLabel_MouseDoubleClick = delegate { };
        public event MouseEventHandler Event_HSetLabel_MouseMove = delegate { };

        private readonly Date _date = new();
        private Image _imageSetLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 120;
        /*
         * H_Dao 
         */
        private H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * H_Vo
         */
        private H_ControlVo _hControlVo;
        private H_SetMasterVo _hSetMasterVo;
        private H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;
        /*
         * プロパティ
         */
        /// <summary>
        /// 作業員付フラグ
        /// true:サ付 false:サ無し
        /// </summary>
        private bool _addWorkerFlag = false;
        /// <summary>
        /// 分類コード
        /// 10:雇上 11:区契 12:臨時 20:清掃工場 30:社内 50:一般 51:社用車 99:指定なし
        /// </summary>
        private int _classificationCode = 99;
        /// <summary>
        /// 連絡事項印フラグ
        /// true:連絡事項あり false:連絡事項なし
        /// </summary>
        private bool _contactInfomationFlag = false;
        /// <summary>
        /// FAX送信フラグ
        /// true:Fax送信 false:なし
        /// </summary>
        private bool _faxTransmissionFlag = false;
        /// <summary>
        /// 帰庫点呼フラグ
        /// true:帰庫点呼済 false:未点呼
        /// </summary>
        private bool _lastRollCallFlag = false;
        /// <summary>
        /// 帰庫点呼日時
        /// </summary>
        private DateTime _lastRollCallYmdHms = new DateTime(1900, 01, 01);
        /// <summary>
        /// 管理地
        /// 0:該当なし 1:足立 2:三郷
        /// </summary>
        private int _managedSpaceCode;
        /// <summary>
        /// メモ
        /// </summary>
        private string _memo = string.Empty;
        /// <summary>
        /// メモフラグ
        /// true:メモあり false:メモなし
        /// </summary>
        private bool _memoFlag = false;
        /// <summary>
        /// 稼働フラグ
        /// true:稼働 false:休車
        /// </summary>
        private bool _operationFlag;
        /// <summary>
        /// 番手コード
        /// 0→指定なし 1→早番 2→遅番
        /// </summary>
        private int _shiftCode = 0;
        /// <summary>
        /// 待機フラグ
        /// true:待機あり false:待機なし
        /// </summary>
        private bool _standByFlag = false;
        /*
         * H_SetControlのアクセサーを操作するのに使うので退避させておく
         */
        private H_SetControl _evacuationHSetControl;
        /*
         * 色の定義
         */
        private readonly SolidBrush _brushColorBlack = new(Color.Black);
        private readonly SolidBrush _solidBrushContactInformation = new(Color.FromArgb(15, Color.LimeGreen));
        private readonly SolidBrush _solidBrushFaxTransmission = new(Color.FromArgb(15, Color.IndianRed));
        /*
         * Fontの定義
         */
        private Font _drawFontSetLabel = new("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font _drawFontContactMethod = new("Yu Gothic UI", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font _drawFontShiftCode = new("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font _drawFontStandByFlag = new("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font _drawFontAddWorkerFlag = new("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);

        private string _drawStringContactMethod = string.Empty;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="hSetMasterVo">Vo</param>
        /// <param name="operationDate">稼働日</param>
        public H_SetLabel(H_ControlVo hControlVo) {
            /*
             * H_Dao 
             */
            _hVehicleDispatchDetailDao = new(hControlVo.ConnectionVo);
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            _hSetMasterVo = hControlVo.HSetMasterVo;
            _hVehicleDispatchDetailVo = hControlVo.HVehicleDispatchDetailVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 2;
            this.Margin = new Padding(2);
            this.Name = "H_SetLabel";
            this.Tag = _hSetMasterVo;
            this.Width = (int)_panelWidth - 2;
            this.CreateContextMenuStrip();

            /*
             * プロパティーの設定
             */
            if (_hVehicleDispatchDetailVo is not null) {
                /*
                 * _hVehicleDispatchDetailVoが固有に保持している値をセットする
                 */
                this.AddWorkerFlag = _hVehicleDispatchDetailVo.AddWorkerFlag; // 作業員付フラグ
                this.ClassificationCode = _hVehicleDispatchDetailVo.ClassificationCode; // 分類コード
                this.ContactInfomationFlag = _hVehicleDispatchDetailVo.ContactInfomationFlag; // 連絡事項印フラグ
                this.FaxTransmissionFlag = _hVehicleDispatchDetailVo.FaxTransmissionFlag; // FAX送信フラグ
                this.LastRollCallFlag = _hVehicleDispatchDetailVo.LastRollCallFlag; // 帰庫点呼フラグ
                this.LastRollCallYmdHms = _hVehicleDispatchDetailVo.LastRollCallYmdHms; // 帰庫点呼日時
                this.ManagedSpaceCode = _hVehicleDispatchDetailVo.ManagedSpaceCode; // 管理地
                this.Memo = _hVehicleDispatchDetailVo.SetMemo; // メモ
                this.MemoFlag = _hVehicleDispatchDetailVo.SetMemoFlag; // メモフラグ
                this.OperationFlag = _hVehicleDispatchDetailVo.OperationFlag; // 稼働フラグ
                this.ShiftCode = _hVehicleDispatchDetailVo.ShiftCode; // 番手コード
                this.StandByFlag = _hVehicleDispatchDetailVo.StandByFlag; // 待機フラグ
            } else {
                /*
                 * H_SetLabelを作成するのに最低限必要な値をセットする
                 */
                this.ClassificationCode = _hSetMasterVo.ClassificationCode; // 分類コード
                this.ManagedSpaceCode = _hSetMasterVo.ManagedSpaceCode; // 管理地
                this.OperationFlag = _date.GetWorkingDays(_hControlVo.OperationDate, _hSetMasterVo.WorkingDays, _hSetMasterVo.FiveLap);
            }
            /*
             * Event
             */
            this.MouseClick += HSetLabel_MouseClick;
            this.MouseDoubleClick += HSetLabel_MouseDoubleClick;
            this.MouseMove += HSetLabel_MouseMove;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            /*
             * H_SetLbelのImage選択
             */
            if (_operationFlag) {
                switch (_managedSpaceCode) {
                    case 1:
                        _imageSetLabel = ClassificationCode switch {
                            10 => Properties.Resources.SetLabelWhiteY,
                            11 => Properties.Resources.SetLabelWhiteK,
                            _ => Properties.Resources.SetLabelWhite,
                        };
                        break;
                    case 2:
                        _imageSetLabel = ClassificationCode switch {
                            10 => Properties.Resources.SetLabelPowerBlueY,
                            11 => Properties.Resources.SetLabelPowerBlueK,
                            _ => Properties.Resources.SetLabelPowerBlue,
                        };
                        break;
                    default:
                        _imageSetLabel = Properties.Resources.SetLabelRed;
                        break;
                }
            } else {
                _imageSetLabel = Properties.Resources.SetLabelRed;
            }
            e.Graphics.DrawImage(_imageSetLabel, 2, 2, _panelWidth - 8, _panelHeight - 6);
            /*
             * 文字(TEL/FAX)を描画
             */
            _drawStringContactMethod = _hSetMasterVo.ContactMethod switch {
                10 => "TEL", // TEL
                11 => "FAX", // FAX
                13 => "TEL/FAX", // TEL/FAX
                _ => string.Empty, // 連絡なし
            };
            e.Graphics.DrawString(_drawStringContactMethod, _drawFontContactMethod, _brushColorBlack, new Point(6, 1));
            /*
             * 文字(配車先)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(string.Concat(_hSetMasterVo.SetName1, "\r\n", _hSetMasterVo.SetName2),
                                                _drawFontSetLabel,
                                                new SolidBrush(Color.Black),
                                                new Rectangle(0, 10, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
            /*
             * 帰庫点呼フラグ
             */
            if (_lastRollCallFlag) {
                Point[] points = { new Point(54, 21), new Point(69, 21), new Point(69, 36) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Gray), points);
            }
            /*
             * メモを描画
             */
            if (_memoFlag) {
                Point[] points = { new Point(7, 21), new Point(21, 21), new Point(7, 35) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
            /*
             * 番手コード
             */
            switch (_shiftCode) {
                case 1:
                    e.Graphics.DrawString("早番", _drawFontShiftCode, Brushes.DarkRed, new Point(7, 77));
                    break;
                case 2:
                    e.Graphics.DrawString("遅番", _drawFontShiftCode, Brushes.DarkRed, new Point(7, 77));
                    break;
            }
            /*
             * 待機フラグ
             */
            if (_standByFlag)
                e.Graphics.DrawString("待機", _drawFontStandByFlag, Brushes.DarkRed, new Point(43, 77));
            /*
             * 作業員付フラグ
             */
            if (_addWorkerFlag)
                e.Graphics.DrawString("作付", _drawFontAddWorkerFlag, Brushes.DarkRed, new Point(24, 20));
        }

        /// <summary>
        /// ContextMenuStrip_Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opened(object sender, EventArgs e) {
            if (((H_SetLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_SetControl)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        ((ToolStripMenuItem)item).Enabled = true;
                }
                /*
                 * H_SetControlのアクセサーを操作するのに使うので退避させておく
                 */
                _evacuationHSetControl = (H_SetControl)((H_SetLabel)((ContextMenuStrip)sender).SourceControl).Parent;
            } else if (((H_SetLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_FlowLayoutPanelEx)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem)) {
                        switch (((ToolStripMenuItem)item).Name) {
                            case "ToolStripMenuItemSetDetail":
                            case "ToolStripMenuItemSetMemo":
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
            contextMenuStrip.Name = "ContextMenuStripHSetLabel";
            contextMenuStrip.Opened += ContextMenuStrip_Opened;
            this.ContextMenuStrip = contextMenuStrip;
            /*
             * 配車先の情報を表示する
             */
            ToolStripMenuItem toolStripMenuItem00 = new("配車先の情報を表示する");
            toolStripMenuItem00.Name = "ToolStripMenuItemSetDetail";
            toolStripMenuItem00.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem00);
            /*
             * スペーサー
             */
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            /*
             * 配車の状態
             */
            ToolStripMenuItem toolStripMenuItem01 = new("配車の状態"); // 親アイテム
            toolStripMenuItem01.Name = "ToolStripMenuItemSetOperation";
            ToolStripMenuItem toolStripMenuItem01_0 = new("配車する"); // 子アイテム１
            toolStripMenuItem01_0.Name = "ToolStripMenuItemSetOperationAdachi";
            toolStripMenuItem01_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_0);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            ToolStripMenuItem toolStripMenuItem01_1 = new("休車する"); // 子アイテム２
            toolStripMenuItem01_1.Name = "ToolStripMenuItemSetOperationMisato";
            toolStripMenuItem01_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_1);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            /*
             * 管理地
             */
            ToolStripMenuItem toolStripMenuItem02 = new("管理地"); // 親アイテム
            toolStripMenuItem02.Name = "ToolStripMenuItemSetWarehouse";
            ToolStripMenuItem toolStripMenuItem02_0 = new("本社管理"); // 子アイテム１
            toolStripMenuItem02_0.Name = "ToolStripMenuItemSetWarehouseAdachi";
            toolStripMenuItem02_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_0);
            contextMenuStrip.Items.Add(toolStripMenuItem02);
            ToolStripMenuItem toolStripMenuItem02_1 = new("三郷管理"); // 子アイテム２
            toolStripMenuItem02_1.Name = "ToolStripMenuItemSetWarehouseMisato";
            toolStripMenuItem02_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_1);
            contextMenuStrip.Items.Add(toolStripMenuItem02);
            /*
             * 雇上・区契
             */
            ToolStripMenuItem toolStripMenuItem03 = new("雇上・区契"); // 親アイテム
            toolStripMenuItem03.Name = "ToolStripMenuItemClassification";
            ToolStripMenuItem toolStripMenuItem03_0 = new("雇上契約に変更する"); // 子アイテム１
            toolStripMenuItem03_0.Name = "ToolStripMenuItemClassificationYOUJYOU";
            toolStripMenuItem03_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem03.DropDownItems.Add(toolStripMenuItem03_0);
            contextMenuStrip.Items.Add(toolStripMenuItem03);
            ToolStripMenuItem toolStripMenuItem03_1 = new("区契約に変更する"); // 子アイテム２
            toolStripMenuItem03_1.Name = "ToolStripMenuItemClassificationKUKEI";
            toolStripMenuItem03_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem03.DropDownItems.Add(toolStripMenuItem03_1);
            contextMenuStrip.Items.Add(toolStripMenuItem03);
            /*
             * 作業員付きの配置
             */
            ToolStripMenuItem toolStripMenuItem04 = new("作業員付きの配置"); // 親アイテム
            toolStripMenuItem04.Name = "ToolStripMenuItemAddWorker";
            ToolStripMenuItem toolStripMenuItem04_0 = new("作業員付きに変更する"); // 子アイテム１
            toolStripMenuItem04_0.Name = "ToolStripMenuItemAddWorkerTrue";
            toolStripMenuItem04_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem04.DropDownItems.Add(toolStripMenuItem04_0);
            contextMenuStrip.Items.Add(toolStripMenuItem04);
            ToolStripMenuItem toolStripMenuItem04_1 = new("作業員なしに変更する"); // 子アイテム２
            toolStripMenuItem04_1.Name = "ToolStripMenuItemAddWorkerFalse";
            toolStripMenuItem04_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem04.DropDownItems.Add(toolStripMenuItem04_1);
            contextMenuStrip.Items.Add(toolStripMenuItem04);
            /*
             * 早番・遅番
             */
            ToolStripMenuItem toolStripMenuItem05 = new("早番・遅番"); // 親アイテム
            toolStripMenuItem05.Name = "ToolStripMenuItemShift";
            ToolStripMenuItem toolStripMenuItem05_0 = new("早番に変更する"); // 子アイテム１
            toolStripMenuItem05_0.Name = "ToolStripMenuItemShiftFirst";
            toolStripMenuItem05_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem05.DropDownItems.Add(toolStripMenuItem05_0);
            contextMenuStrip.Items.Add(toolStripMenuItem05);
            ToolStripMenuItem toolStripMenuItem05_1 = new("遅番に変更する"); // 子アイテム２
            toolStripMenuItem05_1.Name = "ToolStripMenuItemShiftLater";
            toolStripMenuItem05_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem05.DropDownItems.Add(toolStripMenuItem05_1);
            contextMenuStrip.Items.Add(toolStripMenuItem05);
            ToolStripMenuItem toolStripMenuItem05_2 = new("解除する"); // 子アイテム３
            toolStripMenuItem05_2.Name = "ToolStripMenuItemShiftNone";
            toolStripMenuItem05_2.Click += ToolStripMenuItem_Click;
            toolStripMenuItem05.DropDownItems.Add(toolStripMenuItem05_2);
            contextMenuStrip.Items.Add(toolStripMenuItem05);
            /*
             * 待機
             */
            ToolStripMenuItem toolStripMenuItem06 = new("待機"); // 親アイテム
            toolStripMenuItem06.Name = "ToolStripMenuItemStandBy";
            ToolStripMenuItem toolStripMenuItem06_0 = new("待機に変更する"); // 子アイテム１
            toolStripMenuItem06_0.Name = "ToolStripMenuItemStandByTrue";
            toolStripMenuItem06_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem06.DropDownItems.Add(toolStripMenuItem06_0);
            contextMenuStrip.Items.Add(toolStripMenuItem06);
            ToolStripMenuItem toolStripMenuItem06_1 = new("待機を解除する"); // 子アイテム２
            toolStripMenuItem06_1.Name = "ToolStripMenuItemStandByFalse";
            toolStripMenuItem06_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem06.DropDownItems.Add(toolStripMenuItem06_1);
            contextMenuStrip.Items.Add(toolStripMenuItem06);
            /*
             * 連絡事項
             */
            ToolStripMenuItem toolStripMenuItem07 = new("連絡事項"); // 親アイテム
            toolStripMenuItem07.Name = "ToolStripMenuItemContactInformation";
            ToolStripMenuItem toolStripMenuItem07_0 = new("連絡事項あり"); // 子アイテム１
            toolStripMenuItem07_0.Name = "ToolStripMenuItemContactInformationTrue";
            toolStripMenuItem07_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem07.DropDownItems.Add(toolStripMenuItem07_0);
            contextMenuStrip.Items.Add(toolStripMenuItem07);
            ToolStripMenuItem toolStripMenuItem07_1 = new("連絡事項なし"); // 子アイテム２
            toolStripMenuItem07_1.Name = "ToolStripMenuItemContactInformationFalse";
            toolStripMenuItem07_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem07.DropDownItems.Add(toolStripMenuItem07_1);
            contextMenuStrip.Items.Add(toolStripMenuItem07);
            /*
             * メモを作成・編集する
             */
            ToolStripMenuItem toolStripMenuItem08 = new("メモを作成・編集する");
            toolStripMenuItem08.Name = "ToolStripMenuItemSetMemo";
            toolStripMenuItem08.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem08);
            /*
             * スペーサー
             */
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            /*
             * 代車・代番Fax作成確認
             */
            ToolStripMenuItem toolStripMenuItem09 = new("代車・代番Fax作成確認"); // 親アイテム
            toolStripMenuItem09.Name = "ToolStripMenuItemFaxInformation";
            ToolStripMenuItem toolStripMenuItem09_0 = new("Fax送信をする"); // 子アイテム１
            toolStripMenuItem09_0.Name = "ToolStripMenuItemFaxInformationTrue";
            toolStripMenuItem09_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem09.DropDownItems.Add(toolStripMenuItem09_0);
            contextMenuStrip.Items.Add(toolStripMenuItem09);
            ToolStripMenuItem toolStripMenuItem09_1 = new("Fax送信をしない"); // 子アイテム２
            toolStripMenuItem09_1.Name = "ToolStripMenuItemFaxInformationFalse";
            toolStripMenuItem09_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem09.DropDownItems.Add(toolStripMenuItem09_1);
            contextMenuStrip.Items.Add(toolStripMenuItem09);
            /*
             * 代車・代番Faxを作成する
             */
            ToolStripMenuItem toolStripMenuItem10 = new("代車・代番Faxを作成する");
            toolStripMenuItem10.Name = "ToolStripMenuItemCreateFax";
            toolStripMenuItem10.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem10);
            /*
             * スペーサー
             */
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            /*
             * 削除する
             */
            ToolStripMenuItem toolStripMenuItem11 = new("削除する");
            toolStripMenuItem11.Name = "ToolStripMenuItemSetDelete";
            toolStripMenuItem11.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem11);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemSetDetail": // 配車先の情報を表示する
                    MessageBox.Show("ToolStripMenuItemSetDetail");
                    break;
                case "ToolStripMenuItemSetWarehouseAdachi": // 本社管理
                    this.ManagedSpaceCode = 1;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateManagedSpaceCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ManagedSpaceCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemSetWarehouseMisato": // 三郷管理
                    this.ManagedSpaceCode = 2;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateManagedSpaceCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ManagedSpaceCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemSetOperationAdachi": // 配車する
                    this.OperationFlag = true;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateOperationFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.OperationFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemSetOperationMisato": // 休車する
                    this.OperationFlag = false;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateOperationFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.OperationFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemSetMemo": // メモを作成・編集する
                    MessageBox.Show("ToolStripMenuItemSetMemo");
                    break;
                case "ToolStripMenuItemClassificationYOUJYOU": // 雇上契約に変更する
                    this.ClassificationCode = 10;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateClassificationCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ClassificationCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemClassificationKUKEI": // 区契約に変更する
                    this.ClassificationCode = 11;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateClassificationCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ClassificationCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemContactInformationTrue": // 連絡事項あり
                    this.ContactInfomationFlag = true;
                    // H_Controlのメソッドを呼び出す
                    _evacuationHSetControl.ContactInfomationFlag = true;
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateContactInfomationFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ContactInfomationFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemContactInformationFalse": // 連絡事項なし
                    this.ContactInfomationFlag = false;
                    // H_Controlのメソッドを呼び出す
                    _evacuationHSetControl.ContactInfomationFlag = false;
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateContactInfomationFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ContactInfomationFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemAddWorkerTrue": // 作業員付きに変更する
                    this.AddWorkerFlag = true;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateAddWorkerFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.AddWorkerFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemAddWorkerFalse": // 作業員なしに変更する
                    this.AddWorkerFlag = false;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateAddWorkerFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.AddWorkerFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemShiftFirst": // 早番に変更する
                    this.ShiftCode = 1;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateShiftCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ShiftCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemShiftLater": // 遅番に変更する
                    this.ShiftCode = 2;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateShiftCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ShiftCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemShiftNone": // 解除する
                    this.ShiftCode = 0;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateShiftCode(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.ShiftCode);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemStandByTrue": // 待機に変更する
                    this.StandByFlag = true;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStandByFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StandByFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemStandByFalse": // 待機を解除する
                    this.StandByFlag = false;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStandByFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StandByFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemFaxInformationTrue": // Fax送信をする
                    this.FaxTransmissionFlag = true;
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateFaxTransmissionFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.FaxTransmissionFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemFaxInformationFalse": // Fax送信をしない
                    this.FaxTransmissionFlag = false;
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateFaxTransmissionFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.FaxTransmissionFlag);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                case "ToolStripMenuItemCreateFax": // 代車・代番Faxを作成する
                    MessageBox.Show("ToolStripMenuItemCreateFax");
                    break;
                case "ToolStripMenuItemSetDelete": // 削除する
                    MessageBox.Show("ToolStripMenuItemSetDelete");
                    break;
            }
        }

        /*
         * アクセサー
         */
        /// <summary>
        /// 作業員付きフラグ
        /// true:作業員付き false:作業員なし
        /// </summary>
        public bool AddWorkerFlag {
            get => _addWorkerFlag;
            set => _addWorkerFlag = value;
        }
        /// <summary>
        /// 分類コード
        /// 10:雇上 11:区契 12:臨時 20:清掃工場 30:社内 50:一般 51:社用車 99:指定なし
        /// </summary>
        public int ClassificationCode {
            get => _classificationCode;
            set {
                _classificationCode = value;
                _hSetMasterVo.ClassificationCode = value;
            }
        }
        /// <summary>
        /// 連絡事項印フラグ
        /// true:連絡事項あり false:連絡事項なし
        /// </summary>
        public bool ContactInfomationFlag {
            get => _contactInfomationFlag;
            set {
                _contactInfomationFlag = value;
                if (this.Parent is not null)
                    ((H_SetControl)this.Parent).ContactInfomationFlag = value;
            }
        }
        /// <summary>
        /// FAX送信フラグ
        /// true:Fax送信 false:なし
        /// </summary>
        public bool FaxTransmissionFlag {
            get => _faxTransmissionFlag;
            set {
                _faxTransmissionFlag = value;
                if (this.Parent is not null)
                    ((H_SetControl)this.Parent).FaxTransmissionFlag = value;
            }
        }
        /// <summary>
        /// 帰庫点呼フラグ
        /// </summary>
        public bool LastRollCallFlag {
            get => _lastRollCallFlag;
            set => _lastRollCallFlag = value;
        }
        /// <summary>
        /// 帰庫点呼日時
        /// </summary>
        public DateTime LastRollCallYmdHms {
            get => _lastRollCallYmdHms;
            set => _lastRollCallYmdHms = value;
        }
        /// <summary>
        /// 管理地
        /// 0:該当なし 1:足立 2:三郷
        /// </summary>
        public int ManagedSpaceCode {
            get => _managedSpaceCode;
            set {
                _managedSpaceCode = value;
                _hSetMasterVo.ManagedSpaceCode = value;
            }
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string Memo {
            get => _memo;
            set => _memo = value;
        }
        /// <summary>
        /// メモフラグ
        /// true:メモあり false:メモなし
        /// </summary>
        public bool MemoFlag {
            get => _memoFlag;
            set => _memoFlag = value;
        }
        /// <summary>
        /// 稼働フラグ
        /// true:稼働日 false:休車
        /// </summary>
        public bool OperationFlag {
            get => _operationFlag;
            set {
                _operationFlag = value;
                _hControlVo.OperationFlag = value;
            }
        }
        /// <summary>
        /// 番手コード
        /// 0:指定なし 1:早番 2:遅番
        /// </summary>
        public int ShiftCode {
            get => _shiftCode;
            set => _shiftCode = value;
        }
        /// <summary>
        /// 待機フラグ
        /// true:待機 false:通常
        /// </summary>
        public bool StandByFlag {
            get => _standByFlag;
            set => _standByFlag = value;
        }

        /*
         * H_SetLabelEx
         */
        private void HSetLabel_MouseClick(object sender, MouseEventArgs e) {
            Event_HSetLabel_MouseClick.Invoke(sender, e);
        }
        private void HSetLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            Event_HSetLabel_MouseDoubleClick.Invoke(sender, e);
        }
        private void HSetLabel_MouseMove(object sender, MouseEventArgs e) {
            Event_HSetLabel_MouseMove.Invoke(sender, e);
        }
    }
}
