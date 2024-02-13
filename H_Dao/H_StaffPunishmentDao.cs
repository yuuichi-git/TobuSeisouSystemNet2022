/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using H_Vo;

namespace H_Dao {
    public class H_StaffPunishmentDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffPunishmentDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneHStaffPunishmentMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffPunishmentVo> SelectOneHStaffPunishmentMaster(int staffCode) {
            List<H_StaffPunishmentVo> listHStaffPunishmentVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "PunishmentDate," +
                                            "PunishmentNote," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffPunishmentMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffPunishmentVo hStaffPunishmentVo = new();
                    hStaffPunishmentVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffPunishmentVo.PunishmentDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["PunishmentDate"]);
                    hStaffPunishmentVo.PunishmentNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["PunishmentNote"]);
                    hStaffPunishmentVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStaffPunishmentVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffPunishmentVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffPunishmentVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffPunishmentVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffPunishmentVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffPunishmentVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffPunishmentVo.Add(hStaffPunishmentVo);
                }
            }
            return listHStaffPunishmentVo;
        }

        /// <summary>
        /// InsertOneHStaffPunishmentMasters
        /// </summary>
        /// <param name="hStaffPunishmentVo"></param>
        public void InsertOneHStaffPunishmentMasters(H_StaffPunishmentVo hStaffPunishmentVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StaffPunishmentMaster(StaffCode," +
                                                                         "PunishmentDate," +
                                                                         "PunishmentNote," +
                                                                         "InsertPcName," +
                                                                         "InsertYmdHms," +
                                                                         "UpdatePcName," +
                                                                         "UpdateYmdHms," +
                                                                         "DeletePcName," +
                                                                         "DeleteYmdHms," +
                                                                         "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hStaffPunishmentVo.StaffCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffPunishmentVo.PunishmentDate) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffPunishmentVo.PunishmentNote) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffPunishmentVo.InsertPcName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffPunishmentVo.InsertYmdHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffPunishmentVo.UpdatePcName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffPunishmentVo.UpdateYmdHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffPunishmentVo.DeletePcName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffPunishmentVo.DeleteYmdHms) + "'," +
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
