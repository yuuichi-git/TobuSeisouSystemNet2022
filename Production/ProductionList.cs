/*
 * 2022-09-18
 */
using Common;

using ControlEx;

using Dao;

using Vo;

namespace Production {
    public partial class ProductionList : Form {
        /// <summary>
        /// Connectionを保持
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// インスタンス作成
        /// </summary>
        private InitializeForm _initializeForm = new();
        private List<SetMasterVo> _listSetMasterVo = new();
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<StaffMasterVo> _listStaffMasterVo = new();
        private List<VehicleDispatchHeadVo> _listVehicleDispatchHeadVo = new();
        private LabelEx _labelEx = new();

        public ProductionList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * DBを読込
             */
            _listSetMasterVo = new SetMasterDao(connectionVo).SelectAllSetMasterVo();
            _listCarMasterVo = new CarMasterDao(connectionVo).SelectAllCarMaster();
            _listStaffMasterVo = new StaffMasterDao(connectionVo).SelectAllStaffMasterVo();
            _listVehicleDispatchHeadVo = new VehicleDispatchHeadDao(connectionVo).SelectAllVehicleDispatchHeadVo();
            /*
             * Formを初期化する
             */
            InitializeComponent();
            _initializeForm.ProductionList(this);
            CreateSetLabels();
        }

        /// <summary>
        /// エントリーポイント
        /// </summary>
        public static void Main() {
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateSetLabels() {
            int i = 1;
            //レイアウトロジックを停止する
            TableLayoutPanelEx2.SuspendLayout();
            foreach (var vehicleDispatchHeadVo in _listVehicleDispatchHeadVo.OrderBy(x => x.Cell_number)) {
                int column = (i % 25) - 1;
                int row = i / 25;
                int? setCode = vehicleDispatchHeadVo.Set_code;
                SetMasterVo? setMasterVo;
                if (setCode.HasValue) {
                    setMasterVo = _listSetMasterVo.Find(x => x.Set_code == setCode);
                    if (setMasterVo != null) {
                        var labelEx = new LabelEx().CreateLabel(setMasterVo);
                        TableLayoutPanelEx2.Controls.Add(labelEx, column, row);
                    }
                }
                i++;
            }
            //レイアウトロジックを再開する
            TableLayoutPanelEx2.ResumeLayout();
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
        private void ProductionList_FormClosing(object sender, FormClosingEventArgs e) {
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