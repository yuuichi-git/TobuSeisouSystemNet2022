using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchDetailCarDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connection"></param>
        public VehicleDispatchDetailCarDao(ConnectionVo connection) {
            _connectionVo = connection;
        }

        /// <summary>
        /// SelectVehicleDispatchDetailCar
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailCarVo> SelectVehicleDispatchDetailCar(DateTime operationDate) {
            var listVehicleDispatchDetailCarVo = new List<VehicleDispatchDetailCarVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "operation_date," +
                                            "car_code," +
                                            "car_proxy_flag," +
                                            "car_note," +
                                            "insert_pc_name," +
                                            "insert_ymd_hms," +
                                            "update_pc_name," +
                                            "update_ymd_hms," +
                                            "delete_pc_name," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM vehicle_dispatch_detail_car " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailCarVo = new VehicleDispatchDetailCarVo();
                    vehicleDispatchDetailCarVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailCarVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    vehicleDispatchDetailCarVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    vehicleDispatchDetailCarVo.Car_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["car_proxy_flag"]);
                    vehicleDispatchDetailCarVo.Car_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_note"]);
                    vehicleDispatchDetailCarVo.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                    vehicleDispatchDetailCarVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    vehicleDispatchDetailCarVo.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                    vehicleDispatchDetailCarVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    vehicleDispatchDetailCarVo.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                    vehicleDispatchDetailCarVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    vehicleDispatchDetailCarVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listVehicleDispatchDetailCarVo.Add(vehicleDispatchDetailCarVo);
                }
            }
            return listVehicleDispatchDetailCarVo;
        }

        /// <summary>
        /// InsertNewCar
        /// vehicle_dispatch_detail_carへ新規INSERT
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="dropCarCode"></param>
        /// <returns></returns>
        public int InsertNewCar(DateTime operationDate, int dropCellNumber, int dropCarCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_detail_car(cell_number," +
                                                                             "operation_date," +
                                                                             "car_code," +
                                                                             "car_proxy_flag," +
                                                                             "car_note," +
                                                                             "insert_pc_name," +
                                                                             "insert_ymd_hms," +
                                                                             "update_pc_name," +
                                                                             "update_ymd_hms," +
                                                                             "delete_pc_name," +
                                                                             "delete_ymd_hms," +
                                                                             "delete_flag) " +
                                     "VALUES (" + dropCellNumber + "," +
                                            "'" + operationDate.ToString("yyyy-MM-dd") + "'," +
                                            dropCarCode + "," +
                                            "'False'," +
                                            "''," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "''," +
                                            "'1900-01-01 00:00:00'," +
                                            "''," +
                                            "'1900-01-01 00:00:00'," +
                                            "'False');";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// InsertCar
        /// vehicle_dispatch_detailからvehicle_dispatch_detail_carへのINSERT
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int InsertCar(DateTime operationDate, int dragCellNumber, int dropCellNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_detail_car(cell_number," +
                                                                             "operation_date," +
                                                                             "car_code," +
                                                                             "car_proxy_flag," +
                                                                             "car_note," +
                                                                             "insert_pc_name," +
                                                                             "insert_ymd_hms," +
                                                                             "update_pc_name," +
                                                                             "update_ymd_hms," +
                                                                             "delete_pc_name," +
                                                                             "delete_ymd_hms," +
                                                                             "delete_flag) " +
                                     "VALUES (" + dropCellNumber + "," +
                                            "'" + operationDate.ToString("yyyy-MM-dd") + "'," +
                                            "(SELECT car_code FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                            "(SELECT car_proxy_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                            "(SELECT car_note FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "''," +
                                            "'1900-01-01 00:00:00'," +
                                            "''," +
                                            "'1900-01-01 00:00:00'," +
                                            "'False');";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateCar
        /// vehicle_dispatch_detail_carからvehicle_dispatch_detail_carへのUPDATE
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragCarCode"></param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int UpdateCar(DateTime operationDate, int dragCellNumber, int dragCarCode, int dropCellNumber) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail_car " +
                                     "SET cell_number = '" + dropCellNumber + "'," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dragCellNumber + " AND car_code = " + dragCarCode + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteCar
        /// 本番を初期化で使用
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public int DeleteCar(DateTime operationDate) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM vehicle_dispatch_detail_car " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteCar
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragCarCode"></param>
        /// <returns></returns>
        public int DeleteCar(DateTime operationDate, int dragCellNumber, int dragCarCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM vehicle_dispatch_detail_car " +
                                     "WHERE cell_number = " + dragCellNumber + " AND car_code = " + dragCarCode + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
