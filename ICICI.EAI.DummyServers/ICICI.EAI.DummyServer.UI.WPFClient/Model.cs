using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICICI.EAI.DummyServer.UI.WPFClient
{
    public static class Model
    {
        public static bool IsValid(ServerSettings setting)
        {
            var count = 0;
            if (setting.DelayChecked == true) ++count;
            if (setting.FailureChecked == true) ++count;
            if (setting.SuccessChecked == true) ++count;

            return count == 1 ? true : false;
        }
    }
}
