/*
 * 2023-02-20
 * ProductionListに新しい配車先を追加する
 */
using Dao;

using Vo;

namespace Production {
    public partial class ProductionSelect : Form {
        private int _cell_number;
        private readonly DateTime _financial_datetime;
        /*
         * Dao
         */
        private readonly SetMasterDao _setMasterDao;
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

        private void ButtonUpdate_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// InitializeComboBoxSetMaster
        /// ComboBoxに値をセット
        /// </summary>
        private void InitializeComboBoxSetMaster() {

            ComboBoxSetName.Items.Clear();
            foreach(var setMasteVo in _listSetMasterVo.FindAll(x => x.Delete_flag == false).OrderBy(x => x.Set_code))
                ComboBoxSetName.Items.Add(new ExtendsClassSetMasterVo(setMasteVo.Set_name, setMasteVo));
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
