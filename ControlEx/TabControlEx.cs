namespace ControlEx {
    public partial class TabControlEx : TabControl {
        public TabControlEx() {
            InitializeComponent();
            this.DrawItem += new DrawItemEventHandler(TabControlEx_DrawItem);
        }

        private void TabControlEx_DrawItem(object? sender, DrawItemEventArgs e) {
        }
    }
}
