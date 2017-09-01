using System;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Text;


namespace NetMQHelloWorldThreads
{
    sealed class Client
    {
        private readonly string clientName;

        public Client(string clientName)
        {
            this.clientName = clientName;
        }

        public Task RunAsync() => Task.Run(() =>
        {
            using (RequestSocket client = new RequestSocket())
            {
                Console.WriteLine($"Startig client {clientName}");

                client.Connect("tcp://localhost:5556");
                while (true)
                {
                    byte[] message = Encoding.Unicode.GetBytes($"Hello from client {clientName} on {DateTime.Now.ToString("HH:mm:ss.fff")}");
                    client.SendFrame(message);
                    string reply = client.ReceiveFrameString(Encoding.Unicode);
                    Console.WriteLine($"Client: received from server '{reply}' running on thread id {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(5000);
                }
            }
        });
    }
}
