using System.Data;

using Vo;

namespace Dao {
    public class ToukanpoDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);

        public ToukanpoDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneToukanpoTrainingCard
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public ToukanpoVo SelectOneToukanpoTrainingCard(int staffCode) {
            var toukanpoVo = new ToukanpoVo();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_code," +
                                            "display_name," +
                                            "company_name," +
                                            "card_name," +
                                            "certification_date," +
                                            "picture," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM toukanpo_training_card WITH(NOLOCK)" +
                                     "WHERE staff_code = '" + staffCode + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    toukanpoVo.Staff_code = (int)sqlDataReader["staff_code"];
                    toukanpoVo.Display_name = (string)sqlDataReader["display_name"];
                    toukanpoVo.Company_name = (string)sqlDataReader["company_name"];
                    toukanpoVo.Card_name = (string)sqlDataReader["card_name"];
                    toukanpoVo.CertificationDate = (DateTime)sqlDataReader["certification_date"];
                    toukanpoVo.Picture = (byte[])sqlDataReader["picture"];
                    toukanpoVo.Insert_ymd_hms = (DateTime)sqlDataReader["insert_ymd_hms"];
                    toukanpoVo.Update_ymd_hms = (DateTime)sqlDataReader["update_ymd_hms"];
                    toukanpoVo.Delete_ymd_hms = (DateTime)sqlDataReader["delete_ymd_hms"];
                    toukanpoVo.Delete_flag = (bool)sqlDataReader["delete_flag"];
                }
            }
            return toukanpoVo;
        }

        /// <summary>
        /// InsertOneToukanpoTrainingCard
        /// </summary>
        /// <param name="toukanpoVo"></param>
        /// <returns></returns>
        public int InsertOneToukanpoTrainingCard(ToukanpoVo toukanpoVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO toukanpo_training_card(staff_code," +
                                                                        "display_name," +
                                                                        "company_name," +
                                                                        "card_name," +
                                                                        "certification_date," +
                                                                        "picture," +
                                                                        "insert_ymd_hms," +
                                                                        "update_ymd_hms," +
                                                                        "delete_ymd_hms," +
                                                                        "delete_flag) " +
                                     "VALUES (" + toukanpoVo.Staff_code + "," +
                                            "'" + toukanpoVo.Display_name + "'," +
                                            "'" + toukanpoVo.Company_name + "'," +
                                            "'" + toukanpoVo.Card_name + "'," +
                                            "'" + toukanpoVo.CertificationDate + "'," +
                                            "@pictureCard," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'false'" +
                                            ");";
            try {
                sqlCommand.Parameters.Add("@pictureCard", SqlDbType.Image, toukanpoVo.Picture.Length).Value = toukanpoVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneToukanpoTrainingCard
        /// </summary>
        /// <param name="toukanpoVo"></param>
        /// <returns></returns>
        public int UpdateOneToukanpoTrainingCard(ToukanpoVo toukanpoVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE toukanpo_training_card " +
                                     "SET company_name = '" + toukanpoVo.Company_name + "'," +
                                         "display_name = '" + toukanpoVo.Display_name + "'," +
                                         "card_name = '" + toukanpoVo.Card_name + "'," +
                                         "certification_date = '" + toukanpoVo.CertificationDate + "'," +
                                         "picture = @pictureCard," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE staff_code = " + toukanpoVo.Staff_code;
            try {
                sqlCommand.Parameters.Add("@pictureCard", SqlDbType.Image, toukanpoVo.Picture.Length).Value = toukanpoVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
