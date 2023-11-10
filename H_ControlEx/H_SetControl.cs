﻿/*
 * 2023-10-20
 */
using H_Vo;

namespace H_ControlEx {
    public partial class H_SetControl : TableLayoutPanel {
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
        /*
         * StaffLabel用のCellの位置を保持
         */
        private Dictionary<int,Point> _dictionaryCellPoint = new() { { 0, new Point(0, 2) }, { 1, new Point(0, 3) }, { 2, new Point(1, 2) }, { 3, new Point(1, 3) } }; // StaffLabel用のCellの位置
        /*
         * Vo
         */
        private readonly H_SetControlVo _hSetControlVo;
        /*
         * Eventを親へ渡す処理
         * インスタンスから見えるようになる
         */
        public event MouseEventHandler Event_SetControl_MouseDown = delegate {};
        public event MouseEventHandler Event_SetControl_MouseUp = delegate {};
        public event MouseEventHandler Event_SetControl_MouseMove = delegate {};

        /// <summary>
        /// コンストラクタ
        /// 配車されているSetControlを作成する
        /// H_SetControlVoに全ての引数を代入しておく
        /// </summary>
        public H_SetControl(H_SetControlVo hSetControlVo) {
            /*
             * Vo
             */
            _hSetControlVo = hSetControlVo;
            /*
             * ControlIni
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Name = "H_SetControl";
            this.Padding = new Padding(0);
            /*
             * SetControlの形状(１列か２列か)を決定する
             */
            switch(hSetControlVo.Purpose) {
                case true: // ２列
                    this.Size = new Size(160, 400);
                    this.ColumnCount = 2;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
                case false: // １列
                    this.Size = new Size(80, 400);
                    this.ColumnCount = 1;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _panelWidth));
                    this.RowCount = _rowCount;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, _panelHeight));
                    break;
            }
            // SetLabelを作成
            CreateHSetLabel(hSetControlVo.HSetMasterVo);

            /*
             * Event
             */
            this.MouseDown += SetControl_MouseDown;
            this.MouseUp += SetControl_MouseUp;
            this.MouseMove += SetControl_MouseMove;
        }

        /// <summary>
        /// CreateHSetLabel
        /// </summary>
        private void CreateHSetLabel(H_SetMasterVo hSetMasterVo) {
            if(hSetMasterVo is not null) { // HSetMasterVoがNullの場合、作成処理をしない
                H_SetLabel hSetLabel = new(hSetMasterVo);
                this.Controls.Add(hSetLabel, 0, 0); // SetLabelを追加
            }
        }

        /// <summary>
        /// CreateHCarLabel
        /// </summary>
        private void CreateHCarLabel(H_CarMasterVo hCarMasterVo) {
            if(hCarMasterVo is not null) { // HCarMasterVoがNullの場合、作成処理をしない
                H_CarLabel hCarLabel = new(hCarMasterVo);
                this.Controls.Add(hCarLabel, 0, 1); // CarLabelを追加
            }
        }

        /// <summary>
        /// CreateHStaffLabel
        /// </summary>
        /// <param name="listHStaffMasterVo"></param>
        private void CreateHStaffLabel(List<H_StaffMasterVo> listHStaffMasterVo) {
            int i = 0;
            if(listHStaffMasterVo is not null) { // HStaffMasterVoがNullの場合、作成処理をしない
                foreach(H_StaffMasterVo hStaffMasterVo in listHStaffMasterVo) {
                    Point point = _dictionaryCellPoint[i];
                    H_StaffLabel hStaffLabel = new(hStaffMasterVo);
                    this.Controls.Add(hStaffLabel, point.X, point.Y); // StaffLabelを追加
                    i++;
                }
            }
        }

        /// <summary>
        /// OnCellPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e) {
            /*
             * Boderを描画
             */
            Rectangle rectangle = e.CellBounds;
            rectangle.Inflate(-1, -1); // 枠のサイズを小さくする
            if(_hSetControlVo.VehicleDispatchFlag) {
                switch(e.Column) {
                    case 0:
                        switch(e.Row) {
                            case 0: // SetLabel
                                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // SetLabelExの枠線
                                break;
                            case 1: // CarLabel
                                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // CarLabelExの枠線
                                break;
                            case 2: // StaffLabel(1人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 1)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                                break;
                            case 3: // StaffLabel(2人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 2)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                                break;
                        }
                        break;
                    case 1:
                        switch(e.Row) {
                            case 2: // StaffLabel(3人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 3)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                                break;
                            case 3: // StaffLabel(4人目)
                                if(_hSetControlVo.HSetMasterVo.NumberOfPeople >= 4)
                                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Gray, ButtonBorderStyle.Dotted); // StaffLabelの枠線
                                break;
                        }
                        break;
                }
            } else {

            }

        }

        /*
         * Event
         */
        private void SetControl_MouseDown(object sender, MouseEventArgs e) {
            Event_SetControl_MouseDown.Invoke(sender, e);
        }
        private void SetControl_MouseUp(object sender, MouseEventArgs e) {
            Event_SetControl_MouseUp.Invoke(sender, e);
        }
        private void SetControl_MouseMove(object sender, MouseEventArgs e) {
            Event_SetControl_MouseMove.Invoke(sender, e);
        }
    }
}
