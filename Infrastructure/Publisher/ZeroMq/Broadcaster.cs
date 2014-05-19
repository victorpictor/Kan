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
            server.Bind("tcp://127.0.0.1:5003");
        }

        private void Broadcasts(string name, string message)
        {
            server.SendMessage(new NetMQMessage(new[]{new NetMQFrame(name), new NetMQFrame(message)}));
        }

        public void Broadcasts(IEvent message)
        {
            Broadcasts(message.GetType().Name, new Serializer().Serialize(message));
        }

        public void Broadcasts(List<IEvent> messages)
        {
            messages.ForEach(Broadcasts);
        }
    }
}