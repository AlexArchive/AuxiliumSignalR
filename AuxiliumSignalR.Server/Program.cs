using System;
using System.Diagnostics;
using Microsoft.Owin.Hosting;

namespace AuxiliumSignalR.Sever
{
    class Program
    {
        private static void Main()
        {
            WebApp.Start("http://localhost:8080");
            Console.WriteLine("Server started..");
            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
