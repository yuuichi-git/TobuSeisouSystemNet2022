using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchDetailStaffDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public VehicleDispatchDetailStaffDao(ConnectionVo connection) {
            _connectionVo = connection;
        }

        /// <summary>
        /// InsertVehicleDispatchDetailTableLayoutPanel
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

        public int UpdateStaff(DateTime operationDate, int dragCellNumber, int dragOperatorCode, string dropCellNumber) {
            /*
             * Tagがゼロから始まっているので１をプラスする
             */
            dragCellNumber++;

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
        /// DeleteVehicleDispatchDetailTableLayoutPanel
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
    }
}
