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
        private bool _confirmAttendanceFlag = false; // 出勤確認フラグ
        private bool _memoFlag = false; // メモフラグ true:メモあり false:メモなし
        /*
         * Vo
         */
        private readonly H_StaffMasterVo _staffMasterVo;
        /*
          * Fontの定義
          */
        private readonly Font _drawFontStaffLabel = new("メイリオ", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        private readonly Font _drawFontOccupation = new("HGS創英ﾌﾟﾚｾﾞﾝｽEB", 10, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="hStaffMasterVo"></param>
        public H_StaffLabel(H_StaffMasterVo hStaffMasterVo) {
            /*
             * Vo
             */
            _staffMasterVo = hStaffMasterVo;
            /*
             * Imageを選択する
             */
            switch (hStaffMasterVo.JobForm) {
                case 10:
                    _imageStaffLabel = Properties.Resources.StaffLabelWhite;
                    break;
                case 11:
                    _imageStaffLabel = Properties.Resources.StaffLabelGreen;
                    break;
                case 12:
                    _imageStaffLabel = Properties.Resources.StaffLabelYellow;
                    break;
                default:
                    _imageStaffLabel = Properties.Resources.StaffLabelWhite;
                    break;
            }
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.BorderStyle = BorderStyle.None;
            this.Height = (int)_panelHeight - 4;
            this.Margin = new Padding(2);
            this.Name = "H_StaffLabel";
            this.Tag = hStaffMasterVo;
            this.Width = (int)_panelWidth - 4;
            /*
             * ContextMenuStrip
             */
            ContextMenuStrip _contextMenuStrip = new();
            string[] _arrayItemName = { "従事者台帳を表示する",
                                        "-",
                                        "代番として記録する",
                                        "代番を解除する",
                                        "-",
                                        "メモを作成・編集する",
                                        "-",
                                        "運転手の料金設定にする(運賃コードに依存)",
                                        "作業員の料金設定にする",
                                        "-",
                                        "電話連絡対象に設定する",
                                        "電話連絡対象を解除する",
                                        "-",
                                        "備品を支給する" };
            foreach (string itemName in _arrayItemName) {
                switch (itemName) {
                    case "-":
                        _contextMenuStrip.Items.Add(new ToolStripSeparator());
                        break;
                    default:
                        ToolStripMenuItem toolStripMenuItem = new(itemName);
                        toolStripMenuItem.Click += ToolStripMenuItem_Click;
                        _contextMenuStrip.Items.Add(toolStripMenuItem);
                        break;
                }
            }
            _contextMenuStrip.Opened += ContextMenuStrip_Opened;
            this.ContextMenuStrip = _contextMenuStrip;
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
                        switch (((ToolStripMenuItem)item).Text) {
                            case "従事者台帳を表示する":
                            case "メモを作成・編集する":
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
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {

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
            e.Graphics.DrawString(_staffMasterVo.Occupation == 11 ? "作" : "", _drawFontOccupation, Brushes.DarkGray, 8, 72);
        }
    }
}
