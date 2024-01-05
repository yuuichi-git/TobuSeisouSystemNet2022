/*
 * 2023-10-24
 */
using H_Common;

using H_Vo;

namespace H_ControlEx {
    public partial class H_SetLabel : Label {
        private Date _date = new();
        private Image _imageSetLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * Vo
         */
        private H_SetMasterVo _hSetMasterVo;
        /*
         * プロパティ
         */
        /// <summary>
        /// 稼働フラグ
        /// true:稼働 false:休車
        /// </summary>
        private bool _operationFlag;
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
        /// メモフラグ
        /// true:メモあり false:メモなし
        /// </summary>
        private bool _memoFlag = false;
        /// <summary>
        /// メモ
        /// </summary>
        private string _memo = string.Empty;
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
        /// <summary>
        /// 作業員付フラグ
        /// true:サ付 false:サ無し
        /// </summary>
        private bool _addWorkerFlag = false;
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
        private int _workerCount = 0; // 従事者数 1～4
        /*
         * 色の定義
         */
        private SolidBrush _brushColorBlack = new(Color.Black);
        /*
         * Fontの定義
         */
        private Font _drawFontSetLabel = new("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font _drawFontContactMethod = new("Yu Gothic UI", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font _drawFontShiftCode = new("Yu Gothic UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);

