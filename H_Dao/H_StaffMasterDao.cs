/*
 * 2023-11-16
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using Vo;

namespace H_Dao {
    public class H_StaffMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Dao
         */
        private readonly H_StaffHistoryDao _hStaffHistoryDao;
        private readonly H_StaffExperienceDao _hStaffExperienceDao;
        private readonly H_StaffFamilyDao _hStaffFamilyDao;
        private readonly H_StaffMedicalExaminationDao _hStaffMedicalExaminationDao;
        private readonly H_StaffCarViolateDao _hStaffCarViolateDao;
        private readonly H_StaffEducateDao _hStaffEducateDao;
        private readonly H_StaffProperDao _hStaffProperDao;
        private readonly H_StaffPunishmentDao _hStaffPunishmentDao;
        private readonly H_LicenseMasterDao _hLicenseMasterDao;
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
             * Dao
             */
            _hStaffHistoryDao = new(connectionVo);
            _hStaffExperienceDao = new(connectionVo);
            _hStaffFamilyDao = new(connectionVo);
            _hStaffMedicalExaminationDao = new(connectionVo);
            _hStaffCarViolateDao = new(connectionVo);
            _hStaffEducateDao = new(connectionVo);
            _hStaffProperDao = new(connectionVo);
            _hStaffPunishmentDao = new(connectionVo);
            _hLicenseMasterDao = new(connectionVo);
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHStaffMasterRecord
        /// true:該当レコードあり false:該当レコードなし
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public bool ExistenceHStaffMaster(int staffCode) {
            int count;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(StaffCode) " +
                                     "FROM H_StaffMaster " +
                                     "WHERE StaffCode = " + staffCode;
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// 新規staff_codeを採番
        /// 引数(staffCode)より小さい番号の中で最大の番号を取得する
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public int GetStaffCode(int staffCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT MAX(StaffCode) " +
                                     "FROM H_StaffMaster " +
                                     "WHERE StaffCode < " + staffCode;
            try {
                return (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectAllHStaffMaster
        /// H_StaffListで使用(画面に合わせてある)
        /// </summary>
        /// <returns></returns>
        public List<H_StaffMasterVo> SelectHStaffMasterForStaffList(string sqlBelongs, string sqlJobForm, string sqlOccupation) {
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
                                            "OtherNameKana," +
                                            "OtherName," +
                                            "BirthDate," +
                                            "EmploymentDate," +
                                            "CurrentAddress," +
                                            "RetirementFlag," +
                                            "HealthInsuranceDate," +
                                            "HealthInsuranceNumber," +
                                            "WelfarePensionDate," +
                                            "EmploymentInsuranceDate," +
                                            "WorkerAccidentInsuranceDate " +
                                     "FROM H_StaffMaster WITH(NOLOCK) " +
                                     "WHERE Belongs IN (" + sqlBelongs + ") AND JobForm IN (" + sqlJobForm + ") AND Occupation IN (" + sqlOccupation + ")";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StaffMasterVo hStaffMasterVo = new();
                    hStaffMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffMasterVo.UnionCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["UnionCode"]);
                    hStaffMasterVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["Belongs"]);
                    hStaffMasterVo.VehicleDispatchTarget = _defaultValue.GetDefaultValue<bool>(sqlDataReader["VehicleDispatchTarget"]);
                    hStaffMasterVo.JobForm = _defaultValue.GetDefaultValue<int>(sqlDataReader["JobForm"]);
                    hStaffMasterVo.Occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["Occupation"]);
                    hStaffMasterVo.NameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["NameKana"]);
                    hStaffMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["Name"]);
                    hStaffMasterVo.OtherNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherNameKana"]);
                    hStaffMasterVo.OtherName = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherName"]);
                    hStaffMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStaffMasterVo.EmploymentDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentDate"]);
                    hStaffMasterVo.CurrentAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["CurrentAddress"]);
                    hStaffMasterVo.RetirementFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["RetirementFlag"]);
                    hStaffMasterVo.HealthInsuranceDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["HealthInsuranceDate"]);
                    hStaffMasterVo.HealthInsuranceNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["HealthInsuranceNumber"]);
                    hStaffMasterVo.WelfarePensionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["WelfarePensionDate"]);
                    hStaffMasterVo.EmploymentInsuranceDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentInsuranceDate"]);
                    hStaffMasterVo.WorkerAccidentInsuranceDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["WorkerAccidentInsuranceDate"]);
                    listHStaffMasterVo.Add(hStaffMasterVo);
                }
            }
            return listHStaffMasterVo;
        }

        /// <summary>
        /// SelectOneHStaffMaster
        /// </summary>
        /// <returns>詳細を含むListを返す</returns>
        public H_StaffMasterVo SelectOneHStaffMaster(int staffCode) {
            H_StaffMasterVo hStaffMasterVo = new();
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
                                            "OtherNameKana," +
                                            "OtherName," +
                                            "Gender," +
                                            "BirthDate," +
                                            "EmploymentDate," +
                                            "CurrentAddress," +
                                            "BeforeChangeAddress," +
                                            "Remarks," +
                                            "TelephoneNumber," +
                                            "CellphoneNumber," +
                                            "Picture," +
                                            "BloodType," +
                                            "SelectionDate," +
                                            "NotSelectionDate," +
                                            "NotSelectionReason," +
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
                                     "FROM H_StaffMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hStaffMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStaffMasterVo.UnionCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["UnionCode"]);
                    hStaffMasterVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["Belongs"]);
                    hStaffMasterVo.VehicleDispatchTarget = _defaultValue.GetDefaultValue<bool>(sqlDataReader["VehicleDispatchTarget"]);
                    hStaffMasterVo.JobForm = _defaultValue.GetDefaultValue<int>(sqlDataReader["JobForm"]);
                    hStaffMasterVo.Occupation = _defaultValue.GetDefaultValue<int>(sqlDataReader["Occupation"]);
                    hStaffMasterVo.NameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["NameKana"]);
                    hStaffMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["Name"]);
                    hStaffMasterVo.DisplayName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisplayName"]);
                    hStaffMasterVo.OtherNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherNameKana"]);
                    hStaffMasterVo.OtherName = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherName"]);
                    hStaffMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["Gender"]);
                    hStaffMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStaffMasterVo.EmploymentDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentDate"]);
                    hStaffMasterVo.CurrentAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["CurrentAddress"]);
                    hStaffMasterVo.BeforeChangeAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["BeforeChangeAddress"]);
                    hStaffMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["Remarks"]);
                    hStaffMasterVo.TelephoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["TelephoneNumber"]);
                    hStaffMasterVo.CellphoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CellphoneNumber"]);
                    hStaffMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                    hStaffMasterVo.BloodType = _defaultValue.GetDefaultValue<string>(sqlDataReader["BloodType"]);
                    hStaffMasterVo.SelectionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["SelectionDate"]);
                    hStaffMasterVo.NotSelectionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["NotSelectionDate"]);
                    hStaffMasterVo.NotSelectionReason = _defaultValue.GetDefaultValue<string>(sqlDataReader["NotSelectionReason"]);
                    hStaffMasterVo.HLicenseMasterVo = _hLicenseMasterDao.SelectOneHLicenseMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.ListHStaffHistoryVo = _hStaffHistoryDao.SelectOneHStaffHistoryMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.ListHStaffExperienceVo = _hStaffExperienceDao.SelectOneHStaffExperienceMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.RetirementFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["RetirementFlag"]);
                    hStaffMasterVo.RetirementDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["RetirementDate"]);
                    hStaffMasterVo.RetirementNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["RetirementNote"]);
                    hStaffMasterVo.DeathDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeathDate"]);
                    hStaffMasterVo.DeathNote = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeathNote"]);
                    hStaffMasterVo.ListHStaffFamilyVo = _hStaffFamilyDao.SelectOneHStaffFamilyMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
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
                    hStaffMasterVo.ListHStaffMedicalExaminationVo = _hStaffMedicalExaminationDao.SelectOneHStaffMedicalExaminationMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.ListHStaffCarViolateVo = _hStaffCarViolateDao.SelectOneHStaffCarViolateMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.ListHStaffEducateVo = _hStaffEducateDao.SelectOneHStaffEducateMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.ListHStaffProperVo = _hStaffProperDao.SelectOneHStaffProperMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.ListHStaffPunishmentVo = _hStaffPunishmentDao.SelectOneHStaffPunishmentMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
                    hStaffMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStaffMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStaffMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStaffMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStaffMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStaffMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStaffMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hStaffMasterVo;
        }

        /// <summary>
        /// SelectAllHStaffMaster
        /// Picture無
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
                                            "OtherNameKana," +
                                            "OtherName," +
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
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
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
                    hStaffMasterVo.OtherNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherNameKana"]);
                    hStaffMasterVo.OtherName = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherName"]);
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
                    hStaffMasterVo.HLicenseMasterVo = _hLicenseMasterDao.SelectOneHLicenseMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
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

        /// <summary>
        /// SelectAllHStaffMaster
        /// Picture有
        /// </summary>
        /// <returns></returns>
        public List<H_StaffMasterVo> SelectAllHStaffMasterP() {
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
                                            "OtherNameKana," +
                                            "OtherName," +
                                            "Gender," +
                                            "BirthDate," +
                                            "EmploymentDate," +
                                            "CurrentAddress," +
                                            "BeforeChangeAddress," +
                                            "Remarks," +
                                            "TelephoneNumber," +
                                            "CellphoneNumber," +
                                            "Picture," +
                                            "BloodType," +
                                            "SelectionDate," +
                                            "NotSelectionDate," +
                                            "NotSelectionReason," +
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
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
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
                    hStaffMasterVo.OtherNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherNameKana"]);
                    hStaffMasterVo.OtherName = _defaultValue.GetDefaultValue<string>(sqlDataReader["OtherName"]);
                    hStaffMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["Gender"]);
                    hStaffMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStaffMasterVo.EmploymentDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentDate"]);
                    hStaffMasterVo.CurrentAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["CurrentAddress"]);
                    hStaffMasterVo.BeforeChangeAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["BeforeChangeAddress"]);
                    hStaffMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["Remarks"]);
                    hStaffMasterVo.TelephoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["TelephoneNumber"]);
                    hStaffMasterVo.CellphoneNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CellphoneNumber"]);
                    hStaffMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                    hStaffMasterVo.BloodType = _defaultValue.GetDefaultValue<string>(sqlDataReader["BloodType"]);
                    hStaffMasterVo.SelectionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["SelectionDate"]);
                    hStaffMasterVo.NotSelectionDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["NotSelectionDate"]);
                    hStaffMasterVo.NotSelectionReason = _defaultValue.GetDefaultValue<string>(sqlDataReader["NotSelectionReason"]);
                    hStaffMasterVo.HLicenseMasterVo = _hLicenseMasterDao.SelectOneHLicenseMaster(_defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]));
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

        /// <summary>
        /// InsertOneHStaffMaster
        /// </summary>
        /// <param name="hStaffMasterVo"></param>
        public void InsertOneHStaffMaster(H_StaffMasterVo hStaffMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StaffMaster(StaffCode," +
                                                               "UnionCode," +
                                                               "Belongs," +
                                                               "VehicleDispatchTarget," +
                                                               "JobForm," +
                                                               "Occupation," +
                                                               "NameKana," +
                                                               "Name," +
                                                               "DisplayName," +
                                                               "OtherNameKana," +
                                                               "OtherName," +
                                                               "Gender," +
                                                               "BirthDate," +
                                                               "EmploymentDate," +
                                                               "CurrentAddress," +
                                                               "BeforeChangeAddress," +
                                                               "Remarks," +
                                                               "TelephoneNumber," +
                                                               "CellphoneNumber," +
                                                               "Picture," +
                                                               "BloodType," +
                                                               "SelectionDate," +
                                                               "NotSelectionDate," +
                                                               "NotSelectionReason," +
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
                                                               "DeleteFlag) " +
                                     "VALUES (" + hStaffMasterVo.StaffCode + "," +
                                             "" + hStaffMasterVo.UnionCode + "," +
                                             "" + hStaffMasterVo.Belongs + "," +
                                            "'" + hStaffMasterVo.VehicleDispatchTarget + "'," +
                                             "" + hStaffMasterVo.JobForm + "," +
                                             "" + hStaffMasterVo.Occupation + "," +
                                            "'" + hStaffMasterVo.NameKana + "'," +
                                            "'" + hStaffMasterVo.Name + "'," +
                                            "'" + hStaffMasterVo.DisplayName + "'," +
                                            "'" + hStaffMasterVo.OtherNameKana + "'," +
                                            "'" + hStaffMasterVo.OtherName + "'," +
                                            "'" + hStaffMasterVo.Gender + "'," +
                                            "'" + hStaffMasterVo.BirthDate + "'," +
                                            "'" + hStaffMasterVo.EmploymentDate + "'," +
                                            "'" + hStaffMasterVo.CurrentAddress + "'," +
                                            "'" + hStaffMasterVo.BeforeChangeAddress + "'," +
                                            "'" + hStaffMasterVo.Remarks + "'," +
                                            "'" + hStaffMasterVo.TelephoneNumber + "'," +
                                            "'" + hStaffMasterVo.CellphoneNumber + "'," +
                                            "@member_picture," +
                                            "'" + hStaffMasterVo.BloodType + "'," +
                                            "'" + hStaffMasterVo.SelectionDate + "'," +
                                            "'" + hStaffMasterVo.NotSelectionDate + "'," +
                                            "'" + hStaffMasterVo.NotSelectionReason + "'," +
                                            "'" + hStaffMasterVo.RetirementFlag + "'," +
                                            "'" + hStaffMasterVo.RetirementDate + "'," +
                                            "'" + hStaffMasterVo.RetirementNote + "'," +
                                            "'" + hStaffMasterVo.DeathDate + "'," +
                                            "'" + hStaffMasterVo.DeathNote + "'," +
                                            "'" + hStaffMasterVo.UrgentTelephoneNumber + "'," +
                                            "'" + hStaffMasterVo.UrgentTelephoneMethod + "'," +
                                            "'" + hStaffMasterVo.HealthInsuranceDate + "'," +
                                            "'" + hStaffMasterVo.HealthInsuranceNumber + "'," +
                                            "'" + hStaffMasterVo.HealthInsuranceNote + "'," +
                                            "'" + hStaffMasterVo.WelfarePensionDate + "'," +
                                            "'" + hStaffMasterVo.WelfarePensionNumber + "'," +
                                            "'" + hStaffMasterVo.WelfarePensionNote + "'," +
                                            "'" + hStaffMasterVo.EmploymentInsuranceDate + "'," +
                                            "'" + hStaffMasterVo.EmploymentInsuranceNumber + "'," +
                                            "'" + hStaffMasterVo.EmploymentInsuranceNote + "'," +
                                            "'" + hStaffMasterVo.WorkerAccidentInsuranceDate + "'," +
                                            "'" + hStaffMasterVo.WorkerAccidentInsuranceNumber + "'," +
                                            "'" + hStaffMasterVo.WorkerAccidentInsuranceNote + "'," +
                                            "'" + hStaffMasterVo.InsertPcName + "'," +
                                            "'" + hStaffMasterVo.InsertYmdHms + "'," +
                                            "'" + hStaffMasterVo.UpdatePcName + "'," +
                                            "'" + hStaffMasterVo.UpdateYmdHms + "'," +
                                            "'" + hStaffMasterVo.DeletePcName + "'," +
                                            "'" + hStaffMasterVo.DeleteYmdHms + "'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, hStaffMasterVo.Picture.Length).Value = hStaffMasterVo.Picture;
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHStaffMaster
        /// </summary>
        /// <param name="hStaffMasterVo"></param>
        /// <returns></returns>
        public void UpdateOneHStaffMaster(H_StaffMasterVo hStaffMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_StaffMaster " +
                                     "SET StaffCode = " + hStaffMasterVo.StaffCode + "," +
                                         "UnionCode = " + hStaffMasterVo.UnionCode + "," +
                                         "Belongs = " + hStaffMasterVo.Belongs + "," +
                                         "VehicleDispatchTarget = '" + hStaffMasterVo.VehicleDispatchTarget + "'," +
                                         "JobForm = " + hStaffMasterVo.JobForm + "," +
                                         "Occupation = " + hStaffMasterVo.Occupation + "," +
                                         "NameKana = '" + hStaffMasterVo.NameKana + "'," +
                                         "Name = '" + hStaffMasterVo.Name + "'," +
                                         "DisplayName = '" + hStaffMasterVo.DisplayName + "'," +
                                         "OtherNameKana = '" + hStaffMasterVo.OtherNameKana + "'," +
                                         "OtherName = '" + hStaffMasterVo.OtherName + "'," +
                                         "Gender = '" + hStaffMasterVo.Gender + "'," +
                                         "BirthDate = '" + hStaffMasterVo.BirthDate + "'," +
                                         "EmploymentDate = '" + hStaffMasterVo.EmploymentDate + "'," +
                                         "CurrentAddress = '" + hStaffMasterVo.CurrentAddress + "'," +
                                         "BeforeChangeAddress = '" + hStaffMasterVo.BeforeChangeAddress + "'," +
                                         "Remarks = '" + hStaffMasterVo.Remarks + "'," +
                                         "TelephoneNumber = '" + hStaffMasterVo.TelephoneNumber + "'," +
                                         "CellphoneNumber = '" + hStaffMasterVo.CellphoneNumber + "'," +
                                         "Picture = @member_picture," +
                                         "BloodType = '" + hStaffMasterVo.BloodType + "'," +
                                         "SelectionDate = '" + hStaffMasterVo.SelectionDate + "'," +
                                         "NotSelectionDate = '" + hStaffMasterVo.NotSelectionDate + "'," +
                                         "NotSelectionReason = '" + hStaffMasterVo.NotSelectionReason + "'," +
                                         "RetirementFlag = '" + hStaffMasterVo.RetirementFlag + "'," +
                                         "RetirementDate = '" + hStaffMasterVo.RetirementDate + "'," +
                                         "RetirementNote = '" + hStaffMasterVo.RetirementNote + "'," +
                                         "DeathDate = '" + hStaffMasterVo.DeathDate + "'," +
                                         "DeathNote = '" + hStaffMasterVo.DeathNote + "'," +
                                         "UrgentTelephoneNumber = '" + hStaffMasterVo.UrgentTelephoneNumber + "'," +
                                         "UrgentTelephoneMethod = '" + hStaffMasterVo.UrgentTelephoneMethod + "'," +
                                         "HealthInsuranceDate = '" + hStaffMasterVo.HealthInsuranceDate + "'," +
                                         "HealthInsuranceNumber = '" + hStaffMasterVo.HealthInsuranceNumber + "'," +
                                         "HealthInsuranceNote = '" + hStaffMasterVo.HealthInsuranceNote + "'," +
                                         "WelfarePensionDate = '" + hStaffMasterVo.WelfarePensionDate + "'," +
                                         "WelfarePensionNumber = '" + hStaffMasterVo.WelfarePensionNumber + "'," +
                                         "WelfarePensionNote = '" + hStaffMasterVo.WelfarePensionNote + "'," +
                                         "EmploymentInsuranceDate = '" + hStaffMasterVo.EmploymentInsuranceDate + "'," +
                                         "EmploymentInsuranceNumber = '" + hStaffMasterVo.EmploymentInsuranceNumber + "'," +
                                         "EmploymentInsuranceNote = '" + hStaffMasterVo.EmploymentInsuranceNote + "'," +
                                         "WorkerAccidentInsuranceDate = '" + hStaffMasterVo.WorkerAccidentInsuranceDate + "'," +
                                         "WorkerAccidentInsuranceNumber = '" + hStaffMasterVo.WorkerAccidentInsuranceNumber + "'," +
                                         "WorkerAccidentInsuranceNote = '" + hStaffMasterVo.WorkerAccidentInsuranceNote + "'," +
                                         "UpdatePcName = '" + hStaffMasterVo.UpdatePcName + "'," +
                                         "UpdateYmdHms = '" + hStaffMasterVo.UpdateYmdHms + "' " +
                                     "WHERE StaffCode = " + hStaffMasterVo.StaffCode;
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, hStaffMasterVo.Picture.Length).Value = hStaffMasterVo.Picture;
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
