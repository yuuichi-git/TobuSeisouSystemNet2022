/*
 * 2023-08-01
 */
using System.Data.SqlClient;

using Common;

using Vo;

namespace Dao {
    public class CollectionWeightTaitouDao {
        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CollectionWeightTaitouDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }

        /// <summary>
        /// CheckCollectionWeightTaitou
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool CheckCollectionWeightTaitou(DateTime dateTime) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT COUNT(operation_date) " +
                                     "FROM collection_weight_taitou " +
                                     "WHERE operation_date = '" + dateTime.Date + "'";
            try {
                return (int)sqlCommand.ExecuteScalar() > 0 ? true : false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// SelectCollectionWeightTaitou
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public CollectionWeightTaitouVo SelectCollectionWeightTaitou(DateTime dateTime) {
            CollectionWeightTaitouVo collectionWeightTaitouVo = new CollectionWeightTaitouVo();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operation_date," +
                                            "weight_1_total," +
                                            "weight_2_total," +
                                            "weight_3_total," +
                                            "weight_4_total," +
                                            "weight_5_total," +
                                            "weight_6_total," +
                                            "weight_7_total," +
                                            "insert_pc_name," +
                                            "insert_ymd_hms," +
                                            "update_pc_name," +
                                            "update_ymd_hms," +
                                            "delete_pc_name," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM collection_weight_taitou " +
                                     "WHERE operation_date = '" + dateTime.Date + "'";
            using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                while(sqlDataReader.Read() == true) {
                    collectionWeightTaitouVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                    collectionWeightTaitouVo.Weight1Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_1_total"]);
                    collectionWeightTaitouVo.Weight2Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_2_total"]);
                    collectionWeightTaitouVo.Weight3Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_3_total"]);
                    collectionWeightTaitouVo.Weight4Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_4_total"]);
                    collectionWeightTaitouVo.Weight5Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_5_total"]);
                    collectionWeightTaitouVo.Weight6Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_6_total"]);
                    collectionWeightTaitouVo.Weight7Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_7_total"]);
                    collectionWeightTaitouVo.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                    collectionWeightTaitouVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                    collectionWeightTaitouVo.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                    collectionWeightTaitouVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                    collectionWeightTaitouVo.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                    collectionWeightTaitouVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                    collectionWeightTaitouVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                }
            }
            return collectionWeightTaitouVo;
        }

