namespace H_Common {
    public class Desktop {

        /// <summary>
        /// WorkingAreaを取得する
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Rectangle GetWorkingArea(Form form) {
            return Screen.GetWorkingArea(form);
        }

        /// <summary>
        /// モニターを選択する + WorkingAreaを取得する
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Rectangle GetMonitorWorkingArea(Form form, Screen screen) {
            //フォームの開始位置をディスプレイの左上座標に設定する
            form.StartPosition = FormStartPosition.Manual;
            form.Location = screen.Bounds.Location;
            return Screen.GetWorkingArea(form);
        }

        /// <summary>
        /// formをscreenで指定したモニターに表示する
        /// </summary>
        /// <param name="form"></param>
        /// <param name="screen"></param>
        public void SetPosition(Form form, Screen screen) {
            /*
             * マルチ画面等で対象の画面サイズがFHD以下でFormのサイズがFHDであれば、WindowsStateをMaximizedにする
             */
            if (screen.WorkingArea.Width <= 1920 && screen.WorkingArea.Height <= 1080 && form.Size.Width == 1920 && form.Size.Height == 1080) {
                form.WindowState = FormWindowState.Maximized;
            } else {
                form.Left = (screen.WorkingArea.Width - form.Width) / 2 + screen.WorkingArea.X;
                form.Top = (screen.WorkingArea.Height - form.Height) / 2 + screen.WorkingArea.Y;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.WindowState = FormWindowState.Normal;
            }
        }
    }
}
