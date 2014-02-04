using Messages.Markers;

namespace Messages.Collection.Events
{
    public class CollectionCreated : IEvent
    {
        public string Id;
        public string Name;
        public int WipLimit;

        public CollectionCreated(string id, string name, int wipLimit)
        {
            Id = id;
            Name = name;
            WipLimit = wipLimit;
        }
    }
}