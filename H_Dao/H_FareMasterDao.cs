/*
 * 2024-02-21 
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_FareMasterDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_FareMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectAllHFareMasterVo
        /// </summary>
        /// <returns></returns>
        public List<H_FareMasterVo> SelectAllHFareMasterVo() {
            List<H_FareMasterVo> listHFareMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT FareCode," +
                                            "FareName," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_FareMaster";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_FareMasterVo hFareMasterVo = new();
                    hFareMasterVo.FareCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["FareCode"]);
                    hFareMasterVo.FareName = _defaultValue.GetDefaultValue<string>(sqlDataReader["FareName"]);
                    hFareMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hFareMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hFareMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hFareMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hFareMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hFareMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hFareMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHFareMasterVo.Add(hFareMasterVo);
                }
            }
            return listHFareMasterVo;
        }
    }
}
