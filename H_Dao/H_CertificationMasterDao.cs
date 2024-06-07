/*
 * 2024-05-22
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_CertificationMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_CertificationMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;

        }

        /// <summary>
        /// SelectAllCertificationMaster
        /// </summary>
        /// <returns></returns>
        public List<H_CertificationMasterVo> SelectAllCertificationMaster() {
            List<H_CertificationMasterVo> listHCertificationMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT CertificationCode," +
                                            "CertificationName," +
                                            "CertificationDisplayName," +
                                            "DisplayFlag," +
                                            "CertificationType," +
                                            "NumberOfAppointments," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CertificationMaster " +
                                     "WHERE DisplayFlag = 'True' " +
                                       "AND DeleteFlag = 'False' " +
                                       "ORDER BY CertificationCode ASC";
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_CertificationMasterVo hCertificationMasterVo = new();
                    hCertificationMasterVo.CertificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CertificationCode"]);
                    hCertificationMasterVo.CertificationName = _defaultValue.GetDefaultValue<string>(sqlDataReader["CertificationName"]);
                    hCertificationMasterVo.CertificationDisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["CertificationDisplayName"]);
                    hCertificationMasterVo.DisplayFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DisplayFlag"]);
                    hCertificationMasterVo.CertificationType = _defaultValue.GetDefaultValue<int>(sqlDataReader["CertificationType"]);
                    hCertificationMasterVo.NumberOfAppointments = _defaultValue.GetDefaultValue<int>(sqlDataReader["NumberOfAppointments"]);
                    hCertificationMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hCertificationMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCertificationMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCertificationMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCertificationMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCertificationMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCertificationMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHCertificationMasterVo.Add(hCertificationMasterVo);
                }
            }
            return listHCertificationMasterVo;
        }
    }
}
