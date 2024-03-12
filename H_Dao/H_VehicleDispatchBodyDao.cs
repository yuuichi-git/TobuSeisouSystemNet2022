/*
 * 2024-02-24
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

namespace H_Dao {
    public class H_VehicleDispatchBodyDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_VehicleDispatchBodyDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHVehicleDispatchBodyVo
        /// true:該当レコードあり false:該当レコードなし
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool ExistenceHVehicleDispatchBodyVo(int setCode, string dayOfWeek, int financialYear) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(SetCode) " +
                                     "FROM H_VehicleDispatchBody " +
                                     "WHERE SetCode = " + setCode + " AND DayOfWeek = '" + dayOfWeek + "' AND  FinancialYear = " + financialYear + "";
            try {
                return (int)sqlCommand.ExecuteScalar() != 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectOneHVehicleDispatchBody
        /// </summary>
        /// <param name="setCode"></param>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public H_VehicleDispatchBodyVo SelectOneHVehicleDispatchBody(int setCode, DateTime operationDate, int financialYear) {
            H_VehicleDispatchBodyVo hVehicleDispatchBodyVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT SetCode," +
                                            "DayOfWeek," +
                                            "CarCode," +
                                            "StaffCode1," +
                                            "StaffCode2," +
                                            "StaffCode3," +
                                            "StaffCode4," +
                                            "FinancialYear," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_VehicleDispatchBody " +
                                     "WHERE SetCode = " + setCode + " AND DayOfWeek = '" + operationDate.ToString("ddd") + "' AND FinancialYear = " + financialYear + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hVehicleDispatchBodyVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hVehicleDispatchBodyVo.DayOfWeek = _defaultValue.GetDefaultValue<string>(sqlDataReader["DayOfWeek"]);
                    hVehicleDispatchBodyVo.CarCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarCode"]);
                    hVehicleDispatchBodyVo.StaffCode1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode1"]);
                    hVehicleDispatchBodyVo.StaffCode2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode2"]);
                    hVehicleDispatchBodyVo.StaffCode3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode3"]);
                    hVehicleDispatchBodyVo.StaffCode4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode4"]);
                    hVehicleDispatchBodyVo.FinancialYear = _defaultValue.GetDefaultValue<int>(sqlDataReader["FinancialYear"]);
                    hVehicleDispatchBodyVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hVehicleDispatchBodyVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hVehicleDispatchBodyVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hVehicleDispatchBodyVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hVehicleDispatchBodyVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hVehicleDispatchBodyVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hVehicleDispatchBodyVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hVehicleDispatchBodyVo;

        }

        /// <summary>
        /// InsertOneHVehicleDispatchBodyVo
        /// </summary>
        /// <param name="hVehicleDispatchBodyVo"></param>
        public void InsertOneHVehicleDispatchBodyVo(H_VehicleDispatchBodyVo hVehicleDispatchBodyVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_VehicleDispatchBody(SetCode," +
                                                                       "DayOfWeek," +
                                                                       "CarCode," +
                                                                       "StaffCode1," +
                                                                       "StaffCode2," +
                                                                       "StaffCode3," +
                                                                       "StaffCode4," +
                                                                       "FinancialYear," +
                                                                       "InsertPcName," +
                                                                       "InsertYmdHms," +
                                                                       "UpdatePcName," +
                                                                       "UpdateYmdHms," +
                                                                       "DeletePcName," +
                                                                       "DeleteYmdHms," +
                                                                       "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.SetCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchBodyVo.DayOfWeek) + "'," +
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.CarCode) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode1) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode2) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode3) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode4) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.FinancialYear) + "," +
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
        /// UpdateOneHVehicleDispatchBodyVo
        /// </summary>
        /// <param name="hVehicleDispatchBodyVo"></param>
        public void UpdateOneHVehicleDispatchBodyVo(H_VehicleDispatchBodyVo hVehicleDispatchBodyVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchBody " +
                                     "SET SetCode = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.SetCode) + "," +
                                         "DayOfWeek = '" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchBodyVo.DayOfWeek) + "'," +
                                         "CarCode = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.CarCode) + "," +
                                         "StaffCode1 = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode1) + "," +
                                         "StaffCode2 = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode2) + "," +
                                         "StaffCode3 = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode3) + "," +
                                         "StaffCode4 = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.StaffCode4) + "," +
                                         "FinancialYear = " + _defaultValue.GetDefaultValue<int>(hVehicleDispatchBodyVo.FinancialYear) + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE SetCode = " + hVehicleDispatchBodyVo.SetCode + " AND DayOfWeek = '" + hVehicleDispatchBodyVo.DayOfWeek + "' AND FinancialYear = " + hVehicleDispatchBodyVo.FinancialYear + "";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
