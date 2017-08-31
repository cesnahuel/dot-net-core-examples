using System;
using System.Threading.Tasks;
using System.IO;


namespace NetMQHelloWorld
{
    class Client
    {
        public static async Task<int> Main(string[] args)
        {
            await Console.Out.WriteLineAsync("Hello World!");
            return 0;
        }
    }
}
