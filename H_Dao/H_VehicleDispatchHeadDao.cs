/*
 * 2023-11-08
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

namespace H_Dao {
    public class H_VehicleDispatchHeadDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_VehicleDispatchHeadDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectAllHVehicleDispatchHeadVo
        /// 対象年度のレコードを抽出する
        /// </summary>
        /// <param name="financialYear"></param>
        /// <returns></returns>
        public List<H_VehicleDispatchHeadVo> SelectAllHVehicleDispatchHeadVo(int financialYear) {
            List<H_VehicleDispatchHeadVo> listHVehicleDispatchHeadVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT CellNumber," +
                                            "VehicleDispatchFlag," +
                                            "Purpose," +
                                            "SetCode," +
                                            "FinancialYear," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_VehicleDispatchHead " +
                                     "WHERE FinancialYear = " + financialYear + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_VehicleDispatchHeadVo hVehicleDispatchHeadVo = new();
                    hVehicleDispatchHeadVo.CellNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["CellNumber"]);
                    hVehicleDispatchHeadVo.VehicleDispatchFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["VehicleDispatchFlag"]);
                    hVehicleDispatchHeadVo.Purpose = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Purpose"]);
                    hVehicleDispatchHeadVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hVehicleDispatchHeadVo.FinancialYear = _defaultValue.GetDefaultValue<int>(sqlDataReader["FinancialYear"]);
                    hVehicleDispatchHeadVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hVehicleDispatchHeadVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hVehicleDispatchHeadVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hVehicleDispatchHeadVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hVehicleDispatchHeadVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hVehicleDispatchHeadVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hVehicleDispatchHeadVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHVehicleDispatchHeadVo.Add(hVehicleDispatchHeadVo);
                }
            }
            return listHVehicleDispatchHeadVo;
        }
    }
}
