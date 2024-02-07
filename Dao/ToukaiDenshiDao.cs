using Common;

using H_Vo;

namespace Dao {
    public class ToukaiDenshiDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ToukaiDenshiDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        public List<LicenseMasterVo> SelectAllLicenseMaster() {
            var listLicenseMasterVo = new List<LicenseMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT license_master.staff_code," +
                                            "license_master.name_kana," +
                                            "staff_master.display_name," +
                                            "license_master.birth_date," +
                                            "license_master.current_address," +
                                            "license_master.delivery_date," +
                                            "license_master.expiration_date," +
                                            "license_master.license_condition," +
                                            "license_master.license_number," +
                                            "license_master.get_date_1," +
                                            "license_master.get_date_2," +
                                            "license_master.get_date_3," +
                                            //"license_master.picture_head," +
                                            //"license_master.picture_tail," +
                                            "license_master.large," +
                                            "license_master.medium," +
                                            "license_master.quasi_medium," +
                                            "license_master.ordinary," +
                                            "license_master.big_special," +
                                            "license_master.big_auto_bike," +
                                            "license_master.ordinary_auto_bike," +
                                            "license_master.small_special," +
                                            "license_master.with_a_raw," +
                                            "license_master.big_two," +
                                            "license_master.medium_two," +
                                            "license_master.ordinary_two," +
                                            "license_master.big_special_two," +
                                            "license_master.traction," +
                                            "license_master.insert_ymd_hms," +
                                            "license_master.update_ymd_hms," +
                                            "license_master.delete_ymd_hms," +
                                            "license_master.delete_flag " +
                                     "FROM license_master " +
                                     "LEFT JOIN staff_master ON license_master.staff_code = staff_master.staff_code " +
                                     "WHERE staff_master.retirement_flag = 'False' " +
                                       "AND license_master.delete_flag = 'False'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    LicenseMasterVo licenseMasterVo = new();
                    licenseMasterVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    licenseMasterVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    licenseMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
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
    }
}
