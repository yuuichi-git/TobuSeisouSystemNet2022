﻿/*
 * 2023-12-31 
 */
using H_Common;

using H_Vo;

using System.Data.SqlClient;

using Vo;

namespace H_Dao {
    public class H_VehicleDispatchDetailDao {
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
        /// SelectHVehicleDispatchDetail
        /// </summary>
        /// <param name="operationDate"></param>
        /// <returns></returns>
        public List<H_VehicleDispatchDetailVo> SelectHVehicleDispatchDetail(DateTime operationDate) {
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
            }
            catch {
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
            }
            catch {
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
            }
            catch {
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
            }
            catch {
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
            }
            catch {
                throw;
            }
        }
    }
}
