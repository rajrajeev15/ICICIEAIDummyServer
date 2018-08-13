using ICICI.EAI.DummyServer.Servers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start client");
            Console.ReadLine();

            var ports = new int[]
            {
                9901,
                9902
            };

            Parallel.ForEach(ports, async (port) =>
            {
                await MainAsync(port);
            });

            Console.WriteLine("Press enter to end client");
            Console.ReadLine();
        }

        private static async Task MainAsync(int port)
        {
            // arrange
            var ipAddress = GetLocalIPAddress();

            var tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(ipAddress, port);

            var stream = tcpClient.GetStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
            var message = string.Format("{0} Message:", DateTime.UtcNow.Ticks);
            await writer.WriteAsync(message.ToCharArray());
            var buffer = new char[32];

            TimeSpan timeout = new TimeSpan(TimeSpan.TicksPerSecond * 2);
            using (var cts = new CancellationTokenSource(timeout))
            {
                Task
                .Run(async () =>
                    {
                        Console.WriteLine("Inside timed reader");
                        await reader.ReadAsync(buffer, 0, 32);
                    })
                .Wait(cts.Token);
            }

            var replyMessage = new string(buffer);
            Console.WriteLine(string.Format("port :{0} replyMessage {1}",port,replyMessage));
        }

        private static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
