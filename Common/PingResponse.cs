using System.Net.NetworkInformation;

namespace Common {
    public class PingResponse {
        /*
         * pingに対して応答があるかチェックする
         */
        public bool GetPingResponse(string ipAddress) {
            var ping = new Ping();
            bool status;

            PingReply reply = ping.Send(ipAddress);
            if (reply.Status == IPStatus.Success) {
                Console.WriteLine("Reply from {0}: bytes={1} time={2}ms TTL={3}",
                                        reply.Address,
                                        reply.Buffer.Length,
                                        reply.RoundtripTime,
                                        reply.Options.Ttl);
                status = true;
            } else {
                Console.WriteLine(reply.Status);
                status = false;
            }
            return status;
        }
    }
}