        /// <summary>
        /// SelectListCollectionWeightTaitou
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public List<CollectionWeightTaitouVo> SelectListCollectionWeightTaitou(DateTime dateTime1, DateTime dateTime2) {
            List<CollectionWeightTaitouVo> listCollectionWeightTaitouVo = new List<CollectionWeightTaitouVo>();
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "SELECT operation_date," +
                                            "weight_1_total," +
                                            "weight_2_total," +
                                            "weight_3_total," +
                                            "weight_4_total," +
                                            "weight_5_total," +
                                            "weight_6_total," +
                                            "weight_7_total," +
                                            "insert_pc_name," +
                                            "insert_ymd_hms," +
                                            "update_pc_name," +
                                            "update_ymd_hms," +
                                            "delete_pc_name," +
                                            "delete_ymd_hms," +
                                            "delete_flag " +
                                     "FROM collection_weight_taitou " +
                                     "WHERE operation_date BETWEEN '" + dateTime1.Date + "' AND '" + dateTime2.Date + "'";
            try {
                using(var sqlDataReader = sqlCommand.ExecuteReader()) {
                    while(sqlDataReader.Read() == true) {
                        CollectionWeightTaitouVo collectionWeightTaitouVo = new CollectionWeightTaitouVo();
                        collectionWeightTaitouVo.Operation_date = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["operation_date"]);
                        collectionWeightTaitouVo.Weight1Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_1_total"]);
                        collectionWeightTaitouVo.Weight2Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_2_total"]);
                        collectionWeightTaitouVo.Weight3Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_3_total"]);
                        collectionWeightTaitouVo.Weight4Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_4_total"]);
                        collectionWeightTaitouVo.Weight5Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_5_total"]);
                        collectionWeightTaitouVo.Weight6Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_6_total"]);
                        collectionWeightTaitouVo.Weight7Total = _defaultValue.GetDefaultValue<int>(sqlDataReader["weight_7_total"]);
                        collectionWeightTaitouVo.Insert_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["insert_pc_name"]);
                        collectionWeightTaitouVo.Insert_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["insert_ymd_hms"]);
                        collectionWeightTaitouVo.Update_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["update_pc_name"]);
                        collectionWeightTaitouVo.Update_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["update_ymd_hms"]);
                        collectionWeightTaitouVo.Delete_pc_name = _defaultValue.GetDefaultValue<string>(sqlDataReader["delete_pc_name"]);
                        collectionWeightTaitouVo.Delete_ymd_hms = _defaultValue.GetDefaultValue<DateTime>(sqlDataReader["delete_ymd_hms"]);
                        collectionWeightTaitouVo.Delete_flag = _defaultValue.GetDefaultValue<bool>(sqlDataReader["delete_flag"]);
                        listCollectionWeightTaitouVo.Add(collectionWeightTaitouVo);
                    }
                }
                return listCollectionWeightTaitouVo;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// InsertCollectionWeightTaitou
        /// </summary>
        /// <param name="collectionWeightTaitouVo"></param>
        /// <returns></returns>
        public int InsertCollectionWeightTaitou(CollectionWeightTaitouVo collectionWeightTaitouVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO collection_weight_taitou(operation_date," +
                                                                          "weight_1_total," +
                                                                          "weight_2_total," +
                                                                          "weight_3_total," +
                                                                          "weight_4_total," +
                                                                          "weight_5_total," +
                                                                          "weight_6_total," +
                                                                          "weight_7_total," +
                                                                          "insert_pc_name," +
                                                                          "insert_ymd_hms," +
                                                                          "update_pc_name," +
                                                                          "update_ymd_hms," +
                                                                          "delete_pc_name," +
                                                                          "delete_ymd_hms," +
                                                                          "delete_flag) " +
                                     "VALUES ('" + _defaultValue.GetDefaultValue<DateTime>(collectionWeightTaitouVo.Operation_date) + "'," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight1Total) + "," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight2Total) + "," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight3Total) + "," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight4Total) + "," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight5Total) + "," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight6Total) + "," +
                                              "" + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight7Total) + "," +
                                             "'" + _defaultValue.GetDefaultValue<string>(collectionWeightTaitouVo.Insert_pc_name) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(collectionWeightTaitouVo.Insert_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(collectionWeightTaitouVo.Update_pc_name) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(collectionWeightTaitouVo.Update_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<string>(collectionWeightTaitouVo.Delete_pc_name) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<DateTime>(collectionWeightTaitouVo.Delete_ymd_hms) + "'," +
                                             "'" + _defaultValue.GetDefaultValue<bool>(collectionWeightTaitouVo.Delete_flag) + "'" +
                                             ");";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        /// <summary>
        /// UpdateCollectionWeightTaitou
        /// </summary>
        /// <param name="collectionWeightTaitouVo"></param>
        /// <returns></returns>
        public int UpdateCollectionWeightTaitou(CollectionWeightTaitouVo collectionWeightTaitouVo) {
            SqlCommand sqlCommand = _connectionVo.Connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE collection_weight_taitou " +
                                     "SET operation_date = '" + _defaultValue.GetDefaultValue<DateTime>(collectionWeightTaitouVo.Operation_date) + "'," +
                                         "weight_1_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight1Total) + "," +
                                         "weight_2_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight2Total) + "," +
                                         "weight_3_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight3Total) + "," +
                                         "weight_4_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight4Total) + "," +
                                         "weight_5_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight5Total) + "," +
                                         "weight_6_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight6Total) + "," +
                                         "weight_7_total = " + _defaultValue.GetDefaultValue<int>(collectionWeightTaitouVo.Weight7Total) + "," +
                                         "update_pc_name = '" + _defaultValue.GetDefaultValue<string>(collectionWeightTaitouVo.Update_pc_name) + "'," +
                                         "update_ymd_hms = '" + _defaultValue.GetDefaultValue<DateTime>(collectionWeightTaitouVo.Update_ymd_hms) + "' " +
                                     "WHERE operation_date = '" + collectionWeightTaitouVo.Operation_date.Date + "'";
            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
