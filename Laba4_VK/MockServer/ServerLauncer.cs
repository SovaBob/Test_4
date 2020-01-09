using System;
using System.Threading;

namespace MockServer
{
    public class ServerLauncer
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.WriteLine("Server is started...");
            while (server.IsStart)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("Server is stopped...");
        }
    }
}