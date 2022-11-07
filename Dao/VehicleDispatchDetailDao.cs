using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchDetailDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public VehicleDispatchDetailDao(ConnectionVo connection) {
            _connectionVo = connection;
        }

        /// <summary>
        /// CheckVehicleDispatchDetail
        /// レコードの存在確認
        /// </summary>
        /// <returns></returns>
        public bool CheckVehicleDispatchDetail(DateTime operationDate) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 * " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date = '" + operationDate + "'";
            using var sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader.Read() == true;
        }

        /// <summary>
        /// SelectVehicleDispatch
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailVo> SelectVehicleDispatch(string dayOfWeek) {
            var listVehicleDispatchDetailVo = new List<VehicleDispatchDetailVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_head.cell_number," +
                                            "vehicle_dispatch_head.garage_flag," +
                                            "vehicle_dispatch_head.five_lap," +
                                            "vehicle_dispatch_head.move_flag," +
                                            "vehicle_dispatch_body.day_of_week," +
                                            "vehicle_dispatch_head.set_code," +
                                            "vehicle_dispatch_head.car_code," +
                                            "vehicle_dispatch_head.number_of_people," +
                                            "vehicle_dispatch_body.operator_code_1," +
                                            "vehicle_dispatch_body.operator_code_2," +
                                            "vehicle_dispatch_body.operator_code_3," +
                                            "vehicle_dispatch_body.operator_code_4," +
                                            "vehicle_dispatch_body.note " +
                                     "FROM vehicle_dispatch_head " +
                                     "LEFT OUTER JOIN vehicle_dispatch_body ON vehicle_dispatch_head.cell_number = vehicle_dispatch_body.cell_number " +
                                                                          "AND vehicle_dispatch_body.day_of_week = '" + dayOfWeek + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailVo = new VehicleDispatchDetailVo();
                    vehicleDispatchDetailVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    vehicleDispatchDetailVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    vehicleDispatchDetailVo.Move_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["move_flag"]);
                    vehicleDispatchDetailVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    vehicleDispatchDetailVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    vehicleDispatchDetailVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    vehicleDispatchDetailVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    vehicleDispatchDetailVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    vehicleDispatchDetailVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    vehicleDispatchDetailVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    vehicleDispatchDetailVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    vehicleDispatchDetailVo.Set_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["note"]);
                    listVehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
                }
            }
            return listVehicleDispatchDetailVo;
        }

        /// <summary>
        /// SelectVehicleDispatchDetail
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailVo> SelectVehicleDispatchDetail(DateTime operationDate) {
            var listVehicleDispatchDetailVo = new List<VehicleDispatchDetailVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "operation_date," +
                                            "operation_flag," +
                                            "garage_flag," +
                                            "five_lap," +
                                            "day_of_week," +
                                            "set_code," +
                                            "set_note," +
                                            "car_code," +
                                            "car_proxy_flag," +
                                            "car_note," +
                                            "number_of_people," +
                                            "operator_code_1," +
                                            "operator_1_proxy_flag," +
                                            "operator_1_roll_call_ymd_hms," +
                                            "operator_1_note," +
                                            "operator_code_2," +
                                            "operator_2_proxy_flag," +
                                            "operator_2_roll_call_ymd_hms," +
                                            "operator_2_note," +
                                            "operator_code_3," +
                                            "operator_3_proxy_flag," +
                                            "operator_3_roll_call_ymd_hms," +
                                            "operator_3_note," +
                                            "operator_code_4," +
                                            "operator_4_proxy_flag," +
                                            "operator_4_roll_call_ymd_hms," +
                                            "operator_4_note," +
                                            "insert_pc_name," +
                                            "insert_ymd_hms," +
                                            "update_pc_name," +
                                            "update_ymd_hms," +
                                            "delete_pc_name," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailVo = new VehicleDispatchDetailVo();
                    vehicleDispatchDetailVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    vehicleDispatchDetailVo.Operation_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operation_flag"]);
                    vehicleDispatchDetailVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    vehicleDispatchDetailVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    vehicleDispatchDetailVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    vehicleDispatchDetailVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    vehicleDispatchDetailVo.Set_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_note"]);
                    vehicleDispatchDetailVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    vehicleDispatchDetailVo.Car_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["car_proxy_flag"]);
                    vehicleDispatchDetailVo.Car_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_note"]);
                    vehicleDispatchDetailVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    vehicleDispatchDetailVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    vehicleDispatchDetailVo.Operator_1_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_1_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_1_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_1_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_1_note"]);
                    vehicleDispatchDetailVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    vehicleDispatchDetailVo.Operator_2_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_2_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_2_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_2_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_2_note"]);
                    vehicleDispatchDetailVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    vehicleDispatchDetailVo.Operator_3_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_3_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_3_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_3_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_3_note"]);
                    vehicleDispatchDetailVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    vehicleDispatchDetailVo.Operator_4_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_4_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_4_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_4_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_4_note"]);
                    vehicleDispatchDetailVo.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                    vehicleDispatchDetailVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    vehicleDispatchDetailVo.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                    vehicleDispatchDetailVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    vehicleDispatchDetailVo.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                    vehicleDispatchDetailVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    vehicleDispatchDetailVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listVehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
                }
            }
            return listVehicleDispatchDetailVo;
        }

        public List<VehicleDispatchDetailFlowLayoutPanel_StaffLabelEx> SelectVehicleDispatchDetailFlowLayoutPanel_StaffLabelEx(DateTime operationDate) {
            var listVehicleDispatchDetailFlowLayoutPanel_StaffLabelEx = new List<VehicleDispatchDetailFlowLayoutPanel_StaffLabelEx>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "operation_date," +
                                            "operator_code," +
                                            "operator_proxy_flag," +
                                            "operator_roll_call_ymd_hms," +
                                            "operator_note," +
                                            "insert_pc_name," +
                                            "insert_ymd_hms," +
                                            "update_pc_name," +
                                            "update_ymd_hms," +
                                            "delete_pc_name," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM vehicle_dispatch_detail_staff " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx = new VehicleDispatchDetailFlowLayoutPanel_StaffLabelEx();
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Operator_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Operator_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_proxy_flag"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Operator_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_roll_call_ymd_hms"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Operator_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_note"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listVehicleDispatchDetailFlowLayoutPanel_StaffLabelEx.Add(vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx);
                }
            }
            return listVehicleDispatchDetailFlowLayoutPanel_StaffLabelEx;
        }

        /// <summary>
        /// InsertVehicleDispatchDetail
        /// </summary>
        /// <param name="listVehicleDispatchDetailVo"></param>
        public void InsertVehicleDispatchDetail(List<VehicleDispatchDetailVo> listVehicleDispatchDetailVo) {
            int count = 1;
            string sqlString = "";
            foreach (var vehicleDispatchDetailVo in listVehicleDispatchDetailVo) {
                sqlString += "(" + _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Cell_number) + "," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operation_date) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operation_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Garage_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Five_lap) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Move_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Day_of_week) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Set_code) + "," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Set_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Car_code) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Car_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Car_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Number_of_people) + "," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_1) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_1_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_1_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_2) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_2_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_2_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_3) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_3_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_3_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_4) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_4_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_4_note) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Insert_pc_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Insert_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Update_pc_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Update_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Delete_pc_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Delete_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Delete_flag) + "')";
                if (count < listVehicleDispatchDetailVo.Count)
                    sqlString += ",";
                count++;
            }
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_detail(cell_number," +
                                                                         "operation_date," +
                                                                         "operation_flag," +
                                                                         "garage_flag," +
                                                                         "five_lap," +
                                                                         "move_flag," +
                                                                         "day_of_week," +
                                                                         "set_code," +
                                                                         "set_note," +
                                                                         "car_code," +
                                                                         "car_proxy_flag," +
                                                                         "car_note," +
                                                                         "number_of_people," +
                                                                         "operator_code_1," +
                                                                         "operator_1_proxy_flag," +
                                                                         "operator_1_roll_call_ymd_hms," +
                                                                         "operator_1_note," +
                                                                         "operator_code_2," +
                                                                         "operator_2_proxy_flag," +
                                                                         "operator_2_roll_call_ymd_hms," +
                                                                         "operator_2_note," +
                                                                         "operator_code_3," +
                                                                         "operator_3_proxy_flag," +
                                                                         "operator_3_roll_call_ymd_hms," +
                                                                         "operator_3_note," +
                                                                         "operator_code_4," +
                                                                         "operator_4_proxy_flag," +
                                                                         "operator_4_roll_call_ymd_hms," +
                                                                         "operator_4_note," +
                                                                         "insert_pc_name," +
                                                                         "insert_ymd_hms," +
                                                                         "update_pc_name," +
                                                                         "update_ymd_hms," +
                                                                         "delete_pc_name," +
                                                                         "delete_ymd_hms," +
                                                                         "delete_flag) " +
                                     "VALUES " + sqlString;
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteVehicleDispatchDetail
        /// 本番を初期化する際、過去のデータを削除する
        /// </summary>
        /// <param name="operationDate">配車日</param>
        public void DeleteVehicleDispatchDetail(DateTime operationDate) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetControlExからの処理
        /// SetControlExからSetControlEx間のデータをコピーする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int CopySet(DateTime operationDate, int dragCellNumber, int dropCellNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;
            dropCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET operation_flag = (SELECT operation_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "garage_flag = (SELECT garage_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "five_lap = (SELECT five_lap FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "move_flag = (SELECT move_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "day_of_week = (SELECT day_of_week FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "set_code = (SELECT set_code FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "set_note = (SELECT set_note FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dropCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// FlowLayoutPanelExからの処理
        /// FlowLayoutPanelExからDragされたデータを新規で登録する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="setMasterVo"></param>
        /// <returns></returns>
        public int SetDataSetLabelExForFlowLayoutPanelEx(DateTime operationDate, int dropCellNumber, SetMasterVo setMasterVo) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET operation_flag = 'True'," +
                                         "garage_flag = '" + setMasterVo.Garage_flag + "'," +
                                         "five_lap = '" + setMasterVo.Five_lap + "'," +
                                         "move_flag = '" + setMasterVo.Move_flag + "'," +
                                         "day_of_week = '" + operationDate.ToString("ddd") + "'," +
                                         "set_code = '" + setMasterVo.Set_code + "'," +
                                         "set_note = '" + setMasterVo.Remarks + "'," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dropCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        ///  SetControlExからの処理
        ///  Drag元のデータをリセットする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <returns></returns>
        public int ResetSet(DateTime operationDate, int dragCellNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET operation_flag = 'False'," +
                                         "garage_flag = 'False'," +
                                         "five_lap = 'False'," +
                                         "move_flag = 'False'," +
                                         "day_of_week = ''," +
                                         "set_code = 0," +
                                         "set_note = ''," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetControlExからの処理
        /// SetControlExからSetControlEx間のデータをコピーする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int SetCar(DateTime operationDate, int dragCellNumber, int dropCellNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;
            dropCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET car_code = (SELECT car_code FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "car_proxy_flag= (SELECT car_proxy_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "car_note = (SELECT car_note FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dropCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// FlowLayoutPanelExからの処理
        /// FlowLayoutPanelExからDragされたデータを新規で登録する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public int SetCar(DateTime operationDate, int dropCellNumber, CarMasterVo carMasterVo) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET car_code = '" + carMasterVo.Car_code + "'," +
                                         "car_proxy_flag = 'False'," +
                                         "car_note = '" + carMasterVo.Remarks + "'," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dropCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetControlExからの処理
        /// Drag元のデータをリセットする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <returns></returns>
        public int ResetCar(DateTime operationDate, int dragCellNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET car_code = 0," +
                                         "car_proxy_flag = 'False'," +
                                         "car_note = ''," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// operator_1
        /// SetControlExからSetControlEx間のデータをコピーする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragRowNumber">StaffLabelExのSetControlEx上でのRowの位置</param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int SetStaff(DateTime operationDate, int dragCellNumber, int dragRowNumber, int dropCellNumber, int dropRowNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;
            dropCellNumber++;
            /*
             * TableLayoutPanel上のPointを変換する
             */
            dragRowNumber--;
            dropRowNumber--;
            /*
             * Drag項目のSQL文を作成
             */
            string sqlDragOperatorCode = string.Concat("operator_code_" + dragRowNumber);
            string sqlDragOperatorProxyFlag = string.Concat("operator_" + dragRowNumber + "_proxy_flag");
            string sqlDragOperatorRollCallYmdHms = string.Concat("operator_" + dragRowNumber + "_roll_call_ymd_hms");
            string sqlDragOperatorNote = string.Concat("operator_" + dragRowNumber, "_note");
            /*
             * Drop項目のSQL文を作成
             */
            string sqlDropOperatorCode = string.Concat("operator_code_" + dropRowNumber);
            string sqlDropOperatorProxyFlag = string.Concat("operator_" + dropRowNumber + "_proxy_flag");
            string sqlDropOperatorRollCallYmdHms = string.Concat("operator_" + dropRowNumber + "_roll_call_ymd_hms");
            string sqlDropOperatorNote = string.Concat("operator_" + dropRowNumber, "_note");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDropOperatorCode + " = (SELECT " + sqlDragOperatorCode + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         sqlDropOperatorProxyFlag + " = (SELECT " + sqlDragOperatorProxyFlag + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                    sqlDropOperatorRollCallYmdHms + " = (SELECT " + sqlDragOperatorRollCallYmdHms + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                              sqlDropOperatorNote + " = (SELECT " + sqlDragOperatorNote + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dropCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        public int SetStaff(DateTime operationDate, int dragCellNumber, int dropCellNumber, int dropRowNumber, StaffMasterVo staffMasterVo) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlDropOperatorCode = string.Concat("operator_code_" + dropRowNumber);
            string sqlDropOperatorProxyFlag = string.Concat("operator_" + dropRowNumber + "_proxy_flag");
            string sqlDropOperatorRollCallYmdHms = string.Concat("operator_" + dropRowNumber + "_roll_call_ymd_hms");
            string sqlDropOperatorNote = string.Concat("operator_" + dropRowNumber, "_note");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDropOperatorCode + " = (SELECT operator_code " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         sqlDropOperatorProxyFlag + " = (SELECT operator_proxy_flag " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                    sqlDropOperatorRollCallYmdHms + " = (SELECT operator_roll_call_ymd_hms " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                              sqlDropOperatorNote + " = (SELECT operator_note " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                           "update_pc_name = '" + Environment.MachineName + "'," +
                                           "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dropCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// ResetDataStaffLabelExForSetControlEx
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragRowNumber"></param>
        /// <returns></returns>
        public int ResetStaff(DateTime operationDate, int dragCellNumber, int dragRowNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;
            /*
             * TableLayoutPanel上のPointを変換する
             */
            dragRowNumber--;
            /*
             * Drag項目のSQL文を作成
             */
            string sqlDragOperatorCode = string.Concat("operator_code_" + dragRowNumber);
            string sqlDragOperatorProxyFlag = string.Concat("operator_" + dragRowNumber + "_proxy_flag");
            string sqlDragOperatorRollCallYmdHms = string.Concat("operator_" + dragRowNumber + "_roll_call_ymd_hms");
            string sqlDragOperatorNote = string.Concat("operator_" + dragRowNumber, "_note");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDragOperatorCode + " = 0," +
                                              sqlDragOperatorProxyFlag + " = 'False'," +
                                              sqlDragOperatorRollCallYmdHms + " = '1900-01-01 00:00:00'," +
                                              sqlDragOperatorNote + " = ''," +
                                             "update_pc_name = '" + Environment.MachineName + "'," +
                                             "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
