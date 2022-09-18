/*
 * 2022-09-18
 */
using Common;

using Vo;

namespace Production {
    public partial class ProductionList : Form {
        /// <summary>
        /// Connection��ێ�
        /// </summary>
        private readonly ConnectionVo _connectionVo;
        /// <summary>
        /// �C���X�^���X�쐬
        /// </summary>
        private InitializeForm _initializeForm = new();
        private List<SetMasterVo> _listSetMasterVo = new();
        private List<CarMasterVo> _listCarMasterVo = new();
        private List<StaffMasterVo> _listStaffMasterVo = new();

        public ProductionList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            InitializeComponent();
            // Form������������
            _initializeForm.ProductionList(this);
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

    }
}