using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ICICI.EAI.DummyServer.UI.WinFormsClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalConfiguration.Register();
            Application.Run(GlobalConfiguration.Container.Resolve<DummyServerMain>());
        }
    }
}