        private string _drawStringContactMethod = string.Empty;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="hSetMasterVo">Vo</param>
        /// <param name="operationDate">稼働日</param>
        public H_SetLabel(H_SetMasterVo hSetMasterVo, DateTime operationDate) {
            /*
             * 稼働・休車の初期設定
             */
            _operationFlag = _date.GetWorkingDays(operationDate, hSetMasterVo.WorkingDays, hSetMasterVo.FiveLap);
            /*
             * Vo
             */
            _hSetMasterVo = hSetMasterVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 2;
            this.Margin = new Padding(2);
            this.Name = "H_SetLabel";
            this.Tag = hSetMasterVo;
            this.Width = (int)_panelWidth - 2;

            this.CreateContextMenuStrip();
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
                switch (_hSetMasterVo.ManagedSpaceCode) {
                    case 1:
                        _imageSetLabel = _hSetMasterVo.ClassificationCode switch {
                            10 => Properties.Resources.SetLabelWhiteY,
                            11 => Properties.Resources.SetLabelWhiteK,
                            _ => Properties.Resources.SetLabelWhite,
                        };
                        break;
                    case 2:
                        _imageSetLabel = _hSetMasterVo.ClassificationCode switch {
                            10 => Properties.Resources.SetLabelPowerBlueY,
                            11 => Properties.Resources.SetLabelPowerBlueK,
                            _ => Properties.Resources.SetLabelPowerBlue,
                        };
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
             * メモを描画
             */
            if (_memoFlag) {
                Point[] points = { new Point(7, 21), new Point(21, 21), new Point(7, 35) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
            /*
             * 帰庫点呼フラグ
             */
            if (_lastRollCallFlag) {
                Point[] points = { new Point(54, 21), new Point(69, 21), new Point(69, 36) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Gray), points);
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
                e.Graphics.DrawString("待機", _drawFontShiftCode, Brushes.DarkRed, new Point(43, 77));
            /*
             * 作業員付フラグ
             */
            if (_addWorkerFlag)
                e.Graphics.DrawString("作付", _drawFontShiftCode, Brushes.DarkRed, new Point(24, 20));
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
             * 出庫地
             */
            ToolStripMenuItem toolStripMenuItem01 = new("管理地"); // 親アイテム
            toolStripMenuItem01.Name = "ToolStripMenuItemSetWarehouse";
            ToolStripMenuItem toolStripMenuItem01_0 = new("本社管理"); // 子アイテム１
            toolStripMenuItem01_0.Name = "ToolStripMenuItemSetWarehouseAdachi";
            toolStripMenuItem01_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_0);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            ToolStripMenuItem toolStripMenuItem01_1 = new("三郷管理"); // 子アイテム２
            toolStripMenuItem01_1.Name = "ToolStripMenuItemSetWarehouseMisato";
            toolStripMenuItem01_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_1);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            /*
             * 配車の状態
             */
            ToolStripMenuItem toolStripMenuItem02 = new("配車の状態"); // 親アイテム
            toolStripMenuItem02.Name = "ToolStripMenuItemSetOperation";
            ToolStripMenuItem toolStripMenuItem02_0 = new("配車する"); // 子アイテム１
            toolStripMenuItem02_0.Name = "ToolStripMenuItemSetOperationAdachi";
            toolStripMenuItem02_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_0);
            contextMenuStrip.Items.Add(toolStripMenuItem02);
            ToolStripMenuItem toolStripMenuItem02_1 = new("休車する"); // 子アイテム２
            toolStripMenuItem02_1.Name = "ToolStripMenuItemSetOperationMisato";
            toolStripMenuItem02_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_1);
            contextMenuStrip.Items.Add(toolStripMenuItem02);
            /*
             * メモを作成・編集する
             */
            ToolStripMenuItem toolStripMenuItem03 = new("メモを作成・編集する");
            toolStripMenuItem03.Name = "ToolStripMenuItemSetMemo";
            toolStripMenuItem03.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem03);
            /*
             * 雇上・区契
             */
            ToolStripMenuItem toolStripMenuItem04 = new("雇上・区契"); // 親アイテム
            toolStripMenuItem04.Name = "ToolStripMenuItemClassification";
            ToolStripMenuItem toolStripMenuItem04_0 = new("雇上契約に変更する"); // 子アイテム１
            toolStripMenuItem04_0.Name = "ToolStripMenuItemClassificationYOUJYOU";
            toolStripMenuItem04_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem04.DropDownItems.Add(toolStripMenuItem04_0);
            contextMenuStrip.Items.Add(toolStripMenuItem04);
            ToolStripMenuItem toolStripMenuItem04_1 = new("区契約に変更する"); // 子アイテム２
            toolStripMenuItem04_1.Name = "ToolStripMenuItemClassificationKUKEI";
            toolStripMenuItem04_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem04.DropDownItems.Add(toolStripMenuItem04_1);
            contextMenuStrip.Items.Add(toolStripMenuItem04);
            /*
             * 連絡事項
             */
            ToolStripMenuItem toolStripMenuItem05 = new("連絡事項"); // 親アイテム
            toolStripMenuItem05.Name = "ToolStripMenuItemContactInformation";
            ToolStripMenuItem toolStripMenuItem05_0 = new("連絡事項あり"); // 子アイテム１
            toolStripMenuItem05_0.Name = "ToolStripMenuItemContactInformationTrue";
            toolStripMenuItem05_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem05.DropDownItems.Add(toolStripMenuItem05_0);
            contextMenuStrip.Items.Add(toolStripMenuItem05);
            ToolStripMenuItem toolStripMenuItem05_1 = new("連絡事項なし"); // 子アイテム２
            toolStripMenuItem05_1.Name = "ToolStripMenuItemContactInformationFalse";
            toolStripMenuItem05_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem05.DropDownItems.Add(toolStripMenuItem05_1);
            contextMenuStrip.Items.Add(toolStripMenuItem05);
            /*
             * 作業員付きの配置
             */
            ToolStripMenuItem toolStripMenuItem06 = new("作業員付きの配置"); // 親アイテム
            toolStripMenuItem06.Name = "ToolStripMenuItemAddWorker";
            ToolStripMenuItem toolStripMenuItem06_0 = new("作業員付きに変更する"); // 子アイテム１
            toolStripMenuItem06_0.Name = "ToolStripMenuItemAddWorkerTrue";
            toolStripMenuItem06_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem06.DropDownItems.Add(toolStripMenuItem06_0);
            contextMenuStrip.Items.Add(toolStripMenuItem06);
            ToolStripMenuItem toolStripMenuItem06_1 = new("作業員なしに変更する"); // 子アイテム２
            toolStripMenuItem06_1.Name = "ToolStripMenuItemAddWorkerFalse";
            toolStripMenuItem06_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem06.DropDownItems.Add(toolStripMenuItem06_1);
            contextMenuStrip.Items.Add(toolStripMenuItem06);
            /*
             * 早番・遅番
             */
            ToolStripMenuItem toolStripMenuItem07 = new("早番・遅番"); // 親アイテム
            toolStripMenuItem07.Name = "ToolStripMenuItemShift";
            ToolStripMenuItem toolStripMenuItem07_0 = new("早番に変更する"); // 子アイテム１
            toolStripMenuItem07_0.Name = "ToolStripMenuItemShiftFirst";
            toolStripMenuItem07_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem07.DropDownItems.Add(toolStripMenuItem07_0);
            contextMenuStrip.Items.Add(toolStripMenuItem07);
            ToolStripMenuItem toolStripMenuItem07_1 = new("遅番に変更する"); // 子アイテム２
            toolStripMenuItem07_1.Name = "ToolStripMenuItemShiftLater";
            toolStripMenuItem07_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem07.DropDownItems.Add(toolStripMenuItem07_1);
            contextMenuStrip.Items.Add(toolStripMenuItem07);
            ToolStripMenuItem toolStripMenuItem07_2 = new("解除する"); // 子アイテム３
            toolStripMenuItem07_2.Name = "ToolStripMenuItemShiftNone";
            toolStripMenuItem07_2.Click += ToolStripMenuItem_Click;
            toolStripMenuItem07.DropDownItems.Add(toolStripMenuItem07_2);
            contextMenuStrip.Items.Add(toolStripMenuItem07);
            /*
             * 待機
             */
            ToolStripMenuItem toolStripMenuItem08 = new("待機"); // 親アイテム
            toolStripMenuItem08.Name = "ToolStripMenuItemStandBy";
            ToolStripMenuItem toolStripMenuItem08_0 = new("待機に変更する"); // 子アイテム１
            toolStripMenuItem08_0.Name = "ToolStripMenuItemStandByTrue";
            toolStripMenuItem08_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem08.DropDownItems.Add(toolStripMenuItem08_0);
            contextMenuStrip.Items.Add(toolStripMenuItem08);
            ToolStripMenuItem toolStripMenuItem08_1 = new("待機を解除する"); // 子アイテム２
            toolStripMenuItem08_1.Name = "ToolStripMenuItemStandByFalse";
            toolStripMenuItem08_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem08.DropDownItems.Add(toolStripMenuItem08_1);
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
                    _hSetMasterVo.ManagedSpaceCode = 1;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemSetWarehouseMisato": // 三郷管理
                    _hSetMasterVo.ManagedSpaceCode = 2;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemSetOperationAdachi": // 配車する
                    _operationFlag = true;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemSetOperationMisato": // 休車する
                    _operationFlag = false;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemSetMemo": // メモを作成・編集する
                    MessageBox.Show("ToolStripMenuItemSetMemo");
                    break;
                case "ToolStripMenuItemClassificationYOUJYOU": // 雇上契約に変更する
                    _hSetMasterVo.ClassificationCode = 10;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemClassificationKUKEI": // 区契約に変更する
                    _hSetMasterVo.ClassificationCode = 11;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemContactInformationTrue": // 連絡事項あり
                    MessageBox.Show("ToolStripMenuItemContactInformationTrue");
                    break;
                case "ToolStripMenuItemContactInformationFalse": // 連絡事項なし
                    MessageBox.Show("ToolStripMenuItemContactInformationFalse");
                    break;
                case "ToolStripMenuItemAddWorkerTrue": // 作業員付きに変更する
                    MessageBox.Show("ToolStripMenuItemAddWorkerTrue");
                    break;
                case "ToolStripMenuItemAddWorkerFalse": // 作業員なしに変更する
                    MessageBox.Show("ToolStripMenuItemAddWorkerFalse");
                    break;
                case "ToolStripMenuItemShiftFirst": // 早番に変更する
                    MessageBox.Show("ToolStripMenuItemShiftFirst");
                    break;
                case "ToolStripMenuItemShiftLater": // 遅番に変更する
                    MessageBox.Show("ToolStripMenuItemShiftLater");
                    break;
                case "ToolStripMenuItemShiftNone": // 解除する
                    MessageBox.Show("ToolStripMenuItemShiftNone");
                    break;
                case "ToolStripMenuItemStandByTrue": // 待機に変更する
                    MessageBox.Show("ToolStripMenuItemStandByTrue");
                    break;
                case "ToolStripMenuItemStandByFalse": // 待機を解除する
                    MessageBox.Show("ToolStripMenuItemStandByFalse");
                    break;
                case "ToolStripMenuItemFaxInformationTrue": // Fax送信をする
                    MessageBox.Show("ToolStripMenuItemFaxInformationTrue");
                    break;
                case "ToolStripMenuItemFaxInformationFalse": // Fax送信をしない
                    MessageBox.Show("ToolStripMenuItemFaxInformationFalse");
                    break;
                case "ToolStripMenuItemCreateFax": // 代車・代番Faxを作成する
                    MessageBox.Show("ToolStripMenuItemCreateFax");
                    break;
            }
        }

        /*
         * アクセサー
         */
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
        /// メモフラグ
        /// true:メモあり false:メモなし
        /// </summary>
        public bool MemoFlag {
            get => _memoFlag;
            set => _memoFlag = value;
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string Memo {
            get => _memo;
            set => _memo = value;
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
        /// <summary>
        /// 作業員付きフラグ
        /// true:作業員付き false:作業員なし
        /// </summary>
        public bool AddWorkerFlag {
            get => _addWorkerFlag;
            set => _addWorkerFlag = value;
        }
        /// <summary>
        /// 連絡事項印フラグ
        /// true:連絡事項あり false:連絡事項なし
        /// </summary>
        public bool ContactInfomationFlag {
            get => _contactInfomationFlag;
            set => _contactInfomationFlag = value;
        }
        /// <summary>
        /// FAX送信フラグ
        /// true:Fax送信 false:なし
        /// </summary>
        public bool FaxTransmissionFlag {
            get => _faxTransmissionFlag;
            set => _faxTransmissionFlag = value;
        }
    }
}
