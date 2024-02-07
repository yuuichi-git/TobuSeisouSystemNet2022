using System.Data;
using System.Data.SqlClient;

using Common;

using H_Vo;

namespace Dao {
    public class LegalTwelveItemDao {
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        /*
         * Dictionary
         */
        private readonly Dictionary<int, string> _dictionaryBelongs = new Dictionary<int, string> { { 10, "役員" }, { 11, "社員" }, { 12, "アルバイト" }, { 13, "派遣" }, { 20, "新運転" }, { 21, "自運労" } };
        private readonly Dictionary<int, string> _dictionaryJobForm = new Dictionary<int, string> { { 10, "長期雇用" }, { 11, "手帳" }, { 12, "アルバイト" }, { 99, "" } };

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
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
        public List<LegalTwelveItemListVo> SelectLegalTwelveItemList(DateTime startDate, DateTime endDate, bool allTermFlag) {
            /*
             * 短期を含めるかどうかのSQLを作成
             */
            string allTerm;
            if(allTermFlag) {
                allTerm = "staff_master.belongs IN (10,11,12,20,21) AND staff_master.job_form IN(10,11,12,99) AND staff_master.retirement_flag = 'false' ";
            } else {
                allTerm = "staff_master.belongs IN (10,11,12,20,21) AND staff_master.job_form IN(10,12,99) AND staff_master.occupation = 10 AND staff_master.retirement_flag = 'false' ";
            }

            List<LegalTwelveItemListVo> listLegalTwelveItemFormVo = new List<LegalTwelveItemListVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_master.belongs AS belongs_code," +
                                            "staff_master.job_form AS job_form_code," +
                                            "staff_master.occupation AS occupation_code," +
                                            "occupation_master.name AS occupation_name," +
                                            "staff_master.staff_code," +
                                            "staff_master.name AS staff_name," +
                                            "staff_master.employment_date," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 0 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_01_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 1 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_02_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 2 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_03_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 3 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_04_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 4 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_05_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 5 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_06_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 6 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_07_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 7 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_08_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 8 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_09_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 9 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_10_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 10 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_11_flag," +
                                            "(SELECT students_flag FROM legal_twelve_item WHERE staff_master.staff_code = legal_twelve_item.staff_code " +
                                                                                           "AND legal_twelve_item.students_code = 11 " +
                                                                                           "AND legal_twelve_item.students_date BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS students_12_flag " +
                                     "FROM staff_master " +
                                     "LEFT OUTER JOIN occupation_master ON staff_master.occupation = occupation_master.code " +
                                     "WHERE " + allTerm + " AND staff_master.retirement_flag = 'false' " +
                                     "ORDER BY staff_master.name_kana ASC";
            using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    LegalTwelveItemListVo legalTwelveItemListVo = new LegalTwelveItemListVo();
                    legalTwelveItemListVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["belongs_code"]);
                    legalTwelveItemListVo.Belongs_name = _dictionaryBelongs[legalTwelveItemListVo.Belongs];
                    legalTwelveItemListVo.Job_form = _defaultValue.GetDefaultValue<int>(sqlDataReader["job_form_code"]);
                    legalTwelveItemListVo.Job_form_name = _dictionaryJobForm[legalTwelveItemListVo.Job_form];
                    legalTwelveItemListVo.Occupation_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["occupation_code"]);
                    legalTwelveItemListVo.Occupation_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["occupation_name"]);
                    legalTwelveItemListVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    legalTwelveItemListVo.Staff_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["staff_name"]);
                    legalTwelveItemListVo.Employment_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_date"]);
                    legalTwelveItemListVo.Students_01_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_01_flag"]);
                    legalTwelveItemListVo.Students_02_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_02_flag"]);
                    legalTwelveItemListVo.Students_03_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_03_flag"]);
                    legalTwelveItemListVo.Students_04_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_04_flag"]);
                    legalTwelveItemListVo.Students_05_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_05_flag"]);
                    legalTwelveItemListVo.Students_06_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_06_flag"]);
                    legalTwelveItemListVo.Students_07_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_07_flag"]);
                    legalTwelveItemListVo.Students_08_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_08_flag"]);
                    legalTwelveItemListVo.Students_09_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_09_flag"]);
                    legalTwelveItemListVo.Students_10_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_10_flag"]);
                    legalTwelveItemListVo.Students_11_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_11_flag"]);
                    legalTwelveItemListVo.Students_12_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["students_12_flag"]);
                    listLegalTwelveItemFormVo.Add(legalTwelveItemListVo);
                }
                return listLegalTwelveItemFormVo;
            }
        }

        /// <summary>
        /// InsertLegalTwelveItem
        /// </summary>
        /// <param name="legalTwelveItemVo"></param>
        /// <returns></returns>
        public int InsertOneLegalTwelveItem(LegalTwelveItemVo legalTwelveItemVo) {
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
                                     "VALUES ('" + legalTwelveItemVo.Students_date + "'," +
                                              "" + legalTwelveItemVo.Students_code + "," +
                                             "'" + legalTwelveItemVo.Students_flag + "'," +
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

        /// <summary>
        /// UpdateOneLegalTwelveItem
        /// </summary>
        /// <param name="oldStudentsDate">変更前のVo</param>
        /// <param name="newLegalTwelveItemVo">変更後のVo</param>
        /// <returns></returns>
        public int UpdateOneLegalTwelveItem(LegalTwelveItemVo oldLegalTwelveItemVo, LegalTwelveItemVo newLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE legal_twelve_item " +
                                     "SET students_date = '" + _defaultValue.GetDefaultValue<DateTime>(newLegalTwelveItemVo.Students_date) + "'," +
                                         "students_code = " + _defaultValue.GetDefaultValue<int>(newLegalTwelveItemVo.Students_code) + "," +
                                         "students_flag = '" + _defaultValue.GetDefaultValue<bool>(newLegalTwelveItemVo.Students_flag) + "'," +
                                         "staff_code = " + _defaultValue.GetDefaultValue<int>(newLegalTwelveItemVo.Staff_code) + "," +
                                         "staff_sign = @member_picture," +
                                         "sign_number = " + _defaultValue.GetDefaultValue<int>(newLegalTwelveItemVo.Sign_number) + "," +
                                         "memo = '" + _defaultValue.GetDefaultValue<string>(newLegalTwelveItemVo.Memo) + "'," +
                                         "insert_pc_name = '" + _defaultValue.GetDefaultValue<string>(newLegalTwelveItemVo.Insert_pc_name) + "'," +
                                         "insert_ymd_hms = '" + _defaultValue.GetDefaultValue<DateTime>(newLegalTwelveItemVo.Insert_ymd_hms) + "'," +
                                         "update_pc_name = '" + _defaultValue.GetDefaultValue<string>(newLegalTwelveItemVo.Update_pc_name) + "'," +
                                         "update_ymd_hms = '" + _defaultValue.GetDefaultValue<DateTime>(newLegalTwelveItemVo.Update_ymd_hms) + "'," +
                                         "delete_pc_name = '" + _defaultValue.GetDefaultValue<string>(newLegalTwelveItemVo.Delete_pc_name) + "'," +
                                         "delete_ymd_hms = '" + _defaultValue.GetDefaultValue<DateTime>(newLegalTwelveItemVo.Delete_ymd_hms) + "'," +
                                         "delete_flag = '" + _defaultValue.GetDefaultValue<bool>(newLegalTwelveItemVo.Delete_flag) + "' " +
                                     "WHERE (students_date BETWEEN '" + oldLegalTwelveItemVo.Students_date + "' AND '" + oldLegalTwelveItemVo.Students_date + "') " +
                                     "AND students_code = " + oldLegalTwelveItemVo.Students_code + " " +
                                     "AND staff_code = " + oldLegalTwelveItemVo.Staff_code;
            if(newLegalTwelveItemVo.Staff_sign is not null)
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, newLegalTwelveItemVo.Staff_sign.Length).Value = newLegalTwelveItemVo.Staff_sign;
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteOneLegalTwelveItem
        /// </summary>
        /// <param name="legalTwelveItemVo"></param>
        /// <returns></returns>
        public int DeleteOneLegalTwelveItem(LegalTwelveItemVo oldLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM legal_twelve_item " +
                                     "WHERE (students_date BETWEEN '" + oldLegalTwelveItemVo.Students_date + "' AND '" + oldLegalTwelveItemVo.Students_date + "') " +
                                     "AND students_code = " + oldLegalTwelveItemVo.Students_code + " " +
                                     "AND staff_code = " + oldLegalTwelveItemVo.Staff_code;
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// CheckLegalTwelveItem
        /// </summary>
        /// <param name="oldLegalTwelveItemVo">変更前のVo</param>
        /// <returns></returns>
        public bool CheckLegalTwelveItem(LegalTwelveItemVo oldLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(students_date) " +
                                     "FROM legal_twelve_item " +
                                     "WHERE (students_date BETWEEN '" + oldLegalTwelveItemVo.Students_date + "' AND '" + oldLegalTwelveItemVo.Students_date + "') " +
                                     "AND students_code = " + oldLegalTwelveItemVo.Students_code + " " +
                                     "AND staff_code = " + oldLegalTwelveItemVo.Staff_code;
            try {
                return (int)sqlCommand.ExecuteScalar() > 0 ? true : false;
            } catch {
                throw;
            }
        }
    }
}
