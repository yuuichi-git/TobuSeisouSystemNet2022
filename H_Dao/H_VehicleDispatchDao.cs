/*
 * 2023-11-11
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

namespace H_Dao {
    public class H_VehicleDispatchDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_VehicleDispatchDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectHVehicleDispatchVo
        /// </summary>
        /// <param name="financialYear"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="setCode"></param>
        /// <returns></returns>
        public List<H_VehicleDispatchVo> SelectHVehicleDispatchVo(int financialYear, string dayOfWeek) {
            List<H_VehicleDispatchVo> listHVehicleDispatchVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT H_VehicleDispatchHead.CellNumber," +
                                            "H_VehicleDispatchHead.SetCode," +
                                            "H_VehicleDispatchBody.CarCode," +
                                            "H_VehicleDispatchBody.StaffCode1," +
                                            "H_VehicleDispatchBody.StaffCode2," +
                                            "H_VehicleDispatchBody.StaffCode3," +
                                            "H_VehicleDispatchBody.StaffCode4 " +
                                     "FROM H_VehicleDispatchHead " +
                                     "LEFT OUTER JOIN H_VehicleDispatchBody ON H_VehicleDispatchHead.SetCode = H_VehicleDispatchBody.SetCode " +
                                                                          "AND H_VehicleDispatchHead.FinancialYear = H_VehicleDispatchBody.FinancialYear " +
                                     "WHERE H_VehicleDispatchHead.FinancialYear = " + financialYear + " " +
                                       "AND H_VehicleDispatchBody.DayOfWeek = '" + dayOfWeek + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_VehicleDispatchVo hVehicleDispatchVo = new();
                    hVehicleDispatchVo.CellNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["CellNumber"]);
                    hVehicleDispatchVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hVehicleDispatchVo.CarCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarCode"]);
                    hVehicleDispatchVo.StaffCode1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode1"]);
                    hVehicleDispatchVo.StaffCode2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode2"]);
                    hVehicleDispatchVo.StaffCode3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode3"]);
                    hVehicleDispatchVo.StaffCode4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode4"]);
                    listHVehicleDispatchVo.Add(hVehicleDispatchVo);
                }
            }
            return listHVehicleDispatchVo;
        }
    }
}
