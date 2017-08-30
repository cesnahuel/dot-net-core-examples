using System;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;


namespace NetMQHelloWorldThreads
{
    sealed class Server
    {
        public Task Run() => Task.Run(() => {
            using (ResponseSocket server = new ResponseSocket())
            {
                Console.WriteLine("Startig server");

                server.Bind("tcp://localhost:5556");

                while (true) {
                    string request = server.ReceiveFrameString();
                    Console.WriteLine($"From Client: '{request}' running on thead id {Thread.CurrentThread.ManagedThreadId}");
                    server.SendFrame("response back!");
                }
            }
        });
    }
}
