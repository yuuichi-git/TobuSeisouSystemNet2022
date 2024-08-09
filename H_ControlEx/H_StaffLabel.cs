/*
 * 2023-10-31
 */
using System.Diagnostics;

using H_Dao;

using Vo;

namespace H_ControlEx {
    public partial class H_StaffLabel : Label {
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         * StaffLabel
         */
        public event EventHandler Event_HStaffLabel_ToolStripMenuItem_Click = delegate { };

        private readonly Image _imageStaffLabel;
        /*
         * H_Dao 
         */
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
        private readonly H_VehicleDispatchDetailDao _hVehicleDispatchDetailDao;
        /*
         * Vo
         */
        private H_ControlVo _hControlVo;
        private readonly H_StaffMasterVo _hStaffMasterVo;
        private H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 75; // 2024-02-24 80→75に変更
        private const float _panelHeight = 120;
        /*
         * プロパティー
         */
        /// <summary>
        /// H_SetControl上での配置位置を記録
        /// 0:運転手 1:作業員① 2:作業員② 3:作業員③ 9:指定なし
        /// </summary>
        private int _cellNumber = 9;
        /// <summary>
        /// メモ
        /// </summary>
        private string _staffMemo = string.Empty;
        /// <summary>
        /// メモフラグ
        /// true:メモあり false:メモなし
        /// </summary>
        private bool _staffMemoFlag = false;
        /// <summary>
        /// 職種
        /// 10:運転手 11:作業員 20:事務職 99:指定なし
        /// </summary>
        private int _staffOccupationCode = 99;
        /// <summary>
        /// 代番フラグ
        /// true:代番 false:本番
        /// </summary>
        private bool _staffProxyFlag = false;
        /// <summary>
        /// 出庫点呼フラグ
        /// true:出庫点呼済 false:未点呼
        /// </summary>
        private bool _staffRollCallFlag = false;
        /// <summary>
        /// 点呼日時
        /// </summary>
        private DateTime _staffRollCallYmdHms = new DateTime(1900, 01, 01);
        /*
         * H_SetControlのアクセサーを操作するのに使うので退避させておく
         */
        private H_SetControl _evacuationHSetControl;
        /*
         * Fontの定義
         */
        private readonly Font _drawFontStaffLabel = new("メイリオ", 14, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly Font _drawFontOccupation = new("HGS創英ﾌﾟﾚｾﾞﾝｽEB", 10, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="hControlVo"></param>
        public H_StaffLabel(H_ControlVo hControlVo) {
            /*
             * H_Dao 
             */
            _hLicenseMasterDao = new(hControlVo.ConnectionVo);
            _hVehicleDispatchDetailDao = new(hControlVo.ConnectionVo);
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            _hStaffMasterVo = hControlVo.HStaffMasterVo;
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
            this.Name = "H_StaffLabel";
            this.Tag = _hStaffMasterVo;
            this.Width = (int)_panelWidth - 4;
            this.CreateContextMenuStrip();
            /*
             * Imageを選択する
             */
            switch (_hStaffMasterVo.Belongs) {
                case 10: // 役員
                case 11: // 社員
                    _imageStaffLabel = Properties.Resources.StaffLabelWhite;
                    break;
                case 12: // アルバイト
                    _imageStaffLabel = Properties.Resources.StaffLabelYellow;
                    break;
                case 13: // 派遣
                    _imageStaffLabel = Properties.Resources.StaffLabelWhite;
                    break;
                case 20: // 新運転
                case 21: // 自運労
                    switch (_hStaffMasterVo.JobForm) {
                        case 11:
                            _imageStaffLabel = Properties.Resources.StaffLabelGreen;
                            break;
                        default:
                            _imageStaffLabel = Properties.Resources.StaffLabelWhite;
                            break;
                    }
                    break;
            }
            /*
             * プロパティーの設定
             */
            if (_hVehicleDispatchDetailVo is not null) {
                /*
                 * _hControlVo.SelectNumberStaffMasterVoを使って、何番目のデータかを知る
                 * これ以降はthis.CellNumberに格納するので使わない・・・
                 */
                switch (_hControlVo.SelectNumberStaffMasterVo) {
                    case 0:
                        this.StaffCellNumber = 0;
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo1;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag1;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation1;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag1;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag1;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms1;
                        break;
                    case 1:
                        this.StaffCellNumber = 1;
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo2;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag2;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation2;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag2;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag2;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms2;
                        break;
                    case 2:
                        this.StaffCellNumber = 2;
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo3;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag3;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation3;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag3;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag3;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms3;
                        break;
                    case 3:
                        this.StaffCellNumber = 3;
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo4;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag4;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation4;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag4;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag4;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms4;
                        break;
                }
                /*
                 * ToolTip初期化
                 */
                if (this.StaffMemoFlag) {
                    ToolTip toolTip = new();
                    toolTip.InitialDelay = 500; // ToolTipが表示されるまでの時間
                    toolTip.ReshowDelay = 1000; // ToolTipが表示されている時に、別のToolTipを表示するまでの時間
                    toolTip.AutoPopDelay = 10000; // ToolTipを表示する時間
                    toolTip.SetToolTip(this, this.StaffMemo);
                }
            } else {
                switch (_hControlVo.SelectNumberStaffMasterVo) {
                    case 0:
                        this.StaffCellNumber = 0;
                        break;
                    case 1:
                        this.StaffCellNumber = 1;
                        break;
                    case 2:
                        this.StaffCellNumber = 2;
                        break;
                    case 3:
                        this.StaffCellNumber = 3;
                        break;
                }
            }
            /*
             * Event
             */
            this.MouseClick += HStaffLabel_MouseClick;
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            /*
             * Label Fill
             */
            e.Graphics.DrawImage(_imageStaffLabel, 2, 1, _panelWidth - 8, _panelHeight - 6);
            /*
             * 文字(氏名)を描画
             */
            StringFormat stringFormat = new();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat.LineAlignment = StringAlignment.Center;
            string displayName = string.Concat(_hStaffMasterVo.DisplayName);
            /*
             * 誕生日は色を変える 
             */
            if (_hStaffMasterVo.BirthDate.Month == DateTime.Now.Month && _hStaffMasterVo.BirthDate.Day == DateTime.Now.Day) {
                e.Graphics.DrawString(displayName, _drawFontStaffLabel, Brushes.Red, new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
            } else {
                e.Graphics.DrawString(displayName, _drawFontStaffLabel, Brushes.Black, new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
            }
            /*
             * Occupation
             * 10:運転手 11:作業員 20:事務職 99:指定なし
             */
            e.Graphics.DrawString(this.StaffOccupationCode == 11 ? "作" : "", _drawFontOccupation, Brushes.Blue, 8, 92);
            /*
             * 代番処理を描画
             */
            if (_staffProxyFlag) {
                e.Graphics.FillRectangle(Brushes.ForestGreen, 14, 4, 43, 5);
                e.Graphics.DrawLine(new Pen(Color.LawnGreen), new Point(10, 6), new Point(58, 6));
            }
            /*
             * メモを描画
             */
            if (this.StaffMemoFlag) {
                Point[] points = { new Point(7, 10), new Point(21, 10), new Point(7, 24) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
            /*
             * 点呼の印を描画
             */
            if (!this.StaffRollCallFlag) {
                e.Graphics.FillEllipse(Brushes.Crimson, 50, 91, 12, 12);
                e.Graphics.FillEllipse(Brushes.LightPink, 55, 97, 4, 4);
            }
        }

        /// <summary>
        /// ContextMenuStrip_Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opened(object sender, EventArgs e) {
            if (((H_StaffLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_SetControl)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        switch (((ToolStripMenuItem)item).Name) {
                            /*
                             * 従事者免許証を表示する
                             * 免許記録があればTrueなければFalse
                             */
                            case "ToolStripMenuItemStaffLicense":
                                ((ToolStripMenuItem)item).Enabled = _hLicenseMasterDao.ExistenceHLicenseMaster(((H_StaffMasterVo)((H_StaffLabel)((ContextMenuStrip)sender).SourceControl).Tag).StaffCode);
                                break;
                            /*
                             * 上記以外
                             */
                            default:
                                ((ToolStripMenuItem)item).Enabled = true;
                                break;
                        }

                }
                /*
                 * H_SetControlのアクセサーを操作するのに使うので退避させておく
                 */
                _evacuationHSetControl = (H_SetControl)((H_StaffLabel)((ContextMenuStrip)sender).SourceControl).Parent;
            } else if (((H_StaffLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_FlowLayoutPanelEx)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        ((ToolStripMenuItem)item).Enabled = false;
                }
            }
        }

        /// <summary>
        /// CreateContextMenuStrip
        /// </summary>
        private void CreateContextMenuStrip() {
            ContextMenuStrip contextMenuStrip = new();
            contextMenuStrip.Name = "ContextMenuStripHStaffLabel";
            contextMenuStrip.Opened += ContextMenuStrip_Opened;
            this.ContextMenuStrip = contextMenuStrip;
            /*
             * 従事者台帳を表示する
             */
            ToolStripMenuItem toolStripMenuItem00 = new("台帳を表示する");
            toolStripMenuItem00.Name = "ToolStripMenuItemStaffDetail";
            toolStripMenuItem00.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem00);
            /*
             * 従事者免許証を表示する
             */
            ToolStripMenuItem toolStripMenuItem01 = new("免許証を表示する");
            toolStripMenuItem01.Name = "ToolStripMenuItemStaffLicense";
            toolStripMenuItem01.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            /*
             * スペーサー
             */
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            /*
             * 代番処理
             */
            ToolStripMenuItem toolStripMenuItem02 = new("代番処理"); // 親アイテム
            toolStripMenuItem02.Name = "ToolStripMenuItemStaffProxy";

            ToolStripMenuItem toolStripMenuItem02_0 = new("代番として記録する"); // 子アイテム１
            toolStripMenuItem02_0.Name = "ToolStripMenuItemStaffProxyTrue";
            toolStripMenuItem02_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_0);
            contextMenuStrip.Items.Add(toolStripMenuItem02);

            ToolStripMenuItem toolStripMenuItem02_1 = new("代番を解除する"); // 子アイテム２
            toolStripMenuItem02_1.Name = "ToolStripMenuItemStaffProxyFalse";
            toolStripMenuItem02_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_1);
            contextMenuStrip.Items.Add(toolStripMenuItem02);
            /*
             * 料金設定
             */
            ToolStripMenuItem toolStripMenuItem03 = new("料金設定"); // 親アイテム
            toolStripMenuItem03.Name = "ToolStripMenuItemStaffOccupation";

            ToolStripMenuItem toolStripMenuItem03_0 = new("運転手の料金設定にする(運賃コードに依存)"); // 子アイテム１
            toolStripMenuItem03_0.Name = "ToolStripMenuItemStaffOccupation10";
            toolStripMenuItem03_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem03.DropDownItems.Add(toolStripMenuItem03_0);
            contextMenuStrip.Items.Add(toolStripMenuItem03);

            ToolStripMenuItem toolStripMenuItem03_1 = new("作業員の料金設定にする"); // 子アイテム２
            toolStripMenuItem03_1.Name = "ToolStripMenuItemStaffOccupation11";
            toolStripMenuItem03_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem03.DropDownItems.Add(toolStripMenuItem03_1);
            contextMenuStrip.Items.Add(toolStripMenuItem03);
            /*
             * 電話連絡・出勤確認
             */
            ToolStripMenuItem toolStripMenuItem04 = new("出勤確認"); // 親アイテム
            toolStripMenuItem04.Name = "ToolStripMenuItemStaffTelephoneMark";

            ToolStripMenuItem toolStripMenuItem04_0 = new("出勤を確認済"); // 子アイテム１
            toolStripMenuItem04_0.Name = "ToolStripMenuItemTelephoneMarkTrue";
            toolStripMenuItem04_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem04.DropDownItems.Add(toolStripMenuItem04_0);
            contextMenuStrip.Items.Add(toolStripMenuItem04);

            ToolStripMenuItem toolStripMenuItem04_1 = new("出勤を未確認"); // 子アイテム２
            toolStripMenuItem04_1.Name = "ToolStripMenuItemStaffTelephoneMarkFalse";
            toolStripMenuItem04_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem04.DropDownItems.Add(toolStripMenuItem04_1);
            contextMenuStrip.Items.Add(toolStripMenuItem04);
            /*
             * メモを作成・編集する
             */
            ToolStripMenuItem toolStripMenuItem05 = new("メモを作成・編集する");
            toolStripMenuItem05.Name = "ToolStripMenuItemStaffMemo";
            toolStripMenuItem05.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem05);
            /*
             * 備品を支給する
             */
            ToolStripMenuItem toolStripMenuItem06 = new("備品を支給する");
            toolStripMenuItem06.Name = "ToolStripMenuItemStaffEquioment";
            toolStripMenuItem06.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem06);
            /*
             * プロパティ
             */
            ToolStripMenuItem toolStripMenuItem07 = new("プロパティ");
            toolStripMenuItem07.Name = "ToolStripMenuItemStaffProperty";
            toolStripMenuItem07.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem07);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * 従事者台帳を表示する
                 */
                case "ToolStripMenuItemStaffDetail":
                    /*
                     * H_Boardに処理を渡す
                     * H_StaffLabel→H_SetControl→H_Board
                     */
                    Event_HStaffLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
                /*
                 * 従事者台帳を表示する
                 */
                case "ToolStripMenuItemStaffLicense":
                    /*
                     * H_Boardに処理を渡す
                     * H_StaffLabel→H_SetControl→H_Board
                     */
                    Event_HStaffLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
                /*
                 * 代番として記録する
                 */
                case "ToolStripMenuItemStaffProxyTrue":
                    this.StaffProxyFlag = true;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStaffProxyFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StaffProxyFlag, this.StaffCellNumber);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 代番を解除する
                 */
                case "ToolStripMenuItemStaffProxyFalse":
                    this.StaffProxyFlag = false;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStaffProxyFlag(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StaffProxyFlag, this.StaffCellNumber);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 運転手の料金設定にする(運賃コードに依存)
                 */
                case "ToolStripMenuItemStaffOccupation10":
                    this.StaffOccupationCode = 10;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStaffOccupation(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StaffOccupationCode, this.StaffCellNumber);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 作業員の料金設定にする
                 */
                case "ToolStripMenuItemStaffOccupation11":
                    this.StaffOccupationCode = 11;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStaffOccupation(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StaffOccupationCode, this.StaffCellNumber);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 出勤を確認済
                 */
                case "ToolStripMenuItemTelephoneMarkTrue":
                    this.StaffRollCallFlag = true;
                    this.Refresh();
                    /*
                     * DB書換え
                     */
                    try {
                        _hVehicleDispatchDetailDao.UpdateStaffRollCall(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StaffRollCallFlag, this.StaffCellNumber);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * 出勤を未確認
                 */
                case "ToolStripMenuItemStaffTelephoneMarkFalse":
                    this.StaffRollCallFlag = false;
                    this.Refresh();
                    try {
                        _hVehicleDispatchDetailDao.UpdateStaffRollCall(((H_ControlVo)_evacuationHSetControl.Tag).CellNumber, _hControlVo.OperationDate, this.StaffRollCallFlag, this.StaffCellNumber);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    break;
                /*
                 * メモを作成・編集する
                 */
                case "ToolStripMenuItemStaffMemo":
                    /*
                     * H_Boardに処理を渡す
                     * H_StaffLabel→H_SetControl→H_Board
                     */
                    Event_HStaffLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
                /*
                 * 備品を支給する
                 */
                case "ToolStripMenuItemStaffEquioment":
                    /*
                     * H_Boardに処理を渡す
                     * H_StaffLabel→H_SetControl→H_Board
                     */
                    Event_HStaffLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
                case "ToolStripMenuItemStaffProperty": // プロパティ
                    /*
                     * H_Boardに処理を回している
                     * H_StaffLabel→H_SetControl→H_Board
                     */
                    Event_HStaffLabel_ToolStripMenuItem_Click.Invoke(sender, e);
                    break;
            }
        }

