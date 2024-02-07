/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using H_Vo;

namespace H_Dao {
    public class H_StaffProperDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffProperDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// GetProperDate
        /// 初任診断の受診日を取得する
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns>初任診断の受診日を返す。存在しない場合はstring.Emptyを返す</returns>
        public string GetSyoninProperDate(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 ProperDate FROM H_StaffProperMaster WHERE StaffCode = " + staffCode + " AND ProperKind = '初任診断'";
            var data = sqlCommand.ExecuteScalar();
            if (data is not null) {
                return sqlCommand.ExecuteScalar().ToString();
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public string GetTekireiProperDate(int staffCode) {
            TimeSpan timeSpan = new(0, 0, 0, 0);
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 ProperDate FROM H_StaffProperMaster WHERE StaffCode = " + staffCode + " AND ProperKind = '適齢診断'";
            var data = sqlCommand.ExecuteScalar();
            if (data is not null) {
                timeSpan = ((DateTime)sqlCommand.ExecuteScalar()).AddYears(3) - DateTime.Now.Date;
                return string.Concat(timeSpan.Days, "日後");
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// SelectOneHStaffProperMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffProperVo> SelectOneHStaffProperMaster(int staffCode) {
            List<H_StaffProperVo> listHStaffProperVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "ProperKind," +
                                            "ProperDate," +
                                            "ProperNote," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffProperMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffProperVo hStaffProperVo = new();
                    hStaffProperVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffProperVo.ProperKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["ProperKind"]);
                    hStaffProperVo.ProperDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["ProperDate"]);
                    hStaffProperVo.ProperNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["ProperNote"]);
                    hStaffProperVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffProperVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffProperVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffProperVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffProperVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffProperVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffProperVo.Add(hStaffProperVo);
                }
            }
            return listHStaffProperVo;
        }
    }
}
