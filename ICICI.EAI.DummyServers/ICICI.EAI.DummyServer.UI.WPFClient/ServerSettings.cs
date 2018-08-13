using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.UI.WPFClient
{
    public class ServerSettings : INotifyPropertyChanged
    {
        IPAddress _ipAddress;
        int _port;
        bool _successChecked;
        bool _failureChecked;
        bool _delayChecked;

        public IPAddress IPAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("IPAddress"));
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("Port"));
            }
        }
        public bool SuccessChecked
        {
            get
            {
                return _successChecked;
            }
            set
            {
                _successChecked = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("SuccessChecked"));
            }
        }
        public bool FailureChecked
        {
            get
            {
                return _failureChecked;
            }
            set
            {
                _failureChecked = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("FailureChecked"));
            }
        }
        public bool DelayChecked
        {
            get
            {
                return _delayChecked;
            }
            set
            {
                _delayChecked = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("DelayChecked"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
