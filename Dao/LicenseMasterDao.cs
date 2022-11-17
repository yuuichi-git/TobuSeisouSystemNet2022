using System.Data;

using Common;

using Vo;

namespace Dao {
    public class LicenseMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionVo"></param>
        public LicenseMasterDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// レコードの存在チェック
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public bool CheckLicenseMaster(int staffCode) {
            int count = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(staff_code) " +
                                     "FROM license_master " +
                                     "WHERE staff_code = '" + staffCode + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch (Exception e) {
                Console.WriteLine("CheckLicenseLedger : " + e.Message);
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// SelectAllLicenseMaster
        /// </summary>
        /// <returns></returns>
        public List<LicenseMasterVo> SelectAllLicenseMaster() {
            var listLicenseMasterVo = new List<LicenseMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_code," +
                                            "name_kana," +
                                            "name," +
                                            "birth_date," +
                                            "current_address," +
                                            "delivery_date," +
                                            "expiration_date," +
                                            "license_condition," +
                                            "license_number," +
                                            "get_date_1," +
                                            "get_date_2," +
                                            "get_date_3," +
                                            //"picture_head," +
                                            //"picture_tail," +
                                            "large," +
                                            "medium," +
                                            "quasi_medium," +
                                            "ordinary," +
                                            "big_special," +
                                            "big_auto_bike," +
                                            "ordinary_auto_bike," +
                                            "small_special," +
                                            "with_a_raw," +
                                            "big_two," +
                                            "medium_two," +
                                            "ordinary_two," +
                                            "big_special_two," +
                                            "traction," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM license_master WITH(NOLOCK) " +
                                     "WHERE delete_flag = 'False'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var licenseMasterVo = new LicenseMasterVo();
                    licenseMasterVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    licenseMasterVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    licenseMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    licenseMasterVo.Birth_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["birth_date"]);
                    licenseMasterVo.Current_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["current_address"]);
                    licenseMasterVo.Delivery_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delivery_date"]);
                    licenseMasterVo.Expiration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["expiration_date"]);
                    licenseMasterVo.License_condition = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_condition"]);
                    licenseMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    licenseMasterVo.Get_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["get_date_1"]);
                    licenseMasterVo.Get_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["get_date_2"]);
                    licenseMasterVo.Get_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["get_date_3"]);
                    //licenseLedgerVo.Picture_head = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture_head"]);
                    //licenseLedgerVo.Picture_tail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture_tail"]);
                    licenseMasterVo.Large = _defaultValue.GetDefaultValue<bool>(sqlDataReader["large"]);
                    licenseMasterVo.Medium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["medium"]);
                    licenseMasterVo.Quasi_medium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["quasi_medium"]);
                    licenseMasterVo.Ordinary = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ordinary"]);
                    licenseMasterVo.Big_special = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_special"]);
                    licenseMasterVo.Big_auto_bike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_auto_bike"]);
                    licenseMasterVo.Ordinary_auto_bike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ordinary_auto_bike"]);
                    licenseMasterVo.Small_special = _defaultValue.GetDefaultValue<bool>(sqlDataReader["small_special"]);
                    licenseMasterVo.With_a_raw = _defaultValue.GetDefaultValue<bool>(sqlDataReader["with_a_raw"]);
                    licenseMasterVo.Big_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_two"]);
                    licenseMasterVo.Medium_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["medium_two"]);
                    licenseMasterVo.Ordinary_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ordinary_two"]);
                    licenseMasterVo.Big_special_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_special_two"]);
                    licenseMasterVo.Traction = _defaultValue.GetDefaultValue<bool>(sqlDataReader["traction"]);
                    licenseMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    licenseMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    licenseMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    licenseMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listLicenseMasterVo.Add(licenseMasterVo);
                }
                return listLicenseMasterVo;
            }
        }

        /// <summary>
        /// SelectOneLicenseMaster
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public LicenseMasterVo SelectOneLicenseMaster(int staffCode) {
            var licenseMasterVo = new LicenseMasterVo();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_code," +
                                            "name_kana," +
                                            "name," +
                                            "birth_date," +
                                            "current_address," +
                                            "delivery_date," +
                                            "expiration_date," +
                                            "license_condition," +
                                            "license_number," +
                                            "get_date_1," +
                                            "get_date_2," +
                                            "get_date_3," +
                                            "picture_head," +
                                            "picture_tail," +
                                            "large," +
                                            "medium," +
                                            "quasi_medium," +
                                            "ordinary," +
                                            "big_special," +
                                            "big_auto_bike," +
                                            "ordinary_auto_bike," +
                                            "small_special," +
                                            "with_a_raw," +
                                            "big_two," +
                                            "medium_two," +
                                            "ordinary_two," +
                                            "big_special_two," +
                                            "traction," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM license_master " +
                                     "Where staff_code = " + staffCode;
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    licenseMasterVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    licenseMasterVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    licenseMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    licenseMasterVo.Birth_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["birth_date"]);
                    licenseMasterVo.Current_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["current_address"]);
                    licenseMasterVo.Delivery_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delivery_date"]);
                    licenseMasterVo.Expiration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["expiration_date"]);
                    licenseMasterVo.License_condition = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_condition"]);
                    licenseMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    licenseMasterVo.Get_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["get_date_1"]);
                    licenseMasterVo.Get_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["get_date_2"]);
                    licenseMasterVo.Get_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["get_date_3"]);
                    licenseMasterVo.Picture_head = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture_head"]);
                    licenseMasterVo.Picture_tail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture_tail"]);
                    licenseMasterVo.Large = _defaultValue.GetDefaultValue<bool>(sqlDataReader["large"]);
                    licenseMasterVo.Medium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["medium"]);
                    licenseMasterVo.Quasi_medium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["quasi_medium"]);
                    licenseMasterVo.Ordinary = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ordinary"]);
                    licenseMasterVo.Big_special = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_special"]);
                    licenseMasterVo.Big_auto_bike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_auto_bike"]);
                    licenseMasterVo.Ordinary_auto_bike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ordinary_auto_bike"]);
                    licenseMasterVo.Small_special = _defaultValue.GetDefaultValue<bool>(sqlDataReader["small_special"]);
                    licenseMasterVo.With_a_raw = _defaultValue.GetDefaultValue<bool>(sqlDataReader["with_a_raw"]);
                    licenseMasterVo.Big_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_two"]);
                    licenseMasterVo.Medium_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["medium_two"]);
                    licenseMasterVo.Ordinary_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ordinary_two"]);
                    licenseMasterVo.Big_special_two = _defaultValue.GetDefaultValue<bool>(sqlDataReader["big_special_two"]);
                    licenseMasterVo.Traction = _defaultValue.GetDefaultValue<bool>(sqlDataReader["traction"]);
                    licenseMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    licenseMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    licenseMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    licenseMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
                return licenseMasterVo;
            }
        }

        /// <summary>
        /// InsertOneLicenseMaster
        /// </summary>
        /// <param name="licenseMasterVo"></param>
        /// <returns></returns>
        public int InsertOneLicenseMaster(LicenseMasterVo licenseMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO license_master(staff_code," +
                                                                "name_kana," +
                                                                "name," +
                                                                "birth_date," +
                                                                "current_address," +
                                                                "delivery_date," +
                                                                "expiration_date," +
                                                                "license_condition," +
                                                                "license_number," +
                                                                "get_date_1," +
                                                                "get_date_2," +
                                                                "get_date_3," +
                                                                "picture_head," +
                                                                "picture_tail," +
                                                                "large," +
                                                                "medium," +
                                                                "quasi_medium," +
                                                                "ordinary," +
                                                                "big_special," +
                                                                "big_auto_bike," +
                                                                "ordinary_auto_bike," +
                                                                "small_special," +
                                                                "with_a_raw," +
                                                                "big_two," +
                                                                "medium_two," +
                                                                "ordinary_two," +
                                                                "big_special_two," +
                                                                "traction," +
                                                                "insert_ymd_hms," +
                                                                "update_ymd_hms," +
                                                                "delete_ymd_hms," +
                                                                "delete_flag) " +
                                     "VALUES ('" + licenseMasterVo.Staff_code + "'," +
                                             "'" + licenseMasterVo.Name_kana + "'," +
                                             "'" + licenseMasterVo.Name + "'," +
                                             "'" + licenseMasterVo.Birth_date + "'," +
                                             "'" + licenseMasterVo.Current_address + "'," +
                                             "'" + licenseMasterVo.Delivery_date + "'," +
                                             "'" + licenseMasterVo.Expiration_date + "'," +
                                             "'" + licenseMasterVo.License_condition + "'," +
                                             "'" + licenseMasterVo.License_number + "'," +
                                             "'" + licenseMasterVo.Get_date_1 + "'," +
                                             "'" + licenseMasterVo.Get_date_2 + "'," +
                                             "'" + licenseMasterVo.Get_date_3 + "'," +
                                             "@member_picture_head," +
                                             "@member_picture_tail," +
                                             "'" + licenseMasterVo.Large + "'," +
                                             "'" + licenseMasterVo.Medium + "'," +
                                             "'" + licenseMasterVo.Quasi_medium + "'," +
                                             "'" + licenseMasterVo.Ordinary + "'," +
                                             "'" + licenseMasterVo.Big_special + "'," +
                                             "'" + licenseMasterVo.Big_auto_bike + "'," +
                                             "'" + licenseMasterVo.Ordinary_auto_bike + "'," +
                                             "'" + licenseMasterVo.Small_special + "'," +
                                             "'" + licenseMasterVo.With_a_raw + "'," +
                                             "'" + licenseMasterVo.Big_two + "'," +
                                             "'" + licenseMasterVo.Medium_two + "'," +
                                             "'" + licenseMasterVo.Ordinary_two + "'," +
                                             "'" + licenseMasterVo.Big_special_two + "'," +
                                             "'" + licenseMasterVo.Traction + "'," +
                                             "'" + DateTime.Now + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture_head", SqlDbType.Image, licenseMasterVo.Picture_head.Length).Value = licenseMasterVo.Picture_head;
                sqlCommand.Parameters.Add("@member_picture_tail", SqlDbType.Image, licenseMasterVo.Picture_tail.Length).Value = licenseMasterVo.Picture_tail;
                return sqlCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine("InsertOneLicenseLedger : " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// UpdateOneLicenseLedger
        /// </summary>
        /// <param name="licenseMasterVo"></param>
        /// <returns></returns>
        public int UpdateOneLicenseLedger(LicenseMasterVo licenseMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE license_master " +
                                     "SET staff_code = '" + licenseMasterVo.Staff_code + "'," +
                                         "name_kana = '" + licenseMasterVo.Name_kana + "'," +
                                         "name = '" + licenseMasterVo.Name + "'," +
                                         "birth_date = '" + licenseMasterVo.Birth_date + "'," +
                                         "current_address = '" + licenseMasterVo.Current_address + "'," +
                                         "delivery_date = '" + licenseMasterVo.Delivery_date + "'," +
                                         "expiration_date = '" + licenseMasterVo.Expiration_date + "'," +
                                         "license_condition = '" + licenseMasterVo.License_condition + "'," +
                                         "license_number = '" + licenseMasterVo.License_number + "'," +
                                         "get_date_1 = '" + licenseMasterVo.Get_date_1 + "'," +
                                         "get_date_2 = '" + licenseMasterVo.Get_date_2 + "'," +
                                         "get_date_3 = '" + licenseMasterVo.Get_date_3 + "'," +
                                         "picture_head = @member_picture_head," +
                                         "picture_tail = @member_picture_tail," +
                                         "large = '" + licenseMasterVo.Large + "'," +
                                         "medium = '" + licenseMasterVo.Medium + "'," +
                                         "quasi_medium = '" + licenseMasterVo.Quasi_medium + "'," +
                                         "ordinary = '" + licenseMasterVo.Ordinary + "'," +
                                         "big_special = '" + licenseMasterVo.Big_special + "'," +
                                         "big_auto_bike = '" + licenseMasterVo.Big_auto_bike + "'," +
                                         "ordinary_auto_bike = '" + licenseMasterVo.Ordinary_auto_bike + "'," +
                                         "small_special = '" + licenseMasterVo.Small_special + "'," +
                                         "with_a_raw = '" + licenseMasterVo.With_a_raw + "'," +
                                         "big_two = '" + licenseMasterVo.Big_two + "'," +
                                         "medium_two = '" + licenseMasterVo.Medium_two + "'," +
                                         "ordinary_two = '" + licenseMasterVo.Ordinary_two + "'," +
                                         "big_special_two = '" + licenseMasterVo.Big_special_two + "'," +
                                         "traction = '" + licenseMasterVo.Traction + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE staff_code = " + licenseMasterVo.Staff_code + " " +
                                     "AND delete_Flag = 'False'";
            try {
                sqlCommand.Parameters.Add("@member_picture_head", SqlDbType.Image, licenseMasterVo.Picture_head.Length).Value = licenseMasterVo.Picture_head;
                sqlCommand.Parameters.Add("@member_picture_tail", SqlDbType.Image, licenseMasterVo.Picture_tail.Length).Value = licenseMasterVo.Picture_tail;
                return sqlCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine("UpdateOneLicenseLedger : " + e.Message);
                return 0;
            }
        }
    }
}
