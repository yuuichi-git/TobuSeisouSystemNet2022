using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchDetailDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connection"></param>
        public VehicleDispatchDetailDao(ConnectionVo connection) {
            /*
             * Vo
             */
            _connectionVo = connection;
        }

        /// <summary>
        /// CheckVehicleDispatchDetail
        /// レコードの存在確認
        /// </summary>
        /// <returns></returns>
        public bool CheckVehicleDispatchDetail(DateTime operationDate) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 * " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date = '" + operationDate + "'";
            using var sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader.Read() == true;
        }

        /// <summary>
        /// SelectVehicleDispatch
        /// 社内での本番を取得
        /// 2023-02-24 financial_yearを抽出条件に追加した
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailVo> SelectVehicleDispatch(DateTime financial_year, string dayOfWeek) {
            List<VehicleDispatchDetailVo> listVehicleDispatchDetailVo = new List<VehicleDispatchDetailVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_head.cell_number," +
                                            "vehicle_dispatch_head.garage_flag," +
                                            "vehicle_dispatch_head.five_lap," +
                                            "vehicle_dispatch_head.move_flag," +
                                            "vehicle_dispatch_body_office.day_of_week," + // vehicle_dispatch_body_officeから
                                            "vehicle_dispatch_head.set_code," +
                                            "vehicle_dispatch_body_office.car_code," +  // vehicle_dispatch_body_officeから
                                            "vehicle_dispatch_head.number_of_people," +
                                            "vehicle_dispatch_body_office.operator_code_1," + // vehicle_dispatch_body_officeから
                                            "staff_master_1.occupation AS operator_1_occupation," +
                                            "vehicle_dispatch_body_office.operator_code_2," +  // vehicle_dispatch_body_officeから
                                            "staff_master_2.occupation AS operator_2_occupation," +
                                            "vehicle_dispatch_body_office.operator_code_3," +  // vehicle_dispatch_body_officeから
                                            "staff_master_3.occupation AS operator_3_occupation," +
                                            "vehicle_dispatch_body_office.operator_code_4," +  // vehicle_dispatch_body_officeから
                                            "staff_master_4.occupation AS operator_4_occupation," +
                                            "vehicle_dispatch_body_office.note " +  // vehicle_dispatch_body_officeから
                                      "FROM vehicle_dispatch_head " +
                                      "LEFT JOIN vehicle_dispatch_body_office ON (vehicle_dispatch_head.cell_number = vehicle_dispatch_body_office.cell_number " +
                                            "AND vehicle_dispatch_body_office.financial_year = '" + financial_year.ToString("yyyy-04-01") + "' " +
                                            "AND vehicle_dispatch_body_office.day_of_week = '" + dayOfWeek + "') " +
                                      "LEFT OUTER JOIN staff_master AS staff_master_1 ON vehicle_dispatch_body_office.operator_code_1 = staff_master_1.staff_code " +
                                      "LEFT OUTER JOIN staff_master AS staff_master_2 ON vehicle_dispatch_body_office.operator_code_2 = staff_master_2.staff_code " +
                                      "LEFT OUTER JOIN staff_master AS staff_master_3 ON vehicle_dispatch_body_office.operator_code_3 = staff_master_3.staff_code " +
                                      "LEFT OUTER JOIN staff_master AS staff_master_4 ON vehicle_dispatch_body_office.operator_code_4 = staff_master_4.staff_code " +
                                      "WHERE vehicle_dispatch_head.financial_year = '" + financial_year.ToString("yyyy-04-01") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    VehicleDispatchDetailVo vehicleDispatchDetailVo = new VehicleDispatchDetailVo();
                    vehicleDispatchDetailVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    vehicleDispatchDetailVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    vehicleDispatchDetailVo.Move_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["move_flag"]);
                    vehicleDispatchDetailVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    vehicleDispatchDetailVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    vehicleDispatchDetailVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    vehicleDispatchDetailVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    vehicleDispatchDetailVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    vehicleDispatchDetailVo.Operator_1_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_1_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    vehicleDispatchDetailVo.Operator_2_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_2_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    vehicleDispatchDetailVo.Operator_3_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_3_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    vehicleDispatchDetailVo.Operator_4_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_4_occupation"]);
                    vehicleDispatchDetailVo.Set_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["note"]);
                    listVehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
                }
            }
            return listVehicleDispatchDetailVo;
        }

        /// <summary>
        /// SelectOneVehicleDispatchDetail
        /// 2023-09-21
        /// vehicle_dispatch_detail.fax_transmission_flagを追加
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public VehicleDispatchDetailVo SelectOneVehicleDispatchDetail(DateTime operationDate, int cellNumber) {
            VehicleDispatchDetailVo vehicleDispatchDetailVo = new VehicleDispatchDetailVo();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_detail.cell_number," +
                                            "vehicle_dispatch_detail.operation_date," +
                                            "vehicle_dispatch_detail.operation_flag," +
                                            "vehicle_dispatch_detail.garage_flag," +
                                            "vehicle_dispatch_detail.five_lap," +
                                            "vehicle_dispatch_detail.day_of_week," +
                                            "vehicle_dispatch_detail.shift_code," +
                                            "vehicle_dispatch_detail.stand_by_flag," +
                                            "vehicle_dispatch_detail.classification_flag," +
                                            "vehicle_dispatch_detail.add_worker_flag," +
                                            "vehicle_dispatch_detail.contact_infomation_flag," +
                                            "vehicle_dispatch_detail.fax_transmission_flag," +
                                            "vehicle_dispatch_detail.set_code," +
                                            "vehicle_dispatch_detail.set_note," +
                                            "vehicle_dispatch_detail.car_code," +
                                            "vehicle_dispatch_detail.car_proxy_flag," +
                                            "vehicle_dispatch_detail.car_note," +
                                            "vehicle_dispatch_detail.number_of_people," +
                                            "vehicle_dispatch_detail.operator_code_1," +
                                            "vehicle_dispatch_detail.operator_1_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_1_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_1_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_1_note," +
                                            "vehicle_dispatch_detail.operator_1_occupation," +
                                            "vehicle_dispatch_detail.operator_code_2," +
                                            "vehicle_dispatch_detail.operator_2_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_2_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_2_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_2_note," +
                                            "vehicle_dispatch_detail.operator_2_occupation," +
                                            "vehicle_dispatch_detail.operator_code_3," +
                                            "vehicle_dispatch_detail.operator_3_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_3_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_3_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_3_note," +
                                            "vehicle_dispatch_detail.operator_3_occupation," +
                                            "vehicle_dispatch_detail.operator_code_4," +
                                            "vehicle_dispatch_detail.operator_4_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_4_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_4_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_4_note," +
                                            "vehicle_dispatch_detail.operator_4_occupation," +
                                            "vehicle_dispatch_detail.last_roll_call_flag," +
                                            "vehicle_dispatch_detail.last_plant_count," +
                                            "vehicle_dispatch_detail.last_plant_name," +
                                            "vehicle_dispatch_detail.last_plant_ymd_hms," +
                                            "vehicle_dispatch_detail.last_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.insert_pc_name," +
                                            "vehicle_dispatch_detail.insert_ymd_hms," +
                                            "vehicle_dispatch_detail.update_pc_name," +
                                            "vehicle_dispatch_detail.update_ymd_hms," +
                                            "vehicle_dispatch_detail.delete_pc_name," +
                                            "vehicle_dispatch_detail.delete_ymd_hms," +
                                            "vehicle_dispatch_detail.delete_flag " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_1 ON vehicle_dispatch_detail.operator_code_1 = staff_master_1.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_2 ON vehicle_dispatch_detail.operator_code_2 = staff_master_2.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_3 ON vehicle_dispatch_detail.operator_code_3 = staff_master_3.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_4 ON vehicle_dispatch_detail.operator_code_4 = staff_master_4.staff_code " +
                                     "WHERE vehicle_dispatch_detail.operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "' AND vehicle_dispatch_detail.cell_number = " + cellNumber;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    vehicleDispatchDetailVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    vehicleDispatchDetailVo.Operation_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operation_flag"]);
                    vehicleDispatchDetailVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    vehicleDispatchDetailVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    vehicleDispatchDetailVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    vehicleDispatchDetailVo.Shift_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["shift_code"]);
                    vehicleDispatchDetailVo.Stand_by_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["stand_by_flag"]);
                    vehicleDispatchDetailVo.Classification_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["classification_flag"]);
                    vehicleDispatchDetailVo.Add_worker_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["add_worker_flag"]);
                    vehicleDispatchDetailVo.Contact_infomation_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["contact_infomation_flag"]);
                    vehicleDispatchDetailVo.Fax_transmission_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["fax_transmission_flag"]);
                    vehicleDispatchDetailVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    vehicleDispatchDetailVo.Set_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_note"]);
                    vehicleDispatchDetailVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    vehicleDispatchDetailVo.Car_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["car_proxy_flag"]);
                    vehicleDispatchDetailVo.Car_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_note"]);
                    vehicleDispatchDetailVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    vehicleDispatchDetailVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    vehicleDispatchDetailVo.Operator_1_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_1_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_1_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_1_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_1_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_1_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_1_note"]);
                    vehicleDispatchDetailVo.Operator_1_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_1_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    vehicleDispatchDetailVo.Operator_2_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_2_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_2_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_2_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_2_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_2_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_2_note"]);
                    vehicleDispatchDetailVo.Operator_2_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_2_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    vehicleDispatchDetailVo.Operator_3_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_3_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_3_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_3_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_3_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_3_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_3_note"]);
                    vehicleDispatchDetailVo.Operator_3_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_3_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    vehicleDispatchDetailVo.Operator_4_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_4_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_4_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_4_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_4_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_4_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_4_note"]);
                    vehicleDispatchDetailVo.Operator_4_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_4_occupation"]);
                    vehicleDispatchDetailVo.Last_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["last_roll_call_flag"]);
                    vehicleDispatchDetailVo.Last_plant_count = _defaultValue.GetDefaultValue<int>(sqlDataReader["last_plant_count"]);
                    vehicleDispatchDetailVo.Last_plant_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["last_plant_name"]);
                    vehicleDispatchDetailVo.Last_plant_hm = _defaultValue.GetDefaultValue<string>(sqlDataReader["last_plant_ymd_hms"]);
                    vehicleDispatchDetailVo.Last_roll_call_hm = _defaultValue.GetDefaultValue<string>(sqlDataReader["last_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                    vehicleDispatchDetailVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    vehicleDispatchDetailVo.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                    vehicleDispatchDetailVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    vehicleDispatchDetailVo.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                    vehicleDispatchDetailVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    vehicleDispatchDetailVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
            }
            return vehicleDispatchDetailVo;
        }

        /// <summary>
        /// SelectAllVehicleDispatchDetail
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailVo> SelectAllVehicleDispatchDetail(DateTime operationDate) {
            var listVehicleDispatchDetailVo = new List<VehicleDispatchDetailVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT vehicle_dispatch_detail.cell_number," +
                                            "vehicle_dispatch_detail.operation_date," +
                                            "vehicle_dispatch_detail.operation_flag," +
                                            "vehicle_dispatch_detail.garage_flag," +
                                            "vehicle_dispatch_detail.five_lap," +
                                            "vehicle_dispatch_detail.day_of_week," +
                                            "vehicle_dispatch_detail.shift_code," +
                                            "vehicle_dispatch_detail.stand_by_flag," +
                                            "vehicle_dispatch_detail.classification_flag," +
                                            "vehicle_dispatch_detail.add_worker_flag," +
                                            "vehicle_dispatch_detail.contact_infomation_flag," +
                                            "vehicle_dispatch_detail.fax_transmission_flag," +
                                            "vehicle_dispatch_detail.set_code," +
                                            "vehicle_dispatch_detail.set_note," +
                                            "vehicle_dispatch_detail.car_code," +
                                            "vehicle_dispatch_detail.car_proxy_flag," +
                                            "vehicle_dispatch_detail.car_note," +
                                            "vehicle_dispatch_detail.number_of_people," +
                                            "vehicle_dispatch_detail.operator_code_1," +
                                            "vehicle_dispatch_detail.operator_1_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_1_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_1_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_1_note," +
                                            "vehicle_dispatch_detail.operator_1_occupation," +
                                            "vehicle_dispatch_detail.operator_code_2," +
                                            "vehicle_dispatch_detail.operator_2_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_2_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_2_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_2_note," +
                                            "vehicle_dispatch_detail.operator_2_occupation," +
                                            "vehicle_dispatch_detail.operator_code_3," +
                                            "vehicle_dispatch_detail.operator_3_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_3_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_3_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_3_note," +
                                            "vehicle_dispatch_detail.operator_3_occupation," +
                                            "vehicle_dispatch_detail.operator_code_4," +
                                            "vehicle_dispatch_detail.operator_4_proxy_flag," +
                                            "vehicle_dispatch_detail.operator_4_roll_call_flag," +
                                            "vehicle_dispatch_detail.operator_4_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.operator_4_note," +
                                            "vehicle_dispatch_detail.operator_4_occupation," +
                                            "vehicle_dispatch_detail.last_roll_call_flag," +
                                            "vehicle_dispatch_detail.last_plant_count," +
                                            "vehicle_dispatch_detail.last_plant_name," +
                                            "vehicle_dispatch_detail.last_plant_ymd_hms," +
                                            "vehicle_dispatch_detail.last_roll_call_ymd_hms," +
                                            "vehicle_dispatch_detail.insert_pc_name," +
                                            "vehicle_dispatch_detail.insert_ymd_hms," +
                                            "vehicle_dispatch_detail.update_pc_name," +
                                            "vehicle_dispatch_detail.update_ymd_hms," +
                                            "vehicle_dispatch_detail.delete_pc_name," +
                                            "vehicle_dispatch_detail.delete_ymd_hms," +
                                            "vehicle_dispatch_detail.delete_flag " +
                                     "FROM vehicle_dispatch_detail " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_1 ON vehicle_dispatch_detail.operator_code_1 = staff_master_1.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_2 ON vehicle_dispatch_detail.operator_code_2 = staff_master_2.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_3 ON vehicle_dispatch_detail.operator_code_3 = staff_master_3.staff_code " +
                                     "LEFT OUTER JOIN staff_master AS staff_master_4 ON vehicle_dispatch_detail.operator_code_4 = staff_master_4.staff_code " +
                                     "WHERE vehicle_dispatch_detail.operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailVo = new VehicleDispatchDetailVo();
                    vehicleDispatchDetailVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    vehicleDispatchDetailVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    vehicleDispatchDetailVo.Operation_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operation_flag"]);
                    vehicleDispatchDetailVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    vehicleDispatchDetailVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    vehicleDispatchDetailVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    vehicleDispatchDetailVo.Shift_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["shift_code"]);
                    vehicleDispatchDetailVo.Stand_by_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["stand_by_flag"]);
                    vehicleDispatchDetailVo.Classification_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["classification_flag"]);
                    vehicleDispatchDetailVo.Add_worker_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["add_worker_flag"]);
                    vehicleDispatchDetailVo.Contact_infomation_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["contact_infomation_flag"]);
                    vehicleDispatchDetailVo.Fax_transmission_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["fax_transmission_flag"]);
                    vehicleDispatchDetailVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    vehicleDispatchDetailVo.Set_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_note"]);
                    vehicleDispatchDetailVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    vehicleDispatchDetailVo.Car_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["car_proxy_flag"]);
                    vehicleDispatchDetailVo.Car_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_note"]);
                    vehicleDispatchDetailVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    vehicleDispatchDetailVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    vehicleDispatchDetailVo.Operator_1_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_1_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_1_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_1_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_1_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_1_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_1_note"]);
                    vehicleDispatchDetailVo.Operator_1_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_1_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    vehicleDispatchDetailVo.Operator_2_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_2_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_2_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_2_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_2_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_2_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_2_note"]);
                    vehicleDispatchDetailVo.Operator_2_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_2_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    vehicleDispatchDetailVo.Operator_3_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_3_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_3_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_3_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_3_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_3_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_3_note"]);
                    vehicleDispatchDetailVo.Operator_3_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_3_occupation"]);
                    vehicleDispatchDetailVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    vehicleDispatchDetailVo.Operator_4_proxy_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_4_proxy_flag"]);
                    vehicleDispatchDetailVo.Operator_4_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["operator_4_roll_call_flag"]);
                    vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operator_4_roll_call_ymd_hms"]);
                    vehicleDispatchDetailVo.Operator_4_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_4_note"]);
                    vehicleDispatchDetailVo.Operator_4_occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_4_occupation"]);
                    vehicleDispatchDetailVo.Last_roll_call_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["last_roll_call_flag"]);
                    vehicleDispatchDetailVo.Last_plant_count = _defaultValue.GetDefaultValue<int>(sqlDataReader["last_plant_count"]);
                    vehicleDispatchDetailVo.Last_plant_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["last_plant_name"]);
                    vehicleDispatchDetailVo.Last_plant_hm = _defaultValue.GetDefaultValue<string>(sqlDataReader["last_plant_ymd_hms"]);
                    vehicleDispatchDetailVo.Last_roll_call_hm = _defaultValue.GetDefaultValue<string>(sqlDataReader["last_roll_call_ymd_hms"]);
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

        /// <summary>
        /// InsertVehicleDispatchDetail
        /// 2023-09-21
        /// Fax_transmission_flagを追加
        /// </summary>
        /// <param name="listVehicleDispatchDetailVo"></param>
        public void InsertVehicleDispatchDetail(List<VehicleDispatchDetailVo> listVehicleDispatchDetailVo) {
            int count = 1;
            string sqlString = "";
            foreach(var vehicleDispatchDetailVo in listVehicleDispatchDetailVo) {
                sqlString += "(" + _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Cell_number) + "," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operation_date) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operation_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Garage_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Five_lap) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Move_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Day_of_week) + "'," +
                             "'" + _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Shift_code) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Stand_by_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Classification_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Add_worker_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Contact_infomation_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Fax_transmission_flag) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Set_code) + "," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Set_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Car_code) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Car_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Car_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Number_of_people) + "," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_1) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_1_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_1_roll_call_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_1_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_1_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_1_occupation) + "," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_2) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_2_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_2_roll_call_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_2_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_2_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_2_occupation) + "," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_3) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_3_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_3_roll_call_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_3_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_3_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_3_occupation) + "," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_code_4) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_4_proxy_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Operator_4_roll_call_flag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Operator_4_roll_call_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Operator_4_note) + "'," +
                                   _defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Operator_4_occupation) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Last_roll_call_flag) + "'," +
                                 +_defaultValue.GetDefaultValue<int>(vehicleDispatchDetailVo.Last_plant_count) + "," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Last_plant_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Last_plant_hm) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Last_roll_call_hm) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Insert_pc_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Insert_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Update_pc_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Update_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(vehicleDispatchDetailVo.Delete_pc_name) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(vehicleDispatchDetailVo.Delete_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(vehicleDispatchDetailVo.Delete_flag) + "')";
                if(count < listVehicleDispatchDetailVo.Count)
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
                                                                         "shift_code," +
                                                                         "stand_by_flag," +
                                                                         "classification_flag," +
                                                                         "add_worker_flag," +
                                                                         "contact_infomation_flag," +
                                                                         "fax_transmission_flag," +
                                                                         "set_code," +
                                                                         "set_note," +
                                                                         "car_code," +
                                                                         "car_proxy_flag," +
                                                                         "car_note," +
                                                                         "number_of_people," +
                                                                         "operator_code_1," +
                                                                         "operator_1_proxy_flag," +
                                                                         "operator_1_roll_call_flag," +
                                                                         "operator_1_roll_call_ymd_hms," +
                                                                         "operator_1_note," +
                                                                         "operator_1_occupation," +
                                                                         "operator_code_2," +
                                                                         "operator_2_proxy_flag," +
                                                                         "operator_2_roll_call_flag," +
                                                                         "operator_2_roll_call_ymd_hms," +
                                                                         "operator_2_note," +
                                                                         "operator_2_occupation," +
                                                                         "operator_code_3," +
                                                                         "operator_3_proxy_flag," +
                                                                         "operator_3_roll_call_flag," +
                                                                         "operator_3_roll_call_ymd_hms," +
                                                                         "operator_3_note," +
                                                                         "operator_3_occupation," +
                                                                         "operator_code_4," +
                                                                         "operator_4_proxy_flag," +
                                                                         "operator_4_roll_call_flag," +
                                                                         "operator_4_roll_call_ymd_hms," +
                                                                         "operator_4_note," +
                                                                         "operator_4_occupation," +
                                                                         "last_roll_call_flag," +
                                                                         "last_plant_count," +
                                                                         "last_plant_name," +
                                                                         "last_plant_ymd_hms," +
                                                                         "last_roll_call_ymd_hms," +
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
        public int CopySetLabel(DateTime operationDate, int dragCellNumber, int dropCellNumber) {
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
                                         "shift_code = (SELECT shift_code FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "stand_by_flag = (SELECT stand_by_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "classification_flag = (SELECT classification_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "fax_transmission_flag = (SELECT fax_transmission_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "add_worker_flag = (SELECT add_worker_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "set_code = (SELECT set_code FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "set_note = (SELECT set_note FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "last_roll_call_flag = (SELECT last_roll_call_flag FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "last_plant_count = (SELECT last_plant_count FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "last_plant_name = (SELECT last_plant_name FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "last_plant_ymd_hms = (SELECT last_plant_ymd_hms FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         "last_roll_call_ymd_hms = (SELECT last_roll_call_ymd_hms FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
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
        public int CreateSetLabel(DateTime operationDate, int dropCellNumber, SetMasterVo setMasterVo) {
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
                                         "shift_code = 0," + // 番手コードをセット(0:無 1:早番 2:遅番)
                                         "set_code = '" + setMasterVo.Set_code + "'," +
                                         "set_note = '" + setMasterVo.Remarks + "'," +
                                         "last_roll_call_flag = 'False'," +
                                         "last_plant_count = 0," +
                                         "last_plant_name = ''," +
                                         "last_plant_ymd_hms = ''," +
                                         "last_roll_call_ymd_hms = ''," +
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
        public int ResetSetLabel(DateTime operationDate, int dragCellNumber) {
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
                                         "stand_by_flag = 'False'," +
                                         "shift_code = 0," +
                                         "classification_flag = 'False'," +
                                         "fax_transmission_flag = 'False'," +
                                         "add_worker_flag = 'False'," +
                                         "set_code = 0," +
                                         "set_note = ''," +
                                         "last_roll_call_flag = 'False'," +
                                         "last_plant_count = 0," +
                                         "last_plant_name = ''," +
                                         "last_plant_ymd_hms = ''," +
                                         "last_roll_call_ymd_hms = ''," +
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
        public int MoveCarLabel(DateTime operationDate, int dragCellNumber, int dropCellNumber) {
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
        public int CreateCarLabel(DateTime operationDate, int dropCellNumber, CarMasterVo carMasterVo) {
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
        /// ResetCar
        /// vehicle_dispatch_detailをリセットする
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <returns></returns>
        public int ResetCarLabel(DateTime operationDate, int dragCellNumber) {
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
        /// SetControlExからSetControlExへの移動処理
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragRowNumber">StaffLabelExのSetControlEx上でのRowの位置</param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int MoveStaffLabel(DateTime operationDate, int dragCellNumber, int dragRowNumber, int dropCellNumber, int dropRowNumber) {
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
            string sqlDragOperatorRollCallFlag = string.Concat("operator_" + dragRowNumber + "_roll_call_Flag");
            string sqlDragOperatorRollCallYmdHms = string.Concat("operator_" + dragRowNumber + "_roll_call_ymd_hms");
            string sqlDragOperatorNote = string.Concat("operator_" + dragRowNumber, "_note");
            string sqlDragOperatorOccupation = string.Concat("operator_" + dragRowNumber, "_occupation");
            /*
             * Drop項目のSQL文を作成
             */
            string sqlDropOperatorCode = string.Concat("operator_code_" + dropRowNumber);
            string sqlDropOperatorProxyFlag = string.Concat("operator_" + dropRowNumber + "_proxy_flag");
            string sqlDropOperatorRollCallFlag = string.Concat("operator_" + dropRowNumber + "_roll_call_flag");
            string sqlDropOperatorRollCallYmdHms = string.Concat("operator_" + dropRowNumber + "_roll_call_ymd_hms");
            string sqlDropOperatorNote = string.Concat("operator_" + dropRowNumber, "_note");
            string sqlDropOperatorOccupation = string.Concat("operator_" + dropRowNumber, "_occupation");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDropOperatorCode + " = (SELECT " + sqlDragOperatorCode + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         sqlDropOperatorProxyFlag + " = (SELECT " + sqlDragOperatorProxyFlag + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                      sqlDropOperatorRollCallFlag + " = (SELECT " + sqlDragOperatorRollCallFlag + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                    sqlDropOperatorRollCallYmdHms + " = (SELECT " + sqlDragOperatorRollCallYmdHms + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                              sqlDropOperatorNote + " = (SELECT " + sqlDragOperatorNote + " " +
                                                                        "FROM vehicle_dispatch_detail " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                        sqlDropOperatorOccupation + " = (SELECT " + sqlDragOperatorOccupation + " " +
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

        /// <summary>
        /// SetStaff
        /// FlowLayoutPanelEx(右側)からSetControlExへの移動処理
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="dropRowNumber"></param>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public int MoveStaffLabel(DateTime operationDate, int dragCellNumber, int dropCellNumber, int dropRowNumber, StaffMasterVo staffMasterVo) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlDropOperatorCode = string.Concat("operator_code_" + dropRowNumber);
            string sqlDropOperatorProxyFlag = string.Concat("operator_" + dropRowNumber + "_proxy_flag");
            string sqlDropOperatorRollCallFlag = string.Concat("operator_" + dropRowNumber + "_roll_call_flag");
            string sqlDropOperatorRollCallYmdHms = string.Concat("operator_" + dropRowNumber + "_roll_call_ymd_hms");
            string sqlDropOperatorNote = string.Concat("operator_" + dropRowNumber, "_note");
            string sqlDropOperatorOccupation = string.Concat("operator_" + dropRowNumber, "_occupation");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDropOperatorCode + " = (SELECT operator_code " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                         sqlDropOperatorProxyFlag + " = (SELECT operator_proxy_flag " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                      sqlDropOperatorRollCallFlag + " = (SELECT operator_roll_call_flag " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                    sqlDropOperatorRollCallYmdHms + " = (SELECT operator_roll_call_ymd_hms " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                              sqlDropOperatorNote + " = (SELECT operator_note " +
                                                                        "FROM vehicle_dispatch_detail_staff " +
                                                                        "WHERE cell_number = " + dragCellNumber + " AND operator_code = '" + staffMasterVo.Staff_code + "' AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                           sqlDropOperatorOccupation + " = " + staffMasterVo.Occupation + "," +
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
        /// SetStaff
        /// FlowLayoutPanelEx(左側)からSetControlExへの移動処理
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="dropRowNumber"></param>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public int MoveStaffLabel(DateTime operationDate, int dropCellNumber, int dropRowNumber, StaffMasterVo staffMasterVo) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlDropOperatorCode = string.Concat("operator_code_" + dropRowNumber);
            string sqlDropOperatorProxyFlag = string.Concat("operator_" + dropRowNumber + "_proxy_flag");
            string sqlDropOperatorRollCallFlag = string.Concat("operator_" + dropRowNumber + "_roll_call_flag");
            string sqlDropOperatorRollCallYmdHms = string.Concat("operator_" + dropRowNumber + "_roll_call_ymd_hms");
            string sqlDropOperatorNote = string.Concat("operator_" + dropRowNumber, "_note");
            string sqlDropOperatorOccupation = string.Concat("operator_" + dropRowNumber, "_occupation");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDropOperatorCode + " = " + staffMasterVo.Staff_code + "," +
                                         sqlDropOperatorProxyFlag + " = 'False'," +
                                      sqlDropOperatorRollCallFlag + " = 'False'," +
                                    sqlDropOperatorRollCallYmdHms + " = '1900-01-01'," +
                                              sqlDropOperatorNote + " = ''," +
                                        sqlDropOperatorOccupation + " = " + staffMasterVo.Occupation + "," +
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
        public int ResetStaffLabel(DateTime operationDate, int dragCellNumber, int dragRowNumber) {
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
            string sqlDragOperatorRollCallFlag = string.Concat("operator_" + dragRowNumber + "_roll_call_flag");
            string sqlDragOperatorRollCallYmdHms = string.Concat("operator_" + dragRowNumber + "_roll_call_ymd_hms");
            string sqlDragOperatorNote = string.Concat("operator_" + dragRowNumber, "_note");
            string sqlDragOperatorOccupation = string.Concat("operator_" + dragRowNumber, "_occupation");

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlDragOperatorCode + " = 0," +
                                              sqlDragOperatorProxyFlag + " = 'False'," +
                                              sqlDragOperatorRollCallFlag + " = 'False'," +
                                              sqlDragOperatorRollCallYmdHms + " = '1900-01-01 00:00:00'," +
                                              sqlDragOperatorNote + " = ''," +
                                              sqlDragOperatorOccupation + " = 99," +
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
        /// UpdateClassificationFlag
        /// 臨時車に対しての雇上・区契を設定する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="classificationFlag"></param>
        /// <returns></returns>
        public int UpdateClassificationFlag(DateTime operationDate, int dropCellNumber, bool classificationFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET classification_flag = '" + classificationFlag + "'," +
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
        /// UpdateContactInformationFlag
        /// SetControlExに連絡事項あり・なしの枠を付ける
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="contactInformationFlag"></param>
        /// <returns></returns>
        public int UpdateContactInformationFlag(DateTime operationDate, int dropCellNumber, bool contactInformationFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET contact_infomation_flag = '" + contactInformationFlag + "'," +
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
        /// UpdateFaxTransmissionFlag
        /// SetControlExにFax送信あり・なしの枠を付ける
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="faxTransmissionFlag"></param>
        /// <returns></returns>
        public int UpdateFaxTransmissionFlag(DateTime operationDate, int dropCellNumber, bool faxTransmissionFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET fax_transmission_flag = '" + faxTransmissionFlag + "'," +
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
        /// UpdateAddWorkerFlag
        /// 臨時に対しての作業員付きかどうかを設定する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="addWorkerFlag"></param>
        /// <returns></returns>
        public int UpdateAddWorkerFlag(DateTime operationDate, int dropCellNumber, bool addWorkerFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET add_worker_flag = '" + addWorkerFlag + "'," +
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
        /// UpdateGarage
        /// 車庫地を変更
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="garageFlag"></param>
        /// <returns></returns>
        public int UpdateGarageFlag(DateTime operationDate, int dropCellNumber, bool garageFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET garage_flag = '" + garageFlag + "'," +
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
        /// UpdateStandByFlag
        /// 待機を設定する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="standByFlag"></param>
        /// <returns></returns>
        public int UpdateStandByFlag(DateTime operationDate, int dropCellNumber, bool standByFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET stand_by_flag = '" + standByFlag + "'," +
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
        /// UpdateShiftCode
        /// 番手コードを設定する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="shiftCode"></param>
        /// <returns></returns>
        public int UpdateShiftCode(DateTime operationDate, int dropCellNumber, int shiftCode) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dropCellNumber++;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET shift_code = " + shiftCode + "," +
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
        /// UpdateRollCallFlag
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="row"></param>
        /// <param name="rollCallFlag"></param>
        public void UpdateRollCallFlag(DateTime operationDate, int cellNumber, int row, bool rollCallFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;
            /*
             * SetControlExのRowがゼロから始まっているので１をプラスする
             */
            row--;
            /*
             * rollCallFlagを反転する
             */
            rollCallFlag = !rollCallFlag;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlOperatorRollCallFlag = string.Concat("operator_" + row + "_roll_call_flag");
            string sqlOperatorRollCallYmdHms = string.Concat("operator_" + row + "_roll_call_ymd_hms");

            DateTime sqlDateTime = rollCallFlag ? DateTime.Now : new DateTime(1900, 1, 1, 0, 0, 0);

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlOperatorRollCallFlag + " = '" + rollCallFlag + "'," +
                                              sqlOperatorRollCallYmdHms + " = '" + sqlDateTime + "'," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// GetSetNote
        /// 配車先メモを取得する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public string GetSetNote(DateTime operationDate, int cellNumber) {
            string note = string.Empty;
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT set_note " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    note = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_note"]);
                }
            }
            return note;
        }

        /// <summary>
        /// SetSetNote
        /// 配車先メモの登録・修正
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="note"></param>
        public void SetSetNote(DateTime operationDate, int cellNumber, string note) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET set_note = '" + note + "'," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetOperatorNote
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="row"></param>
        /// <param name="note"></param>
        public void SetOperatorNote(DateTime operationDate, int cellNumber, int row, string note) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;
            /*
             * SetControlExのRowがゼロから始まっているので１をプラスする
             */
            row--;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlOperatorNote = string.Concat("operator_" + row + "_note");
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlOperatorNote + " = '" + note + "'," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetCarProxyFlag
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="proxyFlag"></param>
        public void SetCarProxyFlag(DateTime operationDate, int cellNumber, bool proxyFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET car_proxy_flag = '" + proxyFlag + "'," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetStaffProxyFlag
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="row"></param>
        /// <param name="note"></param>
        public void SetStaffProxyFlag(DateTime operationDate, int cellNumber, int row, bool proxyFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;
            /*
             * SetControlExのRowがゼロから始まっているので１をプラスする
             */
            row--;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlProxyFlag = string.Concat("operator_" + row + "_proxy_flag");
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlProxyFlag + " = '" + proxyFlag + "'," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// GetCellNumber
        /// set_codeからcell_numberを取得する
        /// </summary>
        /// <param name="setCode"></param>
        /// <returns></returns>
        public int GetCellNumber(int setCode) {
            int cellNumber = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND set_code = " + setCode;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true)
                    cellNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
            }
            return cellNumber;
        }

        /// <summary>
        /// GetOperatorNote
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        public string GetOperatorNote(DateTime operationDate, int cellNumber, int rowNumber) {
            string note = string.Empty;
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;
            /*
             * TableLayoutPanel上のPointを変換する
             */
            rowNumber--;
            /*
             * Drag項目のSQL文を作成
             */
            string sqlDragOperatorNote = string.Concat("operator_" + rowNumber, "_note");
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT " + sqlDragOperatorNote + " " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    note = _defaultValue.GetDefaultValue<string>(sqlDataReader[sqlDragOperatorNote]);
                }
            }
            return note;
        }

        /// <summary>
        /// GetOperatorFlag
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="operatorCode"></param>
        /// <returns></returns>
        public bool GetOperatorFlag(DateTime operationDate, int cellNumber, int rowNumber) {
            string note = string.Empty;
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;
            /*
             * TableLayoutPanel上のPointを変換する
             */
            rowNumber--;
            /*
             * Drag項目のSQL文を作成
             */
            string sqlDragOperatorFlag = string.Concat("operator_" + rowNumber, "_note");
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT " + sqlDragOperatorFlag + " " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    note = _defaultValue.GetDefaultValue<string>(sqlDataReader[sqlDragOperatorFlag]);
                }
            }
            return note.Length > 0 ? true : false;
        }

        /// <summary>
        /// SetOperationFlag
        /// 配車か休車かを設定
        /// true:配車 false:休車
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="operationFlag"></param>
        public void SetOperationFlag(DateTime operationDate, int cellNumber, bool operationFlag) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET operation_flag = '" + operationFlag + "'," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetLastRollCallFlag
        /// 帰庫点呼に関る情報を更新する
        /// </summary>
        /// <param name="operationDate">配車日</param>
        /// <param name="cellNumber">配車先セル№</param>
        /// <param name="lastRollCallFlag">帰庫点呼フラグ</param>
        /// <param name="lastPlantCount">収集回数</param>
        /// <param name="lastPlantName">最終空け場名</param>
        /// <param name="lastPlantYmdHms">最終空け日時</param>
        /// <param name="lastRollCallYmdHms">帰庫点呼日時</param>
        public void SetLastRollCallFlag(DateTime operationDate, int cellNumber, bool operator1RollCallFlag, DateTime operator1RollCallYmdHms, bool lastRollCallFlag, int lastPlantCount, string lastPlantName, string lastPlantYmdHms, string lastRollCallYmdHms) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;

            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                        "SET operator_1_roll_call_flag = '" + operator1RollCallFlag + "'," +
                                            "operator_1_roll_call_ymd_hms = '" + operator1RollCallYmdHms + "'," +
                                            "last_roll_call_flag = '" + lastRollCallFlag + "'," +
                                            "last_plant_count = " + lastPlantCount + "," +
                                            "last_plant_name = '" + lastPlantName + "'," +
                                            "last_plant_ymd_hms = '" + lastPlantYmdHms + "'," +
                                            "last_roll_call_ymd_hms = '" + lastRollCallYmdHms + "'," +
                                            "update_pc_name = '" + Environment.MachineName + "'," +
                                            "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdatePayFlag
        /// true:運転手 false:作業員
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <param name="row"></param>
        /// <param name="payFlag">true:運転手 false:作業員</param>
        public void UpdateOccupation(DateTime operationDate, int cellNumber, int row, int occupation) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            cellNumber++;
            /*
             * SetControlExのRowがゼロから始まっているので１をプラスする
             */
            row--;
            /*
             * Drop項目のSQL文を作成
             */
            string sqlOperatorOccupation = string.Concat("operator_" + row + "_occupation");

            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail " +
                                     "SET " + sqlOperatorOccupation + " = " + occupation + "," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// GetStaffCode
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber">SetControlEx.Tagから取得している。０から１４９まで</param>
        /// <param name="staffCellNumber">1:運転手 2:作業員１ 3:作業員２ 4:作業員３</param>
        /// <returns></returns>
        public int GetStaffCodeTableLayoutPanelEx(DateTime operationDate, int cellNumber, int staffCellNumber) {
            string sqlOperatorCode = string.Empty;
            string sqlTableName = string.Empty;
            switch(cellNumber) {
                case int i when i <= 149: // CellNumber 1～150
                    switch(staffCellNumber) {
                        case 1: // 運転手
                            sqlOperatorCode = "operator_code_1";
                            sqlTableName = "vehicle_dispatch_detail";
                            break;
                        case 2: // 作業員１
                            sqlOperatorCode = "operator_code_2";
                            sqlTableName = "vehicle_dispatch_detail";
                            break;
                        case 3: // 作業員２
                            sqlOperatorCode = "operator_code_3";
                            sqlTableName = "vehicle_dispatch_detail";
                            break;
                        case 4: // 作業員３
                            sqlOperatorCode = "operator_code_4";
                            sqlTableName = "vehicle_dispatch_detail";
                            break;
                    }
                    break;
                case int i when i <= 167: // CellNumber 150～168
                    sqlOperatorCode = "operator_code";
                    sqlTableName = "vehicle_dispatch_detail_staff";
                    break;
            }

            cellNumber++;

            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT " + sqlOperatorCode + " " +
                                     "FROM " + sqlTableName + " " +
                                     "WHERE cell_number = " + cellNumber + " " +
                                       "AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            return (int)sqlCommand.ExecuteScalar();
        }

        /// <summary>
        /// GetStaffExistFlowLayoutPanelEx
        /// FlowLayoutPanelEx上にStaffLabelが存在するかを確認する
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="staffCode"></param>
        /// <returns>true:レコードあり false:レコードなし</returns>
        public bool GetStaffExistFlowLayoutPanelEx(DateTime operationDate, int cellNumber, int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(operator_code) " +
                                     "FROM vehicle_dispatch_detail_staff " +
                                     "WHERE cell_number = " + cellNumber + " " +
                                       "AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "' " +
                                       "AND operator_code = " + staffCode;
            return (int)sqlCommand.ExecuteScalar() > 0 ? true : false;
        }
    }
}
