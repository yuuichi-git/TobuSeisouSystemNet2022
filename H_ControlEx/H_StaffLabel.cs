/*
 * 2023-10-31
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_StaffLabel : Label {
        private readonly Image _imageStaffLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * プロパティー
         */
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
        private bool _staffRollCallFlag = true;
        /// <summary>
        /// 点呼日時
        /// </summary>
        private DateTime _staffRollCallYmdHms = new DateTime(1900, 01, 01);

        /*
         * Vo
         */
        private H_ControlVo _hControlVo;
        private readonly H_StaffMasterVo _staffMasterVo;
        private H_VehicleDispatchDetailVo _hVehicleDispatchDetailVo;
        /*
          * Fontの定義
          */
        private readonly Font _drawFontStaffLabel = new("メイリオ", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly Font _drawFontOccupation = new("HGS創英ﾌﾟﾚｾﾞﾝｽEB", 10, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="hStaffMasterVo"></param>
        public H_StaffLabel(H_ControlVo hControlVo) {
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            _staffMasterVo = hControlVo.HStaffMasterVo;
            _hVehicleDispatchDetailVo = hControlVo.HVehicleDispatchDetailVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 4;
            this.Margin = new Padding(2);
            this.Name = "H_StaffLabel";
            this.Tag = _staffMasterVo;
            this.Width = (int)_panelWidth - 4;
            this.CreateContextMenuStrip();
            /*
             * Imageを選択する
             */
            _imageStaffLabel = _staffMasterVo.JobForm switch {
                10 => Properties.Resources.StaffLabelWhite,
                11 => Properties.Resources.StaffLabelGreen,
                12 => Properties.Resources.StaffLabelYellow,
                _ => Properties.Resources.StaffLabelWhite,
            };
            /*
             * プロパティーの設定
             */
            if (_hVehicleDispatchDetailVo is not null) {
                /*
                 * _hControlVo.SelectNumberStaffMasterVoを使って、何番目のデータかを知る
                 */
                switch (_hControlVo.SelectNumberStaffMasterVo) {
                    case 0:
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo1;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag1;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation1;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag1;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag1;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms1;
                        break;
                    case 1:
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo2;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag2;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation2;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag2;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag2;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms2;
                        break;
                    case 2:
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo3;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag3;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation3;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag3;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag3;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms3;
                        break;
                    case 3:
                        this.StaffMemo = _hVehicleDispatchDetailVo.StaffMemo4;
                        this.StaffMemoFlag = _hVehicleDispatchDetailVo.StaffMemoFlag4;
                        this.StaffOccupationCode = _hVehicleDispatchDetailVo.StaffOccupation4;
                        this.StaffProxyFlag = _hVehicleDispatchDetailVo.StaffProxyFlag4;
                        this.StaffRollCallFlag = _hVehicleDispatchDetailVo.StaffRollCallFlag4;
                        this.StaffRollCallYmdHms = _hVehicleDispatchDetailVo.StaffRollCallYmdHms4;
                        break;
                }
            } else {

            }
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
            string displayName = string.Concat(_staffMasterVo.DisplayName);
            /*
             * 誕生日は色を変える 
             */
            if (_staffMasterVo.BirthDate.Month == DateTime.Now.Month && _staffMasterVo.BirthDate.Day == DateTime.Now.Day) {
                e.Graphics.DrawString(displayName, _drawFontStaffLabel, Brushes.Red, new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
            } else {
                e.Graphics.DrawString(displayName, _drawFontStaffLabel, Brushes.Black, new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
            }
            /*
             * Occupation
             * 10:運転手 11:作業員 20:事務職 99:指定なし
             */
            e.Graphics.DrawString(this.StaffOccupationCode == 11 ? "作" : "", _drawFontOccupation, Brushes.DarkGray, 8, 72);
            /*
             * 代番処理を描画
             */
            if (StaffProxyFlag) {
                e.Graphics.FillRectangle(Brushes.ForestGreen, 14, 4, 48, 5);
                e.Graphics.DrawLine(new Pen(Color.LawnGreen), new Point(10, 6), new Point(63, 6));
            }
            /*
             * メモを描画
             */
            if (StaffMemoFlag) {
                Point[] points = { new Point(7, 10), new Point(21, 10), new Point(7, 24) };
                e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), points);
            }
            /*
             * 点呼の印を描画
             */
            if (!StaffRollCallFlag) {
                e.Graphics.FillEllipse(Brushes.Crimson, 56, 73, 10, 10);
                e.Graphics.FillEllipse(Brushes.LightPink, 60, 77, 4, 4);
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
                        ((ToolStripMenuItem)item).Enabled = true;
                }
            } else if (((H_StaffLabel)((ContextMenuStrip)sender).SourceControl).Parent.GetType() == typeof(H_FlowLayoutPanelEx)) {
                foreach (object item in ((ContextMenuStrip)sender).Items) {
                    if (item.GetType() == typeof(ToolStripMenuItem)) {
                        switch (((ToolStripMenuItem)item).Name) {
                            case "ToolStripMenuItemStaffDetail":
                            case "ToolStripMenuItemStaffMemo":
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
            contextMenuStrip.Name = "ContextMenuStripHStaffLabel";
            contextMenuStrip.Opened += ContextMenuStrip_Opened;
            this.ContextMenuStrip = contextMenuStrip;
            /*
             * 従事者台帳を表示する
             */
            ToolStripMenuItem toolStripMenuItem00 = new("従事者台帳を表示する");
            toolStripMenuItem00.Name = "ToolStripMenuItemStaffDetail";
            toolStripMenuItem00.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem00);
            /*
             * スペーサー
             */
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            /*
             * 代番処理
             */
            ToolStripMenuItem toolStripMenuItem01 = new("代番処理"); // 親アイテム
            toolStripMenuItem01.Name = "ToolStripMenuItemStaffProxy";
            ToolStripMenuItem toolStripMenuItem01_0 = new("代番として記録する"); // 子アイテム１
            toolStripMenuItem01_0.Name = "ToolStripMenuItemStaffProxyTrue";
            toolStripMenuItem01_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_0);
            contextMenuStrip.Items.Add(toolStripMenuItem01);

            ToolStripMenuItem toolStripMenuItem01_1 = new("代番を解除する"); // 子アイテム２
            toolStripMenuItem01_1.Name = "ToolStripMenuItemStaffProxyFalse";
            toolStripMenuItem01_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_1);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            /*
             * メモを作成・編集する
             */
            ToolStripMenuItem toolStripMenuItem02 = new("メモを作成・編集する");
            toolStripMenuItem02.Name = "ToolStripMenuItemStaffMemo";
            toolStripMenuItem02.Click += ToolStripMenuItem_Click;
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
             * 備品を支給する
             */
            ToolStripMenuItem toolStripMenuItem05 = new("備品を支給する");
            toolStripMenuItem05.Name = "ToolStripMenuItemStaffEquioment";
            toolStripMenuItem05.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem05);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemStaffDetail": // 従事者台帳を表示する
                    MessageBox.Show("ToolStripMenuItemStaffDetail");
                    break;
                case "ToolStripMenuItemStaffProxyTrue": // 代番として記録する
                    MessageBox.Show("ToolStripMenuItemStaffProxyTrue");
                    break;
                case "ToolStripMenuItemStaffProxyFalse": // 代番を解除する
                    MessageBox.Show("ToolStripMenuItemStaffProxyFalse");
                    break;
                case "ToolStripMenuItemStaffMemo": // メモを作成・編集する
                    MessageBox.Show("ToolStripMenuItemStaffMemo");
                    break;
                case "ToolStripMenuItemStaffOccupation10": // 運転手の料金設定にする(運賃コードに依存)
                    MessageBox.Show("ToolStripMenuItemStaffOccupation10");
                    break;
                case "ToolStripMenuItemStaffOccupation11": // 作業員の料金設定にする
                    MessageBox.Show("ToolStripMenuItemStaffOccupation11");
                    break;
                case "ToolStripMenuItemTelephoneMarkTrue": // 出勤を確認済
                    MessageBox.Show("ToolStripMenuItemTelephoneMarkTrue");
                    break;
                case "ToolStripMenuItemStaffTelephoneMarkFalse": // 出勤を未確認
                    MessageBox.Show("ToolStripMenuItemStaffTelephoneMarkFalse");
                    break;
                case "ToolStripMenuItemStaffEquioment": // 備品を支給する
                    MessageBox.Show("ToolStripMenuItemStaffEquioment");
                    break;
            }
        }

        /*
         * アクセサー
         */
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
            set => _staffMemoFlag = value;
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
    }
}
