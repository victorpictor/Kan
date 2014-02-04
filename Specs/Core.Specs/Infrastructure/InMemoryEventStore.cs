using System.Collections.Generic;
using System.Linq;
using Messages.Identities;
using Messages.Markers;

namespace Core.Specs.Infrastructure
{
    public class InMemoryEventStore: IEventStore
    {
        private Dictionary<string, List<IEvent>> stream = new Dictionary<string, List<IEvent>>();

        public int TimesItGotStream = 0;
        public int TimesItAppendedToStream = 0;

        public void  SetUpTheStream(IIdentity identity, params IEvent[] events)
        {
            stream.Add(identity.Get(),events.ToList());
        }

        public List<IEvent> GetStream(IIdentity identity)
        {
            TimesItGotStream ++;
            return stream[identity.Get()];
        }

        public void AppendToStream(IIdentity identity, List<IEvent> changes)
        {
            TimesItAppendedToStream ++;
            stream[identity.Get()].AddRange(changes);
        }

        public int EventsInStream(IIdentity identity)
        {
            return stream[identity.Get()].Count;
        }

    }
}