using ICICI.EAI.DummyServer.Model;
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

namespace ICICI.EAI.DummyServer.Servers
{
    public class Program
    {
        static Dictionary<int, ServerSettings> _serverSettings =
            new Dictionary<int, ServerSettings>();

        static Dictionary<int, Server> _servers = new Dictionary<int, Server>();

        static void Main(string[] args)
        {
            IReadOnlyList<int> ports = new List<int> { 
            9901,
            9902,
            9903,
            9904,
            9905,
            9906,
            9907,
            9908,
            9909,
            9910,
            9911,
            9912};
            var ipAddress = GetLocalIPAddress();
            Action action = () =>
            {
                Thread.Sleep(5000);
            };

            Parallel.ForEach(ports, async (port) =>
            {
                var server = new Server(ipAddress, port);
                _servers.Add(port, server);
                var setting = GetSettingsForPort(port);
                _serverSettings.Add(port, setting);

                setting.PropertyChanged += setting_PropertyChanged;
                server.SleepResponse = setting.SendServerTimedout == true ? action : null;
                server.SuccessResponse = setting.SendSuccess == true ? GetSuccessResponse(port) : null;
                if (setting.SendServerDown == false) await server.StartAsync();
            });

            Task.Run(
                async () =>
                {
                    var port = 10;
                    var server = new Server(ipAddress, port);
                    _servers.Add(port, server);
                    var setting = GetSettingsForPort(port);
                    server.SleepResponse = setting.SendServerTimedout == true ? action : null;
                    server.SuccessResponse = setting.SendSuccess == true ? GetSuccessResponse(port) : null;
                    if (setting.SendServerDown == false) await server.StartAsync();
                });

            Console.WriteLine("Press Enter to stop servers");
            Console.ReadLine();
        }

        static void setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var port = 9902;
            var server = _servers[port];
            server.Stop();

            server.SuccessResponse = null;
        }

        private static Func<string> GetSuccessResponse(int port)
        {
            Dictionary<int, string> _successXmls = new Dictionary<int, string>();
            _successXmls.Add(port, "<xml></xml>");
            var successXml = _successXmls.Where(x => x.Key == port).First().Value;

            return () => { return successXml; };
        }

        private static ServerSettings GetSettingsForPort(int port)
        {
            return _serverSettings.Where(x => x.Key == port).First().Value;
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
