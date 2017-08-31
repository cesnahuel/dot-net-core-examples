using System;
using System.Threading.Tasks;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using Google.Protobuf;
using NetMQHelloWorld.Protobuf;


namespace NetMQHelloWorld
{
    class Server
    {
        public static async Task<int> Main(string[] args)
        {
            if (args.Length != 1)
            {
                await Console.Error.WriteLineAsync("Please specify the server name!");
                return 1;
            }
            string serverName = args[0];
            using (ResponseSocket server = new ResponseSocket())
            {
                await Console.Out.WriteLineAsync($"Starting server '{serverName}'");
                Message message = new Message();
                message.Name = serverName;

                server.Bind("tcp://localhost:5556");
                while (true)
                {
                    byte[] reply = server.ReceiveFrameBytes();
                    Message replyMsg = Message.Parser.ParseFrom(reply);

                    await Console.Out.WriteLineAsync($"{replyMsg.ShowString()}");

                    message.Timestamp = DateTime.UtcNow.Ticks;
                    message.Body = "thank you";

                    await Console.Out.WriteLineAsync($"{message.ShowString()}");
                    byte[] serverMsg = message.ToByteArray();
                    server.SendFrame(serverMsg);

                    //Thread.Sleep(5000);
                }
            }
        }
    }
}
