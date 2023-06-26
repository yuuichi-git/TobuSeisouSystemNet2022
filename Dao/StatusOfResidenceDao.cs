/*
 * 2023-06-23
 */
using System.Data;
using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class StatusOfResidenceDao {
        /*
         * Dao
         */

        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        /// <summary>
        /// コンストラクター
        /// </summary>
        public StatusOfResidenceDao(ConnectionVo connectionVo) {
            /*
             * Dao
             */

            /*
             * Vo
             */
            _connectionVo = connectionVo;

        }

        /// <summary>
        /// SelectStatusOfResidenceMaster
        /// </summary>
        /// <returns></returns>
        public List<StatusOfResidenceListVo> SelectStatusOfResidenceMaster() {
            List<StatusOfResidenceListVo> listStatusOfResidenceListVo = new List<StatusOfResidenceListVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT status_of_residence_master.staff_name," +
                                            "status_of_residence_master.staff_name_kana," +
                                            "status_of_residence_master.birth_date," +
                                            "status_of_residence_master.gender," +
                                            "status_of_residence_master.nationality," +
                                            "status_of_residence_master.address," +
                                            "status_of_residence_master.status_of_residence," +
                                            "status_of_residence_master.work_limit," +
                                            "status_of_residence_master.period_date," +
                                            "status_of_residence_master.deadline_date " +
                                     "FROM status_of_residence_master " +
                                     "LEFT OUTER JOIN staff_master ON staff_master.staff_code = status_of_residence_master.staff_code " +
                                     "WHERE status_of_residence_master.delete_flag = 'false' " +
                                     "ORDER BY staff_master.name_kana ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    StatusOfResidenceListVo statusOfResidenceListVo = new StatusOfResidenceListVo();
                    statusOfResidenceListVo.Staff_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["staff_name"]);
                    statusOfResidenceListVo.Staff_name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["staff_name_kana"]);
                    statusOfResidenceListVo.Birth_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["birth_date"]);
                    statusOfResidenceListVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["gender"]);
                    statusOfResidenceListVo.Nationality = _defaultValue.GetDefaultValue<string>(sqlDataReader["nationality"]);
                    statusOfResidenceListVo.Address = _defaultValue.GetDefaultValue<string>(sqlDataReader["address"]);
                    statusOfResidenceListVo.Status_of_residence = _defaultValue.GetDefaultValue<string>(sqlDataReader["status_of_residence"]);
                    statusOfResidenceListVo.Work_limit = _defaultValue.GetDefaultValue<string>(sqlDataReader["work_limit"]);
                    statusOfResidenceListVo.Period_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["period_date"]);
                    statusOfResidenceListVo.Deadline_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["deadline_date"]);
                    listStatusOfResidenceListVo.Add(statusOfResidenceListVo);
                }
            }
            return listStatusOfResidenceListVo;
        }

        /// <summary>
        /// InsertOneStatusOfResidenceMaster
        /// </summary>
        /// <param name="statusOfResidenceVo"></param>
        /// <returns></returns>
        public int InsertOneStatusOfResidenceMaster(StatusOfResidenceVo statusOfResidenceVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO status_of_residence_master(staff_code," +
                                                                            "staff_name," +
                                                                            "staff_name_kana," +
                                                                            "birth_date," +
                                                                            "gender," +
                                                                            "nationarity," +
                                                                            "address," +
                                                                            "status_of_residence," +
                                                                            "work_limit," +
                                                                            "period_date," +
                                                                            "deadline_date," +
                                                                            "picture_head," +
                                                                            "picture_tail," +
                                                                            "insert_ymd_hms," +
                                                                            "update_ymd_hms," +
                                                                            "delete_ymd_hms," +
                                                                            "delete_flag) " +
                                     "VALUES (" + statusOfResidenceVo.Staff_code + "," +
                                             "" + statusOfResidenceVo.Staff_name + "," +
                                             "" + statusOfResidenceVo.Staff_name_kana + "," +
                                             "" + statusOfResidenceVo.Birth_date + "," +
                                             "" + statusOfResidenceVo.Gender + "," +
                                             "" + statusOfResidenceVo.Nationality + "," +
                                             "" + statusOfResidenceVo.Address + "," +
                                             "" + statusOfResidenceVo.Status_of_residence + "," +
                                             "" + statusOfResidenceVo.Work_limit + "," +
                                             "" + statusOfResidenceVo.Period_date + "," +
                                             "" + statusOfResidenceVo.Deadline_date + "," +
                                             "@member_picture_head," +
                                             "@member_picture_tail," +
                                             "'" + DateTime.Now + "'," +
                                             "'1900-01-01'," +
                                             "'1900-01-01'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture_head", SqlDbType.Image, statusOfResidenceVo.Picture_head.Length).Value = statusOfResidenceVo.Picture_head;
                sqlCommand.Parameters.Add("@member_picture_tail", SqlDbType.Image, statusOfResidenceVo.Picture_tail.Length).Value = statusOfResidenceVo.Picture_tail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
