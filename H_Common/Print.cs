/*
 * 2024-08-03
 */
namespace H_Common {
    public class Print {

        /// <summary>
        /// コンストラクター
        /// </summary>
        public Print() {
        }

        /// <summary>
        /// インストールされている全てのプリンターを返す
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllPrinterName() {
            List<string> listPrinterName = new();
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                listPrinterName.Add(printerName);
            return listPrinterName;
        }
    }
}
