namespace CommuterInsurance {
    public partial class CommuterInsurancePicture : Form {
        public CommuterInsurancePicture(Image image) {
            InitializeComponent();
            Output(image);
        }

        public void Output(Image image) {
            PictureBox1.Image = image;
        }
    }
}