        /*
         * アクセサー
         */
        /// <summary>
        /// H_SetControl上での配置位置を記録
        /// 0:運転手 1:作業員① 2:作業員② 3:作業員③ 9:指定なし
        /// </summary>
        public int StaffCellNumber {
            get => _cellNumber;
            set => _cellNumber = value;
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string StaffMemo {
            get => _staffMemo;
            set => _staffMemo = value;
        }
        /// <summary>
        /// メモフラグ
        /// true:メモあり false:メモなし
        /// </summary>
        public bool StaffMemoFlag {
            get => _staffMemoFlag;
            set {
                _staffMemoFlag = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 職種
        /// 10:運転手 11:作業員 20:事務職 99:指定なし
        /// </summary>
        public int StaffOccupationCode {
            get => _staffOccupationCode;
            set => _staffOccupationCode = value;
        }
        /// <summary>
        /// 代番フラグ
        /// true:代番 false:本番
        /// </summary>
        public bool StaffProxyFlag {
            get => _staffProxyFlag;
            set => _staffProxyFlag = value;
        }
        /// <summary>
        /// 出庫点呼フラグ
        /// true:出庫点呼済 false:未点呼
        /// </summary>
        public bool StaffRollCallFlag {
            get => _staffRollCallFlag;
            set => _staffRollCallFlag = value;
        }
        /// <summary>
        /// 出庫点呼日時
        /// </summary>
        public DateTime StaffRollCallYmdHms {
            get => _staffRollCallYmdHms;
            set => _staffRollCallYmdHms = value;
        }

        /// <summary>
        /// HStaffLabel_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HStaffLabel_MouseClick(object sender, MouseEventArgs e) {
            /*
             * Shift+ClickがH_SetControl上で発火した場合
             */
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                if (((H_StaffLabel)sender).Parent.GetType() == typeof(H_SetControl)) {
                    try {
                        // StaffRollCallFlagを反転
                        this.StaffRollCallFlag = !this.StaffRollCallFlag;
                        // DB書換え
                        _hVehicleDispatchDetailDao.UpdateStaffRollCall(((H_ControlVo)((H_SetControl)((H_StaffLabel)sender).Parent).Tag).CellNumber, _hControlVo.OperationDate, this.StaffRollCallFlag, this.StaffCellNumber);
                        // 再描画
                        this.Refresh();
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                    /*
                     * Shift+ClickがH_FlowLayoutPanelEx上で発火した場合
                     */
                } else if (((H_StaffLabel)sender).Parent.GetType() == typeof(H_FlowLayoutPanelEx)) {
                    MessageBox.Show("StockBoxsでの点呼処理はできません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
