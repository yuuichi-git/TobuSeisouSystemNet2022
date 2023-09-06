using System.Data;
using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class LegalTwelveItemDao {
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public LegalTwelveItemDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneLegalTwelveItem
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <param name="studentsCode"></param>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public List<LegalTwelveItemVo> SelectAllLegalTwelveItem(DateTime dateTime1, DateTime dateTime2, int staffCode) {
            List<LegalTwelveItemVo> listLegalTwelveItemVo = new List<LegalTwelveItemVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT students_date," +
                                            "students_code," +
                                            "students_flag," +
                                            "staff_code," +
                                            "staff_sign," +
                                            "sign_number," +
                                            "memo," +
                                            "insert_pc_name," +
                                            "insert_ymd_hms," +
                                            "update_pc_name," +
                                            "update_ymd_hms," +
                                            "delete_pc_name," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM legal_twelve_item " +
                                     "WHERE (students_date BETWEEN '" + dateTime1 + "' AND '" + dateTime2 + "') " +
                                     "AND staff_code = " + staffCode;
            using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    LegalTwelveItemVo legalTwelveItemVo = new LegalTwelveItemVo();
                    legalTwelveItemVo.Students_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["students_date"]);
                    legalTwelveItemVo.Students_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["students_code"]);
                    legalTwelveItemVo.Students_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_flag"]);
                    legalTwelveItemVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    legalTwelveItemVo.Staff_sign = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["staff_sign"]);
                    legalTwelveItemVo.Sign_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["sign_number"]);
                    legalTwelveItemVo.Memo = _defaultValue.GetDefaultValue<string>(sqlDataReader["memo"]);
                    legalTwelveItemVo.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                    legalTwelveItemVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    legalTwelveItemVo.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                    legalTwelveItemVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    legalTwelveItemVo.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                    legalTwelveItemVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    legalTwelveItemVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listLegalTwelveItemVo.Add(legalTwelveItemVo);
                }
                return listLegalTwelveItemVo;
            }
        }

        /// <summary>
        /// SelectLegalTwelveItemForm
        /// 画面表示に必要なデータを取得する
        /// </summary>
        /// <returns></returns>
        public List<LegalTwelveItemListVo> SelectLegalTwelveItemForm(DateTime startDate, DateTime endDate) {
            List<LegalTwelveItemListVo> listLegalTwelveItemFormVo = new List<LegalTwelveItemListVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_master.occupation AS occupation_code," +
                                            "occupation_master.name AS occupation_name," +
                                            "staff_master.staff_code," +
                                            "staff_master.name AS staff_name," +
                                            "staff_master.employment_date," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 1 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_01_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 2 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_02_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 3 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_03_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 4 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_04_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 5 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_05_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 6 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_06_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 7 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_07_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 8 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_08_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 9 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_09_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 10 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_10_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 11 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_11_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 12 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_12_flag " +
                                     "FROM staff_master " +
                                     "LEFT OUTER JOIN occupation_master ON staff_master.occupation = occupation_master.code " +
                                     "WHERE staff_master.belongs IN (10,11,12,20,21) AND staff_master.job_form IN (10,12,99) AND staff_master.occupation = 10 AND staff_master.retirement_flag = 'false' " +
                                     "ORDER BY staff_master.name_kana ASC";
            using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    LegalTwelveItemListVo legalTwelveItemFormVo = new LegalTwelveItemListVo();
                    legalTwelveItemFormVo.Occupation_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["occupation_code"]);
                    legalTwelveItemFormVo.Occupation_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["occupation_name"]);
                    legalTwelveItemFormVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    legalTwelveItemFormVo.Staff_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["staff_name"]);
                    legalTwelveItemFormVo.Employment_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_date"]);
                    legalTwelveItemFormVo.Students_01_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_01_flag"]);
                    legalTwelveItemFormVo.Students_02_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_02_flag"]);
                    legalTwelveItemFormVo.Students_03_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_03_flag"]);
                    legalTwelveItemFormVo.Students_04_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_04_flag"]);
                    legalTwelveItemFormVo.Students_05_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_05_flag"]);
                    legalTwelveItemFormVo.Students_06_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_06_flag"]);
                    legalTwelveItemFormVo.Students_07_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_07_flag"]);
                    legalTwelveItemFormVo.Students_08_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_08_flag"]);
                    legalTwelveItemFormVo.Students_09_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_09_flag"]);
                    legalTwelveItemFormVo.Students_10_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_10_flag"]);
                    legalTwelveItemFormVo.Students_11_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_11_flag"]);
                    legalTwelveItemFormVo.Students_12_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_12_flag"]);
                    listLegalTwelveItemFormVo.Add(legalTwelveItemFormVo);
                }
                return listLegalTwelveItemFormVo;
            }
        }

        /// <summary>
        /// InsertLegalTwelveItem
        /// </summary>
        /// <param name="legalTwelveItemVo"></param>
        /// <returns></returns>
        public int InsertLegalTwelveItem(LegalTwelveItemVo legalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO legal_twelve_item(students_date," +
                                                                   "students_code," +
                                                                   "students_flag," +
                                                                   "staff_code," +
                                                                   "staff_sign," +
                                                                   "sign_number," +
                                                                   "memo," +
                                                                   "insert_pc_name," +
                                                                   "insert_ymd_hms," +
                                                                   "update_pc_name," +
                                                                   "update_ymd_hms," +
                                                                   "delete_pc_name," +
                                                                   "delete_ymd_hms," +
                                                                   "delete_flag) " +
                                     "VALUES (" + legalTwelveItemVo.Students_date + "," +
                                            "'" + legalTwelveItemVo.Students_code + "'," +
                                             "" + legalTwelveItemVo.Students_flag + "," +
                                             "" + legalTwelveItemVo.Staff_code + "," +
                                            "@member_picture," +
                                             "" + legalTwelveItemVo.Sign_number + "," +
                                            "'" + legalTwelveItemVo.Memo + "'," +
                                            "'" + legalTwelveItemVo.Insert_pc_name + "'," +
                                            "'" + legalTwelveItemVo.Insert_ymd_hms + "'," +
                                            "'" + legalTwelveItemVo.Update_pc_name + "'," +
                                            "'" + legalTwelveItemVo.Update_ymd_hms + "'," +
                                            "'" + legalTwelveItemVo.Delete_pc_name + "'," +
                                            "'" + legalTwelveItemVo.Delete_ymd_hms + "'," +
                                            "'" + legalTwelveItemVo.Delete_flag + "'" +
                                            ");";
            if(legalTwelveItemVo.Staff_sign is not null)
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, legalTwelveItemVo.Staff_sign.Length).Value = legalTwelveItemVo.Staff_sign;
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
