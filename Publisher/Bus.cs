using System.Collections.Generic;
using Core;
using Messages.Markers;

namespace Publisher
{
    public class Bus : IPublishEvents
    {
        public void Publish(IEvent e)
        {
        }

        public void Publish(List<IEvent> es)
        {
        }
    }
}
