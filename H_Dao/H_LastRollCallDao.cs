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
        /// SelectOneHLastRollCallVo
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public H_LastRollCallVo SelectOneHLastRollCallVo(DateTime dateTime) {
            H_LastRollCallVo hLastRollCallVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT OperationDate," +
                                            "LastPlantCount," +
                                            "LastPlantName," +
                                            "LastPlantYmdHms," +
                                            "LastRollCallYmdHms," +
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
                                     "FROM H_StaffCarViolateMaster " +
                                     "WHERE OperationDate = '" + dateTime.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hLastRollCallVo.OperationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OperationDate"]);
                    hLastRollCallVo.LastPlantCount = _defaultValue.GetDefaultValue<int>(sqlDataReader["LastPlantCount"]);
                    hLastRollCallVo.LastPlantName = _defaultValue.GetDefaultValue<string>(sqlDataReader["LastPlantName"]);
                    hLastRollCallVo.LastPlantYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["LastPlantYmdHms"]);
                    hLastRollCallVo.LastRollCallYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["LastRollCallYmdHms"]);
                    hLastRollCallVo.FirstOdoMeter = _defaultValue.GetDefaultValue<double>(sqlDataReader["FirstOdoMeter"]);
                    hLastRollCallVo.LastOdoMeter = _defaultValue.GetDefaultValue<double>(sqlDataReader["LastOdoMeter"]);
                    hLastRollCallVo.OilAmount = _defaultValue.GetDefaultValue<double>(sqlDataReader["OilAmount"]);
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
            sqlCommand.CommandText = "INSERT INTO H_StaffCarViolateMaster(OperationDate," +
                                                                         "LastPlantCount," +
                                                                         "LastPlantName," +
                                                                         "LastPlantYmdHms," +
                                                                         "LastRollCallYmdHms," +
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
                                     "VALUES (" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.OperationDate) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.LastPlantCount) + "," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.LastPlantYmdHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.LastRollCallYmdHms) + "'," +
                                             "" + _defaultValue.GetDefaultValue<double>(hLastRollCallVo.FirstOdoMeter) + "," +
                                             "" + _defaultValue.GetDefaultValue<double>(hLastRollCallVo.LastOdoMeter) + "," +
                                             "" + _defaultValue.GetDefaultValue<double>(hLastRollCallVo.OilAmount) + "'" +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + "" + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + "" + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'False'" +
                                            ");";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
