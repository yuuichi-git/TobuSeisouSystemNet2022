/*
 * 2023-12-31 
 */
using System.Data.SqlClient;

using H_Common;

using H_Vo;

namespace H_Dao {
    public class H_VehicleDispatchDetailDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * H_Common
         */
        private readonly DefaultValue _defaultValue = new();
        /*
         * H_Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_VehicleDispatchDetailDao(ConnectionVo connectionVo) {
            /*
             * H_Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHVehicleDispatchDetail
        /// true:該当レコードあり false:該当レコードなし
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public bool ExistenceHVehicleDispatchDetail(DateTime operationDate) {
            int count;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(CellNumber) " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// ExistenceHVehicleDispatchDetail
        /// true:該当レコードあり false:該当レコードなし 
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public bool ExistenceHVehicleDispatchDetail(int cellNumber, DateTime operationDate) {
            int count;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(CellNumber) " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                count = (int)sqlCommand.ExecuteScalar();
            } catch {
                throw;
            }
            return count != 0 ? true : false;
        }

        /// <summary>
        /// SelectOneHVehicleDispatchDetail
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public H_VehicleDispatchDetailVo SelectOneHVehicleDispatchDetail(int cellNumber, DateTime operationDate) {
            H_VehicleDispatchDetailVo hVehicleDispatchDetailVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT H_VehicleDispatchDetail.CellNumber," +
                                            "H_VehicleDispatchDetail.OperationDate," +
                                            "H_VehicleDispatchDetail.OperationFlag," +
                                            "H_VehicleDispatchDetail.VehicleDispatchFlag," +
                                            "H_VehicleDispatchDetail.PurposeFlag," +
                                            "H_VehicleDispatchDetail.SetCode," +
                                            "H_VehicleDispatchDetail.ManagedSpaceCode," +
                                            "H_VehicleDispatchDetail.ClassificationCode," +
                                            "H_VehicleDispatchDetail.LastRollCallFlag," +
                                            "H_VehicleDispatchDetail.LastRollCallYmdHms," +
                                            "H_VehicleDispatchDetail.SetMemoFlag," +
                                            "H_VehicleDispatchDetail.SetMemo," +
                                            "H_VehicleDispatchDetail.ShiftCode," +
                                            "H_VehicleDispatchDetail.StandByFlag," +
                                            "H_VehicleDispatchDetail.AddWorkerFlag," +
                                            "H_VehicleDispatchDetail.ContactInfomationFlag," +
                                            "H_VehicleDispatchDetail.FaxTransmissionFlag," +
                                            "H_VehicleDispatchDetail.CarCode," +
                                            "H_VehicleDispatchDetail.CarGarageCode," +
                                            "H_VehicleDispatchDetail.CarProxyFlag," +
                                            "H_VehicleDispatchDetail.CarMemoFlag," +
                                            "H_VehicleDispatchDetail.CarMemo," +
                                            "H_VehicleDispatchDetail.StaffCode1," +
                                            "H_VehicleDispatchDetail.StaffOccupation1," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag1," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag1," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms1," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag1," +
                                            "H_VehicleDispatchDetail.StaffMemo1," +
                                            "H_VehicleDispatchDetail.StaffCode2," +
                                            "H_VehicleDispatchDetail.StaffOccupation2," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag2," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag2," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms2," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag2," +
                                            "H_VehicleDispatchDetail.StaffMemo2," +
                                            "H_VehicleDispatchDetail.StaffCode3," +
                                            "H_VehicleDispatchDetail.StaffOccupation3," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag3," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag3," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms3," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag3," +
                                            "H_VehicleDispatchDetail.StaffMemo3," +
                                            "H_VehicleDispatchDetail.StaffCode4," +
                                            "H_VehicleDispatchDetail.StaffOccupation4," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag4," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag4," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms4," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag4," +
                                            "H_VehicleDispatchDetail.StaffMemo4," +
                                            "H_VehicleDispatchDetail.InsertPcName," +
                                            "H_VehicleDispatchDetail.InsertYmdHms," +
                                            "H_VehicleDispatchDetail.UpdatePcName," +
                                            "H_VehicleDispatchDetail.UpdateYmdHms," +
                                            "H_VehicleDispatchDetail.DeletePcName," +
                                            "H_VehicleDispatchDetail.DeleteYmdHms," +
                                            "H_VehicleDispatchDetail.DeleteFlag " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hVehicleDispatchDetailVo.CellNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["CellNumber"]);
                    hVehicleDispatchDetailVo.OperationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OperationDate"]);
                    hVehicleDispatchDetailVo.OperationFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["OperationFlag"]);
                    hVehicleDispatchDetailVo.VehicleDispatchFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["VehicleDispatchFlag"]);
                    hVehicleDispatchDetailVo.PurposeFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["PurposeFlag"]);
                    hVehicleDispatchDetailVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hVehicleDispatchDetailVo.ManagedSpaceCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ManagedSpaceCode"]);
                    hVehicleDispatchDetailVo.ClassificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ClassificationCode"]);
                    hVehicleDispatchDetailVo.LastRollCallFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["LastRollCallFlag"]);
                    hVehicleDispatchDetailVo.LastRollCallYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["LastRollCallYmdHms"]);
                    hVehicleDispatchDetailVo.SetMemoFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["SetMemoFlag"]);
                    hVehicleDispatchDetailVo.SetMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader["SetMemo"]);
                    hVehicleDispatchDetailVo.ShiftCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ShiftCode"]);
                    hVehicleDispatchDetailVo.StandByFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StandByFlag"]);
                    hVehicleDispatchDetailVo.AddWorkerFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["AddWorkerFlag"]);
                    hVehicleDispatchDetailVo.ContactInfomationFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ContactInfomationFlag"]);
                    hVehicleDispatchDetailVo.FaxTransmissionFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["FaxTransmissionFlag"]);
                    hVehicleDispatchDetailVo.CarCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarCode"]);
                    hVehicleDispatchDetailVo.CarGarageCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarGarageCode"]);
                    hVehicleDispatchDetailVo.CarProxyFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["CarProxyFlag"]);
                    hVehicleDispatchDetailVo.CarMemoFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["CarMemoFlag"]);
                    hVehicleDispatchDetailVo.CarMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarMemo"]);
                    hVehicleDispatchDetailVo.StaffCode1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode1"]);
                    hVehicleDispatchDetailVo.StaffOccupation1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation1"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag1 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag1"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag1 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag1"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms1"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag1 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag1"]);
                    hVehicleDispatchDetailVo.StaffMemo1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo1"]);
                    hVehicleDispatchDetailVo.StaffCode2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode2"]);
                    hVehicleDispatchDetailVo.StaffOccupation2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation2"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag2 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag2"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag2 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag2"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms2"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag2 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag2"]);
                    hVehicleDispatchDetailVo.StaffMemo2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo2"]);
                    hVehicleDispatchDetailVo.StaffCode3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode3"]);
                    hVehicleDispatchDetailVo.StaffOccupation3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation3"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag3 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag3"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag3 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag3"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms3"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag3 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag3"]);
                    hVehicleDispatchDetailVo.StaffMemo3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo3"]);
                    hVehicleDispatchDetailVo.StaffCode4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode4"]);
                    hVehicleDispatchDetailVo.StaffOccupation4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation4"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag4 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag4"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag4 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag4"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms4"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag4 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag4"]);
                    hVehicleDispatchDetailVo.StaffMemo4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo4"]);
                    hVehicleDispatchDetailVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hVehicleDispatchDetailVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hVehicleDispatchDetailVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hVehicleDispatchDetailVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hVehicleDispatchDetailVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hVehicleDispatchDetailVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hVehicleDispatchDetailVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hVehicleDispatchDetailVo;
        }

        /// <summary>
        /// SelectHVehicleDispatchDetail
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<H_VehicleDispatchDetailVo> SelectAllHVehicleDispatchDetail(DateTime operationDate) {
            List<H_VehicleDispatchDetailVo> listHVehicleDispatchDetailVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT H_VehicleDispatchDetail.CellNumber," +
                                            "H_VehicleDispatchDetail.OperationDate," +
                                            "H_VehicleDispatchDetail.OperationFlag," +
                                            "H_VehicleDispatchDetail.VehicleDispatchFlag," +
                                            "H_VehicleDispatchDetail.PurposeFlag," +
                                            "H_VehicleDispatchDetail.SetCode," +
                                            "H_VehicleDispatchDetail.ManagedSpaceCode," +
                                            "H_VehicleDispatchDetail.ClassificationCode," +
                                            "H_VehicleDispatchDetail.LastRollCallFlag," +
                                            "H_VehicleDispatchDetail.LastRollCallYmdHms," +
                                            "H_VehicleDispatchDetail.SetMemoFlag," +
                                            "H_VehicleDispatchDetail.SetMemo," +
                                            "H_VehicleDispatchDetail.ShiftCode," +
                                            "H_VehicleDispatchDetail.StandByFlag," +
                                            "H_VehicleDispatchDetail.AddWorkerFlag," +
                                            "H_VehicleDispatchDetail.ContactInfomationFlag," +
                                            "H_VehicleDispatchDetail.FaxTransmissionFlag," +
                                            "H_VehicleDispatchDetail.CarCode," +
                                            "H_VehicleDispatchDetail.CarGarageCode," +
                                            "H_VehicleDispatchDetail.CarProxyFlag," +
                                            "H_VehicleDispatchDetail.CarMemoFlag," +
                                            "H_VehicleDispatchDetail.CarMemo," +
                                            "H_VehicleDispatchDetail.StaffCode1," +
                                            "H_VehicleDispatchDetail.StaffOccupation1," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag1," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag1," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms1," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag1," +
                                            "H_VehicleDispatchDetail.StaffMemo1," +
                                            "H_VehicleDispatchDetail.StaffCode2," +
                                            "H_VehicleDispatchDetail.StaffOccupation2," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag2," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag2," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms2," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag2," +
                                            "H_VehicleDispatchDetail.StaffMemo2," +
                                            "H_VehicleDispatchDetail.StaffCode3," +
                                            "H_VehicleDispatchDetail.StaffOccupation3," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag3," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag3," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms3," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag3," +
                                            "H_VehicleDispatchDetail.StaffMemo3," +
                                            "H_VehicleDispatchDetail.StaffCode4," +
                                            "H_VehicleDispatchDetail.StaffOccupation4," +
                                            "H_VehicleDispatchDetail.StaffProxyFlag4," +
                                            "H_VehicleDispatchDetail.StaffRollCallFlag4," +
                                            "H_VehicleDispatchDetail.StaffRollCallYmdHms4," +
                                            "H_VehicleDispatchDetail.StaffMemoFlag4," +
                                            "H_VehicleDispatchDetail.StaffMemo4," +
                                            "H_VehicleDispatchDetail.InsertPcName," +
                                            "H_VehicleDispatchDetail.InsertYmdHms," +
                                            "H_VehicleDispatchDetail.UpdatePcName," +
                                            "H_VehicleDispatchDetail.UpdateYmdHms," +
                                            "H_VehicleDispatchDetail.DeletePcName," +
                                            "H_VehicleDispatchDetail.DeleteYmdHms," +
                                            "H_VehicleDispatchDetail.DeleteFlag " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE H_VehicleDispatchDetail.OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_VehicleDispatchDetailVo hVehicleDispatchDetailVo = new();
                    hVehicleDispatchDetailVo.CellNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["CellNumber"]);
                    hVehicleDispatchDetailVo.OperationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["OperationDate"]);
                    hVehicleDispatchDetailVo.OperationFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["OperationFlag"]);
                    hVehicleDispatchDetailVo.VehicleDispatchFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["VehicleDispatchFlag"]);
                    hVehicleDispatchDetailVo.PurposeFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["PurposeFlag"]);
                    hVehicleDispatchDetailVo.SetCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["SetCode"]);
                    hVehicleDispatchDetailVo.ManagedSpaceCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ManagedSpaceCode"]);
                    hVehicleDispatchDetailVo.ClassificationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ClassificationCode"]);
                    hVehicleDispatchDetailVo.LastRollCallFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["LastRollCallFlag"]);
                    hVehicleDispatchDetailVo.LastRollCallYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["LastRollCallYmdHms"]);
                    hVehicleDispatchDetailVo.SetMemoFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["SetMemoFlag"]);
                    hVehicleDispatchDetailVo.SetMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader["SetMemo"]);
                    hVehicleDispatchDetailVo.ShiftCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["ShiftCode"]);
                    hVehicleDispatchDetailVo.StandByFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StandByFlag"]);
                    hVehicleDispatchDetailVo.AddWorkerFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["AddWorkerFlag"]);
                    hVehicleDispatchDetailVo.ContactInfomationFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["ContactInfomationFlag"]);
                    hVehicleDispatchDetailVo.FaxTransmissionFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["FaxTransmissionFlag"]);
                    hVehicleDispatchDetailVo.CarCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarCode"]);
                    hVehicleDispatchDetailVo.CarGarageCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["CarGarageCode"]);
                    hVehicleDispatchDetailVo.CarProxyFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["CarProxyFlag"]);
                    hVehicleDispatchDetailVo.CarMemoFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["CarMemoFlag"]);
                    hVehicleDispatchDetailVo.CarMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarMemo"]);
                    hVehicleDispatchDetailVo.StaffCode1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode1"]);
                    hVehicleDispatchDetailVo.StaffOccupation1 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation1"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag1 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag1"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag1 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag1"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms1"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag1 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag1"]);
                    hVehicleDispatchDetailVo.StaffMemo1 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo1"]);
                    hVehicleDispatchDetailVo.StaffCode2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode2"]);
                    hVehicleDispatchDetailVo.StaffOccupation2 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation2"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag2 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag2"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag2 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag2"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms2"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag2 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag2"]);
                    hVehicleDispatchDetailVo.StaffMemo2 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo2"]);
                    hVehicleDispatchDetailVo.StaffCode3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode3"]);
                    hVehicleDispatchDetailVo.StaffOccupation3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation3"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag3 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag3"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag3 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag3"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms3"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag3 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag3"]);
                    hVehicleDispatchDetailVo.StaffMemo3 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo3"]);
                    hVehicleDispatchDetailVo.StaffCode4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode4"]);
                    hVehicleDispatchDetailVo.StaffOccupation4 = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffOccupation4"]);
                    hVehicleDispatchDetailVo.StaffProxyFlag4 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffProxyFlag4"]);
                    hVehicleDispatchDetailVo.StaffRollCallFlag4 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffRollCallFlag4"]);
                    hVehicleDispatchDetailVo.StaffRollCallYmdHms4 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StaffRollCallYmdHms4"]);
                    hVehicleDispatchDetailVo.StaffMemoFlag4 = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StaffMemoFlag4"]);
                    hVehicleDispatchDetailVo.StaffMemo4 = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffMemo4"]);
                    hVehicleDispatchDetailVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hVehicleDispatchDetailVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hVehicleDispatchDetailVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hVehicleDispatchDetailVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hVehicleDispatchDetailVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hVehicleDispatchDetailVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hVehicleDispatchDetailVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHVehicleDispatchDetailVo.Add(hVehicleDispatchDetailVo);
                }
            }
            return listHVehicleDispatchDetailVo;
        }

        /// <summary>
        /// InsertHVehicleDispatchDetail
        /// </summary>
        /// <param name="hVehicleDispatchDetailVo"></param>
        public void InsertOneHVehicleDispatchDetail(H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_VehicleDispatchDetail(CellNumber," +
                                                                         "OperationDate," +
                                                                         "OperationFlag," +
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
                                                                         "CarGarageCode," +
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
                                     "VALUES (" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.CellNumber) + ", " +
                                            "'" + _defaultValue.GetDefaultValue<DateTime>(hVehicleDispatchDetailVo.OperationDate) + "'," +
                                            "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.OperationFlag) + "'," +
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
                                             "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.CarGarageCode) + "," +
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
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
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
                             "'" + _defaultValue.GetDefaultValue<bool>(hVehicleDispatchDetailVo.OperationFlag) + "'," +
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
                              "" + _defaultValue.GetDefaultValue<int>(hVehicleDispatchDetailVo.CarGarageCode) + "," +
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
                                                                         "OperationFlag," +
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
                                                                         "CarGarageCode," +
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
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateHVehicleDispatchDetail
        /// </summary>
        /// <param name="hVehicleDispatchDetailVo"></param>
        public void UpdateOneHVehicleDispatchDetail(H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "Set CellNumber = " + hVehicleDispatchDetailVo.CellNumber + "," +
                                         "OperationDate = '" + hVehicleDispatchDetailVo.OperationDate + "'," +
                                         "OperationFlag = '" + hVehicleDispatchDetailVo.OperationFlag + "'," +
                                         "VehicleDispatchFlag = '" + hVehicleDispatchDetailVo.VehicleDispatchFlag + "'," +
                                         "PurposeFlag = '" + hVehicleDispatchDetailVo.PurposeFlag + "'," +
                                         "SetCode = " + hVehicleDispatchDetailVo.SetCode + "," +
                                         "ManagedSpaceCode = " + hVehicleDispatchDetailVo.ManagedSpaceCode + "," +
                                         "ClassificationCode = " + hVehicleDispatchDetailVo.ClassificationCode + "," +
                                         "LastRollCallFlag = '" + hVehicleDispatchDetailVo.LastRollCallFlag + "'," +
                                         "LastRollCallYmdHms = '" + hVehicleDispatchDetailVo.LastRollCallYmdHms + "'," +
                                         "SetMemoFlag = '" + hVehicleDispatchDetailVo.SetMemoFlag + "'," +
                                         "SetMemo = '" + hVehicleDispatchDetailVo.SetMemo + "'," +
                                         "ShiftCode = " + hVehicleDispatchDetailVo.ShiftCode + "," +
                                         "StandByFlag = '" + hVehicleDispatchDetailVo.StandByFlag + "'," +
                                         "AddWorkerFlag = '" + hVehicleDispatchDetailVo.AddWorkerFlag + "'," +
                                         "ContactInfomationFlag = '" + hVehicleDispatchDetailVo.ContactInfomationFlag + "'," +
                                         "FaxTransmissionFlag = '" + hVehicleDispatchDetailVo.FaxTransmissionFlag + "'," +
                                         "CarCode = " + hVehicleDispatchDetailVo.CarCode + "," +
                                         "CarGarageCode = " + hVehicleDispatchDetailVo.CarGarageCode + "," +
                                         "CarProxyFlag = '" + hVehicleDispatchDetailVo.CarProxyFlag + "'," +
                                         "CarMemoFlag = '" + hVehicleDispatchDetailVo.CarMemoFlag + "'," +
                                         "CarMemo = '" + hVehicleDispatchDetailVo.CarMemo + "'," +
                                         "StaffCode1 = " + hVehicleDispatchDetailVo.StaffCode1 + "," +
                                         "StaffOccupation1 = " + hVehicleDispatchDetailVo.StaffOccupation1 + "," +
                                         "StaffProxyFlag1 = '" + hVehicleDispatchDetailVo.StaffProxyFlag1 + "'," +
                                         "StaffRollCallFlag1 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag1 + "'," +
                                         "StaffRollCallYmdHms1 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms1 + "'," +
                                         "StaffMemoFlag1 = '" + hVehicleDispatchDetailVo.StaffMemoFlag1 + "'," +
                                         "StaffMemo1 = '" + hVehicleDispatchDetailVo.StaffMemo1 + "'," +
                                         "StaffCode2 = " + hVehicleDispatchDetailVo.StaffCode2 + "," +
                                         "StaffOccupation2 = " + hVehicleDispatchDetailVo.StaffOccupation2 + "," +
                                         "StaffProxyFlag2 = '" + hVehicleDispatchDetailVo.StaffProxyFlag2 + "'," +
                                         "StaffRollCallFlag2 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag2 + "'," +
                                         "StaffRollCallYmdHms2 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms2 + "'," +
                                         "StaffMemoFlag2 = '" + hVehicleDispatchDetailVo.StaffMemoFlag2 + "'," +
                                         "StaffMemo2 = '" + hVehicleDispatchDetailVo.StaffMemo2 + "'," +
                                         "StaffCode3 = " + hVehicleDispatchDetailVo.StaffCode3 + "," +
                                         "StaffOccupation3 = " + hVehicleDispatchDetailVo.StaffOccupation3 + "," +
                                         "StaffProxyFlag3 = '" + hVehicleDispatchDetailVo.StaffProxyFlag3 + "'," +
                                         "StaffRollCallFlag3 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag3 + "'," +
                                         "StaffRollCallYmdHms3 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms3 + "'," +
                                         "StaffMemoFlag3 = '" + hVehicleDispatchDetailVo.StaffMemoFlag3 + "'," +
                                         "StaffMemo3 = '" + hVehicleDispatchDetailVo.StaffMemo3 + "'," +
                                         "StaffCode4 = " + hVehicleDispatchDetailVo.StaffCode4 + "," +
                                         "StaffOccupation4 = " + hVehicleDispatchDetailVo.StaffOccupation4 + "," +
                                         "StaffProxyFlag4 = '" + hVehicleDispatchDetailVo.StaffProxyFlag4 + "'," +
                                         "StaffRollCallFlag4 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag4 + "'," +
                                         "StaffRollCallYmdHms4 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms4 + "'," +
                                         "StaffMemoFlag4 = '" + hVehicleDispatchDetailVo.StaffMemoFlag4 + "'," +
                                         "StaffMemo4 = '" + hVehicleDispatchDetailVo.StaffMemo4 + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "'," +
                                         "DeleteFlag = 'false' " +
                                     "WHERE CellNumber = " + hVehicleDispatchDetailVo.CellNumber + " AND OperationDate = '" + hVehicleDispatchDetailVo.OperationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 全営業日の配車(ClassificationCode=11・12)の従業員のみを複製する
        /// </summary>
        /// <param name="hVehicleDispatchDetailVo"></param>
        public void UpdateOneHVehicleDispatchDetailCopy(H_VehicleDispatchDetailVo hVehicleDispatchDetailVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "Set CellNumber = " + hVehicleDispatchDetailVo.CellNumber + "," +
                                         "OperationDate = '" + hVehicleDispatchDetailVo.OperationDate + "'," +
                                         //"OperationFlag = '" + hVehicleDispatchDetailVo.OperationFlag + "'," +
                                         //"VehicleDispatchFlag = '" + hVehicleDispatchDetailVo.VehicleDispatchFlag + "'," +
                                         //"PurposeFlag = '" + hVehicleDispatchDetailVo.PurposeFlag + "'," +
                                         //"SetCode = " + hVehicleDispatchDetailVo.SetCode + "," +
                                         //"ManagedSpaceCode = " + hVehicleDispatchDetailVo.ManagedSpaceCode + "," +
                                         //"ClassificationCode = " + hVehicleDispatchDetailVo.ClassificationCode + "," +
                                         //"LastRollCallFlag = '" + hVehicleDispatchDetailVo.LastRollCallFlag + "'," +
                                         //"LastRollCallYmdHms = '" + hVehicleDispatchDetailVo.LastRollCallYmdHms + "'," +
                                         //"SetMemoFlag = '" + hVehicleDispatchDetailVo.SetMemoFlag + "'," +
                                         //"SetMemo = '" + hVehicleDispatchDetailVo.SetMemo + "'," +
                                         //"ShiftCode = " + hVehicleDispatchDetailVo.ShiftCode + "," +
                                         //"StandByFlag = '" + hVehicleDispatchDetailVo.StandByFlag + "'," +
                                         //"AddWorkerFlag = '" + hVehicleDispatchDetailVo.AddWorkerFlag + "'," +
                                         //"ContactInfomationFlag = '" + hVehicleDispatchDetailVo.ContactInfomationFlag + "'," +
                                         //"FaxTransmissionFlag = '" + hVehicleDispatchDetailVo.FaxTransmissionFlag + "'," +
                                         "CarCode = " + hVehicleDispatchDetailVo.CarCode + "," +
                                         "CarGarageCode = " + hVehicleDispatchDetailVo.CarGarageCode + "," +
                                         "CarProxyFlag = '" + hVehicleDispatchDetailVo.CarProxyFlag + "'," +
                                         "CarMemoFlag = '" + hVehicleDispatchDetailVo.CarMemoFlag + "'," +
                                         "CarMemo = '" + hVehicleDispatchDetailVo.CarMemo + "'," +
                                         "StaffCode1 = " + hVehicleDispatchDetailVo.StaffCode1 + "," +
                                         "StaffOccupation1 = " + hVehicleDispatchDetailVo.StaffOccupation1 + "," +
                                         "StaffProxyFlag1 = '" + hVehicleDispatchDetailVo.StaffProxyFlag1 + "'," +
                                         //"StaffRollCallFlag1 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag1 + "'," +
                                         //"StaffRollCallYmdHms1 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms1 + "'," +
                                         "StaffMemoFlag1 = '" + hVehicleDispatchDetailVo.StaffMemoFlag1 + "'," +
                                         "StaffMemo1 = '" + hVehicleDispatchDetailVo.StaffMemo1 + "'," +
                                         "StaffCode2 = " + hVehicleDispatchDetailVo.StaffCode2 + "," +
                                         "StaffOccupation2 = " + hVehicleDispatchDetailVo.StaffOccupation2 + "," +
                                         "StaffProxyFlag2 = '" + hVehicleDispatchDetailVo.StaffProxyFlag2 + "'," +
                                         //"StaffRollCallFlag2 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag2 + "'," +
                                         //"StaffRollCallYmdHms2 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms2 + "'," +
                                         "StaffMemoFlag2 = '" + hVehicleDispatchDetailVo.StaffMemoFlag2 + "'," +
                                         "StaffMemo2 = '" + hVehicleDispatchDetailVo.StaffMemo2 + "'," +
                                         "StaffCode3 = " + hVehicleDispatchDetailVo.StaffCode3 + "," +
                                         "StaffOccupation3 = " + hVehicleDispatchDetailVo.StaffOccupation3 + "," +
                                         "StaffProxyFlag3 = '" + hVehicleDispatchDetailVo.StaffProxyFlag3 + "'," +
                                         //"StaffRollCallFlag3 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag3 + "'," +
                                         //"StaffRollCallYmdHms3 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms3 + "'," +
                                         "StaffMemoFlag3 = '" + hVehicleDispatchDetailVo.StaffMemoFlag3 + "'," +
                                         "StaffMemo3 = '" + hVehicleDispatchDetailVo.StaffMemo3 + "'," +
                                         "StaffCode4 = " + hVehicleDispatchDetailVo.StaffCode4 + "," +
                                         "StaffOccupation4 = " + hVehicleDispatchDetailVo.StaffOccupation4 + "," +
                                         "StaffProxyFlag4 = '" + hVehicleDispatchDetailVo.StaffProxyFlag4 + "'," +
                                         //"StaffRollCallFlag4 = '" + hVehicleDispatchDetailVo.StaffRollCallFlag4 + "'," +
                                         //"StaffRollCallYmdHms4 = '" + hVehicleDispatchDetailVo.StaffRollCallYmdHms4 + "'," +
                                         "StaffMemoFlag4 = '" + hVehicleDispatchDetailVo.StaffMemoFlag4 + "'," +
                                         "StaffMemo4 = '" + hVehicleDispatchDetailVo.StaffMemo4 + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "'," +
                                         "DeleteFlag = 'false' " +
                                     "WHERE CellNumber = " + hVehicleDispatchDetailVo.CellNumber + " AND OperationDate = '" + hVehicleDispatchDetailVo.OperationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 作業員付フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="addWorkerFlag"></param>
        public void UpdateAddWorkerFlag(int cellNumber, DateTime operationDate, bool addWorkerFlag) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET AddWorkerFlag = '" + addWorkerFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateClassificationCode
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="classificationCode"></param>
        public void UpdateClassificationCode(int cellNumber, DateTime operationDate, int classificationCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET ClassificationCode = " + classificationCode + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 連絡事項印フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="contactInfomationFlag"></param>
        public void UpdateContactInfomationFlag(int cellNumber, DateTime operationDate, bool contactInfomationFlag) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET ContactInfomationFlag = '" + contactInfomationFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 車庫地コード
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="carGarageCode"></param>
        public void UpdateCarGarageCode(int cellNumber, DateTime operationDate, int carGarageCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET CarGarageCode = " + carGarageCode + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 代車フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="carProxyFlag"></param>
        public void UpdateCarProxyFlag(int cellNumber, DateTime operationDate, bool carProxyFlag) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET CarProxyFlag = '" + carProxyFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// FAX送信フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="faxTransmissionFlag"></param>
        public void UpdateFaxTransmissionFlag(int cellNumber, DateTime operationDate, bool faxTransmissionFlag) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET FaxTransmissionFlag = '" + faxTransmissionFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 配車先情報をリセット（削除）する
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="faxTransmissionFlag"></param>
        public void ResetSetCode(int cellNumber, DateTime operationDate) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET OperationFlag = 'false'," +
                                         "VehicleDispatchFlag = 'false'," +
                                         "PurposeFlag = 'false'," +
                                         "SetCode = 0," +
                                         "ManagedSpaceCode = 0," +
                                         "ClassificationCode = 99," +
                                         "LastRollCallFlag = 'false'," +
                                         "LastRollCallYmdHms = '" + _defaultDateTime + "'," +
                                         "SetMemoFlag = 'false'," +
                                         "SetMemo = ''," +
                                         "ShiftCode = 0," +
                                         "StandByFlag = 'false'," +
                                         "AddWorkerFlag = 'false'," +
                                         "ContactInfomationFlag = 'false'," +
                                         "FaxTransmissionFlag = 'false'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 管理地
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="managedSpaceCode"></param>
        public void UpdateManagedSpaceCode(int cellNumber, DateTime operationDate, int managedSpaceCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET ManagedSpaceCode = " + managedSpaceCode + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 稼働フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="operationFlag"></param>
        public void UpdateOperationFlag(int cellNumber, DateTime operationDate, bool operationFlag) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET OperationFlag = '" + operationFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 番手コード
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="shiftCode"></param>
        public void UpdateShiftCode(int cellNumber, DateTime operationDate, int shiftCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET ShiftCode = " + shiftCode + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 職種コード
        /// 10:運転手 11:作業員 20:事務職 99:指定なし
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="staffOccupation"></param>
        /// <param name="staffNumber"></param>
        public void UpdateStaffOccupation(int cellNumber, DateTime operationDate, int staffOccupation, int staffNumber) {
            string sqlStaffOccupation = string.Empty;
            switch (staffNumber) {
                case 0:
                    sqlStaffOccupation = "StaffOccupation1";
                    break;
                case 1:
                    sqlStaffOccupation = "StaffOccupation2";
                    break;
                case 2:
                    sqlStaffOccupation = "StaffOccupation3";
                    break;
                case 3:
                    sqlStaffOccupation = "StaffOccupation4";
                    break;
            }
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET " + sqlStaffOccupation + " = " + staffOccupation + "," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateLastRollCall
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="hLastRollCallVo"></param>
        public void UpdateLastRollCall(bool lastRollCallFlag, int cellNumber, H_LastRollCallVo hLastRollCallVo) {
            /*
             * DB更新
             */
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET LastRollCallFlag = '" + !lastRollCallFlag + "'," +
                                         "LastRollCallYmdHms = '" + hLastRollCallVo.LastRollCallYmdHms + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + hLastRollCallVo.OperationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 点呼フラグ
        /// true:点呼実施 false:点呼未実施
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="staffRollCallFlag"></param>
        /// <param name="staffNumber"></param>
        public void UpdateStaffRollCall(int cellNumber, DateTime operationDate, bool staffRollCallFlag, int staffNumber) {
            string sqlStaffRollCallFlag = string.Empty;
            string sqlStaffRollCallYmdHms = string.Empty;
            switch (staffNumber) {
                case 0:
                    sqlStaffRollCallFlag = "StaffRollCallFlag1";
                    sqlStaffRollCallYmdHms = "StaffRollCallYmdHms1";
                    break;
                case 1:
                    sqlStaffRollCallFlag = "StaffRollCallFlag2";
                    sqlStaffRollCallYmdHms = "StaffRollCallYmdHms2";
                    break;
                case 2:
                    sqlStaffRollCallFlag = "StaffRollCallFlag3";
                    sqlStaffRollCallYmdHms = "StaffRollCallYmdHms3";
                    break;
                case 3:
                    sqlStaffRollCallFlag = "StaffRollCallFlag4";
                    sqlStaffRollCallYmdHms = "StaffRollCallYmdHms4";
                    break;
            }
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET " + sqlStaffRollCallFlag + " = '" + staffRollCallFlag + "'," +
                                              sqlStaffRollCallYmdHms + " = '" + DateTime.Now + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 代番フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="staffProxyFlag"></param>
        /// <param name="staffNumber">0:運転手 1:作業員① 2:作業員② 3:作業員③</param>
        public void UpdateStaffProxyFlag(int cellNumber, DateTime operationDate, bool staffProxyFlag, int staffNumber) {
            string sqlStaffProxyFlag = string.Empty;
            switch (staffNumber) {
                case 0:
                    sqlStaffProxyFlag = "StaffProxyFlag1";
                    break;
                case 1:
                    sqlStaffProxyFlag = "StaffProxyFlag2";
                    break;
                case 2:
                    sqlStaffProxyFlag = "StaffProxyFlag3";
                    break;
                case 3:
                    sqlStaffProxyFlag = "StaffProxyFlag4";
                    break;
            }
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET " + sqlStaffProxyFlag + " = '" + staffProxyFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 待機フラグ
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="standByFlag"></param>
        public void UpdateStandByFlag(int cellNumber, DateTime operationDate, bool standByFlag) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET StandByFlag = '" + standByFlag + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteHVehicleDispatchDetail
        /// </summary>
        /// <param name="operationDate"></param>
        public void DeleteHVehicleDispatchDetail(DateTime operationDate) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM H_VehicleDispatchDetail " +
                                     "WHERE OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectOneSetMemo
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public string SelectOneSetMemo(int cellNumber, DateTime operationDate) {
            string setMemo = string.Empty;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT SetMemo " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    setMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader["SetMemo"]);
                }
            }
            return setMemo;
        }

