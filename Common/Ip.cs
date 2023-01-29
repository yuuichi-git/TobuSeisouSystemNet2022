using System.Net;
using System.Net.Sockets;
namespace Common {
    public class Ip {
        public string GetIpAddress() {
            //IPアドレス用変数
            string ip = "";

            //自身のIPアドレスの一覧を取得する
            string hostname = Dns.GetHostName();
            IPAddress[] ips = Dns.GetHostAddresses(hostname);

            //一覧からIPv4アドレスのみ抽出する
            foreach(IPAddress iPAddress in ips) {
                //IPv4を対象とする
                if(iPAddress.AddressFamily.Equals(AddressFamily.InterNetwork)) {
                    ip = iPAddress.ToString();
                    break;
                }
            }
            return ip;
        }
    }
}

