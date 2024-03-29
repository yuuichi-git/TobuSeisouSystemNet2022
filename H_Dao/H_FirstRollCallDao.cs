/*
 * 2024-02-20
 */
using System.Data.SqlClient;

using H_Common;

using Vo;

namespace H_Dao {
    public class H_FirstRollCallDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_FirstRollCallDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHFirstRollCallVo
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>true:該当レコードあり false:該当レコードなし</returns>
        public bool ExistenceHFirstRollCallVo(DateTime dateTime) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(OperationDate) " +
                                     "FROM H_FirstRollCall " +
                                     "WHERE OperationDate = '" + dateTime.ToString("yyyy-MM-dd") + "'";
            try {
                return (int)sqlCommand.ExecuteScalar() != 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectOneHFirstRollCallVo
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>存在する:H_FirstRollCallVo 存在しない:NULL</returns>
        public H_FirstRollCallVo SelectOneHFirstRollCallVo(DateTime dateTime) {
            H_FirstRollCallVo hFirstRollCallVo = null;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT OperationDate," +
                                            "RollCallName1," +
                                            "RollCallName2," +
                                            "RollCallName3," +
                                            "RollCallName4," +
                                            "RollCallName5," +
                                            "Weather," +
                                            "Instruction1," +
                                            "Instruction2," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_FirstRollCall " +
                                     "WHERE OperationDate = '" + dateTime.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hFirstRollCallVo = new();
                    hFirstRollCallVo.OperationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OperationDate"]);
                    hFirstRollCallVo.RollCallName1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RollCallName1"]);
                    hFirstRollCallVo.RollCallName2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RollCallName2"]);
                    hFirstRollCallVo.RollCallName3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RollCallName3"]);
                    hFirstRollCallVo.RollCallName4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RollCallName4"]);
                    hFirstRollCallVo.RollCallName5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RollCallName5"]);
                    hFirstRollCallVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["Weather"]);
                    hFirstRollCallVo.Instruction1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["Instruction1"]);
                    hFirstRollCallVo.Instruction2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["Instruction2"]);
                    hFirstRollCallVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hFirstRollCallVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hFirstRollCallVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hFirstRollCallVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hFirstRollCallVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hFirstRollCallVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hFirstRollCallVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hFirstRollCallVo;
        }

        /// <summary>
        /// InsertOneHFirstRollCallVo
        /// </summary>
        /// <param name="hFirstRollCallVo"></param>
        public void InsertOneHFirstRollCallVo(H_FirstRollCallVo hFirstRollCallVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_FirstRollCall(OperationDate," +
                                                                 "RollCallName1," +
                                                                 "RollCallName2," +
                                                                 "RollCallName3," +
                                                                 "RollCallName4," +
                                                                 "RollCallName5," +
                                                                 "Weather," +
                                                                 "Instruction1," +
                                                                 "Instruction2," +
                                                                 "InsertPcName," +
                                                                 "InsertYmdHms," +
                                                                 "UpdatePcName," +
                                                                 "UpdateYmdHms," +
                                                                 "DeletePcName," +
                                                                 "DeleteYmdHms," +
                                                                 "DeleteFlag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<DateTime>(hFirstRollCallVo.OperationDate) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName1) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName2) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName3) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName4) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName5) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.Weather) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.Instruction1) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.Instruction2) + "'," +
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
        /// UpdateOneHFirstRollCallVo
        /// </summary>
        /// <param name="hFirstRollCallVo"></param>
        public void UpdateOneHFirstRollCallVo(H_FirstRollCallVo hFirstRollCallVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_FirstRollCall " +
                                     "SET OperationDate = '" + _defaultValue.GetDefaultValue<DateTime>(hFirstRollCallVo.OperationDate) + "'," +
                                         "RollCallName1 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName1) + "'," +
                                         "RollCallName2 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName2) + "'," +
                                         "RollCallName3 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName3) + "'," +
                                         "RollCallName4 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName4) + "'," +
                                         "RollCallName5 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.RollCallName5) + "'," +
                                         "Weather = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.Weather) + "'," +
                                         "Instruction1 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.Instruction1) + "'," +
                                         "Instruction2 = '" + _defaultValue.GetDefaultValue<string>(hFirstRollCallVo.Instruction2) + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE OperationDate = '" + hFirstRollCallVo.OperationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
