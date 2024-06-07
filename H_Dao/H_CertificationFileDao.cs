/*
 * 2024-05-22
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_CertificationFileDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_CertificationFileDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHCertificationFile
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="certificationCode"></param>
        /// <returns>true:該当レコードあり false:該当レコードなし</returns>
        public bool ExistenceHCertificationFile(int staffCode, int certificationCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(StaffCode) " +
                                     "FROM H_CertificationFile " +
                                     "WHERE StaffCode = " + staffCode + " AND CertificationCode = " + certificationCode + "";
            try {
                return (int)sqlCommand.ExecuteScalar() != 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectAllHCertificationFile
        /// Picture無し
        /// </summary>
        /// <returns></returns>
        public List<H_CertificationFileVo> SelectAllHCertificationFile() {
            List<H_CertificationFileVo> listHCertificationFileVo = new();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "CertificationCode," +
                                            "MarkCode," +
                                            //"Picture1," +
                                            //"Picture2," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CertificationFile";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_CertificationFileVo hCertificationFileVo = new();
                    hCertificationFileVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hCertificationFileVo.CertificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CertificationCode"]);
                    hCertificationFileVo.MarkCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["MarkCode"]);
                    //hCertificationFileVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture1"]);
                    //hCertificationFileVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture2"]);
                    hCertificationFileVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hCertificationFileVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCertificationFileVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCertificationFileVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCertificationFileVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCertificationFileVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCertificationFileVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHCertificationFileVo.Add(hCertificationFileVo);
                }
            }
            return listHCertificationFileVo;
        }

        /// <summary>
        /// SelectAllHCertificationFileP
        /// Picture有り
        /// </summary>
        /// <returns></returns>
        public H_CertificationFileVo SelectOneHCertificationFile(int staffCode, int certificationCode) {
            H_CertificationFileVo hCertificationFileVo = new();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "CertificationCode," +
                                            "MarkCode," +
                                            "Picture1," +
                                            "Picture2," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CertificationFile " +
                                     "WHERE StaffCode = " + staffCode + " AND  CertificationCode = " + certificationCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hCertificationFileVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hCertificationFileVo.CertificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CertificationCode"]);
                    hCertificationFileVo.MarkCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["MarkCode"]);
                    hCertificationFileVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture1"]);
                    hCertificationFileVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture2"]);
                    hCertificationFileVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hCertificationFileVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCertificationFileVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCertificationFileVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCertificationFileVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCertificationFileVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCertificationFileVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hCertificationFileVo;
        }

        /// <summary>
        /// InsertOneHCertificationFile
        /// </summary>
        /// <param name="hCertificationFileVo"></param>
        /// <param name="staffCode"></param>
        /// <param name="markCode"></param>
        public void InsertOneHCertificationFile(H_CertificationFileVo hCertificationFileVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_CertificationFile(StaffCode," +
                                                                     "CertificationCode," +
                                                                     "MarkCode," +
                                                                     "Picture1," +
                                                                     "Picture2," +
                                                                     "InsertPcName," +
                                                                     "InsertYmdHms," +
                                                                     "UpdatePcName," +
                                                                     "UpdateYmdHms," +
                                                                     "DeletePcName," +
                                                                     "DeleteYmdHms," +
                                                                     "DeleteFlag) " +
                                     "VALUES (" + hCertificationFileVo.StaffCode + "," +
                                                  hCertificationFileVo.CertificationCode + "," +
                                                  hCertificationFileVo.MarkCode + "," +
                                                 "@member_picture1," +
                                                 "@member_picture2," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'False'" +
                                            ");";
            try {
                if (hCertificationFileVo.Picture1 is not null)
                    sqlCommand.Parameters.Add("@member_picture1", SqlDbType.Image, hCertificationFileVo.Picture1.Length).Value = hCertificationFileVo.Picture1;
                if (hCertificationFileVo.Picture2 is not null)
                    sqlCommand.Parameters.Add("@member_picture2", SqlDbType.Image, hCertificationFileVo.Picture2.Length).Value = hCertificationFileVo.Picture2;
                sqlCommand.ExecuteReader();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHLicenseLedger
        /// </summary>
        /// <param name="hCertificationFileVo"></param>
        /// <returns></returns>
        public int UpdateOneHLicenseLedger(H_CertificationFileVo hCertificationFileVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_CertificationFile " +
                                     "SET StaffCode = " + hCertificationFileVo.StaffCode + "," +
                                         "CertificationCode = " + hCertificationFileVo.CertificationCode + "," +
                                         "MarkCode = " + hCertificationFileVo.MarkCode + "," +
                                         "Picture1 = @member_picture1," +
                                         "Picture2 = @member_picture2," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE StaffCode = " + hCertificationFileVo.StaffCode + " AND CertificationCode = " + hCertificationFileVo.CertificationCode + "";
            try {
                sqlCommand.Parameters.Add("@member_picture1", SqlDbType.Image, hCertificationFileVo.Picture1.Length).Value = hCertificationFileVo.Picture1;
                sqlCommand.Parameters.Add("@member_picture2", SqlDbType.Image, hCertificationFileVo.Picture2.Length).Value = hCertificationFileVo.Picture2;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
