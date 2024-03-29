/*
 * 2023-02-20
 * ProductionListに新しい配車先を追加する
 */
using Common;

using Dao;

using Vo;

namespace Production {
    public partial class ProductionSelect : Form {
        private int _cell_number;
        private DateTime _financial_datetime;
        /*
         * Dao
         */
        private readonly SetMasterDao _setMasterDao;
        private VehicleDispatchHeadDao _vehicleDispatchHeadDao;
        /*
         * Vo
         */
        private readonly List<SetMasterVo> _listSetMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="cell_number"></param>
        /// <param name="financial_datetime"></param>
        public ProductionSelect(ConnectionVo connectionVo, int cell_number, DateTime financial_datetime) {
            _cell_number = cell_number;
            _financial_datetime = financial_datetime;
            /*
             * Dao
             */
            _setMasterDao = new SetMasterDao(connectionVo);
            _vehicleDispatchHeadDao = new VehicleDispatchHeadDao(connectionVo);
            /*
             * Vo
             */
            _listSetMasterVo = _setMasterDao.SelectAllSetMaster();
            /*
             * Control初期化
             */
            InitializeComponent();
            LabelCellNumber.Text = cell_number.ToString();
            InitializeComboBoxSetMaster();
            LabelNumberOfPeople.Text = "";
            LabelDayOfWeek.Text = "";
        }

        /// <summary>
        /// ButtonUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e) {
            ExtendsClassSetMasterVo extendsClassSetMasterVo;
            if(ComboBoxSetName.SelectedItem is not null) {
                extendsClassSetMasterVo = (ExtendsClassSetMasterVo)ComboBoxSetName.SelectedItem;
                try {
                    _vehicleDispatchHeadDao.UpdateVehicleDispatchHead(_cell_number, _financial_datetime, extendsClassSetMasterVo.SetMasterVo);
                } catch(Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            } else {
                MessageBox.Show("配車先が選択されていません", MessageText.Message101, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }

        /// <summary>
        /// InitializeComboBoxSetMaster
        /// ComboBoxに値をセット
        /// </summary>
        private void InitializeComboBoxSetMaster() {
            // Itemsをクリア
            ComboBoxSetName.Items.Clear();
            // Itemをセット
            foreach(var setMasteVo in _listSetMasterVo.FindAll(x => x.Delete_flag == false).OrderBy(x => x.Set_code))
                ComboBoxSetName.Items.Add(new ExtendsClassSetMasterVo(string.Concat(setMasteVo.Set_name_1, setMasteVo.Set_name_2), setMasteVo));
            ComboBoxSetName.DisplayMember = "SetName";
            // オートコンプリートモードの設定
            ComboBoxSetName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // コンボボックスのアイテムをオートコンプリートの選択候補とする
            ComboBoxSetName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// ComboBoxSetName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSetName_SelectedIndexChanged(object sender, EventArgs e) {
            ExtendsClassSetMasterVo nestedClassSetMasterVo = (ExtendsClassSetMasterVo)ComboBoxSetName.SelectedItem;
            /*
             * Controlに表示
             */
            // cell_number
            LabelCellNumber.Text = _cell_number.ToString();
            // 本番人数
            LabelNumberOfPeople.Text = nestedClassSetMasterVo.SetMasterVo.Number_of_people.ToString("0人");
            // 配車曜日
            LabelDayOfWeek.Text = nestedClassSetMasterVo.SetMasterVo.Working_days;
        }

        /// <summary>
        /// ExtendsClassSetMasterVo
        /// ComboBoxSetNameに格納するクラス
        /// </summary>
        private class ExtendsClassSetMasterVo {
            private string _setName = string.Empty;
            private SetMasterVo _setMasterVo;

            public ExtendsClassSetMasterVo(string setName, SetMasterVo setMasterVo) {
                _setName = setName;
                _setMasterVo = setMasterVo;
            }

            public string SetName {
                get => _setName;
                set => _setName = value;
            }

            public SetMasterVo SetMasterVo {
                get => _setMasterVo;
                set => _setMasterVo = value;
            }
        }
    }
}
