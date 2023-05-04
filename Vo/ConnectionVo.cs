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
        /// Connect
        /// </summary>
        /// <param name="localDb">強制的にLocalDBへ接続するかどうかのフラグ</param>
        public void Connect(bool localDb) {
            switch(Environment.MachineName) {
                case "LAPTOP-LI7NSQIT":
                    if(!localDb) { // 自動選択
                        _serverName = new PingResponse().GetPingResponse("192.168.1.21") ? @"TOBUSERVER\SQLEXPRESS" : "(Local)";
                    } else { // LocalDBを選択
                        _serverName = "(Local)";
                    }
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
            } catch {
                throw;
            }
        }

        /// <summary>
        /// DisConnect
        /// Dbを切断
        /// </summary>
        /// <returns></returns>
        public void DisConnect() {
            try {
                Connection.Close();
                Connection.Dispose();
            } catch(Exception) {
                throw;
            }
        }

        public SqlConnection Connection {
            get => _connection;
            set => _connection = value;
        }
    }
}
