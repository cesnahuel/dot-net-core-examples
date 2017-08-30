using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NetMQHelloWorldThreads
{
    class Program
    {
        static void Main()
        {
            Server server = new Server();
            Task serverTask = server.Run();

            IEnumerable<Client> clients =
                Enumerable.Range(0, 10).Select(num => new Client($"{num}"));

            foreach (Client client in clients)
            {
                client.Run();
            }
            Console.WriteLine("Done!");
            serverTask.Wait();
        }
    }
}
