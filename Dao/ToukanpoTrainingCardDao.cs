using System.Data;

using Vo;

namespace Dao {
    public class ToukanpoTrainingCardDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);

        public ToukanpoTrainingCardDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneToukanpoTrainingCard
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public ToukanpoTrainingCardVo SelectOneToukanpoTrainingCard(int staffCode) {
            var toukanpoTrainingCardVo = new ToukanpoTrainingCardVo();
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
                    toukanpoTrainingCardVo.Staff_code = (int)sqlDataReader["staff_code"];
                    toukanpoTrainingCardVo.Display_name = (string)sqlDataReader["display_name"];
                    toukanpoTrainingCardVo.Company_name = (string)sqlDataReader["company_name"];
                    toukanpoTrainingCardVo.Card_name = (string)sqlDataReader["card_name"];
                    toukanpoTrainingCardVo.CertificationDate = (DateTime)sqlDataReader["certification_date"];
                    toukanpoTrainingCardVo.Picture = (byte[])sqlDataReader["picture"];
                    toukanpoTrainingCardVo.Insert_ymd_hms = (DateTime)sqlDataReader["insert_ymd_hms"];
                    toukanpoTrainingCardVo.Update_ymd_hms = (DateTime)sqlDataReader["update_ymd_hms"];
                    toukanpoTrainingCardVo.Delete_ymd_hms = (DateTime)sqlDataReader["delete_ymd_hms"];
                    toukanpoTrainingCardVo.Delete_flag = (bool)sqlDataReader["delete_flag"];
                }
            }
            return toukanpoTrainingCardVo;
        }

        /// <summary>
        /// InsertOneToukanpoTrainingCard
        /// </summary>
        /// <param name="toukanpoTrainingCardVo"></param>
        /// <returns></returns>
        public int InsertOneToukanpoTrainingCard(ToukanpoTrainingCardVo toukanpoTrainingCardVo) {
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
                                     "VALUES (" + toukanpoTrainingCardVo.Staff_code + "," +
                                            "'" + toukanpoTrainingCardVo.Display_name + "'," +
                                            "'" + toukanpoTrainingCardVo.Company_name + "'," +
                                            "'" + toukanpoTrainingCardVo.Card_name + "'," +
                                            "'" + toukanpoTrainingCardVo.CertificationDate + "'," +
                                            "@pictureCard," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'false'" +
                                            ");";
            try {
                sqlCommand.Parameters.Add("@pictureCard", SqlDbType.Image, toukanpoTrainingCardVo.Picture.Length).Value = toukanpoTrainingCardVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneToukanpoTrainingCard
        /// </summary>
        /// <param name="toukanpoTrainingCardVo"></param>
        /// <returns></returns>
        public int UpdateOneToukanpoTrainingCard(ToukanpoTrainingCardVo toukanpoTrainingCardVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE toukanpo_training_card " +
                                     "SET company_name = '" + toukanpoTrainingCardVo.Company_name + "'," +
                                         "display_name = '" + toukanpoTrainingCardVo.Display_name + "'," +
                                         "card_name = '" + toukanpoTrainingCardVo.Card_name + "'," +
                                         "certification_date = '" + toukanpoTrainingCardVo.CertificationDate + "'," +
                                         "picture = @pictureCard," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE staff_code = " + toukanpoTrainingCardVo.Staff_code;
            try {
                sqlCommand.Parameters.Add("@pictureCard", SqlDbType.Image, toukanpoTrainingCardVo.Picture.Length).Value = toukanpoTrainingCardVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
