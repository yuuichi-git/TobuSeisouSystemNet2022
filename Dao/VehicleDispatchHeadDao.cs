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
        /// CheckVehicleDispatchHead
        /// 該当レコードの存在チェック
        /// </summary>
        /// <param name="financialYear"></param>
        /// <returns></returns>
        public bool CheckVehicleDispatchHead(DateTime financialYear) {
            int count;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(cell_number) " +
                                     "FROM vehicle_dispatch_head " +
                                     "WHERE financial_year = '" + financialYear.ToString("yyyy-04-01") + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count == 150 ? true : false;
        }

        /// <summary>
        /// SelectAllVehicleDispatchMasterVo
        /// </summary>
        /// <returns></returns>
        public List<VehicleDispatchHeadVo> SelectAllVehicleDispatchHeadVo(DateTime financial_year) {
            var listVehicleDispatchHeadVo = new List<VehicleDispatchHeadVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT cell_number," +
                                            "garage_flag," +
                                            "five_lap," +
                                            "day_of_week," +
                                            "set_code," +
                                            "car_code," +
                                            "number_of_people," +
                                            "financial_year," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM vehicle_dispatch_head " +
                                     "WHERE financial_year = '" + financial_year.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var setVehicleDispatchHeadVo = new VehicleDispatchHeadVo();
                    setVehicleDispatchHeadVo.Cell_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["cell_number"]);
                    setVehicleDispatchHeadVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    setVehicleDispatchHeadVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    setVehicleDispatchHeadVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    setVehicleDispatchHeadVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    setVehicleDispatchHeadVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    setVehicleDispatchHeadVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    setVehicleDispatchHeadVo.Financial_year = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["financial_year"]);
                    setVehicleDispatchHeadVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    setVehicleDispatchHeadVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    setVehicleDispatchHeadVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    setVehicleDispatchHeadVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listVehicleDispatchHeadVo.Add(setVehicleDispatchHeadVo);
                }
            }
            return listVehicleDispatchHeadVo;
        }

        /// <summary>
        /// InsertVehicleDispatchHead
        /// 新規年度のニュートラルレコードを挿入
        /// </summary>
        /// <param name="financial_year"></param>
        public void InsertVehicleDispatchHead(DateTime financial_year) {
            int cellNumber = 1;
            string sqlString = "";
            for(int i = 0; i < 150; i++) {
                sqlString += "(" + cellNumber + "," +
                             "NULL," +
                             "NULL," +
                             "NULL," +
                             "NULL," +
                             "NULL," +
                             "NULL," +
                             "'" + financial_year.ToString("yyyy-04-01") + "'," +
                             "'" + DateTime.Now.Date + "'," +
                             "'" + new DateTime(1900, 01, 01) + "'," +
                             "'" + new DateTime(1900, 01, 01) + "'," +
                             "'False')";
                if(cellNumber < 150)
                    sqlString += ",";
                cellNumber++;
            }
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO vehicle_dispatch_head(cell_number," +
                                                                       "garage_flag," +
                                                                       "five_lap," +
                                                                       "day_of_week," +
                                                                       "set_code," +
                                                                       "car_code," +
                                                                       "number_of_people," +
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
        /// UpdateVehicleDispatchHead
        /// 
        /// </summary>
        /// <param name="cell_number"></param>
        /// <param name="financial_year"></param>
        public void UpdateVehicleDispatchHead(int cell_number, DateTime financial_year, SetMasterVo setMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_head " +
                                     "SET garage_flag = '" + setMasterVo.Garage_flag + "'," +
                                         "five_lap = '" + setMasterVo.Five_lap + "'," +
                                         "move_flag = '" + setMasterVo.Move_flag + "'," +
                                         "day_of_week = '" + setMasterVo.Working_days + "'," +
                                         "set_code = " + setMasterVo.Set_code + "," +
                                         "car_code = NULL," +
                                         "number_of_people = " + setMasterVo.Number_of_people + "," +
                                         "update_ymd_hms = '" + DateTime.Now.Date + "' " +
                                     "WHERE cell_number = " + cell_number + " AND financial_year = '" + financial_year.ToString("yyyy-04-01") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// ResetVehicleDispatchHead
        /// レコードの値を初期化する
        /// </summary>
        /// <param name="cell_number"></param>
        /// <param name="financial_year"></param>
        public void ResetVehicleDispatchHead(int cell_number, DateTime financial_year) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE vehicle_dispatch_head " +
                                     "SET garage_flag = NULL," +
                                         "five_lap = NULL," +
                                         "move_flag = NULL," +
                                         "day_of_week = NULL," +
                                         "set_code = NULL," +
                                         "car_code = NULL," +
                                         "number_of_people = NULL," +
                                         "insert_ymd_hms = '" + DateTime.Now.Date + "'," +
                                         "update_ymd_hms = '" + new DateTime(1900, 01, 01) + "'," +
                                         "delete_ymd_hms = '" + new DateTime(1900, 01, 01) + "'," +
                                         "delete_flag = 'False' " +
                                     "WHERE cell_number = " + cell_number + " AND financial_year = '" + financial_year.ToString("yyyy-04-01") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
