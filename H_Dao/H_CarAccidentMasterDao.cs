/*
 * 2024-02-07
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_CarAccidentMasterDao {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        private readonly Date _date = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_CarAccidentMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHCarAccidentMaster
        /// true:該当レコードあり false:該当レコードなし
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="occurrenceYmdHms"></param>
        /// <returns></returns>
        public bool ExistenceHCarAccidentMaster(H_CarAccidentMasterVo hCarAccidentMasterVo) {
            int count;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(StaffCode) " +
                                     "FROM H_CarAccidentMaster " +
                                     "WHERE StaffCode = " + hCarAccidentMasterVo.StaffCode + " AND OccurrenceYmdHms = '" + hCarAccidentMasterVo.OccurrenceYmdHms.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// 年度内の事故件数
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>c
        public string GetHCarAccidentMasterCount(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(StaffCode) " +
                                     "FROM H_CarAccidentMaster " +
                                     "WHERE StaffCode = " + staffCode + "" +
                                       "AND OccurrenceYmdHms BETWEEN '" + _date.GetFiscalYearStartDate(DateTime.Now.Date) + "' AND '" + _date.GetFiscalYearEndDate(DateTime.Now.Date) + "' " +
                                       "AND TotallingFlag = 'true'";
            int count = (int)sqlCommand.ExecuteScalar();
            if (count > 0) {
                return string.Concat(sqlCommand.ExecuteScalar().ToString(), "件");
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// SelectGroupHCarAccidentMaster
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public List<H_CarAccidentMasterVo> SelectGroupHCarAccidentMaster(int staffCode) {
            List<H_CarAccidentMasterVo> listHCarAccidentMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "OccurrenceYmdHms," +
                                            "TotallingFlag," +
                                            "Weather," +
                                            "AccidentKind," +
                                            "CarStatic," +
                                            "OccurrenceCause," +
                                            "Negligence," +
                                            "PersonalInjury," +
                                            "PropertyAccident1," +
                                            "PropertyAccident2," +
                                            "OccurrenceAddress," +
                                            "WorkKind," +
                                            "DisplayName," +
                                            "LicenseNumber," +
                                            "CarRegistrationNumber," +
                                            "AccidentSummary," +
                                            "AccidentDetail," +
                                            "Guide," +
                                            "Picture1," +
                                            "Picture2," +
                                            "Picture3," +
                                            "Picture4," +
                                            "Picture5," +
                                            "Picture6," +
                                            "Picture7," +
                                            "Picture8," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CarAccidentMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_CarAccidentMasterVo hCarAccidentMasterVo = new();
                    hCarAccidentMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hCarAccidentMasterVo.OccurrenceYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OccurrenceYmdHms"]);
                    hCarAccidentMasterVo.TotallingFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["TotallingFlag"]);
                    hCarAccidentMasterVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["Weather"]);
                    hCarAccidentMasterVo.AccidentKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentKind"]);
                    hCarAccidentMasterVo.CarStatic = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarStatic"]);
                    hCarAccidentMasterVo.OccurrenceCause = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccurrenceCause"]);
                    hCarAccidentMasterVo.Negligence = _defaultValue.GetDefaultValue<string>(sqlDataReader["Negligence"]);
                    hCarAccidentMasterVo.PersonalInjury = _defaultValue.GetDefaultValue<string>(sqlDataReader["PersonalInjury"]);
                    hCarAccidentMasterVo.PropertyAccident1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["PropertyAccident1"]);
                    hCarAccidentMasterVo.PropertyAccident2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["PropertyAccident2"]);
                    hCarAccidentMasterVo.OccurrenceAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccurrenceAddress"]);
                    hCarAccidentMasterVo.WorkKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkKind"]);
                    hCarAccidentMasterVo.DisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisplayName"]);
                    hCarAccidentMasterVo.LicenseNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseNumber"]);
                    hCarAccidentMasterVo.CarRegistrationNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarRegistrationNumber"]);
                    hCarAccidentMasterVo.AccidentSummary = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentSummary"]);
                    hCarAccidentMasterVo.AccidentDetail = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentDetail"]);
                    hCarAccidentMasterVo.Guide = _defaultValue.GetDefaultValue<string>(sqlDataReader["Guide"]);
                    hCarAccidentMasterVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture1"]);
                    hCarAccidentMasterVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture2"]);
                    hCarAccidentMasterVo.Picture3 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture3"]);
                    hCarAccidentMasterVo.Picture4 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture4"]);
                    hCarAccidentMasterVo.Picture5 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture5"]);
                    hCarAccidentMasterVo.Picture6 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture6"]);
                    hCarAccidentMasterVo.Picture7 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture7"]);
                    hCarAccidentMasterVo.Picture8 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture8"]);
                    hCarAccidentMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCarAccidentMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCarAccidentMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCarAccidentMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCarAccidentMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCarAccidentMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHCarAccidentMasterVo.Add(hCarAccidentMasterVo);
                }
            }
            return listHCarAccidentMasterVo;
        }

        /// <summary>
        /// SelectOneHCarAccidentMaster
        /// Detailで使用
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="occurrenceYmdHms"></param>
        /// <returns></returns>
        public H_CarAccidentMasterVo SelectOneHCarAccidentMaster(int staffCode, DateTime occurrenceYmdHms) {
            H_CarAccidentMasterVo hCarAccidentMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "OccurrenceYmdHms," +
                                            "TotallingFlag," +
                                            "Weather," +
                                            "AccidentKind," +
                                            "CarStatic," +
                                            "OccurrenceCause," +
                                            "Negligence," +
                                            "PersonalInjury," +
                                            "PropertyAccident1," +
                                            "PropertyAccident2," +
                                            "OccurrenceAddress," +
                                            "WorkKind," +
                                            "DisplayName," +
                                            "LicenseNumber," +
                                            "CarRegistrationNumber," +
                                            "AccidentSummary," +
                                            "AccidentDetail," +
                                            "Guide," +
                                            "Picture1," +
                                            "Picture2," +
                                            "Picture3," +
                                            "Picture4," +
                                            "Picture5," +
                                            "Picture6," +
                                            "Picture7," +
                                            "Picture8," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CarAccidentMaster " +
                                     "WHERE StaffCode = " + staffCode + " AND OccurrenceYmdHms = '" + occurrenceYmdHms.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hCarAccidentMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hCarAccidentMasterVo.OccurrenceYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OccurrenceYmdHms"]);
                    hCarAccidentMasterVo.TotallingFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["TotallingFlag"]);
                    hCarAccidentMasterVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["Weather"]);
                    hCarAccidentMasterVo.AccidentKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentKind"]);
                    hCarAccidentMasterVo.CarStatic = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarStatic"]);
                    hCarAccidentMasterVo.OccurrenceCause = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccurrenceCause"]);
                    hCarAccidentMasterVo.Negligence = _defaultValue.GetDefaultValue<string>(sqlDataReader["Negligence"]);
                    hCarAccidentMasterVo.PersonalInjury = _defaultValue.GetDefaultValue<string>(sqlDataReader["PersonalInjury"]);
                    hCarAccidentMasterVo.PropertyAccident1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["PropertyAccident1"]);
                    hCarAccidentMasterVo.PropertyAccident2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["PropertyAccident2"]);
                    hCarAccidentMasterVo.OccurrenceAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccurrenceAddress"]);
                    hCarAccidentMasterVo.WorkKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkKind"]);
                    hCarAccidentMasterVo.DisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisplayName"]);
                    hCarAccidentMasterVo.LicenseNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseNumber"]);
                    hCarAccidentMasterVo.CarRegistrationNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarRegistrationNumber"]);
                    hCarAccidentMasterVo.AccidentSummary = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentSummary"]);
                    hCarAccidentMasterVo.AccidentDetail = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentDetail"]);
                    hCarAccidentMasterVo.Guide = _defaultValue.GetDefaultValue<string>(sqlDataReader["Guide"]);
                    hCarAccidentMasterVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture1"]);
                    hCarAccidentMasterVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture2"]);
                    hCarAccidentMasterVo.Picture3 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture3"]);
                    hCarAccidentMasterVo.Picture4 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture4"]);
                    hCarAccidentMasterVo.Picture5 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture5"]);
                    hCarAccidentMasterVo.Picture6 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture6"]);
                    hCarAccidentMasterVo.Picture7 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture7"]);
                    hCarAccidentMasterVo.Picture8 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture8"]);
                    hCarAccidentMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCarAccidentMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCarAccidentMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCarAccidentMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCarAccidentMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCarAccidentMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hCarAccidentMasterVo;
        }

        /// <summary>
        /// SelectAllHCarAccidentMaster
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public List<H_CarAccidentMasterVo> SelectAllHCarAccidentMaster(DateTime dateTime1, DateTime dateTime2) {
            List<H_CarAccidentMasterVo> listHCarAccidentMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "OccurrenceYmdHms," +
                                            "TotallingFlag," +
                                            "Weather," +
                                            "AccidentKind," +
                                            "CarStatic," +
                                            "OccurrenceCause," +
                                            "Negligence," +
                                            "PersonalInjury," +
                                            "PropertyAccident1," +
                                            "PropertyAccident2," +
                                            "OccurrenceAddress," +
                                            "WorkKind," +
                                            "DisplayName," +
                                            "LicenseNumber," +
                                            "CarRegistrationNumber," +
                                            "AccidentSummary," +
                                            "AccidentDetail," +
                                            "Guide," +
                                            //"Picture1," +
                                            //"Picture2," +
                                            //"Picture3," +
                                            //"Picture4," +
                                            //"Picture5," +
                                            //"Picture6," +
                                            //"Picture7," +
                                            //"Picture8," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CarAccidentMaster " +
                                     "WHERE (OccurrenceYmdHms BETWEEN '" + dateTime1 + "' AND '" + dateTime2 + "')";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_CarAccidentMasterVo hCarAccidentMasterVo = new();
                    hCarAccidentMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hCarAccidentMasterVo.OccurrenceYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OccurrenceYmdHms"]);
                    hCarAccidentMasterVo.TotallingFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["TotallingFlag"]);
                    hCarAccidentMasterVo.Weather = _defaultValue.GetDefaultValue<string>(sqlDataReader["Weather"]);
                    hCarAccidentMasterVo.AccidentKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentKind"]);
                    hCarAccidentMasterVo.CarStatic = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarStatic"]);
                    hCarAccidentMasterVo.OccurrenceCause = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccurrenceCause"]);
                    hCarAccidentMasterVo.Negligence = _defaultValue.GetDefaultValue<string>(sqlDataReader["Negligence"]);
                    hCarAccidentMasterVo.PersonalInjury = _defaultValue.GetDefaultValue<string>(sqlDataReader["PersonalInjury"]);
                    hCarAccidentMasterVo.PropertyAccident1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["PropertyAccident1"]);
                    hCarAccidentMasterVo.PropertyAccident2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["PropertyAccident2"]);
                    hCarAccidentMasterVo.OccurrenceAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccurrenceAddress"]);
                    hCarAccidentMasterVo.WorkKind = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkKind"]);
                    hCarAccidentMasterVo.DisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisplayName"]);
                    hCarAccidentMasterVo.LicenseNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseNumber"]);
                    hCarAccidentMasterVo.CarRegistrationNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarRegistrationNumber"]);
                    hCarAccidentMasterVo.AccidentSummary = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentSummary"]);
                    hCarAccidentMasterVo.AccidentDetail = _defaultValue.GetDefaultValue<string>(sqlDataReader["AccidentDetail"]);
                    hCarAccidentMasterVo.Guide = _defaultValue.GetDefaultValue<string>(sqlDataReader["Guide"]);
                    //hCarAccidentMasterVo.Picture1 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture1"]);
                    //hCarAccidentMasterVo.Picture2 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture2"]);
                    //hCarAccidentMasterVo.Picture3 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture3"]);
                    //hCarAccidentMasterVo.Picture4 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture4"]);
                    //hCarAccidentMasterVo.Picture5 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture5"]);
                    //hCarAccidentMasterVo.Picture6 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture6"]);
                    //hCarAccidentMasterVo.Picture7 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture7"]);
                    //hCarAccidentMasterVo.Picture8 = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture8"]);
                    hCarAccidentMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCarAccidentMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCarAccidentMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCarAccidentMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCarAccidentMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCarAccidentMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHCarAccidentMasterVo.Add(hCarAccidentMasterVo);
                }
            }
            return listHCarAccidentMasterVo;
        }

        /// <summary>
        /// InsertOneHCarAccidentMaster
        /// </summary>
        /// <param name="hCarAccidentMasterVo"></param>
        /// <returns></returns>
        public int InsertOneHCarAccidentMaster(H_CarAccidentMasterVo hCarAccidentMasterVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_CarAccidentMaster(StaffCode," +
                                                                     "OccurrenceYmdHms," +
                                                                     "TotallingFlag," +
                                                                     "Weather," +
                                                                     "AccidentKind," +
                                                                     "CarStatic," +
                                                                     "OccurrenceCause," +
                                                                     "Negligence," +
                                                                     "PersonalInjury," +
                                                                     "PropertyAccident1," +
                                                                     "PropertyAccident2," +
                                                                     "OccurrenceAddress," +
                                                                     "WorkKind," +
                                                                     "DisplayName," +
                                                                     "LicenseNumber," +
                                                                     "CarRegistrationNumber," +
                                                                     "AccidentSummary," +
                                                                     "AccidentDetail," +
                                                                     "Guide," +
                                                                     "Picture1," +
                                                                     "Picture2," +
                                                                     "Picture3," +
                                                                     "Picture4," +
                                                                     "Picture5," +
                                                                     "Picture6," +
                                                                     "Picture7," +
                                                                     "Picture8," +
                                                                     "InsertPcName," +
                                                                     "InsertYmdHms," +
                                                                     "UpdatePcName," +
                                                                     "UpdateYmdHms," +
                                                                     "DeletePcName," +
                                                                     "DeleteYmdHms," +
                                                                     "DeleteFlag) " +
                                     "VALUES ('" + hCarAccidentMasterVo.StaffCode + "'," +
                                             "'" + hCarAccidentMasterVo.OccurrenceYmdHms + "'," +
                                             "'" + hCarAccidentMasterVo.TotallingFlag + "'," +
                                             "'" + hCarAccidentMasterVo.Weather + "'," +
                                             "'" + hCarAccidentMasterVo.AccidentKind + "'," +
                                             "'" + hCarAccidentMasterVo.CarStatic + "'," +
                                             "'" + hCarAccidentMasterVo.OccurrenceCause + "'," +
                                             "'" + hCarAccidentMasterVo.Negligence + "'," +
                                             "'" + hCarAccidentMasterVo.PersonalInjury + "'," +
                                             "'" + hCarAccidentMasterVo.PropertyAccident1 + "'," +
                                             "'" + hCarAccidentMasterVo.PropertyAccident2 + "'," +
                                             "'" + hCarAccidentMasterVo.OccurrenceAddress + "'," +
                                             "'" + hCarAccidentMasterVo.WorkKind + "'," +
                                             "'" + hCarAccidentMasterVo.DisplayName + "'," +
                                             "'" + hCarAccidentMasterVo.LicenseNumber + "'," +
                                             "'" + hCarAccidentMasterVo.CarRegistrationNumber + "'," +
                                             "'" + hCarAccidentMasterVo.AccidentSummary + "'," +
                                             "'" + hCarAccidentMasterVo.AccidentDetail + "'," +
                                             "'" + hCarAccidentMasterVo.Guide + "'," +
                                             "@member_picture1," +
                                             "@member_picture2," +
                                             "@member_picture3," +
                                             "@member_picture4," +
                                             "@member_picture5," +
                                             "@member_picture6," +
                                             "@member_picture7," +
                                             "@member_picture8," +
                                             "'" + Environment.MachineName + "'," +
                                             "'" + DateTime.Now + "'," +
                                             "'" + string.Empty + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'" + string.Empty + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'false'" +
                                             ");";
            try {
                if (hCarAccidentMasterVo.Picture1 is not null)
                    sqlCommand.Parameters.Add("@member_picture1", SqlDbType.Image, hCarAccidentMasterVo.Picture1.Length).Value = hCarAccidentMasterVo.Picture1;
                if (hCarAccidentMasterVo.Picture2 is not null)
                    sqlCommand.Parameters.Add("@member_picture2", SqlDbType.Image, hCarAccidentMasterVo.Picture2.Length).Value = hCarAccidentMasterVo.Picture2;
                if (hCarAccidentMasterVo.Picture3 is not null)
                    sqlCommand.Parameters.Add("@member_picture3", SqlDbType.Image, hCarAccidentMasterVo.Picture3.Length).Value = hCarAccidentMasterVo.Picture3;
                if (hCarAccidentMasterVo.Picture4 is not null)
                    sqlCommand.Parameters.Add("@member_picture4", SqlDbType.Image, hCarAccidentMasterVo.Picture4.Length).Value = hCarAccidentMasterVo.Picture4;
                if (hCarAccidentMasterVo.Picture5 is not null)
                    sqlCommand.Parameters.Add("@member_picture5", SqlDbType.Image, hCarAccidentMasterVo.Picture5.Length).Value = hCarAccidentMasterVo.Picture5;
                if (hCarAccidentMasterVo.Picture6 is not null)
                    sqlCommand.Parameters.Add("@member_picture6", SqlDbType.Image, hCarAccidentMasterVo.Picture6.Length).Value = hCarAccidentMasterVo.Picture6;
                if (hCarAccidentMasterVo.Picture7 is not null)
                    sqlCommand.Parameters.Add("@member_picture7", SqlDbType.Image, hCarAccidentMasterVo.Picture7.Length).Value = hCarAccidentMasterVo.Picture7;
                if (hCarAccidentMasterVo.Picture8 is not null)
                    sqlCommand.Parameters.Add("@member_picture8", SqlDbType.Image, hCarAccidentMasterVo.Picture8.Length).Value = hCarAccidentMasterVo.Picture8;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHCarAccidentMaster
        /// </summary>
        /// <param name="hCarAccidentMasterVo"></param>
        /// <returns></returns>
        public int UpdateOneHCarAccidentMaster(H_CarAccidentMasterVo hCarAccidentMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_CarAccidentMaster " +
                                     "SET StaffCode = " + hCarAccidentMasterVo.StaffCode + "," +
                                         "OccurrenceYmdHms = '" + hCarAccidentMasterVo.OccurrenceYmdHms + "'," +
                                         "TotallingFlag = '" + hCarAccidentMasterVo.TotallingFlag + "'," +
                                         "Weather = '" + hCarAccidentMasterVo.Weather + "'," +
                                         "AccidentKind = '" + hCarAccidentMasterVo.AccidentKind + "'," +
                                         "CarStatic = '" + hCarAccidentMasterVo.CarStatic + "'," +
                                         "OccurrenceCause = '" + hCarAccidentMasterVo.OccurrenceCause + "'," +
                                         "Negligence = '" + hCarAccidentMasterVo.Negligence + "'," +
                                         "PersonalInjury = '" + hCarAccidentMasterVo.PersonalInjury + "'," +
                                         "PropertyAccident1 = '" + hCarAccidentMasterVo.PropertyAccident1 + "'," +
                                         "PropertyAccident2 = '" + hCarAccidentMasterVo.PropertyAccident2 + "'," +
                                         "OccurrenceAddress = '" + hCarAccidentMasterVo.OccurrenceAddress + "'," +
                                         "WorkKind = '" + hCarAccidentMasterVo.WorkKind + "'," +
                                         "DisplayName = '" + hCarAccidentMasterVo.DisplayName + "'," +
                                         "LicenseNumber = '" + hCarAccidentMasterVo.LicenseNumber + "'," +
                                         "CarRegistrationNumber = '" + hCarAccidentMasterVo.CarRegistrationNumber + "'," +
                                         "AccidentSummary = '" + hCarAccidentMasterVo.AccidentSummary + "'," +
                                         "AccidentDetail = '" + hCarAccidentMasterVo.AccidentDetail + "'," +
                                         "Guide = '" + hCarAccidentMasterVo.Guide + "'," +
                                         "Picture1 = @member_picture1," +
                                         "Picture2 = @member_picture2," +
                                         "Picture3 = @member_picture3," +
                                         "Picture4 = @member_picture4," +
                                         "Picture5 = @member_picture5," +
                                         "Picture6 = @member_picture6," +
                                         "Picture7 = @member_picture7," +
                                         "Picture8 = @member_picture8," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE StaffCode = " + hCarAccidentMasterVo.StaffCode + " AND OccurrenceYmdHms = '" + hCarAccidentMasterVo.OccurrenceYmdHms.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            try {
                if (hCarAccidentMasterVo.Picture1 is not null)
                    sqlCommand.Parameters.Add("@member_picture1", SqlDbType.Image, hCarAccidentMasterVo.Picture1.Length).Value = hCarAccidentMasterVo.Picture1;
                if (hCarAccidentMasterVo.Picture2 is not null)
                    sqlCommand.Parameters.Add("@member_picture2", SqlDbType.Image, hCarAccidentMasterVo.Picture2.Length).Value = hCarAccidentMasterVo.Picture2;
                if (hCarAccidentMasterVo.Picture3 is not null)
                    sqlCommand.Parameters.Add("@member_picture3", SqlDbType.Image, hCarAccidentMasterVo.Picture3.Length).Value = hCarAccidentMasterVo.Picture3;
                if (hCarAccidentMasterVo.Picture4 is not null)
                    sqlCommand.Parameters.Add("@member_picture4", SqlDbType.Image, hCarAccidentMasterVo.Picture4.Length).Value = hCarAccidentMasterVo.Picture4;
                if (hCarAccidentMasterVo.Picture5 is not null)
                    sqlCommand.Parameters.Add("@member_picture5", SqlDbType.Image, hCarAccidentMasterVo.Picture5.Length).Value = hCarAccidentMasterVo.Picture5;
                if (hCarAccidentMasterVo.Picture6 is not null)
                    sqlCommand.Parameters.Add("@member_picture6", SqlDbType.Image, hCarAccidentMasterVo.Picture6.Length).Value = hCarAccidentMasterVo.Picture6;
                if (hCarAccidentMasterVo.Picture7 is not null)
                    sqlCommand.Parameters.Add("@member_picture7", SqlDbType.Image, hCarAccidentMasterVo.Picture7.Length).Value = hCarAccidentMasterVo.Picture7;
                if (hCarAccidentMasterVo.Picture8 is not null)
                    sqlCommand.Parameters.Add("@member_picture8", SqlDbType.Image, hCarAccidentMasterVo.Picture8.Length).Value = hCarAccidentMasterVo.Picture8;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
