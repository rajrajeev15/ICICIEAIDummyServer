using ICICI.EAI.DummyServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.MVP
{
    public interface IDummyServerView
    {
        List<ServerSettings> ServerSettings { get; set; }
    }
}
