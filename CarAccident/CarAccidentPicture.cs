namespace CarAccident {
    public partial class CarAccidentPicture : Form {

        public CarAccidentPicture(Image image) {
            InitializeComponent();
            Output(image);
        }

        public void Output(Image image) {
            PictureBox1.Image = image;
        }
    }
}
