/*
 * 2022/05/21
 */
using System.Data;

using Common;

using Vo;

namespace Dao {
    public class CommuterInsuranceDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        public CommuterInsuranceDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// CheckCommuterInsurance
        /// レコードの存在チェック
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public bool CheckCommuterInsurance(int staffCode) {
            int count;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(staff_code) " +
                                     "FROM commuterInsurance " +
                                     "WHERE staff_code = " + staffCode;
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// InsertOneMeansOfCommuting
        /// </summary>
        /// <param name="commuterInsuranceVo"></param>
        /// <returns></returns>
        public int InsertOneCommuterInsurance(CommuterInsuranceVo commuterInsuranceVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO commuterInsurance(staff_code," +
                                                                   "means_of_commuting," +
                                                                   "notification," +
                                                                   "insurance_company_name," +
                                                                   "payment," +
                                                                   "car_number," +
                                                                   "start_date," +
                                                                   "end_date," +
                                                                   "note," +
                                                                   "picture_1," +
                                                                   "picture_2," +
                                                                   "insert_ymd_hms," +
                                                                   "update_ymd_hms," +
                                                                   "delete_ymd_hms," +
                                                                   "delete_flag) " +
                                     "VALUES ('" + commuterInsuranceVo.Staff_code + "'," +
                                             "'" + commuterInsuranceVo.CommuterInsurance + "'," +
                                             "'" + commuterInsuranceVo.Notification + "'," +
                                             "'" + commuterInsuranceVo.InsuranceCompanyName + "'," +
                                             "'" + commuterInsuranceVo.Payment + "'," +
                                             "'" + commuterInsuranceVo.CarNumber + "'," +
                                             "'" + commuterInsuranceVo.StartDate + "'," +
                                             "'" + commuterInsuranceVo.EndDate + "'," +
                                             "'" + commuterInsuranceVo.Note + "'," +
                                             "@member_picture_1," +
                                             "@member_picture_2," +
                                             "'" + DateTime.Now + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture_1", SqlDbType.Image, commuterInsuranceVo.PictureHead.Length).Value = commuterInsuranceVo.PictureHead;
                sqlCommand.Parameters.Add("@member_picture_2", SqlDbType.Image, commuterInsuranceVo.PictureTail.Length).Value = commuterInsuranceVo.PictureTail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectAllCommuterInsurance
        /// </summary>
        /// <returns></returns>
        public List<CommuterInsuranceVo> SelectAllCommuterInsurance() {
            var listCommuterInsuranceVo = new List<CommuterInsuranceVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_master.belongs," +
                                            "staff_master.staff_code," +
                                            "staff_master.name," +
                                            "staff_master.name_kana," +
                                            "staff_master.retirement_flag," +
                                            "commuterInsurance.means_of_commuting," +
                                            "commuterInsurance.notification," +
                                            "commuterInsurance.insurance_company_name," +
                                            "commuterInsurance.payment," +
                                            "commuterInsurance.car_number," +
                                            "commuterInsurance.start_date," +
                                            "commuterInsurance.end_date," +
                                            "commuterInsurance.note," +
                                            "commuterInsurance.insert_ymd_hms," +
                                            "commuterInsurance.update_ymd_hms," +
                                            "commuterInsurance.delete_ymd_hms," +
                                            "commuterInsurance.delete_flag " +
                                     "FROM commuterInsurance LEFT OUTER JOIN staff_master ON commuterInsurance.staff_code = staff_master.staff_code " +
                                     "WHERE staff_master.retirement_flag = 'False' " +
                                     "ORDER BY staff_master.name_kana ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var commuterInsuranceVo = new CommuterInsuranceVo();
                    commuterInsuranceVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["belongs"]);
                    commuterInsuranceVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    commuterInsuranceVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    commuterInsuranceVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    commuterInsuranceVo.Retirement_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["retirement_flag"]);
                    commuterInsuranceVo.CommuterInsurance = _defaultValue.GetDefaultValue<string>(sqlDataReader["means_of_commuting"]);
                    commuterInsuranceVo.Notification = _defaultValue.GetDefaultValue<bool>(sqlDataReader["notification"]);
                    commuterInsuranceVo.InsuranceCompanyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["insurance_company_name"]);
                    commuterInsuranceVo.Payment = _defaultValue.GetDefaultValue<bool>(sqlDataReader["payment"]);
                    commuterInsuranceVo.CarNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_number"]);
                    commuterInsuranceVo.StartDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["start_date"]);
                    commuterInsuranceVo.EndDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["end_date"]);
                    commuterInsuranceVo.Note = _defaultValue.GetDefaultValue<string>(sqlDataReader["note"]);
                    commuterInsuranceVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    commuterInsuranceVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    commuterInsuranceVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    commuterInsuranceVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listCommuterInsuranceVo.Add(commuterInsuranceVo);
                }
            }
            return listCommuterInsuranceVo;
        }

        /// <summary>
        /// SelectOneMeansOfCommutingVo
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public CommuterInsuranceVo SelectOneCommuterInsurance(int staffCode) {
            var commuterInsuranceVo = new CommuterInsuranceVo();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_master.belongs," +
                                            "staff_master.staff_code," +
                                            "staff_master.name," +
                                            "staff_master.name_kana," +
                                            "staff_master.retirement_flag," +
                                            "commuterInsurance.means_of_commuting," +
                                            "commuterInsurance.notification," +
                                            "commuterInsurance.insurance_company_name," +
                                            "commuterInsurance.payment," +
                                            "commuterInsurance.car_number," +
                                            "commuterInsurance.start_date," +
                                            "commuterInsurance.end_date," +
                                            "commuterInsurance.note," +
                                            "commuterInsurance.picture_1," +
                                            "commuterInsurance.picture_2," +
                                            "commuterInsurance.insert_ymd_hms," +
                                            "commuterInsurance.update_ymd_hms," +
                                            "commuterInsurance.delete_ymd_hms," +
                                            "commuterInsurance.delete_flag " +
                                     "FROM commuterInsurance LEFT OUTER JOIN staff_master ON commuterInsurance.staff_code = staff_master.staff_code " +
                                     "WHERE commuterInsurance.staff_code = '" + staffCode + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    commuterInsuranceVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["belongs"]);
                    commuterInsuranceVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    commuterInsuranceVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    commuterInsuranceVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    commuterInsuranceVo.Retirement_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["retirement_flag"]);
                    commuterInsuranceVo.CommuterInsurance = _defaultValue.GetDefaultValue<string>(sqlDataReader["means_of_commuting"]);
                    commuterInsuranceVo.Notification = _defaultValue.GetDefaultValue<bool>(sqlDataReader["notification"]);
                    commuterInsuranceVo.InsuranceCompanyName = _defaultValue.GetDefaultValue<string>(sqlDataReader["insurance_company_name"]);
                    commuterInsuranceVo.Payment = _defaultValue.GetDefaultValue<bool>(sqlDataReader["payment"]);
                    commuterInsuranceVo.CarNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_number"]);
                    commuterInsuranceVo.StartDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["start_date"]);
                    commuterInsuranceVo.EndDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["end_date"]);
                    commuterInsuranceVo.Note = _defaultValue.GetDefaultValue<string>(sqlDataReader["note"]);
                    commuterInsuranceVo.PictureHead = (byte[])sqlDataReader["picture_1"];
                    commuterInsuranceVo.PictureTail = (byte[])sqlDataReader["picture_2"];
                    commuterInsuranceVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    commuterInsuranceVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    commuterInsuranceVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    commuterInsuranceVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
            }
            return commuterInsuranceVo;
        }

        /// <summary>
        ///  UpdateOneCommuterInsurance
        /// </summary>
        /// <param name="commuterInsuranceVo"></param>
        /// <returns></returns>
        public int UpdateOneCommuterInsurance(CommuterInsuranceVo commuterInsuranceVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE commuterInsurance " +
                                     "SET staff_code = '" + commuterInsuranceVo.Staff_code + "'," +
                                         "means_of_commuting = '" + commuterInsuranceVo.CommuterInsurance + "'," +
                                         "notification = '" + commuterInsuranceVo.Notification + "'," +
                                         "insurance_company_name = '" + commuterInsuranceVo.InsuranceCompanyName + "'," +
                                         "payment = '" + commuterInsuranceVo.Payment + "'," +
                                         "car_number = '" + commuterInsuranceVo.CarNumber + "'," +
                                         "start_date = '" + commuterInsuranceVo.StartDate + "'," +
                                         "end_date = '" + commuterInsuranceVo.EndDate + "'," +
                                         "note = '" + commuterInsuranceVo.Note + "'," +
                                         "picture_1 = @member_picture_1," +
                                         "picture_2 = @member_picture_2," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE staff_code='" + commuterInsuranceVo.Staff_code + "' " +
                                     "AND delete_Flag = 'False'";
            try {
                sqlCommand.Parameters.Add("@member_picture_1", SqlDbType.Image, commuterInsuranceVo.PictureHead.Length).Value = commuterInsuranceVo.PictureHead;
                sqlCommand.Parameters.Add("@member_picture_2", SqlDbType.Image, commuterInsuranceVo.PictureTail.Length).Value = commuterInsuranceVo.PictureTail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
