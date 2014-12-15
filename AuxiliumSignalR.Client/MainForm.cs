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

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            var connection = new HubConnection("http://localhost:8080/signalr");
            serverProxy = connection.CreateHubProxy("AuxiliumHub");
            serverProxy.On<string, string>("AddMessage", MessageReceived);
            await connection.Start();

            panelAuth.Enabled = false;
            panelChat.Enabled = true;
        }

        private void MessageReceived(string username, string message)
        {
            Invoke(new Action(() =>
                textBoxChat.Text += username + ": " + message));
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            serverProxy.Invoke("Broadcast", 
                textBoxUsername.Text, 
                textBoxMessage.Text += Environment.NewLine);
            textBoxMessage.Clear();
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonSend.PerformClick();
        }
    }
}
