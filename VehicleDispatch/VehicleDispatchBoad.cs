/*
 * 
 */
using Common;

using ControlEx;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        /// <summary>
        /// Connectionを保持
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// InitializeFormのインスタンス
        /// </summary>
        private InitializeForm _initializeForm = new();

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
            // Formを初期化する
            _initializeForm.VehicleDispatchBoad(this);
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        private void button1_Click(object sender, EventArgs e) {
            /*
             * Test Data
             */
            var setLedgerVo = new SetLedgerVo();
            setLedgerVo.Set_name_1 = "歌舞伎";
            setLedgerVo.Set_name_2 = "1-61";

            var carLedgerVo = new CarLedgerVo();
            carLedgerVo.Disguise_kind_1 = "小プ";
            carLedgerVo.Door_number = "123";
            carLedgerVo.Registration_number_1 = "足立";
            carLedgerVo.Registration_number_2 = "444";
            carLedgerVo.Registration_number_3 = "れ";
            carLedgerVo.Registration_number_4 = "4444";

            var staffLedgerVo = new StaffLedgerVo();
            staffLedgerVo.Display_name = "フローレス・M";
            /*
             * 
             */

            var vehicleDispatchControlVo = new VehicleDispatchBoadVo();
            vehicleDispatchControlVo.Column = 0;
            vehicleDispatchControlVo.Row = 0;
            vehicleDispatchControlVo.SetFlag = true;
            vehicleDispatchControlVo.OperationFlag = true;
            vehicleDispatchControlVo.GarageFlag = false;
            vehicleDispatchControlVo.ProductionNumberOfPeople = 3;
            vehicleDispatchControlVo.SetLedgerVo = setLedgerVo;
            vehicleDispatchControlVo.CarLedgerVo = carLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[0] = staffLedgerVo;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[1] = default;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[2] = default;
            vehicleDispatchControlVo.ArrayStaffLedgerVo[3] = default;

            CreateSetControl(vehicleDispatchControlVo);
        }

        /// <summary>
        /// CreateSetControl
        /// １組分のLabelセットを作成
        /// </summary>
        /// <param name="vehicleDispatchBoadVo"></param>
        public void CreateSetControl(VehicleDispatchBoadVo vehicleDispatchBoadVo) {
            /*
             * SetControlを作成する仕様は？
             * 
             * 
             * GarageFlag値によってBorderColorが変わる(三郷車庫からの配車を視覚的に表示する)
             * ProductionNumberOfPeople値によってTablLayoutPanelの枠数が決まる(本番人数を明示する)
             */
            var setControlEx = new SetControlEx();
            setControlEx.SetFlag = vehicleDispatchBoadVo.SetFlag;
            setControlEx.StopCarFlag = vehicleDispatchBoadVo.OperationFlag;
            setControlEx.GarageFlag = vehicleDispatchBoadVo.GarageFlag;
            setControlEx.ProductionNumberOfPeople = vehicleDispatchBoadVo.ProductionNumberOfPeople;
            /*
             * SetLedgerVoがNullの場合CreateLabelを呼ばない
             */
            if (vehicleDispatchBoadVo.SetLedgerVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.SetLedgerVo);
            /*
             * CarLedgerVoがNullの場合CreateLabelを呼ばない
             */
            if (vehicleDispatchBoadVo.CarLedgerVo != null)
                setControlEx.CreateLabel(vehicleDispatchBoadVo.CarLedgerVo);
            /*
             * ArrayStaffLedgerVo.Lengthは最大4だよ(最大で運転手1名と作業員3名)
             */
            for (int i = 0; i < vehicleDispatchBoadVo.ArrayStaffLedgerVo.Length; i++) {
                /*
                 * ArrayStaffLedgerVo[i]がNullの場合CreateLabelを呼ばない
                 */
                if (vehicleDispatchBoadVo.ArrayStaffLedgerVo[i] != null)
                    setControlEx.CreateLabel(i, vehicleDispatchBoadVo.ArrayStaffLedgerVo[i]);
            }
            TableLayoutPanelEx1.Controls.Add(setControlEx, vehicleDispatchBoadVo.Column, vehicleDispatchBoadVo.Row);
            /*
             * UserControlからイベントを受け取る
             */
            setControlEx.Event_SetControlEx_Click += new EventHandler(SetControlEx_Click);
            setControlEx.Event_SetControlEx_DragDrop += new DragEventHandler(SetControlEx_DragDrop);
            setControlEx.Event_SetControlEx_DragEnter += new DragEventHandler(SetControlEx_DragEnter);
            setControlEx.Event_LabelExControl_Click += new EventHandler(LabelEx_Click);
            setControlEx.Event_LabelExControl_MouseMove += new MouseEventHandler(LabelEx_MouseMove);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_Click(object? sender, EventArgs e) {
            MessageBox.Show("SetControl_Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragDrop(object? sender, DragEventArgs e) {
            // e.DataはNullの可能性があるのでチェックする
            if (e.Data == null)
                return;

            // Dropを受け入れない
            e.Effect = DragDropEffects.None;
            // Drag側のObjectを退避
            var dragItem = e.Data.GetData(typeof(LabelEx));
            // DragされたLabelExのTagを取得
            var dragLabelTag = ((LabelEx)e.Data.GetData(typeof(LabelEx))).Tag;
            // DragされたLabelExのTableLayoutPanelEx上での位置を取得
            var dragLabelCellPosition = ((TableLayoutPanelEx)((LabelEx)dragItem).Parent).GetCellPosition((Control)dragItem);



            MessageBox.Show("UserControlSetControl_DragDrop");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetControlEx_DragEnter(object? sender, DragEventArgs e) {
            // Iconの状態を変更
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_Click(object? sender, EventArgs e) {
            MessageBox.Show("Label_Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelEx_MouseMove(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // ドラッグドロップイベントの開始
                if (sender != null)
                    ((LabelEx)sender).DoDragDrop(sender, DragDropEffects.Move);
            }
        }


        /// <summary>
        /// VehicleDispatchBoad_KeyDown
        /// ショートカットキー等の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchBoad_KeyDown(object sender, KeyEventArgs e) {
            // Open
            if (e.KeyData == (Keys.Shift | Keys.O)) {
                _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, true);
            }
            // Close
            if (e.KeyData == (Keys.Shift | Keys.C)) {
                _initializeForm.SetTableLayoutPanelAll(TableLayoutPanelBase, false);
            }

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleDispatchBoad_FormClosing(object sender, FormClosingEventArgs e) {
            var dialogResult = MessageBox.Show(MessageText.Message102, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}