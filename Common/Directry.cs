﻿namespace Common {
    public class Directry {

        /// <summary>
        /// GetPdfDesktopPass
        /// デスクトップパスを取得する(PDF)
        /// </summary>
        /// <param name="stringName"></param>
        /// <returns></returns>
        public string GetPdfDesktopPass(string stringName) {
            var desktopDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var fileName = string.Concat(stringName);
            desktopDirectoryPath += string.Concat(@"\", fileName, ".pdf");
            return desktopDirectoryPath;
        }

        /// <summary>
        /// System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetExcelDesktopPassXls(string fileName) {
            string desktopDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktopDirectoryPath += string.Concat(@"\", fileName);
            return desktopDirectoryPath;
        }

        /// <summary>
        /// GetExcelDesktopPass
        /// デスクトップパスを取得する(Excel)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetExcelDesktopPassXlsx(string fileName) {
            var desktopDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktopDirectoryPath += string.Concat(@"\", fileName, ".xlsx");
            return desktopDirectoryPath;
        }
    }
}
