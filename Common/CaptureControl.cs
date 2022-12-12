namespace Common {
    public class CaptureControl {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest,
                                          int nXDest,
                                          int nYDest,
                                          int nWidth,
                                          int nHeight,
                                          IntPtr hdcSrc,
                                          int nXSrc,
                                          int nYSrc,
                                          int dwRop);
        private const int SRCCOPY = 0xCC0020;

        public CaptureControl() {

        }

        /// <summary>
        /// コントロールのイメージを取得する
        /// </summary>
        /// <param name="control">キャプチャするコントロール</param>
        /// <returns>取得できたイメージ</returns>
        public Bitmap GetCapture(Control control) {
            Graphics graphics = control.CreateGraphics();
            Bitmap bitmap = new Bitmap(control.ClientRectangle.Width,control.ClientRectangle.Height, graphics);
            Graphics memg = Graphics.FromImage(bitmap);
            IntPtr dc1 = graphics.GetHdc();
            IntPtr dc2 = memg.GetHdc();
            BitBlt(dc2, 0, 0, bitmap.Width, bitmap.Height, dc1, 0, 0, SRCCOPY);
            graphics.ReleaseHdc(dc1);
            memg.ReleaseHdc(dc2);
            memg.Dispose();
            graphics.Dispose();
            return bitmap;
        }
    }
}
