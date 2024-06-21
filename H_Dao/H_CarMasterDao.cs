/*
 * 2023-11-10
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using Vo;

namespace H_Dao {
    public class H_CarMasterDao {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
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
        /// ExistenceHCarMasterRecord
        /// true:該当レコードあり false:該当レコードなし
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public bool ExistenceHCarMaster(int carCode) {
            int count;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(CarCode) " +
                                     "FROM H_CarMaster " +
                                     "WHERE CarCode = " + carCode;
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// 新規CarCodeを採番
        /// </summary>
        /// <returns>CarCodeの最大値</returns>
        public int GetCarCode() {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT MAX(CarCode) " +
                                     "FROM H_CarMaster";
            try {
                return (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectAllHCarMaster
        /// Picture無
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
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
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

        /// <summary>
        /// SelectOnePicture
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public byte[] SelectOnePicture(int carCode) {
            byte[] byteImage = Array.Empty<byte>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT Picture " +
                                     "FROM H_CarMaster " +
                                     "WHERE CarCode = " + carCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    byteImage = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                }
            }
            return byteImage;
        }

        /// <summary>
        /// SelectOneHCarMaster
        /// Picture有
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public H_CarMasterVo SelectOneHCarMasterP(int carCode) {
            H_CarMasterVo hCarMasterVo = new();
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
                                            "Picture," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_CarMaster " +
                                     "WHERE CarCode = " + carCode + "";
            // "WHERE delete_flag = 'False' " + // 2022-07-08 delete_flagを入れると過去の配車に削除済のCarLabelが反映出来なくなる
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
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
                    hCarMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["Picture"]);
                    hCarMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hCarMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hCarMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hCarMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hCarMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hCarMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hCarMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hCarMasterVo;
        }

        /// <summary>
        /// InsertOneHCarMaster
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        public void InsertOneHCarMaster(H_CarMasterVo hCarMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_CarMaster(CarCode," +
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
                                                             "Picture," +
                                                             "InsertPcName," +
                                                             "InsertYmdHms," +
                                                             "UpdatePcName," +
                                                             "UpdateYmdHms," +
                                                             "DeletePcName," +
                                                             "DeleteYmdHms," +
                                                             "DeleteFlag) " +
                                     "VALUES (" + hCarMasterVo.CarCode + "," +
                                             "" + hCarMasterVo.ClassificationCode + "," +
                                            "'" + hCarMasterVo.RegistrationNumber + "'," +
                                            "'" + hCarMasterVo.RegistrationNumber1 + "'," +
                                            "'" + hCarMasterVo.RegistrationNumber2 + "'," +
                                            "'" + hCarMasterVo.RegistrationNumber3 + "'," +
                                            "'" + hCarMasterVo.RegistrationNumber4 + "'," +
                                             "" + hCarMasterVo.GarageCode + "," +
                                             "" + hCarMasterVo.DoorNumber + "," +
                                            "'" + hCarMasterVo.RegistrationDate + "'," +
                                            "'" + hCarMasterVo.FirstRegistrationDate + "'," +
                                             "" + hCarMasterVo.CarKindCode + "," +
                                            "'" + hCarMasterVo.DisguiseKind1 + "'," +
                                            "'" + hCarMasterVo.DisguiseKind2 + "'," +
                                            "'" + hCarMasterVo.DisguiseKind3 + "'," +
                                            "'" + hCarMasterVo.CarUse + "'," +
                                             "" + hCarMasterVo.OtherCode + "," +
                                             "" + hCarMasterVo.ShapeCode + "," +
                                             "" + hCarMasterVo.ManufacturerCode + "," +
                                             "" + hCarMasterVo.Capacity + "," +
                                             "" + hCarMasterVo.MaximumLoadCapacity + "," +
                                             "" + hCarMasterVo.VehicleWeight + "," +
                                             "" + hCarMasterVo.TotalVehicleWeight + "," +
                                            "'" + hCarMasterVo.VehicleNumber + "'," +
                                             "" + hCarMasterVo.Length + "," +
                                             "" + hCarMasterVo.Width + "," +
                                             "" + hCarMasterVo.Height + "," +
                                             "" + hCarMasterVo.FfAxisWeight + "," +
                                             "" + hCarMasterVo.FrAxisWeight + "," +
                                             "" + hCarMasterVo.RfAxisWeight + "," +
                                             "" + hCarMasterVo.RrAxisWeight + "," +
                                            "'" + hCarMasterVo.Version + "'," +
                                            "'" + hCarMasterVo.MotorVersion + "'," +
                                             "" + hCarMasterVo.TotalDisplacement + "," +
                                            "'" + hCarMasterVo.TypesOfFuel + "'," +
                                            "'" + hCarMasterVo.VersionDesignateNumber + "'," +
                                            "'" + hCarMasterVo.CategoryDistinguishNumber + "'," +
                                            "'" + hCarMasterVo.OwnerName + "'," +
                                            "'" + hCarMasterVo.OwnerAddress + "'," +
                                            "'" + hCarMasterVo.UserName + "'," +
                                            "'" + hCarMasterVo.UserAddress + "'," +
                                            "'" + hCarMasterVo.BaseAddress + "'," +
                                            "'" + hCarMasterVo.ExpirationDate + "'," +
                                            "'" + hCarMasterVo.Remarks + "'," +
                                            "@member_picture," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                             "'false'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, hCarMasterVo.Picture.Length).Value = hCarMasterVo.Picture;
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHStaffMaster
        /// </summary>
        /// <param name="hCarMasterVo"></param>
        /// <returns></returns>
        public void UpdateOneHCarMaster(H_CarMasterVo hCarMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_CarMaster " +
                                     "SET CarCode = " + hCarMasterVo.CarCode + "," +
                                         "ClassificationCode = " + hCarMasterVo.ClassificationCode + "," +
                                         "RegistrationNumber = '" + hCarMasterVo.RegistrationNumber + "'," +
                                         "RegistrationNumber1 = '" + hCarMasterVo.RegistrationNumber1 + "'," +
                                         "RegistrationNumber2 = '" + hCarMasterVo.RegistrationNumber2 + "'," +
                                         "RegistrationNumber3 = '" + hCarMasterVo.RegistrationNumber3 + "'," +
                                         "RegistrationNumber4 = '" + hCarMasterVo.RegistrationNumber4 + "'," +
                                         "GarageCode = " + hCarMasterVo.GarageCode + "," +
                                         "DoorNumber = " + hCarMasterVo.DoorNumber + "," +
                                         "RegistrationDate = '" + hCarMasterVo.RegistrationDate + "'," +
                                         "FirstRegistrationDate = '" + hCarMasterVo.FirstRegistrationDate + "'," +
                                         "CarKindCode = " + hCarMasterVo.CarKindCode + "," +
                                         "DisguiseKind1 = '" + hCarMasterVo.DisguiseKind1 + "'," +
                                         "DisguiseKind2 = '" + hCarMasterVo.DisguiseKind2 + "'," +
                                         "DisguiseKind3 = '" + hCarMasterVo.DisguiseKind3 + "'," +
                                         "CarUse = '" + hCarMasterVo.CarUse + "'," +
                                         "OtherCode = " + hCarMasterVo.OtherCode + "," +
                                         "ShapeCode = " + hCarMasterVo.ShapeCode + "," +
                                         "ManufacturerCode = " + hCarMasterVo.ManufacturerCode + "," +
                                         "Capacity = " + hCarMasterVo.Capacity + "," +
                                         "MaximumLoadCapacity = " + hCarMasterVo.MaximumLoadCapacity + "," +
                                         "VehicleWeight = " + hCarMasterVo.VehicleWeight + "," +
                                         "TotalVehicleWeight = " + hCarMasterVo.TotalVehicleWeight + "," +
                                         "VehicleNumber = '" + hCarMasterVo.VehicleNumber + "'," +
                                         "Length = " + hCarMasterVo.Length + "," +
                                         "Width = " + hCarMasterVo.Width + "," +
                                         "Height = " + hCarMasterVo.Height + "," +
                                         "FfAxisWeight = " + hCarMasterVo.FfAxisWeight + "," +
                                         "FrAxisWeight = " + hCarMasterVo.FrAxisWeight + "," +
                                         "RfAxisWeight = " + hCarMasterVo.RfAxisWeight + "," +
                                         "RrAxisWeight = " + hCarMasterVo.RrAxisWeight + "," +
                                         "Version = '" + hCarMasterVo.Version + "'," +
                                         "MotorVersion = '" + hCarMasterVo.MotorVersion + "'," +
                                         "TotalDisplacement = " + hCarMasterVo.TotalDisplacement + "," +
                                         "TypesOfFuel = '" + hCarMasterVo.TypesOfFuel + "'," +
                                         "VersionDesignateNumber = '" + hCarMasterVo.VersionDesignateNumber + "'," +
                                         "CategoryDistinguishNumber = '" + hCarMasterVo.CategoryDistinguishNumber + "'," +
                                         "OwnerName = '" + hCarMasterVo.OwnerName + "'," +
                                         "OwnerAddress = '" + hCarMasterVo.OwnerAddress + "'," +
                                         "UserName = '" + hCarMasterVo.UserName + "'," +
                                         "UserAddress = '" + hCarMasterVo.UserAddress + "'," +
                                         "BaseAddress = '" + hCarMasterVo.BaseAddress + "'," +
                                         "ExpirationDate = '" + hCarMasterVo.ExpirationDate + "'," +
                                         "Remarks = '" + hCarMasterVo.Remarks + "'," +
                                         "Picture = @member_picture," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CarCode = " + hCarMasterVo.CarCode;
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, hCarMasterVo.Picture.Length).Value = hCarMasterVo.Picture;
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteOneHCarMaster
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public int DeleteOneHCarMaster(int carCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_CarMaster " +
                                     "SET DeletePcName = '" + Environment.MachineName + "'," +
                                         "DeleteYmdHms = '" + DateTime.Now + "'," +
                                         "DeleteFlag = 'True' " +
                                     "WHERE CarCode = " + carCode + " " +
                                       "AND DeleteFlag = 'False'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
