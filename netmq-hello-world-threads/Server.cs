using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;


namespace NetMQHelloWorldThreads
{
    sealed class Server
    {
        public Task RunAsync() => Task.Run(() => {
            using (ResponseSocket server = new ResponseSocket())
            {
                Console.WriteLine("Startig server");

                server.Bind("tcp://localhost:5556");
                while (true) {
                    string request = server.ReceiveFrameString(Encoding.Unicode);
                    Console.WriteLine($"Server: received '{request}' running on thread id {Thread.CurrentThread.ManagedThreadId}");
                    byte[] message = Encoding.Unicode.GetBytes($"Hi back! on {DateTime.Now.ToString("HH:mm:ss.fff")}");
                    server.SendFrame(message);
                }
            }
        });
    }
}
