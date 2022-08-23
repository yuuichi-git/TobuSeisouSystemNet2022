/*
 * 2022/08/21
 */
namespace Common {
    public class InitializeForm {
        public Form StartProject(Form form) {
            form.StartPosition = FormStartPosition.CenterScreen;
            return form;
        }
        /*
         * アプリケーションが開かれる画面のワークエリアを返す
         * FHDでの最小サイズ(1920*1048)
         */
        public void GetWorkingArea(Form form) {
            form.Height = Screen.GetWorkingArea(form).Height;
            form.MinimumSize = new Size(1920,1048);
            form.StartPosition = FormStartPosition.Manual;
            form.Text = string.Concat(form.Text, "　(", form.Width, "×", form.Height, ")");
            form.Width = Screen.GetWorkingArea(form).Width;
        }
    }
}
