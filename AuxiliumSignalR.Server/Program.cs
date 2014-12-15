using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Owin.Hosting;

namespace AuxiliumSignalR.Sever
{
    class Program
    {
        private static void Main()
        {
            try
            {
                WebApp.Start("http://localhost:8080");
            }
            catch (TargetInvocationException)
            {
                Console.WriteLine("You are already running a server. Noob.");
                return;
            }

            Console.WriteLine("Server started..");
            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
