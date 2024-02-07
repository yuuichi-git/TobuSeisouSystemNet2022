/*
 * 2023-06-10
 */
using System.Data.SqlClient;

using Common;

using H_Vo;

namespace Dao {
    public class SupplyMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SupplyMasterDao(ConnectionVo connection) {
            _connectionVo = connection;

        }

        /// <summary>
        /// SelectOneSupplyMaster
        /// </summary>
        /// <param name="supplyType">1:事務　2:雇上　3:産廃　4:水物</param>
        /// <returns></returns>
        public List<SupplyMasterVo> SelectOneSupplyMaster(int supplyType) {
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
            List<SupplyMasterVo> listSupplyMasterVo = new List<SupplyMasterVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT code," +
                                            "name," +
                                            "proper_stock," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM supply_master " +
                                     "WHERE code BETWEEN " + startCode + " AND " + endCode;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    SupplyMasterVo supplyMasterVo = new SupplyMasterVo();
                    supplyMasterVo.Code = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    supplyMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    supplyMasterVo.Proper_stock = _defaultValue.GetDefaultValue<int>(sqlDataReader["proper_stock"]);
                    supplyMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    supplyMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    supplyMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    supplyMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listSupplyMasterVo.Add(supplyMasterVo);
                }
            }
            return listSupplyMasterVo;
        }
    }
}
