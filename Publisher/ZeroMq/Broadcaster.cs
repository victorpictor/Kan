using System.Collections.Generic;
using Messages.Markers;
using NetMQ;

namespace Publisher.ZeroMq
{
    public class Broadcaster: IBroadcastEvents
    {
        private NetMQContext ctx;
        private NetMQSocket server;

        public Broadcaster()
        {
            ctx = NetMQContext.Create();
            server = ctx.CreatePublisherSocket();
            server.Bind("tcp://127.0.0.1:5002");
        }

        private void Broadcasts(string message)
        {
            server.Send(message);
            
        }

        public void Broadcasts(IEvent message)
        {
            Broadcasts(new Serializer().Serialize(message));
        }

        public void Broadcasts(List<IEvent> messages)
        {
            Broadcasts(new Serializer().Serialize(messages));
        }
    }
}