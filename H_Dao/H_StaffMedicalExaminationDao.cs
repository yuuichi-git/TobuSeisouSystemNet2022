/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_StaffMedicalExaminationDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffMedicalExaminationDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// レコードの存在確認
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns>存在する:DateTime型 存在しない:_defaultDateTime</returns>
        public DateTime GetMedicalExaminationDate(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 MedicalExaminationDate FROM H_StaffMedicalExaminationMaster WHERE StaffCode = " + staffCode + "";
            var data = sqlCommand.ExecuteScalar();
            if (data is not null) {
                return (DateTime)sqlCommand.ExecuteScalar();
            } else {
                return _defaultDateTime;
            }
        }

        /// <summary>
        /// SelectOneHStaffMedicalExaminationMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffMedicalExaminationVo> SelectOneHStaffMedicalExaminationMaster(int staffCode) {
            List<H_StaffMedicalExaminationVo> listHStaffMedicalExaminationVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "MedicalExaminationDate," +
                                            "MedicalInstitutionName," +
                                            "MedicalExaminationNote," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffMedicalExaminationMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffMedicalExaminationVo hStaffMedicalExaminationVo = new();
                    hStaffMedicalExaminationVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffMedicalExaminationVo.MedicalExaminationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["MedicalExaminationDate"]);
                    hStaffMedicalExaminationVo.MedicalInstitutionName = _defaultValue.GetDefaultValue<string>(sqlDataReader["MedicalInstitutionName"]);
                    hStaffMedicalExaminationVo.MedicalExaminationNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["MedicalExaminationNote"]);
                    hStaffMedicalExaminationVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffMedicalExaminationVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffMedicalExaminationVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffMedicalExaminationVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffMedicalExaminationVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffMedicalExaminationVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffMedicalExaminationVo.Add(hStaffMedicalExaminationVo);
                }
            }
            return listHStaffMedicalExaminationVo;
        }

        /// <summary>
        /// InsertOneHStaffMedicalExaminationMaster
        /// </summary>
        /// <param name="hStaffMedicalExaminationVo"></param>
        public void InsertOneHStaffMedicalExaminationMaster(H_StaffMedicalExaminationVo hStaffMedicalExaminationVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StaffMedicalExaminationMaster(StaffCode," +
                                                                                 "MedicalExaminationDate," +
                                                                                 "MedicalInstitutionName," +
                                                                                 "MedicalExaminationNote," +
                                                                                 "InsertPcName," +
                                                                                 "InsertYmdHms," +
                                                                                 "UpdatePcName," +
                                                                                 "UpdateYmdHms," +
                                                                                 "DeletePcName," +
                                                                                 "DeleteYmdHms," +
                                                                                 "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hStaffMedicalExaminationVo.StaffCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffMedicalExaminationVo.MedicalExaminationDate) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffMedicalExaminationVo.MedicalInstitutionName) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffMedicalExaminationVo.MedicalExaminationNote) + "'," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + "" + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + "" + "'," +
                                            "'" + _defaultDateTime + "'," +
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
