using System.Data.SqlClient;

using Common;

using H_Vo;

namespace Dao {
    public class SupplyInventoryDao {
        /*
         * 定数
         */
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyInventoryDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectSupplyInventory
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="supplyCode"></param>
        /// <returns>画面表示用Vo</returns>
        public List<SupplyScreenVo> SelectSupplyInventory(DateTime dateTime, int supplyType) {
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

            List<SupplyScreenVo> listSupplyInScreenVo = new List<SupplyScreenVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT supply_master.code," +
                                            "supply_master.name," +
                                            "supply_inventory.proper_stock," +
                                            "supply_inventory.memo " +
                                     "FROM supply_master " +
                                     "LEFT OUTER JOIN supply_inventory ON supply_master.code = supply_inventory.code " +
                                     "AND supply_inventory.inventory_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "' " +
                                     "WHERE supply_master.code BETWEEN " + startCode + " AND " + endCode + " " +
                                     "ORDER BY supply_master.code ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    SupplyScreenVo supplyInScreenVo = new SupplyScreenVo();
                    supplyInScreenVo.SupplyCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    supplyInScreenVo.SupplyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    supplyInScreenVo.SupplyCount = _defaultValue.GetDefaultValue<int>(sqlDataReader["proper_stock"]);
                    supplyInScreenVo.Memo = _defaultValue.GetDefaultValue<string>(sqlDataReader["memo"]);
                    listSupplyInScreenVo.Add(supplyInScreenVo);
                }
            }
            return listSupplyInScreenVo;
        }

        /// <summary>
        /// InsertSupplyInventory
        /// </summary>
        /// <param name="supplyInventoryVo"></param>
        /// <returns></returns>
        public void InsertSupplyInventory(SupplyInventoryVo supplyInventoryVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO supply_inventory(inventory_date," +
                                                                  "code," +
                                                                  "name," +
                                                                  "proper_stock," +
                                                                  "memo," +
                                                                  "insert_ymd_hms," +
                                                                  "update_ymd_hms," +
                                                                  "delete_ymd_hms," +
                                                                  "delete_flag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<DateTime>(supplyInventoryVo.Inventory_date) + "'," +
                                              "" + _defaultValue.GetDefaultValue<int>(supplyInventoryVo.Code) + "," +
                                             "'" + _defaultValue.GetDefaultValue<string>(supplyInventoryVo.Name) + "'," +
                                              "" + _defaultValue.GetDefaultValue<int>(supplyInventoryVo.ProperStock) + "," +
                                             "'" + _defaultValue.GetDefaultValue<string>(supplyInventoryVo.Memo) + "'," +
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
        /// DeleteSupplyInventory
        /// </summary>
        /// <param name="dateTime"></param>
        public void DeleteSupplyInventory(DateTime dateTime) {
            /*
             * 月初・月末を設定
             */
            DateTime startDate = new Date().GetBeginOfMonth(dateTime);
            DateTime endDate = new Date().GetEndOfMonth(dateTime);

            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM supply_inventory " +
                                     "WHERE inventory_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
