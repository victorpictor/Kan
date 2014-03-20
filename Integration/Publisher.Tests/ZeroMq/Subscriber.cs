using System.Collections.Generic;
using System.Linq;
using NetMQ;

namespace Publisher.Tests.ZeroMq
{
    public class Subscriber
    {
        private readonly List<string> subscribeTo = new List<string>();

        public Subscriber(params string[] messageKeys)
        {
            if (messageKeys!= null && messageKeys.Length > 0)
                subscribeTo.AddRange(messageKeys.ToList());
            
        }

        private object Receive(out bool more)
        {
            using (var ctx = NetMQContext.Create())
            {
                using (var server = ctx.CreateSubscriberSocket())
                {
                    subscribeTo.ForEach(server.Subscribe);

                    server.Bind("tcp://127.0.0.1:5556");

                    return server.Receive(out more);
                }
            }
        } 
    }
}