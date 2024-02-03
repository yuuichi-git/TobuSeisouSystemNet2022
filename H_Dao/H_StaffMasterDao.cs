/*
 * 2023-11-16
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;


namespace H_Dao {
    public class H_StaffMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// H_StaffMaster
        /// </summary>
        /// <returns></returns>
        public List<H_StaffMasterVo> SelectAllHStaffMaster() {
            List<H_StaffMasterVo> listHStaffMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "UnionCode," +
                                            "Belongs," +
                                            "VehicleDispatchTarget," +
                                            "JobForm," +
                                            "Occupation," +
                                            "NameKana," +
                                            "Name," +
                                            "DisplayName," +
                                            "Gender," +
                                            "BirthDate," +
                                            "EmploymentDate," +
                                            "CurrentAddress," +
                                            "BeforeChangeAddress," +
                                            "Remarks," +
                                            "TelephoneNumber," +
                                            "CellphoneNumber," +
                                            //"Picture," +
                                            "BloodType," +
                                            "SelectionDate," +
                                            "NotSelectionDate," +
                                            "NotSelectionReason," +
                                            "LicenseNumber," +
                                            "RetirementFlag," +
                                            "RetirementDate," +
                                            "RetirementNote," +
                                            "DeathDate," +
                                            "DeathNote," +
                                            "UrgentTelephoneNumber," +
                                            "UrgentTelephoneMethod," +
                                            "HealthInsuranceDate," +
                                            "HealthInsuranceNumber," +
                                            "HealthInsuranceNote," +
                                            "WelfarePensionDate," +
                                            "WelfarePensionNumber," +
                                            "WelfarePensionNote," +
                                            "EmploymentInsuranceDate," +
                                            "EmploymentInsuranceNumber," +
                                            "EmploymentInsuranceNote," +
                                            "WorkerAccidentInsuranceDate," +
                                            "WorkerAccidentInsuranceNumber," +
                                            "WorkerAccidentInsuranceNote," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StaffMaster";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    H_StaffMasterVo hStaffMasterVo = new();
                    hStaffMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffMasterVo.UnionCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["UnionCode"]);
                    hStaffMasterVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["Belongs"]);
                    hStaffMasterVo.VehicleDispatchTarget = _defaultValue.GetDefaultValue<bool>(sqlDataReader["VehicleDispatchTarget"]);
                    hStaffMasterVo.JobForm = _defaultValue.GetDefaultValue<int>(sqlDataReader["JobForm"]);
                    hStaffMasterVo.Occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["Occupation"]);
                    hStaffMasterVo.NameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["NameKana"]);
                    hStaffMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["Name"]);
                    hStaffMasterVo.DisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisplayName"]);
                    hStaffMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["Gender"]);
                    hStaffMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStaffMasterVo.EmploymentDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentDate"]);
                    hStaffMasterVo.CurrentAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["CurrentAddress"]);
                    hStaffMasterVo.BeforeChangeAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["BeforeChangeAddress"]);
                    hStaffMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["Remarks"]);
                    hStaffMasterVo.TelephoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["TelephoneNumber"]);
                    hStaffMasterVo.CellphoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CellphoneNumber"]);
                    //hStaffMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                    hStaffMasterVo.BloodType = _defaultValue.GetDefaultValue<string>(sqlDataReader["BloodType"]);
                    hStaffMasterVo.SelectionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["SelectionDate"]);
                    hStaffMasterVo.NotSelectionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["NotSelectionDate"]);
                    hStaffMasterVo.NotSelectionReason = _defaultValue.GetDefaultValue<string>(sqlDataReader["NotSelectionReason"]);
                    hStaffMasterVo.LicenseNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseNumber"]);
                    hStaffMasterVo.RetirementFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["RetirementFlag"]);
                    hStaffMasterVo.RetirementDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["RetirementDate"]);
                    hStaffMasterVo.RetirementNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["RetirementNote"]);
                    hStaffMasterVo.DeathDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeathDate"]);
                    hStaffMasterVo.DeathNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeathNote"]);
                    hStaffMasterVo.UrgentTelephoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["UrgentTelephoneNumber"]);
                    hStaffMasterVo.UrgentTelephoneMethod = _defaultValue.GetDefaultValue<string>(sqlDataReader["UrgentTelephoneMethod"]);
                    hStaffMasterVo.HealthInsuranceDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["HealthInsuranceDate"]);
                    hStaffMasterVo.HealthInsuranceNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["HealthInsuranceNumber"]);
                    hStaffMasterVo.HealthInsuranceNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["HealthInsuranceNote"]);
                    hStaffMasterVo.WelfarePensionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["WelfarePensionDate"]);
                    hStaffMasterVo.WelfarePensionNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["WelfarePensionNumber"]);
                    hStaffMasterVo.WelfarePensionNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["WelfarePensionNote"]);
                    hStaffMasterVo.EmploymentInsuranceDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentInsuranceDate"]);
                    hStaffMasterVo.EmploymentInsuranceNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["EmploymentInsuranceNumber"]);
                    hStaffMasterVo.EmploymentInsuranceNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["EmploymentInsuranceNote"]);
                    hStaffMasterVo.WorkerAccidentInsuranceDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["WorkerAccidentInsuranceDate"]);
                    hStaffMasterVo.WorkerAccidentInsuranceNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkerAccidentInsuranceNumber"]);
                    hStaffMasterVo.WorkerAccidentInsuranceNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkerAccidentInsuranceNote"]);
                    hStaffMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStaffMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStaffMasterVo.Add(hStaffMasterVo);
                }
            }
            return listHStaffMasterVo;
        }
    }
}
