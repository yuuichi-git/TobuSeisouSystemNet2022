using System.Data.SqlClient;

using H_Vo;

namespace Dao {
    public class ToukanpoSpeedSurveyDao {
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public ToukanpoSpeedSurveyDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// GetEmploymentCount
        /// 雇上の件数を取得
        /// 2023-05-06 fare_code = 21を追加。雇上大Gのclassification_codeが20(清掃工場)のため、運賃コードでSelectする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public int GetEmploymentCount(DateTime operationDate) {
            int count = 0;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(vehicle_dispatch_detail.operation_flag) " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN set_master ON vehicle_dispatch_detail.set_code = set_master.set_code " +
                                     "WHERE operation_date = '" + operationDate + "' " + // 配車日
                                       "AND vehicle_dispatch_detail.operation_flag = 'true' " + // 稼働フラグ
                                       "AND (set_master.classification_code IN (10,12) " + // 雇上・臨時 ※基本臨時は雇上
                                       "OR set_master.fare_code = 21)"; // 運賃コード
            if(sqlCommand.ExecuteScalar() != null)
                count = (int)sqlCommand.ExecuteScalar();
            return count;
        }

        /// <summary>
        /// GetWardCount
        /// 区契の件数を取得
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public int GetWardCount(DateTime operationDate) {
            int count = 0;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(vehicle_dispatch_detail.operation_flag) " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN set_master ON vehicle_dispatch_detail.set_code = set_master.set_code " +
                                     "WHERE operation_date = '" + operationDate + "' " + // 配車日
                                       "AND vehicle_dispatch_detail.operation_flag = 'true' " + // 稼働フラグ
                                       "AND set_master.classification_code = 11"; // 区契約
            if(sqlCommand.ExecuteScalar() != null)
                count = (int)sqlCommand.ExecuteScalar();
            return count;
        }
    }
}
