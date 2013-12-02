using System.Collections.Generic;
using Messages.Markers;

namespace Messages
{
    public interface IPublishEvents
    {
        void Publish(IEvent e);
        void Publish(List<IEvent> es);
    }
}