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
        public List<WardChiyodaVo> SelectChiyodaVehicleDispatchDetail(DateTime operationDate1, DateTime operationDate2) {
            List<WardChiyodaVo> listWardChiyodaVo = new List<WardChiyodaVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_detail.operation_date," +
                                            "vehicle_dispatch_detail.operator_code_1," +
                                            "staff_master_1.display_name AS operator_name_1," +
                                            "vehicle_dispatch_detail.operator_code_2," +
                                            "staff_master_2.display_name AS operator_name_2," +
                                            "vehicle_dispatch_detail.operator_code_3," +
                                            "staff_master_3.display_name AS operator_name_3 " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_1 ON vehicle_dispatch_detail.operator_code_1 = staff_master_1.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_2 ON vehicle_dispatch_detail.operator_code_2 = staff_master_2.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_3 ON vehicle_dispatch_detail.operator_code_3 = staff_master_3.staff_code " +
                                     "WHERE operation_date BETWEEN '" + operationDate1.ToString("yyyy-MM-dd") + "' AND '" + operationDate2.ToString("yyyy-MM-dd") + "' " +
                                       "AND operation_flag = 'True' " +
                                       "AND (vehicle_dispatch_detail.set_code = '1310101' OR vehicle_dispatch_detail.set_code = '1310102' OR vehicle_dispatch_detail.set_code = '1310103') " +
                                     "ORDER BY operation_date ASC, cell_number ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    WardChiyodaVo wardChiyodaVo = new WardChiyodaVo();
                    wardChiyodaVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    wardChiyodaVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    wardChiyodaVo.Operator_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_name_1"]);
                    wardChiyodaVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    wardChiyodaVo.Operator_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_name_2"]);
                    wardChiyodaVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    wardChiyodaVo.Operator_name_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_name_3"]);
                    listWardChiyodaVo.Add(wardChiyodaVo);
                }
            }
            return listWardChiyodaVo;
        }

        /// <summary>
        /// SelectGroupByChiyodaVehicleDispatchDetail
        /// </summary>
        /// <param name="operationDate1"></param>
        /// <param name="operationDate2"></param>
        /// <returns></returns>
        public List<WardChiyodaVo2> SelectGroupByChiyodaVehicleDispatchDetail(DateTime operationDate1, DateTime operationDate2) {
            List<WardChiyodaVo2> listWardChiyodaVo2 = new List<WardChiyodaVo2>();
            WardChiyodaVo2 wardChiyodaVo2;

            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_detail.operation_date," +
                                            "staff_master_1.display_name AS operator_name_1," +
                                            "staff_master_2.display_name AS operator_name_2 " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_1 ON vehicle_dispatch_detail.operator_code_1 = staff_master_1.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_2 ON vehicle_dispatch_detail.operator_code_2 = staff_master_2.staff_code " +
                                     "WHERE operation_date BETWEEN '" + operationDate1.ToString("yyyy-MM-dd") + "' AND '" + operationDate2.ToString("yyyy-MM-dd") + "' " +
                                       "AND operation_flag = 'True' " +
                                       "AND (vehicle_dispatch_detail.set_code = '1310101' OR vehicle_dispatch_detail.set_code = '1310102' OR vehicle_dispatch_detail.set_code = '1310103')";

            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    /*
                     * 運転者を追加する
                     */
                    wardChiyodaVo2 = new WardChiyodaVo2();
                    wardChiyodaVo2.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    wardChiyodaVo2.Operator_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_name_1"]);
                    wardChiyodaVo2.Occupation = "運転手";
                    listWardChiyodaVo2.Add(wardChiyodaVo2);
                    /*
                     * 作業員１を追加する
                     */
                    wardChiyodaVo2 = new WardChiyodaVo2();
                    wardChiyodaVo2.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    wardChiyodaVo2.Operator_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_name_2"]);
                    wardChiyodaVo2.Occupation = "作業員";
                    listWardChiyodaVo2.Add(wardChiyodaVo2);
                }
            }
            return listWardChiyodaVo2;
        }
    }
}
