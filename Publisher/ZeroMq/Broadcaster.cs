using System.Collections.Generic;
using Messages.Markers;
using ZMQ;

namespace Publisher.ZeroMq
{
    public class Broadcaster: IBroadcastEvents
    {
        private void Broadcasts(byte[] message)
        {
            using (var context = new Context(1))
            using (var socket = context.Socket(SocketType.PUB))
            {
                socket.Connect("ipc:///kan/events");

                socket.Send(message);
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