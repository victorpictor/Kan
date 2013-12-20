using Messages.Markers;

namespace Messages.Collection
{
    public class UserStoryRemoved: IEvent
    {
        public int Id;

        public UserStoryRemoved(int id)
        {
            Id = id;
        }
    }
}