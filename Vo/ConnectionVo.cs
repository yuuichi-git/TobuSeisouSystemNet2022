/*
 * 2022/08/22
 */
using System.Data.SqlClient;

using Common;

using Vo.Properties;

namespace Vo {
    public class ConnectionVo {
        /// <summary>
        /// 
        /// </summary>
        private SqlConnection _connection = new();
        /// <summary>
        /// 
        /// </summary>
        private string? _serverName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConnectionVo() {
            _serverName = null;
        }

        /// <summary>
        /// Dbへ接続
        /// </summary>
        /// <returns></returns>
        public void Connect() {
            switch (Environment.MachineName) {
                case "LAPTOP-LI7NSQIT":
                    _serverName = new PingResponse().GetPingResponse("192.168.1.88") ? "192.168.1.88" : "(Local)";
                    break;
                default:
                    _serverName = "192.168.1.88"; // 本番サーバーアドレス
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
