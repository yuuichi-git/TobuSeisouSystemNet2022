/*
 * 2024-05-28
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_Certification {
    public partial class H_CertificationDetail : Form {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        private int _staffCode;
        private int _certificationCode;
        /*
         * Dao 
         */
        private readonly H_CertificationFileDao _hCertificationFileDao;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        /// <param name="staffCode"></param>
        /// <param name="certificationCode"></param>
        public H_CertificationDetail(ConnectionVo connectionVo, int staffCode, int certificationCode) {
            _staffCode = staffCode;
            _certificationCode = certificationCode;
            /*
             * Dao
             */
            _hCertificationFileDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.OutSheetViewList(_hCertificationFileDao.SelectOneHCertificationFile(_staffCode, _certificationCode));
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            H_CertificationFileVo hCertificationFileVo = new();
            hCertificationFileVo.StaffCode = _staffCode;
            hCertificationFileVo.CertificationCode = _certificationCode;
            hCertificationFileVo.MarkCode = 0;
            hCertificationFileVo.Picture1 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx1.Image, typeof(byte[]));
            hCertificationFileVo.Picture2 = (byte[])new ImageConverter().ConvertTo(HPictureBoxEx2.Image, typeof(byte[]));
            hCertificationFileVo.InsertPcName = Environment.MachineName;
            hCertificationFileVo.InsertYmdHms = DateTime.Now;
            hCertificationFileVo.UpdatePcName = string.Empty;
            hCertificationFileVo.UpdateYmdHms = _defaultDateTime;
            hCertificationFileVo.DeletePcName = string.Empty;
            hCertificationFileVo.DeleteYmdHms = _defaultDateTime;
            hCertificationFileVo.DeleteFlag = false;
            /*
             * DBを更新
             * 存在すればUPDATE、存在しなければINSERT
             */
            if (_hCertificationFileDao.ExistenceHCertificationFile(_staffCode, _certificationCode)) {
                try {
                    _hCertificationFileDao.UpdateOneHLicenseLedger(hCertificationFileVo);
                    this.Close();
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            } else {
                try {
                    _hCertificationFileDao.InsertOneHCertificationFile(hCertificationFileVo);
                    this.Close();
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// OutSheetViewList
        /// </summary>
        private void OutSheetViewList(H_CertificationFileVo hCertificationFileVo) {
            if (hCertificationFileVo.Picture1.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxEx1.Image = (Image)imageConv.ConvertFrom(hCertificationFileVo.Picture1); //写真１
            }
            if (hCertificationFileVo.Picture2.Length > 0) {
                ImageConverter imageConv = new();
                HPictureBoxEx2.Image = (Image)imageConv.ConvertFrom(hCertificationFileVo.Picture2); //写真２
            }
        }

        /// <summary>
        /// ToolStripMenuItemがクリックされた時のSourceControlを保持
        /// </summary>
        Control _sourceControl = null;
        /// <summary>
        /// ContextMenuStrip1_Opened
        /// コンテキストが開かれた親コントロールを取得する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opened(object sender, EventArgs e) {
            //ContextMenuStripを表示しているコントロールを取得する
            _sourceControl = ((ContextMenuStrip)sender).SourceControl;
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                /*
                 * Picture クリップボード
                 */
                case "ToolStripMenuItemClip":
                    ((H_PictureBoxEx)_sourceControl).Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    break;
                /*
                 * Picture 削除
                 */
                case "ToolStripMenuItemDelete":
                    ((H_PictureBoxEx)_sourceControl).Image = null;
                    break;
                /*
                 * アプリケーションを終了する
                 */
                case "ToolStripMenuItemExit":
                    this.Close();
                    break;
            }
        }
    }
}
