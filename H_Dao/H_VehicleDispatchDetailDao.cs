/*
 * 2023-12-31 
 */
using H_Common;

using H_Vo;

using System.Data.SqlClient;

using Vo;

namespace H_Dao {
    public class H_VehicleDispatchDetailDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_VehicleDispatchDetailDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// InsertHVehicleDispatchDetail
        /// </summary>
        /// <param name="listHVehicleDispatchDetailVo"></param>
        public void InsertHVehicleDispatchDetail(List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo) {
            int count = 1;
            string sqlString = string.Empty;
            foreach (H_VehicleDispatchDetailVo hVehicleDispatchDetailVo in listHVehicleDispatchDetailVo) {
                sqlString += "(" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.CellNumber) + "," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.OperationDate) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.VehicleDispatchFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.PurposeFlag) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.SetCode) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.ManagedSpaceCode) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.ClassificationCode) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.LastRollCallFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.LastRollCallYmdHms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.SetMemoFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.SetMemo) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.ShiftCode) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StandByFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.AddWorkerFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.ContactInfomationFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.FaxTransmissionFlag) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.CarCode) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.GarageCode) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.CarProxyFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.CarMemoFlag) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.CarMemo) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffCode1) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffOccupation1) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffProxyFlag1) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffRollCallFlag1) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.StaffRollCallYmdHms1) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffMemoFlag1) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.StaffMemo1) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffCode2) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffOccupation2) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffProxyFlag2) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffRollCallFlag2) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.StaffRollCallYmdHms2) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffMemoFlag2) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.StaffMemo2) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffCode3) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffOccupation3) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffProxyFlag3) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffRollCallFlag3) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.StaffRollCallYmdHms3) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffMemoFlag3) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.StaffMemo3) + "'," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffCode4) + "," +
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.StaffOccupation4) + "," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffProxyFlag4) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffRollCallFlag4) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.StaffRollCallYmdHms4) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.StaffMemoFlag4) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.StaffMemo4) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.InsertPcName) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.InsertYmdHms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.UpdatePcName) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.UpdateYmdHms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<string>(hVehicleDispatchDetailVo.DeletePcName) + "'," +
                             "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.DeleteYmdHms) + "'," +
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.DeleteFlag) + "')";
                if (count < listHVehicleDispatchDetailVo.Count)
                    sqlString += ",";
                count++;
            }
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_VehicleDispatchDetail(CellNumber," +
                                                                         "OperationDate," +
                                                                         "VehicleDispatchFlag," +
                                                                         "PurposeFlag," +
                                                                         "SetCode," +
                                                                         "ManagedSpaceCode," +
                                                                         "ClassificationCode," +
                                                                         "LastRollCallFlag," +
                                                                         "LastRollCallYmdHms," +
                                                                         "SetMemoFlag," +
                                                                         "SetMemo," +
                                                                         "ShiftCode," +
                                                                         "StandByFlag," +
                                                                         "AddWorkerFlag," +
                                                                         "ContactInfomationFlag," +
                                                                         "FaxTransmissionFlag," +
                                                                         "CarCode," +
                                                                         "GarageCode," +
                                                                         "CarProxyFlag," +
                                                                         "CarMemoFlag," +
                                                                         "CarMemo," +
                                                                         "StaffCode1," +
                                                                         "StaffOccupation1," +
                                                                         "StaffProxyFlag1," +
                                                                         "StaffRollCallFlag1," +
                                                                         "StaffRollCallYmdHms1," +
                                                                         "StaffMemoFlag1," +
                                                                         "StaffMemo1," +
                                                                         "StaffCode2," +
                                                                         "StaffOccupation2," +
                                                                         "StaffProxyFlag2," +
                                                                         "StaffRollCallFlag2," +
                                                                         "StaffRollCallYmdHms2," +
                                                                         "StaffMemoFlag2," +
                                                                         "StaffMemo2," +
                                                                         "StaffCode3," +
                                                                         "StaffOccupation3," +
                                                                         "StaffProxyFlag3," +
                                                                         "StaffRollCallFlag3," +
                                                                         "StaffRollCallYmdHms3," +
                                                                         "StaffMemoFlag3," +
                                                                         "StaffMemo3," +
                                                                         "StaffCode4," +
                                                                         "StaffOccupation4," +
                                                                         "StaffProxyFlag4," +
                                                                         "StaffRollCallFlag4," +
                                                                         "StaffRollCallYmdHms4," +
                                                                         "StaffMemoFlag4," +
                                                                         "StaffMemo4," +
                                                                         "InsertPcName," +
                                                                         "InsertYmdHms," +
                                                                         "UpdatePcName," +
                                                                         "UpdateYmdHms," +
                                                                         "DeletePcName," +
                                                                         "DeleteYmdHms," +
                                                                         "DeleteFlag) " +
                                     "VALUES " + sqlString;
            try {
                sqlCommand.ExecuteNonQuery();
            }
            catch {
                throw;
            }
        }
    }
}
