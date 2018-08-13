using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICICI.EAI.DummyServer.Model;

namespace ICICI.EAI.DummyServer.MVP
{
    public interface IDummyServerPresenter
    {
        // TODO: Think of a better name
        void GetServerSettings();
        void UpdateServerResponse();
    }
}
