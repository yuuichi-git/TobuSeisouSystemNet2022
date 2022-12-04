using System.Data;

using Common;

using Vo;

namespace Dao {
    public class CarAccidentMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connetionVo"></param>
        public CarAccidentMasterDao(ConnectionVo connetionVo) {
            _connectionVo = connetionVo;
        }

        /// <summary>
        /// CheckCarAccidentLedger
        /// </summary>
        /// <param name="insertYmdHms"></param>
        /// <returns></returns>
        public bool CheckCarAccidentMaster(DateTime insertYmdHms) {
            int count = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(occurrence_ymd_hms) " +
                                     "FROM car_accident_master " +
                                     "WHERE insert_ymd_hms = '" + insertYmdHms + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch(Exception e) {
                Console.WriteLine("CheckCarAccidentLedger : " + e.Message);
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// SelectAllCarAccidentLedger
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public List<CarAccidentMasterVo> SelectAllCarAccidentMaster(DateTime date1, DateTime date2) {
            var datetimeStart = date1.ToString("yyyy-MM-dd 00:00:00.000");
            var datetimeEnd = date2.ToString("yyyy-MM-dd 23:59:59.000");
            var listCarAccidentMasterVo = new List<CarAccidentMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT totalling_flag," +
                                            "occurrence_ymd_hms," +
                                            "weather," +
                                            "accident_kind," +
                                            "car_static," +
                                            "occurrence_cause," +
                                            "negligence," +
                                            "personal_injury," +
                                            "property_accident_1," +
                                            "property_accident_2," +
                                            "occurrence_address," +
                                            "work_kind," +
                                            "staff_code," +
                                            "display_name," +
                                            "license_number," +
                                            "car_registration_number," +
                                            "accident_summary," +
                                            "accident_detail," +
                                            "guide," +
                                            //"picture1," +
                                            //"picture2," +
                                            //"picture3," +
                                            //"picture4," +
                                            //"picture5," +
                                            //"picture6," +
                                            //"picture7," +
                                            //"picture8," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM car_accident_master " +
                                     "WHERE (occurrence_ymd_hms BETWEEN '" + datetimeStart + "' AND '" + datetimeEnd + "') " +
                                     "ORDER BY occurrence_ymd_hms ASC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var carAccidentMasterVo = new CarAccidentMasterVo();
                    carAccidentMasterVo.Totalling_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["totalling_flag"]);
                    carAccidentMasterVo.Occurrence_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["occurrence_ymd_hms"]);
                    carAccidentMasterVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["weather"]);
                    carAccidentMasterVo.Accident_kind = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_kind"]);
                    carAccidentMasterVo.Car_static = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_static"]);
                    carAccidentMasterVo.Occurrence_cause = _defaultValue.GetDefaultValue<string>(sqlDataReader["occurrence_cause"]);
                    carAccidentMasterVo.Negligence = _defaultValue.GetDefaultValue<string>(sqlDataReader["negligence"]);
                    carAccidentMasterVo.Personal_injury = _defaultValue.GetDefaultValue<string>(sqlDataReader["personal_injury"]);
                    carAccidentMasterVo.Property_accident_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["property_accident_1"]);
                    carAccidentMasterVo.Property_accident_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["property_accident_2"]);
                    carAccidentMasterVo.Occurrence_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["occurrence_address"]);
                    carAccidentMasterVo.Work_kind = _defaultValue.GetDefaultValue<string>(sqlDataReader["work_kind"]);
                    carAccidentMasterVo.Staff_code = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["staff_code"]);
                    carAccidentMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    carAccidentMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    carAccidentMasterVo.Car_registration_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_registration_number"]);
                    carAccidentMasterVo.Accident_summary = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_summary"]);
                    carAccidentMasterVo.Accident_detail = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_detail"]);
                    carAccidentMasterVo.Guide = _defaultValue.GetDefaultValue<string>(sqlDataReader["guide"]);
                    //carAccidentLedgerVo.Picture1 = DBNull.Value.Equals(sqlDataReader["picture1"]) ? null : (byte[])sqlDataReader["picture1"];
                    //carAccidentLedgerVo.Picture2 = DBNull.Value.Equals(sqlDataReader["picture2"]) ? null : (byte[])sqlDataReader["picture2"];
                    //carAccidentLedgerVo.Picture3 = DBNull.Value.Equals(sqlDataReader["picture3"]) ? null : (byte[])sqlDataReader["picture3"];
                    //carAccidentLedgerVo.Picture4 = DBNull.Value.Equals(sqlDataReader["picture4"]) ? null : (byte[])sqlDataReader["picture4"];
                    //carAccidentLedgerVo.Picture5 = DBNull.Value.Equals(sqlDataReader["picture5"]) ? null : (byte[])sqlDataReader["picture5"];
                    //carAccidentLedgerVo.Picture6 = DBNull.Value.Equals(sqlDataReader["picture6"]) ? null : (byte[])sqlDataReader["picture6"];
                    //carAccidentLedgerVo.Picture7 = DBNull.Value.Equals(sqlDataReader["picture7"]) ? null : (byte[])sqlDataReader["picture7"];
                    //carAccidentLedgerVo.Picture8 = DBNull.Value.Equals(sqlDataReader["picture8"]) ? null : (byte[])sqlDataReader["picture8"];
                    carAccidentMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    carAccidentMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    carAccidentMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    carAccidentMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listCarAccidentMasterVo.Add(carAccidentMasterVo);
                }
                return listCarAccidentMasterVo;
            }
        }

        /// <summary>
        /// SelectOneCarAccidentLedger
        /// </summary>
        /// <param name="insertYmdHms"></param>
        /// <returns></returns>
        public CarAccidentMasterVo SelectOneCarAccidentMaster(DateTime insertYmdHms) {
            var carAccidentMasterVo = new CarAccidentMasterVo();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT totalling_flag," +
                                            "occurrence_ymd_hms," +
                                            "weather," +
                                            "accident_kind," +
                                            "car_static," +
                                            "occurrence_cause," +
                                            "negligence," +
                                            "personal_injury," +
                                            "property_accident_1," +
                                            "property_accident_2," +
                                            "occurrence_address," +
                                            "work_kind," +
                                            "staff_code," +
                                            "display_name," +
                                            "license_number," +
                                            "car_registration_number," +
                                            "accident_summary," +
                                            "accident_detail," +
                                            "guide," +
                                            "picture1," +
                                            "picture2," +
                                            "picture3," +
                                            "picture4," +
                                            "picture5," +
                                            "picture6," +
                                            "picture7," +
                                            "picture8," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM car_accident_master " +
                                     "WHERE insert_ymd_hms = '" + insertYmdHms + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    carAccidentMasterVo.Totalling_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["totalling_flag"]);
                    carAccidentMasterVo.Occurrence_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["occurrence_ymd_hms"]);
                    carAccidentMasterVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["weather"]);
                    carAccidentMasterVo.Accident_kind = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_kind"]);
                    carAccidentMasterVo.Car_static = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_static"]);
                    carAccidentMasterVo.Occurrence_cause = _defaultValue.GetDefaultValue<string>(sqlDataReader["occurrence_cause"]);
                    carAccidentMasterVo.Negligence = _defaultValue.GetDefaultValue<string>(sqlDataReader["negligence"]);
                    carAccidentMasterVo.Personal_injury = _defaultValue.GetDefaultValue<string>(sqlDataReader["personal_injury"]);
                    carAccidentMasterVo.Property_accident_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["property_accident_1"]);
                    carAccidentMasterVo.Property_accident_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["property_accident_2"]);
                    carAccidentMasterVo.Occurrence_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["occurrence_address"]);
                    carAccidentMasterVo.Work_kind = _defaultValue.GetDefaultValue<string>(sqlDataReader["work_kind"]);
                    carAccidentMasterVo.Staff_code = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["staff_code"]);
                    carAccidentMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    carAccidentMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    carAccidentMasterVo.Car_registration_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_registration_number"]);
                    carAccidentMasterVo.Accident_summary = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_summary"]);
                    carAccidentMasterVo.Accident_detail = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_detail"]);
                    carAccidentMasterVo.Guide = _defaultValue.GetDefaultValue<string>(sqlDataReader["guide"]);
                    carAccidentMasterVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture1"]);
                    carAccidentMasterVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture2"]);
                    carAccidentMasterVo.Picture3 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture3"]);
                    carAccidentMasterVo.Picture4 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture4"]);
                    carAccidentMasterVo.Picture5 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture5"]);
                    carAccidentMasterVo.Picture6 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture6"]);
                    carAccidentMasterVo.Picture7 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture7"]);
                    carAccidentMasterVo.Picture8 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture8"]);
                    carAccidentMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    carAccidentMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    carAccidentMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    carAccidentMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
                return carAccidentMasterVo;
            }
        }

        /// <summary>
        /// SelectOneCarAccidentMaster
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public List<CarAccidentMasterVo> SelectOneCarAccidentMaster(decimal staffCode) {
            var listCarAccidentMasterVo = new List<CarAccidentMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT totalling_flag," +
                                            "occurrence_ymd_hms," +
                                            "weather," +
                                            "accident_kind," +
                                            "car_static," +
                                            "occurrence_cause," +
                                            "negligence," +
                                            "personal_injury," +
                                            "property_accident_1," +
                                            "property_accident_2," +
                                            "occurrence_address," +
                                            "work_kind," +
                                            "staff_code," +
                                            "display_name," +
                                            "license_number," +
                                            "car_registration_number," +
                                            "accident_summary," +
                                            "accident_detail," +
                                            "guide," +
                                            "picture1," +
                                            "picture2," +
                                            "picture3," +
                                            "picture4," +
                                            "picture5," +
                                            "picture6," +
                                            "picture7," +
                                            "picture8," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM car_accident_master " +
                                     "WHERE staff_code = '" + staffCode + "' " +
                                     "ORDER BY occurrence_ymd_hms DESC";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var carAccidentMasterVo = new CarAccidentMasterVo();
                    carAccidentMasterVo.Totalling_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["totalling_flag"]);
                    carAccidentMasterVo.Occurrence_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["occurrence_ymd_hms"]);
                    carAccidentMasterVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["weather"]);
                    carAccidentMasterVo.Accident_kind = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_kind"]);
                    carAccidentMasterVo.Car_static = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_static"]);
                    carAccidentMasterVo.Occurrence_cause = _defaultValue.GetDefaultValue<string>(sqlDataReader["occurrence_cause"]);
                    carAccidentMasterVo.Negligence = _defaultValue.GetDefaultValue<string>(sqlDataReader["negligence"]);
                    carAccidentMasterVo.Personal_injury = _defaultValue.GetDefaultValue<string>(sqlDataReader["personal_injury"]);
                    carAccidentMasterVo.Property_accident_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["property_accident_1"]);
                    carAccidentMasterVo.Property_accident_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["property_accident_2"]);
                    carAccidentMasterVo.Occurrence_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["occurrence_address"]);
                    carAccidentMasterVo.Work_kind = _defaultValue.GetDefaultValue<string>(sqlDataReader["work_kind"]);
                    carAccidentMasterVo.Staff_code = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["staff_code"]);
                    carAccidentMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    carAccidentMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    carAccidentMasterVo.Car_registration_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_registration_number"]);
                    carAccidentMasterVo.Accident_summary = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_summary"]);
                    carAccidentMasterVo.Accident_detail = _defaultValue.GetDefaultValue<string>(sqlDataReader["accident_detail"]);
                    carAccidentMasterVo.Guide = _defaultValue.GetDefaultValue<string>(sqlDataReader["guide"]);
                    carAccidentMasterVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture1"]);
                    carAccidentMasterVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture2"]);
                    carAccidentMasterVo.Picture3 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture3"]);
                    carAccidentMasterVo.Picture4 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture4"]);
                    carAccidentMasterVo.Picture5 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture5"]);
                    carAccidentMasterVo.Picture6 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture6"]);
                    carAccidentMasterVo.Picture7 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture7"]);
                    carAccidentMasterVo.Picture8 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture8"]);
                    carAccidentMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    carAccidentMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    carAccidentMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    carAccidentMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listCarAccidentMasterVo.Add(carAccidentMasterVo);
                }
                return listCarAccidentMasterVo;
            }
        }

        /// <summary>
        /// InsertOneCarAccidentLedger
        /// </summary>
        /// <returns></returns>
        public int InsertOneCarAccidentMaster(CarAccidentMasterVo carAccidentMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO car_accident_ledger(totalling_flag," +
                                                                     "occurrence_ymd_hms," +
                                                                     "weather," +
                                                                     "accident_kind," +
                                                                     "car_static," +
                                                                     "occurrence_cause," +
                                                                     "negligence," +
                                                                     "personal_injury," +
                                                                     "property_accident_1," +
                                                                     "property_accident_2," +
                                                                     "occurrence_address," +
                                                                     "work_kind," +
                                                                     "staff_code," +
                                                                     "display_name," +
                                                                     "license_number," +
                                                                     "car_registration_number," +
                                                                     "accident_summary," +
                                                                     "accident_detail," +
                                                                     "guide," +
                                                                     "picture1," +
                                                                     "picture2," +
                                                                     "picture3," +
                                                                     "picture4," +
                                                                     "picture5," +
                                                                     "picture6," +
                                                                     "picture7," +
                                                                     "picture8," +
                                                                     "insert_ymd_hms," +
                                                                     "update_ymd_hms," +
                                                                     "delete_ymd_hms," +
                                                                     "delete_flag) " +
                                     "VALUES ('" + carAccidentMasterVo.Totalling_flag + "'," +
                                             "'" + carAccidentMasterVo.Occurrence_ymd_hms + "'," +
                                             "'" + carAccidentMasterVo.Weather + "'," +
                                             "'" + carAccidentMasterVo.Accident_kind + "'," +
                                             "'" + carAccidentMasterVo.Car_static + "'," +
                                             "'" + carAccidentMasterVo.Occurrence_cause + "'," +
                                             "'" + carAccidentMasterVo.Negligence + "'," +
                                             "'" + carAccidentMasterVo.Personal_injury + "'," +
                                             "'" + carAccidentMasterVo.Property_accident_1 + "'," +
                                             "'" + carAccidentMasterVo.Property_accident_2 + "'," +
                                             "'" + carAccidentMasterVo.Occurrence_address + "'," +
                                             "'" + carAccidentMasterVo.Work_kind + "'," +
                                             "'" + carAccidentMasterVo.Staff_code + "'," +
                                             "'" + carAccidentMasterVo.Display_name + "'," +
                                             "'" + carAccidentMasterVo.License_number + "'," +
                                             "'" + carAccidentMasterVo.Car_registration_number + "'," +
                                             "'" + carAccidentMasterVo.Accident_summary + "'," +
                                             "'" + carAccidentMasterVo.Accident_detail + "'," +
                                             "'" + carAccidentMasterVo.Guide + "'," +
                                             "@member_picture1," +
                                             "@member_picture2," +
                                             "@member_picture3," +
                                             "@member_picture4," +
                                             "@member_picture5," +
                                             "@member_picture6," +
                                             "@member_picture7," +
                                             "@member_picture8," +
                                             "'" + DateTime.Now + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture1", SqlDbType.Image, carAccidentMasterVo.Picture1.Length).Value = carAccidentMasterVo.Picture1;
                sqlCommand.Parameters.Add("@member_picture2", SqlDbType.Image, carAccidentMasterVo.Picture2.Length).Value = carAccidentMasterVo.Picture2;
                sqlCommand.Parameters.Add("@member_picture3", SqlDbType.Image, carAccidentMasterVo.Picture3.Length).Value = carAccidentMasterVo.Picture3;
                sqlCommand.Parameters.Add("@member_picture4", SqlDbType.Image, carAccidentMasterVo.Picture4.Length).Value = carAccidentMasterVo.Picture4;
                sqlCommand.Parameters.Add("@member_picture5", SqlDbType.Image, carAccidentMasterVo.Picture5.Length).Value = carAccidentMasterVo.Picture5;
                sqlCommand.Parameters.Add("@member_picture6", SqlDbType.Image, carAccidentMasterVo.Picture6.Length).Value = carAccidentMasterVo.Picture6;
                sqlCommand.Parameters.Add("@member_picture7", SqlDbType.Image, carAccidentMasterVo.Picture7.Length).Value = carAccidentMasterVo.Picture7;
                sqlCommand.Parameters.Add("@member_picture8", SqlDbType.Image, carAccidentMasterVo.Picture8.Length).Value = carAccidentMasterVo.Picture8;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneCarAccidentLedger
        /// </summary>
        /// <param name="insertYmdHms"></param>
        /// <returns></returns>
        public int UpdateOneCarAccidentMaster(CarAccidentMasterVo carAccidentMasterVo, DateTime insertYmdHms) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE car_accident_master " +
                                     "SET totalling_flag = '" + carAccidentMasterVo.Totalling_flag + "'," +
                                         "occurrence_ymd_hms = '" + carAccidentMasterVo.Occurrence_ymd_hms + "'," +
                                         "weather = '" + carAccidentMasterVo.Weather + "'," +
                                         "accident_kind = '" + carAccidentMasterVo.Accident_kind + "'," +
                                         "car_static = '" + carAccidentMasterVo.Car_static + "'," +
                                         "occurrence_cause = '" + carAccidentMasterVo.Occurrence_cause + "'," +
                                         "negligence = '" + carAccidentMasterVo.Negligence + "'," +
                                         "personal_injury = '" + carAccidentMasterVo.Personal_injury + "'," +
                                         "property_accident_1 = '" + carAccidentMasterVo.Property_accident_1 + "'," +
                                         "property_accident_2 = '" + carAccidentMasterVo.Property_accident_2 + "'," +
                                         "occurrence_address = '" + carAccidentMasterVo.Occurrence_address + "'," +
                                         "work_kind = '" + carAccidentMasterVo.Work_kind + "'," +
                                         "staff_code = '" + carAccidentMasterVo.Staff_code + "'," +
                                         "display_name = '" + carAccidentMasterVo.Display_name + "'," +
                                         "license_number = '" + carAccidentMasterVo.License_number + "'," +
                                         "car_registration_number = '" + carAccidentMasterVo.Car_registration_number + "'," +
                                         "accident_summary = '" + carAccidentMasterVo.Accident_summary + "'," +
                                         "accident_detail = '" + carAccidentMasterVo.Accident_detail + "'," +
                                         "guide = '" + carAccidentMasterVo.Guide + "'," +
                                         "picture1 = @member_picture1," +
                                         "picture2 = @member_picture2," +
                                         "picture3 = @member_picture3," +
                                         "picture4 = @member_picture4," +
                                         "picture5 = @member_picture5," +
                                         "picture6 = @member_picture6," +
                                         "picture7 = @member_picture7," +
                                         "picture8 = @member_picture8," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE insert_ymd_hms='" + insertYmdHms.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' " +
                                       "AND delete_Flag = 'False'";
            try {
                sqlCommand.Parameters.Add("@member_picture1", SqlDbType.Image, carAccidentMasterVo.Picture1.Length).Value = carAccidentMasterVo.Picture1;
                sqlCommand.Parameters.Add("@member_picture2", SqlDbType.Image, carAccidentMasterVo.Picture2.Length).Value = carAccidentMasterVo.Picture2;
                sqlCommand.Parameters.Add("@member_picture3", SqlDbType.Image, carAccidentMasterVo.Picture3.Length).Value = carAccidentMasterVo.Picture3;
                sqlCommand.Parameters.Add("@member_picture4", SqlDbType.Image, carAccidentMasterVo.Picture4.Length).Value = carAccidentMasterVo.Picture4;
                sqlCommand.Parameters.Add("@member_picture5", SqlDbType.Image, carAccidentMasterVo.Picture5.Length).Value = carAccidentMasterVo.Picture5;
                sqlCommand.Parameters.Add("@member_picture6", SqlDbType.Image, carAccidentMasterVo.Picture6.Length).Value = carAccidentMasterVo.Picture6;
                sqlCommand.Parameters.Add("@member_picture7", SqlDbType.Image, carAccidentMasterVo.Picture7.Length).Value = carAccidentMasterVo.Picture7;
                sqlCommand.Parameters.Add("@member_picture8", SqlDbType.Image, carAccidentMasterVo.Picture8.Length).Value = carAccidentMasterVo.Picture8;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
