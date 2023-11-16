/*
 * 2023-11-10
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_CarMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_CarMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;

        }

        /// <summary>
        /// SelectAllHCarMaster
        /// </summary>
        /// <returns></returns>
        public List<H_CarMasterVo> SelectAllHCarMaster() {
            List<H_CarMasterVo> listHCarMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT CarCode," +
                                            "ClassificationCode," +
                                            "RegistrationNumber," +
                                            "RegistrationNumber1," +
                                            "RegistrationNumber2," +
                                            "RegistrationNumber3," +
                                            "RegistrationNumber4," +
                                            "GarageCode," +
                                            "DoorNumber," +
                                            "RegistrationDate," +
                                            "FirstRegistrationDate," +
                                            "CarKindCode," +
                                            "DisguiseKind1," +
                                            "DisguiseKind2," +
                                            "DisguiseKind3," +
                                            "CarUse," +
                                            "OtherCode," +
                                            "ShapeCode," +
                                            "ManufacturerCode," +
                                            "Capacity," +
                                            "MaximumLoadCapacity," +
                                            "VehicleWeight," +
                                            "TotalVehicleWeight," +
                                            "VehicleNumber," +
                                            "Length," +
                                            "Width," +
                                            "Height," +
                                            "FfAxisWeight," +
                                            "FrAxisWeight," +
                                            "RfAxisWeight," +
                                            "RrAxisWeight," +
                                            "Version," +
                                            "MotorVersion," +
                                            "TotalDisplacement," +
                                            "TypesOfFuel," +
                                            "VersionDesignateNumber," +
                                            "CategoryDistinguishNumber," +
                                            "OwnerName," +
                                            "OwnerAddress," +
                                            "UserName," +
                                            "UserAddress," +
                                            "BaseAddress," +
                                            "ExpirationDate," +
                                            "Remarks," +
                                            //"Picture," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CarMaster";
            // "WHERE delete_flag = 'False' " + // 2022-07-08 delete_flagを入れると過去の配車に削除済のCarLabelが反映出来なくなる
            using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    H_CarMasterVo hCarMasterVo = new();
                    hCarMasterVo.CarCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarCode"]);
                    hCarMasterVo.ClassificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ClassificationCode"]);
                    hCarMasterVo.RegistrationNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["RegistrationNumber"]);
                    hCarMasterVo.RegistrationNumber1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RegistrationNumber1"]);
                    hCarMasterVo.RegistrationNumber2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RegistrationNumber2"]);
                    hCarMasterVo.RegistrationNumber3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RegistrationNumber3"]);
                    hCarMasterVo.RegistrationNumber4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["RegistrationNumber4"]);
                    hCarMasterVo.GarageCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["GarageCode"]);
                    hCarMasterVo.DoorNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["DoorNumber"]);
                    hCarMasterVo.RegistrationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["RegistrationDate"]);
                    hCarMasterVo.FirstRegistrationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["FirstRegistrationDate"]);
                    hCarMasterVo.CarKindCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarKindCode"]);
                    hCarMasterVo.DisguiseKind1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisguiseKind1"]);
                    hCarMasterVo.DisguiseKind2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisguiseKind2"]);
                    hCarMasterVo.DisguiseKind3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["DisguiseKind3"]);
                    hCarMasterVo.CarUse = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarUse"]);
                    hCarMasterVo.OtherCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["OtherCode"]);
                    hCarMasterVo.ShapeCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ShapeCode"]);
                    hCarMasterVo.ManufacturerCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ManufacturerCode"]);
                    hCarMasterVo.Capacity = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["Capacity"]);
                    hCarMasterVo.MaximumLoadCapacity = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["MaximumLoadCapacity"]);
                    hCarMasterVo.VehicleWeight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["VehicleWeight"]);
                    hCarMasterVo.TotalVehicleWeight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["TotalVehicleWeight"]);
                    hCarMasterVo.VehicleNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["VehicleNumber"]);
                    hCarMasterVo.Length = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["Length"]);
                    hCarMasterVo.Width = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["Width"]);
                    hCarMasterVo.Height = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["Height"]);
                    hCarMasterVo.FfAxisWeight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["FfAxisWeight"]);
                    hCarMasterVo.FrAxisWeight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["FrAxisWeight"]);
                    hCarMasterVo.RfAxisWeight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["RfAxisWeight"]);
                    hCarMasterVo.RrAxisWeight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["RrAxisWeight"]);
                    hCarMasterVo.Version = _defaultValue.GetDefaultValue<string>(sqlDataReader["Version"]);
                    hCarMasterVo.MotorVersion = _defaultValue.GetDefaultValue<string>(sqlDataReader["MotorVersion"]);
                    hCarMasterVo.TotalDisplacement = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["TotalDisplacement"]);
                    hCarMasterVo.TypesOfFuel = _defaultValue.GetDefaultValue<string>(sqlDataReader["TypesOfFuel"]);
                    hCarMasterVo.VersionDesignateNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["VersionDesignateNumber"]);
                    hCarMasterVo.CategoryDistinguishNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["CategoryDistinguishNumber"]);
                    hCarMasterVo.OwnerName = _defaultValue.GetDefaultValue<string>(sqlDataReader["OwnerName"]);
                    hCarMasterVo.OwnerAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["OwnerAddress"]);
                    hCarMasterVo.UserName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UserName"]);
                    hCarMasterVo.UserAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["UserAddress"]);
                    hCarMasterVo.BaseAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["BaseAddress"]);
                    hCarMasterVo.ExpirationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["ExpirationDate"]);
                    hCarMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["Remarks"]);
                    //hCarMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                    hCarMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hCarMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCarMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCarMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCarMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCarMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCarMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHCarMasterVo.Add(hCarMasterVo);
                }
            }
            return listHCarMasterVo;
        }
    }
}
