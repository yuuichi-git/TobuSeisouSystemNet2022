﻿/*
 * 2023-10-25
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_CarLabel : Label {
        private Image _imageCarLabel;
        /*
         * １つのパネルのサイズ
         */
        private const float _panelWidth = 80;
        private const float _panelHeight = 100;
        /*
         * プロパティ
         */
        /// <summary>
        /// 代車フラグ
        /// true:代車 false:本番車
        /// </summary>
        private bool _carProxyFlag = false;
        /// <summary>
        /// メモフラグ
        /// true:メモが存在する false:メモが存在しない
        /// </summary>
        private bool _carMemoFlag = false;
        /// <summary>
        /// メモ
        /// </summary>
        private string _carMemo = string.Empty;

        /*
         * Vo
         */
        private readonly H_CarMasterVo _hCarMasterVo;
        /*
         * 色の定義
         */
        private readonly SolidBrush _brushColorBlack = new(Color.Black);
        private readonly SolidBrush _brushColorWhite = new SolidBrush(Color.White);
        private readonly SolidBrush _brushFillColor;
        /*
         * Fontの定義
         */
        private readonly Font _drawFontCarLabel = new("Yu Gothic UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        public H_CarLabel(H_CarMasterVo hCarMasterVo) {
            /*
             * Vo
             */
            _hCarMasterVo = hCarMasterVo;
            /*
             * 本社・三郷で色を変える
             */
            switch (_hCarMasterVo.GarageCode) {
                case 1:
                    _brushFillColor = new SolidBrush(Color.White);
                    break;
                case 2:
                    _brushFillColor = new SolidBrush(Color.PowderBlue);
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
            this.Name = "H_CarLabel";
            this.Tag = _hCarMasterVo;
            this.Width = (int)_panelWidth - 4;

            this.CreateContextMenuStrip();
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
            e.Graphics.DrawString(number, _drawFontCarLabel, new SolidBrush(Color.Black), new Rectangle(0, 0, (int)_panelWidth - 6, (int)_panelHeight - 6), stringFormat);
            /*
             * 代車処理を描画
             */
            if (_carProxyFlag) {
                e.Graphics.FillRectangle(Brushes.ForestGreen, 8, 5, 60, 5);
                e.Graphics.DrawLine(new Pen(Color.LawnGreen), new Point(7, 7), new Point(69, 7));
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
             * 代番処理
             */
            ToolStripMenuItem toolStripMenuItem01 = new("代車処理"); // 親アイテム
            toolStripMenuItem01.Name = "ToolStripMenuItemCarProxy";
            ToolStripMenuItem toolStripMenuItem01_0 = new("代車として記録する"); // 子アイテム１
            toolStripMenuItem01_0.Name = "ToolStripMenuItemCarProxyTrue";
            toolStripMenuItem01_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_0);
            contextMenuStrip.Items.Add(toolStripMenuItem01);

            ToolStripMenuItem toolStripMenuItem01_1 = new("代車を解除する"); // 子アイテム２
            toolStripMenuItem01_1.Name = "ToolStripMenuItemCarProxyFalse";
            toolStripMenuItem01_1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem01.DropDownItems.Add(toolStripMenuItem01_1);
            contextMenuStrip.Items.Add(toolStripMenuItem01);
            /*
             * 出庫地
             */
            ToolStripMenuItem toolStripMenuItem02 = new("出庫地"); // 親アイテム
            toolStripMenuItem01.Name = "ToolStripMenuItemCarWarehouse";
            ToolStripMenuItem toolStripMenuItem02_0 = new("本社から出庫"); // 子アイテム１
            toolStripMenuItem02_0.Name = "ToolStripMenuItemCarWarehouseAdachi";
            toolStripMenuItem02_0.Click += ToolStripMenuItem_Click;
            toolStripMenuItem02.DropDownItems.Add(toolStripMenuItem02_0);
            contextMenuStrip.Items.Add(toolStripMenuItem02);

            ToolStripMenuItem toolStripMenuItem02_1 = new("三郷から出庫"); // 子アイテム２
            toolStripMenuItem02_1.Name = "ToolStripMenuItemCarWarehouseMisato";
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
                case "ToolStripMenuItemCarDetail": // 車両台帳を表示する
                    MessageBox.Show("ToolStripMenuItemCarDetail");
                    break;
                case "ToolStripMenuItemCarProxyTrue": // 代車として記録する
                    MessageBox.Show("ToolStripMenuItemCarProxyTrue");
                    break;
                case "ToolStripMenuItemCarProxyFalse": // 代車を解除する
                    MessageBox.Show("ToolStripMenuItemCarProxyFalse");
                    break;
                case "ToolStripMenuItemCarWarehouseAdachi": // 本社から出庫
                    _hCarMasterVo.GarageCode = 1;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemCarWarehouseMisato": // 三郷から出庫
                    _hCarMasterVo.GarageCode = 2;
                    this.Refresh();
                    break;
                case "ToolStripMenuItemCarMemo": // メモを作成・編集する
                    MessageBox.Show("ToolStripMenuItemCarMemo");
                    break;
                case "ToolStripMenuItemCarNippou": // 日報を作成する
                    MessageBox.Show("ToolStripMenuItemCarNippou");
                    break;
            }
        }

        /*
         * アクセサー
         */
        /// <summary>
        /// 代車フラグ
        /// true:代車 false:本番車
        /// </summary>
        public bool CarProxyFlag {
            get => _carProxyFlag;
            set => _carProxyFlag = value;
        }
        /// <summary>
        /// メモフラグ
        /// true:メモが存在する false:メモが存在しない
        /// </summary>
        public bool CarMemoFlag {
            get => _carMemoFlag;
            set => _carMemoFlag = value;
        }
        /// <summary>
        /// メモ
        /// </summary>
        public string CarMemo {
            get => _carMemo;
            set => _carMemo = value;
        }
    }
}