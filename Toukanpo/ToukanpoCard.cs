using Common;

using Dao;

using Vo;

namespace Toukanpo {
    public partial class ToukanpoCard : Form {
        private readonly ConnectionVo _connectionVo;

        public ToukanpoCard(ConnectionVo connectionVo, int staffCode) {
            _connectionVo = connectionVo;
            InitializeComponent();

            ToukanpoVo toukanpoTrainingCardVo = new();
            try {
                // データを取得
                toukanpoTrainingCardVo = new ToukanpoDao(_connectionVo).SelectOneToukanpoTrainingCard(staffCode);
            } catch(Exception exception) {
                MessageBox.Show(exception.Message, MessageText.Message101, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
            // 写真
            if(toukanpoTrainingCardVo is not null && toukanpoTrainingCardVo.Picture.Length != 0)
                PictureBox1.Image = (Image?)new ImageConverter().ConvertFrom(toukanpoTrainingCardVo.Picture);
        }
    }
}