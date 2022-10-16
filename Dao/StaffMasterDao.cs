using Common;

using Vo;

namespace Dao {
    public class StaffMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public StaffMasterDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        public List<StaffMasterVo> SelectAllStaffMaster() {
            var listStaffMasterVo = new List<StaffMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_code," +
                                            "belongs," +
                                            "belongs_name," + // 外部結合で取得
                                            "vehicle_dispatch_target," +
                                            "job_form," +
                                            "occupation," +
                                            "occupation_name," + // 外部結合で取得
                                            "name_kana," +
                                            "name," +
                                            "display_name," +
                                            "gender," +
                                            "birth_date," +
                                            "employment_date," +
                                            "code," +
                                            "current_address," +
                                            "before_change_address," +
                                            "telephone_number," +
                                            "cellphone_number," +
                                            //"picture," +
                                            "blood_type," +
                                            "selection_date," +
                                            "not_selection_date," +
                                            "not_selection_reason," +
                                            "license_number," +
                                            "history_date_1," +
                                            "history_note_1," +
                                            "history_date_2," +
                                            "history_note_2," +
                                            "history_date_3," +
                                            "history_note_3," +
                                            "history_date_4," +
                                            "history_note_4," +
                                            "history_date_5," +
                                            "history_note_5," +
                                            "history_date_6," +
                                            "history_note_6," +
                                            "experience_kind_1," +
                                            "experience_load_1," +
                                            "experience_duration_1," +
                                            "experience_note_1," +
                                            "experience_kind_2," +
                                            "experience_load_2," +
                                            "experience_duration_2," +
                                            "experience_note_2," +
                                            "experience_kind_3," +
                                            "experience_load_3," +
                                            "experience_duration_3," +
                                            "experience_note_3," +
                                            "experience_kind_4," +
                                            "experience_load_4," +
                                            "experience_duration_4," +
                                            "experience_note_4," +
                                            "retirement_flag," +
                                            "retirement_date," +
                                            "retirement_note," +
                                            "death_date," +
                                            "death_note," +
                                            "family_name_1," +
                                            "family_birth_date_1," +
                                            "family_relationship_1," +
                                            "family_name_2," +
                                            "family_birth_date_2," +
                                            "family_relationship_2," +
                                            "family_name_3," +
                                            "family_birth_date_3," +
                                            "family_relationship_3," +
                                            "family_name_4," +
                                            "family_birth_date_4," +
                                            "family_relationship_4," +
                                            "family_name_5," +
                                            "family_birth_date_5," +
                                            "family_relationship_5," +
                                            "family_name_6," +
                                            "family_birth_date_6," +
                                            "family_relationship_6," +
                                            "urgent_telephone_number," +
                                            "urgent_telephone_method," +
                                            "health_insurance_date," +
                                            "health_insurance_number," +
                                            "health_insurance_note," +
                                            "welfare_pension_date," +
                                            "welfare_pension_number," +
                                            "welfare_pension_note," +
                                            "employment_insurance_date," +
                                            "employment_insurance_number," +
                                            "employment_insurance_note," +
                                            "worker_accident_insurance_date," +
                                            "worker_accident_insurance_number," +
                                            "worker_accident_insurance_note," +
                                            "medical_examination_date_1," +
                                            "medical_examination_note_1," +
                                            "medical_examination_date_2," +
                                            "medical_examination_note_2," +
                                            "medical_examination_date_3," +
                                            "medical_examination_note_3," +
                                            "medical_examination_date_4," +
                                            "medical_examination_note_4," +
                                            "medical_examination_note," +
                                            "car_violate_date_1," +
                                            "car_violate_content_1," +
                                            "car_violate_place_1," +
                                            "car_violate_date_2," +
                                            "car_violate_content_2," +
                                            "car_violate_place_2," +
                                            "car_violate_date_3," +
                                            "car_violate_content_3," +
                                            "car_violate_place_3," +
                                            "car_violate_date_4," +
                                            "car_violate_content_4," +
                                            "car_violate_place_4," +
                                            "car_violate_date_5," +
                                            "car_violate_content_5," +
                                            "car_violate_place_5," +
                                            "car_violate_date_6," +
                                            "car_violate_content_6," +
                                            "car_violate_place_6," +
                                            "educate_date_1," +
                                            "educate_name_1," +
                                            "educate_date_2," +
                                            "educate_name_2," +
                                            "educate_date_3," +
                                            "educate_name_3," +
                                            "educate_date_4," +
                                            "educate_name_4," +
                                            "educate_date_5," +
                                            "educate_name_5," +
                                            "educate_date_6," +
                                            "educate_name_6," +
                                            "proper_kind_1," +
                                            "proper_date_1," +
                                            "proper_note_1," +
                                            "proper_kind_2," +
                                            "proper_date_2," +
                                            "proper_note_2," +
                                            "proper_kind_3," +
                                            "proper_date_3," +
                                            "proper_note_3," +
                                            "punishment_date_1," +
                                            "punishment_note_1," +
                                            "punishment_date_2," +
                                            "punishment_note_2," +
                                            "punishment_date_3," +
                                            "punishment_note_3," +
                                            "punishment_date_4," +
                                            "punishment_note_4," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM view_staff_master ";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var staffMasterVo = new StaffMasterVo();
                    staffMasterVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    staffMasterVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["belongs"]);
                    staffMasterVo.Belongs_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["belongs_name"]); // 外部結合で取得
                    staffMasterVo.Vehicle_dispatch_target = _defaultValue.GetDefaultValue<bool>(sqlDataReader["vehicle_dispatch_target"]);
                    staffMasterVo.Job_form = _defaultValue.GetDefaultValue<int>(sqlDataReader["job_form"]);
                    staffMasterVo.Occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["occupation"]);
                    staffMasterVo.Occupation_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["occupation_name"]); // 外部結合で取得
                    staffMasterVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    staffMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    staffMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    staffMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["gender"]);
                    staffMasterVo.Birth_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["birth_date"]);
                    staffMasterVo.Employment_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_date"]);
                    staffMasterVo.Code = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    staffMasterVo.Current_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["current_address"]);
                    staffMasterVo.Before_change_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["before_change_address"]);
                    staffMasterVo.Telephone_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["telephone_number"]);
                    staffMasterVo.Cellphone_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["cellphone_number"]);
                    //staffLedgerVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture"]);
                    staffMasterVo.Blood_type = _defaultValue.GetDefaultValue<string>(sqlDataReader["blood_type"]);
                    staffMasterVo.Selection_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["selection_date"]);
                    staffMasterVo.Not_selection_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["not_selection_date"]);
                    staffMasterVo.Not_selection_reason = _defaultValue.GetDefaultValue<string>(sqlDataReader["not_selection_reason"]);
                    staffMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    staffMasterVo.History_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_1"]);
                    staffMasterVo.History_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_1"]);
                    staffMasterVo.History_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_2"]);
                    staffMasterVo.History_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_2"]);
                    staffMasterVo.History_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_3"]);
                    staffMasterVo.History_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_3"]);
                    staffMasterVo.History_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_4"]);
                    staffMasterVo.History_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_4"]);
                    staffMasterVo.History_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_5"]);
                    staffMasterVo.History_note_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_5"]);
                    staffMasterVo.History_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_6"]);
                    staffMasterVo.History_note_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_6"]);
                    staffMasterVo.Experience_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_1"]);
                    staffMasterVo.Experience_load_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_1"]);
                    staffMasterVo.Experience_duration_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_1"]);
                    staffMasterVo.Experience_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_1"]);
                    staffMasterVo.Experience_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_2"]);
                    staffMasterVo.Experience_load_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_2"]);
                    staffMasterVo.Experience_duration_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_2"]);
                    staffMasterVo.Experience_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_2"]);
                    staffMasterVo.Experience_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_3"]);
                    staffMasterVo.Experience_load_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_3"]);
                    staffMasterVo.Experience_duration_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_3"]);
                    staffMasterVo.Experience_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_3"]);
                    staffMasterVo.Experience_kind_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_4"]);
                    staffMasterVo.Experience_load_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_4"]);
                    staffMasterVo.Experience_duration_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_4"]);
                    staffMasterVo.Experience_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_4"]);
                    staffMasterVo.Retirement_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["retirement_flag"]);
                    staffMasterVo.Retirement_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["retirement_date"]);
                    staffMasterVo.Retirement_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["retirement_note"]);
                    staffMasterVo.Death_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["death_date"]);
                    staffMasterVo.Death_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["death_note"]);
                    staffMasterVo.Family_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_1"]);
                    staffMasterVo.Family_birth_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_1"]);
                    staffMasterVo.Family_relationship_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_1"]);
                    staffMasterVo.Family_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_2"]);
                    staffMasterVo.Family_birth_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_2"]);
                    staffMasterVo.Family_relationship_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_2"]);
                    staffMasterVo.Family_name_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_3"]);
                    staffMasterVo.Family_birth_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_3"]);
                    staffMasterVo.Family_relationship_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_3"]);
                    staffMasterVo.Family_name_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_4"]);
                    staffMasterVo.Family_birth_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_4"]);
                    staffMasterVo.Family_relationship_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_4"]);
                    staffMasterVo.Family_name_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_5"]);
                    staffMasterVo.Family_birth_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_5"]);
                    staffMasterVo.Family_relationship_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_5"]);
                    staffMasterVo.Family_name_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_6"]);
                    staffMasterVo.Family_birth_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_6"]);
                    staffMasterVo.Family_relationship_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_6"]);
                    staffMasterVo.Urgent_telephone_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["urgent_telephone_number"]);
                    staffMasterVo.Urgent_telephone_method = _defaultValue.GetDefaultValue<string>(sqlDataReader["urgent_telephone_method"]);
                    staffMasterVo.Health_insurance_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["health_insurance_date"]);
                    staffMasterVo.Health_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["health_insurance_number"]);
                    staffMasterVo.Health_insurance_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["health_insurance_note"]);
                    staffMasterVo.Welfare_pension_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["welfare_pension_date"]);
                    staffMasterVo.Welfare_pension_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["welfare_pension_number"]);
                    staffMasterVo.Welfare_pension_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["welfare_pension_note"]);
                    staffMasterVo.Employment_insurance_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_insurance_date"]);
                    staffMasterVo.Employment_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["employment_insurance_number"]);
                    staffMasterVo.Employment_insurance_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["employment_insurance_note"]);
                    staffMasterVo.Worker_accident_insurance_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["worker_accident_insurance_date"]);
                    staffMasterVo.Worker_accident_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["worker_accident_insurance_number"]);
                    staffMasterVo.Worker_accident_insurance_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["worker_accident_insurance_note"]);
                    staffMasterVo.Medical_examination_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_1"]);
                    staffMasterVo.Medical_examination_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_1"]);
                    staffMasterVo.Medical_examination_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_2"]);
                    staffMasterVo.Medical_examination_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_2"]);
                    staffMasterVo.Medical_examination_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_3"]);
                    staffMasterVo.Medical_examination_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_3"]);
                    staffMasterVo.Medical_examination_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_4"]);
                    staffMasterVo.Medical_examination_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_4"]);
                    staffMasterVo.Medical_examination_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note"]);
                    staffMasterVo.Car_violate_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_1"]);
                    staffMasterVo.Car_violate_content_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_1"]);
                    staffMasterVo.Car_violate_place_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_1"]);
                    staffMasterVo.Car_violate_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_2"]);
                    staffMasterVo.Car_violate_content_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_2"]);
                    staffMasterVo.Car_violate_place_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_2"]);
                    staffMasterVo.Car_violate_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_3"]);
                    staffMasterVo.Car_violate_content_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_3"]);
                    staffMasterVo.Car_violate_place_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_3"]);
                    staffMasterVo.Car_violate_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_4"]);
                    staffMasterVo.Car_violate_content_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_4"]);
                    staffMasterVo.Car_violate_place_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_4"]);
                    staffMasterVo.Car_violate_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_5"]);
                    staffMasterVo.Car_violate_content_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_5"]);
                    staffMasterVo.Car_violate_place_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_5"]);
                    staffMasterVo.Car_violate_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_6"]);
                    staffMasterVo.Car_violate_content_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_6"]);
                    staffMasterVo.Car_violate_place_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_6"]);
                    staffMasterVo.Educate_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_1"]);
                    staffMasterVo.Educate_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_1"]);
                    staffMasterVo.Educate_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_2"]);
                    staffMasterVo.Educate_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_2"]);
                    staffMasterVo.Educate_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_3"]);
                    staffMasterVo.Educate_name_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_3"]);
                    staffMasterVo.Educate_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_4"]);
                    staffMasterVo.Educate_name_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_4"]);
                    staffMasterVo.Educate_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_5"]);
                    staffMasterVo.Educate_name_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_5"]);
                    staffMasterVo.Educate_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_6"]);
                    staffMasterVo.Educate_name_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_6"]);
                    staffMasterVo.Proper_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_1"]);
                    staffMasterVo.Proper_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_1"]);
                    staffMasterVo.Proper_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_note_1"]);
                    staffMasterVo.Proper_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_2"]);
                    staffMasterVo.Proper_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_2"]);
                    staffMasterVo.Proper_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_note_2"]);
                    staffMasterVo.Proper_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_3"]);
                    staffMasterVo.Proper_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_3"]);
                    staffMasterVo.Proper_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_note_3"]);
                    staffMasterVo.Punishment_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_1"]);
                    staffMasterVo.Punishment_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_1"]);
                    staffMasterVo.Punishment_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_2"]);
                    staffMasterVo.Punishment_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_2"]);
                    staffMasterVo.Punishment_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_3"]);
                    staffMasterVo.Punishment_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_3"]);
                    staffMasterVo.Punishment_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_4"]);
                    staffMasterVo.Punishment_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_4"]);
                    staffMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    staffMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    staffMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    staffMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listStaffMasterVo.Add(staffMasterVo);
                }
            }
            return listStaffMasterVo;
        }
    }
}
