/*
 * 2024-06-19
 */
using H_Dao;

using Vo;

namespace H_Car {
    public partial class H_CarVerification : Form {
        /*
         * Dao
         */
        private readonly H_CarMasterDao _hCarMasterDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_CarVerification(ConnectionVo connectionVo, int carCode) {
            /*
             * Dao
             */
            _hCarMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.PutMainPicture(_hCarMasterDao.SelectOneMainPicture(carCode));
            this.PutSubPicture(_hCarMasterDao.SelectOneSubPicture(carCode));
        }

        /// <summary>
        /// 車検証
        /// </summary>
        /// <param name="picture"></param>
        private void PutMainPicture(byte[] picture) {
            if (picture.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxExMainPicture.Image = (Image)imageConv.ConvertFrom(picture);
            }
        }

        /// <summary>
        /// 自動車検査証記録事項
        /// </summary>
        /// <param name="picture"></param>
        private void PutSubPicture(byte[] picture) {
            if (picture.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxExSubPicture.Image = (Image)imageConv.ConvertFrom(picture);
            }
        }

        /// <summary>
        /// H_CarVerification_FormClosed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_CarVerification_FormClosed(object sender, FormClosedEventArgs e) {
            this.Dispose();
        }
    }
}
