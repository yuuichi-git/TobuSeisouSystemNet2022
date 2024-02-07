/*
 * 2023-06-05
 */
using System.Data.SqlClient;

using Common;

using H_Vo;

namespace Dao {
    public class SupplyListDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public SupplyListDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectSupplyListVo
        /// </summary>
        /// <param name="dateTime1">開始日</param>
        /// <param name="dateTime2">終了日</param>
        /// <param name="supplyType">在庫種別</param>
        /// <returns></returns>
        public List<SupplyListVo> SelectSupplyListVo(DateTime dateTime1, DateTime dateTime2, int supplyType) {
            /*
             * 備品コードの範囲を調整する
             */
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

            List<SupplyListVo> listSupplyListVo = new List<SupplyListVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT supply_master.code," +
                                            "supply_master.name," +
                                            "supply_master.proper_stock AS m_proper_stock," +
                                            "supply_inventory.proper_stock AS i_proper_stock," +
                                            "(SELECT SUM(supply_number) FROM supply_move " + // サブクエリ１
                                             "WHERE (move_date BETWEEN '" + dateTime1.ToString("yyyy-MM-dd") + "' AND '" + dateTime2.ToString("yyyy-MM-dd") + "') " +
                                             "AND supply_code = supply_master.code " +
                                             "AND move_flag = 'true') AS warehousing," +
                                            "(SELECT SUM(supply_number) FROM supply_move " + // サブクエリ２
                                             "WHERE (move_date BETWEEN '" + dateTime1.ToString("yyyy-MM-dd") + "' AND '" + dateTime2.ToString("yyyy-MM-dd") + "') " +
                                             "AND supply_code = supply_master.code " +
                                             "AND move_flag = 'false') AS delivery " +
                                     "FROM supply_master " +
                                     "LEFT OUTER JOIN supply_inventory ON supply_master.code = supply_inventory.code " +
                                      "AND (supply_inventory.inventory_date BETWEEN '" + dateTime1.ToString("yyyy-MM-dd") + "' AND '" + dateTime2.ToString("yyyy-MM-dd") + "') " +
                                     "WHERE supply_master.code BETWEEN " + startCode + " AND " + endCode;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    SupplyListVo supplyListVo = new SupplyListVo();
                    supplyListVo.SupplyCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    supplyListVo.SupplyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    supplyListVo.AppropriateStock = _defaultValue.GetDefaultValue<int>(sqlDataReader["m_proper_stock"]);
                    supplyListVo.BeginingMonthStock = _defaultValue.GetDefaultValue<int>(sqlDataReader["i_proper_stock"]);
                    supplyListVo.Warehousing = _defaultValue.GetDefaultValue<int>(sqlDataReader["warehousing"]);
                    supplyListVo.Delivery = _defaultValue.GetDefaultValue<int>(sqlDataReader["delivery"]);
                    listSupplyListVo.Add(supplyListVo);
                }
            }
            return listSupplyListVo;
        }
    }
}
