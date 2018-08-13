using ICICI.EAI.DummyServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.MVP
{
    public class DummyServerPresenter : IDummyServerPresenter
    {
        IDummyServerView _view;

        public DummyServerPresenter(IDummyServerView view)
        {
            _view = view;
        }

        public void GetServerSettings()
        {
            var settings = new List<ServerSettings> { 
                new ServerSettings { Port = 9901, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9902, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9903, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9904, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9905, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9906, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9907, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9908, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9909, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
                new ServerSettings { Port = 9910, SendSuccess = true, SendServerDown = false, SendServerTimedout = false},
            };

            _view.ServerSettings = settings;
        }


        public void UpdateServerResponse()
        {
            // Update action and fun here.
        }
    }
}
