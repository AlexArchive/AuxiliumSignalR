using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace AuxiliumSignalR.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void buttonConnect_Click(object sender, System.EventArgs e)
        {
            var connection = new HubConnection("http://localhost:8080/signalr");
            connection.CreateHubProxy("AuxiliumHub");
            await connection.Start();
        }
    }
}
