using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class WardTaitouDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public WardTaitouDao(ConnectionVo connectionVo) {
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// SelectOperationDaysVehicleDispatchDetail
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="setCode"></param>
        /// <returns>int,null</returns>
        public int SelectOperationDaysVehicleDispatchDetail(int year, int month, int setCode) {
            /*
             * 1310602 台東資源1
             * 1310603 台東資源2
             * 1310604 台東資源4
             * 1310606 台東資源臨
             * 1310607 台東資源4(2023年度版)
             */
            DateTime targetYmd = new DateTime(year, month, 01);
            string staYmd = string.Concat(targetYmd.Year, "/",targetYmd.Month, "/01");
            string endYmd = string.Concat(targetYmd.Year, "/",targetYmd.Month, "/", targetYmd.AddMonths(1).AddDays(-1).Day);

            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(set_code) " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date BETWEEN '" + staYmd + "' AND '" + endYmd + "' " +
                                       "AND operation_flag = 'true' " +
                                       "AND set_code = " + setCode + " " +
                                     "GROUP BY set_code";
            int? operationDays = (int?)sqlCommand.ExecuteScalar();
            if(operationDays.HasValue) {
                return (int)operationDays;
            } else {
                return 0;
            }
        }

        /// <summary>
        /// SelectStaffsVehicleDispatchDetail
        /// ３人目の人数を抽出する
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="setCode"></param>
        /// <returns></returns>
        public List<WardTaitouVo> SelectStaffsVehicleDispatchDetail(int year, int month, int setCode) {
            /*
             * 1310602 台東資源1
             * 1310603 台東資源2
             * 1310604 台東資源4
             * 1310606 台東資源臨
             * 1310607 台東資源4(2023年度版)
             */
            DateTime targetYmd = new DateTime(year, month, 01);
            string staYmd = string.Concat(targetYmd.Year, "/",targetYmd.Month, "/01");
            string endYmd = string.Concat(targetYmd.Year, "/",targetYmd.Month, "/", targetYmd.AddMonths(1).AddDays(-1).Day);

            List<WardTaitouVo> listWardTaitouVo = new List<WardTaitouVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT day_of_week," +
                                            "COUNT(operator_code_3) AS COLUMN1 " +
                                     "FROM vehicle_dispatch_detail " +
                                     "WHERE operation_date BETWEEN '" + staYmd + "' AND '" + endYmd + "' " +
                                       "AND operation_flag = 'true' " +
                                       "AND set_code = " + setCode + " " +
                                       "AND operator_code_3 > 0 " +
                                     "GROUP BY day_of_week";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    WardTaitouVo wardTaitouVo = new();
                    wardTaitouVo.Day_of_week = _defaultValue.GetDefaultValue<string>(sqlDataReader["day_of_week"]);
                    wardTaitouVo.Operator_code_3 = _defaultValue.GetDefaultValue<int>(sqlDataReader["COLUMN1"]);
                    listWardTaitouVo.Add(wardTaitouVo);
                }
            }
            return listWardTaitouVo;
        }
    }
}
