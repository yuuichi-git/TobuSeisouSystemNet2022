/*
 * 2024-02-19
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

namespace H_Dao {

    public class H_LastRollCallDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_LastRollCallDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHLastRollCallVo
        /// true:該当レコードあり false:該当レコードなし
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool ExistenceHLastRollCallVo(int setCode, DateTime dateTime) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(SetCode) " +
                                     "FROM H_LastRollCall " +
                                     "WHERE SetCode = " + setCode + " AND OperationDate = '" + dateTime.ToString("yyyy-MM-dd") + "'";
            try {
                return (int)sqlCommand.ExecuteScalar() != 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectOneHLastRollCallVo
        /// </summary>
        /// <param name="dateTime">帰庫点呼日</param>
        /// <returns></returns>
        public H_LastRollCallVo SelectOneHLastRollCallVo(int setCode, DateTime dateTime) {
            H_LastRollCallVo hLastRollCallVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT SetCode," +
                                            "OperationDate," +
                                            "FirstRollCallHms," +
                                            "LastPlantCount," +
                                            "LastPlantName," +
                                            "LastPlantHms," +
                                            "LastRollCallHms," +
                                            "FirstOdoMeter," +
                                            "LastOdoMeter," +
                                            "OilAmount," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_LastRollCall " +
                                     "WHERE SetCode = " + setCode + " AND OperationDate = '" + dateTime.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hLastRollCallVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hLastRollCallVo.OperationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OperationDate"]);
                    hLastRollCallVo.FirstRollCallHms = _defaultValue.GetDefaultValue<string>(sqlDataReader["FirstRollCallHms"]);
                    hLastRollCallVo.LastPlantCount = _defaultValue.GetDefaultValue<int>(sqlDataReader["LastPlantCount"]);
                    hLastRollCallVo.LastPlantName = _defaultValue.GetDefaultValue<string>(sqlDataReader["LastPlantName"]);
                    hLastRollCallVo.LastPlantHms = _defaultValue.GetDefaultValue<string>(sqlDataReader["LastPlantHms"]);
                    hLastRollCallVo.LastRollCallHms = _defaultValue.GetDefaultValue<string>(sqlDataReader["LastRollCallHms"]);
                    hLastRollCallVo.FirstOdoMeter = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["FirstOdoMeter"]);
                    hLastRollCallVo.LastOdoMeter = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["LastOdoMeter"]);
                    hLastRollCallVo.OilAmount = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["OilAmount"]);
                    hLastRollCallVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hLastRollCallVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hLastRollCallVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hLastRollCallVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hLastRollCallVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hLastRollCallVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hLastRollCallVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hLastRollCallVo;
        }

        /// <summary>
        /// InsertOneHLastRollCallVo
        /// </summary>
        /// <param name="hLastRollCallVo"></param>
        public void InsertOneHLastRollCallVo(H_LastRollCallVo hLastRollCallVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_LastRollCall(SetCode," +
                                                                "OperationDate," +
                                                                "FirstRollCallHms," +
                                                                "LastPlantCount," +
                                                                "LastPlantName," +
                                                                "LastPlantHms," +
                                                                "LastRollCallHms," +
                                                                "FirstOdoMeter," +
                                                                "LastOdoMeter," +
                                                                "OilAmount," +
                                                                "InsertPcName," +
                                                                "InsertYmdHms," +
                                                                "UpdatePcName," +
                                                                "UpdateYmdHms," +
                                                                "DeletePcName," +
                                                                "DeleteYmdHms," +
                                                                "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.SetCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.OperationDate) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.FirstRollCallHms) + "'," +
                                             "" + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.LastPlantCount) + "," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastRollCallHms) + "'," +
                                             "" + _defaultValue.GetDefaultValue<decimal>(hLastRollCallVo.FirstOdoMeter) + "," +
                                             "" + _defaultValue.GetDefaultValue<decimal>(hLastRollCallVo.LastOdoMeter) + "," +
                                             "" + _defaultValue.GetDefaultValue<decimal>(hLastRollCallVo.OilAmount) + "," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                          "''," +
                                            "'" + _defaultDateTime + "'," +
                                          "''," +
                                            "'" + _defaultDateTime + "'," +
                                            "'False'" +
                                            ");";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHLastRollCallVo
        /// </summary>
        /// <param name="hLastRollCallVo"></param>
        public void UpdateOneHLastRollCallVo(H_LastRollCallVo hLastRollCallVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_LastRollCall " +
                                     "SET SetCode = " + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.SetCode) + "," +
                                         "OperationDate = '" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.OperationDate) + "'," +
                                         "FirstRollCallHms = '" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.FirstRollCallHms) + "'," +
                                         "LastPlantCount = " + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.LastPlantCount) + "," +
                                         "LastPlantName = '" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantName) + "'," +
                                         "LastPlantHms = '" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantHms) + "'," +
                                         "LastRollCallHms = '" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastRollCallHms) + "'," +
                                         "FirstOdoMeter = " + _defaultValue.GetDefaultValue<decimal>(hLastRollCallVo.FirstOdoMeter) + "," +
                                         "LastOdoMeter = " + _defaultValue.GetDefaultValue<decimal>(hLastRollCallVo.LastOdoMeter) + "," +
                                         "OilAmount = " + _defaultValue.GetDefaultValue<decimal>(hLastRollCallVo.OilAmount) + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE SetCode = " + hLastRollCallVo.SetCode + " AND OperationDate = '" + hLastRollCallVo.OperationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
