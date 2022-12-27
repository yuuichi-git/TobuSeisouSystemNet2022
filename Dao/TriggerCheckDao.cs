using Vo;

namespace Dao {
    public class TriggerCheckDao {
        private readonly ConnectionVo _connectionVo;

        public TriggerCheckDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// CheckUpdateRecordYmdHms
        /// true:更新あり false:更新なし
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="lastUpdateDateTime"></param>
        /// <returns></returns>
        public bool CheckUpdateRecordYmdHms(DateTime operationDate, DateTime lastUpdateDateTime) {
            // SQLの結果を保持
            DateTime _dateTime;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT update_record_ymd_hms " +
                                     "FROM trigger_check " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                /*
                 * _dateTimeがNullの可能性は無い。
                 */
                _dateTime = (DateTime)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return _dateTime > lastUpdateDateTime ? true : false;
        }
    }
}
