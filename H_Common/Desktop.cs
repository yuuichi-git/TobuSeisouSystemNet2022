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
        /// formで指定したFormをscreenで指定したモニターに表示する
        /// </summary>
        /// <param name="form"></param>
        /// <param name="screen"></param>
        public void SetMonitor(Form form, Screen screen) {
            //フォームの開始位置をディスプレイの左上座標に設定する
            form.StartPosition = FormStartPosition.Manual;
            form.Location = screen.Bounds.Location;
        }
    }
}
