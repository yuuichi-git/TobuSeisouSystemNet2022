/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using H_Vo;

namespace H_Dao {
    public class H_StaffExperienceDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffExperienceDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneHStaffExperienceMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffExperienceVo> SelectOneHStaffExperienceMaster(int staffCode) {
            List<H_StaffExperienceVo> listHStaffExperienceVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "ExperienceKind," +
                                            "ExperienceLoad," +
                                            "ExperienceDuration," +
                                            "ExperienceNote," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffExperienceMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffExperienceVo hStaffExperienceVo = new();
                    hStaffExperienceVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffExperienceVo.ExperienceKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["ExperienceKind"]);
                    hStaffExperienceVo.ExperienceLoad = _defaultValue.GetDefaultValue<string>(sqlDataReader["ExperienceLoad"]);
                    hStaffExperienceVo.ExperienceDuration = _defaultValue.GetDefaultValue<string>(sqlDataReader["ExperienceDuration"]);
                    hStaffExperienceVo.ExperienceNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["ExperienceNote"]);
                    hStaffExperienceVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffExperienceVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffExperienceVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffExperienceVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffExperienceVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffExperienceVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffExperienceVo.Add(hStaffExperienceVo);
                }
            }
            return listHStaffExperienceVo;
        }
    }
}
