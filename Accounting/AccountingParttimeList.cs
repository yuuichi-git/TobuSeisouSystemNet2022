using Common;

using FarPoint.Win.Spread;

using Vo;

namespace Accounting {
    public partial class AccountingParttimeList : Form {
        private ConnectionVo _connectionVo;
        private readonly InitializeForm _initializeForm = new();

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public AccountingParttimeList(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.AccountingParttimeList(this);
            // �V�[�g�^�u���\��
            SpreadList.TabStripPolicy = TabStripPolicy.Never;

        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }


    }
}