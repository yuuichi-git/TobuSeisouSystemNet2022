using System.Data.SqlClient;

using Common;

using H_Vo;

namespace Dao {
    public class CertificationDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public CertificationDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        public List<CertificationMasterVo> SelectAllCertificationMasterVo() {
            List<CertificationMasterVo> listCertificationMasterVo = new List<CertificationMasterVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT certification_code," +
                                            "certification_name," +
                                            "certification_display_name," +
                                            "display_flag," +
                                            "certification_type," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM certification_master " +
                                     "WHERE display_flag = 'True' " +
                                       "AND delete_flag = 'False' " +
                                       "ORDER BY certification_code ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var certificationMasterVo = new CertificationMasterVo();
                    certificationMasterVo.Certification_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["certification_code"]);
                    certificationMasterVo.Certification_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["certification_name"]);
                    certificationMasterVo.Certification_display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["certification_display_name"]);
                    certificationMasterVo.Display_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["display_flag"]);
                    certificationMasterVo.Certification_type = _defaultValue.GetDefaultValue<int>(sqlDataReader["certification_type"]);
                    certificationMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    certificationMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    certificationMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    certificationMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listCertificationMasterVo.Add(certificationMasterVo);
                }
            }
            return listCertificationMasterVo;
        }

        /// <summary>
        /// SelectAllCertificationFile
        /// </summary>
        /// <returns></returns>
        public List<CertificationFileVo> SelectAllCertificationFile() {
            List<CertificationFileVo> listCertificationFileVo = new List<CertificationFileVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_code," +
                                            "staff_name," +
                                            "certification_code," +
                                            "certification_name," +
                                            "mark_code," +
                                            "insert_ymd_hms " +
                                     "FROM certification_file ";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    CertificationFileVo certificationFileVo = new CertificationFileVo();
                    certificationFileVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    certificationFileVo.Staff_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["staff_name"]);
                    certificationFileVo.Certification_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["certification_code"]);
                    certificationFileVo.Certification_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["certification_name"]);
                    certificationFileVo.Mark_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["mark_code"]);
                    certificationFileVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    listCertificationFileVo.Add(certificationFileVo);
                }
            }
            return listCertificationFileVo;
        }

        /// <summary>
        /// UpdateOneCertificationRegistered
        /// ①レコードが存在すればDELETEを実行
        /// ②レコードが存在しなければINSERTを実行
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <param name="certificationMasterVo"></param>
        /// <param name="markCode">印のパターン№</param>
        /// <returns></returns>
        public void UpdateOneCertificationFile(StaffMasterVo staffMasterVo, CertificationMasterVo certificationMasterVo, int markCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM certification_file " +
                                     "WHERE staff_code = '" + staffMasterVo.Staff_code + "' AND certification_code = '" + certificationMasterVo.Certification_code + "' " +
                                     "IF @@ROWCOUNT = 0 " +
                                     "INSERT INTO certification_file(staff_code," +
                                                                     "staff_name," +
                                                                     "certification_code," +
                                                                     "certification_name," +
                                                                     "mark_code," +
                                                                     "insert_ymd_hms) " +
                                     "VALUES (" + staffMasterVo.Staff_code + "," +
                                            "'" + staffMasterVo.Display_name + "'," +
                                                  certificationMasterVo.Certification_code + "," +
                                            "'" + certificationMasterVo.Certification_display_name + "'," +
                                                  markCode + "," +
                                            "'" + DateTime.Now + "')";
            try {
                sqlCommand.ExecuteReader();
            } catch {
                throw;
            }
        }
    }
}
