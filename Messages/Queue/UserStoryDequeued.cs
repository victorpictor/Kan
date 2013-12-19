using Messages.Markers;

namespace Messages.Queue
{
    public class UserStoryDequeued: IEvent
    {
        public int Id;

        public UserStoryDequeued(int id)
        {
            Id = id;
        }
    }
}