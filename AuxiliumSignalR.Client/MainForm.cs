using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace AuxiliumSignalR.Client
{
    public partial class MainForm : Form
    {
        private IHubProxy serverProxy;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void buttonConnect_Click(object sender, System.EventArgs e)
        {
            var connection = new HubConnection("http://localhost:8080/signalr");
            serverProxy = connection.CreateHubProxy("AuxiliumHub");
            await connection.Start();
        }

        private void buttonSend_Click(object sender, System.EventArgs e)
        {
            serverProxy.Invoke("Broadcast", textBoxMessage.Text);
        }
    }
}
