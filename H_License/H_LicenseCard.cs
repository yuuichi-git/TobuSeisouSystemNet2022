/*
 * 2024-06-18
 */
using H_Dao;

using Vo;

namespace H_License {
    public partial class H_LicenseCard : Form {
        /*
         * Dao
         */
        private readonly H_LicenseMasterDao _hLicenseMasterDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_LicenseCard(ConnectionVo connectionVo, int staffCode) {
            /*
             * Dao
             */
            _hLicenseMasterDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.PutPictureHead(_hLicenseMasterDao.SelectOnePictureHead(staffCode));
            this.PutPictureTail(_hLicenseMasterDao.SelectOnePictureTail(staffCode));
        }

        /// <summary>
        /// PutPictureHead
        /// </summary>
        /// <param name="pictureHead"></param>
        private void PutPictureHead(byte[] pictureHead) {
            if (pictureHead.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxExHead.Image = (Image)imageConv.ConvertFrom(pictureHead); //写真表
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pictureTail"></param>
        private void PutPictureTail(byte[] pictureTail) {
            if (pictureTail.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxExTail.Image = (Image)imageConv.ConvertFrom(pictureTail); //写真裏
            }
        }

        /// <summary>
        /// H_LicenseCard_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_LicenseCard_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }
    }
}
