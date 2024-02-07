using Common;

using H_Vo;

namespace Dao {
    public class StaffExcelDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public StaffExcelDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// CheckStaffMasterExcel1
        /// レコードの存在確認
        /// </summary>
        /// <returns></returns>
        public bool CheckStaffMasterExcel1(int row) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 * " +
                                     "FROM staff_master_excel_1 " +
                                     "WHERE row = " + row;
            using var sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader.Read() == true;
        }

        /// <summary>
        /// CheckStaffMasterExcel2
        /// レコードの存在確認
        /// </summary>
        /// <returns></returns>
        public bool CheckStaffMasterExcel2(int row) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 * " +
                                     "FROM staff_master_excel_2 " +
                                     "WHERE row = " + row;
            using var sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader.Read() == true;
        }

        /// <summary>
        /// SelectStaffMasterExcel1
        /// </summary>
        /// <returns></returns>
        public List<StaffMasterExcelVo> SelectStaffMasterExcel1() {
            var listStaffPartMasterVo = new List<StaffMasterExcelVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT row," +
                                            "code," +
                                            "display_name," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM staff_master_excel_1";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    StaffMasterExcelVo staffPartMasterVo = new StaffMasterExcelVo();
                    staffPartMasterVo.Row = _defaultValue.GetDefaultValue<int>(sqlDataReader["row"]);
                    staffPartMasterVo.Code = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    staffPartMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    staffPartMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    staffPartMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    staffPartMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    staffPartMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listStaffPartMasterVo.Add(staffPartMasterVo);
                }
            }
            return listStaffPartMasterVo;
        }

        /// <summary>
        /// SelectStaffMasterExcel2
        /// </summary>
        /// <returns></returns>
        public List<StaffMasterExcelVo> SelectStaffMasterExcel2() {
            var listStaffPartMasterVo = new List<StaffMasterExcelVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT row," +
                                            "code," +
                                            "display_name," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM staff_master_excel_2";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    StaffMasterExcelVo staffPartMasterVo = new StaffMasterExcelVo();
                    staffPartMasterVo.Row = _defaultValue.GetDefaultValue<int>(sqlDataReader["row"]);
                    staffPartMasterVo.Code = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    staffPartMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    staffPartMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    staffPartMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    staffPartMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    staffPartMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listStaffPartMasterVo.Add(staffPartMasterVo);
                }
            }
            return listStaffPartMasterVo;
        }

        /// <summary>
        /// InsertStaffMasterExcel1
        /// </summary>
        /// <param name="staffMasterExcelVo"></param>
        public void InsertStaffMasterExcel1(StaffMasterExcelVo staffMasterExcelVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO staff_master_excel_1(row," +
                                                                      "code," +
                                                                      "display_name," +
                                                                      "insert_ymd_hms," +
                                                                      "update_ymd_hms," +
                                                                      "delete_ymd_hms," +
                                                                      "delete_flag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<int>(staffMasterExcelVo.Row) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(staffMasterExcelVo.Code) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(staffMasterExcelVo.Display_name) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(staffMasterExcelVo.Insert_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(staffMasterExcelVo.Update_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(staffMasterExcelVo.Delete_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<bool>(staffMasterExcelVo.Delete_flag) + "')";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// InsertStaffMasterExcel2
        /// </summary>
        /// <param name="staffMasterExcelVo"></param>
        public void InsertStaffMasterExcel2(StaffMasterExcelVo staffMasterExcelVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO staff_master_excel_2(row," +
                                                                      "code," +
                                                                      "display_name," +
                                                                      "insert_ymd_hms," +
                                                                      "update_ymd_hms," +
                                                                      "delete_ymd_hms," +
                                                                      "delete_flag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<int>(staffMasterExcelVo.Row) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(staffMasterExcelVo.Code) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(staffMasterExcelVo.Display_name) + "'," +
                                             "'" + DateTime.Now + "'," +
                                             "'1900-01-01'," +
                                             "'1900-01-01'," +
                                             "'False')";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateStaffMasterExcel1
        /// </summary>
        /// <param name="staffMasterExcelVo"></param>
        public void UpdateStaffMasterExcel1(StaffMasterExcelVo staffMasterExcelVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE staff_master_excel_1 " +
                                     "SET code = " + staffMasterExcelVo.Code + "," +
                                         "display_name = '" + staffMasterExcelVo.Display_name + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE row = " + staffMasterExcelVo.Row;
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateStaffMasterExcel2
        /// </summary>
        /// <param name="staffMasterExcelVo"></param>
        public void UpdateStaffMasterExcel2(StaffMasterExcelVo staffMasterExcelVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE staff_master_excel_2 " +
                                     "SET code = " + staffMasterExcelVo.Code + "," +
                                         "display_name = '" + staffMasterExcelVo.Display_name + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE row = " + staffMasterExcelVo.Row;
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteStaffMasterExcel1
        /// </summary>
        /// <param name="staffMasterExcelVo"></param>
        public void DeleteStaffMasterExcel1(StaffMasterExcelVo staffMasterExcelVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM staff_master_excel_1 " +
                                     "WHERE row = " + staffMasterExcelVo.Row;
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteStaffMasterExcel2
        /// </summary>
        /// <param name="staffMasterExcelVo"></param>
        public void DeleteStaffMasterExcel2(StaffMasterExcelVo staffMasterExcelVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM staff_master_excel_2 " +
                                     "WHERE row = " + staffMasterExcelVo.Row;
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectAllVehicleDispatchDetailVo
        /// 指定された
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailVo> SelectAllVehicleDispatchDetailVo(DateTime operationDate) {
            // 指定月の最終日を算出する
            int daysInMonth = DateTime.DaysInMonth(operationDate.Year, operationDate.Month);
            List<VehicleDispatchDetailVo> listVehicleDispatchDetailVo = new List<VehicleDispatchDetailVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operation_date," +
                                            "set_code," +
                                            "operator_code_1," +
                                            "operator_code_2," +
                                            "operator_code_3," +
                                            "operator_code_4 " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date BETWEEN '" + operationDate.ToString("yyyy-MM") + "-01' AND '" + operationDate.ToString("yyyy-MM") + daysInMonth.ToString("-00") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailVo = new VehicleDispatchDetailVo();
                    vehicleDispatchDetailVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    vehicleDispatchDetailVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    vehicleDispatchDetailVo.Operator_code_1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
                    vehicleDispatchDetailVo.Operator_code_2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
                    vehicleDispatchDetailVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
                    vehicleDispatchDetailVo.Operator_code_4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
                    listVehicleDispatchDetailVo.Add(vehicleDispatchDetailVo);
                }
            }
            return listVehicleDispatchDetailVo;
        }
    }
}
