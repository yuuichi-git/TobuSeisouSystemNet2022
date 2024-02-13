/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

namespace H_Dao {
    public class H_StaffHistoryDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffHistoryDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneHStaffHistoryMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffHistoryVo> SelectOneHStaffHistoryMaster(int staffCode) {
            List<H_StaffHistoryVo> listHStaffHistoryVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "HistoryDate," +
                                            "CompanyName," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffHistoryMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffHistoryVo hStaffHistoryVo = new();
                    hStaffHistoryVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffHistoryVo.HistoryDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["HistoryDate"]);
                    hStaffHistoryVo.CompanyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["CompanyName"]);
                    hStaffHistoryVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStaffHistoryVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffHistoryVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffHistoryVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffHistoryVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffHistoryVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffHistoryVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffHistoryVo.Add(hStaffHistoryVo);
                }
            }
            return listHStaffHistoryVo;
        }

        /// <summary>
        /// InsertOneHStaffHistoryMaster
        /// </summary>
        /// <param name="hStaffHistoryVo"></param>
        public void InsertOneHStaffHistoryMaster(H_StaffHistoryVo hStaffHistoryVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StaffHistoryMaster(StaffCode," +
                                                                      "HistoryDate," +
                                                                      "CompanyName," +
                                                                      "InsertPcName," +
                                                                      "InsertYmdHms," +
                                                                      "UpdatePcName," +
                                                                      "UpdateYmdHms," +
                                                                      "DeletePcName," +
                                                                      "DeleteYmdHms," +
                                                                      "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hStaffHistoryVo.StaffCode) + "," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffHistoryVo.HistoryDate) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hStaffHistoryVo.CompanyName) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hStaffHistoryVo.InsertPcName) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffHistoryVo.InsertYmdHms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hStaffHistoryVo.UpdatePcName) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffHistoryVo.UpdateYmdHms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(hStaffHistoryVo.DeletePcName) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffHistoryVo.DeleteYmdHms) + "'," +
                                             "'False'" +
                                             ");";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
