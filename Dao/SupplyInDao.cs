/*
 * 2023-07-14
 */
using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class SupplyInDao {
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public SupplyInDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;

        }

        /// <summary>
        /// SelectSupplyMove
        /// </summary>
        /// <param name="dateTime">入庫年月日</param>
        /// <param name="supplyCode">備品区分</param>
        /// <returns>画面表示用Vo</returns>
        public List<SupplyScreenVo> SelectSupplyMove(DateTime dateTime, int supplyType) {
            int startCode = 0;
            int endCode = 0;
            switch(supplyType) {
                case 1:
                    startCode = 10000;
                    endCode = 19999;
                    break;
                case 2:
                    startCode = 20000;
                    endCode = 29999;
                    break;
                case 3:
                    startCode = 30000;
                    endCode = 39999;
                    break;
                case 4:
                    startCode = 40000;
                    endCode = 49999;
                    break;
            }
            List<SupplyScreenVo> listSupplyInScreenVo = new List<SupplyScreenVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT supply_master.code," +
                                            "supply_master.name," +
                                            "supply_move.supply_number," +
                                            "supply_move.memo " +
                                     "FROM supply_master " +
                                     "LEFT OUTER JOIN supply_move ON supply_master.code = supply_move.supply_code " +
                                                 "AND supply_move.move_date BETWEEN '" + dateTime.ToString("yyyy-MM-dd") + "' AND '" + dateTime.ToString("yyyy-MM-dd") + "' " +
                                                 "AND supply_move.move_flag = 'true' " +
                                     "WHERE supply_master.code BETWEEN " + startCode + " AND " + endCode + " " +
                                     "ORDER BY supply_master.code ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    SupplyScreenVo supplyInVo = new SupplyScreenVo();
                    supplyInVo.SupplyCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    supplyInVo.SupplyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    supplyInVo.SupplyCount = _defaultValue.GetDefaultValue<int>(sqlDataReader["supply_number"]);
                    supplyInVo.Memo = _defaultValue.GetDefaultValue<string>(sqlDataReader["memo"]);
                    listSupplyInScreenVo.Add(supplyInVo);
                }
            }
            return listSupplyInScreenVo;
        }

        /// <summary>
        /// InsertSupplyMove
        /// </summary>
        /// <param name="supplyMoveVo"></param>
        /// <returns></returns>
        public int InsertSupplyMove(SupplyMoveVo supplyMoveVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO supply_move(staff_code," +
                                                             "move_date," +
                                                             "supply_code," +
                                                             "supply_number," +
                                                             "move_flag," +
                                                             "memo," +
                                                             "insert_pc_name," +
                                                             "insert_ymd_hms," +
                                                             "update_pc_name," +
                                                             "update_ymd_hms," +
                                                             "delete_pc_name," +
                                                             "delete_ymd_hms," +
                                                             "delete_flag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(supplyMoveVo.Staff_code) + "," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(supplyMoveVo.Move_date) + "'," +
                                             "" + _defaultValue.GetDefaultValue<int>(supplyMoveVo.Supply_code) + "," +
                                             "" + _defaultValue.GetDefaultValue<int>(supplyMoveVo.Supply_number) + "," +
                                            "'true'," + // true→入庫
                                            "'" + _defaultValue.GetDefaultValue<string>(supplyMoveVo.Memo) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(supplyMoveVo.Insert_pc_name) + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(supplyMoveVo.Update_pc_name) + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(supplyMoveVo.Delete_pc_name) + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'False'" +
                                            ");";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteSupplyMove
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int DeleteSupplyMove(DateTime dateTime) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM supply_move " +
                                     "WHERE move_date BETWEEN '" + dateTime.ToString("yyyy-MM-dd") + "' AND '" + dateTime.ToString("yyyy-MM-dd") + "' " +
                                       "AND move_flag = 'true'"; // true→入庫
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
