
using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class SupplyInDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyInDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectSupplyInventory
        /// 画面表示用Vo
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="supplyCode"></param>
        /// <returns></returns>
        public List<SupplyInVo> SelectSupplyInventory(DateTime dateTime, int supplyType) {
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
            /*
             * 月初・月末を設定
             */
            DateTime startDate = new Date().GetBeginOfMonth(dateTime);
            DateTime endDate = new Date().GetEndOfMonth(dateTime);

            List<SupplyInVo> listSupplyInVo = new List<SupplyInVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT supply_master.code," +
                                            "supply_master.name," +
                                            "supply_inventory.proper_stock " +
                                     "FROM supply_master " +
                                     "LEFT OUTER JOIN supply_inventory ON supply_master.code = supply_inventory.code " +
                                     "AND supply_inventory.inventory_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "' " +
                                     "WHERE supply_master.code BETWEEN " + startCode + " AND " + endCode + " " +
                                     "ORDER BY supply_master.code ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    SupplyInVo supplyInVo = new SupplyInVo();
                    supplyInVo.SupplyCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    supplyInVo.SupplyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    supplyInVo.InventoryStock = _defaultValue.GetDefaultValue<int>(sqlDataReader["proper_stock"]);
                    listSupplyInVo.Add(supplyInVo);
                }
            }
            return listSupplyInVo;
        }

        public int SelectCountSupplyInventory(DateTime dateTime, int supplyCode) {
            /*
             * 月初・月末を設定
             */
            DateTime startDate = new Date().GetBeginOfMonth(dateTime);
            DateTime endDate = new Date().GetEndOfMonth(dateTime);

            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT proper_stock " +
                                     "FROM supply_inventory " +
                                     "WHERE (inventory_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') " +
                                     "AND code = " + supplyCode + " " +
                                     "AND delete_flag = 'false'";
            try {
                // レコードが存在しなきゃNULLが返ってくるからね
                if(sqlCommand.ExecuteScalar() != DBNull.Value) {
                    return (int)sqlCommand.ExecuteScalar();
                } else {
                    return 0;
                }
            } catch {
                throw;
            }
        }
    }
}
