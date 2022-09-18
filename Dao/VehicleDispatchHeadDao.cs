using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchHeadDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public VehicleDispatchHeadDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectAllVehicleDispatchMasterVo
        /// </summary>
        /// <returns></returns>
        public List<VehicleDispatchHeadVo> SelectAllVehicleDispatchHeadVo() {
            var listVehicleDispatchHeadVo = new List<VehicleDispatchHeadVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "garage_flag," +
                                            "five_lap," +
                                            "day_of_week," +
                                            "set_code," +
                                            "car_code," +
                                            "number_of_people," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM view_set_master ";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var setVehicleDispatchHeadVo = new VehicleDispatchHeadVo();
                    setVehicleDispatchHeadVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    setVehicleDispatchHeadVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    setVehicleDispatchHeadVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    setVehicleDispatchHeadVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    setVehicleDispatchHeadVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    setVehicleDispatchHeadVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    setVehicleDispatchHeadVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    setVehicleDispatchHeadVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    setVehicleDispatchHeadVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    setVehicleDispatchHeadVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    setVehicleDispatchHeadVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listVehicleDispatchHeadVo.Add(setVehicleDispatchHeadVo);
                }
            }
            return listVehicleDispatchHeadVo;
        }
    }
}
