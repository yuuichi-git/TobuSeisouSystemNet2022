using Common;

using Vo;

namespace VehicleDispatch {
    public partial class VehicleDispatchBoad : Form {
        /// <summary>
        /// Connection��ێ�
        /// </summary>
        private readonly ConnectionVo _connectionVo;

        public VehicleDispatchBoad(ConnectionVo connectionVo) {
            InitializeComponent();
            _connectionVo = connectionVo;
            // Form�̕\���T�C�Y��������
            new InitializeForm().GetWorkingArea(this);
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }


    }
}