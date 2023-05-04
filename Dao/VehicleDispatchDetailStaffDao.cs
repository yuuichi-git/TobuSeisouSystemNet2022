using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchDetailStaffDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connection"></param>
        public VehicleDispatchDetailStaffDao(ConnectionVo connection) {
            _connectionVo = connection;
        }

        /// <summary>
        /// SelectVehicleDispatchDetailStaff
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<VehicleDispatchDetailStaffVo> SelectVehicleDispatchDetailStaff(DateTime operationDate) {
            var listVehicleDispatchDetailStaff = new List<VehicleDispatchDetailStaffVo>();
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
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx = new VehicleDispatchDetailStaffVo();
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
                    listVehicleDispatchDetailStaff.Add(vehicleDispatchDetailFlowLayoutPanel_StaffLabelEx);
                }
            }
            return listVehicleDispatchDetailStaff;
        }

        /// <summary>
        /// InsertStaff
        /// vehicle_dispatch_detailからvehicle_dispatch_detail_staffへのINSERT
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragRowNumber"></param>
        /// <param name="dropCellNumber">Tagに埋めてあるのでそのまま利用できる</param>
        /// <returns></returns>
        public int InsertStaff(DateTime operationDate, int dragCellNumber, int dragRowNumber, int dropCellNumber) {
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
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_detail_staff(cell_number," +
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
                                                                               "delete_flag) " +
                                     "VALUES (" + dropCellNumber + "," +
                                            "'" + operationDate.ToString("yyyy-MM-dd") + "'," +
                                            "(SELECT " + sqlDragOperatorCode + " FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                            "(SELECT " + sqlDragOperatorProxyFlag + " FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                            "(SELECT " + sqlDragOperatorRollCallYmdHms + " FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "')," +
                                            "(SELECT " + sqlDragOperatorNote + " FROM vehicle_dispatch_detail WHERE cell_number = " + dragCellNumber + " AND operation_date =  '" + operationDate.ToString("yyyy-MM-dd") + "')," +
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
        /// InsertNewStaff
        /// FlowLayoutPanelExFullEmployees FlowLayoutPanelExLongTerm FlowLayoutPanelExPartTime FlowLayoutPanelExWindowからの移動だから新規レコードを作成
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dropCellNumber"></param>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public int InsertNewStaff(DateTime operationDate, int dropCellNumber, int staffCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_detail_staff(cell_number," +
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
                                                                               "delete_flag) " +
                                     "VALUES (" + dropCellNumber + "," +
                                            "'" + operationDate.ToString("yyyy-MM-dd") + "'," +
                                            staffCode + "," +
                                            "'False'," +
                                            "'1900-01-01'," +
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
        /// UpdateStaff
        /// vehicle_dispatch_detail_staffからvehicle_dispatch_detail_staffへのUPDATE
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragOperatorCode"></param>
        /// <param name="dropCellNumber"></param>
        /// <returns></returns>
        public int UpdateStaff(DateTime operationDate, int dragCellNumber, int dragOperatorCode, int dropCellNumber) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail_staff " +
                                     "SET cell_number = '" + dropCellNumber + "'," +
                                         "update_pc_name = '" + Environment.MachineName + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE cell_number = " + dragCellNumber + " AND operator_code = " + dragOperatorCode + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteStaff
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public int DeleteStaff(DateTime operationDate) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM vehicle_dispatch_detail_staff " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteStaff
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="dragCellNumber"></param>
        /// <param name="dragOperatorCode"></param>
        /// <returns></returns>
        public int DeleteStaff(DateTime operationDate, int dragCellNumber, int dragOperatorCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM vehicle_dispatch_detail_staff " +
                                     "WHERE cell_number = " + dragCellNumber + " AND operator_code = " + dragOperatorCode + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SetOperatorNote
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="operatorCode"></param>
        /// <param name="row"></param>
        /// <param name="note"></param>
        public void SetOperatorNote(DateTime operationDate, int operatorCode, string note) {
            /*
             * Drop項目のSQL文を作成
             */
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_detail_staff " +
                                     "SET operator_note = '" + note + "'," +
                                          "update_pc_name = '" + Environment.MachineName + "'," +
                                          "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE operator_code = " + operatorCode + " AND operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// GetOperatorNote
        /// </summary>
        /// <param name="operationDate"></param>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public string GetOperatorNote(DateTime operationDate, int cellNumber, int operatorCode) {
            string note = string.Empty;
            /*
             * Drag項目のSQL文を作成
             */
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operator_note " +
                                     "FROM vehicle_dispatch_detail_staff " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.Date + "' AND operator_code = " + operatorCode;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_note"]);
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
        public bool GetOperatorFlag(DateTime operationDate, int cellNumber, int operatorCode) {
            string note = string.Empty;
            /*
             * Drag項目のSQL文を作成
             */
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operator_note " +
                                     "FROM vehicle_dispatch_detail_staff " +
                                     "WHERE cell_number = " + cellNumber + " AND operation_date = '" + operationDate.Date + "' AND operator_code = " + operatorCode;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    note = _defaultValue.GetDefaultValue<string>(sqlDataReader["operator_note"]);
                }
            }
            return note.Length > 0 ? true : false;
        }


    }
}
