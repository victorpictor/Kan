using Messages.Markers;

namespace Messages.Collection
{
    public class UserStoryAdded: IEvent
    {
        public int Id;

        public UserStoryAdded(int id)
        {
            Id = id;
        }
    }
}