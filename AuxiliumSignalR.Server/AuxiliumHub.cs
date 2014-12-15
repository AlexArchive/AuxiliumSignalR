using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Auxilium.Sever
{
    public class AuxiliumHub : Hub
    {
        public void Broadcast(string username, string message)
        {
            Clients.All.addMessage(username, message);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}