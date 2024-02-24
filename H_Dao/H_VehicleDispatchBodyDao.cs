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
        public bool ExistenceHVehicleDispatchBodyVo(int setCode, string dayOfWeek) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(SetCode) " +
                                     "FROM H_VehicleDispatchBody " +
                                     "WHERE SetCode = " + setCode + " AND DayOfWeek = '" + dayOfWeek + "'";
            try {
                return (int)sqlCommand.ExecuteScalar() != 0 ? true : false;
            } catch {
                throw;
            }
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
                                     "WHERE SetCode = " + hVehicleDispatchBodyVo.SetCode + " AND DayOfWeek = '" + hVehicleDispatchBodyVo.DayOfWeek + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
