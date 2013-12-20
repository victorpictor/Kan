using Messages.Markers;

namespace Messages.Collection
{
    public class CollectionCreated : IEvent
    {
        public int Id;
        public string Name;
        public int WipLimit;

        public CollectionCreated(int id, string name, int wipLimit)
        {
            Id = id;
            Name = name;
            WipLimit = wipLimit;
        }
    }
}