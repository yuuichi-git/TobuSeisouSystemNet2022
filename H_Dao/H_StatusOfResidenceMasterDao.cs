/*
 * 2024-04-10
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using H_Vo;

using Vo;

namespace H_Dao {
    public class H_StatusOfResidenceMasterDao {
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StatusOfResidenceMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHStatusOfResidenceMaster
        /// true:存在する false:存在しない
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public bool ExistenceHStatusOfResidenceMaster(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 StaffCode FROM H_StatusOfResidenceMaster WHERE StaffCode = " + staffCode + "";
            return sqlCommand.ExecuteScalar() is not null ? true : false;
        }

        /// <summary>
        /// SelectOneHStatusOfResidenceMaster
        /// Picture有
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public H_StatusOfResidenceMasterVo SelectOneHStatusOfResidenceMasterP(int staffCode) {
            H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "StaffNameKana," +
                                            "StaffName," +
                                            "BirthDate," +
                                            "Gender," +
                                            "Nationality," +
                                            "Address," +
                                            "StatusOfResidence," +
                                            "WorkLimit," +
                                            "PeriodDate," +
                                            "DeadlineDate," +
                                            "PictureHead," +
                                            "PictureTail," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StatusOfResidenceMaster " +
                                     "WHERE StaffCode = " + staffCode;
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hStatusOfResidenceMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStatusOfResidenceMasterVo.StaffNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffNameKana"]);
                    hStatusOfResidenceMasterVo.StaffName = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffName"]);
                    hStatusOfResidenceMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStatusOfResidenceMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["Gender"]);
                    hStatusOfResidenceMasterVo.Nationality = _defaultValue.GetDefaultValue<string>(sqlDataReader["Nationality"]);
                    hStatusOfResidenceMasterVo.Address = _defaultValue.GetDefaultValue<string>(sqlDataReader["Address"]);
                    hStatusOfResidenceMasterVo.StatusOfResidence = _defaultValue.GetDefaultValue<string>(sqlDataReader["StatusOfResidence"]);
                    hStatusOfResidenceMasterVo.WorkLimit = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkLimit"]);
                    hStatusOfResidenceMasterVo.PeriodDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["PeriodDate"]);
                    hStatusOfResidenceMasterVo.DeadlineDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeadlineDate"]);
                    hStatusOfResidenceMasterVo.PictureHead = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureHead"]);
                    hStatusOfResidenceMasterVo.PictureTail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureTail"]);
                    hStatusOfResidenceMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStatusOfResidenceMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStatusOfResidenceMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStatusOfResidenceMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStatusOfResidenceMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStatusOfResidenceMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStatusOfResidenceMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hStatusOfResidenceMasterVo;
        }

        /// <summary>
        /// SelectAllHStatusOfResidenceMaster
        /// Picture無
        /// </summary>
        /// <returns></returns>
        public List<H_StatusOfResidenceMasterVo> SelectAllHStatusOfResidenceMaster() {
            List<H_StatusOfResidenceMasterVo> listHStatusOfResidenceMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "StaffNameKana," +
                                            "StaffName," +
                                            "BirthDate," +
                                            "Gender," +
                                            "Nationality," +
                                            "Address," +
                                            "StatusOfResidence," +
                                            "WorkLimit," +
                                            "PeriodDate," +
                                            "DeadlineDate," +
                                            //"PictureHead," +
                                            //"PictureTail," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StatusOfResidenceMaster";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo = new();
                    hStatusOfResidenceMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStatusOfResidenceMasterVo.StaffNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffNameKana"]);
                    hStatusOfResidenceMasterVo.StaffName = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffName"]);
                    hStatusOfResidenceMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStatusOfResidenceMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["Gender"]);
                    hStatusOfResidenceMasterVo.Nationality = _defaultValue.GetDefaultValue<string>(sqlDataReader["Nationality"]);
                    hStatusOfResidenceMasterVo.Address = _defaultValue.GetDefaultValue<string>(sqlDataReader["Address"]);
                    hStatusOfResidenceMasterVo.StatusOfResidence = _defaultValue.GetDefaultValue<string>(sqlDataReader["StatusOfResidence"]);
                    hStatusOfResidenceMasterVo.WorkLimit = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkLimit"]);
                    hStatusOfResidenceMasterVo.PeriodDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["PeriodDate"]);
                    hStatusOfResidenceMasterVo.DeadlineDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeadlineDate"]);
                    //hStatusOfResidenceMasterVo.PictureHead = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureHead"]);
                    //hStatusOfResidenceMasterVo.PictureTail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureTail"]);
                    hStatusOfResidenceMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStatusOfResidenceMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStatusOfResidenceMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStatusOfResidenceMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStatusOfResidenceMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStatusOfResidenceMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStatusOfResidenceMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStatusOfResidenceMasterVo.Add(hStatusOfResidenceMasterVo);
                }
            }
            return listHStatusOfResidenceMasterVo;
        }

        /// <summary>
        /// SelectAllHStatusOfResidenceMasterP
        /// Picture有
        /// </summary>
        /// <returns></returns>
        public List<H_StatusOfResidenceMasterVo> SelectAllHStatusOfResidenceMasterP() {
            List<H_StatusOfResidenceMasterVo> listHStatusOfResidenceMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "StaffNameKana," +
                                            "StaffName," +
                                            "BirthDate," +
                                            "Gender," +
                                            "Nationality," +
                                            "Address," +
                                            "StatusOfResidence," +
                                            "WorkLimit," +
                                            "PeriodDate," +
                                            "DeadlineDate," +
                                            "PictureHead," +
                                            "PictureTail," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_StatusOfResidenceMaster";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo = new();
                    hStatusOfResidenceMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hStatusOfResidenceMasterVo.StaffNameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffNameKana"]);
                    hStatusOfResidenceMasterVo.StaffName = _defaultValue.GetDefaultValue<string>(sqlDataReader["StaffName"]);
                    hStatusOfResidenceMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hStatusOfResidenceMasterVo.Gender = _defaultValue.GetDefaultValue<string>(sqlDataReader["Gender"]);
                    hStatusOfResidenceMasterVo.Nationality = _defaultValue.GetDefaultValue<string>(sqlDataReader["Nationality"]);
                    hStatusOfResidenceMasterVo.Address = _defaultValue.GetDefaultValue<string>(sqlDataReader["Address"]);
                    hStatusOfResidenceMasterVo.StatusOfResidence = _defaultValue.GetDefaultValue<string>(sqlDataReader["StatusOfResidence"]);
                    hStatusOfResidenceMasterVo.WorkLimit = _defaultValue.GetDefaultValue<string>(sqlDataReader["WorkLimit"]);
                    hStatusOfResidenceMasterVo.PeriodDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["PeriodDate"]);
                    hStatusOfResidenceMasterVo.DeadlineDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeadlineDate"]);
                    hStatusOfResidenceMasterVo.PictureHead = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureHead"]);
                    hStatusOfResidenceMasterVo.PictureTail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureTail"]);
                    hStatusOfResidenceMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hStatusOfResidenceMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hStatusOfResidenceMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hStatusOfResidenceMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hStatusOfResidenceMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hStatusOfResidenceMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hStatusOfResidenceMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHStatusOfResidenceMasterVo.Add(hStatusOfResidenceMasterVo);
                }
            }
            return listHStatusOfResidenceMasterVo;
        }

        /// <summary>
        /// InsertOneStatusOfHStatusOfResidenceMaster
        /// </summary>
        /// <param name="hStatusOfResidenceMasterVo"></param>
        /// <returns></returns>
        public int InsertOneHStatusOfResidenceMaster(H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_StatusOfResidenceMaster(StaffCode," +
                                                                           "StaffNameKana," +
                                                                           "StaffName," +
                                                                           "BirthDate," +
                                                                           "Gender," +
                                                                           "Nationality," +
                                                                           "Address," +
                                                                           "StatusOfResidence," +
                                                                           "WorkLimit," +
                                                                           "PeriodDate," +
                                                                           "DeadlineDate," +
                                                                           "PictureHead," +
                                                                           "PictureTail," +
                                                                           "InsertPcName," +
                                                                           "InsertYmdHms," +
                                                                           "UpdatePcName," +
                                                                           "UpdateYmdHms," +
                                                                           "DeletePcName," +
                                                                           "DeleteYmdHms," +
                                                                           "DeleteFlag) " +
                                     "VALUES (" + hStatusOfResidenceMasterVo.StaffCode + "," +
                                            "'" + hStatusOfResidenceMasterVo.StaffNameKana + "'," +
                                            "'" + hStatusOfResidenceMasterVo.StaffName + "'," +
                                            "'" + hStatusOfResidenceMasterVo.BirthDate + "'," +
                                            "'" + hStatusOfResidenceMasterVo.Gender + "'," +
                                            "'" + hStatusOfResidenceMasterVo.Nationality + "'," +
                                            "'" + hStatusOfResidenceMasterVo.Address + "'," +
                                            "'" + hStatusOfResidenceMasterVo.StatusOfResidence + "'," +
                                            "'" + hStatusOfResidenceMasterVo.WorkLimit + "'," +
                                            "'" + hStatusOfResidenceMasterVo.PeriodDate + "'," +
                                            "'" + hStatusOfResidenceMasterVo.DeadlineDate + "'," +
                                            "@memberPictureHead," +
                                            "@memberPictureTail," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'false'" +
                                            ");";
            try {
                sqlCommand.Parameters.Add("@memberPictureHead", SqlDbType.Image, hStatusOfResidenceMasterVo.PictureHead.Length).Value = hStatusOfResidenceMasterVo.PictureHead;
                sqlCommand.Parameters.Add("@memberPictureTail", SqlDbType.Image, hStatusOfResidenceMasterVo.PictureTail.Length).Value = hStatusOfResidenceMasterVo.PictureTail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHStatusOfResidenceMaster
        /// </summary>
        /// <param name="hStatusOfResidenceMasterVo"></param>
        /// <returns></returns>
        public int UpdateOneHStatusOfResidenceMaster(H_StatusOfResidenceMasterVo hStatusOfResidenceMasterVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_StatusOfResidenceMaster " +
                                     "SET StaffCode = " + hStatusOfResidenceMasterVo.StaffCode + "," +
                                         "StaffNameKana = '" + hStatusOfResidenceMasterVo.StaffNameKana + "'," +
                                         "StaffName = '" + hStatusOfResidenceMasterVo.StaffName + "'," +
                                         "BirthDate = '" + hStatusOfResidenceMasterVo.BirthDate + "'," +
                                         "Gender = '" + hStatusOfResidenceMasterVo.Gender + "'," +
                                         "Nationality = '" + hStatusOfResidenceMasterVo.Nationality + "'," +
                                         "Address = '" + hStatusOfResidenceMasterVo.Address + "'," +
                                         "StatusOfResidence = '" + hStatusOfResidenceMasterVo.StatusOfResidence + "'," +
                                         "WorkLimit = '" + hStatusOfResidenceMasterVo.WorkLimit + "'," +
                                         "PeriodDate = '" + hStatusOfResidenceMasterVo.PeriodDate + "'," +
                                         "DeadlineDate = '" + hStatusOfResidenceMasterVo.DeadlineDate + "'," +
                                         "PictureHead = @memberPictureHead," +
                                         "PictureTail = @memberPictureTail," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE StaffCode = " + hStatusOfResidenceMasterVo.StaffCode;
            try {
                sqlCommand.Parameters.Add("@memberPictureHead", SqlDbType.Image, hStatusOfResidenceMasterVo.PictureHead.Length).Value = hStatusOfResidenceMasterVo.PictureHead;
                sqlCommand.Parameters.Add("@memberPictureTail", SqlDbType.Image, hStatusOfResidenceMasterVo.PictureTail.Length).Value = hStatusOfResidenceMasterVo.PictureTail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DeleteOneHStatusOfResidenceMaster
        /// </summary>
        /// <param name="staffCode"></param>
        public void DeleteOneHStatusOfResidenceMaster(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_StatusOfResidenceMaster " +
                                     "SET DeletePcName = '" + Environment.MachineName + "'," +
                                         "DeleteYmdHms = '" + DateTime.Now + "'," +
                                         "DeleteFlag = 'true' " +
                                     "WHERE StaffCode = " + staffCode;
            try {
                sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }


    }
}
