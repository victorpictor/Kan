using System.Collections.Generic;
using Messages.Markers;

namespace Core
{
    public interface IPublishEvents
    {
        void Publish(IEvent e);
        void Publish(List<IEvent> es);
    }
}