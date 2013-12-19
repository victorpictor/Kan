using Messages.Markers;

namespace Messages.Queue
{
    public class UserStoryQueued: IEvent
    {
        public int Id;

        public UserStoryQueued(int id)
        {
            Id = id;
        }
    }
}