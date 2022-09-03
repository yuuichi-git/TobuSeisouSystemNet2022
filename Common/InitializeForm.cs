/*
 * 2022/08/21
 */
namespace Common {
    public class InitializeForm {
        private const float TopWidthMaxSize = 66F;
        private const float TopWidthMinSize = 0F;
        private const float LeftWidthMaxSize = 360F;
        private const float LeftWidthMinSize = 0F;
        private const float RightWidthMaxSize = 360F;
        private const float RightWidthMinSize = 0F;

        /// <summary>
        /// StartProject
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form StartProject(Form form) {
            form.StartPosition = FormStartPosition.CenterScreen;
            return form;
        }

        /// <summary>
        /// VehicleDispatchBoad
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form VehicleDispatchBoad(Form form) {
            form.KeyPreview = true;
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// アプリケーションが開かれる画面のワークエリアを返す
        /// FHDでの最小サイズ(1920*1048)
        /// </summary>
        /// <param name="form"></param>
        public void GetWorkingArea(Form form) {
            form.Height = Screen.GetWorkingArea(form).Height;
            form.MinimumSize = new Size(1920, 1048);
            form.StartPosition = FormStartPosition.Manual;
            form.Text = string.Concat(form.Text, "　(", form.Width, "×", form.Height, ")");
            form.Width = Screen.GetWorkingArea(form).Width;
        }

        public void SetTableLayoutPanelAll(TableLayoutPanel tableLayoutPanel, bool flag) {
            SetTableLayoutPanelTop(tableLayoutPanel, flag);
            SetTableLayoutPanelLeft(tableLayoutPanel, flag);
            SetTableLayoutPanelRight(tableLayoutPanel, flag);
        }

        public void SetTableLayoutPanelTop(TableLayoutPanel tableLayoutPanel, bool flag) {
            tableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, flag ? TopWidthMaxSize : TopWidthMinSize);
        }

        public void SetTableLayoutPanelLeft(TableLayoutPanel tableLayoutPanel, bool flag) {
            tableLayoutPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, flag ? LeftWidthMaxSize : LeftWidthMinSize);
        }

        public void SetTableLayoutPanelRight(TableLayoutPanel tableLayoutPanel, bool flag) {
            tableLayoutPanel.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, flag ? RightWidthMaxSize : RightWidthMinSize);
        }
    }
}
