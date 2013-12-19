using Messages.Markers;

namespace Messages.Queue
{
    public class QueueCreated : IEvent
    {
        public int Id;
        public string Name;
        public int WipLimit;

        public QueueCreated(int id, string name, int wipLimit)
        {
            Id = id;
            Name = name;
            WipLimit = wipLimit;
        }
    }
}