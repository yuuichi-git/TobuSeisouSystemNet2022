﻿/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {

    public class H_StaffEducateDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffEducateDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneHStaffEducateMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffEducateVo> SelectOneHStaffEducateMaster(int staffCode) {
            List<H_StaffEducateVo> listHStaffEducateVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "EducateDate," +
                                            "EducateName," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffEducateMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffEducateVo hStaffEducateVo = new();
                    hStaffEducateVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffEducateVo.EducateDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EducateDate"]);
                    hStaffEducateVo.EducateName = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarViolateContent"]);
                    hStaffEducateVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["EducateName"]);
                    hStaffEducateVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffEducateVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffEducateVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffEducateVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffEducateVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffEducateVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffEducateVo.Add(hStaffEducateVo);
                }
            }
            return listHStaffEducateVo;
        }

        /// <summary>
        /// InsertOneHStaffEducateMaster
        /// </summary>
        /// <param name="hStaffEducateVo"></param>
        public void InsertOneHStaffEducateMaster(H_StaffEducateVo hStaffEducateVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StaffEducateMaster(StaffCode," +
                                                                      "EducateDate," +
                                                                      "EducateName," +
                                                                      "InsertPcName," +
                                                                      "InsertYmdHms," +
                                                                      "UpdatePcName," +
                                                                      "UpdateYmdHms," +
                                                                      "DeletePcName," +
                                                                      "DeleteYmdHms," +
                                                                      "DeleteFlag) " +
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hStaffEducateVo.StaffCode) + "," +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hStaffEducateVo.EducateDate) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<string>(hStaffEducateVo.EducateName) + "'," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + "" + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + "" + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'False'" +
                                            ");";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
