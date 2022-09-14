using Common;

using Vo;

namespace Dao {
    public class CarMasterDao {
        private readonly ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public CarMasterDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        public List<CarMasterVo> SelectAllCarMaster() {
            var listCarMasterVo = new List<CarMasterVo>();
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT car_code," +
                                            "classification_code," +
                                            "classification_name," + // 外部結合で取得
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
                                            "car_kind_name," + // 外部結合で取得
                                            "disguise_kind_1," +
                                            "disguise_kind_2," +
                                            "disguise_kind_3," +
                                            "car_use," +
                                            "other_code," +
                                            "other_name," +
                                            "shape_code," +
                                            "shape_name," + // 外部結合で取得
                                            "manufacturer_code," +
                                            "manufacturer_name," + // 外部結合で取得
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
                                            //"picture," +
                                            "insert_ymd_hms," +
                                            "update_ymd_hms," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM view_car_master ";
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
                    carMasterVo.Door_number = _defaultValue.GetDefaultValue<string>(sqlDataReader["door_number"]);
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
    }
}
