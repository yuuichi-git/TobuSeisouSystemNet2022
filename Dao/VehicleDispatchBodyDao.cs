using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchBodyDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public VehicleDispatchBodyDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectAllVehicleDispatchBodyVo
        /// </summary>
        /// <returns></returns>
        public List<VehicleDispatchBodyVo> SelectAllVehicleDispatchBodyVo() {
            var listVehicleDispatchBodyVo = new List<VehicleDispatchBodyVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "day_of_week," +
                                            "operator_code_1," +
                                            "operator_code_2," +
                                            "operator_code_3," +
                                            "operator_code_4," +
                                            "note," +
                                            "financial_year," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM vehicle_dispatch_body ";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var setVehicleDispatchBodyVo = new VehicleDispatchBodyVo();
                    setVehicleDispatchBodyVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    setVehicleDispatchBodyVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    setVehicleDispatchBodyVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    setVehicleDispatchBodyVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    setVehicleDispatchBodyVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    setVehicleDispatchBodyVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    setVehicleDispatchBodyVo.Note = _defaultValue.GetDefaultValue<string>(sqlDataReader["note"]);
                    setVehicleDispatchBodyVo.Financial_year = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["financial_year"]);
                    setVehicleDispatchBodyVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    setVehicleDispatchBodyVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    setVehicleDispatchBodyVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    setVehicleDispatchBodyVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listVehicleDispatchBodyVo.Add(setVehicleDispatchBodyVo);
                }
            }
            return listVehicleDispatchBodyVo;
        }
    }
}
