/*
 * 2024-02-07
 */
using System.Data.SqlClient;

using H_Common;

using Vo;

namespace H_Dao {
    public class H_CarAccidentMasterDao {
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
        /// 年度内の事故件数
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>c
        public string GetHCarAccidentCount(int staffCode) {
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
        /// SelectOneHCarAccidentMaster
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public List<H_CarAccidentMasterVo> SelectOneHCarAccidentMaster(int staffCode) {
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
    }
}
