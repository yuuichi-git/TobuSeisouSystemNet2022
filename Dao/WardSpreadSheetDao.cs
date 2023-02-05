using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class WardSpreadSheetDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public WardSpreadSheetDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }
        /// <summary>
        /// SelectAllVehicleDispatchDetail
        /// 千代田区配車 set_code = '1310101' '1310102' '1310103'
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<WardChiyodaVo> SelectAllVehicleDispatchDetail(DateTime operationDate1, DateTime operationDate2) {
            List<WardChiyodaVo> listWardChiyodaVo = new List<WardChiyodaVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_detail.operation_date," +
                                            "vehicle_dispatch_detail.operator_code_1," +
                                            "staff_master_1.display_name," +
                                            "vehicle_dispatch_detail.operator_code_2," +
                                            "staff_master_2.display_name," +
                                            "vehicle_dispatch_detail.operator_code_3," +
                                            "staff_master_3.display_name " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN set_master ON vehicle_dispatch_detail.set_code = set_master.set_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_1 ON vehicle_dispatch_detail.operator_code_1 = staff_master_1.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_2 ON vehicle_dispatch_detail.operator_code_1 = staff_master_2.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_3 ON vehicle_dispatch_detail.operator_code_1 = staff_master_3.staff_code " +
                                     "WHERE operation_date BETWEEN '" + operationDate1.ToString("yyyy-MM-dd") + "' AND '" + operationDate2.ToString("yyyy-MM-dd") + "' " +
                                       "AND (vehicle_dispatch_detail.set_code = '1310101' OR vehicle_dispatch_detail.set_code = '1310102' OR vehicle_dispatch_detail.set_code = '1310103')";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    WardChiyodaVo wardChiyodaVo = new WardChiyodaVo();
                    wardChiyodaVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    wardChiyodaVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    wardChiyodaVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    wardChiyodaVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    listWardChiyodaVo.Add(wardChiyodaVo);
                }
            }
            return listWardChiyodaVo;
        }
    }
}
