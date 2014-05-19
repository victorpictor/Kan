using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NetMQ;

namespace Publisher.Tests.ZeroMq
{
    public class Subscriber
    {
        private readonly List<string> subscribeTo = new List<string>();

        private NetMQContext context;
        private NetMQSocket server;

        public Subscriber(params string[] messageKeys)
        {
            if (messageKeys != null && messageKeys.Length > 0)
                subscribeTo.AddRange(messageKeys.ToList());

            context = NetMQContext.Create();
            server = context.CreateSubscriberSocket();
            server.Connect("tcp://127.0.0.1:5003");

            subscribeTo.ForEach(server.Subscribe);

            Thread.Sleep(500);
        }

        ~Subscriber()
        {
            server.Dispose();
            context.Dispose();
        }

        public object Receive(out bool more)
        {
            var r = server.ReceiveString(out more);

            if (more)
                return server.ReceiveString(out more);
            
            return r;
        }
    }
}