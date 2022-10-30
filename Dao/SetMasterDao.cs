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
        /// SelectAllSetMasterVo
        /// </summary>
        /// <returns></returns>
        public List<SetMasterVo> SelectAllSetMaster() {
            var listSetMasterVo = new List<SetMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT word_code," +
                                            "set_code," +
                                            "set_name," +
                                            "set_name_1," +
                                            "set_name_2," +
                                            "garage_flag," +
                                            "classification_code," +
                                            "classification_name," + // 外部結合で取得
                                            "contact_method," +
                                            "contact_name," + // 外部結合で取得
                                            "number_of_people," +
                                            "working_days," +
                                            "five_lap," +
                                            "move_flag," +
                                            "remarks," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM view_set_master ";
                                     // "WHERE delete_flag = 'False'"; // delete_flagを入れると過去の配車に削除済のSetLabelが反映出来なくなる
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var setMasterVo = new SetMasterVo();
                    setMasterVo.Word_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["word_code"]);
                    setMasterVo.Set_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["set_code"]);
                    setMasterVo.Set_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name"]);
                    setMasterVo.Set_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name_1"]);
                    setMasterVo.Set_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["set_name_2"]);
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
