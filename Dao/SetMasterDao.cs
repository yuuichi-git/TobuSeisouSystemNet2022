using Common;

using Vo;

namespace Dao {
    public class SetMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public SetMasterDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneSetMaster
        /// </summary>
        /// <returns></returns>
        public SetMasterVo SelectOneSetMaster(int setCode) {
            var setMasterVo = new SetMasterVo();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT set_master.word_code," +
                                            "set_master.set_code," +
                                            "set_master.set_name," +
                                            "set_master.set_name_1," +
                                            "set_master.set_name_2," +
                                            "set_master.fare_code," +
                                            "set_master.garage_flag," +
                                            "set_master.classification_code," +
                                            "classification_master.name AS classification_name," + // 外部結合で取得
                                            "set_master.contact_method," +
                                            "contact_master.name AS contact_name," + // 外部結合で取得
                                            "set_master.number_of_people," +
                                            "set_master.working_days," +
                                            "set_master.five_lap," +
                                            "set_master.move_flag," +
                                            "set_master.remarks," +
                                            "set_master.insert_ymd_hms," +
                                            "set_master.update_ymd_hms," +
                                            "set_master.delete_ymd_hms," +
                                            "set_master.delete_flag " +
                                     "FROM set_master " +
                                     "LEFT OUTER JOIN classification_master ON set_master.classification_code = classification_master.code " +
                                     "LEFT OUTER JOIN contact_master ON set_master.contact_method = contact_master.code " +
                                     "WHERE set_code = " + setCode;
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    setMasterVo.Word_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["word_code"]);
                    setMasterVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    setMasterVo.Set_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name"]);
                    setMasterVo.Set_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name_1"]);
                    setMasterVo.Set_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name_2"]);
                    setMasterVo.Fare_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["fare_code"]);
                    setMasterVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    setMasterVo.Classification_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["classification_code"]);
                    setMasterVo.Classification_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["classification_name"]); // 外部結合で取得
                    setMasterVo.Contact_method = _defaultValue.GetDefaultValue<int>(sqlDataReader["contact_method"]);
                    setMasterVo.Contact_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["contact_name"]); // 外部結合で取得
                    setMasterVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    setMasterVo.Working_days = _defaultValue.GetDefaultValue<string>(sqlDataReader["working_days"]);
                    setMasterVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    setMasterVo.Move_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["move_flag"]);
                    setMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["remarks"]);
                    setMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    setMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    setMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    setMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
            }
            return setMasterVo;
        }

        /// <summary>
        /// SelectAllSetMaster
        /// </summary>
        /// <returns></returns>
        public List<SetMasterVo> SelectAllSetMaster() {
            var listSetMasterVo = new List<SetMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT set_master.word_code," +
                                            "set_master.set_code," +
                                            "set_master.set_name," +
                                            "set_master.set_name_1," +
                                            "set_master.set_name_2," +
                                            "set_master.fare_code," +
                                            "set_master.garage_flag," +
                                            "set_master.classification_code," +
                                            "classification_master.name AS classification_name," + // 外部結合で取得
                                            "set_master.contact_method," +
                                            "contact_master.name AS contact_name," + // 外部結合で取得
                                            "set_master.number_of_people," +
                                            "set_master.working_days," +
                                            "set_master.five_lap," +
                                            "set_master.move_flag," +
                                            "set_master.remarks," +
                                            "set_master.insert_ymd_hms," +
                                            "set_master.update_ymd_hms," +
                                            "set_master.delete_ymd_hms," +
                                            "set_master.delete_flag " +
                                     "FROM set_master " +
                                     "LEFT OUTER JOIN classification_master ON set_master.classification_code = classification_master.code " +
                                     "LEFT OUTER JOIN contact_master ON set_master.contact_method = contact_master.code";

            // "WHERE delete_flag = 'False'"; // delete_flagを入れると過去の配車に削除済のSetLabelが反映出来なくなる
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    var setMasterVo = new SetMasterVo();
                    setMasterVo.Word_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["word_code"]);
                    setMasterVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    setMasterVo.Set_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name"]);
                    setMasterVo.Set_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name_1"]);
                    setMasterVo.Set_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name_2"]);
                    setMasterVo.Fare_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["fare_code"]);
                    setMasterVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    setMasterVo.Classification_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["classification_code"]);
                    setMasterVo.Classification_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["classification_name"]); // 外部結合で取得
                    setMasterVo.Contact_method = _defaultValue.GetDefaultValue<int>(sqlDataReader["contact_method"]);
                    setMasterVo.Contact_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["contact_name"]); // 外部結合で取得
                    setMasterVo.Number_of_people = _defaultValue.GetDefaultValue<int>(sqlDataReader["number_of_people"]);
                    setMasterVo.Working_days = _defaultValue.GetDefaultValue<string>(sqlDataReader["working_days"]);
                    setMasterVo.Five_lap = _defaultValue.GetDefaultValue<bool>(sqlDataReader["five_lap"]);
                    setMasterVo.Move_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["move_flag"]);
                    setMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["remarks"]);
                    setMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    setMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    setMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    setMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listSetMasterVo.Add(setMasterVo);
                }
            }
            return listSetMasterVo;
        }
    }
}
