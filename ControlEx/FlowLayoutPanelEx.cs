using System.ComponentModel;

namespace ControlEx {
    public partial class FlowLayoutPanelEx : FlowLayoutPanel {
        private Color _borderColor = Color.Black;

        public FlowLayoutPanelEx() {
            InitializeComponent();
        }

        public FlowLayoutPanelEx(IContainer container) {
            InitializeComponent();
        }
    }
}
