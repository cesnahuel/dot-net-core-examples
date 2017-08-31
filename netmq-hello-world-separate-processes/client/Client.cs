using System;
using System.Threading.Tasks;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using Google.Protobuf;
using NetMQHelloWorld.Protobuf;


namespace NetMQHelloWorld
{
    class Client
    {
        public static async Task<int> Main(string[] args)
        {
            if (args.Length != 1)
            {
                await Console.Error.WriteLineAsync("Please specify the client name!");
                return 1;
            }
            string clientName = args[0];
            using (RequestSocket client = new RequestSocket())
            {
                await Console.Out.WriteLineAsync($"Starting client '{clientName}'");
                Message message = new Message();
                message.Name = clientName;

                client.Connect("tcp://localhost:5556");
                while (true)
                {
                    message.Timestamp = DateTime.UtcNow.Ticks;
                    message.Body = "update received";

                    byte[] clientMsg = message.ToByteArray();
                    client.SendFrame(clientMsg);
                    await Console.Out.WriteLineAsync($"{message.ShowString()}");

                    byte[] reply = client.ReceiveFrameBytes();
                    Message replyMsg = Message.Parser.ParseFrom(reply);

                    await Console.Out.WriteLineAsync($"{replyMsg.ShowString()}");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
