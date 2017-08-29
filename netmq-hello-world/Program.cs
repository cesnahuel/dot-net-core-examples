using System;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;


namespace NetMQHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            while (true)
            {
                // specify one ephemeral port
                int port = rand.Next(49152, 65535);
                string address = $"tcp://localhost:{port}";
                try
                {
                    Console.WriteLine($"Trying to use '{address}'");
                    using (var server = new ResponseSocket($"@{address}"))
                    using (var client = new RequestSocket($">{address}"))
                    {
                        while (true)
                        {
                            client.SendFrame("Hello");
                            Console.WriteLine($"From client: {server.ReceiveFrameString()}");

                            server.SendFrame("Hi Back");
                            Console.WriteLine($"From server: {client.ReceiveFrameString()}");

                            Thread.Sleep(1000);
                        }
                    }
                }
                catch(AddressAlreadyInUseException)
                {
                    Console.WriteLine($"This address is in use. Let's pick onther one.");
                }
            }
        }
    }
}
