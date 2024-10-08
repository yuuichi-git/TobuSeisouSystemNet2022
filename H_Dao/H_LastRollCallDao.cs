﻿/*
 * 2024-02-19
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {

    public class H_LastRollCallDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        private readonly Date _date = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_LastRollCallDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// 2024-06-12
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>true:該当レコードあり false:該当レコードなし</returns>
        public bool ExistenceHLastRollCall(H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(LastRollCallYmdHms) " +
                                     "FROM H_LastRollCall " +
                                     "WHERE LastRollCallYmdHms = '" + hVehicleDispatchDetailVo.LastRollCallYmdHms.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            try {
                return (int)sqlCommand.ExecuteScalar() != 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectOneHLastRollCall
        /// </summary>
        /// <param name="hVehicleDispatchDetailVo"></param>
        /// <returns>H_LastRollCallVo</returns>
        public H_LastRollCallVo SelectOneHLastRollCall(H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            H_LastRollCallVo hLastRollCallVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT H_LastRollCall.SetCode," +
                                            "H_LastRollCall.OperationDate," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms1," +
                                            "H_LastRollCall.LastPlantCount," +
                                            "H_LastRollCall.LastPlantName," +
                                            "H_LastRollCall.LastPlantYmdHms," +
                                            "H_LastRollCall.LastRollCallYmdHms," +
                                            "H_LastRollCall.FirstOdoMeter," +
                                            "H_LastRollCall.LastOdoMeter," +
                                            "H_LastRollCall.OilAmount " +
                                     "FROM H_LastRollCall " +
                                     "LEFT OUTER JOIN H_VehicleDispatchDetail ON H_LastRollCall.OperationDate = H_VehicleDispatchDetail.OperationDate " +
                                                                            "AND H_LastRollCall.SetCode = H_VehicleDispatchDetail.SetCode " +
                                     "WHERE H_LastRollCall.LastRollCallYmdHms = '" + hVehicleDispatchDetailVo.LastRollCallYmdHms.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    //hLastRollCallVo = new();
                    hLastRollCallVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hLastRollCallVo.OperationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OperationDate"]);
                    hLastRollCallVo.FirstRollCallYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms1"]);
                    hLastRollCallVo.LastPlantCount = _defaultValue.GetDefaultValue<int>(sqlDataReader["LastPlantCount"]);
                    hLastRollCallVo.LastPlantName = _defaultValue.GetDefaultValue<string>(sqlDataReader["LastPlantName"]);
                    hLastRollCallVo.LastPlantYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["LastPlantYmdHms"]);
                    hLastRollCallVo.LastRollCallYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["LastRollCallYmdHms"]);
                    hLastRollCallVo.FirstOdoMeter = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["FirstOdoMeter"]);
                    hLastRollCallVo.LastOdoMeter = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["LastOdoMeter"]);
                    hLastRollCallVo.OilAmount = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["OilAmount"]);
                }
            }
            return hLastRollCallVo;
        }

        /// <summary>
        /// InsertOneHLastRollCall
        /// </summary>
        /// <param name="hLastRollCallVo"></param>
        public void InsertOneHLastRollCall(H_LastRollCallVo hLastRollCallVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_LastRollCall(SetCode," +
                                                                "OperationDate," +
                                                                "FirstRollCallYmdHms," +
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
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.SetCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.OperationDate) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.FirstRollCallYmdHms) + "'," +
                                             "" + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.LastPlantCount) + "," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.LastPlantYmdHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.LastRollCallYmdHms) + "'," +
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
        /// UpdateOneHLastRollCall
        /// </summary>
        /// <param name="hLastRollCallVo"></param>
        public void UpdateOneHLastRollCall(H_LastRollCallVo hLastRollCallVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_LastRollCall " +
                                     "SET SetCode = " + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.SetCode) + "," +
                                         "OperationDate = '" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.OperationDate) + "'," +
                                         "FirstRollCallYmdHms = '" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.FirstRollCallYmdHms) + "'," +
                                         "LastPlantCount = " + _defaultValue.GetDefaultValue<int>(hLastRollCallVo.LastPlantCount) + "," +
                                         "LastPlantName = '" + _defaultValue.GetDefaultValue<string>(hLastRollCallVo.LastPlantName) + "'," +
                                         "LastPlantYmdHms = '" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.LastPlantYmdHms) + "'," +
                                         "LastRollCallYmdHms = '" + _defaultValue.GetDefaultValue<DateTime>(hLastRollCallVo.LastRollCallYmdHms) + "'," +
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
