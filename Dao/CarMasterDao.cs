using System.Data;

using Common;

using Vo;

namespace Dao {
    public class CarMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01, 00, 00, 00, 000);

        public CarMasterDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOneCarMaster
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public CarMasterVo SelectOneCarMaster(int carCode) {
            var carMasterVo = new CarMasterVo();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT car_master.car_code," +
                                            "car_master.classification_code," +
                                            "classification_master.name AS classification_name," + // 外部結合で取得
                                            "car_master.registration_number," +
                                            "car_master.registration_number_1," +
                                            "car_master.registration_number_2," +
                                            "car_master.registration_number_3," +
                                            "car_master.registration_number_4," +
                                            "car_master.garage_flag," +
                                            "car_master.door_number," +
                                            "car_master.registration_date," +
                                            "car_master.first_registration_date," +
                                            "car_master.car_kind_code," +
                                            "car_kind_master.name AS car_kind_name," + // 外部結合で取得
                                            "car_master.disguise_kind_1," +
                                            "car_master.disguise_kind_2," +
                                            "car_master.disguise_kind_3," +
                                            "car_master.car_use," +
                                            "car_master.other_code," +
                                            "car_master.other_name," +
                                            "car_master.shape_code," +
                                            "car_shape_master.name AS shape_name," + // 外部結合で取得
                                            "car_master.manufacturer_code," +
                                            "car_manufacturer_master.name AS manufacturer_name," + // 外部結合で取得
                                            "car_master.capacity," +
                                            "car_master.maximum_load_capacity," +
                                            "car_master.vehicle_weight," +
                                            "car_master.total_vehicle_weight," +
                                            "car_master.vehicle_number," +
                                            "car_master.length," +
                                            "car_master.width," +
                                            "car_master.height," +
                                            "car_master.ff_axis_weight," +
                                            "car_master.fr_axis_weight," +
                                            "car_master.rf_axis_weight," +
                                            "car_master.rr_axis_weight," +
                                            "car_master.version," +
                                            "car_master.motor_version," +
                                            "car_master.total_displacement," +
                                            "car_master.types_of_fuel," +
                                            "car_master.version_designate_number," +
                                            "car_master.category_distinguish_number," +
                                            "car_master.owner_name," +
                                            "car_master.owner_address," +
                                            "car_master.user_name," +
                                            "car_master.user_address," +
                                            "car_master.base_address," +
                                            "car_master.expiration_date," +
                                            "car_master.remarks," +
                                            "car_master.picture," +
                                            "car_master.insert_ymd_hms," +
                                            "car_master.update_ymd_hms," +
                                            "car_master.delete_ymd_hms," +
                                            "car_master.delete_flag " +
                                     "FROM car_master " +
                                     "LEFT OUTER JOIN car_kind_master ON car_master.car_kind_code = car_kind_master.code " +
                                     "LEFT OUTER JOIN car_shape_master ON car_master.shape_code = car_shape_master.code " +
                                     "LEFT OUTER JOIN car_manufacturer_master ON car_master.manufacturer_code = car_manufacturer_master.code " +
                                     "LEFT OUTER JOIN classification_master ON car_master.classification_code = classification_master.code " +
                                     "WHERE car_code = " + carCode;
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    carMasterVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    carMasterVo.Classification_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["classification_code"]);
                    carMasterVo.Classification_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["classification_name"]); // 外部結合で取得
                    carMasterVo.Registration_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number"]);
                    carMasterVo.Registration_number_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_1"]);
                    carMasterVo.Registration_number_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_2"]);
                    carMasterVo.Registration_number_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_3"]);
                    carMasterVo.Registration_number_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_4"]);
                    carMasterVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    carMasterVo.Door_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["door_number"]);
                    carMasterVo.Registration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["registration_date"]);
                    carMasterVo.First_registration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["first_registration_date"]);
                    carMasterVo.Car_kind_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_kind_code"]);
                    carMasterVo.Car_kind_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_kind_name"]); // 外部結合で取得
                    carMasterVo.Disguise_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["disguise_kind_1"]);
                    carMasterVo.Disguise_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["disguise_kind_2"]);
                    carMasterVo.Disguise_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["disguise_kind_3"]);
                    carMasterVo.Car_use = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_use"]);
                    carMasterVo.Other_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["other_code"]);
                    carMasterVo.Other_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["other_name"]);
                    carMasterVo.Shape_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["shape_code"]);
                    carMasterVo.Shape_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["shape_name"]); // 外部結合で取得
                    carMasterVo.Manufacturer_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["manufacturer_code"]);
                    carMasterVo.Manufacturer_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["manufacturer_name"]); // 外部結合で取得
                    carMasterVo.Capacity = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["capacity"]);
                    carMasterVo.Maximum_load_capacity = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["maximum_load_capacity"]);
                    carMasterVo.Vehicle_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["vehicle_weight"]);
                    carMasterVo.Total_vehicle_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["total_vehicle_weight"]);
                    carMasterVo.Vehicle_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["vehicle_number"]);
                    carMasterVo.Length = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["length"]);
                    carMasterVo.Width = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["width"]);
                    carMasterVo.Height = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["height"]);
                    carMasterVo.Ff_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["ff_axis_weight"]);
                    carMasterVo.Fr_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["fr_axis_weight"]);
                    carMasterVo.Rf_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["rf_axis_weight"]);
                    carMasterVo.Rr_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["rr_axis_weight"]);
                    carMasterVo.Version = _defaultValue.GetDefaultValue<string>(sqlDataReader["version"]);
                    carMasterVo.Motor_version = _defaultValue.GetDefaultValue<string>(sqlDataReader["motor_version"]);
                    carMasterVo.Total_displacement = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["total_displacement"]);
                    carMasterVo.Types_of_fuel = _defaultValue.GetDefaultValue<string>(sqlDataReader["types_of_fuel"]);
                    carMasterVo.Version_designate_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["version_designate_number"]);
                    carMasterVo.Category_distinguish_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["category_distinguish_number"]);
                    carMasterVo.Owner_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["owner_name"]);
                    carMasterVo.Owner_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["owner_address"]);
                    carMasterVo.User_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["user_name"]);
                    carMasterVo.User_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["user_address"]);
                    carMasterVo.Base_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["base_address"]);
                    carMasterVo.Expiration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["expiration_date"]);
                    carMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["remarks"]);
                    carMasterVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture"]);
                    carMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    carMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    carMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    carMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
            }
            return carMasterVo;
        }

        /// <summary>
        /// SelectAllCarMaster
        /// </summary>
        /// <returns></returns>
        public List<CarMasterVo> SelectAllCarMaster() {
            var listCarMasterVo = new List<CarMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT car_master.car_code," +
                                            "car_master.classification_code," +
                                            "classification_master.name AS classification_name," + // 外部結合で取得
                                            "car_master.registration_number," +
                                            "car_master.registration_number_1," +
                                            "car_master.registration_number_2," +
                                            "car_master.registration_number_3," +
                                            "car_master.registration_number_4," +
                                            "car_master.garage_flag," +
                                            "car_master.door_number," +
                                            "car_master.registration_date," +
                                            "car_master.first_registration_date," +
                                            "car_master.car_kind_code," +
                                            "car_kind_master.name AS car_kind_name," + // 外部結合で取得
                                            "car_master.disguise_kind_1," +
                                            "car_master.disguise_kind_2," +
                                            "car_master.disguise_kind_3," +
                                            "car_master.car_use," +
                                            "car_master.other_code," +
                                            "car_master.other_name," +
                                            "car_master.shape_code," +
                                            "car_shape_master.name AS shape_name," + // 外部結合で取得
                                            "car_master.manufacturer_code," +
                                            "car_manufacturer_master.name AS manufacturer_name," + // 外部結合で取得
                                            "car_master.capacity," +
                                            "car_master.maximum_load_capacity," +
                                            "car_master.vehicle_weight," +
                                            "car_master.total_vehicle_weight," +
                                            "car_master.vehicle_number," +
                                            "car_master.length," +
                                            "car_master.width," +
                                            "car_master.height," +
                                            "car_master.ff_axis_weight," +
                                            "car_master.fr_axis_weight," +
                                            "car_master.rf_axis_weight," +
                                            "car_master.rr_axis_weight," +
                                            "car_master.version," +
                                            "car_master.motor_version," +
                                            "car_master.total_displacement," +
                                            "car_master.types_of_fuel," +
                                            "car_master.version_designate_number," +
                                            "car_master.category_distinguish_number," +
                                            "car_master.owner_name," +
                                            "car_master.owner_address," +
                                            "car_master.user_name," +
                                            "car_master.user_address," +
                                            "car_master.base_address," +
                                            "car_master.expiration_date," +
                                            "car_master.remarks," +
                                            //"picture," +
                                            "car_master.insert_ymd_hms," +
                                            "car_master.update_ymd_hms," +
                                            "car_master.delete_ymd_hms," +
                                            "car_master.delete_flag " +
                                     "FROM car_master " +
                                     "LEFT OUTER JOIN car_kind_master ON car_master.car_kind_code = car_kind_master.code " +
                                     "LEFT OUTER JOIN car_shape_master ON car_master.shape_code = car_shape_master.code " +
                                     "LEFT OUTER JOIN car_manufacturer_master ON car_master.manufacturer_code = car_manufacturer_master.code " +
                                     "LEFT OUTER JOIN classification_master ON car_master.classification_code = classification_master.code";
            // "WHERE delete_flag = 'False' " + // 2022-07-08 delete_flagを入れると過去の配車に削除済のCarLabelが反映出来なくなる
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    var carMasterVo = new CarMasterVo();
                    carMasterVo.Car_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_code"]);
                    carMasterVo.Classification_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["classification_code"]);
                    carMasterVo.Classification_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["classification_name"]); // 外部結合で取得
                    carMasterVo.Registration_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number"]);
                    carMasterVo.Registration_number_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_1"]);
                    carMasterVo.Registration_number_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_2"]);
                    carMasterVo.Registration_number_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_3"]);
                    carMasterVo.Registration_number_4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["registration_number_4"]);
                    carMasterVo.Garage_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["garage_flag"]);
                    carMasterVo.Door_number = _defaultValue.GetDefaultValue<int>(sqlDataReader["door_number"]);
                    carMasterVo.Registration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["registration_date"]);
                    carMasterVo.First_registration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["first_registration_date"]);
                    carMasterVo.Car_kind_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["car_kind_code"]);
                    carMasterVo.Car_kind_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_kind_name"]); // 外部結合で取得
                    carMasterVo.Disguise_kind_1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["disguise_kind_1"]);
                    carMasterVo.Disguise_kind_2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["disguise_kind_2"]);
                    carMasterVo.Disguise_kind_3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["disguise_kind_3"]);
                    carMasterVo.Car_use = _defaultValue.GetDefaultValue<string>(sqlDataReader["car_use"]);
                    carMasterVo.Other_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["other_code"]);
                    carMasterVo.Other_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["other_name"]);
                    carMasterVo.Shape_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["shape_code"]);
                    carMasterVo.Shape_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["shape_name"]); // 外部結合で取得
                    carMasterVo.Manufacturer_code = _defaultValue.GetDefaultValue<int>(sqlDataReader["manufacturer_code"]);
                    carMasterVo.Manufacturer_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["manufacturer_name"]); // 外部結合で取得
                    carMasterVo.Capacity = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["capacity"]);
                    carMasterVo.Maximum_load_capacity = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["maximum_load_capacity"]);
                    carMasterVo.Vehicle_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["vehicle_weight"]);
                    carMasterVo.Total_vehicle_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["total_vehicle_weight"]);
                    carMasterVo.Vehicle_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["vehicle_number"]);
                    carMasterVo.Length = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["length"]);
                    carMasterVo.Width = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["width"]);
                    carMasterVo.Height = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["height"]);
                    carMasterVo.Ff_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["ff_axis_weight"]);
                    carMasterVo.Fr_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["fr_axis_weight"]);
                    carMasterVo.Rf_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["rf_axis_weight"]);
                    carMasterVo.Rr_axis_weight = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["rr_axis_weight"]);
                    carMasterVo.Version = _defaultValue.GetDefaultValue<string>(sqlDataReader["version"]);
                    carMasterVo.Motor_version = _defaultValue.GetDefaultValue<string>(sqlDataReader["motor_version"]);
                    carMasterVo.Total_displacement = _defaultValue.GetDefaultValue<decimal>(sqlDataReader["total_displacement"]);
                    carMasterVo.Types_of_fuel = _defaultValue.GetDefaultValue<string>(sqlDataReader["types_of_fuel"]);
                    carMasterVo.Version_designate_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["version_designate_number"]);
                    carMasterVo.Category_distinguish_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["category_distinguish_number"]);
                    carMasterVo.Owner_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["owner_name"]);
                    carMasterVo.Owner_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["owner_address"]);
                    carMasterVo.User_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["user_name"]);
                    carMasterVo.User_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["user_address"]);
                    carMasterVo.Base_address = _defaultValue.GetDefaultValue<string>(sqlDataReader["base_address"]);
                    carMasterVo.Expiration_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["expiration_date"]);
                    carMasterVo.Remarks = _defaultValue.GetDefaultValue<string>(sqlDataReader["remarks"]);
                    //carLedgerVo.Picture = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["picture"]);
                    carMasterVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    carMasterVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    carMasterVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    carMasterVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                    listCarMasterVo.Add(carMasterVo);
                }
            }
            return listCarMasterVo;
        }

        /// <summary>
        /// InsertOneCarMaster
        /// </summary>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public void InsertOneCarMaster(CarMasterVo carMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO car_master(car_code," +
                                                            "classification_code," +
                                                            "registration_number," +
                                                            "registration_number_1," +
                                                            "registration_number_2," +
                                                            "registration_number_3," +
                                                            "registration_number_4," +
                                                            "garage_flag," +
                                                            "door_number," +
                                                            "registration_date," +
                                                            "first_registration_date," +
                                                            "car_kind_code," +
                                                            "disguise_kind_1," +
                                                            "disguise_kind_2," +
                                                            "disguise_kind_3," +
                                                            "car_use," +
                                                            "other_code," +
                                                            "other_name," +
                                                            "shape_code," +
                                                            "manufacturer_code," +
                                                            "capacity," +
                                                            "maximum_load_capacity," +
                                                            "vehicle_weight," +
                                                            "total_vehicle_weight," +
                                                            "vehicle_number," +
                                                            "length," +
                                                            "width," +
                                                            "height," +
                                                            "ff_axis_weight," +
                                                            "fr_axis_weight," +
                                                            "rf_axis_weight," +
                                                            "rr_axis_weight," +
                                                            "version," +
                                                            "motor_version," +
                                                            "total_displacement," +
                                                            "types_of_fuel," +
                                                            "version_designate_number," +
                                                            "category_distinguish_number," +
                                                            "owner_name," +
                                                            "owner_address," +
                                                            "user_name," +
                                                            "user_address," +
                                                            "base_address," +
                                                            "expiration_date," +
                                                            "remarks," +
                                                            "picture," +
                                                            "insert_ymd_hms," +
                                                            "update_ymd_hms," +
                                                            "delete_ymd_hms," +
                                                            "delete_flag) " +
                                     "VALUES ('" + carMasterVo.Car_code + "'," +
                                             "'" + carMasterVo.Classification_code + "'," +
                                             "'" + carMasterVo.Registration_number + "'," +
                                             "'" + carMasterVo.Registration_number_1 + "'," +
                                             "'" + carMasterVo.Registration_number_2 + "'," +
                                             "'" + carMasterVo.Registration_number_3 + "'," +
                                             "'" + carMasterVo.Registration_number_4 + "'," +
                                             "'" + carMasterVo.Garage_flag + "'," +
                                             "'" + carMasterVo.Door_number + "'," +
                                             "'" + carMasterVo.Registration_date + "'," +
                                             "'" + carMasterVo.First_registration_date + "'," +
                                             "'" + carMasterVo.Car_kind_code + "'," +
                                             "'" + carMasterVo.Disguise_kind_1 + "'," +
                                             "'" + carMasterVo.Disguise_kind_2 + "'," +
                                             "'" + carMasterVo.Disguise_kind_3 + "'," +
                                             "'" + carMasterVo.Car_use + "'," +
                                             "'" + carMasterVo.Other_code + "'," +
                                             "'" + carMasterVo.Other_name + "'," +
                                             "'" + carMasterVo.Shape_code + "'," +
                                             "'" + carMasterVo.Manufacturer_code + "'," +
                                             "'" + carMasterVo.Capacity + "'," +
                                             "'" + carMasterVo.Maximum_load_capacity + "'," +
                                             "'" + carMasterVo.Vehicle_weight + "'," +
                                             "'" + carMasterVo.Total_vehicle_weight + "'," +
                                             "'" + carMasterVo.Vehicle_number + "'," +
                                             "'" + carMasterVo.Length + "'," +
                                             "'" + carMasterVo.Width + "'," +
                                             "'" + carMasterVo.Height + "'," +
                                             "'" + carMasterVo.Ff_axis_weight + "'," +
                                             "'" + carMasterVo.Fr_axis_weight + "'," +
                                             "'" + carMasterVo.Ff_axis_weight + "'," +
                                             "'" + carMasterVo.Rr_axis_weight + "'," +
                                             "'" + carMasterVo.Version + "'," +
                                             "'" + carMasterVo.Motor_version + "'," +
                                             "'" + carMasterVo.Total_displacement + "'," +
                                             "'" + carMasterVo.Types_of_fuel + "'," +
                                             "'" + carMasterVo.Version_designate_number + "'," +
                                             "'" + carMasterVo.Category_distinguish_number + "'," +
                                             "'" + carMasterVo.Owner_name + "'," +
                                             "'" + carMasterVo.Owner_address + "'," +
                                             "'" + carMasterVo.User_name + "'," +
                                             "'" + carMasterVo.User_address + "'," +
                                             "'" + carMasterVo.Base_address + "'," +
                                             "'" + carMasterVo.Expiration_date + "'," +
                                             "'" + carMasterVo.Remarks + "'," +
                                             "@picture," +
                                             "'" + DateTime.Now + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'" + _defaultDateTime + "'," +
                                             "'False'" +
                                             ");";
            try {
                sqlCommand.Parameters.Add("@picture", SqlDbType.Image, carMasterVo.Picture.Length).Value = carMasterVo.Picture;
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneCarMaster
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public int UpdateOneCarMaster(int carCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE car_master " +
                                     "SET update_ymd_hms = '" + DateTime.Now + "'," +
                                         "delete_flag = 'True' " +
                                     "WHERE car_code = " + carCode + " " +
                                       "AND delete_Flag = 'False'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine("UpdateOneCarLedger : " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// UpdateOneCarMaster
        /// </summary>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public void UpdateOneCarMaster(CarMasterVo carMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE car_master " +
                                     "SET car_code = " + carMasterVo.Car_code + "," +
                                         "classification_code = " + carMasterVo.Classification_code + "," +
                                         "registration_number = '" + carMasterVo.Registration_number + "'," +
                                         "registration_number_1 = '" + carMasterVo.Registration_number_1 + "'," +
                                         "registration_number_2 = '" + carMasterVo.Registration_number_2 + "'," +
                                         "registration_number_3 = '" + carMasterVo.Registration_number_3 + "'," +
                                         "registration_number_4 = '" + carMasterVo.Registration_number_4 + "'," +
                                         "garage_flag = '" + carMasterVo.Garage_flag + "'," +
                                         "door_number = " + carMasterVo.Door_number + "," +
                                         "registration_date = '" + carMasterVo.Registration_date + "'," +
                                         "first_registration_date = '" + carMasterVo.First_registration_date + "'," +
                                         "car_kind_code = '" + carMasterVo.Car_kind_code + "'," +
                                         "disguise_kind_1 = '" + carMasterVo.Disguise_kind_1 + "'," +
                                         "disguise_kind_2 = '" + carMasterVo.Disguise_kind_2 + "'," +
                                         "disguise_kind_3 = '" + carMasterVo.Disguise_kind_3 + "'," +
                                         "car_use = '" + carMasterVo.Car_use + "'," +
                                         "other_code = '" + carMasterVo.Other_code + "'," +
                                         "other_name = '" + carMasterVo.Other_name + "'," +
                                         "shape_code = '" + carMasterVo.Shape_code + "'," +
                                         "manufacturer_code = '" + carMasterVo.Manufacturer_code + "'," +
                                         "capacity = '" + carMasterVo.Capacity + "'," +
                                         "maximum_load_capacity = '" + carMasterVo.Maximum_load_capacity + "'," +
                                         "vehicle_weight = '" + carMasterVo.Vehicle_weight + "'," +
                                         "total_vehicle_weight = '" + carMasterVo.Total_vehicle_weight + "'," +
                                         "vehicle_number = '" + carMasterVo.Vehicle_number + "'," +
                                         "length = '" + carMasterVo.Length + "'," +
                                         "width = '" + carMasterVo.Width + "'," +
                                         "height = '" + carMasterVo.Height + "'," +
                                         "ff_axis_weight = '" + carMasterVo.Ff_axis_weight + "'," +
                                         "fr_axis_weight = '" + carMasterVo.Fr_axis_weight + "'," +
                                         "rf_axis_weight = '" + carMasterVo.Rf_axis_weight + "'," +
                                         "rr_axis_weight = '" + carMasterVo.Rr_axis_weight + "'," +
                                         "version = '" + carMasterVo.Version + "'," +
                                         "motor_version = '" + carMasterVo.Motor_version + "'," +
                                         "total_displacement = '" + carMasterVo.Total_displacement + "'," +
                                         "types_of_fuel = '" + carMasterVo.Types_of_fuel + "'," +
                                         "version_designate_number = '" + carMasterVo.Version_designate_number + "'," +
                                         "category_distinguish_number = '" + carMasterVo.Category_distinguish_number + "'," +
                                         "owner_name = '" + carMasterVo.Owner_name + "'," +
                                         "owner_address = '" + carMasterVo.Owner_address + "'," +
                                         "user_name = '" + carMasterVo.User_name + "'," +
                                         "user_address = '" + carMasterVo.User_address + "'," +
                                         "base_address = '" + carMasterVo.Base_address + "'," +
                                         "expiration_date = '" + carMasterVo.Expiration_date + "'," +
                                         "remarks = '" + carMasterVo.Remarks + "'," +
                                         "picture = @member_picture," +
                                         "update_ymd_hms = '" + DateTime.Now + "' " +
                                     "WHERE car_code = " + carMasterVo.Car_code + " " +
                                       "AND delete_Flag = 'False'";
            try {
                sqlCommand.Parameters.Add("@member_picture", SqlDbType.Image, carMasterVo.Picture.Length).Value = carMasterVo.Picture;
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// CheckCarMaster
        /// 0:存在しない 他:返り値の数だけ存在する
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public int CheckCarMaster(int carCode) {
            int count = 0;
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(car_code) " +
                                     "FROM car_master " +
                                     "WHERE car_code = " + carCode;
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch (Exception e) {
                Console.WriteLine("CheckCarMaster : " + e.Message);
            }
            return count;
        }

        /// <summary>
        /// 新規car_codeを採番
        /// 引数(carCode)より小さい番号の中で最大の番号を取得する
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public int GetCarCode(int carCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT MAX(car_code) " +
                                     "FROM car_master " +
                                     "WHERE car_code < " + carCode;
            try {
                return (int)sqlCommand.ExecuteScalar();
            } catch (Exception e) {
                Console.WriteLine("GetCarCode : " + e.Message);
                return 0;
            }
        }
    }
}
