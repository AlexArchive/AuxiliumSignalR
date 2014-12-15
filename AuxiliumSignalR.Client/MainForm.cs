using System;
using System.Net.Http;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace AuxiliumSignalR.Client
{
    public partial class MainForm : Form
    {
        private IHubProxy serverProxy;
        private HubConnection hubConnection;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Enter a username.");
                return;
            }

            hubConnection = new HubConnection("http://localhost:8080/signalr");
            hubConnection.Error += Connection_Error;
            serverProxy = hubConnection.CreateHubProxy("AuxiliumHub");
            serverProxy.On<string, string>("AddMessage", MessageReceived);

            try
            {
                await hubConnection.Start();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Unable to connect to the server.");
                return;
            }

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

        private void Connection_Error(Exception obj)
        {
            MessageBox.Show("Connection lost. Please connect again.");
            Invoke(new Action(() =>
            {
                panelAuth.Enabled = true;
                panelChat.Enabled = false;
                textBoxChat.Clear();
                textBoxMessage.Clear();
            }));
        }
    }
}
