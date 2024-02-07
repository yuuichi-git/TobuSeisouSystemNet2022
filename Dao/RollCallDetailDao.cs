using Common;

using H_Vo;

namespace Dao {
    public class RollCallDetailDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        public RollCallDetailDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        public int CheckRollCallDetail(DateTime operationDate) {
            int count = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(operation_date) " +
                                     "FROM roll_call_detail " +
                                     "WHERE operation_date = '" + operationDate.Date + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count;
        }

        /// <summary>
        /// InsertOneRollCallDetail
        /// </summary>
        /// <param name="rollCallDetailVo"></param>
        public void InsertOneRollCallDetail(RollCallDetailVo rollCallDetailVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO roll_call_detail(operation_date," +
                                                                  "roll_coll_name_1," +
                                                                  "roll_coll_name_2," +
                                                                  "roll_coll_name_3," +
                                                                  "roll_coll_name_4," +
                                                                  "roll_coll_name_5," +
                                                                  "weather," +
                                                                  "instruction1," +
                                                                  "instruction2," +
                                                                  "insert_ymd_hms," +
                                                                  "update_ymd_hms," +
                                                                  "delete_ymd_hms," +
                                                                  "delete_flag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<DateTime>(rollCallDetailVo.Operation_date) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_1) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_2) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_3) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_4) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_5) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Weather) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Instruction1) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Instruction2) + "'," +
                                             "'" + DateTime.Now + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'False'" +
                                             ");";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneRollCallDetail
        /// </summary>
        /// <param name="rollCallDetailVo"></param>
        public void UpdateOneRollCallDetail(RollCallDetailVo rollCallDetailVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE roll_call_detail " +
                                     "SET roll_coll_name_1 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_1) + "'," +
                                         "roll_coll_name_2 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_2) + "'," +
                                         "roll_coll_name_3 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_3) + "'," +
                                         "roll_coll_name_4 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_4) + "'," +
                                         "roll_coll_name_5 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Roll_call_name_5) + "'," +
                                         "weather = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Weather) + "'," +
                                         "instruction1 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Instruction1) + "'," +
                                         "instruction2 = '" + _defaultValue.GetDefaultValue<string>(rollCallDetailVo.Instruction2) + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE operation_date = '" + rollCallDetailVo.Operation_date.Date + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectOneRollCallDetail
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public RollCallDetailVo? SelectOneRollCallDetail(DateTime operationDate) {
            RollCallDetailVo? rollCallDetailVo = null;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operation_date," +
                                            "roll_coll_name_1," +
                                            "roll_coll_name_2," +
                                            "roll_coll_name_3," +
                                            "roll_coll_name_4," +
                                            "roll_coll_name_5," +
                                            "weather," +
                                            "instruction1," +
                                            "instruction2," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM roll_call_detail " +
                                     "WHERE operation_date = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    rollCallDetailVo = new();
                    rollCallDetailVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    rollCallDetailVo.Roll_call_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["roll_coll_name_1"]);
                    rollCallDetailVo.Roll_call_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["roll_coll_name_2"]);
                    rollCallDetailVo.Roll_call_name_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["roll_coll_name_3"]);
                    rollCallDetailVo.Roll_call_name_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["roll_coll_name_4"]);
                    rollCallDetailVo.Roll_call_name_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["roll_coll_name_5"]);
                    rollCallDetailVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["weather"]);
                    rollCallDetailVo.Instruction1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["instruction1"]);
                    rollCallDetailVo.Instruction2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["instruction2"]);
                    rollCallDetailVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    rollCallDetailVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    rollCallDetailVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    rollCallDetailVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
            }
            return rollCallDetailVo;
        }
    }
}
