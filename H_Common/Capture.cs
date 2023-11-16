/*
 * 2023-11-15
 */
namespace H_Common {
    public class Capture {

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private extern static bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        /// <summary>
        /// コントロールのイメージを取得する
        /// </summary>
        /// <param name="ctrl">キャプチャするコントロール</param>
        /// <returns>取得できたイメージ</returns>
        public Bitmap CaptureControl(Control ctrl) {
            Bitmap bitmap = new(ctrl.Width, ctrl.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            IntPtr intPtr = graphics.GetHdc();
            PrintWindow(ctrl.Handle, intPtr, 0);
            graphics.ReleaseHdc(intPtr);
            graphics.Dispose();
            return bitmap;
        }
    }
}
