/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

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
        public List<H_StaffFamilyVo> SelectOneHStaffFamilyMaster() {
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
                                     "FROM H_StaffFamilyMaster";
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
    }
}
