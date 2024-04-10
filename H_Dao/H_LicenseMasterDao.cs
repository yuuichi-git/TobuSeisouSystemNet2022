/*
 * 2024-02-07
 */
using System.Data;
using System.Data.SqlClient;

using H_Common;

using Vo;

namespace H_Dao {
    public class H_LicenseMasterDao {
        private readonly DefaultValue _defaultValue = new();
        private readonly DateTime _defaultDateTime = new DateTime(1900, 01, 01);
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_LicenseMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// ExistenceHLicenseMaster
        /// 存在確認
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public bool ExistenceHLicenseMaster(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 StaffCode FROM H_LicenseMaster WHERE StaffCode = " + staffCode + "";
            return sqlCommand.ExecuteScalar() is not null ? true : false;
        }

        /// <summary>
        /// GetExpirationDate
        /// 有効期限を取得する
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns>有効期限を返す。存在しない場合はstring.Emptyを返す</returns>
        public string GetExpirationDate(int staffCode) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT TOP 1 ExpirationDate FROM H_LicenseMaster WHERE StaffCode = " + staffCode + "";
            var data = sqlCommand.ExecuteScalar();
            if (data is not null) {
                return sqlCommand.ExecuteScalar().ToString();
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// SelectHLicenseMasterForStaffDetail
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public H_LicenseMasterVo SelectOneHLicenseMaster(int staffCode) {
            H_LicenseMasterVo hLicenseMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "NameKana," +
                                            "Name," +
                                            "BirthDate," +
                                            "CurrentAddress," +
                                            "DeliveryDate," +
                                            "ExpirationDate," +
                                            "LicenseCondition," +
                                            "LicenseNumber," +
                                            "GetDate1," +
                                            "GetDate2," +
                                            "GetDate3," +
                                            "PictureHead," +
                                            "PictureTail," +
                                            "Large," +
                                            "Medium," +
                                            "QuasiMedium," +
                                            "Ordinary," +
                                            "BigSpecial," +
                                            "BigAutoBike," +
                                            "OrdinaryAutoBike," +
                                            "SmallSpecial," +
                                            "WithARaw," +
                                            "BigTwo," +
                                            "MediumTwo," +
                                            "OrdinaryTwo," +
                                            "BigSpecialTwo," +
                                            "Traction," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_LicenseMaster " +
                                     "WHERE StaffCode = " + staffCode + "";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    hLicenseMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hLicenseMasterVo.NameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["NameKana"]);
                    hLicenseMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["Name"]);
                    hLicenseMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hLicenseMasterVo.CurrentAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["CurrentAddress"]);
                    hLicenseMasterVo.DeliveryDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeliveryDate"]);
                    hLicenseMasterVo.ExpirationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["ExpirationDate"]);
                    hLicenseMasterVo.LicenseCondition = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseCondition"]);
                    hLicenseMasterVo.LicenseNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseNumber"]);
                    hLicenseMasterVo.GetDate1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["GetDate1"]);
                    hLicenseMasterVo.GetDate2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["GetDate2"]);
                    hLicenseMasterVo.GetDate3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["GetDate3"]);
                    hLicenseMasterVo.PictureHead = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureHead"]);
                    hLicenseMasterVo.PictureTail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureTail"]);
                    hLicenseMasterVo.Large = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Large"]);
                    hLicenseMasterVo.Medium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Medium"]);
                    hLicenseMasterVo.QuasiMedium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["QuasiMedium"]);
                    hLicenseMasterVo.Ordinary = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Ordinary"]);
                    hLicenseMasterVo.BigSpecial = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigSpecial"]);
                    hLicenseMasterVo.BigAutoBike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigAutoBike"]);
                    hLicenseMasterVo.OrdinaryAutoBike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["OrdinaryAutoBike"]);
                    hLicenseMasterVo.SmallSpecial = _defaultValue.GetDefaultValue<bool>(sqlDataReader["SmallSpecial"]);
                    hLicenseMasterVo.WithARaw = _defaultValue.GetDefaultValue<bool>(sqlDataReader["WithARaw"]);
                    hLicenseMasterVo.BigTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigTwo"]);
                    hLicenseMasterVo.MediumTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["MediumTwo"]);
                    hLicenseMasterVo.OrdinaryTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["OrdinaryTwo"]);
                    hLicenseMasterVo.BigSpecialTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigSpecialTwo"]);
                    hLicenseMasterVo.Traction = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Traction"]);
                    hLicenseMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hLicenseMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hLicenseMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hLicenseMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hLicenseMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hLicenseMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hLicenseMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                }
            }
            return hLicenseMasterVo;
        }

        /// <summary>
        /// SelectAllHLicenseMaster
        /// PictureHead/PictureTail無し
        /// </summary>
        /// <returns></returns>
        public List<H_LicenseMasterVo> SelectAllHLicenseMaster() {
            List<H_LicenseMasterVo> listHLicenseMasterVo = new();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT StaffCode," +
                                            "NameKana," +
                                            "Name," +
                                            "BirthDate," +
                                            "CurrentAddress," +
                                            "DeliveryDate," +
                                            "ExpirationDate," +
                                            "LicenseCondition," +
                                            "LicenseNumber," +
                                            "GetDate1," +
                                            "GetDate2," +
                                            "GetDate3," +
                                            //"PictureHead," +
                                            //"PictureTail," +
                                            "Large," +
                                            "Medium," +
                                            "QuasiMedium," +
                                            "Ordinary," +
                                            "BigSpecial," +
                                            "BigAutoBike," +
                                            "OrdinaryAutoBike," +
                                            "SmallSpecial," +
                                            "WithARaw," +
                                            "BigTwo," +
                                            "MediumTwo," +
                                            "OrdinaryTwo," +
                                            "BigSpecialTwo," +
                                            "Traction," +
                                            "InsertPcName," +
                                            "InsertYmdHms," +
                                            "UpdatePcName," +
                                            "UpdateYmdHms," +
                                            "DeletePcName," +
                                            "DeleteYmdHms," +
                                            "DeleteFlag " +
                                     "FROM H_LicenseMaster";
            using (var sqlDataReader = sqlCommand.ExecuteReader()) {
                while (sqlDataReader.Read() == true) {
                    H_LicenseMasterVo hLicenseMasterVo = new();
                    hLicenseMasterVo.StaffCode = _defaultValue.GetDefaultValue<int>(sqlDataReader["StaffCode"]);
                    hLicenseMasterVo.NameKana = _defaultValue.GetDefaultValue<string>(sqlDataReader["NameKana"]);
                    hLicenseMasterVo.Name = _defaultValue.GetDefaultValue<string>(sqlDataReader["Name"]);
                    hLicenseMasterVo.BirthDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["BirthDate"]);
                    hLicenseMasterVo.CurrentAddress = _defaultValue.GetDefaultValue<string>(sqlDataReader["CurrentAddress"]);
                    hLicenseMasterVo.DeliveryDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeliveryDate"]);
                    hLicenseMasterVo.ExpirationDate = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["ExpirationDate"]);
                    hLicenseMasterVo.LicenseCondition = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseCondition"]);
                    hLicenseMasterVo.LicenseNumber = _defaultValue.GetDefaultValue<string>(sqlDataReader["LicenseNumber"]);
                    hLicenseMasterVo.GetDate1 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["GetDate1"]);
                    hLicenseMasterVo.GetDate2 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["GetDate2"]);
                    hLicenseMasterVo.GetDate3 = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["GetDate3"]);
                    //hLicenseMasterVo.PictureHead = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureHead"]);
                    //hLicenseMasterVo.PictureTail = _defaultValue.GetDefaultValue<byte[]>(sqlDataReader["PictureTail"]);
                    hLicenseMasterVo.Large = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Large"]);
                    hLicenseMasterVo.Medium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Medium"]);
                    hLicenseMasterVo.QuasiMedium = _defaultValue.GetDefaultValue<bool>(sqlDataReader["QuasiMedium"]);
                    hLicenseMasterVo.Ordinary = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Ordinary"]);
                    hLicenseMasterVo.BigSpecial = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigSpecial"]);
                    hLicenseMasterVo.BigAutoBike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigAutoBike"]);
                    hLicenseMasterVo.OrdinaryAutoBike = _defaultValue.GetDefaultValue<bool>(sqlDataReader["OrdinaryAutoBike"]);
                    hLicenseMasterVo.SmallSpecial = _defaultValue.GetDefaultValue<bool>(sqlDataReader["SmallSpecial"]);
                    hLicenseMasterVo.WithARaw = _defaultValue.GetDefaultValue<bool>(sqlDataReader["WithARaw"]);
                    hLicenseMasterVo.BigTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigTwo"]);
                    hLicenseMasterVo.MediumTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["MediumTwo"]);
                    hLicenseMasterVo.OrdinaryTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["OrdinaryTwo"]);
                    hLicenseMasterVo.BigSpecialTwo = _defaultValue.GetDefaultValue<bool>(sqlDataReader["BigSpecialTwo"]);
                    hLicenseMasterVo.Traction = _defaultValue.GetDefaultValue<bool>(sqlDataReader["Traction"]);
                    hLicenseMasterVo.InsertPcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["InsertPcName"]);
                    hLicenseMasterVo.InsertYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["InsertYmdHms"]);
                    hLicenseMasterVo.UpdatePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["UpdatePcName"]);
                    hLicenseMasterVo.UpdateYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["UpdateYmdHms"]);
                    hLicenseMasterVo.DeletePcName = _defaultValue.GetDefaultValue<string>(sqlDataReader["DeletePcName"]);
                    hLicenseMasterVo.DeleteYmdHms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["DeleteYmdHms"]);
                    hLicenseMasterVo.DeleteFlag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["DeleteFlag"]);
                    listHLicenseMasterVo.Add(hLicenseMasterVo);
                }
            }
            return listHLicenseMasterVo;
        }

        /// <summary>
        /// InsertOneHLicenseMaster
        /// </summary>
        /// <param name="hLicenseMasterVo"></param>
        /// <returns></returns>
        public int InsertOneHLicenseMaster(H_LicenseMasterVo hLicenseMasterVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO H_LicenseMaster(StaffCode," +
                                                                 "NameKana," +
                                                                 "Name," +
                                                                 "BirthDate," +
                                                                 "CurrentAddress," +
                                                                 "DeliveryDate," +
                                                                 "ExpirationDate," +
                                                                 "LicenseCondition," +
                                                                 "LicenseNumber," +
                                                                 "GetDate1," +
                                                                 "GetDate2," +
                                                                 "GetDate3," +
                                                                 "PictureHead," +
                                                                 "PictureTail," +
                                                                 "Large," +
                                                                 "Medium," +
                                                                 "QuasiMedium," +
                                                                 "Ordinary," +
                                                                 "BigSpecial," +
                                                                 "BigAutoBike," +
                                                                 "OrdinaryAutoBike," +
                                                                 "SmallSpecial," +
                                                                 "WithARaw," +
                                                                 "BigTwo," +
                                                                 "MediumTwo," +
                                                                 "OrdinaryTwo," +
                                                                 "BigSpecialTwo," +
                                                                 "Traction," +
                                                                 "InsertPcName," +
                                                                 "InsertYmdHms," +
                                                                 "UpdatePcName," +
                                                                 "UpdateYmdHms," +
                                                                 "DeletePcName," +
                                                                 "DeleteYmdHms," +
                                                                 "DeleteFlag) " +
                                     "VALUES (" + hLicenseMasterVo.StaffCode + "," +
                                            "'" + hLicenseMasterVo.NameKana + "'," +
                                            "'" + hLicenseMasterVo.Name + "'," +
                                            "'" + hLicenseMasterVo.BirthDate + "'," +
                                            "'" + hLicenseMasterVo.CurrentAddress + "'," +
                                            "'" + hLicenseMasterVo.DeliveryDate + "'," +
                                            "'" + hLicenseMasterVo.ExpirationDate + "'," +
                                            "'" + hLicenseMasterVo.LicenseCondition + "'," +
                                            "'" + hLicenseMasterVo.LicenseNumber + "'," +
                                            "'" + hLicenseMasterVo.GetDate1 + "'," +
                                            "'" + hLicenseMasterVo.GetDate2 + "'," +
                                            "'" + hLicenseMasterVo.GetDate3 + "'," +
                                            "@memberPictureHead," +
                                            "@memberPictureTail," +
                                            "'" + hLicenseMasterVo.Large + "'," +
                                            "'" + hLicenseMasterVo.Medium + "'," +
                                            "'" + hLicenseMasterVo.QuasiMedium + "'," +
                                            "'" + hLicenseMasterVo.Ordinary + "'," +
                                            "'" + hLicenseMasterVo.BigSpecial + "'," +
                                            "'" + hLicenseMasterVo.BigAutoBike + "'," +
                                            "'" + hLicenseMasterVo.OrdinaryAutoBike + "'," +
                                            "'" + hLicenseMasterVo.SmallSpecial + "'," +
                                            "'" + hLicenseMasterVo.WithARaw + "'," +
                                            "'" + hLicenseMasterVo.BigTwo + "'," +
                                            "'" + hLicenseMasterVo.MediumTwo + "'," +
                                            "'" + hLicenseMasterVo.OrdinaryTwo + "'," +
                                            "'" + hLicenseMasterVo.BigSpecialTwo + "'," +
                                            "'" + hLicenseMasterVo.Traction + "'," +
                                            "'" + Environment.MachineName + "'," +
                                            "'" + DateTime.Now + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'" + string.Empty + "'," +
                                            "'" + _defaultDateTime + "'," +
                                            "'false'" +
                                            ");";
            try {
                sqlCommand.Parameters.Add("@memberPictureHead", SqlDbType.Image, hLicenseMasterVo.PictureHead.Length).Value = hLicenseMasterVo.PictureHead;
                sqlCommand.Parameters.Add("@memberPictureTail", SqlDbType.Image, hLicenseMasterVo.PictureTail.Length).Value = hLicenseMasterVo.PictureTail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateOneHLicenseLedger
        /// </summary>
        /// <param name="hLicenseMasterVo"></param>
        /// <returns></returns>
        public int UpdateOneHLicenseLedger(H_LicenseMasterVo hLicenseMasterVo) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE H_LicenseMaster " +
                                     "SET StaffCode = " + hLicenseMasterVo.StaffCode + "," +
                                         "NameKana = '" + hLicenseMasterVo.NameKana + "'," +
                                         "Name = '" + hLicenseMasterVo.Name + "'," +
                                         "BirthDate = '" + hLicenseMasterVo.BirthDate + "'," +
                                         "CurrentAddress = '" + hLicenseMasterVo.CurrentAddress + "'," +
                                         "DeliveryDate = '" + hLicenseMasterVo.DeliveryDate + "'," +
                                         "ExpirationDate = '" + hLicenseMasterVo.ExpirationDate + "'," +
                                         "LicenseCondition = '" + hLicenseMasterVo.LicenseCondition + "'," +
                                         "LicenseNumber = '" + hLicenseMasterVo.LicenseNumber + "'," +
                                         "GetDate1 = '" + hLicenseMasterVo.GetDate1 + "'," +
                                         "GetDate2 = '" + hLicenseMasterVo.GetDate2 + "'," +
                                         "GetDate3 = '" + hLicenseMasterVo.GetDate3 + "'," +
                                         "PictureHead = @memberPictureHead," +
                                         "PictureTail = @memberPictureTail," +
                                         "Large = '" + hLicenseMasterVo.Large + "'," +
                                         "Medium = '" + hLicenseMasterVo.Medium + "'," +
                                         "QuasiMedium = '" + hLicenseMasterVo.QuasiMedium + "'," +
                                         "Ordinary = '" + hLicenseMasterVo.Ordinary + "'," +
                                         "BigSpecial = '" + hLicenseMasterVo.BigSpecial + "'," +
                                         "BigAutoBike = '" + hLicenseMasterVo.BigAutoBike + "'," +
                                         "OrdinaryAutoBike = '" + hLicenseMasterVo.OrdinaryAutoBike + "'," +
                                         "SmallSpecial = '" + hLicenseMasterVo.SmallSpecial + "'," +
                                         "WithARaw = '" + hLicenseMasterVo.WithARaw + "'," +
                                         "BigTwo = '" + hLicenseMasterVo.BigTwo + "'," +
                                         "MediumTwo = '" + hLicenseMasterVo.MediumTwo + "'," +
                                         "OrdinaryTwo = '" + hLicenseMasterVo.OrdinaryTwo + "'," +
                                         "BigSpecialTwo = '" + hLicenseMasterVo.BigSpecialTwo + "'," +
                                         "Traction = '" + hLicenseMasterVo.Traction + "'," +
                                         "UpdatePcName = '" + Environment.MachineName + "'," +
                                         "UpdateYmdHms = '" + DateTime.Now + "' " +
                                     "WHERE StaffCode = " + hLicenseMasterVo.StaffCode;
            try {
                sqlCommand.Parameters.Add("@memberPictureHead", SqlDbType.Image, hLicenseMasterVo.PictureHead.Length).Value = hLicenseMasterVo.PictureHead;
                sqlCommand.Parameters.Add("@memberPictureTail", SqlDbType.Image, hLicenseMasterVo.PictureTail.Length).Value = hLicenseMasterVo.PictureTail;
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
