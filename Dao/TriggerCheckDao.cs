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
            DateTime? _dateTime;
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
            if(_dateTime.HasValue) {
                // _dateTime > lastUpdateDateTimeの場合、誰かが更新しているって事だから更新あり(True)を返す
                return _dateTime > lastUpdateDateTime ? true : false;
            } else {
                // _dateTimeがNullの場合、レコードが存在していないって事だから更新なし(False)を返す
                return false;
            }
        }

        /// <summary>
        /// 最終更新日時を調べる
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public DateTime? GetLastUpdate(DateTime operationDate) {
            // SQLの結果を保持
            DateTime? _dateTime;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT update_record_ymd_hms " +
                                     "FROM trigger_check " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                /*
                 * _dateTimeがNullの可能性は無い。
                 */
                _dateTime = (DateTime?)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return _dateTime;
        }
    }
}
