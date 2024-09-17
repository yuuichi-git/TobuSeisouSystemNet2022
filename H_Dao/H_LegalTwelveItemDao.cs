/*
 * 2024-04-27
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_LegalTwelveItemDao {
        /*
         * 
         */
        private readonly Date _date = new();
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;
        private readonly H_LegalTwelveItemListVo _hLegalTwelveItemVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_LegalTwelveItemDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
            _hLegalTwelveItemVo = new();
        }

        /// <summary>
        /// ExistenceHLegalTwelveItem
        /// </summary>
        /// <param name="hLegalTwelveItemVo">変更前のVo</param>
        /// <returns></returns>
        public bool ExistenceHLegalTwelveItem(H_LegalTwelveItemVo hLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(StudentsDate) " +
                                     "FROM H_LegalTwelveItem " +
                                     "WHERE (StudentsDate BETWEEN '" + hLegalTwelveItemVo.StudentsDate + "' AND '" + hLegalTwelveItemVo.StudentsDate + "') " +
                                     "AND StudentsCode = " + hLegalTwelveItemVo.StudentsCode + " " +
                                     "AND StaffCode = " + hLegalTwelveItemVo.StaffCode;
            try {
                return (int)sqlCommand.ExecuteScalar() > 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectLegalTwelveItemForm
        /// 画面表示に必要なデータを取得する
        /// </summary>
        /// <returns></returns>
        public List<H_LegalTwelveItemListVo> SelectHLegalTwelveItemListVo(DateTime startDate, DateTime endDate) {
            /*
             * 短期を含めるかどうかのSQLを作成
             * Belongs 10:役員 11:社員 12:アルバイト 13:派遣 20:新運転 21:自運労
             * JobForm 10:長期雇用 11:手帳 12:アルバイト 99:指定なし
             */
            //string allTerm;
            //if (allTermFlag) {
            //    allTerm = "H_StaffMaster.Belongs IN (10,11,12,13,20,21) AND H_StaffMaster.JobForm IN(10,11,12,99) AND H_StaffMaster.Occupation = 10 AND H_StaffMaster.RetirementFlag = 'false' ";
            //} else {
            //    allTerm = "H_StaffMaster.Belongs IN (10,11,12,13,20,21) AND H_StaffMaster.JobForm IN(10,12,99) AND H_StaffMaster.Occupation = 10 AND H_StaffMaster.RetirementFlag = 'false' ";
            //}

            List<H_LegalTwelveItemListVo> listHLegalTwelveItemVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT H_BelongsMaster.Code AS BelongsCode," +
                                            "H_BelongsMaster.Name AS BelongsName," +
                                            "H_JobFormMaster.Code AS JobFormCode," +
                                            "H_JobFormMaster.Name AS JobFormName," +
                                            "H_OccupationMaster.Code AS OccupationCode," +
                                            "H_OccupationMaster.Name AS OccupationName," +
                                            "H_StaffMaster.StaffCode," +
                                            "H_StaffMaster.Name AS StaffName," +
                                            "H_StaffMaster.EmploymentDate," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 0 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students01Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 1 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students02Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 2 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students03Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 3 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students04Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 4 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students05Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 5 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students06Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 6 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students07Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 7 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students08Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 8 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students09Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 9 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students10Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 10 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students11Flag," +
                                            "(SELECT StudentsFlag FROM H_LegalTwelveItem WHERE H_StaffMaster.StaffCode = H_LegalTwelveItem.StaffCode " +
                                                                                          "AND H_LegalTwelveItem.StudentsCode = 11 " +
                                                                                          "AND H_LegalTwelveItem.StudentsDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "') AS Students12Flag " +
                                     "FROM H_StaffMaster " +
                                     "LEFT OUTER JOIN H_OccupationMaster ON H_StaffMaster.Occupation = H_OccupationMaster.Code " +
                                     "LEFT OUTER JOIN H_JobFormMaster ON H_StaffMaster.JobForm = H_JobFormMaster.Code " +
                                     "LEFT OUTER JOIN H_BelongsMaster ON H_StaffMaster.Belongs = H_BelongsMaster.Code " +
                                     "WHERE H_StaffMaster.LegalTwelveItemFlag = 'true' AND H_StaffMaster.RetirementFlag = 'false' " +
                                     "ORDER BY H_StaffMaster.NameKana ASC";
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_LegalTwelveItemListVo hLegalTwelveItemVo = new();
                    hLegalTwelveItemVo.Belongs = _defaultValue.GetDefaultValue<int>(sqlDataReader["BelongsCode"]);
                    hLegalTwelveItemVo.BelongsName = _defaultValue.GetDefaultValue<string>(sqlDataReader["BelongsName"]);
                    hLegalTwelveItemVo.JobForm = _defaultValue.GetDefaultValue<int>(sqlDataReader["JobFormCode"]);
                    hLegalTwelveItemVo.JobFormName = _defaultValue.GetDefaultValue<string>(sqlDataReader["JobFormName"]);
                    hLegalTwelveItemVo.OccupationCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["OccupationCode"]);
                    hLegalTwelveItemVo.OccupationName = _defaultValue.GetDefaultValue<string>(sqlDataReader["OccupationName"]);
                    hLegalTwelveItemVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hLegalTwelveItemVo.StaffName = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffName"]);
                    hLegalTwelveItemVo.EmploymentDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["EmploymentDate"]);
                    hLegalTwelveItemVo.Students01Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students01Flag"]);
                    hLegalTwelveItemVo.Students02Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students02Flag"]);
                    hLegalTwelveItemVo.Students03Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students03Flag"]);
                    hLegalTwelveItemVo.Students04Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students04Flag"]);
                    hLegalTwelveItemVo.Students05Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students05Flag"]);
                    hLegalTwelveItemVo.Students06Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students06Flag"]);
                    hLegalTwelveItemVo.Students07Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students07Flag"]);
                    hLegalTwelveItemVo.Students08Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students08Flag"]);
                    hLegalTwelveItemVo.Students09Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students09Flag"]);
                    hLegalTwelveItemVo.Students10Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students10Flag"]);
                    hLegalTwelveItemVo.Students11Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students11Flag"]);
                    hLegalTwelveItemVo.Students12Flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Students12Flag"]);
                    listHLegalTwelveItemVo.Add(hLegalTwelveItemVo);
                }
                return listHLegalTwelveItemVo;
            }
        }

        /// <summary>
        /// SelectHLegalTwelveItemVo
        /// </summary>
        /// <param name="fiscalYear"></param>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public List<H_LegalTwelveItemVo> SelectHLegalTwelveItemVo(int fiscalYear, int staffCode) {
            List<H_LegalTwelveItemVo> listHLegalTwelveItemVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StudentsDate," +
                                            "StudentsCode," +
                                            "StudentsFlag," +
                                            "StaffCode," +
                                            "StaffSign," +
                                            "SignNumber," +
                                            "Memo," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_LegalTwelveItem " +
                                     "WHERE (StudentsDate BETWEEN '" + _date.GetFiscalYearStartDate(fiscalYear) + "' AND '" + _date.GetFiscalYearEndDate(fiscalYear) + "') " +
                                     "AND StaffCode = " + staffCode;
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_LegalTwelveItemVo hLegalTwelveItemVo = new();
                    hLegalTwelveItemVo.StudentsDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["StudentsDate"]);
                    hLegalTwelveItemVo.StudentsCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StudentsCode"]);
                    hLegalTwelveItemVo.StudentsFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["StudentsFlag"]);
                    hLegalTwelveItemVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hLegalTwelveItemVo.StaffSign = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["StaffSign"]);
                    hLegalTwelveItemVo.SignNumber = _defaultValue.GetDefaultValue<int>(sqlDataReader["SignNumber"]);
                    hLegalTwelveItemVo.Memo = _defaultValue.GetDefaultValue<string>(sqlDataReader["Memo"]);
                    hLegalTwelveItemVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hLegalTwelveItemVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hLegalTwelveItemVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hLegalTwelveItemVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hLegalTwelveItemVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hLegalTwelveItemVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hLegalTwelveItemVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHLegalTwelveItemVo.Add(hLegalTwelveItemVo);
                }
                return listHLegalTwelveItemVo;
            }
        }

        /// <summary>
        /// InsertOneHLegalTwelveItem
        /// </summary>
        /// <param name="hLegalTwelveItemVo"></param>
        /// <returns></returns>
        public int InsertOneHLegalTwelveItem(H_LegalTwelveItemVo hLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_LegalTwelveItem(StudentsDate," +
                                                                   "StudentsCode," +
                                                                   "StudentsFlag," +
                                                                   "StaffCode," +
                                                                   "StaffSign," +
                                                                   "SignNumber," +
                                                                   "Memo," +
                                                                   "InsertPcName," +
                                                                   "InsertYmdHms," +
                                                                   "UpdatePcName," +
                                                                   "UpdateYmdHms," +
                                                                   "DeletePcName," +
                                                                   "DeleteYmdHms," +
                                                                   "DeleteFlag) " +
                                     "VALUES ('" + hLegalTwelveItemVo.StudentsDate + "'," +
                                              "" + hLegalTwelveItemVo.StudentsCode + "," +
                                             "'" + hLegalTwelveItemVo.StudentsFlag + "'," +
                                              "" + hLegalTwelveItemVo.StaffCode + "," +
                                             "@Picture," +
                                              "" + hLegalTwelveItemVo.SignNumber + "," +
                                             "'" + hLegalTwelveItemVo.Memo + "'," +
                                             "'" + hLegalTwelveItemVo.InsertPcName + "'," +
                                             "'" + hLegalTwelveItemVo.InsertYmdHms + "'," +
                                             "'" + hLegalTwelveItemVo.UpdatePcName + "'," +
                                             "'" + hLegalTwelveItemVo.UpdateYmdHms + "'," +
                                             "'" + hLegalTwelveItemVo.DeletePcName + "'," +
                                             "'" + hLegalTwelveItemVo.DeleteYmdHms + "'," +
                                             "'" + hLegalTwelveItemVo.DeleteFlag + "'" +
                                             ");";
            if (hLegalTwelveItemVo.StaffSign is not null)
                sqlCommand.Parameters.Add("@Picture", SqlDbType.Image, hLegalTwelveItemVo.StaffSign.Length).Value = hLegalTwelveItemVo.StaffSign;
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHLegalTwelveItem
        /// </summary>
        /// <param name="oldHLegalTwelveItemVo"></param>
        /// <param name="newHLegalTwelveItemVo"></param>
        /// <returns></returns>
        public int UpdateOneHLegalTwelveItem(H_LegalTwelveItemVo oldHLegalTwelveItemVo, H_LegalTwelveItemVo newHLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_LegalTwelveItem " +
                                     "SET StudentsDate = '" + _defaultValue.GetDefaultValue<DateTime>(newHLegalTwelveItemVo.StudentsDate) + "'," +
                                         "StudentsCode = " + _defaultValue.GetDefaultValue<int>(newHLegalTwelveItemVo.StudentsCode) + "," +
                                         "StudentsFlag = '" + _defaultValue.GetDefaultValue<bool>(newHLegalTwelveItemVo.StudentsFlag) + "'," +
                                         "StaffCode = " + _defaultValue.GetDefaultValue<int>(newHLegalTwelveItemVo.StaffCode) + "," +
                                         "StaffSign = @Picture," +
                                         "SignNumber = " + _defaultValue.GetDefaultValue<int>(newHLegalTwelveItemVo.SignNumber) + "," +
                                         "Memo = '" + _defaultValue.GetDefaultValue<string>(newHLegalTwelveItemVo.Memo) + "'," +
                                         "InsertPcName = '" + _defaultValue.GetDefaultValue<string>(newHLegalTwelveItemVo.InsertPcName) + "'," +
                                         "InsertYmdHms = '" + _defaultValue.GetDefaultValue<DateTime>(newHLegalTwelveItemVo.InsertYmdHms) + "'," +
                                         "UpdatePcName = '" + _defaultValue.GetDefaultValue<string>(newHLegalTwelveItemVo.UpdatePcName) + "'," +
                                         "UpdateYmdHms = '" + _defaultValue.GetDefaultValue<DateTime>(newHLegalTwelveItemVo.UpdateYmdHms) + "'," +
                                         "DeletePcName = '" + _defaultValue.GetDefaultValue<string>(newHLegalTwelveItemVo.DeletePcName) + "'," +
                                         "DeleteYmdHms = '" + _defaultValue.GetDefaultValue<DateTime>(newHLegalTwelveItemVo.DeleteYmdHms) + "'," +
                                         "DeleteFlag = '" + _defaultValue.GetDefaultValue<bool>(newHLegalTwelveItemVo.DeleteFlag) + "' " +
                                     "WHERE (StudentsDate BETWEEN '" + oldHLegalTwelveItemVo.StudentsDate + "' AND '" + oldHLegalTwelveItemVo.StudentsDate + "') " +
                                     "AND StudentsCode = " + oldHLegalTwelveItemVo.StudentsCode + " " +
                                     "AND StaffCode = " + oldHLegalTwelveItemVo.StaffCode;
            if (newHLegalTwelveItemVo.StaffSign is not null)
                sqlCommand.Parameters.Add("@Picture", SqlDbType.Image, newHLegalTwelveItemVo.StaffSign.Length).Value = newHLegalTwelveItemVo.StaffSign;
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteOneLegalTwelveItem
        /// </summary>
        /// <param name="oldHLegalTwelveItemVo"></param>
        /// <returns></returns>
        public int DeleteOneHLegalTwelveItemVo(H_LegalTwelveItemVo oldHLegalTwelveItemVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM H_LegalTwelveItem " +
                                     "WHERE (StudentsDate BETWEEN '" + oldHLegalTwelveItemVo.StudentsDate + "' AND '" + oldHLegalTwelveItemVo.StudentsDate + "') " +
                                     "AND StudentsCode = " + oldHLegalTwelveItemVo.StudentsCode + " " +
                                     "AND StaffCode = " + oldHLegalTwelveItemVo.StaffCode;
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
