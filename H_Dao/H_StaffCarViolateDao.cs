/*
 * 2024-02-03
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_StaffCarViolateDao {
        /*
         * インスタンス
         */
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffCarViolateDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneHStaffCarViolateMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffCarViolateVo> SelectOneHStaffCarViolateMaster() {
            List<H_StaffCarViolateVo> listHStaffCarViolateVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "CarViolateDate," +
                                            "CarViolateContent," +
                                            "CarViolatePlace," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffCarViolateMaster";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffCarViolateVo hStaffCarViolateVo = new();
                    hStaffCarViolateVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffCarViolateVo.CarViolateDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["CarViolateDate"]);
                    hStaffCarViolateVo.CarViolateContent = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarViolateContent"]);
                    hStaffCarViolateVo.CarViolatePlace = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarViolatePlace"]);
                    hStaffCarViolateVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStaffCarViolateVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffCarViolateVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffCarViolateVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffCarViolateVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffCarViolateVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffCarViolateVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffCarViolateVo.Add(hStaffCarViolateVo);
                }
            }
            return listHStaffCarViolateVo;
        }
    }
}