        /// <summary>
        /// SelectOneCarMemo
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public string SelectOneCarMemo(int cellNumber, DateTime operationDate) {
            string carMemo = string.Empty;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT CarMemo " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    carMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader["CarMemo"]);
                }
            }
            return carMemo;
        }

        /// <summary>
        /// SelectOneStaffMemo
        /// </summary>
        /// <param name="cellNumber">Cell№</param>
        /// <param name="operationDate">稼働日</param>
        /// <param name="staffNumber">配置番号</param>
        /// <returns></returns>
        public string SelectOneStaffMemo(int cellNumber, DateTime operationDate, int staffNumber) {
            string columnName = string.Empty;
            switch (staffNumber) {
                case 0:
                    columnName = "StaffMemo1";
                    break;
                case 1:
                    columnName = "StaffMemo2";
                    break;
                case 2:
                    columnName = "StaffMemo3";
                    break;
                case 3:
                    columnName = "StaffMemo4";
                    break;
            }
            string staffMemo = string.Empty;
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT " + columnName + " " +
                                     "FROM H_VehicleDispatchDetail " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    staffMemo = _defaultValue.GetDefaultValue<string>(sqlDataReader[columnName]);
                }
            }
            return staffMemo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="setMemoFlag"></param>
        /// <param name="setMemo"></param>
        public void UpdateOneSetMemo(int cellNumber, DateTime operationDate, bool setMemoFlag, string setMemo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET SetMemoFlag = '" + setMemoFlag + "'," +
                                         "SetMemo = '" + setMemo + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="carMemoFlag"></param>
        /// <param name="carMemo"></param>
        public void UpdateOneCarMemo(int cellNumber, DateTime operationDate, bool carMemoFlag, string carMemo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET CarMemoFlag = '" + carMemoFlag + "'," +
                                         "CarMemo = '" + carMemo + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <param name="operationDate"></param>
        /// <param name="staffNumber"></param>
        /// <param name="staffMemoFlag"></param>
        /// <param name="staffMemo"></param>
        public void UpdateOneStaffMemo(int cellNumber, DateTime operationDate, int staffNumber, bool staffMemoFlag, string staffMemo) {
            string columnStaffMemoFlag = string.Empty;
            string columnStaffMemo = string.Empty;
            switch (staffNumber) {
                case 0:
                    columnStaffMemoFlag = "StaffMemoFlag1";
                    columnStaffMemo = "StaffMemo1";
                    break;
                case 1:
                    columnStaffMemoFlag = "StaffMemoFlag2";
                    columnStaffMemo = "StaffMemo2";
                    break;
                case 2:
                    columnStaffMemoFlag = "StaffMemoFlag3";
                    columnStaffMemo = "StaffMemo3";
                    break;
                case 3:
                    columnStaffMemoFlag = "StaffMemoFlag4";
                    columnStaffMemo = "StaffMemo4";
                    break;
            }
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_VehicleDispatchDetail " +
                                     "SET " + columnStaffMemoFlag + " = '" + staffMemoFlag + "'," +
                                         "" + columnStaffMemo + " = '" + staffMemo + "'," +
                                          "UpdatePcName = '" + Environment.MachineName + "'," +
                                          "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE CellNumber = " + cellNumber + " AND OperationDate = '" + operationDate.ToString("yyyy-MM-dd") + "'";
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
