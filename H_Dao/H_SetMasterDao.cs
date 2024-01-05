/*
 * 2023-11-06
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_SetMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_SetMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectAllHSetMaster
        /// </summary>
        /// <returns></returns>
        public List<H_SetMasterVo> SelectAllHSetMaster() {
            List<H_SetMasterVo> listHSetMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT SetCode," +
                                            "WordCode," +
                                            "SetName," +
                                            "SetName1," +
                                            "SetName2," +
                                            "FareCode," +
                                            "ManagedSpaceCode," +
                                            "ClassificationCode," +
                                            "ContactMethod," +
                                            "NumberOfPeople," +
                                            "SpareOfPeople," +
                                            "WorkingDays," +
                                            "FiveLap," +
                                            "MoveFlag," +
                                            "Remarks," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_SetMaster";
            // "WHERE delete_flag = 'False'"; // delete_flagを入れると過去の配車に削除済のSetLabelが反映出来なくなる
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    H_SetMasterVo hSetMasterVo = new();
                    hSetMasterVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hSetMasterVo.WordCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["WordCode"]);
                    hSetMasterVo.SetName = _defaultValue.GetDefaultValue<string>(sqlDataReader["SetName"]);
                    hSetMasterVo.SetName1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["SetName1"]);
                    hSetMasterVo.SetName2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["SetName2"]);
                    hSetMasterVo.FareCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["FareCode"]);
                    hSetMasterVo.ManagedSpaceCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ManagedSpaceCode"]);
                    hSetMasterVo.ClassificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ClassificationCode"]);
                    hSetMasterVo.ContactMethod = _defaultValue.GetDefaultValue<int>(sqlDataReader["ContactMethod"]);
                    hSetMasterVo.NumberOfPeople = _defaultValue.GetDefaultValue<int>(sqlDataReader["NumberOfPeople"]);
                    hSetMasterVo.SpareOfPeople = _defaultValue.GetDefaultValue<bool>(sqlDataReader["SpareOfPeople"]);
                    hSetMasterVo.WorkingDays = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkingDays"]);
                    hSetMasterVo.FiveLap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["FiveLap"]);
                    hSetMasterVo.MoveFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["MoveFlag"]);
                    hSetMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["Remarks"]);
                    hSetMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hSetMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hSetMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hSetMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hSetMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hSetMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hSetMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHSetMasterVo.Add(hSetMasterVo);
                }
            }
            return listHSetMasterVo;
        }
    }
}
