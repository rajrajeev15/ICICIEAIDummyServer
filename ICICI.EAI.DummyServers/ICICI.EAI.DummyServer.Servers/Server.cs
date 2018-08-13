using ICICI.EAI.DummyServer.Utilities;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.Servers
{
    public class Server
    {
        const int MaxNumberOfPendingConnections = 10;

        static object tcpClientNumberLock = new object();

        TcpListener _listener;
        public Action ServerDeadResponse { get; set; }
        public Action SleepResponse { get; set; }
        public Func<string> SuccessResponse { get; set; }
        int _port;

        CancellationTokenSource _cancellationTokenSource;
        public Server()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public Server(IPAddress ipAddress, int port)
            : this()
        {
            _port = port;
            Validations.ValidArgument(() => ipAddress != null);
            Validations.ValidArgument(() => port > 0);

            _listener = new TcpListener(ipAddress, port);
        }

        async Task StartAsync(CancellationToken token)
        {
            _listener.Start(MaxNumberOfPendingConnections);

            while (!token.IsCancellationRequested)
            {
                Console.WriteLine(string.Format("waiting for incoming socket port:  {0}", _port));
                var tcpClient = await _listener.AcceptTcpClientAsync();
                var stream = tcpClient.GetStream();
                var reader = new StreamReader(stream);

                Console.WriteLine(string.Format("SleepResponse {0}: {1}", _port, SleepResponse != null));
                if (SleepResponse != null)
                    SleepResponse.Invoke();

                var writer = new StreamWriter(stream)
                {
                    AutoFlush = true
                };

                var buffer = new char[128];
                await reader.ReadAsync(buffer, 0, 128);
                var message = new string(buffer);
                Console.WriteLine(string.Format("received {0}:{1}", _port, message));
                var successMessage = SuccessResponse != null ? SuccessResponse.Invoke() : string.Empty;
                await writer.WriteAsync(successMessage.ToCharArray(), 0, successMessage.Length);
                Console.WriteLine(string.Format("Server echoed message {0}: {1}", _port, message));
            }
        }

        public async Task StartAsync()
        {
            await StartAsync(_cancellationTokenSource.Token);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _listener.Stop();
        }
    }
}
