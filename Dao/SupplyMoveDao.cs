/*
 * 2023-06-05
 */
using System.Data.SqlClient;

using Vo;

namespace Dao {
    public class SupplyMoveDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public SupplyMoveDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// InsertOneSupplyMove
        /// </summary>
        /// <param name="supplyMoveVo"></param>
        public void InsertOneSupplyMove(SupplyMoveVo supplyMoveVo) {
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
                                     "VALUES (" + supplyMoveVo.Staff_code + "," +
                                            "'" + supplyMoveVo.Move_date + "'," +
                                             "" + supplyMoveVo.Supply_code + "," +
                                             "" + supplyMoveVo.Supply_number + "," +
                                            "'" + supplyMoveVo.Move_flag + "'," +
                                            "'" + supplyMoveVo.Memo + "'," +
                                            "'" + supplyMoveVo.Insert_pc_name + "'," +
                                            "'" + supplyMoveVo.Insert_ymd_hms + "'," +
                                            "'" + supplyMoveVo.Update_pc_name + "'," +
                                            "'" + supplyMoveVo.Update_ymd_hms + "'," +
                                            "'" + supplyMoveVo.Delete_pc_name + "'," +
                                            "'" + supplyMoveVo.Delete_ymd_hms + "'," +
                                            "'" + supplyMoveVo.Delete_flag + "'" +
                                            ");";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
