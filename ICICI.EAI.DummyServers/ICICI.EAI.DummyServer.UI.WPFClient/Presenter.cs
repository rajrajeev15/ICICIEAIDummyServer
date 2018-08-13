using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.UI.WPFClient
{
    public class Presenter
    {
        IPAddress _ipAddress;
        ObservableCollection<ServerSettings> _serverSettings;
        public Presenter()
        {
            _ipAddress = GetLocalIPAddress();
            _serverSettings = new ObservableCollection<ServerSettings>()
            {
                new ServerSettings {IPAddress = _ipAddress, Port = 9901, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9902, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9903, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9904, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9905, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9906, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9907, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9908, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9909, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
                new ServerSettings {IPAddress = _ipAddress, Port = 9910, SuccessChecked = true, FailureChecked = false, DelayChecked = false},
            };

            foreach (var setting in _serverSettings)
            {
                setting.PropertyChanged += ServerSettingsUpdated;
            }
        }

        internal void StopServers()
        {
            throw new NotImplementedException();
        }

        internal void StartServers()
        {
            throw new NotImplementedException();
        }

        void ServerSettingsUpdated(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var setting = sender as ServerSettings;

            if (!Model.IsValid(setting)) return;

            System.Diagnostics.Debug.WriteLine("Port: {0}, SuccessChecked: {1}, FailureChecked : {2}, DelayChecked: {3}", setting.Port, setting.SuccessChecked, setting.FailureChecked, setting.DelayChecked);
        }

        public ObservableCollection<ServerSettings> GetServerSettings()
        {
            return _serverSettings;
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
