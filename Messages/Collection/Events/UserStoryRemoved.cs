using Messages.Markers;

namespace Messages.Collection.Events
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