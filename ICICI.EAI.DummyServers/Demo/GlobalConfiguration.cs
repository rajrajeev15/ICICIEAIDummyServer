using ICICI.EAI.DummyServer.MVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Unity;

namespace ICICI.EAI.DummyServer.UI.WinFormsClient
{
    static class GlobalConfiguration
    {
        static IUnityContainer _container = new UnityContainer();

        internal static void Register()
        {
            _container.RegisterType<IDummyServerPresenter, DummyServerPresenter>();
            _container.RegisterType<DummyServerMain, DummyServerMain>();
        }

        public static IUnityContainer Container { get { return _container; } }
    }
}
