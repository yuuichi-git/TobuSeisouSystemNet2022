/*
 * 2024-03-01
 * 主に旧テーブルを新テーブルに変換するためのクラス
 */
using Dao;

using H_Vo;

using Vo;

namespace H_Dao {
    public class ConvertTableDao {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public ConvertTableDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ConvertHCarMaster
        /// car_masterをH_CarMasterに変換する
        /// </summary>
        public void ConvertHCarMaster() {
            CarMasterDao carMasterDao = new(_connectionVo);
            H_CarMasterDao hCarMasterDao = new(_connectionVo);
            foreach (CarMasterVo carMasterVo in carMasterDao.SelectAllCarMasterP()) {
                H_CarMasterVo hCarMasterVo = new();
                hCarMasterVo.CarCode = carMasterVo.Car_code;
                hCarMasterVo.ClassificationCode = carMasterVo.Classification_code;
                hCarMasterVo.RegistrationNumber = carMasterVo.Registration_number;
                hCarMasterVo.RegistrationNumber1 = carMasterVo.Registration_number_1;
                hCarMasterVo.RegistrationNumber2 = carMasterVo.Registration_number_2;
                hCarMasterVo.RegistrationNumber3 = carMasterVo.Registration_number_3;
                hCarMasterVo.RegistrationNumber4 = carMasterVo.Registration_number_4;
                hCarMasterVo.GarageCode = carMasterVo.Garage_flag ? 1 : 2;
                hCarMasterVo.DoorNumber = carMasterVo.Door_number;
                hCarMasterVo.RegistrationDate = carMasterVo.Registration_date;
                hCarMasterVo.FirstRegistrationDate = carMasterVo.First_registration_date;
                hCarMasterVo.CarKindCode = carMasterVo.Car_kind_code;
                hCarMasterVo.DisguiseKind1 = carMasterVo.Disguise_kind_1;
                hCarMasterVo.DisguiseKind2 = carMasterVo.Disguise_kind_2;
                hCarMasterVo.DisguiseKind3 = carMasterVo.Disguise_kind_3;
                hCarMasterVo.CarUse = carMasterVo.Car_use;
                hCarMasterVo.OtherCode = carMasterVo.Other_code;
                hCarMasterVo.ShapeCode = carMasterVo.Shape_code;
                hCarMasterVo.ManufacturerCode = carMasterVo.Manufacturer_code;
                hCarMasterVo.Capacity = carMasterVo.Capacity;
                hCarMasterVo.MaximumLoadCapacity = carMasterVo.Maximum_load_capacity;
                hCarMasterVo.VehicleWeight = carMasterVo.Vehicle_weight;
                hCarMasterVo.TotalVehicleWeight = carMasterVo.Total_vehicle_weight;
                hCarMasterVo.VehicleNumber = carMasterVo.Vehicle_number;
                hCarMasterVo.Length = carMasterVo.Length;
                hCarMasterVo.Width = carMasterVo.Width;
                hCarMasterVo.Height = carMasterVo.Height;
                hCarMasterVo.FfAxisWeight = carMasterVo.Ff_axis_weight;
                hCarMasterVo.FrAxisWeight = carMasterVo.Fr_axis_weight;
                hCarMasterVo.RfAxisWeight = carMasterVo.Rf_axis_weight;
                hCarMasterVo.RrAxisWeight = carMasterVo.Rr_axis_weight;
                hCarMasterVo.Version = carMasterVo.Version;
                hCarMasterVo.MotorVersion = carMasterVo.Motor_version;
                hCarMasterVo.TotalDisplacement = carMasterVo.Total_displacement;
                hCarMasterVo.TypesOfFuel = carMasterVo.Types_of_fuel;
                hCarMasterVo.VersionDesignateNumber = carMasterVo.Version_designate_number;
                hCarMasterVo.CategoryDistinguishNumber = carMasterVo.Category_distinguish_number;
                hCarMasterVo.OwnerName = carMasterVo.Owner_name;
                hCarMasterVo.OwnerAddress = carMasterVo.Owner_address;
                hCarMasterVo.UserName = carMasterVo.User_name;
                hCarMasterVo.UserAddress = carMasterVo.User_address;
                hCarMasterVo.BaseAddress = carMasterVo.Base_address;
                hCarMasterVo.ExpirationDate = carMasterVo.Expiration_date;
                hCarMasterVo.Remarks = carMasterVo.Remarks;
                hCarMasterVo.SubPicture = carMasterVo.Picture;
                hCarMasterVo.InsertPcName = Environment.MachineName;
                hCarMasterVo.InsertYmdHms = carMasterVo.Insert_ymd_hms;
                hCarMasterVo.UpdatePcName = Environment.MachineName;
                hCarMasterVo.UpdateYmdHms = carMasterVo.Update_ymd_hms;
                hCarMasterVo.DeletePcName = string.Empty;
                hCarMasterVo.DeleteYmdHms = carMasterVo.Delete_ymd_hms;
                hCarMasterVo.DeleteFlag = carMasterVo.Delete_flag;
                /*
                 * DB更新
                 * INSERT　UPDATE
                 */
                if (hCarMasterDao.ExistenceHCarMaster(hCarMasterVo.CarCode)) {
                    try {
                        hCarMasterDao.UpdateOneHCarMaster(hCarMasterVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                } else {
                    try {
                        hCarMasterDao.InsertOneHCarMaster(hCarMasterVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ConvertHStaffMaster
        /// staff_masterをH_StaffMasterに変換する
        /// </summary>
        public void ConvertHStaffMaster() {
            StaffMasterDao staffMasterDao = new(_connectionVo);
            H_StaffMasterDao hStaffMasterDao = new(_connectionVo);
            foreach (StaffMasterVo staffMasterVo in staffMasterDao.SelectAllStaffMasterP()) {
                H_StaffMasterVo hStaffMasterVo = new();
                hStaffMasterVo.StaffCode = staffMasterVo.Staff_code;
                hStaffMasterVo.UnionCode = staffMasterVo.Code;
                hStaffMasterVo.Belongs = staffMasterVo.Belongs;
                hStaffMasterVo.VehicleDispatchTarget = staffMasterVo.Vehicle_dispatch_target;
                hStaffMasterVo.JobForm = staffMasterVo.Job_form;
                hStaffMasterVo.Occupation = staffMasterVo.Occupation;
                hStaffMasterVo.NameKana = staffMasterVo.Name_kana;
                hStaffMasterVo.Name = staffMasterVo.Name;
                hStaffMasterVo.DisplayName = staffMasterVo.Display_name;
                hStaffMasterVo.OtherNameKana = string.Empty;
                hStaffMasterVo.OtherName = string.Empty;
                hStaffMasterVo.Gender = staffMasterVo.Gender;
                hStaffMasterVo.BirthDate = staffMasterVo.Birth_date;
                hStaffMasterVo.EmploymentDate = staffMasterVo.Employment_date;
                hStaffMasterVo.CurrentAddress = staffMasterVo.Current_address;
                hStaffMasterVo.BeforeChangeAddress = staffMasterVo.Before_change_address;
                hStaffMasterVo.Remarks = string.Empty;
                hStaffMasterVo.TelephoneNumber = staffMasterVo.Telephone_number;
                hStaffMasterVo.CellphoneNumber = staffMasterVo.Cellphone_number;
                hStaffMasterVo.Picture = staffMasterVo.Picture;
                hStaffMasterVo.BloodType = staffMasterVo.Blood_type;
                hStaffMasterVo.SelectionDate = staffMasterVo.Selection_date;
                hStaffMasterVo.NotSelectionDate = staffMasterVo.Not_selection_date;
                hStaffMasterVo.NotSelectionReason = staffMasterVo.Not_selection_reason;
                //private H_LicenseMasterVo _hLicenseMasterVo;
                //private List<H_StaffHistoryVo> _listHStaffHistoryVo;
                //private List<H_StaffExperienceVo> _listHStaffExperienceVo;
                hStaffMasterVo.RetirementFlag = staffMasterVo.Retirement_flag;
                hStaffMasterVo.RetirementDate = staffMasterVo.Retirement_date;
                hStaffMasterVo.RetirementNote = staffMasterVo.Retirement_note;
                hStaffMasterVo.DeathDate = staffMasterVo.Death_date;
                hStaffMasterVo.DeathNote = staffMasterVo.Death_note;
                //private List<H_StaffFamilyVo> _listHStaffFamilyVo;
                hStaffMasterVo.UrgentTelephoneNumber = staffMasterVo.Urgent_telephone_number;
                hStaffMasterVo.UrgentTelephoneMethod = staffMasterVo.Urgent_telephone_method;
                hStaffMasterVo.HealthInsuranceDate = staffMasterVo.Health_insurance_date;
                hStaffMasterVo.HealthInsuranceNumber = staffMasterVo.Health_insurance_number;
                hStaffMasterVo.HealthInsuranceNote = staffMasterVo.Health_insurance_note;
                hStaffMasterVo.WelfarePensionDate = staffMasterVo.Welfare_pension_date;
                hStaffMasterVo.WelfarePensionNumber = staffMasterVo.Welfare_pension_number;
                hStaffMasterVo.WelfarePensionNote = staffMasterVo.Welfare_pension_note;
                hStaffMasterVo.EmploymentInsuranceDate = staffMasterVo.Employment_insurance_date;
                hStaffMasterVo.EmploymentInsuranceNumber = staffMasterVo.Employment_insurance_number;
                hStaffMasterVo.EmploymentInsuranceNote = staffMasterVo.Employment_insurance_note;
                hStaffMasterVo.WorkerAccidentInsuranceDate = staffMasterVo.Worker_accident_insurance_date;
                hStaffMasterVo.WorkerAccidentInsuranceNumber = staffMasterVo.Worker_accident_insurance_number;
                hStaffMasterVo.WorkerAccidentInsuranceNote = staffMasterVo.Worker_accident_insurance_note;
                //private List<H_StaffMedicalExaminationVo> _listHStaffMedicalExaminationVo;
                //private List<H_StaffCarViolateVo> _listHStaffCarViolateVo;
                //private List<H_StaffEducateVo> _listHStaffEducateVo;
                //private List<H_StaffProperVo> _listHStaffProperVo;
                //private List<H_StaffPunishmentVo> _listHStaffPunishmentVo;
                hStaffMasterVo.InsertPcName = Environment.MachineName;
                hStaffMasterVo.InsertYmdHms = staffMasterVo.Insert_ymd_hms;
                hStaffMasterVo.UpdatePcName = Environment.MachineName;
                hStaffMasterVo.UpdateYmdHms = staffMasterVo.Update_ymd_hms;
                hStaffMasterVo.DeletePcName = string.Empty;
                hStaffMasterVo.DeleteYmdHms = staffMasterVo.Delete_ymd_hms;
                hStaffMasterVo.DeleteFlag = staffMasterVo.Delete_flag;
                /*
                 * DB更新
                 * INSERT　UPDATE
                 */
                if (hStaffMasterDao.ExistenceHStaffMaster(hStaffMasterVo.StaffCode)) {
                    try {
                        hStaffMasterDao.UpdateOneHStaffMaster(hStaffMasterVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                } else {
                    try {
                        hStaffMasterDao.InsertOneHStaffMaster(hStaffMasterVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        /// <summary>
        /// CreateHVehicleDispatchBody
        /// 新規年度のHVehicleDispatchBodyを初期化
        /// 2024-03-03の時点では、下記コード内の年度は手書きだよ
        /// </summary>
        public void CreateHVehicleDispatchBody() {
            H_VehicleDispatchHeadDao hVehicleDispatchHeadDao = new(_connectionVo);
            H_VehicleDispatchBodyDao hVehicleDispatchBodyDao = new(_connectionVo);
            Dictionary<int, string> dictionaryWeekOfDay = new Dictionary<int, string> { { 0, "日" }, { 1, "月" }, { 2, "火" }, { 3, "水" }, { 4, "木" }, { 5, "金" }, { 6, "土" } };
            foreach (H_VehicleDispatchHeadVo hVehicleDispatchHeadVo in hVehicleDispatchHeadDao.SelectAllHVehicleDispatchHeadVo(2024).FindAll(x => x.VehicleDispatchFlag && x.SetCode > 0)) {
                /*
                 * 配車されていない
                 */
                for (int i = 0; i <= 6; i++) {
                    H_VehicleDispatchBodyVo hVehicleDispatchBodyVo = new();
                    hVehicleDispatchBodyVo.SetCode = hVehicleDispatchHeadVo.SetCode;
                    hVehicleDispatchBodyVo.DayOfWeek = dictionaryWeekOfDay[i];
                    hVehicleDispatchBodyVo.CarCode = 0;
                    hVehicleDispatchBodyVo.StaffCode1 = 0;
                    hVehicleDispatchBodyVo.StaffCode2 = 0;
                    hVehicleDispatchBodyVo.StaffCode3 = 0;
                    hVehicleDispatchBodyVo.StaffCode4 = 0;
                    hVehicleDispatchBodyVo.FinancialYear = 2024;
                    hVehicleDispatchBodyVo.InsertPcName = Environment.MachineName;
                    hVehicleDispatchBodyVo.InsertYmdHms = DateTime.Now;
                    hVehicleDispatchBodyVo.UpdatePcName = string.Empty;
                    hVehicleDispatchBodyVo.UpdateYmdHms = _defaultDateTime;
                    hVehicleDispatchBodyVo.DeletePcName = string.Empty;
                    hVehicleDispatchBodyVo.DeleteYmdHms = _defaultDateTime;
                    hVehicleDispatchBodyVo.DeleteFlag = false;
                    try {
                        hVehicleDispatchBodyDao.InsertOneHVehicleDispatchBodyVo(hVehicleDispatchBodyVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ConvertHCollectionWeightTaitou
        /// collection_weight_taitouをH_CollectionWeightTaitouに変換する
        /// </summary>
        public void ConvertHCollectionWeightTaitou() {
            CollectionWeightTaitouDao collectionWeightTaitouDao = new(_connectionVo);
            H_CollectionWeightTaitouDao hCollectionWeightTaitouDao = new(_connectionVo);
            foreach (CollectionWeightTaitouVo collectionWeightTaitouVo in collectionWeightTaitouDao.SelectAllListCollectionWeightTaitou()) {
                H_CollectionWeightTaitouVo hCollectionWeightTaitouVo = new();
                hCollectionWeightTaitouVo.OperationDate = collectionWeightTaitouVo.Operation_date;
                hCollectionWeightTaitouVo.Weight1Total = collectionWeightTaitouVo.Weight1Total;
                hCollectionWeightTaitouVo.Weight2Total = collectionWeightTaitouVo.Weight2Total;
                hCollectionWeightTaitouVo.Weight3Total = collectionWeightTaitouVo.Weight3Total;
                hCollectionWeightTaitouVo.Weight4Total = collectionWeightTaitouVo.Weight4Total;
                hCollectionWeightTaitouVo.Weight5Total = collectionWeightTaitouVo.Weight5Total;
                hCollectionWeightTaitouVo.Weight6Total = collectionWeightTaitouVo.Weight6Total;
                hCollectionWeightTaitouVo.Weight7Total = collectionWeightTaitouVo.Weight7Total;
                hCollectionWeightTaitouVo.InsertPcName = collectionWeightTaitouVo.Insert_pc_name;
                hCollectionWeightTaitouVo.InsertYmdHms = collectionWeightTaitouVo.Insert_ymd_hms;
                hCollectionWeightTaitouVo.UpdatePcName = collectionWeightTaitouVo.Update_pc_name;
                hCollectionWeightTaitouVo.UpdateYmdHms = collectionWeightTaitouVo.Update_ymd_hms;
                hCollectionWeightTaitouVo.DeletePcName = collectionWeightTaitouVo.Delete_pc_name;
                hCollectionWeightTaitouVo.DeleteYmdHms = collectionWeightTaitouVo.Delete_ymd_hms;
                hCollectionWeightTaitouVo.DeleteFlag = collectionWeightTaitouVo.Delete_flag;
                /*
                 * DB更新
                 * INSERT　UPDATE
                 */
                if (hCollectionWeightTaitouDao.ExistenceCollectionWeightTaitou(collectionWeightTaitouVo.Operation_date)) {
                    try {
                        hCollectionWeightTaitouDao.UpdateOneCollectionWeightTaitou(hCollectionWeightTaitouVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                } else {
                    try {
                        hCollectionWeightTaitouDao.InsertOneCollectionWeightTaitou(hCollectionWeightTaitouVo);
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                }

            }
        }
    }
}