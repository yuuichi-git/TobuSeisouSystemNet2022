using Dao;

using Vo;

namespace License {
    public partial class LicenseCard : Form {
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        public LicenseCard(ConnectionVo connectionVo, int staffCode) {
            InitializeComponent();
            _connectionVo = connectionVo;
            Output(staffCode);
        }

        /// <summary>
        /// Output
        /// </summary>
        /// <param name="staffCode"></param>
        public void Output(int staffCode) {
            // データを取得
            var licenseMasterVo = new LicenseMasterDao(_connectionVo).SelectOneLicenseMaster(staffCode);
            // 写真表
            if (licenseMasterVo.Picture_head != null && licenseMasterVo.Picture_head.Length != 0) {
                PictureBoxHead.Image = (Image?)new ImageConverter().ConvertFrom(licenseMasterVo.Picture_head);
            }
        }
    }
}
