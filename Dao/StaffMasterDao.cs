using System.Data;

using Common;

using Vo;

namespace Dao {
    public class StaffMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public StaffMasterDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneStaffMaster
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public ExtendsStaffMasterVo SelectOneStaffMaster(int staffCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff.master.staff_code," +
                                            "staff.master.belongs," +
                                            "belongs_name," + // 外部結合で取得
                                            "staff.master.vehicle_dispatch_target," +
                                            "staff.master.job_form," +
                                            "staff.master.occupation," +
                                            "occupation_name," + // 外部結合で取得
                                            "staff.master.name_kana," +
                                            "staff.master.name," +
                                            "staff.master.display_name," +
                                            "staff.master.gender," +
                                            "staff.master.birth_date," +
                                            "staff.master.employment_date," +
                                            "staff.master.code," +
                                            "staff.master.current_address," +
                                            "staff.master.before_change_address," +
                                            "staff.master.telephone_number," +
                                            "staff.master.cellphone_number," +
                                            "staff.master.picture," +
                                            "staff.master.blood_type," +
                                            "staff.master.staff.master.selection_date," +
                                            "not_selection_date," +
                                            "staff.master.not_selection_reason," +
                                            "staff.master.license_number," +
                                            "staff.master.history_date_1," +
                                            "staff.master.history_note_1," +
                                            "staff.master.history_date_2," +
                                            "staff.master.history_note_2," +
                                            "staff.master.history_date_3," +
                                            "staff.master.history_note_3," +
                                            "staff.master.history_date_4," +
                                            "staff.master.history_note_4," +
                                            "staff.master.history_date_5," +
                                            "staff.master.history_note_5," +
                                            "staff.master.history_date_6," +
                                            "staff.master.history_note_6," +
                                            "staff.master.experience_kind_1," +
                                            "staff.master.experience_load_1," +
                                            "staff.master.experience_duration_1," +
                                            "staff.master.experience_note_1," +
                                            "staff.master.experience_kind_2," +
                                            "staff.master.experience_load_2," +
                                            "staff.master.experience_duration_2," +
                                            "staff.master.experience_note_2," +
                                            "staff.master.experience_kind_3," +
                                            "staff.master.experience_load_3," +
                                            "staff.master.experience_duration_3," +
                                            "staff.master.experience_note_3," +
                                            "staff.master.experience_kind_4," +
                                            "staff.master.experience_load_4," +
                                            "staff.master.experience_duration_4," +
                                            "staff.master.experience_note_4," +
                                            "staff.master.retirement_flag," +
                                            "staff.master.retirement_date," +
                                            "staff.master.retirement_note," +
                                            "staff.master.death_date," +
                                            "staff.master.death_note," +
                                            "staff.master.family_name_1," +
                                            "staff.master.family_birth_date_1," +
                                            "staff.master.family_relationship_1," +
                                            "staff.master.family_name_2," +
                                            "staff.master.family_birth_date_2," +
                                            "staff.master.family_relationship_2," +
                                            "staff.master.family_name_3," +
                                            "staff.master.family_birth_date_3," +
                                            "staff.master.family_relationship_3," +
                                            "staff.master.family_name_4," +
                                            "staff.master.family_birth_date_4," +
                                            "staff.master.family_relationship_4," +
                                            "staff.master.family_name_5," +
                                            "staff.master.family_birth_date_5," +
                                            "staff.master.family_relationship_5," +
                                            "staff.master.family_name_6," +
                                            "staff.master.family_birth_date_6," +
                                            "staff.master.family_relationship_6," +
                                            "staff.master.urgent_telephone_number," +
                                            "staff.master.urgent_telephone_method," +
                                            "staff.master.health_insurance_date," +
                                            "staff.master.health_insurance_number," +
                                            "staff.master.health_insurance_note," +
                                            "staff.master.welfare_pension_date," +
                                            "staff.master.welfare_pension_number," +
                                            "staff.master.welfare_pension_note," +
                                            "staff.master.employment_insurance_date," +
                                            "staff.master.employment_insurance_number," +
                                            "staff.master.employment_insurance_note," +
                                            "staff.master.worker_accident_insurance_date," +
                                            "staff.master.worker_accident_insurance_number," +
                                            "staff.master.worker_accident_insurance_note," +
                                            "staff.master.medical_examination_date_1," +
                                            "staff.master.medical_examination_note_1," +
                                            "staff.master.medical_examination_date_2," +
                                            "staff.master.medical_examination_note_2," +
                                            "staff.master.medical_examination_date_3," +
                                            "staff.master.medical_examination_note_3," +
                                            "staff.master.medical_examination_date_4," +
                                            "staff.master.medical_examination_note_4," +
                                            "staff.master.medical_examination_note," +
                                            "staff.master.car_violate_date_1," +
                                            "staff.master.car_violate_content_1," +
                                            "staff.master.car_violate_place_1," +
                                            "staff.master.car_violate_date_2," +
                                            "staff.master.car_violate_content_2," +
                                            "staff.master.car_violate_place_2," +
                                            "staff.master.car_violate_date_3," +
                                            "staff.master.car_violate_content_3," +
                                            "staff.master.car_violate_place_3," +
                                            "staff.master.car_violate_date_4," +
                                            "staff.master.car_violate_content_4," +
                                            "staff.master.car_violate_place_4," +
                                            "staff.master.car_violate_date_5," +
                                            "staff.master.car_violate_content_5," +
                                            "staff.master.car_violate_place_5," +
                                            "staff.master.car_violate_date_6," +
                                            "staff.master.car_violate_content_6," +
                                            "staff.master.car_violate_place_6," +
                                            "staff.master.educate_date_1," +
                                            "staff.master.educate_name_1," +
                                            "staff.master.educate_date_2," +
                                            "staff.master.educate_name_2," +
                                            "staff.master.educate_date_3," +
                                            "staff.master.educate_name_3," +
                                            "staff.master.educate_date_4," +
                                            "staff.master.educate_name_4," +
                                            "staff.master.educate_date_5," +
                                            "staff.master.educate_name_5," +
                                            "staff.master.educate_date_6," +
                                            "staff.master.educate_name_6," +
                                            "staff.master.proper_kind_1," +
                                            "staff.master.proper_date_1," +
                                            "staff.master.proper_note_1," +
                                            "staff.master.proper_kind_2," +
                                            "staff.master.proper_date_2," +
                                            "staff.master.proper_note_2," +
                                            "staff.master.proper_kind_3," +
                                            "staff.master.proper_date_3," +
                                            "staff.master.proper_note_3," +
                                            "staff.master.punishment_date_1," +
                                            "staff.master.punishment_note_1," +
                                            "staff.master.punishment_date_2," +
                                            "staff.master.punishment_note_2," +
                                            "staff.master.punishment_date_3," +
                                            "staff.master.punishment_note_3," +
                                            "staff.master.punishment_date_4," +
                                            "staff.master.punishment_note_4," +
                                            "staff.master.insert_ymd_hms," +
                                            "staff.master.update_ymd_hms," +
                                            "staff.master.delete_ymd_hms," +
                                            "staff.master.delete_flag " +
                                     "FROM staff_master " +
                                     "WHERE staff_code = " + staffCode;
            ExtendsStaffMasterVo extendsStaffMasterVo = new ExtendsStaffMasterVo();
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    extendsStaffMasterVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    extendsStaffMasterVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["belongs"]);
                    extendsStaffMasterVo.Belongs_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["belongs_name"]); // 外部結合で取得
                    extendsStaffMasterVo.Vehicle_dispatch_target = _defaultValue.GetDefaultValue<bool>(sqlDataReader["vehicle_dispatch_target"]);
                    extendsStaffMasterVo.Job_form = _defaultValue.GetDefaultValue<int>(sqlDataReader["job_form"]);
                    extendsStaffMasterVo.Occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["occupation"]);
                    extendsStaffMasterVo.Occupation_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["occupation_name"]); // 外部結合で取得
                    extendsStaffMasterVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    extendsStaffMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    extendsStaffMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    extendsStaffMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["gender"]);
                    extendsStaffMasterVo.Birth_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["birth_date"]);
                    extendsStaffMasterVo.Employment_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_date"]);
                    extendsStaffMasterVo.Code = _defaultValue.GetDefaultValue<int>(sqlDataReader["code"]);
                    extendsStaffMasterVo.Current_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["current_address"]);
                    extendsStaffMasterVo.Before_change_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["before_change_address"]);
                    extendsStaffMasterVo.Telephone_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["telephone_number"]);
                    extendsStaffMasterVo.Cellphone_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["cellphone_number"]);
                    extendsStaffMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture"]);
                    extendsStaffMasterVo.Blood_type = _defaultValue.GetDefaultValue<string>(sqlDataReader["blood_type"]);
                    extendsStaffMasterVo.Selection_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["selection_date"]);
                    extendsStaffMasterVo.Not_selection_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["not_selection_date"]);
                    extendsStaffMasterVo.Not_selection_reason = _defaultValue.GetDefaultValue<string>(sqlDataReader["not_selection_reason"]);
                    extendsStaffMasterVo.License_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    extendsStaffMasterVo.History_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_1"]);
                    extendsStaffMasterVo.History_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_1"]);
                    extendsStaffMasterVo.History_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_2"]);
                    extendsStaffMasterVo.History_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_2"]);
                    extendsStaffMasterVo.History_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_3"]);
                    extendsStaffMasterVo.History_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_3"]);
                    extendsStaffMasterVo.History_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_4"]);
                    extendsStaffMasterVo.History_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_4"]);
                    extendsStaffMasterVo.History_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_5"]);
                    extendsStaffMasterVo.History_note_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_5"]);
                    extendsStaffMasterVo.History_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["history_date_6"]);
                    extendsStaffMasterVo.History_note_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["history_note_6"]);
                    extendsStaffMasterVo.Experience_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_1"]);
                    extendsStaffMasterVo.Experience_load_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_1"]);
                    extendsStaffMasterVo.Experience_duration_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_1"]);
                    extendsStaffMasterVo.Experience_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_1"]);
                    extendsStaffMasterVo.Experience_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_2"]);
                    extendsStaffMasterVo.Experience_load_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_2"]);
                    extendsStaffMasterVo.Experience_duration_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_2"]);
                    extendsStaffMasterVo.Experience_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_2"]);
                    extendsStaffMasterVo.Experience_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_3"]);
                    extendsStaffMasterVo.Experience_load_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_3"]);
                    extendsStaffMasterVo.Experience_duration_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_3"]);
                    extendsStaffMasterVo.Experience_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_3"]);
                    extendsStaffMasterVo.Experience_kind_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_kind_4"]);
                    extendsStaffMasterVo.Experience_load_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_load_4"]);
                    extendsStaffMasterVo.Experience_duration_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_duration_4"]);
                    extendsStaffMasterVo.Experience_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["experience_note_4"]);
                    extendsStaffMasterVo.Retirement_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["retirement_flag"]);
                    extendsStaffMasterVo.Retirement_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["retirement_date"]);
                    extendsStaffMasterVo.Retirement_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["retirement_note"]);
                    extendsStaffMasterVo.Death_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["death_date"]);
                    extendsStaffMasterVo.Death_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["death_note"]);
                    extendsStaffMasterVo.Family_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_1"]);
                    extendsStaffMasterVo.Family_birth_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_1"]);
                    extendsStaffMasterVo.Family_relationship_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_1"]);
                    extendsStaffMasterVo.Family_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_2"]);
                    extendsStaffMasterVo.Family_birth_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_2"]);
                    extendsStaffMasterVo.Family_relationship_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_2"]);
                    extendsStaffMasterVo.Family_name_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_3"]);
                    extendsStaffMasterVo.Family_birth_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_3"]);
                    extendsStaffMasterVo.Family_relationship_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_3"]);
                    extendsStaffMasterVo.Family_name_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_4"]);
                    extendsStaffMasterVo.Family_birth_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_4"]);
                    extendsStaffMasterVo.Family_relationship_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_4"]);
                    extendsStaffMasterVo.Family_name_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_5"]);
                    extendsStaffMasterVo.Family_birth_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_5"]);
                    extendsStaffMasterVo.Family_relationship_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_5"]);
                    extendsStaffMasterVo.Family_name_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_name_6"]);
                    extendsStaffMasterVo.Family_birth_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["family_birth_date_6"]);
                    extendsStaffMasterVo.Family_relationship_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["family_relationship_6"]);
                    extendsStaffMasterVo.Urgent_telephone_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["urgent_telephone_number"]);
                    extendsStaffMasterVo.Urgent_telephone_method = _defaultValue.GetDefaultValue<string>(sqlDataReader["urgent_telephone_method"]);
                    extendsStaffMasterVo.Health_insurance_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["health_insurance_date"]);
                    extendsStaffMasterVo.Health_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["health_insurance_number"]);
                    extendsStaffMasterVo.Health_insurance_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["health_insurance_note"]);
                    extendsStaffMasterVo.Welfare_pension_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["welfare_pension_date"]);
                    extendsStaffMasterVo.Welfare_pension_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["welfare_pension_number"]);
                    extendsStaffMasterVo.Welfare_pension_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["welfare_pension_note"]);
                    extendsStaffMasterVo.Employment_insurance_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_insurance_date"]);
                    extendsStaffMasterVo.Employment_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["employment_insurance_number"]);
                    extendsStaffMasterVo.Employment_insurance_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["employment_insurance_note"]);
                    extendsStaffMasterVo.Worker_accident_insurance_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["worker_accident_insurance_date"]);
                    extendsStaffMasterVo.Worker_accident_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["worker_accident_insurance_number"]);
                    extendsStaffMasterVo.Worker_accident_insurance_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["worker_accident_insurance_note"]);
                    extendsStaffMasterVo.Medical_examination_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_1"]);
                    extendsStaffMasterVo.Medical_examination_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_1"]);
                    extendsStaffMasterVo.Medical_examination_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_2"]);
                    extendsStaffMasterVo.Medical_examination_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_2"]);
                    extendsStaffMasterVo.Medical_examination_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_3"]);
                    extendsStaffMasterVo.Medical_examination_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_3"]);
                    extendsStaffMasterVo.Medical_examination_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_4"]);
                    extendsStaffMasterVo.Medical_examination_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note_4"]);
                    extendsStaffMasterVo.Medical_examination_note = _defaultValue.GetDefaultValue<string>(sqlDataReader["medical_examination_note"]);
                    extendsStaffMasterVo.Car_violate_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_1"]);
                    extendsStaffMasterVo.Car_violate_content_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_1"]);
                    extendsStaffMasterVo.Car_violate_place_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_1"]);
                    extendsStaffMasterVo.Car_violate_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_2"]);
                    extendsStaffMasterVo.Car_violate_content_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_2"]);
                    extendsStaffMasterVo.Car_violate_place_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_2"]);
                    extendsStaffMasterVo.Car_violate_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_3"]);
                    extendsStaffMasterVo.Car_violate_content_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_3"]);
                    extendsStaffMasterVo.Car_violate_place_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_3"]);
                    extendsStaffMasterVo.Car_violate_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_4"]);
                    extendsStaffMasterVo.Car_violate_content_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_4"]);
                    extendsStaffMasterVo.Car_violate_place_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_4"]);
                    extendsStaffMasterVo.Car_violate_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_5"]);
                    extendsStaffMasterVo.Car_violate_content_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_5"]);
                    extendsStaffMasterVo.Car_violate_place_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_5"]);
                    extendsStaffMasterVo.Car_violate_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["car_violate_date_6"]);
                    extendsStaffMasterVo.Car_violate_content_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_content_6"]);
                    extendsStaffMasterVo.Car_violate_place_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_violate_place_6"]);
                    extendsStaffMasterVo.Educate_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_1"]);
                    extendsStaffMasterVo.Educate_name_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_1"]);
                    extendsStaffMasterVo.Educate_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_2"]);
                    extendsStaffMasterVo.Educate_name_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_2"]);
                    extendsStaffMasterVo.Educate_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_3"]);
                    extendsStaffMasterVo.Educate_name_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_3"]);
                    extendsStaffMasterVo.Educate_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_4"]);
                    extendsStaffMasterVo.Educate_name_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_4"]);
                    extendsStaffMasterVo.Educate_date_5 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_5"]);
                    extendsStaffMasterVo.Educate_name_5 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_5"]);
                    extendsStaffMasterVo.Educate_date_6 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["educate_date_6"]);
                    extendsStaffMasterVo.Educate_name_6 = _defaultValue.GetDefaultValue<string>(sqlDataReader["educate_name_6"]);
                    extendsStaffMasterVo.Proper_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_1"]);
                    extendsStaffMasterVo.Proper_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_1"]);
                    extendsStaffMasterVo.Proper_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_note_1"]);
                    extendsStaffMasterVo.Proper_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_2"]);
                    extendsStaffMasterVo.Proper_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_2"]);
                    extendsStaffMasterVo.Proper_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_note_2"]);
                    extendsStaffMasterVo.Proper_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_3"]);
                    extendsStaffMasterVo.Proper_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_3"]);
                    extendsStaffMasterVo.Proper_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_note_3"]);
                    extendsStaffMasterVo.Punishment_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_1"]);
                    extendsStaffMasterVo.Punishment_note_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_1"]);
                    extendsStaffMasterVo.Punishment_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_2"]);
                    extendsStaffMasterVo.Punishment_note_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_2"]);
                    extendsStaffMasterVo.Punishment_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_3"]);
                    extendsStaffMasterVo.Punishment_note_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_3"]);
                    extendsStaffMasterVo.Punishment_date_4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["punishment_date_4"]);
                    extendsStaffMasterVo.Punishment_note_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["punishment_note_4"]);
                    extendsStaffMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    extendsStaffMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    extendsStaffMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    extendsStaffMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);

                    extendsStaffMasterVo.LicenseLedgerVo = new LicenseMasterDao(_connectionVo).SelectOneLicenseMaster(staffCode);
                }
            }
            return extendsStaffMasterVo;
        }

        /// <summary>
        /// SelectAllStaffMaster
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// SelectAllExtendsStaffMasterVo
        /// StaffList用
        /// </summary>
        /// <returns></returns>
        public List<ExtendsStaffMasterVo> SelectAllExtendsStaffMasterVo() {
            var listExtendsStaffMasterVo = new List<ExtendsStaffMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT staff_master.staff_code," +
                                            "staff_master.belongs," +
                                            "staff_master.vehicle_dispatch_target," +
                                            "staff_master.job_form," +
                                            "staff_master.occupation," +
                                            "staff_master.name," +
                                            "staff_master.display_name," +
                                            "staff_master.name_kana," +
                                            "staff_master.birth_date," +
                                            "staff_master.employment_date," +
                                            "staff_master.proper_kind_1," +
                                            "staff_master.proper_date_1," +
                                            "staff_master.proper_kind_2," +
                                            "staff_master.proper_date_2," +
                                            "staff_master.proper_kind_3," +
                                            "staff_master.proper_date_3," +
                                            "staff_master.medical_examination_date_1," +
                                            "staff_master.current_address," +
                                            "staff_master.health_insurance_number," +
                                            "staff_master.welfare_pension_number," +
                                            "staff_master.employment_insurance_number," +
                                            "staff_master.worker_accident_insurance_number," +
                                            "staff_master.delete_flag," +
                                            "staff_master.retirement_flag," +
                                            "toukanpo_training_card.staff_code AS toukanpo_staff_code," +
                                            "license_master.staff_code AS license_staff_code," +
                                            "license_master.license_number AS license_number," +
                                            "license_master.expiration_date AS license_expiration_date," +
                                            "means_of_commuting.notification AS commuting_notification," +
                                            "means_of_commuting.end_date AS means_of_commuting_end_date," +
                                            "(SELECT COUNT(staff_code) FROM car_accident_master WHERE staff_master.staff_code = car_accident_master.staff_code " +
                                                                                                 "AND car_accident_master.totalling_flag = 'True') AS car_accident_count " +
                                     //"AND car_accident_ledger.occurrence_ymd_hms BETWEEN '" + startDate + "' AND '" + endDate + "') AS car_accident_count " +
                                     "FROM staff_master LEFT OUTER JOIN toukanpo_training_card ON staff_master.staff_code = toukanpo_training_card.staff_code " +
                                                       "LEFT OUTER JOIN license_master ON staff_master.staff_code = license_master.staff_code " +
                                                       "LEFT OUTER JOIN means_of_commuting ON staff_master.staff_code = means_of_commuting.staff_code";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var extendsStaffMasterVo = new ExtendsStaffMasterVo();
                    extendsStaffMasterVo.Staff_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["staff_code"]);
                    extendsStaffMasterVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["belongs"]);
                    extendsStaffMasterVo.Vehicle_dispatch_target = _defaultValue.GetDefaultValue<bool>(sqlDataReader["vehicle_dispatch_target"]);
                    extendsStaffMasterVo.Job_form = _defaultValue.GetDefaultValue<int>(sqlDataReader["job_form"]);
                    extendsStaffMasterVo.Occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["occupation"]);
                    extendsStaffMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["name"]);
                    extendsStaffMasterVo.Display_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["display_name"]);
                    extendsStaffMasterVo.Name_kana = _defaultValue.GetDefaultValue<string>(sqlDataReader["name_kana"]);
                    extendsStaffMasterVo.ToukanpoTrainingCardFlag = sqlDataReader["toukanpo_staff_code"] == DBNull.Value ? false : true;
                    extendsStaffMasterVo.LicenseLedgerNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["license_number"]);
                    extendsStaffMasterVo.LicenseLedgerExpirationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["license_expiration_date"]);
                    extendsStaffMasterVo.CommutingNotification = _defaultValue.GetDefaultValue<bool>(sqlDataReader["commuting_notification"]);
                    extendsStaffMasterVo.MeansOfCommutingEndDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["means_of_commuting_end_date"]);
                    extendsStaffMasterVo.Birth_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["birth_date"]);
                    extendsStaffMasterVo.Employment_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["employment_date"]);
                    extendsStaffMasterVo.Proper_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_1"]);
                    extendsStaffMasterVo.Proper_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_1"]);
                    extendsStaffMasterVo.Proper_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_2"]);
                    extendsStaffMasterVo.Proper_date_2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_2"]);
                    extendsStaffMasterVo.Proper_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["proper_kind_3"]);
                    extendsStaffMasterVo.Proper_date_3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["proper_date_3"]);
                    extendsStaffMasterVo.CarAccidentLedgerCount = (int)sqlDataReader["car_accident_count"];
                    extendsStaffMasterVo.Medical_examination_date_1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["medical_examination_date_1"]);
                    extendsStaffMasterVo.Current_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["current_address"]);
                    extendsStaffMasterVo.Health_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["health_insurance_number"]);
                    extendsStaffMasterVo.Welfare_pension_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["welfare_pension_number"]);
                    extendsStaffMasterVo.Employment_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["employment_insurance_number"]);
                    extendsStaffMasterVo.Worker_accident_insurance_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["worker_accident_insurance_number"]);
                    extendsStaffMasterVo.Retirement_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["retirement_flag"]);
                    listExtendsStaffMasterVo.Add(extendsStaffMasterVo);
                }
            }
            return listExtendsStaffMasterVo;
        }

        /// <summary>
        /// InsertOneStaffMaster
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public int InsertOneStaffMaster(StaffMasterVo staffMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO staff_ledger(staff_code," +
                                                              "belongs," +
                                                              "vehicle_dispatch_target," +
                                                              "job_form," +
                                                              "occupation," +
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
                                                              "picture," +
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
                                                              "delete_flag) " +
                                     "VALUES ('" + staffMasterVo.Staff_code + "'," +
                                             "'" + staffMasterVo.Belongs + "'," +
                                             "'" + staffMasterVo.Vehicle_dispatch_target + "'," +
                                             "'" + staffMasterVo.Job_form + "'," +
                                             "'" + staffMasterVo.Occupation + "'," +
                                             "'" + staffMasterVo.Name_kana + "'," +
                                             "'" + staffMasterVo.Name + "'," +
                                             "'" + staffMasterVo.Display_name + "'," +
                                             "'" + staffMasterVo.Gender + "'," +
                                             "'" + staffMasterVo.Birth_date + "'," +
                                             "'" + staffMasterVo.Employment_date + "'," +
                                             "'" + staffMasterVo.Code + "'," +
                                             "'" + staffMasterVo.Current_address + "'," +
                                             "'" + staffMasterVo.Before_change_address + "'," +
                                             "'" + staffMasterVo.Telephone_number + "'," +
                                             "'" + staffMasterVo.Cellphone_number + "'," +
                                             "@member_picture," +
                                             "'" + staffMasterVo.Blood_type + "'," +
                                             "'" + staffMasterVo.Selection_date + "'," +
                                             "'" + staffMasterVo.Not_selection_date + "'," +
                                             "'" + staffMasterVo.Not_selection_reason + "'," +
                                             "'" + staffMasterVo.License_number + "'," +
                                             "'" + staffMasterVo.History_date_1 + "'," +
                                             "'" + staffMasterVo.History_note_1 + "'," +
                                             "'" + staffMasterVo.History_date_2 + "'," +
                                             "'" + staffMasterVo.History_note_2 + "'," +
                                             "'" + staffMasterVo.History_date_3 + "'," +
                                             "'" + staffMasterVo.History_note_3 + "'," +
                                             "'" + staffMasterVo.History_date_4 + "'," +
                                             "'" + staffMasterVo.History_note_4 + "'," +
                                             "'" + staffMasterVo.History_date_5 + "'," +
                                             "'" + staffMasterVo.History_note_5 + "'," +
                                             "'" + staffMasterVo.History_date_6 + "'," +
                                             "'" + staffMasterVo.History_note_6 + "'," +
                                             "'" + staffMasterVo.Experience_kind_1 + "'," +
                                             "'" + staffMasterVo.Experience_load_1 + "'," +
                                             "'" + staffMasterVo.Experience_duration_1 + "'," +
                                             "'" + staffMasterVo.Experience_note_1 + "'," +
                                             "'" + staffMasterVo.Experience_kind_2 + "'," +
                                             "'" + staffMasterVo.Experience_load_2 + "'," +
                                             "'" + staffMasterVo.Experience_duration_2 + "'," +
                                             "'" + staffMasterVo.Experience_note_2 + "'," +
                                             "'" + staffMasterVo.Experience_kind_3 + "'," +
                                             "'" + staffMasterVo.Experience_load_3 + "'," +
                                             "'" + staffMasterVo.Experience_duration_3 + "'," +
                                             "'" + staffMasterVo.Experience_note_3 + "'," +
                                             "'" + staffMasterVo.Experience_kind_4 + "'," +
                                             "'" + staffMasterVo.Experience_load_4 + "'," +
                                             "'" + staffMasterVo.Experience_duration_4 + "'," +
                                             "'" + staffMasterVo.Experience_note_4 + "'," +
                                             "'" + staffMasterVo.Retirement_flag + "'," +
                                             "'" + staffMasterVo.Retirement_date + "'," +
                                             "'" + staffMasterVo.Retirement_note + "'," +
                                             "'" + staffMasterVo.Death_date + "'," +
                                             "'" + staffMasterVo.Death_note + "'," +
                                             "'" + staffMasterVo.Family_name_1 + "'," +
                                             "'" + staffMasterVo.Family_birth_date_1 + "'," +
                                             "'" + staffMasterVo.Family_relationship_1 + "'," +
                                             "'" + staffMasterVo.Family_name_2 + "'," +
                                             "'" + staffMasterVo.Family_birth_date_2 + "'," +
                                             "'" + staffMasterVo.Family_relationship_2 + "'," +
                                             "'" + staffMasterVo.Family_name_3 + "'," +
                                             "'" + staffMasterVo.Family_birth_date_3 + "'," +
                                             "'" + staffMasterVo.Family_relationship_3 + "'," +
                                             "'" + staffMasterVo.Family_name_4 + "'," +
                                             "'" + staffMasterVo.Family_birth_date_4 + "'," +
                                             "'" + staffMasterVo.Family_relationship_4 + "'," +
                                             "'" + staffMasterVo.Family_name_5 + "'," +
                                             "'" + staffMasterVo.Family_birth_date_5 + "'," +
                                             "'" + staffMasterVo.Family_relationship_5 + "'," +
                                             "'" + staffMasterVo.Family_name_6 + "'," +
                                             "'" + staffMasterVo.Family_birth_date_6 + "'," +
                                             "'" + staffMasterVo.Family_relationship_6 + "'," +
                                             "'" + staffMasterVo.Urgent_telephone_number + "'," +
                                             "'" + staffMasterVo.Urgent_telephone_method + "'," +
                                             "'" + staffMasterVo.Health_insurance_date + "'," +
                                             "'" + staffMasterVo.Health_insurance_number + "'," +
                                             "'" + staffMasterVo.Health_insurance_note + "'," +
                                             "'" + staffMasterVo.Welfare_pension_date + "'," +
                                             "'" + staffMasterVo.Welfare_pension_number + "'," +
                                             "'" + staffMasterVo.Welfare_pension_note + "'," +
                                             "'" + staffMasterVo.Employment_insurance_date + "'," +
                                             "'" + staffMasterVo.Employment_insurance_number + "'," +
                                             "'" + staffMasterVo.Employment_insurance_note + "'," +
                                             "'" + staffMasterVo.Worker_accident_insurance_date + "'," +
                                             "'" + staffMasterVo.Worker_accident_insurance_number + "'," +
                                             "'" + staffMasterVo.Worker_accident_insurance_note + "'," +
                                             "'" + staffMasterVo.Medical_examination_date_1 + "'," +
                                             "'" + staffMasterVo.Medical_examination_note_1 + "'," +
                                             "'" + staffMasterVo.Medical_examination_date_2 + "'," +
                                             "'" + staffMasterVo.Medical_examination_note_2 + "'," +
                                             "'" + staffMasterVo.Medical_examination_date_3 + "'," +
                                             "'" + staffMasterVo.Medical_examination_note_3 + "'," +
                                             "'" + staffMasterVo.Medical_examination_date_4 + "'," +
                                             "'" + staffMasterVo.Medical_examination_note_4 + "'," +
                                             "'" + staffMasterVo.Medical_examination_note + "'," +
                                             "'" + staffMasterVo.Car_violate_date_1 + "'," +
                                             "'" + staffMasterVo.Car_violate_content_1 + "'," +
                                             "'" + staffMasterVo.Car_violate_place_1 + "'," +
                                             "'" + staffMasterVo.Car_violate_date_2 + "'," +
                                             "'" + staffMasterVo.Car_violate_content_2 + "'," +
                                             "'" + staffMasterVo.Car_violate_place_2 + "'," +
                                             "'" + staffMasterVo.Car_violate_date_3 + "'," +
                                             "'" + staffMasterVo.Car_violate_content_3 + "'," +
                                             "'" + staffMasterVo.Car_violate_place_3 + "'," +
                                             "'" + staffMasterVo.Car_violate_date_4 + "'," +
                                             "'" + staffMasterVo.Car_violate_content_4 + "'," +
                                             "'" + staffMasterVo.Car_violate_place_4 + "'," +
                                             "'" + staffMasterVo.Car_violate_date_5 + "'," +
                                             "'" + staffMasterVo.Car_violate_content_5 + "'," +
                                             "'" + staffMasterVo.Car_violate_place_5 + "'," +
                                             "'" + staffMasterVo.Car_violate_date_6 + "'," +
                                             "'" + staffMasterVo.Car_violate_content_6 + "'," +
                                             "'" + staffMasterVo.Car_violate_place_6 + "'," +
                                             "'" + staffMasterVo.Educate_date_1 + "'," +
                                             "'" + staffMasterVo.Educate_name_1 + "'," +
                                             "'" + staffMasterVo.Educate_date_2 + "'," +
                                             "'" + staffMasterVo.Educate_name_2 + "'," +
                                             "'" + staffMasterVo.Educate_date_3 + "'," +
                                             "'" + staffMasterVo.Educate_name_3 + "'," +
                                             "'" + staffMasterVo.Educate_date_4 + "'," +
                                             "'" + staffMasterVo.Educate_name_4 + "'," +
                                             "'" + staffMasterVo.Educate_date_5 + "'," +
                                             "'" + staffMasterVo.Educate_name_5 + "'," +
                                             "'" + staffMasterVo.Educate_date_6 + "'," +
                                             "'" + staffMasterVo.Educate_name_6 + "'," +
                                             "'" + staffMasterVo.Proper_kind_1 + "'," +
                                             "'" + staffMasterVo.Proper_date_1 + "'," +
                                             "'" + staffMasterVo.Proper_note_1 + "'," +
                                             "'" + staffMasterVo.Proper_kind_2 + "'," +
                                             "'" + staffMasterVo.Proper_date_2 + "'," +
                                             "'" + staffMasterVo.Proper_note_2 + "'," +
                                             "'" + staffMasterVo.Proper_kind_3 + "'," +
                                             "'" + staffMasterVo.Proper_date_3 + "'," +
                                             "'" + staffMasterVo.Proper_note_3 + "'," +
                                             "'" + staffMasterVo.Punishment_date_1 + "'," +
                                             "'" + staffMasterVo.Punishment_note_1 + "'," +
                                             "'" + staffMasterVo.Punishment_date_2 + "'," +
                                             "'" + staffMasterVo.Punishment_note_2 + "'," +
                                             "'" + staffMasterVo.Punishment_date_3 + "'," +
                                             "'" + staffMasterVo.Punishment_note_3 + "'," +
                                             "'" + staffMasterVo.Punishment_date_4 + "'," +
                                             "'" + staffMasterVo.Punishment_note_4 + "'," +
                                             "'" + DateTime.Now + "'," +
                                             "'1900-01-01'," +
                                             "'1900-01-01'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, staffMasterVo.Picture.Length).Value = staffMasterVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine("InsertOneStaffLedger : " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// UpdateOneStaffLedger
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public int UpdateOneStaffLedger(StaffMasterVo staffMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE staff_ledger " +
                                     "SET staff_code = '" + staffMasterVo.Staff_code + "'," +
                                         "belongs = '" + staffMasterVo.Belongs + "'," +
                                         "vehicle_dispatch_target = '" + staffMasterVo.Vehicle_dispatch_target + "'," +
                                         "job_form = '" + staffMasterVo.Job_form + "'," +
                                         "occupation = '" + staffMasterVo.Occupation + "'," +
                                         "name_kana = '" + staffMasterVo.Name_kana + "'," +
                                         "name = '" + staffMasterVo.Name + "'," +
                                         "display_name = '" + staffMasterVo.Display_name + "'," +
                                         "gender = '" + staffMasterVo.Gender + "'," +
                                         "birth_date = '" + staffMasterVo.Birth_date + "'," +
                                         "employment_date = '" + staffMasterVo.Employment_date + "'," +
                                         "code = '" + staffMasterVo.Code + "'," +
                                         "current_address = '" + staffMasterVo.Current_address + "'," +
                                         "before_change_address = '" + staffMasterVo.Before_change_address + "'," +
                                         "telephone_number = '" + staffMasterVo.Telephone_number + "'," +
                                         "cellphone_number = '" + staffMasterVo.Cellphone_number + "'," +
                                         "picture = @member_picture," +
                                         "blood_type = '" + staffMasterVo.Blood_type + "'," +
                                         "selection_date = '" + staffMasterVo.Selection_date + "'," +
                                         "not_selection_date = '" + staffMasterVo.Not_selection_date + "'," +
                                         "not_selection_reason = '" + staffMasterVo.Not_selection_reason + "'," +
                                         "license_number = '" + staffMasterVo.License_number + "'," +
                                         "history_date_1 = '" + staffMasterVo.History_date_1 + "'," +
                                         "history_note_1 = '" + staffMasterVo.History_note_1 + "'," +
                                         "history_date_2 = '" + staffMasterVo.History_date_2 + "'," +
                                         "history_note_2 = '" + staffMasterVo.History_note_2 + "'," +
                                         "history_date_3 = '" + staffMasterVo.History_date_3 + "'," +
                                         "history_note_3 = '" + staffMasterVo.History_note_3 + "'," +
                                         "history_date_4 = '" + staffMasterVo.History_date_4 + "'," +
                                         "history_note_4 = '" + staffMasterVo.History_note_4 + "'," +
                                         "history_date_5 = '" + staffMasterVo.History_date_5 + "'," +
                                         "history_note_5 = '" + staffMasterVo.History_note_5 + "'," +
                                         "history_date_6 = '" + staffMasterVo.History_date_6 + "'," +
                                         "history_note_6 = '" + staffMasterVo.History_note_6 + "'," +
                                         "experience_kind_1 = '" + staffMasterVo.Experience_kind_1 + "'," +
                                         "experience_load_1 = '" + staffMasterVo.Experience_load_1 + "'," +
                                         "experience_duration_1 = '" + staffMasterVo.Experience_duration_1 + "'," +
                                         "experience_note_1 = '" + staffMasterVo.Experience_note_1 + "'," +
                                         "experience_kind_2 = '" + staffMasterVo.Experience_kind_2 + "'," +
                                         "experience_load_2 = '" + staffMasterVo.Experience_load_2 + "'," +
                                         "experience_duration_2 = '" + staffMasterVo.Experience_duration_2 + "'," +
                                         "experience_note_2 = '" + staffMasterVo.Experience_note_2 + "'," +
                                         "experience_kind_3 = '" + staffMasterVo.Experience_kind_3 + "'," +
                                         "experience_load_3 = '" + staffMasterVo.Experience_load_3 + "'," +
                                         "experience_duration_3 = '" + staffMasterVo.Experience_duration_3 + "'," +
                                         "experience_note_3 = '" + staffMasterVo.Experience_note_3 + "'," +
                                         "experience_kind_4 = '" + staffMasterVo.Experience_kind_4 + "'," +
                                         "experience_load_4 = '" + staffMasterVo.Experience_load_4 + "'," +
                                         "experience_duration_4 = '" + staffMasterVo.Experience_duration_4 + "'," +
                                         "experience_note_4 = '" + staffMasterVo.Experience_note_4 + "'," +
                                         "retirement_flag = '" + staffMasterVo.Retirement_flag + "'," +
                                         "retirement_date = '" + staffMasterVo.Retirement_date + "'," +
                                         "retirement_note = '" + staffMasterVo.Retirement_note + "'," +
                                         "death_date = '" + staffMasterVo.Death_date + "'," +
                                         "death_note = '" + staffMasterVo.Death_note + "'," +
                                         "family_name_1 = '" + staffMasterVo.Family_name_1 + "'," +
                                         "family_birth_date_1 = '" + staffMasterVo.Family_birth_date_1 + "'," +
                                         "family_relationship_1 = '" + staffMasterVo.Family_relationship_1 + "'," +
                                         "family_name_2 = '" + staffMasterVo.Family_name_2 + "'," +
                                         "family_birth_date_2 = '" + staffMasterVo.Family_birth_date_2 + "'," +
                                         "family_relationship_2 = '" + staffMasterVo.Family_relationship_2 + "'," +
                                         "family_name_3 = '" + staffMasterVo.Family_name_3 + "'," +
                                         "family_birth_date_3 = '" + staffMasterVo.Family_birth_date_3 + "'," +
                                         "family_relationship_3 = '" + staffMasterVo.Family_relationship_3 + "'," +
                                         "family_name_4 = '" + staffMasterVo.Family_name_4 + "'," +
                                         "family_birth_date_4 = '" + staffMasterVo.Family_birth_date_4 + "'," +
                                         "family_relationship_4 = '" + staffMasterVo.Family_relationship_4 + "'," +
                                         "family_name_5 = '" + staffMasterVo.Family_name_5 + "'," +
                                         "family_birth_date_5 = '" + staffMasterVo.Family_birth_date_5 + "'," +
                                         "family_relationship_5 = '" + staffMasterVo.Family_relationship_5 + "'," +
                                         "family_name_6 = '" + staffMasterVo.Family_name_6 + "'," +
                                         "family_birth_date_6 = '" + staffMasterVo.Family_birth_date_6 + "'," +
                                         "family_relationship_6 = '" + staffMasterVo.Family_relationship_6 + "'," +
                                         "urgent_telephone_number = '" + staffMasterVo.Urgent_telephone_number + "'," +
                                         "urgent_telephone_method = '" + staffMasterVo.Urgent_telephone_method + "'," +
                                         "health_insurance_date = '" + staffMasterVo.Health_insurance_date + "'," +
                                         "health_insurance_number = '" + staffMasterVo.Health_insurance_number + "'," +
                                         "health_insurance_note = '" + staffMasterVo.Health_insurance_note + "'," +
                                         "welfare_pension_date = '" + staffMasterVo.Welfare_pension_date + "'," +
                                         "welfare_pension_number = '" + staffMasterVo.Welfare_pension_number + "'," +
                                         "welfare_pension_note = '" + staffMasterVo.Welfare_pension_note + "'," +
                                         "employment_insurance_date = '" + staffMasterVo.Employment_insurance_date + "'," +
                                         "employment_insurance_number = '" + staffMasterVo.Employment_insurance_number + "'," +
                                         "employment_insurance_note = '" + staffMasterVo.Employment_insurance_note + "'," +
                                         "worker_accident_insurance_date = '" + staffMasterVo.Worker_accident_insurance_date + "'," +
                                         "worker_accident_insurance_number = '" + staffMasterVo.Worker_accident_insurance_number + "'," +
                                         "worker_accident_insurance_note = '" + staffMasterVo.Worker_accident_insurance_note + "'," +
                                         "medical_examination_date_1 = '" + staffMasterVo.Medical_examination_date_1 + "'," +
                                         "medical_examination_note_1 = '" + staffMasterVo.Medical_examination_note_1 + "'," +
                                         "medical_examination_date_2 = '" + staffMasterVo.Medical_examination_date_2 + "'," +
                                         "medical_examination_note_2 = '" + staffMasterVo.Medical_examination_note_2 + "'," +
                                         "medical_examination_date_3 = '" + staffMasterVo.Medical_examination_date_3 + "'," +
                                         "medical_examination_note_3 = '" + staffMasterVo.Medical_examination_note_3 + "'," +
                                         "medical_examination_date_4 = '" + staffMasterVo.Medical_examination_date_4 + "'," +
                                         "medical_examination_note_4 = '" + staffMasterVo.Medical_examination_note_4 + "'," +
                                         "medical_examination_note = '" + staffMasterVo.Medical_examination_note + "'," +
                                         "car_violate_date_1 = '" + staffMasterVo.Car_violate_date_1 + "'," +
                                         "car_violate_content_1 = '" + staffMasterVo.Car_violate_content_1 + "'," +
                                         "car_violate_place_1 = '" + staffMasterVo.Car_violate_place_1 + "'," +
                                         "car_violate_date_2 = '" + staffMasterVo.Car_violate_date_2 + "'," +
                                         "car_violate_content_2 = '" + staffMasterVo.Car_violate_content_2 + "'," +
                                         "car_violate_place_2 = '" + staffMasterVo.Car_violate_place_2 + "'," +
                                         "car_violate_date_3 = '" + staffMasterVo.Car_violate_date_3 + "'," +
                                         "car_violate_content_3 = '" + staffMasterVo.Car_violate_content_3 + "'," +
                                         "car_violate_place_3 = '" + staffMasterVo.Car_violate_place_3 + "'," +
                                         "car_violate_date_4 = '" + staffMasterVo.Car_violate_date_4 + "'," +
                                         "car_violate_content_4 = '" + staffMasterVo.Car_violate_content_4 + "'," +
                                         "car_violate_place_4 = '" + staffMasterVo.Car_violate_place_4 + "'," +
                                         "car_violate_date_5 = '" + staffMasterVo.Car_violate_date_5 + "'," +
                                         "car_violate_content_5 = '" + staffMasterVo.Car_violate_content_5 + "'," +
                                         "car_violate_place_5 = '" + staffMasterVo.Car_violate_place_5 + "'," +
                                         "car_violate_date_6 = '" + staffMasterVo.Car_violate_date_6 + "'," +
                                         "car_violate_content_6 = '" + staffMasterVo.Car_violate_content_6 + "'," +
                                         "car_violate_place_6 = '" + staffMasterVo.Car_violate_place_6 + "'," +
                                         "educate_date_1 = '" + staffMasterVo.Educate_date_1 + "'," +
                                         "educate_name_1 = '" + staffMasterVo.Educate_name_1 + "'," +
                                         "educate_date_2 = '" + staffMasterVo.Educate_date_2 + "'," +
                                         "educate_name_2 = '" + staffMasterVo.Educate_name_2 + "'," +
                                         "educate_date_3 = '" + staffMasterVo.Educate_date_3 + "'," +
                                         "educate_name_3 = '" + staffMasterVo.Educate_name_3 + "'," +
                                         "educate_date_4 = '" + staffMasterVo.Educate_date_4 + "'," +
                                         "educate_name_4 = '" + staffMasterVo.Educate_name_4 + "'," +
                                         "educate_date_5 = '" + staffMasterVo.Educate_date_5 + "'," +
                                         "educate_name_5 = '" + staffMasterVo.Educate_name_5 + "'," +
                                         "educate_date_6 = '" + staffMasterVo.Educate_date_6 + "'," +
                                         "educate_name_6 = '" + staffMasterVo.Educate_name_6 + "'," +
                                         "proper_kind_1 = '" + staffMasterVo.Proper_kind_1 + "'," +
                                         "proper_date_1 = '" + staffMasterVo.Proper_date_1 + "'," +
                                         "proper_note_1 = '" + staffMasterVo.Proper_note_1 + "'," +
                                         "proper_kind_2 = '" + staffMasterVo.Proper_kind_2 + "'," +
                                         "proper_date_2 = '" + staffMasterVo.Proper_date_2 + "'," +
                                         "proper_note_2 = '" + staffMasterVo.Proper_note_2 + "'," +
                                         "proper_kind_3 = '" + staffMasterVo.Proper_kind_3 + "'," +
                                         "proper_date_3 = '" + staffMasterVo.Proper_date_3 + "'," +
                                         "proper_note_3 = '" + staffMasterVo.Proper_note_3 + "'," +
                                         "punishment_date_1 = '" + staffMasterVo.Punishment_date_1 + "'," +
                                         "punishment_note_1 = '" + staffMasterVo.Punishment_note_1 + "'," +
                                         "punishment_date_2 = '" + staffMasterVo.Punishment_date_2 + "'," +
                                         "punishment_note_2 = '" + staffMasterVo.Punishment_note_2 + "'," +
                                         "punishment_date_3 = '" + staffMasterVo.Punishment_date_3 + "'," +
                                         "punishment_note_3 = '" + staffMasterVo.Punishment_note_3 + "'," +
                                         "punishment_date_4 = '" + staffMasterVo.Punishment_date_4 + "'," +
                                         "punishment_note_4 = '" + staffMasterVo.Punishment_note_4 + "'," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE staff_code='" + staffMasterVo.Staff_code + "' " +
                                     "AND delete_Flag = 'False'";
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, staffMasterVo.Picture.Length).Value = staffMasterVo.Picture;
                return sqlCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine("UpdateOneStaffLedger : " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// 新規staff_codeを採番
        /// 引数(staffCode)より小さい番号の中で最大の番号を取得する
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public int GetStaffCode(int staffCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT MAX(staff_code) " +
                                     "FROM staff_ledger " +
                                     "WHERE staff_code < '" + staffCode + "'";
            try {
                return (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// CheckStaffLedger
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public bool CheckStaffMaster(decimal staffCode) {
            int count;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(staff_code) " +
                                     "FROM staff_master " +
                                     "WHERE staff_code = " + staffCode;
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }
    }
}
