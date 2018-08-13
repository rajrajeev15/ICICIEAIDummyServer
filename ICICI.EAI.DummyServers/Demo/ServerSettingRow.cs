using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICICI.EAI.DummyServer.UI.WinFormsClient
{
    internal class ServerSettingRow
    {
        public Label PortNumber { get; set; }
        public GroupBox OperationGroup { get; set; }
        public RadioButton SendSuccess { get; set; }
        public RadioButton SendTimeOut { get; set; }
        public RadioButton SendServerDead { get; set; }
    }
}
