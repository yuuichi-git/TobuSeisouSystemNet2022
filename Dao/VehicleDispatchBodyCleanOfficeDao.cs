using Common;

using H_Vo;

namespace Dao {
    public class VehicleDispatchBodyCleanOfficeDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public VehicleDispatchBodyCleanOfficeDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectAllVehicleDispatchBodyVo
        /// </summary>
        /// <returns></returns>
        public List<VehicleDispatchBodyVo> SelectAllVehicleDispatchBodyVo(DateTime financial_year) {
            var listVehicleDispatchBodyVo = new List<VehicleDispatchBodyVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "day_of_week," +
                                            "car_code," +
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
                                     "FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE financial_year = '" + financial_year.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    VehicleDispatchBodyVo setVehicleDispatchBodyVo = new VehicleDispatchBodyVo();
                    setVehicleDispatchBodyVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    setVehicleDispatchBodyVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    setVehicleDispatchBodyVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
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

        /// <summary>
        /// InsertVehicleDispatchBodyVo
        /// </summary>
        /// <param name="productionListVo"></param>
        public void InsertVehicleDispatchBodyVo(ProductionListVo productionListVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_body_clean_office (cell_number," +
                                                                                     "day_of_week," +
                                                                                     "car_code," +
                                                                                     "operator_code_1," +
                                                                                     "operator_code_2," +
                                                                                     "operator_code_3," +
                                                                                     "operator_code_4," +
                                                                                     "note," +
                                                                                     "financial_year," +
                                                                                     "insert_ymd_hms," +
                                                                                     "update_ymd_hms," +
                                                                                     "delete_ymd_hms," +
                                                                                     "delete_flag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<int>(productionListVo.Cell_number) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(productionListVo.Day_of_week) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(productionListVo.Car_code) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_1) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_2) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_3) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_4) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(productionListVo.Note) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Financial_year) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Insert_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Update_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Delete_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<bool>(productionListVo.Delete_flag) + "')";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// InsertVehicleDispatchBodyVo
        /// 複数レコード一括INSERT
        /// </summary>
        /// <param name="listProductionListVo"></param>
        public void InsertVehicleDispatchBodyVo(List<ProductionListVo> listProductionListVo) {
            int count = 1;
            string sqlString = "";
            foreach(var productionListVo in listProductionListVo) {
                sqlString += "(" + _defaultValue.GetDefaultValue<int>(productionListVo.Cell_number) + "," +
                             "'" + _defaultValue.GetDefaultValue<string>(productionListVo.Day_of_week) + "'," +
                                   _defaultValue.GetDefaultValue<int>(productionListVo.Car_code) + "," +
                                   _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_1) + "," +
                                   _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_2) + "," +
                                   _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_3) + "," +
                                   _defaultValue.GetDefaultValue<int>(productionListVo.Operator_code_4) + "," +
                             "'" + _defaultValue.GetDefaultValue<string>(productionListVo.Note) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Financial_year) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Insert_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Update_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(productionListVo.Delete_ymd_hms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(productionListVo.Delete_flag) + "')";
                if(count < listProductionListVo.Count)
                    sqlString += ",";
                count++;
            }
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_body_clean_office(" +
                                                 "cell_number," +
                                                 "day_of_week," +
                                                 "car_code," +
                                                 "operator_code_1," +
                                                 "operator_code_2," +
                                                 "operator_code_3," +
                                                 "operator_code_4," +
                                                 "note," +
                                                 "financial_year," +
                                                 "insert_ymd_hms," +
                                                 "update_ymd_hms," +
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
        /// DeleteVehicleDispatchBodyVo
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="financialYear"></param>
        public void DeleteVehicleDispatchBodyVo(int cellNumber, DateTime financialYear) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE cell_number = '" + cellNumber + "' AND financial_year = '" + financialYear + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// GetCarCode
        /// cell_numberからcar_codeを取得する
        /// 現時点での会計年度で計算される
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public int GetCarCode(int cellNumber) {
            int carCode = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT car_code " +
                                     "FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE cell_number = '" + cellNumber + "' AND financial_year = '" + DateTime.Now.AddMonths(-3).ToString("yyyy-04-01") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true)
                    carCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
            }
            return carCode;
        }

        /// <summary>
        /// GetOperatorCode1
        /// 現時点での会計年度で計算される
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public int GetOperatorCode1(int cellNumber) {
            int operatorCode = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operator_code_1 " +
                                     "FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE cell_number = " + cellNumber + " AND financial_year = '" + DateTime.Now.AddMonths(-3).ToString("yyyy-04-01") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true)
                    operatorCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_1"]);
            }
            return operatorCode;
        }

        /// <summary>
        /// GetOperatorCode2
        /// 現時点での会計年度で計算される
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public int GetOperatorCode2(int cellNumber) {
            int operatorCode = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operator_code_2 " +
                                     "FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE cell_number = '" + cellNumber + "' AND financial_year = '" + DateTime.Now.AddMonths(-3).ToString("yyyy-04-01") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true)
                    operatorCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_2"]);
            }
            return operatorCode;
        }

        /// <summary>
        /// GetOperatorCode3
        /// 現時点での会計年度で計算される
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public int GetOperatorCode3(int cellNumber) {
            int operatorCode = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operator_code_3 " +
                                     "FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE cell_number = '" + cellNumber + "' AND financial_year = '" + DateTime.Now.AddMonths(-3).ToString("yyyy-04-01") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true)
                    operatorCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_3"]);
            }
            return operatorCode;
        }

        /// <summary>
        /// GetOperatorCode4
        /// 現時点での会計年度で計算される
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public int GetOperatorCode4(int cellNumber) {
            int operatorCode = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operator_code_4 " +
                                     "FROM vehicle_dispatch_body_clean_office " +
                                     "WHERE cell_number = '" + cellNumber + "' AND financial_year = '" + DateTime.Now.AddMonths(-3).ToString("yyyy-04-01") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true)
                    operatorCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["operator_code_4"]);
            }
            return operatorCode;
        }
    }
}
