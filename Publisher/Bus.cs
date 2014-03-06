using System.Collections.Generic;
using Core;
using Messages.Markers;

namespace Publisher
{
    public class Bus : IPublishEvents
    {
        private IBroadcastEvents broadcaster;

        public Bus(IBroadcastEvents broadcaster)
        {
            this.broadcaster = broadcaster;
        }

        public void Publish(IEvent e)
        {
            broadcaster.Broadcasts(e);
        }

        public void Publish(List<IEvent> es)
        {
            broadcaster.Broadcasts(es);
        }
        
    }
}
