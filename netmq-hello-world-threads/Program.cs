using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NetMQHelloWorldThreads
{
    class Program
    {
        public static async Task Main()
        {
            Server server = new Server();
            Task serverTask = server.RunAsync();

            IEnumerable<Client> clients =
                Enumerable.Range(0, 10).Select(num => new Client($"{num}"));

            foreach (Client client in clients)
            {
                // supress the missing await warning
                var _ = client.RunAsync().ConfigureAwait(false);
            }
            Console.WriteLine("Welcome!");
            await serverTask;
        }
    }
}
