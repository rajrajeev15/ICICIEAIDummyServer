using ICICI.EAI.DummyServer.Model;
using ICICI.EAI.DummyServer.MVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ICICI.EAI.DummyServer.UI.WinFormsClient
{
    public partial class DummyServerMain : Form, IDummyServerView
    {
        IDummyServerPresenter _presenter;
        List<ServerSettingRow> _serverSettingRow;

        public DummyServerMain()
        {
            InitializeComponent();
            _serverSettingRow = new List<ServerSettingRow>(10);

            var mvpContainer = GlobalConfiguration.Container.CreateChildContainer();
            mvpContainer.RegisterInstance<IDummyServerView>(this);
            _presenter = mvpContainer.Resolve<IDummyServerPresenter>();
            _presenter.GetServerSettings();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }

        public List<ServerSettings> ServerSettings
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                var serverSettings = value;
                foreach (var serverSetting in serverSettings)
                {
                    serverSetting.PropertyChanged += serverSetting_PropertyChanged;
                    var serverSettingRow = new ServerSettingRow
                    {
                        PortNumber = new Label(),
                        OperationGroup = new GroupBox(),
                        SendServerDead = new RadioButton(),
                        SendSuccess = new RadioButton(),
                        SendTimeOut = new RadioButton()
                    };

                    serverSettingRow.PortNumber.Text = string.Format("IP: {0}", serverSetting.Port);
                    serverSettingRow.SendServerDead.Text = "Server Dead";
                    serverSettingRow.SendServerDead.Click += SendServerDead_Click;
                    serverSettingRow.SendSuccess.Text = "Send Success";
                    serverSettingRow.SendTimeOut.Text = "Send Timeout";

                    // add control to group

                    this.Controls.Add(serverSettingRow.PortNumber);
                    this.Controls.Add(serverSettingRow.SendServerDead);
                    this.Controls.Add(serverSettingRow.SendSuccess);
                    this.Controls.Add(serverSettingRow.SendTimeOut);

                    _serverSettingRow.Add(serverSettingRow);
                }
            }
        }

        void serverSetting_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void SendServerDead_Click(object sender, EventArgs e)
        {

        }
    }
}
