namespace TobuSeisouSystemNet2022 {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //�~���[�e�b�N�X�쐬
            Mutex app_mutex = new Mutex(false, "StartProject");

            //�~���[�e�b�N�X�̏��L����v������
            if (app_mutex.WaitOne(0, false) == false) {
                MessageBox.Show("���̃A�v���P�[�V�����͕����N���ł��܂���");
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StartProject());
        }
    }
}