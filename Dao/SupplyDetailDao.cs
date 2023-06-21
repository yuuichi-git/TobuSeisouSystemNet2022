/*
 * 2023-06-20
 */
using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class SupplyDetailDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public SupplyDetailDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectSupplyDetailVo
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <param name="supplyCode"></param>
        /// <returns></returns>
        public List<SupplyDetailVo> SelectSupplyDetailVo(DateTime dateTime1, DateTime dateTime2, int supplyCode) {
            List<SupplyDetailVo> listSupplyDetailVo = new List<SupplyDetailVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT supply_move.move_date," +
                                            "supply_move.staff_code," +
                                            "staff_master.display_name," +
                                            "supply_move.supply_code," +
                                            "supply_master.name," +
                                            "supply_move.supply_number " +
                                     "FROM supply_move " +
                                     "LEFT OUTER JOIN staff_master ON supply_move.staff_code = staff_master.staff_code " +
                                     "LEFT OUTER JOIN supply_master ON supply_move.supply_code = supply_master.code " +
                                     "WHERE (supply_move.move_date BETWEEN '" + dateTime1.ToString("yyyy-MM-dd") + "' AND '" + dateTime2.ToString("yyyy-MM-dd") + "') " +
                                        "AND supply_move.supply_code = '" + supplyCode + "'" +
                                        "AND supply_move.move_flag = 'false'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    SupplyDetailVo supplyDetailVo = new SupplyDetailVo();
                    supplyDetailVo.MoveDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["move_date"]);
                    supplyDetailVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    supplyDetailVo.StaffName = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    supplyDetailVo.SupplyCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["supply_code"]);
                    supplyDetailVo.SupplyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    supplyDetailVo.MoveNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["supply_number"]);
                    listSupplyDetailVo.Add(supplyDetailVo);
                }
            }
            return listSupplyDetailVo;
        }
    }
}
