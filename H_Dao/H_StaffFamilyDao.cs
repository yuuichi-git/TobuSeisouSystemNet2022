/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using H_Vo;

namespace H_Dao {
    public class H_StaffFamilyDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffFamilyDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneHStaffFamilyMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffFamilyVo> SelectOneHStaffFamilyMaster(int staffCode) {
            List<H_StaffFamilyVo> listHStaffFamilyVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "FamilyName," +
                                            "FamilyBirthDay," +
                                            "FamilyRelationship," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffFamilyMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffFamilyVo hStaffFamilyVo = new();
                    hStaffFamilyVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffFamilyVo.FamilyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["FamilyName"]);
                    hStaffFamilyVo.FamilyBirthDay = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["FamilyBirthDay"]);
                    hStaffFamilyVo.FamilyRelationship = _defaultValue.GetDefaultValue<string>(sqlDataReader["FamilyRelationship"]);
                    hStaffFamilyVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffFamilyVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffFamilyVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffFamilyVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffFamilyVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffFamilyVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffFamilyVo.Add(hStaffFamilyVo);
                }
            }
            return listHStaffFamilyVo;
        }

        /// <summary>
        /// InsertOneHStaffFamilyMaster
        /// </summary>
        /// <param name="hStaffFamilyVo"></param>
        public void InsertOneHStaffFamilyMaster(H_StaffFamilyVo hStaffFamilyVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StaffExperienceMaster(StaffCode," +
                                                                         "FamilyName," +
                                                                         "FamilyBirthDay," +
                                                                         "FamilyRelationship," +
                                                                         "InsertPcName," +
                                                                         "InsertYmdHms," +
                                                                         "UpdatePcName," +
                                                                         "DeletePcName," +
                                                                         "DeleteYmdHms," +
                                                                         "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hStaffFamilyVo.StaffCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffFamilyVo.FamilyName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffFamilyVo.FamilyBirthDay) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffFamilyVo.FamilyRelationship) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffFamilyVo.InsertPcName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffFamilyVo.InsertYmdHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffFamilyVo.UpdatePcName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffFamilyVo.UpdateYmdHms) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffFamilyVo.DeletePcName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffFamilyVo.DeleteYmdHms) + "'," +
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
