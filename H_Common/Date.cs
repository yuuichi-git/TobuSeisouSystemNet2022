/*
 * 2023-11-08
 */

namespace H_Common {
    public class Date {
        private readonly DateTime _todayDate = DateTime.Today;

        /// <summary>
        /// 年齢を計算
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetStaffAge(DateTime dateTime) {
            int age = _todayDate.Year - dateTime.Year;
            //誕生日がまだ来ていなければ、1引く
            if(_todayDate.Month < dateTime.Month || (_todayDate.Month == dateTime.Month && _todayDate.Day < dateTime.Day)) {
                age--;
            }
            return age;
        }
        /// <summary>
        /// 勤続年数を計算
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetEmploymenteYear(DateTime dateTime) {
            DateTime nowDate = DateTime.Now.Date;
            TimeSpan elapsedSpan = nowDate - dateTime;
            return (int)elapsedSpan.TotalDays / 365;
        }

        /// <summary>
        /// 勤続月数を計算
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetEmploymenteMonth(DateTime dateTime) {
            DateTime nowDate = DateTime.Now.Date;
            TimeSpan elapsedSpan = nowDate - dateTime;
            return (int)elapsedSpan.TotalDays % 365 / 30;
        }

        /// <summary>
        /// 勤続日数を計算
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetEmploymenteDay(DateTime dateTime) {
            DateTime nowDate = DateTime.Now.Date;
            TimeSpan elapsedSpan = nowDate - dateTime;
            return (int)elapsedSpan.TotalDays;
        }

        /// <summary>
        /// 瞬間の日時を取得する
        /// </summary>
        /// <returns></returns>
        public string GetDateTimeNow() {
            return DateTime.Now.ToString("yyyy年MM月dd日(ddd)　HH時mm分ss秒");
        }

        /// <summary>
        /// 月初日を返す
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime GetBeginOfMonth(DateTime dateTime) {
            return dateTime.AddDays((dateTime.Day - 1) * -1);
        }

        /// <summary>
        /// 月末日を返す
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime GetEndOfMonth(DateTime dateTime) {
            return new DateTime(dateTime.Year, dateTime.Month, GetDaysInMonth(dateTime));
        }

        /// <summary>
        /// 該当年月の日数を返す
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int GetDaysInMonth(DateTime dateTime) {
            return DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        }

        /// <summary>
        /// 会計年度を返す
        /// </summary>
        /// <returns></returns>
        public int GetFiscalYear() {
            return _todayDate.AddMonths(-3).Year;
        }

        /// <summary>
        /// 会計年度を返す
        /// </summary>
        /// <returns></returns>
        public int GetFiscalYear(DateTime dateTime) {
            return dateTime.AddMonths(-3).Year;
        }

        /// <summary>
        /// 会計年度の始めの日付を返す
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public DateTime GetFiscalYearStartDate(DateTime datetime) {
            int fiscalYear = datetime.AddMonths(-3).Year;
            return new DateTime(fiscalYear, 4, 1, 0, 00, 00, 000);
        }

        /// <summary>
        /// 会計年度の最後の日付を返す
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public DateTime GetFiscalYearEndDate(DateTime datetime) {
            int fiscalYear = datetime.AddMonths(-3).Year;
            return new DateTime(fiscalYear, 4, 1, 0, 00, 00, 000).AddDays(365);
        }
    }
}
