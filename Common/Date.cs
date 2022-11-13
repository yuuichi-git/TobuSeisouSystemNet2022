namespace Common {
    public class Date {
        private readonly DateTime _todayDate = DateTime.Now.Date;

        /// <summary>
        /// 年齢を計算
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetStaffAge(DateTime dateTime) {
            int age = _todayDate.Year - dateTime.Year;
            //誕生日がまだ来ていなければ、1引く
            if (_todayDate.Month < dateTime.Month || (_todayDate.Month == dateTime.Month && _todayDate.Day < dateTime.Day)) {
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
    }
}
