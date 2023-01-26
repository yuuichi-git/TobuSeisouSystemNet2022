using Common;

using Dao;

using Vo;

namespace Toukanpo {
    public partial class ToukanpoTrainingCard : Form {
        private readonly ConnectionVo _connectionVo;

        public ToukanpoTrainingCard(ConnectionVo connectionVo, int staffCode) {
            _connectionVo = connectionVo;
            InitializeComponent();

            ToukanpoTrainingCardVo toukanpoTrainingCardVo = new();
            try {
                // データを取得
                toukanpoTrainingCardVo = new ToukanpoTrainingCardDao(_connectionVo).SelectOneToukanpoTrainingCard(staffCode);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
            // 写真
            if(toukanpoTrainingCardVo is not null && toukanpoTrainingCardVo.Picture.Length != 0)
                PictureBox1.Image = (Image?)new ImageConverter().ConvertFrom(toukanpoTrainingCardVo.Picture);
        }
    }
}