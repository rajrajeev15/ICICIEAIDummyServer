using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.Model
{
    public class ServerSettings : INotifyPropertyChanged
    {
        int _port;
        bool _sendSuccess;
        bool _sendServerDown;
        bool _sendServerTimedout;

        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Port"));
            }
        }
        public bool SendSuccess
        {
            get
            {
                return _sendSuccess;
            }
            set
            {
                _sendSuccess = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SendSuccess"));
            }
        }
        public bool SendServerDown
        {
            get
            {
                return _sendServerDown;
            }
            set
            {
                _sendServerDown = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SendServerDown"));
            }
        }
        public bool SendServerTimedout
        {
            get
            {
                return _sendServerTimedout;
            }
            set
            {
                _sendServerTimedout = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SendServerTimedout"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
