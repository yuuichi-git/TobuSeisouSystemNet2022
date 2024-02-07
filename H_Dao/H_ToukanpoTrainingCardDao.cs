/*
 * 2024-02-07
 */
using System.Data.SqlClient;

using H_Vo;

using H_Vo;

namespace H_Dao {
    public class H_ToukanpoTrainingCardDao {
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
        public bool ExistenceToukanpoTrainingCard(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 StaffCode FROM H_ToukanpoTrainingCardMaster WHERE StaffCode = " + staffCode + "";
            return sqlCommand.ExecuteScalar() is not null ? true : false;
        }


        public H_ToukanpoTrainingCardVo SelectOneToukanpoTrainingCard(int staffCode) {
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
                    hToukanpoTrainingCardVo.StaffCode = (int)sqlDataReader["StaffCode"];
                    hToukanpoTrainingCardVo.DisplayName = (string)sqlDataReader["DisplayName"];
                    hToukanpoTrainingCardVo.CompanyName = (string)sqlDataReader["CompanyName"];
                    hToukanpoTrainingCardVo.CardName = (string)sqlDataReader["CardName"];
                    hToukanpoTrainingCardVo.CertificationDate = (DateTime)sqlDataReader["CertificationDate"];
                    hToukanpoTrainingCardVo.Picture = (byte[])sqlDataReader["Picture"];
                    hToukanpoTrainingCardVo.InsertPcName = (string)sqlDataReader["InsertPcName"];
                    hToukanpoTrainingCardVo.InsertYmdHms = (DateTime)sqlDataReader["InsertYmdHms"];
                    hToukanpoTrainingCardVo.UpdatePcName = (string)sqlDataReader["UpdatePcName"];
                    hToukanpoTrainingCardVo.UpdateYmdHms = (DateTime)sqlDataReader["UpdateYmdHms"];
                    hToukanpoTrainingCardVo.DeletePcName = (string)sqlDataReader["DeletePcName"];
                    hToukanpoTrainingCardVo.DeleteYmdHms = (DateTime)sqlDataReader["DeleteYmdHms"];
                    hToukanpoTrainingCardVo.DeleteFlag = (bool)sqlDataReader["DeleteFlag"];
                }
            }
            return hToukanpoTrainingCardVo;
        }
    }
}
