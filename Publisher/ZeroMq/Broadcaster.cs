using System.Collections.Generic;
using Messages.Markers;
using NetMQ;

namespace Publisher.ZeroMq
{
    public class Broadcaster: IBroadcastEvents
    {
        private void Broadcasts(byte[] message)
        {
            using (var ctx = NetMQContext.Create())
            {
                using (var server = ctx.CreatePublisherSocket())
                {
                    server.Bind("tcp://127.0.0.1:5556");

                    server.Send(message);
                }
            }
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