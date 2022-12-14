/*
 * 2022/08/22
 */
using System.Data.SqlClient;

using Common;

using Vo.Properties;

namespace Vo {
    public class ConnectionVo {
        /// <summary>
        /// 接続を保持
        /// </summary>
        private SqlConnection _connection = new();
        /// <summary>
        /// 接続先名を保持
        /// </summary>
        private string _serverName = string.Empty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConnectionVo() {
        }

        /// <summary>
        /// Dbへ接続
        /// </summary>
        /// <returns></returns>
        public void Connect() {
            switch (Environment.MachineName) {
                case "LAPTOP-LI7NSQIT":
                    _serverName = new PingResponse().GetPingResponse("192.168.1.21") ? @"TOBUSERVER\SQLEXPRESS" : "(Local)";
                    break;
                default:
                    _serverName = @"TOBUSERVER\SQLEXPRESS"; // 本番サーバーアドレス
                    break;
            }
            string connectionString = "Data Source = " + _serverName + ";"
                                    + "Initial Catalog = " + Resources.DatabaseName + ";"
                                    + "User ID = " + Resources.UserName + ";"
                                    + "Password = " + Resources.UserPassword + ";"
                                    + "MultipleActiveResultSets = True";
            var sqlConnection = new SqlConnection(connectionString);
            try {
                sqlConnection.Open();
                Connection = sqlConnection;
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Dbを切断
        /// </summary>
        /// <returns></returns>
        public void DisConnect() {
            try {
                Connection.Close();
                Connection.Dispose();
            } catch (Exception) {
                throw;
            }
        }

        public SqlConnection Connection {
            get => _connection;
            set => _connection = value;
        }
    }
}
