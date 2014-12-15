using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace AuxiliumSignalR.Sever
{
    public class AuxiliumHub : Hub
    {
        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
    }
}