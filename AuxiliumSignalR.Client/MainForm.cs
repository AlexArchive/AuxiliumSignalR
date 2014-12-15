using System;
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
            serverProxy.On<string, string>("AddMessage", (username, message) =>
                Invoke(new Action(() => textBoxChat.Text += username + ": " + message)));
            await connection.Start();

            panel2.Enabled = false;
            panel1.Enabled = true;
        }

        private void buttonSend_Click(object sender, System.EventArgs e)
        {
            serverProxy.Invoke("Broadcast", textBoxUsername.Text, textBoxMessage.Text);
        }
    }
}
