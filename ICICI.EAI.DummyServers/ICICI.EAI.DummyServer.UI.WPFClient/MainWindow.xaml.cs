using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICICI.EAI.DummyServer.UI.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Presenter _presenter = new Presenter();
        public ObservableCollection<ServerSettings> Settings { get; set; }
        public MainWindow()
        {
            Settings = _presenter.GetServerSettings();
            InitializeComponent();
            settingsGrid.ItemsSource = Settings;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _presenter.StartServers();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _presenter.StopServers();
        }
    }
}
