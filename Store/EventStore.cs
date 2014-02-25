using System.Collections.Generic;
using Core;
using Messages.Markers;

namespace Store
{
    public class EventStore : IEventStore
    {
        public List<IEvent> GetStream(Messages.Identities.IIdentity identity)
        {
            return new List<IEvent>();
        }

        public void AppendToStream(Messages.Identities.IIdentity identity, List<IEvent> changes)
        {
        }
    }
}
