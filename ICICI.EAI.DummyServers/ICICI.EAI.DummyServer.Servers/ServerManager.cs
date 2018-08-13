using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.Servers
{
    class ServerManager
    {
        static Dictionary<int, Server> _servers;

        public static void StartServer(int port)
        {
            Task.Run(async () =>
            {
                await _servers[port].StartAsync();
            });

        }
        public static void StopServer(int port)
        {
            _servers[port].Stop();
        }

        public static void SleepServer(int port)
        {
            _servers[port].SleepResponse = async () => await Task.Delay(3000);
        }

        void SuccessResponse(int port)
        {
            _servers[port].SleepResponse = null;
        }
    }
}
