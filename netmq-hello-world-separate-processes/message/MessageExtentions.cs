using System;


namespace NetMQHelloWorld.Protobuf
{
    public static class MessageExtentions
    {
        public static string ShowString(this Message msg)
        {
            DateTime dt = new DateTime(msg.Timestamp);
            return $"{dt.ToString("HH:mm:ss.fff")} {msg.Name}: {msg.Body}";
        }
    }
}
