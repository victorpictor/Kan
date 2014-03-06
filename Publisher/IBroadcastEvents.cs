using System.Collections.Generic;
using Messages.Markers;

namespace Publisher
{
    public interface IBroadcastEvents
    {
        void Broadcasts(IEvent message);
        void Broadcasts(List<IEvent> message);
    }
}