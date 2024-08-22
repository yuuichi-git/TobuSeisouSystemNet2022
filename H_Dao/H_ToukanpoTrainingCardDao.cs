/*
 * 2024-02-07
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_ToukanpoTrainingCardDao {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_ToukanpoTrainingCardDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// レコードの存在確認
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns>true:存在する false:存在しない</returns>
        public bool ExistenceHToukanpoTrainingCardMaster(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 StaffCode " +
                                     "FROM H_ToukanpoTrainingCardMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            return sqlCommand.ExecuteScalar() is not null ? true : false;
        }

        public H_ToukanpoTrainingCardVo SelectOneHToukanpoTrainingCardMaster(int staffCode) {
            H_ToukanpoTrainingCardVo hToukanpoTrainingCardVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "DisplayName," +
                                            "CompanyName," +
                                            "CardName," +
                                            "CertificationDate," +
                                            "Picture," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_ToukanpoTrainingCardMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hToukanpoTrainingCardVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hToukanpoTrainingCardVo.DisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisplayName"]);
                    hToukanpoTrainingCardVo.CompanyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["CompanyName"]);
                    hToukanpoTrainingCardVo.CardName = _defaultValue.GetDefaultValue<string>(sqlDataReader["CardName"]);
                    hToukanpoTrainingCardVo.CertificationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["CertificationDate"]);
                    hToukanpoTrainingCardVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                    hToukanpoTrainingCardVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hToukanpoTrainingCardVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hToukanpoTrainingCardVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hToukanpoTrainingCardVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hToukanpoTrainingCardVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hToukanpoTrainingCardVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hToukanpoTrainingCardVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hToukanpoTrainingCardVo;
        }

        public int InsertOneHToukanpoTrainingCardMaster(H_ToukanpoTrainingCardVo hToukanpoTrainingCardVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_ToukanpoTrainingCardMaster(StaffCode," +
                                                                              "DisplayName," +
                                                                              "CompanyName," +
                                                                              "CardName," +
                                                                              "CertificationDate," +
                                                                              "Picture," +
                                                                              "InsertPcName," +
                                                                              "InsertYmdHms," +
                                                                              "UpdatePcName," +
                                                                              "UpdateYmdHms," +
                                                                              "DeletePcName," +
                                                                              "DeleteYmdHms," +
                                                                              "DeleteFlag) " +
                                     "VALUES (" + hToukanpoTrainingCardVo.StaffCode + "," +
                                            "'" + hToukanpoTrainingCardVo.DisplayName + "'," +
                                            "'" + hToukanpoTrainingCardVo.CompanyName + "'," +
                                            "'" + hToukanpoTrainingCardVo.CardName + "'," +
                                            "'" + hToukanpoTrainingCardVo.CertificationDate + "'," +
                                            "@pictureCard," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "''," +
                                            "'" + _defaultDateTime + "'," +
                                            "''," +
                                            "'" + _defaultDateTime + "'," +
                                            "'false'" +
                                            ");";
            try {
                sqlCommand.Parameters.Add("@pictureCard", SqlDbType.Image, hToukanpoTrainingCardVo.Picture.Length).Value = hToukanpoTrainingCardVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        public int UpdateOneHToukanpoTrainingCardMaster(H_ToukanpoTrainingCardVo hToukanpoTrainingCardVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_ToukanpoTrainingCardMaster " +
                                     "SET CompanyName = '" + hToukanpoTrainingCardVo.CompanyName + "'," +
                                         "DisplayName = '" + hToukanpoTrainingCardVo.DisplayName + "'," +
                                         "CardName = '" + hToukanpoTrainingCardVo.CardName + "'," +
                                         "CertificationDate = '" + hToukanpoTrainingCardVo.CertificationDate + "'," +
                                         "Picture = @pictureCard," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE StaffCode = " + hToukanpoTrainingCardVo.StaffCode;
            try {
                sqlCommand.Parameters.Add("@pictureCard", SqlDbType.Image, hToukanpoTrainingCardVo.Picture.Length).Value = hToukanpoTrainingCardVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
