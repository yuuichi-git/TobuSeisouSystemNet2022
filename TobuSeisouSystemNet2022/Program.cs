namespace TobuSeisouSystemNet2022 {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //ミューテックス作成
            Mutex app_mutex = new Mutex(false, "StartProject");

            //ミューテックスの所有権を要求する
            if (app_mutex.WaitOne(0, false) == false) {
                MessageBox.Show("このアプリケーションは複数起動できません");
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StartProject());
        }
    }
}