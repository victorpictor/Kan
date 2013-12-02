using System.Collections.Generic;
using Messages.Identities;
using Messages.Markers;

namespace Core
{
    public interface IEventStore
    {
        List<IEvent> GetStream(IIdentity identity);
        
        void AppendToStream(IIdentity identity, List<IEvent> changes);
    }
}