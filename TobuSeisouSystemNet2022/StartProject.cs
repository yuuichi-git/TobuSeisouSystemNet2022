using Common;

namespace TobuSeisouSystemNet2022 {
    public partial class StartProject : Form {
        public StartProject() {
            InitializeComponent();
            new InitializeForm().StartProject(this);
        }

    }
}