using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace AuxiliumSignalR.Sever
{
    public class AuxiliumHub : Hub
    {
        public void Broadcast(string message)
        {
            Clients.All.addMessage(message);
            Console.WriteLine("Received: " + message);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
    }
}