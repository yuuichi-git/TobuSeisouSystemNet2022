using Common;

using FarPoint.Win.Spread;

using Vo;

namespace Substitute {
    public partial class SubstitutePaper : Form {
        private ConnectionVo _connectionVo;
        private InitializeForm _initializeForm = new();

        public SubstitutePaper(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;

            /*
             * �R���g���[��������
             */
            InitializeComponent();
            _initializeForm.SubstitutePaper(this);
            // �V�[�g�^�u���\��
            SpreadPaper.TabStripPolicy = TabStripPolicy.Never;

        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }


    }
}